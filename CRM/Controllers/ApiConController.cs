using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json.Linq;
using NF.Framework;
using NF.BLL;
using NF.MODEL;
using CRM.ApiDtos;
using NF.Bussiness.Interface;
using NF.Web.Core;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Newtonsoft.Json;
using NF.DAL;

namespace CRM.Controllers
{
    /// <summary>
    /// 合同
    /// </summary>
    public class ApiConController : ApiBaseController
    {

        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TQB_PACK tqb_pack = new Bll_TQB_PACK();
        private Bll_TMB_AREAMAX tmb_areamax = new Bll_TMB_AREAMAX();
        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_TMO_CONDETAILS tmo_condetails = new Bll_TMO_CONDETAILS();
        private static Bll_TB_STD_CONFIG tb_std_config = new Bll_TB_STD_CONFIG();
        private Bll_TS_USER ts_user = new Bll_TS_USER();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();
        private Bll_TMB_AREA tmb_area = new Bll_TMB_AREA();

        private Bll_RandomNumber randomnumber = new Bll_RandomNumber();
        private Bll_TMB_TAXITEMS tmb_taxitems = new Bll_TMB_TAXITEMS();
        private Bll_TS_CUSTADDR ts_custaddr = new Bll_TS_CUSTADDR();
        private Bll_TQB_CHECKSTATE tqb_checkstate = new Bll_TQB_CHECKSTATE();




        IBasicsDataService service = DIFactory.GetContainer().Resolve<IBasicsDataService>();

        #region //合同基础信息_ConBaseInfo

        /// <summary>
        /// 合同基础信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult ConBaseInfo([FromBody]dynamic Json)
        {

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            ContractDto conDto = new ContractDto();

            //货币
            conDto.CurrencyList = ts_dic.DataTableToList(ts_dic.GetDis("Currency").Tables[0]);


            //合同类型

            conDto.ConTypeList = ts_dic.DataTableToList(ts_dic.GetDis("ContractType").Tables[0]);


            //发运方式

            conDto.ShipViaList = ts_dic.DataTableToList(ts_dic.GetDis("ShipVia").Tables[0]);


            //合同区域
            conDto.ConAreaList = tmb_areamax.DataTableToList(tmb_areamax.GetAreaList("").Tables[0]);
            result.Result = SerializationHelper.JsonSerialize(conDto);

            #endregion

            return result;
        }


        /// <summary>
        /// 站点
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult Station([FromBody]dynamic Json)
        {

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            StationDto dto = new StationDto();

            dto.StationList = tmb_area.DataTableToList(tmb_area.GetStation().Tables[0]);
            result.Result = SerializationHelper.JsonSerialize(dto);

            #endregion

            return result;
        }

        #endregion

        #region //获取收货单位/开票单位_GetCompany
        /// <summary>
        /// 获取收货单位&开票单位
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetCompany([FromBody]dynamic Json)
        {
            string CustName = Json.CustName;//搜索条件：客户

            #region//数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(ts_custfile.GetListByPage(50, 1, "", CustName).Tables[0]);
            #endregion

            return result;
        }

        #endregion

        #region//查询合同列表_ConList
        /// <summary>
        /// 查询合同列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult ConList([FromBody]dynamic Json)
        {

            #region //参数
            int PageSize = Json.PageSize;//显示页数
            int StartIndex = Json.StartIndex;//起始页数
            string ConNo = Json.ConNo;//合同号
            string ConName = Json.ConName;//合同名称
            string StartDT = Json.StartDT;//签署开始时间
            string EndDT = Json.EndDT;//签署结束时间
            string ConType = Json.ConType;//合同类型ID

            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            Mod_TS_USER modUser = GetUserID();
            DataTable dt = DataSetHelper.SplitDataSet(tmo_con.GetConList(ConNo, ConName, StartDT, EndDT, modUser.C_ID, ConType, ""), PageSize, StartIndex).Tables[0];
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(dt);
            #endregion

            return result;
        }
        #endregion

        #region//查询合同列表_ConList_Sub
        /// <summary>
        /// 查询合同列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult ConList_Sub([FromBody]dynamic Json)
        {

            #region //参数

            string ConNo = Json.ConNo;//合同号

            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            DataTable dt = tmo_con.GetConListSub(ConNo).Tables[0];
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(dt);
            #endregion

            return result;
        }
        #endregion

        #region//合同附件_ConFiles
        /// <summary>
        /// 查询合同列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult ConFiles([FromBody]dynamic Json)
        {

            #region //参数

            string ConNo = Json.ConNo;//合同号

            #endregion

            #region //数据操作
            Bll_TB_FILE tb_file = new Bll_TB_FILE();
            AjaxResult result = new AjaxResult();
            DataTable dt = tb_file.GetList(ConNo).Tables[0];
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(dt);
            #endregion

            return result;
        }
        #endregion

        #region//合同基本信息_ConInfo
        /// <summary>
        /// 合同基本信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult ConInfo([FromBody]dynamic Json)
        {
            string ConNo = Json.ConNo;//参数：合同号

            #region//数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            ConInfoDto conInfo = new ConInfoDto();
            conInfo.ConModel = tmo_con.GetModel(ConNo);
            //result.Result = SerializationHelper.JsonSerialize(conInfo);
            result.Result = JsonConvert.SerializeObject(conInfo);
            #endregion

            return result;
        }
        #endregion

        #region //合同明细_ConOrder_2018-10-28
        /// <summary>
        /// 合同明细
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult ConOrder([FromBody]dynamic Json)
        {

            #region //参数
            string ConNo = Json.ConNo;//合同
            string MatCode = Json.MatCode;//物料编码
            string MatName = Json.MatName;//物料名称
            string Spec = Json.Spec;//规格
            string Stl_Grd = Json.Stl_Grd;//钢种
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            OrderDto dto = new OrderDto();

            if (!string.IsNullOrEmpty(ConNo))
            {
                DataSet ds = tmo_condetails.GetList(ConNo, MatCode, MatName, Spec, Stl_Grd);
                dto.count = tmo_condetails.GetList(ConNo, "", "", "", "").Tables[0].Rows.Count.ToString();


                dto.OrderList = tmo_condetails.DataTableToList2(ds.Tables[0]);
                result.Result = SerializationHelper.JsonSerialize(dto);
            }
            else
            {
                result.Result = "暂时没有相关记录";
            }
            #endregion

            return result;
        }
        #endregion

        #region //合同编辑_ConEdit_2018-12-04

        /// <summary>
        /// 合同编辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult ConEdit([FromBody]dynamic Json)
        {

            #region //参数
            string ConNo = Json.ConNo;//合同号
            string ConName = Json.ConName;//合同名称
            string ConType = Json.ConType;//合同类型ID  
            string Currency = Json.Currency;//货币类型ID
            string ConsingDT = Json.ConsingDT;//签署日期
            string ConeffeDT = Json.ConeffeDT;//计划有效日期
            string ConinvalidDT = Json.ConinvalidDT;//计划失效日期
            string ShipVia = Json.ShipVia;//发运方式ID
            string Remark = Json.Remark;//备注
            string CGCID = Json.CGCID;//收货单位ID
            string STATION = Json.STATION;//站点   
            string SalesEmpID = Json.SalesEmpID;//业务员ID
            string Addr = Json.Addr;//收货地址
            string OTCID = Json.OTCID;//开票单位
            #endregion

            #region //数据操作

            AjaxResult result = new AjaxResult();


            if (!string.IsNullOrEmpty(ConNo))
            {
                List<Mod_TMO_ORDER> orderList = new List<Mod_TMO_ORDER>();

                DataTable dt = ts_user.GetSaleDept(SalesEmpID).Tables[0];
                Mod_TMO_CON mod = tmo_con.GetModel(ConNo);

                mod.C_CON_NAME = ConName;//合同名称
                mod.C_CONTYPEID = ConType;//合同类型
                mod.C_CURRENCYTYPEID = Currency;//货币类型ID
                mod.D_CONSING_DT = Convert.ToDateTime(ConsingDT);//签署日期
                mod.D_CONEFFE_DT = Convert.ToDateTime(ConeffeDT);//计划有效日期
                mod.D_CONINVALID_DT = Convert.ToDateTime(ConinvalidDT);//计划失效日期
                mod.C_TRANSMODEID = ShipVia;//发运方式ID
                mod.C_AREA = dt.Rows[0]["AREA"].ToString();//合同区域
                mod.C_CRECEIPTCUSTOMERID = CGCID;//收货单位
                mod.C_CRECEIPTCORPID = OTCID;//开票单位
                mod.C_STATION = STATION;//站点
                mod.C_EMPLOYEEID = SalesEmpID;//业务员
                mod.C_DEPTID = dt.Rows[0]["C_DEPTID"].ToString();//业务部门
                mod.C_REAMRK = Remark;//备注
                mod.N_CHANGENUM = 0;//合同变更次数

                if (!string.IsNullOrEmpty(CGCID))
                {
                    Mod_TS_CUSTFILE modCust = ts_custfile.GetCustModel(CGCID);
                    mod.C_CRECEIPTCUSTOMERID = CGCID;//收货单位
                    mod.C_ADDRESS = Addr;//收货地址
                    mod.C_CRECEIPTAREAID = modCust.C_AREATYPE;//收货地区
                }
                if (tmo_con.UpdateConOrder(mod, orderList))
                {
                    result.Code = DoResult.Success;
                    result.Result = "编辑成功";
                }
                else
                {
                    result.Code = DoResult.Failed;
                    result.Result = "编辑失败";
                }
            }
            else
            {
                result.Code = DoResult.Failed;
                result.Result = "编辑失败";
            }
            #endregion

            return result;
        }
        #endregion

        #region //新增合同 ConAdd_2018-12-04

        /// <summary>
        /// 新增合同
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult ConAdd([FromBody]dynamic Json)
        {
            #region 参数
            string ZCCode = Json.ZCCode == null ? "01" : Json.ZCCode;//政策编码
            string ConName = Json.ConName;//合同名称
            string ConType = Json.ConType;//合同类型ID
            string Currency = Json.Currency;//货币类型ID
            string ConsingDT = Json.ConsingDT;//签署日期
            string ConeffeDT = Json.ConeffeDT;//计划有效日期
            string ConinvalidDT = Json.ConinvalidDT;//计划失效日期
            string ShipVia = Json.ShipVia;//发运方式ID
            string Remark = Json.Remark;//备注
            string CGID = Json.CGID;//收货单位
            string STATION = Json.STATION;//站点
            string SalesEmpID = Json.SalesEmpID;//业务员ID
            string Addr = Json.Addr;//收货地址
            string OTCID = Json.OTCID;//开票单位
            string CustID = Json.CustID;//客户
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            List<Mod_TMO_ORDER> orderList = new List<Mod_TMO_ORDER>();
            DataTable dt = ts_user.GetSaleDept(SalesEmpID).Tables[0];

            Mod_TS_USER modUser = GetUserID();
            Mod_TMO_CON mod = new Mod_TMO_CON();
            string conNo = randomnumber.CreateConNo(ZCCode);//合同号
            mod.C_CON_XH = conNo;//合同序号
            mod.C_CON_NO = conNo;//合同号
            mod.C_CON_NAME = ConName;//合同名称
            mod.C_CONTYPEID = ConType;//合同类型ID
            mod.C_CURRENCYTYPEID = Currency;//货币类型ID 
            mod.D_CONSING_DT = Convert.ToDateTime(ConsingDT);//签署日期
            mod.D_CONEFFE_DT = Convert.ToDateTime(ConeffeDT);//计划有效日期
            mod.D_CONINVALID_DT = Convert.ToDateTime(ConinvalidDT);//计划失效日期
            //mod.D_NEED_DT = Convert.ToDateTime(ConinvalidDT).AddDays(-30);//需求日期
            mod.C_TRANSMODEID = ShipVia;//发运方式ID 
            mod.C_AREA = dt.Rows[0]["AREA"].ToString();//合同区域
            mod.C_REAMRK = Remark;//备注
            mod.C_CRECEIPTCUSTOMERID = CGID;//收货单位ID
            mod.C_CRECEIPTCORPID = OTCID;//开票单位ID
            mod.C_STATION = STATION;//站点
            mod.C_EMPLOYEEID = SalesEmpID;//业务员ID
            mod.C_DEPTID = dt.Rows[0]["C_DEPTID"].ToString();//业务部门

            if (!string.IsNullOrEmpty(CGID))
            {
                Mod_TS_CUSTFILE modCust = ts_custfile.GetCustModel(CGID);
                mod.C_ADDRESS = Addr;//收货地址
                mod.C_CRECEIPTAREAID = modCust.C_AREATYPE;//收货地区
            }

            Mod_TS_CUSTFILE modCustfile = CustID == "" ? ts_custfile.GetModel(modUser.C_CUST_ID) : ts_custfile.GetCustModel(CustID);
            mod.C_CUSTOMERID = modCustfile.C_NC_M_ID;//NCID
            mod.C_CUSTNAME = modCustfile.C_NAME;
            mod.C_CUST_NO = modCustfile.C_NO;//客户编码
            mod.C_COPERATORID = SalesEmpID;//制单人
            mod.C_EMP_ID = modUser.C_ID;
            mod.C_EMP_NAME = modUser.C_NAME;
            mod.N_CUST_LEV = modCustfile.N_LEVEL;
            mod.N_CHANGENUM = 0;//变更次数默认0

            if (tmo_con.InsertConOrder(mod, orderList))
            {
                result.Code = DoResult.Success;
                result.Result = conNo;
            }
            else
            {
                result.Code = DoResult.Failed;
                result.Result = "提交失败";
            }
            #endregion

            return result;
        }
        #endregion

        #region //删除订单OrderDel_2018-10-28
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult OrderDel([FromBody]dynamic Json)
        {
            string OrderNo = Json.OrderNo;//参数:订单号

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = tmo_con.DelOrderNo(OrderNo) == false ? "删除失败" : "删除成功";
            #endregion

            return result;
        }
        #endregion  

        #region //新增订单_OrderAdd_2018-12-09
        /// <summary>
        /// 新增订单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult OrderAdd([FromBody]dynamic Json)
        {
            #region //参数
            string ConNo = Json.ConNo;//合同号
            string MatID = Json.MatID;//物料ID
            string TechProt = Json.TechProt;//客户协议号
            string StdCode = Json.StdCode;//执行标准
            string Pack = Json.Pack;//包装要求
            string Wgt = Json.Wgt;//重量
            string Price = Json.Price;//含税单价
            string VdefID = Json.VdefID;//质量ID
            #endregion

            #region 数据操作     
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;

            Mod_TS_USER modUser = GetUserID();
            Mod_TMO_CON modCon = tmo_con.GetModel(ConNo);
            Mod_TB_MATRL_MAIN modMat = tb_matrl_main.GetModel(MatID);
            Mod_TS_CUSTFILE modCust = ts_custfile.GetModel(modUser.C_CUST_ID);
            Mod_TMO_ORDER modOrder = new Mod_TMO_ORDER();

            DataTable dt = tb_matrl_main.GetCustStlGrd(modCust.C_NO, modMat.C_MAT_CODE, modMat.C_STL_GRD, modMat.C_SPEC, TechProt, StdCode).Tables[0];

            string order_no = randomnumber.CreateOrderNo(ConNo);//订单号
            modOrder.C_ORDER_NO = order_no;
            modOrder.C_CON_NO = modCon.C_CON_NO;//合同号
            modOrder.C_CON_NAME = modCon.C_CON_NAME;//合同名称
            modOrder.C_AREA = modCon.C_AREA;//区域
            modOrder.C_INVBASDOCID = modMat.C_PK_INVBASDOC;//存货档案主键
            modOrder.C_INVENTORYID = modMat.C_PK_INVMANDOC;//存货管理档案主键
            modOrder.C_PROD_NAME = modMat.C_PROD_NAME;//品名
            modOrder.C_PROD_KIND = modMat.C_PROD_KIND;//品种
            modOrder.C_MAT_CODE = modMat.C_MAT_CODE;//物料编码
            modOrder.C_MAT_NAME = modMat.C_MAT_NAME;//物料名称
            modOrder.C_SPEC = modMat.C_SPEC;//规格
            modOrder.C_STL_GRD = modMat.C_STL_GRD;//钢种
            modOrder.C_FUNITID = modMat.C_FJLDW;//辅单位
            modOrder.C_UNITID = modMat.C_PK_MEASDOC;//主计量单位
            modOrder.D_DELIVERY_DT = modCon.D_CONINVALID_DT;//计划交货日期
            modOrder.D_DT = modCon.D_CONSING_DT;//订单日期//签单日期
            modOrder.C_VDEF1 = VdefID;//质量主键ID
            modOrder.C_SFPJ = "N";
            modOrder.C_TECH_PROT = TechProt;//客户协议号
            modOrder.C_FREE1 = dt?.Rows[0]["C_ZYX1"].ToString() ?? "";//自由项1
            modOrder.C_FREE2 = dt?.Rows[0]["C_ZYX2"].ToString() ?? "";//自由项2
            modOrder.C_STD_CODE = StdCode;//执行标准
            modOrder.C_BY4 = dt?.Rows[0]["C_IS_BXG"].ToString() ?? "";//是否不锈钢
            modOrder.N_TYPE = Convert.ToDecimal(modMat.C_MAT_TYPE);//订单类型


            modOrder.C_PACK = Pack;//包装要求

            Mod_TMB_TAXITEMS modTaxi = tmb_taxitems.GetModel(modMat.C_PK_TAXITEMS);
            modOrder.N_TAXRATE = modTaxi.N_TAXRATIO;//税率

            decimal N_WGT = 0;
            if (!string.IsNullOrEmpty(Wgt))
            {
                N_WGT = Convert.ToDecimal(Wgt);

            }
            modOrder.N_WGT = N_WGT;//数量
            modOrder.N_HSL = modMat.N_HSL == null ? 0 : modMat.N_HSL;//换算率
            modOrder.N_FNUM = modMat.N_HSL == null ? 1 : N_WGT / modMat.N_HSL;//辅数量

            #region //获取钢种单价-税率                           
            if (!string.IsNullOrEmpty(Price))
            {
                decimal N_TAXRATE = Convert.ToDecimal(modOrder.N_TAXRATE) + 1;//税率
                decimal N_ORIGINALCURPRICE = Convert.ToDecimal(Price) / N_TAXRATE;//原币无税单价
                decimal N_ORIGINALCURTAXPRICE = Convert.ToDecimal(Price);//原币含税单价

                decimal N_ORIGINALCURMNY = decimal.Round(N_WGT * N_ORIGINALCURPRICE, 2);//原币无税金额
                decimal N_ORIGINALCURSUMMNY = N_WGT * N_ORIGINALCURTAXPRICE;//原币价税合计
                decimal N_ORIGINALCURTAXMNY = decimal.Round(N_ORIGINALCURSUMMNY - N_ORIGINALCURMNY, 2);//原币税额

                modOrder.N_ORIGINALCURPRICE = N_ORIGINALCURPRICE;//原币无税单价
                modOrder.N_ORIGINALCURTAXPRICE = N_ORIGINALCURTAXPRICE;//原币含税单价
                modOrder.N_ORIGINALCURTAXMNY = N_ORIGINALCURTAXMNY;//原币税额
                modOrder.N_ORIGINALCURMNY = N_ORIGINALCURMNY;//原币无税金额
                modOrder.N_ORIGINALCURSUMMNY = N_ORIGINALCURSUMMNY;//原币价税合计
            }
            #endregion

            modOrder.C_RECEIPTAREAID = modCon.C_CRECEIPTAREAID;//收货地区
            modOrder.C_RECEIVEADDRESS = modCon.C_ADDRESS;//收货地址
            modOrder.C_RECEIPTCORPID = modCon.C_CRECEIPTCUSTOMERID;//收货单位
            modOrder.C_CURRENCYTYPEID = modCon.C_CURRENCYTYPEID; //货币

            modOrder.N_USER_LEV = modCon.N_CUST_LEV;//客户等级
            modOrder.C_CUST_SQ = modCon.C_REAMRK;//客户要求
            modOrder.C_EMP_ID = modCon.C_EMP_ID;
            modOrder.C_EMP_NAME = modCon.C_EMP_NAME;
            modOrder.C_CUST_NO = modCust.C_NO;
            modOrder.C_CUST_NAME = modCust.C_NAME;
            modOrder.C_SALE_CHANNEL = "";
            modOrder.C_LEV = GetLev("STL_GRD_Lev");//钢种等级
            modOrder.C_ORDER_LEV = GetLev("Order_Lev");//订单等级
            modOrder.N_COST = 0;//成本
            modOrder.C_TRANSMODE = modCon.C_TRANSMODEID;//发运方式
            modOrder.C_TRANSMODEID = modCon.C_TRANSMODEID;//发运方式主键
            modOrder.C_YWY = ts_user.GetSaleName(modCon.C_EMPLOYEEID);//业务员姓名
            modOrder.N_STATUS = Convert.ToDecimal(modCon.N_STATUS);


            List<Mod_TMO_ORDER> orderList = new List<Mod_TMO_ORDER>();
            orderList.Add(modOrder);
            result.Result = tmo_con.InsertFirstOrder(orderList) == true ? "提交成功" : "提交失败";
            #endregion

            return result;
        }
        #endregion     

        #region //查看订单 GetOrderView_2018-10-28
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetOrderView([FromBody]dynamic Json)
        {
            string OrderNo = Json.OrderNo;//参数:订单号

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            Mod_TMO_CONDETAILS mod = tmo_condetails.GetModel(OrderNo);
            if (mod != null)
            {
                result.Result = SerializationHelper.JsonSerialize(mod);
            }
            else
            {

                result.Result = "当前没有相关订单信息";
            }
            #endregion

            return result;
        }
        #endregion

        #region//修改订单_OrderEdit_2018-10-28
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult OrderEdit([FromBody]dynamic Json)
        {
            #region //参数
            string OrderNO = Json.OrderNO;//订单号
            string Pack = Json.Pack;//包装要求
            string Wgt = Json.Wgt;//重量
            string Price = Json.Price;//含税单价
            string VdefID = Json.VdefID;//质量ID
            #endregion

            #region 数据操作         
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;

            DataRow drOrder = tmo_order.GetRowOrder(OrderNO, "");
            if (drOrder != null)
            {
                Mod_TS_USER modUser = GetUserID();
                Mod_TS_CUSTFILE modCust = ts_custfile.GetModel(modUser.C_CUST_ID);
                Mod_TMO_ORDER modOrder = tmo_order.GetModel(drOrder["C_ID"].ToString());

                Mod_TMO_CON modCon = tmo_con.GetModel(modOrder.C_CON_NO);

                modOrder.C_VDEF1 = VdefID;//质量;
                modOrder.C_PACK = Pack;//包装要求
                decimal N_WGT = 0;
                if (!string.IsNullOrEmpty(Wgt))
                {
                    N_WGT = Convert.ToDecimal(Wgt);
                }
                modOrder.N_WGT = N_WGT;//数量 
                modOrder.N_FNUM = N_WGT / modOrder.N_HSL;//数量 

                #region //获取钢种单价-税率                           
                if (!string.IsNullOrEmpty(Price))
                {
                    decimal N_TAXRATE = Convert.ToDecimal(modOrder.N_TAXRATE) + 1;//税率
                    decimal N_ORIGINALCURPRICE = decimal.Round(Convert.ToDecimal(Price) / N_TAXRATE, 2);//原币无税单价
                    decimal N_ORIGINALCURTAXPRICE = Convert.ToDecimal(Price);//原币含税单价

                    decimal N_ORIGINALCURMNY = N_WGT * N_ORIGINALCURPRICE;//原币无税金额
                    decimal N_ORIGINALCURSUMMNY = N_WGT * N_ORIGINALCURTAXPRICE;//原币价税合计
                    decimal N_ORIGINALCURTAXMNY = N_ORIGINALCURSUMMNY - N_ORIGINALCURMNY;//原币税额

                    modOrder.N_ORIGINALCURPRICE = N_ORIGINALCURPRICE;//原币无税单价
                    modOrder.N_ORIGINALCURTAXPRICE = N_ORIGINALCURTAXPRICE;//原币含税单价                  
                    modOrder.N_ORIGINALCURTAXMNY = N_ORIGINALCURTAXMNY;//原币税额
                    modOrder.N_ORIGINALCURMNY = N_ORIGINALCURMNY;//原币无税金额
                    modOrder.N_ORIGINALCURSUMMNY = N_ORIGINALCURSUMMNY;//原币价税合计
                }
                #endregion

                List<Mod_TMO_ORDER> orderList = new List<Mod_TMO_ORDER>();
                orderList.Add(modOrder);

                result.Result = tmo_con.UpdateConOrder(modCon, orderList) == true ? "修改成功" : "修改失败";
            }
            else
            {
                result.Result = "当前暂无修改订单";
            }


            #endregion

            return result;
        }
        #endregion

        #region //物料钢种＿Material
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult Material([FromBody]dynamic Json)
        {
            Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();

            AjaxResult result = new AjaxResult();

            #region //参数
            string MatCode = Json.MatCode;//物料编码
            string MatName = Json.MatName;//物料名称
            string StlGrd = Json.StlGrd;//钢种
            string Spec = Json.Spec;//规格
            string MatClass = Json.MatClass;//分类
            #endregion

            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(tb_matrl_main.GetList(MatName, MatCode, StlGrd, Spec, MatClass, "").Tables[0]);
            return result;
        }

        /// <summary>
        /// 钢种分类//修改时间2018-12-08
        /// </summary>
        /// <param name="Json"></param>S
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult MatClass([FromBody]dynamic Json)
        {

            string groupCode = Json.groupCode;//物料组编码

            Bll_TB_MATRL_GROUP tb_matrl_group = new Bll_TB_MATRL_GROUP();

            AjaxResult result = new AjaxResult();

            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(tb_matrl_group.GetMatrlGroup(groupCode).Tables[0]);

            return result;
        }

        #endregion

        #region //客户下订单产品查询＿Material2
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult Material2([FromBody]dynamic Json)
        {
            Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();

            Mod_TS_USER modUser = GetUserID();
            Mod_TS_CUSTFILE modCustfile = ts_custfile.GetModel(modUser.C_CUST_ID);

            AjaxResult result = new AjaxResult();

            #region //参数
            string MatCode = Json.MatCode;//物料编码
            string MatName = Json.MatName;//物料名称
            string Stl_Grd = Json.Stl_Grd;//钢种
            string Spec = Json.Spec;//规格
            string prodKind = Json.prodKind;//大类
            string prodName = Json.prodName;//小类
            #endregion

            DataTable dt = new DataTable();
            if (prodKind.Contains("商品坯"))
            {
                dt = tb_matrl_main.GetCustStlGrd_GP(prodKind, prodName, modCustfile.C_NO, MatCode, Stl_Grd, Spec).Tables[0];
            }
            else
            {
                dt = tb_matrl_main.GetCust_StlGrd(prodKind, prodName, modCustfile.C_NO, MatCode, Stl_Grd, Spec).Tables[0];
            }
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(dt);
            return result;
        }

        #region  菜单


        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetMenu([FromBody]dynamic Json)
        {
            #region //数据操作
            Mod_TS_USER modUser = GetUserID();
            Mod_TS_CUSTFILE modCustfile = ts_custfile.GetModel(modUser.C_CUST_ID);
            DataTable dt = tb_matrl_main.Get_PROD_KIND(modCustfile.C_NO).Tables[0];
            AjaxResult result = new AjaxResult();

            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(dt);
            #endregion

            return result;

        }
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetMenu2([FromBody]dynamic Json)
        {
            #region //参数
            string key = Json.key;

            #endregion

            #region // 数据操作
            AjaxResult result = new AjaxResult();

            Mod_TS_USER modUser = GetUserID();
            Mod_TS_CUSTFILE modCustfile = ts_custfile.GetModel(modUser.C_CUST_ID);

            DataTable dt = tb_matrl_main.Get_PROD_NAME(modCustfile.C_NO, key).Tables[0];
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(dt);
            #endregion


            return result;
        }
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetMenu3([FromBody]dynamic Json)
        {

            #region //参数
            string key = Json.key;
            string key2 = Json.key2;

            #endregion

            #region 数据操作
            AjaxResult result = new AjaxResult();
            Mod_TS_USER modUser = GetUserID();
            Mod_TS_CUSTFILE modCustfile = ts_custfile.GetModel(modUser.C_CUST_ID);
            DataTable dt = tb_matrl_main.Get_PROD_NAME_StlGrd(modCustfile.C_NO, key, key2).Tables[0];
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(dt);
            #endregion

            return result;
        }

        #endregion



        #endregion

        #region //客户协议号＿Tech_Prot_2018-12-04
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult Tech_Prot([FromBody]dynamic Json)
        {

            string MatID = Json.MatID;//物料ID 

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            string[] matList = { "851", "841", "831" };

            Mod_TS_USER mod = GetUserID();
            Mod_TS_CUSTFILE modCust = ts_custfile.GetModel(mod.C_CUST_ID);
            Mod_TB_MATRL_MAIN modMat = tb_matrl_main.GetModel(MatID);

            decimal n_type = Convert.ToDecimal(modMat.C_MAT_TYPE);

            if (!matList.Contains(modMat.C_MAT_GROUP_CODE))
            {
                DataTable dt = tb_std_config.GetCUST_TECH_PROT(modMat.C_STL_GRD, modCust.C_NO).Tables[0];
                if (dt.Rows.Count > 0)
                {

                    result.Result = JsonConvert.SerializeObject(dt);
                }
            }
            #endregion

            return result;
        }
        #endregion

        #region //质量＿GetZL_2018-12-09
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetZL([FromBody]dynamic Json)
        {
            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            DataTable dtzl = tqb_checkstate.GetCheckState("").Tables[0];
            if (dtzl.Rows.Count > 0)
            {
                result.Result = JsonConvert.SerializeObject(dtzl);
            }
            #endregion

            return result;
        }
        #endregion

        #region //包装要求_Pack
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult Pack([FromBody]dynamic Json)
        {
            #region //参数
            string PackCode = Json.PackCode;//包装代码
            string PackName = Json.PackName;//包装名称
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            DataTable dt = tqb_pack.GetPackList(PackCode, PackName).Tables[0];
            result.Result = SerializationHelper.Dtb2Json(dt);
            #endregion

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult PackView([FromBody]dynamic Json)
        {
            #region //参数
            string PackCode = Json.PackCode;//包装代码
            string PackName = Json.PackName;//包装名称
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            DataTable dt = tqb_pack.GetPackList(PackCode, PackName).Tables[0];
            result.Result = SerializationHelper.Dtb2Json(dt);
            #endregion

            return result;
        }

        #endregion

        #region//提交合同_SubmitCon
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult SubmitCon([FromBody]dynamic Json)
        {
            string ConNo = Json.ConNo;//参数:合同号

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;

            //客户提交/待审0
            if (tmo_con.UpdateConStatus(0, ConNo))
            {
                result.Result = "提交成功";
            }
            else
            {
                result.Result = "提交失败";
            }
            #endregion

            return result;
        }
        #endregion

        #region //获取等级_GetLev
        /// <summary>
        /// 获取等级
        /// </summary>
        /// <param name="code">编码</param>
        /// <returns></returns>
        private string GetLev(string code)
        {
            string result = "";
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = code;
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {
                result = dt.Rows[0]["C_DETAILNAME"].ToString();
            }
            return result;
        }
        #endregion

        #region 业务员_SalesEmp_2018-09-28
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult SalesEmp([FromBody]dynamic Json)
        {
            #region //参数
            string Name = Json.Name;//姓名
            string Code = Json.Code;//编码
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(ts_user.GetSales(Name, Code).Tables[0]);
            #endregion

            return result;
        }
        #endregion

        #region  客户收货地址_GetAddr_2018-10-14
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetAddr([FromBody]dynamic Json)
        {

            string CGID = Json.CGID;//参数：收货单位

            #region //数据操作
            Mod_TS_USER modUser = GetUserID();
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(ts_custaddr.GetAddr("", "", CGID, "", "").Tables[0]);
            #endregion

            return result;
        }

        #endregion

        #region  客户历史签单_2018-10-25

        /// <summary>
        /// 获取客户历史订单
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetOldOrder([FromBody]dynamic Json)
        {

            #region //参数
            string ConNo = Json.ConNo;//合同号
            string StlGrd = Json.StlGrd;//钢种
            string StartTime = Json.StartTime;//签署开始时间
            string EndTime = Json.EndTime;//签署结束时间
            #endregion

            #region //数据操作
            Mod_TS_USER modUser = GetUserID();

            Mod_TS_CUSTFILE mod = ts_custfile.GetModel(modUser.C_CUST_ID);

            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(tmo_condetails.GetConOrderList(ConNo, "", StlGrd, StartTime, EndTime, mod.C_NO).Tables[0]);
            #endregion

            return result;
        }

        /// <summary>
        /// 添加历史订单
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetOldOrderAdd([FromBody]dynamic Json)
        {

            #region //参数
            string ConNo = Json.ConNo;//合同号
            JArray OrderList = (JArray)Json.OrderList;//.OrderNo
            #endregion

            #region 数据操作               
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;

            List<Mod_TMO_ORDER> ListOrder = new List<Mod_TMO_ORDER>();

            Mod_TMO_CON modCon = tmo_con.GetModel(ConNo);
            for (int i = 0; i < OrderList.Count; i++)
            {
                #region //添加订单

                Mod_TMO_ORDER modOrder = tmo_order.GetOrderModel(OrderList[i]["OrderNo"].ToString());
                string order_no = randomnumber.CreateOrderNo(ConNo);//订单号
                modOrder.C_ORDER_NO = order_no;
                modOrder.C_CON_NO = ConNo;//合同号
                modOrder.C_CON_NAME = modCon.C_CON_NAME;//合同名称
                modOrder.C_AREA = modCon.C_AREA;//区域
                //modOrder.D_NEED_DT = modCon.D_CONINVALID_DT;//需求日期
                modOrder.D_DELIVERY_DT = modCon.D_CONINVALID_DT;//计划收货日期
                modOrder.D_DT = DateTime.Now;//订单日期
                modOrder.C_RECEIPTAREAID = modCon.C_CRECEIPTAREAID;//收货地区
                modOrder.C_RECEIVEADDRESS = modCon.C_ADDRESS;//收货地址
                modOrder.C_RECEIPTCORPID = modCon.C_CRECEIPTCUSTOMERID;//收货单位
                modOrder.C_CURRENCYTYPEID = modCon.C_CURRENCYTYPEID; //货币
                modOrder.N_USER_LEV = modCon.N_CUST_LEV;//客户等级
                modOrder.C_REMARK = modCon.C_REAMRK;

                ListOrder.Add(modOrder);
                #endregion
            }
            result.Result = tmo_con.InsertConOrder(modCon, ListOrder) == true ? "提交成功" : "提交失败";
            #endregion

            return result;
        }


        #endregion

        #region //PC端
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult SalesEmpPC([FromBody]dynamic Json)
        {
            #region //参数
            string Name = Json.Name;//姓名
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();

            DataTable dt = ts_user.GetSales(Name, "").Tables[0];
            if (dt.Rows.Count > 0)
            {
                result.Code = DoResult.Success;
                result.Result = JsonConvert.SerializeObject(dt);
            }
            else
            {
                result.Code = DoResult.Failed;
            }

            #endregion

            return result;
        }
        #endregion

        #region //获取客户合同变更次数
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetConNum([FromBody]dynamic Json)
        {
            #region //参数
            string conNO = Json.conNO;//合同号
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();

            DataTable dt = tmo_con.GetConListSub(conNO).Tables[0];
            if (dt.Rows.Count > 1)
            {
                result.Code = DoResult.Success;
            }
            else
            {
                result.Code = DoResult.Failed;
            }

            #endregion

            return result;
        }
        #endregion


        #region //客户合同变更
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult ConChange([FromBody]dynamic Json)
        {
            #region //参数
            string conNO = Json.conNO;//合同号
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();

            try
            {
                if (!string.IsNullOrEmpty(conNO))
                {

                    #region //新增变更合同
                    List<Mod_TMO_ORDER> orderList = new List<Mod_TMO_ORDER>();

                    #region //添加合同基本信息



                    Mod_TMO_CON modCon = tmo_con.GetModel(conNO);
                    int NO = Convert.ToInt32(modCon.N_CHANGENUM.ToString()) + 1;
                    modCon.C_CON_NO = modCon.C_CON_NO + "-" + NO.ToString();
                    modCon.C_CON_NAME = modCon.C_CON_NAME;
                    modCon.N_STATUS = -1;//客户待提交
                    modCon.D_CONSING_DT = DateTime.Now;//合同签署日期
                    modCon.D_CONEFFE_DT = Convert.ToDateTime(DateTime.Now);//计划生效日期
                    modCon.D_CONINVALID_DT = Convert.ToDateTime(DateTime.Now).AddDays(60);//计划失效日期
                    modCon.C_CON_NO_OLD = conNO;//原始合同号
                    modCon.N_CHANGENUM = NO;//变更次数
                    #endregion

                    #region//添加合同明细
                    Bll_RandomNumber randomnumber = new Bll_RandomNumber();//流水号
                    DataTable dtOrder = tmo_order.GetConOrderList(conNO, "", "", "", "", "").Tables[0];

                    for (int i = 0; i < dtOrder.Rows.Count; i++)
                    {

                        Mod_TMO_ORDER modOrder = tmo_order.GetModel(dtOrder.Rows[i]["C_ID"].ToString());//订单表
                        string order_no = randomnumber.CreateOrderNo(modCon.C_CON_NO);//订单号
                        modOrder.C_ORDER_NO = order_no;
                        modOrder.C_CON_NO = modCon.C_CON_NO;//合同号
                        modOrder.C_CON_NAME = modCon.C_CON_NAME;//合同名称
                        modOrder.N_STATUS = -1;//客户待提交
                        modOrder.C_SFPJ = "N"; //是否评价
                        modOrder.N_EXEC_STATUS = -2;//未提报
                        modOrder.N_WGT = modOrder.N_WGT;//原合同数量
                        modOrder.C_ORDER_NO_OLD = dtOrder.Rows[i]["C_ORDER_NO"].ToString();//原合同号
                        orderList.Add(modOrder);

                    }
                    #endregion

                    #endregion

                    if (tmo_con.InsertConOrder(modCon, orderList))
                    {
                        result.Code = DoResult.Success;
                        result.Result = "变更成功";
                    }
                }
                else
                {
                    result.Code = DoResult.Success;
                    result.Result = "合同为空，无法操作";
                }
            }
            catch (Exception ex)
            {
                result.Code = DoResult.Success;
                result.Result = ex.Message;
            }
            #endregion

            return result;
        }
        #endregion

        #region//数字字典
        /// <summary>
        /// 查询合同列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetDic([FromBody]dynamic Json)
        {

            #region //参数

            string key = Json.key;//合同号

            #endregion

            #region //数据操作
            Bll_TB_FILE tb_file = new Bll_TB_FILE();
            AjaxResult result = new AjaxResult();
            DataTable dt = ts_dic.GetDis(key).Tables[0];
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(dt);
            #endregion

            return result;
        }
        #endregion
    }
}