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
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_TMO_CON con = new Bll_TMO_CON();
        private Bll_TMB_FLOWSTEP flowstep = new Bll_TMB_FLOWSTEP();
        private Bll_TMB_FLOWPROC flowproc = new Bll_TMB_FLOWPROC();
        private Bll_TMF_FILEINFO fileinfo = new Bll_TMF_FILEINFO();
        private Bll_TS_DEPT ts_dept = new Bll_TS_DEPT();
        private Bll_TS_USER ts_user = new Bll_TS_USER();
        private Bll_TS_ROLE ts_role = new Bll_TS_ROLE();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private Bll_TMB_FILE_NEXT_EMP tmb_file_next_emp = new Bll_TMB_FILE_NEXT_EMP();
        private Bll_TMB_AREAPLAN tmb_areaplan = new Bll_TMB_AREAPLAN();
        private Bll_TMB_FLOWINFO tmb_flowinfo = new Bll_TMB_FLOWINFO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    try
                    {
                        ltlUserID.Text = BaseUser.Id;
                        ltlUserName.Text = BaseUser.Name;
                        if (!string.IsNullOrEmpty(Request.QueryString["ID"]) && !string.IsNullOrEmpty(Request.QueryString["flag"]))
                        {
                            ltlFileID.Text = Request.QueryString["ID"];
                            ltlFlag.Text = Request.QueryString["flag"];
                            Mod_TMF_FILEINFO modFile = fileinfo.GetModel(Request.QueryString["ID"]);
                            ltlTaskID.Text = modFile.C_TASK_ID;
                            hidTask.Value = modFile.C_TASK_ID;
                            ltlFlowID.Text = modFile.C_FLOW_ID;
                            ltlStepID.Text = modFile.C_STEP_ID;

                            GetConInfo();//加载合同信息
                            GetFlowProc();//加载审批记录
                            //GetPlanWGT();//区域计划量

                            Mod_TMF_FILEINFO mod = fileinfo.GetModel(ltlFileID.Text);
                            if (mod != null)
                            {
                                ltlContent.Text = mod.C_CONTENT;
                            }

                            div_check.Visible = ltlFlag.Text == "0" ? true : false;
                            hidNextSetpID.Value = flowstep.GetNextStep(ltlFlowID.Text, ltlStepID.Text);

                            //最后步骤操作
                            if (hidNextSetpID.Value == "0")
                            {
                                trNextEmp.Visible = false;
                            }
                            else
                            {
                                trNextEmp.Visible = true;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        WebMsg.MessageBox(ex.Message);
                    }
                }
            }
        }


        ///// <summary>
        ///// 区域计划量/实际接收订单量
        ///// </summary>
        //private void GetPlanWGT()
        //{
        //    DataTable dt = tmb_areaplan.GetPlanWGT().Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {

        //            string[] arr = dt.Rows[i]["wgt"].ToString().Split(':');
        //            //ltlWGT.Text += "<a href=\"javascript:void(0);\" onclick=\"openWeb3('" + arr[0] + "');\" style=\"margin-left:15px; \">" + dt.Rows[i]["wgt"].ToString() + "</a>";
        //            ltlWGT.Text += "<li><a href=\"javascript:void(0);\" class=\"a_wgt\"  style=\"margin-left:15px; \">" + dt.Rows[i]["wgt"].ToString() + "</a></li>";
        //        }
        //    }
        //}


        /// <summary>
        /// 获取收货单位/开票单位
        /// </summary>
        /// <param name="C_NC_M_ID">NC客商管理档案主键</param>
        /// <returns></returns>
        private string GetCust(string C_NC_M_ID)
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(C_NC_M_ID))
            {
                Mod_TS_CUSTFILE mod = ts_custfile.GetCustModel(C_NC_M_ID);
                str = mod.C_NAME;
            }

            return str;
        }

        /// <summary>
        /// 获取数字字典名称
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        private string GetDic(object id)
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                Mod_TS_DIC mod = ts_dic.GetModel(id.ToString());
                str = mod.C_DETAILNAME;
            }

            return str;
        }

        /// <summary>
        /// 获取用户姓名
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        private string GetUserName(string id)
        {
            string name = string.Empty;
            if (!string.IsNullOrEmpty(id))
            {
                Mod_TS_USER mod = ts_user.GetModel(id);
                if (mod != null)
                {
                    name = mod.C_NAME;
                }
            }

            return name;
        }

        /// <summary>
        /// 流程列表
        /// </summary>
        private void GetFlowProc()
        {
            DataTable dt = flowproc.GetFlowSteps(ltlTaskID.Text).Tables[0];
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
                try
                {
                    #region //加载合同基本信息

                    Mod_TMO_CON modcon = con.GetModel(ltlTaskID.Text);
                    if (modcon != null)
                    {
                        hidcon.Value = modcon.C_CON_NO;
                        ltlConNo.Text = modcon.C_CON_NO;
                        ltlConName.Text = modcon.C_CON_NAME;
                        ltlConType.Text = GetDic(modcon.C_CONTYPEID);
                        ltlCustName.Text = modcon.C_CUSTNAME;
                        ltlD_CONSING_DT.Text = Convert.ToDateTime(modcon.D_CONSING_DT).ToString("yyy-MM-dd");
                        ltlD_CONEFFE_DT.Text = Convert.ToDateTime(modcon.D_CONEFFE_DT).ToString("yyy-MM-dd");
                        ltlD_CONINVALID_DT.Text = Convert.ToDateTime(modcon.D_CONINVALID_DT).ToString("yyy-MM-dd");

                        Mod_TMB_FLOWINFO modFlow = tmb_flowinfo.GetModel(modcon.C_FLOWID);
                        ltlC_APPROVER_FLOW.Text = modFlow?.C_NAME ?? "";

                        ltlC_SHIPVIA.Text = GetDic(modcon.C_TRANSMODEID);//发运方式
                        ltlC_CURRENCY_TYPE.Text = GetDic(modcon.C_CURRENCYTYPEID);//货币类型
                        ltlC_BUSINESS_TYPE.Text = GetDic(modcon.C_BIZTYPE);//业务类型

                        Mod_TS_DEPT modDept = ts_dept.GetModel(modcon.C_DEPTID);
                        if (modDept != null)
                        {
                            ltlDept.Text = modDept.C_NAME;//部门
                        }

                        ltlSaleUser.Text = ts_user.GetSaleName(modcon.C_EMPLOYEEID);//业务员
                        ltlC_SALE_DEPT.Text = GetDic(modcon.C_SALECORPID);//销售组织

                        ltlC_CGC.Text = GetCust(modcon.C_CRECEIPTCUSTOMERID);//收货单位
                        ltlC_OTC.Text = GetCust(modcon.C_CRECEIPTCORPID);//开票单位
                        ltlC_STATION.Text = modcon.C_STATION;
                        ltlConArea.Text = modcon.C_AREA;
                        ltlConState.Text = StringFormat.GetOrderState(modcon.N_STATUS);
                        ltlDESC.Text = modcon.C_REAMRK;


                        //加载合同订单列表
                        GetOrderList();
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    WebMsg.MessageBox(ex.Message);
                }

            }
        }

        private void GetOrderList()
        {
            if (!string.IsNullOrEmpty(ltlConNo.Text))
            {
                DataTable dt = tmo_order.GetConOrderList(ltlConNo.Text, "", "", "", "", "").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    rptList.DataSource = dt;
                    rptList.DataBind();

                    ltlWGT_SUM.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                    ltlN_ORIGINALCURMNY.Text = dt.Compute("sum(N_ORIGINALCURMNY)", "true").ToString();
                    ltlN_ORIGINALCURSUMMNY.Text = dt.Compute("sum(N_ORIGINALCURSUMMNY)", "true").ToString();
                    ltlN_ORIGINALCURTAXMNY.Text = dt.Compute("sum(N_ORIGINALCURTAXMNY)", "true").ToString();
                }
                else
                {
                    rptList.DataSource = null;
                    rptList.DataBind();
                }
            }
        }

        //批准
        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string nextStep = hidNextSetpID.Value;//下一步骤

                if (nextStep == "0")
                {
                    #region //最后步骤操作

                    Mod_ApproveCon mod = new Mod_ApproveCon();

                    mod.C_EMP_ID = ltlUserID.Text;//当前审批人
                    mod.NEXTSTEPID = nextStep;//下一步骤
                    mod.FILE_STATUS = "1";// 办结
                    mod.FILEID = ltlFileID.Text;
                    mod.CON_STATUS = "4";//审核通过
                    mod.CON_NO = ltlTaskID.Text;
                    mod.STEPID = ltlStepID.Text;//当前步骤
                    if (fileinfo.UpdateLastStep(mod))
                    {
                        ProAdd("批准");
                    }
                    #endregion
                }
                else
                {
                    #region //下一步骤操作

                    if (tmb_file_next_emp.UpdateNextSetp(ltlFileID.Text, ltlStepID.Text, nextStep, hidEmpID.Value, ltlUserID.Text))
                    {
                        ProAdd("批准");
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }

        /// <summary>
        /// 记录审批内容
        /// </summary>
        /// <param name="status">状态</param>
        private void ProAdd(string status)
        {
            #region //添加流程明细
            string content = string.Empty;

            if (!string.IsNullOrEmpty(txtContent.Text))
            {
                content += txtContent.Text;
            }
            else
            {
                content += status;
            }

            Mod_TMB_FLOWPROC modPro = new Mod_TMB_FLOWPROC();
            modPro.C_FILE_ID = ltlFileID.Text;
            modPro.C_STEP_ID = ltlStepID.Text;
            modPro.C_STEP_EMP_ID = ltlUserID.Text;
            modPro.C_STEPNOTE = content;
            modPro.N_PROCRESULT = status == "批准" ? 1 : 0;
            Mod_TS_ROLE modRloe = ts_role.GetModel(ltlStepID.Text);
            modPro.C_REMARK = modRloe.C_NAME;
            #endregion
            if (flowproc.Add(modPro))
            {
                WebMsg.MessageBox("提交成功", "WorkFlow_F.aspx");
            }
        }

        //退回
        protected void btnNo_Click(object sender, EventArgs e)
        {
            try
            {

                #region //驳回最后步骤操作
                Mod_ApproveCon mod = new Mod_ApproveCon();

                mod.UPSTEPID = "0";//步骤
                mod.FILE_STATUS = "1";//办结
                mod.FILEID = ltlFileID.Text;
                mod.STEPID = ltlStepID.Text;
                mod.CON_STATUS = "0";//待办
                mod.CON_NO = ltlTaskID.Text;
                mod.C_EMP_ID = ltlUserID.Text;
                if (fileinfo.UpdateBackLastSetp(mod))
                {
                    ProAdd("驳回");
                }
                #endregion


            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
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