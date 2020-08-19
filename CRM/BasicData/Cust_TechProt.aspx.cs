using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.Unity;

using System.Data;
using NF.BLL;
using NF.MODEL;
using NF.Framework;
using NF.Bussiness.Interface;
using NF.Web.Core;
using NF.EF.Model;

namespace CRM.BasicData
{
    public partial class Cust_TechProt : System.Web.UI.Page
    {
        private Bll_TB_STD_CONFIG tb_std_config = new Bll_TB_STD_CONFIG();

        IComService buttonService = DIFactory.GetContainer().Resolve<IComService>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    GetFun();//加载按钮权限

                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }

        private void GetFun()
        {
            var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (user != null)
            {
                buttonService.RefreshButton("/BasicData/Cust_TechProt.aspx", user, Session);
                List<TS_BUTTON> button = (List<TS_BUTTON>)Session["button"];

                foreach (var item in button)
                {
                    if (Page.FindControl(item.C_CODE) != null)
                    {
                        Page.FindControl(item.C_CODE).Visible = true;
                    }
                }
            }
            else
            {
                WebMsg.CheckUserLogin();
            }
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="mod"></param>
        private void GetListBind()
        {

            DataTable dt = tb_std_config.GetList(txtcustno.Text, txtcustname.Text, txtstlgrd.Text, txttech_prot.Text, txtstd.Text).Tables[0];
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


        //停用
        protected void Button3_Click(object sender, EventArgs e)
        {
            List<string> listID = new List<string>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                if (cbxselect.Checked)
                {
                    listID.Add(cbxselect.Value);
                }
            }
            if (tb_std_config.UpdateStatus(listID, 0))
            {
                WebMsg.MessageBox("提交成功");
            }
            else
            {
                WebMsg.MessageBox("提交失败");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetListBind();
        }

        //客户协议标记
        protected void btnflag_Click(object sender, EventArgs e)
        {
            try
            {
                List<Mod_TB_STD_CONFIG> list = new List<Mod_TB_STD_CONFIG>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                    Literal ltlflag = (Literal)rptList.Items[i].FindControl("ltlflag");

                    if (cbxselect.Checked)
                    {
                        Mod_TB_STD_CONFIG mod = new Mod_TB_STD_CONFIG();
                        mod.C_ID = cbxselect.Value;
                        mod.C_FLAG = ltlflag.Text == "N" ? "Y" : "N";
                        list.Add(mod);
                    }
                }
                if (tb_std_config.UpdateFlag(list))
                {
                    WebMsg.MessageBox("设置成功");
                    GetListBind();
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}