using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

using System.Data;
using NF.BLL;
using NF.MODEL;
using NF.Framework;
using System.IO;

namespace CRM.WebForms.Report
{
    public partial class zzs_file : System.Web.UI.Page
    {
        private Bll_TQC_ZZS_FILE tqc_zzs_file = new Bll_TQC_ZZS_FILE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Text1.Value = DateTime.Now.ToString("yyy-MM-dd");

                txtjssj.Value = DateTime.Now.ToString("yyy-MM-dd");

            }
        }

        private void GetList()
        {
            DataTable dt = tqc_zzs_file.GetList(txtbatch.Text, txtstlgrd.Text, txtstove.Text, Text1.Value, txtjssj.Value).Tables[0];
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

        //预览
        public static string GetPrint(object batch, object stove, object stlgrd, object spec, object pdf)
        {


            string[] arr = { batch.ToString(), stove.ToString(), stlgrd.ToString(), spec.ToString() };
            StringBuilder strHtml = new StringBuilder();
            strHtml.AppendFormat("<a href=\"http://192.168.2.93:8685/webroot/decision/view/report?viewlet=xgcap/ZZS_FJ.cpt&BATCH={0}&STOVE={1}&STLGRD={2}&GG={3}\" target=\"_blank\" class=\"btn btn-success btn-xs\">下载模板<span class=\"glyphicon glyphicon - search\"></span></a>", arr);

            if (!string.IsNullOrEmpty(pdf.ToString()))
            {
                string pdfpath = NF.Framework.StringFormat.ResolveUrl(pdf.ToString());
                strHtml.AppendFormat(" &nbsp;<a href='{0}' target=\"_blank\" class=\"btn btn-success btn-xs\">金相图片</a>", pdfpath);
            }
            return strHtml.ToString();
        }

        protected void btnxc_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private string GetTime()
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            string hour = DateTime.Now.Hour.ToString();
            string minute = DateTime.Now.Minute.ToString();
            string second = DateTime.Now.Second.ToString();
            return year + month + day + hour + minute + second;

        }


        //上传附件
        protected void Button2_Click(object sender, EventArgs e)
        {
            bool frist = true;
            bool result = false;
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox cbxID = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxID");
                if (cbxID.Checked)
                {
                    Literal ltlC_BATCH_NO = (Literal)rptList.Items[i].FindControl("ltlC_BATCH_NO");
                    Literal ltlC_STOVE = (Literal)rptList.Items[i].FindControl("ltlC_STOVE");
                    Literal ltlC_STD_CODE = (Literal)rptList.Items[i].FindControl("ltlC_STD_CODE");
                    Literal ltlC_STL_GRD = (Literal)rptList.Items[i].FindControl("ltlC_STL_GRD");
                    Literal ltlC_SPEC = (Literal)rptList.Items[i].FindControl("ltlC_SPEC");


                    if (!tqc_zzs_file.ExistsZZS(ltlC_BATCH_NO.Text, ltlC_STL_GRD.Text, ltlC_STOVE.Text, ltlC_STD_CODE.Text))
                    {
                        #region //上传附件
                        string filetype = Path.GetExtension(file1.PostedFile.FileName);
                        string filename = Path.GetFileNameWithoutExtension(file1.PostedFile.FileName);//文件名；
                        string newfilename = ltlC_BATCH_NO.Text + "(" + GetTime() + ")" + filetype;//+ 
                        string path = "~/files/";
                        string savepath = System.Web.HttpContext.Current.Server.MapPath(path) + newfilename;
                        file1.PostedFile.SaveAs(savepath);

                        string dz = path + newfilename;

                        #endregion

                        var mod = new Mod_TQC_ZZS_FILE()
                        {
                            C_BATCH_NO = ltlC_BATCH_NO.Text,
                            C_STOVE = ltlC_STOVE.Text,
                            C_STD_CODE = ltlC_STD_CODE.Text,
                            C_STL_GRD = ltlC_STL_GRD.Text,
                            C_SPEC = ltlC_SPEC.Text,
                            C_PDF_PATCH = dz,
                            C_EMP_ID = vUser.Name
                        };
                        result = tqc_zzs_file.InsertItem(mod);
                    }
                    else
                    {
                        #region //上传附件
                        string filetype = Path.GetExtension(file1.PostedFile.FileName);
                        string filename = Path.GetFileNameWithoutExtension(file1.PostedFile.FileName);//文件名；
                        string newfilename = ltlC_BATCH_NO.Text + "(" + GetTime() + ")" + filetype;//+ 
                        string path = "~/files/";
                        string savepath = System.Web.HttpContext.Current.Server.MapPath(path) + newfilename;
                        file1.PostedFile.SaveAs(savepath);

                        string dz = path + newfilename;

                        #endregion

                        var mod = new Mod_TQC_ZZS_FILE()
                        {
                            C_BATCH_NO = ltlC_BATCH_NO.Text,
                            C_STOVE = ltlC_STOVE.Text,
                            C_STD_CODE = ltlC_STD_CODE.Text,
                            C_STL_GRD = ltlC_STL_GRD.Text,
                            C_SPEC = ltlC_SPEC.Text,
                            C_PDF_PATCH = dz,
                            C_EMP_ID = vUser.Name
                        };
                        result = tqc_zzs_file.UpdateItem(mod);
                    }


                    frist = false;
                    break;
                }
            }
            if (result)
            {
                WebMsg.MessageBox("上传成功");
                GetList();
            }
        }
    }
}