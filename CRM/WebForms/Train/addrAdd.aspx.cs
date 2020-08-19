using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Data;
using NF.BLL;
using NF.Framework;
using NF.MODEL;

namespace CRM.WebForms.Train
{
    public partial class addrAdd : System.Web.UI.Page
    {
        private Bll_TMB_AREA tmb_area = new Bll_TMB_AREA();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TMB_NCADDRESS_COST tmb_ncaddress_cost = new Bll_TMB_NCADDRESS_COST();


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
        /// 基础数据
        /// </summary>
        private void GetDic()
        {
            #region//发运方式
            DataTable dt = GetData("ShipVia");
            if (dt.Rows.Count > 0)
            {

                dropfyfs.DataSource = dt;
                dropfyfs.DataTextField = "C_DETAILNAME";
                dropfyfs.DataValueField = "C_DETAILCODE";
                dropfyfs.DataBind();
            }
            else
            {
                dropfyfs.DataSource = null;
                dropfyfs.DataBind();
            }
            #endregion

           

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtEnd.Value = DateTime.Now.ToString("yyy-MM-dd");
                GetDic();

                BindList();


            }
        }

        private void BindList()
        {
            DataTable dt = tmb_area.GetAddrList(txtcode.Text, txtname.Text).Tables[0];
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


        protected void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                bool res = true;
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

                var list = new List<Mod_TMB_NCADDRESS_COST>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {

                    HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                    Literal ltlADDRCODE = (Literal)rptList.Items[i].FindControl("ltlADDRCODE");
                    Literal ltlADDRNAME = (Literal)rptList.Items[i].FindControl("ltlADDRNAME");
                    Literal ltlPK_AREACL = (Literal)rptList.Items[i].FindControl("ltlPK_AREACL");

                    if (cbxselect.Checked)
                    {
                        var mod = new Mod_TMB_NCADDRESS_COST()
                        {
                           
                            C_FAYUN = dropfyfs.SelectedItem.Text,
                            N_PRICE = Convert.ToDecimal(txtprice.Text == "" ? "0" : txtprice.Text),
                            D_START_DT = Convert.ToDateTime(txtStart.Value),
                            D_END_DT = Convert.ToDateTime(txtEnd.Value),
                            C_ADDRNAME = ltlADDRNAME.Text,
                            C_ADDRCODE = ltlADDRCODE.Text,
                            C_ADDR_NCPK = cbxselect.Value,
                            C_AREA_PK = ltlPK_AREACL.Text,
                            C_CREATE_EMP = vUser?.Name,
                            C_EMP=vUser?.Name,
                            D_EMP=DateTime.Now
                        };

                        if (!tmb_ncaddress_cost.Exists( mod.C_FAYUN, mod.C_ADDRNAME))
                        {
                            list.Add(mod);
                        }
                        else
                        {
                            res = false;
                            string msg = mod.C_ADDRNAME + "，该地点已存在";
                            WebMsg.MessageBox(msg);
                            break;
                        }
                    }
                }
                if (res)
                {
                    if (list.Count > 0)
                    {
                        tmb_ncaddress_cost.Add(list);
                        Response.Write("<script>window.parent.document.getElementById('imgbtnJz').click();window.parent.close();</script>");
                    }
                }

            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }

        protected void btncx_Click(object sender, EventArgs e)
        {
            BindList();
        }
    }
}