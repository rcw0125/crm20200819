using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Data;

using NF.MODEL;
using NF.BLL;
using NF.Framework;

namespace CRM.Sale_App
{
    public partial class _Roll_Product : System.Web.UI.Page
    {
        Bll_TMO_CONDETAILS tmo_condetails = new Bll_TMO_CONDETAILS();
        Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();
        Bll_TMO_ORDER_MATCH tmo_order_match = new Bll_TMO_ORDER_MATCH();
        Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    ltlCustID.Text = BaseUser.CustId;

                    if (string.IsNullOrEmpty(Request.QueryString["orderNo"]))
                    {

                        ltlOrderNo.Text = Request.QueryString["orderNo"];

                        GetList();
                    }
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }

        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        private void GetList()
        {
            Mod_TMO_CONDETAILS mod = tmo_condetails.GetModel(ltlOrderNo.Text);
            if (mod != null)
            {
                ltlConNo.Text = mod.C_CON_NO;
                ltlType.Text = mod.N_TYPE.ToString();

                DataTable dt = trc_roll_prodcut.GetRollProdcut(mod.C_STL_GRD, mod.C_SPEC, mod.C_STD_CODE, mod.C_AREA).Tables[0];
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
        }


        /// <summary>
        /// 提交
        /// </summary>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool result = false;
            decimal wgt = 0;
            foreach (RepeaterItem rpt in rptList.Items)
            {
                HtmlInputCheckBox chkID = (HtmlInputCheckBox)rpt.FindControl("chkID");
                Literal OrderNo = (Literal)rpt.FindControl("ltlOrderNo");
                Literal ltlWGT = (Literal)rpt.FindControl("ltlWGT");
                if (chkID.Checked)
                {
                    wgt += Convert.ToDecimal(ltlWGT.Text);

                    Mod_TMO_ORDER_MATCH mod = new Mod_TMO_ORDER_MATCH();
                    mod.C_ORDER_NO = ltlOrderNo.Text;
                    mod.C_MATCH_ID = chkID.Value;
                    mod.C_OLD_ORDER_NO = OrderNo.Text;
                    mod.C_TYPE = Convert.ToDecimal(ltlType.Text);
                    if (tmo_order_match.Add(mod))//记录
                    {


                        Mod_TS_CUSTFILE modCust = ts_custfile.GetModel(ltlCustID.Text);

                        if (trc_roll_prodcut.UpdateMatch(chkID.Value, ltlOrderNo.Text, ltlConNo.Text, modCust.C_NO, modCust.C_NAME, "N"))//更新线材自由状态
                        {
                            result = true;
                        }
                    }
                }
            }
            if(result)
            {
                //更新订单匹配量
                if(tmo_condetails.UpdateMatch(wgt,ltlOrderNo.Text,Convert .ToInt32(ltlType.Text)))
                {
                    WebMsg.MessageBox("提交成功");
                    GetList();
                }
            }
        }
    }
}