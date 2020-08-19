using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using NF.BLL;
using NF.MODEL;
using NF.Framework;

namespace CRM.BasicData
{
    public partial class AreaPlanUpdate : System.Web.UI.Page
    {
        private Bll_TMB_AREAPLAN areaPlan = new Bll_TMB_AREAPLAN();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    GetArea();
                    if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                    {
                        hidID.Value = Request.QueryString["ID"];

                        Mod_TMB_AREAPLAN mod = new Mod_TMB_AREAPLAN();
                        mod = areaPlan.GetModel(hidID.Value);
                        if (mod != null)
                        {
                            dropArea.SelectedIndex = dropArea.Items.IndexOf(dropArea.Items.FindByValue(mod.C_AERA_ID));
                            Start.Value = Convert.ToDateTime(mod.D_START).ToString("yyy-MM-dd");
                            End.Value = Convert.ToDateTime(mod.D_END).ToString("yyy-MM-dd");
                            txtNum.Value = mod.N_WGT.ToString();
                        }

                    }
                }
                catch (Exception ex)
                {
                    WebMsg.MessageBox(ex.Message);
                }
            }
        }

        /// <summary>
        /// 获取区域
        /// </summary>
        private void GetArea()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ConArea";
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropArea.DataSource = dt;
                dropArea.DataTextField = "C_DETAILNAME";
                dropArea.DataValueField = "C_DETAILNAME";
                dropArea.DataBind();
               
            }
            else
            {
                dropArea.DataSource = null;
                dropArea.DataBind();
            }
        }

        /// <summary>
        /// 数据是否重复
        /// </summary>
        /// <returns></returns>

        private bool GetCheckPepeat(string areaID, string start, string end)
        {
            Mod_TMB_AREAPLAN mod = new Mod_TMB_AREAPLAN();
            mod.C_AERA_ID = areaID;
            mod.D_START = Convert.ToDateTime(start);
            mod.D_END = Convert.ToDateTime(end);

            if (areaPlan.Exists(areaID, start, end))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool UpdatePlan(string ID, string num)
        {
            var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            Mod_TMB_AREAPLAN mod = areaPlan.GetModel(ID);
            mod.C_EMP_ID = BaseUser.Id;
            mod.C_EMP_NAME = BaseUser.Name;
            mod.D_MOD_DT = DateTime.Now;
            mod.N_WGT = Convert.ToDecimal(num);
            return areaPlan.Update(mod);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdatePlan(hidID.Value, txtNum.Value))
                {
                    Response.Write("<script>alert('提交成功');window.parent.document.getElementById(\"btn_Search\").click();window.parent.close();</script>");
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }

        }
    }
}