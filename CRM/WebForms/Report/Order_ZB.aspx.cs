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
    public partial class Order_ZB : System.Web.UI.Page
    {

        private Bll_TMO_ORDER_PCZB tmo_order_pczb = new Bll_TMO_ORDER_PCZB();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtEnd.Value = DateTime.Now.ToString("yyy-MM-dd");
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
            DataTable dt = tmo_order_pczb.GetList(txtStart.Value, txtEnd.Value, Convert.ToInt32(dropZB.SelectedItem.Value)).Tables[0];
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
                    HtmlInputText txtN_DAY_JK_ZB = (HtmlInputText)rptList.Items[i].FindControl("txtN_DAY_JK_ZB");//旬指标监控
                    HtmlInputText txtN_DAY_JP_ZB = (HtmlInputText)rptList.Items[i].FindControl("txtN_DAY_JP_ZB");//旬指标精品
                    HtmlInputText txtN_DAY_PZ_ZB = (HtmlInputText)rptList.Items[i].FindControl("txtN_DAY_PZ_ZB");//旬指标品种
                    HtmlInputText txtN_DAY_PT_ZB = (HtmlInputText)rptList.Items[i].FindControl("txtN_DAY_PT_ZB");//旬指标普碳钢


                    Literal ltlC_TYPE = (Literal)rptList.Items[i].FindControl("ltlC_TYPE");//N/Y INSERT/UPDATE

                    Mod_TMO_ORDER_PCZB mod = new Mod_TMO_ORDER_PCZB();
                    mod.C_ID = cbxID.Value;
                    mod.C_AREA = ltlC_AREA.Text;//区域
                    mod.N_MONTH_JK_ZB = Convert.ToDecimal(txtN_MONTH_JK_ZB.Value == "" ? "0" : txtN_MONTH_JK_ZB.Value);//月监控指标
                    mod.N_MONTH_JP_ZB = Convert.ToDecimal(txtN_MONTH_JP_ZB.Value == "" ? "0" : txtN_MONTH_JP_ZB.Value);//月精品指标
                    mod.N_MONTH_PZ_ZB = Convert.ToDecimal(txtN_MONTH_PZ_ZB.Value == "" ? "0" : txtN_MONTH_PZ_ZB.Value);//月品种指标
                    mod.N_MONTH_PT_ZB = Convert.ToDecimal(txtN_MONTH_PT_ZB.Value == "" ? "0" : txtN_MONTH_PT_ZB.Value);//月普碳指标
                    if (ltlC_TYPE.Text == "N")
                    {
                        switch (dropZB.SelectedItem.Value)
                        {
                            case "0"://上旬指标
                                mod.N_DAY_JK_ZB = decimal.Round(Convert.ToDecimal(txtN_MONTH_JK_ZB.Value == "" ? "0" : txtN_MONTH_JK_ZB.Value) / 3, 0);//旬监控指标
                                mod.N_DAY_JP_ZB = decimal.Round(Convert.ToDecimal(txtN_MONTH_JP_ZB.Value == "" ? "0" : txtN_MONTH_JP_ZB.Value) / 3, 0);//旬精品指标
                                mod.N_DAY_PZ_ZB = decimal.Round(Convert.ToDecimal(txtN_MONTH_PZ_ZB.Value == "" ? "0" : txtN_MONTH_PZ_ZB.Value) / 3, 0);//旬品种指标
                                mod.N_DAY_PT_ZB = decimal.Round(Convert.ToDecimal(txtN_MONTH_PT_ZB.Value == "" ? "0" : txtN_MONTH_PT_ZB.Value) / 3, 0);//旬普碳指标
                                break;
                            case "1"://中旬指标
                                DataTable dtZB = tmo_order_pczb.GetZB(txtEnd.Value, ltlC_AREA.Text).Tables[0];
                                if (dtZB.Rows.Count > 0)
                                {
                                    mod.N_DAY_JK_ZB = decimal.Round(Convert.ToDecimal(dtZB.Rows[0]["JKZB"].ToString()) / 2, 0);//旬监控指标
                                    mod.N_DAY_JP_ZB = decimal.Round(Convert.ToDecimal(dtZB.Rows[0]["JPZB"].ToString()) / 2, 0);//旬精品指标
                                    mod.N_DAY_PZ_ZB = decimal.Round(Convert.ToDecimal(dtZB.Rows[0]["PZZB"].ToString()) / 2, 0);//旬品种指标
                                    mod.N_DAY_PT_ZB = decimal.Round(Convert.ToDecimal(dtZB.Rows[0]["PTZB"].ToString()) / 2, 0);//旬普碳指标
                                }
                                break;
                            case "2"://下旬指标
                                DataTable dtZB2 = tmo_order_pczb.GetZB(txtEnd.Value, ltlC_AREA.Text).Tables[0];
                                if (dtZB2.Rows.Count > 0)
                                {
                                    mod.N_DAY_JK_ZB = Convert.ToDecimal(dtZB2.Rows[0]["JKZB"].ToString());//旬监控指标
                                    mod.N_DAY_JP_ZB = Convert.ToDecimal(dtZB2.Rows[0]["JPZB"].ToString());//旬精品指标
                                    mod.N_DAY_PZ_ZB = Convert.ToDecimal(dtZB2.Rows[0]["PZZB"].ToString());//旬品种指标
                                    mod.N_DAY_PT_ZB = Convert.ToDecimal(dtZB2.Rows[0]["PTZB"].ToString());//旬普碳指标
                                }
                                break;
                        }

                    }
                    else
                    {
                        mod.N_DAY_JK_ZB = Convert.ToDecimal(txtN_DAY_JK_ZB.Value);//旬监控指标
                        mod.N_DAY_JP_ZB = Convert.ToDecimal(txtN_DAY_JP_ZB.Value);//旬精品指标
                        mod.N_DAY_PZ_ZB = Convert.ToDecimal(txtN_DAY_PZ_ZB.Value);//旬品种指标
                        mod.N_DAY_PT_ZB = Convert.ToDecimal(txtN_DAY_PT_ZB.Value);//旬普碳指标
                    }
                    mod.D_PLAN_DT = Convert.ToDateTime(txtEnd.Value);//计划日期
                    mod.N_TYPE = Convert.ToDecimal(dropZB.SelectedItem.Value);//1上旬 ，2中旬，3下旬
                    mod.C_CREATE_ID = ltlEmpName.Text;//制单人
                    mod.C_EMP_ID = ltlEmpName.Text;//最后修改人
                    mod.D_EMP_DT = DateTime.Now;//最后修改实际
                    mod.N_PC_JK = Convert.ToDecimal(txtjkzb.Text == "" ? "0" : txtjkzb.Text);//监控下发范围
                    mod.N_PC_JP = Convert.ToDecimal(txtjp.Text == "" ? "0" : txtjp.Text);//精品下发范围
                    mod.N_PC_PZ = Convert.ToDecimal(txtpz.Text == "" ? "0" : txtpz.Text);//品种下发范围
                    mod.N_PC_PT = Convert.ToDecimal(txtpt.Text == "" ? "0" : txtpt.Text);//普碳下发范围
                    mod.N_SORT = i;
                    mod.C_TYPE2 = ltlC_TYPE.Text;//N/Y 添加/修改
                    list.Add(mod);

                }
                if (tmo_order_pczb.Insert_Update(list))
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

        protected void btnFlag_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new List<Mod_TMO_ORDER_PCZB>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxID = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxID");
                    Literal ltlC_FLAG = (Literal)rptList.Items[i].FindControl("ltlC_FLAG");
                    Literal ltlC_TYPE = (Literal)rptList.Items[i].FindControl("ltlC_TYPE");

                    Mod_TMO_ORDER_PCZB mod = new Mod_TMO_ORDER_PCZB();
                    if (cbxID.Checked)
                    {
                        mod.C_ID = cbxID.Value;
                        mod.C_EMP_ID = ltlEmpName.Text;
                        mod.D_EMP_DT = DateTime.Now;
                        mod.C_TYPE2 = ltlC_TYPE.Text;
                        mod.C_FLAG = ltlC_FLAG.Text == "N" ? "Y" : "N";
                        list.Add(mod);
                    }
                }

                if (tmo_order_pczb.UpdateFlag(list))
                {
                    GetList();
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('设置成功');</script>", false);
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
                if (tmo_order_pczb.DelZB(txtEnd.Value, Convert.ToInt32(dropZB.SelectedItem.Value)))
                {
                    GetList();
                    WebMsg.MessageBox("删除成功");
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}