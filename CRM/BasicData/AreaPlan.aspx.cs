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
using NF.Bussiness.Interface;
using NF.Web.Core;
using Microsoft.Practices.Unity;
using NF.EF.Model;

namespace CRM.BasicData
{
    public partial class AreaPlan : System.Web.UI.Page
    {


        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();

        private Bll_TMB_AREAPLAN areaPlan = new Bll_TMB_AREAPLAN();

        IComService buttonService = DIFactory.GetContainer().Resolve<IComService>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {


                    GetFun();//加载按钮权限

                    GetArea();
           
                    ByPageBind();
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
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ConArea";
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropArea.DataSource = dt;
                dropArea.DataTextField = "C_DETAILNAME";
                dropArea.DataValueField = "C_DETAILNAME";
                dropArea.DataBind();
                dropArea.Items.Insert(0, new ListItem("全部",""));
            }
            else
            {
                dropArea.DataSource = null;
                dropArea.DataBind();
            }
        }

        /// <summary>
        /// 分页绑定
        /// </summary>
        /// <param name="mod"></param>
        private void ByPageBind()
        {
            Pager1.RecordCount = areaPlan.GetRecordCount(dropArea.SelectedItem.Value);
            if (Pager1.RecordCount > 0)
            {
                GetListBind();
            }
            else
            {
                rpt_List.DataSource = null;
                rpt_List.DataBind();
            }
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="mod"></param>
        private void GetListBind()
        {
            rpt_List.DataSource = areaPlan.GetListByPage(Pager1.PageSize, Pager1.CurrentPageIndex, dropArea.SelectedItem.Value);
            rpt_List.DataBind();
        }

        /// <summary>
        /// 查询
        /// </summary>

        protected void btn_Search_Click(object sender, EventArgs e)
        {

            ByPageBind();
        }

        /// <summary>
        /// 翻页
        /// </summary>
        protected void Pager1_PageChanged(object sender, EventArgs e)
        {

            GetListBind();
        }

        //删除
        protected void btn_Del_Click(object sender, EventArgs e)
        {
            bool result = false;
            foreach (RepeaterItem rpt in rpt_List.Items)
            {
                HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)rpt.FindControl("chkSelect");
                if (chkSelect.Checked)
                {
                    if (!string.IsNullOrEmpty(chkSelect.Value))
                    {
                        result = areaPlan.Delete(chkSelect.Value);
                    }
                }
            }
            if (result)
            {
                ByPageBind();
            }

        }
    }
}