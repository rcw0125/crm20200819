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
using NF.Bussiness.Interface;
using NF.Web.Core;
using Microsoft.Practices.Unity;
using NF.EF.Model;

namespace CRM.BasicData
{
    public partial class Activity : System.Web.UI.Page
    {

        private Bll_TMB_ACTIVITY tmb_activity = new Bll_TMB_ACTIVITY();

        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();

        private static DataTable activityData = new DataTable();

        private Bll_TMB_AREAMAX tmb_areamax = new Bll_TMB_AREAMAX();

        IComService buttonService = DIFactory.GetContainer().Resolve<IComService>();

        private static DataTable matData = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                    if (BaseUser != null)
                    {
                        GetFun();//加载按钮权限

                        DateTime dt = DateTime.Now;
                        Start.Value = Convert.ToDateTime(dt).ToString("yyy-MM-dd");
                        End.Value = dt.AddMonths(1).AddDays(-(dt.Day)).ToString("yyy-MM-dd");

                        GetArea();
                        GetMat();
                        ltlC_EMP_ID.Text = BaseUser.Id;
                        ltlC_EMP_NAME.Text = BaseUser.Name;

                    }
                    else
                    {
                        WebMsg.CheckUserLogin();
                    }
                }
                catch (Exception ex)
                {
                    WebMsg.MessageBox(ex.Message);
                }
            }
        }


        private void GetFun()
        {
            var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (user != null)
            {
                buttonService.RefreshButton(Request.RawUrl, user, Session);
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


        #region //物料分类

        protected void trv_menu_SelectedNodeChanged(object sender, EventArgs e)
        {
            ltlC_PROD_NAME.Text = trv_menu.SelectedNode.Text;
            ltlgroupCode.Text= trv_menu.SelectedNode.Value; 
            GetMatList();
        }

        private void GetMat()
        {
            matData = tb_matrl_main.GetMatrlGroup().Tables[0];
            trv_menu.Nodes.Clear();

            bindtree("1"); //传入第-1个parent_ID开始遍历根节点

        }
        /// <summary>
        /// 查找根节点(parent_ID为0的节点)的子节点
        /// </summary>
        /// <param name="LEV">参数，接收根节点ID</param>
        private void bindtree(string LEV)
        {

            DataRow[] row = matData.Select("N_LEV='" + LEV + "'", "C_MAT_GROUP_CODE desc");
            //添加根目录
            for (int i = 0; i < row.Length; i++)
            {
                //这是在找数据库中的节点
                TreeNode node = new TreeNode(row[i]["C_MAT_GROUP_NAME"].ToString().Trim(), row[i]["C_MAT_GROUP_CODE"].ToString());
                this.trv_menu.Nodes.Add(node);//把指定节点添加到控件中
                bindnode(node);//遍历子节点
            }
        }

        /// <summary>
        /// 递归遍历指定节点下的子节点
        /// </summary>
        /// <param name="nd">参数，接收节点对象</param>
        private void bindnode(TreeNode nd)
        {

            DataRow[] row = matData.Select("C_MAT_GROUP_CODE like '" + nd.Value + "%' and N_LEV='2'", "C_MAT_GROUP_CODE asc");
            //添加根目录
            for (int i = 0; i < row.Length; i++)
            {
                TreeNode node = new TreeNode();
                node.Text = row[i]["C_MAT_GROUP_NAME"].ToString();
                node.Value = row[i]["C_MAT_GROUP_CODE"].ToString();
                nd.ChildNodes.Add(node);//把指定节点添加到控件中
                nd.Expand();
                bindnode3(node);
            }
        }

        /// <summary>
        /// 递归遍历指定节点下的子节点
        /// </summary>
        /// <param name="nd">参数，接收节点对象</param>
        private void bindnode3(TreeNode nd)
        {

            DataRow[] row = matData.Select("C_MAT_GROUP_CODE like '" + nd.Value + "%' and N_LEV='3'", "C_MAT_GROUP_CODE asc");
            //添加根目录
            for (int i = 0; i < row.Length; i++)
            {
                TreeNode node = new TreeNode();
                node.Text = row[i]["C_MAT_GROUP_NAME"].ToString();
                node.Value = row[i]["C_MAT_GROUP_CODE"].ToString();
                nd.ChildNodes.Add(node);//把指定节点添加到控件中
                trv_menu.CollapseAll();
                bindnode4(node);
            }
        }

        /// <summary>
        /// 递归遍历指定节点下的子节点
        /// </summary>
        /// <param name="nd">参数，接收节点对象</param>
        private void bindnode4(TreeNode nd)
        {
            DataRow[] row = matData.Select("C_MAT_GROUP_CODE like '" + nd.Value + "%' and N_LEV='4'", "C_MAT_GROUP_CODE asc");
            //添加根目录
            for (int i = 0; i < row.Length; i++)
            {
                TreeNode node = new TreeNode();
                node.Text = row[i]["C_MAT_GROUP_NAME"].ToString();
                node.Value = row[i]["C_MAT_GROUP_CODE"].ToString();
                nd.ChildNodes.Add(node);//把指定节点添加到控件中
                trv_menu.CollapseAll();
                //bindnode(node);
            }
        }



        #endregion

        private void GetArea()
        {

            DataTable dtArea = tmb_areamax.GetList("").Tables[0];
            if (dtArea.Rows.Count > 0)
            {
                dropArea.DataSource = dtArea;
                dropArea.DataTextField = "C_NAME";
                dropArea.DataValueField = "C_NAME";
                dropArea.DataBind();
                dropArea.Items.Insert(0, new ListItem("全部", ""));
            }
            else
            {
                dropArea.Items.Insert(0, new ListItem("全部", ""));
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        private void GetMatList()
        {
            DataTable dt = tmb_activity.GetList(ltlgroupCode.Text, dropArea.SelectedValue, txtCode.Value, txt_GRD.Value, txtSPEC.Value, Start.Value,End.Value).Tables[0];
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetMatList();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Mod_TMB_ACTIVITY mod = new Mod_TMB_ACTIVITY();

                List<Mod_TMB_ACTIVITY> activityList = new List<Mod_TMB_ACTIVITY>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    Literal ltlStatus = (Literal)rptList.Items[i].FindControl("ltlStatus");
                    HtmlInputText txtPRICE2 = (HtmlInputText)rptList.Items[i].FindControl("txtPRICE2");
                    HtmlInputText txtPRICE = (HtmlInputText)rptList.Items[i].FindControl("txtPRICE");
                    HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkSelect");

                    if (chkSelect.Checked)
                    {
                        mod.C_ID = chkSelect.Value;
                        mod.N_PRICE = Convert.ToDecimal(txtPRICE.Value);
                        mod.N_PRICE2 = Convert.ToDecimal(txtPRICE2.Value);
                        mod.C_EMP_ID = ltlC_EMP_ID.Text;
                        mod.C_EMP_NAME = ltlC_EMP_NAME.Text;
                        activityList.Add(mod);
                    }
                }
                if (tmb_activity.UpdateMatCode(activityList))
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('保存成功');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('保存失败');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('"+ ex.Message + "');", true);
            }
        }


        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> list = new List<string>();
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkSelect");
                    if (chkSelect.Checked)
                    {
                        list.Add("'"+chkSelect.Value+"'");
                       
                    }
                }
                if(tmb_activity.DeleteList(string.Join(",",list)))
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('操作成功');", true);
                    GetMatList();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('保存失败');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('"+ ex.Message + "');", true);
            }
        }
    }
}