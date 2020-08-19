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
    public partial class ZZSConfimRecord : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TMD_ZZSCONFIRM_RECORD tmd = new Bll_TMD_ZZSCONFIRM_RECORD();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                DateTime dt = DateTime.Now;
                InitDDL();
                //默认打印状态
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

        private void InitDDL()
        {
            var dic = EnumHelper.GetEnumDic<PrintTypeEnum>();
            dic.Keys.ToList().ForEach(x =>
                this.ddlType.Items.Add(new ListItem()
                {
                    Text = x,
                    Value = dic[x].ToString()
                }));
            this.ddlType.SelectedIndex = 0;
        }

        private void GetList()
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(txtCKD.Text))
            {
                strWhere += " and C_CKD like '%" + txtCKD.Text.Trim() + "%' ";
            }
            if (!string.IsNullOrEmpty(txtFYD.Text))
            {
                strWhere += " and C_FYD like '%" + txtFYD.Text.Trim() + "%' ";
            }
            if (!string.IsNullOrEmpty(txtBatch.Text))
            {
                strWhere += " and C_BATCH like '%" + txtBatch.Text.Trim() + "%' ";
            }
            if (ddlType.SelectedValue!="0")
            {
                strWhere += " and N_TYPE=" + this.ddlType.SelectedValue;
            }
            DataTable dt = tmd.GetList(strWhere).Tables[0];
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

       
    }
}