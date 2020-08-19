using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Data;
using NF.MODEL;
using NF.BLL;
using NF.Framework;
using NF.Bussiness.Interface;
using NF.Web.Core;
using Microsoft.Practices.Unity;


namespace CRM.Cust_App
{
    public partial class ConView : System.Web.UI.Page
    {
        private Bll_TS_DIC dic = new Bll_TS_DIC();
        private Bll_TS_CUSTFILE custFile = new Bll_TS_CUSTFILE();
        private Bll_TMB_AREAMAX areamax = new Bll_TMB_AREAMAX();
        private Bll_TMO_CONDETAILS condetails = new Bll_TMO_CONDETAILS();
        private Bll_TMO_CON con = new Bll_TMO_CON();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCurrency();
                BindContractType();
                BindShipVia();
                BindArea();
                
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    txtConNO.Text = Request.QueryString["ID"];
                    BindConInfo();
                }
            }
        }

        /// <summary>
        /// 绑定合同相关信息
        /// </summary>
        private void BindConInfo()
        {
            if (!string.IsNullOrEmpty(txtConNO.Text))
            {
                Mod_TMO_CON mod = con.GetModel(txtConNO.Text);
                if (mod != null)
                {
                    dropCurrType.SelectedIndex = dropCurrType.Items.IndexOf(dropCurrType.Items.FindByText(mod.C_CURRENCY_TYPE));
                    txtDate.Value = Convert.ToDateTime(mod.D_CONSING_DT).ToString("yyy-MM-dd");
                    txtStart.Value = Convert.ToDateTime(mod.D_CONEFFE_DT).ToString("yyy-MM-dd");
                    txtEnd.Value = Convert.ToDateTime(mod.D_CONINVALID_DT).ToString("yyy-MM-dd");
                    dropConType.SelectedIndex = dropConType.Items.IndexOf(dropConType.Items.FindByText(mod.C_CON_TYPE));
                    txtConNO.Text = mod.C_CON_NO;
                    txtConName.Text = mod.C_CON_NAME;
                    txtCustName.Text = mod.C_CUST_NAME;
                    dropShipVia.SelectedIndex = dropShipVia.Items.IndexOf(dropShipVia.Items.FindByText(mod.C_SHIPVIA));
                    dropConArea.SelectedIndex = dropConArea.Items.IndexOf(dropConArea.Items.FindByText(mod.C_CON_AREA));
                    txtState.Text = GetOrderState(mod.N_CON_STATUS);
                    hidState.Value = mod.N_CON_STATUS.ToString();

                    BindConOrder();
                }

               
            }
        }

        /// <summary>
        /// 绑定合同明细
        /// </summary>
        private void BindConOrder()
        {
            if (!string.IsNullOrEmpty(txtConNO.Text))
            {
                DataTable dt = condetails.GetConOrderList(txtConNO.Text, "").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    rptList.DataSource = dt;
                    rptList.DataBind();

                    decimal sum = 0;
                   
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sum += Convert.ToDecimal(dt.Rows[i]["N_WGT"]);

                    }
                   
                    lblSum.Text = sum.ToString();

                }
                else
                {
                    rptList.DataSource = null;
                    rptList.DataBind();
                }
            }
        }



        /// <summary>
        /// 获取类型
        /// </summary>
        private void BindCurrency()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "Currency";
            DataTable dt = dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropCurrType.DataSource = dt;
                dropCurrType.DataTextField = "C_DETAILNAME";
                dropCurrType.DataValueField = "C_ID";
                dropCurrType.DataBind();
            }
            else
            {
                dropCurrType.DataSource = null;
                dropCurrType.DataBind();
            }
        }

        /// <summary>
        /// 合同类型
        /// </summary>
        private void BindContractType()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ContractType";
            DataTable dt = dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropConType.DataSource = dt;
                dropConType.DataTextField = "C_DETAILNAME";
                dropConType.DataValueField = "C_ID";
                dropConType.DataBind();
            }
            else
            {
                dropConType.DataSource = null;
                dropConType.DataBind();
            }
        }

        /// <summary>
        /// 发运方式
        /// </summary>
        private void BindShipVia()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ShipVia";
            DataTable dt = dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropShipVia.DataSource = dt;
                dropShipVia.DataTextField = "C_DETAILNAME";
                dropShipVia.DataValueField = "C_ID";
                dropShipVia.DataBind();
            }
            else
            {
                dropShipVia.DataSource = null;
                dropShipVia.DataBind();
            }
        }

        /// <summary>
        /// 合同区域
        /// </summary>
        private void BindArea()
        {

            DataTable dt = areamax.GetAreaList("").Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropConArea.DataSource = dt;
                dropConArea.DataTextField = "C_Name";
                dropConArea.DataValueField = "C_CODE";
                dropConArea.DataBind();
            }
            else
            {
                dropConArea.DataSource = null;
                dropConArea.DataBind();
            }
        }


        /// <summary>
        /// 合同状态
        /// </summary>
        /// <param name="OrderStateId">标识</param>
        /// <returns></returns>
        public static string GetOrderState(object OrderStateId)
        {
            string _name = string.Empty;
            int _status = Convert.ToInt32(OrderStateId);

            switch (_status)
            {
                case -1:
                    _name = "未提交";
                    break;
                case 0:
                    _name = "待审";
                    break;
                case 1:
                    _name = "审核中";
                    break;
                case 2:
                    _name = "生效";
                    break;
                case 3:
                    _name = "撤回";
                    break;
                case 4:
                    _name = "冻结";
                    break;
            }
            return _name;

        }
    }
}