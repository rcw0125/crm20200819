using NF.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NF.EF.Model;
using NF.Framework;
using NF.Framework.DTO;
using System.Linq.Expressions;

namespace NF.Bussiness.Service
{
    public class WorkFlowService : BaseService, IWorkFlowService
    {
        private DbSet<TMB_FLOWINFO> _FlowInfo;
        private DbSet<TMB_FLOWSTEP> _FlowStep;
        private DbSet<TS_USER> _User;
        private DbSet<TS_ROLE> _Role;

        public WorkFlowService(DbContext context) : base(context)
        {
            _FlowInfo = context.Set<TMB_FLOWINFO>();
            _FlowStep = context.Set<TMB_FLOWSTEP>();
            _User = context.Set<TS_USER>();
            _Role = context.Set<TS_ROLE>();
        }

        /// <summary>
        /// 流程信息列表（分页）
        /// </summary>
        /// <param name="fiDto"></param>
        /// <returns></returns>
        public PageResult<TMB_FLOWINFO> FlowInfos(TMB_FLOWINFODTO fiDto)
        {
            Expression<Func<TMB_FLOWINFO, bool>> where = null;
            where = where.And<TMB_FLOWINFO>(x => x.N_STATUS == 1);

            if (fiDto.N_TYPE != null)
            {
                where = where.And<TMB_FLOWINFO>(x => x.N_TYPE == fiDto.N_TYPE);
            }

            Expression<Func<TMB_FLOWINFO, int>> order = null;
            order = t => t.N_SORT ?? 1;

            return QueryPage<TMB_FLOWINFO, int>(where, fiDto.BasePage.PageSize, fiDto.BasePage.PageIndex, order);
        }

        /// <summary>
        /// 流程信息新增
        /// </summary>
        /// <param name="fiDto"></param>
        public void FlowInfoInsert(TMB_FLOWINFODTO fiDto)
        {
            try
            {
                TMB_FLOWINFO fiEf = AutoMapper.Mapper.Map<TMB_FLOWINFO>(fiDto);
                fiEf.C_ID = Guid.NewGuid().ToString();
                fiEf.N_STATUS = 1;
                _FlowInfo.Add(fiEf);
                List<TMB_STEPINFODTO> siDto = fiDto.StepInfos.Where(x => x.IsCheck == true).ToList();
                foreach (var item in siDto)
                {
                    TMB_FLOWSTEP fsEf = new TMB_FLOWSTEP()
                    {
                        C_FLOW_ID = fiEf.C_ID,
                        C_STEP_ID = item.C_ID,
                        //N_TYPE = short.Parse(item.N_Type.ToString()),
                        N_STATUS = short.Parse(item.N_STATUS.ToString()),
                        N_SORT = short.Parse(item.N_SORT.ToString()),
                        C_EMP_ID = fiEf.C_EMP_ID,
                        C_EMP_NAME = fiEf.C_EMP_NAME,
                        D_MOD_DT = fiEf.D_MOD_DT,
                        C_APPROVE_ID = item.C_NAME
                    };
                    _FlowStep.Add(fsEf);
                }
                this.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 验证流程信息是否重复
        /// </summary>
        /// <param name="fiDto"></param>
        /// <returns></returns>
        public bool ValidateIsRepeat(TMB_FLOWINFODTO fiDto)
        {
            Expression<Func<TMB_FLOWINFO, bool>> where = null;
            where = where.And(x => x.N_STATUS == 1);
            where = where.And(x => x.C_NAME.Equals(fiDto.C_NAME));


            TMB_FLOWINFO ef = _FlowInfo.FirstOrDefault(
                x => x.C_NAME.Equals(fiDto.C_NAME)
                && x.N_STATUS == 1);
            bool result = false;
            if (ef.Equals(null))
                result = true;
            return result;
        }

        /// <summary>
        /// 验证流程信息是否重复
        /// </summary>
        /// <param name="fiDto"></param>
        /// <param name="type">操作方式1修改 0新增</param>
        /// <returns></returns>
        public bool ValidateIsRepeat(TMB_FLOWINFODTO fiDto, int type)
        {
            TMB_FLOWINFO ef = null;
            try
            {
                Expression<Func<TMB_FLOWINFO, bool>> where = null;
                where = where.And(x => x.N_STATUS == 1);
                where = where.And(x => x.C_NAME.Equals(fiDto.C_NAME));
                if (type == 1)
                {
                    where = where.And(x => x.C_ID != fiDto.C_ID);
                }
                ef = _FlowInfo.FirstOrDefault(where);
            }
            catch (Exception e)
            { throw e; }
            bool result = false;
            if (ef == null)
                result = true;
            return result;
        }

        /// <summary>
        /// 获取流程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TMB_FLOWINFODTO GetFlowInfo(string id)
        {
            TMB_FLOWINFO fiEf = _FlowInfo.Find(id);
            TMB_FLOWINFODTO fiDto = AutoMapper.Mapper.Map<TMB_FLOWINFODTO>(fiEf);
            fiDto.StepInfos = GetStepInfos();
            var news = from flowStep in _FlowStep
                       where flowStep.C_FLOW_ID.Equals(id)
                       select new TMB_STEPINFODTO
                       {
                           C_ID = flowStep.C_STEP_ID,
                           C_APPROVE_ID = flowStep.C_APPROVE_ID,
                           N_SORT = flowStep.N_SORT,
                           IsCheck = true,
                       };
            if (news.Count() > 0)
            {
                for (int i = 0; i < fiDto.StepInfos.Count; i++)
                {
                    var sis = news.ToList().FirstOrDefault(x => x.C_ID.Equals(fiDto.StepInfos[i].C_ID));
                    if (sis != null)
                    {
                        fiDto.StepInfos[i].IsCheck = true;
                        fiDto.StepInfos[i].N_SORT = sis.N_SORT;
                    }
                }
            }
            return fiDto;
        }

        /// <summary>
        /// 流程信息修改
        /// </summary>
        /// <param name="fiDto"></param>
        public void FlowInfoUpdate(TMB_FLOWINFODTO fiDto)
        {
            try
            {
                TMB_FLOWINFO fiEf = AutoMapper.Mapper.Map<TMB_FLOWINFO>(fiDto);
                Update(fiEf);
                var efsDel = _FlowStep.Where(x => x.C_FLOW_ID.Equals(fiEf.C_ID)).ToList();
                Delete<TMB_FLOWSTEP>(efsDel);

                List<TMB_STEPINFODTO> siDto = fiDto.StepInfos.Where(x => x.IsCheck == true).ToList();
                foreach (var item in siDto)
                {
                    TMB_FLOWSTEP fsEf = new TMB_FLOWSTEP()
                    {
                        C_FLOW_ID = fiEf.C_ID,
                        C_STEP_ID = item.C_ID,
                        //N_TYPE = short.Parse(item.N_Type.ToString()),
                        N_STATUS = short.Parse(item.N_STATUS.ToString()),
                        N_SORT = short.Parse(item.N_SORT.ToString()),
                        C_EMP_ID = fiEf.C_EMP_ID,
                        C_EMP_NAME = fiEf.C_EMP_NAME,
                        D_MOD_DT = fiEf.D_MOD_DT,
                        C_APPROVE_ID = item.C_NAME
                    };
                    _FlowStep.Add(fsEf);
                }
                this.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 流程信息删除
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="user"></param>
        public void FlowInfoDel(string ids, CurrentUser user)
        {
            List<TMB_FLOWINFO> efs = new List<TMB_FLOWINFO>();
            string[] arr = ids.Split(',');
            try
            {
                foreach (var i in arr)
                {
                    TMB_FLOWINFO ef = new TMB_FLOWINFO();
                    ef = this.Find<TMB_FLOWINFO>(i);
                    ef.N_STATUS = 0;
                    ef.C_EMP_ID = user.Id;
                    ef.C_EMP_NAME = user.Name;
                    efs.Add(ef);
                }

                if (efs.Count > 0)
                {
                    foreach (var i in efs)
                    {
                        Update(i);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        ///角色生成步骤信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<TMB_STEPINFODTO> GetStepInfos()
        {
            var list = _Role.Where(x => x.N_STATUS == 1).ToList();
            List<TMB_STEPINFODTO> steps = new List<TMB_STEPINFODTO>();
            foreach (var item in list)
            {

                TMB_STEPINFODTO newEf = new TMB_STEPINFODTO();
                newEf.C_ID = item.C_ID;
                newEf.C_NAME = item.C_NAME;
                newEf.N_STATUS = item.N_STATUS;
                newEf.C_REMARK = item.C_NAME;
                newEf.C_DESC = item.C_NAME;
                if (item.C_CODE.IndexOf('-') < 0)
                    steps.Add(newEf);
            }
            return steps;
        }


    }
}
