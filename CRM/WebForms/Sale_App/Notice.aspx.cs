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

namespace CRM.Sale_App
{
    public partial class Notice : System.Web.UI.Page
    {

        private Bll_TS_DIC dic = new Bll_TS_DIC();
        private Bll_TMB_NOTICE notice = new Bll_TMB_NOTICE();


        IComService buttonService = DIFactory.GetContainer().Resolve<IComService>();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {

                    GetFun();//加载按钮权限
                    GetClass();
                    DateTime dt = DateTime.Now;
                    Start.Value = dt.AddDays(-(dt.Day) + 1).ToString("yyy-MM-dd");
                    End.Value = dt.AddMonths(1).AddDays(-(dt.Day)).ToString("yyy-MM-dd");
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
        /// 获取公告分类
        /// </summary>
        private void GetClass()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "NoticeType";
            DataTable dt = dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropClass.DataSource = dt;
                dropClass.DataTextField = "C_DETAILNAME";
                dropClass.DataValueField = "C_ID";
                dropClass.DataBind();
            }
            else
            {
                dropClass.DataSource = null;
                dropClass.DataBind();
            }
        }

        /// <summary>
        /// 分页绑定
        /// </summary>
        /// <param name="mod"></param>
        private void ByPageBind()
        {
            Pager1.RecordCount = notice.GetRecordCount(dropClass.SelectedValue, txtTitle.Value, Start.Value,End.Value);
            if (Pager1.RecordCount > 0)
            {
                GetListBind();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
            }
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="mod"></param>
        private void GetListBind()
        {
            rptList.DataSource = notice.GetListByPage(Pager1.PageSize, Pager1.CurrentPageIndex, dropClass.SelectedItem.Value, txtTitle.Value, Start.Value, End.Value);
            rptList.DataBind();
        }

        //查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ByPageBind();
        }

        //分页
        protected void Pager1_PageChanged(object sender, EventArgs e)
        {
            GetListBind();
        }

        //删除
        protected void btnDel_Click(object sender, EventArgs e)
        {

            string IDList = "";
            foreach (RepeaterItem item in rptList.Items)
            {
                HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)item.FindControl("chkSelect");
                if (chkSelect.Checked)
                {
                    IDList += "'" + chkSelect.Value + "',";
                }
            }
            if (!string.IsNullOrEmpty(IDList))
            {
                IDList = IDList.Substring(0, IDList.Length - 1);
                if (notice.UpdateStatus(IDList, 0))
                {
                    WebMsg.MessageBox("删除成功");
                    ByPageBind();
                }
            }
        }
    }
}