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

namespace CRM.WebForms.Report
{
    public partial class ProcAdd : System.Web.UI.Page
    {
        private Bll_TMB_PROC tmb_proc = new Bll_TMB_PROC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetProcType();
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    hid.Value = Request.QueryString["ID"];
                    DataTable dt = tmb_proc.GetProcList(hid.Value).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        dropproctype.SelectedIndex = dropproctype.Items.IndexOf(dropproctype.Items.FindByText(dt.Rows[0]["C_PROCTYPE"].ToString()));
                        txtstlgrd.Value = dt.Rows[0]["C_STLGRD"].ToString();
                        txtspec.Value = dt.Rows[0]["C_SPEC"].ToString();
                        txtstdcode.Value = dt.Rows[0]["C_STDCODE"].ToString();
                        txtdesc.Value = dt.Rows[0]["C_DESC"].ToString();
                        txtremark.Value = dt.Rows[0]["C_REMARK"].ToString();
                        preview.Src = ResolveUrl(dt.Rows[0]["C_IMGURL"].ToString());
                        hidimg.Value = dt.Rows[0]["C_IMGURL"].ToString();
                    }
                }
            }
        }
        private void GetProcType()
        {
            DataTable dt = tmb_proc.GetProcType().Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropproctype.DataSource = dt;
                dropproctype.DataTextField = "C_NAME";
                dropproctype.DataValueField = "C_NAME";
                dropproctype.DataBind();
            }
            else
            {
                dropproctype.DataSource = null;
                dropproctype.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string filetype = Path.GetExtension(File1.PostedFile.FileName);
            string filename = Path.GetFileNameWithoutExtension(File1.PostedFile.FileName);//文件名；
            string newfilename = filename + filetype;//+ 
            string path = "/Uploads/";

            Mod_TMB_PROC mod = new Mod_TMB_PROC();
            mod.C_STLGRD = txtstlgrd.Value;
            mod.C_SPEC = txtspec.Value;
            mod.C_STDCODE = txtstdcode.Value;
            mod.C_DESC = txtdesc.Value;
            mod.C_REMARK = txtremark.Value;
            mod.C_PROCTYPE = dropproctype.SelectedItem.Text;

            if (!string.IsNullOrEmpty(hid.Value))
            {
                mod.C_ID = hid.Value;
                if (!string.IsNullOrEmpty(filename))
                {
                    mod.C_IMGURL = path + newfilename;
                    string savepath = System.Web.HttpContext.Current.Server.MapPath(path) + newfilename;
                    File1.PostedFile.SaveAs(savepath);
                }
                else
                {
                    mod.C_IMGURL = hidimg.Value;
                }
                if (tmb_proc.UpdateProc(mod))
                {
                    Response.Write("<script>alert('修改成功');window.parent.getProcList();window.parent.close();</script>");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(filename))
                {
                    mod.C_IMGURL = path+newfilename;
                    string savepath = System.Web.HttpContext.Current.Server.MapPath(path) + newfilename;
                    File1.PostedFile.SaveAs(savepath);
                }
                if (tmb_proc.AddProc(mod))
                {                  
                    WebMsg.MessageBox("添加成功", "ProcAdd.aspx");
                }
            }
        }
    }
}