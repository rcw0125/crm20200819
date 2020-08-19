using NF.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NF.Framework;
using NF.EF.Model;
using NF.Framework.DTO;
using System.Linq.Expressions;
using System.Transactions;
using NF.NC.Interface;

namespace NF.Bussiness.Service
{
    public class PlanService : BaseService, IPlanService
    {
        private DbSet<TMP_PLAN> _Plan;
        private DbSet<TMP_DAYPLAN> _DayPlan;
        private DbSet<TS_DIC> _Dic;
        private DbSet<TMO_ORDER> _ConDetails;
        private DbSet<TMO_CON> _Con;
        private DbSet<TMD_DISPATCH> _Dispatch;
        private DbSet<TMD_DISPATCHDETAILS> _DispatchDetails;
        private DbSet<TMD_DIS_CONDET> _DisConDet;
        private DbSet<TS_USER> _User;
        private DbSet<TS_DEPT> _Dept;
        private DbSet<TRC_ROLL_PRODCUT> _RollProduct;
        private DbSet<TSC_SLAB_MAIN> _SlabMain;
        private DbSet<TMD_DISPATCH_LOG> _DispatchLog;
        private DbSet<TB_MATRL_MAIN> _MatrlMain;
        private DbSet<TMB_AREAMAX> _AreaMax;
        private DbSet<TS_CUSTFILE> _CustFile;
        private DbSet<TPB_LINEWH> _LineWh;
        private DbSet<TPB_SLABWH> _SlabWh;


        public PlanService(DbContext context) : base(context)
        {
            _DayPlan = context.Set<TMP_DAYPLAN>();
            _Plan = context.Set<TMP_PLAN>();
            _Dic = context.Set<TS_DIC>();
            _ConDetails = context.Set<TMO_ORDER>();
            _Con = context.Set<TMO_CON>();
            _Dispatch = context.Set<TMD_DISPATCH>();
            _DispatchDetails = context.Set<TMD_DISPATCHDETAILS>();
            _User = context.Set<TS_USER>();
            _Dept = context.Set<TS_DEPT>();
            _RollProduct = context.Set<TRC_ROLL_PRODCUT>();
            _DisConDet = context.Set<TMD_DIS_CONDET>();
            _DispatchLog = context.Set<TMD_DISPATCH_LOG>();
            _SlabMain = context.Set<TSC_SLAB_MAIN>();
            _MatrlMain = context.Set<TB_MATRL_MAIN>();
            _AreaMax = context.Set<TMB_AREAMAX>();
            _CustFile = context.Set<TS_CUSTFILE>();
            _LineWh = context.Set<TPB_LINEWH>();
            _SlabWh = context.Set<TPB_SLABWH>();
        }

        /// <summary>
        /// 获取发运方式GPS是否启用
        /// </summary>
        /// <param name="matCode">物料编码</param>
        /// <returns></returns>
        public int GetShipviaGps(string shipvia)
        {
            int result = 0;
            var ef = _Dic.FirstOrDefault(x => x.C_TYPECODE == "ShipVia" && x.C_DETAILCODE == shipvia);
            if (ef != null && ef.N_ISGPS != null)
                result = Convert.ToInt32(ef.N_ISGPS);
            return result;
        }

        /// <summary>
        /// 获取钢种GPS是否启用
        /// </summary>
        /// <param name="matCode">物料编码</param>
        /// <returns></returns>
        public int GetMatrlMainGps(string matCode)
        {
            int result = 0;
            var ef = _MatrlMain.FirstOrDefault(x => x.C_MAT_CODE == matCode);
            if (ef != null)
                result = Convert.ToInt32(ef.N_ISGPS);
            return result;
        }

        /// <summary>
        /// 获取地区GPS是否启用
        /// </summary>
        /// <param name="area">地区</param>
        /// <returns></returns>
        public int GetAreaGps(string area)
        {
            int result = 0;
            var ef = _Dic.FirstOrDefault(x => x.C_TYPECODE == "ConArea"
            &&x.C_DETAILNAME==area);
            if (ef != null)
                result = Convert.ToInt32(ef.N_ISGPS);
            return result;
        }

        /// <summary>
        /// 获取客户编码GPS是否启用
        /// </summary>
        /// <param name="no">客户编码</param>
        /// <returns></returns>
        public int GetCustFileGps(string no)
        {
            int result = 0;
            var ef = _CustFile.FirstOrDefault(x => x.C_NO == no);
            if (ef != null && ef.N_ISGPS != null)
                result = Convert.ToInt32(ef.N_ISGPS);
            return result;
        }

        /// <summary>
        /// 获取明细合同列表（分页）
        /// </summary>
        /// <param name="conDto">合同明细实体DTO</param>
        /// <returns></returns>
        public PageResult<TMO_ORDER> GetConDetails(TMO_CONDETAILSDTO conDto)
        {

            string table = "  TMO_ORDER T  ";

            table += "  LEFT JOIN TMP_DAYPLAN TDP ON TDP.C_ORDERNO=T.C_ORDER_NO  ";

            string where = "  AND T.N_STATUS=2   AND TDP.C_ID IS NOT NULL ";

            string order = "T.D_DT  desc";


            if (!string.IsNullOrWhiteSpace(conDto.C_CON_NO))
            {
                where += string.Format("  AND T.C_CON_NO like '%{0}%' ", conDto.C_CON_NO);
            }

            if (!string.IsNullOrWhiteSpace(conDto.C_ORDER_NO))
            {
                where += string.Format("  AND T.C_ORDER_NO like '%{0}%' ", conDto.C_ORDER_NO);
            }

            if (!string.IsNullOrWhiteSpace(conDto.C_CON_NAME))
            {
                where += string.Format("  AND T.C_CON_NAME like  '%{0}%' ", conDto.C_CON_NAME);
            }

            if (conDto.N_TYPE != null && conDto.N_TYPE != 0)
            {
                where += string.Format("  AND T.N_TYPE={0} ", conDto.N_TYPE);
            }

            if (conDto.Start != DateTime.MinValue)
            {
                where += " AND  T.D_DELIVERY_DT>=to_date('" + conDto.Start.ToString("yyyyMMdd") + "','yyyy-mm-dd') ";
                where += " AND  T.D_DELIVERY_DT<=to_date('" + conDto.End.ToString("yyyyMMdd") + "','yyyy-mm-dd') ";
            }

            if (!string.IsNullOrWhiteSpace(conDto.C_AREA))
            {
                where += string.Format("  AND T.C_AREA='{0}' ", conDto.C_AREA);
            }
            //总条数
            int count = 0;
            //数据集合
            List<TMO_ORDER> users = GenerateByPageSql<TMO_ORDER>(conDto.BasePage.PageSize, conDto.BasePage.PageIndex, " T.* ", table, order, where, out count).ToList();

            //转换为分页数据
            PageResult<TMO_ORDER> result = new PageResult<TMO_ORDER>()
            {
                DataList = users,
                PageIndex = conDto.BasePage.PageIndex,
                PageSize = conDto.BasePage.PageSize,
                TotalCount = count
            };
            //计算页数
            BaseService.CalculatePage<TMO_ORDER>(result.PageSize, result);

            return result;
        }

        /// <summary>
        /// 获取发运日计划列表
        /// </summary>
        /// <param name="no">订单号</param>
        /// <returns></returns>
        public List<TMP_PLANDTO> GetPlans(string no)
        {
            var data = from plan in _Plan
                       join shipvia in _Dic on plan.C_SHIPVIA equals shipvia.C_DETAILCODE
                       where shipvia.C_TYPECODE.Equals("ShipVia")
                       && plan.C_NO.Equals(no)
                       orderby plan.D_MOD_DT
                       select new TMP_PLANDTO
                       {
                           C_ID = plan.C_ID,
                           C_NO = plan.C_NO,
                           C_CON_NO = plan.C_CON_NO,
                           D_PLANSEND_DT = plan.D_PLANSEND_DT,
                           C_MAT_CODE = plan.C_MAT_CODE,
                           C_MAT_NAME = plan.C_MAT_NAME,
                           C_SPEC = plan.C_SPEC,
                           C_STL_GRD = plan.C_STL_GRD,
                           C_QUALIRY_LEV = plan.C_QUALIRY_LEV,
                           N_WGT = plan.N_WGT,
                           N_SENDNUM_WGT = plan.N_SENDNUM_WGT,
                           C_ATSTATION = plan.C_ATSTATION,
                           C_AREA = plan.C_AREA,
                           C_ADDR = plan.C_ADDR,
                           C_SHIPVIA = plan.C_SHIPVIA,
                           C_SHIPVIA_NAME = shipvia.C_DETAILNAME,
                           C_CGC = plan.C_CGC,
                           C_ORGO_CUST = plan.C_ORGO_CUST,
                           C_SEND_STOCK_DEPT = plan.C_SEND_STOCK_DEPT,
                           N_STATUS = plan.N_STATUS,
                           C_SEND_STOCK = plan.C_SEND_STOCK,
                           C_AOG_STOCK_DEPT = plan.C_AOG_STOCK_DEPT,
                           C_AOG_STOCK = plan.C_AOG_STOCK,
                           C_SEND_COM = plan.C_SEND_COM,
                           C_SALE_COM = plan.C_SALE_COM,
                           C_AOG_COM = plan.C_AOG_COM,
                           C_SEND_AREA = plan.C_SEND_AREA,
                           C_SEND_ADDR = plan.C_SEND_ADDR,
                           C_SEND_SITE = plan.C_SEND_SITE,
                           C_AOG_SITE = plan.C_AOG_SITE,
                           N_OUT_STOCK_WGT = plan.N_OUT_STOCK_WGT,
                           N_SIGN_WGT = plan.N_SIGN_WGT,
                           N_BACK_WGT = plan.N_BACK_WGT,
                           N_DAMAGE_WGT = plan.N_DAMAGE_WGT,
                           C_FOR_PALN_ID = plan.C_FOR_PALN_ID,
                           D_APPROVE_DT = plan.D_APPROVE_DT,
                           C_APPROVE_ID = plan.C_APPROVE_ID,
                           C_ORDER_TYPE = plan.C_ORDER_TYPE,
                           N_SORO_BACK = plan.N_SORO_BACK,
                           C_REMARK = plan.C_REMARK,
                           C_BUSINESS_DEPT = plan.C_BUSINESS_DEPT,
                           C_BUSINESS_TYPE = plan.C_BUSINESS_TYPE,
                           C_SALESMAN = plan.C_SALESMAN,
                           D_ORRE_AOG_DT = plan.D_ORRE_AOG_DT,
                           D_FOR_PLAN_DT = plan.D_FOR_PLAN_DT,
                           D_MOD_DT = plan.D_MOD_DT
                       };
            return data.ToList();
        }

        /// <summary>
        /// 获取发运日计划
        /// </summary>
        /// <param name="no">合同号</param>
        /// <param name="baseUser">当前登陆人信息</param>
        /// <returns></returns>
        public TMP_PLANDTO GetPlan(string no, CurrentUser baseUser)
        {
            TMP_PLANDTO planDto = null;
            var conDtails = _ConDetails.First(x => x.C_ORDER_NO.Equals(no));
            var con = _Con.First(x => x.C_CON_NO.Equals(conDtails.C_CON_NO));
            string status = con.N_STATUS.ToString();
            var dic = _Dic.Where(x => x.C_TYPECODE == "ContractStatus"
            && x.C_DETAILCODE == status).ToList();
            var user = _User.AsQueryable();
            var dept = _Dept.AsQueryable();
            if (conDtails != null)
            {
                planDto = new TMP_PLANDTO()
                {
                    C_CON_NO = conDtails.C_CON_NO,
                    C_NO = conDtails.C_ORDER_NO,
                    C_ID = CreatePlanID(),
                    D_PLANSEND_DT = conDtails.D_DELIVERY_DT,
                    C_MAT_CODE = conDtails.C_MAT_CODE,
                    C_MAT_NAME = conDtails.C_MAT_NAME,
                    C_SPEC = conDtails.C_SPEC,
                    C_STL_GRD = conDtails.C_STL_GRD,
                    N_WGT = conDtails.N_WGT,
                    C_AREA = conDtails.C_AREA,
                    C_CGC = conDtails.C_RECEIPTCORPID,
                    C_SEND_STOCK_DEPT = "型钢库存组织",
                    N_STATUS = conDtails.N_STATUS,
                    D_ORRE_AOG_DT = conDtails.D_DELIVERY_DT,
                    C_SALE_COM = "邢台钢铁有限公责任司",
                    C_SEND_AREA = "邢台市区",
                    D_FOR_PLAN_DT = DateTime.Now,
                    C_FOR_PALN_ID = baseUser.Id,
                    C_ORDER_TYPE = conDtails.N_TYPE.ToString(),
                    D_APPROVE_DT = con.D_APPROVEDATE,
                    C_APPROVE_ID = con.C_APPROVEID,
                    C_BUSINESS_DEPT = con.C_DEPTID,
                    C_BUSINESS_TYPE = con.C_BIZTYPE,
                    C_SALESMAN = con.C_EMPLOYEEID,
                    C_STATUS_NAME = dic.FirstOrDefault().C_DETAILNAME
                };
            }
            //planDto.C_SALESMAN_NAME = user.FirstOrDefault(x => x.C_ID.Equals(planDto.C_SALESMAN)).C_NAME;
            //planDto.C_BUSINESS_DEPT_NAME = dept.FirstOrDefault(x => x.C_ID.Equals(planDto.C_BUSINESS_DEPT)).C_NAME;
            return planDto;
        }

        /// <summary>
        /// 获取发运日计划
        /// </summary>
        /// <param name="no">日计划单据号</param>
        /// <returns></returns>
        public TMP_PLANDTO GetPlan(string no)
        {
            TMP_PLANDTO planDto = null;
            var plan = _Plan.First(x => x.C_ID.Equals(no));
            string status = plan.N_STATUS.ToString();
            var dic = _Dic.Where(x => x.C_TYPECODE == "ContractStatus"
            && x.C_DETAILCODE == status).ToList();
            if (plan != null)
            {
                planDto = new TMP_PLANDTO()
                {
                    C_CON_NO = plan.C_CON_NO,
                    C_NO = plan.C_NO,
                    C_ID = plan.C_ID,
                    D_PLANSEND_DT = plan.D_PLANSEND_DT,
                    C_MAT_CODE = plan.C_MAT_CODE,
                    C_MAT_NAME = plan.C_MAT_NAME,
                    C_SPEC = plan.C_SPEC,
                    C_STL_GRD = plan.C_STL_GRD,
                    C_QUALIRY_LEV = plan.C_QUALIRY_LEV,
                    N_WGT = plan.N_WGT,
                    C_ATSTATION = plan.C_ATSTATION,
                    C_AREA = plan.C_AREA,
                    C_ADDR = plan.C_ADDR,
                    C_CGC = plan.C_CGC,
                    C_SEND_STOCK_DEPT = plan.C_SEND_STOCK_DEPT,
                    N_STATUS = plan.N_STATUS,
                    D_ORRE_AOG_DT = plan.D_ORRE_AOG_DT,
                    C_SALE_COM = plan.C_SALE_COM,
                    C_SEND_AREA = plan.C_SEND_AREA,
                    D_FOR_PLAN_DT = plan.D_FOR_PLAN_DT,
                    C_FOR_PALN_ID = plan.C_FOR_PALN_ID,
                    C_ORDER_TYPE = plan.C_ORDER_TYPE,
                    D_APPROVE_DT = plan.D_APPROVE_DT,
                    C_APPROVE_ID = plan.C_APPROVE_ID,
                    C_BUSINESS_DEPT = plan.C_BUSINESS_DEPT,
                    C_BUSINESS_TYPE = plan.C_BUSINESS_TYPE,
                    C_SALESMAN = plan.C_SALESMAN,
                    C_STATUS_NAME = dic.FirstOrDefault().C_DETAILNAME
                };
            }
            return planDto;
        }

        /// <summary>
        /// 添加发运日计划
        /// </summary>
        /// <param name="pDto">发运日计划实体DTO</param>
        public void PlanInsert(TMP_PLANDTO pDto)
        {
            TMP_PLAN pEf = AutoMapper.Mapper.Map<TMP_PLAN>(pDto);
            try
            { this.Insert(pEf); }
            catch (Exception e)
            { }
        }

        /// <summary>
        /// 修改发运日计划
        /// </summary>
        /// <param name="pDto">发运日计划实体DTO</param>
        public void PlanUpdate(TMP_PLANDTO pDto)
        {
            TMP_PLAN pEf = AutoMapper.Mapper.Map<TMP_PLAN>(pDto);
            this.Update(pEf);
        }

        /// <summary>
        /// 分页获取发运日计划列表（分页）
        /// </summary>
        /// <param name="pDto">发运日计划实体DTO</param>
        /// <returns></returns>
        public PageResult<TMP_PLAN> GetPlans(TMP_PLANDTO pDto)
        {
            Expression<Func<TMP_PLAN, bool>> where = null;
            where = where.And<TMP_PLAN>(x => x.N_STATUS == 2);

            if (!string.IsNullOrWhiteSpace(pDto.C_CON_NO))
            {
                where = where.And<TMP_PLAN>(x => x.C_CON_NO.Equals(pDto.C_CON_NO));
            }

            if (!string.IsNullOrWhiteSpace(pDto.C_NO))
            {
                where = where.And<TMP_PLAN>(x => x.C_NO.Equals(pDto.C_NO));
            }

            if (!string.IsNullOrWhiteSpace(pDto.C_ID))
            {
                where = where.And<TMP_PLAN>(x => x.C_ID.Equals(pDto.C_ID));
            }

            Expression<Func<TMP_PLAN, DateTime>> order = null;
            //order = t => t.D_MOD_DT ?? DateTime.Now;

            return QueryPage<TMP_PLAN, DateTime>(where, pDto.BasePage.PageSize, pDto.BasePage.PageIndex, order, false);
        }

        /// <summary>
        /// 获取发运单列表
        /// </summary>
        /// <returns></returns>
        public PageResult<TMD_DISPATCH> GetDispatchs(TMD_DISPATCHDTO dispatchDto)
        {
            Expression<Func<TMD_DISPATCH, bool>> where = null;

            where = where.And<TMD_DISPATCH>(x => x.C_STATUS != "5");

            where = where.And<TMD_DISPATCH>(x => x.C_STATUS != "6");

            if (dispatchDto.Start != DateTime.MinValue)
            {
                DateTime startTime = Convert.ToDateTime(dispatchDto.Start.ToString("yyyy-MM-dd"));
                where = where.And<TMD_DISPATCH>(x => x.D_DISP_DT > startTime);
            }

            if (dispatchDto.End != DateTime.MinValue)
            {
                DateTime endTime = Convert.ToDateTime(dispatchDto.End.AddDays(1).ToString("yyyy-MM-dd"));
                where = where.And<TMD_DISPATCH>(x => x.D_DISP_DT < endTime);
            }

            if (!string.IsNullOrWhiteSpace(dispatchDto.C_ID))
            {
                where = where.Or<TMD_DISPATCH>(x => x.C_ID.Equals(dispatchDto.C_ID));
            }

            if (!string.IsNullOrWhiteSpace(dispatchDto.C_CON_NO))
            {
                var conDetails = _ConDetails.Where(x => x.C_CON_NO.Contains(dispatchDto.C_CON_NO));
                if (conDetails != null && conDetails.Count() > 0)
                {
                    foreach (var item in conDetails)
                    {
                        var ef = _DisConDet.FirstOrDefault(x => x.C_NO.Contains(item.C_ORDER_NO));
                        if (ef != null && !string.IsNullOrWhiteSpace(ef.C_DISPATCH_ID))
                        {
                            if (!string.IsNullOrWhiteSpace(ef.C_DISPATCH_ID))
                                where = where.Or<TMD_DISPATCH>(x => x.C_ID.Equals(ef.C_DISPATCH_ID));
                        }
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(dispatchDto.C_LIC_PLA_NO))
            {
                dispatchDto.C_LIC_PLA_NO = dispatchDto.C_LIC_PLA_NO.Trim();
                where = where.And<TMD_DISPATCH>(x => x.C_LIC_PLA_NO.Contains(dispatchDto.C_LIC_PLA_NO));
            }

            if (!string.IsNullOrWhiteSpace(dispatchDto.C_STATUS))
            {
                where = where.And<TMD_DISPATCH>(x => x.C_STATUS == dispatchDto.C_STATUS);
            }

            Expression<Func<TMD_DISPATCH, DateTime>> order = null;
            order = t => t.D_CREATE_DT ?? DateTime.Now;

            return QueryPage<TMD_DISPATCH, DateTime>(where, dispatchDto.BasePage.PageSize, dispatchDto.BasePage.PageIndex, order, false);
        }

        /// <summary>
        /// 获取发运单列表
        /// </summary>
        /// <param name="no">日计划单据号</param>
        /// <returns></returns>
        public List<TMD_DISPATCHDTO> GetDispatchs(string no)
        {
            var data = from dis in _Dispatch
                       join user in _User on dis.C_CREATE_ID equals user.C_ID
                       orderby dis.D_MOD_DT descending
                       where dis.C_PLAN_ID.Equals(no)
                       select new TMD_DISPATCHDTO
                       {
                           C_ID = dis.C_ID,
                           C_PLAN_ID = dis.C_PLAN_ID,
                           C_GPS_NO = dis.C_GPS_NO,
                           C_NO = dis.C_NO,
                           C_CON_NO = dis.C_CON_NO,
                           D_DISP_DT = dis.D_DISP_DT,
                           C_SHIPVIA = dis.C_SHIPVIA,
                           C_COMCAR = dis.C_COMCAR,
                           C_PATH_DESC = dis.C_PATH_DESC,
                           C_SEND_DEPT = dis.C_SEND_DEPT,
                           C_BUSINESS_DEPT = dis.C_BUSINESS_DEPT,
                           C_BUSINESS_ID = dis.C_BUSINESS_ID,
                           C_IS_WIRESALE = dis.C_IS_WIRESALE,
                           C_IS_WIRESALE_ID = dis.C_IS_WIRESALE_ID,
                           N_IS_EXPORT = dis.N_IS_EXPORT,
                           C_LIC_PLA_NO = dis.C_LIC_PLA_NO,
                           C_ATSTATION = dis.C_ATSTATION,
                           D_APPROVE_DT = dis.D_APPROVE_DT,
                           D_CREATE_DT = dis.D_CREATE_DT,
                           C_APPROVE_ID = dis.C_APPROVE_ID,
                           C_CREATE_ID = dis.C_CREATE_ID,
                           C_CREATE_NAME = user.C_NAME,
                           C_STATUS = dis.C_STATUS
                       };

            return data.ToList();
        }

        /// <summary>
        /// 创建发运单明细(线材)
        /// </summary>
        /// <param name="dispatchDto">发运单DTO</param>
        /// <param name="no">订单编号</param>
        /// <returns></returns>
        public TMD_DISPATCHDTO CreateDispatchDetailsProduct(TMD_DISPATCHDTO dispatchDto, string no)
        {
            TMO_ORDER details = _ConDetails.First(x => x.C_ORDER_NO.Equals(no));
            TMO_CON con = _Con.FirstOrDefault(x => x.C_CON_NO.Equals(details.C_CON_NO));

            if (dispatchDto.Rolls.Count > 0)
            {
                for (int i = 0; i < dispatchDto.Rolls.Count; i++)
                {
                    TMD_DISPATCHDETAILSDTO ddDto = new TMD_DISPATCHDETAILSDTO();
                    ddDto.C_ID = Guid.NewGuid().ToString();
                    ddDto.C_DISPATCH_ID = dispatchDto.C_ID;
                    ddDto.C_STOVE = dispatchDto.Rolls[i].C_STOVE;
                    ddDto.C_BATCH_NO = dispatchDto.Rolls[i].C_BATCH_NO;
                    ddDto.C_TICK_NO = dispatchDto.Rolls[i].C_TICK_NO;
                    ddDto.C_MAT_CODE = details.C_MAT_CODE;
                    ddDto.C_MAT_NAME = details.C_MAT_NAME;
                    ddDto.C_SPEC = details.C_SPEC;
                    ddDto.C_STL_GRD = details.C_STL_GRD;
                    ddDto.C_STD_CODE = details.C_STD_CODE;
                    string lineCode = dispatchDto.Rolls[i].C_LINEWH_CODE;
                    //var line = _LineWh.FirstOrDefault(x => x.C_LINEWH_CODE == lineCode);
                    ddDto.C_SEND_STOCK = lineCode;
                    ddDto.C_QUALIRY_LEV = dispatchDto.Rolls[i].C_JUDGE_LEV_ZH;
                    ddDto.N_WGT = dispatchDto.Rolls[i].N_WGT;
                    ddDto.C_UNITIS = "吨";
                    ddDto.C_SEND_SITE = "邢钢库存组织";
                    ddDto.C_ORGO_CUST = con == null ? "" : con.C_CUSTNAME;
                    ddDto.C_CGC = details.C_RECEIPTCORPID;
                    ddDto.C_ORDER_TYPE = details.N_TYPE.ToString();
                    ddDto.C_SEND_AREA = "邢钢库存组织";
                    ddDto.C_AREA = details.C_AREA;
                    ddDto.C_AU_UNITIS = "件";
                    ddDto.C_PRODUCT_ID = dispatchDto.Rolls[i].C_ID;
                    ddDto.C_JUDGE_LEV_ZH = dispatchDto.Rolls[i].C_JUDGE_LEV_ZH;
                    ddDto.C_NO = no;
                    ddDto.C_CON_NO = con == null ? "" : con.C_CON_NO;
                    ddDto.C_FREE_TERM = details.C_FREE1;
                    ddDto.C_FREE_TERM2 = details.C_FREE2;
                    ddDto.C_PACK = details.C_PACK;
                    dispatchDto.DispatchDetails.Add(ddDto);
                }
            }

            dispatchDto.DispatchDetails = dispatchDto.DispatchDetails.OrderBy(x => x.C_BATCH_NO).ThenBy(x => x.C_TICK_NO).ToList();

            return dispatchDto;
        }

        /// <summary>
        /// 创建发运单明细(线材 修改时使用)
        /// </summary>
        /// <param name="dispatchDto">发运单DTO</param>
        /// <param name="no">订单编号</param>
        /// <returns></returns>
        public TMD_DISPATCHDTO CreateDispatchDetailsProduct(TMD_DISPATCHDTO dispatchDto, string no, int type)
        {
            TMO_ORDER details = _ConDetails.First(x => x.C_ORDER_NO.Equals(no));
            TMO_CON con = _Con.FirstOrDefault(x => x.C_CON_NO.Equals(details.C_CON_NO));

            if (dispatchDto.Rolls.Count > 0)
            {
                for (int i = 0; i < dispatchDto.Rolls.Count; i++)
                {
                    TMD_DISPATCHDETAILSDTO ddDto = new TMD_DISPATCHDETAILSDTO();
                    ddDto.C_ID = Guid.NewGuid().ToString();
                    ddDto.C_DISPATCH_ID = dispatchDto.C_ID;
                    ddDto.C_STOVE = dispatchDto.Rolls[i].C_STOVE;
                    ddDto.C_BATCH_NO = dispatchDto.Rolls[i].C_BATCH_NO;
                    ddDto.C_TICK_NO = dispatchDto.Rolls[i].C_TICK_NO;
                    ddDto.C_MAT_CODE = details.C_MAT_CODE;
                    ddDto.C_MAT_NAME = details.C_MAT_NAME;
                    ddDto.C_SPEC = details.C_SPEC;
                    ddDto.C_STL_GRD = details.C_STL_GRD;
                    ddDto.C_STD_CODE = details.C_STD_CODE;
                    string lineCode = dispatchDto.Rolls[i].C_LINEWH_CODE;
                    //var line = _LineWh.FirstOrDefault(x => x.C_LINEWH_CODE == lineCode);
                    ddDto.C_SEND_STOCK = lineCode;
                    ddDto.C_QUALIRY_LEV = dispatchDto.Rolls[i].C_JUDGE_LEV_ZH;
                    ddDto.N_WGT = dispatchDto.Rolls[i].N_WGT;
                    ddDto.C_UNITIS = "吨";
                    ddDto.C_SEND_SITE = "邢钢库存组织";
                    ddDto.C_ORGO_CUST = con == null ? "" : con.C_CUSTNAME;
                    ddDto.C_CGC = details.C_RECEIPTCORPID;
                    ddDto.C_ORDER_TYPE = details.N_TYPE.ToString();
                    ddDto.C_SEND_AREA = "邢钢库存组织";
                    ddDto.C_AREA = details.C_AREA;
                    ddDto.C_AU_UNITIS = "件";
                    ddDto.C_PRODUCT_ID = dispatchDto.Rolls[i].C_ID;
                    ddDto.C_JUDGE_LEV_ZH = dispatchDto.Rolls[i].C_JUDGE_LEV_ZH;
                    ddDto.C_NO = no;
                    ddDto.C_CON_NO = con == null ? "" : con.C_CON_NO;
                    ddDto.Flag = 1;
                    ddDto.C_FREE_TERM = details.C_FREE1;
                    ddDto.C_FREE_TERM2 = details.C_FREE2;
                    ddDto.C_PACK = details.C_PACK;
                    dispatchDto.DispatchDetails.Add(ddDto);
                }
            }

            dispatchDto.DispatchDetails = dispatchDto.DispatchDetails.OrderBy(x => x.C_BATCH_NO).ThenBy(x => x.C_TICK_NO).ToList();

            return dispatchDto;
        }

        /// <summary>
        /// 创建发运单明细(线材补单)
        /// </summary>
        /// <param name="dispatchDto">发运单DTO</param>
        /// <param name="no">订单编号</param>
        /// <returns></returns>
        public TMD_DISPATCHDTO CreateSupplementProduct(TMD_DISPATCHDTO dispatchDto, string no)
        {
            TMO_ORDER details = _ConDetails.First(x => x.C_ORDER_NO.Equals(no));
            TMO_CON con = _Con.FirstOrDefault(x => x.C_CON_NO.Equals(details.C_CON_NO));

            if (dispatchDto.Rolls.Count > 0)
            {
                for (int i = 0; i < dispatchDto.Rolls.Count; i++)
                {
                    //如果以包含当前补单则不在添加
                    if (dispatchDto.SupplementDispatchDetails.Any(x => x.C_PRODUCT_ID.Equals(dispatchDto.Rolls[i].C_ID)))
                        continue;
                    TMD_DISPATCHDETAILSDTO ddDto = new TMD_DISPATCHDETAILSDTO();
                    ddDto.C_ID = Guid.NewGuid().ToString();
                    ddDto.C_DISPATCH_ID = dispatchDto.C_ID;
                    ddDto.C_STOVE = dispatchDto.Rolls[i].C_STOVE;
                    ddDto.C_BATCH_NO = dispatchDto.Rolls[i].C_BATCH_NO;
                    ddDto.C_TICK_NO = dispatchDto.Rolls[i].C_TICK_NO;
                    ddDto.C_MAT_CODE = details.C_MAT_CODE;
                    ddDto.C_MAT_NAME = details.C_MAT_NAME;
                    ddDto.C_SPEC = details.C_SPEC;
                    ddDto.C_STL_GRD = details.C_STL_GRD;
                    ddDto.C_STD_CODE = details.C_STD_CODE;
                    string lineCode = dispatchDto.Rolls[i].C_LINEWH_CODE;
                    //var line = _LineWh.FirstOrDefault(x => x.C_LINEWH_CODE == lineCode);
                    ddDto.C_SEND_STOCK = lineCode;
                    ddDto.C_QUALIRY_LEV = dispatchDto.Rolls[i].C_JUDGE_LEV_ZH;
                    ddDto.N_WGT = dispatchDto.Rolls[i].N_WGT;
                    ddDto.C_UNITIS = "吨";
                    ddDto.C_SEND_SITE = "邢钢库存组织";
                    ddDto.C_ORGO_CUST = con == null ? "" : con.C_CUSTNAME;
                    ddDto.C_CGC = details.C_RECEIPTCORPID;
                    ddDto.C_ORDER_TYPE = details.N_TYPE.ToString();
                    ddDto.C_SEND_AREA = "邢钢库存组织";
                    ddDto.C_AREA = details.C_AREA;
                    ddDto.C_AU_UNITIS = "件";
                    ddDto.C_PRODUCT_ID = dispatchDto.Rolls[i].C_ID;
                    ddDto.C_JUDGE_LEV_ZH = dispatchDto.Rolls[i].C_JUDGE_LEV_ZH;
                    ddDto.C_NO = no;
                    ddDto.C_CON_NO = con == null ? "" : con.C_CON_NO;
                    ddDto.C_FREE_TERM = details.C_FREE1;
                    ddDto.C_FREE_TERM2 = details.C_FREE2;
                    ddDto.C_PACK = details.C_PACK;
                    dispatchDto.SupplementDispatchDetails.Add(ddDto);
                }
            }

            dispatchDto.SupplementDispatchDetails = dispatchDto.SupplementDispatchDetails.OrderBy(x => x.C_BATCH_NO).ToList();

            return dispatchDto;
        }

        /// <summary>
        /// 创建发运单明细(钢坯)
        /// </summary>
        /// <param name="dispatchDto">发运单DTO</param>
        /// <returns></returns>
        public TMD_DISPATCHDTO CreateDispatchDetailsSlab(TMD_DISPATCHDTO dispatchDto, string no)
        {
            TMO_ORDER details = _ConDetails.First(x => x.C_ORDER_NO.Equals(no));
            TMO_CON con = _Con.FirstOrDefault(x => x.C_CON_NO.Equals(details.C_CON_NO));

            if (dispatchDto.Slabs.Count > 0)
            {
                for (int i = 0; i < dispatchDto.Slabs.Count; i++)
                {
                    TMD_DISPATCHDETAILSDTO ddDto = new TMD_DISPATCHDETAILSDTO();
                    ddDto.C_ID = Guid.NewGuid().ToString();
                    ddDto.C_DISPATCH_ID = dispatchDto.C_ID;
                    ddDto.C_STOVE = dispatchDto.Slabs[i].C_STOVE;
                    ddDto.C_BATCH_NO = dispatchDto.Slabs[i].C_BATCH_NO;
                    ddDto.C_SLAB_NO = dispatchDto.Slabs[i].C_SLAB_NO;
                    ddDto.C_MAT_CODE = details.C_MAT_CODE;
                    ddDto.C_MAT_NAME = details.C_MAT_NAME;
                    ddDto.C_SPEC = details.C_SPEC;
                    ddDto.C_STL_GRD = details.C_STL_GRD;
                    ddDto.C_STD_CODE = details.C_STD_CODE;
                    string lineCode = dispatchDto.Slabs[i].C_SLABWH_CODE;
                    //var line = _SlabWh.FirstOrDefault(x => x.C_SLABWH_CODE == lineCode);
                    ddDto.C_SEND_STOCK = lineCode;
                    ddDto.C_QUALIRY_LEV = dispatchDto.Slabs[i].C_JUDGE_LEV_ZH;
                    ddDto.N_WGT = dispatchDto.Slabs[i].N_WGT;
                    ddDto.C_UNITIS = "吨";
                    ddDto.C_SEND_SITE = "邢钢库存组织";
                    ddDto.C_ORGO_CUST = con == null ? "" : con.C_CUSTNAME;
                    ddDto.C_CGC = details.C_RECEIPTCORPID;
                    ddDto.C_ORDER_TYPE = details.N_TYPE.ToString();
                    ddDto.C_SEND_AREA = "邢钢库存组织";
                    ddDto.C_AREA = details.C_AREA;
                    ddDto.C_AU_UNITIS = "件";
                    ddDto.C_PRODUCT_ID = dispatchDto.Slabs[i].C_ID;
                    ddDto.C_JUDGE_LEV_ZH = dispatchDto.Slabs[i].C_JUDGE_LEV_ZH;
                    ddDto.C_NO = no;
                    ddDto.C_FREE_TERM = details.C_FREE1;
                    ddDto.C_FREE_TERM2 = details.C_FREE2;
                    ddDto.C_PACK = details.C_PACK;
                    ddDto.C_CON_NO = details.C_CON_NO;
                    dispatchDto.DispatchDetails.Add(ddDto);
                }
            }

            dispatchDto.DispatchDetails = dispatchDto.DispatchDetails.OrderBy(x => x.C_BATCH_NO).ThenBy(x => x.C_SLAB_NO).ToList();

            return dispatchDto;
        }

        /// <summary>
        /// 创建发运单明细(钢坯 修改时使用)
        /// </summary>
        /// <param name="dispatchDto">发运单DTO</param>
        /// <returns></returns>
        public TMD_DISPATCHDTO CreateDispatchDetailsSlab(TMD_DISPATCHDTO dispatchDto, string no, int type)
        {
            TMO_ORDER details = _ConDetails.First(x => x.C_ORDER_NO.Equals(no));
            TMO_CON con = _Con.FirstOrDefault(x => x.C_CON_NO.Equals(details.C_CON_NO));

            if (dispatchDto.Slabs.Count > 0)
            {
                for (int i = 0; i < dispatchDto.Slabs.Count; i++)
                {
                    TMD_DISPATCHDETAILSDTO ddDto = new TMD_DISPATCHDETAILSDTO();
                    ddDto.C_ID = Guid.NewGuid().ToString();
                    ddDto.C_DISPATCH_ID = dispatchDto.C_ID;
                    ddDto.C_STOVE = dispatchDto.Slabs[i].C_STOVE;
                    ddDto.C_BATCH_NO = dispatchDto.Slabs[i].C_BATCH_NO;
                    ddDto.C_SLAB_NO = dispatchDto.Slabs[i].C_SLAB_NO;
                    ddDto.C_MAT_CODE = details.C_MAT_CODE;
                    ddDto.C_MAT_NAME = details.C_MAT_NAME;
                    ddDto.C_SPEC = details.C_SPEC;
                    ddDto.C_STL_GRD = details.C_STL_GRD;
                    ddDto.C_STD_CODE = details.C_STD_CODE;
                    string lineCode = dispatchDto.Slabs[i].C_SLABWH_CODE;
                    //var line = _SlabWh.FirstOrDefault(x => x.C_SLABWH_CODE == lineCode);
                    ddDto.C_SEND_STOCK = lineCode;
                    ddDto.C_QUALIRY_LEV = dispatchDto.Slabs[i].C_JUDGE_LEV_ZH;
                    ddDto.N_WGT = dispatchDto.Slabs[i].N_WGT;
                    ddDto.C_UNITIS = "吨";
                    ddDto.C_SEND_SITE = "邢钢库存组织";
                    ddDto.C_ORGO_CUST = con == null ? "" : con.C_CUSTNAME;
                    ddDto.C_CGC = details.C_RECEIPTCORPID;
                    ddDto.C_ORDER_TYPE = details.N_TYPE.ToString();
                    ddDto.C_SEND_AREA = "邢钢库存组织";
                    ddDto.C_AREA = details.C_AREA;
                    ddDto.C_AU_UNITIS = "件";
                    ddDto.C_PRODUCT_ID = dispatchDto.Slabs[i].C_ID;
                    ddDto.C_JUDGE_LEV_ZH = dispatchDto.Slabs[i].C_JUDGE_LEV_ZH;
                    ddDto.C_NO = no;
                    ddDto.Flag = 1;
                    ddDto.C_FREE_TERM = details.C_FREE1;
                    ddDto.C_FREE_TERM2 = details.C_FREE2;
                    ddDto.C_PACK = details.C_PACK;
                    ddDto.C_CON_NO = details.C_CON_NO;
                    dispatchDto.DispatchDetails.Add(ddDto);
                }
            }

            dispatchDto.DispatchDetails = dispatchDto.DispatchDetails.OrderBy(x => x.C_BATCH_NO).ThenBy(x => x.C_SLAB_NO).ToList();

            return dispatchDto;
        }

        /// <summary>
        /// 创建发运单明细(钢坯补单)
        /// </summary>
        /// <param name="dispatchDto">发运单DTO</param>
        /// <param name="no">订单编号</param>
        /// <returns></returns>
        public TMD_DISPATCHDTO CreateSupplementSlab(TMD_DISPATCHDTO dispatchDto, string no)
        {
            TMO_ORDER details = _ConDetails.First(x => x.C_ORDER_NO.Equals(no));
            TMO_CON con = _Con.FirstOrDefault(x => x.C_CON_NO.Equals(details.C_CON_NO));

            if (dispatchDto.Slabs.Count > 0)
            {
                for (int i = 0; i < dispatchDto.Slabs.Count; i++)
                {
                    //如果以包含当前补单则不在添加
                    if (dispatchDto.SupplementDispatchDetails.Any(x => x.C_PRODUCT_ID.Equals(dispatchDto.Slabs[i].C_ID)))
                        continue;
                    TMD_DISPATCHDETAILSDTO ddDto = new TMD_DISPATCHDETAILSDTO();
                    ddDto.C_ID = Guid.NewGuid().ToString();
                    ddDto.C_DISPATCH_ID = dispatchDto.C_ID;
                    ddDto.C_STOVE = dispatchDto.Slabs[i].C_STOVE;
                    ddDto.C_BATCH_NO = dispatchDto.Slabs[i].C_BATCH_NO;
                    ddDto.C_SLAB_NO = dispatchDto.Slabs[i].C_SLAB_NO;
                    ddDto.C_MAT_CODE = details.C_MAT_CODE;
                    ddDto.C_MAT_NAME = details.C_MAT_NAME;
                    ddDto.C_SPEC = details.C_SPEC;
                    ddDto.C_STL_GRD = details.C_STL_GRD;
                    ddDto.C_STD_CODE = details.C_STD_CODE;
                    string lineCode = dispatchDto.Slabs[i].C_SLABWH_CODE;
                    //var line = _SlabWh.FirstOrDefault(x => x.C_SLABWH_CODE == lineCode);
                    ddDto.C_SEND_STOCK = lineCode;
                    ddDto.C_QUALIRY_LEV = dispatchDto.Slabs[i].C_JUDGE_LEV_ZH;
                    ddDto.N_WGT = dispatchDto.Slabs[i].N_WGT;
                    ddDto.C_UNITIS = "吨";
                    ddDto.C_SEND_SITE = "邢钢库存组织";
                    ddDto.C_ORGO_CUST = con == null ? "" : con.C_CUSTNAME;
                    ddDto.C_CGC = details.C_RECEIPTCORPID;
                    ddDto.C_ORDER_TYPE = details.N_TYPE.ToString();
                    ddDto.C_SEND_AREA = "邢钢库存组织";
                    ddDto.C_AREA = details.C_AREA;
                    ddDto.C_AU_UNITIS = "件";
                    ddDto.C_PRODUCT_ID = dispatchDto.Slabs[i].C_ID;
                    ddDto.C_JUDGE_LEV_ZH = dispatchDto.Slabs[i].C_JUDGE_LEV_ZH;
                    ddDto.C_NO = no;
                    ddDto.C_CON_NO = con == null ? "" : con.C_CON_NO;
                    ddDto.C_FREE_TERM = details.C_FREE1;
                    ddDto.C_FREE_TERM2 = details.C_FREE2;
                    ddDto.C_PACK = details.C_PACK;
                    ddDto.C_CON_NO = details.C_CON_NO;
                    dispatchDto.SupplementDispatchDetails.Add(ddDto);
                }
            }

            dispatchDto.SupplementDispatchDetails = dispatchDto.SupplementDispatchDetails.OrderBy(x => x.C_BATCH_NO).ToList();

            return dispatchDto;
        }


        /// <summary>
        /// 创建发运单明细(渣 焦化产品)
        /// </summary>
        /// <param name="dispatchDto">发运单DTO</param>
        /// <param name="no">订单编号</param>
        /// <returns></returns>
        public TMD_DISPATCHDTO CreateDispatchDetailsOther(TMD_DISPATCHDTO dispatchDto, string no)
        {
            TMO_ORDER details = _ConDetails.First(x => x.C_ORDER_NO.Equals(no));
            TMO_CON con = _Con.FirstOrDefault(x => x.C_CON_NO.Equals(details.C_CON_NO));
            dispatchDto.DispatchDetails.Clear();
            TMD_DISPATCHDETAILSDTO ddDto = new TMD_DISPATCHDETAILSDTO();
            ddDto.C_ID = Guid.NewGuid().ToString();
            ddDto.C_DISPATCH_ID = dispatchDto.C_ID;
            ddDto.C_MAT_CODE = details.C_MAT_CODE;
            ddDto.C_MAT_NAME = details.C_MAT_NAME;
            ddDto.C_SPEC = details.C_SPEC;
            ddDto.C_STL_GRD = details.C_STL_GRD;
            ddDto.C_STD_CODE = details.C_STD_CODE;
            ddDto.N_WGT = details.N_WGT;
            ddDto.C_UNITIS = "吨";
            ddDto.C_SEND_SITE = "邢钢库存组织";
            ddDto.C_ORGO_CUST = con == null ? "" : con.C_CUSTNAME;
            ddDto.C_CGC = details.C_RECEIPTCORPID;
            ddDto.C_ORDER_TYPE = details.N_TYPE.ToString();
            ddDto.C_SEND_AREA = "邢钢库存组织";
            ddDto.C_AREA = details.C_AREA;
            ddDto.C_AU_UNITIS = "件";
            ddDto.C_NO = no;
            ddDto.C_CON_NO = con == null ? "" : con.C_CON_NO;
            ddDto.C_FREE_TERM = details.C_FREE1;
            ddDto.C_FREE_TERM2 = details.C_FREE2;
            ddDto.C_PACK = details.C_PACK;
            dispatchDto.DispatchDetails.Add(ddDto);
            return dispatchDto;
        }

        /// <summary>
        /// 添加发运单
        /// </summary>
        /// <param name="dDto"></param>
        public void DispatchInsert(TMD_DISPATCHDTO dDto)
        {
            try
            {
                #region 添加发运单

                TMD_DISPATCH dEf = AutoMapper.Mapper.Map<TMD_DISPATCH>(dDto);
                if (dDto.PitchConDetails != null && dDto.PitchConDetails.Count > 0)
                {
                    string no = dDto.PitchConDetails[0].C_ORDER_NO;
                    var plan = _DayPlan.FirstOrDefault(x => x.C_ORDERNO.Equals(no));
                    dEf.C_CON_NO = dDto.PitchConDetails[0].C_CON_NO;
                    dEf.C_SEND_DEPT = plan.C_PKDELIVORG;
                    dEf.C_BUSINESS_DEPT = plan.C_PKOPRDEPART;
                    dEf.C_BUSINESS_ID = plan.C_PKOPERATOR;
                }
                dEf.C_STATUS = "0";
                dEf.C_EXTEND1 = "0";
                dEf = Insert(dEf);
                #endregion

                #region 删除明细(发运单明细 关系表)
                var conDets = _DisConDet.Where(x => x.C_DISPATCH_ID.Equals(dDto.C_ID)).ToList();
                if (conDets.Count > 0)
                    this.Delete<TMD_DIS_CONDET>(conDets);
                var dds = _DispatchDetails.Where(x => x.C_DISPATCH_ID.Equals(dDto.C_ID)).ToList();
                if (dds.Count() > 0)
                    this.Delete<TMD_DISPATCHDETAILS>(dds);
                #endregion

                #region 添加关系表
                List<TMD_DIS_CONDET> list = new List<TMD_DIS_CONDET>();
                foreach (var item in dDto.PitchConDetails)
                {
                    TMD_DIS_CONDET newEf = new TMD_DIS_CONDET();
                    newEf.C_DISPATCH_ID = dDto.C_ID;
                    newEf.C_NO = item.C_ORDER_NO;
                    list.Add(newEf);
                }
                Insert<TMD_DIS_CONDET>(list);
                #endregion

                #region 添加明细
                if (dDto.DispatchDetails.Count > 0)
                {
                    foreach (var con in dDto.PitchConDetails)
                    {
                        List<TMD_DISPATCHDETAILSDTO> dtDtos = dDto.DispatchDetails.Where(x => x.C_NO.Equals(con.C_ORDER_NO)).ToList();
                        var conDetail = _ConDetails.FirstOrDefault(x => x.C_ORDER_NO.Equals(con.C_ORDER_NO));
                        var plan = _DayPlan.FirstOrDefault(x => x.C_ORDERNO.Equals(con.C_ORDER_NO));
                        if (dtDtos.Count > 0)
                        {
                            List<TMD_DISPATCHDETAILS> dtEfs = MAPPING.ConvertDtoToEntityList<TMD_DISPATCHDETAILSDTO, TMD_DISPATCHDETAILS>(dtDtos);
                            List<TSC_SLAB_MAIN> slabs = new List<TSC_SLAB_MAIN>();
                            dtEfs.ForEach(x =>
                            {
                                x.C_DISPATCH_ID = dDto.C_ID;
                                x.C_CON_NO = conDetail.C_CON_NO;
                                if (plan != null)
                                {
                                    x.C_PLAN_ID = plan.C_ID;
                                    x.C_PLAN_CODE = plan.C_PLCODE;
                                }
                            });

                            this.Insert<TMD_DISPATCHDETAILS>(dtEfs);
                        }
                    }
                }
                #endregion


                List<Result> results = this.ExcuteQuery<Result>(@"SELECT TDD.C_PRODUCT_ID FROM TMD_DISPATCH T
                     JOIN TMD_DISPATCHDETAILS TDD
                       ON TDD.C_DISPATCH_ID = T.C_ID
                    WHERE T.C_ID = '" + dEf.C_ID + "'").ToList();
                if (results.Count > 0)
                {
                    string fromName = "";
                    if (dEf.C_IS_WIRESALE == "是")
                        fromName = " TRC_ROLL_PRODCUT ";
                    else
                        fromName = " TSC_SLAB_MAIN ";

                    string sql = @" UPDATE " + fromName + " T";
                    sql += " SET T.C_FYDH = '" + dEf.C_ID + "'  ";
                    sql += @"  WHERE T.C_ID IN ( ";

                    for (int i = 0; i < results.Count; i++)
                    {
                        if (i == results.Count - 1)
                            sql += " '" + results[i].C_PRODUCT_ID + "' ";
                        else
                            sql += " '" + results[i].C_PRODUCT_ID + "' , ";
                    }

                    sql += "  )  ";
                    this.Excute<TRC_ROLL_PRODCUT>(sql);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 获取发运单
        /// </summary>
        /// <param name="no">发运单单据号</param>
        /// <returns></returns>
        public TMD_DISPATCHDTO GetDispatch(string id)
        {
            //获取发运单
            TMD_DISPATCH dEf = _Dispatch.FirstOrDefault(x => x.C_ID == id);
            TMD_DISPATCHDTO dDto = null;
            if (dEf != null)
            {
                //转换DTO
                dDto = AutoMapper.Mapper.Map<TMD_DISPATCHDTO>(dEf);
                //获取发运单详情
                dDto.DispatchDetails = GetDispatchDetails(id);

                List<string> nos = new List<string>();
                //通过中间表获取所有选中订单
                var dcdEF = _DisConDet.Where(x => x.C_DISPATCH_ID.Equals(dEf.C_ID));
                if (dcdEF != null && dcdEF.Count() > 0)
                {
                    foreach (var item in dcdEF)
                    {
                        nos.Add(item.C_NO);
                    }
                    //获取选中订单
                    dDto.PitchConDetails = GetDispatchConDetails(nos);
                }
            }
            return dDto;
        }

        /// <summary>
        /// 获取发运单详情
        /// </summary>
        /// <returns></returns>
        public List<TMD_DISPATCHDETAILSDTO> GetDispatchDetails(string id)
        {
            try
            {
                List<TMD_DISPATCHDETAILS> ddEf = _DispatchDetails
                    .Where(x => x.C_DISPATCH_ID.Equals(id))
                    .OrderBy(x => x.C_BATCH_NO)
                    .ThenBy(x => x.C_TICK_NO)
                    .ThenBy(x => x.C_SLAB_NO)
                    .ToList();
                return MAPPING.ConvertEntityToDtoList<TMD_DISPATCHDETAILS, TMD_DISPATCHDETAILSDTO>(ddEf);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// 发运单修改
        /// </summary>
        /// <param name="dDto"></param>
        public void DispatchUpdate(TMD_DISPATCHDTO dDto)
        {
            try
            {
                TMD_DISPATCH dEf = AutoMapper.Mapper.Map<TMD_DISPATCH>(dDto);
                if (dDto.PitchConDetails != null && dDto.PitchConDetails.Count > 0)
                {
                    string no = dDto.PitchConDetails[0].C_ORDER_NO;
                    var plan = _DayPlan.FirstOrDefault(x => x.C_ORDERNO.Equals(no));
                    dEf.C_SEND_DEPT = plan.C_PKDELIVORG;
                    dEf.C_BUSINESS_DEPT = plan.C_PKOPRDEPART;
                    dEf.C_BUSINESS_ID = plan.C_PKOPERATOR;
                }
                Update(dEf);


                #region 删除明细(发运单明细 关系表)
                var conDets = _DisConDet.Where(x => x.C_DISPATCH_ID.Equals(dDto.C_ID)).ToList();
                if (conDets.Count > 0)
                    this.Delete<TMD_DIS_CONDET>(conDets);
                var dds = _DispatchDetails.Where(x => x.C_DISPATCH_ID.Equals(dDto.C_ID)).ToList();
                if (dds.Count() > 0)
                    this.Delete<TMD_DISPATCHDETAILS>(dds);
                #endregion

                #region 添加关系表
                List<TMD_DIS_CONDET> list = new List<TMD_DIS_CONDET>();
                foreach (var item in dDto.PitchConDetails)
                {
                    TMD_DIS_CONDET newEf = new TMD_DIS_CONDET();
                    newEf.C_DISPATCH_ID = dDto.C_ID;
                    newEf.C_NO = item.C_ORDER_NO;
                    list.Add(newEf);
                }
                Insert<TMD_DIS_CONDET>(list);
                #endregion

                #region 添加明细
                if (dDto.DispatchDetails.Count > 0)
                {
                    foreach (var con in dDto.PitchConDetails)
                    {
                        List<TMD_DISPATCHDETAILSDTO> dtDtos = dDto.DispatchDetails.Where(x => x.C_NO.Equals(con.C_ORDER_NO)).ToList();
                        var conDetail = _ConDetails.FirstOrDefault(x => x.C_ORDER_NO.Equals(con.C_ORDER_NO));
                        var plan = _DayPlan.FirstOrDefault(x => x.C_ORDERNO.Equals(con.C_ORDER_NO));
                        if (dtDtos.Count > 0)
                        {
                            List<TMD_DISPATCHDETAILS> dtEfs = MAPPING.ConvertDtoToEntityList<TMD_DISPATCHDETAILSDTO, TMD_DISPATCHDETAILS>(dtDtos);
                            List<TSC_SLAB_MAIN> slabs = new List<TSC_SLAB_MAIN>();
                            dtEfs.ForEach(x =>
                            {
                                x.C_DISPATCH_ID = dDto.C_ID;
                                x.C_CON_NO = conDetail.C_CON_NO;
                                x.C_ID = Guid.NewGuid().ToString();
                                if (plan != null)
                                {
                                    x.C_PLAN_ID = plan.C_ID;
                                    x.C_PLAN_CODE = plan.C_PLCODE;
                                }

                            });
                            this.Insert<TMD_DISPATCHDETAILS>(dtEfs);
                        }
                    }
                }
                #endregion

                List<Result> results = this.ExcuteQuery<Result>(@"SELECT TDD.C_PRODUCT_ID FROM TMD_DISPATCH T
                     JOIN TMD_DISPATCHDETAILS TDD
                       ON TDD.C_DISPATCH_ID = T.C_ID
                    WHERE T.C_ID = '" + dEf.C_ID + "'").ToList();
                if (results.Count > 0)
                {
                    string fromName = "";
                    if (dEf.C_IS_WIRESALE == "是")
                        fromName = " TRC_ROLL_PRODCUT ";
                    else
                        fromName = " TSC_SLAB_MAIN ";

                    string sql = @" UPDATE " + fromName + " T";
                    sql += " SET T.C_FYDH = '" + dEf.C_ID + "'  ";
                    sql += @"  WHERE T.C_ID IN ( ";

                    for (int i = 0; i < results.Count; i++)
                    {
                        if (i == results.Count - 1)
                            sql += " '" + results[i].C_PRODUCT_ID + "' ";
                        else
                            sql += " '" + results[i].C_PRODUCT_ID + "' , ";
                    }

                    sql += "  )  ";
                    this.Excute<TRC_ROLL_PRODCUT>(sql);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 导入NC
        /// </summary>
        /// <param name="dDto"></param>
        /// <param name="flag"></param>
        public string DispatchImportNc(TMD_DISPATCHDTO dDto, string flag)
        {
            string result = "1";
            TMD_DISPATCH dEf = AutoMapper.Mapper.Map<TMD_DISPATCH>(dDto);

            ApiDispatchOrder aip = new ApiDispatchOrder();
            string filePath = "FileInterface\\" + dEf.C_ID + ".xml";
            string xmlName = AppDomain.CurrentDomain.BaseDirectory + filePath;
            var strs = aip.SendXmlApiDispatchOrder(dEf.C_ID, xmlName, dEf.C_EMP_ID, int.Parse(flag));
            if (strs[0] == "1")
            {
                dEf.C_REMARK = strs[1];
                Update(dEf);
            }
            else
                result = strs[1];

            return result;
        }

        /// <summary>
        /// 导入物流
        /// </summary>
        /// <param name="dDto"></param>
        /// <param name="flag"></param>
        public string DispatchImportLg(TMD_DISPATCHDTO dDto)
        {
            string result = "1";
            TMD_DISPATCH dEf = AutoMapper.Mapper.Map<TMD_DISPATCH>(dDto);
            ApiWL aip = new ApiWL();
            string filePath = "FileInterface\\" + dEf.C_ID + ".xml";
            string xmlName = AppDomain.CurrentDomain.BaseDirectory + filePath;
            var strs = aip.SendXmlApiDispatchOrder(dEf.C_ID, xmlName, dEf.C_EMP_ID);
            if (strs == "success")
            {
                Update(dEf);
            }
            else
                result = "0";
            return result;
        }

        /// <summary>
        /// 获取合同详情
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<TMO_CONDETAILSDTO> GetDispatchConDetails(List<string> ids)
        {
            Expression<Func<TMO_ORDER, bool>> where = null;

            foreach (var item in ids)
            {
                where = where.Or<TMO_ORDER>(x => x.C_ORDER_NO.Equals(item) & x.N_STATUS == 2);
            }

            List<TMO_CONDETAILSDTO> list = MAPPING.ConvertEntityToDtoList<TMO_ORDER, TMO_CONDETAILSDTO>(_ConDetails.Where(where).ToList());

            return list;
        }

        /// <summary>
        /// 修改线材库存状态
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="type">1生效发运单，2撤销发运单</param>
        /// <returns></returns>
        public string UpdateTRCStoveStatus(TMD_DISPATCHDTO dto, int type)
        {
            int count = dto.DispatchDetails.Count;
            string result = string.Empty;
            string moveType = "0";
            if (type != 1)
            {
                moveType = "E";
            }

            using (var tran = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {

                    string sql = @"   update   trc_roll_prodcut t    set ";
                    sql += "  t.c_Move_Type='" + moveType + "' ";
                    sql += "  where  (";

                    for (int i = 0; i < count; i++)
                    {
                        if (i == dto.DispatchDetails.Count - 1)
                        {
                            sql += "  t.c_id =  '" + dto.DispatchDetails[i].C_PRODUCT_ID + "'    )   ";
                        }
                        else
                        {
                            sql += "  t.c_id =  '" + dto.DispatchDetails[i].C_PRODUCT_ID + "'  or   ";
                        }
                    }

                    if (type == 1)
                        sql += "  and  t.c_Move_Type!='0'   ";

                    int exec = this.Excute<TRC_ROLL_PRODCUT>(sql);

                    if (exec == count)
                    {
                        result = "1";
                        tran.Complete();
                    }
                    else
                    {
                        result = "0";
                    }

                }
                catch (Exception ex)
                {
                    result = "0";
                }

                return result;
            }
        }

        /// <summary>
        /// 修改钢坯库存状态
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="type">1生效发运单，2撤销发运单</param>
        /// <returns></returns>
        public string UpdateTSCStoveStatus(TMD_DISPATCHDTO dto, int type)
        {
            int count = dto.DispatchDetails.Count;
            string result = string.Empty;
            string moveType = "0";
            if (type != 1)
            {
                moveType = "E";
            }

            using (var tran = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {

                    string sql = @"   update   tsc_slab_main  t    set ";
                    sql += "  t.c_Move_Type='" + moveType + "' ";
                    sql += "  where  (";

                    for (int i = 0; i < count; i++)
                    {
                        if (i == dto.DispatchDetails.Count - 1)
                        {
                            sql += "  t.c_id =  '" + dto.DispatchDetails[i].C_PRODUCT_ID + "'    )   ";
                        }
                        else
                        {
                            sql += "  t.c_id =  '" + dto.DispatchDetails[i].C_PRODUCT_ID + "'  or   ";
                        }
                    }

                    if (type == 1)
                        sql += "  and  t.c_Move_Type!='0'   ";

                    int exec = this.Excute<TSC_SLAB_MAIN>(sql);

                    if (exec == count)
                    {
                        result = "1";
                        tran.Complete();
                    }
                    else
                    {
                        result = "0";
                    }

                }
                catch (Exception ex)
                {
                    result = "0";
                }

                return result;
            }
        }

        /// <summary>
        /// 添加发运单日志
        /// </summary>
        /// <param name="disLog"></param>
        public void DispatchLogInsert(TMD_DISPATCH_LOG disLog, TMD_DISPATCHDTO dto)
        {
            try
            {
                var logEf = Insert<TMD_DISPATCH_LOG>(disLog);
                if (dto != null)
                {
                    var ef = AutoMapper.Mapper.Map<TMD_DISPATCH_MAIN_LOG>(dto);
                    ef.C_LOG_ID = logEf.C_ID;
                    List<TMD_DISPATCHDETAILS_MAIN_LOG> details = new List<TMD_DISPATCHDETAILS_MAIN_LOG>();

                    if (dto.DispatchDetails != null && dto.DispatchDetails.Count > 0)
                    {
                        foreach (var item in dto.DispatchDetails)
                        {
                            var detailEf = AutoMapper.Mapper.Map<TMD_DISPATCHDETAILS_MAIN_LOG>(item);
                            detailEf.C_LOG_ID = logEf.C_ID;
                            details.Add(detailEf);
                        }
                    }
                    ef.C_ID = Guid.NewGuid().ToString();
                    this.Insert(ef);
                    this.Insert<TMD_DISPATCHDETAILS_MAIN_LOG>(details);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取发运单操作记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<TMD_DISPATCH_LOG> GetDispatchLog(string id)
        {
            return _DispatchLog.Where(x => x.C_DISPATCH_ID.Equals(id)).ToList();
        }

        /// <summary>
        ///根据订单获取所有发运单重量
        /// </summary>
        /// <param name="no">订单号</param>
        public Result GetDispathWgt(string no)
        {
            //发运单数量
            string sql = @"SELECT sum(DISDETAILS.N_WGT)WGT ,count(DISDETAILS.C_ID)QUA  FROM
                                                 TMD_DISPATCHDETAILS DISDETAILS 
                                                 WHERE  DISDETAILS.C_NO='" + no + "'";
            var result = this.ExcuteQuery<Result>(sql).First();
            return result;
        }

        /// <summary>
        /// 删除发运单明细
        /// </summary>
        /// <param name="id"></param>
        public void DispatchDeitalDelete(string id)
        {
            var ef = _DispatchDetails.FirstOrDefault(x => x.C_ID.Equals(id));
            if (ef != null)
                this.Delete(ef);
        }

        /// <summary>
        /// 订单详情匹配量更新
        /// </summary>
        public void ConDetailMatchUpdate(TMD_DISPATCHDTO dto)
        {
            if (dto != null)
            {
                if (dto.PitchConDetails != null && dto.PitchConDetails.Count > 0)
                {
                    foreach (var item in dto.PitchConDetails)
                    {
                        var ef = _ConDetails.FirstOrDefault(x => x.C_ORDER_NO.Equals(item.C_ORDER_NO));
                        if (item.N_TYPE == 8)
                        {
                            ef.N_LINE_MATCH_WGT = decimal.Parse(item.DispatchSumWgt.ToString());
                        }
                        else
                        {
                            ef.N_SLAB_MATCH_WGT = decimal.Parse(item.DispatchSumWgt.ToString());
                        }
                        Update(ef);
                    }
                }
            }
        }

        /// <summary>
        /// NC发运单是否已存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int NcDisExist(string id)
        {
            string sql = @"SELECT  COUNT(*) Count  FROM dm_delivbill_b@cap_nc_cs
                                     WHERE vfree9 ='" + id + "' ";
            sql += "  AND pksalecorp = '1001'    AND dr = 0  ";
            var result = this.ExcuteQuery<Result>(sql).First();
            return result.Count;
        }

        /// <summary>
        /// 删除发运单
        /// </summary>
        public void DelDispatch(TMD_DISPATCHDTO dto)
        {
            TMD_DISPATCH dEf = AutoMapper.Mapper.Map<TMD_DISPATCH>(dto);
            Update<TMD_DISPATCH>(dEf);
        }

        /// <summary>
        /// 获取订单明细
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public TMO_CONDETAILSDTO GetOrderDetails(string orderNo)
        {
            var ef = _ConDetails.FirstOrDefault(x => x.C_ORDER_NO == orderNo);
            return AutoMapper.Mapper.Map<TMO_CONDETAILSDTO>(ef);
        }

    }
}
