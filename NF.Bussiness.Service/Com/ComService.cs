using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

using NF.Bussiness.Interface;
using NF.EF.Model;
using NF.Framework.DTO;
using System.Linq.Expressions;
using NF.Framework;
using System.Web;
using NF.Web.Core;
using System.Web.SessionState;
using System.Transactions;

namespace NF.Bussiness.Service
{
    public class ComService : BaseService, IComService
    {
        IMenuButtonService buttonService = DIFactory.GetContainer().Resolve<IMenuButtonService>();

        private DbSet<TMB_AREA> _Area;
        private DbSet<TS_DIC> _Dic;
        private DbSet<TS_DEPT> _Dept;
        private DbSet<TRC_ROLL_PRODCUT> _RollProduct;
        private DbSet<TSC_SLAB_MAIN> _StdMain;
        private DbSet<TMB_LOG> _TmbLog;

        public ComService(DbContext context) : base(context)
        {
            _Area = context.Set<TMB_AREA>();
            _Dic = context.Set<TS_DIC>();
            _Dept = context.Set<TS_DEPT>();
            _RollProduct = context.Set<TRC_ROLL_PRODCUT>();
            _StdMain = context.Set<TSC_SLAB_MAIN>();
            _TmbLog = context.Set<TMB_LOG>();
        }

        /// <summary>
        /// 获取数据字典（根据类别编码）
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public List<TS_DIC> GetTypeCodeDic(params string[] arr)
        {
            Expression<Func<TS_DIC, bool>> where = null;
            where = where.And<TS_DIC>(x => x.N_STATUS == 1);

            foreach (var item in arr)
            {
                where = where.And<TS_DIC>(x => x.C_TYPECODE == item);
            }

            return _Dic.Where(where).ToList();
        }

        /// <summary>
        /// 获取到站信息
        /// </summary>
        /// <param name="parentID">parentID</param>
        /// <returns></returns>
        public List<TMB_AREADTO> GetStation(string parentID)
        {
            List<TMB_AREADTO> list = ExcuteQuery<TMB_AREADTO>(" select * from TMB_AREA start with c_id ='dqdaa000000000000001'  connect by prior  c_id = N_PARENTID  ").ToList();
            List<TMB_AREADTO> areas = new List<TMB_AREADTO>();
            foreach (var item in list.Where(x => x.N_PARENTID == parentID))
            {
                TMB_AREADTO dto = new TMB_AREADTO();
                dto.C_ID = item.C_ID;
                dto.C_CODE = item.C_CODE;
                dto.C_NAME = item.C_NAME;
                dto.N_PARENTID = item.N_PARENTID;
                dto.N_SORT = item.N_SORT;
                dto.N_DEPTH = item.N_DEPTH;
                dto.C_REMARK = item.C_REMARK;
                dto.N_ISGPS = item.N_ISGPS;
                dto.C_EMP_ID = item.C_EMP_ID;
                dto.C_EMP_NAME = item.C_EMP_NAME;
                dto.D_MOD_DT = item.D_MOD_DT;
                dto.C_MAXAREA = item.C_MAXAREA;
                dto.N_STATUS = item.N_STATUS;
                dto.Areas = CreateChildTree(list, dto);
                areas.Add(dto);
            }
            return areas;
        }

        /// <summary>
        /// 递归生成子树
        /// </summary>
        /// <param name="AllMenuList"></param>
        /// <param name="vmMenu"></param>
        /// <returns></returns>
        private List<TMB_AREADTO> CreateChildTree(List<TMB_AREADTO> AllMenuList, TMB_AREADTO vmMenu)
        {
            string parentMenuID = vmMenu.C_ID;//根节点ID
            List<TMB_AREADTO> nodeList = new List<TMB_AREADTO>();
            var children = AllMenuList.Where(t => t.N_PARENTID == parentMenuID);
            foreach (var chl in children)
            {
                TMB_AREADTO node = new TMB_AREADTO();
                node.C_ID = chl.C_ID;
                node.C_CODE = chl.C_CODE;
                node.C_NAME = chl.C_NAME;
                node.N_PARENTID = chl.N_PARENTID;
                node.N_SORT = chl.N_SORT;
                node.N_DEPTH = chl.N_DEPTH;
                node.C_REMARK = chl.C_REMARK;
                node.N_ISGPS = chl.N_ISGPS;
                node.C_EMP_ID = chl.C_EMP_ID;
                node.C_EMP_NAME = chl.C_EMP_NAME;
                node.D_MOD_DT = chl.D_MOD_DT;
                node.C_MAXAREA = chl.C_MAXAREA;
                node.N_STATUS = chl.N_STATUS;
                node.Areas = CreateChildTree(AllMenuList, node);
                nodeList.Add(node);
            }
            return nodeList;
        }

        /// <summary>
        /// 获取部门
        /// </summary>
        /// <param name="parentID">parentID</param>
        /// <returns></returns>
        public List<TS_DEPTDTO> GetDetp(string parentID)
        {
            List<TS_DEPT> list = ExcuteQuery<TS_DEPT>("  select  *  from TS_DEPT  start with c_id ='" + parentID + "'  connect by prior  c_id = C_PARENT_ID   ").ToList();
            List<TS_DEPTDTO> areas = new List<TS_DEPTDTO>();
            foreach (var item in list.Where(x => x.C_PARENT_ID == parentID))
            {
                TS_DEPTDTO dto = new TS_DEPTDTO();
                dto.C_ID = item.C_ID;
                dto.C_CODE = item.C_CODE;
                dto.C_NAME = item.C_NAME;
                dto.C_PARENT_ID = item.C_PARENT_ID;
                dto.C_DESC = item.C_DESC;
                dto.N_STATUS = Convert.ToInt32(item.N_STATUS);
                dto.C_DEPTH = Convert.ToInt32(item.C_DEPTH);
                dto.N_DEPTATTR = item.N_DEPTATTR;
                dto.C_EMP_ID = item.C_EMP_ID;
                dto.C_EMP_NAME = item.C_EMP_NAME;
                dto.D_MOD_DT = item.D_MOD_DT;
                dto.Depts = CreateChildTree2(list, dto);
                areas.Add(dto);
            }
            return areas;
        }

        /// <summary>
        /// 递归生成子树
        /// </summary>
        /// <param name="AllMenuList"></param>
        /// <param name="vmMenu"></param>
        /// <returns></returns>
        private List<TS_DEPTDTO> CreateChildTree2(List<TS_DEPT> AllMenuList, TS_DEPTDTO vmMenu)
        {
            string parentMenuID = vmMenu.C_ID;//根节点ID
            List<TS_DEPTDTO> nodeList = new List<TS_DEPTDTO>();
            var children = AllMenuList.Where(t => t.C_PARENT_ID == parentMenuID);
            foreach (var chl in children)
            {
                TS_DEPTDTO node = new TS_DEPTDTO();
                node.C_ID = chl.C_ID;
                node.C_CODE = chl.C_CODE;
                node.C_NAME = chl.C_NAME;
                node.C_PARENT_ID = chl.C_PARENT_ID;
                node.C_DESC = chl.C_DESC;
                node.N_STATUS = Convert.ToInt32(chl.N_STATUS);
                node.C_DEPTH = Convert.ToInt32(chl.C_DEPTH);
                node.N_DEPTATTR = chl.N_DEPTATTR;
                node.C_EMP_ID = chl.C_EMP_ID;
                node.C_EMP_NAME = chl.C_EMP_NAME;
                node.D_MOD_DT = chl.D_MOD_DT;
                node.Depts = CreateChildTree2(AllMenuList, node);
                nodeList.Add(node);
            }
            return nodeList;
        }

        /// <summary>
        ///刷新按钮
        /// </summary>
        /// <param name="url"></param>
        /// <param name="user"></param>
        /// <param name="session"></param>
        public void RefreshButton(string url, CurrentUser user, HttpSessionState session)
        {

            List<TS_BUTTON> buttons = buttonService.GetButtons(url).ToList();
            List<TS_BUTTON> useButtons = new List<TS_BUTTON>();
            if (buttons == null)
            {
                buttons = new List<TS_BUTTON>();
            }

            List<TS_FUNCTIONDTO> fDtos = user.ButtonFuncs;
            foreach (var m in buttons)
            {
                if (fDtos.Exists(x => x.ButtonID.Equals(m.C_ID)))
                {
                    useButtons.Add(m);
                }
            }
            session["button"] = useButtons;
        }

        /// <summary>
        /// 获取线材库产品
        /// </summary>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="area">地区</param>
        /// <param name="stdCode">执行标准</param>
        /// <returns></returns>
        public List<TRC_ROLL_PRODCUTDTO> GetRollProducts(string stlGrd, string spec, string area, string stdCode)
        {
            var list = _RollProduct.Where(x => x.C_STL_GRD.Equals(stlGrd)
              && x.C_SPEC.Equals(spec)
              && x.C_SALE_AREA.Equals(area)
              && x.C_STD_CODE.Equals(stdCode)
              && x.C_MOVE_TYPE.Equals("E")
              && x.C_JUDGE_LEV_ZH.Equals("A")
              && x.C_IS_QR.Equals("Y")
              ).OrderBy(x => x.C_BATCH_NO).OrderBy(x => x.C_TICK_NO).ToList();
            return MAPPING.ConvertEntityToDtoList<TRC_ROLL_PRODCUT, TRC_ROLL_PRODCUTDTO>(list);
        }

        /// <summary>
        /// 获取线材库产品
        /// </summary>
        /// <param name="conDetailNo">订单号</param>
        /// <returns></returns>
        public List<TRC_ROLL_PRODCUTDTO> GetRollProducts(string conDetailNo)
        {
            List<TRC_ROLL_PRODCUT> list = _RollProduct.Where(x => x.C_ORDER_NO.Equals(conDetailNo)
               && x.C_MOVE_TYPE.Equals("E")
              && x.C_JUDGE_LEV_ZH.Equals("A")
              && x.C_IS_QR.Equals("Y"))
                .OrderBy(x => x.C_BATCH_NO).ThenBy(x => x.C_TICK_NO)
                .ToList();
            foreach (var item in list)
            {
                item.C_MOVE_TYPE = "0";
            }
            Update<TRC_ROLL_PRODCUT>(list);
            return MAPPING.ConvertEntityToDtoList<TRC_ROLL_PRODCUT, TRC_ROLL_PRODCUTDTO>(list);
        }


        /// <summary>
        /// 获取钢坯库产品
        /// </summary>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="area">地区</param>
        /// <param name="stdCode">执行标准</param>
        /// <returns></returns>
        public List<TSC_SLAB_MAINDTO> GetSlabMain(string stlGrd, string spec, string area, string stdCode)
        {
            var list = _StdMain.Where(x => x.C_STL_GRD.Equals(stlGrd)
              && x.C_SPEC.Equals(spec)
              && x.C_STD_CODE.Equals(stdCode)
              && x.C_MOVE_TYPE.Equals("E")
              && x.C_JUDGE_LEV_ZH.Equals("合格品")
              && x.C_IS_QR.Equals("Y")
              ).OrderBy(x => x.C_BATCH_NO).ThenBy(x => x.C_BATCH_NO).ToList();
            return MAPPING.ConvertEntityToDtoList<TSC_SLAB_MAIN, TSC_SLAB_MAINDTO>(list);
        }

        /// <summary>
        /// 获取钢坯库产品
        /// </summary>
        /// <param name="stlGrd">钢种</param>
        /// <param name="断面">断面</param>
        /// <param name="长度">长度</param>
        /// <param name="area">地区</param>
        /// <param name="stdCode">执行标准</param>
        /// <param name="fNum">支数</param>
        /// <returns></returns>
        public List<TSC_SLAB_MAINDTO> GetSlabMain(string stlGrd, string spec, int len, string area, string stdCode, int fNum)
        {
            var list = _StdMain.Where(x => x.C_STL_GRD==stlGrd
              && x.C_SPEC == spec
              && x.N_LEN == len
              && x.C_STD_CODE == stdCode
              && x.C_MOVE_TYPE.Equals("E")
              && x.C_JUDGE_LEV_ZH.Equals("合格品")
              && x.C_IS_QR.Equals("Y")
              ).OrderBy(x => x.C_BATCH_NO).ThenBy(x => x.C_BATCH_NO).Take(fNum).ToList();
            foreach (var item in list)
            {
                item.C_MOVE_TYPE = "0";
            }
            Update<TSC_SLAB_MAIN>(list);
            return MAPPING.ConvertEntityToDtoList<TSC_SLAB_MAIN, TSC_SLAB_MAINDTO>(list);
        }

        /// <summary>
        /// 获取钢坯库产品
        /// </summary>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="area">地区</param>
        /// <param name="stdCode">执行标准</param>
        /// <returns></returns>
        public List<TSC_SLAB_MAINDTO> GetSlabMain(string stlGrd, string spec, string len, string area, string stdCode)
        {
            var list = _StdMain.Where(x => x.C_STL_GRD.Equals(stlGrd)
              && x.C_SPEC.Equals(spec)
              && x.C_STD_CODE.Equals(stdCode)
              && x.C_MOVE_TYPE.Equals("E")
              && x.C_JUDGE_LEV_ZH.Equals("合格品")
              && x.C_IS_QR.Equals("Y")
              ).OrderBy(x => x.C_BATCH_NO).ThenBy(x => x.C_BATCH_NO).ToList();
            return MAPPING.ConvertEntityToDtoList<TSC_SLAB_MAIN, TSC_SLAB_MAINDTO>(list);
        }

        /// <summary>
        /// 取消线材占位
        /// </summary>
        public void CancelPlace(string stoveID)
        {
            var product = _RollProduct.FirstOrDefault(x => x.C_ID.Equals(stoveID));
            if (product != null && !string.IsNullOrWhiteSpace(product.C_ID))
            {
                product.C_MOVE_TYPE = "E";
                product.C_FYDH = null;
                Update(product);
            }
        }

        /// <summary>
        /// 线材占位
        /// </summary>
        /// <param name="stoveid"></param>
        /// <returns></returns>
        public string TrcPlace(string stoveid)
        {
            string result = "";
            using (var tran = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    string sql = @"   update   trc_roll_prodcut t    set ";
                    sql += "  t.c_Move_Type='0' ";
                    sql += "  where   t.c_id= '" + stoveid + "'";
                    sql += "  and  t.c_Move_Type!='0'   ";
                    int exec = this.Excute<TRC_ROLL_PRODCUT>(sql);
                    if (exec == 1)
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
            }
            return result;
        }

        /// <summary>
        /// 取消钢坯占位
        /// </summary>
        public void CancelPlaceSecond(string stoveID)
        {
            var product = _StdMain.FirstOrDefault(x => x.C_ID.Equals(stoveID));
            if (product != null && !string.IsNullOrWhiteSpace(product.C_ID))
            {
                product.C_MOVE_TYPE = "E";
                product.C_FYDH = null;
                Update(product);
            }
        }

        /// <summary>
        /// 钢坯占位
        /// </summary>
        /// <param name="stoveid"></param>
        /// <returns></returns>
        public string TscPlace(string stoveid)
        {
            string result = "";
            using (var tran = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    string sql = @"   update    tsc_slab_main t    set ";
                    sql += "  t.c_Move_Type='0' ";
                    sql += "  where   t.c_id= '" + stoveid + "'";
                    sql += "  and  t.c_Move_Type!='0'   ";
                    int exec = this.Excute<TSC_SLAB_MAIN>(sql);
                    if (exec == 1)
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
            }
            return result;
        }

        /// <summary>
        /// 添加系统日志
        /// </summary>
        /// <param name="ef"></param>
        public void SystemLog(TMB_LOG ef)
        {
            if (ef != null)
                this.Insert(ef);
        }

    }
}
