using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.Unity;

using System.Data;

using NF.BLL;
using NF.MODEL;
using NF.Framework;
using NF.Bussiness.Interface;
using NF.Web.Core;
using NF.EF.Model;
using NF.NC.Interface;

namespace CRM.Sale_App
{
    public partial class ConEdit : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TMB_AREAPLAN tmb_areaplan = new Bll_TMB_AREAPLAN();
        private Bll_TMB_FLOWINFO tmb_flowinfo = new Bll_TMB_FLOWINFO();
        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_TS_USER ts_user = new Bll_TS_USER();
        private Bll_TS_DEPT ts_dept = new Bll_TS_DEPT();
        private Bll_TB_STD_CONFIG tb_std_config = new Bll_TB_STD_CONFIG();
        private Bll_TQB_STD_MAIN tqb_std_main = new Bll_TQB_STD_MAIN();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private Bll_TQB_CHECKSTATE tqb_checkstate = new Bll_TQB_CHECKSTATE();
        private Bll_TS_CUSTADDR ts_custaddr = new Bll_TS_CUSTADDR();
        private Bll_TMB_STLGRD_PRICE_WGT tmb_stlgrd_price_wgt = new Bll_TMB_STLGRD_PRICE_WGT();

        IComService buttonService = DIFactory.GetContainer().Resolve<IComService>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["back_no"] = 0;

                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    try
                    {
                        GetFun();//加载按钮权限

                        ltlC_EMP_ID.Text = vUser.Id;
                        ltlC_EMP_NAME.Text = vUser.Name;

                        #region //加载基础数据

                        GetConType(); //合同类型
                        GetShipVia();//发运方式
                        GetCurrency(); //币种
                        GetBusinessType();//业务类型
                        GetSalesOrg();//销售组织

                        //GetPlanWGT();//区域计划量/实际接收订单量

                        #endregion

                        if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                        {
                            txtConNO.Value = Request.QueryString["ID"];
                            hidconno.Value = Request.QueryString["ID"];
                            GetConInfo();//加载合同信息
                        }
                    }
                    catch (Exception ex)
                    {
                        WebMsg.MessageBox(ex.Message);
                    }
                }
            }
            ViewState["back_no"] = Convert.ToInt32(ViewState["back_no"]) + 1;
        }


        private void GetFun()
        {
            var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (user != null)
            {
                buttonService.RefreshButton("/WebForms/Sale_App/ConList.aspx", user, Session);
                List<TS_BUTTON> button = (List<TS_BUTTON>)Session["button"];

                foreach (var item in button)
                {
                    if (Page.FindControl(item.C_CODE) != null)
                    {
                        Page.FindControl(item.C_CODE).Visible = true;
                    }
                }
            }
            else
            {
                WebMsg.CheckUserLogin();
            }
        }

        #region //加载基础数据

        ///// <summary>
        ///// 区域计划量/实际接收订单量
        ///// </summary>
        //private void GetPlanWGT()
        //{
        //    DataTable dt = tmb_areaplan.GetPlanWGT().Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            string[] arr = dt.Rows[i]["wgt"].ToString().Split(':');
        //            //ltlWGT.Text += "<a href=\"javascript:void(0);\" class=\"a_wgt\" onclick=\"openWeb3('" + arr[0] + "');\" style=\"margin-left:15px; \">" + dt.Rows[i]["wgt"].ToString() + "</a>";
        //            ltlWGT.Text += "<li><a href=\"javascript:void(0);\" class=\"a_wgt\"  style=\"margin-left:15px; \">" + dt.Rows[i]["wgt"].ToString() + "</a></li>";
        //        }
        //    }
        //}

        /// <summary>
        /// 获取数字字典
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private DataTable GetData(string code)
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = code;
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            return dt;
        }



        /// <summary>
        /// 销售组织
        /// </summary>
        private void GetSalesOrg()
        {
            DataTable dt = GetData("SalesOrg");
            if (dt.Rows.Count > 0)
            {
                dropSale.DataSource = dt;
                dropSale.DataTextField = "C_DETAILNAME";
                dropSale.DataValueField = "C_ID";
                dropSale.DataBind();
                dropSale.Items.Insert(0, new ListItem("", ""));
            }
            else
            {
                dropSale.DataSource = null;
                dropSale.DataBind();
            }
        }

        /// <summary>
        /// 业务类型
        /// </summary>
        private void GetBusinessType()
        {

            DataTable dt = GetData("BusinessType");
            if (dt.Rows.Count > 0)
            {

                dropYeWuType.DataSource = dt;
                dropYeWuType.DataTextField = "C_DETAILNAME";
                dropYeWuType.DataValueField = "C_ID";
                dropYeWuType.DataBind();
                dropYeWuType.Items.Insert(0, new ListItem("", ""));
            }
            else
            {
                dropYeWuType.DataSource = null;
                dropYeWuType.DataBind();
            }
        }

        /// <summary>
        /// 获取货币类型
        /// </summary>
        private void GetCurrency()
        {

            DataTable dt = GetData("Currency");
            if (dt.Rows.Count > 0)
            {

                dropBiZhong.DataSource = dt;
                dropBiZhong.DataTextField = "C_DETAILNAME";
                dropBiZhong.DataValueField = "C_ID";
                dropBiZhong.DataBind();
                dropBiZhong.Items.Insert(0, new ListItem("", ""));
            }
            else
            {
                dropBiZhong.DataSource = null;
                dropBiZhong.DataBind();
            }
        }

        /// <summary>
        /// 合同类型
        /// </summary>
        private void GetConType()
        {

            DataTable dt = GetData("ContractType");
            if (dt.Rows.Count > 0)
            {

                dropConType.DataSource = dt;
                dropConType.DataTextField = "C_DETAILNAME";
                dropConType.DataValueField = "C_ID";
                dropConType.DataBind();
                dropConType.Items.Insert(0, new ListItem("", ""));
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
        private void GetShipVia()
        {
            DataTable dt = GetData("ShipVia");
            if (dt.Rows.Count > 0)
            {

                dropFaYun.DataSource = dt;
                dropFaYun.DataTextField = "C_DETAILNAME";
                dropFaYun.DataValueField = "C_ID";
                dropFaYun.DataBind();
                dropFaYun.Items.Insert(0, new ListItem("", ""));
            }
            else
            {
                dropFaYun.DataSource = null;
                dropFaYun.DataBind();
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
            if (mod != null)
            {
                str = mod.C_NAME;
            }

            return str;
        }

        /// <summary>
        /// 获取用户姓名
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        private string GetUserName(string id)
        {
            string name = string.Empty;
            Mod_TS_USER mod = ts_user.GetModel(id);
            if (mod != null)
            {
                name = mod.C_NAME;
            }
            return name;
        }

        /// <summary>
        /// 加载合同信息
        /// </summary>
        private void GetConInfo()
        {
            if (!string.IsNullOrEmpty(hidconno.Value))
            {
                Mod_TMO_CON modcon = tmo_con.GetModel(hidconno.Value);
                if (modcon != null)
                {
                    #region //是否合同变更
                    if (!string.IsNullOrEmpty(modcon.C_CON_NO_OLD))
                    {
                        hidycon.Value = modcon.C_CON_NO_OLD;//原合同号
                        hidycondlxwgt.Value = tmo_order.GetConSumWgt(modcon.C_CON_NO_OLD);//原合同待履行量

                        #region //变更合同量控制
                        DataTable dtfywgt = GetData("DM002");
                        if (dtfywgt.Rows.Count > 0)
                        {
                            decimal num = 0;
                            if (!string.IsNullOrEmpty(dtfywgt.Rows[0]["C_DETAILCODE"].ToString()))
                            {
                                num = Convert.ToDecimal(dtfywgt.Rows[0]["C_DETAILCODE"].ToString());
                                decimal fywgt = Convert.ToDecimal(hidycondlxwgt.Value);
                                decimal fd = fywgt * num;
                                hidsf.Value = Convert.ToString(fywgt + fd);//上幅数
                                hidxf.Value = Convert.ToString(fywgt - fd);//下幅数
                                hidmsg.Value = dtfywgt.Rows[0]["C_DETAILNAME"].ToString();
                            }
                        }
                        #endregion

                    }
                    #endregion

                    txtConNO.Value = modcon.C_CON_NO;
                    ltlcon_bgNo.Text = modcon.N_CHANGENUM.ToString();
                    Mod_TS_CUSTFILE modCust = ts_custfile.GetCustModel(modcon.C_CUSTOMERID);
                    ltlCustNo.Text = modCust?.C_NO ?? "";
                    ltlN_CON_STATUS.Text = modcon.N_STATUS.ToString();
                    hidstatus.Value = modcon.N_STATUS.ToString();

                    #region //根据合同状态显示按钮

                    switch (modcon.N_STATUS.ToString())
                    {
                        case "0"://待审
                            btnSave.Enabled = true;//保存
                            btnAdd.Disabled = false;//产品
                            btnCheck.Enabled = true;//送审
                            btnSX.Enabled = false;//生效
                            btndj.Enabled = true;//冻结
                            btnjd.Enabled = !btndj.Enabled;//解冻
                            btnzz.Enabled = true;//终止
                            btnqs.Enabled = false;//弃审
                            btncondel.Enabled = true;//合同删除
                            btncancel.Enabled = true;//撤回客户
                            btnAdd_TWC.Disabled = false;//头尾材
                            btnPrice.Enabled = true;



                            break;
                        case "1"://审核中
                            btnSave.Enabled = false;//保存
                            btnAdd.Disabled = true;//产品
                            btnCheck.Enabled = false;//送审
                            btnSX.Enabled = false;//生效
                            btndj.Enabled = false;//冻结
                            btnjd.Enabled = false;//解冻
                            btnzz.Enabled = false;//终止
                            btnqs.Enabled = false;//弃审
                            btncondel.Enabled = false;//合同删除
                            btncancel.Enabled = false;//撤回客户
                            btnAdd_TWC.Disabled = true;//头尾材
                            btnPrice.Enabled = false;

                            break;
                        case "4":// 审核通过
                            btnSave.Enabled = false;//保存
                            btnAdd.Disabled = true;//产品
                            btnCheck.Enabled = false;//送审

                            btnSX.Enabled = true;//生效
                            btndj.Enabled = true;//冻结
                            btnjd.Enabled = !btndj.Enabled;//解冻
                            btnzz.Enabled = true;//终止
                            btnqs.Enabled = true;//弃审
                            btncondel.Enabled = false;//合同删除
                            btncancel.Enabled = false;//撤回客户
                            btnAdd_TWC.Disabled = true;//头尾材
                            btnPrice.Enabled = false;


                            break;
                        case "2"://生效
                            btnSave.Enabled = false;//保存
                            btnAdd.Disabled = true;//产品
                            btnCheck.Enabled = false;//送审

                            btnSX.Enabled = false;//生效
                            btndj.Enabled = true;//冻结
                            btnjd.Enabled = !btndj.Enabled;//解冻
                            btnzz.Enabled = true;//终止
                            btnqs.Enabled = false;//弃审
                            btncondel.Enabled = false;//合同删除
                            btncancel.Enabled = false;//撤回客户
                            btnAdd_TWC.Disabled = true;//头尾材
                            btnPrice.Enabled = false;

                            break;

                        case "5":// 冻结
                            btnSave.Enabled = false;//保存
                            btnAdd.Disabled = true;//产品
                            btnCheck.Enabled = false;//送审

                            btnSX.Enabled = false;//生效
                            btndj.Enabled = false;//冻结
                            btnjd.Enabled = !btndj.Enabled;//解冻
                            btnzz.Enabled = false;//终止
                            btnqs.Enabled = false;//弃审
                            btncondel.Enabled = false;//合同删除
                            btncancel.Enabled = false;//撤回客户
                            btnAdd_TWC.Disabled = true;//头尾材
                            btnPrice.Enabled = false;

                            break;
                        case "6":// 终止
                            btnSave.Enabled = false;//保存
                            btnAdd.Disabled = true;//产品
                            btnCheck.Enabled = false;//送审

                            btnSX.Enabled = false;//生效
                            btndj.Enabled = false;//冻结
                            btnjd.Enabled = false;//解冻
                            btnzz.Enabled = false;//终止
                            btnqs.Enabled = false;//弃审
                            btncondel.Enabled = false;//合同删除
                            btncancel.Enabled = false;//撤回客户
                            btnAdd_TWC.Disabled = true;//头尾材
                            btnPrice.Enabled = false;

                            break;
                    }

                    #endregion


                    txtConName.Value = modcon.C_CON_NAME;
                    txtCustName.Value = modcon.C_CUSTNAME;

                    txtQianDanDT.Value = Convert.ToDateTime(modcon.D_CONSING_DT).ToString("yyy-MM-dd");
                    txtPlanStartDT.Value = Convert.ToDateTime(modcon.D_CONEFFE_DT).ToString("yyy-MM-dd");
                    txtPlanEndDT.Value = Convert.ToDateTime(modcon.D_CONINVALID_DT).ToString("yyy-MM-dd");


                    dropFaYun.SelectedIndex = dropFaYun.Items.IndexOf(dropFaYun.Items.FindByValue(modcon.C_TRANSMODEID));//发运方式
                    dropBiZhong.SelectedIndex = dropBiZhong.Items.IndexOf(dropBiZhong.Items.FindByValue(modcon.C_CURRENCYTYPEID));//货币类型
                    dropYeWuType.SelectedIndex = dropYeWuType.Items.IndexOf(dropYeWuType.Items.FindByValue(modcon.C_BIZTYPE));//业务类型
                    dropConType.SelectedIndex = dropConType.Items.IndexOf(dropConType.Items.FindByValue(modcon.C_CONTYPEID));//合同类型
                    dropSale.SelectedIndex = dropSale.Items.IndexOf(dropSale.Items.FindByValue(modcon.C_SALECORPID));//销售组织

                    dropClass.SelectedIndex = dropClass.Items.IndexOf(dropClass.Items.FindByValue(modcon.N_FLAG));

                    #region//收货地址
                    DataTable dtaddr = ts_custaddr.GetAddr("", "", modcon.C_CUSTOMERID, "", "").Tables[0];
                    if (dtaddr.Rows.Count > 0)
                    {
                        dropAddr.DataSource = dtaddr;
                        dropAddr.DataTextField = "C_CGAREA";
                        dropAddr.DataValueField = "C_CGAREA";
                        dropAddr.DataBind();
                        dropAddr.SelectedIndex = dropAddr.Items.IndexOf(dropAddr.Items.FindByText(modcon.C_ADDRESS));
                    }
                    #endregion

                    #region //部门
                    Mod_TS_DEPT modDept = ts_dept.GetModel(modcon.C_DEPTID);
                    if (modDept != null)
                    {
                        txtDept.Value = modDept.C_NAME;

                        hidC_DEPT_ID.Value = modcon.C_DEPTID;
                    }

                    #endregion

                    #region //业务员
                    txtSaleUser.Value = ts_user.GetSaleName(modcon.C_EMPLOYEEID);
                    hidC_SALESMAN.Value = modcon.C_EMPLOYEEID;
                    #endregion

                    txtShuoHuoCompany.Value = GetCust(modcon.C_CRECEIPTCUSTOMERID);
                    hidC_CGID.Value = modcon.C_CRECEIPTCUSTOMERID ?? "";
                    txtKaiPiaoCompany.Value = GetCust(modcon.C_CRECEIPTCORPID);
                    hidC_OTCID.Value = modcon.C_CRECEIPTCORPID ?? "";
                    txtC_STATION.Value = modcon.C_STATION;

                    txtState.Value = StringFormat.GetOrderState(modcon.N_STATUS);
                    txtDESC.Value = modcon.C_REAMRK;
                    txtZhiDanRen.Value = GetUserName(modcon.C_COPERATORID);
                    txtZhiDanTime.Value = modcon.D_DMAKEDATE.ToString();

                    #region //最后修改人/最后修改时间 

                    txtLastEditUser.Value = GetUserName(modcon.C_EDITEMPLOYEEID);
                    txtLastEditTime.Value = modcon.D_EDITDATE.ToString();

                    #endregion

                    #region//审批流程

                    txtC_APPROVEID.Value = GetUserName(modcon.C_APPROVEID);
                    txtD_APPROVEDATE.Value = modcon.D_APPROVEDATE.ToString();

                    if (!string.IsNullOrEmpty(modcon.C_FLOWID))
                    {
                        string url = "FlowStep_View.aspx?taskID=" + hidconno.Value + "&flowID=" + modcon.C_FLOWID;

                        Mod_TMB_FLOWINFO modFlow = tmb_flowinfo.GetModel(modcon.C_FLOWID);
                        ltlC_APPROVER_FLOW.Text = "<a href=\"javascript: void(0); \" class='flow' onclick=\"_iframe('" + url + "','500','400','审批记录');\">" + modFlow?.C_NAME + "&nbsp;<span class=\"glyphicon glyphicon-search\"></span></a>";
                    }
                    #endregion

                    GetOrderList();
                }
            }
        }

        /// <summary>
        /// 加载合同订单列表
        /// </summary>
        private void GetOrderList()
        {
            if (!string.IsNullOrEmpty(hidconno.Value))
            {
                DataTable dt = tmo_order.GetConOrderList(hidconno.Value, "", "", "", "", "").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    rptList.DataSource = dt;
                    rptList.DataBind();

                    txtWGT_SUM.Value = dt.Compute("sum(N_WGT)", "true").ToString();
                    txtN_ORIGINALCURMNY.Value = dt.Compute("sum(N_ORIGINALCURMNY)", "true").ToString();
                    txtN_ORIGINALCURSUMMNY.Value = dt.Compute("sum(N_ORIGINALCURSUMMNY)", "true").ToString();
                    txtN_ORIGINALCURTAXMNY.Value = dt.Compute("sum(N_ORIGINALCURTAXMNY)", "true").ToString();
                }
                else
                {
                    rptList.DataSource = null;
                    rptList.DataBind();
                }
            }
        }


        /// <summary>
        /// 保存合同
        /// </summary>
        /// <param name="state">状态</param>
        /// <returns></returns>
        private bool SaveCon(int state)
        {
            List<Mod_TMO_ORDER> orderList = new List<Mod_TMO_ORDER>();

            #region //修改合同基本信息

            Mod_TMO_CON modCon = tmo_con.GetModel(hidconno.Value);
            if (hidconno.Value != txtConNO.Value)
            {
                modCon.C_CON_NEW = txtConNO.Value;//合同号
            }
            modCon.N_STATUS = state;//合同状态
            modCon.C_CON_NAME = txtConName.Value;//合同名称
            modCon.C_CONTYPEID = dropConType.SelectedValue;//合同类型
            modCon.C_CURRENCYTYPEID = dropBiZhong.SelectedValue;//货币类型
            modCon.D_CONSING_DT = Convert.ToDateTime(txtQianDanDT.Value);//签署日期
            modCon.D_CONEFFE_DT = Convert.ToDateTime(txtPlanStartDT.Value);//生效日期
            modCon.D_CONINVALID_DT = Convert.ToDateTime(txtPlanEndDT.Value);//失效日期

            modCon.C_TRANSMODEID = dropFaYun.SelectedItem.Value;//发运方式
            modCon.C_SALECORPID = dropSale.SelectedItem.Value;//销售组织-
            modCon.C_AREA = txtDept.Value;//合同区域
            modCon.C_REAMRK = txtDESC.Value;//备注
            modCon.C_STATION = txtC_STATION.Value;//站点
            modCon.C_BIZTYPE = dropYeWuType.SelectedItem.Value;//业务类型-
            modCon.C_DEPTID = hidC_DEPT_ID.Value;//业务部门-
            modCon.C_EMPLOYEEID = hidC_SALESMAN.Value;//业务员
            modCon.C_EDITEMPLOYEEID = ltlC_EMP_ID.Text;//修改人
            modCon.D_EDITDATE = DateTime.Now;//修改时间
            modCon.C_ADDRESS = dropAddr.SelectedItem?.Text ?? "";//收货地址

            string C_PCLX = dropYeWuType.SelectedItem.Text == "1001NC10000000005EI8" ? "1" : "0";//1出口材，0普通材

            modCon.C_CRECEIPTCUSTOMERID = hidC_CGID.Value;//收货单位
            modCon.C_CRECEIPTCORPID = hidC_OTCID.Value;//开票单位
            modCon.N_FLAG = dropClass.SelectedValue;

            #endregion

            #region //修改合同明细

            for (int i = 0; i < rptList.Items.Count; i++)
            {

                DropDownList dropZL = (DropDownList)rptList.Items[i].FindControl("dropZL");
                DropDownList dropzxzt = (DropDownList)rptList.Items[i].FindControl("dropzxzt");

                DropDownList dropsfjk = (DropDownList)rptList.Items[i].FindControl("dropsfjk");

                TextBox txtWgt = (TextBox)rptList.Items[i].FindControl("txtWgt");//数量
                TextBox txtN_ORIGINALCURTAXPRICE = (TextBox)rptList.Items[i].FindControl("txtN_ORIGINALCURTAXPRICE");//原币含税单价

                TextBox txtPack_Code = (TextBox)rptList.Items[i].FindControl("txtPack_Code");
                TextBox txtRemark = (TextBox)rptList.Items[i].FindControl("txtRemark");//行备注

                Literal ltlC_NO = (Literal)rptList.Items[i].FindControl("ltlC_NO");

                HtmlInputText txtD_DELIVERY_DT = (HtmlInputText)rptList.Items[i].FindControl("txtD_DELIVERY_DT");//订单交货日期
                HtmlInputText txtN_TAXRATE = (HtmlInputText)rptList.Items[i].FindControl("txtN_TAXRATE");//税率
                HtmlInputText txtStd_Code = (HtmlInputText)rptList.Items[i].FindControl("txtStd_Code");//执行标准
                HtmlInputText txtC_FREE1 = (HtmlInputText)rptList.Items[i].FindControl("txtC_FREE1");//自由项1
                HtmlInputText txtC_FREE2 = (HtmlInputText)rptList.Items[i].FindControl("txtC_FREE2");//自由项2



                Mod_TMO_ORDER modOrder = tmo_order.GetModel(ltlC_NO.Text);

                if (hidconno.Value != txtConNO.Value)
                {
                    modOrder.C_CON_NO = modCon.C_CON_NEW;//新合同号
                }
                modOrder.C_CON_NAME = txtConName.Value;//合同名称
                modOrder.C_AREA = txtDept.Value;//区域
                modOrder.C_CUST_SQ = txtDESC.Value;
                modOrder.C_PCLX = C_PCLX;//1出口材，0普通材
                modOrder.N_EXEC_STATUS = Convert.ToDecimal(dropzxzt.SelectedItem.Value);//执行状态
                                                                                        //modOrder.D_NEED_DT = modCon.D_NEED_DT;//需求日期
                modOrder.D_DELIVERY_DT = Convert.ToDateTime(txtD_DELIVERY_DT.Value);//计划订单交货日期
                modOrder.C_YWY = txtSaleUser.Value;//业务员姓名
                modOrder.C_CURRENCYTYPEID = dropBiZhong.SelectedValue;//货币

                modOrder.C_STD_CODE = txtStd_Code.Value;//执行标准
                modOrder.C_FREE1 = txtC_FREE1.Value;//自由项1
                modOrder.C_FREE2 = txtC_FREE2.Value;//自由项2

                modOrder.C_PACK = txtPack_Code.Text;//包装要求
                modOrder.C_LEV = "";//等级
                modOrder.C_ORDER_LEV = "";//级别
                modOrder.C_VDEF1 = dropZL.SelectedValue;//质量等级
                modOrder.C_STL_GRD_CLASS = "";//钢种大类
                modOrder.C_SFJK = dropsfjk.SelectedItem.Text;//监控钢种
                modOrder.C_RECEIPTAREAID = modCon.C_CRECEIPTAREAID;//收货地区
                modOrder.C_RECEIVEADDRESS = modCon.C_ADDRESS;// 收货地址
                modOrder.C_RECEIPTCORPID = modCon.C_CRECEIPTCUSTOMERID;//收货单位
                modOrder.C_REMARK = txtRemark.Text;//行备注


                decimal N_WGT = 0;
                if (!string.IsNullOrEmpty(txtWgt.Text))
                {
                    N_WGT = Convert.ToDecimal(txtWgt.Text);
                }
                modOrder.N_WGT = N_WGT;//数量
                modOrder.N_FNUM = modOrder.N_HSL == 0 ? 1 : N_WGT / modOrder.N_HSL;//辅数量


                #region //获取钢种单价-折扣-税率                           
                if (!string.IsNullOrEmpty(txtN_ORIGINALCURTAXPRICE.Text))
                {
                    decimal shuolv = Convert.ToDecimal(txtN_TAXRATE.Value == "" ? "0" : txtN_TAXRATE.Value);//税率
                    if (Convert.ToDecimal(shuolv) >= 1)
                    {
                        shuolv = shuolv / 100;
                    }

                    decimal N_TAXRATE = shuolv + 1;//税率
                    decimal N_ORIGINALCURPRICE = Convert.ToDecimal(txtN_ORIGINALCURTAXPRICE.Text) / N_TAXRATE;//原币无税单价
                    decimal N_ORIGINALCURTAXPRICE = Convert.ToDecimal(txtN_ORIGINALCURTAXPRICE.Text);//原币含税单价

                    decimal N_ORIGINALCURMNY = decimal.Round(N_WGT * N_ORIGINALCURPRICE, 2);//原币无税金额
                    decimal N_ORIGINALCURSUMMNY = N_WGT * N_ORIGINALCURTAXPRICE;//原币价税合计
                    decimal N_ORIGINALCURTAXMNY = decimal.Round(N_ORIGINALCURSUMMNY - N_ORIGINALCURMNY, 2);//原币税额

                    modOrder.N_TAXRATE = shuolv;//税率
                    modOrder.N_ORIGINALCURPRICE = N_ORIGINALCURPRICE;//原币无税单价
                    modOrder.N_ORIGINALCURTAXPRICE = N_ORIGINALCURTAXPRICE;//原币含税单价

                    modOrder.N_ORIGINALCURTAXMNY = N_ORIGINALCURTAXMNY;//原币税额
                    modOrder.N_ORIGINALCURMNY = N_ORIGINALCURMNY;//原币无税金额
                    modOrder.N_ORIGINALCURSUMMNY = N_ORIGINALCURSUMMNY;//原币价税合计
                }
                #endregion

                orderList.Add(modOrder);


            }
            #endregion

            return tmo_con.UpdateConOrder(modCon, orderList);
        }

        /// <summary>
        /// 获取等级
        /// </summary>
        /// <param name="code">编码</param>
        /// <returns></returns>
        private DataTable GetLev(string code)
        {

            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = code;
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            return dt;
        }


        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            LinkButton lbtDel = (LinkButton)e.Item.FindControl("lbtDel");

            DropDownList dropZL = (DropDownList)e.Item.FindControl("dropZL");
            DropDownList dropzxzt = (DropDownList)e.Item.FindControl("dropzxzt");

            DropDownList dropsfjk = (DropDownList)e.Item.FindControl("dropsfjk");

            Literal ltlC_VDEF1 = (Literal)e.Item.FindControl("ltlC_VDEF1");
            Literal ltlzxzt = (Literal)e.Item.FindControl("ltlzxzt");
            Literal ltlsfpj = (Literal)e.Item.FindControl("ltlsfpj");


            Literal ltlN_TYPE = (Literal)e.Item.FindControl("ltlN_TYPE");

            Literal ltlsfjk = (Literal)e.Item.FindControl("ltlsfjk");//监控钢种
            TextBox txtWgt = (TextBox)e.Item.FindControl("txtWgt");
            TextBox txtN_ORIGINALCURTAXPRICE = (TextBox)e.Item.FindControl("txtN_ORIGINALCURTAXPRICE");//无税单价
            TextBox txtPack_Code = (TextBox)e.Item.FindControl("txtPack_Code");

            dropzxzt.SelectedIndex = dropzxzt.Items.IndexOf(dropzxzt.Items.FindByValue(ltlzxzt.Text));

            #region //监控钢种/钢种大类

            if (!string.IsNullOrEmpty(ltlsfjk.Text))
            {
                dropsfjk.SelectedIndex = dropsfjk.Items.IndexOf(dropsfjk.Items.FindByText(ltlsfjk.Text));
            }
            #endregion

            #region //质量等级
            DataTable dtzl = tqb_checkstate.GetCheckState("").Tables[0];
            if (dtzl.Rows.Count > 0)
            {
                dropZL.DataSource = dtzl;
                dropZL.DataTextField = "C_CHECKSTATE_NAME";
                dropZL.DataValueField = "C_ID";
                dropZL.DataBind();
                dropZL.Items.Add(new ListItem("", ""));
                dropZL.SelectedIndex = dropZL.Items.IndexOf(dropZL.Items.FindByValue(ltlC_VDEF1.Text));
            }
            #endregion

            #region //判断当前状态

            if (ltlN_CON_STATUS.Text == "0" || ltlN_CON_STATUS.Text == "3")
            {
                lbtDel.Visible = true;
                txtWgt.Enabled = true;
                txtN_ORIGINALCURTAXPRICE.Enabled = true;
            }
            else
            {
                lbtDel.Visible = false;
                txtWgt.Enabled = false;
                txtN_ORIGINALCURTAXPRICE.Enabled = false;
            }
            #endregion

        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveCon(0))
                {
                    string[] arr = { "轴承钢销售区域", "不锈钢公司", "副产品销售部" };
                    if (!arr.Contains(txtDept.Value))
                    {
                        //执行订单毛利/成本
                        tmb_stlgrd_price_wgt.UpdateOrderMAOLI(txtConNO.Value);
                    }

                    hidconno.Value = txtConNO.Value;
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('保存成功');", true);
                    GetOrderList();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('保存失败');", true);
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }


        //送审
        protected void btnCheck_Click(object sender, EventArgs e)
        {

            bool result = true;
            int row = 0;
            string[] arr = { "轴承钢销售区域", "不锈钢公司", "副产品销售部" };
            //if (!arr.Contains(txtDept.Value))
            //{
            //    for (int i = 0; i < rptList.Items.Count; i++)
            //    {
            //        HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
            //        Literal ltlmatcode = (Literal)rptList.Items[i].FindControl("ltlmatcode");
            //        result = tmb_stlgrd_price_wgt.CheckMAOLI(cbxselect.Value, ltlmatcode.Text, txtPlanStartDT.Value);
            //        row += 1;
            //        if (result == false)
            //        {
            //            break;
            //        }
            //    }
            //}

            if (result)
            {
                if (SaveCon(0))
                {
                    Response.Redirect("Con_Check.aspx?ID=" + hidconno.Value + "");
                }
            }
            else
            {
                string msg = "第" + row + "行钢种毛利低于系统配置毛利无法通过！";
                WebMsg.MessageBox(msg);
            }
        }

        #region//合同变更
        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (tmo_con.AlterationCon(6, txtConNO.Value, ltlC_EMP_ID.Text))//变更合同状态
        //        {

        //            #region //新增变更合同
        //            List<Mod_TMO_ORDER> orderList = new List<Mod_TMO_ORDER>();

        //            #region //添加合同基本信息

        //            int NO = Convert.ToInt32(ltlcon_bgNo.Text) + 1;
        //            string conNo = txtConNO.Value + "-" + NO.ToString();//变更合同号
        //            Mod_TMO_CON modCon = tmo_con.GetModel(txtConNO.Value);
        //            modCon.C_CON_NO = conNo;
        //            modCon.C_CON_NAME = modCon.C_CON_NAME + "合同变更";
        //            modCon.N_STATUS = 0;//待审
        //            modCon.D_CONSING_DT = DateTime.Now;//合同签署日期
        //            modCon.D_CONEFFE_DT = Convert.ToDateTime(DateTime.Now);//计划生效日期
        //            modCon.D_CONINVALID_DT = Convert.ToDateTime(DateTime.Now).AddDays(60);//计划失效日期

        //            #endregion

        //            #region//添加合同明细
        //            Bll_RandomNumber randomnumber = new Bll_RandomNumber();//流水号
        //            DataTable dtOrder = tmo_order.GetConOrderList(txtConNO.Value, "", "", "", "", "").Tables[0];

        //            for (int i = 0; i < dtOrder.Rows.Count; i++)
        //            {

        //                Mod_TMO_ORDER modOrder = tmo_order.GetModel(dtOrder.Rows[i]["C_ID"].ToString());//订单表
        //                string order_no = randomnumber.CreateOrderNo(conNo);//订单号
        //                modOrder.C_ORDER_NO = order_no;
        //                modOrder.C_CON_NO = conNo;//合同号
        //                modOrder.C_CON_NAME = modCon.C_CON_NAME;//合同名称
        //                modOrder.N_STATUS = 0;//待审
        //                modOrder.C_SFPJ = "N"; //是否评价
        //                modOrder.C_ORDER_NO_OLD = dtOrder.Rows[i]["C_ORDER_NO"].ToString();//原合同号
        //                orderList.Add(modOrder);

        //            }
        //            #endregion

        //            #endregion

        //            if (tmo_con.InsertConOrder(modCon, orderList))
        //            {
        //                if (tmo_con.UpdateEditEmp(conNo, txtConNO.Value, ltlC_EMP_ID.Text))//修改变更合同修改人/制单记录
        //                {
        //                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "close();", true);
        //                    string url = "ConEdit_BG.aspx?ID=" + conNo + "&YID=" + txtConNO.Value;
        //                    Response.Redirect(url);
        //                    //WebMsg.MessageBox("原始合同已帮您终止", url);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('变更失败,合同部分订单已进行生产计划,或正在生产中,请先终止订单生产计划');", true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WebMsg.MessageBox(ex.Message);
        //    }

        //}
        #endregion



        //删除
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string orderID = e.CommandArgument.ToString();
                if (tmo_con.DelConOrder(orderID))
                {
                    GetOrderList();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('删除失败');", true);

                }
            }
        }

        //加载产品
        protected void imgbtnJz_Click(object sender, ImageClickEventArgs e)
        {
            GetOrderList();
        }

        //生效
        protected void btnSX_Click(object sender, EventArgs e)
        {
            try
            {
                if (tmo_con.UpdateStatus(2, hidconno.Value, ltlC_EMP_ID.Text))
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('生效成功');", true);
                    GetConInfo();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('生效失败');", true);
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }
        //冻结
        protected void btndj_Click(object sender, EventArgs e)
        {
            if (tmo_con.UpdateFreezeStatus(5, hidconno.Value, ltlC_EMP_ID.Text))
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('冻结成功');", true);
                GetConInfo();
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('冻结失败", true);
            }
        }
        //解冻
        protected void btnjd_Click(object sender, EventArgs e)
        {
            if (tmo_con.UpdateStatus(0, hidconno.Value, ltlC_EMP_ID.Text))
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('解冻成功');", true);
                GetConInfo();
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('解冻失败');", true);
            }
        }

        //终止
        protected void btnzz_Click(object sender, EventArgs e)
        {
            if (tmo_con.UpdateStatus(6, hidconno.Value, ltlC_EMP_ID.Text))
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('终止成功');", true);
                GetConInfo();
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('终止失败,合同部分订单已进行生产计划,或正在生产中,请先终止订单生产计划');", true);
            }
        }

        //合同弃审
        protected void btnqs_Click(object sender, EventArgs e)
        {
            try
            {
                if (tmo_con.UpdateStatus(0, hidconno.Value, ltlC_EMP_ID.Text))
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('弃审成功');", true);
                    GetConInfo();
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('" + ex.Message + "');", true);
            }
        }

        //合同删除
        protected void btncondel_Click(object sender, EventArgs e)
        {
            try
            {
                if (tmo_con.Delete(hidconno.Value))
                {
                    //操作日志
                    tmo_con.InsertConOrderLog(hidconno.Value, ltlC_EMP_ID.Text, ltlC_EMP_NAME.Text);
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('合同删除成功');", true);
                    Response.Redirect("ConList.aspx");
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('" + ex.Message + "');", true);
            }
        }

        //撤回客户
        protected void btncancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (tmo_con.UpdateStatus(-1, hidconno.Value, ltlC_EMP_ID.Text))
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('撤回客户成功');", true);
                    GetConInfo();
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('" + ex.Message + "');", true);
            }
        }


        //利润评价录入
        protected void btnPrice_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new List<Mod_TMO_LOWMAOLI_ORDER>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                    if (cbxselect.Checked)
                    {
                        var modOrder = tmo_order.GetModel(cbxselect.Value);

                        var mod = new Mod_TMO_LOWMAOLI_ORDER()
                        {
                            C_CUSTNAME = modOrder.C_CUST_NAME,
                            C_CONNO = modOrder.C_CON_NO,
                            C_ORDERNO = modOrder.C_ORDER_NO,
                            C_STLGRD = modOrder.C_STL_GRD,
                            C_SPEC = modOrder.C_SPEC,
                            C_MAOLI = Convert.ToString(modOrder.N_PROFIT),
                            N_WGT = Convert.ToDecimal(modOrder.N_WGT),
                            C_EMPID = ltlC_EMP_ID.Text,
                            C_EMPNAME = ltlC_EMP_NAME.Text,
                            D_CONSING_DT = Convert.ToDateTime(txtQianDanDT.Value),
                            D_CONEFFE_DT = Convert.ToDateTime(txtPlanStartDT.Value),
                            C_SALEORG = dropSale.SelectedItem.Text,
                            N_PRICE = Convert.ToDecimal(modOrder.N_ORIGINALCURTAXPRICE),
                            N_COSTPRICE = Convert.ToDecimal(modOrder.N_COST)

                        };
                        list.Add(mod);
                    }
                }

                if (tmb_stlgrd_price_wgt.InsertMAOLI(list))
                {
                    WebMsg.MessageBox("提交成功");
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}