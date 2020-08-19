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
    public partial class addrList : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TMB_NCADDRESS_COST tmb_ncaddress_cost = new Bll_TMB_NCADDRESS_COST();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetDic();
            }
        }

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
                dropfyfs.DataValueField = "C_DETAILNAME";
                dropfyfs.DataBind();
                dropfyfs.Items.Insert(0, new ListItem("全部", ""));
            }
            else
            {
                dropfyfs.DataSource = null;
                dropfyfs.DataBind();
            }
            #endregion

        }

        private void BindList()
        {
            DataTable dt = tmb_ncaddress_cost.GetList(dropfyfs.SelectedValue, txtaddr.Text).Tables[0];
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
            BindList();
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

                var list = new List<Mod_TMB_NCADDRESS_COST>();
               
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                    if (cbxselect.Checked)
                    {
                        var mod = new Mod_TMB_NCADDRESS_COST() {
                            C_ID=cbxselect.Value,
                            C_EMP=vUser?.Name
                        };
                        list.Add(mod);
                       
                    }
                }
                if(tmb_ncaddress_cost.Del(list))
                {
                    BindList();
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

                var list = new List<Mod_TMB_NCADDRESS_COST>();


                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                    TextBox txtprice = (TextBox)rptList.Items[i].FindControl("txtprice");
                    HtmlInputText txtStart = (HtmlInputText)rptList.Items[i].FindControl("txtStart");
                    HtmlInputText txtEnd = (HtmlInputText)rptList.Items[i].FindControl("txtEnd");
                    Literal ltlC_FAYUN = (Literal)rptList.Items[i].FindControl("ltlC_FAYUN");
                    Literal ltlC_ADDRNAME = (Literal)rptList.Items[i].FindControl("ltlC_ADDRNAME");

                    if (cbxselect.Checked)
                    {
                        var mod = new Mod_TMB_NCADDRESS_COST()
                        {
                            C_ID = cbxselect.Value,
                            C_FAYUN= ltlC_FAYUN.Text,
                            C_ADDRNAME=ltlC_ADDRNAME.Text,
                            N_PRICE =Convert .ToDecimal(txtprice.Text),
                            D_START_DT=Convert.ToDateTime(txtStart.Value),
                            D_END_DT=Convert .ToDateTime(txtEnd.Value),
                            C_CREATE_EMP=vUser?.Name
                            
                        };
                        list.Add(mod);

                    }
                }
                if (tmb_ncaddress_cost.UpdateList(list))
                {
                    WebMsg.MessageBox("保存成功");
                    BindList();
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }

        protected void imgbtnJz_Click(object sender, ImageClickEventArgs e)
        {
            BindList();
        }
    }
}