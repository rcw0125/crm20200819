using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Data;
using NF.MODEL;
using NF.BLL;
using NF.Framework;



namespace CRM.Sale_App
{
    public partial class Quality_CheckList : System.Web.UI.Page
    {
        private Bll_TMB_FLOWSTEP flowstep = new Bll_TMB_FLOWSTEP();
        private Bll_TMB_FLOWPROC flowproc = new Bll_TMB_FLOWPROC();
        private Bll_TMB_STEPINFO stepinfo = new Bll_TMB_STEPINFO();
        private Bll_TMF_FILEINFO fileinfo = new Bll_TMF_FILEINFO();
        private Bll_TS_ROLE ts_role = new Bll_TS_ROLE();
        private Bll_TMQ_QUALITY_FILE quality_file = new Bll_TMQ_QUALITY_FILE();
        private Bll_TMQ_QUALITY_MAIN quality_main = new Bll_TMQ_QUALITY_MAIN();
        private Bll_TMQ_QUALITY_STL_GRD quality_stl_grd = new Bll_TMQ_QUALITY_STL_GRD();

        private Bll_TMB_AREA area = new Bll_TMB_AREA();
        private Bll_TB_MATRL_MAIN matrl_main = new Bll_TB_MATRL_MAIN();
        private Bll_TQB_STD_MAIN tqb_std_main = new Bll_TQB_STD_MAIN();

        private Bll_TMB_FILE_NEXT_EMP tmb_file_next_emp = new Bll_TMB_FILE_NEXT_EMP();

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
                            ltlFlowID.Text = modFile.C_FLOW_ID;
                            ltlStepID.Text = modFile.C_STEP_ID;

                            div_check.Visible = ltlFlag.Text == "0" ? true : false;
                            hidNextSetpID.Value = flowstep.GetNextStep(ltlFlowID.Text, ltlStepID.Text);
                            if (hidNextSetpID.Value == "0")//是否最后步骤
                            {
                                trNextEmp.Visible = false;
                            }
                            else
                            {
                                trNextEmp.Visible = true;
                            }

                            Mod_TMF_FILEINFO mod = fileinfo.GetModel(ltlFileID.Text);
                            if (mod != null)
                            {
                                ltlContent.Text = mod.C_CONTENT;
                            }
                            GetFlowProc();//加载审批记录
                            GetQuality();//加载质量异议
                            GetFile();//加载质量附件
                        }
                    }
                    catch (Exception ex)
                    {
                        WebMsg.MessageBox(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 获取附件
        /// </summary>
        private void GetFile()
        {
            if (!string.IsNullOrEmpty(ltlTaskID.Text))
            {
                DataTable dt = quality_file.GetQualityFileList(ltlTaskID.Text).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    rptDown.DataSource = dt;
                    rptDown.DataBind();
                }
                else
                {
                    rptDown.DataSource = null;
                    rptDown.DataBind();
                }
            }
        }

        /// <summary>
        /// 获取流程明细
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

        private void GetQuality()
        {
            try
            {
                if (!string.IsNullOrEmpty(ltlTaskID.Text))
                {
                    Mod_TMQ_QUALITY_MAIN mod = quality_main.GetModel(ltlTaskID.Text);
                    if (mod != null)
                    {
                        #region //客户质量信息
                        //区域
                        if (!string.IsNullOrEmpty(mod.C_AREA))
                        {
                            Mod_TMB_AREA modArea = area.GetModel(mod.C_AREA);
                            txtArea.Text = modArea.C_NAME;
                        }
                        txtCustName.Text = mod.C_CUST_NAME;
                        txtUser.Text = mod.C_NAME;
                        txtTel.Text = mod.C_TEL;

                        //钢种分类
                        //if (!string.IsNullOrEmpty())
                        //{
                        //Mod_TQB_STD_MAIN modstd_main = tqb_std_main.GetModel(mod.C_STL_GRD_CLASS);
                        //Mod_TB_MATRL_MAIN modClass = matrl_main.GetModel(mod.C_STL_GRD_CLASS);
                        //if(modClass!=null)
                        //{
                        txtSTL_GRD.Text = mod.C_STL_GRD_CLASS;
                           // }
                            
                        //}
                        txtUse.Text = mod.C_PROD_USE;
                        txtFHTime.Text = Convert.ToDateTime(mod.D_SHIP_START_DT).ToString("yyy-MM-dd");
                        txtDHTime.Text = Convert.ToDateTime(mod.D_SHIP_END_DT).ToString("yyy-MM-dd");
                        txtTouSu.Text = mod.C_OBJECT_CONTENT;
                        txtGongYi.Text = mod.C_TECH_DESC;

                        //客户质量钢种
                        DataTable dt = quality_stl_grd.GetQUALITY_STL_GRD(ltlTaskID.Text).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            rptSTL_GRD.DataSource = dt;
                            rptSTL_GRD.DataBind();

                            ltlShipSum.Text = dt.Compute("sum(N_SHIP_WGT)", "true").ToString();
                            ltlObjecSum.Text = dt.Compute("sum(N_OBJEC_WGT)", "true").ToString();

                        }
                        else
                        {
                            rptSTL_GRD.DataSource = null;
                            rptSTL_GRD.DataBind();
                        }

                        #endregion

                        #region//现场处理信息
                        txtXinaChang.Text = mod.C_SITE_SURVEY_CONTENT;
                        txtMuCai.Text = mod.N_PARENT_QUA.ToString();
                        txtWenTi.Text = mod.N_QUEST_QUA.ToString();
                        txtZhongJian.Text = mod.N_MIDDLE_QUA.ToString();
                        txtQiTa.Text = mod.N_ELSE_QUA.ToString();
                        txtDept.Text = mod.C_DEPT;
                        txtZKDept.Text = mod.C_DEPT2;
                        txtJSDept.Text = mod.C_DEPT3;
                        txtQTDept.Text = mod.C_DEPT4;
                        txtRemark.Text = mod.C_REMARK;
                        #endregion
                    }

                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }

        }

        protected void rptDown_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "down")
            {
                string path = e.CommandArgument.ToString();

                #region //下载附件
                try
                {
                    string fname1 = path;
                    string DownloadFileName = "~/upfile/" + fname1;
                    string filepath = Server.MapPath(DownloadFileName);
                    string filename = Path.GetFileName(filepath);
                    FileInfo file = new FileInfo(filepath);
                    Response.Clear();
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8));
                    Response.AddHeader("Content-length", file.Length.ToString());
                    Response.Flush();
                    Response.WriteFile(filepath);
                }
                catch
                {
                    Response.Write("<script>alert('没有找到下载的源文件')</script>");
                }
                #endregion
            }
        }

        //批准
        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string nextStep = flowstep.GetNextStep(ltlFlowID.Text, ltlStepID.Text);//下一处理步骤

                if (nextStep == "0")//判断是否流程，最后步骤
                {
                    if (fileinfo.UpdateStepStatus(nextStep, 1, ltlFileID.Text))//更新文件事务状态为办结
                    {
                        ////更新当前审批人/时间/状态
                        quality_main.UpdateCheckEmp(ltlTaskID.Text, ltlUserID.Text, "2", DateTime.Now);
                        ProAdd("批准");
                    }
                }
                else
                {
                    ////更新文件事务下一步骤
                    if (tmb_file_next_emp.UpdateNextSetp(ltlFileID.Text, ltlStepID.Text, nextStep, hidEmpID.Value, ltlUserID.Text))
                    {
                        ProAdd("批准");

                    }
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
            DateTime dt = DateTime.Now;
            if (!string.IsNullOrEmpty(txtContent.Text))
            {
                content += txtContent.Text + "-(" + ltlUserName.Text + "    " + dt.ToString() + ")";
            }
            else
            {
                content += status + "—(" + ltlUserName.Text + "    " + dt.ToString() + ")";
            }

            Mod_TMB_FLOWPROC modPro = new Mod_TMB_FLOWPROC();
            modPro.C_FILE_ID = ltlFileID.Text;
            modPro.C_STEP_ID = ltlStepID.Text;
            modPro.C_STEP_EMP_ID = ltlUserID.Text;
            modPro.C_STEPNOTE = content;
            modPro.D_STEP_DT = dt;
            modPro.N_PROCRESULT = 1;
            Mod_TS_ROLE modRloe = ts_role.GetModel(ltlStepID.Text);
            modPro.C_REMARK = modRloe.C_NAME;
            #endregion
            if (flowproc.Add(modPro))
            {
                WebMsg.MessageBox("提交成功", "WorkFlow_D.aspx");
            }
        }

        //驳回操作
        protected void btnNo_Click(object sender, EventArgs e)
        {
            try
            {
                string nextStep = flowstep.GetNextStep(ltlFlowID.Text, ltlStepID.Text);//下一步骤
                string upStep = "0"; //flowstep.GetUpStep(ltlFlowID.Text, ltlStepID.Text);//获取上一步骤

                //删除当前步骤与下一步骤
                if (tmb_file_next_emp.BackSetp(ltlFileID.Text, ltlStepID.Text, nextStep, upStep))
                {
                    //更新当前审批人/时间/状态
                    if (quality_main.UpdateCheckEmp(ltlTaskID.Text, ltlUserID.Text, "2", DateTime.Now))
                    {
                        ProAdd("驳回");
                    }
                }

                #region //注销
                //最后步骤操作
                //if (upStep == "0")
                //{
                //    //删除当前步骤与下一步骤
                //    if (tmb_file_next_emp.BackSetp(ltlFileID.Text, ltlStepID.Text, nextStep, upStep))
                //    {
                //        //更新当前审批人/时间/状态
                //        if (quality_main.UpdateCheckEmp(ltlTaskID.Text, ltlUserID.Text, "2", DateTime.Now))
                //        {
                //            ProAdd("驳回");
                //        }
                //    }
                //}
                //else
                //{
                //    //删除当前步骤与下一步骤
                //    if (tmb_file_next_emp.BackSetp(ltlFileID.Text, ltlStepID.Text, nextStep, upStep))
                //    {
                //        ProAdd("驳回");
                //    }
                //}
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