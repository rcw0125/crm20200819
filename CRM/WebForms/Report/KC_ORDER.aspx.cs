using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.BLL;
using NF.MODEL;
using NF.Framework;

namespace CRM.WebForms.Report
{
    public partial class KC_ORDER : System.Web.UI.Page
    {
        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_RandomNumber randomnumber = new Bll_RandomNumber();
        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    ltlOrderNo.Text = Request.QueryString["ID"];
                    Mod_TMO_ORDER mod = tmo_order.GetModel(ltlOrderNo.Text);
                    if (mod != null)
                    {
                        ltlConNO.Text = mod.C_CON_NO;
                        ltlMatCode.Text = mod.C_MAT_CODE;
                        ltlMatName.Text = mod.C_MAT_NAME;
                        ltlSpec.Text = mod.C_SPEC;
                        ltlStlGrd.Text = mod.C_STL_GRD;
                        ltlFree1.Text = mod.C_FREE1;
                        ltlFree2.Text = mod.C_FREE2;
                        ltlPack.Text = mod.C_PACK;
                        txtNum.Value = mod.N_WGT.ToString();
                        ltlTaxRate.Text = mod.N_TAXRATE.ToString();
                        ltlPrice.Text = mod.N_ORIGINALCURTAXPRICE.ToString();
                    }
                }
            }
        }

        //库存订单
        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {

                List<Mod_TMO_ORDER> orderList = new List<Mod_TMO_ORDER>();

                #region Insert

                Mod_TMO_ORDER modOrder = tmo_order.GetModel(ltlOrderNo.Text);

                Mod_TB_MATRL_MAIN modMat = tb_matrl_main.GetModel(modOrder.C_MAT_CODE);

                string order_no = randomnumber.CreateOrderNo(ltlConNO.Text);//订单号
                modOrder.C_ORDER_NO = order_no;
                modOrder.N_USER_LEV = 0;
                modOrder.N_COST = 0;

                decimal N_WGT = Convert.ToDecimal(txtNum.Value ?? "0");
                modOrder.N_WGT = N_WGT;//数量
                modOrder.N_HSL = modMat.N_HSL == null ? 0 : modMat.N_HSL;//换算率
                modOrder.N_FNUM = modMat.N_HSL == null ? 1 : N_WGT / modMat.N_HSL;//辅数量
               
                #region //获取钢种单价-折扣-税率 
                decimal Price = Convert.ToDecimal(modOrder.N_ORIGINALCURTAXPRICE);//原币含税单价
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

                if (tmo_con.InsertKCFirstOrder(orderList))
                {
                    Response.Write("<script>alert('提交成功');window.parent.close();</script>");
                }

            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}