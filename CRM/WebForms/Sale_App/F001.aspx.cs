using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using NF.BLL;
using NF.Framework;
using NF.MODEL;
using System.Data;

namespace CRM.WebForms.Sale_App
{
    public partial class F001 : System.Web.UI.Page
    {
        private Bll_TMC_TRAIN_MAIN tmc_train_main = new Bll_TMC_TRAIN_MAIN();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindInfo();
                txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtEnd.Value = DateTime.Now.ToString("yyy-MM-dd");
            }
        }

        #region //基础数据
        /// <summary>
        /// 获取数字字典
        /// </summary>
        /// <param name="code">编码</param>
        /// <returns></returns>
        private DataTable GetData(string code)
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = code;
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            return dt;
        }
        private void BindInfo()
        {
            DataTable dt = GetData("ShipVia");
            if (dt.Rows.Count > 0)
            {
                dropfyfs.DataSource = dt;
                dropfyfs.DataTextField = "C_DETAILNAME";
                dropfyfs.DataValueField = "C_DETAILNAME";
                dropfyfs.DataBind();
            }
            else
            {
                dropfyfs.DataSource = null;
                dropfyfs.DataBind();
            }
            DataTable dtArea = GetData("ConArea");
            if (dtArea.Rows.Count > 0)
            {

                droparea.DataSource = dtArea;
                droparea.DataTextField = "C_DETAILNAME";
                droparea.DataValueField = "C_DETAILNAME";
                droparea.DataBind();
                droparea.Items.Insert(0, new ListItem("全部区域", ""));
            }
            else
            {
                droparea.DataSource = null;
                droparea.DataBind();
                droparea.Items.Insert(0, new ListItem("全部区域", ""));
            }

        }
        #endregion

        private void BindList()
        {

           

            DataTable dt = tmc_train_main.GetTrainMain(txtfyd.Text, txtzdr.Text, txtconno.Text, txtcust.Text, txtstlgrd.Text, txtspec.Text, dropcheck.SelectedValue, dropsfjk.SelectedValue == "全部" ? "" : dropsfjk.SelectedValue, txtStart.Value, txtEnd.Value, dropfyfs.SelectedItem.Text, txtstation.Text, droparea.SelectedValue,txtxfwgt.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();
                ltlsumwgt.Text = dt.Compute("sum(N_WGT)", "true").ToString();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                ltlsumwgt.Text = "";
            }
        }

        protected void btnxc_Click(object sender, EventArgs e)
        {
            BindList();
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            var list = new List<string>();

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                if (cbxselect.Checked)
                {
                    list.Add(cbxselect.Value);
                }
            }
            //获取用户所属公司名称
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

            if (tmc_train_main.UpdateTrainMain(list.Distinct().ToList(), vUser?.Name))
            {
                WebMsg.MessageBox("提交成功");
                BindList();
            }
        }
    }
}