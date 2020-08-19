using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.BLL;
using NF.MODEL;
using System.Data;
using NF.Framework;
using System.Web.UI.HtmlControls;

namespace CRM.WebForms.Report
{
    public partial class GrdInfo : System.Web.UI.Page
    { 
        private Bll_TQB_REMARKPRINT tmd = new Bll_TQB_REMARKPRINT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                DateTime dt = DateTime.Now;
               
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    hidempname.Value = vUser.Name;
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }

      

        private void GetList()
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(txtGrd.Text))
            {
                strWhere += " and C_STL_GRD like '%" + txtGrd.Text.Trim() + "%' ";
            }          
            DataTable dt = tmd.GetGrdList(strWhere).Tables[0];
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

        protected void btncx_Click(object sender, EventArgs e)
        {           

            GetList();
            Page pa = (Page)System.Web.HttpContext.Current.CurrentHandler;
            ClientScript.RegisterClientScriptBlock(pa.GetType(), "aa", "<script language='javascript'>close();</script>");
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            var list = new List<string>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                if (cbxselect.Checked)
                {
                    Literal lblCID = (Literal)rptList.Items[i].FindControl("lblCID");
                    string idstr = lblCID.Text;
                    list.Add(idstr);
                }
            }
            var str = string.Join("','",list.ToArray());
            tmd.DeleteGrdList("'" + str + "'");
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> refers();</script>", false);
        }
    }
}