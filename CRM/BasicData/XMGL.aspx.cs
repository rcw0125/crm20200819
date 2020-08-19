using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.BLL;
using NF.MODEL;
using NF.Framework;

namespace CRM.BasicData
{
    public partial class XMGL : System.Web.UI.Page
    {
        private Bll_TMC_CUSTGIVEMARK tmc_custgivemark = new Bll_TMC_CUSTGIVEMARK();
        private Bll_TMC_GIVEMARK_ITEM tmc_givemark_item = new Bll_TMC_GIVEMARK_ITEM();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page .IsPostBack)
            {
                GetClass();
                GetList();
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
        /// 分类
        /// </summary>
        private void GetClass()
        {

            DataTable dt = GetData("GiveMark");
            if (dt.Rows.Count > 0)
            {

                dropclass.DataSource = dt;
                dropclass.DataTextField = "C_DETAILNAME";
                dropclass.DataValueField = "C_DETAILNAME";
                dropclass.DataBind();
            }
            else
            {
                dropclass.DataSource = null;
                dropclass.DataBind();
            }
        }


        private void GetList()
        {
            DataTable dt = tmc_givemark_item.GetList("").Tables[0];
            if(dt.Rows.Count>0)
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Mod_TMC_GIVEMARK_ITEM mod = new Mod_TMC_GIVEMARK_ITEM();
            mod.C_NAME = txtname.Text;
            if(!string .IsNullOrEmpty(txtscroe.Text))
            {
                mod.N_SCORE = Convert.ToDecimal(txtscroe.Text);
            }
            mod.C_FLAG = dropclass.SelectedItem.Text;
            if(tmc_givemark_item.Add(mod))
            {
                WebMsg.MessageBox("添加成功");
                GetList();
            }            
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            TextBox txtname =(TextBox) e.Item.FindControl("txtname");
            TextBox txtscore = (TextBox)e.Item.FindControl("txtscore");
            DropDownList dropclass = (DropDownList)e.Item.FindControl("dropclass");

            string ID = e.CommandArgument.ToString();

            if (e.CommandName=="save")
            {
                Mod_TMC_GIVEMARK_ITEM mod = tmc_givemark_item.GetModel(ID);
                mod.C_NAME = txtname.Text;
                mod.C_FLAG = dropclass.SelectedItem.Text;
                if (!string.IsNullOrEmpty(txtscroe.Text))
                {
                    mod.N_SCORE = Convert.ToDecimal(txtscroe.Text);
                }
                if(tmc_givemark_item.Update(mod))
                {
                    WebMsg.MessageBox("保存成功");
                    GetList();
                }
            }
            if(e.CommandName=="del")
            {
                if(tmc_givemark_item.Delete(ID))
                {
                    WebMsg.MessageBox("删除成功");
                    GetList();
                }
            }
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DropDownList dropclass =(DropDownList) e.Item.FindControl("dropclass");
            Literal ltlclass = (Literal)e.Item.FindControl("ltlclass");
            DataTable dt = GetData("GiveMark");
            if (dt.Rows.Count > 0)
            {
                dropclass.DataSource = dt;
                dropclass.DataTextField = "C_DETAILNAME";
                dropclass.DataValueField = "C_DETAILNAME";
                dropclass.DataBind();
                dropclass.SelectedIndex = dropclass.Items.IndexOf(dropclass.Items.FindByText(ltlclass.Text));
            }
        }
    }
}