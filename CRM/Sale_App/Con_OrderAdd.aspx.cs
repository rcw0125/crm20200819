using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.BLL;
using System.Web.Services;
using NF.Framework;
using NF.MODEL;

namespace CRM.Sale_App
{
    public partial class Con_OrderAdd : System.Web.UI.Page
    {
        private static Bll_TB_STD_CONFIG std_config = new Bll_TB_STD_CONFIG();
        private static Bll_TS_CUSTADDR custaddr = new Bll_TS_CUSTADDR();
        private Bll_TS_CUSTOTCOMPANY custcompany = new Bll_TS_CUSTOTCOMPANY();
        private Bll_TMB_MEAS meas = new Bll_TMB_MEAS();
        private Bll_TS_CUSTFILE custfile = new Bll_TS_CUSTFILE();

        private static Bll_TMB_ACTIVITY activity = new Bll_TMB_ACTIVITY();
        private static Bll_TMO_CONDETAILS condetails = new Bll_TMO_CONDETAILS();
        private static Bll_TPB_STEEL_PRO_CONDITION steel_pro_condition = new Bll_TPB_STEEL_PRO_CONDITION();
        private static Bll_TQB_STD_MAIN std_main = new Bll_TQB_STD_MAIN();
        private static Bll_TQB_DESIGN design = new Bll_TQB_DESIGN();
        private static Bll_TQB_DESIGN_ORDER design_order = new Bll_TQB_DESIGN_ORDER();

        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                //添加
                if (!string.IsNullOrEmpty(Request.QueryString["add"]))
                {
                    hidconNo.Value = Request.QueryString["add"];
                    BindUserInfo();
                }
                //修改
                if(!string .IsNullOrEmpty(Request .QueryString ["edit"]))
                {
                    hidOrderNo.Value = Request.QueryString["edit"];

                    Mod_TMO_CONDETAILS mod = condetails.GetModel(hidOrderNo.Value);

                    hidconNo.Value = mod.C_CON_NO;
                    BindUserInfo();
                }


            }
        }

        /// <summary>
        /// 加载客户默认地址与开票单位
        /// </summary>
        private void BindUserInfo()
        {

            Mod_TMO_CON modCON = tmo_con.GetModel(hidconNo.Value);
            if (modCON != null)
            {

                hidConName.Value = modCON.C_CON_NAME;
                hidCurrType.Value = modCON.C_CURRENCY_TYPE;
                hidConArea.Value = modCON.C_CON_AREA;
                hidShipVia.Value = modCON.C_SHIPVIA;

                //客户档案
                Mod_TS_CUSTFILE mod = custfile.GetCustModel(modCON.C_CUST_NO);
                if (mod != null)
                {
                    hidCustNO.Value = mod.C_NO;
                    hidCustName.Value = mod.C_NAME;
                    hidCustLEV.Value = mod.N_LEVEL.ToString();
                    hidCustType.Value = mod.N_TYPE.ToString() == "1" ? "经销" : "直销";

                }

                //默认收货单位
                DataTable dt = custaddr.GetAddrList(mod.C_ID, "1").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txtAddress.Value = dt.Rows[0]["C_CGC"].ToString();
                    hidAddrID.Value = dt.Rows[0]["C_ID"].ToString();
                }
                //默认开票单位
                DataTable dtc = custcompany.GetList(mod.C_ID).Tables[0];
                if (dtc.Rows.Count > 0)
                {
                    txtOTCompany.Value = dtc.Rows[0]["C_OTCOMPANY"].ToString();
                }
            }
        }

        /// <summary>
        /// 获取钢种用途
        /// </summary>
        /// <param name="C_STD_ID">执行标准ID</param>
        /// <returns></returns>
        [WebMethod]
        public static string GetUSES(string C_STD_ID)
        {
            string result = string.Empty;

            Mod_TQB_STD_MAIN mod = std_main.GetModel(C_STD_ID);
            if (mod != null)
            {
                result = mod.C_USES;
            }
            return result;
        }

        /// <summary>
        /// 获取协议号
        /// </summary>
        /// <param name="stl_grd">钢种</param>
        /// <returns></returns>
        [WebMethod]
        public static string GetCUST_TECH_PROT(string stl_grd)
        {
            DataTable dt = std_config.GetCUST_TECH_PROT(stl_grd).Tables[0];
            return SerializationHelper.Dtb2Json(dt);
        }

        /// <summary>
        /// 获取计划交货时间
        /// </summary>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="stdcode">执行标准</param>
        /// <param name="num">重量</param>
        /// <returns></returns>
        [WebMethod]
        public static string GetTime(string stlgrd, string spec, string stdcode, string num)
        {
            return Date.GetDeliveryDate(stlgrd, spec, stdcode, num).ToString("yyy-MM-dd");
        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="c_no">订单号</param>
        /// <returns></returns>
        [WebMethod]
        public static string GetOrderInfo(string c_no)
        {
            DataTable dt = condetails.GetConOrderList("", c_no).Tables[0];
            return SerializationHelper.Dtb2Json(dt);
        }


        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="c_con_no">合同号</param>
        /// <param name="c_con_name">C_CON_NAME</param>
        /// <param name="c_area">区域</param>
        /// <param name="c_mat_code">物料编码</param>
        /// <param name="c_mat_name">物料名称</param>
        /// <param name="c_tech_prot">客户协议号</param>
        /// <param name="c_spec">规格</param>
        /// <param name="c_stl_grd">钢种</param>
        /// <param name="c_unitis">单位</param>
        /// <param name="c_pro_use">产品用途</param>
        /// <param name="d_delivery_dt">计划交货日期</param>
        /// <param name="n_wgt">重量</param>
        /// <param name="addrid">收货地址</param>
        /// <param name="c_otc">开票单位</param>
        /// <param name="n_currency_type">币种</param>
        /// <param name="c_std_code">执行标准</param>
        /// <param name="n_type">订单类型</param>
        /// <param name="n_dia">直径</param>
        /// <param name="c_pack">包装要求</param>
        /// <param name="custNo">客户编码</param>
        /// <param name="custName">客户名称</param>
        /// <param name="custLEV">客户等级</param>
        /// <param name="custType">分销类别（直销/经销）</param>
        /// <param name="sysDate">系统推荐交货日期</param>
        /// <param name="shipvia">发运方式</param>
        /// <param name="lev">维护等级</param>
        /// <param name="need_date">需求日期</param>
        /// <param name="orderNo">订单号</param>
        /// <returns></returns>
        [WebMethod]
        public static bool AddOrder(string c_con_no, string c_con_name, string c_area, string c_mat_code, string c_mat_name, string c_tech_prot, string c_spec, string c_stl_grd, string c_unitis, string c_pro_use, string d_delivery_dt, string n_wgt, string addrid, string c_otc, string n_currency_type, string c_std_code, string n_type, string n_dia, string c_pack, string custNo, string custName, string custLEV, string custType, string sysDate, string shipvia,string lev,string need_date,string orderNo)
        {

            if (!string.IsNullOrEmpty(orderNo))//更新数据
            {
                Mod_TMO_CONDETAILS mod = condetails.GetModel(orderNo);
                mod.C_MAT_CODE = c_mat_code;
                mod.C_MAT_NAME = c_mat_name;
                mod.C_TECH_PROT = c_tech_prot;
                mod.C_SPEC = c_spec;
                mod.C_STL_GRD = c_stl_grd;
                //mod.C_STD_CODE = c_std_code;
                mod.C_UNITIS = c_unitis;
                mod.C_PRO_USE = c_pro_use;
                mod.D_DELIVERY_DT = Convert.ToDateTime(d_delivery_dt);//交货日期
                mod.N_WGT = Convert.ToDecimal(n_wgt);
                mod.N_DIA = Convert.ToDecimal(n_dia);
                mod.N_TYPE = Convert.ToDecimal(n_type);
                mod.C_PACK = c_pack;
                mod.C_CURRENCY_TYPE = n_currency_type;
                mod.C_OTC = c_otc;
                mod.C_CUST_NO = custNo;
                mod.C_CUST_NAME = custName;
                mod.N_USER_LEV = Convert.ToDecimal(custLEV);//客户等级
                mod.C_SALE_CHANNEL = custType;
                mod.D_SYS_DELIVERY_DT = Convert.ToDateTime(sysDate);//系统推荐交货日期
                mod.D_NEED_DT = Convert.ToDateTime(sysDate);//需求日期
                mod.C_SHIPVIA = shipvia;


                #region //收货单位相关信息
                Mod_TS_CUSTADDR modaddr = custaddr.GetModel(addrid);
                if (modaddr != null)
                {
                    mod.C_CGC = modaddr.C_CGC;
                    mod.C_CGAREA = modaddr.C_CGAREA;
                    mod.C_CGADDR = modaddr.C_CGADDR;
                    mod.C_CGMAN = modaddr.C_CGMAN;
                    mod.C_CGMOBILE = modaddr.C_CGMOBILE;
                }
                #endregion

                #region //获取钢种单价-折扣-税率
                DataTable dt = activity.GetActivityList(c_mat_code, c_stl_grd, c_spec).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    decimal n_notax_unitprice = Convert.ToDecimal(dt.Rows[0]["N_PRICE"]);//无税单价
                    decimal n_rate = Convert.ToDecimal(dt.Rows[0]["N_RATE"]);//税率
                    decimal unitPrice = n_notax_unitprice * n_rate + n_notax_unitprice;//含税单价

                    decimal n_discount = Convert.ToDecimal(dt.Rows[0]["N_DISCOUNT"]);//折扣

                    decimal n_orimoto = Convert.ToDecimal(dt.Rows[0]["N_ORIMOTO"]);//折本汇率
                    mod.N_CELING_RATE = n_orimoto;

                    mod.N_NOTAX_UNITPRICE = n_notax_unitprice;//无税单价
                    mod.N_NOTAX_NETPRICE = n_notax_unitprice;//无税净价
                    mod.N_INCLUTAX_NETPRICE = unitPrice;//含税净价
                    mod.N_DC_NOTAX_UNITPRICE = n_notax_unitprice;//本币无税单价
                    mod.N_DC_INCLUTAX_UNITPRICE = unitPrice;//本币含税单价

                    mod.N_TAX = n_rate;//税率

                    decimal n_nomoney = Convert.ToDecimal(n_wgt) * n_notax_unitprice;//无税金额
                    mod.N_NOMONEY = n_nomoney;//无税金额

                    decimal n_pricetax_sum = Convert.ToDecimal(n_wgt) * unitPrice;//价税合计
                    mod.N_PRICETAX_SUM = n_pricetax_sum;//价税合计
                    mod.N_DC_PRICETAX_SUM = n_pricetax_sum;//本币价税合计

                    mod.N_ITEM_DIS = Convert.ToDecimal(dt.Rows[0]["N_DISCOUNT"]);//单品折扣

                    mod.N_AMOUNT_FAX = n_pricetax_sum - n_nomoney;//税额
                    mod.N_DC_AMOUNT_FAX = n_pricetax_sum - n_nomoney;//税额
                }
                #endregion

                #region  //获取执行标准/自由项/品种/类别 //设置质量设计号//订单-质量 //等级

                Mod_TQB_STD_MAIN mod_std_main = std_main.GetModel(c_std_code);
                if (mod_std_main != null)
                {
                    mod.C_PROD_NAME = mod_std_main.C_PROD_NAME;//类别
                    mod.C_PROD_KIND = mod_std_main.C_PROD_KIND;//品种
                    mod.C_STD_CODE = mod_std_main.C_STD_CODE;//执行标准代码
                }

                DataRow dr = std_config.GetFREE(c_std_code);
                if (dr != null)
                {
                    mod.C_FREE_TERM = dr["C_ZYX1"].ToString();
                    mod.C_FREE_TERM2 = dr["C_ZYX2"].ToString();
                }

                mod.C_LEV = "普通";

                string PK_DESIGN_ID = "";//质量设计号主键ID

                DataTable dtDesign = design.GetList("", c_std_code).Tables[0];//质量设计信息
                if (dtDesign.Rows.Count > 0)
                {
                    mod.C_DESIGN_NO = dtDesign.Rows[0]["C_DESIGN_NO"].ToString();//质量设计号
                    PK_DESIGN_ID = dtDesign.Rows[0]["C_ID"].ToString();//质量设计主键ID
                }

                #endregion

                bool result = false;

                if (condetails.Update(mod))
                {
                    //删除订单-质量
                    if (design_order.DeleteOder(orderNo))
                    {
                        //订单质量设计信息插入
                        Mod_TQB_DESIGN_ORDER modDesign_Order = new Mod_TQB_DESIGN_ORDER();
                        modDesign_Order.C_ORDER_ID = orderNo;
                        modDesign_Order.C_DESIGN_ID = PK_DESIGN_ID;
                        result = design_order.Add(modDesign_Order);
                    }
                }
                return result;
            }
            else//新增数据
            {
                Mod_TMO_CONDETAILS mod = new Mod_TMO_CONDETAILS();

                string order_no = c_con_no + DateTime.Now.ToString("MMddHHmmss");//订单号
                mod.C_NO = order_no;
                mod.C_CON_NO = c_con_no;
                mod.C_CON_NAME = c_con_name;
                mod.C_AREA = c_area;
                mod.C_MAT_CODE = c_mat_code;
                mod.C_MAT_NAME = c_mat_name;
                mod.C_STD_CODE = c_std_code;
                mod.C_TECH_PROT = c_tech_prot;
                mod.C_SPEC = c_spec;
                mod.C_STL_GRD = c_stl_grd;
                mod.C_UNITIS = c_unitis;
                mod.C_PRO_USE = c_pro_use;
                mod.D_DELIVERY_DT = Convert.ToDateTime(d_delivery_dt);
                mod.D_DT = DateTime.Now;
                mod.N_WGT = Convert.ToDecimal(n_wgt);
                mod.N_DIA = Convert.ToDecimal(n_dia);
                mod.N_TYPE = Convert.ToDecimal(n_type);
                mod.C_PACK = c_pack;
                mod.C_CURRENCY_TYPE = n_currency_type;
                mod.C_OTC = c_otc;
                mod.D_SYS_DELIVERY_DT = Convert.ToDateTime(sysDate);//系统推荐交货日期
                mod.D_NEED_DT = Convert.ToDateTime(need_date);//需求日期

                mod.C_CUST_NO = custNo;
                mod.C_CUST_NAME = custName;
                mod.N_USER_LEV = Convert.ToDecimal(custLEV);//客户等级
                mod.C_LEV = lev;//维护等级
                mod.C_SALE_CHANNEL = custType;

                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    mod.C_EMP_ID = BaseUser.Id;
                    mod.C_EMP_NAME = BaseUser.Name;
                }

                #region //收货单位相关信息
                Mod_TS_CUSTADDR modaddr = custaddr.GetModel(addrid);
                if (modaddr != null)
                {
                    mod.C_CGC = modaddr.C_CGC;
                    mod.C_CGAREA = modaddr.C_CGAREA;
                    mod.C_CGADDR = modaddr.C_CGADDR;
                    mod.C_CGMAN = modaddr.C_CGMAN;
                    mod.C_CGMOBILE = modaddr.C_CGMOBILE;
                }
                #endregion

                #region //获取钢种单价-折扣-税率
                DataTable dt = activity.GetActivityList(c_mat_code, c_stl_grd, c_spec).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    decimal n_notax_unitprice = Convert.ToDecimal(dt.Rows[0]["N_PRICE"]);//无税单价
                    decimal n_rate = Convert.ToDecimal(dt.Rows[0]["N_RATE"]);//税率
                    decimal unitPrice = n_notax_unitprice * n_rate + n_notax_unitprice;//含税单价

                    decimal n_discount = Convert.ToDecimal(dt.Rows[0]["N_DISCOUNT"]);//折扣

                    decimal n_orimoto = Convert.ToDecimal(dt.Rows[0]["N_ORIMOTO"]);//折本汇率
                    mod.N_CELING_RATE = n_orimoto;

                    mod.N_NOTAX_UNITPRICE = n_notax_unitprice;//无税单价
                    mod.N_NOTAX_NETPRICE = n_notax_unitprice;//无税净价
                    mod.N_INCLUTAX_NETPRICE = unitPrice;//含税净价
                    mod.N_DC_NOTAX_UNITPRICE = n_notax_unitprice;//本币无税单价
                    mod.N_DC_INCLUTAX_UNITPRICE = unitPrice;//本币含税单价

                    mod.N_TAX = n_rate;//税率

                    decimal n_nomoney = Convert.ToDecimal(n_wgt) * n_notax_unitprice;//无税金额
                    mod.N_NOMONEY = n_nomoney;//无税金额

                    decimal n_pricetax_sum = Convert.ToDecimal(n_wgt) * unitPrice;//价税合计
                    mod.N_PRICETAX_SUM = n_pricetax_sum;//价税合计
                    mod.N_DC_PRICETAX_SUM = n_pricetax_sum;//本币价税合计

                    mod.N_ITEM_DIS = Convert.ToDecimal(dt.Rows[0]["N_DISCOUNT"]);//单品折扣

                    mod.N_AMOUNT_FAX = n_pricetax_sum - n_nomoney;//税额
                    mod.N_DC_AMOUNT_FAX = n_pricetax_sum - n_nomoney;//税额
                }
                #endregion

                #region  //获取执行标准/自由项/品种/类别 //设置质量设计号//订单-质量 //等级

                Mod_TQB_STD_MAIN mod_std_main = std_main.GetModel(c_std_code);
                if (mod_std_main != null)
                {
                    mod.C_PROD_NAME = mod_std_main.C_PROD_NAME;//类别
                    mod.C_PROD_KIND = mod_std_main.C_PROD_KIND;//品种
                    mod.C_STD_CODE = mod_std_main.C_STD_CODE;//执行标准代码
                }

                DataRow dr = std_config.GetFREE(c_std_code);
                if (dr != null)
                {
                    mod.C_FREE_TERM = dr["C_ZYX1"].ToString();
                    mod.C_FREE_TERM2 = dr["C_ZYX2"].ToString();
                }

                mod.C_LEV = "普通";

                string PK_DESIGN_ID = "";//质量设计号主键ID

                DataTable dtDesign = design.GetList("", c_std_code).Tables[0];//质量设计信息
                if (dtDesign.Rows.Count > 0)
                {
                    mod.C_DESIGN_NO = dtDesign.Rows[0]["C_DESIGN_NO"].ToString();//质量设计号
                    PK_DESIGN_ID = dtDesign.Rows[0]["C_ID"].ToString();//质量设计主键ID
                }

                #endregion


                bool result = false;

                if (condetails.Add(mod))
                {
                    //插入订单质量设计号
                    Mod_TQB_DESIGN_ORDER modDesign_Order = new Mod_TQB_DESIGN_ORDER();
                    modDesign_Order.C_ORDER_ID = order_no;
                    modDesign_Order.C_DESIGN_ID = PK_DESIGN_ID;
                    result = design_order.Add(modDesign_Order);
                }
                return result;
            }
        }
    }
}