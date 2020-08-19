using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using NF.BLL;
using NF.MODEL;
using NF.NC.Interface;
using ZXing;
using System.Drawing;
using NF.Framework;

namespace CRM.FileInterface
{
    public partial class receive : System.Web.UI.Page
    {
        private Bll_TMB_INTERFACE_LOG tmb_interface_log = new Bll_TMB_INTERFACE_LOG();
        private Bll_TMD_DISPATCHDETAILS tmd_dispatchdetails = new Bll_TMD_DISPATCHDETAILS();
        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();
        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();

        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private static Bll_TQC_ZZS_FILE tqc_zzs_file = new Bll_TQC_ZZS_FILE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.RequestType == "POST")
            {
                //接收并读取POST过来的XML文件流
                StreamReader reader = new StreamReader(Request.InputStream);

                String xmlData = reader.ReadToEnd();
                List<ApiDispDto> apiDispList = new List<ApiDispDto>();
                #region //读取WL实绩XML
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlData);

                string sendcode = string.Empty;//发运单号
                XmlNodeList headlist = xmlDoc.SelectNodes("//bill/bill_head");
                foreach (XmlNode item in headlist)
                {
                    sendcode = item["vdelivbillcode"].InnerText;
                }

                XmlNodeList ndlist = xmlDoc.SelectNodes("//bill/bill_body"); //xmlDoc.GetElementsByTagName("bill_body");
                foreach (XmlNode item1 in ndlist)
                {
                    XmlNodeList ndlist2 = item1.ChildNodes;
                    foreach (XmlNode item2 in ndlist2)
                    {
                        if (item2["nnetwgt"].InnerText != "")
                        {
                            ApiDispDto mod = new ApiDispDto();
                            mod.sendcode = sendcode;//发运单
                            mod.pkid = item2["vfree10"].InnerText;//发运单表体主键
                            mod.matcode = item2["vinvcode"].InnerText;//存货编码
                            mod.mzdate = item2["vuserdef1"].InnerText;//毛重日期
                            mod.mztime = item2["vuserdef6"].InnerText;//毛重时间
                            mod.mwgt = item2["vuserdef2"].InnerText;//毛重
                            mod.pzdate = item2["vuserdef3"].InnerText;//皮重日期
                            mod.pztime = item2["vuserdef7"].InnerText.Trim();//皮重时间
                            mod.pwgt = item2["vuserdef4"].InnerText;//皮重
                            mod.jwgt = item2["nnetwgt"].InnerText;//净重
                            apiDispList.Add(mod);
                        }
                    }
                }

                string ss = "ss" + DateTime.Now.Second.ToString();
                string filePath2 = "~/FileInterface/download/wlsj" + sendcode + ss + ".xml";
                string xmlfile2 = Server.MapPath(filePath2);
                xmlDoc.Save(xmlfile2);
                #endregion

                //更新物流实绩到发运单明细并钢种库存与发运单NC中间表

                if (apiDispList.Count > 0)
                {
                    #region //检测发运单物流实绩是否导入NC
                    Mod_TMD_DISPATCH modDisp = tmd_dispatch.GetModel(sendcode);
                    if (modDisp != null)
                    {
                        if (modDisp.C_STATUS == "9")//钢坯实绩已导入NC
                        {
                            BackMsg("N", "异常信息:钢坯实绩已导入NC", sendcode);
                        }
                        else
                        {
                            int result = tmd_dispatchdetails.WL_SJ(apiDispList);

                            #region //钢坯
                            bool res = true;

                            DataTable dt = tmd_dispatchdetails.GetZJBList(sendcode).Tables[0];
                            if (dt.Rows.Count > 0)//有实绩
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (string.IsNullOrEmpty(dt.Rows[i]["N_JZ"].ToString()))
                                    {
                                        res = false;
                                    }
                                }
                                if (res)
                                {
                              
                                    //发运实绩净重，导入NC
                                    ApiWL_SJ apiwl_sj = new ApiWL_SJ();
                                    string filename = "wlsj_nc" + sendcode;
                                    string filePath = "~/FileInterface/download/" + filename + ".xml";
                                    string xmlfile = Server.MapPath(filePath);
                                    apiwl_sj.SendXml_DM(xmlfile, sendcode, apiDispList);
                                    BackMsg("Y", "接收成功", sendcode);
                                }
                                else
                                {
                                    BackMsg("Y", "接收成功", sendcode);
                                }
                            }
                            else
                            {
                                BackMsg("Y", "接收成功", sendcode);
                            }
                            #endregion

                            #region //副产品
                            //if(modDisp.C_EXTEND5=="6")//钢坯
                            //{

                            //}
                            //else
                            //{
                            //    if(tmd_dispatchdetails.WL_SJ_F(apiDispList))
                            //    {
                            //        #region //辅产品 发运实绩净重，导入NC

                            //        ApiWL_SJ_F apiwl_sj_f = new ApiWL_SJ_F();
                            //        string filename = "wlsj_nc" + sendcode;
                            //        string filePath = "~/FileInterface/download/" + filename + ".xml";
                            //        string xmlfile = Server.MapPath(filePath);
                            //        apiwl_sj_f.SendXml_DM(xmlfile, sendcode);
                            //        #endregion

                            //        BackMsg("Y", "接收成功", sendcode);
                            //    }
                            //}
                            #endregion

                        }
                    }
                    else
                    {
                        BackMsg("N", "当前发运单系统不存在", sendcode);
                    }
                    #endregion
                }
                else
                {
                    BackMsg("N", "异常信息:没有重量", sendcode);
                }

            }
        }

        private void GetZZS(string sendcode)
        {
            var logger = Logger.CreateLogger(this.GetType());

            try
            {
               
                logger.Info("生成钢坯质证：" + sendcode);

                #region//钢坯质证书

                Bll_RandomNumber randomnumber = new Bll_RandomNumber();

                DataTable gpdt = tmd_dispatchdetails.GetZJBList(sendcode).Tables[0];
                for (int i = 0; i < gpdt.Rows.Count; i++)
                {
                    logger.Info("开始生成钢坯质证书1" + sendcode);

                    if (gpdt.Rows[i]["N_STATUS"].ToString() == "6")//钢坯
                    {
                        logger.Info("开始生成钢坯质证书2" + sendcode);

                        DataTable dtroll = trc_roll_prodcut.GetZZS("", "", sendcode, "", "", gpdt.Rows[i]["C_BATCH_NO"].ToString(), "", "", "N", gpdt.Rows[i]["N_STATUS"].ToString(), gpdt.Rows[i]["C_STOVE"].ToString(), "").Tables[0];
                        if (dtroll.Rows.Count > 0)
                        {
                            DataTable dtCustStd = trc_roll_prodcut.GetCustStd_JH(dtroll.Rows[0]["C_STD_CODE"].ToString(), dtroll.Rows[0]["C_STL_GRD"].ToString(), dtroll.Rows[0]["C_ZYX1"].ToString(), dtroll.Rows[0]["C_ZYX2"].ToString()).Tables[0];

                            DataTable dtJSXYH = trc_roll_prodcut.GetCustStd_JH(dtroll.Rows[0]["C_STD_CODE"].ToString(), dtroll.Rows[0]["C_STL_GRD"].ToString(), dtroll.Rows[0]["C_TECH_PROT"].ToString(), dtroll.Rows[0]["C_ZYX1"].ToString(), dtroll.Rows[0]["C_ZYX2"].ToString()).Tables[0];

                            #region //添加参数
                            Mod_TQC_ZZS_INFO mod = new Mod_TQC_ZZS_INFO();
                            mod.C_FYDH = sendcode;
                            mod.C_BATCH_NO = dtroll.Rows[i]["C_BATCH_NO"].ToString();
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

                            string upPath = $@"http://192.168.2.91:808/QRCode/{mod.C_ZSH}.jpg";

                            bt.Save(upPath);//保存二维码图片

                            logger.Info("生成钢坯质证书二维码" + sendcode);

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

                            if(trc_roll_prodcut.InsertZZS(mod))
                            {
                                logger.Info("生成钢坯质证成功" + sendcode);
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {

                logger.Info("生成钢坯质证失败" +ex.Message+ sendcode);
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


        private void BackMsg(string res, string msg, string sendCode)
        {
            #region //反馈结果
            XmlDocument doc = new XmlDocument();
            //创建类型声明节点
            XmlNode node = doc.CreateXmlDeclaration("1.0", "UTF-8", "no");
            doc.AppendChild(node);
            XmlElement root = doc.CreateElement("ufinterface");
            #region//给节点属性赋值
            root.SetAttribute("successful", res);
            #endregion
            doc.AppendChild(root);
            XmlNode head = doc.CreateNode(XmlNodeType.Element, "sendresult", null);
            CreateNode(doc, head, "resultcode", res == "Y" ? "1" : "-1");
            CreateNode(doc, head, "resultdescription", msg);
            root.AppendChild(head);

            if (res == "N")
            {
                string xmlname = "Msg" + sendCode + RTime() + ".xml";
                string xmlFileName = Server.MapPath("/FileInterface/download/" + xmlname);
                doc.Save(xmlFileName);
            }
            #endregion


            Response.Write(doc.InnerXml);
            Response.End();
        }

        /// <summary>    
        /// 创建节点    
        /// </summary>    
        /// <param name="xmldoc"></param>  xml文档  
        /// <param name="parentnode"></param>父节点    
        /// <param name="name"></param>  节点名  
        /// <param name="value"></param>  节点值  
        ///   
        private void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value)
        {
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
            node.InnerText = value;
            parentNode.AppendChild(node);
        }

        private string RTime()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int s = DateTime.Now.Second;
            int m = DateTime.Now.Minute;

            string dt = year.ToString() + month.ToString() + day.ToString() + s.ToString() + m.ToString();
            return dt;
        }
    }
}