using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;

using NF.BLL;
using NF.MODEL;
using NF.Framework;
using System.Web.Services;
using Newtonsoft.Json;

namespace CRM.WebForms.Cust_App
{
    public partial class MatList5 : System.Web.UI.Page
    {
        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["custno"]) || !string.IsNullOrEmpty(Request.QueryString["stlgrd"]))
                {
                    ltlCustNo.Text = Request.QueryString["custno"];
                    GetMenu();
                }

            }
        }

        #region  菜单

        private void GetMenu()
        {
            StringBuilder strMenu = new StringBuilder();

            DataTable dt = tb_matrl_main.Get_PROD_KIND(ltlCustNo.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                strMenu.Append("<ul>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string guid = Guid.NewGuid().ToString("N");
                    strMenu.AppendFormat("<li class=\"folder\"><a  data-toggle=\"collapse\" data-parent=\"#accordion\"  href = \"#{0}\" >{1}</a></li>", guid, dt.Rows[i]["C_PROD_KIND"].ToString());
                    GetMenu2(dt.Rows[i]["C_PROD_KIND"].ToString(), strMenu, guid);

                }
                strMenu.Append("</ul>");
            }
            ltlmenu.Text = strMenu.ToString();

        }

        private void GetMenu2(string C_PROD_KIND, StringBuilder strMenu, string index)
        {
            DataTable dt = tb_matrl_main.Get_PROD_NAME(ltlCustNo.Text, C_PROD_KIND).Tables[0];
            if (dt.Rows.Count > 0)
            {
                strMenu.AppendFormat("<ul class=\"collapse\" id=\"{0}\">", index);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string guid = Guid.NewGuid().ToString("N");
                    strMenu.AppendFormat("<li class=\"folder\"><a data-toggle=\"collapse\" data-parent=\"#accordion\"  href = \"#{0}\">{1}</a></li>", guid, dt.Rows[i]["C_PROD_NAME"].ToString());
                    GetMenu3(C_PROD_KIND, dt.Rows[i]["C_PROD_NAME"].ToString(), strMenu, guid);
                }
                strMenu.Append("</ul>");
            }
        }

        private void GetMenu3(string C_PROD_KIND, string C_PROD_NAME, StringBuilder strMenu, string index)
        {
            DataTable dt = tb_matrl_main.Get_PROD_NAME_StlGrd(ltlCustNo.Text, C_PROD_KIND, C_PROD_NAME).Tables[0];
            if (dt.Rows.Count > 0)
            {
                strMenu.AppendFormat("<ul class=\"collapse\" id=\"{0}\">", index);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strMenu.AppendFormat("<li><a  href=\"MatList4.aspx?custno={0}&stlgrd={1}&prockind=" + Server.UrlEncode(C_PROD_KIND) + "&procname=" +Server.UrlEncode(C_PROD_NAME) + "\"  target=\"right\">{1}</a></li>", ltlCustNo.Text, dt.Rows[i]["C_STL_GRD"].ToString());
                }
                strMenu.Append("</ul>");
            }
        }

        #endregion



    }
}