using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using NF.BLL;
using NF.MODEL;

namespace CRM.WebForms.Cust_App
{
    public partial class OrderList : System.Web.UI.Page
    {
        //private Bll_TMO_CONDETAILS tmo_condetails = new Bll_TMO_CONDETAILS();
        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["kh"] = null;

                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {

                    DateTime dt = DateTime.Now;
                    Start.Value = dt.AddDays(-(dt.Day) + 1).ToString("yyy-MM-dd");
                    End.Value = dt.AddMonths(1).AddDays(-(dt.Day)).ToString("yyy-MM-dd");

                    Mod_TS_CUSTFILE mod = ts_custfile.GetModel(vUser.CustId);
                    if (mod != null)
                    {
                        ltlcustno.Text = mod.C_NO;
                    }
                }
            }
        }

        /// <summary>
        /// 订单列表
        /// </summary>
        private void GetOrder()
        {
            DataTable dt = tmo_order.GetConOrderList(txtConNo.Text, "", txtstlgrd.Text, Start.Value, End.Value, ltlcustno.Text).Tables[0];
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
            GetOrder();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Session["kh"] = null;

            #region //DataTable初始化
            DataTable dt = new DataTable();
            dt.Columns.Add("C_ID", typeof(string));//物料主键
            dt.Columns.Add("C_MAT_CODE", typeof(string));//物料编码
            dt.Columns.Add("C_MAT_NAME", typeof(string));//物料名称
            dt.Columns.Add("C_STL_GRD", typeof(string));//钢种
            dt.Columns.Add("C_SPEC", typeof(string));//规格
            dt.Columns.Add("C_CUST_TECH_PROT", typeof(string));//客户协议
            dt.Columns.Add("C_STD_CODE", typeof(string));//执行标准
            dt.Columns.Add("ZYX1", typeof(string));//自由项1
            dt.Columns.Add("ZYX2", typeof(string));//自由项2
            dt.Columns.Add("C_BY4", typeof(string));//是否不锈钢
            dt.Columns.Add("C_PACK", typeof(string));//包装
            dt.Columns.Add("N_WGT", typeof(string));//数量
            dt.Columns.Add("PRICE", typeof(string));//价格
            #endregion


            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox chkMat_Code = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkMat_Code");
                Literal ltlC_TECH_PROT = (Literal)rptList.Items[i].FindControl("ltlC_TECH_PROT");//客户协议
                Literal ltlC_STD_CODE = (Literal)rptList.Items[i].FindControl("ltlC_STD_CODE");//执行标准
                Literal ltlzyx1 = (Literal)rptList.Items[i].FindControl("ltlzyx1");//自由项1
                Literal ltlzyx2 = (Literal)rptList.Items[i].FindControl("ltlzyx2");//自由项2
                Literal ltlC_IS_BXG = (Literal)rptList.Items[i].FindControl("ltlC_IS_BXG");//是否不锈钢
                Literal ltlC_PACK = (Literal)rptList.Items[i].FindControl("ltlC_PACK");//包装
                Literal ltlwgt = (Literal)rptList.Items[i].FindControl("ltlwgt");//数量
                Literal ltlprice = (Literal)rptList.Items[i].FindControl("ltlprice");//单价

                if (chkMat_Code.Checked)
                {
                    Mod_TB_MATRL_MAIN modMat = tb_matrl_main.GetMatModel(chkMat_Code.Value);

                    dt.Rows.Add(new object[] {
                        modMat.C_ID,
                        modMat.C_MAT_CODE,
                        modMat.C_MAT_NAME,
                        modMat.C_STL_GRD,
                        modMat.C_SPEC,
                        ltlC_TECH_PROT.Text,
                        ltlC_STD_CODE.Text,
                        ltlzyx1.Text,
                        ltlzyx2.Text,
                        ltlC_IS_BXG.Text,
                        ltlC_PACK.Text,
                        ltlwgt.Text,
                        ltlprice.Text});
                }
            }
            if (dt.Rows.Count > 0)
            {
                Session["kh"] = dt;
                Response.Write("<script>window.parent.document.getElementById('imgbtnJz').click();window.parent.close();</script>");
            }
            else
            {
                Response.Write("<script>window.close();</script>");
            }
        }

        protected void txtConNo_TextChanged(object sender, EventArgs e)
        {
            GetOrder();
        }

        protected void txtstlgrd_TextChanged(object sender, EventArgs e)
        {
            GetOrder();
        }
    }
}