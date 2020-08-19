using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using NF.MODEL;
using NF.BLL;
using System.Data;
using NF.Framework;

namespace CRM.WebForms.Report
{
    public partial class Order_ZB2 : System.Web.UI.Page
    {

        private Bll_TMO_ORDER_PCZB tmo_order_pczb = new Bll_TMO_ORDER_PCZB();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                txtStart.Value = DateTime.Now.ToString("yyy-MM");

                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlEmpName.Text = vUser.Name;
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }

        }

        protected void btnCX_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private void GetList()
        {
            DataTable dt = tmo_order_pczb.GetList(txtStart.Value + "-1").Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
            }
        }

        //生成指标
        protected void btnZB_Click(object sender, EventArgs e)
        {
            try
            {

                var list = new List<Mod_TMO_ORDER_PCZB>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxID = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxID");
                    Literal ltlC_AREA = (Literal)rptList.Items[i].FindControl("ltlC_AREA");
                    HtmlInputText txtN_MONTH_JK_ZB = (HtmlInputText)rptList.Items[i].FindControl("txtN_MONTH_JK_ZB");//月指标监控
                    HtmlInputText txtN_MONTH_JP_ZB = (HtmlInputText)rptList.Items[i].FindControl("txtN_MONTH_JP_ZB");//月指标精品
                    HtmlInputText txtN_MONTH_PZ_ZB = (HtmlInputText)rptList.Items[i].FindControl("txtN_MONTH_PZ_ZB");//月指标品种
                    HtmlInputText txtN_MONTH_PT_ZB = (HtmlInputText)rptList.Items[i].FindControl("txtN_MONTH_PT_ZB");//月指标普碳钢

                    Literal ltlC_TYPE = (Literal)rptList.Items[i].FindControl("ltlC_TYPE");//N/Y INSERT/UPDATE

                    Mod_TMO_ORDER_PCZB mod = new Mod_TMO_ORDER_PCZB();
                    mod.C_ID = cbxID.Value;
                    mod.C_AREA = ltlC_AREA.Text;//区域
                    mod.N_MONTH_JK_ZB = Convert.ToDecimal(txtN_MONTH_JK_ZB.Value == "" ? "0" : txtN_MONTH_JK_ZB.Value);//月监控指标
                    mod.N_MONTH_JP_ZB = Convert.ToDecimal(txtN_MONTH_JP_ZB.Value == "" ? "0" : txtN_MONTH_JP_ZB.Value);//月精品指标
                    mod.N_MONTH_PZ_ZB = Convert.ToDecimal(txtN_MONTH_PZ_ZB.Value == "" ? "0" : txtN_MONTH_PZ_ZB.Value);//月品种指标
                    mod.N_MONTH_PT_ZB = Convert.ToDecimal(txtN_MONTH_PT_ZB.Value == "" ? "0" : txtN_MONTH_PT_ZB.Value);//月普碳指标

                    mod.D_PLAN_DT = Convert.ToDateTime(txtStart.Value + "-1");//计划日期
                    mod.C_CREATE_ID = ltlEmpName.Text;//制单人

                    mod.C_TYPE2 = ltlC_TYPE.Text;//N/Y 添加/修改
                    list.Add(mod);

                }
                if (tmo_order_pczb.Insert_Update2(list))
                {
                    GetList();
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('保存成功');</script>", false);
                }

            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }
        }



        //删除指标
        protected void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new List<Mod_TMO_ORDER_PCZB>();
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxID = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxID");
                    if (cbxID.Checked)
                    {
                        var mod = new Mod_TMO_ORDER_PCZB() { C_ID = cbxID.Value };
                        list.Add(mod);
                    }
                }
                if (tmo_order_pczb.DelZB2(list))
                {
                    WebMsg.MessageBox("删除成功");
                    GetList();
                }

            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}