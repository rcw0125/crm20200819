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

namespace CRM.Common
{
    public partial class _Site : System.Web.UI.Page
    {
        private Bll_TMB_AREA area = new Bll_TMB_AREA();

        private static DataTable areaData = new DataTable();


        #region 自定义方法

        /// <summary>
        /// 递归遍历指定节点下的子节点
        /// </summary>
        /// <param name="nd">参数，接收节点对象</param>
        private void bindnode(TreeNode nd)
        {
            DataRow[] row = areaData.Select("N_PARENTID='" + nd.Value + "'");
            for (int i = 0; i < row.Length; i++)
            {
                TreeNode node = new TreeNode();
                node.Text = row[i]["C_Name"].ToString();
                node.Value = row[i]["C_ID"].ToString();
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
            DataRow[] row = areaData.Select("N_PARENTID='" + parent_ID + "'");
            for (int i = 0; i < row.Length; i++)
            {
                //这是在找数据库中的节点
                TreeNode node = new TreeNode(row[i]["C_Name"].ToString().Trim(), row[i]["C_ID"].ToString());
                this.trv_menu.Nodes.Add(node);//把指定节点添加到控件中
                node.CollapseAll();
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
                if (!string.IsNullOrEmpty(Request.QueryString["flag"]))
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                    {
                        hidindex.Value = Request.QueryString["ID"];
                    }
                    ltlFlag.Text = Request.QueryString["flag"];
                    //查找根结点的子节点
                    init_tree(); //传入第-1个parent_ID开始遍历根节点
                }


            }

        }

        public void init_tree()
        {
            areaData = area.GetList("").Tables[0];

            trv_menu.Nodes.Clear();


            if (ltlFlag.Text == "0")
            {
                bindtree("-1"); //传入第-1个parent_ID开始遍历根节点
            }
            else
            {
                bindtree("dqdaa000000000000001");
            }


        }

        protected void trv_menu_SelectedNodeChanged(object sender, EventArgs e)
        {

            string name = trv_menu.SelectedNode.Text;
            string id = trv_menu.SelectedNode.Value;
            if (ltlFlag.Text == "1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "GetSite('" + name + "','" + id + "');", true);
            }
            else if(!string .IsNullOrEmpty(hidindex.Value))
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "GetDWDQ('" + name + "','" + id + "');", true);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "GetLine('" + name + "','" + id + "');", true);
            }

        }
    }
}