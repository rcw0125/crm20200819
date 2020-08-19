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
using ZXing;
using System.Drawing;

namespace CRM.WebForms.Cust_App
{
    public partial class CustZZS : System.Web.UI.Page
    {
        private static Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();
        private static Bll_TQC_ZZS_FILE tqc_zzs_file = new Bll_TQC_ZZS_FILE();
        private Bll_TMD_DISPATCHDETAILS tmd_dispatchdetails = new Bll_TMD_DISPATCHDETAILS();

        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtckkssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtckjssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlemp.Text = vUser.Name;
                    ltlcustno.Text = vUser.CustFile.C_NO;

                    //自动生成质证书
                    GetZZS();
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }



        #region //自动生成质证书

        private void GetZZS()
        {
            var logger = Logger.CreateLogger(this.GetType());

            try
            {
                DataTable dt = tmd_dispatchdetails.GetGPZZS();
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string sendcode = dt.Rows[j]["C_DISPATCH_ID"].ToString();

                    #region//钢坯质证书

                    Bll_RandomNumber randomnumber = new Bll_RandomNumber();

                    DataTable gpdt = tmd_dispatchdetails.GetZJBList(sendcode).Tables[0];
                    for (int i = 0; i < gpdt.Rows.Count; i++)
                    {
                        if (gpdt.Rows[i]["N_STATUS"].ToString() == "6")//钢坯
                        {

                            bool res = trc_roll_prodcut.ExistsZZS(sendcode, gpdt.Rows[i]["C_BATCH_NO"].ToString(), gpdt.Rows[i]["C_STOVE"].ToString());
                            //检查是否重复批次
                            if (!res)
                            {

                                DataTable dtroll = trc_roll_prodcut.GetZZS("", "", sendcode, "", "", gpdt.Rows[i]["C_BATCH_NO"].ToString(), "", "", "N", gpdt.Rows[i]["N_STATUS"].ToString(), gpdt.Rows[i]["C_STOVE"].ToString(), "").Tables[0];
                                if (dtroll.Rows.Count > 0)
                                {
                                    DataTable dtCustStd = trc_roll_prodcut.GetCustStd_JH(dtroll.Rows[0]["C_STD_CODE"].ToString(), dtroll.Rows[0]["C_STL_GRD"].ToString(), dtroll.Rows[0]["C_ZYX1"].ToString(), dtroll.Rows[0]["C_ZYX2"].ToString()).Tables[0];

                                    DataTable dtJSXYH = trc_roll_prodcut.GetCustStd_JH(dtroll.Rows[0]["C_STD_CODE"].ToString(), dtroll.Rows[0]["C_STL_GRD"].ToString(), dtroll.Rows[0]["C_TECH_PROT"].ToString(), dtroll.Rows[0]["C_ZYX1"].ToString(), dtroll.Rows[0]["C_ZYX2"].ToString()).Tables[0];

                                    #region //添加参数
                                    Mod_TQC_ZZS_INFO mod = new Mod_TQC_ZZS_INFO();
                                    mod.C_FYDH = sendcode;
                                    mod.C_BATCH_NO = dtroll.Rows[0]["C_BATCH_NO"].ToString();
                                    mod.C_STOVE = dtroll.Rows[0]["C_STOVE"].ToString();
                                    mod.C_SPEC = dtroll.Rows[0]["C_SPEC"].ToString();
                                    mod.C_STL_GRD = dtroll.Rows[0]["C_STL_GRD"].ToString();
                                    mod.C_STD_CODE = dtroll.Rows[0]["C_STD_CODE"].ToString();
                                    mod.D_CKSJ = Convert.ToDateTime(dtroll.Rows[0]["D_CKSJ"].ToString());
                                    mod.N_JZ = Convert.ToDecimal(dtroll.Rows[0]["N_WGT"].ToString());
                                    mod.N_NUM = Convert.ToDecimal(dtroll.Rows[0]["QUA"].ToString());
                                    mod.C_CH = dtroll.Rows[0]["C_CH"].ToString();

                                    mod.C_ZSH = randomnumber.GetZSH();//证书号

                                    mod.C_QZR = "01";//签证人


                                    #region //生成二维码

                                    string msg = $@"http://60.6.254.51:808/Common/qualCert.aspx?fyd={mod.C_FYDH}&zsh={mod.C_ZSH}";

                                    Bitmap bt = GenByZXingNet(msg);//调用生成二维码方法

                                    mod.C_IMG = $@"D:/QRCode/{mod.C_ZSH}.jpg";//生成二维码图片命名

                                    string upPath = $@"~/QRCode/{mod.C_ZSH}.jpg";

                                    bt.Save(Server.MapPath(upPath));//保存二维码图片


                                    #endregion

                                    Mod_TS_CUSTFILE mod_TS_CUSTFILE = ts_custfile.GetCustModel(dtroll.Rows[0]["C_CGC"].ToString());

                                    mod.C_CUST_NO = mod_TS_CUSTFILE.C_NO;
                                    mod.C_CON_NO = dtroll.Rows[0]["C_CON_NO"].ToString();
                                    mod.C_CUST_NAME = dtroll.Rows[0]["C_CUST_NAME"].ToString();
                                    mod.C_SH_NAME = mod_TS_CUSTFILE.C_NAME;
                                    mod.C_MAT_NAME = dtroll.Rows[0]["C_MAT_DESC"].ToString();
                                    mod.C_STD_JH = dtCustStd.Rows[0]["C_STD_JH"].ToString();
                                    mod.C_ZLDJ = dtroll.Rows[0]["C_JUDGE_LEV_ZH"].ToString();
                                    mod.C_JH_STATE = dtroll.Rows[0]["C_JH_STATE"].ToString();
                                    mod.C_JSXYH = dtJSXYH.Rows[0]["C_JSXYH"].ToString();
                                    mod.C_XKZH = dtroll.Rows[0]["C_XKZH"].ToString();
                                    mod.C_BY1 = gpdt.Rows[i]["N_STATUS"].ToString();

                                    #endregion

                                    trc_roll_prodcut.InsertZZS(mod);
                                }
                            }
                        }
                    }

                    #endregion
                }


            }
            catch (Exception ex)
            {

                logger.Info("生成钢坯质证失败" + ex.Message);
            }
        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private Bitmap GenByZXingNet(string msg)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");//编码问题
            writer.Options.Hints.Add(
            EncodeHintType.ERROR_CORRECTION,
            ZXing.QrCode.Internal.ErrorCorrectionLevel.H

            );
            const int codeSizeInPixels = 500; //设置图片长宽
            writer.Options.Height = writer.Options.Width = codeSizeInPixels;
            writer.Options.Margin = 0;//设置边框
            ZXing.Common.BitMatrix bm = writer.Encode(msg);
            Bitmap img = writer.Write(bm);
            return img;
        }
        #endregion

        public static string GetPrint(object zsh, object batch, object std, object stlgrd, object fyd, object qzrq, object judge_lev_zh, object pdf, object stove,object type)
        {
            string result = string.Empty;

            if (!string.IsNullOrEmpty(zsh.ToString()))
            {
                string cpt = string.Empty;

                string strpdf = string.Empty;

                DataTable dtpdf = tqc_zzs_file.GetList(batch.ToString(), stlgrd.ToString(), stove.ToString(),std.ToString()).Tables[0];
                if (dtpdf.Rows.Count > 0)
                {
                    strpdf = dtpdf.Rows[0]["PDF"].ToString();
                }


                string[] dj = { "B1", "B2", "C1", "C2" };

                if (dj.Contains(judge_lev_zh.ToString()))
                {
                    cpt = "ZZS_YCDY_BHG.cpt";
                    string[] arr = { fyd.ToString(), zsh.ToString() };
                    StringBuilder strHtml = new StringBuilder();

                    strHtml.AppendFormat("<a href=\"http://60.6.254.52:8685/webroot/decision/view/report?viewlet=xgcap/" + cpt + "&FYD={0}&ZSH={1}\" target=\"_blank\" class=\"btn btn-success btn-xs\">预览<span class=\"glyphicon glyphicon - search\"></span></a>", arr);

                    result = strHtml.ToString();
                }
                else
                {

                    string printType = trc_roll_prodcut.GetZZSType(stlgrd.ToString(), std.ToString());
                    switch (printType)
                    {
                        case "1":
                            cpt = "ZZS_YCDY_YL.cpt";
                            break;
                        case "2":
                            cpt = "ZZS_YCDY_RZ_YL.cpt";
                            break;
                        case "3":
                            cpt = "ZZS_YCDY_D_YL.cpt";
                            break;
                        case "4":
                            cpt = "ZZS_YCDY_YL_RBZH.cpt";
                            break;
                        default:
                            cpt = "ZZS_YCDY_YL.cpt";
                            break;

                    }

                    string rownum = trc_roll_prodcut.GetZZSPrintRowNum(stlgrd.ToString(), std.ToString());

                    string[] arr = { fyd.ToString(), rownum, zsh.ToString() };
                    StringBuilder strHtml = new StringBuilder();

                    if (type.ToString() == "8")
                    {
                        strHtml.AppendFormat("<a href=\"http://60.6.254.52:8685/webroot/decision/view/report?viewlet=xgcap/" + cpt + "&FYD={0}&COU={1}&ZSH={2}\" target=\"_blank\" class=\"btn btn-success btn-xs\">预览<span class=\"glyphicon glyphicon - search\"></span></a>", arr);
                    }
                    else
                    {
                        cpt = "ZZS_YCDY_GP_YL.cpt";
                        strHtml.AppendFormat("<a href=\"http://60.6.254.52:8685/webroot/decision/view/report?viewlet=xgcap/" + cpt + "&FYD={0}&COU={1}&ZSH={2}\" target=\"_blank\" class=\"btn btn-success btn-xs\">预览<span class=\"glyphicon glyphicon - search\"></span></a>", arr);
                    }



                    if (!string.IsNullOrEmpty(strpdf))
                    {
                        string pdfpath = NF.Framework.StringFormat.ResolveUrl(strpdf);
                        strHtml.AppendFormat(" &nbsp;<a href='{0}' target=\"_blank\" class=\"btn btn-success btn-xs\">金相图片</a>", pdfpath);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(pdf.ToString()))
                        {
                            string pdfpath = NF.Framework.StringFormat.ResolveUrl(pdf.ToString());
                            strHtml.AppendFormat(" &nbsp;<a href='{0}' target=\"_blank\" class=\"btn btn-success btn-xs\">金相图片</a>", pdfpath);
                        }
                    }

                    result = strHtml.ToString();
                }
            }
            return result;
        }

        private void GetList()
        {

            DataTable dt = trc_roll_prodcut.GetCustZZS(txtfyd.Text, txtzsh.Text, txtbatch.Text, txtch.Text, txtcon.Text, txtckkssj.Value, txtckjssj.Value, ltlcustno.Text, droptype.SelectedValue).Tables[0];
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

        protected void btnxc_Click(object sender, EventArgs e)
        {
            GetList();
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "print")
                {
                    string zsh = e.CommandArgument.ToString();
                    Literal ltlC_FYDH = (Literal)e.Item.FindControl("ltlC_FYDH");
                    Literal ltlC_BATCH_NO = (Literal)e.Item.FindControl("ltlC_BATCH_NO");
                    Literal ltlC_ZLDJ = (Literal)e.Item.FindControl("ltlC_ZLDJ");

                    DataTable dt = trc_roll_prodcut.GetCustZZS(txtfyd.Text, zsh, ltlC_BATCH_NO.Text, "", "", "", "", ltlcustno.Text, droptype.SelectedValue).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(zsh.ToString()))
                        {


                            string[] dj = { "B1", "B2", "C1", "C2" };

                            if (dj.Contains(ltlC_ZLDJ.Text))
                            {
                                string[] arr = { ltlC_FYDH.Text, zsh.ToString() };

                                string cpt = "ZZS_YCDY_BHG.cpt";
                                StringBuilder strHtml = new StringBuilder();

                                strHtml.AppendFormat("http://60.6.254.52:8685/webroot/decision/view/report?viewlet=xgcap/" + cpt + "&FYD={0}&ZSH={1}", arr);

                                Response.Write("<script>window.open('" + strHtml.ToString() + "','_blank')</script>");
                            }
                            else
                            {

                                int print = trc_roll_prodcut.GetPrintNum(zsh);

                                string cpt = string.Empty;

                                if (droptype.SelectedValue == "8")
                                {
                                    #region // 线材打印
                                    string printType = trc_roll_prodcut.GetZZSType(dt.Rows[0]["C_STL_GRD"].ToString(), dt.Rows[0]["C_STD_CODE"].ToString());
                                    switch (printType)
                                    {
                                        case "1":
                                            if (print > 0)
                                            {
                                                cpt = "ZZS_YCDY_SY.cpt";
                                            }
                                            else
                                            {
                                                cpt = "ZZS_YCDY.cpt";
                                            }

                                            break;
                                        case "2":
                                            if (print > 0)
                                            {
                                                cpt = "ZZS_YCDY_RZ_SY.cpt";
                                            }
                                            else
                                            {
                                                cpt = "ZZS_YCDY_RZ.cpt";
                                            }
                                            break;
                                        case "3":
                                            if (print > 0)
                                            {
                                                cpt = "ZZS_YCDY_D_SY.cpt";
                                            }
                                            else
                                            {
                                                cpt = "ZZS_YCDY_D.cpt";
                                            }
                                            break;
                                        case "4":
                                            if (print > 0)
                                            {
                                                cpt = "ZZS_YCDY_SY_RBZH.cpt";
                                            }
                                            else
                                            {
                                                cpt = "ZZS_YCDY_RBZH.cpt";
                                            }
                                            break;
                                        default:
                                            if (print > 0)
                                            {
                                                cpt = "ZZS_YCDY_SY.cpt";
                                            }
                                            else
                                            {
                                                cpt = "ZZS_YCDY.cpt";
                                            }
                                            break;

                                    }

                                    //更新打印次数
                                    trc_roll_prodcut.UpdateZZSPrint(ltlC_FYDH.Text, zsh, ltlemp.Text);

                                    string rownum = trc_roll_prodcut.GetZZSPrintRowNum(dt.Rows[0]["C_STL_GRD"].ToString(), dt.Rows[0]["C_STD_CODE"].ToString());

                                    string[] arr = { ltlC_FYDH.Text, rownum, zsh.ToString() };


                                    StringBuilder strHtml = new StringBuilder();

                                    strHtml.AppendFormat("http://60.6.254.52:8685/webroot/decision/view/report?viewlet=xgcap/" + cpt + "&FYD={0}&COU={1}&ZSH={2}", arr);

                                    Response.Write("<script>window.open('" + strHtml.ToString() + "','_blank')</script>");
                                    #endregion
                                }
                                else
                                {
                                    #region //钢坯打印

                                    if (print > 0)
                                    {
                                        cpt = "ZZS_YCDY_GP_SY.cpt";
                                    }
                                    else
                                    {
                                        cpt = "ZZS_YCDY_GP.cpt";
                                    }

                                    //更新打印次数
                                    trc_roll_prodcut.UpdateZZSPrint(ltlC_FYDH.Text, zsh, ltlemp.Text);

                                    string[] arr = { ltlC_FYDH.Text, zsh.ToString() };

                                    StringBuilder strHtml = new StringBuilder();

                                    strHtml.AppendFormat("http://60.6.254.52:8685/webroot/decision/view/report?viewlet=xgcap/" + cpt + "&FYD={0}&ZSH={1}", arr);

                                    Response.Write("<script>window.open('" + strHtml.ToString() + "','_blank')</script>");

                                    #endregion
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}