﻿using System;
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
    public partial class _CustDoc : System.Web.UI.Page
    {
        private const string RoleCode = "kh-001";

        private Bll_TMQ_QUALITY_FILE tmq_quality_file = new Bll_TMQ_QUALITY_FILE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {

                    if (vUser.Roles.Where(x => x.C_CODE == RoleCode).Any())
                    {
                        Button2.Visible =true;
                    }
                    else
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
            DataTable dt = tmq_quality_file.GetQualityFileList(ltlpk.Text).Tables[0];
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string filetype = Path.GetExtension(file1.PostedFile.FileName);
                string filename = Path.GetFileNameWithoutExtension(file1.PostedFile.FileName);//文件名；
                string newfilename = filename + filetype;//+ 
                string path = "~/files/";
                string savepath = System.Web.HttpContext.Current.Server.MapPath(path) + newfilename;
                file1.PostedFile.SaveAs(savepath);

                Mod_TMQ_QUALITY_FILE mod = new Mod_TMQ_QUALITY_FILE();

                mod.C_TITLE = newfilename;
                mod.C_PATH = path + newfilename;
                mod.C_QUALITY_ID = ltlpk.Text;
                mod.C_REMARK = ltlempid.Text;

                if (tmq_quality_file.Add(mod))
                {
                    WebMsg.MessageBox("上传成功");
                    GetList();
                }
                else
                {
                    WebMsg.MessageBox("上传失败");
                }
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