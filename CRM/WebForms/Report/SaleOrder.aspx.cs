using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data;
using NF.Framework;
using NF.BLL;
using NF.MODEL;
using NF.NC.Interface;

namespace CRM.WebForms.Report
{
    public partial class SaleOrder : System.Web.UI.Page
    {
        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_TMP_DAYPLAN tmp_dayplan = new Bll_TMP_DAYPLAN();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlempid.Text = vUser.Id;

                    DateTime dt = DateTime.Now;
                    Start.Value = dt.AddMonths(-3).ToString("yyy-MM-dd");
                    End.Value = dt.ToString("yyy-MM-dd");

                }
            }
        }

        private void GetSale()
        {
            DataTable dt = tmo_order.GetSaleCode(txtcustname.Text, txtconno.Text, txtyewuyuan.Text, Start.Value, End.Value).Tables[0];

            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = dt.DefaultView;
            Pager1.RecordCount = ps.Count;
            if (Pager1.RecordCount > 0)
            {
                ps.AllowPaging = true;
                ps.PageSize = Pager1.PageSize;
                ps.CurrentPageIndex = Pager1.CurrentPageIndex - 1;

                rptSale.DataSource = ps;
                rptSale.DataBind();
            }
            else
            {
                rptSale.DataSource = null;
                rptSale.DataBind();
            }
        }
        //分页
        protected void Pager1_PageChanged(object sender, EventArgs e)
        {
            GetSale();
        }

        //查询
        protected void btncx_Click(object sender, EventArgs e)
        {
            GetSale();

            rptList.DataSource = null;
            rptList.DataBind();
        }

        private string GetNCError(List<string> arrstr)
        {
            if (arrstr.Count < 2) { return "上传NC失败，请联系管理员"; }
            var result = arrstr[1].Replace("\r\n", "<br/>").Replace("\r", "<br/>").Replace("\n", "<br/>").Replace(" ", "&nbsp;");

            return result;
        }


        #region //销售合同导入NC
        private void NC_SaleCon(string conNO)
        {
            if (tmo_con.GetSaleCon(conNO) == "N")
            {
                ApiSaleCon apisalecon = new ApiSaleCon();
                string result = "";
                string fileName = conNO + ".xml";
                string filePath = "../../FileInterface/download/" + fileName;
                string xmlFileName = Server.MapPath(filePath);
                List<string> resList = apisalecon.SendXmlOrder(conNO, xmlFileName, ltlempid.Text);
                result = "销售合同：" + conNO + ",结果：" + GetNCError(resList);
                if (resList[0].ToString() == "1")
                {
                    tmo_con.UpdateNC("Y", conNO);
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + result + "');</script>", false);
                }
            }

        }
        #endregion


        #region //销售订单导入NC
        /// <summary>
        /// 销售订单导入NC
        /// </summary>
        /// <param name="NC_ID">NC主键</param>
        /// <param name="SaleCode">销售单据号</param>
        /// <param name="ConNO">合同号</param>
        /// <param name="D_NC_DATE">销售单据号日期</param>
        private void NC_SaleOrder(string NC_ID, string SaleCode, string ConNO, string D_NC_DATE)
        {
            ApiSaleOrder apisaleorder = new ApiSaleOrder();
            List<ApiOrderDto> orderDto = new List<ApiOrderDto>();
            ApiOrderDto dto = new ApiOrderDto();
            dto.NC_ID = NC_ID;
            dto.SaleCode = SaleCode;
            dto.ConNO = ConNO;
            dto.D_NC_DATE = D_NC_DATE;
            orderDto.Add(dto);
            string result = "";
            string filePath = "~/FileInterface/download/" + SaleCode + ".xml";
            string xmlFileName = System.Web.HttpContext.Current.Server.MapPath(filePath);
            List<string> resList = apisaleorder.SendXmlOrder(orderDto, xmlFileName, ltlempid.Text);

            string jg = resList[0].ToString().ToString() == "1" ? "导入NC成功" : GetNCError(resList);
            result = "单据号：" + SaleCode + ",结果：" + jg;

            if (resList[0].ToString() == "1")
            {
                if (tmo_order.UpdateExeStatus(2, SaleCode))//更新执行状态
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + result + "');</script>", false);
                    GetSale();
                }

            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + result + "');</script>", false);
            }



        }
        #endregion

        //销售订单导入NC
        protected void btncdr_Click(object sender, EventArgs e)
        {
            rptList.DataSource = null;
            rptList.DataBind();
            try
            {
                for (int i = 0; i < rptSale.Items.Count; i++)
                {
                    HtmlInputRadioButton rdoselect = (HtmlInputRadioButton)rptSale.Items[i].FindControl("rdoselect");
                    Literal ltlsalecode = (Literal)rptSale.Items[i].FindControl("ltlsalecode");
                    Literal ltlconno = (Literal)rptSale.Items[i].FindControl("ltlconno");
                    Literal ltldate = (Literal)rptSale.Items[i].FindControl("ltldate");

                    if (rdoselect.Checked)
                    {

                        //销售合同导入NC
                        NC_SaleCon(ltlconno.Text);

                        //销售订单导入NC
                        NC_SaleOrder(rdoselect.Value, ltlsalecode.Text, ltlconno.Text, ltldate.Text);

                    }
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }

        //日计划导入NC
        protected void btnplan_nc_Click(object sender, EventArgs e)
        {
            try
            {
                int num1 = 0;//成功
                int num2 = 0;//失败
                ApiDayPlan apidayplan = new ApiDayPlan();
                StringBuilder strResult = new StringBuilder();
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                    Literal ltlplancode = (Literal)rptList.Items[i].FindControl("ltlplancode");

                    if (cbxselect.Checked)
                    {
                        string filePath = "~/FileInterface/download/" + ltlplancode.Text + ".xml";
                        string xmlFileName = Server.MapPath(filePath);
                        List<string> resList = apidayplan.SendXmlDayPlan(ltlplancode.Text, xmlFileName, ltlempid.Text);
                        if (resList[0].ToString() == "1")
                        {
                            num1 += 1;
                            tmp_dayplan.UpdateDayPlanStatus(ltlplancode.Text);//更新日计划状态
                        }
                        else
                        {
                            num2 += 1;
                        }
                    }
                }
                string msg = num1 + "条导入成功," + "失败：" + num2 + "条";
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + msg + "');</script>", false);
                GetList();//加载日计划

            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }

        }

        protected void rptSale_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "xc")
            {
                ltlPlanCode.Text = e.CommandArgument.ToString();
                GetList();
            }
        }

        private void GetList()
        {
            DataTable dt = tmo_order.GetSaleOrder(ltlPlanCode.Text).Tables[0];
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

        //删除订单
        protected void btndel_Click(object sender, EventArgs e)
        {
            rptList.DataSource = null;
            rptList.DataBind();

            try
            {
                for (int i = 0; i < rptSale.Items.Count; i++)
                {
                    HtmlInputRadioButton rdoselect = (HtmlInputRadioButton)rptSale.Items[i].FindControl("rdoselect");
                    if (rdoselect.Checked)
                    {

                        if (tmo_order.DelNCSalePlan(rdoselect.Value))
                        {
                            if (tmo_order.DelSalePlan(rdoselect.Value))
                            {

                                WebMsg.MessageBox("删除成功");
                                GetSale();
                            }
                        }
                        else
                        {
                            WebMsg.MessageBox("请先同步删除NC订单号与计划号");
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }

        protected void btndel_day_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new List<Mod_TMP_DAYPLAN>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                    if (cbxselect.Checked)
                    {
                        var mod = new Mod_TMP_DAYPLAN() { C_ID = cbxselect.Value };
                        list.Add(mod);
                    }
                }

                if (tmo_order.DelDayPlan(list))
                {
                    WebMsg.MessageBox("删除成功");
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }
    }
}