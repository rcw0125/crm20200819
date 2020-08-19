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
    public partial class AreaPlanInsert : System.Web.UI.Page
    {
        private static Bll_TMB_AREAPLAN areaPlan = new Bll_TMB_AREAPLAN();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetArea();

                DateTime dt = DateTime.Now;
                Start.Value = Convert.ToDateTime(dt).ToString("yyy-MM-dd");
                End.Value = dt.AddMonths(1).AddDays(-(dt.Day)).ToString("yyy-MM-dd");
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

        private bool GetCheckPepeat(string areaID, string start, string end)
        {
            return areaPlan.Exists(areaID, start, end);
        }


        private bool InsertAreaPlan(string areaID, string start, string end, string num)
        {
            var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

            Mod_TMB_AREAPLAN mod = new Mod_TMB_AREAPLAN();
            if (BaseUser != null)
            {
                mod.C_EMP_ID = BaseUser.Id;
                mod.C_EMP_NAME = BaseUser.Name;
            }
            mod.D_MOD_DT = DateTime.Now;
            mod.N_WGT = Convert.ToDecimal(num);
            mod.C_AERA_ID = areaID;
            mod.D_START = Convert.ToDateTime(start);
            mod.D_END = Convert.ToDateTime(end);

            return areaPlan.Add(mod);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!GetCheckPepeat(dropArea.SelectedItem.Value, Start.Value, End.Value))
                {
                    if (InsertAreaPlan(dropArea.SelectedItem.Value, Start.Value, End.Value, txtNum.Value))
                    {
                        Response.Write("<script>alert('添加成功'); window.parent.document.getElementById(\"btn_Search\").click();</script>");
                    }
                }
                else
                {
                    WebMsg.MessageBox("当前区域时间重复");
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}