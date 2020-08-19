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
using System.Data.SqlClient;
using System.Web.Mvc;

namespace NF.Bussiness.Service
{
    public class QualityService : BaseService, IQualityService
    {

        private DbSet<TMQ_QUALITY_MAIN> _Quality;
        private DbSet<TMQ_QUALITY_STL_GRD> _QualityStlGrd;
        private DbSet<TMB_AREA> _Area;
        private DbSet<TMQ_QUALITY_FILE> _QualityFile;
        private DbSet<TMB_FLOWINFO> _FlowInfo;
        private DbSet<TMB_FLOWSTEP> _FlowStep;
        private DbSet<TMF_FILEINFO> _FileInfo;
        private DbSet<TRC_ROLL_PRODCUT> _Rolls;
        private DbSet<TSC_SLAB_MAIN> _Slabs;



        public QualityService(DbContext context) : base(context)
        {
            _Quality = context.Set<TMQ_QUALITY_MAIN>();
            _QualityStlGrd = context.Set<TMQ_QUALITY_STL_GRD>();
            _Area = context.Set<TMB_AREA>();
            _QualityFile = context.Set<TMQ_QUALITY_FILE>();
            _FlowInfo = context.Set<TMB_FLOWINFO>();
            _FlowStep = context.Set<TMB_FLOWSTEP>();
            _FileInfo = context.Set<TMF_FILEINFO>();
            _Rolls = context.Set<TRC_ROLL_PRODCUT>();
            _Slabs = context.Set<TSC_SLAB_MAIN>();
        }

        /// <summary>
        /// 获取质量问题反馈列表（分页）
        /// </summary>
        /// <param name="qmDto"></param>
        /// <param name="empID"></param>
        /// <returns></returns>
        public PageResult<TMQ_QUALITY_MAIN> GetQualitys(TMQ_QUALITY_MAINDTO qmDto, string empID)
        {
            Expression<Func<TMQ_QUALITY_MAIN, bool>> where = null;
            //where = where.And<TMQ_QUALITY_MAIN>(x => x.N_STATUS <= 0);
            where = where.And<TMQ_QUALITY_MAIN>(x => x.C_EMP_ID == empID);

            if (qmDto.Start != DateTime.MinValue)
            {
                DateTime startTime = Convert.ToDateTime(qmDto.Start.ToString("yyyy-MM-dd"));
                where = where.And<TMQ_QUALITY_MAIN>(x => x.D_MOD_DT > startTime);
            }

            if (qmDto.End != DateTime.MinValue)
            {
                DateTime endTime = Convert.ToDateTime(qmDto.End.AddDays(1).ToString("yyyy-MM-dd"));
                where = where.And<TMQ_QUALITY_MAIN>(x => x.D_MOD_DT < endTime);
            }

            if (qmDto.N_FLAG != null)
            {
                where = where.And<TMQ_QUALITY_MAIN>(x => x.N_FLAG == qmDto.N_FLAG);
            }

            if (!string.IsNullOrWhiteSpace(qmDto.C_CUST_NAME))
            {
                qmDto.C_CUST_NAME = qmDto.C_CUST_NAME.Trim();
                where = where.And<TMQ_QUALITY_MAIN>(x => x.C_CUST_NAME.Contains(qmDto.C_CUST_NAME));
            }

            if (!string.IsNullOrWhiteSpace(qmDto.C_TEL))
            {
                qmDto.C_TEL = qmDto.C_TEL.Trim();
                where = where.And<TMQ_QUALITY_MAIN>(x => x.C_TEL.Contains(qmDto.C_TEL));
            }

            Expression<Func<TMQ_QUALITY_MAIN, DateTime>> order = null;
            order = t => t.D_MOD_DT;

            return QueryPage<TMQ_QUALITY_MAIN, DateTime>(where, qmDto.BasePage.PageSize, qmDto.BasePage.PageIndex, order, false);
        }

        /// <summary>
        /// 获取质量问题反馈列表（分页）
        /// </summary>
        /// <param name="qmDto"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public PageResult<TMQ_QUALITY_MAIN> GetQualitys(TMQ_QUALITY_MAINDTO qmDto, int type)
        {
            Expression<Func<TMQ_QUALITY_MAIN, bool>> where = null;
            where = where.And<TMQ_QUALITY_MAIN>(x => x.N_STATUS >= 0);


            if (qmDto.Start != DateTime.MinValue)
            {
                DateTime startTime = Convert.ToDateTime(qmDto.Start.ToString("yyyy-MM-dd"));
                where = where.And<TMQ_QUALITY_MAIN>(x => x.D_MOD_DT > startTime);
            }

            if (qmDto.End != DateTime.MinValue)
            {
                DateTime endTime = Convert.ToDateTime(qmDto.End.AddDays(1).ToString("yyyy-MM-dd"));
                where = where.And<TMQ_QUALITY_MAIN>(x => x.D_MOD_DT < endTime);
            }

            if (qmDto.N_FLAG != null)
            {
                where = where.And<TMQ_QUALITY_MAIN>(x => x.N_FLAG == qmDto.N_FLAG);
            }

            if (!string.IsNullOrWhiteSpace(qmDto.C_CUST_NAME))
            {
                qmDto.C_CUST_NAME = qmDto.C_CUST_NAME.Trim();
                where = where.And<TMQ_QUALITY_MAIN>(x => x.C_CUST_NAME.Contains(qmDto.C_CUST_NAME));
            }

            if (!string.IsNullOrWhiteSpace(qmDto.C_TEL))
            {
                qmDto.C_TEL = qmDto.C_TEL.Trim();
                where = where.And<TMQ_QUALITY_MAIN>(x => x.C_TEL.Contains(qmDto.C_TEL));
            }

            Expression<Func<TMQ_QUALITY_MAIN, DateTime>> order = null;
            order = t => t.D_MOD_DT;

            return QueryPage<TMQ_QUALITY_MAIN, DateTime>(where, qmDto.BasePage.PageSize, qmDto.BasePage.PageIndex, order, false);
        }

        /// <summary>
        /// 质量异议新增
        /// </summary>
        /// <param name="qmDto"></param>
        public TMQ_QUALITY_MAIN QualitysInser(TMQ_QUALITY_MAINDTO qmDto)
        {
            TMQ_QUALITY_MAIN ef = AutoMapper.Mapper.Map<TMQ_QUALITY_MAIN>(qmDto);
            TMQ_QUALITY_MAIN_LOG logEf = AUTOMAPING.Mapping<TMQ_QUALITY_MAIN_LOG>(ef);
            Insert(logEf);
            return Insert(ef);
        }

        /// <summary>
        /// 质量异议新增
        /// </summary>
        /// <param name="qmDto"></param>
        /// <returns></returns>
        public TMQ_QUALITY_MAIN QualitysInser(TMQ_QUALITY_MAIN dto)
        {
            TMQ_QUALITY_MAIN_LOG logEf = AUTOMAPING.Mapping<TMQ_QUALITY_MAIN_LOG>(dto);
            Insert(logEf);
            return Insert(dto);
        }

        /// <summary>
        /// 质量异议详情新增
        /// </summary>
        /// <param name="qsgDto"></param>
        public void QualitysDetailInser(List<TMQ_QUALITY_STL_GRDDTO> qsgDto)
        {
            List<TMQ_QUALITY_STL_GRD> ef = MAPPING.ConvertDtoToEntityList<TMQ_QUALITY_STL_GRDDTO, TMQ_QUALITY_STL_GRD>(qsgDto);
            Insert<TMQ_QUALITY_STL_GRD>(ef);
        }

        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="id"></param>
        public void QualitysDetailDelete(string id)
        {
            var list = _QualityStlGrd.Where(x => x.C_QUALITY_ID.Equals(id)).ToList();
            if (list != null && list.Count > 0)
            {
                Delete<TMQ_QUALITY_STL_GRD>(list);
            }
        }

        /// <summary>
        /// 质量异议修改
        /// </summary>
        /// <param name="qmDto"></param>
        public void QualitysUpdate(TMQ_QUALITY_MAINDTO qmDto)
        {
            TMQ_QUALITY_MAIN ef = AutoMapper.Mapper.Map<TMQ_QUALITY_MAIN>(qmDto);
            ef.D_MOD_DT = DateTime.Now;
            Update(ef);
            QualitysDetailDelete(qmDto.C_ID);
            //给子表赋值主表主键
            if (qmDto.QualityStlGrds != null && qmDto.QualityStlGrds.Count > 0)
            {
                foreach (var item in qmDto.QualityStlGrds)
                {
                    item.C_QUALITY_ID = qmDto.C_ID;
                }
                QualitysDetailInser(qmDto.QualityStlGrds);
            }
        }

        /// <summary>
        /// 质量异议修改
        /// </summary>
        /// <param name="qmDto"></param>
        public void QualitysUpdate(TMQ_QUALITY_MAIN qmDto)
        {
            qmDto.D_MOD_DT = DateTime.Now;
            this.Update<TMQ_QUALITY_MAIN>(qmDto);
        }

        /// <summary>
        /// 获取质量问题反馈
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<TMQ_QUALITY_STL_GRDDTO> GetQualityDetail(string id)
        {
            var list = _QualityStlGrd.Where(x => x.C_QUALITY_ID.Equals(id)).ToList();
            return MAPPING.ConvertEntityToDtoList<TMQ_QUALITY_STL_GRD, TMQ_QUALITY_STL_GRDDTO>(list);
        }

        /// <summary>
        /// 获取地区名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetAreaName(string id)
        {
            if (id == null)
            {
                return "";
            }
            else
                return _Area.Where(x => x.C_ID.Equals(id)).FirstOrDefault().C_NAME;
        }

        /// <summary>
        /// 验证是否重复
        /// </summary>
        /// <param name="qfDto"></param>
        /// <returns></returns>
        public bool ValidateIsRepeat(TMQ_QUALITY_FILE qfDto)
        {
            Expression<Func<TMQ_QUALITY_FILE, bool>> where = null;

            where = where.And(x => x.C_TITLE.Equals(qfDto.C_TITLE));

            where = where.And(x => x.C_QUALITY_ID.Equals(qfDto.C_QUALITY_ID));

            TMQ_QUALITY_FILE ef = _QualityFile.FirstOrDefault(where);
            bool result = true;
            if (ef == null)
                result = false;
            else
            {
                ef.D_DT = DateTime.Now;
                Update(ef);
            }
            return result;
        }

        /// <summary>
        /// 获取审批流程
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetFlowInfo()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var fls = _FlowInfo.Where(x => x.N_TYPE == 2).ToList();
            if (fls.Count > 0)
            {
                foreach (var item in fls)
                {
                    SelectListItem li = new SelectListItem();
                    li.Text = item.C_NAME;
                    li.Value = item.C_ID;
                    list.Add(li);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取审批步骤
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TMB_FLOWSTEP GetFlowStep(string id)
        {
            return _FlowStep.Where(x => x.C_FLOW_ID.Equals(id)).OrderBy(x => x.N_SORT).ToList().First();
        }

        /// <summary>
        /// 新增流程处理
        /// </summary>
        /// <param name="fileDto"></param>
        public TMF_FILEINFO FileInfoInsert(TMF_FILEINFODTO fileDto)
        {
            TMF_FILEINFO ef = AutoMapper.Mapper.Map<TMF_FILEINFO>(fileDto);
            return Insert(ef);
        }

        /// <summary>
        /// 获取质量反馈信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TMQ_QUALITY_MAINDTO GetQuality(string id)
        {
            TMQ_QUALITY_MAINDTO dto = AutoMapper.Mapper.Map<TMQ_QUALITY_MAINDTO>(_Quality.FirstOrDefault(x => x.C_ID.Equals(id)));
            List<TMQ_QUALITY_STL_GRD> stls = _QualityStlGrd.Where(x => x.C_QUALITY_ID.Equals(id)).ToList();
            List<TMQ_QUALITY_STL_GRDDTO> stlDtos = MAPPING.ConvertEntityToDtoList<TMQ_QUALITY_STL_GRD, TMQ_QUALITY_STL_GRDDTO>(stls);
            if (stlDtos != null && stlDtos.Count > 0)
                dto.QualityStlGrds = stlDtos;
            return dto;
        }

        /// <summary>
        /// 获取质量反馈信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TMQ_QUALITY_MAIN GetQualityMain(string id)
        {
            return _Quality.FirstOrDefault(x => x.C_ID.Equals(id));
        }

        /// <summary>
        /// 获取质量反馈附件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TMQ_QUALITY_FILE GetQuqlityFile(string id)
        {
            return _QualityFile.FirstOrDefault(x => x.C_ID.Equals(id));
        }

        /// <summary>
        /// 获取质量反馈附件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<TMQ_QUALITY_FILE> GetQuqlityFiles(string id)
        {
            return _QualityFile.Where(x => x.C_QUALITY_ID.Equals(id)).OrderBy(x => x.D_DT).ToList();
        }

        /// <summary>
        /// 根据批号获取线材组批信息
        /// </summary>
        /// <param name="batchID"></param>
        /// <returns></returns>
        public List<TRC_ROLL_PRODCUT> GetRollProdcut(string batchID, string stove)
        {
            Expression<Func<TRC_ROLL_PRODCUT, bool>> where = null;

            if (!string.IsNullOrWhiteSpace(batchID))
                where = where.And(x => x.C_BATCH_NO.Equals(batchID));
            if (!string.IsNullOrWhiteSpace(stove))
                where = where.And(x => x.C_STOVE.Equals(stove));

            List<TRC_ROLL_PRODCUT> list = new List<TRC_ROLL_PRODCUT>();
            var result = _Rolls.Where(where)
            .GroupBy(x => new { x.C_STL_GRD, x.C_SPEC, x.C_STD_CODE, x.C_STOVE })
            .Select(g => new
            {
                C_STL_GRD = g.Key.C_STL_GRD,
                C_SPEC = g.Key.C_SPEC,
                C_STD_CODE = g.Key.C_STD_CODE,
                C_STOVE = g.Key.C_STOVE
            }).ToList();

            foreach (var item in result)
            {
                TRC_ROLL_PRODCUT example = new TRC_ROLL_PRODCUT()
                {
                    C_STL_GRD = item.C_STL_GRD,
                    C_SPEC = item.C_SPEC,
                    C_STOVE = item.C_STOVE,
                    C_STD_CODE = item.C_STD_CODE
                };
                list.Add(example);
            }

            return list;
        }

        /// <summary>
        /// 根据批号获取钢坯组批信息
        /// </summary>
        /// <param name="batchID"></param>
        /// <param name="stove"></param>
        /// <returns></returns>
        public List<TSC_SLAB_MAIN> GetSlabMain(string batchID, string stove)
        {
            Expression<Func<TSC_SLAB_MAIN, bool>> where = null;

            if (!string.IsNullOrWhiteSpace(batchID))
                where = where.And(x => x.C_BATCH_NO.Equals(batchID));
            if (!string.IsNullOrWhiteSpace(stove))
                where = where.And(x => x.C_STOVE.Equals(stove));

            List<TSC_SLAB_MAIN> list = new List<TSC_SLAB_MAIN>();
            var result = _Slabs.Where(where)
            .GroupBy(x => new { x.C_STL_GRD, x.C_SPEC, x.C_STD_CODE, x.C_STOVE })
            .Select(g => new
            {
                C_STL_GRD = g.Key.C_STL_GRD,
                C_SPEC = g.Key.C_SPEC,
                C_STD_CODE = g.Key.C_STD_CODE,
                C_STOVE = g.Key.C_STOVE
            }).ToList();

            foreach (var item in result)
            {
                TSC_SLAB_MAIN example = new TSC_SLAB_MAIN()
                {
                    C_STL_GRD = item.C_STL_GRD,
                    C_SPEC = item.C_SPEC,
                    C_STD_CODE = item.C_STD_CODE,
                    C_STOVE = item.C_STOVE
                };
                list.Add(example);
            }

            return list;
        }

    }
}
