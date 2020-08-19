using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.MODEL;
using NF.BLL;
using System.IO;
using NF.Framework;

namespace CRM.WebForms.Report
{
    public partial class PrintRecordDel : System.Web.UI.Page
    {
        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser == null)
                {
                    WebMsg.CheckUserLogin();
                }
               
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    hid.Value = Request.QueryString["ID"];
                    hidType.Value = Request.QueryString["Type"];

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtremark.Value))
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                var strArr = string.Join("','", hid.Value.Split(','));
                if (hidType.Value == "1")
                {
                    if (tmd_dispatch.UpdateReprint("'" + strArr + "'", this.txtremark.Value.Trim(), vUser.Name))
                    {
                        Response.Write("<script>alert('修改成功！');window.parent.refers();</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('修改失败！');window.parent.refers();</script>");
                    }
                }
                else
                {
                    if (tmd_dispatch.UpdateWWReprint("'" + strArr + "'", this.txtremark.Value.Trim(), vUser.Name))
                    {
                        Response.Write("<script>alert('修改成功！');window.parent.refers();</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('修改失败！');window.parent.refers();</script>");
                    }
                }
            }
        }
    }
}