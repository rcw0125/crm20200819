using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using NF.BLL;
using System.Data;

namespace CRM.Sale_App
{
    public partial class Consult_List : System.Web.UI.Page
    {

        private Bll_TMC_TECH_CONSULT_RESULT tmc_tech_consult_result = new Bll_TMC_TECH_CONSULT_RESULT();
        private Bll_TS_USER_DEPT ts_user_dept = new Bll_TS_USER_DEPT();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                DateTime time = DateTime.Now;
                Start.Value = time.AddDays(-(time.Day) + 1).ToString("yyy-MM-dd");
                End.Value = time.AddMonths(1).AddDays(-(time.Day)).ToString("yyy-MM-dd");

                //获取用户所属公司名称
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    DataTable dt = ts_user_dept.GetUserDeptList(BaseUser.Id).Tables[0];
                    if(dt.Rows .Count>0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ltlDeptID.Text += "'" + dt.Rows[0]["C_DEPT_ID"] + "',";
                        }
                        if(ltlDeptID.Text .Length>0)
                        {
                            ltlDeptID.Text = ltlDeptID.Text.Substring(0, ltlDeptID.Text.Length - 1);

                            ByPageBind();
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 分页绑定
        /// </summary>

        private void ByPageBind()
        {
            if (!string.IsNullOrEmpty(ltlDeptID.Text))
            {
                Pager1.RecordCount = tmc_tech_consult_result.GetRecordCount(ltlDeptID.Text,Start.Value, End.Value);
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
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        private void GetListBind()
        {
            rptList.DataSource = tmc_tech_consult_result.GetListByPage(Pager1.PageSize, Pager1.CurrentPageIndex, ltlDeptID.Text, Start.Value, End.Value);
            rptList.DataBind();
        }

        //分页
        protected void Pager1_PageChanged(object sender, EventArgs e)
        {
            GetListBind();
        }

        //查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ByPageBind();
        }

    }
}