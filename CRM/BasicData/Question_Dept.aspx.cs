using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using NF.BLL;
using NF.Framework;
using NF.MODEL;

namespace CRM.BasicData
{
    public partial class Question_Dept : System.Web.UI.Page
    {
        private Bll_TS_DEPT dept = new Bll_TS_DEPT();
        private Bll_TMC_QUESTION_DEPT tmc_question_dept = new Bll_TMC_QUESTION_DEPT();

        private static DataTable deptData = new DataTable();
        private static DataTable quest_deptData = new DataTable();

        private static bool result = false;


        #region 自定义方法

        /// <summary>
        /// 判断是否有记录
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        private bool CheckQuest_Dept(string deptID)
        {
            DataRow[] row = quest_deptData.Select("C_DEPT_ID='" + deptID + "'");
            if (row.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 递归遍历指定节点下的子节点
        /// </summary>
        /// <param name="nd">参数，接收节点对象</param>
        private void bindnode(TreeNode nd)
        {
            DataRow[] row = deptData.Select("C_PARENT_ID='" + nd.Value + "'");
            for (int i = 0; i < row.Length; i++)
            {
                TreeNode node = new TreeNode();
                node.Text = row[i]["C_Name"].ToString();
                node.Value = row[i]["C_ID"].ToString();
                node.ShowCheckBox = true;
                node.Checked = CheckQuest_Dept(row[i]["C_ID"].ToString());
                node.Collapse();

                nd.ChildNodes.Add(node);//把指定节点添加到控件中

                bindnode(node);
            }
        }

        /// <summary>
        /// 查找根节点(parent_ID为0的节点)的子节点
        /// </summary>
        /// <param name="parent_ID">参数，接收根节点ID</param>
        private void bindtree(string parent_ID)
        {
            DataRow[] row = deptData.Select("C_PARENT_ID='" + parent_ID + "'");
            for (int i = 0; i < row.Length; i++)
            {
                //这是在找数据库中的节点
                TreeNode node = new TreeNode(row[i]["C_Name"].ToString().Trim(), row[i]["C_ID"].ToString());
                node.ShowCheckBox = true;
                this.trv_menu.Nodes.Add(node);//把指定节点添加到控件中

                bindnode(node);//遍历子节点
            }

        }

        #endregion


        /// <summary>
        /// 加载时运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var User = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (User != null)
                {
                    ltlEmpID.Text = User.Id;
                    ltlEmpName.Text = User.Name;

                    if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                    {
                        ltlID.Text = Request.QueryString["ID"];

                        init_tree();
                    }
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }


            }

        }


        public void init_tree()
        {
            deptData = dept.GetList("").Tables[0];
            quest_deptData = tmc_question_dept.GetQuestion_Dept(ltlID.Text, "").Tables[0];

            trv_menu.Nodes.Clear();

            bindtree("-1"); //传入第-1个parent_ID开始遍历根节点

        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {

            tmc_question_dept.DeleteQuestion_Dept(ltlID.Text);//删除

            for (int i = 0; i < trv_menu.Nodes.Count; i++)
            {
                SetCheckedChildNodes(trv_menu.Nodes[i]);
            }

            if (result)
            {
                Response.Write("<script>alert('提交成功');window.close();</script>");
            }
        }
        private void SetCheckedChildNodes(TreeNode node)
        {
            Mod_TMC_QUESTION_DEPT mod = new Mod_TMC_QUESTION_DEPT();

            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                string id =node.ChildNodes[i].Value;
                if (node.ChildNodes[i].Checked)
                {
                    mod.C_QUESTION_ID = ltlID.Text;
                    mod.C_DEPT_ID = id;
                    mod.C_EMP_ID = ltlEmpID.Text;
                    mod.C_EMP_NAME = ltlEmpName.Text;
                    result = tmc_question_dept.Add(mod);
                }
                SetCheckedChildNodes(node.ChildNodes[i]);
            }
        }
    }
}