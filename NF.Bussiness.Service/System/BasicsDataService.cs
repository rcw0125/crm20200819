using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NF.Bussiness.Interface;
using NF.EF.Model;
using NF.Framework;
using NF.Framework.DTO;
using System.Data.Entity;
using System.Linq.Expressions;
using NF.Web.Core;
using System.Web.Mvc;

namespace NF.Bussiness.Service
{
    public partial class BasicsDataService : BaseService, IBasicsDataService
    {
        private DbSet<TMB_AREAPLAN> _AreaPlan;
        private DbSet<TS_DIC> _Dic;
        private DbSet<TMB_COMDIFF> _ComDiff;
        private DbSet<TS_CUSTFILE> _CustFile;
        private DbSet<TS_CUSTADDR> _CustAddr;
        private DbSet<TMC_CUST_REPORT> _CustReport;
        private DbSet<TMC_EVAL_ITEM> _EvalItem;
        private DbSet<TMC_CUST_EVAL> _CustEval;
        private DbSet<TMC_CUST_EVAL_SUB> _CustEvalSub;
        private DbSet<TS_CUSTOTCOMPANY> _CustTot;
        private DbSet<TS_FUNCTION> _Func;
        private DbSet<TS_ROLE> _Role;
        private DbSet<TS_USER_FUN> _UserFunc;
        private DbSet<TS_DEPT> _Dept;
        private DbSet<TS_USER_DEPT> _UserDept;
        private DbSet<TS_USER_ROLE> _UserRole;
        private DbSet<TS_MENU_FUN> _MenuFun;
        private DbSet<TS_BUTTON> _Button;
        private DbSet<TS_BUTTON_FUN> _ButtonFun;
        private DbSet<TS_ROLE_FUN> _RoleFun;
        private DbSet<TMB_AREAMAX> _AreaMax;
        private DbSet<TB_MATRL_MAIN> _MatrlMain;

        public BasicsDataService(DbContext context) : base(context)
        {
            _AreaPlan = context.Set<TMB_AREAPLAN>();
            _Dic = context.Set<TS_DIC>();
            _ComDiff = context.Set<TMB_COMDIFF>();
            _CustFile = context.Set<TS_CUSTFILE>();
            _CustAddr = context.Set<TS_CUSTADDR>();
            _CustReport = context.Set<TMC_CUST_REPORT>();
            _EvalItem = context.Set<TMC_EVAL_ITEM>();
            _CustEval = context.Set<TMC_CUST_EVAL>();
            _CustEvalSub = context.Set<TMC_CUST_EVAL_SUB>();
            _CustTot = context.Set<TS_CUSTOTCOMPANY>();
            _Func = context.Set<TS_FUNCTION>();
            _Role = context.Set<TS_ROLE>();
            _UserFunc = context.Set<TS_USER_FUN>();
            _Dept = context.Set<TS_DEPT>();
            _UserDept = context.Set<TS_USER_DEPT>();
            _UserRole = context.Set<TS_USER_ROLE>();
            _MenuFun = context.Set<TS_MENU_FUN>();
            _ButtonFun = context.Set<TS_BUTTON_FUN>();
            _RoleFun = context.Set<TS_ROLE_FUN>();
            _AreaMax = context.Set<TMB_AREAMAX>();
            _Button = context.Set<TS_BUTTON>();
            _MatrlMain = context.Set<TB_MATRL_MAIN>();
        }

        /// <summary>
        /// 获取完成完工差列表
        /// </summary>
        /// <param name="cdDto"></param>
        /// <returns></returns>
        public PageResult<TMB_COMDIFF> GetComDiffs(TMB_COMDIFFDTO cdDto)
        {
            Expression<Func<TMB_COMDIFF, bool>> where = null;
            where = where.And<TMB_COMDIFF>(x => x.N_STATUS == 1);

            if (cdDto.Start != DateTime.MinValue)
            {
                DateTime startTime = Convert.ToDateTime(cdDto.Start.ToString("yyyy-MM-dd"));
                where = where.And<TMB_COMDIFF>(x => x.D_MOD_DT > startTime);
            }

            if (cdDto.End != DateTime.MinValue)
            {
                DateTime endTime = Convert.ToDateTime(cdDto.End.AddDays(1).ToString("yyyy-MM-dd"));
                where = where.And<TMB_COMDIFF>(x => x.D_MOD_DT < endTime);
            }

            Expression<Func<TMB_COMDIFF, DateTime>> order = null;
            order = t => t.D_MOD_DT;

            return QueryPage<TMB_COMDIFF, DateTime>(where, cdDto.BasePage.PageSize, cdDto.BasePage.PageIndex, order);
        }

        /// <summary>
        /// 获取合同工差
        /// </summary>
        /// <param name="cdDto"></param>
        /// <returns></returns>
        public List<TMB_COMDIFF> GetComDiffs()
        {
            return _ComDiff.ToList();
        }

        /// <summary>
        /// 合同工差新增
        /// </summary>
        /// <param name="cdDto"></param>
        public void ComDiffInsert(TMB_COMDIFFDTO cdDto)
        {
            TMB_COMDIFF ef = AutoMapper.Mapper.Map<TMB_COMDIFF>(cdDto);
            Insert(ef);
        }

        /// <summary>
        /// 合同工差修改
        /// </summary>
        /// <param name="cdDto"></param>
        public void ComDiffUpdate(TMB_COMDIFFDTO cdDto)
        {
            TMB_COMDIFF ef = AutoMapper.Mapper.Map<TMB_COMDIFF>(cdDto);
            Update(ef);
        }

        /// <summary>
        /// 合同工差删除
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="user"></param>
        public void ComDiffDel(string ids, CurrentUser user)
        {
            List<TMB_COMDIFF> efs = new List<TMB_COMDIFF>();
            string[] arr = ids.Split(',');
            try
            {
                foreach (var i in arr)
                {
                    TMB_COMDIFF ef = new TMB_COMDIFF();
                    ef = this.Find<TMB_COMDIFF>(i);
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
        /// 验证合同工差是否重复
        /// </summary>
        /// <param name="cdDto"></param>
        /// <returns></returns>
        public bool ValidateIsRepeat(TMB_COMDIFFDTO cdDto)
        {
            TMB_COMDIFF ef = _ComDiff.FirstOrDefault(
                x => x.D_MIN == cdDto.D_MIN
                && x.D_MAX == cdDto.D_MAX
                && x.C_ID != cdDto.C_ID
                && x.N_STATUS == 1);
            bool result = false;
            if (ef == null)
                result = true;
            return result;
        }

        /// <summary>
        /// 验证合同工差是否重复
        /// </summary>
        /// <param name="cdDto"></param>
        /// <param name="type">操作方式1修改 0新增</param>
        /// <returns></returns>
        public bool ValidateIsRepeat(TMB_COMDIFFDTO cdDto, int type)
        {
            Expression<Func<TMB_COMDIFF, bool>> where = null;
            where = where.And(x => x.N_STATUS == 1);

            if (cdDto.D_MAX != null)
            {
                where = where.And(x => x.D_MAX == cdDto.D_MAX);
            }

            if (cdDto.D_MIN != null)
            {
                where = where.And(x => x.D_MIN == cdDto.D_MIN);
            }

            if (type == 1)
            {
                where = where.And(x => x.C_ID != cdDto.C_ID);
            }

            TMB_COMDIFF ef = _ComDiff.FirstOrDefault(where);
            bool result = false;
            if (ef == null)
                result = true;
            return result;
        }

        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <param name="dicDto"></param>
        /// <returns></returns>
        public PageResult<TS_DIC> GetDics(TS_DICDTO dicDto)
        {
            Expression<Func<TS_DIC, bool>> where = null;
            where = where.And<TS_DIC>(x => x.N_STATUS == 1);

            if (!string.IsNullOrWhiteSpace(dicDto.C_TYPECODE))
            {
                dicDto.C_TYPECODE = dicDto.C_TYPECODE.Trim();
                where = where.And<TS_DIC>(x => x.C_TYPECODE.Contains(dicDto.C_TYPECODE));
            }

            if (!string.IsNullOrWhiteSpace(dicDto.C_TYPENAME))
            {
                dicDto.C_TYPENAME = dicDto.C_TYPENAME.Trim();
                where = where.And<TS_DIC>(x => x.C_TYPENAME.Contains(dicDto.C_TYPENAME));
            }

            Expression<Func<TS_DIC, string>> order = null;
            order = t => t.C_TYPECODE ?? "";

            return QueryPage<TS_DIC, string>(where, dicDto.BasePage.PageSize, dicDto.BasePage.PageIndex, order);
        }

        /// <summary>
        /// 数据字典新增
        /// </summary>
        /// <param name="dicDto"></param>
        public void DicInsert(TS_DICDTO dicDto)
        {
            TS_DIC ef = AutoMapper.Mapper.Map<TS_DIC>(dicDto);
            Insert(ef);
        }

        /// <summary>
        /// 验证合同工差是否重复
        /// </summary>
        /// <param name="dicDto"></param>
        /// <returns></returns>
        public bool ValidateIsRepeat(TS_DICDTO dicDto)
        {
            TS_DIC ef = _Dic.FirstOrDefault(
                x => x.C_TYPECODE.Equals(dicDto.C_TYPECODE)
                && x.C_TYPENAME.Equals(dicDto.C_TYPENAME)
                && x.C_DETAILCODE.Equals(dicDto.C_DETAILCODE)
                && x.C_DETAILNAME.Equals(dicDto.C_DETAILNAME)
                && x.C_ID != dicDto.C_ID);
            bool result = false;
            if (ef == null)
                result = true;
            return result;
        }

        /// <summary>
        /// 验证合同工差是否重复
        /// </summary>
        /// <param name="dicDto"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool ValidateIsRepeat(TS_DICDTO dicDto, int type)
        {
            Expression<Func<TS_DIC, bool>> where = null;

            where = where.And(x => x.N_STATUS == 1);

            if (!string.IsNullOrWhiteSpace(dicDto.C_TYPECODE))
            {
                where = where.And(x => x.C_TYPECODE.Equals(dicDto.C_TYPECODE));
            }

            if (!string.IsNullOrWhiteSpace(dicDto.C_TYPENAME))
            {
                where = where.And(x => x.C_TYPENAME.Equals(dicDto.C_TYPENAME));
            }

            if (!string.IsNullOrWhiteSpace(dicDto.C_DETAILCODE))
            {
                where = where.And(x => x.C_DETAILCODE.Equals(dicDto.C_DETAILCODE));
            }

            if (!string.IsNullOrWhiteSpace(dicDto.C_DETAILNAME))
            {
                where = where.And(x => x.C_DETAILNAME.Equals(dicDto.C_DETAILNAME));
            }

            if (type == 1)
            {
                where = where.And(x => x.C_ID != dicDto.C_ID);
            }

            TS_DIC ef = _Dic.FirstOrDefault(where);
            bool result = false;
            if (ef == null)
                result = true;
            return result;
        }

        /// <summary>
        /// 数据字典修改
        /// </summary>
        /// <param name="dicDto"></param>
        public void DicUpdate(TS_DICDTO dicDto)
        {
            TS_DIC ef = AutoMapper.Mapper.Map<TS_DIC>(dicDto);
            Update(ef);
        }

        /// <summary>
        /// 数据字典删除
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="user"></param>
        public void DicDel(string ids, CurrentUser user)
        {
            List<TS_DIC> efs = new List<TS_DIC>();
            string[] arr = ids.Split(',');
            try
            {
                foreach (var i in arr)
                {
                    TS_DIC ef = new TS_DIC();
                    ef = this.Find<TS_DIC>(i);
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
        /// 部门列表
        /// </summary>
        /// <param name="dDto"></param>
        /// <returns></returns>
        public PageResult<TS_DEPT> GetDepts(TS_DEPTDTO dDto)
        {
            Expression<Func<TS_DEPT, bool>> where = null;
            where = where.And<TS_DEPT>(x => x.N_STATUS == 1);

            if (!string.IsNullOrWhiteSpace(dDto.C_CODE))
            {
                where = where.And<TS_DEPT>(x => x.C_CODE.Contains(dDto.C_CODE));
            }

            if (!string.IsNullOrWhiteSpace(dDto.C_NAME))
            {
                where = where.And<TS_DEPT>(x => x.C_NAME.Contains(dDto.C_NAME));
            }

            Expression<Func<TS_DEPT, string>> order = null;
            order = t => t.C_CODE ?? "";

            return QueryPage<TS_DEPT, string>(where, dDto.BasePage.PageSize, dDto.BasePage.PageIndex, order);
        }

        /// <summary>
        /// 客户档案列表
        /// </summary>
        /// <param name="cfDto"></param>
        /// <returns></returns>
        public PageResult<TS_CUSTFILE> GetCustFiles(TS_CUSTFILEDTO cfDto)
        {
            Expression<Func<TS_CUSTFILE, bool>> where = null;
            where = where.And<TS_CUSTFILE>(x => x.N_STATUS == 1);

            if (cfDto.N_LEVEL != 0)
            {
                where = where.And<TS_CUSTFILE>(x => x.N_LEVEL == cfDto.N_LEVEL);
            }

            if (!string.IsNullOrWhiteSpace(cfDto.C_NO))
            {
                where = where.And<TS_CUSTFILE>(x => x.C_NO.Equals(cfDto.C_NO));
            }

            if (!string.IsNullOrWhiteSpace(cfDto.C_NAME))
            {
                where = where.And<TS_CUSTFILE>(x => x.C_NAME.Contains(cfDto.C_NAME));
            }

            Expression<Func<TS_CUSTFILE, string>> order = null;
            order = t => t.C_NO ?? "";
            return QueryPage<TS_CUSTFILE, string>(where, cfDto.BasePage.PageSize, cfDto.BasePage.PageIndex, order);
        }

        /// <summary>
        /// 修改客户档案
        /// </summary>
        /// <param name="cfDto"></param>
        public void CustFileUpdate(TS_CUSTFILEDTO cfDto)
        {
            TS_CUSTFILE ef = AutoMapper.Mapper.Map<TS_CUSTFILE>(cfDto);
            Update(ef);
        }

        /// <summary>
        /// 获取客户档案收货地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<TS_CUSTADDR> GetCustAddrs(string id)
        {
            return _CustAddr.Where(x => x.C_CUST_ID.Equals(id)).ToList();
        }

        /// <summary>
        /// 获取客户档案
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TS_CUSTFILE GetCustFile(string id)
        {
            return _CustFile.Where(x => x.C_ID.Equals(id)).FirstOrDefault();
        }

        /// <summary>
        /// 获取客户档案收货地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TS_CUSTADDR GetCustAddr(string id)
        {
            return _CustAddr.Where(x => x.C_CUST_ID.Equals(id) && x.N_ISDEFAULT == 0).FirstOrDefault();
        }

        /// <summary>
        /// 保存客户地址
        /// </summary>
        /// <param name="dto"></param>
        public void SaveCustAddr(TS_CUSTFILEDTO dto)
        {
            var custEf = _CustAddr.Where(x => x.C_CUST_ID.Equals(dto.C_ID));
            this.Delete<TS_CUSTADDR>(custEf);
            if (dto.CustAddrs != null && dto.CustAddrs.Count > 0)
            {
                foreach (var item in dto.CustAddrs)
                {
                    var ef = AutoMapper.Mapper.Map<TS_CUSTADDR>(item);
                    this.Insert(ef);
                }
            }
        }

        /// <summary>
        /// 获取客户开票信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<TS_CUSTOTCOMPANY> GetCustTots(string id)
        {
            return _CustTot.Where(x => x.C_CUST_ID.Equals(id)).ToList();
        }

        /// <summary>
        /// 保存客户开票信息
        /// </summary>
        /// <param name="dto"></param>
        public void SaveCustTot(TS_CUSTFILEDTO dto)
        {
            var custEf = _CustTot.Where(x => x.C_CUST_ID.Equals(dto.C_ID));
            this.Delete<TS_CUSTOTCOMPANY>(custEf);
            if (dto.CustTots != null && dto.CustTots.Count > 0)
            {
                foreach (var item in dto.CustTots)
                {
                    var ef = AutoMapper.Mapper.Map<TS_CUSTOTCOMPANY>(item);
                    this.Insert(ef);
                }
            }
        }

        /// <summary>
        /// 用户使用报告添加
        /// </summary>
        /// <param name="crDto"></param>
        public void CustReportInsert(TMC_CUST_REPORTDTO crDto)
        {
            TMC_CUST_REPORT ef = AutoMapper.Mapper.Map<TMC_CUST_REPORT>(crDto);
            Insert(ef);
        }

        /// <summary>
        /// 用户使用报告列表
        /// </summary>
        /// <param name="crDto"></param>
        /// <returns></returns>
        public PageResult<TMC_CUST_REPORT> GetCustReports(TMC_CUST_REPORTDTO crDto)
        {
            Expression<Func<TMC_CUST_REPORT, bool>> where = null;

            if (crDto.Start != DateTime.MinValue)
            {
                DateTime startTime = Convert.ToDateTime(crDto.Start.ToString("yyyy-MM-dd"));
                where = where.And<TMC_CUST_REPORT>(x => x.D_MOD_DT > startTime);
            }

            if (crDto.End != DateTime.MinValue)
            {
                DateTime endTime = Convert.ToDateTime(crDto.End.AddDays(1).ToString("yyyy-MM-dd"));
                where = where.And<TMC_CUST_REPORT>(x => x.D_MOD_DT < endTime);
            }

            if (!string.IsNullOrWhiteSpace(crDto.C_STL_GRD))
            {
                crDto.C_STL_GRD = crDto.C_STL_GRD.Trim();
                where = where.And<TMC_CUST_REPORT>(x => x.C_STL_GRD.Contains(crDto.C_STL_GRD));
            }

            if (!string.IsNullOrWhiteSpace(crDto.C_SPEC))
            {
                crDto.C_SPEC = crDto.C_SPEC.Trim();
                where = where.And<TMC_CUST_REPORT>(x => x.C_SPEC.Contains(crDto.C_SPEC));
            }

            Expression<Func<TMC_CUST_REPORT, DateTime>> order = null;
            order = t => t.D_MOD_DT;

            return QueryPage<TMC_CUST_REPORT, DateTime>(where, crDto.BasePage.PageSize, crDto.BasePage.PageIndex, order, false);
        }

        /// <summary>
        /// 用户使用报告
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TMC_CUST_REPORTDTO GetCustReport(string id)
        {
            return AutoMapper.Mapper.Map<TMC_CUST_REPORTDTO>(_CustReport.FirstOrDefault(x => x.C_ID.Equals(id)));
        }

        /// <summary>
        /// 获取评价项目
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<TMC_EVAL_ITEMDTO> GetEvalItems(string type = "0")
        {
            return MAPPING.ConvertEntityToDtoList<TMC_EVAL_ITEM, TMC_EVAL_ITEMDTO>(_EvalItem.Where(x => x.C_REMARK.Equals(type) && x.N_STATUS == 1).OrderBy(x => x.C_EMP_NAME).ToList());
        }

        /// <summary>
        /// 满意度调查新增
        /// </summary>
        /// <param name="ceDto"></param>
        public void CustEvalInsert(TMC_CUST_EVALDTO ceDto)
        {
            TMC_CUST_EVAL ef = AutoMapper.Mapper.Map<TMC_CUST_EVAL>(ceDto);
            try
            {
                Insert(ef);
                if (ceDto.EvalSubs != null && ceDto.EvalSubs.Count > 0)
                {
                    foreach (var item in ceDto.EvalSubs)
                    {
                        TMC_CUST_EVAL_SUB cesEf = AutoMapper.Mapper.Map<TMC_CUST_EVAL_SUB>(item);
                        cesEf.C_CUST_EVAL_ID = ceDto.C_ID;
                        Insert(cesEf);
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// 获取钢种大类
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetStdMain()
        {
            List<MatrlMain> list = this.ExcuteQuery<MatrlMain>(@"   SELECT DISTINCT T.c_prod_name  FROM TB_MATRL_MAIN T  WHERE T.c_prod_name   IS NOT NULL ").ToList();
            List<SelectListItem> listItem = new List<SelectListItem>();
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    SelectListItem items = new SelectListItem();
                    items.Text = item.C_PROD_NAME;
                    items.Value = item.C_PROD_NAME;
                    listItem.Add(items);
                }
            }
            return listItem;
        }

        /// <summary>
        /// 满意度调查列表
        /// </summary>
        /// <param name="ceDto"></param>
        /// <returns></returns>
        public PageResult<TMC_CUST_EVAL> GetCustEvals(TMC_CUST_EVALDTO ceDto)
        {
            Expression<Func<TMC_CUST_EVAL, bool>> where = null;


            if (ceDto.Start != DateTime.MinValue)
            {
                DateTime startTime = Convert.ToDateTime(ceDto.Start.ToString("yyyy-MM-dd"));
                where = where.And<TMC_CUST_EVAL>(x => x.D_MOD_DT > startTime);
            }

            if (ceDto.End != DateTime.MinValue)
            {
                DateTime endTime = Convert.ToDateTime(ceDto.End.AddDays(1).ToString("yyyy-MM-dd"));
                where = where.And<TMC_CUST_EVAL>(x => x.D_MOD_DT < endTime);
            }

            if (!string.IsNullOrWhiteSpace(ceDto.C_PROD ))
            {
                ceDto.C_PROD = ceDto.C_PROD.Trim();
                where = where.And<TMC_CUST_EVAL>(x => x.C_PROD.Contains(ceDto.C_PROD));
            }

            Expression<Func<TMC_CUST_EVAL, DateTime>> order = null;
            order = t => t.D_MOD_DT;

            return QueryPage<TMC_CUST_EVAL, DateTime>(where, ceDto.BasePage.PageSize, ceDto.BasePage.PageIndex, order);
        }

        /// <summary>
        /// 满意度调查
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TMC_CUST_EVALDTO GetCustEval(string id)
        {
            TMC_CUST_EVAL custEvalEf = _CustEval.FirstOrDefault(x => x.C_ID.Equals(id));
            List<TMC_CUST_EVAL_SUB> custEvalSubEfs = _CustEvalSub.Where(x => x.C_CUST_EVAL_ID.Equals(id)).ToList();
            TMC_CUST_EVALDTO dto = AutoMapper.Mapper.Map<TMC_CUST_EVALDTO>(custEvalEf);
            List<TMC_CUST_EVAL_SUBDTO> dtos = MAPPING.ConvertEntityToDtoList<TMC_CUST_EVAL_SUB, TMC_CUST_EVAL_SUBDTO>(custEvalSubEfs);
            dto.EvalSubs = dtos;
            return dto;
        }

        /// <summary>
        /// 权限列表
        /// </summary>
        /// <param name="fcDto"></param>
        /// <returns></returns>
        public PageResult<TS_FUNCTION> GetFunctions(TS_FUNCTIONDTO fcDto)
        {
            Expression<Func<TS_FUNCTION, bool>> where = null;
            where = where.And<TS_FUNCTION>(x => x.N_STATUS == 1);

            if (!string.IsNullOrWhiteSpace(fcDto.C_CODE))
            {
                fcDto.C_CODE = fcDto.C_CODE.Trim();
                where = where.And<TS_FUNCTION>(x => x.C_CODE.Contains(fcDto.C_CODE));
            }

            if (!string.IsNullOrWhiteSpace(fcDto.C_NAME))
            {
                fcDto.C_NAME = fcDto.C_NAME.Trim();
                where = where.And<TS_FUNCTION>(x => x.C_NAME.Contains(fcDto.C_NAME));
            }

            Expression<Func<TS_FUNCTION, DateTime>> order = null;
            order = t => t.D_MOD_DT ?? DateTime.Now;

            return QueryPage<TS_FUNCTION, DateTime>(where, fcDto.BasePage.PageSize, fcDto.BasePage.PageIndex, order);
        }

        /// <summary>
        /// 权限添加
        /// </summary>
        /// <param name="fcDto"></param>
        public void FunctionInsert(TS_FUNCTIONDTO fcDto)
        {
            TS_FUNCTION ef = AutoMapper.Mapper.Map<TS_FUNCTION>(fcDto);
            Insert(ef);
        }

        /// <summary>
        /// 验证权限是否重复
        /// </summary>
        /// <param name="fcDto"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool ValidateIsRepeat(TS_FUNCTIONDTO fcDto, int type)
        {
            Expression<Func<TS_FUNCTION, bool>> where = null;

            where = where.And(x => x.N_STATUS == 1);

            if (!string.IsNullOrWhiteSpace(fcDto.C_CODE))
            {
                where = where.And(x => x.C_CODE.Equals(fcDto.C_CODE));
            }

            //if (!string.IsNullOrWhiteSpace(fcDto.C_NAME))
            //{
            //    where = where.And(x => x.C_NAME.Equals(fcDto.C_NAME));
            //}


            if (type == 1)
            {
                where = where.And(x => x.C_ID != fcDto.C_ID);
            }

            TS_FUNCTION ef = _Func.FirstOrDefault(where);
            bool result = false;
            if (ef == null)
                result = true;
            return result;
        }

        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TS_FUNCTIONDTO GetFunction(string id)
        {
            return AutoMapper.Mapper.Map<TS_FUNCTIONDTO>(_Func.FirstOrDefault(x => x.C_ID.Equals(id)));
        }

        /// <summary>
        /// 修改权限信息
        /// </summary>
        /// <param name="fcDto"></param>
        public void FunctionUpdate(TS_FUNCTIONDTO fcDto)
        {
            TS_FUNCTION ef = AutoMapper.Mapper.Map<TS_FUNCTION>(fcDto);
            Update(ef);
        }

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="rDto"></param>
        /// <returns></returns>
        public PageResult<TS_ROLE> GetRoles(TS_ROLEDTO rDto)
        {
            Expression<Func<TS_ROLE, bool>> where = null;
            where = where.And<TS_ROLE>(x => x.N_STATUS == 1);

            if (!string.IsNullOrWhiteSpace(rDto.C_CODE))
            {
                rDto.C_CODE = rDto.C_CODE.Trim();
                where = where.And<TS_ROLE>(x => x.C_CODE.Contains(rDto.C_CODE));
            }

            if (!string.IsNullOrWhiteSpace(rDto.C_NAME))
            {
                rDto.C_NAME = rDto.C_NAME.Trim();
                where = where.And<TS_ROLE>(x => x.C_NAME.Contains(rDto.C_NAME));
            }

            Expression<Func<TS_ROLE, DateTime>> order = null;
            order = t => t.D_MOD_DT ?? DateTime.Now;

            return QueryPage<TS_ROLE, DateTime>(where, rDto.BasePage.PageSize, rDto.BasePage.PageIndex, order);
        }

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <returns></returns>
        public List<TS_ROLEDTO> GetRoles()
        {
            List<TS_ROLE> roles = _Role.OrderBy(x => x.D_MOD_DT).ToList();
            return MAPPING.ConvertEntityToDtoList<TS_ROLE, TS_ROLEDTO>(roles);
        }

        /// <summary>
        /// 角色新增
        /// </summary>
        /// <param name="rDto"></param>
        public void RoleInsert(TS_ROLEDTO rDto)
        {
            TS_ROLE ef = AutoMapper.Mapper.Map<TS_ROLE>(rDto);
            Insert(ef);
        }

        /// <summary>
        /// 验证角色是否重复
        /// </summary>
        /// <param name="fcDto"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool ValidateIsRepeat(TS_ROLEDTO fcDto, int type)
        {
            Expression<Func<TS_ROLE, bool>> where = null;

            where = where.And(x => x.N_STATUS == 1);

            if (!string.IsNullOrWhiteSpace(fcDto.C_CODE))
            {
                where = where.And(x => x.C_CODE.Equals(fcDto.C_CODE));
            }

            //if (!string.IsNullOrWhiteSpace(fcDto.C_NAME))
            //{
            //    where = where.And(x => x.C_NAME.Equals(fcDto.C_NAME));
            //}

            if (type == 1)
            {
                where = where.And(x => x.C_ID != fcDto.C_ID);
            }

            TS_ROLE ef = _Role.FirstOrDefault(where);
            bool result = false;
            if (ef == null)
                result = true;
            return result;
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TS_ROLEDTO GetRole(string id)
        {
            return AutoMapper.Mapper.Map<TS_ROLEDTO>(_Role.FirstOrDefault(x => x.C_ID.Equals(id)));
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="fcDto"></param>
        public void RoleUpdate(TS_ROLEDTO fcDto)
        {
            TS_ROLE ef = AutoMapper.Mapper.Map<TS_ROLE>(fcDto);
            Update(ef);
        }

        /// <summary>
        /// 获取菜单权限列表
        /// </summary>
        /// <returns></returns>
        public List<TS_FUNCTIONDTO> GetMenuFuncs()
        {
            List<TS_FUNCTIONDTO> dtos = new List<TS_FUNCTIONDTO>();
            List<TS_FUNCTION> list = _Func.Where(x => x.N_STATUS == 1
              & x.C_TYPE == 1).OrderBy(x => x.C_CODE).ToList();
            if (list != null & list.Count > 0)
            {
                dtos = MAPPING.ConvertEntityToDtoList<TS_FUNCTION, TS_FUNCTIONDTO>(list);
            }
            return dtos;
        }

        /// <summary>
        /// 获取按钮权限列表
        /// </summary>
        /// <returns></returns>
        public List<TS_FUNCTIONDTO> GetButtonFuncs()
        {
            List<TS_FUNCTIONDTO> dtos = new List<TS_FUNCTIONDTO>();
            List<TS_FUNCTION> list = _Func.Where(x => x.N_STATUS == 1
              & x.C_TYPE == 2).OrderBy(x => x.C_CODE).ToList();
            if (list != null & list.Count > 0)
            {
                dtos = MAPPING.ConvertEntityToDtoList<TS_FUNCTION, TS_FUNCTIONDTO>(list);
            }
            return dtos;
        }

        /// <summary>
        /// 关联用户权限
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="funcID"></param>
        /// <returns></returns>
        public string RelationUserFunc(string userID, string funcID)
        {
            string result = string.Empty;
            try
            {
                List<TS_USER_FUN> list = _UserFunc.Where(x => x.C_USER_ID.Equals(userID)).ToList();
                if (list != null && list.Count > 0)
                {
                    this.Delete<TS_USER_FUN>(list);
                }

                if (funcID != null)
                {
                    string[] arr = funcID.Split(',');
                    List<TS_USER_FUN> efs = new List<TS_USER_FUN>();
                    foreach (var str in arr)
                    {
                        TS_USER_FUN ef = new TS_USER_FUN();
                        ef.C_FUN_ID = str;
                        ef.C_USER_ID = userID;
                        efs.Add(ef);
                    }
                    this.Insert<TS_USER_FUN>(efs);
                }

                result = "1";
            }
            catch (Exception ex)
            {
                result = "0";
            }

            return result;
        }

        /// <summary>
        /// 获取所有用户权限ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public string GetUserFun(string userID)
        {
            string result = string.Empty;
            var data = from fun in _UserFunc
                       where fun.C_USER_ID.Equals(userID)
                       select fun.C_FUN_ID;
            if (data != null && data.Count() > 0)
                result = string.Join(",", data);
            return result;
        }

        /// <summary>
        /// 用户ID获取所有菜单权限信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<TS_FUNCTIONDTO> GetCurrentMenuFun(string userID)
        {
            var data = from userFun in _UserFunc
                       join fun in _Func on userFun.C_FUN_ID equals fun.C_ID
                       join menu in _MenuFun on fun.C_ID equals menu.C_FUN_ID
                       where userFun.C_USER_ID.Equals(userID) & fun.C_TYPE == 1
                       select new TS_FUNCTIONDTO
                       {
                           C_ID = fun.C_ID,
                           C_CODE = fun.C_CODE,
                           C_CONTROLLERCODE = fun.C_CONTROLLERCODE,
                           C_ACTIONCODE = fun.C_ACTIONCODE,
                           C_TYPE = fun.C_TYPE,
                           C_DESC = fun.C_DESC,
                           N_STATUS = fun.N_STATUS,
                           C_NAME = fun.C_NAME,
                           C_EMP_ID = fun.C_EMP_ID,
                           C_EMP_NAME = fun.C_EMP_NAME,
                           D_MOD_DT = fun.D_MOD_DT,
                           MenuID = menu.C_MENU_ID
                       };
            List<TS_FUNCTIONDTO> list = data.ToList();
            return list;
        }

        /// <summary>
        /// 用户ID获取所有按钮权限信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<TS_FUNCTIONDTO> GetCurrentButtonFun(string userID)
        {
            var data = from userFun in _UserFunc
                       join fun in _Func on userFun.C_FUN_ID equals fun.C_ID
                       join button in _ButtonFun on fun.C_ID equals button.C_FUN_ID
                       where userFun.C_USER_ID.Equals(userID) & fun.C_TYPE == 2
                       select new TS_FUNCTIONDTO
                       {
                           C_ID = fun.C_ID,
                           C_CODE = fun.C_CODE,
                           C_CONTROLLERCODE = fun.C_CONTROLLERCODE,
                           C_ACTIONCODE = fun.C_ACTIONCODE,
                           C_TYPE = fun.C_TYPE,
                           C_DESC = fun.C_DESC,
                           N_STATUS = fun.N_STATUS,
                           C_NAME = fun.C_NAME,
                           C_EMP_ID = fun.C_EMP_ID,
                           C_EMP_NAME = fun.C_EMP_NAME,
                           D_MOD_DT = fun.D_MOD_DT,
                           ButtonID = button.C_BUTTON_ID
                       };
            List<TS_FUNCTIONDTO> list = data.ToList();
            return list;
        }

        /// <summary>
        /// 用户ID获取所有部门信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<TS_DEPTDTO> GetCurrentUserDept(string userID)
        {
            var data = from userDept in _UserDept
                       join dept in _Dept on userDept.C_DEPT_ID equals dept.C_ID
                       where userDept.C_USER_ID.Equals(userID)
                       select new TS_DEPTDTO
                       {
                           C_ID = dept.C_ID,
                           C_PARENT_ID = dept.C_PARENT_ID,
                           C_CODE = dept.C_CODE,
                           C_NAME = dept.C_NAME,
                           C_DESC = dept.C_DESC,
                           N_STATUS = dept.N_STATUS,
                           C_DEPTH = dept.C_DEPTH,
                           N_DEPTATTR = dept.N_DEPTATTR,
                           C_EMP_ID = dept.C_EMP_ID,
                           C_EMP_NAME = dept.C_EMP_NAME,
                           D_MOD_DT = dept.D_MOD_DT
                       };
            return data.ToList();
        }

        /// <summary>
        /// 用户ID获取所有角色信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<TS_ROLEDTO> GetCurrentUserRole(string userID)
        {
            var data = from userRole in _UserRole
                       join role in _Role on userRole.C_ROLE_ID equals role.C_ID
                       where userRole.C_USER_ID.Equals(userID)
                       select new TS_ROLEDTO
                       {
                           C_ID = role.C_ID,
                           C_CODE = role.C_CODE,
                           C_DESC = role.C_DESC,
                           C_NAME = role.C_NAME,
                           N_STATUS = role.N_STATUS,
                           C_EMP_ID = role.C_EMP_ID,
                           C_EMP_NAME = role.C_EMP_NAME,
                           D_MOD_DT = role.D_MOD_DT,
                       };
            return data.ToList();
        }

        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public string GetRoleFun(string roleID)
        {
            string result = string.Empty;
            var data = from fun in _RoleFun
                       where fun.C_ROLE_ID.Equals(roleID)
                       select fun.C_FUN_ID;
            if (data != null && data.Count() > 0)
                result = string.Join(",", data);
            return result;
        }

        /// <summary>
        /// 关联角色权限
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="funcID"></param>
        /// <returns></returns>
        public string RelationRoleFunc(string roleID, string funcID)
        {
            string result = string.Empty;
            try
            {
                List<TS_ROLE_FUN> list = _RoleFun.Where(x => x.C_ROLE_ID.Equals(roleID)).ToList();
                if (list != null && list.Count > 0)
                {
                    this.Delete<TS_ROLE_FUN>(list);
                }

                if (funcID != null)
                {
                    string[] arr = funcID.Split(',');
                    List<TS_ROLE_FUN> efs = new List<TS_ROLE_FUN>();
                    foreach (var str in arr)
                    {
                        TS_ROLE_FUN ef = new TS_ROLE_FUN();
                        ef.C_FUN_ID = str;
                        ef.C_ROLE_ID = roleID;
                        efs.Add(ef);
                    }
                    this.Insert<TS_ROLE_FUN>(efs);
                }

                result = "1";
            }
            catch (Exception ex)
            {
                result = "0";
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// 关联用户角色
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public string RelationUserRole(string userID, string roleID)
        {
            string result = string.Empty;
            try
            {
                List<TS_USER_ROLE> list = _UserRole.Where(x => x.C_USER_ID.Equals(userID)).ToList();
                if (list != null && list.Count > 0)
                {
                    this.Delete<TS_USER_ROLE>(list);
                }

                if (roleID != null)
                {
                    string[] arr = roleID.Split(',');
                    List<TS_USER_ROLE> efs = new List<TS_USER_ROLE>();
                    foreach (var str in arr)
                    {
                        TS_USER_ROLE ef = new TS_USER_ROLE();
                        ef.C_ROLE_ID = str;
                        ef.C_USER_ID = userID;
                        efs.Add(ef);
                    }
                    this.Insert<TS_USER_ROLE>(efs);
                }

                result = "1";
            }
            catch (Exception ex)
            {
                result = "0";
            }

            return result;
        }

        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public string GetUserRole(string userID)
        {
            string result = string.Empty;
            var data = from fun in _UserRole
                       where fun.C_USER_ID.Equals(userID)
                       select fun.C_ROLE_ID;
            if (data != null && data.Count() > 0)
                result = string.Join(",", data);
            return result;
        }

        /// <summary>
        /// 获取所有角色权限
        /// </summary>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public CurrentUser GetRoleFun(CurrentUser currentUser)
        {

            if (currentUser.Roles != null && currentUser.Roles.Count > 0)
            {
                string sql = @"    SELECT  tf.*,mf.c_menu_id  MenuID  FROM  ts_role_fun rf
                                        JOIN ts_function tf ON tf.c_id=rf.c_fun_id
                                        JOIN ts_menu_fun mf ON mf.c_fun_id=tf.c_id
                                        WHERE    ";

                for (int i = 0; i < currentUser.Roles.Count; i++)
                {
                    if (i == currentUser.Roles.Count - 1)
                    {
                        sql += "  rf.c_role_id =  '" + currentUser.Roles[i].C_ID + "' ";
                    }
                    else
                    {
                        sql += "  rf.c_role_id =  '" + currentUser.Roles[i].C_ID + "'  or";
                    }
                }

                sql += "   UNION   ";

                sql += @"     SELECT  tf.*,bf.c_button_id  MenuID FROM  ts_role_fun rf
                                JOIN ts_function tf ON tf.c_id=rf.c_fun_id
                                JOIN ts_button_fun bf ON bf.c_fun_id=rf.c_fun_id
                                WHERE    ";

                for (int i = 0; i < currentUser.Roles.Count; i++)
                {
                    if (i == currentUser.Roles.Count - 1)
                    {
                        sql += "  rf.c_role_id =  '" + currentUser.Roles[i].C_ID + "' ";
                    }
                    else
                    {
                        sql += "  rf.c_role_id =  '" + currentUser.Roles[i].C_ID + "'  or";
                    }
                }

                List<TS_FUNCTIONDTO> funs = this.ExcuteQuery<TS_FUNCTIONDTO>(sql).ToList();
                List<TS_FUNCTIONDTO> menuFuns = funs.Where(x => x.C_TYPE == 1).ToList();
                List<TS_FUNCTIONDTO> btnFuns = funs.Where(x => x.C_TYPE == 2).ToList();

                foreach (var menu in menuFuns)
                {
                    if (!currentUser.MenuFuncs.Exists(x => x.C_ID.Equals(menu.C_ID)))
                    {
                        currentUser.MenuFuncs.Add(menu);
                    }
                }

                foreach (var btn in btnFuns)
                {
                    if (!currentUser.ButtonFuncs.Exists(x => x.C_ID.Equals(btn.C_ID)))
                    {
                        btn.ButtonID = btn.MenuID;
                        btn.MenuID = null;
                        currentUser.ButtonFuncs.Add(btn);
                    }
                }

                return currentUser;
            }
            else
            {
                return currentUser;
            }
        }

        /// <summary>
        /// 获取区域信息
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetAreaMax()
        {
            var newList = _AreaMax.ToList();

            List<SelectListItem> listItem = new List<SelectListItem>();
            if (newList != null && newList.Count > 0)
            {
                foreach (var item in newList)
                {
                    SelectListItem items = new SelectListItem();
                    items.Text = item.C_NAME;
                    items.Value = item.C_NAME;
                    listItem.Add(items);
                }
            }
            return listItem;
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetRoleDropDown()
        {
            var newList = _Role.ToList();
            List<SelectListItem> listItem = new List<SelectListItem>();
            if (newList != null && newList.Count > 0)
            {
                foreach (var item in newList)
                {
                    SelectListItem items = new SelectListItem();
                    items.Text = item.C_NAME;
                    items.Value = item.C_ID;
                    listItem.Add(items);
                }
            }
            return listItem;
        }

        /// <summary>
        /// 获取按钮列表
        /// </summary>
        /// <returns></returns>
        public PageResult<TS_BUTTON> GetButtons(TS_BUTTONDTO bDto)
        {
            Expression<Func<TS_BUTTON, bool>> where = null;
            where = where.And<TS_BUTTON>(x => x.N_STATUS == 1);

            if (!string.IsNullOrWhiteSpace(bDto.C_NAME))
            {
                bDto.C_NAME = bDto.C_NAME.Trim();
                where = where.And<TS_BUTTON>(x => x.C_NAME.Contains(bDto.C_NAME));
            }

            if (!string.IsNullOrWhiteSpace(bDto.C_DESC))
            {
                bDto.C_DESC = bDto.C_DESC.Trim();
                where = where.And<TS_BUTTON>(x => x.C_DESC.Contains(bDto.C_DESC));
            }

            Expression<Func<TS_BUTTON, string>> order = null;
            order = t => t.C_MENU_ID;
            return QueryPage<TS_BUTTON, string>(where, bDto.BasePage.PageSize, bDto.BasePage.PageIndex, order);
        }

        /// <summary>
        /// 按钮添加
        /// </summary>
        /// <param name="bDto"></param>
        public void ButtonInsert(TS_BUTTONDTO bDto)
        {
            var ef = AutoMapper.Mapper.Map<TS_BUTTON>(bDto);
            this.Insert(ef);
        }

        /// <summary>
        /// 获取所有按钮权限ID
        /// </summary>
        /// <param name="id">按钮id</param>
        /// <returns></returns>
        public string GetButtonFun(string id)
        {
            string result = string.Empty;
            var data = from fun in _ButtonFun
                       where fun.C_BUTTON_ID.Equals(id)
                       select fun.C_FUN_ID;
            if (data != null && data.Count() > 0)
                result = string.Join(",", data);
            return result;
        }

        /// <summary>
        /// 关联按钮权限
        /// </summary>
        /// <param name="buttonID"></param>
        /// <param name="funcID"></param>
        /// <returns></returns>
        public string RelationButtonFunc(string buttonID, string funcID)
        {
            string result = string.Empty;
            try
            {
                List<TS_BUTTON_FUN> list = _ButtonFun.Where(x => x.C_BUTTON_ID.Equals(buttonID)).ToList();
                if (list != null && list.Count > 0)
                {
                    this.Delete<TS_BUTTON_FUN>(list);
                }

                if (funcID != null)
                {
                    string[] arr = funcID.Split(',');
                    List<TS_BUTTON_FUN> efs = new List<TS_BUTTON_FUN>();
                    foreach (var str in arr)
                    {
                        TS_BUTTON_FUN ef = new TS_BUTTON_FUN();
                        ef.C_FUN_ID = str;
                        ef.C_BUTTON_ID = buttonID;
                        efs.Add(ef);
                    }
                    this.Insert<TS_BUTTON_FUN>(efs);
                }
                result = "1";
            }
            catch (Exception ex)
            {
                result = "0";
            }

            return result;
        }

        /// <summary>
        /// 获取按钮信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TS_BUTTONDTO GetButton(string id)
        {
            var ef = _Button.FirstOrDefault(x => x.C_ID.Equals(id));
            return AutoMapper.Mapper.Map<TS_BUTTONDTO>(ef);
        }

        /// <summary>
        /// 按钮修改
        /// </summary>
        /// <param name="bDto"></param>
        public void ButtonUpdate(TS_BUTTONDTO bDto)
        {
            var ef = AutoMapper.Mapper.Map<TS_BUTTON>(bDto);
            this.Update(ef);
        }

        /// <summary>
        /// 获取二级菜单权限
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userID"></param>
        public void GetSecondFuncs(TS_FUNCTIONDTO dto, string userID)
        {
            string sql = @"SELECT tt.* FROM
                                    (SELECT FUN.* FROM TS_FUNCTION FUN
                                    LEFT JOIN TS_USER_FUN UF ON UF.C_FUN_ID=FUN.C_ID
                                    WHERE  UF.C_USER_ID='{0}'
                                    union
                                    SELECT FUN.* FROM TS_FUNCTION FUN
                                    LEFT JOIN TS_ROLE_FUN RF ON RF.C_FUN_ID=FUN.C_ID
                                    LEFT JOIN TS_USER_ROLE UR ON UR.C_ROLE_ID=RF.C_ROLE_ID
                                    WHERE UR.C_USER_ID='{0}'
                                    ) tt
                                    order by tt.c_code";
            sql = string.Format(sql, userID);
            var funDto = MAPPING.ConvertEntityToDtoList<TS_FUNCTION, TS_FUNCTIONDTO>(this.ExcuteQuery<TS_FUNCTION>(sql).ToList());
            if (funDto != null && funDto.Count > 0)
            {
                dto.MenuSecondFuncs = funDto.Where(x => x.C_TYPE == 1).ToList();
                dto.ButtonSecondFuncs = funDto.Where(x => x.C_TYPE == 2).ToList();
            }
        }

        /// <summary>
        /// 获取所有菜单权限ID
        /// </summary>
        /// <param name="id">按钮id</param>
        /// <returns></returns>
        public string GetMenuFun(string id)
        {
            string result = string.Empty;
            var data = from fun in _MenuFun
                       where fun.C_MENU_ID.Equals(id)
                       select fun.C_FUN_ID;
            if (data != null && data.Count() > 0)
                result = string.Join(",", data);
            return result;
        }

        /// <summary>
        /// 关联菜单权限
        /// </summary>
        /// <param name="buttonID"></param>
        /// <param name="funcID"></param>
        /// <returns></returns>
        public string RelationMenuFunc(string menuID, string funcID)
        {
            string result = string.Empty;
            try
            {
                List<TS_MENU_FUN> list = _MenuFun.Where(x => x.C_MENU_ID.Equals(menuID)).ToList();
                if (list != null && list.Count > 0)
                {
                    this.Delete<TS_MENU_FUN>(list);
                }

                if (funcID != null)
                {
                    string[] arr = funcID.Split(',');
                    List<TS_MENU_FUN> efs = new List<TS_MENU_FUN>();
                    foreach (var str in arr)
                    {
                        TS_MENU_FUN ef = new TS_MENU_FUN();
                        ef.C_FUN_ID = str;
                        ef.C_MENU_ID = menuID;
                        efs.Add(ef);
                    }
                    this.Insert<TS_MENU_FUN>(efs);
                }
                result = "1";
            }
            catch (Exception ex)
            {
                result = "0";
            }

            return result;
        }

    }

    public class MatrlMain
    {
        public string C_PROD_NAME { get; set; }
    }

}
