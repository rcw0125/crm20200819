using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.BLL;
using NF.MODEL;
using NF.Framework;

namespace CRM.WebForms.Report
{
    public partial class Order_End : System.Web.UI.Page
    {
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    Mod_TMO_ORDER mod = tmo_order.GetModel(Request.QueryString["ID"]);
                    if (mod != null)
                    {
                        Mod_TMO_CON conmod = tmo_con.GetModel(mod.C_CON_NO);
                        if (conmod != null)
                        {

                            var list = trc_roll_prodcut.Check_OrderAndRoll(mod.C_CON_NO);
                            if(list.Result)
                            {
                                if(list.Flag==0)
                                {
                                    lbl_msg.Text = "当前合同存在排产计划，请谨慎操作！";
                                }
                                else
                                {
                                    lbl_msg.Text = "当前合同存在线材库存，请谨慎操作！";
                                }
                            }

                            ltlConNO.Text = conmod.C_CON_NO;
                            ltlcustno.Text = conmod.C_CUST_NO;
                            ltlcustname.Text = conmod.C_CUSTNAME;
                            ltlarea.Text = conmod.C_AREA;
                        }
                    }
                }
            }

        }

        protected void btnok_Click(object sender, EventArgs e)
        {
            try
            {



                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

                DataTable dt = tmo_con.GetCustCon_End_List(ltlConNO.Text, ltlcustno.Text, "", "", "").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string msg = ltlConNO.Text + ",已重复提交，无法继续操作";
                    WebMsg.MessageBox(msg);
                }
                else
                {
                    var mod = new Mod_TMO_CON_END()
                    {
                        C_CUSTNO = ltlcustno.Text,
                        C_CUSTNAME = ltlcustname.Text,
                        C_SALEEMPID = vUser.Id,
                        C_REMARK = txtremark.Text,
                        C_CONNO = ltlConNO.Text,
                        C_AREA = ltlarea.Text
                    };

                    if (tmo_con.InsertCustCon_End(mod))
                    {
                        Response.Write("<script>alert('提交成功');window.parent.document.getElementById('btncx').click();window.parent.close();</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }

        }
    }
}