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
    public partial class HYPLAN : System.Web.UI.Page
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
            DataTable dt = tmd_hy_plan.GetListFrist(txtStart.Value).Tables[0];
            if (dt.Rows.Count > 0)
            {
                txtRemark.Text = dt.Rows[0]["C_REMARK"].ToString();
                ltlID.Text = dt.Rows[0]["C_ID"].ToString();
            }
            else
            {
                string str = "1.火车执行情况：点前0车，执行 0 车、剩余 0车；点后0车，执行0车、剩余0车；次日点后0车，执行0车、剩余0车。\r\n";
                str += "2.厂内火车情况：空车0车、重车0车、到达预报：无。\r\n";
                str += "3. 零点后出库0吨，其中：汽运0吨，火运0吨。\r\n";
                str += "4.17日全天自提车进0车。18日0:00—6:30进0车。\r\n";
                str += "5. 全天水渣进0车.";

                txtRemark.Text = str;
                ltlID.Text = string.Empty;
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Mod_TMD_HY_PLAN mod = new Mod_TMD_HY_PLAN();

                if (string.IsNullOrEmpty(ltlID.Text))
                {
                    Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();
                    trc_roll_prodcut.ExeProc();//执行钢坯/线材库存类型
                }

                mod.C_TYPE = ltlID.Text == "" ? "N" : "Y";
                mod.C_REMARK = txtRemark.Text;
                mod.C_EMP_NAME = ltlEmpName.Text;
                mod.D_DT = Convert.ToDateTime(txtStart.Value);
                mod.C_ID = ltlID.Text;
                if (tmd_hy_plan.Insert_Update(mod))
                {
                    WebMsg.MessageBox("保存成功");
                    GetList();
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
            if (!string.IsNullOrEmpty(ltlID.Text))
            {
                Mod_TMD_HY_PLAN mod = new Mod_TMD_HY_PLAN();
                mod.C_ID = ltlID.Text;
                if (tmd_hy_plan.Del(mod))
                {
                    WebMsg.MessageBox("删除成功");
                    GetList();
                }
            }
        }
    }
}