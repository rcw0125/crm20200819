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

namespace CRM.BasicData
{
    public partial class Cust_TechProtAdd : System.Web.UI.Page
    {
        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();
        private Bll_TB_STD_CONFIG tb_std_config = new Bll_TB_STD_CONFIG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlempid.Text = vUser.Id;
                    ltlempname.Text = vUser.Name;
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }


        /// <summary>
        /// 执行标准
        /// </summary>
        private void GetSTD()
        {
            DataTable dt = tb_matrl_main.GetSTD(txtstlgrd.Value).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropstd.DataSource = dt;
                dropstd.DataValueField = "c_id";
                dropstd.DataTextField = "c_std_code";
                dropstd.DataBind();
                dropstd.Items.Insert(0, new ListItem("请选择", ""));

                dropzzs.DataSource = dt;
                dropzzs.DataValueField = "c_id";
                dropzzs.DataTextField = "c_std_code";
                dropzzs.DataBind();
                dropzzs.Items.Insert(0, new ListItem("", ""));

            }
        }

        public void GetFree()
        {
            DataTable dtzyx1 = tb_matrl_main.GetZYX1(txtstlgrd.Value).Tables[0];
            if (dtzyx1.Rows.Count > 0)
            {
                dropzyx1.DataSource = dtzyx1;
                dropzyx1.DataTextField = "ZYX1";
                dropzyx1.DataValueField = "ZYX1";
                dropzyx1.DataBind();
            }
            else
            {
                dropzyx1.DataSource = null;
                dropzyx1.DataBind();
            }

            DataTable dtzyx2 = tb_matrl_main.GetZYX2(txtstlgrd.Value).Tables[0];
            if (dtzyx2.Rows.Count > 0)
            {
                dropzyx2.DataSource = dtzyx2;
                dropzyx2.DataTextField = "ZYX2";
                dropzyx2.DataValueField = "ZYX2";
                dropzyx2.DataBind();
            }
            else
            {
                dropzyx2.DataSource =null;
                dropzyx2.DataBind();
            }

        }

        //执行标准选择
        protected void dropstd_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropzyx1.Items.Clear();
            dropzyx2.Items.Clear();

            GetFree();//自由项
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_std_config.Exists(txtstlgrd.Value, txtcustno.Value, txtcust_tech_prot.Text))
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('当前客户钢种协议号重复');", true);
                }
                else
                {
                    Mod_TB_STD_CONFIG mod = new Mod_TB_STD_CONFIG();
                    mod.C_STD_CODE = dropstd.SelectedItem.Text;
                    mod.C_STD_ID = dropstd.SelectedItem.Value;
                    mod.C_CUST_TECH_PROT = txtcust_tech_prot.Text;
                    mod.C_ZYX1 = dropzyx1.SelectedItem.Text;
                    mod.C_ZYX2 = dropzyx2.SelectedItem.Text;
                    mod.C_STL_GRD = txtstlgrd.Value;
                    mod.C_EMP_ID = ltlempid.Text;
                    mod.C_CUST_NO = txtcustno.Value;
                    mod.C_CUST_NAME = txtcustname.Value;
                    mod.C_ZZS = dropzzs.SelectedItem.Text;
                    if (tb_matrl_main.InsertFree(mod))
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('保存成功');", true);

                    }
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }
        }
        //加载钢种
        protected void imgbtnJz_Click(object sender, ImageClickEventArgs e)
        {
            dropzyx1.Items.Clear();
            dropzyx2.Items.Clear();
            dropstd.Items.Clear();

            GetSTD();//执行标准
        }
    }
}




