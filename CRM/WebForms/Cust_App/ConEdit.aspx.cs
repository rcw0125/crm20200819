using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Data;
using NF.MODEL;
using NF.BLL;
using NF.Framework;
using NF.Bussiness.Interface;
using NF.Web.Core;
using Microsoft.Practices.Unity;
using System.Web.UI;



namespace CRM.Cust_App
{
    public partial class ConEdit : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();

        private Bll_TB_STD_CONFIG tb_std_config = new Bll_TB_STD_CONFIG();

        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();

        private Bll_TQB_PACK tqb_pack = new Bll_TQB_PACK();
        private Bll_TS_USER ts_user = new Bll_TS_USER();
        private Bll_TS_DEPT ts_dept = new Bll_TS_DEPT();
        private Bll_TQB_CHECKSTATE tqb_checkstate = new Bll_TQB_CHECKSTATE();
        private Bll_TMB_TAXITEMS tmb_taxitems = new Bll_TMB_TAXITEMS();

        private Bll_RandomNumber randomnumber = new Bll_RandomNumber();


        private static DataTable dtOrder = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                ViewState["back_no"] = 0;

                Session["kh"] = null;


                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlC_EMP_ID.Text = vUser.Id;
                    ltlC_EMP_NAME.Text = vUser.Name;

                    try
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                        {
                            #region //加载基础数据
                            BindCurrency();
                            BindContractType();
                            BindShipVia();
                            #endregion

                            txtConNO.Text = Request.QueryString["ID"];
                            GetConInfo();//加载合同订单信息
                        }
                    }
                    catch (Exception ex)
                    {
                        WebMsg.MessageBox(ex.Message);
                    }


                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }

            ViewState["back_no"] = Convert.ToInt32(ViewState["back_no"]) + 1;
        }


        #region //加载合同基础数据

        /// <summary>
        /// 获取数字字典
        /// </summary>
        /// <param name="code">编码</param>
        /// <returns></returns>
        private DataTable GetData(string code)
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = code;
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            return dt;
        }

        /// <summary>
        /// 获取货币类型
        /// </summary>
        private void BindCurrency()
        {

            DataTable dt = GetData("Currency");
            if (dt.Rows.Count > 0)
            {

                dropCurrType.DataSource = dt;
                dropCurrType.DataTextField = "C_DETAILNAME";
                dropCurrType.DataValueField = "C_ID";
                dropCurrType.DataBind();
            }
            else
            {
                dropCurrType.DataSource = null;
                dropCurrType.DataBind();
            }
        }

        /// <summary>
        /// 合同类型
        /// </summary>
        private void BindContractType()
        {
            DataTable dt = GetData("ContractType");
            if (dt.Rows.Count > 0)
            {

                dropConType.DataSource = dt;
                dropConType.DataTextField = "C_DETAILNAME";
                dropConType.DataValueField = "C_ID";
                dropConType.DataBind();
            }
            else
            {
                dropConType.DataSource = null;
                dropConType.DataBind();
            }
        }

        /// <summary>
        /// 发运方式
        /// </summary>
        private void BindShipVia()
        {
            DataTable dt = GetData("ShipVia");
            if (dt.Rows.Count > 0)
            {

                dropShipVia.DataSource = dt;
                dropShipVia.DataTextField = "C_DETAILNAME";
                dropShipVia.DataValueField = "C_ID";
                dropShipVia.DataBind();
            }
            else
            {
                dropShipVia.DataSource = null;
                dropShipVia.DataBind();
            }
        }
        #endregion

        /// <summary>
        /// 获取收货单位/开票单位
        /// </summary>
        /// <param name="C_NC_M_ID">NC客商管理档案主键</param>
        /// <returns></returns>
        private string GetCust(string C_NC_M_ID)
        {
            string str = string.Empty;
            Mod_TS_CUSTFILE mod = ts_custfile.GetCustModel(C_NC_M_ID);
            str = mod.C_NAME;
            return str;
        }

        /// <summary>
        /// 加载合同信息
        /// </summary>
        private void GetConInfo()
        {
            if (!string.IsNullOrEmpty(txtConNO.Text))
            {
                Mod_TMO_CON modcon = tmo_con.GetModel(txtConNO.Text);
                if (modcon != null)
                {
                    ltlcon_bgNo.Text = modcon.N_CHANGENUM.ToString();//合同版本

                    Mod_TS_CUSTFILE modCust = ts_custfile.GetCustModel(modcon.C_CUSTOMERID);
                    hidCustNO.Value = modCust.C_NO;
                    hidCustID.Value = modcon.C_CUSTOMERID;//客户ID

                    ltlCustType.Text = modCust.N_TYPE == 1 ? "经销" : "直销";
                    ltlN_CON_STATUS.Text = modcon.N_STATUS.ToString();
                    hidstatus.Value = modcon.N_STATUS.ToString();//当前状态

                    #region //状态按钮设置

                    bool boolbtn = ltlN_CON_STATUS.Text == "-1" ? true : false;
                    btnSave.Enabled = boolbtn;
                    btnSubmit.Enabled = boolbtn;
                    btnProc.Disabled = ltlN_CON_STATUS.Text == "-1" ? false : true;
                    //btnProc_F.Disabled = ltlN_CON_STATUS.Text == "-1" ? false : true;
                    btnAdd.Disabled = ltlN_CON_STATUS.Text == "-1" ? false : true;
                    btnConBg.Enabled = ltlN_CON_STATUS.Text == "2" ? true : false;
                    #endregion


                    txtConName.Text = modcon.C_CON_NAME;
                    dropConType.SelectedIndex = dropConType.Items.IndexOf(dropConType.Items.FindByText(modcon.C_CONTYPEID));
                    txtCustName.Text = modcon.C_CUSTNAME;


                    if (!string.IsNullOrEmpty(modcon.D_CONSING_DT.ToString()))
                    {
                        txtDate.Value = Convert.ToDateTime(modcon.D_CONSING_DT).ToString("yyy-MM-dd");
                    }

                    if (!string.IsNullOrEmpty(modcon.D_CONEFFE_DT.ToString()))
                    {
                        txtStart.Value = Convert.ToDateTime(modcon.D_CONEFFE_DT).ToString("yyy-MM-dd");
                    }
                    if (!string.IsNullOrEmpty(modcon.D_CONINVALID_DT.ToString()))
                    {
                        txtEnd.Value = Convert.ToDateTime(modcon.D_CONINVALID_DT).ToString("yyy-MM-dd");
                    }

                    dropShipVia.SelectedIndex = dropShipVia.Items.IndexOf(dropShipVia.Items.FindByValue(modcon.C_TRANSMODEID));
                    dropCurrType.SelectedIndex = dropCurrType.Items.IndexOf(dropCurrType.Items.FindByValue(modcon.C_CURRENCYTYPEID));


                    txtC_CGC.Value = GetCust(modcon.C_CRECEIPTCUSTOMERID);//收货单位
                    hidC_CGID.Value = modcon.C_CRECEIPTCUSTOMERID;//收货单位NC主键

                    txtC_OTC.Value = GetCust(modcon.C_CRECEIPTCORPID);//开票单位
                    hidC_OTCID.Value = modcon.C_CRECEIPTCORPID;//开票单位NC主键
                    txtC_STATION.Value = modcon.C_STATION;

                    #region //业务员
                    txtSaleUser.Value = ts_user.GetSaleName(modcon.C_EMPLOYEEID);
                    hidsaleempid.Value = modcon.C_EMPLOYEEID;
                    hiddeptid.Value = modcon.C_DEPTID;
                    #endregion

                    txtReamrk.Value = modcon.C_REAMRK;

                    txtAddr.Value = modcon.C_ADDRESS;

                    GetOrderList();
                }
            }
        }

        /// <summary>
        /// 加载合同订单列表
        /// </summary>
        private void GetOrderList()
        {
            if (!string.IsNullOrEmpty(txtConNO.Text))
            {

                dtOrder = tmo_order.GetConOrderList(txtConNO.Text, "", "", "", "", "").Tables[0];
                if (dtOrder.Rows.Count > 0)
                {
                    rptList.DataSource = dtOrder;
                    rptList.DataBind();

                    ltlWGT_SUM.Text = dtOrder.Compute("sum(N_WGT)", "true").ToString();
                    ltlN_ORIGINALCURSUMMNY.Text = dtOrder.Compute("sum(N_ORIGINALCURSUMMNY)", "true").ToString();
                }
                else
                {

                    ltlWGT_SUM.Text = string.Empty;
                    ltlN_ORIGINALCURSUMMNY.Text = string.Empty;
                    rptList.DataSource = null;
                    rptList.DataBind();
                }
            }
        }


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


        private bool Add(int N_STATUS)
        {

            bool result = true;

            List<Mod_TMO_ORDER> orderList = new List<Mod_TMO_ORDER>();

            #region //修改合同基本信息

            Mod_TMO_CON modCon = tmo_con.GetModel(txtConNO.Text);
            modCon.C_CON_NO = txtConNO.Text;
            modCon.C_CON_NAME = txtConName.Text;
            modCon.C_CONTYPEID = dropConType.SelectedItem.Value;//合同类型
            modCon.C_EMPLOYEEID = hidsaleempid.Value;//业务员
            modCon.C_DEPTID = hiddeptid.Value;//业务部门

            modCon.C_CURRENCYTYPEID = dropCurrType.SelectedValue;//货币类型
            modCon.D_CONSING_DT = Convert.ToDateTime(txtDate.Value);//签约日期
            modCon.D_CONEFFE_DT = Convert.ToDateTime(txtStart.Value);//计划生效日期
            modCon.D_CONINVALID_DT = Convert.ToDateTime(txtEnd.Value);//计划失效日期
            modCon.D_NEED_DT = Convert.ToDateTime(txtEnd.Value).AddDays(-30);//需求日期
            modCon.C_TRANSMODEID = dropShipVia.SelectedValue;//发运方式     
            modCon.N_STATUS = N_STATUS;

            Mod_TS_DEPT modDept = ts_dept.GetModel(hiddeptid.Value);
            if (modDept != null)
            {
                modCon.C_AREA = modDept.C_NAME;//合同区域
            }

            if (!string.IsNullOrEmpty(hidC_CGID.Value))
            {
                Mod_TS_CUSTFILE modCust = ts_custfile.GetCustModel(hidC_CGID.Value);
                modCon.C_CRECEIPTCUSTOMERID = hidC_CGID.Value;//收货单位
                modCon.C_ADDRESS = txtAddr.Value;//收货地址
                modCon.C_CRECEIPTAREAID = modCust.C_AREATYPE;//收货地区
            }

            modCon.C_STATION = txtC_STATION.Value;
            modCon.C_REAMRK = txtReamrk.Value;

            #endregion

            #region//修改合同明细
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                Literal ltlC_NO = (Literal)rptList.Items[i].FindControl("ltlC_NO");
                TextBox txtPack_Code = (TextBox)rptList.Items[i].FindControl("txtPack_Code");//包装要求
                TextBox txtWgt = (TextBox)rptList.Items[i].FindControl("txtWgt");//数量
                TextBox txtC_PRO_USE = (TextBox)rptList.Items[i].FindControl("txtC_PRO_USE");//用途
                TextBox txtC_CUST_SQ = (TextBox)rptList.Items[i].FindControl("txtC_CUST_SQ");//特殊要求
                TextBox txtN_ORIGINALCURTAXPRICE = (TextBox)rptList.Items[i].FindControl("txtN_ORIGINALCURTAXPRICE");//含税单价
                DropDownList dropZL = (DropDownList)rptList.Items[i].FindControl("dropZL");//质量

                if (string.IsNullOrEmpty(txtPack_Code.Text) && tqb_pack.Exists(txtPack_Code.Text))
                {
                    result = false;
                    break;
                }


                Mod_TMO_ORDER modOrder = tmo_order.GetModel(ltlC_NO.Text);
                modOrder.C_CON_NAME = modCon.C_CON_NAME;//合同名称
                modOrder.C_AREA = modCon.C_AREA;//合同区域
                //modOrder.D_NEED_DT = modCon.D_NEED_DT;//需求日期
                modOrder.D_DELIVERY_DT = modCon.D_CONINVALID_DT;//计划收货日期
                modOrder.C_VDEF1 = dropZL.SelectedItem.Value;//质量主键
                modOrder.C_PACK = txtPack_Code.Text.Trim();//包装要求
                decimal N_WGT = 0;
                if (!string.IsNullOrEmpty(txtWgt.Text))
                {
                    N_WGT = Convert.ToDecimal(txtWgt.Text);
                    modOrder.N_WGT = N_WGT;//数量

                }
                modOrder.N_FNUM = modOrder.N_HSL == 0 ? 1 : N_WGT / modOrder.N_HSL;//辅数量

                #region //获取钢种单价-折扣-税率                           
                if (!string.IsNullOrEmpty(txtN_ORIGINALCURTAXPRICE.Text))
                {
                    decimal N_TAXRATE = Convert.ToDecimal(modOrder.N_TAXRATE) + 1;//税率
                    decimal N_ORIGINALCURPRICE = Convert.ToDecimal(txtN_ORIGINALCURTAXPRICE.Text) / N_TAXRATE;//原币无税单价
                    decimal N_ORIGINALCURTAXPRICE = Convert.ToDecimal(txtN_ORIGINALCURTAXPRICE.Text);//原币含税单价

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
                modOrder.C_CUST_SQ = txtC_CUST_SQ.Text;//客户要求
                modOrder.C_PRO_USE = txtC_PRO_USE.Text;//产品用途
                modOrder.C_TRANSMODE = dropShipVia.SelectedItem.Text;//发运方式
                modOrder.C_TRANSMODEID = dropShipVia.SelectedItem.Value;//发运主键
                modOrder.C_YWY = txtSaleUser.Value;//业务员
                modOrder.N_STATUS = N_STATUS;//订单状态
                modOrder.N_EXEC_STATUS = -2;//订单状态
                orderList.Add(modOrder);
            }
            #endregion

            return result == true ? tmo_con.UpdateConOrder(modCon, orderList) : result;

        }


        //提交合同
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Add(0))
                {
                    WebMsg.MessageBox("提交成功", "MyCon.aspx");
                }
                else
                {
                    WebMsg.MessageBox("包装不能为空或与实际包装不符！");
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }

        //删除合同明细
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "del")
            {
                string orderNo = e.CommandArgument.ToString();

                if (tmo_con.DelConOrder(orderNo))
                {
                    GetOrderList();
                    ScriptManager.RegisterStartupScript(UpdatePanel4, this.Page.GetType(), "", "tabActive();", true);
                }
            }
        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Add(-1))
                {
                    GetOrderList();
                    WebMsg.MessageBox("保存成功");
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DropDownList dropZL = (DropDownList)e.Item.FindControl("dropZL");
            Literal ltlC_VDEF1 = (Literal)e.Item.FindControl("ltlC_VDEF1");
            LinkButton lbtDel = (LinkButton)e.Item.FindControl("lbtDel");
            lbtDel.Visible = ltlN_CON_STATUS.Text == "-1" ? true : false;

            DataTable dtzl = tqb_checkstate.GetCheckState("").Tables[0];
            if (dtzl.Rows.Count > 0)
            {
                dropZL.DataSource = dtzl;
                dropZL.DataTextField = "C_CHECKSTATE_NAME";
                dropZL.DataValueField = "C_ID";
                dropZL.DataBind();
                dropZL.SelectedIndex = dropZL.Items.IndexOf(dropZL.Items.FindByValue(ltlC_VDEF1.Text));
            }
        }

        protected void imgbtnJz_Click(object sender, ImageClickEventArgs e)
        {
            if (InsertOrder())
            {
                Session["kh"] = null;
                GetOrderList();
            }
            else
            {
                Session["kh"] = null;
            }
        }

        private bool InsertOrder()
        {
            List<Mod_TMO_ORDER> orderList = new List<Mod_TMO_ORDER>();
            if (Session["kh"] != null)
            {
                DataTable dt = (DataTable)Session["kh"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    #region 数据操作     

                    Mod_TS_USER modUser = ts_user.GetModel(ltlC_EMP_ID.Text);
                    Mod_TMO_CON modCon = tmo_con.GetModel(txtConNO.Text);
                    Mod_TB_MATRL_MAIN modMat = tb_matrl_main.GetModel(dt.Rows[i]["C_ID"].ToString());
                    Mod_TS_CUSTFILE modCust = ts_custfile.GetModel(modUser.C_CUST_ID);
                    Mod_TMO_ORDER modOrder = new Mod_TMO_ORDER();

                    string order_no = randomnumber.CreateOrderNo(txtConNO.Text);//订单号
                    modOrder.C_ORDER_NO = order_no;
                    modOrder.C_CON_NO = txtConNO.Text;//合同号
                    modOrder.C_CON_NAME = modCon.C_CON_NAME;//合同名称
                    modOrder.C_AREA = modCon.C_AREA;//区域
                    modOrder.C_INVBASDOCID = modMat.C_PK_INVBASDOC;//存货档案主键
                    modOrder.C_INVENTORYID = modMat.C_PK_INVMANDOC;//存货管理档案主键
                    modOrder.C_PROD_NAME = modMat.C_PROD_NAME;//品名
                    modOrder.C_PROD_KIND = modMat.C_PROD_KIND;//品种
                    modOrder.C_MAT_CODE = modMat.C_MAT_CODE;//物料编码
                    modOrder.C_MAT_NAME = modMat.C_MAT_NAME;//物料名称
                    modOrder.C_SPEC = modMat.C_SPEC;//规格
                    modOrder.C_STL_GRD = modMat.C_MAT_TYPE == "841" ? modMat.C_MAT_NAME : modMat.C_MAT_TYPE == "851" ? modMat.C_MAT_NAME : modMat.C_STL_GRD;//钢种
                    modOrder.C_FUNITID = modMat.C_FJLDW;//辅单位
                    modOrder.C_UNITID = modMat.C_PK_MEASDOC;//主计量单位
                    modOrder.D_DELIVERY_DT = modCon.D_CONINVALID_DT;//计划收货日期
                    modOrder.D_DT = modCon.D_CONSING_DT;//订单日期//签单日期
                    modOrder.C_VDEF1 = "";//质量ID
                    modOrder.C_SFPJ = "N";

                    modOrder.C_TECH_PROT = dt.Rows[i]["C_CUST_TECH_PROT"].ToString();//客户协议号
                    modOrder.C_STD_CODE = dt.Rows[i]["C_STD_CODE"].ToString();//执行标准
                    modOrder.C_FREE1 = dt.Rows[i]["ZYX1"].ToString();//自由项1
                    modOrder.C_FREE2 = dt.Rows[i]["ZYX2"].ToString();//自由项2
                    modOrder.C_BY4 = dt.Rows[i]["C_BY4"].ToString();//是否不锈钢
                    modOrder.N_TYPE = Convert.ToDecimal(modMat.C_MAT_TYPE);
                    modOrder.C_PACK = dt.Rows[i]["C_PACK"].ToString();//包装要求
                    modOrder.C_RECEIPTAREAID = modCon.C_CRECEIPTAREAID;//收货地区
                    modOrder.C_RECEIVEADDRESS = modCon.C_ADDRESS;//收货地址
                    modOrder.C_RECEIPTCORPID = modCon.C_CRECEIPTCUSTOMERID;//收货单位
                    modOrder.C_CURRENCYTYPEID = modCon.C_CURRENCYTYPEID; //货币
                    modOrder.N_TYPE = Convert.ToDecimal(modMat.C_MAT_TYPE);
                    modOrder.N_USER_LEV = modCon.N_CUST_LEV;//客户等级
                    modOrder.C_REMARK = modCon.C_REAMRK;
                    modOrder.C_EMP_ID = modUser.C_ID;
                    modOrder.C_EMP_NAME = modUser.C_EMP_NAME;
                    modOrder.C_CUST_NO = modCust.C_NO;
                    modOrder.C_CUST_NAME = modCust.C_NAME;
                    modOrder.C_SALE_CHANNEL = modCust.N_TYPE == 1 ? "经销" : "直销";
                    modOrder.C_LEV = GetLev("STL_GRD_Lev");//钢种等级
                    modOrder.C_ORDER_LEV = GetLev("Order_Lev");//订单等级
                    modOrder.N_COST = 0;//成本
                    modOrder.N_STATUS = -1;//订单状态

                    decimal N_WGT = 0;
                    if (!string.IsNullOrEmpty(dt.Rows[i]["N_WGT"].ToString()))
                    {
                        N_WGT = Convert.ToDecimal(dt.Rows[i]["N_WGT"].ToString());
                    }
                    modOrder.N_WGT = N_WGT;//数量
                    modOrder.N_HSL = modMat.N_HSL == null ? 0 : modMat.N_HSL;//换算率
                    modOrder.N_FNUM = modMat.N_HSL == null ? 1 : N_WGT / modMat.N_HSL;//辅数量
                    if (!string.IsNullOrEmpty(modMat.C_PK_TAXITEMS))
                    {
                        Mod_TMB_TAXITEMS modTaxi = tmb_taxitems.GetModel(modMat.C_PK_TAXITEMS);
                        modOrder.N_TAXRATE = modTaxi.N_TAXRATIO;//税率

                        #region //获取钢种单价-税率   
                        string Price = dt.Rows[i]["PRICE"].ToString().ToString() == "" ? "0" : dt.Rows[i]["PRICE"].ToString().ToString();//单价
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
                    }


                    orderList.Add(modOrder);

                    #endregion
                }
            }

            return tmo_con.InsertFirstOrder(orderList);


        }
        //合同变更
        protected void btnConBg_Click(object sender, EventArgs e)
        {
            try
            {
                #region //新增变更合同
                List<Mod_TMO_ORDER> orderList = new List<Mod_TMO_ORDER>();

                #region //添加合同基本信息

                int NO = Convert.ToInt32(ltlcon_bgNo.Text) + 1;

                Mod_TMO_CON modCon = tmo_con.GetModel(txtConNO.Text);
                modCon.C_CON_NO = modCon.C_CON_NO + "-" + NO.ToString();
                modCon.C_CON_NAME = modCon.C_CON_NAME;
                modCon.N_STATUS = -1;//客户待提交
                modCon.D_CONSING_DT = DateTime.Now;//合同签署日期
                modCon.D_CONEFFE_DT = Convert.ToDateTime(DateTime.Now);//计划生效日期
                modCon.D_CONINVALID_DT = Convert.ToDateTime(DateTime.Now).AddDays(60);//计划失效日期
                modCon.C_CON_NO_OLD = txtConNO.Text;//原始合同号
                modCon.N_CHANGENUM = NO;//变更次数
                #endregion

                #region//添加合同明细
                Bll_RandomNumber randomnumber = new Bll_RandomNumber();//流水号
                DataTable dtOrder = tmo_order.GetConOrderList(txtConNO.Text, "", "", "", "", "").Tables[0];

                for (int i = 0; i < dtOrder.Rows.Count; i++)
                {

                    Mod_TMO_ORDER modOrder = tmo_order.GetModel(dtOrder.Rows[i]["C_ID"].ToString());//订单表
                    string order_no = randomnumber.CreateOrderNo(modCon.C_CON_NO);//订单号
                    modOrder.C_ORDER_NO = order_no;
                    modOrder.C_CON_NO = modCon.C_CON_NO;//合同号
                    modOrder.C_CON_NAME = modCon.C_CON_NAME;//合同名称
                    modOrder.C_CUST_NO = modCon.C_CUST_NO;//客户编码
                    modOrder.C_CUST_NAME = modCon.C_CUSTNAME;//客户名称
                    modOrder.C_RECEIPTCORPID = modCon.C_CRECEIPTCUSTOMERID;//收货单位
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
                    string url = "ConEdit_BG.aspx?ID=" + modCon.C_CON_NO + "&YID=" + txtConNO.Text;
                    Response.Redirect(url);
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }
    }
}