using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

using NF.BLL;
using NF.MODEL;
using NF.Framework;
using NF.Bussiness.Interface;
using NF.Web.Core;
using Microsoft.Practices.Unity;
using NF.EF.Model;
using System.Collections;

namespace CRM.BasicData
{
    public partial class AreaPlan_Add : System.Web.UI.Page
    {
        private Bll_TMB_AREAPLAN tmb_areaplan = new Bll_TMB_AREAPLAN();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();


        IComService buttonService = DIFactory.GetContainer().Resolve<IComService>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    //GetFun();//加载按钮权限

                    txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");
                    txtEnd.Value = DateTime.Now.ToString("yyy-MM-dd");

                    var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                    if (vUser != null)
                    {
                        ltlempID.Text = vUser.Id;
                        ltlempName.Text = vUser.Name;

                        GetArea();

                    }
                    else
                    {
                        WebMsg.CheckUserLogin();
                    }
                }
                catch (Exception ex)
                {

                    WebMsg.MessageBox(ex.Message);
                }
            }
        }


        private void GetFun()
        {
            var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (user != null)
            {
                buttonService.RefreshButton(Request.RawUrl, user, Session);
                List<TS_BUTTON> button = (List<TS_BUTTON>)Session["button"];

                foreach (var item in button)
                {
                    if (Page.FindControl(item.C_CODE) != null)
                    {
                        Page.FindControl(item.C_CODE).Visible = true;
                    }
                }
            }
            else
            {
                WebMsg.CheckUserLogin();
            }
        }

        /// <summary>
        /// 获取区域
        /// </summary>
        private void GetArea()
        {

            DataTable dt = tmb_areaplan.GetAreaPlan(txtStart.Value, txtEnd.Value);
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<Mod_TMB_AREAPLAN> list = new List<Mod_TMB_AREAPLAN>();
            try
            {
                bool result = true;//是否生成签单指标

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxID = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxID");
                    Literal ltlArea = (Literal)rptList.Items[i].FindControl("ltlArea");
                    TextBox txtPTZB = (TextBox)rptList.Items[i].FindControl("txtPTZB");
                    TextBox txtPZZB = (TextBox)rptList.Items[i].FindControl("txtPZZB");
                    TextBox txtJPZB = (TextBox)rptList.Items[i].FindControl("txtJPZB");
                    TextBox txtJKZB = (TextBox)rptList.Items[i].FindControl("txtJKZB");

                    if (!string.IsNullOrEmpty(cbxID.Value))
                    {
                        result = false;
                        break;
                    }
                    #region //添加区域签单量/监控量
                    Mod_TMB_AREAPLAN mod = new Mod_TMB_AREAPLAN();
                    mod.C_AERA_ID = ltlArea.Text;
                    mod.N_WGT_PT = Convert.ToDecimal(txtPTZB.Text == "" ? "0" : txtPTZB.Text);
                    mod.N_WGT_GS = Convert.ToDecimal(txtPZZB.Text == "" ? "0" : txtPZZB.Text);
                    mod.N_WGT_JP = Convert.ToDecimal(txtJPZB.Text == "" ? "0" : txtJPZB.Text);
                    mod.N_WGT_JK = Convert.ToDecimal(txtJKZB.Text == "" ? "0" : txtJKZB.Text);
                    mod.C_EMP_ID = ltlempID.Text;
                    mod.C_EMP_NAME = ltlempName.Text;
                    mod.D_START = Convert.ToDateTime(txtStart.Value);
                    mod.D_END = Convert.ToDateTime(txtEnd.Value);
                    mod.N_SORT = i;
                    list.Add(mod);
                    #endregion
                }

                if (result)
                {
                    if (tmb_areaplan.AddList(list))
                    {
                        WebMsg.MessageBox("生成成功");
                        GetArea();
                    }
                }
                else
                {
                    WebMsg.MessageBox("当月已生成签单指标！");
                }

            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }

        protected void btnCx_Click(object sender, EventArgs e)
        {
            GetArea();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            List<Mod_TMB_AREAPLAN> list = new List<Mod_TMB_AREAPLAN>();
            try
            {
                bool result = true;//是否生成签单指标

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxID = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxID");
                    TextBox txtPTZB = (TextBox)rptList.Items[i].FindControl("txtPTZB");
                    TextBox txtPZZB = (TextBox)rptList.Items[i].FindControl("txtPZZB");
                    TextBox txtJPZB = (TextBox)rptList.Items[i].FindControl("txtJPZB");
                    TextBox txtJKZB = (TextBox)rptList.Items[i].FindControl("txtJKZB");
                    if (cbxID.Checked)
                    {
                        if (string.IsNullOrEmpty(cbxID.Value))
                        {
                            result = false;
                            break;
                        }
                        #region //添加区域签单量/监控量
                        Mod_TMB_AREAPLAN mod = new Mod_TMB_AREAPLAN();
                        mod.N_WGT_PT = Convert.ToDecimal(txtPTZB.Text == "" ? "0" : txtPTZB.Text);
                        mod.N_WGT_GS = Convert.ToDecimal(txtPZZB.Text == "" ? "0" : txtPZZB.Text);
                        mod.N_WGT_JP = Convert.ToDecimal(txtJPZB.Text == "" ? "0" : txtJPZB.Text);
                        mod.N_WGT_JK = Convert.ToDecimal(txtJKZB.Text == "" ? "0" : txtJKZB.Text);
                        mod.C_EMP_ID = ltlempID.Text;
                        mod.C_EMP_NAME = ltlempName.Text;
                        mod.C_ID = cbxID.Value;
                        list.Add(mod);
                        #endregion
                    }
                }
                if (result)
                {
                    if (list.Count > 0)
                    {
                        if (tmb_areaplan.UpdateList(list))
                        {
                            WebMsg.MessageBox("修改成功");
                            GetArea();
                        }
                    }
                    else
                    {
                        WebMsg.MessageBox("请选择项");
                    }

                }
                else
                {
                    WebMsg.MessageBox("请先生成当月签单指标！");
                }

            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new List<string>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxID = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxID");
                    if (cbxID.Checked)
                    {
                        list.Add(cbxID.Value);
                    }
                }
                if (list.Count > 0)
                {
                    string strWhere = string.Join("','", list.ToArray());
                    if (tmb_areaplan.DeleteList(strWhere))
                    {
                        WebMsg.MessageBox("删除成功");
                        GetArea();
                    }
                }
                else
                {
                    WebMsg.MessageBox("请选择需要删除的项");
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}