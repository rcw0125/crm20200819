using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NF.MODEL;
using NF.BLL;
using System.Xml;
using System.Data;
using System.Net;
using System.IO;

namespace NF.NC.Interface
{
    /// <summary>
    /// 接口日计划
    /// </summary>
    public partial class ApiDayPlan
    {
        private Bll_TMB_INTERFACE_LOG tmb_interface_log = new Bll_TMB_INTERFACE_LOG();
        private Bll_TMP_DAYPLAN tmp_dayplan = new Bll_TMP_DAYPLAN();

        public ApiDayPlan() { }

        public List<string> SendXmlDayPlan(string dayplcode, string xmlFileName, string empID)
        {
            try
            {
                Mod_TMP_DAYPLAN modPlan = tmp_dayplan.GetModel(dayplcode);

                XmlDocument xmlDoc = new XmlDocument();
                //创建类型声明节点  
                XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "no");
                xmlDoc.AppendChild(node);

                //创建根节点  
                XmlElement root = xmlDoc.CreateElement("ufinterface");
                #region//给节点属性赋值
                root.SetAttribute("account", "1");
                root.SetAttribute("billtype", "DMDP");
                root.SetAttribute("filename", "" + dayplcode + ".xml");
                root.SetAttribute("isexchange", "Y");
                root.SetAttribute("proc", "add");
                root.SetAttribute("receiver", "101");
                root.SetAttribute("replace", "Y");
                root.SetAttribute("roottag", "bill");
                root.SetAttribute("sender", "1107");
                #endregion
                xmlDoc.AppendChild(root);

                //创建子根节点
                XmlElement so_order = xmlDoc.CreateElement("bill");
                so_order.SetAttribute("id", modPlan.C_ID);
                root.AppendChild(so_order);

                XmlNode head = xmlDoc.CreateNode(XmlNodeType.Element, "bill_head", null);

                #region //表头_order_head
                CreateNode(xmlDoc, head, "vdelivdayplcode", modPlan.C_PLCODE);//日计划单据号
                CreateNode(xmlDoc, head, "vbilltype", "30");//来源单据类型
                CreateNode(xmlDoc, head, "pkbillb", modPlan.C_PKBILLB);//来源单据子表ID
                CreateNode(xmlDoc, head, "pkbillh", modPlan.C_PKBILLH);//来源单据主表ID
                CreateNode(xmlDoc, head, "vsrcbillnum", modPlan.C_SALECODE);//来源销售主表单据号
                CreateNode(xmlDoc, head, "iplanstatus", "0");
                CreateNode(xmlDoc, head, "plandate", Convert.ToDateTime(modPlan.D_PLANDATE).ToString("yyy-MM-dd"));//日计划日期
                CreateNode(xmlDoc, head, "ordsndate", Convert.ToDateTime(modPlan.D_ORDSNDATE).ToString("yyy-MM-dd"));//定单要求发货日期
                CreateNode(xmlDoc, head, "requiredate", Convert.ToDateTime(modPlan.D_REQUIREDATE).ToString("yyy-MM-dd"));//定单要求到货日期
                CreateNode(xmlDoc, head, "snddate", Convert.ToDateTime(modPlan.D_SNDDATE).ToString("yyy-MM-dd"));//实际发货日期
                CreateNode(xmlDoc, head, "pkinv", modPlan.C_PKINV);//存货主键
                CreateNode(xmlDoc, head, "pkassistmeasure", modPlan.C_PKASSISTMEASURE); //辅计量单位
                CreateNode(xmlDoc, head, "dassistnum", modPlan.N_ASSISTNUM.ToString()); //辅数量
                CreateNode(xmlDoc, head, "dnum", modPlan.N_NUM.ToString());//主数量
                CreateNode(xmlDoc, head, "pkcust", modPlan.C_PKCUST);//客户主键
                CreateNode(xmlDoc, head, "pksendtype", modPlan.C_PKSENDTYPE);//发运方式
                CreateNode(xmlDoc, head, "vbatchcode", "");
                CreateNode(xmlDoc, head, "ibatchstatus", "0");
                CreateNode(xmlDoc, head, "pkdeststoreorg", "");
                CreateNode(xmlDoc, head, "pkdeststore", "");
                CreateNode(xmlDoc, head, "pksalecorp", modPlan.C_PKSALECORP); //销售公司主键
                CreateNode(xmlDoc, head, "pksaleorg", modPlan.C_PKSALEORG);//销售组织主键
                CreateNode(xmlDoc, head, "pksendstoreorg", modPlan.C_PKSENDSTOREORG);//发货库存组织主键
                CreateNode(xmlDoc, head, "pksendstore", "N");
                CreateNode(xmlDoc, head, "dweight", "");
                CreateNode(xmlDoc, head, "dvolumn", "");
                CreateNode(xmlDoc, head, "dunitprice", modPlan.N_UNITPRICE.ToString());//单价
                CreateNode(xmlDoc, head, "dmoney", modPlan.N_MONEY.ToString());//订单金额
                CreateNode(xmlDoc, head, "bpresent", "N");
                CreateNode(xmlDoc, head, "dsendnum", "");
                CreateNode(xmlDoc, head, "dsignnum", "");
                CreateNode(xmlDoc, head, "doutnum", "");
                CreateNode(xmlDoc, head, "dbacknum", "");
                CreateNode(xmlDoc, head, "pkitem", "");
                CreateNode(xmlDoc, head, "pkitemperiod", "");
                CreateNode(xmlDoc, head, "pkoperator", modPlan.C_PKOPERATOR);//业务员主键
                CreateNode(xmlDoc, head, "pkoprdepart", modPlan.C_PKOPRDEPART);//业务部门主键
                CreateNode(xmlDoc, head, "pkplanperson", modPlan.C_PKPLANPERSON);//计划人
                CreateNode(xmlDoc, head, "pkapprperson", modPlan.C_PKAPPRPERSON);//审批人
                CreateNode(xmlDoc, head, "apprdate", Convert.ToDateTime(modPlan.D_APPRDATE).ToString("yyy-MM-dd"));//审批日期
                CreateNode(xmlDoc, head, "pkarrivearea", modPlan.C_PKARRIVEAREA);//到货地区主键
                CreateNode(xmlDoc, head, "vdestaddress", modPlan.C_DESTADDRESS);//到货地址
                CreateNode(xmlDoc, head, "cfreezeid", "");
                CreateNode(xmlDoc, head, "creceiptcorpid", modPlan.C_RECEIPTCORPID);//收货单位
                CreateNode(xmlDoc, head, "cbiztype", modPlan.C_BIZTYPE);//业务类型
                CreateNode(xmlDoc, head, "vnote", modPlan.C_REMARK);
                CreateNode(xmlDoc, head, "dwaylossnum", "");
                CreateNode(xmlDoc, head, "bisdelivend", "");
                CreateNode(xmlDoc, head, "bisoutend", "");
                CreateNode(xmlDoc, head, "pkarrivecorp", "");
                CreateNode(xmlDoc, head, "pksendarea", modPlan.C_PKSENDAREA);//发货地区
                CreateNode(xmlDoc, head, "cplansendtime", "");
                CreateNode(xmlDoc, head, "crequiretime", "");
                CreateNode(xmlDoc, head, "pkarriveaddress", "");
                CreateNode(xmlDoc, head, "pksendaddress", "");
                CreateNode(xmlDoc, head, "pkdelivorg", modPlan.C_PKDELIVORG);//发运组织固定
                CreateNode(xmlDoc, head, "pkorderplanid", "");
                CreateNode(xmlDoc, head, "borderreturn", "N");
                CreateNode(xmlDoc, head, "csendcorpid", "");
                CreateNode(xmlDoc, head, "vsendaddr", "");
                CreateNode(xmlDoc, head, "ntotalshouldoutnum", "");
                CreateNode(xmlDoc, head, "nfeedbacknum", modPlan.N_NUM.ToString());//回写上游数量--发运单
                CreateNode(xmlDoc, head, "iprintcount", "");
                CreateNode(xmlDoc, head, "cquoteunitid", modPlan.C_UNITID);//报价计量单位ID
                CreateNode(xmlDoc, head, "nquoteunitnum", "1");
                CreateNode(xmlDoc, head, "nquoteunitrate", "1");
                CreateNode(xmlDoc, head, "taudittime", "");
                CreateNode(xmlDoc, head, "tmaketime", "");
                CreateNode(xmlDoc, head, "tlastmodifytime", "");
                CreateNode(xmlDoc, head, "clastmodifierid", "");
                CreateNode(xmlDoc, head, "vfree1", modPlan.C_VFREE1);//自由项1
                CreateNode(xmlDoc, head, "vfree2", modPlan.C_VFREE2);//自由项2
                CreateNode(xmlDoc, head, "vfree3", modPlan.C_VFREE3);//包装要求
                CreateNode(xmlDoc, head, "vfree4", "");
                CreateNode(xmlDoc, head, "vfree5", "");
                CreateNode(xmlDoc, head, "vfree6", "");
                CreateNode(xmlDoc, head, "vfree7", "");
                CreateNode(xmlDoc, head, "vfree8", "");
                CreateNode(xmlDoc, head, "vfree9", "");
                CreateNode(xmlDoc, head, "vfree10", "");
                CreateNode(xmlDoc, head, "vuserdef0", "");
                CreateNode(xmlDoc, head, "vuserdef1", "");
                CreateNode(xmlDoc, head, "vuserdef2", "");
                CreateNode(xmlDoc, head, "vuserdef3", "");
                CreateNode(xmlDoc, head, "vuserdef4", "");
                CreateNode(xmlDoc, head, "vuserdef5", "");
                CreateNode(xmlDoc, head, "vuserdef6", "");
                CreateNode(xmlDoc, head, "vuserdef7", "");
                CreateNode(xmlDoc, head, "vuserdef8", "");
                CreateNode(xmlDoc, head, "vuserdef9", "");
                CreateNode(xmlDoc, head, "vuserdef10", "");
                CreateNode(xmlDoc, head, "vuserdef11", "");
                CreateNode(xmlDoc, head, "vuserdef12", "");
                CreateNode(xmlDoc, head, "vuserdef13", "");
                CreateNode(xmlDoc, head, "vuserdef14", "");
                CreateNode(xmlDoc, head, "vuserdef15", "");
                CreateNode(xmlDoc, head, "vuserdef16", "");
                CreateNode(xmlDoc, head, "vuserdef17", "");
                CreateNode(xmlDoc, head, "vuserdef18", "");
                CreateNode(xmlDoc, head, "vuserdef19", "");
                CreateNode(xmlDoc, head, "pk_defdoc0", "");
                CreateNode(xmlDoc, head, "pk_defdoc1", "");
                CreateNode(xmlDoc, head, "pk_defdoc2", "");
                CreateNode(xmlDoc, head, "pk_defdoc3", "");
                CreateNode(xmlDoc, head, "pk_defdoc4", "");
                CreateNode(xmlDoc, head, "pk_defdoc5", "");
                CreateNode(xmlDoc, head, "pk_defdoc6", "");
                CreateNode(xmlDoc, head, "pk_defdoc7", "");
                CreateNode(xmlDoc, head, "pk_defdoc8", "");
                CreateNode(xmlDoc, head, "pk_defdoc9", "");
                CreateNode(xmlDoc, head, "pk_defdoc10", "");
                CreateNode(xmlDoc, head, "pk_defdoc11", "");
                CreateNode(xmlDoc, head, "pk_defdoc12", "");
                CreateNode(xmlDoc, head, "pk_defdoc13", "");
                CreateNode(xmlDoc, head, "pk_defdoc14", "");
                CreateNode(xmlDoc, head, "pk_defdoc15", "");
                CreateNode(xmlDoc, head, "pk_defdoc16", "");
                CreateNode(xmlDoc, head, "pk_defdoc17", "");
                CreateNode(xmlDoc, head, "pk_defdoc18", "");
                CreateNode(xmlDoc, head, "pk_defdoc19", "");
                CreateNode(xmlDoc, head, "vuserdef_b_0", "");
                CreateNode(xmlDoc, head, "vuserdef_b_1", "");
                CreateNode(xmlDoc, head, "vuserdef_b_2", "");
                CreateNode(xmlDoc, head, "vuserdef_b_3", "");
                CreateNode(xmlDoc, head, "vuserdef_b_4", "");
                CreateNode(xmlDoc, head, "vuserdef_b_5", "");
                CreateNode(xmlDoc, head, "vuserdef_b_6", "");
                CreateNode(xmlDoc, head, "vuserdef_b_7", "");
                CreateNode(xmlDoc, head, "vuserdef_b_8", "");
                CreateNode(xmlDoc, head, "vuserdef_b_9", "");
                CreateNode(xmlDoc, head, "vuserdef_b_10", modPlan.C_CONNO);//合同号
                CreateNode(xmlDoc, head, "vuserdef_b_11", modPlan.C_VFREE4);//质量等级
                CreateNode(xmlDoc, head, "vuserdef_b_12", "");
                CreateNode(xmlDoc, head, "vuserdef_b_13", "");
                CreateNode(xmlDoc, head, "vuserdef_b_14", "");
                CreateNode(xmlDoc, head, "vuserdef_b_15", "");
                CreateNode(xmlDoc, head, "vuserdef_b_16", "");
                CreateNode(xmlDoc, head, "vuserdef_b_17", "");
                CreateNode(xmlDoc, head, "vuserdef_b_18", "");
                CreateNode(xmlDoc, head, "vuserdef_b_19", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_0", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_1", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_2", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_3", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_4", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_5", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_6", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_7", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_8", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_9", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_10", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_11", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_12", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_13", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_14", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_15", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_16", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_17", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_18", "");
                CreateNode(xmlDoc, head, "pk_defdoc_b_19", "");

                #endregion

                so_order.AppendChild(head);

                xmlDoc.Save(xmlFileName);

                List<string> parem = NCSendXml.SendXML(xmlDoc);//发送NC
                parem.Add(dayplcode);
                parem.Add(empID);
                parem.Add("日计划-NC");
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
