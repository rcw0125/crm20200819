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
    public partial class train_day_apply : System.Web.UI.Page
    {
        private Bll_TMC_TRAIN_ITEM tmc_train_item = new Bll_TMC_TRAIN_ITEM();
        private Bll_TMC_TRAIN_MAIN tmc_train_main = new Bll_TMC_TRAIN_MAIN();
        private Bll_RandomNumber randomnumber = new Bll_RandomNumber();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();

        public static DataTable dtExport = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtEnd.Value = DateTime.Now.ToString("yyy-MM-dd");
                BindArea();
            }

        }

        private void BindArea()
        {
            #region //需求区域

            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ConArea";
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropneedarea.DataSource = dt;
                dropneedarea.DataTextField = "C_DETAILNAME";
                dropneedarea.DataValueField = "C_DETAILNAME";
                dropneedarea.DataBind();
                dropneedarea.Items.Insert(0, new ListItem("全部区域", ""));
            }
            else
            {

                dropneedarea.DataSource = null;
                dropneedarea.DataBind();
                dropneedarea.Items.Insert(0, new ListItem("全部区域", ""));
            }
            #endregion

        }

        private void BindList()
        {
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

            DataTable dt = tmc_train_item.GetList(vUser.Id, txtcust.Text, txtcustno.Text, txtStart.Value, txtEnd.Value, txtconno.Text, txtplancode.Text, txtstlgrd.Text, dropneedarea.SelectedValue).Tables[0];
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


        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (dtExport.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("C_ID", "单据号");
                dic.Add("C_AREA", "区域");
                dic.Add("C_EMPNAME", "提报人");
                dic.Add("D_DATE", "提报日期");
                dic.Add("C_CONNO", "合同号");
                dic.Add("C_DH_COMPANY", "订货单位");
                dic.Add("C_SH_COMPANY", "收货单位");
                dic.Add("C_STATION", "到站");
                dic.Add("C_PLANNO", "计划号");
                dic.Add("C_LINE", "专用线");
                dic.Add("C_SPEC", "规格");
                dic.Add("C_STL_GRD", "钢种");
                dic.Add("N_WGT", "*吨数");
                dic.Add("N_TRAIN_NUM", "*车数");
                dic.Add("C_CUSTNO", "客户编码");
                dic.Add("C_CUSTNAME", "客户名称");
                dic.Add("C_KH_BANK", "开户行");
                dic.Add("C_TAXNO", "税号");
                dic.Add("C_ACCOUNT", "账号");
                dic.Add("C_TEL", "电话");
                dic.Add("C_ADDRESS", "地址");
                dic.Add("C_REMARK", "备注");
                ExportHelper.BudgetExport(dtExport, dic, "火运日计划申请", Response);
                dtExport = null;
            }
        }

        //计划申请
        protected void btnapply_Click(object sender, EventArgs e)
        {
            try
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                var mod = new Mod_TMC_TRAIN_MAIN()
                {
                    C_ID = randomnumber.GetTrainDayCode(),
                    C_EMPID = vUser.Id,
                    C_EMPNAME = vUser.Name
                };

                if (tmc_train_main.Insert(mod))
                {
                    string url = "train_day_edit.aspx?ID=" + mod.C_ID;
                    Response.Redirect(url);
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}