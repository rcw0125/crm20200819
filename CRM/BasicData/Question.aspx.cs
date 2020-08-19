using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using NF.MODEL;
using NF.BLL;
using NF.Framework;

namespace CRM.BasicData
{
    public partial class Question : System.Web.UI.Page
    {
        private Bll_TMC_QUESTION question = new Bll_TMC_QUESTION();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetList();
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        private void GetList()
        {
            DataTable dt = question.GetQuestionList("").Tables[0];
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {


                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    if (!string.IsNullOrEmpty(ltlID.Text))
                    {
                        //修改
                        Mod_TMC_QUESTION mod = question.GetModel(ltlID.Text);
                        if (mod != null)
                        {
                            mod.C_NAME = txtName.Text;
                            if (question.Update(mod))
                            {
                                WebMsg.MessageBox("保存成功");
                                ltlID.Text = string.Empty;
                                txtName.Text = string.Empty;
                                GetList();
                            }
                        }
                    }
                    else //添加
                    {
                        Mod_TMC_QUESTION mod = new Mod_TMC_QUESTION();
                        mod.C_NAME = txtName.Text;
                        var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                        if (BaseUser != null)
                        {
                            mod.C_EMP_ID = BaseUser.Id;
                            mod.C_EMP_NAME = BaseUser.Name;
                        }
                        if (question.Add(mod))
                        {
                            WebMsg.MessageBox("保存成功！");
                            txtName.Text = string.Empty;
                            GetList();
                        }
                    }
                }
                else
                {
                    WebMsg.MessageBox("名称不能为空!");
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {


                string id = e.CommandArgument.ToString();
                if (e.CommandName == "edit")//修改
                {
                    ltlID.Text = id;
                    Literal ltlName = (Literal)e.Item.FindControl("ltlName");
                    txtName.Text = ltlName.Text;
                }

                if (e.CommandName == "del")//删除
                {
                    if (question.Delete(id))
                    {
                        GetList();
                    }
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}