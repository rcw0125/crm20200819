using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.BLL;
using NF.MODEL;
using NF.Framework;


namespace CRM.Common
{
    public partial class _ZZSDoc : System.Web.UI.Page
    {
        private const string RoleCode = "kh-001";

        private Bll_TB_FILE tb_file = new Bll_TB_FILE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {

                    ltlempid.Text = vUser.Id;
                    if (!string.IsNullOrEmpty(Request.QueryString["pk"])&&!string .IsNullOrEmpty(Request .QueryString["zsh"]))
                    {
                        ltlpk.Text = Request.QueryString["pk"];
                        ltlzsh.Text = Request.QueryString["zsh"];
                    }


                }
                else
                {
                    WebMsg.CheckUserLogin();
                }

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string filetype = Path.GetExtension(file1.PostedFile.FileName);
                string filename = Path.GetFileNameWithoutExtension(file1.PostedFile.FileName);//文件名；
                string newfilename = ltlzsh.Text + filetype;//+ 
                string path = "~/files/";
                string savepath = System.Web.HttpContext.Current.Server.MapPath(path) + newfilename;
                file1.PostedFile.SaveAs(savepath);

                string dz = path + newfilename;


                Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();
                if (trc_roll_prodcut.UpdateZZSPDF(ltlpk.Text, ltlzsh.Text, dz))
                {
                    Response.Write("<script>alert('上传成功');window.parent.document.getElementById('imgbtnJz').click();window.parent.close();</script>");
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }


        }
    }
}