using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.BLL;
using NF.Framework;

namespace CRM.WebForms.Cust_App
{
    public partial class MyGiveMark : System.Web.UI.Page
    {
        private Bll_TMC_CUSTGMARK_MAIN tmc_custgmark_main = new Bll_TMC_CUSTGMARK_MAIN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltluserID.Text = vUser.Id;
                    DateTime dt = DateTime.Now;
                    Start.Value = dt.AddDays(-(dt.Day) + 1).ToString("yyy-MM-dd");
                    End.Value = dt.AddMonths(10).AddDays(-(dt.Day)).ToString("yyy-MM-dd");
                    ByPageBind();
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }
        /// <summary>
        /// 分页绑定
        /// </summary>
        /// <param name="mod"></param>
        private void ByPageBind()
        {
            Pager1.RecordCount = tmc_custgmark_main.GetRecordCount(txtTitle.Value, Start.Value, End.Value, ltluserID.Text);
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
            rptList.DataSource = tmc_custgmark_main.GetListByPage(Pager1.PageSize, Pager1.CurrentPageIndex, txtTitle.Value, Start.Value, End.Value, ltluserID.Text);
            rptList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ByPageBind();
        }

        protected void Pager1_PageChanged(object sender, EventArgs e)
        {
            GetListBind();
        }
    }
}