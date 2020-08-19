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
using NF.Bussiness.Interface;
using Microsoft.Practices.Unity;
using NF.Web.Core;
using NF.EF.Model;
using CRM.Common;

namespace CRM.WebForms.Report
{
    public partial class ZZS_List : System.Web.UI.Page
    {
        private static Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private static Bll_TQC_ZZS_FILE tqc_zzs_file = new Bll_TQC_ZZS_FILE();

        IComService buttonService = DIFactory.GetContainer().Resolve<IComService>();

        private static DataTable dtOrderEx = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                txtckkssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtckjssj.Value = DateTime.Now.ToString("yyy-MM-dd");

                GetFun();//加载按钮权限

            }
        }

        private void GetFun()
        {
            var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (user != null)
            {
                ltlC_QZR.Text = user.Name;

                buttonService.RefreshButton("/WebForms/Report/ZZS_List.aspx", user, Session);
                List<TS_BUTTON> button = (List<TS_BUTTON>)Session["button"];

                foreach (var item in button)
                {
                    if (Page.FindControl(item.C_CODE) != null)
                    {
                        Page.FindControl(item.C_CODE).Visible = true;
                    }
                }
            }
            else
            {
                WebMsg.CheckUserLogin();
            }
        }



        //预览
        public static string GetPrint(object zsh, object batch, object std, object stlgrd, object fyd, object qzrq, object type, object stove, object judge_lev_zh, object pdf)
        {
            string result = string.Empty;

            if (!string.IsNullOrEmpty(zsh.ToString()))
            {
                string cpt = string.Empty;

                string strpdf = string.Empty;

                DataTable dtpdf = tqc_zzs_file.GetList(batch.ToString(), stlgrd.ToString(), stove.ToString(), std.ToString()).Tables[0];
                if (dtpdf.Rows.Count > 0)
                {
                    strpdf = dtpdf.Rows[0]["PDF"].ToString();
                }

                string[] dj = { "B1", "B2", "C1", "C2" };

                string url = HttpContext.Current.Request.Url.Host;

                if(url== "60.6.254.51:808")
                {
                    url = "60.6.254.52:8685";
                }
                else
                {
                    url = "192.168.2.93:8685";
                }

                if (dj.Contains(judge_lev_zh.ToString()))
                {
                    cpt = "ZZS_YCDY_BHG.cpt";
                    string[] arr = { fyd.ToString(), zsh.ToString() };
                    StringBuilder strHtml = new StringBuilder();

                    strHtml.AppendFormat("<a href=\"http://192.168.2.93:8685/webroot/decision/view/report?viewlet=xgcap/" + cpt + "&FYD={0}&ZSH={1}\" target=\"_blank\" class=\"btn btn-success btn-xs\">预览<span class=\"glyphicon glyphicon - search\"></span></a>", arr);

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
                else
                {

                    if (type.ToString() == "8")
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

                        strHtml.AppendFormat("<a href=\"http://"+url+"/webroot/decision/view/report?viewlet=xgcap/" + cpt + "&FYD={0}&COU={1}&ZSH={2}\" target=\"_blank\" class=\"btn btn-success btn-xs\">预览<span class=\"glyphicon glyphicon - search\"></span></a>", arr);

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
                    else
                    {
                        cpt = "ZZS_YCDY_GP_YL.cpt";
                        string[] arr = { fyd.ToString(), zsh.ToString() };
                        StringBuilder strHtml = new StringBuilder();

                        strHtml.AppendFormat("<a href=\"http://"+url+"/webroot/decision/view/report?viewlet=xgcap/" + cpt + "&FYD={0}&ZSH={1}\" target=\"_blank\" class=\"btn btn-success btn-xs\">预览<span class=\"glyphicon glyphicon - search\"></span></a>", arr);

                        result = strHtml.ToString();
                    }
                }



            }
            return result;
        }

        private void GetList()
        {

            string ww = cbxww.Checked == true ? "Y" : "N";

            DataTable dt = trc_roll_prodcut.GetZZS(txtch.Text, txtcust.Text, txtfyd.Text, txtstlgrd.Text, "", txtbatch.Text, txtckkssj.Value, txtckjssj.Value, ww, droptype.SelectedValue, "", dropprint.SelectedValue == "全部" ? "" : dropprint.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();

                dtOrderEx = dt;
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

        //生成远程质证书
        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = true;
                string ww = cbxww.Checked == true ? "Y" : "N";

                List<Mod_TQC_ZZS_INFO> list = new List<Mod_TQC_ZZS_INFO>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxID = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxID");
                    if (cbxID.Checked)
                    {
                        Bll_RandomNumber randomnumber = new Bll_RandomNumber();

                        #region //控件
                        Literal ltlC_FYDH = (Literal)rptList.Items[i].FindControl("ltlC_FYDH");
                        Literal ltlC_BATCH_NO = (Literal)rptList.Items[i].FindControl("ltlC_BATCH_NO");
                        Literal ltlC_JUDGE_LEV_ZH = (Literal)rptList.Items[i].FindControl("ltlC_JUDGE_LEV_ZH");
                        Literal ltlC_TYPE = (Literal)rptList.Items[i].FindControl("ltlC_TYPE");//8线材/6钢坯
                        Literal ltlC_STOVE = (Literal)rptList.Items[i].FindControl("ltlC_STOVE");
                        #endregion

                        string[] dj = { "A", "AA", "AAA", "CK", "A1", "合格品", "B1", "B2", "C1", "C2" };
                        if (dj.Contains(ltlC_JUDGE_LEV_ZH.Text))
                        {
                            bool res = ltlC_TYPE.Text == "8" ? trc_roll_prodcut.ExistsZZS(ltlC_FYDH.Text, ltlC_BATCH_NO.Text) : trc_roll_prodcut.ExistsZZS(ltlC_FYDH.Text, ltlC_BATCH_NO.Text, ltlC_STOVE.Text);
                            //检查是否重复批次
                            if (!res)
                            {
                                DataTable dt = trc_roll_prodcut.GetZZS("", "", ltlC_FYDH.Text, "", "", ltlC_BATCH_NO.Text, "", "", ww, ltlC_TYPE.Text, ltlC_STOVE.Text, "").Tables[0];
                                if (dt.Rows.Count > 0)
                                {

                                    DataTable dtCustStd = trc_roll_prodcut.GetCustStd_JH(dt.Rows[0]["C_STD_CODE"].ToString(), dt.Rows[0]["C_STL_GRD"].ToString(), dt.Rows[0]["C_ZYX1"].ToString(), dt.Rows[0]["C_ZYX2"].ToString()).Tables[0];

                                    DataTable dtJSXYH = trc_roll_prodcut.GetCustStd_JH(dt.Rows[0]["C_STD_CODE"].ToString(), dt.Rows[0]["C_STL_GRD"].ToString(), dt.Rows[0]["C_TECH_PROT"].ToString(), dt.Rows[0]["C_ZYX1"].ToString(), dt.Rows[0]["C_ZYX2"].ToString()).Tables[0];

                                    #region //添加参数
                                    Mod_TQC_ZZS_INFO mod = new Mod_TQC_ZZS_INFO();
                                    mod.C_FYDH = ltlC_FYDH.Text;
                                    mod.C_BATCH_NO = ltlC_BATCH_NO.Text;
                                    mod.C_STOVE = dt.Rows[0]["C_STOVE"].ToString();
                                    mod.C_SPEC = dt.Rows[0]["C_SPEC"].ToString();
                                    mod.C_STL_GRD = dt.Rows[0]["C_STL_GRD"].ToString();
                                    mod.C_STD_CODE = dt.Rows[0]["C_STD_CODE"].ToString();
                                    mod.D_CKSJ = Convert.ToDateTime(dt.Rows[0]["D_CKSJ"].ToString());
                                    mod.N_JZ = Convert.ToDecimal(dt.Rows[0]["N_WGT"].ToString());
                                    mod.N_NUM = Convert.ToDecimal(dt.Rows[0]["QUA"].ToString());
                                    mod.C_CH = dt.Rows[0]["C_CH"].ToString();

                                    mod.C_ZSH = randomnumber.GetZSH();//证书号

                                    mod.C_QZR = ltlC_QZR.Text;//签证人


                                    #region //生成二维码

                                    string msg = $@"http://60.6.254.51:808/Common/qualCert.aspx?fyd={mod.C_FYDH}&zsh={mod.C_ZSH}";

                                    Bitmap bt = GenByZXingNet(msg);//调用生成二维码方法

                                    mod.C_IMG = $@"D:/QRCode/{mod.C_ZSH}.jpg";//生成二维码图片命名

                                    string upPath = $@"~/QRCode/{mod.C_ZSH}.jpg";

                                    bt.Save(Server.MapPath(upPath));//保存二维码图片

                                    #endregion

                                    Mod_TS_CUSTFILE mod_TS_CUSTFILE = ts_custfile.GetCustModel(dt.Rows[0]["C_CGC"].ToString());

                                    mod.C_CUST_NO = mod_TS_CUSTFILE.C_NO;
                                    mod.C_CON_NO = dt.Rows[0]["C_CON_NO"].ToString();
                                    mod.C_CUST_NAME = dt.Rows[0]["C_CUST_NAME"].ToString();
                                    mod.C_SH_NAME = mod_TS_CUSTFILE.C_NAME;
                                    mod.C_MAT_NAME = dt.Rows[0]["C_MAT_DESC"].ToString();
                                    mod.C_STD_JH = dtCustStd.Rows[0]["C_STD_JH"].ToString();
                                    mod.C_ZLDJ = dt.Rows[0]["C_JUDGE_LEV_ZH"].ToString();
                                    mod.C_JH_STATE = dt.Rows[0]["C_JH_STATE"].ToString();
                                    mod.C_JSXYH = dtJSXYH.Rows[0]["C_JSXYH"].ToString();
                                    mod.C_XKZH = dt.Rows[0]["C_XKZH"].ToString();
                                    mod.C_BY1 = ltlC_TYPE.Text;

                                    #endregion

                                    result = trc_roll_prodcut.InsertZZS(mod);
                                }
                            }

                        }
                    }
                }
                if (result)
                {
                    GetList();
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
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

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {

                //打印

                if (e.CommandName == "print")
                {
                    string zsh = e.CommandArgument.ToString();
                    Literal ltlC_FYDH = (Literal)e.Item.FindControl("ltlC_FYDH");
                    Literal ltlC_BATCH_NO = (Literal)e.Item.FindControl("ltlC_BATCH_NO");
                    Literal ltlC_TYPE = (Literal)e.Item.FindControl("ltlC_TYPE");
                    Literal ltlC_STOVE = (Literal)e.Item.FindControl("ltlC_STOVE");
                    Literal ltlC_JUDGE_LEV_ZH = (Literal)e.Item.FindControl("ltlC_JUDGE_LEV_ZH");

                    DataTable dt = trc_roll_prodcut.GetCustZZS(txtfyd.Text, zsh, "", "", "", "", "", "", ltlC_TYPE.Text).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(zsh.ToString()))
                        {

                            string[] dj = { "B1", "B2", "C1", "C2" };

                            if (dj.Contains(ltlC_JUDGE_LEV_ZH.Text))
                            {
                                string[] arr = { ltlC_FYDH.Text, zsh.ToString() };

                                string cpt = "ZZS_YCDY_BHG.cpt";
                                StringBuilder strHtml = new StringBuilder();

                                strHtml.AppendFormat("http://192.168.2.93:8685/webroot/decision/view/report?viewlet=xgcap/" + cpt + "&FYD={0}&ZSH={1}", arr);

                                Response.Write("<script>window.open('" + strHtml.ToString() + "','_blank')</script>");
                            }
                            else
                            {
                                int print = trc_roll_prodcut.GetPrintNum(zsh);

                                string cpt = string.Empty;

                                if (ltlC_TYPE.Text == "8")
                                {
                                    #region //线材打印
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
                                    trc_roll_prodcut.UpdateZZSPrint(ltlC_FYDH.Text, zsh, ltlC_QZR.Text);

                                    string rownum = trc_roll_prodcut.GetZZSPrintRowNum(dt.Rows[0]["C_STL_GRD"].ToString(), dt.Rows[0]["C_STD_CODE"].ToString());

                                    string[] arr = { ltlC_FYDH.Text, rownum, zsh.ToString() };


                                    StringBuilder strHtml = new StringBuilder();

                                    strHtml.AppendFormat("http://192.168.2.93:8685/webroot/decision/view/report?viewlet=xgcap/" + cpt + "&FYD={0}&COU={1}&ZSH={2}", arr);

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
                                    trc_roll_prodcut.UpdateZZSPrint(ltlC_FYDH.Text, zsh, ltlC_QZR.Text);

                                    string[] arr = { ltlC_FYDH.Text, zsh.ToString() };

                                    StringBuilder strHtml = new StringBuilder();

                                    strHtml.AppendFormat("http://192.168.2.93:8685/webroot/decision/view/report?viewlet=xgcap/" + cpt + "&FYD={0}&ZSH={1}", arr);

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

        //初始化打印
        protected void btncsh_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox cbxSelect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxID");
                if (cbxSelect.Checked)
                {
                    Literal ltlzsh = (Literal)rptList.Items[i].FindControl("ltlzsh");
                    Literal ltlC_FYDH = (Literal)rptList.Items[i].FindControl("ltlC_FYDH");
                    //初始化打印
                    if (trc_roll_prodcut.UpdateZZSPrint(ltlC_FYDH.Text, ltlzsh.Text))
                    {
                        WebMsg.MessageBox("设置成功！");
                    }
                }
            }

        }

        protected void imgbtnJz_Click(object sender, ImageClickEventArgs e)
        {
            GetList();
        }

        //导出
        protected void btnOut_Click(object sender, EventArgs e)
        {
            if (dtOrderEx.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("C_ZSH", "证书号");
                dic.Add("C_FYDH", "发运单号");
                dic.Add("C_CH", "车牌号");
                dic.Add("C_MAT_DESC", "物料名称");
                dic.Add("C_BATCH_NO", "批次号");
                dic.Add("C_STD_CODE", "执行标准");
                dic.Add("C_STL_GRD", "钢种");
                dic.Add("C_JUDGE_LEV_ZH", "质量等级");
                dic.Add("C_SPEC", "规格");
                dic.Add("N_WGT", "*重量");
                dic.Add("QUA", "*件数");
                dic.Add("D_CKSJ", "发货时间");
                dic.Add("C_CUST_NAME", "客户");
                dic.Add("ZDR", "制单人");
                dic.Add("C_QZR", "审批人");
                dic.Add("D_QZRQ", "审批时间");
                dic.Add("N_PRINT_NUM", "打印次数");
                dic.Add("C_PRINT_EMP", "最后打印人");
                dic.Add("D_PRINT_DT", "最后打印时间");

                ExportHelper.BudgetExport(dtOrderEx, dic, "质证书管理", Response);
                dtOrderEx = null;
            }
        }
    }
}