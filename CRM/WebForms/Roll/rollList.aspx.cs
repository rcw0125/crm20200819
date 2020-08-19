using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using NF.BLL;
using NF.Framework;
using NF.MODEL;
using System.Data;

namespace CRM.WebForms.Roll
{
    public partial class rollList : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();

        private Bll_TMC_ROLL_APPLY_ITEM tmc_roll_apply_item = new Bll_TMC_ROLL_APPLY_ITEM();

        private Bll_TS_USER ts_user = new Bll_TS_USER();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetArea();

                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    ltlID.Text = Request.QueryString["ID"];
                }

               
            }
        }

        private void GetArea()
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
            }
            else
            {

                dropneedarea.DataSource = null;
                dropneedarea.DataBind();
            }
            #endregion

            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

            string dept = ts_user.GetDept(vUser.Account);

            dropneedarea.SelectedIndex = dropneedarea.Items.IndexOf(dropneedarea.Items.FindByText(dept));


            #region //线材库区域

            DataTable dtxcarea = tmo_order.GetXCAREA().Tables[0];
            if (dtxcarea.Rows.Count > 0)
            {
                dropsalearea.DataSource = dtxcarea;
                dropsalearea.DataTextField = "C_SALE_AREA";
                dropsalearea.DataValueField = "C_SALE_AREA";
                dropsalearea.DataBind();
                dropsalearea.Items.Insert(0, new ListItem("全部区域", "-1"));//
            }
            else
            {
                dropsalearea.DataSource = null;
                dropsalearea.DataBind();

            }
            #endregion

            #region //质量
            DataTable dtzl = tmo_order.GetXC_JUDGE_LEV_ZH("").Tables[0];
            if (dtzl.Rows.Count > 0)
            {
                dropzldj.DataSource = dtzl;
                dropzldj.DataTextField = "C_JUDGE_LEV_ZH";
                dropzldj.DataValueField = "C_JUDGE_LEV_ZH";
                dropzldj.DataBind();
                dropzldj.Items.Insert(0, new ListItem("全部质量", ""));
            }
            #endregion
        }

        private void GetList()
        {
            DataTable dt = trc_roll_prodcut.GetRollProdcut2_top(txtbatchno.Text, "", txtstlgrd.Text, txtspec.Text, txtmatcode.Text, dropzldj.SelectedItem.Value, dropsalearea.SelectedItem.Value, txtcustname.Text, "", "", txtcon.Text, txtrow.Text).Tables[0];
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {


                bool result = false;

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                    if (cbxselect.Checked)
                    {
                        Literal ltlsalearea = (Literal)rptList.Items[i].FindControl("ltlsalearea");
                        Literal ltlbatch = (Literal)rptList.Items[i].FindControl("ltlbatch");
                        Literal ltlstlgrd = (Literal)rptList.Items[i].FindControl("ltlstlgrd");
                        Literal ltlspec = (Literal)rptList.Items[i].FindControl("ltlspec");
                        Literal ltlN_WGT = (Literal)rptList.Items[i].FindControl("ltlN_WGT");
                        Literal ltllev = (Literal)rptList.Items[i].FindControl("ltllev");
                        Literal ltlpack = (Literal)rptList.Items[i].FindControl("ltlpack");
                        Literal ltlmatcode = (Literal)rptList.Items[i].FindControl("ltlmatcode");
                        Literal ltlC_CUST_NAME = (Literal)rptList.Items[i].FindControl("ltlC_CUST_NAME");
                        Literal ltlstdcode = (Literal)rptList.Items[i].FindControl("ltlstdcode");
                        Literal ltlC_CON_NO = (Literal)rptList.Items[i].FindControl("ltlC_CON_NO");

                        var mod = new Mod_TMC_ROLL_APPLY_ITEM()
                        {
                            C_ID = Guid.NewGuid().ToString("N"),
                            C_PKID = ltlID.Text,
                            C_NEEDAREA = dropneedarea.SelectedValue,//需求区域
                            C_NEEDCUST = txtC_CGC.Value.Trim() == "" ? ltlC_CUST_NAME.Text : txtC_CGC.Value.Trim(),//需求客户
                            C_QUA = txtNeedCon.Text.Trim() == "" ? ltlC_CON_NO.Text : txtNeedCon.Text.Trim(),//需求合同
                            C_ZYAREA = ltlsalearea.Text,//原资源区域
                            C_ZYCUST = ltlC_CUST_NAME.Text,//原资源客户信息
                            C_SPEC = ltlspec.Text,
                            C_STL_GRD = ltlstlgrd.Text,
                            C_WGT = Convert.ToDecimal(ltlN_WGT.Text),
                            C_VFREE1 = ltlbatch.Text,//批次
                            C_VFREE2 = ltlmatcode.Text,//物料编码
                            C_VFREE3 = cbxselect.Value,//线材主键
                            C_VFREE4 = ltlpack.Text,//包装
                            C_VFREE5 = ltllev.Text,//质量
                            C_REMARK = ltlstdcode.Text,//执行标准
                            C_ZYCON = ltlC_CON_NO.Text//原资源合同

                        };
                        result = tmc_roll_apply_item.Add(mod);
                    }
                }

                if (result)
                {
                    Response.Write("<script>window.parent.document.getElementById('imgbtnJz').click();window.parent.close();</script>");
                }

            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }
    }
}