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
    public partial class ApiSaleCon
    {
        private Bll_TMB_INTERFACE_LOG tmb_interface_log = new Bll_TMB_INTERFACE_LOG();

        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_TS_USER ts_user = new Bll_TS_USER();
        private Bll_TMB_FLOWINFO tmb_flowinfo = new Bll_TMB_FLOWINFO();

        public ApiSaleCon() { }


        /// <summary>
        /// 获取用户姓名
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        private string GetUserName(string id)
        {
            string name = string.Empty;
            Mod_TS_USER mod = ts_user.GetModel(id);
            if (mod != null)
            {
                name = mod.C_NAME;
            }
            return name;
        }

        /// <summary>
        /// NC销售合同接口
        /// </summary>
        /// <param name="con">合同号</param>
        /// <param name="xmlFileName">文件名/路径</param>
        /// <param name="empID">操作人ID</param>
        /// <returns></returns>
        public List<string> SendXmlOrder(string con, string xmlFileName, string empID)
        {
            try
            {
                Mod_TMO_CON modCon = tmo_con.GetModel(con);
                Mod_TMB_FLOWINFO modFlow = tmb_flowinfo.GetModel(modCon.C_FLOWID);

                XmlDocument xmlDoc = new XmlDocument();
                //创建类型声明节点
                XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "no");
                xmlDoc.AppendChild(node);

                //创建根节点  
                XmlElement root = xmlDoc.CreateElement("ufinterface");
                #region//给节点属性赋值
                root.SetAttribute("account", "1");
                root.SetAttribute("billtype", "CTEXT");
                root.SetAttribute("filename", "");
                root.SetAttribute("isexchange", "Y");
                root.SetAttribute("proc", "add");
                root.SetAttribute("receiver", "101");
                root.SetAttribute("replace", "Y");
                root.SetAttribute("roottag", "bill");
                root.SetAttribute("sender", "1107");
                root.SetAttribute("subbilltype", "");
                #endregion
                xmlDoc.AppendChild(root);

                //创建子根节点
                XmlElement so_order = xmlDoc.CreateElement("bill");
                #region//节点属性
                so_order.SetAttribute("id", con);//主键
                #endregion
                root.AppendChild(so_order);

                XmlNode head = xmlDoc.CreateNode(XmlNodeType.Element, "bill_head", null);

                #region //表头_bill_head
                CreateNode(xmlDoc, head, "actualinvalidate", Convert.ToDateTime(modCon.D_CONINVALID_DT).ToString("yyy-MM-dd"));//实际终止日期
                CreateNode(xmlDoc, head, "actualvalidate", Convert.ToDateTime(modCon.D_CONEFFE_DT).ToString("yyy-MM-dd"));//实际生效日期
                CreateNode(xmlDoc, head, "audiid", modCon.C_APPROVEID);//审核人
                CreateNode(xmlDoc, head, "auditdate", Convert.ToDateTime(modCon.D_APPROVEDATE).ToString("yyy-MM-dd"));//审核日期
                CreateNode(xmlDoc, head, "bsc", "N");//是否委外---****
                CreateNode(xmlDoc, head, "ct_code", modCon.C_CON_NO);//合同编码
                CreateNode(xmlDoc, head, "ct_name", modCon.C_CON_NAME);//合同名称
                CreateNode(xmlDoc, head, "ctflag", modCon.N_STATUS.ToString());//合同状态
                CreateNode(xmlDoc, head, "currid", modCon.C_CURRENCYTYPEID);//币种
                CreateNode(xmlDoc, head, "currrate", "1");//折本汇率
                CreateNode(xmlDoc, head, "custid", modCon.C_CUSTOMERID);//客商
                CreateNode(xmlDoc, head, "custunit", "");//对方单位说明
                CreateNode(xmlDoc, head, "depid", modCon.C_DEPTID);//部门1001NC100000008KOR85
                CreateNode(xmlDoc, head, "ifearly", "N");//是否期初
                CreateNode(xmlDoc, head, "invallidate", Convert.ToDateTime(modCon.D_CONINVALID_DT).ToString("yyy-MM-dd"));//计划失效日期
                CreateNode(xmlDoc, head, "iprintcount", "0");//计划失效日期
                CreateNode(xmlDoc, head, "operdate", Convert.ToDateTime(modCon.D_DMAKEDATE).ToString("yyy-MM-dd"));//制单日期
                CreateNode(xmlDoc, head, "operid", modCon.C_COPERATORID);//制单人1006AA1000000000NI7B 
                CreateNode(xmlDoc, head, "payterm", "");//收付款协议
                CreateNode(xmlDoc, head, "personnelid", modCon.C_EMPLOYEEID);//人员(业务员ID)1001NC10000000000TD8
                CreateNode(xmlDoc, head, "pk_corp", modCon.C_XGID);//公司
                CreateNode(xmlDoc, head, "pk_ct_manage",modCon.C_CON_NO);//合同主键
                CreateNode(xmlDoc, head, "pk_ct_type", modCon.C_CONTYPEID);//类型定义主键
                CreateNode(xmlDoc, head, "projectid", "");//项目号
                CreateNode(xmlDoc, head, "subscribedate", Convert.ToDateTime(modCon.D_CONSING_DT).ToString("yyy-MM-dd"));//合同签订日期
                CreateNode(xmlDoc, head, "valdate", Convert.ToDateTime(modCon.D_CONEFFE_DT).ToString("yyy-MM-dd"));//计划生效日期
                CreateNode(xmlDoc, head, "activeflag", "0");//激活状态
                CreateNode(xmlDoc, head, "clastoperatorid", modCon.C_EDITEMPLOYEEID);//最后修改人
                CreateNode(xmlDoc, head, "astcurrate", "");//折辅汇率
                CreateNode(xmlDoc, head, "nprepaylimitmny", "");//预付款限额
                CreateNode(xmlDoc, head, "nprepaymny", "");//预付款
                CreateNode(xmlDoc, head, "taudittime", Convert.ToDateTime(modCon.D_APPROVEDATE).ToString("yyy-MM-dd HH:mm:ss"));//审批时间
                CreateNode(xmlDoc, head, "tlastmaketime", Convert.ToDateTime(modCon.D_EDITDATE).ToString("yyy-MM-dd HH:mm:ss"));//最后修改时间
                CreateNode(xmlDoc, head, "tmaketime", Convert.ToDateTime(modCon.D_DMAKEDATE).ToString("yyy-MM-dd HH:mm:ss"));//制单时间
                CreateNode(xmlDoc, head, "def1","");//自定义项1
                CreateNode(xmlDoc, head, "def2",modFlow.C_NAME);//审批流程名称（日常合同）
                CreateNode(xmlDoc, head, "def3","");//自定义项3
                CreateNode(xmlDoc, head, "def4","");//自定义项4
                CreateNode(xmlDoc, head, "def5", modCon.C_CON_NO);//自定义项5-合同表头主键
                CreateNode(xmlDoc, head, "pk_defdoc1", modCon.C_REAMRK);// 合同说明信息
                CreateNode(xmlDoc, head, "pk_defdoc2","");// 审批流主键
                CreateNode(xmlDoc, head, "pk_defdoc3","");// 自定义项主键3
                CreateNode(xmlDoc, head, "pk_defdoc4","");// 自定义项主键4
                CreateNode(xmlDoc, head, "pk_defdoc5", GetUserName(modCon.C_EMPLOYEEID));// 自定义项主键5-业务员姓名
                CreateNode(xmlDoc, head, "transpmode", modCon.C_TRANSMODEID);// 发运方式

                #endregion

                so_order.AppendChild(head);
                XmlElement body = xmlDoc.CreateElement("bill_body");
                so_order.AppendChild(body);

                DataTable dt = tmo_order.GetList(" C_CON_NO='" + con + "'").Tables[0];
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int rowno = j + 1;

                    Mod_TMO_ORDER modOrder = tmo_order.GetModel(dt.Rows[j]["C_ID"].ToString());
                    if (modOrder != null)
                    {
                        XmlNode entry = xmlDoc.CreateNode(XmlNodeType.Element, "item", null);

                        #region //表体_item

                        CreateNode(xmlDoc, entry, "amount", modOrder.N_WGT.ToString());//数量
                        CreateNode(xmlDoc, entry, "invclid", ""); //存货分类
                        CreateNode(xmlDoc, entry, "invid", modOrder.C_INVENTORYID);//存货管理档案主键
                        CreateNode(xmlDoc, entry, "measid", modOrder.C_UNITID);//主计量单位
                        CreateNode(xmlDoc, entry, "natiprice", modOrder.N_ORIGINALCURPRICE.ToString());//本币无税单价
                        CreateNode(xmlDoc, entry, "natisum", modOrder.N_ORIGINALCURMNY.ToString());//本币无税金额
                        CreateNode(xmlDoc, entry, "natitaxmny", modOrder.N_ORIGINALCURTAXMNY.ToString());//本币税额
                        CreateNode(xmlDoc, entry, "natitaxprice", modOrder.N_ORIGINALCURTAXPRICE.ToString());//本币含税单价
                        CreateNode(xmlDoc, entry, "natitaxsummny", modOrder.N_ORIGINALCURSUMMNY.ToString());//本币价税合计
                        CreateNode(xmlDoc, entry, "ordnum", "");//订单执行累计数量
                        CreateNode(xmlDoc, entry, "ordprice", "");//订单执行累计含税单价
                        CreateNode(xmlDoc, entry, "ordsum", "");//订单执行累计本币价税合计
                        CreateNode(xmlDoc, entry, "oriprice", modOrder.N_ORIGINALCURPRICE.ToString());//原币无税单价
                        CreateNode(xmlDoc, entry, "orisum", modOrder.N_ORIGINALCURMNY.ToString());//原币无税金额
                        CreateNode(xmlDoc, entry, "oritaxmny", modOrder.N_ORIGINALCURTAXMNY.ToString());//原币税额
                        CreateNode(xmlDoc, entry, "oritaxprice", modOrder.N_ORIGINALCURTAXPRICE.ToString());//原币含税单价
                        CreateNode(xmlDoc, entry, "oritaxsummny", modOrder.N_ORIGINALCURSUMMNY.ToString());//原币价税合计
                        CreateNode(xmlDoc, entry, "pk_corp", modOrder.C_XGID);//公司
                        CreateNode(xmlDoc, entry, "pk_ct_manage","");//合同主键
                        CreateNode(xmlDoc, entry, "pk_ct_manage_b","");//表体主键
                        CreateNode(xmlDoc, entry, "taxration", modOrder.N_TAXRATE.ToString());//税率
                        CreateNode(xmlDoc, entry, "astmeasid", modOrder.C_FUNITID);//辅计量单位
                        CreateNode(xmlDoc, entry, "astnum", modOrder.N_FNUM.ToString());//辅数量
                        CreateNode(xmlDoc, entry, "astprice", "");//辅币无税单价
                        CreateNode(xmlDoc, entry, "astsum", "");//辅币无税金额
                        CreateNode(xmlDoc, entry, "asttaxmny", "");//辅币税额
                        CreateNode(xmlDoc, entry, "asttaxprice", "");//辅币含税单价
                        CreateNode(xmlDoc, entry, "asttaxsummny", "");//辅币价税合计
                        CreateNode(xmlDoc, entry, "cqpbaseschemeid", "");//优质优价方案
                        CreateNode(xmlDoc, entry, "crowno", rowno.ToString());//行号
                        CreateNode(xmlDoc, entry, "transrate", modOrder.N_HSL.ToString());//主辅计量换算率
                        CreateNode(xmlDoc, entry, "vbatchcode", "");//批次号
                        CreateNode(xmlDoc, entry, "def1", "");//自定义项1
                        CreateNode(xmlDoc, entry, "def2", "");//自定义项2
                        CreateNode(xmlDoc, entry, "def3", "");//自定义项3
                        CreateNode(xmlDoc, entry, "def4", modOrder.C_PRO_USE);//自定义项4产品用途
                        CreateNode(xmlDoc, entry, "def5","");//自定义项5
                        CreateNode(xmlDoc, entry, "def6", "");//自定义项6
                        CreateNode(xmlDoc, entry, "def7", "");//自定义项7
                        CreateNode(xmlDoc, entry, "def8", "");//自定义项8
                        CreateNode(xmlDoc, entry, "def9", "");//自定义项9
                        CreateNode(xmlDoc, entry, "def10", modOrder.C_ID);//合同表体主键
                        CreateNode(xmlDoc, entry, "pk_defdoc1", "");//自定义项主键1
                        CreateNode(xmlDoc, entry, "pk_defdoc2", "");//自定义项主键2
                        CreateNode(xmlDoc, entry, "pk_defdoc3", "");//自定义项主键3
                        CreateNode(xmlDoc, entry, "pk_defdoc4", "");//自定义项主键4
                        CreateNode(xmlDoc, entry, "pk_defdoc5", "");//自定义项主键5
                        CreateNode(xmlDoc, entry, "pk_defdoc6", "");//自定义项主键6
                        CreateNode(xmlDoc, entry, "pk_defdoc7", "");//自定义项主键7
                        CreateNode(xmlDoc, entry, "pk_defdoc8", "");//自定义项主键8
                        CreateNode(xmlDoc, entry, "pk_defdoc9", "");//自定义项主键9
                        CreateNode(xmlDoc, entry, "pk_defdoc10", "");//自定义项主键10
                        CreateNode(xmlDoc, entry, "pk_defdoc11", "");//自定义项主键11
                        CreateNode(xmlDoc, entry, "pk_defdoc12", "");//自定义项主键12
                        CreateNode(xmlDoc, entry, "pk_defdoc13", "");//自定义项主键13
                        CreateNode(xmlDoc, entry, "pk_defdoc14", "");//自定义项主键14
                        CreateNode(xmlDoc, entry, "pk_defdoc15", "");//自定义项主键15
                        CreateNode(xmlDoc, entry, "pk_defdoc16", modOrder.C_SPEC);//规格
                        CreateNode(xmlDoc, entry, "pk_defdoc17", modOrder.C_STL_GRD);//钢种
                        CreateNode(xmlDoc, entry, "pk_defdoc18", "");//自定义项主键18
                        CreateNode(xmlDoc, entry, "pk_defdoc19", "");//自定义项主键19
                        CreateNode(xmlDoc, entry, "pk_defdoc20", "");//自定义项主键20
                        CreateNode(xmlDoc, entry, "vfree1", modOrder.C_FREE1);//自由项1
                        CreateNode(xmlDoc, entry, "vfree2", modOrder.C_FREE2);//自由项2
                        CreateNode(xmlDoc, entry, "vfree3", modOrder.C_PACK);//自由项3
                        CreateNode(xmlDoc, entry, "vfree4","");//自由项4
                        CreateNode(xmlDoc, entry, "vfree5", "");//自由项5
                        CreateNode(xmlDoc, entry, "creceiptcorpid", modOrder.C_RECEIPTCORPID);//收货单位
                        CreateNode(xmlDoc, entry, "vreceiveaddress", modOrder.C_RECEIVEADDRESS);//收货地址
                        CreateNode(xmlDoc, entry, "delivdate", Convert.ToDateTime(modOrder.D_DELIVERY_DT).ToString("yyy-MM-dd"));//计划收发货日期
                        CreateNode(xmlDoc, entry, "creceiptareaid", modOrder.C_RECEIPTAREAID);//收货地区ID
                        #endregion

                        body.AppendChild(entry);
                    }
                }

                xmlDoc.Save(xmlFileName);

                List<string> parem = NCSendXml.SendXML(xmlDoc);//发送NC
                parem.Add(con);//合同号
                parem.Add(empID);
                parem.Add("销售合同-NC");
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
