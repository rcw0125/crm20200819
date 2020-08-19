using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.MODEL;
using NF.Framework;
using NF.BLL;
using System.Web.Services;

namespace CRM.WebForms.Report
{
    public partial class roll_apply : System.Web.UI.Page
    {
        private Bll_TMF_FILEINFO tmf_fileinfo = new Bll_TMF_FILEINFO();
        private Bll_TMB_FLOWINFO tmb_flowinfo = new Bll_TMB_FLOWINFO();
        private static Bll_TMB_FLOWSTEP tmb_flowstep = new Bll_TMB_FLOWSTEP();
        private Bll_TMB_FILE_NEXT_EMP tmb_file_next_emp = new Bll_TMB_FILE_NEXT_EMP();

        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();

        private static DataTable dtOrder = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                //if (BaseUser != null)
                //{
                try
                {
                    //ltlUserID.Text = BaseUser.Id;
                    GetFlow();

                    SetData();

                    BindList();
                }
                catch (Exception ex)
                {
                    WebMsg.MessageBox(ex.Message);
                }
                //}
                //else
                //{
                //    WebMsg.CheckUserLogin();
                //}
            }
        }


        #region //初始化datatable
        private void SetData()
        {
            Session["xm"] = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));//
            dt.Columns.Add("NEEDAREA", typeof(string));//需求区域
            dt.Columns.Add("NEEDCUST", typeof(string));//需求客户
            dt.Columns.Add("ZYAREA", typeof(string));//资源所属区域
            dt.Columns.Add("ZYCUST", typeof(string));//资源客户
            dt.Columns.Add("SPEC", typeof(string));//规格
            dt.Columns.Add("STL_GRD", typeof(string));//钢种
            dt.Columns.Add("NEEDWGT", typeof(string));//需求吨数
            dt.Columns.Add("QUA", typeof(string));//件数   
            dt.Columns.Add("REMARK", typeof(string));//备注
            dtOrder = dt;
        }
        #endregion

        private void BindList()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["batchno"]))
            {
                ltlbatch.Text = Request.QueryString["batchno"];
                List<string> list = new List<string>();
                string[] arr = ltlbatch.Text.Split(',');
                if (arr.Length > 0)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if(!string.IsNullOrEmpty(arr[i]))
                        {
                            string id = "'" + arr[i] + "'";
                            list.Add(id);
                        }
                    }
                    string batch = string.Join(",", list);

                    DataTable dt = trc_roll_prodcut.GetRollProdcut(batch).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dtOrder.Rows.Add(new object[] {
                               i,//主键
                               "",//需求区域
                               "",//需求客户
                               dt.Rows[i]["C_SALE_AREA"],//资源所属区域
                               dt.Rows[i]["C_CUST_NAME"],//资源客户
                               dt.Rows[i]["C_SPEC"],//规格   
                               dt.Rows[i]["C_STL_GRD"],//钢种
                               "",//需求吨数
                               "",//件数  
                               ""//备注
                               });
                        }
                    }
                }

            }

            rptList.DataSource = dtOrder;
            rptList.DataBind();
        }


        /// <summary>
        /// 获取流程
        /// </summary>
        private void GetFlow()
        {
            DataTable dt = tmb_flowinfo.GetFlowList("3").Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropFlow.DataSource = dt;
                dropFlow.DataTextField = "C_NAME";
                dropFlow.DataValueField = "C_ID";
                dropFlow.DataBind();
            }
            else
            {
                dropFlow.DataSource = null;
                dropFlow.DataBind();
            }
        }

        /// <summary>
        /// 获取流程步骤
        /// </summary>
        /// <param name="flowID"></param>
        /// <returns></returns>
        [WebMethod]
        public static string GetStep(string flowID)
        {
            return tmb_flowstep.GetFirstStep(flowID);//获取流程第一步骤           
        }

        //提交申请
        protected void btnok_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(hidEmpID.Value))
                {
                    //文件
                    Mod_TMF_FILEINFO modFile = new Mod_TMF_FILEINFO();
                    modFile.C_FLOW_ID = dropFlow.SelectedValue;//流程
                    modFile.C_EMP_ID = ltlUserID.Text;
                    modFile.C_TITLE = txtTitle.Text;
                    modFile.C_CONTENT = txtContent.Text;
                    modFile.N_TYPE = 0;
                    modFile.C_TASK_ID = "";
                    modFile.C_STEP_ID = hidSetpID.Value;//步骤

                    //步骤操作人
                    Mod_TMB_FILE_NEXT_EMP modNextEmp = new Mod_TMB_FILE_NEXT_EMP();
                    modNextEmp.C_FILE_ID = ID;
                    modNextEmp.C_NEXT_EMP_ID = hidEmpID.Value;
                    modNextEmp.C_STEP_ID = hidSetpID.Value;

                    //if (tmo_con.ApproveCon(modFile, modNextEmp))
                    //{
                    //    WebMsg.MessageBox("提交成功", "ConList.aspx");
                    //}
                    //else
                    //{
                    //    WebMsg.MessageBox("提交失败");
                    //}
                }
                else
                {
                    WebMsg.MessageBox("请选择下一处理人");
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }

        //增行
        protected void btnadd_Click(object sender, EventArgs e)
        {
            int row = rptList.Items.Count + 1;


            DataTable dt = dtOrder;

            dtOrder.Rows.Add(new object[] {
                               row,//主键
                               "",//需求区域
                               "",//需求客户
                               "",//资源所属区域
                               "",//资源客户
                               "",//规格   
                               "",//钢种
                               "",//需求吨数
                               "",//件数  
                               ""//备注
                               });
            rptList.DataSource = dtOrder;
            rptList.DataBind();
        }
    }
}