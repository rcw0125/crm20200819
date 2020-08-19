﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.BLL;
using NF.MODEL;
using System.Data;
using NF.Framework;

namespace CRM.WebForms.Report
{
    public partial class ZZS2 : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtremark.Text = "";

                GetShipVia();
                InitDDL();
                DateTime dt = DateTime.Now;
                ddlPrintStatus.SelectedValue = "1";
                ddlQPrint.SelectedValue = "0";
                //初始化日期
                txtStart.Value = Convert.ToDateTime(dt).ToString("yyy-MM-dd");
                txtEnd.Value = Convert.ToDateTime(dt).ToString("yyy-MM-dd");
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
            var dic = EnumHelper.GetEnumDic<PrintRemarkEnum>();
            dic.Keys.ToList().ForEach(x =>
            {
                if(dic[x].ToString()!="3")
                this.ddlType.Items.Add(new ListItem()
                {
                    Text = x,
                    Value = dic[x].ToString()
                });
            });        
            this.ddlType.SelectedIndex = 0;
        }

        #region //发运方式
        /// <summary>
        /// 获取数字字典
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private DataTable GetData(string code)
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = code;
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            return dt;
        }
        /// <summary>
        /// 发运方式
        /// </summary>
        private void GetShipVia()
        {
            DataTable dt = GetData("ShipVia");
            if (dt.Rows.Count > 0)
            {

                dropysfs.DataSource = dt;
                dropysfs.DataTextField = "C_DETAILNAME";
                dropysfs.DataValueField = "C_ID";
                dropysfs.DataBind();
                dropysfs.Items.Insert(0, new ListItem("全部", ""));
            }
            else
            {
                dropysfs.DataSource = null;
                dropysfs.DataBind();
            }
        }
        #endregion

        public string ShowPrintStaus(string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                return "";
            }
            else if(status=="0")
            {
                return "未打印";
            }
            else if (status == "1")
            {
                return "已打印";
            }
            else if (status == "2")
            {
                return "异常项";
            }
            else
            {
                return "补打";
            }
        }
        private void GetList()
        {
            DataTable dt = tmd_dispatch.GetPrintInfo(txtfyd.Text,txtcph.Text,dropysfs.SelectedValue, cbxcktime.Checked == true ? txtStart.Value : "",
                cbxcktime.Checked == true ? txtEnd.Value : "",txtbatch.Text,int.Parse(ddlQPrint.SelectedValue), txtAttrstor.Text.Trim(),txtCNo.Text.Trim(),this.dropmb.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                lstHJ.Text = dt.Rows.Count.ToString();
                List<string> ls = new List<string>();
                List<string> lsFYD = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ls.Add(dt.Rows[i]["C_LIC_PLA_NO"].ToString());
                    lsFYD.Add(dt.Rows[i]["C_DISPATCH_ID"].ToString());
                }
                lstCPH.Text = ls.Distinct().Count().ToString();
                lstFYDH.Text = lsFYD.Distinct().Count().ToString();
                lstWgt.Text = Math.Round(decimal.Parse(dt.Compute("sum(N_JZ)", "true").ToString()),4).ToString();
                rptList.DataSource = dt;
                rptList.DataBind();
            }
            else
            {
                lstHJ.Text = "0";
                lstCPH.Text ="0";
                lstFYDH.Text ="0";
                lstWgt.Text = "0";
               rptList.DataSource = null;
                rptList.DataBind();
            }
        }

        protected void btncx_Click(object sender, EventArgs e)
        {
            txtremark.Text = "";

            GetList();
            Page pa = (Page)System.Web.HttpContext.Current.CurrentHandler;
            ClientScript.RegisterClientScriptBlock(pa.GetType(), "aa", "<script language='javascript'>close();</script>");
        }

        protected void chkIsGP_CheckedChanged(object sender, EventArgs e)
        {
            this.dropmb.Items.Clear();
            if (chkIsGP.Checked)
            {               
                this.dropmb.Items.Add(new ListItem() {  Text="钢坯",Value="4"});
            }
            else
            {
                this.dropmb.Items.Add(new ListItem() { Text = "线材", Value = "1" });
                this.dropmb.Items.Add(new ListItem() { Text = "认证", Value = "3" });
                this.dropmb.Items.Add(new ListItem() { Text = "空白", Value = "5" });
                this.dropmb.Items.Add(new ListItem() { Text = "特殊", Value = "2" });
            }
        }
    }
}