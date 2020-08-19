using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using NF.MODEL;
using NF.BLL;
using System.Data;
using NF.Framework;

namespace CRM.WebForms.Report
{
    public partial class HYPLAN_INFO : System.Web.UI.Page
    {
        private Bll_TMD_HY_PLAN tmd_hy_plan = new Bll_TMD_HY_PLAN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");

                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlEmpName.Text = vUser.Name;

                    GetList();
                }

            }
        }

        private void GetList()
        {
            DataTable dt = tmd_hy_plan.GetListInfo(txtStart.Value);
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                var list = new List<Mod_TMD_HY_INFO>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxID = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxID");
                   
                    HtmlInputText txtN_KC_NUM = (HtmlInputText)rptList.Items[i].FindControl("txtN_KC_NUM");
                    HtmlInputText txtN_ZC_NUM = (HtmlInputText)rptList.Items[i].FindControl("txtN_ZC_NUM");
                    HtmlInputText txtN_YB_NUM = (HtmlInputText)rptList.Items[i].FindControl("txtN_YB_NUM");
                  
                    Literal ltlC_TYPE = (Literal)rptList.Items[i].FindControl("ltlC_TYPE");//N/Y INSERT/UPDATE

                    Mod_TMD_HY_INFO mod = new Mod_TMD_HY_INFO();
                    mod.C_ID = cbxID.Value;
                  
                    mod.N_KC_NUM = Convert.ToDecimal(txtN_KC_NUM.Value == "" ? "0" : txtN_KC_NUM.Value);
                    mod.N_ZC_NUM = Convert.ToDecimal(txtN_ZC_NUM.Value == "" ? "0" : txtN_ZC_NUM.Value);
                    mod.N_YB_NUM = Convert.ToDecimal(txtN_YB_NUM.Value == "" ? "0" : txtN_YB_NUM.Value);
                  
                    mod.C_EMP_NAME = ltlEmpName.Text;
                    mod.C_TYPE = ltlC_TYPE.Text;

                    list.Add(mod);

                }
                if (tmd_hy_plan.Insert_Update_Info(list))
                {
                    GetList();
                    WebMsg.MessageBox("保存成功");
                    //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('保存成功');</script>", false);
                }

            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }
        }

        protected void btnCX_Click(object sender, EventArgs e)
        {
            GetList();
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new List<Mod_TMD_HY_INFO>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxID = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxID");
                    if (cbxID.Checked)
                    {
                        Mod_TMD_HY_INFO mod = new Mod_TMD_HY_INFO();
                        mod.C_ID = cbxID.Value;
                        list.Add(mod);
                    }
                }

                if (tmd_hy_plan.DelList_Info(list))
                {
                    GetList();
                    WebMsg.MessageBox("删除成功");
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}