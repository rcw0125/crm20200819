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
    public partial class _ConDoc : System.Web.UI.Page
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

                    if (vUser.Roles.Where(x => x.C_CODE == RoleCode).Any())
                    {
                        Button2.Visible = false;
                    }

                    ltlempid.Text = vUser.Id;
                    if (!string.IsNullOrEmpty(Request.QueryString["pk"]))
                    {
                        ltlpk.Text = Request.QueryString["pk"];
                        GetList();
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
            DataTable dt = tb_file.GetList(ltlpk.Text).Tables[0];
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

        private string GetTime()
        {
            
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            string hour = DateTime.Now.Hour.ToString();
            string minute = DateTime.Now.Minute.ToString();
            string second = DateTime.Now.Second.ToString();
            return month + day + hour + minute + second;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string filetype = Path.GetExtension(file1.PostedFile.FileName);
                string filename = Path.GetFileNameWithoutExtension(file1.PostedFile.FileName);//文件名；
                string newfilename = filename + "(" + GetTime() + ")" + filetype;//+ 
                string path = "~/files/";
                string savepath = System.Web.HttpContext.Current.Server.MapPath(path) + newfilename;
                file1.PostedFile.SaveAs(savepath);


                Mod_TB_FILE mod = new Mod_TB_FILE();
                mod.C_FILENAME = newfilename;
                mod.C_FILETYPE = "0";
                mod.C_FILEPATH = path + newfilename;
                mod.C_FILELINK = ltlpk.Text;
                mod.C_EMPID = ltlempid.Text;

                if (tb_file.Add(mod))
                {
                    WebMsg.MessageBox("上传成功");
                    GetList();
                }
                else
                {
                    WebMsg.MessageBox("上传失败");
                }

                //if (tb_file.Exists(ltlpk.Text, newfilename))
                //{
                //    Mod_TB_FILE mod = new Mod_TB_FILE();
                //    mod.C_FILENAME = newfilename;
                //    mod.C_FILETYPE = "0";
                //    mod.C_FILEPATH = path + newfilename;
                //    mod.C_FILELINK = ltlpk.Text;
                //    mod.C_EMPID = ltlempid.Text;
                //    if (tb_file.Update(mod))
                //    {
                //        WebMsg.MessageBox("上传成功");
                //        GetList();
                //    }
                //    else
                //    {
                //        WebMsg.MessageBox("上传失败");
                //    }
                //}
                //else
                //{

                //}
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }


        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "down")
            {
                try
                {
                    if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
                    {
                        string DownloadFileName = e.CommandArgument.ToString();
                        string filepath = Server.MapPath(DownloadFileName);
                        string filename = Path.GetFileName(filepath);
                        FileInfo file = new FileInfo(filepath);
                        Response.Clear();
                        Response.ContentType = "application/octet-stream";
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8));
                        Response.AddHeader("Content-length", file.Length.ToString());
                        Response.Flush();
                        Response.WriteFile(filepath);
                    }
                }
                catch
                {
                    Response.Write("<script>alert('没有找到下载的源文件')</script>");
                }
            }
        }
    }
}