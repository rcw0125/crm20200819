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
    public partial class Dept : System.Web.UI.Page
    {
        private Bll_TS_DEPT dept = new Bll_TS_DEPT();
       

        #region 自定义方法

        private DataTable Getdata(string ID) //在这里我们传入一个parent_ID
        {
            DataTable dt = dept.GetDeptList(ID).Tables[0];

            return dt;
        }

        /// <summary>
        /// 递归遍历指定节点下的子节点
        /// </summary>
        /// <param name="nd">参数，接收节点对象</param>
        private void bindnode(TreeNode nd)
        {
            DataTable dt = Getdata(nd.Value);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode node = new TreeNode();
                node.Text = dt.Rows[i]["C_Name"].ToString();
                node.Value = dt.Rows[i]["C_ID"].ToString();

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
            DataTable dt = Getdata(parent_ID);
            if (dt.Rows.Count > 0)
            {
                if(parent_ID=="-1")
                {
                    btnInit.Visible = false;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //这是在找数据库中的节点
                    TreeNode node = new TreeNode(dt.Rows[i]["C_Name"].ToString().Trim(), dt.Rows[i]["C_ID"].ToString());
                    this.trv_menu.Nodes.Add(node);//把指定节点添加到控件中
                    trv_menu.CollapseAll();

                    bindnode(node);//遍历子节点
                }

                this.lbl_nodeText.Text = this.trv_menu.Nodes[0].Text;
            }
            else
            {
                if (parent_ID == "-1")
                {
                    btnInit.Visible = true;
                }
            }
        }

        /// <summary>
        /// 查找指定ID的子目录
        /// </summary>
        /// <param name="ID"></param>
        private void ListAll(string ID)
        {
            grd_menu.DataSource = null;
            DataTable dt = Getdata(ID);
            this.grd_menu.DataSource = dt;
            grd_menu.DataKeyNames = new string[] { "C_ID" };//主键

            this.grd_menu.DataBind();

           
        }

        /// <summary>
        /// 查找指定ID的目录
        /// </summary>
        /// <param name="ID"></param>

        #endregion

        #region 系统事件
        /// <summary>
        /// 加载时运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //查找根结点的子节点
                init_tree(); //传入第-1个parent_ID开始遍历根节点

               
            }

        }

        public void init_tree()
        {
            trv_menu.Nodes.Clear();

            bindtree("-1"); //传入第-1个parent_ID开始遍历根节点
            trv_menu.CollapseAll();

        }

        /// <summary>
        /// 在选定节点更改后激发
        /// </summary>
        protected void trv_menu_SelectedNodeChanged(object sender, EventArgs e)
        {
            this.lbl_nodeText.Text = this.trv_menu.SelectedNode.Text;

            lfid.Text = this.trv_menu.SelectedNode.Value;

            ldeph.Text = trv_menu.SelectedNode.Depth.ToString();

            this.ListAll(lfid.Text);
        }

        /// <summary>
        /// 添加事件
        protected void btn_Add_Click(object sender, EventArgs e)
        {


            int num2 = Convert.ToInt32(ldeph.Text) + 1;


            Mod_TS_DEPT mod = new Mod_TS_DEPT();
            mod.C_NAME = txt_menu.Text;
            mod.C_CODE = txtCode.Text;
            mod.C_PARENT_ID = lfid.Text;
            mod.C_DEPTH = num2;
            if (dept.Add(mod))
            {
                this.txt_menu.Text = "";
                txtCode.Text = "";
                this.ListAll(lfid.Text);
                init_tree();
            }
        }

        #endregion


        /// <summary>
        /// 编辑事件
        /// </summary>
        protected void grd_menu_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

          
            string lmcode = ((TextBox)(grd_menu.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();
            string lmmc = ((TextBox)(grd_menu.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
         
 
                Mod_TS_DEPT mod = dept.GetModel(grd_menu.DataKeys[e.RowIndex].Value.ToString());

                mod.C_NAME = lmmc;
                mod.C_CODE = lmcode;
              
                dept.Update(mod);

                this.grd_menu.EditIndex = -1;


                this.ListAll(lfid.Text);

                init_tree();
           
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        protected void grd_menu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            dept.UpdateStatus(grd_menu.DataKeys[e.RowIndex].Value.ToString());

            this.ListAll(lfid.Text);

            init_tree();

        }

        /// <summary>
        /// 取消编辑
        /// </summary>
        protected void grd_menu_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            this.grd_menu.EditIndex = -1;
            this.ListAll(lfid.Text);
        }
        protected void grd_menu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //如果是绑定数据行 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[4].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('确定要删除：\"" + e.Row.Cells[2].Text + "\"吗?一旦删除将不能恢复！');");
                }
            }

        }

        protected void grd_menu_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grd_menu.EditIndex = e.NewEditIndex;
            this.ListAll(lfid.Text);
        }

        /// <summary>
        /// 验证是否为正整数
        /// </summary>
        private bool IsNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$");
            return reg1.IsMatch(str.Trim());
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ListAll(lfid.Text);
            init_tree();
        }

        //初始化根目录
        protected void btnInit_Click(object sender, EventArgs e)
        {
            //var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            //if (BaseUser != null)
            {

                Mod_TS_DEPT mod = new Mod_TS_DEPT();
                mod.C_CODE = "-1";
                mod.C_NAME = "总根目录";
                mod.C_PARENT_ID = "-1";
                mod.C_DEPTH = -1;
                //mod.C_EMP_ID = BaseUser.Id;
               // mod.C_EMP_NAME = BaseUser.Name;
                if(dept.Add(mod))
                {
                    this.ListAll(lfid.Text);
                    init_tree();
                }
            }
        }
    }
}