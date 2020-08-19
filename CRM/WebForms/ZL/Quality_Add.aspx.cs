using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.MODEL;
using NF.BLL;
using System.IO;
using NF.Framework;
using System.Web.UI.HtmlControls;
using NF.BLL.Q;
using NF.MODEL.Q;

namespace CRM.WebForms.ZL
{
    public partial class Quality_Add : System.Web.UI.Page
    {
        private const string RoleCode = "kh-001";
        private const string KFCode = "z-002";
        private const string SaleCode = "S0002/S0003/S0004/S0005/S0006/S0007";
        private Bll_TMQ_QUA_MAIN qua = new Bll_TMQ_QUA_MAIN();
        private Bll_TS_USER ts_user = new Bll_TS_USER();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["back_no"] = 0;

                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser == null)
                {
                    WebMsg.CheckUserLogin();
                    return;
                }
                else
                {

                    if (vUser.Roles.Where(x => x.C_CODE == RoleCode).Any())
                    {
                        hidroles.Value = "kh-001";

                        trSale1.Visible = false;
                        trSale2.Visible = false;
                        trSale3.Visible = false;
                        trSale4.Visible = false;
                        trCus1.Visible = false;
                        trSale5.Visible = false;

                    }
                    else
                    {
                        trSale1.Visible = true;
                        trSale2.Visible = true;
                        trSale3.Visible = true;
                        trSale4.Visible = true;
                        trCus1.Visible = true;
                        trSale5.Visible = true;
                    }
                }
                Session["Quality"] = null;
                InitDDL();
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    hid.Value = Request.QueryString["ID"];
                    var mod = qua.GetModel(hid.Value);
                    if (mod != null)
                    {

                        hidstatus.Value = Convert.ToString(mod.N_status);

                        if (vUser.Roles.Where(x => x.C_CODE == RoleCode).Any())
                        {
                            btnflow.Visible = false;

                            if (Convert.ToInt32(mod.N_status) > 0)
                            {
                                this.btnAdd.Visible = false;//添加行
                                this.btndelrow.Visible = false;//删除行
                                this.btnsave.Visible = false;//保存
                                this.btnSubmit.Visible = false;//提交
                                btnCheck.Visible = false;//送审

                            }
                            else
                            {
                                this.btnAdd.Visible = true;//添加行
                                this.btndelrow.Visible = true;//删除行
                                this.btnsave.Visible = true;//保存
                                this.btnSubmit.Visible = true;//提交
                                btnCheck.Visible = false;//送审
                            }

                        }
                        else
                        {

                            btndoc.Visible = true;//文档
                            this.btnSubmit.Visible = false;//提交

                            switch (Convert.ToInt32(mod.N_status))
                            {
                                case 0://待处理
                                    this.btnAdd.Visible = true;//添加行
                                    this.btndelrow.Visible = true;//删除行
                                    //btnsave.Visible = true;//保存
                                    btnCheck.Visible = true;//送审
                                    break;
                                case 1://审批中
                                    //btnsave.Visible = false;//保存
                                    btnCheck.Visible = false;//送审
                                    this.btnAdd.Visible = false;//添加行
                                    this.btndelrow.Visible = false;//删除行
                                    break;
                                case 2://已完成

                                    this.btnAdd.Visible = false;//添加行
                                    this.btndelrow.Visible = false;//删除行
                                    //btnsave.Visible = false;//保存
                                    btnCheck.Visible = false;//送审
                                    break;
                            }
                        }

                        #region 详细信息

                        ltlStat.Text = mod.N_statusname;//当前状态

                        ddlArea.SelectedIndex = ddlArea.Items.IndexOf(ddlArea.Items.FindByText(mod.C_area_id));
                        if (!string.IsNullOrEmpty(mod.C_distributor))
                        {
                            txtDistributor.Value = mod.C_distributor;
                        }
                        if (!string.IsNullOrEmpty(mod.C_directuser))
                        {
                            txtDirectuser.Value = mod.C_directuser;
                        }
                        if (!string.IsNullOrEmpty(mod.C_contact))
                        {
                            txtContact.Value = mod.C_contact;
                        }
                        if (!string.IsNullOrEmpty(mod.C_con_phone))
                        {
                            txtConPhone.Value = mod.C_con_phone;
                        }

                        ddlGrd.SelectedIndex = ddlGrd.Items.IndexOf(ddlGrd.Items.FindByText(mod.C_grd));


                        if (mod.D_ship_start_dt != null)
                        {
                            txtShipStart.Value = DateTime.Parse(mod.D_ship_start_dt.ToString()).ToString("yyyy-MM-dd");
                        }
                        if (mod.D_ship_end_dt != null)
                        {
                            txtShipEnd.Value = DateTime.Parse(mod.D_ship_end_dt.ToString()).ToString("yyyy-MM-dd");
                        }
                        if (!string.IsNullOrEmpty(mod.C_prod_use))
                        {
                            txtProUse.Value = mod.C_prod_use;
                        }
                        if (!string.IsNullOrEmpty(mod.C_object_content))
                        {
                            txtObjContent.Text = mod.C_object_content;
                        }
                        if (!string.IsNullOrEmpty(mod.C_tech_desc))
                        {
                            txtTechDesc.Text = mod.C_tech_desc;
                        }
                        if (!string.IsNullOrEmpty(mod.C_remark))
                        {
                            txtBz.Text = mod.C_remark;
                        }
                        if (mod.N_object_count_wgt != null)
                        {
                            txtOBJECT_COUNT_WGT.Value = mod.N_object_count_wgt.ToString();
                        }
                        if (mod.C_site_survey_content != null)
                        {
                            txtSite_SURVEY_CONTENT.Text = mod.C_site_survey_content.ToString();
                        }
                        if (mod.N_parent_qua != null)
                        {
                            txtPARENT_QUA.Value = mod.N_parent_qua.ToString();
                        }
                        if (mod.N_quest_qua != null)
                        {
                            txtQUEST_QUA.Value = mod.N_quest_qua.ToString();
                        }
                        if (mod.N_middle_qua != null)
                        {
                            txtMIDDLE_QUA.Value = mod.N_middle_qua.ToString();
                        }
                        if (mod.N_else_qua != null)
                        {
                            txtELSE_QUA.Value = mod.N_else_qua.ToString();
                        }
                        if (!string.IsNullOrEmpty(mod.C_dept))
                        {
                            txtDEPT.Value = mod.C_dept;
                        }
                        if (!string.IsNullOrEmpty(mod.C_quality_dept))
                        {
                            txtQUALITY_DEPT.Value = mod.C_quality_dept;
                        }
                        if (!string.IsNullOrEmpty(mod.C_technology))
                        {
                            txtTECHNOLOGY.Value = mod.C_technology;
                        }
                        if (!string.IsNullOrEmpty(mod.C_qt))
                        {
                            txtQT.Value = mod.C_qt;
                        }
                        if (!string.IsNullOrEmpty(mod.C_cust_making))
                        {
                            txtCUST_MAKING.Value = GetUserName(mod.C_cust_making);
                        }
                        if (mod.D_cust_making_dt != null)
                        {
                            txtCUST_MAKING_DT.Value = DateTime.Parse(mod.D_cust_making_dt.ToString()).ToString("yyy-MM-dd");
                        }
                        if (mod.N_flag != null)
                        {
                            ddlType.SelectedValue = mod.N_flag.ToString();
                        }
                        if (!string.IsNullOrEmpty(mod.C_salesman))
                        {
                            txtSaleUser.Value = mod.C_salesman;
                        }

                        if (!string.IsNullOrEmpty(mod.C_quality_result))
                        {
                            txtQUALITY_RESULT.Value = mod.C_quality_result;
                        }

                        //if (!string.IsNullOrEmpty(mod.C_month_average))
                        //{
                        //    txtMONTH_AVERAGE.Value= mod.C_month_average;
                        //}
                        if (txtCUST_MAKING.Value == "" && vUser.Roles.Where(x => SaleCode.Contains(x.C_CODE)).Any() && mod.N_status == 0)
                        {
                            txtCUST_MAKING.Value = vUser.Name;
                            txtCUST_MAKING_DT.Value = DateTime.Now.ToString("yyyy-MM-dd");
                        }
                        #endregion
                        DataTable dt = qua.GetItemList(" and c_parentid='" + hid.Value + "'").Tables[0];
                        rptList.DataSource = dt;
                        rptList.DataBind();
                        Session["Quality"] = dt;

                        if(dt.Rows.Count>0)
                        {
                            qua.UpdateMatCode();//执行质量批次物料编码/生产日期
                        }
                    }
                }
                else
                {

                    #region //客户基本信息
                    Mod_TS_USER mod = ts_user.GetModel(vUser.Id);
                    if (mod != null)
                    {
                        #region //基本信息
                        txtDistributor.Value = mod.C_CJNAME;
                        txtContact.Value = mod.C_NAME;
                        txtConPhone.Value = mod.C_MOBILE;
                        #endregion

                    }
                    #endregion

                    this.btnAdd.Visible = true;//添加行
                    this.btndelrow.Visible = true;//删除行
                    this.btnsave.Visible = true;//保存
                    this.btnSubmit.Visible = true;//提交
                    btnCheck.Visible = false;//送审
                    //btnAudit.Visible = false;//审批
                    btndoc.Visible = false;//文档
                }
            }

            ViewState["back_no"] = Convert.ToInt32(ViewState["back_no"]) + 1;
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

        //删除行
        protected void btndelrow_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = false;
                DataTable dt = Session["Quality"] as DataTable;
                var ls = new List<string>();
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkOrder");
                    if (chkOrder.Checked)
                    {
                        ls.Add(chkOrder.Value);
                    }
                }
                for (int i = dt.Rows.Count - 1; i > -1; i--)
                {
                    if (ls.Contains(dt.Rows[i]["C_ID"].ToString()))
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                    result = true;
                }
                if (result)
                {
                    Session["Quality"] = dt;
                    rptList.DataSource = dt;
                    txtOBJECT_COUNT_WGT.Value = dt.Compute("sum(N_OBJECT_WGT)", "true").ToString() == "" ? "0" : dt.Compute("sum(N_OBJECT_WGT)", "true").ToString();
                    rptList.DataBind();
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }
        }
        private void InitDDL()
        {

            DataTable dt = qua.ListArea().Tables[0];
            if (dt.Rows.Count > 0)
            {
                ddlArea.DataSource = dt;
                ddlArea.DataTextField = "C_DETAILNAME";
                ddlArea.DataValueField = "C_DETAILCODE";
                ddlArea.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

            if (vUser.Roles.Where(x => x.C_CODE == RoleCode).Any())
            {
                Save(true);
            }
            else
            {
                if (ltlStat.Text == "2" && !string.IsNullOrEmpty(hid.Value))
                {
                    if (qua.UpdateMoneyAndDate(txtPFMONEY.Value, txtPFDATE.Value, hid.Value))
                    {
                        WebMsg.MessageBox("保存成功");
                    }
                }
                else
                {
                    Save(true);
                }
            }




        }
        /// <summary>
        /// 保存信息 
        /// </summary>
        /// <param name="isShowMsg">是否显示弹出信息</param>
        private void Save(bool isShowMsg)
        {
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            Mod_TMQ_QUA_MAIN mod = new Mod_TMQ_QUA_MAIN();
            if (!string.IsNullOrEmpty(hid.Value))
            {
                mod = qua.GetModel(hid.Value);
                hidQNO.Value = mod.C_No;
            }
            mod.C_emp_id = vUser.Id;
            mod.C_emp_name = vUser.Name;

            #region 保存信息
            if (this.ddlArea.SelectedValue != "")
            {
                mod.C_area_id = ddlArea.SelectedItem.Text;
            }
            if (!string.IsNullOrEmpty(txtDistributor.Value))
            {
                mod.C_distributor = this.txtDistributor.Value.Trim();
            }
            if (!string.IsNullOrEmpty(txtDirectuser.Value))
            {
                mod.C_directuser = this.txtDirectuser.Value.Trim();
            }
            if (!string.IsNullOrEmpty(txtContact.Value))
            {
                mod.C_contact = txtContact.Value.Trim();
            }
            if (!string.IsNullOrEmpty(txtConPhone.Value))
            {
                mod.C_con_phone = txtConPhone.Value.Trim();
            }
            mod.C_grd = ddlGrd.SelectedItem.Text;

            if (!string.IsNullOrEmpty(txtShipStart.Value))
            {
                mod.D_ship_start_dt = DateTime.Parse(txtShipStart.Value.Trim());
            }
            if (!string.IsNullOrEmpty(txtShipEnd.Value))
            {
                mod.D_ship_end_dt = DateTime.Parse(txtShipEnd.Value.Trim());
            }
            if (!string.IsNullOrEmpty(txtProUse.Value))
            {
                mod.C_prod_use = txtProUse.Value.Trim();
            }
            if (!string.IsNullOrEmpty(txtObjContent.Text))
            {
                mod.C_object_content = txtObjContent.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txtTechDesc.Text))
            {
                mod.C_tech_desc = txtTechDesc.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txtBz.Text))
            {
                mod.C_remark = txtBz.Text.Trim();
            }

            if (!string.IsNullOrEmpty(txtSite_SURVEY_CONTENT.Text))
            {
                mod.C_site_survey_content = txtSite_SURVEY_CONTENT.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txtPARENT_QUA.Value))
            {
                mod.N_parent_qua = decimal.Parse(txtPARENT_QUA.Value.Trim());
            }
            if (!string.IsNullOrEmpty(txtQUEST_QUA.Value))
            {
                mod.N_quest_qua = decimal.Parse(txtQUEST_QUA.Value.Trim());
            }
            if (!string.IsNullOrEmpty(txtMIDDLE_QUA.Value))
            {
                mod.N_middle_qua = decimal.Parse(txtMIDDLE_QUA.Value.Trim());
            }
            if (!string.IsNullOrEmpty(txtELSE_QUA.Value))
            {
                mod.N_else_qua = decimal.Parse(txtELSE_QUA.Value.Trim());
            }
            if (!string.IsNullOrEmpty(txtDEPT.Value))
            {
                mod.C_dept = txtDEPT.Value.Trim();
            }
            if (!string.IsNullOrEmpty(txtQUALITY_DEPT.Value))
            {
                mod.C_quality_dept = txtQUALITY_DEPT.Value.Trim();
            }
            if (!string.IsNullOrEmpty(txtTECHNOLOGY.Value))
            {
                mod.C_technology = txtTECHNOLOGY.Value.Trim();
            }
            if (!string.IsNullOrEmpty(txtQT.Value))
            {
                mod.C_qt = txtQT.Value.Trim();
            }
            if (!string.IsNullOrEmpty(txtCUST_MAKING.Value))
            {
                mod.C_cust_making = txtCUST_MAKING.Value.Trim();
            }
            if (!string.IsNullOrEmpty(txtCUST_MAKING_DT.Value))
            {
                mod.D_cust_making_dt = DateTime.Parse(txtCUST_MAKING_DT.Value.Trim());
            }
            if (!string.IsNullOrEmpty(ddlType.SelectedValue) && this.ddlType.SelectedValue != "-1")
            {
                mod.N_flag = decimal.Parse(ddlType.SelectedValue);
            }
            if (!string.IsNullOrEmpty(txtSaleUser.Value))
            {
                mod.C_salesman = txtSaleUser.Value;
            }

            if (!string.IsNullOrEmpty(txtQUALITY_RESULT.Value))
            {
                mod.C_quality_result = txtQUALITY_RESULT.Value;
            }

            mod.C_objection_type = dropGrdType.SelectedValue;//钢种类型

            if (dropQUEXIAN.SelectedValue != "-1")
            {
                mod.C_ourreasons = dropQUEXIAN.SelectedValue;//缺陷类别
            }
            if (!string.IsNullOrEmpty(txtPFDATE.Value))//赔付日期
            {
                mod.D_compensation_dt = Convert.ToDateTime(txtPFDATE.Value);
            }

            if (!string.IsNullOrEmpty(txtPFMONEY.Value))//赔付金额
            {
                mod.N_amount = Convert.ToDecimal(txtPFMONEY.Value);
            }

            #endregion

            if (!string.IsNullOrEmpty(hid.Value))
            {
                mod.C_id = hid.Value;
                List<Mod_TMQ_QUA_ITEM> ls = AddListItem(vUser, mod);
                mod.N_object_count_wgt = ls.Sum(x => x.N_object_wgt);
                if (vUser.Roles.Where(x => x.C_CODE == RoleCode).Any())
                {
                    mod.N_status = -1;
                }

                if (qua.AddListItem(ls, hid.Value) && qua.Update(mod) && isShowMsg)
                {
                    Page pa = (Page)System.Web.HttpContext.Current.CurrentHandler;
                    ClientScript.RegisterClientScriptBlock(pa.GetType(), "aa", "<script language='javascript'>alert('修改成功');</script>");
                }
            }
            else
            {
                if (vUser.Roles.Where(x => x.C_CODE == RoleCode).Any())
                {
                    mod.N_status = -1;
                }
                mod.C_crt_id = vUser.Id;
                mod.C_id = Guid.NewGuid().ToString();

                List<Mod_TMQ_QUA_ITEM> ls = AddListItem(vUser, mod);
                mod.N_object_count_wgt = ls.Sum(x => x.N_object_wgt);
                if (qua.AddListItem(ls, mod.C_id) && qua.Add(mod) && isShowMsg)
                {
                    Page pa = (Page)System.Web.HttpContext.Current.CurrentHandler;
                    ClientScript.RegisterClientScriptBlock(pa.GetType(), "aa", "<script language='javascript'>alert('添加成功');</script>");
                }
                hid.Value = mod.C_id;
                hidQNO.Value = qua.GetModel(mod.C_id).C_No;
            }

        }

        //送审
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            Save(false);
            {
                Response.Redirect("Quality_Audit.aspx?ID=" + hid.Value + "&QNO=" + hidQNO.Value);
            }
        }
        /// <summary>
        /// 页面数据转换成List
        /// </summary>
        /// <param name="vUser"></param>
        /// <param name="mod"></param>
        /// <returns></returns>
        private List<Mod_TMQ_QUA_ITEM> AddListItem(CurrentUser vUser, Mod_TMQ_QUA_MAIN mod)
        {
            var ls = new List<Mod_TMQ_QUA_ITEM>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                Mod_TMQ_QUA_ITEM modItem = new Mod_TMQ_QUA_ITEM();
                modItem.C_id = Guid.NewGuid().ToString();
                modItem.C_brand_name = ((TextBox)rptList.Items[i].FindControl("txtBRAND_NAME")).Text;
                modItem.C_spec = ((TextBox)rptList.Items[i].FindControl("txtSPEC")).Text;
                modItem.C_batch = ((TextBox)rptList.Items[i].FindControl("txtBATCH")).Text;//
                if (((TextBox)rptList.Items[i].FindControl("txtSHIPPEDQTY")).Text != "")
                {
                    modItem.N_shippedqty = decimal.Parse(((TextBox)rptList.Items[i].FindControl("txtSHIPPEDQTY")).Text);//
                }
                if (((HtmlInputText)rptList.Items[i].FindControl("txtOBJECT_WGT")).Value != "")
                {
                    modItem.N_object_wgt = decimal.Parse(((HtmlInputText)rptList.Items[i].FindControl("txtOBJECT_WGT")).Value);//
                }
                modItem.C_stl_code = ((TextBox)rptList.Items[i].FindControl("txtSTL_CODE")).Text;
                modItem.C_crt_id = vUser.Id;
                modItem.C_emp_dt = DateTime.Now;
                modItem.C_emp_id = vUser.Id;
                modItem.C_emp_name = vUser.Name;
                modItem.C_parentid = mod.C_id;
                modItem.D_crt_dt = DateTime.Now;
                ls.Add(modItem);
            }

            return ls;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (Session["Quality"] != null)
            {
                dt = Session["Quality"] as DataTable;
            }
            if (rptList.Items.Count > 0)
            {
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    dt.Rows[i]["C_ID"] = ((HtmlInputCheckBox)rptList.Items[i].FindControl("chkOrder")).Value;
                    dt.Rows[i]["C_PARENTID"] = ((HtmlInputHidden)rptList.Items[i].FindControl("hidVal")).Value;
                    dt.Rows[i]["C_BRAND_NAME"] = ((TextBox)rptList.Items[i].FindControl("txtBRAND_NAME")).Text;
                    dt.Rows[i]["C_SPEC"] = ((TextBox)rptList.Items[i].FindControl("txtSPEC")).Text;
                    dt.Rows[i]["C_BATCH"] = ((TextBox)rptList.Items[i].FindControl("txtBATCH")).Text;//
                    dt.Rows[i]["N_SHIPPEDQTY"] = ((TextBox)rptList.Items[i].FindControl("txtSHIPPEDQTY")).Text;//
                    dt.Rows[i]["N_OBJECT_WGT"] = ((HtmlInputText)rptList.Items[i].FindControl("txtOBJECT_WGT")).Value;//
                    dt.Rows[i]["C_STL_CODE"] = ((TextBox)rptList.Items[i].FindControl("txtSTL_CODE")).Text;//   
                }
            }
            else
            {
                if (!dt.Columns.Contains("C_ID"))
                {
                    dt.Columns.Add("C_ID", typeof(string));//
                    dt.Columns.Add("C_PARENTID", typeof(string));//
                    dt.Columns.Add("C_BRAND_NAME", typeof(string));//
                    dt.Columns.Add("C_SPEC", typeof(string));//钢种
                    dt.Columns.Add("C_BATCH", typeof(string));//规格
                    dt.Columns.Add("N_SHIPPEDQTY", typeof(string));//客户协议
                    dt.Columns.Add("N_OBJECT_WGT", typeof(string));//执行标准
                    dt.Columns.Add("C_STL_CODE", typeof(string));//自由项1
                }
            }
            var row = dt.NewRow();
            row["C_ID"] = Guid.NewGuid().ToString();
            row["C_PARENTID"] = hid.Value;
            row["C_SPEC"] = "φ";
            dt.Rows.Add(row);

            Session["Quality"] = dt;
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                Session["Quality"] = null;
            }

        }

        //提交邢钢处理（客户）
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrEmpty(hid.Value))
                {
                    Mod_TMQ_QUA_MAIN mod = new Mod_TMQ_QUA_MAIN();
                    mod = qua.GetModel(hid.Value);
                    var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                    if (vUser.Roles.Where(x => x.C_CODE == RoleCode).Any())
                    {
                        mod.N_status = 0;
                    }

                    if (qua.Update(mod))
                    {
                        this.btnAdd.Visible = false;//添加行
                        this.btndelrow.Visible = false;//删除行
                        this.btnsave.Visible = false;//保存
                        this.btnSubmit.Visible = false;//提交
                        btndoc.Visible = false;//文档
                        //btnAudit.Visible = false;//审批
                        btnCheck.Visible = false;//送审

                        WebMsg.MessageBox("提交成功");

                        //Page pa = (Page)System.Web.HttpContext.Current.CurrentHandler;
                        //ClientScript.RegisterClientScriptBlock(pa.GetType(), "aa", "<script language='javascript'>alert('提交成功!');</script>");
                    }
                }
                else
                {
                    WebMsg.MessageBox("请点击保存");
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}