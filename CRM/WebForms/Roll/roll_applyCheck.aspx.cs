using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using NF.BLL;
using NF.MODEL;
using NF.Framework;
using System.Data;

namespace CRM.WebForms.Roll
{
    public partial class roll_applyCheck : System.Web.UI.Page
    {

        private Bll_TMC_ROLL_APPLY tmc_roll_apply = new Bll_TMC_ROLL_APPLY();
        private Bll_TMC_ROLL_APPLY_ITEM tmc_roll_apply_item = new Bll_TMC_ROLL_APPLY_ITEM();

        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_TMC_ROLL_DEPLOY_LOG tmc_roll_deploy_log = new Bll_TMC_ROLL_DEPLOY_LOG();

        private Bll_TS_USER ts_user = new Bll_TS_USER();
        private Bll_TMB_FLOWINFO tmb_flowinfo = new Bll_TMB_FLOWINFO();
        private Bll_TMB_FLOWSTEP flowstep = new Bll_TMB_FLOWSTEP();
        private Bll_TMB_FILE_NEXT_EMP tmb_file_next_emp = new Bll_TMB_FILE_NEXT_EMP();
        private Bll_TMB_FLOWPROC flowproc = new Bll_TMB_FLOWPROC();
        private Bll_TMF_FILEINFO fileinfo = new Bll_TMF_FILEINFO();
        private Bll_TS_ROLE ts_role = new Bll_TS_ROLE();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser == null)
                {
                    WebMsg.CheckUserLogin();
                    return;
                }
                else
                {
                    ltlUserID.Text = vUser.Id;
                    ltlUserName.Text = vUser.Name;
                    if (!string.IsNullOrEmpty(Request.QueryString["ID"]) && !string.IsNullOrEmpty(Request.QueryString["flag"]))
                    {
                        ltlFileID.Text = Request.QueryString["ID"];
                        ltlFlag.Text = Request.QueryString["flag"];

                        Mod_TMF_FILEINFO modFile = fileinfo.GetModel(ltlFileID.Text);
                        if (modFile != null)
                        {
                            GetInfo(modFile.C_TASK_ID);//基本信息

                            hid.Value = modFile.C_TASK_ID;

                            ltlTaskID.Text = modFile.C_TASK_ID;
                            ltlFlowID.Text = modFile.C_FLOW_ID;
                            ltlStepID.Text = modFile.C_STEP_ID;

                            GetFlowProc();//加载审批记录                         

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

                }
            }

        }

        private void GetInfo(string ID)
        {
            Mod_TMC_ROLL_APPLY mod = tmc_roll_apply.GetModel(ID);
            if (mod != null)
            {
                txtEmpName.Text = mod.C_EMPNAME;
                ltlcheckstate.Text = GetState(mod.C_STATUS);
                ltldate.Text = mod.D_MOD.ToString();
                GetList(ID);
            }
        }


        private string GetState(string state)
        {
            string res = string.Empty;
            switch (state)
            {
                case "-1":
                    res = "未提交";
                    break;
                case "0":
                    res = "待处理";
                    break;
                case "1":
                    res = "审批中";
                    break;
                case "2":
                    res = "已完成";
                    break;
            }
            return res;
        }

        private void GetList(string ID)
        {
            string strSql = $@" C_PKID='{ID}'";
            DataTable dt = tmc_roll_apply_item.GetList(strSql).Tables[0];
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
        /// <summary>
        /// 获取用户姓名
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        private string GetUserName(string id)
        {
            string name = string.Empty;
            Mod_TS_USER mod = ts_user.GetModel(id);
            if (mod != null)
            {
                name = mod.C_NAME;
            }
            return name;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string nextStep = hidNextSetpID.Value;//下一步骤

                if (nextStep == "0")
                {
                    #region//先判定是否资源调配成功

                    bool result = true;//判断当前发运数量已超出可发运量
                    string stlgrd = string.Empty;

                    #region //初始化DataTable
                    DataTable dt = new DataTable();
                    dt.Columns.Add("matCode", typeof(string));//物料编码
                    dt.Columns.Add("stdCode", typeof(string));//执行标准
                    dt.Columns.Add("area", typeof(string));//区域
                    dt.Columns.Add("pack", typeof(string));//包装
                    dt.Columns.Add("lev", typeof(string));//等级
                    dt.Columns.Add("custname", typeof(string));//客户名称
                    dt.Columns.Add("conno", typeof(string));//合同号
                    dt.Columns.Add("stlgrd", typeof(string));//钢种
                    dt.Columns.Add("wgt", typeof(string));//重量
                    #endregion




                    List<Mod_TMC_ROLL_DEPLOY_LOG> list = new List<Mod_TMC_ROLL_DEPLOY_LOG>();
                    for (int i = 0; i < rptList.Items.Count; i++)
                    {
                        HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                        Literal ltlbatch = (Literal)rptList.Items[i].FindControl("ltlbatch");//批次号
                        Literal ltlmatcode = (Literal)rptList.Items[i].FindControl("ltlmatcode");//物料编码
                        Literal ltlstlgrd = (Literal)rptList.Items[i].FindControl("ltlstlgrd");//钢种
                        Literal ltlspec = (Literal)rptList.Items[i].FindControl("ltlspec");//规格
                        Literal ltlsalearea = (Literal)rptList.Items[i].FindControl("ltlsalearea");//销售区域
                        Literal ltlstdcode = (Literal)rptList.Items[i].FindControl("ltlstdcode");//执行标准
                        Literal ltlpack = (Literal)rptList.Items[i].FindControl("ltlpack");//包装要求
                        Literal ltllev = (Literal)rptList.Items[i].FindControl("ltllev");//质量等级
                        Literal ltlN_WGT = (Literal)rptList.Items[i].FindControl("ltlN_WGT");//重量
                        Literal ltlneedarea = (Literal)rptList.Items[i].FindControl("ltlneedarea");//需求区域
                        Literal ltlneedcust = (Literal)rptList.Items[i].FindControl("ltlneedcust");//需求客户
                        Literal ltlneedcon = (Literal)rptList.Items[i].FindControl("ltlneedcon");//需求合同
                        Literal ltlzycust = (Literal)rptList.Items[i].FindControl("ltlzycust");//原资源客户
                        Literal ltlzycon = (Literal)rptList.Items[i].FindControl("ltlzycon");//原资源合同

                        #region //插入值
                        if (ts_dic.GetAreaFlag(ltlsalearea.Text) == "N")//获取区域是否按客户发运Y/N
                        {

                            DataRow[] dr2 = dt.Select("matCode='" + ltlmatcode.Text + "' and stdCode='" + ltlstdcode.Text + "' and area='" + ltlsalearea.Text + "' and pack='" + ltlpack.Text + "' and lev='" + ltllev.Text + "'");
                            if (dr2.Length <= 0)
                            {
                                dt.Rows.Add(new object[] { ltlmatcode.Text, ltlstdcode.Text, ltlsalearea.Text, ltlpack.Text, ltllev.Text, "", "", ltlstlgrd.Text, ltlN_WGT.Text });
                            }
                            else
                            {
                                foreach (var item in dr2)
                                {
                                    item["wgt"] = Convert.ToString(Convert.ToDecimal(item["wgt"]) + Convert.ToDecimal(ltlN_WGT.Text));
                                }
                            }
                        }
                        else
                        {
                            DataRow[] dr2 = dt.Select("matCode='" + ltlmatcode.Text + "' and stdCode='" + ltlstdcode.Text + "' and area='" + ltlsalearea.Text + "' and pack='" + ltlpack.Text + "' and lev='" + ltllev.Text + "' and custname='" + ltlzycust.Text + "' and conno='" + ltlzycon.Text + "'");
                            if (dr2.Length <= 0)
                            {
                                dt.Rows.Add(new object[] { ltlmatcode.Text, ltlstdcode.Text, ltlsalearea.Text, ltlpack.Text, ltllev.Text, ltlzycust.Text, ltlzycon.Text, ltlstlgrd.Text, ltlN_WGT.Text });
                            }
                            else
                            {
                                foreach (var item in dr2)
                                {
                                    item["wgt"] = Convert.ToString(Convert.ToDecimal(item["wgt"]) + Convert.ToDecimal(ltlN_WGT.Text));
                                }
                            }
                        }
                        #endregion

                        #region //参数
                        Mod_TMC_ROLL_DEPLOY_LOG modLog = new Mod_TMC_ROLL_DEPLOY_LOG();
                        modLog.C_ROLL_PROCID = cbxselect.Value;
                        modLog.C_BATCH_NO = ltlbatch.Text;
                        modLog.C_MAT_CODE = ltlmatcode.Text;
                        modLog.C_STL_GRD = ltlstlgrd.Text;
                        modLog.C_SPEC = ltlspec.Text;
                        modLog.C_OLDAREA = ltlsalearea.Text;//原资源区域
                        modLog.C_NEWAREA = ltlneedarea.Text;//需求区域

                        modLog.C_OLDCUST = ltlzycust.Text;//原资源客户
                        modLog.C_NEWCUST = ltlneedcust.Text;//需求客户信息

                        modLog.C_OLDCON = ltlzycon.Text;//原资源合同
                        modLog.C_NEWCON = ltlneedcon.Text;//需求合同

                        modLog.C_EMPID = ltlUserID.Text;
                        modLog.C_EMPNAME = ltlUserName.Text;
                        modLog.C_STD_CODE = ltlstdcode.Text;
                        modLog.C_JUDGE_LEV = ltllev.Text;
                        modLog.C_PACK = ltlpack.Text;
                        list.Add(modLog);
                        #endregion
                    }

                    #region //在途量/库存量


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (ts_dic.GetAreaFlag(dt.Rows[i]["area"].ToString()) == "N")//获取区域是否按客户发运Y/N
                        {
                            //判断当前发运数量已超出可发运量
                            if (!tmo_order.IsFy(Convert.ToDecimal(dt.Rows[i]["wgt"].ToString()), dt.Rows[i]["matCode"].ToString(), dt.Rows[i]["stdCode"].ToString(), dt.Rows[i]["area"].ToString(), dt.Rows[i]["pack"].ToString(), dt.Rows[i]["lev"].ToString()))
                            {
                                stlgrd = dt.Rows[i]["stlgrd"].ToString();
                                result = false;
                                break;
                            }
                        }
                        else
                        {
                            //判断当前发运数量已超出可发运量
                            if (!tmo_order.IsFy(Convert.ToDecimal(dt.Rows[i]["wgt"].ToString()), dt.Rows[i]["matCode"].ToString(), dt.Rows[i]["stdCode"].ToString(), dt.Rows[i]["area"].ToString(), dt.Rows[i]["pack"].ToString(), dt.Rows[i]["lev"].ToString(), dt.Rows[i]["custname"].ToString(), dt.Rows[i]["conno"].ToString()))
                            {
                                stlgrd = dt.Rows[i]["stlgrd"].ToString();
                                result = false;
                                break;
                            }
                        }
                    }

                    //if (dt.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dt.Rows.Count; i++)
                    //    {
                    //        DataTable dtfyzt = tmo_order.ZTWGT(dt.Rows[i]["matCode"].ToString(), dt.Rows[i]["stdCode"].ToString(), dt.Rows[i]["area"].ToString(), dt.Rows[i]["pack"].ToString(), dt.Rows[i]["lev"].ToString()).Tables[0];
                    //        if (dtfyzt.Rows.Count > 0)//在途量
                    //        {
                    //            ztwgt += Convert.ToDecimal(dtfyzt.Compute("sum(N_FYWGT)", "true"));//合计在途量
                    //        }
                    //        DataTable dtkc = tmo_order.KCWGT(dt.Rows[i]["matCode"].ToString(), dt.Rows[i]["stdCode"].ToString(), dt.Rows[i]["area"].ToString(), dt.Rows[i]["pack"].ToString(), dt.Rows[i]["lev"].ToString()).Tables[0];
                    //        if (dtkc.Rows.Count > 0)//库存量
                    //        {
                    //            if (!string.IsNullOrEmpty(dtkc.Rows[0]["N_WGT"].ToString()))
                    //            {
                    //                kcwgt += Convert.ToDecimal(dtkc.Rows[0]["N_WGT"]);//合计在途量
                    //            }
                    //        }
                    //    }
                    //}
                    #endregion

                    if (result)
                    {
                        if (tmc_roll_deploy_log.InsertRoll_Proc3(list))//执行调配资源
                        {
                            #region //最后步骤操作

                            Mod_ApproveCon mod = new Mod_ApproveCon();

                            mod.C_EMP_ID = ltlUserID.Text;//当前审批人
                            mod.NEXTSTEPID = nextStep;//下一步骤
                            mod.FILE_STATUS = "1";// 办结
                            mod.FILEID = ltlFileID.Text;
                            mod.CON_STATUS = "2";//审核通过
                            mod.CON_NO = ltlTaskID.Text;
                            mod.STEPID = ltlStepID.Text;//当前步骤

                            if (fileinfo.UpdateLastStep_ROLL(mod))
                            {
                                ProAdd("批准");
                            }
                            #endregion
                        }
                    }
                    else
                    {


                        string msg = stlgrd + ",存在发运单占用该资源";
                        txtContent.Text = msg;
                        WebMsg.MessageBox(stlgrd + ",存在发运单占用该资源,请点击驳回！");
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
                if (fileinfo.UpdateBackLastSetp_ROLL(mod))
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
                WebMsg.MessageBox("提交成功", "../Sale_App/WorkFlow_F.aspx");
            }
        }

    }
}