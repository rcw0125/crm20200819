using NF.BLL;
using NF.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CRM.WebForms.PCI
{
    public partial class THTB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtBegTime.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                txtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        Bll_Interface_FR bll = new Bll_Interface_FR();
        protected void btncx_Click(object sender, EventArgs e)
        {
            Query();
        }
        protected void Pager1_PageChanged(object sender, EventArgs e)
        {
            Query();
        }
        private void Query()
        {
            try
            {
                DataTable dt = bll.GetRFKCbyPH(txtph.Text.Trim(),txtgh.Text.Trim()).Tables[0];
                PagedDataSource ps = new PagedDataSource();
                ps.DataSource = dt.DefaultView;
                Pager1.RecordCount = ps.Count;
                if (Pager1.RecordCount > 0)
                {
                    ps.AllowPaging = true;
                    ps.PageSize = Pager1.PageSize;
                    ps.CurrentPageIndex = Pager1.CurrentPageIndex - 1;

                    rptList.DataSource = ps;
                    rptList.DataBind();
                }
                else
                {
                    rptList.DataSource = null;
                    rptList.DataBind();
                }
               
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.ToString());
            }
        }

        protected void btnSync_Click(object sender, EventArgs e)
        {
            var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            string message = "";
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox chkMat_Code = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                Literal lstdjh = (Literal)rptList.Items[i].FindControl("lbldjh");
                Literal lstck = (Literal)rptList.Items[i].FindControl("lblck");
                Literal lsthw = (Literal)rptList.Items[i].FindControl("lblhw");
                Literal lstzl = (Literal)rptList.Items[i].FindControl("lblzl");
                if (chkMat_Code.Checked)
                {
                    string type = bll.GetMOVETYPE(lstdjh.Text);
                    if (type == "")
                    {
                        message += lstdjh.Text + ":PCI不存在该卷！";
                        continue;
                    }
                    if (type != "S"||type != "QS")
                    {
                        message += lstdjh.Text + ":该卷未销售不能走退货！";
                        continue;
                    }
                    int szs = bll.UPRoll(lstdjh.Text, lstck.Text, lsthw.Text, lstzl.Text, "system");
                    if (szs==0)
                    {
                        message += lstdjh.Text+":PCI不存在该卷！";
                        continue;
                    }
                    if (szs == 2)
                    {
                        message += lstdjh.Text + ":PCI添加操作记录错误！";
                        continue;
                    }
                    if (szs == 3)
                    {
                        message += lstdjh.Text + ":PCI变更线材实绩错误！";
                        continue;
                    }
                }
            }
            if (message=="")
            {
                WebMsg.MessageBox("同步成功");
            }
            else
            {
                WebMsg.MessageBox(message);
            }
        }

        protected void btnjlcx_Click(object sender, EventArgs e)
        {
           Query2();
        }
        private void Query2()
        {
            try
            {
                DataTable dt = bll.GetLog(txtphcx.Text.Trim(), txtBegTime.Text,txtEndTime.Text,txtghcx.Text.Trim()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    rptList2.DataSource = dt;
                    rptList2.DataBind();
                }
                else
                {
                    rptList2.DataSource = null;
                    rptList2.DataBind();
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.ToString());
            }
        }
    }
}