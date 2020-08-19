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
using NF.BLL.D;
using NF.MODEL.D;

namespace CRM.WebForms.Report
{
    public partial class CarNum_Add : System.Web.UI.Page
    {
        private Bll_TMD_CAR_NUMBER tmd = new Bll_TMD_CAR_NUMBER();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlempID.Text = vUser.Name;
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Mod_TMD_CAR_NUMBER mod = new Mod_TMD_CAR_NUMBER();
            mod.C_NUMBER = txtCar.Value.Trim();
            mod.N_STATUS = 1;
            mod.C_EMP_ID = ltlempID.Text;
            mod.C_TYPE = droptype.SelectedValue;
            if (tmd.Add(mod))
            {
                WebMsg.MessageBox("添加成功");
                txtCar.Value = string.Empty;
                //Response.Write("<script>alert('添加成功');window.parent.refers();</script>");
            }
        }
    }
}