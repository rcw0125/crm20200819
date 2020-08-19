using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Data;
using NF.MODEL;
using NF.Framework;
using NF.BLL;
using CRM.Common;

namespace CRM.WebForms.Sale_App
{
    public partial class Order_Roll : System.Web.UI.Page
    {
        private static DataTable dtOrder = new DataTable();

        private static DataTable dtArea = new DataTable();

        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();
        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_TB_STD_CONFIG tb_std_config = new Bll_TB_STD_CONFIG();

        private Bll_TQB_PACK tqb_pack = new Bll_TQB_PACK();


        private static DataTable dtOrderEx = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlempid.Text = vUser.Id;
                    ltlempname.Text = vUser.Name;
                    GetArea();
                    SetData();

                    txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");
                    txtEnd.Value = DateTime.Now.ToString("yyy-MM-dd");
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }

        private void GetArea()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ConArea";
            dtArea = ts_dic.GetList(mod).Tables[0];
            if (dtArea.Rows.Count > 0)
            {
                dropsalearea.DataSource = dtArea;
                dropsalearea.DataTextField = "C_DETAILNAME";
                dropsalearea.DataValueField = "C_DETAILNAME";
                dropsalearea.DataBind();
                dropsalearea.Items.Insert(0, new ListItem("全部", ""));//

            }
            else
            {
                dropsalearea.DataSource = null;
                dropsalearea.DataBind();
                dropsalearea.Items.Insert(0, new ListItem("全部", ""));//
            }
        }

        #region //初始化DataTable
        private void SetData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("C_ID", typeof(string));//物料主键
            dt.Columns.Add("C_MAT_CODE", typeof(string));//物料编码
            dt.Columns.Add("C_MAT_NAME", typeof(string));//物料名称
            dt.Columns.Add("C_STL_GRD", typeof(string));//钢种
            dt.Columns.Add("C_SPEC", typeof(string));//规格
            dt.Columns.Add("C_STD_CODE", typeof(string));//执行标准主键
            dt.Columns.Add("ZYX1", typeof(string));//自由项1
            dt.Columns.Add("ZYX2", typeof(string));//自由项2
            dt.Columns.Add("C_IS_BXG", typeof(string));// 是否不锈钢
            dt.Columns.Add("Area", typeof(string));//销售区域
            dt.Columns.Add("Pack", typeof(string));//包装
            dt.Columns.Add("WGT", typeof(string));// 重量
            dt.Columns.Add("CustName", typeof(string));// 客户信息
            dt.Columns.Add("Remark", typeof(string));// 备注
            dt.Columns.Add("INDEX", typeof(string));//GUID
            dtOrder = dt;
        }
        #endregion


        #region //获取当前值
        /// <summary>
        /// 获取当前值
        /// </summary>
        private void BindOrderValue()
        {
            SetData();//初始化TABLE

            if (rptList_Add.Items.Count > 0)
            {

                for (int i = 0; i < rptList_Add.Items.Count; i++)
                {
                    HtmlInputCheckBox chkMat_Code = (HtmlInputCheckBox)rptList_Add.Items[i].FindControl("chkMat_Code");
                    Literal ltlindex = (Literal)rptList_Add.Items[i].FindControl("ltlindex");//索引

                    Literal ltlC_MAT_CODE = (Literal)rptList_Add.Items[i].FindControl("ltlC_MAT_CODE");
                    Literal ltlC_MAT_NAME = (Literal)rptList_Add.Items[i].FindControl("ltlC_MAT_NAME");
                    Literal ltlC_STL_GRD = (Literal)rptList_Add.Items[i].FindControl("ltlC_STL_GRD");
                    Literal ltlC_SPEC = (Literal)rptList_Add.Items[i].FindControl("ltlC_SPEC");
                    Literal ltlC_IS_BXG = (Literal)rptList_Add.Items[i].FindControl("ltlC_IS_BXG");
                    Literal ltlZYX1 = (Literal)rptList_Add.Items[i].FindControl("ltlZYX1");
                    Literal ltlZYX2 = (Literal)rptList_Add.Items[i].FindControl("ltlZYX2");
                    Literal ltlStdCode = (Literal)rptList_Add.Items[i].FindControl("ltlStdCode");
                    TextBox txtPack_Code = (TextBox)rptList_Add.Items[i].FindControl("txtPack_Code");
                    TextBox txtWgt = (TextBox)rptList_Add.Items[i].FindControl("txtWgt");
                    TextBox txtCustName = (TextBox)rptList_Add.Items[i].FindControl("txtCustName");
                    TextBox txtRemark = (TextBox)rptList_Add.Items[i].FindControl("txtRemark");
                    DropDownList dropArea = (DropDownList)rptList_Add.Items[i].FindControl("dropArea");

                    dtOrder.Rows.Add(new object[] { chkMat_Code.Value, ltlC_MAT_CODE.Text, ltlC_MAT_NAME.Text, ltlC_STL_GRD.Text, ltlC_SPEC.Text, ltlStdCode.Text, ltlZYX1.Text, ltlZYX2.Text, ltlC_IS_BXG.Text, dropArea.SelectedValue, txtPack_Code.Text, txtWgt.Text, txtCustName.Text, txtRemark.Text, ltlindex.Text });
                }
            }
        }
        #endregion

        private void GetNewOrder()
        {
            DataTable dt = tmo_order.GetNeedOrderList(txtMatCode.Text, txtMatName.Text, txtStlGrd.Text, txtSpec.Text, ltlempname.Text, dropsalearea.SelectedItem.Text == "全部" ? "" : dropsalearea.SelectedItem.Text, txtStart.Value, txtEnd.Value, "", txtCustName.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dtOrderEx = dt;
                rptNeedOrder.DataSource = dt;
                rptNeedOrder.DataBind();
                ltlsumwgt.Text = dt.Compute("sum(N_WGT)", "true").ToString();
            }
            else
            {
                rptNeedOrder.DataSource = null;
                rptNeedOrder.DataBind();
                ltlsumwgt.Text = "";
            }
        }

        private void BindOrderList()
        {

            BindOrderValue();

            if (Session[ltlempid.Text] != null)
            {
                DataTable dt = (DataTable)Session[ltlempid.Text];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dtOrder.Rows.Add(new object[] { dt.Rows[i]["C_ID"], dt.Rows[i]["C_MAT_CODE"], dt.Rows[i]["C_MAT_NAME"], dt.Rows[i]["C_STL_GRD"], dt.Rows[i]["C_SPEC"], dt.Rows[i]["C_STD_CODE"], dt.Rows[i]["ZYX1"], dt.Rows[i]["ZYX2"], dt.Rows[i]["C_BY4"], "", "", "", "", "", Guid.NewGuid().ToString("N") });
                }
            }


            if (dtOrder.Rows.Count > 0)
            {
                rptList_Add.DataSource = dtOrder;
                rptList_Add.DataBind();
                Session[ltlempid.Text] = null;
            }
            else
            {

                rptList_Add.DataSource = null;
                rptList_Add.DataBind();

                Session[ltlempid.Text] = null;
            }
        }


        //加载钢种
        protected void imgbtnJz_Click(object sender, ImageClickEventArgs e)
        {
            BindOrderList();
        }

        //保存订单
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = true;

                List<string[]> list_log = new List<string[]>();

                List<Mod_TMO_ORDER> orderList = new List<Mod_TMO_ORDER>();

                for (int i = 0; i < rptList_Add.Items.Count; i++)
                {
                    HtmlInputCheckBox chkMat_Code = (HtmlInputCheckBox)rptList_Add.Items[i].FindControl("chkMat_Code");//物料ID
                    Literal ltlStdCode = (Literal)rptList_Add.Items[i].FindControl("ltlStdCode");//执行标准
                    Literal ltlC_IS_BXG = (Literal)rptList_Add.Items[i].FindControl("ltlC_IS_BXG");//是否不锈钢
                    Literal ltlZYX1 = (Literal)rptList_Add.Items[i].FindControl("ltlZYX1");//自由项1
                    Literal ltlZYX2 = (Literal)rptList_Add.Items[i].FindControl("ltlZYX2");//自由项2
                    DropDownList dropArea = (DropDownList)rptList_Add.Items[i].FindControl("dropArea");//区域
                    TextBox txtPack_Code = (TextBox)rptList_Add.Items[i].FindControl("txtPack_Code");//包装
                    TextBox txtCustName = (TextBox)rptList_Add.Items[i].FindControl("txtCustName");//客户
                    TextBox txtBXGCustName = (TextBox)rptList_Add.Items[i].FindControl("txtBXGCustName");//不锈钢客户
                    TextBox txtWgt = (TextBox)rptList_Add.Items[i].FindControl("txtWgt");//排产量
                    TextBox txtRemark = (TextBox)rptList_Add.Items[i].FindControl("txtRemark");//备注


                    if(string .IsNullOrEmpty(txtPack_Code.Text)|| tqb_pack.Exists(txtPack_Code.Text)==false)
                    {
                        result = false;
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('包装不能为空或与实际包装不符');", true);
                        break;
                    }

                    if (dropArea.SelectedItem.Text != "不锈钢公司")
                    {
                        if (string.IsNullOrEmpty(txtCustName.Text))
                        {
                            result = false;
                            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('请补全客户信息');", true);
                            break;
                        }
                    }
                    if (result)
                    {
                        #region //插入预测订单
                        Bll_RandomNumber randomnumber = new Bll_RandomNumber();
                        Mod_TB_MATRL_MAIN modMat = tb_matrl_main.GetModel(chkMat_Code.Value);

                        Mod_TMO_ORDER modOrder = new Mod_TMO_ORDER();//订单表
                        string orderNo = "YC" + DateTime.Now.ToString("yyyMMdd");
                        modOrder.C_ORDER_NO = randomnumber.CreateNeedOrderNo(orderNo);//订单号
                        modOrder.C_CON_NO = "YC";//合同号
                        modOrder.C_AREA = dropArea.SelectedItem.Text;//区域
                        modOrder.C_INVBASDOCID = modMat.C_PK_INVBASDOC;//存货档案主键
                        modOrder.C_INVENTORYID = modMat.C_PK_INVMANDOC;//存货管理档案主键
                        modOrder.C_MAT_CODE = modMat.C_MAT_CODE;//物料编码
                        modOrder.C_MAT_NAME = modMat.C_MAT_NAME;//物料名称
                        modOrder.C_SPEC = modMat.C_SPEC;//规格
                        modOrder.C_STL_GRD = modMat.C_STL_GRD;//钢种
                        modOrder.C_FUNITID = modMat.C_FJLDW;//辅单位
                        modOrder.C_UNITID = modMat.C_PK_MEASDOC;//主计量单位
                        modOrder.C_YWY = ltlempname.Text;//业务员
                        modOrder.C_SFPJ = "N";
                        modOrder.N_FLAG = 1;//预测订单
                        modOrder.N_EXEC_STATUS = -1;//提报订单
                        modOrder.N_TYPE = Convert.ToDecimal(modMat.C_MAT_TYPE);//订单类型

                        modOrder.C_FREE1 = ltlZYX1.Text;//自由项1
                        modOrder.C_FREE2 = ltlZYX2.Text;//自由项2
                        modOrder.C_STD_CODE = ltlStdCode.Text;//执行标准
                        modOrder.C_BY4 = ltlC_IS_BXG.Text;//是否不锈钢                  
                        modOrder.N_WGT = Convert.ToDecimal(txtWgt.Text);
                        modOrder.C_LEV = "普通";//钢种等级
                        modOrder.C_ORDER_LEV = "三级";//订单等级
                        modOrder.N_STATUS = 2;//生效
                        modOrder.C_EMP_ID = ltlempid.Text;
                        modOrder.C_EMP_NAME = ltlempname.Text;
                        modOrder.C_PACK = txtPack_Code.Text;

                        if (modOrder.C_AREA == "不锈钢公司")
                        {
                            modOrder.C_CUST_NAME = txtBXGCustName.Text;//客户信息
                        }
                        else
                        {
                            modOrder.C_CUST_NAME = txtCustName.Text;//客户信息

                            Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
                            string where = $@" C_NAME='{txtCustName.Text}'";
                            DataTable dt = ts_custfile.GetList(where).Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                modOrder.C_CUST_NO = dt.Rows[0]["C_NO"].ToString();//客户编码
                            }
                        }
                        modOrder.C_REMARK4 = txtRemark.Text;//备注
                        modOrder.C_PCTBEMP = ltlempname.Text;//提报人


                        orderList.Add(modOrder);

                        string[] arr_log = { "提报订单", "预测订单页面", ltlempid.Text, GetClientIP(), "", orderNo };
                        list_log.Add(arr_log);
                        #endregion
                    }
                }
                if (result)
                {
                    if (tmo_con.InsertNeedOrder(orderList))
                    {
                        //日志
                        tmo_order.InsertOrderPlanLog(list_log);

                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "_closemsg('保存成功');", true);

                        rptList_Add.DataSource = null;
                        rptList_Add.DataBind();

                        SetData();

                    }
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }


        }
        //删除
        protected void btndel_Click(object sender, EventArgs e)
        {
            BindOrderValue();

            for (int i = 0; i < rptList_Add.Items.Count; i++)
            {
                HtmlInputCheckBox chkMat_Code = (HtmlInputCheckBox)rptList_Add.Items[i].FindControl("chkMat_Code");

                Literal ltlindex = (Literal)rptList_Add.Items[i].FindControl("ltlindex");

                if (chkMat_Code.Checked)
                {
                    DataRow[] dr = dtOrder.Select("INDEX='" + ltlindex.Text + "'");
                    if (dr.Length > 0)
                    {
                        int index = dtOrder.Rows.IndexOf(dr[0]);
                        dtOrder.Rows.RemoveAt(index);
                    }
                }
            }
            if (dtOrder.Rows.Count > 0)
            {
                rptList_Add.DataSource = dtOrder;
                rptList_Add.DataBind();
            }
            else
            {

                rptList_Add.DataSource = null;
                rptList_Add.DataBind();
            }
        }

        protected void rptList_Add_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (dtArea.Rows.Count > 0)
            {
                Literal ltlArea = (Literal)e.Item.FindControl("ltlArea");
                DropDownList dropArea = (DropDownList)e.Item.FindControl("dropArea");
                dropArea.DataSource = dtArea;
                dropArea.DataTextField = "C_DETAILNAME";
                dropArea.DataValueField = "C_DETAILNAME";
                dropArea.DataBind();
                dropArea.Items.Insert(0, new ListItem("", ""));
                dropArea.SelectedIndex = dropArea.Items.IndexOf(dropArea.Items.FindByText(ltlArea.Text));
            }
        }

        protected void btnxc_Click(object sender, EventArgs e)
        {
            GetNewOrder();
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "close();", true);
        }

        protected void rptNeedOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Literal ltlN_EXEC_STATUS = (Literal)e.Item.FindControl("ltlN_EXEC_STATUS");
            HtmlInputCheckBox cbxID = (HtmlInputCheckBox)e.Item.FindControl("cbxID");
            cbxID.Visible = ltlN_EXEC_STATUS.Text == "-1" ? true : false;
        }

        //关闭订单
        protected void btnclose_Click(object sender, EventArgs e)
        {
            try
            {

                List<string[]> list = new List<string[]>();
                List<string[]> list_log = new List<string[]>();

                for (int i = 0; i < rptNeedOrder.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxID = (HtmlInputCheckBox)rptNeedOrder.Items[i].FindControl("cbxID");
                    Literal ltlC_ORDER_NO = (Literal)rptNeedOrder.Items[i].FindControl("ltlC_ORDER_NO");
                    Literal ltlwgt = (Literal)rptNeedOrder.Items[i].FindControl("ltlwgt");
                    if (cbxID.Checked)
                    {

                        string[] arr = { "5", cbxID.Value };

                        list.Add(arr);

                        //日志
                        string[] arr2 = { "关闭预测订单", ltlwgt.Text, ltlempid.Text, GetClientIP(), ltlC_ORDER_NO.Text, cbxID.Value };
                        list_log.Add(arr2);
                    }
                }

                if (list.Count > 0)
                {
                    if (tmo_order.UpdateCancelSubmission(list))
                    {
                        //日志
                        tmo_order.InsertOrderPlanLog(list_log);

                        WebMsg.MessageBox("关闭成功");
                        GetNewOrder();
                    }
                }

            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.ToString());
            }

        }

        private string GetClientIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            return result;

        }

        //导出文件
        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (dtOrderEx.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("C_MAT_CODE", "物料编码 ");
                dic.Add("C_MAT_NAME", "物料名称");
                dic.Add("C_STL_GRD", "钢种");
                dic.Add("C_SPEC", "规格");
                dic.Add("N_WGT", "数量*");
                dic.Add("ZXZT", "状态");
                dic.Add("C_FREE1", "自由项1");
                dic.Add("C_FREE2", "自由项2");
                dic.Add("C_STD_CODE", "执行标准");
                dic.Add("C_PACK", "包装要求");
                dic.Add("C_AREA", "销售区域");
                dic.Add("C_CUST_NAME", "客户信息");
                dic.Add("C_EMP_NAME", "业务员");
                dic.Add("D_DT", "录入时间");
                dic.Add("C_ORDER_NO", "订单号");
                ExportHelper.BudgetExport(dtOrderEx, dic, "订单提报表", Response);
                dtOrderEx = null;
            }
        }
    }
}