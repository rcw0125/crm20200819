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

namespace CRM.WebForms.Train
{
    public partial class addrAdd2 : System.Web.UI.Page
    {
        private Bll_TMB_AREA area = new Bll_TMB_AREA();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TMB_NCADDRESS_COST tmb_ncaddress_cost = new Bll_TMB_NCADDRESS_COST();

        private static DataTable areaData = new DataTable();
        private static DataTable addrData = new DataTable();

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

            #region//承运商
            DataTable dt2 = GetData("TRANCUST");
            if (dt.Rows.Count > 0)
            {
                dropcys.DataSource = dt2;
                dropcys.DataTextField = "C_DETAILNAME";
                dropcys.DataValueField = "C_DETAILCODE";
                dropcys.DataBind();
            }
            else
            {
                dropcys.DataSource = null;
                dropcys.DataBind();
            }
            #endregion

        }


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
                bindnode2(node);

                bindnode(node);
            }
        }

        /// <summary>
        /// 递归遍历指定节点下的子节点
        /// </summary>
        /// <param name="nd">参数，接收节点对象</param>
        private void bindnode2(TreeNode nd)
        {
            DataRow[] row = addrData.Select("N_PARENTID='" + nd.Value + "'");
            for (int i = 0; i < row.Length; i++)
            {
                TreeNode node = new TreeNode();
                node.Text = row[i]["C_Name"].ToString();
                node.Value = row[i]["C_ID"].ToString();
                node.Collapse();
                nd.ChildNodes.Add(node);//把指定节点添加到控件中
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtEnd.Value = DateTime.Now.ToString("yyy-MM-dd");

                init_tree(); //传入第-1个parent_ID开始遍历根节点
                GetDic();
            }
        }

        public void init_tree()
        {
            areaData = area.GetList("").Tables[0];
            addrData = area.GetAddrList("").Tables[0];

            trv_menu.Nodes.Clear();

            bindtree("-1"); //传入第-1个parent_ID开始遍历根节点
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {


            for (int i = 0; i < trv_menu.Nodes.Count; i++)
            {
                SetCheckedChildNodes(trv_menu.Nodes[i]);
            }

            Response.Write("<script>window.parent.document.getElementById('imgbtnJz').click();window.parent.close();</script>");


        }

        private void SetCheckedChildNodes(TreeNode node)
        {
            try
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

                var list = new List<Mod_TMB_NCADDRESS_COST>();

                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    string id = node.ChildNodes[i].Value;
                    if (node.ChildNodes[i].Checked)
                    {
                        DataTable dt = tmb_ncaddress_cost.GetList(id).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            var mod = new Mod_TMB_NCADDRESS_COST()
                            {
                                C_CHENGYUN = dropcys.SelectedItem.Text,
                                C_FAYUN = dropfyfs.SelectedItem.Text,
                                N_PRICE = Convert.ToDecimal(txtprice.Text == "" ? "0" : txtprice.Text),
                                D_START_DT = Convert.ToDateTime(txtStart.Value),
                                D_END_DT = Convert.ToDateTime(txtEnd.Value),
                                C_ADDRNAME = dt.Rows[0]["ADDRNAME"].ToString(),
                                C_ADDRCODE = dt.Rows[0]["ADDRCODE"].ToString(),
                                C_ADDR_NCPK = dt.Rows[0]["PK_ADDRESS"].ToString(),
                                C_AREA_PK = id,
                                C_CREATE_EMP = vUser?.Name
                            };

                            if (!tmb_ncaddress_cost.Exists(mod.C_FAYUN, mod.C_ADDRNAME))
                            {
                                list.Add(mod);
                            }
                        }
                    }
                    SetCheckedChildNodes(node.ChildNodes[i]);
                }
                if (list.Count > 0)
                {
                    tmb_ncaddress_cost.Add(list);
                }

            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}