using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using NF.BLL;
using NF.MODEL;

namespace CRM.Common
{
    public partial class _MatGroup : System.Web.UI.Page
    {
        private Bll_TB_MATRL_GROUP tb_matrl_group = new Bll_TB_MATRL_GROUP();
        private static Dictionary<string, IList<Mod_TB_MATRL_GROUP>> nodeDictionary = new Dictionary<string, IList<Mod_TB_MATRL_GROUP>>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MatGroup();
            }
        }

        private void MatGroup()
        {
            nodeDictionary.Clear();
            trv_menu.Nodes.Clear();

            TreeNode tnRootNode = new TreeNode();
            tnRootNode.Text = "根目录";
            tnRootNode.Value = "-1";

            //取得根目录的第一级数据
            IList<Mod_TB_MATRL_GROUP> ilPwDepts = tb_matrl_group.DataTableToList(tb_matrl_group.GetMatrlGroup("").Tables[0]);

            if (ilPwDepts == null || ilPwDepts.Count < 1)
            {
                return;
            }
            foreach (Mod_TB_MATRL_GROUP pdItem in ilPwDepts)
            {
                TreeNode tnNewNode = new TreeNode(pdItem.C_MAT_GROUP_NAME, pdItem.C_MAT_GROUP_CODE);
                //取得第一级数据下的第二级数据
                IList<Mod_TB_MATRL_GROUP> ilChilldDepts = tb_matrl_group.DataTableToList(tb_matrl_group.GetMatrlGroup(pdItem.C_MAT_GROUP_CODE).Tables[0]);

                tnRootNode.ChildNodes.Add(tnNewNode);

                if (ilChilldDepts == null || ilChilldDepts.Count < 1)
                {
                }
                else
                {
                    //设置父结点可以扩展
                    tnNewNode.PopulateOnDemand = true;
                    tnNewNode.Expanded = false;
                    nodeDictionary.Add(pdItem.C_MAT_GROUP_CODE, ilChilldDepts);
                }
            }
            trv_menu.Nodes.Add(tnRootNode);
        }

        protected void trv_menu_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            //取得当前点击的node的值
            if (trv_menu.SelectedNode != null)
            {
                string sValue = trv_menu.SelectedNode.Value;
            }

            string nodeID = e.Node.Value;
            if (nodeDictionary != null)
            {
                if (nodeDictionary.Keys.Contains(nodeID))
                {
                    if (nodeDictionary[nodeID].Count > 0)
                    {
                        //从缓存中取得当前结点的第一级结点
                        foreach (Mod_TB_MATRL_GROUP pdItem in nodeDictionary[nodeID])
                        {
                            TreeNode tnNewNode = new TreeNode(pdItem.C_MAT_GROUP_NAME, pdItem.C_MAT_GROUP_CODE);
                            //取得当前结点第一级结点下的子结点
                            IList<Mod_TB_MATRL_GROUP> ilPwDepts = tb_matrl_group.DataTableToList(tb_matrl_group.GetMatrlGroup(tnNewNode.Value).Tables[0]);
                            //如果没有子结点，不可以扩展
                            if (ilPwDepts == null || ilPwDepts.Count < 1)
                            {
                                tnNewNode.Expanded = false;
                                tnNewNode.PopulateOnDemand = false;
                                tnNewNode.SelectAction = TreeNodeSelectAction.Select;
                                e.Node.ChildNodes.Add(tnNewNode);
                            }
                            else
                            {
                                //设置父结点可以扩展
                                tnNewNode.PopulateOnDemand = true;
                                tnNewNode.Expanded = false;
                                tnNewNode.SelectAction = TreeNodeSelectAction.Select;
                                e.Node.ChildNodes.Add(tnNewNode);
                                //级存当前结点第一级结点下的子结点
                                nodeDictionary.Add(pdItem.C_MAT_GROUP_CODE, ilPwDepts);
                            }
                        }
                        //移除已展开的节点
                        nodeDictionary.Remove(nodeID);
                    }
                }
            }
        }

        protected void trv_menu_SelectedNodeChanged(object sender, EventArgs e)
        {

            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>GetMat('"+trv_menu.SelectedNode.Text+"');</script>");
        }
    }
}