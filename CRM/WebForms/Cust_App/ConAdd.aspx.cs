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
using NF.EF.Model;

namespace CRM.Cust_App
{
    public partial class ConAdd : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TS_DEPT ts_dept = new Bll_TS_DEPT();
        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_TB_STD_CONFIG tb_std_config = new Bll_TB_STD_CONFIG();
        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();
        private Bll_TQB_PACK tqb_pack = new Bll_TQB_PACK();

        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private Bll_TS_CUSTADDR ts_custaddr = new Bll_TS_CUSTADDR();
        private Bll_TQB_CHECKSTATE tqb_checkstate = new Bll_TQB_CHECKSTATE();
        private Bll_TMB_TAXITEMS tmb_taxitems = new Bll_TMB_TAXITEMS();

        private Bll_RandomNumber randomnumber = new Bll_RandomNumber();

        private static DataTable dtOrder = new DataTable();

        IComService buttonService = DIFactory.GetContainer().Resolve<IComService>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Session["kh"] = null;

                GetFun();//加载按钮权限

                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    SetData();//初始化数据

                    try
                    {
                        if (!string.IsNullOrEmpty(vUser.CustId))
                        {

                            ltlC_EMP_ID.Text = vUser.Id;
                            ltlC_EMP_NAME.Text = vUser.Name;

                            DateTime dt = DateTime.Now;
                            //初始化日期
                            txtDate.Value = Convert.ToDateTime(dt).ToString("yyy-MM-dd");//签署日期
                            txtStart.Value = Convert.ToDateTime(dt).ToString("yyy-MM-dd");
                            txtEnd.Value = Convert.ToDateTime(dt.AddDays(60)).ToString("yyy-MM-dd");


                            #region //加载基础数据
                            BindCurrency();
                            BindContractType();
                            BindShipVia();
                            BindConPolicyArea();
                            #endregion

                            //加载客户基本信息
                            GetCustInfo(vUser.CustId);
                        }
                        else
                        {
                            WebMsg.MessageBox("当前用户暂无公司信息关联，无法正常使用新增合同", "MyCon.aspx");
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
        }

        /// <summary>
        /// 按钮权限
        /// </summary>
        private void GetFun()
        {
            var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (user != null)
            {
                buttonService.RefreshButton(Request.RawUrl, user, Session);
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



        #region //获取客户基本信息
        /// <summary>
        /// 获取客户基本信息
        /// </summary>
        /// <param name="CustID">客户ID</param>
        private void GetCustInfo(string CustID)
        {
            Mod_TS_CUSTFILE mod = ts_custfile.GetModel(CustID);
            if (mod != null)
            {
                txtConName.Text = DateTime.Now.ToString("MM.dd") + mod.C_SHORNAME;

                hidC_CGID.Value = mod.C_NC_M_ID;//收货单位
                hidC_OTCID.Value = mod.C_NC_M_ID;//开票单位
                txtCust.Value = mod.C_NAME;
                txtC_CGC.Value = mod.C_NAME;
                txtC_OTC.Value = mod.C_NAME;
                txtCustName.Text = mod.C_NAME;//客户名称
                hidCustID.Value = mod.C_NC_M_ID;//客户NC主键
                hidCustNO.Value = mod.C_NO;//客户编码
                ltlCustLEV.Text = mod.N_LEVEL.ToString();
                ltlCustType.Text = mod.N_TYPE.ToString() == "1" ? "经销商" : "直销商";

                //收货地址
                DataTable dtaddr = ts_custaddr.GetAddr(CustID, "", "", "", "1").Tables[0];
                if (dtaddr.Rows.Count > 0)
                {
                    txtAddr.Value = dtaddr.Rows[0]["C_CGAREA"].ToString();
                }

            }
        }

        #endregion

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

        /// <summary>
        /// 合同政策区域
        /// </summary>
        private void BindConPolicyArea()
        {
            DataTable dt = GetData("ConPolicyArea");
            if (dt.Rows.Count > 0)
            {

                dropConPolicyArea.DataSource = dt;
                dropConPolicyArea.DataTextField = "C_DETAILNAME";
                dropConPolicyArea.DataValueField = "C_DETAILCODE";
                dropConPolicyArea.DataBind();
                dropConPolicyArea.Items.Insert(0, new ListItem("请选择", ""));
            }
            else
            {
                dropConPolicyArea.DataSource = null;
                dropConPolicyArea.DataBind();
                dropConPolicyArea.Items.Insert(0, new ListItem("请选择", ""));
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

        #endregion


        private static string conNo = string.Empty;

        /// <summary>
        /// 新增合同
        /// </summary>
        /// <param name="N_STATUS">合同状态</param>
        /// <returns></returns>
        private bool Add(int N_STATUS)
        {

            bool result = true;

            List<Mod_TMO_ORDER> orderList = new List<Mod_TMO_ORDER>();

            #region //添加合同基本信息

            Mod_TMO_CON modCon = new Mod_TMO_CON();

            Mod_TS_DEPT modDept = ts_dept.GetModel(hiddeptid.Value);


            string areaCode = dropConPolicyArea.SelectedItem.Value == "" ? "01" : dropConPolicyArea.SelectedItem.Value;

            conNo = randomnumber.CreateConNo(areaCode);//合同号
            modCon.C_CON_XH = conNo;
            modCon.C_CON_NO = conNo;//合同号
            modCon.C_CON_NAME = txtConName.Text;//合同名称
            modCon.C_CONTYPEID = dropConType.SelectedItem.Value;//合同类型
            modCon.C_CUSTOMERID = hidCustID.Value;//客户ID
            modCon.C_CUSTNAME = txtCustName.Text;//客户名称
            modCon.C_CUST_NO = hidCustNO.Value;//客户客户编码
            modCon.C_EMPLOYEEID = hidsaleempid.Value;//业务员ID
            modCon.C_DEPTID = hiddeptid.Value;//业务部门
            if (!string.IsNullOrEmpty(hiddeptid.Value))
            {
                Mod_TS_DEPT moddept = ts_dept.GetModel(hiddeptid.Value);
                modCon.C_AREA = moddept.C_NAME;//部门
            }
            modCon.C_CURRENCYTYPEID = dropCurrType.SelectedValue;//货币
            modCon.D_CONSING_DT = Convert.ToDateTime(txtDate.Value);//签署日期
            modCon.D_CONEFFE_DT = Convert.ToDateTime(txtStart.Value);//计划生效日期
            modCon.D_CONINVALID_DT = Convert.ToDateTime(txtEnd.Value);//计划失效日期
            modCon.C_TRANSMODEID = dropShipVia.SelectedValue;//发运方式
            modCon.N_STATUS = N_STATUS;
            modCon.C_EMP_ID = ltlC_EMP_ID.Text;
            modCon.C_EMP_NAME = ltlC_EMP_NAME.Text;
            modCon.N_CUST_LEV = Convert.ToDecimal(ltlCustLEV.Text);//客户等级

            if (!string.IsNullOrEmpty(hidC_CGID.Value))
            {
                Mod_TS_CUSTFILE modCust = ts_custfile.GetCustModel(hidC_CGID.Value);
                modCon.C_CRECEIPTCUSTOMERID = hidC_CGID.Value;//收货单位
                modCon.C_ADDRESS = txtAddr.Value;//收货地址
                modCon.C_CRECEIPTAREAID = modCust.C_AREATYPE;//收货地区
            }
            modCon.C_CRECEIPTCORPID = hidC_OTCID.Value;//开票单位

            modCon.C_STATION = txtC_STATION.Value;//站点
            modCon.C_REAMRK = txtReamrk.Value;
            modCon.N_CHANGENUM = 0;//合同变更次数


            #endregion

            #region//添加合同明细
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                Literal ltlC_ID = (Literal)rptList.Items[i].FindControl("ltlC_ID");//物料ID
                Literal ltlC_TECH_PROT = (Literal)rptList.Items[i].FindControl("ltlC_TECH_PROT");//客户协议号
                Literal ltlC_STD_CODE = (Literal)rptList.Items[i].FindControl("ltlC_STD_CODE");//执行标准
                Literal ltlzyx1 = (Literal)rptList.Items[i].FindControl("ltlzyx1");//自由项1
                Literal ltlzyx2 = (Literal)rptList.Items[i].FindControl("ltlzyx2");//自由项2
                Literal ltlC_IS_BXG = (Literal)rptList.Items[i].FindControl("ltlC_IS_BXG");//执行标准
                TextBox txtPack_Code = (TextBox)rptList.Items[i].FindControl("txtPack_Code");//包装要求
                TextBox txtC_PRO_USE = (TextBox)rptList.Items[i].FindControl("txtC_PRO_USE");//产品用途
                TextBox txtC_CUST_SQ = (TextBox)rptList.Items[i].FindControl("txtC_CUST_SQ");//特殊要求
                DropDownList dropZL = (DropDownList)rptList.Items[i].FindControl("dropZL");//质量
                HtmlInputText txtWgt = (HtmlInputText)rptList.Items[i].FindControl("txtWgt");//数量
                HtmlInputText txtPrice = (HtmlInputText)rptList.Items[i].FindControl("txtPrice");//含税单价

                if (dropConPolicyArea.SelectedItem.Text != "钢坯")
                {
                    if (string.IsNullOrEmpty(txtPack_Code.Text) && tqb_pack.Exists(txtPack_Code.Text))
                    {
                        result = false;
                        break;
                    }
                }

                #region //合同明细

                Mod_TB_MATRL_MAIN modMat = tb_matrl_main.GetModel(ltlC_ID.Text);

                Mod_TMO_ORDER modOrder = new Mod_TMO_ORDER();//订单表

                string order_no = randomnumber.CreateOrderNo(conNo);//订单号
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

                modOrder.C_STL_GRD = modMat.C_MAT_TYPE == "841" ? modMat.C_MAT_NAME : modMat.C_MAT_TYPE == "851" ? modMat.C_MAT_NAME : modMat.C_STL_GRD;//钢种
                modOrder.C_FUNITID = modMat.C_FJLDW;//辅单位
                modOrder.C_UNITID = modMat.C_PK_MEASDOC;//主计量单位
                modOrder.D_DELIVERY_DT = modCon.D_CONINVALID_DT;//计划交货日期
                modOrder.D_DT = modCon.D_CONSING_DT;//订单日期//签单日期
                modOrder.C_VDEF1 = dropZL.SelectedItem.Value;//质量主键ID
                modOrder.C_SFPJ = "N";
                modOrder.C_TECH_PROT = ltlC_TECH_PROT.Text;//客户协议号
                modOrder.C_FREE1 = ltlzyx1.Text;//自由项1
                modOrder.C_FREE2 = ltlzyx2.Text;//自由项2
                modOrder.C_STD_CODE = ltlC_STD_CODE.Text;//执行标准
                modOrder.C_BY4 = ltlC_IS_BXG.Text;//是否不锈钢
                modOrder.N_TYPE = Convert.ToDecimal(modMat.C_MAT_TYPE);//订单类型
                modOrder.C_PACK = txtPack_Code.Text.Trim();//包装要求

                Mod_TMB_TAXITEMS modTaxi = tmb_taxitems.GetModel(modMat.C_PK_TAXITEMS);

                decimal shuolv = Convert.ToDecimal(modTaxi.N_TAXRATIO) >= 1 ? Convert.ToDecimal(modTaxi.N_TAXRATIO) / 100 : Convert.ToDecimal(modTaxi.N_TAXRATIO);//税率

                modOrder.N_TAXRATE = shuolv;//税率

                decimal N_WGT = 0;
                if (!string.IsNullOrEmpty(txtWgt.Value))
                {
                    N_WGT = Convert.ToDecimal(txtWgt.Value);

                }
                modOrder.N_WGT = N_WGT;//数量
                modOrder.N_HSL = modMat.N_HSL == null ? 0 : modMat.N_HSL;//换算率
                modOrder.N_FNUM = modMat.N_HSL == null ? 1 : N_WGT / modMat.N_HSL;//辅数量

                #region //获取钢种单价-税率                           
                if (!string.IsNullOrEmpty(txtPrice.Value))
                {


                    decimal N_TAXRATE = Convert.ToDecimal(modOrder.N_TAXRATE) + 1;//税率
                    decimal N_ORIGINALCURPRICE = Convert.ToDecimal(txtPrice.Value) / N_TAXRATE;//原币无税单价
                    decimal N_ORIGINALCURTAXPRICE = Convert.ToDecimal(txtPrice.Value);//原币含税单价

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
                modOrder.C_CUST_SQ = txtC_CUST_SQ.Text;//客户要求
                modOrder.C_PRO_USE = txtC_PRO_USE.Text;//产品用途
                modOrder.C_EMP_ID = modCon.C_EMP_ID;
                modOrder.C_EMP_NAME = modCon.C_EMP_NAME;
                modOrder.C_CUST_NO = hidCustNO.Value;
                modOrder.C_CUST_NAME = txtCustName.Text;
                modOrder.C_SALE_CHANNEL = ltlCustType.Text;
                modOrder.C_LEV = GetLev("STL_GRD_Lev");//钢种等级
                modOrder.C_ORDER_LEV = GetLev("Order_Lev");//订单等级
                modOrder.N_COST = 0;//成本
                modOrder.C_TRANSMODE = dropShipVia.SelectedItem.Text;//发运方式
                modOrder.C_TRANSMODEID = dropShipVia.SelectedItem.Value;//发运方式主键
                modOrder.C_YWY = txtSaleUser.Value;//业务员姓名
                modOrder.N_STATUS = N_STATUS;

                orderList.Add(modOrder);
                #endregion
            }
            #endregion

            return result == true ? tmo_con.InsertConOrder(modCon, orderList) : result;

        }


        //提交合同
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrEmpty(dropConPolicyArea.SelectedItem.Value))
                {

                    if (Add(0))
                    {
                        rptList.DataSource = null;
                        rptList.DataBind();
                        SetData();
                        WebMsg.MessageBox("提交成功", "ConEdit.aspx?ID=" + conNo + "");
                    }
                    else
                    {
                        WebMsg.MessageBox("包装不能为空或与实际包装不符！");
                    }
                }
                else
                {
                    WebMsg.MessageBox("请选择合同政策区域！");
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

            BindOrderValue();//获取页面值

            if (e.CommandName == "del")
            {
                string guid = e.CommandArgument.ToString();

                DataRow[] dr = dtOrder.Select("INDEX='" + guid + "'");
                if (dr.Length > 0)
                {
                    int index = dtOrder.Rows.IndexOf(dr[0]);
                    dtOrder.Rows.RemoveAt(index);
                }
                if (dtOrder.Rows.Count > 0)
                {
                    rptList.DataSource = dtOrder;
                    rptList.DataBind();
                }
                else
                {
                    rptList.DataSource = null;
                    rptList.DataBind();
                }
            }

        }

        /// <summary>
        /// 获取当前值
        /// </summary>
        private void BindOrderValue()
        {
            SetData();//初始化TABLE

            if (rptList.Items.Count > 0)
            {

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    Literal ltlC_MAT_CODE = (Literal)rptList.Items[i].FindControl("ltlC_MAT_CODE");//物料编码
                    Literal ltlC_MAT_NAME = (Literal)rptList.Items[i].FindControl("ltlC_MAT_NAME");//物料名称
                    Literal ltlC_STL_GRD = (Literal)rptList.Items[i].FindControl("ltlC_STL_GRD");//钢种
                    Literal ltlC_SPEC = (Literal)rptList.Items[i].FindControl("ltlC_SPEC");//规格
                    Literal ltlC_ID = (Literal)rptList.Items[i].FindControl("ltlC_ID");//物料ID
                    Literal ltlC_TECH_PROT = (Literal)rptList.Items[i].FindControl("ltlC_TECH_PROT");//客户协议
                    Literal ltlC_STD_CODE = (Literal)rptList.Items[i].FindControl("ltlC_STD_CODE");//执行标准
                    Literal ltlzyx1 = (Literal)rptList.Items[i].FindControl("ltlzyx1");//自由项1
                    Literal ltlzyx2 = (Literal)rptList.Items[i].FindControl("ltlzyx2");//自由项2
                    Literal ltlC_IS_BXG = (Literal)rptList.Items[i].FindControl("ltlC_IS_BXG");//是否不锈钢
                    TextBox txtPack_Code = (TextBox)rptList.Items[i].FindControl("txtPack_Code");//包装
                    HtmlInputText txtWgt = (HtmlInputText)rptList.Items[i].FindControl("txtWgt");//数量
                    HtmlInputText txtPrice = (HtmlInputText)rptList.Items[i].FindControl("txtPrice");//单价
                    Literal ltlindex = (Literal)rptList.Items[i].FindControl("ltlindex");//索引

                    dtOrder.Rows.Add(new object[] {
                        ltlC_ID.Text,
                        ltlC_MAT_CODE.Text,
                        ltlC_MAT_NAME.Text,
                        ltlC_STL_GRD.Text,
                        ltlC_SPEC.Text,
                        ltlC_TECH_PROT.Text,
                        ltlC_STD_CODE.Text,
                        ltlzyx1.Text,
                        ltlzyx2.Text,
                        ltlC_IS_BXG.Text,
                        txtPack_Code.Text,
                        txtWgt.Value,
                        txtPrice.Value,
                        ltlindex.Text });
                }
            }
        }

        //初始化
        private void SetData()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("C_ID", typeof(string));//物料主键
            dt.Columns.Add("C_MAT_CODE", typeof(string));//物料编码
            dt.Columns.Add("C_MAT_NAME", typeof(string));//物料名称
            dt.Columns.Add("C_STL_GRD", typeof(string));//钢种
            dt.Columns.Add("C_SPEC", typeof(string));//规格
            dt.Columns.Add("C_TECH_PROT", typeof(string));//客户协议
            dt.Columns.Add("C_STD_CODE", typeof(string));//执行标准
            dt.Columns.Add("ZYX1", typeof(string));//自由项1
            dt.Columns.Add("ZYX2", typeof(string));//自由项2
            dt.Columns.Add("C_BY4", typeof(string));//是否不锈钢
            dt.Columns.Add("C_PACK", typeof(string));//包装要求
            dt.Columns.Add("N_WGT", typeof(string));//数量
            dt.Columns.Add("PRICE", typeof(string));//含税单价
            dt.Columns.Add("INDEX", typeof(string));//唯一标识
            dtOrder = dt;
        }


        private void BindOrderList()
        {
            try
            {
                BindOrderValue();

                if (Session["kh"] != null)
                {
                    DataTable dt = (DataTable)Session["kh"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dtOrder.Rows.Add(new object[] {
                            dt.Rows[i]["C_ID"],
                            dt.Rows[i]["C_MAT_CODE"],
                            dt.Rows[i]["C_MAT_NAME"],
                            dt.Rows[i]["C_STL_GRD"],
                            dt.Rows[i]["C_SPEC"],
                            dt.Rows[i]["C_CUST_TECH_PROT"],
                            dt.Rows[i]["C_STD_CODE"],
                            dt.Rows[i]["ZYX1"],
                            dt.Rows[i]["ZYX2"],
                            dt.Rows[i]["C_BY4"],
                            dt.Rows[i]["C_PACK"],
                            dt.Rows[i]["N_WGT"],
                            dt.Rows[i]["PRICE"],
                            Guid.NewGuid().ToString("N") });
                    }
                }

                if (dtOrder.Rows.Count > 0)
                {
                    rptList.DataSource = dtOrder;
                    rptList.DataBind();
                    Session["kh"] = null;
                }
                else
                {

                    rptList.DataSource = null;
                    rptList.DataBind();
                    Session["kh"] = null;
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('" + ex.Message + "')", true);
            }

        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(dropConPolicyArea.SelectedItem.Value))
                {
                    if (Add(-1))
                    {
                        WebMsg.MessageBox("保存成功", "ConEdit.aspx?ID=" + conNo + "");
                    }
                    else
                    {
                        WebMsg.MessageBox("包装标准不能为空！");
                    }
                }
                else
                {
                    WebMsg.MessageBox("请选择合同政策区域");
                }

            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }

        //加载产品
        protected void imgbtnJz_Click(object sender, ImageClickEventArgs e)
        {

            BindOrderList();
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DropDownList dropZL = (DropDownList)e.Item.FindControl("dropZL");
            DataTable dtzl = tqb_checkstate.GetCheckState("").Tables[0];
            if (dtzl.Rows.Count > 0)
            {
                dropZL.DataSource = dtzl;
                dropZL.DataTextField = "C_CHECKSTATE_NAME";
                dropZL.DataValueField = "C_ID";
                dropZL.DataBind();
            }
        }
    }
}