using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

using NF.BLL;
using NF.MODEL;
using NF.Framework;

namespace CRM.WebForms.Sale_App
{
    public partial class MatList5 : System.Web.UI.Page
    {
        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();
        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private Bll_TMB_TAXITEMS tmb_taxitems = new Bll_TMB_TAXITEMS();

        private Bll_RandomNumber randomnumber = new Bll_RandomNumber();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlC_EMP_ID.Text = vUser.Id;
                    ltlC_EMP_NAME.Text = vUser.Name;

                    if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                    {
                        ltlCon_No.Text = Request.QueryString["ID"];//合同号
                        Mod_TMO_CON modCon = tmo_con.GetModel(ltlCon_No.Text);
                        ltlCustNo.Text = modCon.C_CUST_NO;
                    }
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetStlGrd();
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }

        private void GetStlGrd()
        {



            DataTable dt = new DataTable();
            if (cbxmatcode.Checked)
            {
                var list = new List<string>();

                if (txtmatcode.Text.Trim() != "")
                {
                    string[] OrderNo = txtmatcode.Text.Trim().Split(new string[] { "\n" }, StringSplitOptions.None);
                    OrderNo = OrderNo.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                    if (OrderNo.Length > 0)
                    {
                        for (int i = 0; i < OrderNo.Length; i++)
                        {
                            list.Add(OrderNo[i]);
                        }
                    }
                }

                var strOrder = string.Empty;
                if (list.Count > 0)
                {
                    strOrder = "'" + string.Join("','", list.ToArray()) + "'";
                }

                dt = tb_matrl_main.GetTWC_StlGrd(strOrder).Tables[0];
            }
            else
            {
                dt = tb_matrl_main.GetTWC_StlGrd(txtmatcode.Text, txtstlgrd.Text, tstspec.Text).Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('暂无头尾材产品')", true);
                rptList.DataSource = null;
                rptList.DataBind();
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

        //添加
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                Mod_TMO_CON modCon = tmo_con.GetModel(ltlCon_No.Text);
                Mod_TS_CUSTFILE modCust = ts_custfile.GetCustModel(modCon.C_CUSTOMERID);

                List<Mod_TMO_ORDER> orderList = new List<Mod_TMO_ORDER>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxSelect = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkMat_Code");//物料ID
                    Literal ltlmatcode = (Literal)rptList.Items[i].FindControl("ltlmatcode");//物料编码
                    Literal ltlmatname = (Literal)rptList.Items[i].FindControl("ltlmatname");//物料名称
                    Literal ltlstlgrd = (Literal)rptList.Items[i].FindControl("ltlstlgrd");//钢种
                    Literal ltlspec = (Literal)rptList.Items[i].FindControl("ltlspec");//规格
                    Literal ltlC_STD_CODE = (Literal)rptList.Items[i].FindControl("ltlC_STD_CODE");//执行标准
                    Literal ltlzyx1 = (Literal)rptList.Items[i].FindControl("ltlzyx1");//自由项1
                    Literal ltlzyx2 = (Literal)rptList.Items[i].FindControl("ltlzyx2");//自由项2
                    Literal ltlzldj = (Literal)rptList.Items[i].FindControl("ltlzldj");//质量等级
                    Literal ltlwgt = (Literal)rptList.Items[i].FindControl("ltlwgt");//库存量



                    if (cbxSelect.Checked)
                    {
                        #region Insert
                        Mod_TB_MATRL_MAIN modMat = tb_matrl_main.GetModel(cbxSelect.Value);
                        Mod_TMO_ORDER modOrder = new Mod_TMO_ORDER();

                        string order_no = randomnumber.CreateOrderNo(ltlCon_No.Text);//订单号
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
                        modOrder.C_FUNITID = modMat.C_FJLDW;// "jlda0000000000000041";//辅单位
                        modOrder.C_UNITID = modMat.C_PK_MEASDOC;//主计量单位
                        modOrder.D_DELIVERY_DT = modCon.D_CONINVALID_DT;//计划收货日期
                        modOrder.D_DT = DateTime.Now;//订单日期


                        modOrder.C_TECH_PROT = "";//客户协议号
                        modOrder.C_FREE1 = ltlzyx1.Text;//自由项1
                        modOrder.C_FREE2 = ltlzyx2.Text;//自由项2
                        modOrder.C_STD_CODE = ltlC_STD_CODE.Text;//执行标准
                        modOrder.C_VDEF1 = ltlzldj.Text;//质量等级
                                                        //modOrder.C_PACK = ltlpack.Text;//包装要求

                        //modOrder.C_BY4 = ltlC_IS_BXG.Text;//是否不锈钢


                        decimal N_WGT =Convert.ToDecimal(ltlwgt.Text);
                        modOrder.N_WGT = N_WGT;//数量
                        modOrder.N_HSL = modMat.N_HSL == null ? 0 : modMat.N_HSL;//换算率
                        modOrder.N_FNUM = modMat.N_HSL == null ? 1 : N_WGT / modMat.N_HSL;//辅数量

                        modOrder.C_RECEIPTCORPID = modCon.C_CRECEIPTAREAID;//收货地区
                        modOrder.C_RECEIVEADDRESS = modCon.C_ADDRESS;//收货地址
                        modOrder.C_RECEIPTCORPID = modCon.C_CRECEIPTCUSTOMERID;//收货单位
                        modOrder.C_CURRENCYTYPEID = modCon.C_CURRENCYTYPEID; //货币
                        modOrder.N_TYPE = Convert.ToDecimal(modMat.C_MAT_TYPE);
                        modOrder.N_USER_LEV = modCon.N_CUST_LEV;//客户等级

                        modOrder.C_CUST_SQ = modCon.C_REAMRK;//客户要求
                        modOrder.C_EMP_ID = ltlC_EMP_ID.Text;//操作人ID
                        modOrder.C_EMP_NAME = ltlC_EMP_NAME.Text; //操作人姓名
                        modOrder.C_CUST_NO = ltlCustNo.Text;//客户编码
                        modOrder.C_CUST_NAME = modCon.C_CUSTNAME;//客户名称
                        modOrder.C_SALE_CHANNEL = modCust.N_TYPE == 1 ? "经销" : "直销";

                        modOrder.C_LEV = GetLev("STL_GRD_Lev");//钢种等级
                        modOrder.C_ORDER_LEV = GetLev("Order_Lev");//订单等级
                        modOrder.N_COST = 0;//成本
                        modOrder.N_STATUS = 0;//待审

                        Mod_TMB_TAXITEMS modTaxi = tmb_taxitems.GetModel(modMat.C_PK_TAXITEMS);
                        modOrder.N_TAXRATE = modTaxi.N_TAXRATIO;//税率

                        #region //获取钢种单价-折扣-税率 
                        decimal Price = 0;
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
                        #endregion

                        orderList.Add(modOrder);

                        #endregion

                    }
                }

                if (tmo_con.InsertFirstOrder(orderList))
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "window.parent.document.getElementById('imgbtnJz').click();window.parent.close();", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('" + ex.Message + "')", true);
            }
        }
    }
}