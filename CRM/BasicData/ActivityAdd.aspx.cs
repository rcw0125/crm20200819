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

namespace CRM.BasicData
{
    public partial class ActivityAdd : System.Web.UI.Page
    {
        private Bll_TMB_ACTIVITY tmb_activity = new Bll_TMB_ACTIVITY();

        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();
        private Bll_TMB_AREAMAX tmb_areamax = new Bll_TMB_AREAMAX();



        private static DataTable dtActivity = new DataTable();

        private static DataTable matData = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    try
                    {
                        ltlC_EMP_ID.Text = BaseUser.Id;
                        ltlC_EMP_NAME.Text = BaseUser.Name;
                        GetMat();
                        GetArea();

                        DateTime dt = DateTime.Now;
                        txtStart.Value = Convert.ToDateTime(dt).ToString("yyy-MM-dd");
                        txtEnd.Value = dt.AddMonths(1).AddDays(-(dt.Day)).ToString("yyy-MM-dd");

                        if (!string.IsNullOrEmpty(Request.QueryString["type"]))
                        {
                            ltlMatType.Text = Request.QueryString["type"];
                            if (ltlMatType.Text == "6")
                            {
                                txtSPEC1.Disabled = !txtSPEC1.Disabled;
                                txtSPEC2.Disabled = !txtSPEC2.Disabled;
                            } 
                        }
                    }
                    catch (Exception ex)
                    {
                        WebMsg.MessageBox(ex.Message);
                    }
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }

        private void GetArea()
        {

            DataTable dtArea = tmb_areamax.GetList("").Tables[0];
            if (dtArea.Rows.Count > 0)
            {
                dropAreaMax.DataSource = dtArea;
                dropAreaMax.DataTextField = "C_NAME";
                dropAreaMax.DataValueField = "C_NAME";
                dropAreaMax.DataBind();

            }

        }


        #region //物料分类

        protected void trv_menu_SelectedNodeChanged(object sender, EventArgs e)
        {
            ltlC_PROD_NAME.Text = trv_menu.SelectedNode.Text;
            ltlgroupCode.Text = trv_menu.SelectedNode.Value;
            BindMatList();
        }
        private void BindMatList()
        {
            DataTable dt = tb_matrl_main.GetMatList(txt_GRD.Value, txtSPEC1.Value, txtSPEC2.Value, ltlgroupCode.Text,ltlMatType.Text).Tables[0];
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
                trv_menu.ExpandAll();
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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindMatList();
        }




        private bool Check(string MatCode)
        {
            DataRow[] row = dtActivity.Select("C_MAT_CODE='" + MatCode + "'");
            if (row.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                dtActivity = tmb_activity.GetList(txtStart.Value, txtEnd.Value, dropAreaMax.SelectedValue).Tables[0];



                bool result = false;

                Mod_TMB_ACTIVITY mod = new Mod_TMB_ACTIVITY();

                List<string> list = new List<string>();
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkSelect");
                    Literal ltlC_MAT_NAME = (Literal)rptList.Items[i].FindControl("ltlC_MAT_NAME");
                    Literal ltlSTL_GRD = (Literal)rptList.Items[i].FindControl("ltlSTL_GRD");
                    Literal ltlSPEC = (Literal)rptList.Items[i].FindControl("ltlSPEC");
                    Literal ltlGroupCode = (Literal)rptList.Items[i].FindControl("ltlGroupCode");
                    if (chkSelect.Checked)
                    {
                        if (!Check(chkSelect.Value))
                        {
                            mod.C_MAT_CODE = chkSelect.Value;
                            mod.C_MAT_NAME = ltlC_MAT_NAME.Text;
                            mod.C_STL_GRD = ltlSTL_GRD.Text;
                            mod.C_SPEC = ltlSPEC.Text;
                            mod.C_EMP_ID = ltlC_EMP_ID.Text;
                            mod.C_EMP_NAME = ltlC_EMP_NAME.Text;
                            mod.D_START_DT = Convert.ToDateTime(txtStart.Value);
                            mod.D_END_DT = Convert.ToDateTime(txtEnd.Value);
                            mod.C_AREAMAX = dropAreaMax.SelectedValue;
                            mod.N_PRICE = Convert.ToDecimal(txtPRICE.Value);//成本价
                            mod.N_PRICE2 = txtPRICE2.Value == "" ? 0 : Convert.ToDecimal(txtPRICE2.Value);//售价       
                            mod.C_PROD_NAME = ltlGroupCode.Text;//物料组编码
                            result = tmb_activity.Add(mod);

                        }
                        else
                        {
                            list.Add(chkSelect.Value);
                        }
                    }
                }
                if (result)
                {
                    if (list.Count > 0)
                    {
                        string str = "新增成功! 以下物料数据以重复(" + string.Join(",", list) + ")";

                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('" + str + "');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('新增成功');", true);
                    }

                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('" + ex.Message + "');", true);

            }
        }

        //置空
        protected void btnclear_Click(object sender, EventArgs e)
        {
            ltlgroupCode.Text = string.Empty;
            ltlC_PROD_NAME.Text = string.Empty;
            txt_GRD.Value = string.Empty;
            txtSPEC1.Value = string.Empty;
            txtSPEC2.Value = string.Empty;

        }
    }
}