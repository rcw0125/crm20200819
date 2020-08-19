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

namespace CRM.WebForms.PCI
{
    public partial class FYDTB : System.Web.UI.Page
    {
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        Bll_TRC_ROLL_PRODCUT bll_TRC_ROLL_PRODCUT = new Bll_TRC_ROLL_PRODCUT();
        Bll_Interface_FR bll_Interface_FR = new Bll_Interface_FR();
        Bll_TPB_LINEWH bll_TPB_LINEWH = new Bll_TPB_LINEWH();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    try
                    {
                        txtBegTime.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                        txtEndTime.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                        ltlempid.Text = vUser.Id;
                        Query();
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
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "xc")
            {
                lblFYD.Text = e.CommandArgument.ToString();
                ltlRecord.Text = ((System.Web.UI.WebControls.Literal)e.Item.Controls[3]).Text;
                Detail();
            }
           
        }

        private void Detail()
        {
            try
            {
                DataTable dt = null;
                dt = bll_Interface_FR.GetYWDXQ(lblFYD.Text, "2", ltlRecord.Text).Tables[0];
                rptList2.DataSource = dt;
                rptList2.DataBind();
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.ToString());
            }
        }
        private void Query()
        {
            try
            {
                DataTable dt = null;
                dt = bll_Interface_FR.GetTMFYD(txtFYD.Text.Trim(), Convert.ToDateTime(txtBegTime.Text), Convert.ToDateTime(txtEndTime.Text)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    rptList.DataSource = dt;
                    rptList.DataBind();
                }
                else
                {
                    rptList.DataSource = null;
                    rptList.DataBind();
                    txtFYD.Text = "";
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.ToString());
            }
        }
        

        protected void btncx_Click(object sender, EventArgs e)
        {
            Query();
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
        }           


        protected void btnSync_Click(object sender, EventArgs e)
        {
            string filePath = "~/FileInterface/download";
            string xmlFileName = Server.MapPath(filePath);
            string message = bll_Interface_FR.TBFYD(xmlFileName);//需要修改
            if (message == "1")
            {
                Query();
                Detail();
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('同步完成！');</script>", false);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('"+ message + "');</script>", false);
            }
           
        }
    }
}