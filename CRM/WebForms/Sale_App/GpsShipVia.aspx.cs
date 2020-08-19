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
using NF.Framework;
using NF.MODEL;

namespace CRM.Sale_App
{
    public partial class GpsShipVia : System.Web.UI.Page
    {
        private Bll_TS_DIC dic = new Bll_TS_DIC();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private Bll_GPS bll_gps = new Bll_GPS();

        private Bll_TMB_AREA tmb_area = new Bll_TMB_AREA();
        private Bll_TMB_AREAMAX tmb_areamax = new Bll_TMB_AREAMAX();
        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();

        private static DataTable areaData = new DataTable();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    BindData();//发运方式
                    BindArea();//区域
                    BindCust();//客户
                    BindStlGrd();//钢种

                }
                catch (Exception ex)
                {
                    WebMsg.MessageBox(ex.Message);
                }

            }
        }

        #region //发运方式


        //加载数据
        private void BindData()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ShipVia";
            DataTable dt = dic.GetList(mod).Tables[0];
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

        //是否下发审核
        protected void btnNo_Click(object sender, EventArgs e)
        {

            List<Mod_TS_DIC> list = new List<Mod_TS_DIC>();

            foreach (RepeaterItem item in rptList.Items)
            {
                HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)item.FindControl("chkSelect");
                Literal ltlnextcheck = (Literal)item.FindControl("ltlnextcheck");

                if (chkSelect.Checked)
                {
                    Mod_TS_DIC mod = new Mod_TS_DIC();
                    mod.C_ID = chkSelect.Value;
                    mod.C_EXTEND2 = ltlnextcheck.Text == "N" ? "Y" : "N";
                    list.Add(mod);
                }
            }
            if (dic.UpdateAreaCust(list))
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('设置成功')", true);
                //WebMsg.MessageBox("设置成功");
                BindData();
            }
        }

        //发运方式GPS控制
        protected void btnOk_Click(object sender, EventArgs e)
        {
           

            List<Mod_TS_DIC> list = new List<Mod_TS_DIC>();

            foreach (RepeaterItem item in rptList.Items)
            {
                HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)item.FindControl("chkSelect");
                Literal ltlgps = (Literal)item.FindControl("ltlfygps");

                if (chkSelect.Checked)
                {
                    Mod_TS_DIC mod = new Mod_TS_DIC();
                    mod.C_ID = chkSelect.Value;
                    mod.N_ISGPS = Convert.ToDecimal(ltlgps.Text == "N" ? "1" : "0");
                    list.Add(mod);
                }
            }
            if (dic.UpdateAreaGPS(list))
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('设置成功')", true);
                //WebMsg.MessageBox("设置成功");
                BindData();
            }
        }
        #endregion

        #region //客户


        private void BindCust()
        {
            StringBuilder where = new StringBuilder();

            where.Append(" 1=1");
            if (!string.IsNullOrEmpty(txtCustCode.Value))
            {
                where.AppendFormat(" AND  C_NO='{0}'", txtCustCode.Value);
            }
            if (!string.IsNullOrEmpty(txtCustCode.Value))
            {
                where.AppendFormat(" AND  C_NAME LIKE '%{0}%'", txtCustName.Value);
            }

            DataTable dt = ts_custfile.GetList(where.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptCust.DataSource = dt;
                rptCust.DataBind();
            }
            else
            {
                rptCust.DataSource = null;
                rptCust.DataBind();
            }
        }




        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindCust();
        }


        protected void btnOk2_Click(object sender, EventArgs e)
        {
            string idList = "";

            foreach (RepeaterItem item in rptCust.Items)
            {
                HtmlInputCheckBox chkSelect2 = (HtmlInputCheckBox)item.FindControl("chkSelect2");
                if (chkSelect2.Checked)
                {
                    idList += "'" + chkSelect2.Value + "',";
                }
            }
            if (!string.IsNullOrEmpty(idList))
            {
                idList = idList.Substring(0, idList.Length - 1);
                if (bll_gps.UpdateGPS(1, idList, "TS_CUSTFILE"))
                {
                    //WebMsg.MessageBox("设置成功");
                    BindCust();
                }
            }
        }

        protected void btnNo2_Click(object sender, EventArgs e)
        {
            string idList = "";

            foreach (RepeaterItem item in rptCust.Items)
            {
                HtmlInputCheckBox chkSelect2 = (HtmlInputCheckBox)item.FindControl("chkSelect2");
                if (chkSelect2.Checked)
                {
                    idList += "'" + chkSelect2.Value + "',";
                }
            }
            if (!string.IsNullOrEmpty(idList))
            {
                idList = idList.Substring(0, idList.Length - 1);
                if (bll_gps.UpdateGPS(0, idList, "TS_CUSTFILE"))
                {
                    // WebMsg.MessageBox("设置成功");
                    BindCust();
                }
            }
        }

        #endregion

        #region //区域


        private void BindArea()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ConArea";
            DataTable dt = dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptArea.DataSource = dt;
                rptArea.DataBind();
            }
            else
            {
                rptArea.DataSource = null;
                rptArea.DataBind();
            }
        }

        //区域GPS控制
        protected void btnOk4_Click(object sender, EventArgs e)
        {
            List<Mod_TS_DIC> list = new List<Mod_TS_DIC>();

            foreach (RepeaterItem item in rptArea.Items)
            {
                HtmlInputCheckBox chkSelect4 = (HtmlInputCheckBox)item.FindControl("chkSelect4");
                Literal ltlgps = (Literal)item.FindControl("ltlgps");

                if (chkSelect4.Checked)
                {
                    Mod_TS_DIC mod = new Mod_TS_DIC();
                    mod.C_ID = chkSelect4.Value;
                    mod.N_ISGPS = Convert.ToDecimal(ltlgps.Text == "N" ? "1" : "0");
                    list.Add(mod);
                }
            }
            if(dic.UpdateAreaGPS(list))
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('设置成功')", true);
                //WebMsg.MessageBox("设置成功");
                BindArea();
            } 
        }
        //区域按客户控制发运
        protected void btnNo4_Click(object sender, EventArgs e)
        {
            List<Mod_TS_DIC> list = new List<Mod_TS_DIC>();

            foreach (RepeaterItem item in rptArea.Items)
            {
                HtmlInputCheckBox chkSelect4 = (HtmlInputCheckBox)item.FindControl("chkSelect4");
                Literal ltlcust = (Literal)item.FindControl("ltlcust");

                if (chkSelect4.Checked)
                {
                    Mod_TS_DIC mod = new Mod_TS_DIC();
                    mod.C_ID = chkSelect4.Value;
                    mod.C_EXTEND2 = ltlcust.Text == "N" ? "Y" : "N";
                    list.Add(mod);
                }
            }
            if (dic.UpdateAreaCust(list))
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('设置成功')", true);
                //WebMsg.MessageBox("设置成功");
                BindArea();
            }
        }
        #endregion

        #region//钢种


        private void BindStlGrd()
        {
            Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();

            DataTable dt = tmo_order.GetStl_Gps(txtGRD.Value).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptMat.DataSource = dt;
                rptMat.DataBind();
            }
            else
            {
                rptMat.DataSource = null;
                rptMat.DataBind();
            }
        }


        protected void btnSearch2_Click(object sender, EventArgs e)
        {
            BindStlGrd();
        }


        protected void btnOk3_Click(object sender, EventArgs e)
        {
            string idList = "";

            foreach (RepeaterItem item in rptMat.Items)
            {
                HtmlInputCheckBox chkSelect3 = (HtmlInputCheckBox)item.FindControl("chkSelect3");
                if (chkSelect3.Checked)
                {
                    idList += "'" + chkSelect3.Value + "',";
                }
            }
            if (!string.IsNullOrEmpty(idList))
            {
                idList = idList.Substring(0, idList.Length - 1);
                if (bll_gps.UpdateGPS(1, idList, "TB_MATRL_MAIN"))
                {
                    //WebMsg.MessageBox("设置成功");
                    BindStlGrd();
                }
            }
        }

        protected void btnNo3_Click(object sender, EventArgs e)
        {
            string idList = "";

            foreach (RepeaterItem item in rptMat.Items)
            {
                HtmlInputCheckBox chkSelect3 = (HtmlInputCheckBox)item.FindControl("chkSelect3");
                if (chkSelect3.Checked)
                {
                    idList += "'" + chkSelect3.Value + "',";
                }
            }
            if (!string.IsNullOrEmpty(idList))
            {
                idList = idList.Substring(0, idList.Length - 1);
                if (bll_gps.UpdateStlGrd(0, idList, "TB_MATRL_MAIN"))
                {
                    //WebMsg.MessageBox("设置成功");
                    BindStlGrd();
                }
            }
        }

        #endregion

    }
}