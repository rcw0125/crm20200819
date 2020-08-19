using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NF.MODEL;
using NF.BLL;
using System.Xml;
using System.Data;
using System.Net;
using System.IO;
using NF.NC;

namespace NF.NC.Interface
{


    /// <summary>
    /// 销售订单导入NC接口
    /// </summary>
    public partial class ApiOrder
    {
        private Bll_TMB_INTERFACE_LOG tmb_interface_log = new Bll_TMB_INTERFACE_LOG();

        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();

        public ApiOrder() { }




        /// <summary>
        /// NC订单维护接口
        /// </summary>
        /// <param name="saleCode">销售单据号列表</param>
        /// <param name="xmlFileName">路径/文件名.xml</param>
        /// <param name="empID">操作人ID</param>
        /// <returns>返回结果集</returns>
        public List<string> SendXmlOrder(List<ApiOrderDto> orderDto, string xmlFileName, string empID)
        {
            try
            {
                Mod_TMO_CON modCon = tmo_con.GetModel(orderDto[0].ConNO);

                XmlDocument xmlDoc = new XmlDocument();
                //创建类型声明节点
                XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "no");
                xmlDoc.AppendChild(node);

                //创建根节点  
                XmlElement root = xmlDoc.CreateElement("ufinterface");
                #region//给节点属性赋值
                root.SetAttribute("account", "1");
                root.SetAttribute("billtype", "30ext");
                root.SetAttribute("filename", "" + orderDto[0].SaleCode + ".xml");//单据号
                root.SetAttribute("isexchange", "Y");
                root.SetAttribute("proc", "add");
                root.SetAttribute("receiver", "101");
                root.SetAttribute("replace", "Y");
                root.SetAttribute("roottag", "so_order");
                root.SetAttribute("sender", "1107");
                #endregion
                xmlDoc.AppendChild(root);

                //创建子根节点
                XmlElement so_order = xmlDoc.CreateElement("so_order");
                #region//节点属性
                so_order.SetAttribute("id", orderDto[0].NC_ID);//主键
                #endregion
                root.AppendChild(so_order);

                XmlNode head = xmlDoc.CreateNode(XmlNodeType.Element, "so_order_head", null);

                #region //表头_order_head
                CreateNode(xmlDoc, head, "pk_corp", "1001");
                CreateNode(xmlDoc, head, "vreceiptcode", orderDto[0].SaleCode);//销售单据号
                CreateNode(xmlDoc, head, "creceipttype", "30");
                CreateNode(xmlDoc, head, "cbiztype", modCon.C_BIZTYPE);//业务类型
                CreateNode(xmlDoc, head, "vaccountyear", "");
                CreateNode(xmlDoc, head, "binitflag", "N");
                CreateNode(xmlDoc, head, "dbilldate", Convert.ToDateTime(orderDto[0].D_NC_DATE).ToString("yyy-MM-dd"));//单据日期
                CreateNode(xmlDoc, head, "ccustomerid", modCon.C_CUSTOMERID);//客户ID
                CreateNode(xmlDoc, head, "cdeptid", modCon.C_DEPTID);//部门ID
                CreateNode(xmlDoc, head, "cemployeeid", modCon.C_EMPLOYEEID);//业务员ID
                CreateNode(xmlDoc, head, "coperatorid", modCon.C_COPERATORID);//制单人
                CreateNode(xmlDoc, head, "ctermprotocolid", "");
                CreateNode(xmlDoc, head, "csalecorpid", modCon.C_SALECORPID);//销售组织
                CreateNode(xmlDoc, head, "ccalbodyid", "1001NC10000000000669");//库存组织
                CreateNode(xmlDoc, head, "creceiptcustomerid", modCon.C_CRECEIPTCUSTOMERID);//收货单位
                CreateNode(xmlDoc, head, "vreceiveaddress", modCon.C_ADDRESS);//收货地址
                CreateNode(xmlDoc, head, "creceiptareaid", "");
                CreateNode(xmlDoc, head, "creceiptcorpid", modCon.C_CRECEIPTCORPID);//开票单位
                CreateNode(xmlDoc, head, "ccustbankid", "");
                CreateNode(xmlDoc, head, "ctransmodeid", modCon.C_TRANSMODEID);//发运方式
                CreateNode(xmlDoc, head, "ndiscountrate", "100");
                CreateNode(xmlDoc, head, "cwarehouseid", "");
                CreateNode(xmlDoc, head, "veditreason", "");
                CreateNode(xmlDoc, head, "bfreecustflag", "N");
                CreateNode(xmlDoc, head, "cfreecustid", "");
                CreateNode(xmlDoc, head, "ibalanceflag", "");
                CreateNode(xmlDoc, head, "nsubscription", "");
                CreateNode(xmlDoc, head, "nevaluatecarriage", "0");
                CreateNode(xmlDoc, head, "dmakedate", Convert.ToDateTime(modCon.D_DMAKEDATE).ToString("yyy-MM-dd"));//制单日期
                CreateNode(xmlDoc, head, "capproveid", modCon.C_APPROVEID);//审批人
                CreateNode(xmlDoc, head, "dapprovedate", Convert.ToDateTime(modCon.D_APPROVEDATE).ToString("yyy-MM-dd"));//审批日期
                CreateNode(xmlDoc, head, "fstatus", "1");
                CreateNode(xmlDoc, head, "vnote", modCon.C_CON_NAME);//合同名称
                CreateNode(xmlDoc, head, "vdef1", "");
                CreateNode(xmlDoc, head, "vdef2", "");
                CreateNode(xmlDoc, head, "vdef3", "");
                CreateNode(xmlDoc, head, "vdef4", "");
                CreateNode(xmlDoc, head, "vdef5", "");
                CreateNode(xmlDoc, head, "vdef6", "");
                CreateNode(xmlDoc, head, "vdef7", "");
                CreateNode(xmlDoc, head, "vdef8", "");
                CreateNode(xmlDoc, head, "vdef9", "");
                CreateNode(xmlDoc, head, "vdef10", "");
                CreateNode(xmlDoc, head, "bretinvflag", "N");
                CreateNode(xmlDoc, head, "boutendflag", "N");
                CreateNode(xmlDoc, head, "binvoicendflag", "N");
                CreateNode(xmlDoc, head, "breceiptendflag", "N");
                CreateNode(xmlDoc, head, "bpayendflag", "N");
                CreateNode(xmlDoc, head, "bdeliver", "Y");
                #endregion

                so_order.AppendChild(head);
                XmlElement body = xmlDoc.CreateElement("so_order_body");
                so_order.AppendChild(body);

                DataTable dt = tmo_order.GetSaleOrder(orderDto[0].SaleCode).Tables[0];
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int rowno = j + 1;

                    Mod_TMO_ORDER modOrder = tmo_order.GetModel(dt.Rows[j]["C_ID"].ToString());
                    if (modOrder != null)
                    {
                        XmlNode entry = xmlDoc.CreateNode(XmlNodeType.Element, "entry", null);

                        #region //表体_entry

                        string[] arr = { "6", "8" };

                        CreateNode(xmlDoc, entry, "pk_corp", modOrder.C_XGID);//邢钢公司'1001'
                        CreateNode(xmlDoc, entry, "creceipttype", "");
                        CreateNode(xmlDoc, entry, "csourcebillid", "");
                        CreateNode(xmlDoc, entry, "csourcebillbodyid", "");
                        CreateNode(xmlDoc, entry, "cinvbasdocid", modOrder.C_INVBASDOCID);//存货档案主键
                        CreateNode(xmlDoc, entry, "cinventoryid", modOrder.C_INVENTORYID);//存货管理档案主键
                        CreateNode(xmlDoc, entry, "cunitid", modOrder.C_UNITID);//主计量单位

                        if (arr.Contains(modOrder.N_TYPE.ToString()))
                        {
                            CreateNode(xmlDoc, entry, "cpackunitid", modOrder.C_FUNITID);//辅单位
                        }
                        else
                        {
                            CreateNode(xmlDoc, entry, "cpackunitid","");//辅单位
                        }
                        CreateNode(xmlDoc, entry, "cbatchid", "");

                        CreateNode(xmlDoc, entry, "nnumber", modOrder.N_WGT.ToString());//数量
                        if (arr.Contains(modOrder.N_TYPE.ToString()))
                        {
                            CreateNode(xmlDoc, entry, "npacknumber", modOrder.N_FNUM.ToString());//辅数量
                        }
                        else
                        {
                            CreateNode(xmlDoc, entry, "npacknumber","");//辅数量
                        }
                        CreateNode(xmlDoc, entry, "cconsigncorpid", modOrder.C_XGID);//发货公司
                        CreateNode(xmlDoc, entry, "cadvisecalbodyid", "1001NC10000000000669");//发货库存组织
                        CreateNode(xmlDoc, entry, "cbodywarehouseid", "");
                        CreateNode(xmlDoc, entry, "creccalbodyid", "");
                        CreateNode(xmlDoc, entry, "crecwarehouseid", "a");
                        CreateNode(xmlDoc, entry, "dconsigndate", Convert.ToDateTime(modOrder.D_DELIVERY_DT).ToString("yyy-MM-dd"));//发货日期
                        CreateNode(xmlDoc, entry, "ddeliverdate", Convert.ToDateTime(modOrder.D_DELIVERY_DT).ToString("yyy-MM-dd"));//交货日期
                        CreateNode(xmlDoc, entry, "blargessflag", "N");
                        CreateNode(xmlDoc, entry, "ceditsaleid", "");
                        CreateNode(xmlDoc, entry, "beditflag", "N");
                        CreateNode(xmlDoc, entry, "veditreason", "");
                        CreateNode(xmlDoc, entry, "ccurrencytypeid", modOrder.C_CURRENCYTYPEID);//原币
                        CreateNode(xmlDoc, entry, "nitemdiscountrate", "100");
                        CreateNode(xmlDoc, entry, "ndiscountrate", "100");
                        CreateNode(xmlDoc, entry, "nexchangeotobrate", "1");
                        CreateNode(xmlDoc, entry, "nexchangeotoarate", "");
                        CreateNode(xmlDoc, entry, "ntaxrate", Convert.ToString(modOrder.N_TAXRATE * 100));//税率
                        CreateNode(xmlDoc, entry, "noriginalcurprice", modOrder.N_ORIGINALCURPRICE.ToString());//原币无税单价
                        CreateNode(xmlDoc, entry, "noriginalcurtaxprice", modOrder.N_ORIGINALCURTAXPRICE.ToString());//原币含税单价
                        CreateNode(xmlDoc, entry, "noriginalcurnetprice", modOrder.N_ORIGINALCURPRICE.ToString());//原币无税净价
                        CreateNode(xmlDoc, entry, "noriginalcurtaxnetprice", modOrder.N_ORIGINALCURTAXPRICE.ToString());//原币含税净价
                        CreateNode(xmlDoc, entry, "noriginalcurtaxmny", modOrder.N_ORIGINALCURTAXMNY.ToString());//原币税额
                        CreateNode(xmlDoc, entry, "noriginalcurmny", modOrder.N_ORIGINALCURMNY.ToString());//原币无税金额
                        CreateNode(xmlDoc, entry, "noriginalcursummny", modOrder.N_ORIGINALCURSUMMNY.ToString());//原币价税合计
                        CreateNode(xmlDoc, entry, "noriginalcurdiscountmny", "0");
                        CreateNode(xmlDoc, entry, "nprice", modOrder.N_ORIGINALCURPRICE.ToString());//本币无税单价
                        CreateNode(xmlDoc, entry, "ntaxprice", modOrder.N_ORIGINALCURTAXPRICE.ToString());//本币含税单价
                        CreateNode(xmlDoc, entry, "nnetprice", modOrder.N_ORIGINALCURPRICE.ToString());//本币无税净价
                        CreateNode(xmlDoc, entry, "ntaxnetprice", modOrder.N_ORIGINALCURTAXPRICE.ToString());//本币含税净价
                        CreateNode(xmlDoc, entry, "ntaxmny", modOrder.N_ORIGINALCURTAXMNY.ToString());//本币税额
                        CreateNode(xmlDoc, entry, "nmny", modOrder.N_ORIGINALCURMNY.ToString());//本币无税金额
                        CreateNode(xmlDoc, entry, "nsummny", modOrder.N_ORIGINALCURSUMMNY.ToString());//本币价税合计
                        CreateNode(xmlDoc, entry, "ndiscountmny", "0");
                        CreateNode(xmlDoc, entry, "coperatorid", "");//制单人
                        CreateNode(xmlDoc, entry, "frowstatus", "1");
                        CreateNode(xmlDoc, entry, "frownote", "");
                        CreateNode(xmlDoc, entry, "fbatchstatus", "0");
                        CreateNode(xmlDoc, entry, "ct_manageid", "");
                        CreateNode(xmlDoc, entry, "cfactoryid", "");//合同表头主键
                        CreateNode(xmlDoc, entry, "cfreezeid", "");//合同表体主键
                        CreateNode(xmlDoc, entry, "cbomorderid", modOrder.C_ID);//销售订单表体主键
                        CreateNode(xmlDoc, entry, "boosflag", "N");
                        CreateNode(xmlDoc, entry, "bsupplyflag", "N");
                        CreateNode(xmlDoc, entry, "creceiptareaid", modOrder.C_RECEIPTAREAID);//收货地区
                        CreateNode(xmlDoc, entry, "vreceiveaddress", modOrder.C_RECEIVEADDRESS);//收货地址
                        CreateNode(xmlDoc, entry, "creceiptcorpid", modOrder.C_RECEIPTCORPID);//收货单位
                        CreateNode(xmlDoc, entry, "crowno", rowno.ToString());//行号
                        CreateNode(xmlDoc, entry, "ntotalpaymny", "0.00000000");
                        CreateNode(xmlDoc, entry, "ntotalreceiptnumber", "0.00000000");
                        CreateNode(xmlDoc, entry, "ntotalinvoicenumber", "0.00000000");
                        CreateNode(xmlDoc, entry, "ntotalinvoicemny", "0.00000000");
                        CreateNode(xmlDoc, entry, "ntotalinventorynumber", "0.00000000");
                        CreateNode(xmlDoc, entry, "ntotalbalancenumber", "0.00000000");
                        CreateNode(xmlDoc, entry, "ntotalsignnumber", "0.00000000");
                        CreateNode(xmlDoc, entry, "ntotalcostmny", "0.00000000");
                        CreateNode(xmlDoc, entry, "bifinvoicefinish", "N");
                        CreateNode(xmlDoc, entry, "bifreceiptfinish", "N");
                        CreateNode(xmlDoc, entry, "bifinventoryfinish", "N");
                        CreateNode(xmlDoc, entry, "bifpayfinish", "N");
                        CreateNode(xmlDoc, entry, "bifpaybalance", "N");
                        CreateNode(xmlDoc, entry, "bifpaysign", "N");
                        CreateNode(xmlDoc, entry, "nassistcurdiscountmny", "0.00000000");
                        CreateNode(xmlDoc, entry, "nassistcursummny", "0.00000000");
                        CreateNode(xmlDoc, entry, "nassistcurtaxmny", "0.00000000");
                        CreateNode(xmlDoc, entry, "nassistcurtaxnetprice", "0.00000000");
                        CreateNode(xmlDoc, entry, "nassistcurnetprice", "0.00000000");
                        CreateNode(xmlDoc, entry, "nassistcurtaxprice", "0.00000000");
                        CreateNode(xmlDoc, entry, "nassistcurprice", "0.00000000");
                        CreateNode(xmlDoc, entry, "cprojectid", "");
                        CreateNode(xmlDoc, entry, "cprojectphaseid", "");
                        CreateNode(xmlDoc, entry, "vfree1", modOrder.C_FREE1); //自由项1
                        CreateNode(xmlDoc, entry, "vfree2", modOrder.C_FREE2);//自由项2
                        CreateNode(xmlDoc, entry, "vfree3", modOrder.C_PACK);//包装
                        CreateNode(xmlDoc, entry, "vfree4", "");
                        CreateNode(xmlDoc, entry, "vfree5", "");
                        CreateNode(xmlDoc, entry, "vdef1", "");
                        CreateNode(xmlDoc, entry, "vdef2", "");
                        CreateNode(xmlDoc, entry, "vdef3", "");
                        CreateNode(xmlDoc, entry, "vdef4", "");
                        CreateNode(xmlDoc, entry, "vdef5", "");
                        CreateNode(xmlDoc, entry, "vdef6", "");
                        CreateNode(xmlDoc, entry, "vdef11", modOrder.C_CON_NO);//合同号
                        CreateNode(xmlDoc, entry, "vdef12", modOrder.C_VDEF1);//质量等级主键
                        CreateNode(xmlDoc, entry, "ntotalreturnnumber", "0.00000000");
                        CreateNode(xmlDoc, entry, "ntotalcarrynumber", "0.00000000");
                        CreateNode(xmlDoc, entry, "ntotalplanreceiptnumber", "0.00000000");
                        #endregion

                        body.AppendChild(entry);
                    }
                }

                xmlDoc.Save(xmlFileName);

                List<string> parem = NCSendXml.SendXML(xmlDoc);//发送NC
                parem.Add(orderDto[0].SaleCode);//销售单据号
                parem.Add(empID);
                parem.Add("销售订单-NC");
                parem.Add(parem[0] == "1" ? "导入NC成功" : "导入NC失败");
                //日志录入
                AddLog(parem);

                return parem;

            }
            catch (Exception ex)
            {
                throw ex;
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
        /// 添加日志
        /// </summary>
        /// <param name="parem"></param>
        /// <returns></returns>
        private void AddLog(List<string> parem)
        {
            try
            {
                Mod_TMB_INTERFACE_LOG mod = new Mod_TMB_INTERFACE_LOG();

                mod.D_SENDTIME = DateTime.Now;
                mod.C_RESULTCODE = parem[0];//返回结果
                mod.C_RESULTDESC = parem[1];//返回结果描述
                mod.C_CONTENT = parem[2];//返回成功或空
                mod.C_PKID = parem[3];//主键
                mod.C_EMPID = parem[4];//操作人ID
                mod.C_FLAG = parem[5];//标识
                mod.C_REMARK = parem[6];//备注
                tmb_interface_log.Add(mod);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
