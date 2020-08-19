using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.BLL;
using NF.NC.Interface;
using System.Data;
using NF.Framework;
using NF.MODEL;

namespace CRM.WebForms.Sale_App
{
    public partial class demo : System.Web.UI.Page
    {

        private Bll_TMO_SALEORDER tmo_saleorder = new Bll_TMO_SALEORDER();

        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();

        private ApiOrder apiorder = new ApiOrder();
        private ApiDayPlan apidayplan = new ApiDayPlan();
        private ApiDispatchOrder apidispatchorder = new ApiDispatchOrder();
        private ApiWL apiwl = new ApiWL();
        private ApiWL_SJ apiwl_sj = new ApiWL_SJ();

        private ApiSaleCon apisalecon = new ApiSaleCon();

        private ApiSaleOrder apisaleorder = new ApiSaleOrder();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //销售订单导入NC
        protected void Button1_Click(object sender, EventArgs e)
        {
            #region //导入NC

            Mod_TMO_CON mod = tmo_con.GetModel(txtCON.Text);

            List<ApiOrderDto> orderDto = new List<ApiOrderDto>();
            ApiOrderDto dto = new ApiOrderDto();
            dto.NC_ID ="";
            dto.SaleCode = txtConNo.Text;
            dto.ConNO = mod.C_CON_NO;
            dto.D_NC_DATE =mod.D_MOD_DT.ToString();
            orderDto.Add(dto);
            string result = "";
            string filePath = "~/FileInterface/download/" + txtConNo.Text + ".xml";
            string xmlFileName = System.Web.HttpContext.Current.Server.MapPath(filePath);
            List<string> resList = apisaleorder.SendXmlOrder(orderDto, xmlFileName, "");
            #endregion

            string jg = resList[0].ToString().ToString() == "1" ? "导入NC成功" : GetNCError(resList);
            result = "单据号：" + txtConNo.Text + ",结果：" + jg;

            WebMsg.MessageBox(result);
        }


        private string GetNCError(List<string> arrstr)
        {
            if (arrstr.Count < 2) { return "上传NC失败，请联系管理员"; }
            var result = arrstr[1].Replace("\r\n", "<br/>").Replace("\r", "<br/>").Replace("\n", "<br/>").Replace(" ", "&nbsp;");

            return result;
        }


        //发运日计划导入NC
        protected void Button2_Click(object sender, EventArgs e)
        {
            string strmsg = string.Empty;

            string fileName = txtDayPlanCode.Text + ".xml";
            string filePath = "../../FileInterface/" + fileName;
            string xmlFileName = Server.MapPath(filePath);
            List<string> result = apidayplan.SendXmlDayPlan(txtDayPlanCode.Text, xmlFileName, "");
            strmsg += "代码：" + result[0] + ",结果：" + result[2] + "\n";
            WebMsg.MessageBox(strmsg);
        }

        //发运单物流导入NC
        protected void Button3_Click(object sender, EventArgs e)
        {
            string strmsg = string.Empty;
            string fileName = txtFYD.Text + ".xml";
            string filePath = "../../FileInterface/" + fileName;
            string xmlFileName = Server.MapPath(filePath);
            List<string> result = apidispatchorder.SendXmlApiDispatchOrder(txtFYD.Text, xmlFileName, "",6);
            strmsg += "代码：" + result[0] + ",结果：" + result[2] + "\n";
            WebMsg.MessageBox(strmsg);
        }

        //发运单导入物流
        protected void Button4_Click(object sender, EventArgs e)
        {
            string strmsg = string.Empty;
            string fileName = txtFYD0.Text + ".xml";
            string filePath = "../../FileInterface/" + fileName;
            string xmlFileName = Server.MapPath(filePath);
            string result = apiwl.SendXmlApiDispatchOrder(txtFYD0.Text, xmlFileName, "");
            WebMsg.MessageBox(result);
        }

        //物流实绩导入NC
        protected void Button5_Click(object sender, EventArgs e)
        {
            List<ApiDispDto> apiDispList = new List<ApiDispDto>();
            string strmsg = string.Empty;
            string fileName = txtFYD1.Text + ".xml";
            string filePath = "~/FileInterface/" + fileName;
            string xmlFileName = Server.MapPath(filePath);
            bool result = apiwl_sj.SendXml_DM(xmlFileName, txtFYD1.Text, apiDispList);
            WebMsg.MessageBox(result == true ? "成功" : "失败");
        }


        //销售合同导入NC
        protected void Button6_Click(object sender, EventArgs e)
        {
            string strmsg = string.Empty;
            string fileName =txtCON.Text+ ".xml";
            string filePath = "../../FileInterface/download/" + fileName;
            string xmlFileName = Server.MapPath(filePath);
            List<string> result =apisalecon.SendXmlOrder(txtCON.Text, xmlFileName, "");
           strmsg += "代码：" + result[0] + ",结果：" + result[2]+ "";

            WebMsg.MessageBox(strmsg);
        }
    }
}