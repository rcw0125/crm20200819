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
using NF.BLL.Q;
using CRM.Common;

namespace CRM.WebForms.ZL
{
    public partial class QualityInfo : System.Web.UI.Page
    {
        private const string RoleCode = "kh-001";
        private const string KFCode = "z-002";
        private const string SaleCode = "S0005/S0006";
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TMQ_QUA_MAIN qua = new Bll_TMQ_QUA_MAIN();

        public static DataTable dtExport = new DataTable();
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

                    if (vUser.Roles.Where(x => x.C_CODE == RoleCode).Any())
                    {
                        btnDel.Visible = false;
                    }
                    else
                    {
                        btnDel.Visible = true;
                    }
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }
        private void InitDDL()
        {

            DataTable dt = qua.ListArea().Tables[0];
            if (dt.Rows.Count > 0)
            {
                ddlArea.DataSource = dt;
                ddlArea.DataTextField = "C_DETAILNAME";
                ddlArea.DataValueField = "C_DETAILNAME";
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, new ListItem("全部", "全部"));
            }

        }

        private void GetList()
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(txtDistributor.Text))
            {
                strWhere += " and m.C_DISTRIBUTOR like '%" + txtDistributor.Text + "%' ";
            }
            if (!string.IsNullOrEmpty(txtStart.Value))
            {
                strWhere += " AND m.D_SHIP_START_DT>=TO_DATE('" + txtStart.Value + "', 'yyyy-mm-dd hh24:mi:ss')";
            }
            if (!string.IsNullOrEmpty(txtEnd.Value))
            {
                strWhere += " AND m.D_SHIP_START_DT<=TO_DATE('" + txtEnd.Value + "', 'yyyy-mm-dd hh24:mi:ss')";
            }
            if (ddlArea.SelectedValue != "全部")
            {
                strWhere += " and m.C_AREA_ID='" + this.ddlArea.SelectedValue + "'";
            }
            if (ddlType.SelectedValue != "0")
            {
                strWhere += " and m.N_FLAG=" + this.ddlType.SelectedValue;
            }
            if (!string.IsNullOrEmpty(txtSaleMan.Text.Trim()))
            {
                strWhere += " and m.C_SALESMAN like '%" + txtSaleMan.Text.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txtGrd.Text.Trim()))
            {
                strWhere += " and m.C_GRD like '%" + txtGrd.Text.Trim() + "%'";
            }
            if (this.ddlState.SelectedValue != "-2")
            {
                strWhere += " and m.N_STATUS=" + this.ddlState.SelectedValue;
            }
            //if (!string.IsNullOrEmpty(txtObjType.Text.Trim()))
            //{
            //    strWhere += " and m.C_OBJECTION_TYPE like '%" + txtObjType.Text.Trim() + "%'";
            //}
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (vUser.Roles.Where(x => x.C_CODE == RoleCode).Any())
            {
                strWhere += " and m.C_CRT_ID='" + vUser.Id + "' ";
                strWhere += " and m.n_status>=-1 ";
            }
            else
            {
                strWhere += " and m.n_status>=0";
            }
            //if (vUser.Roles.Where(x => SaleCode.Contains(x.C_CODE)).Any())
            //{
            //    strWhere += " and m.n_status>=0 and m.C_SALESID='" + vUser.Id + "'";
            //}
            //if (vUser.Roles.Where(x => x.C_CODE == KFCode).Any() || !vUser.Roles.Where(x => SaleCode.Contains(x.C_CODE) || x.C_CODE == RoleCode).Any())
            //{
            //    strWhere += " and m.n_status>=0";
            //}
            DataTable dt = qua.GetList(strWhere);
            if (dt.Rows.Count > 0)
            {
                //lstHJ.Text = dt.Rows.Count.ToString();
                //lstJE.Text = dt.Compute("sum(N_AMOUNT)", "true").ToString() == "" ? "0" : dt.Compute("sum(N_AMOUNT)", "true").ToString();
                decimal cycle = dt.Compute("sum(N_CYCLE)", "true").ToString() == "" ? 0 : decimal.Parse(dt.Compute("sum(N_CYCLE)", "true").ToString());
                var averageCycl = decimal.Round((cycle / dt.Rows.Count), 2);
                foreach (DataRow item in dt.Rows)
                {
                    item["C_MONTH_AVERAGE"] = averageCycl.ToString();
                }
                rptList.DataSource = dt;
                dtExport = dt;

                rptList.DataBind();
            }
            else
            {

                rptList.DataSource = null;
                rptList.DataBind();
            }

        }
        protected void btnDel_Click(object sender, EventArgs e)
        {

            var list = new List<string>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                Literal ltlN_STATUSNAME = (Literal)rptList.Items[i].FindControl("ltlN_STATUSNAME");
                if (cbxselect.Checked)
                {
                    if (ltlN_STATUSNAME.Text != "未提交")
                    {
                        HtmlInputHidden hidVal = (HtmlInputHidden)rptList.Items[i].FindControl("hidCID");
                        string idstr = hidVal.Value;
                        list.Add(idstr);
                    }
                }
            }
            var str = string.Join("','", list.ToArray());

            if (qua.DeleteList("'" + str + "'"))
            {
                WebMsg.MessageBox("删除成功！");
                GetList();
            }

            //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> refers();</script>", false);
        }
        protected void btncx_Click(object sender, EventArgs e)
        {
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (vUser != null)
            {
                hidempname.Value = vUser.Name;
            }
            else
            {
                WebMsg.CheckUserLogin();
            }
            GetList();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (dtExport.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("C_NO", "编号");
                dic.Add("N_FLAGNAME", "反馈类型");
                dic.Add("D_CRT_DT", "提交日期");
                dic.Add("N_STATUS", "状态");
                dic.Add("C_AREA_NAME", "区域");
                dic.Add("C_CUST_MAKING", "处理人员");
                dic.Add("C_SALESMAN", "业务员");
                dic.Add("C_DISTRIBUTOR", "经销商");
                dic.Add("C_DIRECTUSER", "用户");
                dic.Add("D_SHIP_START_DT", "发运日期");
                dic.Add("D_SHIP_END_DT", "到货日期");
                dic.Add("C_GRD", "钢种分类");
                dic.Add("C_PROD_USE", "线材用途");
                dic.Add("C_TECH_DESC", "生产工艺");
                dic.Add("C_OBJECT_CONTENT", "用户异议简述");
                dic.Add("C_REMARK", "备注");
                ExportHelper.BudgetExport(dtExport, dic, "质量异议反馈", Response);
                dtExport = null;
            }
        }
    }

}