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

namespace CRM.WebForms.Sale_App
{
    public partial class OrderList : System.Web.UI.Page
    {
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_TQB_CHECKSTATE tqb_checkstate = new Bll_TQB_CHECKSTATE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltluserID.Text = vUser.Id;
                    DateTime dt = DateTime.Now;
                    txtStart.Value = dt.AddMonths(-2).ToString("yyy-MM-dd");
                    txtEnd.Value = dt.ToString("yyy-MM-dd");
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }

            }
        }

        private void GetList()
        {
            DataTable dt = tmo_order.GetDayPlanOrder(txtcustname.Text, txtconno.Text, txtyewuyuan.Text, txtstlgrd.Text, txtStart.Value, txtEnd.Value, droptype.SelectedItem.Value, txtspec.Text, txtmatcode.Text).Tables[0];
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

        protected void btncx_Click(object sender, EventArgs e)
        {
            GetList();
        }
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)e.Item.FindControl("chkOrder");
            Literal ltldlxwgt = (Literal)e.Item.FindControl("ltldlxwgt");//订单待履行量
            Literal ltlztwgt = (Literal)e.Item.FindControl("ltlztwgt");//订单发运在途量
            Literal ltlyfywgt = (Literal)e.Item.FindControl("ltlyfywgt");//订单已履行量

            try
            {
                if (Convert.ToDecimal(ltldlxwgt.Text ?? "0") <= 0)
                {
                    chkOrder.Visible = false;
                }
                else
                {
                    chkOrder.Visible = true;
                }

            }
            catch (Exception ex)
            {
                chkOrder.Visible = false;
                WebMsg.MessageBox(ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            Session[ltluserID.Text] = null;


            #region //DataTable初始化
            DataTable dt = new DataTable();
            dt.Columns.Add("C_ID", typeof(string));
            dt.Columns.Add("PKPLAN", typeof(string));
            dt.Columns.Add("FLAG", typeof(string));
            dt.Columns.Add("YLXWGT", typeof(string));//已履行量
            dt.Columns.Add("DLXWGT", typeof(string));//待履行量
            #endregion


            string con = "";//客户编码
            bool isFirstCheck = false;
            bool isequer = true;

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkOrder");
                Literal ltlpkplan = (Literal)rptList.Items[i].FindControl("ltlpkplan");
                Literal ltlyfywgt = (Literal)rptList.Items[i].FindControl("ltlyfywgt");//已履行量
                Literal ltldlxwgt = (Literal)rptList.Items[i].FindControl("ltldlxwgt");//待履行量
                Literal ltlC_CUST_NO = (Literal)rptList.Items[i].FindControl("ltlC_CUST_NO");//客户编码
                if (chkOrder.Checked)
                {
                    if (!isFirstCheck)
                    {
                        con = ltlC_CUST_NO.Text;
                        isFirstCheck = true;
                    }
                    if (ltlC_CUST_NO.Text != con)
                    {
                        isequer = false;
                        break;
                    }

                    dt.Rows.Add(new object[] { chkOrder.Value, ltlpkplan.Text, "N", ltlyfywgt.Text, ltldlxwgt.Text });
                }
            }

            if (!isequer)
            {
                WebMsg.MessageBox("请保持客户一致，进行发运单制作！");

            }
            else
            {
                Session[ltluserID.Text] = dt;

                if (dt.Rows.Count > 0)
                {
                    Response.Write("<script>window.parent.document.getElementById('imgbtnJz').click();window.parent.close();</script>");
                }
            }

        }
    }
}