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
using NF.NC.Interface;

namespace CRM.WebForms.Sale_App
{
    public partial class fyd_edit_slabout : System.Web.UI.Page
    {

        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlempName.Text = vUser.Name;

                    if (!string.IsNullOrEmpty(Request.QueryString["fyd"]))
                    {
                        ltlfyd.Text = Request.QueryString["fyd"];
                        Mod_TMD_DISPATCH mod = tmd_dispatch.GetModel(ltlfyd.Text);
                        if (mod != null)
                        {
                            btnSave.Enabled = mod.C_STATUS == "9" ? true : false;
                            btnNC.Enabled = mod.C_STATUS == "9" ? true : false;

                            GetList();
                        }
                    }
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }

        private void GetList()
        {
            DataTable dt = tmd_dispatch.GetStockOut(ltlfyd.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();

                ltlsumwgt.Text = dt.Compute("sum(N_JZ)", "true").ToString();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                ltlsumwgt.Text = "";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new List<Mod_TMD_DISPATCH_SJZJB>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    Literal ltlID = (Literal)rptList.Items[i].FindControl("ltlID");
                    TextBox txtN_JZ = (TextBox)rptList.Items[i].FindControl("txtN_JZ");
                    Mod_TMD_DISPATCH_SJZJB mod = new Mod_TMD_DISPATCH_SJZJB();
                    mod.C_ID = ltlID.Text;
                    mod.C_DISPATCH_ID = ltlfyd.Text;
                    mod.N_JZ = Convert.ToDecimal(txtN_JZ.Text == "" ? "0" : txtN_JZ.Text);
                    list.Add(mod);
                }
                if (tmd_dispatch.UpdateStockOut(list))
                {
                    var logger = Logger.CreateLogger(this.GetType());
                    logger.Info("操作人姓名" + ltlempName.Text + DateTime.Now.ToString() + ";修改销售出库量，发运单号" + ltlfyd.Text);

                    GetList();
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('保存成功');</script>", false);
                }
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + ex.Message + "');</script>", false);
            }
        }



        protected void btnNC_Click(object sender, EventArgs e)
        {
            ApiWL_SJ apiwl_sj = new ApiWL_SJ();

            List<ApiDispDto> apiDispList = new List<ApiDispDto>();
            string strmsg = string.Empty;
            string fileName = ltlfyd.Text + ".xml";
            string filePath = "~/FileInterface/" + fileName;
            string xmlFileName = Server.MapPath(filePath);
            bool result = apiwl_sj.SendXml_DM(xmlFileName, ltlfyd.Text, apiDispList);
            if (result)
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('导入NC成功');</script>", false);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('导入NC失败');</script>", false);
            }
        }

    }
}