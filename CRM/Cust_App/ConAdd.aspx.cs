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
    public partial class ConAdd : System.Web.UI.Page
    {
        private Bll_TS_DIC dic = new Bll_TS_DIC();
        private Bll_TS_CUSTFILE custFile = new Bll_TS_CUSTFILE();
        private Bll_TMB_AREAMAX areamax = new Bll_TMB_AREAMAX();
        private Bll_TMO_CONDETAILS condetails = new Bll_TMO_CONDETAILS();
        private Bll_TMO_CON con = new Bll_TMO_CON();
        private Bll_TMB_COMDIFF comdiff = new Bll_TMB_COMDIFF();
        private Bll_TQB_DESIGN_ORDER design_order = new Bll_TQB_DESIGN_ORDER();

        IBasicsDataService service = DIFactory.GetContainer().Resolve<IBasicsDataService>();




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取用户所属公司名称
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    //初始化日期
                    txtDate.Value = Convert.ToDateTime(DateTime.Now).ToString("yyy-MM-dd");

                    DateTime dt = DateTime.Now;
                    txtStart.Value = Convert.ToDateTime(dt).ToString("yyy-MM-dd");
                    txtEnd.Value = Convert.ToDateTime(dt.AddDays(10)).ToString("yyy-MM-dd");

                    BindCurrency();
                    BindContractType();
                    BindShipVia();
                    BindArea();

                    ltlCustName.Text = BaseUser.Name;

                    Mod_TS_CUSTFILE mod = custFile.GetModel(BaseUser.CustId);
                    if (mod != null)
                    {
                        txtCustName.Text = mod.C_NAME;
                        ltlCUST_NO.Text = mod.C_NO;
                        ltlCustLEV.Text = mod.N_LEVEL.ToString() == "1" ? "普通" : "优先";
                    }


                    if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                    {
                        txtConNO.Text = Request.QueryString["ID"];
                        BindConInfo();
                    }
                }
                else
                {
                    WebMsg.CheckUserLogin();
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
                    txtState.Text = GetOrderState(Convert.ToInt32(mod.N_CON_STATUS));
                    hidState.Value = mod.N_CON_STATUS.ToString();

                    bool status = mod.N_CON_STATUS.ToString() == "-1" ? true : false;
                    btnSave.Enabled = status;
                    btnAdd.Disabled = mod.N_CON_STATUS.ToString() == "-1" ? false : true;
                    btnEdit.Disabled = mod.N_CON_STATUS.ToString() == "-1" ? false : true;
                    btnDel.Enabled = status;
                    btnSubmit.Enabled = status;

                }

                BindConOrder();
            }
        }

        private string GetOrderState(int n)
        {
            string result = string.Empty;
            switch (n)
            {
                case -1:
                    result = "未提交";
                    break;
                case 0:
                    result = "待审";
                    break;
                case 1:
                    result = "审核中";
                    break;
                case 2:
                    result = "生效";
                    break;
            }
            return result;
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

                    #region //获取订单数量合计/总计划失效时间

                    dt.DefaultView.Sort = "D_DELIVERY_DT desc";

                    dt = dt.DefaultView.ToTable();

                    decimal sum = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sum += Convert.ToDecimal(dt.Rows[i]["N_WGT"]);
                    }

                    txtEnd.Value = Convert.ToDateTime(dt.Rows[0]["D_DELIVERY_DT"]).ToString("yyy-MM-dd");
                    ltlSysDate.Text = Convert.ToDateTime(dt.Rows[0]["D_SYS_DELIVERY_DT"]).ToString("yyy-MM-dd");

                    lblSum.Text = sum.ToString();
                    #endregion
                }
                else
                {
                    rptList.DataSource = null;
                    rptList.DataBind();
                }
            }
        }



        /// <summary>
        /// 获取货币类型
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

        //查询合同明细
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindConOrder();
        }

        //保存合同基本信息
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtConNO.Text) && hidState.Value == "-1")
            {
                //更新
                Mod_TMO_CON mod = con.GetModel(txtConNO.Text);
                mod.C_CON_NAME = txtConName.Text;
                mod.C_CON_TYPE = dropConType.SelectedItem.Text;
                mod.C_CUST_NAME = txtCustName.Text;
                mod.C_CUST_MAKING = ltlCustName.Text;
                mod.C_CUST_MAKING_DT = DateTime.Now;
                mod.C_CURRENCY_TYPE = dropCurrType.SelectedItem.Text;
                mod.D_CONSING_DT = Convert.ToDateTime(txtDate.Value);
                mod.D_CONEFFE_DT = Convert.ToDateTime(txtStart.Value);
                mod.D_CONINVALID_DT = Convert.ToDateTime(txtEnd.Value);

                if (!string.IsNullOrEmpty(ltlSysDate.Text))
                {
                    mod.D_SYS_CONINVALID_DT = Convert.ToDateTime(ltlSysDate.Text);
                }
                else
                {
                    mod.D_SYS_CONINVALID_DT = Convert.ToDateTime(txtEnd.Value);
                }

                mod.C_SHIPVIA = dropShipVia.SelectedItem.Text;
                mod.C_CON_AREA = dropConArea.SelectedItem.Text;

                if (con.Update(mod))
                {
                    WebMsg.MessageBox("保存成功");
                }
            }
            else
            {
                //新增一条
                string conNo = service.CreateConNo(Convert.ToInt32(dropConArea.SelectedValue));

                Mod_TMO_CON mod = new Mod_TMO_CON();
                mod.C_CON_NO = conNo;
                mod.C_CON_NAME = txtConName.Text;
                mod.C_CON_TYPE = dropConType.SelectedItem.Text;
                mod.C_CUST_NO = ltlCUST_NO.Text;
                mod.C_CUST_NAME = txtCustName.Text;
                mod.C_CUST_MAKING = ltlCustName.Text;
                mod.C_CUST_MAKING_DT = DateTime.Now;
                mod.C_CURRENCY_TYPE = dropCurrType.SelectedItem.Text;
                mod.D_CONSING_DT = Convert.ToDateTime(txtDate.Value);
                mod.D_CONEFFE_DT = Convert.ToDateTime(txtStart.Value);
                mod.D_CONINVALID_DT = Convert.ToDateTime(txtEnd.Value);
                if (!string.IsNullOrEmpty(ltlSysDate.Text))
                {
                    mod.D_SYS_CONINVALID_DT = Convert.ToDateTime(ltlSysDate.Text);
                }
                else
                {
                    mod.D_SYS_CONINVALID_DT = Convert.ToDateTime(txtEnd.Value);
                }

                mod.C_SHIPVIA = dropShipVia.SelectedItem.Text;
                mod.C_CON_AREA = dropConArea.SelectedItem.Text;

                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

                if (BaseUser != null)
                {
                    mod.C_EMP_ID = BaseUser.Id;
                    mod.C_EMP_NAME = BaseUser.Name;
                }
                if (con.Add(mod))
                {
                    WebMsg.MessageBox("保存成功,请添加订单");
                    txtConNO.Text = conNo;
                    txtState.Text = GetOrderState(-1);
                }
            }

        }



        //删除
        protected void btnDel_Click(object sender, EventArgs e)
        {
            bool result = false;

            foreach (RepeaterItem rpt in rptList.Items)
            {
                HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)rpt.FindControl("chkSelect");
                if (chkSelect.Checked)
                {
                    if (condetails.Delete(chkSelect.Value))//删除合同明细
                    {
                        result = design_order.DeleteOder(chkSelect.Value);//删除订单-质量信息
                    }
                }
            }
            if (result)
            {
                //WebMsg.MessageBox("删除成功");

                //重新加载订单
                BindConOrder();
            }
        }

        //提交合同
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtConNO.Text) && !string.IsNullOrEmpty(txtCustName.Text))
            {
                if (rptList.Items.Count > 0)
                {
                    Mod_TMO_CON modcon = con.GetModel(txtConNO.Text);
                    modcon.N_CON_STATUS = 0;//更新合同状态
                    modcon.D_CONINVALID_DT = Convert.ToDateTime(txtEnd.Value);
                    modcon.D_SYS_CONINVALID_DT = Convert.ToDateTime(ltlSysDate.Text);//系统计划失效日期
                    if (con.Update(modcon))
                    {
                        #region//获取发货上允差
                        decimal range = 0;
                        DataTable dt = comdiff.GetRangeList(Convert.ToDecimal(lblSum.Text)).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            range = Convert.ToDecimal(dt.Rows[0]["C_RANGE"]);
                        }
                        #endregion

                        //更新每个订单状态和发货上允差
                        bool result = false;
                        foreach (RepeaterItem rpt in rptList.Items)
                        {
                            HtmlInputCheckBox chkSelect = (HtmlInputCheckBox)rpt.FindControl("chkSelect");
                            result = condetails.UpdateGC(range, chkSelect.Value);
                        }
                        if (result)
                        {
                            WebMsg.MessageBox("提交成功", "MyCon.aspx");
                        }
                    }
                }
                else
                {
                    WebMsg.MessageBox("请添加订单");
                    return;
                }
            }
            else
            {
                WebMsg.MessageBox("请输入合同名称，再点击保存");
            }
        }
    }
}