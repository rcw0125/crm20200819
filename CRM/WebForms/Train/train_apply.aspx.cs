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
using CRM.Common;

namespace CRM.WebForms.Train
{
    public partial class train_apply : System.Web.UI.Page
    {
        private Bll_TMC_TRAIN_ITEM tmc_train_item = new Bll_TMC_TRAIN_ITEM();

        public static DataTable dtExport = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtEnd.Value = DateTime.Now.AddMonths(1).ToString("yyy-MM-dd");
            }

        }

        private void BindList()
        {
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

            string flag = string.Empty;
            if (dropflag.SelectedValue == "全部")
            {
                flag = "'0','2'";
            }
            else
            {
                flag = $"'{dropflag.SelectedValue}'";
            }


            DataTable dt = tmc_train_item.GetList(vUser.Id, txtcust.Text, txtcustno.Text, txtStart.Value, txtEnd.Value, txtconno.Text, flag).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();

                dtExport = dt;
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
            }
        }

        protected void btncx_Click(object sender, EventArgs e)
        {
            BindList();
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                bool res = false;
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                    if (cbxselect.Checked)
                    {
                        var mod = new Mod_TMC_TRAIN_ITEM() { C_ID = cbxselect.Value };
                        res = tmc_train_item.Del(mod);
                    }
                }
                if (res)
                {
                    WebMsg.MessageBox("删除成功");
                    BindList();
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (dtExport.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("C_BILLCODE", "单据号");
                dic.Add("C_AREA", "区域");
                dic.Add("C_EMPNAME", "提报人");
                dic.Add("D_DATE", "提报日期");
                dic.Add("C_CONNO", "合同号");
                dic.Add("C_DH_COMPANY", "订货单位");
                dic.Add("C_SH_COMPANY", "收货单位");
                dic.Add("C_STATION", "到站");
                dic.Add("N_TRAIN_NUM", "*车数");
                dic.Add("C_LINE", "专用线");
                dic.Add("C_CUSTNO", "客户编码");
                dic.Add("C_CUSTNAME", "客户名称");
                dic.Add("C_KH_BANK", "开户行");
                dic.Add("C_TAXNO", "税号");
                dic.Add("C_ACCOUNT", "账号");
                dic.Add("C_TEL", "电话");
                dic.Add("C_ADDRESS", "地址");

                ExportHelper.BudgetExport(dtExport, dic, "火运计划（内/外）", Response);
                dtExport = null;
            }
        }
    }
}