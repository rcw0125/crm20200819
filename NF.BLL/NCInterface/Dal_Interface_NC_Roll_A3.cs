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
    public partial class Dal_Interface_NC_Roll_A3
    {

        //private readonly Dal_TB_NCIF_LOG dal_TB_NCIF_LOG = new Dal_TB_NCIF_LOG();

        public List<string> SendXml_ROLL_A3(string c_id, string zdrid, string xmlFileName, NcRollA3 nc, string path)
        {
            try
            {

                string url = path + $"\\NCXML\\{c_id}";
                if (!Directory.Exists(url))
                {
                    Directory.CreateDirectory(url);
                }

                //Mod_TMO_CON modCon = tmo_con.GetModel(zdrid);
                XmlDocument xmlDoc = new XmlDocument();
                //创建类型声明节点  
                XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "no");
                xmlDoc.AppendChild(node);

                //创建根节点  
                XmlElement root = xmlDoc.CreateElement("ufinterface");
                #region//给节点属性赋值
                root.SetAttribute("billtype", "A3");
                root.SetAttribute("filename", "" + zdrid + ".xml");
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
                bill.SetAttribute("id", nc.hpch);
                #endregion
                root.AppendChild(bill);

                XmlNode head = xmlDoc.CreateNode(XmlNodeType.Element, "bill_head", null);

                #region //表头_order_head

                CreateNode(xmlDoc, head, "scddh", "");//生产订单号  表头是线材数据
                CreateNode(xmlDoc, head, "zdrid", nc.hzdrid);//制单人
                CreateNode(xmlDoc, head, "pch", nc.hpch);//批次号
                CreateNode(xmlDoc, head, "wlbmid", nc.hwlbmid);//物料编码ID
                CreateNode(xmlDoc, head, "jldwid", nc.hjldwid);//计量单位ID
                CreateNode(xmlDoc, head, "ylbmid", "");//用料部门ID
                CreateNode(xmlDoc, head, "bljhdh", "");//备料计划单号
                CreateNode(xmlDoc, head, "zdrq", nc.hzdrq.ToString("yyyy-MM-dd"));//制单日期  没有出出炉日期，可以编辑
                CreateNode(xmlDoc, head, "freeitemvalue1", nc.hfreeitemvalue1);
                CreateNode(xmlDoc, head, "freeitemvalue2", nc.hfreeitemvalue2);
                CreateNode(xmlDoc, head, "freeitemvalue3", nc.hfreeitemvalue3);
                CreateNode(xmlDoc, head, "freeitemvalue4", "");
                CreateNode(xmlDoc, head, "freeitemvalue5", "");
                #endregion

                bill.AppendChild(head);
                XmlElement body = xmlDoc.CreateElement("bill_body");
                bill.AppendChild(body);

                XmlNode item = xmlDoc.CreateNode(XmlNodeType.Element, "item", null);

                #region //表体_item

                CreateNode(xmlDoc, item, "kgyid", nc.kgyid);//库管员  表体是消耗钢坯数据
                CreateNode(xmlDoc, item, "ckckid", nc.ckckid);//出库仓库ID
                CreateNode(xmlDoc, item, "ckckbm", "");
                CreateNode(xmlDoc, item, "wlbmid", nc.wlbmid);//物料编码ID
                CreateNode(xmlDoc, item, "jldwid", nc.jldwid);//计量单位ID
                CreateNode(xmlDoc, item, "fjldwid", nc.fjldwid);//辅计量单位ID
                CreateNode(xmlDoc, item, "ljcksl", nc.ljcksl);//累计出库数量
                CreateNode(xmlDoc, item, "fljcksl", nc.fljcksl);//辅累计出库数量
                CreateNode(xmlDoc, item, "pch", nc.pch);//批次号
                CreateNode(xmlDoc, item, "gzzxid", nc.gzzxid);//工作中心ID
                CreateNode(xmlDoc, item, "gxh", "");//工序号
                CreateNode(xmlDoc, item, "zdy1", "");//自定义项1
                CreateNode(xmlDoc, item, "zdy2", "");//自定义项2
                CreateNode(xmlDoc, item, "zdy3", "");//自定义项3
                CreateNode(xmlDoc, item, "zdy4", "");//自定义项4
                CreateNode(xmlDoc, item, "zdy5", "");//自定义项5
                CreateNode(xmlDoc, item, "freeitemvalue1", nc.freeitemvalue1);
                CreateNode(xmlDoc, item, "freeitemvalue2", nc.freeitemvalue2);
                CreateNode(xmlDoc, item, "freeitemvalue3", nc.freeitemvalue3);
                CreateNode(xmlDoc, item, "freeitemvalue4", "");
                CreateNode(xmlDoc, item, "freeitemvalue5", "");
                CreateNode(xmlDoc, item, "pk_corp", "");//公司编码
                CreateNode(xmlDoc, item, "gcbm", "");//工厂
                CreateNode(xmlDoc, item, "ccostobject", "");//成本对象ID
                CreateNode(xmlDoc, item, "flrq", nc.flrq);//发料日期
                CreateNode(xmlDoc, item, "pk_moid", "");//生产定单ID
                #endregion

                body.AppendChild(item);


                xmlDoc.Save(url + "\\" + xmlFileName);

                if (NCConfig.IsSendToNC)
                {
                    var result = SendXML(url + "\\" + xmlFileName);
                    //Mod_TB_NCIF_LOG log = new Mod_TB_NCIF_LOG();
                    //log.C_TYPE = "A3";
                    //log.C_RESULT = result[0];
                    //log.C_REMARK = result[1];
                    //log.C_RELATIONSHIP_ID = nc.pch;
                    //dal_TB_NCIF_LOG.Add(log);
                    return result;
                }

                return null;
            }

            catch (Exception ex)
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
