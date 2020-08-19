using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using NF.MODEL;
using NF.BLL;
using NF.Framework;
using System.Text;
using System.Data;

namespace CRM.WebForms.Sale_App
{
    public partial class webpost : System.Web.UI.Page
    {

        Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        Bll_TMO_CONDETAILS tmo_condetails = new Bll_TMO_CONDETAILS();
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void Button2_Click(object sender, EventArgs e)
        {
            //XML文件路径

            string xmlFileName = Server.MapPath("../../FileInterface/wlsjDMC1904170104ss15.xml");

            XmlDocument xmlDoc = new XmlDocument();
            //创建类型声明节点  
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "no");
            xmlDoc.AppendChild(node);
            XmlElement root = xmlDoc.CreateElement("ufinterface");
            xmlDoc.AppendChild(root);

            XmlNode head = xmlDoc.CreateNode(XmlNodeType.Element, "sendresult", null);
            CreateNode(xmlDoc, head, "resultcode", "1");
            CreateNode(xmlDoc, head, "resultdescription", "1");
            CreateNode(xmlDoc, head, "content", "重量");
            root.AppendChild(head);

            //string xmlFileName = Server.MapPath("../../FileInterface/sendResult.xml");
            xmlDoc.Save(xmlFileName);

            HttpWebRequest req = null;
            try
            {
                //设置要POST到的页面URL，这里中文参数或者有特殊符号的，要进行编码.
                string url = "http://localhost:49839/FileInterface/receive.aspx";

                //创建一个HttpWebRequest对象
                req = (HttpWebRequest)HttpWebRequest.Create(url);

                //设置它提交数据的方式post
                req.Method = "POST";

                //设置 Content-type HTTP 标头的值
                req.ContentType = "text/xml";// "application/x-www-form-urlencoded;charset=gb2312";

                using (StreamWriter requestWriter = new StreamWriter(req.GetRequestStream()))
                {

                    //定义一个StreamReader对象，用于读取xml文件的内容
                    StreamReader reader = new StreamReader(xmlFileName);
                    string ret = reader.ReadToEnd();
                    //SendXML(ret);
                    reader.Close();
                   
                   requestWriter.WriteLine(ret);//将读取的内容写入到RequestStream中。
                }

                #region //获取

                //Get answer
                System.Net.HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                Stream rcvStream = resp.GetResponseStream();
                byte[] respBytes = new byte[1024];
                int byteCount;
                MemoryStream ms = new MemoryStream();

                do
                {
                    byteCount = rcvStream.Read(respBytes, 0, 1024);
                    if (byteCount > 0)
                    {
                        ms.Write(respBytes, 0, byteCount);
                    }
                } while (byteCount > 0);

                System.Text.Encoding encoding = Encoding.UTF8;// Encoding.GetEncoding("gb2312");
                string xmlRet = encoding.GetString(ms.ToArray());
                // builder.Append(inputString);

                XmlDocument doc = new XmlDocument();
                //  string xmlRet = builder.ToString();
                int iPos = xmlRet.IndexOf(@"</ufinterface>");
                xmlRet = xmlRet.Substring(0, iPos + ((string)@"</ufinterface>").Length);
                doc.LoadXml(xmlRet);

                string tok = XmlGetElement(doc, "resultcode");
                string resultCont = XmlGetElement(doc, "resultdescription");
                //string content = XmlGetElement(doc, "content");

                resultCont = resultCont.Replace("\r\n", "");
                resultCont = resultCont.Replace("\t", "");
                resp.Close();
                rcvStream.Close();
                //WebMsg.MessageBox(content);
                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SendXML(string strXML)
        {
            byte[] data = Encoding.GetEncoding("gb2312").GetBytes(strXML);
            //string strURI = "http://192.168.2.230:80/service/XChangeServlet?account=001&receiver=101"; //NCServer;
            string strURI = "http://192.168.1.103:8080/FileInterface/receive.aspx"; //本地服务
            HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(strURI);
            if (request == null)
            {
                throw new Exception("连接NC服务器失败");
            }

            request.Method = "POST";
            request.ContentType = "text/xml; charset=gb2312";
            request.ContentLength = data.Length;
            request.Timeout = 500000; // 500秒

            using (StreamWriter requestWriter = new StreamWriter(request.GetRequestStream()))
            {

                //定义一个StreamReader对象，用于读取xml文件的内容
                StreamReader reader = new StreamReader(strXML);
                string ret = reader.ReadToEnd();
                reader.Close();

                requestWriter.WriteLine(ret);//将读取的内容写入到RequestStream中。
            }

            //Get answer
            System.Net.HttpWebResponse resp = (HttpWebResponse)request.GetResponse();

            Stream rcvStream = resp.GetResponseStream();
            byte[] respBytes = new byte[1024];
            int byteCount;
            MemoryStream ms = new MemoryStream();


            do
            {
                byteCount = rcvStream.Read(respBytes, 0, 1024);
                if (byteCount > 0)
                {
                    ms.Write(respBytes, 0, byteCount);
                }
            } while (byteCount > 0);

            System.Text.Encoding encoding = Encoding.UTF8;// Encoding.GetEncoding("gb2312");
            string xmlRet = encoding.GetString(ms.ToArray());
            // builder.Append(inputString);

            XmlDocument doc = new XmlDocument();
            //  string xmlRet = builder.ToString();
            int iPos = xmlRet.IndexOf(@"</ufinterface>");
            xmlRet = xmlRet.Substring(0, iPos + ((string)@"</ufinterface>").Length);
            doc.LoadXml(xmlRet);

            string tok = XmlGetElement(doc, "resultcode");
            string resultCont = XmlGetElement(doc, "resultdescription");
            //string content = XmlGetElement(doc, "content");

            resultCont = resultCont.Replace("\r\n", "");
            resultCont = resultCont.Replace("\t", "");
            resp.Close();
            rcvStream.Close();
        }

        private string XmlGetElement(XmlDocument doc, string code)
        {

            XmlNode root = doc.SelectSingleNode("//sendresult");

            return root.SelectSingleNode(code).InnerText;
        }

    }
}