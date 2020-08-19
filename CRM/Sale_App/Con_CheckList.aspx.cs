using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using NF.MODEL;
using NF.BLL;
using NF.Framework;


namespace CRM.Sale_App
{
    public partial class Con_CheckList : System.Web.UI.Page
    {
        private Bll_TMO_CON con = new Bll_TMO_CON();
        private Bll_TMO_CONDETAILS condetails = new Bll_TMO_CONDETAILS();
        private Bll_TMB_FLOWSTEP flowstep = new Bll_TMB_FLOWSTEP();
        private Bll_TMB_FLOWPROC flowproc = new Bll_TMB_FLOWPROC();
        private Bll_TMB_STEPINFO stepinfo = new Bll_TMB_STEPINFO();
        private Bll_TMF_FILEINFO fileinfo = new Bll_TMF_FILEINFO();
        private Bll_TMP_PLAN tmp_plan = new Bll_TMP_PLAN();

        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();

        private static DataTable orderdata;
        private static DataTable plandata;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    ltlUserID.Text = BaseUser.Id;
                    ltlUserName.Text = BaseUser.Name;
                    if (!string.IsNullOrEmpty(Request.QueryString["ID"]) && !string.IsNullOrEmpty(Request.QueryString["task"]) && !string.IsNullOrEmpty(Request.QueryString["flow"]) && !string.IsNullOrEmpty(Request.QueryString["step"]) && !string.IsNullOrEmpty(Request.QueryString["flag"]))
                    {
                        ltlFileID.Text = Request.QueryString["ID"];
                        ltlTaskID.Text = Request.QueryString["task"];
                        ltlFlowID.Text = Request.QueryString["flow"];
                        ltlStepID.Text = Request.QueryString["step"];
                        ltlFlag.Text = Request.QueryString["flag"];

                        div_check.Visible = Request.QueryString["flag"] == "0" ? true : false;

                        orderdata = tmo_order.GetOrderList(ltlTaskID.Text).Tables[0];//订单池订单列表
                        plandata = tmp_plan.GetPlanList(ltlTaskID.Text).Tables[0];//日计划

                        GetConInfo();//加载合同信息
                        GetFlowProc();//加载审批记录

                        Mod_TMF_FILEINFO mod = fileinfo.GetModel(ltlFileID.Text);
                        if (mod != null)
                        {
                            ltlContent.Text = mod.C_CONTENT;
                        }
                    }
                }
            }
        }

        private void GetFlowProc()
        {
            DataTable dt = flowproc.GetFlowProcList(ltlFileID.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptCheckList.DataSource = dt;
                rptCheckList.DataBind();
            }
            else
            {
                rptCheckList.DataSource = null;
                rptCheckList.DataBind();
            }
        }

        /// <summary>
        /// 加载合同信息
        /// </summary>
        private void GetConInfo()
        {
            if (!string.IsNullOrEmpty(ltlTaskID.Text))
            {
                Mod_TMO_CON modcon = con.GetModel(ltlTaskID.Text);
                if (modcon != null)
                {
                    txtConNO.Value = ltlTaskID.Text;
                    txtConName.Value = modcon.C_CON_NAME;
                    dropConType.Items.Insert(0, new ListItem(modcon.C_CON_TYPE, modcon.C_CON_TYPE));
                    txtCustName.Value = modcon.C_CUST_NAME;
                    txtQianDanDT.Value = Convert.ToDateTime(modcon.D_CONSING_DT).ToString("yyy-MM-dd");
                    txtPlanStartDT.Value = Convert.ToDateTime(modcon.D_CONEFFE_DT).ToString("yyy-MM-dd");
                    txtPlanEndDT.Value = Convert.ToDateTime(modcon.D_CONINVALID_DT).ToString("yyy-MM-dd");
                    txtSysPlanEndDT.Value = Convert.ToDateTime(modcon.D_SYS_CONINVALID_DT).ToString("yyy-MM-dd");
                    txtCustLEV.Value = modcon.N_CUST_LEV.ToString() == "1" ? "优先" : "普通";

                    dropFaYun.Items.Insert(0, new ListItem(modcon.C_SHIPVIA, modcon.C_SHIPVIA));
                    dropBiZhong.Items.Insert(0, new ListItem(modcon.C_CURRENCY_TYPE, modcon.C_CURRENCY_TYPE));
                    dropYeWuType.Items.Insert(0, new ListItem(modcon.C_BUSINESS_TYPE, modcon.C_BUSINESS_TYPE));
                    string flag = GetConFlag(Convert.ToInt32(modcon.N_FLAG));
                    dropClass.Items.Insert(0, new ListItem(flag, flag));

                    #region //收货单位/收货地址/开票单位

                    DataTable dt1 = condetails.GetCGC_OTC(txtConNO.Value).Tables[0];
                    if (dt1.Rows.Count > 0)
                    {
                        txtShuoHuoCompany.Value = dt1.Rows[0]["C_CGC"].ToString();
                        txtShuoHuoAddr.Value = dt1.Rows[0]["C_CGADDR"].ToString();
                        txtKaiPiaoCompany.Value = dt1.Rows[0]["C_OTC"].ToString();
                    }


                    #endregion

                    dropArea.Items.Insert(0, new ListItem(modcon.C_CON_AREA, modcon.C_CON_AREA));

                    txtState.Value = StringFormat.GetOrderState(modcon.N_CON_STATUS);

                    if (!string.IsNullOrEmpty(modcon.C_ISSHIP))
                    {
                        chkIsFaYun.Checked = modcon.C_ISSHIP == "0" ? false : true;
                    }
                    txtDESC.Value = modcon.C_DESC;


                    GetOrderList();//加载合同明细

                }

            }
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        private void GetOrderList()
        {
            DataTable dt = condetails.GetConOrderList(ltlTaskID.Text, "").Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();

                DataTable dt2 = condetails.GetOrderSum(ltlTaskID.Text).Tables[0];
                if (dt2.Rows.Count > 0)
                {
                    ltlWGTSUM.Text = dt2.Rows[0]["N_WGT"].ToString();
                    ltlN_NOMONEY.Text = dt2.Rows[0]["N_NOMONEY"].ToString();
                    ltlPRICETAX_SUM.Text = dt2.Rows[0]["N_DC_PRICETAX_SUM"].ToString();
                    ltlN_AMOUNT_FAX.Text = dt2.Rows[0]["N_AMOUNT_FAX"].ToString();
                }
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
            }
        }

        /// <summary>
        /// 获取合同分类
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        private string GetConFlag(int flag)
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

        //批准
        protected void btnOk_Click(object sender, EventArgs e)
        {
            #region //添加流程明细
            string content = string.Empty;
            DateTime dt = DateTime.Now;
            if (!string.IsNullOrEmpty(txtContent.Text))
            {
                content += txtContent.Text + "-(" + ltlUserName.Text + "    " + dt.ToString() + ")";
            }
            else
            {
                content += "批准—(" + ltlUserName.Text + "    " + dt.ToString() + ")";
            }

            Mod_TMB_FLOWPROC modPro = new Mod_TMB_FLOWPROC();
            modPro.C_FILE_ID = ltlFileID.Text;
            modPro.C_STEP_ID = ltlStepID.Text;
            modPro.C_STEP_EMP_ID = ltlUserID.Text;
            modPro.C_STEPNOTE = content;
            modPro.D_STEP_DT = dt;
            modPro.N_PROCRESULT = 1;
            #endregion

            if (flowproc.Add(modPro))//插入流程明细
            {
                con.UpdateCheckEmp(ltlTaskID.Text, ltlUserID.Text, dt);//更新当前审批人/时间

                string nextStep = flowstep.GetNextStep(ltlFlowID.Text, ltlStepID.Text);//下一处理步骤

                if (nextStep == "0")//判断是否最后步骤
                {
                    if (fileinfo.UpdateStepStatus(nextStep, 1, ltlFileID.Text))//更新文件事务状态为办结
                    {
                        #region //更新合同/明细状态
                        if (con.UpdateConStatus(2, ltlTaskID.Text))//更新合同
                        {
                            if (condetails.UpdateStatus(2, ltlTaskID.Text))//更新合同明细
                            {
                                bool result = false;

                                foreach (RepeaterItem rpt in rptList.Items)
                                {
                                    Literal ltlOrderNo = (Literal)rpt.FindControl("ltlOrderNo");
                                    DataRow[] row = orderdata.Select("C_ORDER_NO='" + ltlOrderNo.Text + "'");
                                    if (row.Length > 0)
                                    {
                                        if (row[0]["N_EXEC_STATUS"].ToString() == "0")//订单未排产
                                        {
                                            Mod_TMO_CONDETAILS mod = condetails.GetModel(ltlOrderNo.Text);
                                            if(tmo_order.UpdateOrder(mod))//更新订单池订单
                                            {
                                                result=tmp_plan.UpdatePlan(mod);//更新订单日计划
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (condetails.AddOrder(ltlOrderNo.Text))//订单插入订单池
                                        {
                                            Mod_TMO_CONDETAILS mod = condetails.GetModel(ltlOrderNo.Text);
                                            mod.C_BUSINESS_TYPE = dropYeWuType.SelectedValue;

                                            if (mod != null)
                                            {
                                                result = tmp_plan.AddPlan(mod);//插入日计划
                                            }
                                        }
                                    }
                                }
                                if (result)
                                {
                                    WebMsg.MessageBox("提交成功", "WorkFlow_D.aspx");
                                }
                            }
                        }
                        #endregion
                    }
                }
                else
                {
                    if (fileinfo.UpdateStep(nextStep, ltlFileID.Text))//更新文件事务下一步骤
                    {
                        WebMsg.MessageBox("提交成功", "WorkFlow_D.aspx");
                    }
                }
            }
        }

        //退回
        protected void btnNo_Click(object sender, EventArgs e)
        {
            #region //添加流程明细
            string content = string.Empty;
            DateTime dt = DateTime.Now;
            if (!string.IsNullOrEmpty(txtContent.Text))
            {
                content += txtContent.Text + "-(" + ltlUserName.Text + "    " + dt.ToString() + ")";
            }
            else
            {
                content += "退回—(" + ltlUserName.Text + "    " + dt.ToString() + ")";
            }

            Mod_TMB_FLOWPROC modPro = new Mod_TMB_FLOWPROC();
            modPro.C_FILE_ID = ltlFileID.Text;
            modPro.C_STEP_ID = ltlStepID.Text;
            modPro.C_STEP_EMP_ID = ltlUserID.Text;
            modPro.C_STEPNOTE = content;
            modPro.D_STEP_DT = dt;
            modPro.N_PROCRESULT = 1;
            #endregion

            if (flowproc.Add(modPro))//插入流程明细
            {
                con.UpdateCheckEmp(ltlTaskID.Text, ltlUserID.Text, dt);//更新当前审批人/时间

                string upStep = flowstep.GetUpStep(ltlFlowID.Text, ltlStepID.Text);//获取上一步骤
                if (upStep == "0")//判断是否流程第一步
                {
                    if (fileinfo.UpdateStepStatus(upStep, 1, ltlFileID.Text))//更新文件事务状态为办结
                    {
                        #region //退回合同
                        if (con.UpdateConStatus(0, ltlTaskID.Text))//更新合同状态
                        {
                            WebMsg.MessageBox("提交成功", "WorkFlow_D.aspx");
                        }
                        #endregion
                    }
                }
                else
                {
                    if (fileinfo.UpdateStep(upStep, ltlFileID.Text))//更新当前步骤，上一步骤
                    {
                        WebMsg.MessageBox("提交成功", "WorkFlow_D.aspx");
                    }
                }
            }
        }

        //跳转
        protected void btnhref_Click(object sender, EventArgs e)
        {
            string url = ltlFlag.Text == "0" ? "WorkFlow_D.aspx" : "WorkFlow_F.aspx";
            Response.Redirect(url);
        }
    }
}