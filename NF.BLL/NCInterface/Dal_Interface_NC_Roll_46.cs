using MODEL;
using NF.BLL.NCInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace DAL
{
    public partial class Dal_Interface_NC_Roll_46
    {
        //private readonly Dal_TB_NCIF_LOG dal_TB_NCIF_LOG = new Dal_TB_NCIF_LOG();

        public List<string> SendXml_ROLL_46(string c_id, string cwarehouseid, string xmlFileName, List<NcRoll46> nc, string path)
        {
            try
            {

                string url = path + $"\\NCXML\\{c_id}";
                if (!Directory.Exists(url))
                {
                    Directory.CreateDirectory(url);
                }

                //Mod_TMO_CON modCon = tmo_con.GetModel(cwarehouseid);
                XmlDocument xmlDoc = new XmlDocument();
                //创建类型声明节点  
                XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "no");
                xmlDoc.AppendChild(node);

                //创建根节点  
                XmlElement root = xmlDoc.CreateElement("ufinterface");
                #region//给节点属性赋值
                root.SetAttribute("billtype", "46");
                root.SetAttribute("filename", "123.xml");
                root.SetAttribute("isexchange", "Y");
                root.SetAttribute("operation", "req");
                root.SetAttribute("proc", "add");
                root.SetAttribute("receiver", "101");
                root.SetAttribute("replace", "Y");
                root.SetAttribute("roottag", "bill");
                root.SetAttribute("sender", "1107");
                #endregion
                xmlDoc.AppendChild(root);

                //创建子根节点
                XmlElement bill = xmlDoc.CreateElement("bill");
                #region//节点属性
                bill.SetAttribute("id", nc[0].vbatchcode);
                #endregion
                root.AppendChild(bill);

                XmlNode head = xmlDoc.CreateNode(XmlNodeType.Element, "bill_head", null);

                #region //表头_order_head

                CreateNode(xmlDoc, head, "cwarehouseid", nc[0].castunitid);

                #endregion

                bill.AppendChild(head);
                XmlElement body = xmlDoc.CreateElement("bill_body");
                bill.AppendChild(body);



                #region //表体_item
                foreach (var n in nc)
                {
                    XmlNode item = xmlDoc.CreateNode(XmlNodeType.Element, "item", null);
                    CreateNode(xmlDoc, item, "cwarehouseid", n.cwarehouseid);//仓库ID
                    CreateNode(xmlDoc, item, "taccounttime", n.taccounttime.ToString("yyyy-MM-dd HH:mm:ss"));//库房签字时间
                    CreateNode(xmlDoc, item, "coperatorid", n.coperatorid);//制单人
                    CreateNode(xmlDoc, item, "ccheckstate_bid", n.ccheckstate_bid);//质量等级NC主键
                    CreateNode(xmlDoc, item, "cworkcenterid", n.cworkcenterid);//工作中心主键1线NC主键
                    CreateNode(xmlDoc, item, "dbizdate", n.dbizdate.ToString("yyyy-MM-dd"));//业务日期
                    CreateNode(xmlDoc, item, "vbatchcode", n.vbatchcode);//批次号
                    CreateNode(xmlDoc, item, "cinvbasid", n.cinvbasid);//存货基本ID
                    CreateNode(xmlDoc, item, "pk_produce", n.pk_produce);//物料PK C_PK_PRODUCE
                    CreateNode(xmlDoc, item, "ninnum", n.ninnum);//实入数量
                    CreateNode(xmlDoc, item, "ninassistnum", n.ninassistnum);//实入辅数量 件数
                    CreateNode(xmlDoc, item, "castunitid", n.castunitid);//辅计量单位ID
                    CreateNode(xmlDoc, item, "vfree1", n.vfree1);//自由项1
                    CreateNode(xmlDoc, item, "vfree2", n.vfree2);//自由项2
                    CreateNode(xmlDoc, item, "vfree3", n.vfree3);//自由项3
                    CreateNode(xmlDoc, item, "vfree4", "");//自由项4
                    CreateNode(xmlDoc, item, "vfree5", "");//自由项5
                    CreateNode(xmlDoc, item, "pk_corp", "1001");//公司编码 1001
                    CreateNode(xmlDoc, item, "gcbm", "");//工厂 
                    #endregion

                    body.AppendChild(item);

                }

                xmlDoc.Save(url + "\\" + xmlFileName);

                if (NCConfig.IsSendToNC)
                {
                    List<string> result = SendXML(url + "\\" + xmlFileName);
                    // Mod_TB_NCIF_LOG log = new Mod_TB_NCIF_LOG();
                    //log.C_TYPE = "46";
                    //log.C_RESULT = result[0];
                    //log.C_REMARK = result[1];
                    //log.C_RELATIONSHIP_ID = nc[0].vbatchcode;
                    //dal_TB_NCIF_LOG.Add(log);
                    return result;
                }

                return null;

            }
            catch
            {
                return null;
            }
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
        /// <summary>
        /// 发送NC
        /// </summary>
        /// <param name="strXML">文件地址</param>
        private List<string> SendXML(string strXML)
        {
            HttpWebRequest req = null;
            try
            {
                //设置要POST到的页面URL，这里中文参数或者有特殊符号的，要进行编码.
                string url = NCConfig.Url;

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
                    StreamReader reader = new StreamReader(strXML);
                    string ret = reader.ReadToEnd();
                    reader.Close();

                    requestWriter.WriteLine(ret);//将读取的内容写入到RequestStream中。
                }

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

        private string XmlGetElement(XmlDocument doc, string code)
        {
            XmlNode root = doc.SelectSingleNode("//sendresult");
            return root.SelectSingleNode(code).InnerText;
        }
    }
}
