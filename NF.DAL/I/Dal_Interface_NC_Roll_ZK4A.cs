using NF.MODEL;
using NF.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace NF.DAL
{
    public partial class Dal_Interface_NC_Roll_ZK4A
    {
        Dal_Send_NC SendNC = new Dal_Send_NC();
        Dal_TRC_ROLL_ZKD dal_TRC_ROLL_ZKD = new Dal_TRC_ROLL_ZKD();
        Dal_TB_MATRL_MAIN dal_TB_MATRL_MAIN = new Dal_TB_MATRL_MAIN();
        Dal_TPB_LINEWH dal_TPB_LINEWH = new Dal_TPB_LINEWH();
        Dal_TRC_ROLL_PRODCUT dal_TRC_ROLL_PRODCUT = new Dal_TRC_ROLL_PRODCUT();
        Dal_TRC_ROLL_MAIN dal_TRC_ROLL_MAIN = new Dal_TRC_ROLL_MAIN();
        Dal_TS_USER dal_TS_USER = new Dal_TS_USER();
        Dal_TQB_CHECKSTATE dal_TQB_CHECKSTATE = new Dal_TQB_CHECKSTATE();
        Dal_TS_DEPT dal_TS_DEPT = new Dal_TS_DEPT();
        /// <summary>
        /// 发送转库实绩信息给NC
        /// </summary>
        /// <param name="xmlFileName">xml完整路径</param>
        /// <returns></returns>
        public string SendXml_GP(string xmlFileName, string C_ZKD_NO)
        {
            try
            {
                string name = "\\4A" + C_ZKD_NO + ".xml";
                xmlFileName += name;
                DataTable zkddt = dal_TRC_ROLL_ZKD.GetListBydh(C_ZKD_NO).Tables[0];
                if (zkddt.Rows.Count == 0)
                {
                    return "PCI转库单表未查询到转库单：" + C_ZKD_NO + "信息！";
                }
                DataRow dtrow = zkddt.Rows[0];

                Mod_TPB_LINEWH yck = dal_TPB_LINEWH.GetModel(dtrow["C_LINEWH_ID"].ToString());//源仓库
                Mod_TPB_LINEWH mbck = dal_TPB_LINEWH.GetModel(dtrow["C_MBLINEWH_ID"].ToString());//目标仓库
                //Mod_TRC_ROLL_PRODCUT mod_TRC_ROLL_PRODCUT = dal_TRC_ROLL_PRODCUT.GetModel();
                string djrq = Convert.ToDateTime(dtrow["D_MOD_DT"].ToString()).ToString("yyyy-MM-dd");
                Mod_TS_USER mod_TS_USER = dal_TS_USER.GetModel(dtrow["C_EMP_ID"].ToString());
                string bmid = dal_TS_DEPT.GetDept(mod_TS_USER.C_ACCOUNT);
                if (bmid == "")
                {
                    return "操作人部门未维护！";
                }
                Mod_TS_DEPT mod_TS_DEPT = dal_TS_DEPT.GetModel(bmid);//获取部门

                XmlDocument xmlDoc = new XmlDocument();
                //创建类型声明节点  
                XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "no");
                xmlDoc.AppendChild(node);

                //创建根节点  
                XmlElement root = xmlDoc.CreateElement("ufinterface");
                #region//给节点属性赋值
                root.SetAttribute("billtype", "4K");
                root.SetAttribute("filename", "ZK4A" + C_ZKD_NO + ".xml");
                root.SetAttribute("isexchange", "Y");
                root.SetAttribute("operation", "req");
                root.SetAttribute("proc", "update");
                root.SetAttribute("receiver", "101");
                root.SetAttribute("replace", "y");
                root.SetAttribute("roottag", "bill");
                root.SetAttribute("sender", "1107");
                #endregion
                xmlDoc.AppendChild(root);

                //创建子根节点
                XmlElement bill = xmlDoc.CreateElement("bill");
                #region//节点属性
                bill.SetAttribute("id", "ZK" + C_ZKD_NO);
                #endregion
                root.AppendChild(bill);

                XmlNode head = xmlDoc.CreateNode(XmlNodeType.Element, "bill_head", null);
                #region //表头_order_head	
                CreateNode(xmlDoc, head, "ctjname", "");
                CreateNode(xmlDoc, head, "bz", "");
                CreateNode(xmlDoc, head, "cbilltypecode", "4K");	//库存单据类型编码
                CreateNode(xmlDoc, head, "cinbsrid", "");
                CreateNode(xmlDoc, head, "cinbsrname", "");
                CreateNode(xmlDoc, head, "cindeptid", mod_TS_DEPT.C_ID);	//入库部门ID
                CreateNode(xmlDoc, head, "cindeptname", mod_TS_DEPT.C_NAME);
                CreateNode(xmlDoc, head, "cinwarehouseid", mbck.C_ID);	//入库仓库ID
                CreateNode(xmlDoc, head, "cinwarehousename", mbck.C_LINEWH_NAME);	//仓库名称
                CreateNode(xmlDoc, head, "isLocatorMgtIn", "0");
                CreateNode(xmlDoc, head, "isWasteWhIn", "0");
                CreateNode(xmlDoc, head, "whreservedptyin", "");
                CreateNode(xmlDoc, head, "islocatormgtin", "0");
                CreateNode(xmlDoc, head, "iswastewhin", "0");
                CreateNode(xmlDoc, head, "whreservedptyin", "");
                CreateNode(xmlDoc, head, "coutbsor", "");
                CreateNode(xmlDoc, head, "coutbsorname", "");
                CreateNode(xmlDoc, head, "coutdeptid", mod_TS_DEPT.C_ID);	//出库部门ID
                CreateNode(xmlDoc, head, "coutdeptname", mod_TS_DEPT.C_NAME);	//出库部门名称
                CreateNode(xmlDoc, head, "coutwarehouseid", yck.C_ID);	//出库仓库ID
                CreateNode(xmlDoc, head, "coutwarehousename", yck.C_LINEWH_NAME);	//仓库名称
                CreateNode(xmlDoc, head, "isLocatorMgtOut", "0");
                CreateNode(xmlDoc, head, "isWasteWhOut", "0");
                CreateNode(xmlDoc, head, "whReservedPtyOut", "");
                CreateNode(xmlDoc, head, "islocatormgtout", "0");
                CreateNode(xmlDoc, head, "iswastewhout", "0");
                CreateNode(xmlDoc, head, "whreservedptyout", "");
                CreateNode(xmlDoc, head, "cshlddiliverdate", djrq);	//单据日期
                CreateNode(xmlDoc, head, "ctj", "");
                CreateNode(xmlDoc, head, "dbilldate", djrq);	//单据日期
                CreateNode(xmlDoc, head, "nfixdisassemblymny", "");	//组装拆卸费用
                CreateNode(xmlDoc, head, "pdfs", "");
                CreateNode(xmlDoc, head, "pk_corp", "1001");	//公司ID
                CreateNode(xmlDoc, head, "vbillcode", C_ZKD_NO);	//单据号
                CreateNode(xmlDoc, head, "vnote", "");	//备注
                CreateNode(xmlDoc, head, "vshldarrivedate", djrq);	//应到货日期
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
                CreateNode(xmlDoc, head, "vuserdef20", "");
                CreateNode(xmlDoc, head, "vuserdef11h", "");
                CreateNode(xmlDoc, head, "vuserdef12h", "");
                CreateNode(xmlDoc, head, "vuserdef13h", "");
                CreateNode(xmlDoc, head, "vuserdef14h", "");
                CreateNode(xmlDoc, head, "vuserdef15h", "");
                CreateNode(xmlDoc, head, "vuserdef16h", "");
                CreateNode(xmlDoc, head, "vuserdef17h", "");
                CreateNode(xmlDoc, head, "vuserdef18h", "");
                CreateNode(xmlDoc, head, "vuserdef19h", "");
                CreateNode(xmlDoc, head, "vuserdef20h", "");
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
                CreateNode(xmlDoc, head, "pk_defdoc1h", "");
                CreateNode(xmlDoc, head, "pk_defdoc2h", "");
                CreateNode(xmlDoc, head, "pk_defdoc3h", "");
                CreateNode(xmlDoc, head, "pk_defdoc4h", "");
                CreateNode(xmlDoc, head, "pk_defdoc5h", "");
                CreateNode(xmlDoc, head, "pk_defdoc6h", "");
                CreateNode(xmlDoc, head, "pk_defdoc7h", "");
                CreateNode(xmlDoc, head, "pk_defdoc8h", "");
                CreateNode(xmlDoc, head, "pk_defdoc9h", "");
                CreateNode(xmlDoc, head, "pk_defdoc10h", "");
                CreateNode(xmlDoc, head, "pk_defdoc11", "");
                CreateNode(xmlDoc, head, "pk_defdoc12", "");
                CreateNode(xmlDoc, head, "pk_defdoc13", "");
                CreateNode(xmlDoc, head, "pk_defdoc14", "");
                CreateNode(xmlDoc, head, "pk_defdoc15", "");
                CreateNode(xmlDoc, head, "pk_defdoc16", "");
                CreateNode(xmlDoc, head, "pk_defdoc17", "");
                CreateNode(xmlDoc, head, "pk_defdoc18", "");
                CreateNode(xmlDoc, head, "pk_defdoc19", "");
                CreateNode(xmlDoc, head, "pk_defdoc20", "");
                CreateNode(xmlDoc, head, "pk_defdoc11h", "");
                CreateNode(xmlDoc, head, "pk_defdoc12h", "");
                CreateNode(xmlDoc, head, "pk_defdoc13h", "");
                CreateNode(xmlDoc, head, "pk_defdoc14h", "");
                CreateNode(xmlDoc, head, "pk_defdoc15h", "");
                CreateNode(xmlDoc, head, "pk_defdoc16h", "");
                CreateNode(xmlDoc, head, "pk_defdoc17h", "");
                CreateNode(xmlDoc, head, "pk_defdoc18h", "");
                CreateNode(xmlDoc, head, "pk_defdoc19h", "");
                CreateNode(xmlDoc, head, "pk_defdoc20h", "");
                CreateNode(xmlDoc, head, "vuserdef1h", "");
                CreateNode(xmlDoc, head, "vuserdef2h", "");
                CreateNode(xmlDoc, head, "vuserdef3h", "");
                CreateNode(xmlDoc, head, "vuserdef4h", "");
                CreateNode(xmlDoc, head, "vuserdef5h", "");
                CreateNode(xmlDoc, head, "vuserdef6h", "");
                CreateNode(xmlDoc, head, "vuserdef7h", "");
                CreateNode(xmlDoc, head, "vuserdef8h", "");
                CreateNode(xmlDoc, head, "vuserdef9h", "");
                CreateNode(xmlDoc, head, "vuserdef10h", "");
                CreateNode(xmlDoc, head, "cauditorid", "");
                CreateNode(xmlDoc, head, "cauditorname", "");
                CreateNode(xmlDoc, head, "coperatorid", mod_TS_USER.C_ID);	//制单人
                CreateNode(xmlDoc, head, "coperatorname", mod_TS_USER.C_NAME);	//制单人名称
                CreateNode(xmlDoc, head, "vadjuster", "");
                CreateNode(xmlDoc, head, "vadjustername", "");
                CreateNode(xmlDoc, head, "coperatoridnow", "");
                CreateNode(xmlDoc, head, "ctjname", "");
                CreateNode(xmlDoc, head, "pk_calbody_in", "1001NC10000000000669");
                CreateNode(xmlDoc, head, "pk_calbody_out", "1001NC10000000000669");
                CreateNode(xmlDoc, head, "vcalbody_inname", "邢钢库存组织");
                CreateNode(xmlDoc, head, "vcalbody_outname", "邢钢库存组织");
                CreateNode(xmlDoc, head, "ts", DateTime.Now.ToString());
                CreateNode(xmlDoc, head, "timestamp", "");	//?
                CreateNode(xmlDoc, head, "headts", DateTime.Now.ToString());
                CreateNode(xmlDoc, head, "isforeignstor_in", "N");
                CreateNode(xmlDoc, head, "isgathersettle_in", "N");
                CreateNode(xmlDoc, head, "isforeignstor_out", "N");
                CreateNode(xmlDoc, head, "isgathersettle_out", "N");
                CreateNode(xmlDoc, head, "icheckmode", "");
                CreateNode(xmlDoc, head, "fassistantflag", "N");	//是否计算期间业务量
                CreateNode(xmlDoc, head, "fbillflag", "");
                CreateNode(xmlDoc, head, "vostatus", "");
                CreateNode(xmlDoc, head, "iprintcount", "");
                CreateNode(xmlDoc, head, "clastmodiid", mod_TS_USER.C_ID);	//最后修改人
                CreateNode(xmlDoc, head, "clastmodiname", mod_TS_USER.C_NAME);	//最后修改人名称
                CreateNode(xmlDoc, head, "tlastmoditime", mod_TS_USER.D_MOD_DT.ToString());	//最后修改时间
                CreateNode(xmlDoc, head, "cnxtbilltypecode", "4A");
                CreateNode(xmlDoc, head, "cspecialhid", "");

                #endregion
                bill.AppendChild(head);
                XmlElement body = xmlDoc.CreateElement("bill_body");
                bill.AppendChild(body);
                int hno = 0;
                foreach (DataRow row in zkddt.Rows)
                {
                    hno++;
                    string zldj = row["C_JUDGE_LEV_ZH"].ToString();
                    if (zldj == "")
                    {
                        zldj = "DP";
                    }
                    Mod_TB_MATRL_MAIN mod_TB_MATRL_MAIN = dal_TB_MATRL_MAIN.GetModel(row["C_MAT_CODE"].ToString());
                    Mod_TQB_CHECKSTATE mod_TQB_CHECKSTATE = dal_TQB_CHECKSTATE.GetModelByName(zldj, "1001");
                    Mod_TRC_ROLL_ZKD mod_TRC_ROLL_ZKD = dal_TRC_ROLL_ZKD.GetModeltran(row["C_ID"].ToString());
                    decimal num = Convert.ToDecimal(mod_TRC_ROLL_ZKD.N_SJNUM == null ? 0 : mod_TRC_ROLL_ZKD.N_SJNUM);
                    decimal wgt = Convert.ToDecimal(mod_TRC_ROLL_ZKD.N_SJWGT == null ? 0 : mod_TRC_ROLL_ZKD.N_SJWGT);
                    XmlNode item = xmlDoc.CreateNode(XmlNodeType.Element, "item", null);
                    #region //表体_item	
                    CreateNode(xmlDoc, item, "csourcetypename", "");
                    CreateNode(xmlDoc, item, "cinvbasid", mod_TB_MATRL_MAIN.C_PK_INVBASDOC);    //来源单据号
                    CreateNode(xmlDoc, item, "pk_invbasdoc", mod_TB_MATRL_MAIN.C_PK_INVBASDOC);
                    CreateNode(xmlDoc, item, "fixedflag", "N");
                    CreateNode(xmlDoc, item, "bgssl", "");
                    CreateNode(xmlDoc, item, "castunitid", mod_TB_MATRL_MAIN.C_FJLDW);  //辅计量单位ID
                    CreateNode(xmlDoc, item, "castunitname", mod_TB_MATRL_MAIN.C_FJLDWMC);
                    CreateNode(xmlDoc, item, "cinventorycode", mod_TB_MATRL_MAIN.C_MAT_CODE);
                    CreateNode(xmlDoc, item, "cinventoryid", mod_TB_MATRL_MAIN.C_PK_INVMANDOC); //存货ID
                    CreateNode(xmlDoc, item, "cinvmanid", mod_TB_MATRL_MAIN.C_PK_INVBASDOC);
                    CreateNode(xmlDoc, item, "isLotMgt", "1");
                    CreateNode(xmlDoc, item, "isSerialMgt", "0");
                    CreateNode(xmlDoc, item, "isValidateMgt", "0");
                    CreateNode(xmlDoc, item, "isAstUOMmgt", "1");
                    CreateNode(xmlDoc, item, "isFreeItemMgt", "1");
                    CreateNode(xmlDoc, item, "isSet", "0");
                    CreateNode(xmlDoc, item, "standStoreUOM", "");
                    CreateNode(xmlDoc, item, "defaultAstUOM", mod_TB_MATRL_MAIN.C_FJLDW);
                    CreateNode(xmlDoc, item, "isSellProxy", "0");
                    CreateNode(xmlDoc, item, "qualityDay", "");
                    CreateNode(xmlDoc, item, "invReservedPty", "");
                    CreateNode(xmlDoc, item, "isSolidConvRate", "0");
                    CreateNode(xmlDoc, item, "islotmgt", "1");
                    CreateNode(xmlDoc, item, "isserialmgt", "0");
                    CreateNode(xmlDoc, item, "isvalidatemgt", "0");
                    CreateNode(xmlDoc, item, "isastuommgt", "1");
                    CreateNode(xmlDoc, item, "isfreeitemmgt", "1");
                    CreateNode(xmlDoc, item, "isset", "0");
                    CreateNode(xmlDoc, item, "standstoreuom", "");
                    CreateNode(xmlDoc, item, "defaultastuom", mod_TB_MATRL_MAIN.C_FJLDW);
                    CreateNode(xmlDoc, item, "issellproxy", "0");
                    CreateNode(xmlDoc, item, "qualityday", "");
                    CreateNode(xmlDoc, item, "invreservedpty", "");
                    CreateNode(xmlDoc, item, "issolidconvrate", "0");
                    CreateNode(xmlDoc, item, "csourcebillbid", "");
                    CreateNode(xmlDoc, item, "csourcebillhid", "");
                    CreateNode(xmlDoc, item, "csourcetype", "");
                    CreateNode(xmlDoc, item, "cspaceid", "");
                    CreateNode(xmlDoc, item, "cspacecode", "");
                    CreateNode(xmlDoc, item, "cspacename", "");
                    CreateNode(xmlDoc, item, "cspecialhid", "");    //？？？
                    CreateNode(xmlDoc, item, "cwarehouseid", "");
                    CreateNode(xmlDoc, item, "cwarehousename", "");
                    CreateNode(xmlDoc, item, "isLocatorMgt", "");
                    CreateNode(xmlDoc, item, "isWasteWh", "");
                    CreateNode(xmlDoc, item, "whreservedpty", "");
                    CreateNode(xmlDoc, item, "islocatormgt", "");
                    CreateNode(xmlDoc, item, "iswastewh", "");
                    CreateNode(xmlDoc, item, "whreservedpty", "");
                    CreateNode(xmlDoc, item, "cyfsl", "");
                    CreateNode(xmlDoc, item, "cysl", "");
                    CreateNode(xmlDoc, item, "desl", "");
                    CreateNode(xmlDoc, item, "dshldtransnum", wgt.ToString());   //应转数量
                    CreateNode(xmlDoc, item, "dvalidate", "");
                    CreateNode(xmlDoc, item, "fbillrowflag", "");
                    CreateNode(xmlDoc, item, "hlzl", "");
                    if (num == 0)
                    {
                        CreateNode(xmlDoc, item, "hsl", "0");   //换算率
                    }
                    else
                    {
                        CreateNode(xmlDoc, item, "hsl", Math.Round(Convert.ToDouble(wgt / num), 6).ToString());   //换算率
                    }
                    CreateNode(xmlDoc, item, "invname", mod_TB_MATRL_MAIN.C_MAT_NAME);  //物料名称
                    CreateNode(xmlDoc, item, "invspec", mod_TRC_ROLL_ZKD.C_SPEC);   //规格
                    CreateNode(xmlDoc, item, "invtype", mod_TRC_ROLL_ZKD.C_STL_GRD);    //钢种
                    CreateNode(xmlDoc, item, "je", "");
                    CreateNode(xmlDoc, item, "jhdj", "");
                    CreateNode(xmlDoc, item, "jhje", "");
                    CreateNode(xmlDoc, item, "jhpdzq", "");
                    CreateNode(xmlDoc, item, "measdocname", mod_TB_MATRL_MAIN.C_ZJLDWMC);   //主计量单位名称
                    CreateNode(xmlDoc, item, "naccountastnum", "");
                    CreateNode(xmlDoc, item, "naccountnum", "");
                    CreateNode(xmlDoc, item, "nadjustastnum", "");
                    CreateNode(xmlDoc, item, "nadjustnum", "");
                    CreateNode(xmlDoc, item, "ncheckastnum", "");
                    CreateNode(xmlDoc, item, "nchecknum", "");
                    CreateNode(xmlDoc, item, "nprice", "");
                    CreateNode(xmlDoc, item, "nmny", "");
                    CreateNode(xmlDoc, item, "nplannedmny", "");    //计划金额
                    CreateNode(xmlDoc, item, "nplannedprice", "");  //计划单价
                    CreateNode(xmlDoc, item, "nshldtransastnum", num.ToString());    //应转辅数量
                    CreateNode(xmlDoc, item, "pk_measdoc", mod_TB_MATRL_MAIN.C_PK_MEASDOC); //主计量单位
                    CreateNode(xmlDoc, item, "scrq", djrq); //生产日期
                    CreateNode(xmlDoc, item, "sjpdzq", "");
                    CreateNode(xmlDoc, item, "vbatchcode", mod_TRC_ROLL_ZKD.C_BATCH_NO);    //批号
                    CreateNode(xmlDoc, item, "vfree0", ""); //？
                    CreateNode(xmlDoc, item, "vfree1", mod_TRC_ROLL_ZKD.C_ZYX1);    //自由项1
                    CreateNode(xmlDoc, item, "vfree2", mod_TRC_ROLL_ZKD.C_ZYX2);    //自由项2
                    CreateNode(xmlDoc, item, "vfree3", mod_TRC_ROLL_ZKD.C_BZYQ);    //包装要求
                    CreateNode(xmlDoc, item, "vfree4", "");
                    CreateNode(xmlDoc, item, "vfree5", "");
                    CreateNode(xmlDoc, item, "vfree6", "");
                    CreateNode(xmlDoc, item, "vfree7", "");
                    CreateNode(xmlDoc, item, "vfree8", "");
                    CreateNode(xmlDoc, item, "vfree9", "");
                    CreateNode(xmlDoc, item, "vfree10", "");
                    CreateNode(xmlDoc, item, "vfreename1", ""); //？
                    CreateNode(xmlDoc, item, "vfreename2", ""); //？
                    CreateNode(xmlDoc, item, "vfreename3", ""); //？
                    CreateNode(xmlDoc, item, "vfreename4", "");
                    CreateNode(xmlDoc, item, "vfreename5", "");
                    CreateNode(xmlDoc, item, "vfreename6", "");
                    CreateNode(xmlDoc, item, "vfreename7", "");
                    CreateNode(xmlDoc, item, "vfreename8", "");
                    CreateNode(xmlDoc, item, "vfreename9", "");
                    CreateNode(xmlDoc, item, "vfreename10", "");
                    CreateNode(xmlDoc, item, "vsourcebillcode", "");
                    CreateNode(xmlDoc, item, "vuserdef1", "");
                    CreateNode(xmlDoc, item, "vuserdef2", "");
                    CreateNode(xmlDoc, item, "vuserdef3", "");
                    CreateNode(xmlDoc, item, "vuserdef4", "");
                    CreateNode(xmlDoc, item, "vuserdef5", "");
                    CreateNode(xmlDoc, item, "vuserdef6", "");
                    CreateNode(xmlDoc, item, "vuserdef7", "");
                    CreateNode(xmlDoc, item, "vuserdef8", "");
                    CreateNode(xmlDoc, item, "vuserdef9", "");
                    CreateNode(xmlDoc, item, "vuserdef10", mod_TRC_ROLL_ZKD.C_ID);  //自定义项
                    CreateNode(xmlDoc, item, "vuserdef11", "");
                    CreateNode(xmlDoc, item, "vuserdef12", "");
                    CreateNode(xmlDoc, item, "vuserdef13", "");
                    CreateNode(xmlDoc, item, "vuserdef14", "");
                    CreateNode(xmlDoc, item, "vuserdef15", "");
                    CreateNode(xmlDoc, item, "vuserdef16", "");
                    CreateNode(xmlDoc, item, "vuserdef17", "");
                    CreateNode(xmlDoc, item, "vuserdef18", "");
                    CreateNode(xmlDoc, item, "vuserdef19", "");
                    CreateNode(xmlDoc, item, "vuserdef20", "");
                    CreateNode(xmlDoc, item, "pk_defdoc1", "");
                    CreateNode(xmlDoc, item, "pk_defdoc2", "");
                    CreateNode(xmlDoc, item, "pk_defdoc3", "");
                    CreateNode(xmlDoc, item, "pk_defdoc4", "");
                    CreateNode(xmlDoc, item, "pk_defdoc5", "");
                    CreateNode(xmlDoc, item, "pk_defdoc6", "");
                    CreateNode(xmlDoc, item, "pk_defdoc7", "");
                    CreateNode(xmlDoc, item, "pk_defdoc8", "");
                    CreateNode(xmlDoc, item, "pk_defdoc9", "");
                    CreateNode(xmlDoc, item, "pk_defdoc10", "");
                    CreateNode(xmlDoc, item, "pk_defdoc11", "");
                    CreateNode(xmlDoc, item, "pk_defdoc12", "");
                    CreateNode(xmlDoc, item, "pk_defdoc13", "");
                    CreateNode(xmlDoc, item, "pk_defdoc14", "");
                    CreateNode(xmlDoc, item, "pk_defdoc15", "");
                    CreateNode(xmlDoc, item, "pk_defdoc16", "");
                    CreateNode(xmlDoc, item, "pk_defdoc17", "");
                    CreateNode(xmlDoc, item, "pk_defdoc18", "");
                    CreateNode(xmlDoc, item, "pk_defdoc19", "");
                    CreateNode(xmlDoc, item, "pk_defdoc20", "");
                    CreateNode(xmlDoc, item, "yy", "");
                    CreateNode(xmlDoc, item, "ztsl", "");
                    CreateNode(xmlDoc, item, "bkxcl", "");
                    CreateNode(xmlDoc, item, "chzl", "");
                    CreateNode(xmlDoc, item, "neconomicnum", "");
                    CreateNode(xmlDoc, item, "nmaxstocknum", "");
                    CreateNode(xmlDoc, item, "nminstocknum", num.ToString());    //？
                    CreateNode(xmlDoc, item, "norderpointnum", wgt.ToString());  //？
                    CreateNode(xmlDoc, item, "xczl", "");
                    CreateNode(xmlDoc, item, "nsafestocknum", "");
                    CreateNode(xmlDoc, item, "fbillflag", "");
                    CreateNode(xmlDoc, item, "vfreeid1", "");   //？
                    CreateNode(xmlDoc, item, "vfreeid2", "");   //？
                    CreateNode(xmlDoc, item, "vfreeid3", "");   //？
                    CreateNode(xmlDoc, item, "vfreeid4", "");
                    CreateNode(xmlDoc, item, "vfreeid5", "");
                    CreateNode(xmlDoc, item, "vfreeid6", "");
                    CreateNode(xmlDoc, item, "vfreeid7", "");
                    CreateNode(xmlDoc, item, "vfreeid8", "");
                    CreateNode(xmlDoc, item, "vfreeid9", "");
                    CreateNode(xmlDoc, item, "vfreeid10", "");
                    CreateNode(xmlDoc, item, "discountflag", "N");
                    CreateNode(xmlDoc, item, "laborflag", "N");
                    CreateNode(xmlDoc, item, "childsnum", "");
                    CreateNode(xmlDoc, item, "invsetparttype", "");
                    CreateNode(xmlDoc, item, "partpercent", "");
                    CreateNode(xmlDoc, item, "vnote", "");
                    CreateNode(xmlDoc, item, "vbodynote", "");
                    CreateNode(xmlDoc, item, "ccorrespondtypename", "");
                    CreateNode(xmlDoc, item, "cfirstbillbid", "");
                    CreateNode(xmlDoc, item, "cfirstbillhid", "");
                    CreateNode(xmlDoc, item, "cfirsttypename", "");
                    CreateNode(xmlDoc, item, "cfirsttype", "");
                    CreateNode(xmlDoc, item, "csourcetypename", "");
                    CreateNode(xmlDoc, item, "pk_calbody", "");
                    CreateNode(xmlDoc, item, "vcalbodyname", "");
                    CreateNode(xmlDoc, item, "ts", DateTime.Now.ToString());    //？
                    CreateNode(xmlDoc, item, "timestamp", "");  //？
                    CreateNode(xmlDoc, item, "bodyts", DateTime.Now.ToString());    //？
                    CreateNode(xmlDoc, item, "crowno", hno.ToString());    //行号???
                    CreateNode(xmlDoc, item, "nperiodastnum", "");  //期间业务辅数量
                    CreateNode(xmlDoc, item, "nperiodnum", ""); //期间业务数量
                    CreateNode(xmlDoc, item, "isforeignstor", "N");
                    CreateNode(xmlDoc, item, "isgathersettle", "N");
                    CreateNode(xmlDoc, item, "csortrowno", "");
                    CreateNode(xmlDoc, item, "cvendorid", "");
                    CreateNode(xmlDoc, item, "cvendorname", "");
                    CreateNode(xmlDoc, item, "pk_cubasdoc", "");
                    CreateNode(xmlDoc, item, "pk_corp", "1001");    //公司ID
                    CreateNode(xmlDoc, item, "tbatchtime", ""); //组坯时间
                    CreateNode(xmlDoc, item, "dproducedate", "");
                    CreateNode(xmlDoc, item, "dvalidate", "");
                    CreateNode(xmlDoc, item, "vvendbatchcode", "");
                    CreateNode(xmlDoc, item, "qualitymanflag", "");
                    CreateNode(xmlDoc, item, "qualitydaynum", "");
                    CreateNode(xmlDoc, item, "cqualitylevelid", mod_TQB_CHECKSTATE.C_ID);   //质量等级主键
                    CreateNode(xmlDoc, item, "vnote", "");
                    CreateNode(xmlDoc, item, "tchecktime", ""); //打牌时间
                    CreateNode(xmlDoc, item, "vdef1", "");
                    CreateNode(xmlDoc, item, "vdef2", "");
                    CreateNode(xmlDoc, item, "vdef3", "");
                    CreateNode(xmlDoc, item, "vdef4", "");
                    CreateNode(xmlDoc, item, "vdef5", "");
                    CreateNode(xmlDoc, item, "vdef6", "");
                    CreateNode(xmlDoc, item, "vdef7", "");
                    CreateNode(xmlDoc, item, "vdef8", "");
                    CreateNode(xmlDoc, item, "vdef9", "");
                    CreateNode(xmlDoc, item, "vdef10", "");
                    CreateNode(xmlDoc, item, "vdef11", "");
                    CreateNode(xmlDoc, item, "vdef12", "");
                    CreateNode(xmlDoc, item, "vdef13", "");
                    CreateNode(xmlDoc, item, "vdef14", "");
                    CreateNode(xmlDoc, item, "vdef15", "");
                    CreateNode(xmlDoc, item, "vdef16", "");
                    CreateNode(xmlDoc, item, "vdef17", "");
                    CreateNode(xmlDoc, item, "vdef18", "");
                    CreateNode(xmlDoc, item, "vdef19", "");
                    CreateNode(xmlDoc, item, "vdef20", "");
                    CreateNode(xmlDoc, item, "naccountgrsnum", "");
                    CreateNode(xmlDoc, item, "ncheckgrsnum", "");
                    CreateNode(xmlDoc, item, "nadjustgrsnum", "");
                    CreateNode(xmlDoc, item, "nshldtransgrsnum", "");
                    CreateNode(xmlDoc, item, "cspecialbid", "");    //？
                    CreateNode(xmlDoc, item, "vbatchcode_temp", "");    //？
                    CreateNode(xmlDoc, item, "cqualitylevelname", zldj); //？
                    CreateNode(xmlDoc, item, "vdef1", "");  //？
                    CreateNode(xmlDoc, item, "vdef2", "");  //？
                    CreateNode(xmlDoc, item, "vdef3", "");  //？
                    #endregion
                    body.AppendChild(item);
                }
                xmlDoc.Save(xmlFileName);
                //List<string> parem = SendNC.SendXML("D:/XML/ZK18091300456044K4A.XML");
                List<string> parem = SendNC.SendXML(xmlFileName);
                //parem.Add(dayplcode);
                //parem.Add(empID);
                //parem.Add("发运单");

                ////日志
                ////AddLog(parem);

                if (parem[0] == "1")
                {
                    return "1";
                }
                else
                {
                    return parem[1];
                }

            }
            catch (Exception ex)
            {
                return ex.ToString();
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

    }
}
