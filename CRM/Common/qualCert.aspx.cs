using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.BLL;
using NF.MODEL;
using System.Data;

namespace CRM.Common
{
    public partial class qualCert : System.Web.UI.Page
    {
        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["fyd"]) && !string.IsNullOrEmpty(Request.QueryString["zsh"]))
                {
                    DataTable dt = trc_roll_prodcut.GetZZSList(Request.QueryString["fyd"], Request.QueryString["zsh"]).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        ltlzsh.Text = dt.Rows[0]["C_ZSH"].ToString();
                        ltlch.Text = dt.Rows[0]["C_CH"].ToString();
                        ltlqua.Text = dt.Rows[0]["N_NUM"].ToString();
                        ltlwgt.Text = dt.Rows[0]["N_JZ"].ToString();
                        ltlkzrq.Text = dt.Rows[0]["D_QZRQ"].ToString();
                        ltlcustname.Text = dt.Rows[0]["C_CUST_NAME"].ToString();
                        ltlshcust.Text = dt.Rows[0]["C_SH_NAME"].ToString();
                        ltlmatname.Text = dt.Rows[0]["C_MAT_NAME"].ToString();
                        ltlstlgrd.Text = dt.Rows[0]["C_STL_GRD"].ToString();
                        ltlbatch.Text = dt.Rows[0]["C_BATCH_NO"].ToString();
                        ltljhstd.Text = dt.Rows[0]["C_STD_JH"].ToString();
                        ltlstove.Text = dt.Rows[0]["C_STOVE"].ToString();
                        ltlspec.Text = dt.Rows[0]["C_SPEC"].ToString();
                        ltldj.Text = dt.Rows[0]["C_ZLDJ"].ToString();
                        ltljhstate.Text = dt.Rows[0]["C_JH_STATE"].ToString();

                    }
                }
            }
        }
    }
}