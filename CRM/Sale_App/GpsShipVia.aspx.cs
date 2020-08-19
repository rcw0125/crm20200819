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

namespace CRM.Sale_App
{
    public partial class GpsShipVia : System.Web.UI.Page
    {
        private Bll_TS_DIC dic = new Bll_TS_DIC();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private Bll_GPS bll_gps = new Bll_GPS();

        private Bll_TMB_AREA tmb_area = new Bll_TMB_AREA();
        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();

        private static DataTable areaData = new DataTable();

        private static bool result = false;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
                init_tree();
                result = false;

            }
        }

        #region //发运方式


        //加载数据
        private void BindData()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ShipVia";
            DataTable dt = dic.GetList(mod).Tables[0];
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

        //否
        protected void btnNo_Click(object sender, EventArgs e)
        {
            string idList = "";

            foreach (RepeaterItem item in rptList.Items)
            {
                HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)item.FindControl("chkSelect");
                if (chkSelect.Checked)
                {
                    idList += "'" + chkSelect.Value + "',";
                }
            }
            if (!string.IsNullOrEmpty(idList))
            {
                idList = idList.Substring(0, idList.Length - 1);
                if (dic.UpdateN_ISGPS(0, idList))
                {
                    //WebMsg.MessageBox("设置成功");
                    BindData();
                }
            }
        }

        //是
        protected void btnOk_Click(object sender, EventArgs e)
        {
            string idList = "";

            foreach (RepeaterItem item in rptList.Items)
            {
                HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)item.FindControl("chkSelect");
                if (chkSelect.Checked)
                {
                    idList += "'" + chkSelect.Value + "',";
                }
            }
            if (!string.IsNullOrEmpty(idList))
            {
                idList = idList.Substring(0, idList.Length - 1);
                if (dic.UpdateN_ISGPS(1, idList))
                {
                    //WebMsg.MessageBox("设置成功");
                    BindData();
                }
            }
        }
        #endregion

        #region //客户

        /// <summary>
        /// 分页绑定
        /// </summary>

        private void ByPageBind()
        {
            Pager1.RecordCount = ts_custfile.GetRecordCount(txtCustCode.Value, txtCustName.Value);
            if (Pager1.RecordCount > 0)
            {
                GetListBind();
            }
            else
            {
                rptCust.DataSource = null;
                rptCust.DataBind();
            }
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        private void GetListBind()
        {

            rptCust.DataSource = ts_custfile.GetListByPage(Pager1.PageSize, Pager1.CurrentPageIndex, txtCustCode.Value, txtCustName.Value);
            rptCust.DataBind();
        }



        protected void Pager1_PageChanged(object sender, EventArgs e)
        {
            GetListBind();
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ByPageBind();
        }


        protected void btnOk2_Click(object sender, EventArgs e)
        {
            string idList = "";

            foreach (RepeaterItem item in rptCust.Items)
            {
                HtmlInputCheckBox chkSelect2 = (HtmlInputCheckBox)item.FindControl("chkSelect2");
                if (chkSelect2.Checked)
                {
                    idList += "'" + chkSelect2.Value + "',";
                }
            }
            if (!string.IsNullOrEmpty(idList))
            {
                idList = idList.Substring(0, idList.Length - 1);
                if (bll_gps.UpdateGPS(1, idList, "TS_CUSTFILE"))
                {
                    //WebMsg.MessageBox("设置成功");
                    GetListBind();
                }
            }
        }

        protected void btnNo2_Click(object sender, EventArgs e)
        {
            string idList = "";

            foreach (RepeaterItem item in rptCust.Items)
            {
                HtmlInputCheckBox chkSelect2 = (HtmlInputCheckBox)item.FindControl("chkSelect2");
                if (chkSelect2.Checked)
                {
                    idList += "'" + chkSelect2.Value + "',";
                }
            }
            if (!string.IsNullOrEmpty(idList))
            {
                idList = idList.Substring(0, idList.Length - 1);
                if (bll_gps.UpdateGPS(0, idList, "TS_CUSTFILE"))
                {
                    // WebMsg.MessageBox("设置成功");
                    GetListBind();
                }
            }
        }

        #endregion

        #region //区域

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
                node.ShowCheckBox = true;
                node.Checked = row[i]["N_ISGPS"].ToString() == "0" ? false : true;
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
                node.ShowCheckBox = true;
                this.trv_menu.Nodes.Add(node);//把指定节点添加到控件中

                bindnode(node);//遍历子节点
            }

        }

        #endregion


        public void init_tree()
        {
            areaData = tmb_area.GetList("").Tables[0];


            trv_menu.Nodes.Clear();

            bindtree("-1"); //传入第-1个parent_ID开始遍历根节点

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
           

            for (int i = 0; i <trv_menu.Nodes.Count; i++)
            {
                SetCheckedChildNodes(trv_menu.Nodes[i]);
            }
            if (result)
            {
                init_tree();
                ScriptManager.RegisterStartupScript(UpdatePanel2, this.Page.GetType(), "", "alert('提交成功');", true);
            }
        }

        private void SetCheckedChildNodes(TreeNode node)
        {
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                string id = "'" + node.ChildNodes[i].Value + "'";
                if (node.ChildNodes[i].Checked)
                {

                    DataRow[] row = areaData.Select("C_ID='" + node.ChildNodes[i].Value + "'");
                    if(row[0]["N_ISGPS"].ToString ()!="1")
                    {
                        result= bll_gps.UpdateGPS(1, id, "TMB_AREA");
                    }
                }
                else
                {
                    DataRow[] row = areaData.Select("C_ID='" + node.ChildNodes[i].Value + "'");
                    if (row[0]["N_ISGPS"].ToString() != "0")
                    {
                        result=bll_gps.UpdateGPS(0, id, "TMB_AREA");
                    }
                }
                SetCheckedChildNodes(node.ChildNodes[i]);
            }
        }


        #endregion

        #region//钢种

        /// <summary>
        /// 分页绑定
        /// </summary>

        private void ByMat()
        {
            AspNetPager1.RecordCount = tb_matrl_main.GetRecordCount(txtMatCode.Value, txtGRD.Value, txtSpec.Value);
            if (AspNetPager1.RecordCount > 0)
            {
                GetMatList();
            }
            else
            {

                rptMat.DataSource = null;
                rptMat.DataBind();
            }
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        private void GetMatList()
        {

            rptMat.DataSource = tb_matrl_main.GetListByPage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, txtMatCode.Value, txtGRD.Value, txtSpec.Value);
            rptMat.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            GetMatList();
        }

        protected void btnSearch2_Click(object sender, EventArgs e)
        {
            ByMat();
        }


        protected void btnOk3_Click(object sender, EventArgs e)
        {
            string idList = "";

            foreach (RepeaterItem item in rptMat.Items)
            {
                HtmlInputCheckBox chkSelect3 = (HtmlInputCheckBox)item.FindControl("chkSelect3");
                if (chkSelect3.Checked)
                {
                    idList += "'" + chkSelect3.Value + "',";
                }
            }
            if (!string.IsNullOrEmpty(idList))
            {
                idList = idList.Substring(0, idList.Length - 1);
                if (bll_gps.UpdateGPS(1, idList, "TB_MATRL_MAIN"))
                {
                    //WebMsg.MessageBox("设置成功");
                    GetMatList();
                }
            }
        }

        protected void btnNo3_Click(object sender, EventArgs e)
        {
            string idList = "";

            foreach (RepeaterItem item in rptMat.Items)
            {
                HtmlInputCheckBox chkSelect3 = (HtmlInputCheckBox)item.FindControl("chkSelect3");
                if (chkSelect3.Checked)
                {
                    idList += "'" + chkSelect3.Value + "',";
                }
            }
            if (!string.IsNullOrEmpty(idList))
            {
                idList = idList.Substring(0, idList.Length - 1);
                if (bll_gps.UpdateGPS(0, idList, "TB_MATRL_MAIN"))
                {
                    //WebMsg.MessageBox("设置成功");
                    GetMatList();
                }
            }
        }

        #endregion

    }
}