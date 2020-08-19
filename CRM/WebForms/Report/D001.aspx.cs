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
    public partial class D001 : System.Web.UI.Page
    {
        private Bll_TMD_DISPATCHDETAILS tmd_dispatchdetails = new Bll_TMD_DISPATCHDETAILS();
        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();

        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private static Bll_TQC_ZZS_FILE tqc_zzs_file = new Bll_TQC_ZZS_FILE();

        IComService buttonService = DIFactory.GetContainer().Resolve<IComService>();

        private static DataTable dtOrderEx = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (user == null)
                {
                    WebMsg.CheckUserLogin();
                }

                txtckkssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtckjssj.Value = DateTime.Now.ToString("yyy-MM-dd");

                //GetFun();//加载按钮权限

                //自动生成质证书
                GetZZS();

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

        private void GetFun()
        {
            var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (user != null)
            {
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



        private void GetList()
        {

            DataTable dt = tmd_dispatchdetails.GetZJBList(txtfyd.Text, txtch.Text, txtstlgrd.Text, txtbatch.Text, txtprintemp.Text, txtckkssj.Value, txtckjssj.Value, dropprint.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();


                ltlsumwgt.Text = dt.Compute("sum(N_JZ)", "true").ToString();

                ltlsumqua.Text = dt.Compute("sum(N_NUM)", "true").ToString();

                List<string> ls = new List<string>();
                List<string> lsFYD = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ls.Add(dt.Rows[i]["C_LIC_PLA_NO"].ToString());
                    lsFYD.Add(dt.Rows[i]["C_DISPATCH_ID"].ToString());
                }
                ltlsumch.Text = ls.Distinct().Count().ToString();
                ltlsumfyd.Text = lsFYD.Distinct().Count().ToString();

                dtOrderEx = dt;
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();

                ltlsumfyd.Text = "";
                ltlsumch.Text = "";
                ltlsumqua.Text = "";
                ltlsumwgt.Text = "";

            }
        }

        protected void btnxc_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtch.Text) || !string.IsNullOrEmpty(txtfyd.Text))
            {
                GetList();
            }
            else
            {
                WebMsg.MessageBox("请输入车牌号或发运单号查询");
            }

        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {

                var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

                if (user == null)
                {
                    WebMsg.CheckUserLogin();
                }
                else
                {
                    if (!string.IsNullOrEmpty(user.Name))
                    {
                        //打印

                        if (e.CommandName == "print")
                        {
                            string fyd = e.CommandArgument.ToString();

                            string cpt = $@"http://192.168.2.96:8080/WebReport/ReportServer?reportlet=ZZS_FYMX.cpt&fyd={fyd}";

                            tmd_dispatchdetails.UpdateZJB(fyd, user?.Name,"1");

                            Response.Write("<script>window.open('" + cpt + "','_blank')</script>");
                        }
                        if (e.CommandName == "print2")
                        {
                            string fyd = e.CommandArgument.ToString();

                            string cpt = $@"http://192.168.2.96:8080/WebReport/ReportServer?reportlet=ZZS_BXGFYMX.cpt&fyd={fyd}";

                            tmd_dispatchdetails.UpdateZJB(fyd, user?.Name,"2");

                            Response.Write("<script>window.open('" + cpt + "','_blank')</script>");
                        }
                        GetList();
                    }
                    else
                    {
                        WebMsg.CheckUserLogin();
                    }
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }
        }

        //导出
        protected void btnOut_Click(object sender, EventArgs e)
        {
            if (dtOrderEx.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("C_DISPATCH_ID", "发运单号");
                dic.Add("C_LIC_PLA_NO", "车牌号");
                dic.Add("C_BATCH_NO", "批次号");
                dic.Add("C_STOVE", "炉号");
                dic.Add("N_JZ", "重量");
                dic.Add("N_NUM", "件数");
                dic.Add("C_STL_GRD", "钢种");
                dic.Add("C_SPEC", "规格");
                dic.Add("C_ZLDJ", "质量等级");
                dic.Add("C_MAT_NAME", "物料名称");
                dic.Add("C_STD_CODE", "执行标准");
                dic.Add("D_CKSJ", "发货时间");
                dic.Add("C_NAME", "制单人");
                dic.Add("N_PRINT_NUM", "打印次数");
                dic.Add("C_PRINTEMP", "最后打印人");
                dic.Add("D_PRINTTIME", "最后打印时间");


                ExportHelper.BudgetExport(dtOrderEx, dic, "销售出库单", Response);
                dtOrderEx = null;
            }
        }
    }
}