using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using NF.BLL;
using NF.MODEL;
using NF.Framework;

namespace CRM.Sale_App
{
    public partial class ConEdit : System.Web.UI.Page
    {
        private Bll_TS_DIC dic = new Bll_TS_DIC();
        private Bll_TMB_AREAPLAN areaplan = new Bll_TMB_AREAPLAN();
        private Bll_TMB_FLOWINFO flowinfo = new Bll_TMB_FLOWINFO();
        private Bll_TMO_CON con = new Bll_TMO_CON();
        private Bll_TMO_CONDETAILS condetails = new Bll_TMO_CONDETAILS();
        private Bll_TMB_AREAMAX areamax = new Bll_TMB_AREAMAX();
        private Bll_TS_USER user = new Bll_TS_USER();
        private Bll_TS_DEPT dept = new Bll_TS_DEPT();

        private Bll_TMF_FILEINFO fileinfo = new Bll_TMF_FILEINFO();
        private Bll_TMB_FLOWPROC flowproc = new Bll_TMB_FLOWPROC();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    ltlUserID.Text = BaseUser.Id;

                    #region //加载基础数据

                    GetConType(); //合同类型
                    GetShipVia();//发运方式
                    GetCurrency(); //币种
                    GetBusinessType();//业务类型
                    GetSalesOrg();//销售组织
                    GetConClass();//合同分类
                    GetPlanWGT();//区域计划量/实际接收订单量
                    GetArea();//区域

                    #endregion

                    if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                    {
                        txtConNO.Value = Request.QueryString["ID"];
                        GetConInfo();//加载合同信息
                    }
                }
            }
        }

        /// <summary>
        /// 加载合同信息
        /// </summary>
        private void GetConInfo()
        {
            if (!string.IsNullOrEmpty(txtConNO.Value))
            {
                Mod_TMO_CON modcon = con.GetModel(txtConNO.Value);
                if (modcon != null)
                {
                    txtConName.Value = modcon.C_CON_NAME;
                    dropConType.SelectedIndex = dropConType.Items.IndexOf(dropConType.Items.FindByText(modcon.C_CON_TYPE));
                    txtCustName.Value = modcon.C_CUST_NAME;
                    txtQianDanDT.Value = Convert.ToDateTime(modcon.D_CONSING_DT).ToString("yyy-MM-dd");
                    txtPlanStartDT.Value = Convert.ToDateTime(modcon.D_CONEFFE_DT).ToString("yyy-MM-dd");
                    txtPlanEndDT.Value = Convert.ToDateTime(modcon.D_CONINVALID_DT).ToString("yyy-MM-dd");
                    txtSysPlanEndDT.Value = Convert.ToDateTime(modcon.D_SYS_CONINVALID_DT).ToString("yyy-MM-dd");
                    txtCustLEV.Value = modcon.N_CUST_LEV.ToString() == "1" ? "优先" : "普通";
                    dropFaYun.SelectedIndex = dropFaYun.Items.IndexOf(dropFaYun.Items.FindByText(modcon.C_SHIPVIA));
                    dropBiZhong.SelectedIndex = dropBiZhong.Items.IndexOf(dropBiZhong.Items.FindByText(modcon.C_CURRENCY_TYPE));
                    dropYeWuType.SelectedIndex = dropYeWuType.Items.IndexOf(dropYeWuType.Items.FindByText(modcon.C_BUSINESS_TYPE));

                    #region //部门
                    Mod_TS_DEPT modDept = dept.GetModel(modcon.C_DEPT_ID);
                    if (modDept != null)
                    {
                        txtDept.Value = modDept.C_NAME;
                        hidDeptID.Value = modcon.C_DEPT_ID;
                    }

                    #endregion

                    #region //业务员
                    txtSaleUser.Value = GetUserName(modcon.C_SALESMAN);
                    hidEmpID.Value = modcon.C_SALESMAN;
                    #endregion

                    dropSale.SelectedIndex = dropSale.Items.IndexOf(dropSale.Items.FindByText(modcon.C_SALE_DEPT));

                    dropClass.SelectedIndex = dropClass.Items.IndexOf(dropClass.Items.FindByText(GetConFlag(Convert.ToInt32(modcon.N_FLAG))));

                    txtKC.Value = modcon.C_STOCK_DEPT;

                    #region //收货单位/收货地址/开票单位

                    DataTable dt1 = condetails.GetCGC_OTC(txtConNO.Value).Tables[0];
                    if (dt1.Rows.Count > 0)
                    {
                        txtShuoHuoCompany.Value = dt1.Rows[0]["C_CGC"].ToString();
                        txtShuoHuoAddr.Value = dt1.Rows[0]["C_CGADDR"].ToString();
                        txtKaiPiaoCompany.Value = dt1.Rows[0]["C_OTC"].ToString();
                    }


                    #endregion

                    dropArea.SelectedIndex = dropArea.Items.IndexOf(dropArea.Items.FindByText(modcon.C_CON_AREA));

                    txtState.Value = StringFormat.GetOrderState(modcon.N_CON_STATUS);

                    if (!string.IsNullOrEmpty(modcon.C_ISSHIP))
                    {
                        chkIsFaYun.Checked = modcon.C_ISSHIP == "0" ? false : true;
                    }

                    
                    txtDESC.Value = modcon.C_DESC;

                    txtZhiDanRen.Value = modcon.C_CUST_MAKING;
                    txtZhiDanTime.Value = modcon.C_CUST_MAKING_DT.ToString();

                    #region //最后修改人/最后修改时间 /审批人/审批时间

                    txtLastEditUser.Value = GetUserName(modcon.C_XG_MODIFY);
                    txtLastEditTime.Value = modcon.C_XG_MODEIFY_DT.ToString();

                    txtCheckUser.Value = GetUserName(modcon.C_APPROVER);
                    txtCheckTime.Value = modcon.D_APPROVER_DT.ToString();

                    #endregion


                    iframe1.Src = "Con_OrderList.aspx?ID="+txtConNO.Value;
                }

            }
        }

        #region //加载基础数据

        /// <summary>
        /// 获取区域
        /// </summary>
        private void GetArea()
        {
            DataTable dt = areamax.GetAreaList("").Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropArea.DataSource = dt;
                dropArea.DataTextField = "C_NAME";
                dropArea.DataValueField = "C_NAME";
                dropArea.DataBind();
            }
            else
            {
                dropArea.DataSource = null;
                dropArea.DataBind();
            }
        }

        /// <summary>
        /// 区域计划量/实际接收订单量
        /// </summary>
        private void GetPlanWGT()
        {
            DataTable dt = areaplan.GetPlanWGT().Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ltlWGT.Text += "<span style=\"margin-left:15px; \">" + dt.Rows[i]["wgt"].ToString() + "</span>";
                }
            }
        }

        /// <summary>
        /// 合同分类
        /// </summary>
        private void GetConClass()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "OrderPreceLevel";
            DataTable dt = dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropClass.DataSource = dt;
                dropClass.DataTextField = "C_DETAILNAME";
                dropClass.DataValueField = "C_DETAILCODE";
                dropClass.DataBind();
            }
            else
            {
                dropClass.DataSource = null;
                dropClass.DataBind();
            }
        }

        /// <summary>
        /// 销售组织
        /// </summary>
        private void GetSalesOrg()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "SalesOrg";
            DataTable dt = dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropSale.DataSource = dt;
                dropSale.DataTextField = "C_DETAILNAME";
                dropSale.DataValueField = "C_DETAILNAME";
                dropSale.DataBind();
            }
            else
            {
                dropSale.DataSource = null;
                dropSale.DataBind();
            }
        }

        /// <summary>
        /// 业务类型
        /// </summary>
        private void GetBusinessType()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "BusinessType";
            DataTable dt = dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropYeWuType.DataSource = dt;
                dropYeWuType.DataTextField = "C_DETAILNAME";
                dropYeWuType.DataValueField = "C_DETAILNAME";
                dropYeWuType.DataBind();
            }
            else
            {
                dropYeWuType.DataSource = null;
                dropYeWuType.DataBind();
            }
        }

        /// <summary>
        /// 获取货币类型
        /// </summary>
        private void GetCurrency()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "Currency";
            DataTable dt = dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropBiZhong.DataSource = dt;
                dropBiZhong.DataTextField = "C_DETAILNAME";
                dropBiZhong.DataValueField = "C_DETAILNAME";
                dropBiZhong.DataBind();
            }
            else
            {
                dropBiZhong.DataSource = null;
                dropBiZhong.DataBind();
            }
        }

        /// <summary>
        /// 合同类型
        /// </summary>
        private void GetConType()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ContractType";
            DataTable dt = dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropConType.DataSource = dt;
                dropConType.DataTextField = "C_DETAILNAME";
                dropConType.DataValueField = "C_DETAILNAME";
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
        private void GetShipVia()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ShipVia";
            DataTable dt = dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropFaYun.DataSource = dt;
                dropFaYun.DataTextField = "C_DETAILNAME";
                dropFaYun.DataValueField = "C_DETAILNAME";
                dropFaYun.DataBind();
            }
            else
            {
                dropFaYun.DataSource = null;
                dropFaYun.DataBind();
            }
        }

        #endregion


        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region //保存
            Mod_TMO_CON mod = con.GetModel(txtConNO.Value);
            if (mod != null)
            {
                mod.C_CON_NAME = txtConName.Value;
                mod.C_CON_TYPE = dropConType.SelectedItem.Text;
                mod.D_CONSING_DT = Convert.ToDateTime(txtQianDanDT.Value);
                mod.D_CONEFFE_DT = Convert.ToDateTime(txtPlanStartDT.Value);
                mod.D_CONINVALID_DT = Convert.ToDateTime(txtPlanEndDT.Value);
                mod.C_SHIPVIA = dropFaYun.SelectedItem.Text;
                mod.C_CURRENCY_TYPE = dropBiZhong.SelectedItem.Text;
                mod.C_BUSINESS_TYPE = dropYeWuType.SelectedItem.Text;
                mod.C_DEPT_ID = hidDeptID.Value;
                mod.C_SALESMAN = hidEmpID.Value;
                mod.C_SALE_DEPT = dropSale.SelectedValue;
                mod.N_FLAG = Convert.ToInt32(dropClass.SelectedValue);
                mod.C_STOCK_DEPT = txtKC.Value;
                mod.C_CON_AREA = dropArea.SelectedValue;
                mod.C_ISSHIP = chkIsFaYun.Checked == true ? "1" : "0";
               
                mod.C_DESC = txtDESC.Value;

                mod.N_FLAG = Convert.ToInt32(GetConFlag(dropClass.SelectedItem.Text));

                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    mod.C_XG_MODIFY = BaseUser.Id;
                    mod.C_XG_MODEIFY_DT = DateTime.Now;
                }

                if (con.Update(mod))
                {
                    #region //更新订单等级

                    int lev = Convert.ToInt32(dropClass.SelectedValue);

                    if (condetails.UpdateOrderLEV(txtConNO.Value, lev))
                    {
                        WebMsg.MessageBox("保存成功");
                        GetConInfo();//重新加载
                    }

                    #endregion
                }
            }

            #endregion
        }

        /// <summary>
        /// 获取用户姓名
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        private string GetUserName(string id)
        {
            string name = string.Empty;
            Mod_TS_USER mod = user.GetModel(id);
            if (mod != null)
            {
                name = mod.C_NAME;
            }
            return name;
        }

        /// <summary>
        /// 获取合同分类
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        private string GetConFlag(string flag)
        {
            string result = "";
            if (!string.IsNullOrEmpty(flag))
            {
                switch (flag)
                {
                    case "日常合同":
                        result = "0";
                        break;
                    case "买断合同":
                        result = "1";
                        break;
                    case "特殊价格合同":
                        result = "2";
                        break;
                    case "意向合同":
                        result = "3";
                        break;

                }
            }

            return result;
        }
        /// <summary>
        /// 获取合同分类
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        private string GetConFlag(int  flag)
        {
            string result = "";
            switch (flag)
            {
                case 0:
                    result = "日常合同";
                    break;
                case 1:
                    result = "买断合同";
                    break;
                case 2:
                    result = "特殊价格合同";
                    break;
                case 3:
                    result = "意向合同";
                    break;

            }

            return result;
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            Response.Redirect("Con_Check.aspx?ID="+txtConNO.Value+"");
        }

        
    }
}