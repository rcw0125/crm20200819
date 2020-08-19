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

namespace CRM.WebForms.Cust_App
{
    public partial class GiveMark : System.Web.UI.Page
    {
        private Bll_TMC_GIVEMARK_ITEM tmc_givemark_item = new Bll_TMC_GIVEMARK_ITEM();
        private Bll_TMC_CUSTGMARK_MAIN tmc_custgmark_main = new Bll_TMC_CUSTGMARK_MAIN();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltluserID.Text = vUser.Id;
                    ltluserName.Text = vUser.Name;

                    Mod_TS_CUSTFILE mod = ts_custfile.GetModel(vUser.CustId);
                    if (mod != null)
                    {
                        ltlCustNo.Text = mod.C_NO;
                        ltlCustName.Text = mod.C_NAME;
                    }
                   
                    GetList();
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }

            }
        }

        private void GetList()
        {
            DataTable dt = tmc_givemark_item.GetList("").Tables[0];
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

        private bool Add()
        {


            Mod_TMC_CUSTGMARK_MAIN mod = new Mod_TMC_CUSTGMARK_MAIN();
            mod.C_TITLE = "供应商综合评分-" +DateTime.Now.ToString("yyy年MM月");
            mod.C_STLGRD = hidgrd.Value;
            mod.C_CUSTNO = ltlCustNo.Text;
            mod.C_CUSTNAME = ltlCustName.Text;
            mod.C_EMPID = ltluserID.Text;
            mod.C_EMPNAME = ltluserName.Text;
            mod.C_REMARK = txtremark.Text;
            mod.C_ORDER_NO = horderNO.Value;

            #region 初始化DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("C_ID", typeof(string));
            dt.Columns.Add("N_SCORE", typeof(string));
            #endregion

            for (int i = 0; i < rptList.Items.Count; i++)
            {

                Literal ltlID = (Literal)rptList.Items[i].FindControl("ltlID");
                DropDownList dropNum = (DropDownList)rptList.Items[i].FindControl("dropNum");
               
                dt.Rows.Add(new object[] { ltlID.Text, dropNum.SelectedItem.Value });
            }
            return tmc_custgmark_main.InsertData(mod, dt);
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if(tmc_custgmark_main.CheckMonth(ltluserID.Text))
            {
                WebMsg.MessageBox("当前月已评分");
                
            }
            else
            {
                if (Add())
                {
                    WebMsg.MessageBox("提交成功");
                }
            }
           
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Literal ltlscore = (Literal)e.Item.FindControl("ltlscore");
            DropDownList dropNum = (DropDownList)e.Item.FindControl("dropNum");
            for (int i = 0; i <= Convert .ToInt32(ltlscore.Text); i++)
            {
                dropNum.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
    }
}