using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NF.NC.Interface
{
    public abstract class NCSendXml
    {


        /// <summary>
        /// 发送NC
        /// </summary>
        /// <param name="xmlDoc">XML文件</param>
        public static List<string> SendXML(XmlDocument xmlDoc)
        {
            HttpWebRequest req = null;
            try
            {
                #region //发送

                //设置要POST到的页面URL，这里中文参数或者有特殊符号的，要进行编码.
               
                string url = "http://192.168.2.231:80/service/XChangeServlet?account=001&receiver=101";

                //创建一个HttpWebRequest对象
                req = (HttpWebRequest)HttpWebRequest.Create(url);

                if (req == null)
                {
                    throw new Exception("连接NC服务器失败");
                }
                //设置它提交数据的方式post
                req.Method = "POST";
                //设置 Content-type HTTP 标头的值
                req.ContentType = "text/xml";// "application/x-www-form-urlencoded;charset=gb2312";
                req.Timeout = 500000; // 500秒

                using (StreamWriter requestWriter = new StreamWriter(req.GetRequestStream()))
                {

                    //定义一个StreamReader对象，用于读取xml文件的内容
                    //StreamReader reader = new StreamReader(strXML);
                    //string ret = reader.ReadToEnd();
                    //reader.Close();
                    
                    requestWriter.WriteLine(xmlDoc.InnerXml);//将读取的内容写入到RequestStream中。
                }
                #endregion

                #region 接收

                //Get answer
                System.Net.HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                Stream rcvStream = resp.GetResponseStream();
                byte[] respBytes = new byte[1024];
                int byteCount;
                MemoryStream ms = new MemoryStream();

                //  StringBuilder builder = new StringBuilder();
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
                string content = XmlGetElement(doc, "content");

                resultCont = resultCont.Replace("\r\n", "");
                resultCont = resultCont.Replace("\t", "");
                resp.Close();
                rcvStream.Close();
                #endregion

                List<string> p = new List<string>();
                p.Add(tok);
                p.Add(resultCont);
                p.Add(content);
                return p;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 发送物流
        /// </summary>
        /// <param name="xmlDoc">XML文件</param>
        public static string  WLSendXML(XmlDocument xmlDoc)
        {
            HttpWebRequest req = null;
            try
            {
                byte[] data = System.Text.Encoding.GetEncoding("GB2312").GetBytes(xmlDoc.InnerXml);
                #region //发送

                //设置要POST到的页面URL，这里中文参数或者有特殊符号的，要进行编码.
                string url = "http://192.168.2.42:6080/Logistical/unauth/interface/download";

                //创建一个HttpWebRequest对象
                req = (HttpWebRequest)HttpWebRequest.Create(url);

                if (req == null)
                {
                    throw new Exception("连接WL服务器失败");
                }
                //设置它提交数据的方式post
                req.Method = "POST";
                //设置 Content-type HTTP 标头的值
                req.ContentType = "text/xml;charset=GB2312";// "application/x-www-form-urlencoded;charset=gb2312";
                req.Timeout = 500000; // 500秒
                req.ContentLength = data.Length;
                Stream stream = req.GetRequestStream();
                // 发送数据 
                stream.Write(data, 0, data.Length);
                stream.Close();
                //using (StreamWriter requestWriter = new StreamWriter(req.GetRequestStream()))
                //{

                //    //定义一个StreamReader对象，用于读取xml文件的内容
                //    //StreamReader reader = new StreamReader(strXML);
                //    //string ret = reader.ReadToEnd();
                //    //reader.Close();

                //    requestWriter.Write(xmlDoc.InnerXml);//将读取的内容写入到RequestStream中。
                //}
                #endregion

                #region 接收

                //Get answer
                System.Net.HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                Stream rcvStream = resp.GetResponseStream();
                byte[] respBytes = new byte[1024];
                int byteCount;
                MemoryStream ms = new MemoryStream();

                //  StringBuilder builder = new StringBuilder();
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
                rcvStream.Close();
                #endregion

                return xmlRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 销售合同发送NC---测试地址
        /// </summary>
        /// <param name="xmlDoc">XML文件</param>
        public static List<string> SendXML_CON(XmlDocument xmlDoc)
        {
            HttpWebRequest req = null;
            try
            {
                #region //发送

                //设置要POST到的页面URL，这里中文参数或者有特殊符号的，要进行编码.

                string url = "http://192.168.2.207:80/service/XChangeServlet?account=001&receiver=101";

                //创建一个HttpWebRequest对象
                req = (HttpWebRequest)HttpWebRequest.Create(url);

                if (req == null)
                {
                    throw new Exception("连接NC服务器失败");
                }
                //设置它提交数据的方式post
                req.Method = "POST";
                //设置 Content-type HTTP 标头的值
                req.ContentType = "text/xml";// "application/x-www-form-urlencoded;charset=gb2312";
                req.Timeout = 500000; // 500秒

                using (StreamWriter requestWriter = new StreamWriter(req.GetRequestStream()))
                {

                    //定义一个StreamReader对象，用于读取xml文件的内容
                    //StreamReader reader = new StreamReader(strXML);
                    //string ret = reader.ReadToEnd();
                    //reader.Close();

                    requestWriter.WriteLine(xmlDoc.InnerXml);//将读取的内容写入到RequestStream中。
                }
                #endregion

                #region 接收

                //Get answer
                System.Net.HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                Stream rcvStream = resp.GetResponseStream();
                byte[] respBytes = new byte[1024];
                int byteCount;
                MemoryStream ms = new MemoryStream();

                //  StringBuilder builder = new StringBuilder();
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
                string content = XmlGetElement(doc, "content");

                resultCont = resultCont.Replace("\r\n", "");
                resultCont = resultCont.Replace("\t", "");
                resp.Close();
                rcvStream.Close();
                #endregion

                List<string> p = new List<string>();
                p.Add(tok);
                p.Add(resultCont);
                p.Add(content);
                return p;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private static string XmlGetElement(XmlDocument doc, string code)
        {
            XmlNode root = doc.SelectSingleNode("//sendresult");
            return root.SelectSingleNode(code).InnerText;
        }

       
    }
}
