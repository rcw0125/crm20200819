using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Collections;
using System.Collections.Generic;
using NF.MODEL;
using System.Linq;

namespace NF.DAL
{
    /// <summary>
    /// 订单池
    /// </summary>
    public partial class Dal_TMO_ORDER
    {
        public Dal_TMO_ORDER()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMO_CON_ORDER");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMO_ORDER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMO_CON_ORDER(");
            strSql.Append("C_ORDER_NO,C_CON_NO,C_CON_NAME,C_AREA,C_CUST_NO,C_CUST_NAME,C_SALE_CHANNEL,C_CURRENCYTYPEID,C_RECEIPTAREAID,C_RECEIVEADDRESS,C_RECEIPTCORPID,C_PROD_NAME,C_PROD_KIND,C_INVBASDOCID,C_INVENTORYID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,C_TECH_PROT,C_FREE1,C_FREE2,C_PACK,C_STD_CODE,C_DESIGN_NO,C_STDID,C_DESIGNID,C_VDEF1,C_PRO_USE,C_CUST_SQ,C_FUNITID,C_UNITID,N_HSL,N_FNUM,N_WGT,N_PROFIT,N_COST,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,N_ORIGINALCURSUMMNY,D_NEED_DT,D_DELIVERY_DT,D_DT,N_STATUS,N_TYPE,N_FLAG,N_EXEC_STATUS,N_USER_LEV,C_LEV,C_ORDER_LEV,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_SLAB_MATCH_WGT,N_LINE_MATCH_WGT,N_PROD_WGT,N_WARE_WGT,N_WARE_OUT_WGT,N_MACH_WGT,C_ISSUE_EMP_ID,C_PRD_EMP_ID,C_DESIGN_PROG,N_SMS_PROD_WGT,C_SMS_PROD_EMP_ID,D_SMS_PROD_DT,N_ROLL_PROD_WGT,C_ROLL_PROD_EMP_ID,D_STL_ROL_DT,C_LINE_NO,C_CCM_NO,N_ISSUE_WGT,C_RH,C_LF,C_KP,N_HL_TIME,C_HL,N_DFP_HL_TIME,C_DFP_HL,C_XM,C_ROUTE,C_MATRL_CODE_SLAB,C_MATRL_NAME_SLAB,C_SLAB_SIZE,N_SLAB_LENGTH,N_SLAB_PW,C_MATRL_CODE_KP,C_MATRL_NAME_KP,C_KP_SIZE,N_KP_LENGTH,N_KP_PW,N_GROUP,N_SORT,C_XC,C_SL,C_WL,C_SFPJ,C_TRANSMODE,N_MACH_WGT_CCM,C_XGID,N_ZJCLS,C_BY1,C_BY2,C_BY3,C_BY4,C_BY5,C_NC_ID,C_LGJH,C_ZLDJ_ID)");
            strSql.Append(" values (");
            strSql.Append(":C_ORDER_NO,:C_CON_NO,:C_CON_NAME,:C_AREA,:C_CUST_NO,:C_CUST_NAME,:C_SALE_CHANNEL,:C_CURRENCYTYPEID,:C_RECEIPTAREAID,:C_RECEIVEADDRESS,:C_RECEIPTCORPID,:C_PROD_NAME,:C_PROD_KIND,:C_INVBASDOCID,:C_INVENTORYID,:C_MAT_CODE,:C_MAT_NAME,:C_STL_GRD,:C_SPEC,:C_TECH_PROT,:C_FREE1,:C_FREE2,:C_PACK,:C_STD_CODE,:C_DESIGN_NO,:C_STDID,:C_DESIGNID,:C_VDEF1,:C_PRO_USE,:C_CUST_SQ,:C_FUNITID,:C_UNITID,:N_HSL,:N_FNUM,:N_WGT,:N_PROFIT,:N_COST,:N_TAXRATE,:N_ORIGINALCURPRICE,:N_ORIGINALCURTAXPRICE,:N_ORIGINALCURTAXMNY,:N_ORIGINALCURMNY,:N_ORIGINALCURSUMMNY,:D_NEED_DT,:D_DELIVERY_DT,:D_DT,:N_STATUS,:N_TYPE,:N_FLAG,:N_EXEC_STATUS,:N_USER_LEV,:C_LEV,:C_ORDER_LEV,:C_REMARK,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT,:N_SLAB_MATCH_WGT,:N_LINE_MATCH_WGT,:N_PROD_WGT,:N_WARE_WGT,:N_WARE_OUT_WGT,:N_MACH_WGT,:C_ISSUE_EMP_ID,:C_PRD_EMP_ID,:C_DESIGN_PROG,:N_SMS_PROD_WGT,:C_SMS_PROD_EMP_ID,:D_SMS_PROD_DT,:N_ROLL_PROD_WGT,:C_ROLL_PROD_EMP_ID,:D_STL_ROL_DT,:C_LINE_NO,:C_CCM_NO,:N_ISSUE_WGT,:C_RH,:C_LF,:C_KP,:N_HL_TIME,:C_HL,:N_DFP_HL_TIME,:C_DFP_HL,:C_XM,:C_ROUTE,:C_MATRL_CODE_SLAB,:C_MATRL_NAME_SLAB,:C_SLAB_SIZE,:N_SLAB_LENGTH,:N_SLAB_PW,:C_MATRL_CODE_KP,:C_MATRL_NAME_KP,:C_KP_SIZE,:N_KP_LENGTH,:N_KP_PW,:N_GROUP,:N_SORT,:C_XC,:C_SL,:C_WL,:C_SFPJ,:C_TRANSMODE,:N_MACH_WGT_CCM,:C_XGID,:N_ZJCLS,:C_BY1,:C_BY2,:C_BY3,:C_BY4,:C_BY5,:C_NC_ID,:C_LGJH,:C_ZLDJ_ID)");
            OracleParameter[] parameters = {

                    new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SALE_CHANNEL", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CURRENCYTYPEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RECEIPTAREAID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RECEIVEADDRESS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RECEIPTCORPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_KIND", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_INVBASDOCID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_INVENTORYID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TECH_PROT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FREE1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FREE2", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PACK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DESIGN_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STDID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DESIGNID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_VDEF1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRO_USE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_SQ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FUNITID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_UNITID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_HSL", OracleDbType.Decimal,15),
                    new OracleParameter(":N_FNUM", OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_PROFIT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_COST", OracleDbType.Decimal,15),
                    new OracleParameter(":N_TAXRATE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURTAXPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURTAXMNY", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURMNY", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURSUMMNY", OracleDbType.Decimal,15),
                    new OracleParameter(":D_NEED_DT", OracleDbType.Date),
                    new OracleParameter(":D_DELIVERY_DT", OracleDbType.Date),
                    new OracleParameter(":D_DT", OracleDbType.Date),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,2),
                    new OracleParameter(":N_TYPE", OracleDbType.Decimal,2),
                    new OracleParameter(":N_FLAG", OracleDbType.Decimal,2),
                    new OracleParameter(":N_EXEC_STATUS", OracleDbType.Decimal,2),
                    new OracleParameter(":N_USER_LEV", OracleDbType.Decimal,2),
                    new OracleParameter(":C_LEV", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORDER_LEV", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":N_SLAB_MATCH_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_LINE_MATCH_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_PROD_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_WARE_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_WARE_OUT_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_MACH_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_ISSUE_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRD_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DESIGN_PROG", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_SMS_PROD_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_SMS_PROD_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_SMS_PROD_DT", OracleDbType.Date),
                    new OracleParameter(":N_ROLL_PROD_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_ROLL_PROD_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_STL_ROL_DT", OracleDbType.Date),
                    new OracleParameter(":C_LINE_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CCM_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_ISSUE_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_RH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LF", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_KP", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_HL_TIME", OracleDbType.Decimal,10),
                    new OracleParameter(":C_HL", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_DFP_HL_TIME", OracleDbType.Decimal,10),
                    new OracleParameter(":C_DFP_HL", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_XM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ROUTE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MATRL_CODE_SLAB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MATRL_NAME_SLAB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SLAB_SIZE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_SLAB_LENGTH", OracleDbType.Decimal,15),
                    new OracleParameter(":N_SLAB_PW", OracleDbType.Decimal,15),
                    new OracleParameter(":C_MATRL_CODE_KP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MATRL_NAME_KP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_KP_SIZE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_KP_LENGTH", OracleDbType.Decimal,15),
                    new OracleParameter(":N_KP_PW", OracleDbType.Decimal,15),
                    new OracleParameter(":N_GROUP", OracleDbType.Decimal,4),
                    new OracleParameter(":N_SORT", OracleDbType.Decimal,4),
                    new OracleParameter(":C_XC", OracleDbType.Varchar2,10),
                    new OracleParameter(":C_SL", OracleDbType.Varchar2,10),
                    new OracleParameter(":C_WL", OracleDbType.Varchar2,10),
                    new OracleParameter(":C_SFPJ", OracleDbType.Varchar2,10),
                    new OracleParameter(":C_TRANSMODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_MACH_WGT_CCM", OracleDbType.Decimal,15),
                    new OracleParameter(":C_XGID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_ZJCLS", OracleDbType.Decimal,4),
                    new OracleParameter(":C_BY1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BY2", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BY3", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BY4", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BY5", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NC_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LGJH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZLDJ_ID", OracleDbType.Varchar2,100)};

            parameters[0].Value = model.C_ORDER_NO;
            parameters[1].Value = model.C_CON_NO;
            parameters[2].Value = model.C_CON_NAME;
            parameters[3].Value = model.C_AREA;
            parameters[4].Value = model.C_CUST_NO;
            parameters[5].Value = model.C_CUST_NAME;
            parameters[6].Value = model.C_SALE_CHANNEL;
            parameters[7].Value = model.C_CURRENCYTYPEID;
            parameters[8].Value = model.C_RECEIPTAREAID;
            parameters[9].Value = model.C_RECEIVEADDRESS;
            parameters[10].Value = model.C_RECEIPTCORPID;
            parameters[11].Value = model.C_PROD_NAME;
            parameters[12].Value = model.C_PROD_KIND;
            parameters[13].Value = model.C_INVBASDOCID;
            parameters[14].Value = model.C_INVENTORYID;
            parameters[15].Value = model.C_MAT_CODE;
            parameters[16].Value = model.C_MAT_NAME;
            parameters[17].Value = model.C_STL_GRD;
            parameters[18].Value = model.C_SPEC;
            parameters[19].Value = model.C_TECH_PROT;
            parameters[20].Value = model.C_FREE1;
            parameters[21].Value = model.C_FREE2;
            parameters[22].Value = model.C_PACK;
            parameters[23].Value = model.C_STD_CODE;
            parameters[24].Value = model.C_DESIGN_NO;
            parameters[25].Value = model.C_STDID;
            parameters[26].Value = model.C_DESIGNID;
            parameters[27].Value = model.C_VDEF1;
            parameters[28].Value = model.C_PRO_USE;
            parameters[29].Value = model.C_CUST_SQ;
            parameters[30].Value = model.C_FUNITID;
            parameters[31].Value = model.C_UNITID;
            parameters[32].Value = model.N_HSL;
            parameters[33].Value = model.N_FNUM;
            parameters[34].Value = model.N_WGT;
            parameters[35].Value = model.N_PROFIT;
            parameters[36].Value = model.N_COST;
            parameters[37].Value = model.N_TAXRATE;
            parameters[38].Value = model.N_ORIGINALCURPRICE;
            parameters[39].Value = model.N_ORIGINALCURTAXPRICE;
            parameters[40].Value = model.N_ORIGINALCURTAXMNY;
            parameters[41].Value = model.N_ORIGINALCURMNY;
            parameters[42].Value = model.N_ORIGINALCURSUMMNY;
            parameters[43].Value = model.D_NEED_DT;
            parameters[44].Value = model.D_DELIVERY_DT;
            parameters[45].Value = model.D_DT;
            parameters[46].Value = model.N_STATUS;
            parameters[47].Value = model.N_TYPE;
            parameters[48].Value = model.N_FLAG;
            parameters[49].Value = model.N_EXEC_STATUS;
            parameters[50].Value = model.N_USER_LEV;
            parameters[51].Value = model.C_LEV;
            parameters[52].Value = model.C_ORDER_LEV;
            parameters[53].Value = model.C_REMARK;
            parameters[54].Value = model.C_EMP_ID;
            parameters[55].Value = model.C_EMP_NAME;
            parameters[56].Value = model.D_MOD_DT;
            parameters[57].Value = model.N_SLAB_MATCH_WGT;
            parameters[58].Value = model.N_LINE_MATCH_WGT;
            parameters[59].Value = model.N_PROD_WGT;
            parameters[60].Value = model.N_WARE_WGT;
            parameters[61].Value = model.N_WARE_OUT_WGT;
            parameters[62].Value = model.N_MACH_WGT;
            parameters[63].Value = model.C_ISSUE_EMP_ID;
            parameters[64].Value = model.C_PRD_EMP_ID;
            parameters[65].Value = model.C_DESIGN_PROG;
            parameters[66].Value = model.N_SMS_PROD_WGT;
            parameters[67].Value = model.C_SMS_PROD_EMP_ID;
            parameters[68].Value = model.D_SMS_PROD_DT;
            parameters[69].Value = model.N_ROLL_PROD_WGT;
            parameters[70].Value = model.C_ROLL_PROD_EMP_ID;
            parameters[71].Value = model.D_STL_ROL_DT;
            parameters[72].Value = model.C_LINE_NO;
            parameters[73].Value = model.C_CCM_NO;
            parameters[74].Value = model.N_ISSUE_WGT;
            parameters[75].Value = model.C_RH;
            parameters[76].Value = model.C_LF;
            parameters[77].Value = model.C_KP;
            parameters[78].Value = model.N_HL_TIME;
            parameters[79].Value = model.C_HL;
            parameters[80].Value = model.N_DFP_HL_TIME;
            parameters[81].Value = model.C_DFP_HL;
            parameters[82].Value = model.C_XM;
            parameters[83].Value = model.C_ROUTE;
            parameters[84].Value = model.C_MATRL_CODE_SLAB;
            parameters[85].Value = model.C_MATRL_NAME_SLAB;
            parameters[86].Value = model.C_SLAB_SIZE;
            parameters[87].Value = model.N_SLAB_LENGTH;
            parameters[88].Value = model.N_SLAB_PW;
            parameters[89].Value = model.C_MATRL_CODE_KP;
            parameters[90].Value = model.C_MATRL_NAME_KP;
            parameters[91].Value = model.C_KP_SIZE;
            parameters[92].Value = model.N_KP_LENGTH;
            parameters[93].Value = model.N_KP_PW;
            parameters[94].Value = model.N_GROUP;
            parameters[95].Value = model.N_SORT;
            parameters[96].Value = model.C_XC;
            parameters[97].Value = model.C_SL;
            parameters[98].Value = model.C_WL;
            parameters[99].Value = model.C_SFPJ;
            parameters[100].Value = model.C_TRANSMODE;
            parameters[101].Value = model.N_MACH_WGT_CCM;
            parameters[102].Value = model.C_XGID;
            parameters[103].Value = model.N_ZJCLS;
            parameters[104].Value = model.C_BY1;
            parameters[105].Value = model.C_BY2;
            parameters[106].Value = model.C_BY3;
            parameters[107].Value = model.C_BY4;
            parameters[108].Value = model.C_BY5;
            parameters[109].Value = model.C_NC_ID;
            parameters[110].Value = model.C_LGJH;
            parameters[111].Value = model.C_ZLDJ_ID;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMO_ORDER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMO_CON_ORDER set ");
            strSql.Append("C_ORDER_NO=:C_ORDER_NO,");
            strSql.Append("C_CON_NO=:C_CON_NO,");
            strSql.Append("C_CON_NAME=:C_CON_NAME,");
            strSql.Append("C_AREA=:C_AREA,");
            strSql.Append("C_CUST_NO=:C_CUST_NO,");
            strSql.Append("C_CUST_NAME=:C_CUST_NAME,");
            strSql.Append("C_SALE_CHANNEL=:C_SALE_CHANNEL,");
            strSql.Append("C_CURRENCYTYPEID=:C_CURRENCYTYPEID,");
            strSql.Append("C_RECEIPTAREAID=:C_RECEIPTAREAID,");
            strSql.Append("C_RECEIVEADDRESS=:C_RECEIVEADDRESS,");
            strSql.Append("C_RECEIPTCORPID=:C_RECEIPTCORPID,");
            strSql.Append("C_PROD_NAME=:C_PROD_NAME,");
            strSql.Append("C_PROD_KIND=:C_PROD_KIND,");
            strSql.Append("C_INVBASDOCID=:C_INVBASDOCID,");
            strSql.Append("C_INVENTORYID=:C_INVENTORYID,");
            strSql.Append("C_MAT_CODE=:C_MAT_CODE,");
            strSql.Append("C_MAT_NAME=:C_MAT_NAME,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_SPEC=:C_SPEC,");
            strSql.Append("C_TECH_PROT=:C_TECH_PROT,");
            strSql.Append("C_FREE1=:C_FREE1,");
            strSql.Append("C_FREE2=:C_FREE2,");
            strSql.Append("C_PACK=:C_PACK,");
            strSql.Append("C_STD_CODE=:C_STD_CODE,");
            strSql.Append("C_DESIGN_NO=:C_DESIGN_NO,");
            strSql.Append("C_STDID=:C_STDID,");
            strSql.Append("C_DESIGNID=:C_DESIGNID,");
            strSql.Append("C_VDEF1=:C_VDEF1,");
            strSql.Append("C_PRO_USE=:C_PRO_USE,");
            strSql.Append("C_CUST_SQ=:C_CUST_SQ,");
            strSql.Append("C_FUNITID=:C_FUNITID,");
            strSql.Append("C_UNITID=:C_UNITID,");
            strSql.Append("N_HSL=:N_HSL,");
            strSql.Append("N_FNUM=:N_FNUM,");
            strSql.Append("N_WGT=:N_WGT,");
            strSql.Append("N_PROFIT=:N_PROFIT,");
            strSql.Append("N_COST=:N_COST,");
            strSql.Append("N_TAXRATE=:N_TAXRATE,");
            strSql.Append("N_ORIGINALCURPRICE=:N_ORIGINALCURPRICE,");
            strSql.Append("N_ORIGINALCURTAXPRICE=:N_ORIGINALCURTAXPRICE,");
            strSql.Append("N_ORIGINALCURTAXMNY=:N_ORIGINALCURTAXMNY,");
            strSql.Append("N_ORIGINALCURMNY=:N_ORIGINALCURMNY,");
            strSql.Append("N_ORIGINALCURSUMMNY=:N_ORIGINALCURSUMMNY,");
            strSql.Append("D_NEED_DT=:D_NEED_DT,");
            strSql.Append("D_DELIVERY_DT=:D_DELIVERY_DT,");
            strSql.Append("D_DT=:D_DT,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("N_TYPE=:N_TYPE,");
            strSql.Append("N_FLAG=:N_FLAG,");
            strSql.Append("N_EXEC_STATUS=:N_EXEC_STATUS,");
            strSql.Append("N_USER_LEV=:N_USER_LEV,");
            strSql.Append("C_LEV=:C_LEV,");
            strSql.Append("C_ORDER_LEV=:C_ORDER_LEV,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("N_SLAB_MATCH_WGT=:N_SLAB_MATCH_WGT,");
            strSql.Append("N_LINE_MATCH_WGT=:N_LINE_MATCH_WGT,");
            strSql.Append("N_PROD_WGT=:N_PROD_WGT,");
            strSql.Append("N_WARE_WGT=:N_WARE_WGT,");
            strSql.Append("N_WARE_OUT_WGT=:N_WARE_OUT_WGT,");
            strSql.Append("N_MACH_WGT=:N_MACH_WGT,");
            strSql.Append("C_ISSUE_EMP_ID=:C_ISSUE_EMP_ID,");
            strSql.Append("C_PRD_EMP_ID=:C_PRD_EMP_ID,");
            strSql.Append("C_DESIGN_PROG=:C_DESIGN_PROG,");
            strSql.Append("N_SMS_PROD_WGT=:N_SMS_PROD_WGT,");
            strSql.Append("C_SMS_PROD_EMP_ID=:C_SMS_PROD_EMP_ID,");
            strSql.Append("D_SMS_PROD_DT=:D_SMS_PROD_DT,");
            strSql.Append("N_ROLL_PROD_WGT=:N_ROLL_PROD_WGT,");
            strSql.Append("C_ROLL_PROD_EMP_ID=:C_ROLL_PROD_EMP_ID,");
            strSql.Append("D_STL_ROL_DT=:D_STL_ROL_DT,");
            strSql.Append("C_LINE_NO=:C_LINE_NO,");
            strSql.Append("C_CCM_NO=:C_CCM_NO,");
            strSql.Append("N_ISSUE_WGT=:N_ISSUE_WGT,");
            strSql.Append("C_RH=:C_RH,");
            strSql.Append("C_LF=:C_LF,");
            strSql.Append("C_KP=:C_KP,");
            strSql.Append("N_HL_TIME=:N_HL_TIME,");
            strSql.Append("C_HL=:C_HL,");
            strSql.Append("N_DFP_HL_TIME=:N_DFP_HL_TIME,");
            strSql.Append("C_DFP_HL=:C_DFP_HL,");
            strSql.Append("C_XM=:C_XM,");
            strSql.Append("C_ROUTE=:C_ROUTE,");
            strSql.Append("C_MATRL_CODE_SLAB=:C_MATRL_CODE_SLAB,");
            strSql.Append("C_MATRL_NAME_SLAB=:C_MATRL_NAME_SLAB,");
            strSql.Append("C_SLAB_SIZE=:C_SLAB_SIZE,");
            strSql.Append("N_SLAB_LENGTH=:N_SLAB_LENGTH,");
            strSql.Append("N_SLAB_PW=:N_SLAB_PW,");
            strSql.Append("C_MATRL_CODE_KP=:C_MATRL_CODE_KP,");
            strSql.Append("C_MATRL_NAME_KP=:C_MATRL_NAME_KP,");
            strSql.Append("C_KP_SIZE=:C_KP_SIZE,");
            strSql.Append("N_KP_LENGTH=:N_KP_LENGTH,");
            strSql.Append("N_KP_PW=:N_KP_PW,");
            strSql.Append("N_GROUP=:N_GROUP,");
            strSql.Append("N_SORT=:N_SORT,");
            strSql.Append("C_XC=:C_XC,");
            strSql.Append("C_SL=:C_SL,");
            strSql.Append("C_WL=:C_WL,");
            strSql.Append("C_SFPJ=:C_SFPJ,");
            strSql.Append("C_TRANSMODE=:C_TRANSMODE,");
            strSql.Append("N_MACH_WGT_CCM=:N_MACH_WGT_CCM,");
            strSql.Append("C_XGID=:C_XGID,");
            strSql.Append("N_ZJCLS=:N_ZJCLS,");
            strSql.Append("C_BY1=:C_BY1,");
            strSql.Append("C_BY2=:C_BY2,");
            strSql.Append("C_BY3=:C_BY3,");
            strSql.Append("C_BY4=:C_BY4,");
            strSql.Append("C_BY5=:C_BY5,");
            strSql.Append("C_NC_ID=:C_NC_ID,");
            strSql.Append("C_LGJH=:C_LGJH,");
            strSql.Append("C_ZLDJ_ID=:C_ZLDJ_ID");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SALE_CHANNEL", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CURRENCYTYPEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RECEIPTAREAID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RECEIVEADDRESS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RECEIPTCORPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_KIND", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_INVBASDOCID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_INVENTORYID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TECH_PROT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FREE1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FREE2", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PACK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DESIGN_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STDID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DESIGNID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_VDEF1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRO_USE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_SQ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FUNITID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_UNITID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_HSL", OracleDbType.Decimal,15),
                    new OracleParameter(":N_FNUM", OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_PROFIT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_COST", OracleDbType.Decimal,15),
                    new OracleParameter(":N_TAXRATE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURTAXPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURTAXMNY", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURMNY", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURSUMMNY", OracleDbType.Decimal,15),
                    new OracleParameter(":D_NEED_DT", OracleDbType.Date),
                    new OracleParameter(":D_DELIVERY_DT", OracleDbType.Date),
                    new OracleParameter(":D_DT", OracleDbType.Date),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,2),
                    new OracleParameter(":N_TYPE", OracleDbType.Decimal,2),
                    new OracleParameter(":N_FLAG", OracleDbType.Decimal,2),
                    new OracleParameter(":N_EXEC_STATUS", OracleDbType.Decimal,2),
                    new OracleParameter(":N_USER_LEV", OracleDbType.Decimal,2),
                    new OracleParameter(":C_LEV", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORDER_LEV", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":N_SLAB_MATCH_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_LINE_MATCH_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_PROD_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_WARE_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_WARE_OUT_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_MACH_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_ISSUE_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRD_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DESIGN_PROG", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_SMS_PROD_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_SMS_PROD_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_SMS_PROD_DT", OracleDbType.Date),
                    new OracleParameter(":N_ROLL_PROD_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_ROLL_PROD_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_STL_ROL_DT", OracleDbType.Date),
                    new OracleParameter(":C_LINE_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CCM_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_ISSUE_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_RH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LF", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_KP", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_HL_TIME", OracleDbType.Decimal,10),
                    new OracleParameter(":C_HL", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_DFP_HL_TIME", OracleDbType.Decimal,10),
                    new OracleParameter(":C_DFP_HL", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_XM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ROUTE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MATRL_CODE_SLAB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MATRL_NAME_SLAB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SLAB_SIZE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_SLAB_LENGTH", OracleDbType.Decimal,15),
                    new OracleParameter(":N_SLAB_PW", OracleDbType.Decimal,15),
                    new OracleParameter(":C_MATRL_CODE_KP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MATRL_NAME_KP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_KP_SIZE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_KP_LENGTH", OracleDbType.Decimal,15),
                    new OracleParameter(":N_KP_PW", OracleDbType.Decimal,15),
                    new OracleParameter(":N_GROUP", OracleDbType.Decimal,4),
                    new OracleParameter(":N_SORT", OracleDbType.Decimal,4),
                    new OracleParameter(":C_XC", OracleDbType.Varchar2,10),
                    new OracleParameter(":C_SL", OracleDbType.Varchar2,10),
                    new OracleParameter(":C_WL", OracleDbType.Varchar2,10),
                    new OracleParameter(":C_SFPJ", OracleDbType.Varchar2,10),
                    new OracleParameter(":C_TRANSMODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_MACH_WGT_CCM", OracleDbType.Decimal,15),
                    new OracleParameter(":C_XGID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_ZJCLS", OracleDbType.Decimal,4),
                    new OracleParameter(":C_BY1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BY2", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BY3", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BY4", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BY5", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NC_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LGJH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZLDJ_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_ORDER_NO;
            parameters[1].Value = model.C_CON_NO;
            parameters[2].Value = model.C_CON_NAME;
            parameters[3].Value = model.C_AREA;
            parameters[4].Value = model.C_CUST_NO;
            parameters[5].Value = model.C_CUST_NAME;
            parameters[6].Value = model.C_SALE_CHANNEL;
            parameters[7].Value = model.C_CURRENCYTYPEID;
            parameters[8].Value = model.C_RECEIPTAREAID;
            parameters[9].Value = model.C_RECEIVEADDRESS;
            parameters[10].Value = model.C_RECEIPTCORPID;
            parameters[11].Value = model.C_PROD_NAME;
            parameters[12].Value = model.C_PROD_KIND;
            parameters[13].Value = model.C_INVBASDOCID;
            parameters[14].Value = model.C_INVENTORYID;
            parameters[15].Value = model.C_MAT_CODE;
            parameters[16].Value = model.C_MAT_NAME;
            parameters[17].Value = model.C_STL_GRD;
            parameters[18].Value = model.C_SPEC;
            parameters[19].Value = model.C_TECH_PROT;
            parameters[20].Value = model.C_FREE1;
            parameters[21].Value = model.C_FREE2;
            parameters[22].Value = model.C_PACK;
            parameters[23].Value = model.C_STD_CODE;
            parameters[24].Value = model.C_DESIGN_NO;
            parameters[25].Value = model.C_STDID;
            parameters[26].Value = model.C_DESIGNID;
            parameters[27].Value = model.C_VDEF1;
            parameters[28].Value = model.C_PRO_USE;
            parameters[29].Value = model.C_CUST_SQ;
            parameters[30].Value = model.C_FUNITID;
            parameters[31].Value = model.C_UNITID;
            parameters[32].Value = model.N_HSL;
            parameters[33].Value = model.N_FNUM;
            parameters[34].Value = model.N_WGT;
            parameters[35].Value = model.N_PROFIT;
            parameters[36].Value = model.N_COST;
            parameters[37].Value = model.N_TAXRATE;
            parameters[38].Value = model.N_ORIGINALCURPRICE;
            parameters[39].Value = model.N_ORIGINALCURTAXPRICE;
            parameters[40].Value = model.N_ORIGINALCURTAXMNY;
            parameters[41].Value = model.N_ORIGINALCURMNY;
            parameters[42].Value = model.N_ORIGINALCURSUMMNY;
            parameters[43].Value = model.D_NEED_DT;
            parameters[44].Value = model.D_DELIVERY_DT;
            parameters[45].Value = model.D_DT;
            parameters[46].Value = model.N_STATUS;
            parameters[47].Value = model.N_TYPE;
            parameters[48].Value = model.N_FLAG;
            parameters[49].Value = model.N_EXEC_STATUS;
            parameters[50].Value = model.N_USER_LEV;
            parameters[51].Value = model.C_LEV;
            parameters[52].Value = model.C_ORDER_LEV;
            parameters[53].Value = model.C_REMARK;
            parameters[54].Value = model.C_EMP_ID;
            parameters[55].Value = model.C_EMP_NAME;
            parameters[56].Value = model.D_MOD_DT;
            parameters[57].Value = model.N_SLAB_MATCH_WGT;
            parameters[58].Value = model.N_LINE_MATCH_WGT;
            parameters[59].Value = model.N_PROD_WGT;
            parameters[60].Value = model.N_WARE_WGT;
            parameters[61].Value = model.N_WARE_OUT_WGT;
            parameters[62].Value = model.N_MACH_WGT;
            parameters[63].Value = model.C_ISSUE_EMP_ID;
            parameters[64].Value = model.C_PRD_EMP_ID;
            parameters[65].Value = model.C_DESIGN_PROG;
            parameters[66].Value = model.N_SMS_PROD_WGT;
            parameters[67].Value = model.C_SMS_PROD_EMP_ID;
            parameters[68].Value = model.D_SMS_PROD_DT;
            parameters[69].Value = model.N_ROLL_PROD_WGT;
            parameters[70].Value = model.C_ROLL_PROD_EMP_ID;
            parameters[71].Value = model.D_STL_ROL_DT;
            parameters[72].Value = model.C_LINE_NO;
            parameters[73].Value = model.C_CCM_NO;
            parameters[74].Value = model.N_ISSUE_WGT;
            parameters[75].Value = model.C_RH;
            parameters[76].Value = model.C_LF;
            parameters[77].Value = model.C_KP;
            parameters[78].Value = model.N_HL_TIME;
            parameters[79].Value = model.C_HL;
            parameters[80].Value = model.N_DFP_HL_TIME;
            parameters[81].Value = model.C_DFP_HL;
            parameters[82].Value = model.C_XM;
            parameters[83].Value = model.C_ROUTE;
            parameters[84].Value = model.C_MATRL_CODE_SLAB;
            parameters[85].Value = model.C_MATRL_NAME_SLAB;
            parameters[86].Value = model.C_SLAB_SIZE;
            parameters[87].Value = model.N_SLAB_LENGTH;
            parameters[88].Value = model.N_SLAB_PW;
            parameters[89].Value = model.C_MATRL_CODE_KP;
            parameters[90].Value = model.C_MATRL_NAME_KP;
            parameters[91].Value = model.C_KP_SIZE;
            parameters[92].Value = model.N_KP_LENGTH;
            parameters[93].Value = model.N_KP_PW;
            parameters[94].Value = model.N_GROUP;
            parameters[95].Value = model.N_SORT;
            parameters[96].Value = model.C_XC;
            parameters[97].Value = model.C_SL;
            parameters[98].Value = model.C_WL;
            parameters[99].Value = model.C_SFPJ;
            parameters[100].Value = model.C_TRANSMODE;
            parameters[101].Value = model.N_MACH_WGT_CCM;
            parameters[102].Value = model.C_XGID;
            parameters[103].Value = model.N_ZJCLS;
            parameters[104].Value = model.C_BY1;
            parameters[105].Value = model.C_BY2;
            parameters[106].Value = model.C_BY3;
            parameters[107].Value = model.C_BY4;
            parameters[108].Value = model.C_BY5;
            parameters[109].Value = model.C_NC_ID;
            parameters[110].Value = model.C_LGJH;
            parameters[111].Value = model.C_ZLDJ_ID;
            parameters[112].Value = model.C_ID;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TMO_CON_ORDER ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string C_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TMO_ORDER ");
            strSql.Append(" where C_ID in (" + C_IDlist + ")  ");
            int rows = DbHelperOra.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMO_ORDER GetModel_OrderNO(string C_ORDER_NO)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_ORDER_NO,C_CON_NO,C_CON_NAME,C_AREA,C_CUST_NO,C_CUST_NAME,C_SALE_CHANNEL,C_CURRENCYTYPEID,C_RECEIPTAREAID,C_RECEIVEADDRESS,C_RECEIPTCORPID,C_PROD_NAME,C_PROD_KIND,C_INVBASDOCID,C_INVENTORYID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,C_TECH_PROT,C_FREE1,C_FREE2,C_PACK,C_STD_CODE,C_DESIGN_NO,C_STDID,C_DESIGNID,C_VDEF1,C_PRO_USE,C_CUST_SQ,C_FUNITID,C_UNITID,N_HSL,CEIL(N_FNUM)AS N_FNUM,N_WGT,N_PROFIT,N_COST,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,N_ORIGINALCURSUMMNY,D_NEED_DT,D_DELIVERY_DT,D_DT,N_STATUS,N_TYPE,N_FLAG,N_EXEC_STATUS,N_USER_LEV,C_LEV,C_ORDER_LEV,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_SLAB_MATCH_WGT,N_LINE_MATCH_WGT,N_PROD_WGT,N_WARE_WGT,N_WARE_OUT_WGT,N_MACH_WGT,C_ISSUE_EMP_ID,C_PRD_EMP_ID,C_DESIGN_PROG,N_SMS_PROD_WGT,C_SMS_PROD_EMP_ID,D_SMS_PROD_DT,N_ROLL_PROD_WGT,C_ROLL_PROD_EMP_ID,D_STL_ROL_DT,C_LINE_NO,C_CCM_NO,N_ISSUE_WGT,C_RH,C_LF,C_KP,N_HL_TIME,C_HL,N_DFP_HL_TIME,C_DFP_HL,C_XM,C_ROUTE,C_MATRL_CODE_SLAB,C_MATRL_NAME_SLAB,C_SLAB_SIZE,N_SLAB_LENGTH,N_SLAB_PW,C_MATRL_CODE_KP,C_MATRL_NAME_KP,C_KP_SIZE,N_KP_LENGTH,N_KP_PW,N_GROUP,N_SORT,C_XC,C_SL,C_WL,C_SFPJ,C_TRANSMODE,N_MACH_WGT_CCM,C_XGID,N_ZJCLS,C_BY1,C_BY2,C_BY3,C_BY4,C_BY5,C_NC_ID,C_LGJH,C_ZLDJ_ID,C_ZL_ID,C_LF_ID,C_RH_ID,N_SLAB_WIDTH,N_SLAB_THICK,N_DIAMETER,D_NC_DATE,C_YWY,C_NC_SALECODE from TMO_CON_ORDER ");

            strSql.Append(" where C_ORDER_NO=:C_ORDER_NO ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ORDER_NO;

            Mod_TMO_ORDER model = new Mod_TMO_ORDER();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMO_ORDER GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_ORDER_NO,C_CON_NO,C_CON_NAME,C_AREA,C_CUST_NO,C_CUST_NAME,C_SALE_CHANNEL,C_CURRENCYTYPEID,C_RECEIPTAREAID,C_RECEIVEADDRESS,C_RECEIPTCORPID,C_PROD_NAME,C_PROD_KIND,C_INVBASDOCID,C_INVENTORYID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,C_TECH_PROT,C_FREE1,C_FREE2,C_PACK,C_STD_CODE,C_DESIGN_NO,C_STDID,C_DESIGNID,C_VDEF1,C_PRO_USE,C_CUST_SQ,C_FUNITID,C_UNITID,N_HSL,CEIL(N_FNUM)AS N_FNUM,N_WGT,N_PROFIT,N_COST,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,N_ORIGINALCURSUMMNY,D_NEED_DT,D_DELIVERY_DT,D_DT,N_STATUS,N_TYPE,N_FLAG,N_EXEC_STATUS,N_USER_LEV,C_LEV,C_ORDER_LEV,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_SLAB_MATCH_WGT,N_LINE_MATCH_WGT,N_PROD_WGT,N_WARE_WGT,N_WARE_OUT_WGT,N_MACH_WGT,C_ISSUE_EMP_ID,C_PRD_EMP_ID,C_DESIGN_PROG,N_SMS_PROD_WGT,C_SMS_PROD_EMP_ID,D_SMS_PROD_DT,N_ROLL_PROD_WGT,C_ROLL_PROD_EMP_ID,D_STL_ROL_DT,C_LINE_NO,C_CCM_NO,N_ISSUE_WGT,C_RH,C_LF,C_KP,N_HL_TIME,C_HL,N_DFP_HL_TIME,C_DFP_HL,C_XM,C_ROUTE,C_MATRL_CODE_SLAB,C_MATRL_NAME_SLAB,C_SLAB_SIZE,N_SLAB_LENGTH,N_SLAB_PW,C_MATRL_CODE_KP,C_MATRL_NAME_KP,C_KP_SIZE,N_KP_LENGTH,N_KP_PW,N_GROUP,N_SORT,C_XC,C_SL,C_WL,C_SFPJ,C_TRANSMODE,N_MACH_WGT_CCM,C_XGID,N_ZJCLS,C_BY1,C_BY2,C_BY3,C_BY4,C_BY5,C_NC_ID,C_LGJH,C_ZLDJ_ID,C_ZL_ID,C_LF_ID,C_RH_ID,N_SLAB_WIDTH,N_SLAB_THICK,N_DIAMETER,D_NC_DATE,C_YWY,C_NC_SALECODE from TMO_CON_ORDER ");

            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            Mod_TMO_ORDER model = new Mod_TMO_ORDER();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMO_ORDER DataRowToModel(DataRow row)
        {
            Mod_TMO_ORDER model = new Mod_TMO_ORDER();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_ORDER_NO"] != null)
                {
                    model.C_ORDER_NO = row["C_ORDER_NO"].ToString();
                }
                if (row["C_CON_NO"] != null)
                {
                    model.C_CON_NO = row["C_CON_NO"].ToString();
                }
                if (row["C_CON_NAME"] != null)
                {
                    model.C_CON_NAME = row["C_CON_NAME"].ToString();
                }
                if (row["C_AREA"] != null)
                {
                    model.C_AREA = row["C_AREA"].ToString();
                }
                if (row["C_CUST_NO"] != null)
                {
                    model.C_CUST_NO = row["C_CUST_NO"].ToString();
                }
                if (row["C_CUST_NAME"] != null)
                {
                    model.C_CUST_NAME = row["C_CUST_NAME"].ToString();
                }
                if (row["C_SALE_CHANNEL"] != null)
                {
                    model.C_SALE_CHANNEL = row["C_SALE_CHANNEL"].ToString();
                }
                if (row["C_CURRENCYTYPEID"] != null)
                {
                    model.C_CURRENCYTYPEID = row["C_CURRENCYTYPEID"].ToString();
                }
                if (row["C_RECEIPTAREAID"] != null)
                {
                    model.C_RECEIPTAREAID = row["C_RECEIPTAREAID"].ToString();
                }
                if (row["C_RECEIVEADDRESS"] != null)
                {
                    model.C_RECEIVEADDRESS = row["C_RECEIVEADDRESS"].ToString();
                }
                if (row["C_RECEIPTCORPID"] != null)
                {
                    model.C_RECEIPTCORPID = row["C_RECEIPTCORPID"].ToString();
                }
                if (row["C_PROD_NAME"] != null)
                {
                    model.C_PROD_NAME = row["C_PROD_NAME"].ToString();
                }
                if (row["C_PROD_KIND"] != null)
                {
                    model.C_PROD_KIND = row["C_PROD_KIND"].ToString();
                }
                if (row["C_INVBASDOCID"] != null)
                {
                    model.C_INVBASDOCID = row["C_INVBASDOCID"].ToString();
                }
                if (row["C_INVENTORYID"] != null)
                {
                    model.C_INVENTORYID = row["C_INVENTORYID"].ToString();
                }
                if (row["C_MAT_CODE"] != null)
                {
                    model.C_MAT_CODE = row["C_MAT_CODE"].ToString();
                }
                if (row["C_MAT_NAME"] != null)
                {
                    model.C_MAT_NAME = row["C_MAT_NAME"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_SPEC"] != null)
                {
                    model.C_SPEC = row["C_SPEC"].ToString();
                }
                if (row["C_TECH_PROT"] != null)
                {
                    model.C_TECH_PROT = row["C_TECH_PROT"].ToString();
                }
                if (row["C_FREE1"] != null)
                {
                    model.C_FREE1 = row["C_FREE1"].ToString();
                }
                if (row["C_FREE2"] != null)
                {
                    model.C_FREE2 = row["C_FREE2"].ToString();
                }
                if (row["C_PACK"] != null)
                {
                    model.C_PACK = row["C_PACK"].ToString();
                }
                if (row["C_STD_CODE"] != null)
                {
                    model.C_STD_CODE = row["C_STD_CODE"].ToString();
                }
                if (row["C_DESIGN_NO"] != null)
                {
                    model.C_DESIGN_NO = row["C_DESIGN_NO"].ToString();
                }
                if (row["C_STDID"] != null)
                {
                    model.C_STDID = row["C_STDID"].ToString();
                }
                if (row["C_DESIGNID"] != null)
                {
                    model.C_DESIGNID = row["C_DESIGNID"].ToString();
                }
                if (row["C_VDEF1"] != null)
                {
                    model.C_VDEF1 = row["C_VDEF1"].ToString();
                }
                if (row["C_PRO_USE"] != null)
                {
                    model.C_PRO_USE = row["C_PRO_USE"].ToString();
                }
                if (row["C_CUST_SQ"] != null)
                {
                    model.C_CUST_SQ = row["C_CUST_SQ"].ToString();
                }
                if (row["C_FUNITID"] != null)
                {
                    model.C_FUNITID = row["C_FUNITID"].ToString();
                }
                if (row["C_UNITID"] != null)
                {
                    model.C_UNITID = row["C_UNITID"].ToString();
                }
                if (row["N_HSL"] != null && row["N_HSL"].ToString() != "")
                {
                    model.N_HSL = decimal.Parse(row["N_HSL"].ToString());
                }
                if (row["N_FNUM"] != null && row["N_FNUM"].ToString() != "")
                {
                    model.N_FNUM = decimal.Parse(row["N_FNUM"].ToString());
                }
                if (row["N_WGT"] != null && row["N_WGT"].ToString() != "")
                {
                    model.N_WGT = decimal.Parse(row["N_WGT"].ToString());
                }
                if (row["N_PROFIT"] != null && row["N_PROFIT"].ToString() != "")
                {
                    model.N_PROFIT = decimal.Parse(row["N_PROFIT"].ToString());
                }
                if (row["N_COST"] != null && row["N_COST"].ToString() != "")
                {
                    model.N_COST = decimal.Parse(row["N_COST"].ToString());
                }
                if (row["N_TAXRATE"] != null && row["N_TAXRATE"].ToString() != "")
                {
                    model.N_TAXRATE = decimal.Parse(row["N_TAXRATE"].ToString());
                }
                if (row["N_ORIGINALCURPRICE"] != null && row["N_ORIGINALCURPRICE"].ToString() != "")
                {
                    model.N_ORIGINALCURPRICE = decimal.Parse(row["N_ORIGINALCURPRICE"].ToString());
                }
                if (row["N_ORIGINALCURTAXPRICE"] != null && row["N_ORIGINALCURTAXPRICE"].ToString() != "")
                {
                    model.N_ORIGINALCURTAXPRICE = decimal.Parse(row["N_ORIGINALCURTAXPRICE"].ToString());
                }
                if (row["N_ORIGINALCURTAXMNY"] != null && row["N_ORIGINALCURTAXMNY"].ToString() != "")
                {
                    model.N_ORIGINALCURTAXMNY = decimal.Parse(row["N_ORIGINALCURTAXMNY"].ToString());
                }
                if (row["N_ORIGINALCURMNY"] != null && row["N_ORIGINALCURMNY"].ToString() != "")
                {
                    model.N_ORIGINALCURMNY = decimal.Parse(row["N_ORIGINALCURMNY"].ToString());
                }
                if (row["N_ORIGINALCURSUMMNY"] != null && row["N_ORIGINALCURSUMMNY"].ToString() != "")
                {
                    model.N_ORIGINALCURSUMMNY = decimal.Parse(row["N_ORIGINALCURSUMMNY"].ToString());
                }
                if (row["D_NEED_DT"] != null && row["D_NEED_DT"].ToString() != "")
                {
                    model.D_NEED_DT = DateTime.Parse(row["D_NEED_DT"].ToString());
                }
                if (row["D_DELIVERY_DT"] != null && row["D_DELIVERY_DT"].ToString() != "")
                {
                    model.D_DELIVERY_DT = DateTime.Parse(row["D_DELIVERY_DT"].ToString());
                }
                if (row["D_DT"] != null && row["D_DT"].ToString() != "")
                {
                    model.D_DT = DateTime.Parse(row["D_DT"].ToString());
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["N_TYPE"] != null && row["N_TYPE"].ToString() != "")
                {
                    model.N_TYPE = decimal.Parse(row["N_TYPE"].ToString());
                }
                if (row["N_FLAG"] != null && row["N_FLAG"].ToString() != "")
                {
                    model.N_FLAG = decimal.Parse(row["N_FLAG"].ToString());
                }
                if (row["N_EXEC_STATUS"] != null && row["N_EXEC_STATUS"].ToString() != "")
                {
                    model.N_EXEC_STATUS = decimal.Parse(row["N_EXEC_STATUS"].ToString());
                }
                if (row["N_USER_LEV"] != null && row["N_USER_LEV"].ToString() != "")
                {
                    model.N_USER_LEV = decimal.Parse(row["N_USER_LEV"].ToString());
                }
                if (row["C_LEV"] != null)
                {
                    model.C_LEV = row["C_LEV"].ToString();
                }
                if (row["C_ORDER_LEV"] != null)
                {
                    model.C_ORDER_LEV = row["C_ORDER_LEV"].ToString();
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["C_EMP_NAME"] != null)
                {
                    model.C_EMP_NAME = row["C_EMP_NAME"].ToString();
                }
                if (row["D_MOD_DT"] != null && row["D_MOD_DT"].ToString() != "")
                {
                    model.D_MOD_DT = DateTime.Parse(row["D_MOD_DT"].ToString());
                }
                if (row["N_SLAB_MATCH_WGT"] != null && row["N_SLAB_MATCH_WGT"].ToString() != "")
                {
                    model.N_SLAB_MATCH_WGT = decimal.Parse(row["N_SLAB_MATCH_WGT"].ToString());
                }
                if (row["N_LINE_MATCH_WGT"] != null && row["N_LINE_MATCH_WGT"].ToString() != "")
                {
                    model.N_LINE_MATCH_WGT = decimal.Parse(row["N_LINE_MATCH_WGT"].ToString());
                }
                if (row["N_PROD_WGT"] != null && row["N_PROD_WGT"].ToString() != "")
                {
                    model.N_PROD_WGT = decimal.Parse(row["N_PROD_WGT"].ToString());
                }
                if (row["N_WARE_WGT"] != null && row["N_WARE_WGT"].ToString() != "")
                {
                    model.N_WARE_WGT = decimal.Parse(row["N_WARE_WGT"].ToString());
                }
                if (row["N_WARE_OUT_WGT"] != null && row["N_WARE_OUT_WGT"].ToString() != "")
                {
                    model.N_WARE_OUT_WGT = decimal.Parse(row["N_WARE_OUT_WGT"].ToString());
                }
                if (row["N_MACH_WGT"] != null && row["N_MACH_WGT"].ToString() != "")
                {
                    model.N_MACH_WGT = decimal.Parse(row["N_MACH_WGT"].ToString());
                }
                if (row["C_ISSUE_EMP_ID"] != null)
                {
                    model.C_ISSUE_EMP_ID = row["C_ISSUE_EMP_ID"].ToString();
                }
                if (row["C_PRD_EMP_ID"] != null)
                {
                    model.C_PRD_EMP_ID = row["C_PRD_EMP_ID"].ToString();
                }
                if (row["C_DESIGN_PROG"] != null)
                {
                    model.C_DESIGN_PROG = row["C_DESIGN_PROG"].ToString();
                }
                if (row["N_SMS_PROD_WGT"] != null && row["N_SMS_PROD_WGT"].ToString() != "")
                {
                    model.N_SMS_PROD_WGT = decimal.Parse(row["N_SMS_PROD_WGT"].ToString());
                }
                if (row["C_SMS_PROD_EMP_ID"] != null)
                {
                    model.C_SMS_PROD_EMP_ID = row["C_SMS_PROD_EMP_ID"].ToString();
                }
                if (row["D_SMS_PROD_DT"] != null && row["D_SMS_PROD_DT"].ToString() != "")
                {
                    model.D_SMS_PROD_DT = DateTime.Parse(row["D_SMS_PROD_DT"].ToString());
                }
                if (row["N_ROLL_PROD_WGT"] != null && row["N_ROLL_PROD_WGT"].ToString() != "")
                {
                    model.N_ROLL_PROD_WGT = decimal.Parse(row["N_ROLL_PROD_WGT"].ToString());
                }
                if (row["C_ROLL_PROD_EMP_ID"] != null)
                {
                    model.C_ROLL_PROD_EMP_ID = row["C_ROLL_PROD_EMP_ID"].ToString();
                }
                if (row["D_STL_ROL_DT"] != null && row["D_STL_ROL_DT"].ToString() != "")
                {
                    model.D_STL_ROL_DT = DateTime.Parse(row["D_STL_ROL_DT"].ToString());
                }
                if (row["C_LINE_NO"] != null)
                {
                    model.C_LINE_NO = row["C_LINE_NO"].ToString();
                }
                if (row["C_CCM_NO"] != null)
                {
                    model.C_CCM_NO = row["C_CCM_NO"].ToString();
                }
                if (row["N_ISSUE_WGT"] != null && row["N_ISSUE_WGT"].ToString() != "")
                {
                    model.N_ISSUE_WGT = decimal.Parse(row["N_ISSUE_WGT"].ToString());
                }
                if (row["C_RH"] != null)
                {
                    model.C_RH = row["C_RH"].ToString();
                }
                if (row["C_LF"] != null)
                {
                    model.C_LF = row["C_LF"].ToString();
                }
                if (row["C_KP"] != null)
                {
                    model.C_KP = row["C_KP"].ToString();
                }
                if (row["N_HL_TIME"] != null && row["N_HL_TIME"].ToString() != "")
                {
                    model.N_HL_TIME = decimal.Parse(row["N_HL_TIME"].ToString());
                }
                if (row["C_HL"] != null)
                {
                    model.C_HL = row["C_HL"].ToString();
                }
                if (row["N_DFP_HL_TIME"] != null && row["N_DFP_HL_TIME"].ToString() != "")
                {
                    model.N_DFP_HL_TIME = decimal.Parse(row["N_DFP_HL_TIME"].ToString());
                }
                if (row["C_DFP_HL"] != null)
                {
                    model.C_DFP_HL = row["C_DFP_HL"].ToString();
                }
                if (row["C_XM"] != null)
                {
                    model.C_XM = row["C_XM"].ToString();
                }
                if (row["C_ROUTE"] != null)
                {
                    model.C_ROUTE = row["C_ROUTE"].ToString();
                }
                if (row["C_MATRL_CODE_SLAB"] != null)
                {
                    model.C_MATRL_CODE_SLAB = row["C_MATRL_CODE_SLAB"].ToString();
                }
                if (row["C_MATRL_NAME_SLAB"] != null)
                {
                    model.C_MATRL_NAME_SLAB = row["C_MATRL_NAME_SLAB"].ToString();
                }
                if (row["C_SLAB_SIZE"] != null)
                {
                    model.C_SLAB_SIZE = row["C_SLAB_SIZE"].ToString();
                }
                if (row["N_SLAB_LENGTH"] != null && row["N_SLAB_LENGTH"].ToString() != "")
                {
                    model.N_SLAB_LENGTH = decimal.Parse(row["N_SLAB_LENGTH"].ToString());
                }
                if (row["N_SLAB_PW"] != null && row["N_SLAB_PW"].ToString() != "")
                {
                    model.N_SLAB_PW = decimal.Parse(row["N_SLAB_PW"].ToString());
                }
                if (row["C_MATRL_CODE_KP"] != null)
                {
                    model.C_MATRL_CODE_KP = row["C_MATRL_CODE_KP"].ToString();
                }
                if (row["C_MATRL_NAME_KP"] != null)
                {
                    model.C_MATRL_NAME_KP = row["C_MATRL_NAME_KP"].ToString();
                }
                if (row["C_KP_SIZE"] != null)
                {
                    model.C_KP_SIZE = row["C_KP_SIZE"].ToString();
                }
                if (row["N_KP_LENGTH"] != null && row["N_KP_LENGTH"].ToString() != "")
                {
                    model.N_KP_LENGTH = decimal.Parse(row["N_KP_LENGTH"].ToString());
                }
                if (row["N_KP_PW"] != null && row["N_KP_PW"].ToString() != "")
                {
                    model.N_KP_PW = decimal.Parse(row["N_KP_PW"].ToString());
                }
                if (row["N_GROUP"] != null && row["N_GROUP"].ToString() != "")
                {
                    model.N_GROUP = decimal.Parse(row["N_GROUP"].ToString());
                }
                if (row["N_SORT"] != null && row["N_SORT"].ToString() != "")
                {
                    model.N_SORT = decimal.Parse(row["N_SORT"].ToString());
                }
                if (row["C_XC"] != null)
                {
                    model.C_XC = row["C_XC"].ToString();
                }
                if (row["C_SL"] != null)
                {
                    model.C_SL = row["C_SL"].ToString();
                }
                if (row["C_WL"] != null)
                {
                    model.C_WL = row["C_WL"].ToString();
                }
                if (row["C_SFPJ"] != null)
                {
                    model.C_SFPJ = row["C_SFPJ"].ToString();
                }
                if (row["C_TRANSMODE"] != null)
                {
                    model.C_TRANSMODE = row["C_TRANSMODE"].ToString();
                }
                if (row["N_MACH_WGT_CCM"] != null && row["N_MACH_WGT_CCM"].ToString() != "")
                {
                    model.N_MACH_WGT_CCM = decimal.Parse(row["N_MACH_WGT_CCM"].ToString());
                }
                if (row["C_XGID"] != null)
                {
                    model.C_XGID = row["C_XGID"].ToString();
                }
                if (row["N_ZJCLS"] != null && row["N_ZJCLS"].ToString() != "")
                {
                    model.N_ZJCLS = decimal.Parse(row["N_ZJCLS"].ToString());
                }
                if (row["C_BY1"] != null)
                {
                    model.C_BY1 = row["C_BY1"].ToString();
                }
                if (row["C_BY2"] != null)
                {
                    model.C_BY2 = row["C_BY2"].ToString();
                }
                if (row["C_BY3"] != null)
                {
                    model.C_BY3 = row["C_BY3"].ToString();
                }
                if (row["C_BY4"] != null)
                {
                    model.C_BY4 = row["C_BY4"].ToString();
                }
                if (row["C_BY5"] != null)
                {
                    model.C_BY5 = row["C_BY5"].ToString();
                }
                if (row["C_NC_ID"] != null)
                {
                    model.C_NC_ID = row["C_NC_ID"].ToString();
                }
                if (row["C_LGJH"] != null)
                {
                    model.C_LGJH = row["C_LGJH"].ToString();
                }
                if (row["C_ZLDJ_ID"] != null)
                {
                    model.C_ZLDJ_ID = row["C_ZLDJ_ID"].ToString();
                }
                if (row["C_ZL_ID"] != null)
                {
                    model.C_ZL_ID = row["C_ZL_ID"].ToString();
                }
                if (row["C_LF_ID"] != null)
                {
                    model.C_LF_ID = row["C_LF_ID"].ToString();
                }
                if (row["C_RH_ID"] != null)
                {
                    model.C_RH_ID = row["C_RH_ID"].ToString();
                }
                if (row["N_SLAB_WIDTH"] != null && row["N_SLAB_WIDTH"].ToString() != "")
                {
                    model.N_SLAB_WIDTH = decimal.Parse(row["N_SLAB_WIDTH"].ToString());
                }
                if (row["N_SLAB_THICK"] != null && row["N_SLAB_THICK"].ToString() != "")
                {
                    model.N_SLAB_THICK = decimal.Parse(row["N_SLAB_THICK"].ToString());
                }
                if (row["N_DIAMETER"] != null && row["N_DIAMETER"].ToString() != "")
                {
                    model.N_DIAMETER = decimal.Parse(row["N_DIAMETER"].ToString());
                }
                if (row["D_NC_DATE"] != null && row["D_NC_DATE"].ToString() != "")
                {
                    model.D_NC_DATE = DateTime.Parse(row["D_NC_DATE"].ToString());
                }
                if (row["C_YWY"] != null)
                {
                    model.C_YWY = row["C_YWY"].ToString();
                }
                if (row["C_NC_SALECODE"] != null)
                {
                    model.C_NC_SALECODE = row["C_NC_SALECODE"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_ORDER_NO,C_CON_NO,C_CON_NAME,C_AREA,C_CUST_NO,C_CUST_NAME,C_SALE_CHANNEL,C_CURRENCYTYPEID,C_RECEIPTAREAID,C_RECEIVEADDRESS,C_RECEIPTCORPID,C_PROD_NAME,C_PROD_KIND,C_INVBASDOCID,C_INVENTORYID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,C_TECH_PROT,C_FREE1,C_FREE2,C_PACK,C_STD_CODE,C_DESIGN_NO,C_STDID,C_DESIGNID,C_VDEF1,C_PRO_USE,C_CUST_SQ,C_FUNITID,C_UNITID,N_HSL,N_FNUM,N_WGT,N_PROFIT,N_COST,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,N_ORIGINALCURSUMMNY,D_NEED_DT,D_DELIVERY_DT,D_DT,N_STATUS,N_TYPE,N_FLAG,N_EXEC_STATUS,N_USER_LEV,C_LEV,C_ORDER_LEV,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_SLAB_MATCH_WGT,N_LINE_MATCH_WGT,N_PROD_WGT,N_WARE_WGT,N_WARE_OUT_WGT,N_MACH_WGT,C_ISSUE_EMP_ID,C_PRD_EMP_ID,C_DESIGN_PROG,N_SMS_PROD_WGT,C_SMS_PROD_EMP_ID,D_SMS_PROD_DT,N_ROLL_PROD_WGT,C_ROLL_PROD_EMP_ID,D_STL_ROL_DT,C_LINE_NO,C_CCM_NO,N_ISSUE_WGT,C_RH,C_LF,C_KP,N_HL_TIME,C_HL,N_DFP_HL_TIME,C_DFP_HL,C_XM,C_ROUTE,C_MATRL_CODE_SLAB,C_MATRL_NAME_SLAB,C_SLAB_SIZE,N_SLAB_LENGTH,N_SLAB_PW,C_MATRL_CODE_KP,C_MATRL_NAME_KP,C_KP_SIZE,N_KP_LENGTH,N_KP_PW,N_GROUP,N_SORT,C_XC,C_SL,C_WL,C_SFPJ,C_TRANSMODE,N_MACH_WGT_CCM,C_XGID,N_ZJCLS,C_BY1,C_BY2,C_BY3,C_BY4,C_BY5,C_NC_ID,C_LGJH,C_ZLDJ_ID ");
            strSql.Append(" FROM TMO_CON_ORDER ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TMO_CON_ORDER ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.C_ID desc");
            }
            strSql.Append(")AS Row, T.*  from TMO_CON_ORDER T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion  BasicMethod

        #region //自定义方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMO_ORDER GetOrderModel(string C_ORDER_NO)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_ORDER_NO,C_CON_NO,C_CON_NAME,C_AREA,C_CUST_NO,C_CUST_NAME,C_SALE_CHANNEL,C_CURRENCYTYPEID,C_RECEIPTAREAID,C_RECEIVEADDRESS,C_RECEIPTCORPID,C_PROD_NAME,C_PROD_KIND,C_INVBASDOCID,C_INVENTORYID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,C_TECH_PROT,C_FREE1,C_FREE2,C_PACK,C_STD_CODE,C_DESIGN_NO,C_STDID,C_DESIGNID,C_VDEF1,C_PRO_USE,C_CUST_SQ,C_FUNITID,C_UNITID,N_HSL,CEIL(N_FNUM)AS N_FNUM,N_WGT,N_PROFIT,N_COST,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,N_ORIGINALCURSUMMNY,D_NEED_DT,D_DELIVERY_DT,D_DT,N_STATUS,N_TYPE,N_FLAG,N_EXEC_STATUS,N_USER_LEV,C_LEV,C_ORDER_LEV,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_SLAB_MATCH_WGT,N_LINE_MATCH_WGT,N_PROD_WGT,N_WARE_WGT,N_WARE_OUT_WGT,N_MACH_WGT,C_ISSUE_EMP_ID,C_PRD_EMP_ID,C_DESIGN_PROG,N_SMS_PROD_WGT,C_SMS_PROD_EMP_ID,D_SMS_PROD_DT,N_ROLL_PROD_WGT,C_ROLL_PROD_EMP_ID,D_STL_ROL_DT,C_LINE_NO,C_CCM_NO,N_ISSUE_WGT,C_RH,C_LF,C_KP,N_HL_TIME,C_HL,N_DFP_HL_TIME,C_DFP_HL,C_XM,C_ROUTE,C_MATRL_CODE_SLAB,C_MATRL_NAME_SLAB,C_SLAB_SIZE,N_SLAB_LENGTH,N_SLAB_PW,C_MATRL_CODE_KP,C_MATRL_NAME_KP,C_KP_SIZE,N_KP_LENGTH,N_KP_PW,N_GROUP,N_SORT,C_XC,C_SL,C_WL,C_SFPJ,C_TRANSMODE,N_MACH_WGT_CCM,C_XGID,N_ZJCLS,C_BY1,C_BY2,C_BY3,C_BY4,C_BY5,C_NC_ID,C_LGJH,C_ZLDJ_ID,C_ZL_ID,C_LF_ID,C_RH_ID,N_SLAB_WIDTH,N_SLAB_THICK,N_DIAMETER,D_NC_DATE,C_YWY,C_NC_SALECODE from TMO_CON_ORDER ");

            strSql.Append(" where C_ORDER_NO=:C_ORDER_NO ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ORDER_NO;

            Mod_TMO_ORDER model = new Mod_TMO_ORDER();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMO_ORDER GetOrderModel_Plan(string C_ORDER_NO)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_ORDER_NO,C_CON_NO,C_CON_NAME,C_AREA,C_CUST_NO,C_CUST_NAME,C_SALE_CHANNEL,C_CURRENCYTYPEID,C_RECEIPTAREAID,C_RECEIVEADDRESS,C_RECEIPTCORPID,C_PROD_NAME,C_PROD_KIND,C_INVBASDOCID,C_INVENTORYID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,C_TECH_PROT,C_FREE1,C_FREE2,C_PACK,C_STD_CODE,C_DESIGN_NO,C_STDID,C_DESIGNID,C_VDEF1,C_PRO_USE,C_CUST_SQ,C_FUNITID,C_UNITID,N_HSL,CEIL(N_FNUM)AS N_FNUM,N_WGT,N_PROFIT,N_COST,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,N_ORIGINALCURSUMMNY,D_NEED_DT,D_DELIVERY_DT,D_DT,N_STATUS,N_TYPE,N_FLAG,N_EXEC_STATUS,N_USER_LEV,C_LEV,C_ORDER_LEV,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_SLAB_MATCH_WGT,N_LINE_MATCH_WGT,N_PROD_WGT,N_WARE_WGT,N_WARE_OUT_WGT,N_MACH_WGT,C_ISSUE_EMP_ID,C_PRD_EMP_ID,C_DESIGN_PROG,N_SMS_PROD_WGT,C_SMS_PROD_EMP_ID,D_SMS_PROD_DT,N_ROLL_PROD_WGT,C_ROLL_PROD_EMP_ID,D_STL_ROL_DT,C_LINE_NO,C_CCM_NO,N_ISSUE_WGT,C_RH,C_LF,C_KP,N_HL_TIME,C_HL,N_DFP_HL_TIME,C_DFP_HL,C_XM,C_ROUTE,C_MATRL_CODE_SLAB,C_MATRL_NAME_SLAB,C_SLAB_SIZE,N_SLAB_LENGTH,N_SLAB_PW,C_MATRL_CODE_KP,C_MATRL_NAME_KP,C_KP_SIZE,N_KP_LENGTH,N_KP_PW,N_GROUP,N_SORT,C_XC,C_SL,C_WL,C_SFPJ,C_TRANSMODE,N_MACH_WGT_CCM,C_XGID,N_ZJCLS,C_BY1,C_BY2,C_BY3,C_BY4,C_BY5,C_NC_ID,C_LGJH,C_ZLDJ_ID,C_ZL_ID,C_LF_ID,C_RH_ID,N_SLAB_WIDTH,N_SLAB_THICK,N_DIAMETER,D_NC_DATE,C_YWY,C_NC_SALECODE from TMO_ORDER ");

            strSql.Append(" where C_ORDER_NO=:C_ORDER_NO ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ORDER_NO;

            Mod_TMO_ORDER model = new Mod_TMO_ORDER();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获取单行数据
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public DataRow GetRowOrder(string orderNo, string orderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_ORDER_NO,C_CON_NO,C_CON_NAME,C_AREA,C_CUST_NO,C_CUST_NAME,C_SALE_CHANNEL,C_CURRENCYTYPEID,C_RECEIPTAREAID,C_RECEIVEADDRESS,C_RECEIPTCORPID,C_PROD_NAME,C_PROD_KIND,C_INVBASDOCID,C_INVENTORYID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,C_TECH_PROT,C_FREE1,C_FREE2,C_PACK,C_STD_CODE,C_DESIGN_NO,C_STDID,C_DESIGNID,C_VDEF1,C_PRO_USE,C_CUST_SQ,C_FUNITID,C_UNITID,N_HSL,N_FNUM,N_WGT,N_PROFIT,N_COST,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,N_ORIGINALCURSUMMNY,D_NEED_DT,D_DELIVERY_DT,D_DT,N_STATUS,N_TYPE,N_FLAG,N_EXEC_STATUS,N_USER_LEV,C_LEV,C_ORDER_LEV,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_SLAB_MATCH_WGT,N_LINE_MATCH_WGT,N_PROD_WGT,N_WARE_WGT,N_WARE_OUT_WGT,N_MACH_WGT,C_ISSUE_EMP_ID,C_PRD_EMP_ID,C_DESIGN_PROG,N_SMS_PROD_WGT,C_SMS_PROD_EMP_ID,D_SMS_PROD_DT,N_ROLL_PROD_WGT,C_ROLL_PROD_EMP_ID,D_STL_ROL_DT,C_LINE_NO,C_CCM_NO,N_ISSUE_WGT,C_RH,C_LF,C_KP,N_HL_TIME,C_HL,N_DFP_HL_TIME,C_DFP_HL,C_XM,C_ROUTE,C_MATRL_CODE_SLAB,C_MATRL_NAME_SLAB,C_SLAB_SIZE,N_SLAB_LENGTH,N_SLAB_PW,C_MATRL_CODE_KP,C_MATRL_NAME_KP,C_KP_SIZE,N_KP_LENGTH,N_KP_PW,N_GROUP,N_SORT,C_XC,C_SL,C_WL,C_SFPJ,C_TRANSMODE,N_MACH_WGT_CCM,C_XGID,N_ZJCLS,C_BY1,C_BY2,C_BY3,C_BY4,C_BY5,C_NC_ID,C_LGJH,C_ZLDJ_ID ");
            strSql.Append(" FROM TMO_CON_ORDER where 1=1");
            if (!string.IsNullOrEmpty(orderNo))
            {
                strSql.Append(" and C_ORDER_NO='" + orderNo + "'");
            }
            if (!string.IsNullOrEmpty(orderID))
            {
                strSql.Append(" and C_ID='" + orderID + "'");
            }
            return DbHelperOra.GetDataRow(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetConOrderList(string conNo, string orderNo, string stlGrd, string start, string end, string custNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_ORDER_NO,C_CON_NO,C_CON_NAME,C_AREA,C_CUST_NO,C_CUST_NAME,C_SALE_CHANNEL,C_CURRENCYTYPEID,C_RECEIPTAREAID,C_RECEIVEADDRESS,C_RECEIPTCORPID,C_PROD_NAME,C_PROD_KIND,C_INVBASDOCID,C_INVENTORYID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,C_TECH_PROT,C_FREE1,C_FREE2,C_PACK,C_STD_CODE,C_DESIGN_NO,C_STDID,C_DESIGNID,C_VDEF1,C_PRO_USE,C_CUST_SQ,C_FUNITID,C_UNITID,N_HSL,N_FNUM,N_WGT,N_PROFIT,N_COST,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,N_ORIGINALCURSUMMNY,D_NEED_DT,D_DELIVERY_DT,D_DT,N_STATUS,N_TYPE,N_FLAG,N_EXEC_STATUS,N_USER_LEV,C_LEV,C_ORDER_LEV,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_SLAB_MATCH_WGT,N_LINE_MATCH_WGT,N_PROD_WGT,N_WARE_WGT,N_WARE_OUT_WGT,N_MACH_WGT,C_ISSUE_EMP_ID,C_PRD_EMP_ID,C_DESIGN_PROG,N_SMS_PROD_WGT,C_SMS_PROD_EMP_ID,D_SMS_PROD_DT,N_ROLL_PROD_WGT,C_ROLL_PROD_EMP_ID,D_STL_ROL_DT,C_LINE_NO,C_CCM_NO,N_ISSUE_WGT,C_RH,C_LF,C_KP,N_HL_TIME,C_HL,N_DFP_HL_TIME,C_DFP_HL,C_XM,C_ROUTE,C_MATRL_CODE_SLAB,C_MATRL_NAME_SLAB,C_SLAB_SIZE,N_SLAB_LENGTH,N_SLAB_PW,C_MATRL_CODE_KP,C_MATRL_NAME_KP,C_KP_SIZE,N_KP_LENGTH,N_KP_PW,N_GROUP,N_SORT,C_XC,C_SL,C_WL,C_SFPJ,C_TRANSMODE,N_MACH_WGT_CCM,C_XGID,N_ZJCLS,C_BY1,C_BY2,C_BY3,C_BY4,C_BY5,C_NC_ID,C_LGJH,C_ZLDJ_ID,C_ORDER_NO_OLD,C_STL_GRD_CLASS,C_SFJK  ");
            strSql.Append(" FROM TMO_CON_ORDER where 1=1");
            if (!string.IsNullOrEmpty(custNO))
            {
                strSql.Append(" and C_CUST_NO='" + custNO + "'");
            }
            if (!string.IsNullOrEmpty(conNo))
            {
                strSql.Append(" and C_CON_NO  = '" + conNo + "'");
            }
            if (!string.IsNullOrEmpty(orderNo))
            {
                strSql.Append(" and C_ORDER_NO='" + orderNo + "'");
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.Append(" and UPPER(C_STL_GRD) like '%" + stlGrd.ToUpper() + "%'");
            }
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                strSql.Append(" and D_DT between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }


            strSql.Append(" order by D_DT,C_MAT_NAME,C_STL_GRD,C_SPEC");
            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 日计划订单
        /// </summary>
        /// <param name="custName">客户名称</param>
        /// <param name="conno">合同号</param>
        /// <param name="saleEmp">业务员</param>
        /// <param name="strGrd">钢种</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <returns></returns>
        public DataSet GetDayPlanOrder(string custName, string conno, string saleEmp, string stlGrd, string startTime, string endTime, string type, string spec, string matcode)
        {
            StringBuilder strSql = new StringBuilder();

            #region//线材//钢坯
            strSql.AppendFormat(@"SELECT TT.C_ID,
       TT.C_CON_NO,
       TT.D_DELIVERY_DT,
       TT.C_STL_GRD,
       TT.C_SPEC,
       TT.PKPLAN,
       TT.C_MAT_CODE,
       TT.C_MAT_NAME,
       TT.C_STD_CODE,
       TT.C_FREE1,
       TT.C_FREE2,
       TT.C_PACK,
       TT.C_AREA,
       TT.N_TYPE,
       TT.ORDERWGT, --原订单量
       TRC.YLXWGT, --已履行量
       (TT.ORDERWGT - nvl(TRC.YLXWGT, 0)) DLXWGT, --待履行量
       TMD.YFWGT, --在途量
       TT.C_ORDER_NO,
       TT.C_CUST_NAME,
       TT.C_CUST_NO,
       TT.SHDW,
       TT.C_YWY,
       TT.D_DT
  FROM (SELECT TMO.C_ID,
               TMO.C_CON_NO,
               TMO.C_ORDER_NO,
               TMO.D_DELIVERY_DT,
               TMO.C_STL_GRD,
               TMO.C_SPEC,
               TMO.ORDERWGT,
               TMO.PKPLAN,
               TMO.C_MAT_CODE,
               TMO.C_MAT_NAME,
               TMO.C_STD_CODE,
               TMO.C_FREE1,
               TMO.C_FREE2,
               TMO.C_PACK,
               TMO.C_AREA,
               TMO.N_TYPE,
               TMO.C_CUST_NAME,
               TMO.C_CUST_NO,
               TMO.SHDW,
               TMO.C_YWY,
               TMO.D_DT
          FROM (SELECT T.C_ID,
                       T.C_ORDER_NO,
                       T.C_CON_NO,
                       T.D_DELIVERY_DT,
                       T.C_STL_GRD,
                       T.C_SPEC,
                       T.N_WGT         AS ORDERWGT,
                       B.C_ID          AS PKPLAN,
                       T.C_MAT_CODE,
                       T.C_MAT_NAME,
                       T.C_STD_CODE,
                       T.C_FREE1,
                       T.C_FREE2,
                       T.C_PACK,
                       T.C_AREA,
                       T.N_TYPE,
                       T.C_CUST_NAME,
                       T.C_CUST_NO,
                       (SELECT MAX(A.C_NAME)
          FROM TS_CUSTFILE A
         WHERE A.C_NC_M_ID = T.C_RECEIPTCORPID) SHDW,
                       T.C_YWY,
                       T.D_DT
                  FROM TMO_CON_ORDER T
                  left JOIN TMP_DAYPLAN B
                    ON B.C_PKBILLB = T.C_ID
                 WHERE T.N_STATUS = 2
                   AND B.N_EXEC_STATUS = 1
                 ORDER BY T.D_DT ASC) TMO) TT
  LEFT JOIN (SELECT SUM(NVL(G.N_JZ, 0)) YLXWGT, K.C_ORDERPK
               FROM TMD_DISPATCH_SJZJB G
              INNER JOIN TMD_DISPATCHDETAILS K
                 ON G.C_PK_NCID = K.C_ID
              GROUP BY K.C_ORDERPK
             UNION ALL
             select SUM(NVL(L.N_FYWGT, 0)) YLXWGT, L.C_ORDERPK
               from tmd_dispatchdetails L
              WHERE L.C_ORDER_TYPE in ('805', '806', '807')
              GROUP BY L.C_ORDERPK) TRC
    ON TRC.C_ORDERPK = TT.C_ID

  LEFT JOIN (SELECT NVL(sum(T.N_FYWGT), 0) YFWGT, T.C_ORDERPK
               FROM TMD_DISPATCHDETAILS T
              INNER JOIN TMD_DISPATCH A
                 ON A.C_ID = T.C_DISPATCH_ID
              WHERE A.C_STATUS IN ('0', '2', '3', '4', '7', '10')
              GROUP BY T.C_ORDERPK) TMD
    ON TMD.C_ORDERPK = TT.C_ID
 WHERE TT.N_TYPE in (6,8, 805, 806, 807)");

            if (!string.IsNullOrEmpty(matcode))
            {
                strSql.Append(" AND TT.C_MAT_CODE = '" + matcode + "'");
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.Append(" AND TT.C_SPEC LIKE '%" + spec + "%'");
            }

            if (!string.IsNullOrEmpty(custName))
            {
                strSql.Append(" AND TT.C_CUST_NAME LIKE '%" + custName + "%'");
            }
            if (!string.IsNullOrEmpty(conno))
            {
                strSql.Append(" AND TT.C_CON_NO  LIKE '%" + conno + "'");
            }
            if (!string.IsNullOrEmpty(saleEmp))
            {
                strSql.Append(" AND TT.C_YWY LIKE '%" + saleEmp + "%'");
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.Append(" AND UPPER(TT.C_STL_GRD) LIKE '%" + stlGrd.ToUpper() + "%'");
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.Append(" AND TT.D_DT BETWEEN TO_DATE('" + Convert.ToDateTime(startTime).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') AND TO_DATE('" + Convert.ToDateTime(endTime).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            strSql.Append(" ORDER BY TT.D_DT, TT.C_MAT_NAME,TT.C_STL_GRD,TT.C_SPEC");


            #endregion

            #region 停用
            //           switch (type)
            //           {
            //               case "6":

            //                   #region//钢坯
            //                   strSql.AppendFormat(@"SELECT TT.C_ID,
            //                                          TT.C_CON_NO,
            //                                          TT.D_DELIVERY_DT,
            //                                          TT.C_STL_GRD,
            //                                          TT.C_SPEC,
            //                                          TT.PKPLAN,
            //                                          TT.C_MAT_CODE,
            //                                          TT.C_MAT_NAME,
            //                                          TT.C_STD_CODE,
            //                                          TT.C_AREA,
            //                                          TT.N_TYPE,
            //                                          TT.ORDERWGT, --原订单量
            //                                          TT.N_WGT, --线材量
            //                                          TT.QUA, --线材支数
            //                                          TMD.YFQUA, --在途支数
            //                                          TMD.YFWGT, --在途量
            //                                          (TT.QUA - NVL(TMD.YFQUA, 0)) SYQUA, --线材剩余支数
            //                                          (TT.N_WGT - NVL(TMD.YFWGT, 0)) SYWGT, --线材剩余量
            //                                          TRC.YLXWGT, --已履行量
            //                                          (TT.ORDERWGT - nvl(TMD.YFWGT, 0) - nvl(TRC.YLXWGT, 0)) DLXWGT, --待履行量
            //                                          TT.C_ORDER_NO,
            //                                          TT.C_CUST_NAME,
            //                                          TT.C_YWY,
            //                                          TT.D_DT
            //                                     FROM (SELECT TMO.C_ID,
            //                                                  TMO.C_CON_NO,
            //                                                  TMO.C_ORDER_NO,
            //                                                  TMO.D_DELIVERY_DT,
            //                                                  TMO.C_STL_GRD,
            //                                                  TMO.C_SPEC,
            //                                                  TMO.ORDERWGT,
            //                                                  TMO.PKPLAN,
            //                                                  TMO.C_MAT_CODE,
            //                                                  TMO.C_MAT_NAME,
            //                                                  TMO.C_STD_CODE,
            //                                                  TMO.C_AREA,
            //                                                  TMO.N_TYPE,
            //                                                  TRC.N_WGT,
            //                                                  TRC.QUA,
            //                                                  TMO.C_CUST_NAME,
            //                                                  TMO.C_YWY,
            //                                                  TMO.D_DT
            //                                             FROM (SELECT T.C_ID,
            //                                                          T.C_ORDER_NO,
            //                                                          T.C_CON_NO,
            //                                                          T.D_DELIVERY_DT,
            //                                                          T.C_STL_GRD,
            //                                                          T.C_SPEC,
            //                                                          T.N_WGT         AS ORDERWGT,
            //                                                          B.C_ID          AS PKPLAN,
            //                                                          T.C_MAT_CODE,
            //                                                          T.C_MAT_NAME,
            //                                                          T.C_STD_CODE,
            //                                                          T.C_AREA,
            //                                                          T.N_TYPE,
            //                                                          T.C_CUST_NAME,
            //                                                          T.C_YWY,
            //                                                          T.D_DT
            //                                                     FROM TMO_ORDER T
            //                                                    left JOIN TMP_DAYPLAN B
            //                                                       ON B.C_PKBILLB = T.C_ID
            //                                                    WHERE T.N_STATUS = 2
            //                                                      AND B.N_EXEC_STATUS = 1
            //                                                    ORDER BY T.D_DT ASC) TMO
            //                                             LEFT JOIN (SELECT A.C_MAT_CODE,
            //                                                              A.C_STD_CODE,
            //                                                              SUM(A.N_WGT) AS N_WGT,
            //                                                              COUNT(0) AS QUA
            //                                                         FROM TSC_SLAB_MAIN A
            //                                                        WHERE A.C_MOVE_TYPE = 'E'
            //                                                          AND A.C_JUDGE_LEV_ZH IN ('合格品')
            //                                                          AND A.C_IS_QR = 'Y'
            //                                                        GROUP BY A.C_MAT_CODE, A.C_STD_CODE) TRC
            //                                               ON TMO.C_MAT_CODE = TRC.C_MAT_CODE
            //                                              AND TMO.C_STD_CODE = TRC.C_STD_CODE) TT
            //                                     LEFT JOIN (SELECT NVL(SUM(T.N_FYZS), 0) AS YFQUA, --已发在途支数
            //                                                       NVL(SUM(T.N_FYWGT), 0) YFWGT, --已发在途量
            //                                                       T.C_MAT_CODE,
            //                                                       T.C_STD_CODE,
            //                                                       B.C_AREA,
            //                                                       B.C_ID
            //                                                  FROM TMD_DISPATCHDETAILS T
            //                                                 INNER JOIN TMD_DISPATCH A
            //                                                    ON A.C_ID = T.C_DISPATCH_ID
            //                                                 INNER JOIN TMO_ORDER B
            //                                                    ON B.C_ORDER_NO = T.C_NO
            //                                                 WHERE A.C_STATUS IN ('0', '2', '3', '4', '7', '10')
            //                                                 GROUP BY T.C_MAT_CODE, T.C_STD_CODE, B.C_AREA, B.C_ID) TMD
            //                                       ON TMD.C_ID = TT.C_ID
            //                                     LEFT JOIN (SELECT SUM(NVL(G.N_JZ, 0)) YLXWGT, K.C_ORDERPK
            //              FROM TMD_DISPATCH_SJZJB G
            //             INNER JOIN TMD_DISPATCHDETAILS K
            //                ON G.C_PK_NCID = K.C_ID
            //             GROUP BY K.C_ORDERPK) TRC
            //                                       ON TRC.C_ORDERPK = TT.C_ID
            //                                    WHERE TT.N_TYPE in (6) ");

            //                   if (!string.IsNullOrEmpty(custName))
            //                   {
            //                       strSql.Append(" AND TT.C_CUST_NAME LIKE '%" + custName + "%'");
            //                   }
            //                   if (!string.IsNullOrEmpty(conno))
            //                   {
            //                       strSql.Append(" AND TT.C_CON_NO like  '%" + conno + "'");
            //                   }
            //                   if (!string.IsNullOrEmpty(saleEmp))
            //                   {
            //                       strSql.Append(" AND TT.C_YWY LIKE '%" + saleEmp + "%'");
            //                   }
            //                   if (!string.IsNullOrEmpty(stlGrd))
            //                   {
            //                       strSql.Append(" AND UPPER(T.C_STL_GRD) LIKE '%" + stlGrd.ToUpper() + "%'");
            //                   }
            //                   if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            //                   {
            //                       strSql.Append(" AND TT.D_DT BETWEEN TO_DATE('" + startTime + "', 'yyyy-mm-dd hh24:mi:ss') AND TO_DATE('" + Convert.ToDateTime(endTime).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            //                   }
            //                   strSql.Append(" ORDER BY TT.D_DT ASC ");


            //                   #endregion
            //                   break;
            //               case "8":

            //                   break;
            //               default:
            //                   #region //渣，焦化，废材
            //                   strSql.AppendFormat(@"SELECT T.C_ID,
            //                                          T.C_CON_NO,
            //                                          T.D_DELIVERY_DT,
            //                                          T.C_STL_GRD,
            //                                          T.C_SPEC,
            //                                          T.N_WGT AS ORDERWGT,
            //                                          B.C_ID AS PKPLAN,
            //                                          T.C_MAT_CODE,
            //                                          T.C_MAT_NAME,
            //                                          T.C_STD_CODE,
            //                                          T.C_AREA,
            //                                          T.N_TYPE,
            //                                          '' as N_WGT, --库存量
            //                                          '' as QUA,
            //                                          TMD.YFQUA, --已发在途支数
            //                                          TMD.YFWGT, --已发在途量
            //                                          '' as SYQUA,
            //                                          '' as SYWGT,
            //                                          TMD2.YLXWGT, --已履行量
            //                                          (T.N_WGT - TMD.YFWGT - TMD2.YLXWGT) DLXWGT, --待履行量
            //                                          T.C_ORDER_NO,
            //                                          T.C_CUST_NAME,
            //                                          T.C_YWY,
            //                                          T.D_DT
            //                                     FROM TMO_ORDER T
            //                                    INNER JOIN TMP_DAYPLAN B
            //                                       ON B.C_PKBILLB = T.C_ID
            //                                     LEFT JOIN (SELECT NVL(SUM(T.N_FYZS), 0) AS YFQUA, --已发在途支数
            //                                                       NVL(SUM(T.N_FYWGT), 0) YFWGT, --已发在途量
            //                                                       T.C_MAT_CODE,
            //                                                       T.C_STD_CODE,
            //                                                       B.C_ID
            //                                                  FROM TMD_DISPATCHDETAILS T
            //                                                 INNER JOIN TMD_DISPATCH A
            //                                                    ON A.C_ID = T.C_DISPATCH_ID
            //                                                 INNER JOIN TMO_ORDER B
            //                                                    ON B.C_ORDER_NO = T.C_NO
            //                                                 WHERE A.C_STATUS IN ('0', '2', '3', '4', '7', '10')
            //                                                 GROUP BY T.C_MAT_CODE, T.C_STD_CODE, B.C_ID) TMD
            //                                       ON TMD.C_ID = T.C_ID
            //                                     LEFT JOIN (SELECT SUM(NVL(A.N_JWGT, 0)) YLXWGT, A.C_ORDERPK
            // FROM TMD_DISPATCHDETAILS A
            //GROUP BY A.C_ORDERPK) TMD2
            //                                       ON TMD2.C_ORDERPK = T.C_ID WHERE T.N_TYPE={0}", type);
            //                   if (!string.IsNullOrEmpty(custName))
            //                   {
            //                       strSql.Append(" AND T.C_CUST_NAME LIKE '%" + custName + "%'");
            //                   }
            //                   if (!string.IsNullOrEmpty(conno))
            //                   {
            //                       strSql.Append(" AND T.C_CON_NO = '" + conno + "'");
            //                   }
            //                   if (!string.IsNullOrEmpty(saleEmp))
            //                   {
            //                       strSql.Append(" AND T.C_YWY LIKE '%" + saleEmp + "%'");
            //                   }
            //                   if (!string.IsNullOrEmpty(stlGrd))
            //                   {
            //                       strSql.Append(" AND UPPER(T.C_STL_GRD) LIKE '%" + stlGrd.ToUpper() + "%'");
            //                   }
            //                   if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            //                   {
            //                       strSql.Append(" AND T.D_DT BETWEEN TO_DATE('" + startTime + "', 'yyyy-mm-dd hh24:mi:ss') AND TO_DATE('" + Convert.ToDateTime(endTime).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            //                   }
            //                   strSql.Append(" ORDER BY T.D_DT ASC");
            //                   #endregion
            //                   break;

            //           }
            #endregion


            return DbHelperOra.Query(strSql.ToString());

        }

        /// <summary>
        /// 检测是否可发运(发运单自由状态下保存校验)
        /// </summary>
        /// <param name="oldfywgt">原发运计划量</param>
        /// <returns></returns>
        public bool IsFy_Edit(decimal fywgt, decimal oldfywgt, string matcode, string stdcode, string area, string pack, string lev)
        {
            string[] arr = { matcode, stdcode, area, pack, lev };
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select TRC.n_wgt - nvl(TMD.YFWGT,0) AS KFWGT
  from ( select sum(nvl(t.n_wgt,0)) n_wgt, t.c_mat_code
               from trc_roll_prodcut t
              where t.C_MOVE_TYPE = 'E'
                and t.C_IS_QR = 'Y'
                and t.c_mat_code = '{0}'
                and t.c_std_code = '{1}'
                and t.c_sale_area = '{2}'
                and t.C_BZYQ = '{3}'
                and t.C_JUDGE_LEV_ZH = '{4}'
              group by t.c_mat_code) trc
  left join (SELECT sum(nvl(T.N_FYWGT,0)) YFWGT, t.c_mat_code --在途量
          FROM TMD_DISPATCHDETAILS T
         INNER JOIN TMD_DISPATCH A
            ON A.C_ID = T.C_DISPATCH_ID
         INNER JOIN TMO_CON_ORDER B
            ON B.C_ORDER_NO = T.C_NO
         WHERE A.C_STATUS IN ('0', '2', '3', '4', '7', '10')
           and t.c_mat_code = '{0}'
           and t.c_std_code = '{1}'
           and b.c_area = '{2}'
           and t.c_pack = '{3}'
           and t.C_JUDGE_LEV_ZH = '{4}'
         group by t.c_mat_code) tmd
    on trc.c_mat_code = tmd.c_mat_code", arr);

            decimal kfwgt = 0;

            DataTable dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["KFWGT"].ToString()))
                {
                    kfwgt = Convert.ToDecimal(dt.Rows[0]["KFWGT"]);
                }
            }
            decimal wgt = kfwgt + oldfywgt;
            if (fywgt <= wgt)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检测是否可发运
        /// </summary>
        /// <param name="fywgt"></param>
        /// <returns></returns>
        public bool IsFy(decimal fywgt, string matcode, string stdcode, string area, string pack, string lev)
        {
            string[] arr = { matcode, stdcode, area, pack, lev };


            StringBuilder strSql = new StringBuilder();

            if (!string.IsNullOrEmpty(pack))
            {
                strSql.AppendFormat(@"select TRC.n_wgt - nvl(TMD.YFWGT,0) AS KFWGT
                      from ( select sum(nvl(t.n_wgt,0)) n_wgt, t.c_mat_code
                                   from trc_roll_prodcut t
                                  where t.C_MOVE_TYPE = 'E'
                                    and t.C_IS_QR = 'Y'
                                    and t.c_mat_code = '{0}'
                                    and t.c_std_code = '{1}'
                                    and t.c_sale_area = '{2}'
                                    and t.C_BZYQ = '{3}'
                                    and t.C_JUDGE_LEV_ZH = '{4}'
                                  group by t.c_mat_code) trc
                      left join (SELECT sum(nvl(T.N_FYWGT,0)) YFWGT, t.c_mat_code --在途量
                              FROM TMD_DISPATCHDETAILS T
                             INNER JOIN TMD_DISPATCH A
                                ON A.C_ID = T.C_DISPATCH_ID
                             INNER JOIN TMO_CON_ORDER B
                                ON B.C_ORDER_NO = T.C_NO
                             WHERE A.C_STATUS IN ('0', '2', '3', '4', '7', '10')
                               and t.c_mat_code = '{0}'
                               and t.c_std_code = '{1}'
                               and b.c_area = '{2}'
                               and t.c_pack = '{3}'
                               and t.C_JUDGE_LEV_ZH = '{4}'
                             group by t.c_mat_code) tmd
                        on trc.c_mat_code = tmd.c_mat_code", arr);
            }
            else
            {
                strSql.AppendFormat(@"select TRC.n_wgt - nvl(TMD.YFWGT,0) AS KFWGT
                      from ( select sum(nvl(t.n_wgt,0)) n_wgt, t.c_mat_code
                                   from trc_roll_prodcut t
                                  where t.C_MOVE_TYPE = 'E'
                                    and t.C_IS_QR = 'Y'
                                    and t.c_mat_code = '{0}'
                                    and t.c_std_code = '{1}'
                                    and t.c_sale_area = '{2}'
                                    and (t.C_BZYQ = '{3}' or t.C_BZYQ  is null)
                                    and t.C_JUDGE_LEV_ZH = '{4}'
                                  group by t.c_mat_code) trc
                      left join (SELECT sum(nvl(T.N_FYWGT,0)) YFWGT, t.c_mat_code --在途量
                              FROM TMD_DISPATCHDETAILS T
                             INNER JOIN TMD_DISPATCH A
                                ON A.C_ID = T.C_DISPATCH_ID
                             INNER JOIN TMO_CON_ORDER B
                                ON B.C_ORDER_NO = T.C_NO
                             WHERE A.C_STATUS IN ('0', '2', '3', '4', '7', '10')
                               and t.c_mat_code = '{0}'
                               and t.c_std_code = '{1}'
                               and b.c_area = '{2}'
                               and (t.c_pack = '{3}' or t.c_pack is null)
                               and t.C_JUDGE_LEV_ZH = '{4}'
                             group by t.c_mat_code) tmd
                        on trc.c_mat_code = tmd.c_mat_code", arr);
            }

            DataTable dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {

                if (!string.IsNullOrEmpty(dt.Rows[0]["KFWGT"].ToString()))
                {

                    decimal wgt = Convert.ToDecimal(dt.Rows[0]["KFWGT"]);
                    if (fywgt <= wgt)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检测是否可发运
        /// </summary>
        /// <param name="fywgt"></param>
        /// <returns></returns>
        public bool IsFy(decimal fywgt, string matcode, string stdcode, string area, string pack, string lev, string custName, string con)
        {
            string[] arr = { matcode, stdcode, area, pack, lev, custName, con };


            StringBuilder strSql = new StringBuilder();

            if (!string.IsNullOrEmpty(pack))
            {
                strSql.AppendFormat(@"select TRC.n_wgt - nvl(TMD.YFWGT,0) AS KFWGT
                      from ( select sum(nvl(t.n_wgt,0)) n_wgt, t.c_mat_code
                                   from trc_roll_prodcut t
                                  where t.C_MOVE_TYPE = 'E'
                                    and t.C_IS_QR = 'Y'
                                    and t.c_mat_code = '{0}'
                                    and t.c_std_code = '{1}'
                                    and t.c_sale_area = '{2}'
                                    and t.C_BZYQ = '{3}'
                                    and t.C_JUDGE_LEV_ZH = '{4}'
                                    and t.C_CUST_NAME='{5}'
                                    AND SUBSTR(T.C_CON_NO,0,15) = SUBSTR('{6}',0,15)
                                  group by t.c_mat_code) trc
                      left join (SELECT sum(nvl(T.N_FYWGT,0)) YFWGT, t.c_mat_code --在途量
                              FROM TMD_DISPATCHDETAILS T
                             INNER JOIN TMD_DISPATCH A
                                ON A.C_ID = T.C_DISPATCH_ID
                             INNER JOIN TMO_CON_ORDER B
                                ON B.C_ORDER_NO = T.C_NO
                             WHERE A.C_STATUS IN ('0', '2', '3', '4', '7', '10')
                               and t.c_mat_code = '{0}'
                               and t.c_std_code = '{1}'
                               and b.c_area = '{2}'
                               and t.c_pack = '{3}'
                               and t.C_JUDGE_LEV_ZH = '{4}'
                               and b.C_CUST_NAME = '{5}'
                               AND SUBSTR(B.C_CON_NO,0,15) = SUBSTR('{6}',0,15)
                             group by t.c_mat_code) tmd
                        on trc.c_mat_code = tmd.c_mat_code", arr);
            }
            else
            {
                strSql.AppendFormat(@"select TRC.n_wgt - nvl(TMD.YFWGT,0) AS KFWGT
                      from ( select sum(nvl(t.n_wgt,0)) n_wgt, t.c_mat_code
                                   from trc_roll_prodcut t
                                  where t.C_MOVE_TYPE = 'E'
                                    and t.C_IS_QR = 'Y'
                                    and t.c_mat_code = '{0}'
                                    and t.c_std_code = '{1}'
                                    and t.c_sale_area = '{2}'
                                    and (t.C_BZYQ = '{3}' or t.C_BZYQ  is null)
                                    and t.C_JUDGE_LEV_ZH = '{4}'
                                    and t.C_CUST_NAME='{5}'
                                    AND SUBSTR(T.C_CON_NO,0,15) = SUBSTR('{6}',0,15)
                                  group by t.c_mat_code) trc
                      left join (SELECT sum(nvl(T.N_FYWGT,0)) YFWGT, t.c_mat_code --在途量
                              FROM TMD_DISPATCHDETAILS T
                             INNER JOIN TMD_DISPATCH A
                                ON A.C_ID = T.C_DISPATCH_ID
                             INNER JOIN TMO_CON_ORDER B
                                ON B.C_ORDER_NO = T.C_NO
                             WHERE A.C_STATUS IN ('0', '2', '3', '4', '7', '10')
                               and t.c_mat_code = '{0}'
                               and t.c_std_code = '{1}'
                               and b.c_area = '{2}'
                               and (t.c_pack = '{3}' or t.c_pack is null)
                               and t.C_JUDGE_LEV_ZH = '{4}'
                               and b.C_CUST_NAME = '{5}'
                               AND SUBSTR(B.C_CON_NO,0,15) = SUBSTR('{6}',0,15)
                             group by t.c_mat_code) tmd
                        on trc.c_mat_code = tmd.c_mat_code", arr);
            }

            DataTable dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {

                if (!string.IsNullOrEmpty(dt.Rows[0]["KFWGT"].ToString()))
                {

                    decimal wgt = Convert.ToDecimal(dt.Rows[0]["KFWGT"]);
                    if (fywgt <= wgt)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 区域发运在途量查询
        /// </summary>
        /// <param name="matcode"></param>
        /// <param name="stdcode"></param>
        /// <param name="area"></param>
        /// <param name="pack"></param>
        /// <param name="dj"></param>
        /// <returns></returns>
        public DataSet ZTWGT(string matcode, string stdcode, string area, string pack, string dj)
        {
            string[] arr = { matcode, stdcode, area, pack, dj };
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT a.c_id,
                                   t.c_mat_code,
                                   t.C_ORGO_CUST,
                                   b.c_area,
                                   t.c_mat_code,
                                   t.c_stl_grd,
                                   t.c_spec,
                                   t.N_FYZS,
                                   t.n_fywgt,
                                   t.c_std_code,
                                   t.c_free_term,
                                   t.c_free_term2,
                                   t.c_pack,
                                   t.C_JUDGE_LEV_ZH,
                                   A.C_STATUS
                              FROM TMD_DISPATCHDETAILS T
                             INNER JOIN TMD_DISPATCH A
                                ON A.C_ID = T.C_DISPATCH_ID
                             INNER JOIN TMO_CON_ORDER B
                                ON B.C_ORDER_NO = T.C_NO
                             WHERE A.C_STATUS IN ('0', '2', '3', '4', '7', '10')
                               and t.c_mat_code = '{0}'
                               and t.c_std_code = '{1}'
                               and b.c_area = '{2}'
                               and t.c_pack = '{3}'
                               and t.C_JUDGE_LEV_ZH = '{4}'", arr);
            return DbHelperOra.Query(strSql.ToString());

        }


        /// <summary>
        /// 区域客户发运在途量查询
        /// </summary>
        /// <param name="matcode"></param>
        /// <param name="stdcode"></param>
        /// <param name="area"></param>
        /// <param name="pack"></param>
        /// <param name="dj"></param>
        /// <returns></returns>
        public DataSet ZTWGT(string matcode, string stdcode, string area, string pack, string dj, string custName, string con)
        {
            string[] arr = { matcode, stdcode, area, pack, dj, custName, con };
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT a.c_id,
                                   t.c_mat_code,
                                   t.C_ORGO_CUST,
                                   b.c_area,
                                   t.c_mat_code,
                                   t.c_stl_grd,
                                   t.c_spec,
                                   t.N_FYZS,
                                   t.n_fywgt,
                                   t.c_std_code,
                                   t.c_free_term,
                                   t.c_free_term2,
                                   t.c_pack,
                                   t.C_JUDGE_LEV_ZH,
                                   A.C_STATUS
                              FROM TMD_DISPATCHDETAILS T
                             INNER JOIN TMD_DISPATCH A
                                ON A.C_ID = T.C_DISPATCH_ID
                             INNER JOIN TMO_CON_ORDER B
                                ON B.C_ORDER_NO = T.C_NO
                             WHERE A.C_STATUS IN ('0', '2', '3', '4', '7', '10')
                               and t.c_mat_code = '{0}'
                               and t.c_std_code = '{1}'
                               and b.c_area = '{2}'
                               and t.c_pack = '{3}'
                               and t.C_JUDGE_LEV_ZH = '{4}' and b.C_CUST_NAME = '{5}' AND  SUBSTR(T.C_CON_NO,0,15) = SUBSTR('{6}',0,15)", arr);
            return DbHelperOra.Query(strSql.ToString());

        }


        /// <summary>
        /// 区域库存量查询
        /// </summary>
        /// <returns></returns>
        public DataSet KCWGT(string matcode, string stdcode, string area, string pack, string dj)
        {
            StringBuilder strSql = new StringBuilder();
            string[] arr = { matcode, stdcode, area, pack, dj };



            if (!string.IsNullOrEmpty(area))
            {
                if (!string.IsNullOrEmpty(pack))
                {
                    strSql.AppendFormat(@"select nvl(sum(t.n_wgt),0) N_WGT,count(0)jianshu
               from trc_roll_prodcut t
              where t.C_MOVE_TYPE = 'E'
                and t.C_IS_QR = 'Y'
                and t.c_mat_code = '{0}'
                and t.c_std_code = '{1}'
                and t.c_sale_area = '{2}'
                and t.C_BZYQ = '{3}'
                and t.C_JUDGE_LEV_ZH = '{4}'", arr);
                }
                else
                {
                    strSql.AppendFormat(@"select nvl(sum(t.n_wgt),0) N_WGT,count(0)jianshu
               from trc_roll_prodcut t
              where t.C_MOVE_TYPE = 'E'
                and t.C_IS_QR = 'Y'
                and t.c_mat_code = '{0}'
                and t.c_std_code = '{1}'
                and t.c_sale_area = '{2}'
                and (t.C_BZYQ = '{3}' or t.C_BZYQ is null)
                and t.C_JUDGE_LEV_ZH = '{4}'", arr);
                }


            }
            else
            {
                strSql.AppendFormat(@"select sum(nvl(t.n_wgt,0)) N_WGT
               from trc_roll_prodcut t
              where t.C_MOVE_TYPE = 'E'
                and t.C_IS_QR = 'Y'
                and t.c_mat_code = '{0}'
                and t.c_std_code = '{1}'
                and (t.c_sale_area = '{2}' or t.c_sale_area is null )
                and t.C_BZYQ = '{3}'
                and t.C_JUDGE_LEV_ZH = '{4}'", arr);
            }

            return DbHelperOra.Query(strSql.ToString());
        }



        /// <summary>
        /// 区域客户库存量查询
        /// </summary>
        /// <returns></returns>
        public DataSet KCWGT(string matcode, string stdcode, string area, string pack, string dj, string custName, string con)
        {
            StringBuilder strSql = new StringBuilder();
            string[] arr = { matcode, stdcode, area, pack, dj, custName, con };



            if (!string.IsNullOrEmpty(area))
            {
                if (!string.IsNullOrEmpty(pack))
                {
                    strSql.AppendFormat(@"select nvl(sum(t.n_wgt),0) N_WGT,count(0)jianshu
               from trc_roll_prodcut t
              where t.C_MOVE_TYPE = 'E'
                and t.C_IS_QR = 'Y'
                and t.c_mat_code = '{0}'
                and t.c_std_code = '{1}'
                and t.c_sale_area = '{2}'
                and t.C_BZYQ = '{3}'
                and t.C_JUDGE_LEV_ZH = '{4}' and t.C_CUST_NAME='{5}' AND SUBSTR(T.C_CON_NO,0,15) = SUBSTR('{6}',0,15)", arr);
                }
                else
                {
                    strSql.AppendFormat(@"select nvl(sum(t.n_wgt),0) N_WGT,count(0)jianshu
               from trc_roll_prodcut t
              where t.C_MOVE_TYPE = 'E'
                and t.C_IS_QR = 'Y'
                and t.c_mat_code = '{0}'
                and t.c_std_code = '{1}'
                and t.c_sale_area = '{2}'
                and (t.C_BZYQ = '{3}' or t.C_BZYQ is null)
                and t.C_JUDGE_LEV_ZH = '{4}' and t.C_CUST_NAME='{5}' AND SUBSTR(T.C_CON_NO,0,15) = SUBSTR('{6}',0,15)", arr);
                }


            }
            else
            {
                strSql.AppendFormat(@"select sum(nvl(t.n_wgt,0)) N_WGT
               from trc_roll_prodcut t
              where t.C_MOVE_TYPE = 'E'
                and t.C_IS_QR = 'Y'
                and t.c_mat_code = '{0}'
                and t.c_std_code = '{1}'
                and (t.c_sale_area = '{2}' or t.c_sale_area is null )
                and t.C_BZYQ = '{3}'
                and t.C_JUDGE_LEV_ZH = '{4}' and t.C_CUST_NAME='{5}' AND SUBSTR(T.C_CON_NO,0,15) = SUBSTR('{6}',0,15)", arr);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取订单已出库量+订单在途已发量
        /// </summary>
        /// <param name="orderID">订单主键</param>
        /// <returns></returns>
        public decimal GetYLX_YFWGT(string orderID)
        {
            #region //订单已出库量
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT NVL(SUM(A.N_JZ), 0) YLXWGT
          FROM TMD_DISPATCHDETAILS T
         INNER JOIN TMD_DISPATCH_SJZJB A
            ON A.C_PK_NCID = T.C_ID
            WHERE t.c_orderpk = '{0}'", orderID);
            #endregion

            #region //订单在途量

            StringBuilder strSql2 = new StringBuilder();
            strSql2.AppendFormat(@"SELECT NVL(sum(T.N_FYWGT), 0) YFWGT
  FROM TMD_DISPATCHDETAILS T
 INNER JOIN TMD_DISPATCH A
    ON A.C_ID = T.C_DISPATCH_ID
 WHERE A.C_STATUS IN ('0', '2', '3', '4', '7', '10')
   and t.c_orderpk = '{0}'", orderID);
            #endregion

            decimal sumwgt = 0;
            decimal YLXWGT = Convert.ToDecimal(DbHelperOra.GetSingle(strSql.ToString()));
            decimal YFWGT = Convert.ToDecimal(DbHelperOra.GetSingle(strSql2.ToString()));
            sumwgt = YLXWGT + YFWGT;

            return sumwgt;

        }


        /// <summary>
        /// 获取订单已发数量
        /// </summary>
        /// <param name="orderID">订单主键</param>
        /// <returns></returns>
        public DataSet GetYFYWGT(string orderID)
        {


            //订单已出库量+订单发运在途量
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT NVL(TT.YLXWGT, 0) + NVL(TMD.YFWGT, 0) AS SUMWGT,
       NVL(TT.YLXWGT,0)YLXWGT,
       NVL(TMD.YFWGT,0)YFWGT,
       TT.C_ORDERPK
  FROM (SELECT NVL(SUM(A.N_JZ), 0) YLXWGT, T.C_ORDERPK
          FROM TMD_DISPATCHDETAILS T
         INNER JOIN TMD_DISPATCH_SJZJB A
            ON A.C_PK_NCID = T.C_ID
         GROUP BY T.C_ORDERPK) TT
  LEFT JOIN (SELECT NVL(sum(T.N_FYWGT),0) YFWGT, T.C_ORDERPK
               FROM TMD_DISPATCHDETAILS T
              INNER JOIN TMD_DISPATCH A
                 ON A.C_ID = T.C_DISPATCH_ID
              WHERE A.C_STATUS IN ('0', '2', '3', '4', '7', '10')
              GROUP BY T.C_ORDERPK) TMD
    ON TT.C_ORDERPK = TMD.C_ORDERPK
  WHERE TT.C_ORDERPK='{0}'", orderID);

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取订单总履行量
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public DataTable GetOUTSTOCKWGT(string orderID,string fyd)
        {

            //订单类型: 6 钢坯，8线材,851渣，841焦化，831废材,(805,806,807委外线材)


            string[] mattype = { "851", "841", "831" };

            StringBuilder strSql = new StringBuilder();
            Mod_TMO_ORDER mod = GetModel(orderID);
            if (mod != null)
            {

                if (mattype.Contains(mod.N_TYPE.ToString()))//水渣，焦化
                {
                    strSql.AppendFormat(@"SELECT NVL(SUM(T.N_JWGT),0) AS QUA, NVL(SUM(T.N_FYWGT),0) AS N_WGT
                                          FROM TMD_DISPATCHDETAILS T
                                         WHERE T.C_ORDERPK = '{0}' AND T.C_DISPATCH_ID='{1}'", orderID,fyd);
                }
                else
                {
                    strSql.AppendFormat(@"SELECT NVL(SUM(A.N_NUM),0) AS QUA, NVL(SUM(A.N_JZ),0) AS N_WGT
                                          FROM TMD_DISPATCHDETAILS T
                                         INNER JOIN TMD_DISPATCH_SJZJB A
                                            ON A.C_PK_NCID = T.C_ID WHERE T.C_ORDERPK='{0}' AND T.C_DISPATCH_ID='{1}'", orderID,fyd);
                }

            }


            return DbHelperOra.Query(strSql.ToString()).Tables[0];
        }



        /// <summary>
        /// 实时获取可发库存量
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public DataTable GetKCWGT(string orderID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("QUA", typeof(string));
            dt.Columns.Add("N_WGT", typeof(string));

            StringBuilder strSql = new StringBuilder();
            Mod_TMO_ORDER mod = GetModel(orderID);
            if (mod != null)
            {
                string[] arr = { mod.C_MAT_CODE, mod.C_STD_CODE, mod.C_AREA };
                switch (mod.N_TYPE)
                {
                    case 6:
                        #region //钢坯
                        strSql.AppendFormat(@"SELECT (TSC.QUA - NVL(TMD.QUA,0)) AS QUA,
                                               (TSC.N_WGT - NVL(TMD.N_WGT,0)) AS N_WGT 
                                          FROM (SELECT COUNT(*) QUA, NVL(SUM(N_WGT), 0) N_WGT,T.C_MAT_CODE,T.C_STD_CODE
                                                  FROM TSC_SLAB_MAIN T
                                                 WHERE T.C_MAT_CODE = '{0}'
                                                   AND T.C_STD_CODE = '{1}'
                                                   AND T.C_MOVE_TYPE = 'E'
                                                   AND T.C_JUDGE_LEV_ZH IN ('合格品')
                                                   AND T.C_IS_QR = 'Y' GROUP BY T.C_MAT_CODE,T.C_STD_CODE) TSC
                                         LEFT JOIN (SELECT NVL(SUM(T.N_FYZS), 0) AS QUA,
                                                            NVL(SUM(T.N_FYWGT), 0) N_WGT,
                                                                T.C_STD_CODE,
                                                                T.C_MAT_CODE
                                                       FROM TMD_DISPATCHDETAILS T
                                                      INNER JOIN TMD_DISPATCH A
                                                         ON A.C_ID = T.C_DISPATCH_ID
                                                      WHERE A.C_STATUS IN ('0', '2', '3', '4', '10')
                                                        AND T.C_MAT_CODE = '{0}'
                                                        AND T.C_STD_CODE = '{1}' GROUP BY T.C_STD_CODE,
                                                                T.C_MAT_CODE ) TMD
                                            ON TSC.C_MAT_CODE = TMD.C_MAT_CODE AND TSC.C_STD_CODE=TMD.C_STD_CODE", arr);
                        dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
                        #endregion
                        break;
                    case 8:
                        #region //线材
                        strSql.AppendFormat(@"SELECT (TRC.QUA - NVL(TMD.QUA, 0)) AS QUA,
                                                   (TRC.N_WGT - NVL(TMD.N_WGT, 0)) AS N_WGT
                                              FROM (SELECT COUNT(*) QUA,
                                                           NVL(SUM(N_WGT), 0) N_WGT,
                                                           T.C_MAT_CODE,
                                                           T.C_STD_CODE,
                                                           T.C_SALE_AREA
                                                      FROM TRC_ROLL_PRODCUT T
                                                     WHERE T.C_MAT_CODE = '{0}'
                                                       AND T.C_STD_CODE = '{1}'
                                                       AND T.C_MOVE_TYPE = 'E'
                                                       --AND T.C_JUDGE_LEV_ZH IN ('A', 'CK', 'AA', 'AAA')
                                                       AND T.C_IS_QR = 'Y'
                                                       AND T.C_SALE_AREA='{2}'
                                                     GROUP BY T.C_MAT_CODE, T.C_STD_CODE,T.C_SALE_AREA) TRC
                                              LEFT JOIN (SELECT NVL(SUM(T.N_FYZS), 0) AS QUA,
                                                                NVL(SUM(T.N_FYWGT), 0) N_WGT,
                                                                T.C_STD_CODE,
                                                                T.C_MAT_CODE,
                                                                B.C_AREA
                                                           FROM TMD_DISPATCHDETAILS T
                                                          INNER JOIN TMD_DISPATCH A
                                                             ON A.C_ID = T.C_DISPATCH_ID INNER JOIN TMO_CON_ORDER B ON B.C_ORDER_NO=T.C_NO
                                                          WHERE A.C_STATUS IN ('0', '2', '3', '4', '10')
                                                            AND T.C_MAT_CODE = '{0}'
                                                            AND T.C_STD_CODE = '{1}'
                                                            AND B.C_AREA='{2}'
                                                          GROUP BY T.C_STD_CODE, T.C_MAT_CODE,B.C_AREA) TMD
                                                ON TRC.C_MAT_CODE = TMD.C_MAT_CODE
                                               AND TRC.C_STD_CODE = TMD.C_STD_CODE AND TRC.C_SALE_AREA=TMD.C_AREA 
                                            ", arr);
                        dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
                        #endregion
                        break;
                }
            }

            return dt;
        }

        /// <summary>
        /// 获取可发支数总量
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public DataTable GetKCWGT(string orderID, string top)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("C_ID", typeof(string));
            dt.Columns.Add("N_WGT", typeof(string));

            StringBuilder strSql = new StringBuilder();
            Mod_TMO_ORDER mod = GetModel(orderID);
            if (mod != null)
            {
                string[] arr = { mod.C_MAT_CODE, mod.C_STD_CODE };
                string strTMD = "";
                #region //获取发运单明细

                string cmd = string.Format(@"SELECT  T.C_PRODUCT_ID
                                              FROM TMD_DISPATCHDETAILS T
                                             INNER JOIN TMD_DISPATCH A
                                                ON A.C_ID = T.C_DISPATCH_ID
                                             WHERE A.C_STATUS IN('0', '2', '3', '4', '10')
                                               AND T.C_MAT_CODE = '{0}'
                                               AND T.C_STD_CODE = '{1}'", arr);
                DataTable dtTMD = DbHelperOra.Query(cmd).Tables[0];
                if (dtTMD.Rows.Count > 0)
                {
                    List<string> list = new List<string>();
                    for (int i = 0; i < dtTMD.Rows.Count; i++)
                    {
                        string[] str = dtTMD.Rows[i]["C_PRODUCT_ID"].ToString().Split('#');
                        if (str.Length > 0)
                        {
                            for (int j = 0; j < str.Length; j++)
                            {
                                var id = "'" + str[j] + "'";
                                list.Add(id);
                            }
                        }
                    }
                    strTMD = string.Join(",", list);
                }
                #endregion


                switch (mod.N_TYPE)
                {
                    case 6:
                        #region//钢坯
                        strSql.AppendFormat(@"WITH T AS
                                             (SELECT ROW_NUMBER() OVER(ORDER BY T.C_BATCH_NO) AS ROW_NUMBER,
                                                     T.C_ID,
                                                     T.C_BATCH_NO,
                                                     T.N_WGT
                                                FROM TSC_SLAB_MAIN T
                                               WHERE T.C_MAT_CODE = '{0}'
                                                 AND T.C_STD_CODE = '{1}'
                                                 AND T.C_MOVE_TYPE = 'E'
                                                 AND T.C_JUDGE_LEV_ZH IN ('合格品')
                                                 AND T.C_IS_QR = 'Y'", arr);
                        if (!string.IsNullOrEmpty(strTMD))
                        {
                            strSql.AppendFormat(@"AND T.C_ID NOT IN({0})", strTMD);
                        }
                        strSql.AppendFormat(@")SELECT T.C_ID, T.N_WGT FROM T WHERE ROW_NUMBER <={0}", top);
                        dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
                        #endregion
                        break;
                    case 8:
                        #region//线材
                        strSql.AppendFormat(@"WITH T AS
                                             (SELECT ROW_NUMBER() OVER(ORDER BY T.C_BATCH_NO) AS ROW_NUMBER,
                                                     T.C_ID,
                                                     T.C_BATCH_NO,
                                                     T.N_WGT
                                                FROM TRC_ROLL_PRODCUT T
                                               WHERE T.C_MAT_CODE = '{0}'
                                                 AND T.C_STD_CODE = '{1}'
                                                 AND T.C_MOVE_TYPE = 'E'
                                                 --AND T.C_JUDGE_LEV_ZH IN ('A', 'CK', 'AA', 'AAA')
                                                 AND T.C_IS_QR = 'Y'", arr);
                        if (!string.IsNullOrEmpty(strTMD))
                        {
                            strSql.AppendFormat(@"AND T.C_ID NOT IN({0})", strTMD);
                        }
                        strSql.AppendFormat(@")SELECT T.C_ID, T.N_WGT FROM T WHERE ROW_NUMBER <={0}", top);
                        dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
                        #endregion
                        break;
                }
            }

            return dt;
        }

        /// <summary>
        /// 获取发运单原本支数重量
        /// </summary>
        /// <param name="type">订单类型</param>
        /// <param name="fydid">发运单ID</param>
        /// <param name="top"></param>
        /// <returns></returns>
        public DataTable GetFydWgt(string type, string fydid, string top)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("C_ID", typeof(string));
            dt.Columns.Add("N_WGT", typeof(string));

            StringBuilder strSql = new StringBuilder();
            string procid = "";
            #region //获取发运单明细

            string cmd = string.Format(@"SELECT  T.C_PRODUCT_ID FROM TMD_DISPATCHDETAILS T WHERE T.C_ID='{0}'", fydid);
            DataRow dr = DbHelperOra.GetDataRow(cmd);
            if (dr != null)
            {
                string[] str = dr["C_PRODUCT_ID"].ToString().Split('#');
                if (str.Length > 0)
                {
                    List<string> list = new List<string>();
                    for (int i = 0; i < str.Length; i++)
                    {
                        var id = "'" + str[i] + "'";
                        list.Add(id);
                    }
                    procid = string.Join(",", list);
                }
            }
            #endregion
            switch (type)
            {
                case "6":
                    #region //钢坯
                    strSql.AppendFormat(@"WITH T AS
                                         (SELECT ROW_NUMBER() OVER(ORDER BY T.C_BATCH_NO) AS ROW_NUMBER,
                                                 T.C_ID,
                                                 T.C_BATCH_NO,
                                                 T.N_WGT
                                            FROM TSC_SLAB_MAIN T
                                           WHERE t.C_ID in({0})
                                             AND T.C_MOVE_TYPE = 'E'
                                             AND T.C_JUDGE_LEV_ZH IN ('合格品')
                                             AND T.C_IS_QR = 'Y')
                                        SELECT T.C_ID,T.N_WGT FROM T where  ROW_NUMBER <={1}", procid, top);
                    dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
                    #endregion

                    break;
                case "8":
                    #region //线材
                    strSql.AppendFormat(@"WITH T AS
                                         (SELECT ROW_NUMBER() OVER(ORDER BY T.C_BATCH_NO) AS ROW_NUMBER,
                                                 T.C_ID,
                                                 T.C_BATCH_NO,
                                                 T.N_WGT
                                            FROM TRC_ROLL_PRODCUT T
                                           WHERE t.C_ID in({0})
                                             AND T.C_MOVE_TYPE = 'E'
                                             --AND T.C_JUDGE_LEV_ZH IN ('A', 'CK', 'AA', 'AAA')
                                             AND T.C_IS_QR = 'Y')
                                        SELECT T.C_ID,T.N_WGT FROM T where  ROW_NUMBER <={1}", procid, top);
                    dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
                    #endregion
                    break;
            }

            return dt;
        }



        /// <summary>
        /// 储运获取发运单原本支数重量
        /// </summary>
        /// <param name="type">订单类型8,6</param>
        /// <param name="fydid">发运单明细主键</param>
        /// <param name="procid">其他产品ID</param>
        /// <param name="delprocid">排除其他产品ID</param>
        /// <param name="top"></param>
        /// <returns></returns>
        public DataTable GetCyFydWgt(string type, string fydid, string procid, string delprocid, string top)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("C_ID", typeof(string));
            dt.Columns.Add("N_WGT", typeof(string));


            if (!string.IsNullOrEmpty(procid) && procid != "#")
            {
                string[] arr = procid.Split('#');
                List<string> list = new List<string>();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!string.IsNullOrEmpty(arr[i]))
                    {
                        var id = "'" + arr[i] + "'";
                        list.Add(id);
                    }
                }
                procid = string.Join(",", list);
            }

            if (!string.IsNullOrEmpty(delprocid) && delprocid != "#")
            {
                string[] arr = delprocid.Split('#');
                List<string> list = new List<string>();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!string.IsNullOrEmpty(arr[i]))
                    {
                        var id = "'" + arr[i] + "'";
                        list.Add(id);
                    }
                }
                delprocid = string.Join(",", list);
            }

            StringBuilder strSql = new StringBuilder();
            string procid_y = "";

            #region //获取发运单明细
            if (!string.IsNullOrEmpty(procid))
            {
                procid_y = procid;
            }
            else
            {
                string cmd = string.Format(@"SELECT  T.C_PRODUCT_ID FROM TMD_DISPATCHDETAILS T WHERE T.C_DISPATCH_ID='{0}'", fydid);
                DataTable dt2 = DbHelperOra.Query(cmd).Tables[0];
                if (dt2.Rows.Count > 0)
                {
                    List<string> list = new List<string>();
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        string[] str = dt2.Rows[i]["C_PRODUCT_ID"].ToString().Split('#');
                        if (str.Length > 0)
                        {
                            for (int j = 0; j < str.Length; j++)
                            {
                                var id = "'" + str[j] + "'";
                                list.Add(id);
                            }
                        }
                    }
                    procid_y = string.Join(",", list);

                }

            }

            #endregion
            switch (type)
            {
                case "6":
                    #region //钢坯
                    strSql.AppendFormat(@"WITH T AS
                                         (SELECT ROW_NUMBER() OVER(ORDER BY T.C_BATCH_NO) AS ROW_NUMBER,
                                                 T.C_ID,
                                                 T.C_BATCH_NO,
                                                 T.N_WGT
                                            FROM TSC_SLAB_MAIN T
                                           WHERE t.c_id in({0})
                                             AND T.C_MOVE_TYPE = 'E'
                                             AND T.C_JUDGE_LEV_ZH IN ('合格品')
                                             AND T.C_IS_QR = 'Y'", procid_y);
                    if (!string.IsNullOrEmpty(delprocid))
                    {
                        strSql.AppendFormat(@"AND T.C_ID NOT IN({0})", delprocid);
                    }
                    strSql.AppendFormat(@" ) SELECT T.C_ID,T.N_WGT FROM T where  ROW_NUMBER <={0}", top);

                    dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
                    #endregion

                    break;
                case "8":
                    #region //线材
                    strSql.AppendFormat(@"WITH T AS
                                         (SELECT ROW_NUMBER() OVER(ORDER BY T.C_BATCH_NO) AS ROW_NUMBER,
                                                 T.C_ID,
                                                 T.C_BATCH_NO,
                                                 T.N_WGT
                                            FROM TRC_ROLL_PRODCUT T
                                           WHERE t.c_id in({0})
                                             AND T.C_MOVE_TYPE = 'E'
                                             --AND T.C_JUDGE_LEV_ZH IN ('A', 'CK', 'AA', 'AAA')
                                             AND T.C_IS_QR = 'Y'", procid_y);
                    if (!string.IsNullOrEmpty(delprocid))
                    {
                        strSql.AppendFormat(@"AND T.C_ID NOT IN({0})", delprocid);
                    }
                    strSql.AppendFormat(@" ) SELECT T.C_ID,T.N_WGT FROM T where  ROW_NUMBER <={0}", top);

                    dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
                    #endregion
                    break;
            }

            return dt;
        }

        /// <summary>
        /// 不锈钢委外仓库
        /// </summary>
        /// <param name="key">仓库编码</param>
        /// <param name="fydID">发运明细主键</param>
        /// <param name="batch">批次号</param>
        /// <returns></returns>
        public DataSet GetCKW(string key, string fydID, string batch)
        {
            Dal_TMD_DISPATCHDETAILS dal = new Dal_TMD_DISPATCHDETAILS();
            Mod_TMD_DISPATCHDETAILS mod = dal.GetModel(fydID);
            string[] arr = { mod.C_MAT_CODE, mod.C_STD_CODE, mod.C_PACK, mod.C_JUDGE_LEV_ZH };

            StringBuilder strSql = new StringBuilder();

            if (!string.IsNullOrEmpty(mod.C_PACK))
            {
                strSql.AppendFormat(@"SELECT T.C_MAT_CODE,
                                   T.C_BATCH_NO,
                                   T.C_STL_GRD,
                                   T.C_SPEC,
                                   SUM(T.N_WGT) N_WGT,
                                   COUNT(T.C_BATCH_NO) QUA,
                                   T.C_STD_CODE,
                                   T.C_JUDGE_LEV_ZH,
                                   T.C_BZYQ,
                                   T.C_LINEWH_CODE,
                                   A.C_ID,
                                   A.C_LINEWH_NAME
                              FROM TRC_ROLL_PRODCUT T LEFT JOIN TPB_LINEWH A ON A.C_LINEWH_CODE=T.C_LINEWH_CODE
                             WHERE T.C_MOVE_TYPE = 'E'
                               --AND T.C_JUDGE_LEV_ZH IN ('A', 'CK', 'AA', 'AAA')
                               AND T.C_IS_QR = 'Y' AND T.C_MAT_CODE='{0}' AND T.C_STD_CODE='{1}' AND T.C_BZYQ='{2}' AND T.C_JUDGE_LEV_ZH='{3}'", arr);
            }
            else
            {
                strSql.AppendFormat(@"SELECT T.C_MAT_CODE,
                                   T.C_BATCH_NO,
                                   T.C_STL_GRD,
                                   T.C_SPEC,
                                   SUM(T.N_WGT) N_WGT,
                                   COUNT(T.C_BATCH_NO) QUA,
                                   T.C_STD_CODE,
                                   T.C_JUDGE_LEV_ZH,
                                   T.C_BZYQ,
                                   T.C_LINEWH_CODE,
                                   A.C_ID,
                                   A.C_LINEWH_NAME
                              FROM TRC_ROLL_PRODCUT T LEFT JOIN TPB_LINEWH A ON A.C_LINEWH_CODE=T.C_LINEWH_CODE
                             WHERE T.C_MOVE_TYPE = 'E'
                               --AND T.C_JUDGE_LEV_ZH IN ('A', 'CK', 'AA', 'AAA')
                               AND T.C_IS_QR = 'Y' AND T.C_MAT_CODE='{0}' AND T.C_STD_CODE='{1}' AND (T.C_BZYQ='{2}' or T.C_BZYQ is null) AND T.C_JUDGE_LEV_ZH='{3}'", arr);
            }




            if (!string.IsNullOrEmpty(key))
            {
                strSql.AppendFormat(" AND T.C_LINEWH_CODE = '{0}'", key);
            }
            if (!string.IsNullOrEmpty(batch))
            {
                strSql.AppendFormat(" AND T.C_BATCH_NO = '{0}'", batch);
            }
            strSql.AppendFormat(@"GROUP BY T.C_MAT_CODE,
                                      T.C_BATCH_NO,
                                      T.C_STL_GRD,
                                      T.C_SPEC,
                                      T.C_STD_CODE,
                                      T.C_JUDGE_LEV_ZH,
                                      T.C_LINEWH_CODE,
                                      T.C_BZYQ,
                                      A.C_ID,
                                      A.C_LINEWH_NAME");

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取仓库位置
        /// </summary>
        /// <returns></returns>
        public DataSet GetLine_Slab_CK(string key, string type)
        {
            StringBuilder strSql = new StringBuilder();

            if (type == "1")
            {
                strSql.AppendFormat(@"SELECT T.C_ID, T.C_SLABWH_CODE as CKCODE, T.C_SLABWH_NAME AS CKNAME
          FROM TPB_SLABWH T
         WHERE T.N_STATUS = 1  and t.C_SLABWH_CODE in ('591', '592', '593') ");
                if (!string.IsNullOrEmpty(key))
                {
                    strSql.AppendFormat(" AND (T.C_SLABWH_CODE LIKE '%{0}%' OR T.C_SLABWH_NAME LIKE '%{0}%')", key);
                }
            }
            else
            {
                strSql.AppendFormat(@"SELECT T.C_ID, T.C_LINEWH_CODE as CKCODE, T.C_LINEWH_NAME AS CKNAME
          FROM tpb_linewh T  WHERE T.N_STATUS = 1 ");
                if (!string.IsNullOrEmpty(key))
                {
                    strSql.AppendFormat(" AND (T.C_LINEWH_CODE LIKE '%{0}%' OR T.C_LINEWH_NAME LIKE '%{0}%')", key);
                }
            }

            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取仓库位置
        /// </summary>
        /// <param name="key">仓库编码或仓库名称</param>
        /// <param name="fyID">发运明细ID</param>
        /// <returns></returns>
        public DataSet GetCK(string key, string fydID)
        {
            StringBuilder strSql = new StringBuilder();
            Dal_TMD_DISPATCHDETAILS dal = new Dal_TMD_DISPATCHDETAILS();
            Mod_TMD_DISPATCHDETAILS mod = dal.GetModel(fydID);
            string[] arr = { mod.C_MAT_CODE, mod.C_STD_CODE, mod.C_PACK, mod.C_JUDGE_LEV_ZH };
            string[] arr2 = { mod.C_MAT_CODE, mod.C_STD_CODE, mod.C_JUDGE_LEV_ZH };
            strSql.AppendFormat(@"WITH TT AS
                                     (SELECT TPB.C_ID,
                                             TPB.C_SLABWH_CODE      AS CKCODE,
                                             TPB.C_SLABWH_NAME      CKNAME,
                                             TPB.C_SLABWH_AREA_NAME CKAREA,
                                             TSC.QUA,
                                             TSC.N_WGT
                                        FROM (SELECT T.C_ID,
                                                     T.C_SLABWH_CODE,
                                                     T.C_SLABWH_NAME,
                                                     A.C_SLABWH_AREA_CODE,
                                                     A.C_SLABWH_AREA_NAME
                                                FROM TPB_SLABWH T
                                               INNER JOIN TPB_SLABWH_AREA A
                                                  ON A.C_SLABWH_ID = T.C_ID WHERE T.N_STATUS=1) TPB
                                        LEFT JOIN (SELECT COUNT(*) QUA,
                                                         SUM(NVL(T.N_WGT, 0)) N_WGT,
                                                         T.C_SLABWH_CODE,
                                                         T.C_SLABWH_AREA_CODE
                                                    FROM TSC_SLAB_MAIN T WHERE  T.C_MOVE_TYPE = 'E'
                                             AND T.C_JUDGE_LEV_ZH IN ('合格品')
                                             AND T.C_IS_QR = 'Y' ");

            strSql.AppendFormat(" AND T.C_MAT_CODE='{0}' AND T.C_STD_CODE='{1}' AND T.C_JUDGE_LEV_ZH='{2}'", arr2);

            strSql.AppendFormat(@"   GROUP BY T.C_SLABWH_CODE, T.C_SLABWH_AREA_CODE) TSC
                                          ON TSC.C_SLABWH_CODE = TPB.C_SLABWH_CODE
                                         AND TSC.C_SLABWH_AREA_CODE = TPB.C_SLABWH_AREA_CODE
                                      UNION
                                      SELECT TPB.C_ID,
                                             TPB.C_LINEWH_CODE      AS CKCODE,
                                             TPB.C_LINEWH_NAME      AS CKNAME,
                                             TPB.C_LINEWH_AREA_NAME AS CKAREA,
                                             TRC.QUA,
                                             TRC.N_WGT
                                        FROM (SELECT T.C_ID,
                                                     T.C_LINEWH_CODE,
                                                     T.C_LINEWH_NAME,
                                                     A.C_LINEWH_AREA_CODE,
                                                     A.C_LINEWH_AREA_NAME
                                                FROM TPB_LINEWH T
                                               INNER JOIN TPB_LINEWH_AREA A
                                                  ON A.C_LINEWH_ID = T.C_ID WHERE T.N_STATUS=1) TPB
                                        LEFT JOIN (SELECT COUNT(*) QUA,
                                                         SUM(NVL(T.N_WGT, 0)) N_WGT,
                                                         T.C_LINEWH_CODE,
                                                         T.C_LINEWH_AREA_CODE
                                                    FROM TRC_ROLL_PRODCUT T WHERE T.C_MOVE_TYPE = 'E'
                               AND T.C_IS_QR = 'Y' ");


            strSql.AppendFormat(" AND T.C_MAT_CODE='{0}' AND T.C_STD_CODE='{1}' AND T.C_BZYQ='{2}' AND T.C_JUDGE_LEV_ZH='{3}'", arr);

            strSql.AppendFormat(@"  GROUP BY T.C_LINEWH_CODE, T.C_LINEWH_AREA_CODE) TRC
                                          ON TRC.C_LINEWH_CODE = TPB.C_LINEWH_CODE
                                         AND TRC.C_LINEWH_AREA_CODE = TPB.C_LINEWH_AREA_CODE)
                                    SELECT C_ID, CKCODE, CKNAME, CKAREA, QUA, N_WGT FROM TT WHERE 1=1
                                    ");
            if (!string.IsNullOrEmpty(key))
            {
                strSql.AppendFormat(" AND (TT.CKCODE LIKE '%{0}%' OR TT.CKNAME LIKE '%{0}%')", key);
            }

            strSql.Append(" ORDER BY TT.N_WGT,TT.CKCODE");



            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取可发仓库线材量
        /// </summary>
        /// <param name="fydID">发运单明细主键</param>
        /// <returns></returns>
        public DataSet GetKFCK(string fydID)
        {
            StringBuilder strSql = new StringBuilder();
            Dal_TMD_DISPATCHDETAILS dal = new Dal_TMD_DISPATCHDETAILS();
            Mod_TMD_DISPATCHDETAILS mod = dal.GetModel(fydID);
            string[] arr = { mod?.C_MAT_CODE ?? "", mod?.C_STD_CODE ?? "", mod?.C_PACK ?? "", mod?.C_JUDGE_LEV_ZH ?? "" };

            strSql.AppendFormat(@"
 SELECT T.C_ID, T.C_LINEWH_CODE AS  CKCODE, T.C_LINEWH_NAME AS CKNAME,QUA,N_WGT
                  FROM TPB_LINEWH T
          LEFT JOIN (select nvl(tt.QUA,0) - nvl(tmd.FYZS,0) as QUA,
                           nvl(tt.N_WGT,0) - nvl(tmd.FYWGT,0) as N_WGT,
                           tt.C_LINEWH_CODE
                      from (SELECT COUNT(*) QUA,
                                   SUM(NVL(T.N_WGT, 0)) N_WGT,
                                   T.C_LINEWH_CODE
                              FROM TRC_ROLL_PRODCUT T
                             WHERE T.C_MOVE_TYPE = 'E'
                               AND T.C_IS_QR = 'Y'
                               AND T.C_MAT_CODE = '{0}'
                               AND T.C_STD_CODE = '{1}'
                               AND T.C_BZYQ = '{2}'
                               AND T.C_JUDGE_LEV_ZH = '{3}'
                             GROUP BY T.C_LINEWH_CODE) tt", arr);

            strSql.AppendFormat(@" left join (SELECT sum(nvl(t.n_fyzs, 0)) FYZS,
                                       sum(nvl(t.n_fywgt, 0)) FYWGT,
                                       t.C_SEND_STOCK_CODE
                                  FROM TMD_DISPATCHDETAILS T
                                 INNER JOIN TMD_DISPATCH A
                                    ON A.C_ID = T.C_DISPATCH_ID
                                 WHERE A.C_STATUS IN
                                       ('0', '2', '3', '4', '7', '10')
                                   and t.c_mat_code = '{0}'
                                   and t.c_std_code = '{1}'
                                   and t.c_pack = '{2}'
                                   and t.C_JUDGE_LEV_ZH = '{3}'
                                 group by t.C_SEND_STOCK_CODE) tmd
                        on tmd.C_SEND_STOCK_CODE = tt.C_LINEWH_CODE) TRC
            ON TRC.C_LINEWH_CODE = T.C_LINEWH_CODE
", arr);
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 线材仓库区域查询
        /// </summary>
        /// <param name="fydID">发运单主键</param>
        /// <param name="ckCode">仓库编码</param>
        /// <returns></returns>

        public DataSet GetKFCK_Area(string fydID, string ckCode)
        {
            Dal_TMD_DISPATCHDETAILS dal = new Dal_TMD_DISPATCHDETAILS();
            Mod_TMD_DISPATCHDETAILS mod = dal.GetModel(fydID);
            string[] arr = { mod.C_MAT_CODE, mod.C_STD_CODE, mod.C_PACK, mod.C_JUDGE_LEV_ZH, ckCode };
            string[] arr2 = { mod.C_MAT_CODE, mod.C_STD_CODE, mod.C_JUDGE_LEV_ZH };

            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"WITH TT AS
 (SELECT TPB.C_ID,
         TPB.C_SLABWH_CODE      AS CKCODE,
         TPB.C_SLABWH_NAME      CKNAME,
         TPB.C_SLABWH_AREA_NAME CKAREA,
         TSC.QUA,
         TSC.N_WGT
    FROM (SELECT T.C_ID,
                 T.C_SLABWH_CODE,
                 T.C_SLABWH_NAME,
                 A.C_SLABWH_AREA_CODE,
                 A.C_SLABWH_AREA_NAME
            FROM TPB_SLABWH T
           INNER JOIN TPB_SLABWH_AREA A
              ON A.C_SLABWH_ID = T.C_ID
           WHERE T.N_STATUS = 1) TPB
    LEFT JOIN (SELECT COUNT(*) QUA,
                     SUM(NVL(T.N_WGT, 0)) N_WGT,
                     T.C_SLABWH_CODE,
                     T.C_SLABWH_AREA_CODE
                FROM TSC_SLAB_MAIN T
               WHERE T.C_MOVE_TYPE = 'E'
                 AND T.C_IS_QR = 'Y'
                 AND T.C_MAT_CODE = '{0}'
                 AND T.C_STD_CODE = '{1}'
                 AND T.C_JUDGE_LEV_ZH ='{2}'
               GROUP BY T.C_SLABWH_CODE, T.C_SLABWH_AREA_CODE) TSC
      ON TSC.C_SLABWH_CODE = TPB.C_SLABWH_CODE", arr2);
            strSql.AppendFormat(@" AND TSC.C_SLABWH_AREA_CODE = TPB.C_SLABWH_AREA_CODE
  UNION
  SELECT TPB.C_ID,
         TPB.C_LINEWH_CODE      AS CKCODE,
         TPB.C_LINEWH_NAME      AS CKNAME,
         TPB.C_LINEWH_AREA_NAME AS CKAREA,
         TRC.QUA,
         TRC.N_WGT
    FROM (SELECT T.C_ID,
                 T.C_LINEWH_CODE,
                 T.C_LINEWH_NAME,
                 A.C_LINEWH_AREA_CODE,
                 A.C_LINEWH_AREA_NAME
            FROM TPB_LINEWH T
           INNER JOIN TPB_LINEWH_AREA A
              ON A.C_LINEWH_ID = T.C_ID
           WHERE T.N_STATUS = 1) TPB
    LEFT JOIN (SELECT COUNT(*) QUA,
                     SUM(NVL(T.N_WGT, 0)) N_WGT,
                     T.C_LINEWH_CODE,
                     T.C_LINEWH_AREA_CODE
                FROM TRC_ROLL_PRODCUT T
               WHERE T.C_MOVE_TYPE = 'E'
                 AND T.C_IS_QR = 'Y'
                 AND T.C_MAT_CODE = '{0}'
                 AND T.C_STD_CODE = '{1}'
                 AND T.C_BZYQ = '{2}'
                 AND T.C_JUDGE_LEV_ZH = '{3}'
              
               GROUP BY T.C_LINEWH_CODE, T.C_LINEWH_AREA_CODE) TRC
      ON TRC.C_LINEWH_CODE = TPB.C_LINEWH_CODE
     AND TRC.C_LINEWH_AREA_CODE = TPB.C_LINEWH_AREA_CODE)
SELECT C_ID, CKCODE, CKNAME, CKAREA, QUA, N_WGT FROM TT WHERE 1 = 1  AND TT.CKCODE='{4}' ORDER BY TT.N_WGT,TT.CKCODE
", arr);

            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion

        #region //发运单线材引入
        /// <summary>
        /// 发运单线材自由项引入
        /// </summary>
        /// <param name="matcode"></param>
        /// <param name="stdcode"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public DataSet GetFyd_Roll_Prodcut(string matcode, string stdcode, string area)
        {
            string[] arr = { matcode, stdcode, area };
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT DISTINCT T.C_MAT_CODE,
                                                T.C_STD_CODE,
                                                T.C_ZYX1,
                                                T.C_ZYX2,
                                                T.C_BZYQ,
                                                T.C_JUDGE_LEV_ZH,
                                                T.C_SALE_AREA
                                  FROM TRC_ROLL_PRODCUT T
                                 WHERE T.C_MOVE_TYPE = 'E'
                                   AND T.C_IS_QR = 'Y'
                                   AND T.C_MAT_CODE = '{0}'
                                   AND T.C_STD_CODE = '{1}'
                                   AND T.C_SALE_AREA = '{2}'", arr);
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 发运单头尾材线材自由项引入
        /// </summary>
        /// <param name="matcode"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public DataSet GetFyd_Roll_Prodcut_TWC(string matcode, string area)
        {
            string[] arr = { matcode, area };
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT DISTINCT T.C_MAT_CODE,
                                                T.C_STD_CODE,
                                                T.C_ZYX1,
                                                T.C_ZYX2,
                                                T.C_BZYQ,
                                                T.C_JUDGE_LEV_ZH,
                                                T.C_SALE_AREA
                                  FROM TRC_ROLL_PRODCUT T
                                 WHERE T.C_MOVE_TYPE = 'E'
                                   AND T.C_IS_QR = 'Y'
                                   AND T.C_MAT_CODE = '{0}'
                                   AND T.C_SALE_AREA = '{1}'", arr);
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

        #region //获取预测订单
        /// <summary>
        /// 获取需求订单
        /// </summary>
        /// <param name="matCode">物料编码</param>
        /// <param name="matName">物料名称</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="empname">业务员</param>
        /// <param name="saleArea">销售区域</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="status">订单状态</param>
        /// <param name="exeStatus">生产执行状态</param>
        /// <returns></returns>
        public DataSet GetNeedOrderList(string matCode, string matName, string stlGrd, string spec, string empname, string saleArea, string start, string end, string exeStatus, string custName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT T.C_ID,
                               T.C_ORDER_NO,
                               T.C_AREA,
                               T.C_MAT_CODE,
                               T.C_MAT_NAME,
                               T.C_STL_GRD,
                               T.C_SPEC,
                               T.C_FREE1,
                               T.C_FREE2,
                               T.C_PACK,
                               T.C_STD_CODE,
                               T.C_DESIGN_NO,
                               T.C_STDID,
                               T.C_DESIGNID,
                               T.C_VDEF1,
                               T.N_WGT,
                               T.D_NEED_DT,
                               T.D_DT,
                               T.N_STATUS,
                               DECODE(T.N_STATUS,
                                      0,
                                      '待审',
                                      1,
                                      '审核中',
                                      2,
                                      '生效',
                                      4,
                                      '审核通过',5,'冻结',6,'终止') N_STATUS2,
                               T.N_TYPE,
                               T.N_FLAG,
                               T.N_EXEC_STATUS,
                                DECODE(T.N_EXEC_STATUS,-2,'未提报',-1,'已提报',0,'已审核',5,'关闭',6,'生产完成',2,'已排轧钢 ') ZXZT,
                               T.C_LEV,
                               T.C_ORDER_LEV,
                               T.C_REMARK,
                               T.C_REMARK4,
                               T.C_EMP_ID,
                               T.C_EMP_NAME,
                               T.D_MOD_DT,
                               T.C_SFPJ,
                               T.C_CUST_NAME

                          FROM TMO_ORDER T  WHERE T.N_FLAG=1 AND T.N_EXEC_STATUS NOT IN(5)");

            if (!string.IsNullOrEmpty(matCode))
            {
                strSql.Append(" and T.C_MAT_CODE = '" + matCode + "'");
            }
            if (!string.IsNullOrEmpty(exeStatus))
            {
                strSql.Append(" and T.N_EXEC_STATUS = '" + exeStatus + "'");
            }


            if (!string.IsNullOrEmpty(empname))
            {
                strSql.Append(" and T.C_EMP_NAME ='" + empname + "'");
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.Append(" and UPPER(T.C_STL_GRD) like '%" + stlGrd.ToUpper() + "%'");
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.Append(" and T.C_SPEC like '" + spec + "%'");
            }
            if (!string.IsNullOrEmpty(saleArea))
            {
                strSql.Append(" and T.C_AREA = '" + saleArea + "'");
            }
            if (!string.IsNullOrEmpty(custName))
            {
                strSql.Append(" and T.C_CUST_NAME  like '%" + custName + "%'");
            }
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                strSql.Append(" and T.D_DT between to_date('" + Convert.ToDateTime(start).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            strSql.Append(" order by  T.C_MAT_NAME,T.C_STL_GRD, T.C_SPEC");



            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion

        #region //获取合同明细
        /// <summary>
        /// 获取合同明细
        /// </summary>
        /// <param name="custName">客户名称</param>
        /// <param name="conNo">合同号</param>
        /// <param name="empID">业务员</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="start">签署开始时间</param>
        /// <param name="end">签署结束时间</param>
        /// <param name="orderStatus">订单是否评价</param>
        /// <param name="exeStatus">执行状态</param>
        /// <param name="orderType">订单类型8线材，6钢坯，</param>
        /// <returns></returns>
        public DataSet GetConOrderList(string custName, string conNo, string empID, string stlGrd, string start, string end, string orderStatus, string exeStatus, string area, string status, int orderType, string spec)
        {
            //订单类型: 6 钢坯，8线材,851渣，841焦化，831废材,(805,806,807委外线材)

            StringBuilder strSql = new StringBuilder();

            string[] mattype = { "851", "841", "831" };

            if (mattype.Contains(orderType.ToString()))
            {
                #region //辅产品
                strSql.AppendFormat(@"SELECT TT.C_ID,
       TT.C_ORDER_NO,
       TT.C_CON_NO,
       TT.C_EMPLOYEEID,
       TT.C_APPROVEID,
       TT.C_RECEIPTCORPID,
       TT.C_FLOWID,
       TT.C_DEPTID,
       C_CON_NAME,
       TT.C_AREA,
       TT.C_CUST_NO,
       TT.C_CUST_NAME,
       TT.C_MAT_CODE,
       TT.C_MAT_NAME,
       TT.C_STL_GRD,
       TT.C_SPEC,
       TT.C_TECH_PROT,
       TT.C_FREE1,
       TT.C_FREE2,
       TT.C_PACK,
       TT.C_STD_CODE,
       TT.C_DESIGN_NO,
       TT.C_STDID,
       TT.C_DESIGNID,
       TT.C_VDEF1,
       TT.C_PRO_USE,
       TT.C_CUST_SQ,
       TT.C_FUNITID,
       TT.C_UNITID,
       TT.N_HSL,
       TT.N_FNUM,
       TT.N_WGT,
       TMD.YLXWGT,
       (TT.N_WGT - TMD.YLXWGT) AS DLXWGT,
       TT.N_TAXRATE,
       TT.N_ORIGINALCURPRICE,
       TT.N_ORIGINALCURTAXPRICE,
       TT.N_ORIGINALCURTAXMNY,
       TT.N_ORIGINALCURMNY,
       TT.N_ORIGINALCURSUMMNY,
       TT.D_NEED_DT,
       TT.D_DELIVERY_DT,
       TT.D_DT,
       TT.N_STATUS,
       TT.N_STATUS2,
       TT.N_TYPE,
       TT.N_FLAG,
       TT.N_EXEC_STATUS,
       TT.SCZT,
       TT.C_NCSTATUS2,
       TT.C_NCSTATUS,
       TT.N_USER_LEV,
       TT.C_LEV,
       TT.C_ORDER_LEV,
       TT.C_REMARK,
       TT.C_EMP_ID,
       TT.C_EMP_NAME,
       TT.D_MOD_DT,
       TT.C_SFPJ,
       TT.C_TRANSMODE,
       TT.C_YWY
  FROM (SELECT T.C_ID,
               T.C_ORDER_NO,
               T.C_CON_NO,
               B.C_NAME AS C_EMPLOYEEID, --业务员
               C.C_NAME AS C_APPROVEID, --审批人
               D.C_NAME AS C_RECEIPTCORPID, --收货单位
               E.C_NAME AS C_FLOWID, --审批流程
               F.C_NAME AS C_DEPTID, --部门
               T.C_CON_NAME,
               T.C_AREA,
               T.C_CUST_NO,
               T.C_CUST_NAME,
               T.C_MAT_CODE,
               T.C_MAT_NAME,
               T.C_STL_GRD,
               T.C_SPEC,
               T.C_TECH_PROT,
               T.C_FREE1,
               T.C_FREE2,
               T.C_PACK,
               T.C_STD_CODE,
               T.C_DESIGN_NO,
               T.C_STDID,
               T.C_DESIGNID,
               T.C_VDEF1,
               T.C_PRO_USE,
               T.C_CUST_SQ,
               T.C_FUNITID,
               T.C_UNITID,
               T.N_HSL,
               T.N_FNUM,
               T.N_WGT,
               T.N_TAXRATE,
               T.N_ORIGINALCURPRICE,
               T.N_ORIGINALCURTAXPRICE,
               T.N_ORIGINALCURTAXMNY,
               T.N_ORIGINALCURMNY,
               T.N_ORIGINALCURSUMMNY,
               T.D_NEED_DT,
               T.D_DELIVERY_DT,
               T.D_DT,
               T.N_STATUS,
               DECODE(T.N_STATUS,
                      -1,
                      '未提交',
                      0,
                      '待审',
                      1,
                      '审核中',
                      2,
                      '生效',
                      3,
                      '变更',
                      4,
                      '审核通过',
                      5,
                      '冻结',
                      6,
                      '终止') N_STATUS2,
               T.N_TYPE,
               T.N_FLAG,
               T.N_EXEC_STATUS,
               (CASE T.N_EXEC_STATUS
                 WHEN 5 THEN
                  '关闭'
                 WHEN 6 THEN
                  '生产完成'
                 WHEN 7 THEN
                  '库存货'
                 ELSE
                  ''
               END) SCZT,
               DECODE(T.C_NCSTATUS,
                      0,
                      '自由状态',
                      1,
                      '销售订单',
                      2,
                      '已导入NC') C_NCSTATUS2,
               T.C_NCSTATUS,
               T.N_USER_LEV,
               T.C_LEV,
               T.C_ORDER_LEV,
               T.C_REMARK,
               T.C_EMP_ID,
               T.C_EMP_NAME,
               T.D_MOD_DT,
               T.C_SFPJ,
               T.C_TRANSMODE,
               T.C_YWY
          FROM TMO_CON_ORDER T
          LEFT JOIN TMO_CON A
            ON A.C_CON_NO = T.C_CON_NO
          LEFT JOIN TS_SALE_EMP B
            ON B.C_ID = A.C_EMPLOYEEID
          LEFT JOIN TS_USER C
            ON C.C_ID = A.C_APPROVEID
          LEFT JOIN TS_CUSTFILE D
            ON D.C_NC_M_ID = T.C_RECEIPTCORPID
          LEFT JOIN TMB_FLOWINFO E
            ON E.C_ID = A.C_FLOWID
          LEFT JOIN TS_DEPT F
            ON F.C_ID = A.C_DEPTID) TT
  LEFT JOIN (SELECT SUM(NVL(A.N_JWGT, 0)) YLXWGT, A.C_NO
  FROM TMD_DISPATCHDETAILS A
 GROUP BY A.C_NO ) TMD
    ON TMD.C_NO = TT.C_ORDER_NO
 WHERE TT.N_TYPE={0}", orderType);

                if (!string.IsNullOrEmpty(area))
                {
                    strSql.Append(" and TT.C_AREA = '" + area + "'");
                }
                if (!string.IsNullOrEmpty(orderStatus))
                {
                    strSql.Append(" and TT.C_SFPJ = '" + orderStatus + "'");
                }
                if (!string.IsNullOrEmpty(status))
                {
                    strSql.Append(" and TT.N_STATUS in (" + status + ")");
                }
                if (!string.IsNullOrEmpty(exeStatus))
                {
                    strSql.Append(" and TT.C_NCSTATUS in (" + exeStatus + ")");
                }
                if (!string.IsNullOrEmpty(custName))
                {
                    strSql.Append(" and TT.C_CUST_NAME like '%" + custName + "%'");
                }
                if (!string.IsNullOrEmpty(conNo))
                {
                    strSql.Append(" and TT.C_CON_NO = '" + conNo + "'");
                }
                if (!string.IsNullOrEmpty(empID))
                {
                    strSql.Append(" and TT.C_YWY like '%" + empID + "%'");
                }
                if (!string.IsNullOrEmpty(stlGrd))
                {
                    strSql.Append(" and UPPER(TT.C_STL_GRD) like '%" + stlGrd.ToUpper() + "%'");
                }
                if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                {
                    strSql.Append(" and TT.D_DT BETWEEN to_date('" + Convert.ToDateTime(start).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
                }
                strSql.Append(" ORDER BY TT.D_DT ASC");

                #endregion
            }
            else
            {
                #region //线材/钢坯
                strSql.Append(@"SELECT TT.C_ID,
       TT.C_ORDER_NO,
       TT.C_CON_NO,
       TT.C_EMPLOYEEID,
       TT.C_APPROVEID,
       TT.C_RECEIPTCORPID,
       TT.C_FLOWID,
       TT.C_DEPTID,
       TT.C_CON_NAME,
       TT.C_AREA,
       TT.C_CUST_NO,
       TT.C_CUST_NAME,
       TT.C_MAT_CODE,
       TT.C_MAT_NAME,
       TT.C_STL_GRD,
       TT.C_SPEC,
       TT.C_TECH_PROT,
       TT.C_FREE1,
       TT.C_FREE2,
       TT.C_PACK,
       TT.C_STD_CODE,
       TT.C_DESIGN_NO,
       TT.C_STDID,
       TT.C_DESIGNID,
       TT.C_VDEF1,
       TT.C_PRO_USE,
       TT.C_CUST_SQ,
       TT.C_FUNITID,
       TT.C_UNITID,
       TT.N_HSL,
       TT.N_FNUM,
       TT.N_WGT,
       TRC.YLXWGT,
       (TT.N_WGT - NVL(TRC.YLXWGT, 0)) AS DLXWGT,
       NVL(TMO.XFWGT, 0) AS XFWGT,
       TT.N_TAXRATE,
       TT.N_ORIGINALCURPRICE,
       TT.N_ORIGINALCURTAXPRICE,
       TT.N_ORIGINALCURTAXMNY,
       TT.N_ORIGINALCURMNY,
       TT.N_ORIGINALCURSUMMNY,
       TT.D_NEED_DT,
       TO_CHAR(TT.D_DELIVERY_DT, 'YYYY-MM-DD') D_DELIVERY_DT,
       TO_CHAR(TT.D_DT, 'YYYY-MM-DD') D_DT2,
       TT.D_DT,
       TT.N_STATUS,
       TT.N_STATUS2,
       TT.N_TYPE,
       TT.N_FLAG,
       TT.N_EXEC_STATUS,
       DECODE(NVL(TMO.XFWGT, 0), 0, '已排产', '') AS SCZT,
       TT.C_NCSTATUS2,
       TT.C_NCSTATUS,
       TT.N_USER_LEV,
       TT.C_LEV,
       TT.C_ORDER_LEV,
       TT.C_REMARK,
       TT.C_EMP_ID,
       TT.C_EMP_NAME,
       TT.D_MOD_DT,
       TT.C_SFPJ,
       TT.C_TRANSMODE,
       TT.C_YWY,
       TT.C_ORDER_NO_OLD,
       (SELECT DECODE(B.C_FLAG,'-1','待审','已通知')
          FROM TMO_CON_END B
         WHERE B.C_CONNO = TT.C_CON_NO) TONGZHI
  FROM (SELECT T.C_ID,
               T.C_ORDER_NO,
               T.C_CON_NO,
               B.C_NAME AS C_EMPLOYEEID, --业务员
               C.C_NAME AS C_APPROVEID, --审批人
               D.C_NAME AS C_RECEIPTCORPID, --收货单位
               E.C_NAME AS C_FLOWID, --审批流程
               F.C_NAME AS C_DEPTID, --部门
               T.C_CON_NAME,
               T.C_AREA,
               T.C_CUST_NO,
               T.C_CUST_NAME,
               T.C_MAT_CODE,
               T.C_MAT_NAME,
               T.C_STL_GRD,
               T.C_SPEC,
               T.C_TECH_PROT,
               T.C_FREE1,
               T.C_FREE2,
               T.C_PACK,
               T.C_STD_CODE,
               T.C_DESIGN_NO,
               T.C_STDID,
               T.C_DESIGNID,
               T.C_VDEF1,
               T.C_PRO_USE,
               T.C_CUST_SQ,
               T.C_FUNITID,
               T.C_UNITID,
               T.N_HSL,
               T.N_FNUM,
               T.N_WGT,
               T.N_TAXRATE,
               T.N_ORIGINALCURPRICE,
               T.N_ORIGINALCURTAXPRICE,
               T.N_ORIGINALCURTAXMNY,
               T.N_ORIGINALCURMNY,
               T.N_ORIGINALCURSUMMNY,
               T.D_NEED_DT,
               T.D_DELIVERY_DT,
               T.D_DT,
               T.N_STATUS,
               DECODE(T.N_STATUS,
                      -1,
                      '未提交',
                      0,
                      '待审',
                      1,
                      '审核中',
                      2,
                      '生效',
                      3,
                      '变更',
                      4,
                      '审核通过',
                      5,
                      '冻结',
                      6,
                      '终止') N_STATUS2,
               T.N_TYPE,
               T.N_FLAG,
               T.N_EXEC_STATUS,
               (CASE T.N_EXEC_STATUS
                 WHEN 5 THEN
                  '关闭'
                 WHEN 6 THEN
                  '生产完成'
                 WHEN 7 THEN
                  '库存货'
                 ELSE
                  ''
               END) SCZT,
               DECODE(T.C_NCSTATUS,
                      0,
                      '自由状态',
                      1,
                      '销售订单',
                      2,
                      '已导入NC') C_NCSTATUS2,
               T.C_NCSTATUS,
               T.N_USER_LEV,
               T.C_LEV,
               T.C_ORDER_LEV,
               T.C_REMARK,
               T.C_EMP_ID,
               T.C_EMP_NAME,
               T.D_MOD_DT,
               T.C_SFPJ,
               T.C_TRANSMODE,
               T.C_YWY,
               T.C_ORDER_NO_OLD
          FROM TMO_CON_ORDER T
         INNER JOIN TMO_CON A
            ON A.C_CON_NO = T.C_CON_NO
          LEFT JOIN TS_SALE_EMP B
            ON B.C_ID = A.C_EMPLOYEEID
          LEFT JOIN TS_USER C
            ON C.C_ID = A.C_APPROVEID
          LEFT JOIN TS_CUSTFILE D
            ON D.C_NC_M_ID = T.C_RECEIPTCORPID
          LEFT JOIN TMB_FLOWINFO E
            ON E.C_ID = A.C_FLOWID
          LEFT JOIN TS_DEPT F
            ON F.C_ID = A.C_DEPTID) TT
  LEFT JOIN (SELECT SUM(NVL(G.N_JZ, 0)) YLXWGT, K.C_NO
               FROM TMD_DISPATCH_SJZJB G
              INNER JOIN TMD_DISPATCHDETAILS K
                 ON G.C_PK_NCID = K.C_ID
              GROUP BY K.C_NO
             UNION ALL
             select SUM(NVL(L.N_FYWGT, 0)) YLXWGT, L.C_NO
               from tmd_dispatchdetails L
              WHERE L.C_ORDER_TYPE in ('805', '806', '807','851','841')
              GROUP BY L.C_NO) TRC
    ON TRC.C_NO = TT.C_ORDER_NO
  LEFT JOIN (SELECT NVL(SUM(M.N_WGT), 0) XFWGT,
                    NVL(SUBSTR(M.C_ORDER_NO, 0, INSTR(M.C_ORDER_NO, '/') - 1),
                        M.C_ORDER_NO) C_ORDER_NO
               FROM TMO_ORDER M
              WHERE M.N_EXEC_STATUS IN (-1, 0, 6)
              GROUP BY NVL(SUBSTR(M.C_ORDER_NO,
                                  0,
                                  INSTR(M.C_ORDER_NO, '/') - 1),
                           M.C_ORDER_NO)) TMO
    ON NVL(SUBSTR(TMO.C_ORDER_NO, 0, INSTR(TMO.C_ORDER_NO, '/') - 1),
           TMO.C_ORDER_NO) = TT.C_ORDER_NO

 WHERE TT.N_TYPE IN (6, 8, 805, 806, 807,851,841)
   AND TT.N_FLAG IN (0)
   AND TT.N_STATUS != -1");


                if (!string.IsNullOrEmpty(area))
                {
                    strSql.Append(" and TT.C_AREA = '" + area + "'");
                }
                if (!string.IsNullOrEmpty(orderStatus))
                {
                    strSql.Append(" and TT.C_SFPJ = '" + orderStatus + "'");
                }
                if (!string.IsNullOrEmpty(status))
                {
                    strSql.Append(" and TT.N_STATUS in (" + status + ")");
                }
                if (!string.IsNullOrEmpty(exeStatus))
                {
                    strSql.Append(" and TT.C_NCSTATUS in (" + exeStatus + ")");
                }
                if (!string.IsNullOrEmpty(custName))
                {
                    strSql.Append(" and TT.C_CUST_NAME like '%" + custName + "%'");
                }
                if (!string.IsNullOrEmpty(conNo))
                {
                    strSql.Append(" and TT.C_CON_NO like '%" + conNo + "%'");
                }
                if (!string.IsNullOrEmpty(empID))
                {
                    strSql.Append(" and TT.C_YWY like '%" + empID + "%'");
                }
                if (!string.IsNullOrEmpty(stlGrd))
                {
                    strSql.Append(" and UPPER(TT.C_STL_GRD) like '%" + stlGrd.ToUpper() + "%'");
                }
                if (!string.IsNullOrEmpty(spec))
                {
                    strSql.Append(" and TT.C_SPEC like '%" + spec + "%'");
                }
                if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                {
                    strSql.Append(" and TT.D_DT between to_date('" + Convert.ToDateTime(start).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
                }
                strSql.Append(" ORDER BY TT.D_DT, TT.C_MAT_NAME,TT.C_STL_GRD,TT.C_SPEC ");



                #endregion
            }


            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取合同明细
        /// </summary>
        /// <param name="custName">客户名称</param>
        /// <param name="conNo">合同号</param>
        /// <param name="empID">业务员</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="start">签署开始时间</param>
        /// <param name="end">签署结束时间</param>
        /// <param name="orderStatus">订单是否评价</param>
        /// <param name="exeStatus">执行状态</param>
        /// <param name="orderType">订单类型8线材，6钢坯，</param>
        /// <returns></returns>
        public DataSet GetConOrderList(string custName, string conNo, string empID, string stlGrd, string start, string end, string orderStatus, string exeStatus, string area, string status, int orderType, string spec,string matcode)
        {
            //订单类型: 6 钢坯，8线材,851渣，841焦化，831废材,(805,806,807委外线材)

            StringBuilder strSql = new StringBuilder();

            string[] mattype = { "851", "841", "831" };

            if (mattype.Contains(orderType.ToString()))
            {
                #region //辅产品
                strSql.AppendFormat(@"SELECT TT.C_ID,
       TT.C_ORDER_NO,
       TT.C_CON_NO,
       TT.C_EMPLOYEEID,
       TT.C_APPROVEID,
       TT.C_RECEIPTCORPID,
       TT.C_FLOWID,
       TT.C_DEPTID,
       C_CON_NAME,
       TT.C_AREA,
       TT.C_CUST_NO,
       TT.C_CUST_NAME,
       TT.C_MAT_CODE,
       TT.C_MAT_NAME,
       TT.C_STL_GRD,
       TT.C_SPEC,
       TT.C_TECH_PROT,
       TT.C_FREE1,
       TT.C_FREE2,
       TT.C_PACK,
       TT.C_STD_CODE,
       TT.C_DESIGN_NO,
       TT.C_STDID,
       TT.C_DESIGNID,
       TT.C_VDEF1,
       TT.C_PRO_USE,
       TT.C_CUST_SQ,
       TT.C_FUNITID,
       TT.C_UNITID,
       TT.N_HSL,
       TT.N_FNUM,
       TT.N_WGT,
       TMD.YLXWGT,
       (TT.N_WGT - TMD.YLXWGT) AS DLXWGT,
       TT.N_TAXRATE,
       TT.N_ORIGINALCURPRICE,
       TT.N_ORIGINALCURTAXPRICE,
       TT.N_ORIGINALCURTAXMNY,
       TT.N_ORIGINALCURMNY,
       TT.N_ORIGINALCURSUMMNY,
       TT.D_NEED_DT,
       TT.D_DELIVERY_DT,
       TT.D_DT,
       TT.N_STATUS,
       TT.N_STATUS2,
       TT.N_TYPE,
       TT.N_FLAG,
       TT.N_EXEC_STATUS,
       TT.SCZT,
       TT.C_NCSTATUS2,
       TT.C_NCSTATUS,
       TT.N_USER_LEV,
       TT.C_LEV,
       TT.C_ORDER_LEV,
       TT.C_REMARK,
       TT.C_EMP_ID,
       TT.C_EMP_NAME,
       TT.D_MOD_DT,
       TT.C_SFPJ,
       TT.C_TRANSMODE,
       TT.C_YWY
  FROM (SELECT T.C_ID,
               T.C_ORDER_NO,
               T.C_CON_NO,
               B.C_NAME AS C_EMPLOYEEID, --业务员
               C.C_NAME AS C_APPROVEID, --审批人
               D.C_NAME AS C_RECEIPTCORPID, --收货单位
               E.C_NAME AS C_FLOWID, --审批流程
               F.C_NAME AS C_DEPTID, --部门
               T.C_CON_NAME,
               T.C_AREA,
               T.C_CUST_NO,
               T.C_CUST_NAME,
               T.C_MAT_CODE,
               T.C_MAT_NAME,
               T.C_STL_GRD,
               T.C_SPEC,
               T.C_TECH_PROT,
               T.C_FREE1,
               T.C_FREE2,
               T.C_PACK,
               T.C_STD_CODE,
               T.C_DESIGN_NO,
               T.C_STDID,
               T.C_DESIGNID,
               T.C_VDEF1,
               T.C_PRO_USE,
               T.C_CUST_SQ,
               T.C_FUNITID,
               T.C_UNITID,
               T.N_HSL,
               T.N_FNUM,
               T.N_WGT,
               T.N_TAXRATE,
               T.N_ORIGINALCURPRICE,
               T.N_ORIGINALCURTAXPRICE,
               T.N_ORIGINALCURTAXMNY,
               T.N_ORIGINALCURMNY,
               T.N_ORIGINALCURSUMMNY,
               T.D_NEED_DT,
               T.D_DELIVERY_DT,
               T.D_DT,
               T.N_STATUS,
               DECODE(T.N_STATUS,
                      -1,
                      '未提交',
                      0,
                      '待审',
                      1,
                      '审核中',
                      2,
                      '生效',
                      3,
                      '变更',
                      4,
                      '审核通过',
                      5,
                      '冻结',
                      6,
                      '终止') N_STATUS2,
               T.N_TYPE,
               T.N_FLAG,
               T.N_EXEC_STATUS,
               (CASE T.N_EXEC_STATUS
                 WHEN 5 THEN
                  '关闭'
                 WHEN 6 THEN
                  '生产完成'
                 WHEN 7 THEN
                  '库存货'
                 ELSE
                  ''
               END) SCZT,
               DECODE(T.C_NCSTATUS,
                      0,
                      '自由状态',
                      1,
                      '销售订单',
                      2,
                      '已导入NC') C_NCSTATUS2,
               T.C_NCSTATUS,
               T.N_USER_LEV,
               T.C_LEV,
               T.C_ORDER_LEV,
               T.C_REMARK,
               T.C_EMP_ID,
               T.C_EMP_NAME,
               T.D_MOD_DT,
               T.C_SFPJ,
               T.C_TRANSMODE,
               T.C_YWY
          FROM TMO_CON_ORDER T
          LEFT JOIN TMO_CON A
            ON A.C_CON_NO = T.C_CON_NO
          LEFT JOIN TS_SALE_EMP B
            ON B.C_ID = A.C_EMPLOYEEID
          LEFT JOIN TS_USER C
            ON C.C_ID = A.C_APPROVEID
          LEFT JOIN TS_CUSTFILE D
            ON D.C_NC_M_ID = T.C_RECEIPTCORPID
          LEFT JOIN TMB_FLOWINFO E
            ON E.C_ID = A.C_FLOWID
          LEFT JOIN TS_DEPT F
            ON F.C_ID = A.C_DEPTID) TT
  LEFT JOIN (SELECT SUM(NVL(A.N_JWGT, 0)) YLXWGT, A.C_NO
  FROM TMD_DISPATCHDETAILS A
 GROUP BY A.C_NO ) TMD
    ON TMD.C_NO = TT.C_ORDER_NO
 WHERE TT.N_TYPE={0}", orderType);

                if (!string.IsNullOrEmpty(area))
                {
                    strSql.Append(" and TT.C_AREA = '" + area + "'");
                }
                if (!string.IsNullOrEmpty(orderStatus))
                {
                    strSql.Append(" and TT.C_SFPJ = '" + orderStatus + "'");
                }
                if (!string.IsNullOrEmpty(status))
                {
                    strSql.Append(" and TT.N_STATUS in (" + status + ")");
                }
                if (!string.IsNullOrEmpty(exeStatus))
                {
                    strSql.Append(" and TT.C_NCSTATUS in (" + exeStatus + ")");
                }
                if (!string.IsNullOrEmpty(custName))
                {
                    strSql.Append(" and TT.C_CUST_NAME like '%" + custName + "%'");
                }
                if (!string.IsNullOrEmpty(conNo))
                {
                    strSql.Append(" and TT.C_CON_NO = '" + conNo + "'");
                }
                if (!string.IsNullOrEmpty(empID))
                {
                    strSql.Append(" and TT.C_YWY like '%" + empID + "%'");
                }
                if (!string.IsNullOrEmpty(stlGrd))
                {
                    strSql.Append(" and UPPER(TT.C_STL_GRD) like '%" + stlGrd.ToUpper() + "%'");
                }
                if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                {
                    strSql.Append(" and TT.D_DT BETWEEN to_date('" + Convert.ToDateTime(start).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
                }
                strSql.Append(" ORDER BY TT.D_DT ASC");

                #endregion
            }
            else
            {
                #region //线材/钢坯
                strSql.Append(@"SELECT TT.C_ID,
       TT.C_ORDER_NO,
       TT.C_CON_NO,
       TT.C_EMPLOYEEID,
       TT.C_APPROVEID,
       TT.C_RECEIPTCORPID,
       TT.C_FLOWID,
       TT.C_DEPTID,
       TT.C_CON_NAME,
       TT.C_AREA,
       TT.C_CUST_NO,
       TT.C_CUST_NAME,
       TT.C_MAT_CODE,
       TT.C_MAT_NAME,
       TT.C_STL_GRD,
       TT.C_SPEC,
       TT.C_TECH_PROT,
       TT.C_FREE1,
       TT.C_FREE2,
       TT.C_PACK,
       TT.C_STD_CODE,
       TT.C_DESIGN_NO,
       TT.C_STDID,
       TT.C_DESIGNID,
       TT.C_VDEF1,
       TT.C_PRO_USE,
       TT.C_CUST_SQ,
       TT.C_FUNITID,
       TT.C_UNITID,
       TT.N_HSL,
       TT.N_FNUM,
       TT.N_WGT,
       TRC.YLXWGT,
       (TT.N_WGT - NVL(TRC.YLXWGT, 0)) AS DLXWGT,
       NVL(TMO.XFWGT, 0) AS XFWGT,
       TT.N_TAXRATE,
       TT.N_ORIGINALCURPRICE,
       TT.N_ORIGINALCURTAXPRICE,
       TT.N_ORIGINALCURTAXMNY,
       TT.N_ORIGINALCURMNY,
       TT.N_ORIGINALCURSUMMNY,
       TT.D_NEED_DT,
       TO_CHAR(TT.D_DELIVERY_DT, 'YYYY-MM-DD') D_DELIVERY_DT,
       TO_CHAR(TT.D_DT, 'YYYY-MM-DD') D_DT2,
       TT.D_DT,
       TT.N_STATUS,
       TT.N_STATUS2,
       TT.N_TYPE,
       TT.N_FLAG,
       TT.N_EXEC_STATUS,
       DECODE(NVL(TMO.XFWGT, 0), 0, '已排产', '') AS SCZT,
       TT.C_NCSTATUS2,
       TT.C_NCSTATUS,
       TT.N_USER_LEV,
       TT.C_LEV,
       TT.C_ORDER_LEV,
       TT.C_REMARK,
       TT.C_EMP_ID,
       TT.C_EMP_NAME,
       TT.D_MOD_DT,
       TT.C_SFPJ,
       TT.C_TRANSMODE,
       TT.C_YWY,
       TT.C_ORDER_NO_OLD,
       (SELECT DECODE(B.C_FLAG,'-1','待审','已通知')
          FROM TMO_CON_END B
         WHERE B.C_CONNO = TT.C_CON_NO) TONGZHI
  FROM (SELECT T.C_ID,
               T.C_ORDER_NO,
               T.C_CON_NO,
               B.C_NAME AS C_EMPLOYEEID, --业务员
               C.C_NAME AS C_APPROVEID, --审批人
               D.C_NAME AS C_RECEIPTCORPID, --收货单位
               E.C_NAME AS C_FLOWID, --审批流程
               F.C_NAME AS C_DEPTID, --部门
               T.C_CON_NAME,
               T.C_AREA,
               T.C_CUST_NO,
               T.C_CUST_NAME,
               T.C_MAT_CODE,
               T.C_MAT_NAME,
               T.C_STL_GRD,
               T.C_SPEC,
               T.C_TECH_PROT,
               T.C_FREE1,
               T.C_FREE2,
               T.C_PACK,
               T.C_STD_CODE,
               T.C_DESIGN_NO,
               T.C_STDID,
               T.C_DESIGNID,
               T.C_VDEF1,
               T.C_PRO_USE,
               T.C_CUST_SQ,
               T.C_FUNITID,
               T.C_UNITID,
               T.N_HSL,
               T.N_FNUM,
               T.N_WGT,
               T.N_TAXRATE,
               T.N_ORIGINALCURPRICE,
               T.N_ORIGINALCURTAXPRICE,
               T.N_ORIGINALCURTAXMNY,
               T.N_ORIGINALCURMNY,
               T.N_ORIGINALCURSUMMNY,
               T.D_NEED_DT,
               T.D_DELIVERY_DT,
               T.D_DT,
               T.N_STATUS,
               DECODE(T.N_STATUS,
                      -1,
                      '未提交',
                      0,
                      '待审',
                      1,
                      '审核中',
                      2,
                      '生效',
                      3,
                      '变更',
                      4,
                      '审核通过',
                      5,
                      '冻结',
                      6,
                      '终止') N_STATUS2,
               T.N_TYPE,
               T.N_FLAG,
               T.N_EXEC_STATUS,
               (CASE T.N_EXEC_STATUS
                 WHEN 5 THEN
                  '关闭'
                 WHEN 6 THEN
                  '生产完成'
                 WHEN 7 THEN
                  '库存货'
                 ELSE
                  ''
               END) SCZT,
               DECODE(T.C_NCSTATUS,
                      0,
                      '自由状态',
                      1,
                      '销售订单',
                      2,
                      '已导入NC') C_NCSTATUS2,
               T.C_NCSTATUS,
               T.N_USER_LEV,
               T.C_LEV,
               T.C_ORDER_LEV,
               T.C_REMARK,
               T.C_EMP_ID,
               T.C_EMP_NAME,
               T.D_MOD_DT,
               T.C_SFPJ,
               T.C_TRANSMODE,
               T.C_YWY,
               T.C_ORDER_NO_OLD
          FROM TMO_CON_ORDER T
         INNER JOIN TMO_CON A
            ON A.C_CON_NO = T.C_CON_NO
          LEFT JOIN TS_SALE_EMP B
            ON B.C_ID = A.C_EMPLOYEEID
          LEFT JOIN TS_USER C
            ON C.C_ID = A.C_APPROVEID
          LEFT JOIN TS_CUSTFILE D
            ON D.C_NC_M_ID = T.C_RECEIPTCORPID
          LEFT JOIN TMB_FLOWINFO E
            ON E.C_ID = A.C_FLOWID
          LEFT JOIN TS_DEPT F
            ON F.C_ID = A.C_DEPTID) TT
  LEFT JOIN (SELECT SUM(NVL(G.N_JZ, 0)) YLXWGT, K.C_NO
               FROM TMD_DISPATCH_SJZJB G
              INNER JOIN TMD_DISPATCHDETAILS K
                 ON G.C_PK_NCID = K.C_ID
              GROUP BY K.C_NO
             UNION ALL
             select SUM(NVL(L.N_FYWGT, 0)) YLXWGT, L.C_NO
               from tmd_dispatchdetails L
              WHERE L.C_ORDER_TYPE in ('805', '806', '807','851','841')
              GROUP BY L.C_NO) TRC
    ON TRC.C_NO = TT.C_ORDER_NO
  LEFT JOIN (SELECT NVL(SUM(M.N_WGT), 0) XFWGT,
                    NVL(SUBSTR(M.C_ORDER_NO, 0, INSTR(M.C_ORDER_NO, '/') - 1),
                        M.C_ORDER_NO) C_ORDER_NO
               FROM TMO_ORDER M
              WHERE M.N_EXEC_STATUS IN (-1, 0, 6)
              GROUP BY NVL(SUBSTR(M.C_ORDER_NO,
                                  0,
                                  INSTR(M.C_ORDER_NO, '/') - 1),
                           M.C_ORDER_NO)) TMO
    ON NVL(SUBSTR(TMO.C_ORDER_NO, 0, INSTR(TMO.C_ORDER_NO, '/') - 1),
           TMO.C_ORDER_NO) = TT.C_ORDER_NO

 WHERE TT.N_TYPE IN (6, 8, 805, 806, 807,851,841)
   AND TT.N_FLAG IN (0)
   AND TT.N_STATUS != -1");

                if (!string.IsNullOrEmpty(matcode))
                {
                    strSql.Append(" and TT.C_MAT_CODE = '" + matcode + "'");
                }
                if (!string.IsNullOrEmpty(area))
                {
                    strSql.Append(" and TT.C_AREA = '" + area + "'");
                }
                if (!string.IsNullOrEmpty(orderStatus))
                {
                    strSql.Append(" and TT.C_SFPJ = '" + orderStatus + "'");
                }
                if (!string.IsNullOrEmpty(status))
                {
                    strSql.Append(" and TT.N_STATUS in (" + status + ")");
                }
                if (!string.IsNullOrEmpty(exeStatus))
                {
                    strSql.Append(" and TT.C_NCSTATUS in (" + exeStatus + ")");
                }
                if (!string.IsNullOrEmpty(custName))
                {
                    strSql.Append(" and TT.C_CUST_NAME like '%" + custName + "%'");
                }
                if (!string.IsNullOrEmpty(conNo))
                {
                    strSql.Append(" and TT.C_CON_NO like '%" + conNo + "%'");
                }
                if (!string.IsNullOrEmpty(empID))
                {
                    strSql.Append(" and TT.C_YWY like '%" + empID + "%'");
                }
                if (!string.IsNullOrEmpty(stlGrd))
                {
                    strSql.Append(" and UPPER(TT.C_STL_GRD) like '%" + stlGrd.ToUpper() + "%'");
                }
                if (!string.IsNullOrEmpty(spec))
                {
                    strSql.Append(" and TT.C_SPEC like '%" + spec + "%'");
                }
                if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
                {
                    strSql.Append(" and TT.D_DT between to_date('" + Convert.ToDateTime(start).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
                }
                strSql.Append(" ORDER BY TT.D_DT, TT.C_MAT_NAME,TT.C_STL_GRD,TT.C_SPEC ");



                #endregion
            }


            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion

        #region //获取订单已履行数量
        /// <summary>
        /// 获取订单已履行数量
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public DataRow GetOrderExeNum(string matCode, string orderNo, int flag)
        {

            StringBuilder strSql = new StringBuilder();

            //订单类型: 6 钢坯，8线材,851渣，841焦化，831废材,(805,806,807委外线材)

            if (flag == 8 || flag == 6)
            {
                strSql.AppendFormat(@"SELECT NVL(SUM(G.N_JZ),0) YLXNUM, K.C_NO
                                          FROM TMD_DISPATCH_SJZJB G
                                         INNER JOIN TMD_DISPATCHDETAILS K
                                            ON G.C_PK_NCID = K.C_ID WHERE K.C_NO='{0}'
                                         GROUP BY K.C_NO", orderNo);
            }
            else
            {
                strSql.AppendFormat(@"SELECT NVL(SUM(A.N_JWGT),0) YLXNUM, A.C_NO
                                          FROM TMD_DISPATCHDETAILS A where A.C_NO='{0}'
                                         GROUP BY A.C_NO", orderNo);
            }

            return DbHelperOra.GetDataRow(strSql.ToString());
        }
        #endregion

        #region//生成销售订单&日计划

        /// <summary>
        /// 生成销售订单&日计划
        /// </summary>
        /// <param name="empID">操作人ID</param>
        /// <param name="orderList">订单主键ID</param>
        /// <returns></returns>
        public bool CreateSaleOrderDayPlan(string empID, List<string> orderList)
        {
            bool result = false;


            string pkid = Guid.NewGuid().ToString("N");//销售主键ID
            string salecode = Dal_RandomNumber.GetSaleCode();//销售单据号
            string D_NC_DATE = DateTime.Now.ToString();//单据号时间

            for (int i = 0; i < orderList.Count; i++)
            {
                ArrayList arraySql = new ArrayList();

                #region //销售订单
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update TMO_CON_ORDER set C_NCSTATUS='1',C_NC_ID='" + pkid + "',C_NC_SALECODE='" + salecode + "',D_NC_DATE=to_date('" + D_NC_DATE + "', 'yyyy-mm-dd hh24:mi:ss') where C_ID='" + orderList[i] + "'");
                arraySql.Add(strSql.ToString());
                #endregion

                #region //日计划
                Mod_TMO_ORDER modOrder = GetModel(orderList[i]);
                Dal_TMO_CON tmo_con = new Dal_TMO_CON();
                Mod_TMO_CON modCon = tmo_con.GetModel(modOrder.C_CON_NO);

                string dayCode = Dal_RandomNumber.GetDayPlanCode();//日计划单据号
                StringBuilder cmdText3 = new StringBuilder();
                cmdText3.Append("insert into TMP_DAYPLAN(");
                cmdText3.Append(@"C_PLCODE,
                                                C_PKBILLB,
                                                C_PKBILLH,
                                                C_CONNO,
                                                C_ORDERNO,
                                                C_PKINV,
                                                C_PKASSISTMEASURE,
                                                N_ASSISTNUM,
                                                N_NUM,
                                                N_UNITPRICE,
                                                N_MONEY,
                                                D_PLANDATE,
                                                D_ORDSNDATE,
                                                D_REQUIREDATE,
                                                D_SNDDATE,
                                                C_PKCUST,
                                                C_PKSENDTYPE,
                                                C_PKSALEORG,
                                                C_PKOPERATOR,
                                                C_PKOPRDEPART,
                                                C_PKPLANPERSON,
                                                C_PKAPPRPERSON,
                                                D_APPRDATE,
                                                C_PKARRIVEAREA,
                                                C_DESTADDRESS,
                                                C_RECEIPTCORPID,
                                                C_BIZTYPE,
                                                C_UNITID,
                                                C_VFREE1,
                                                C_VFREE2,
                                                C_VFREE3,
                                                C_VFREE4,
                                                C_SALECODE)");
                cmdText3.Append(" values (");
                cmdText3.Append("'" + dayCode + "',");//日计划单据号
                cmdText3.Append("'" + modOrder.C_ID + "',");//来源销售订单子表ID
                cmdText3.Append("'" + pkid + "',");//来源销售订单主表ID
                cmdText3.Append("'" + modOrder.C_CON_NO + "',");//合同号
                cmdText3.Append("'" + modOrder.C_ORDER_NO + "',");//订单号
                cmdText3.Append("'" + modOrder.C_INVENTORYID + "',");//存货主键
                cmdText3.Append("'" + modOrder.C_FUNITID + "',");//辅计量单位ID
                if (!string.IsNullOrEmpty(modOrder.N_FNUM.ToString()))
                {
                    cmdText3.Append("" + modOrder.N_FNUM + ",");//辅数量
                }
                else
                {
                    cmdText3.Append("0,");//辅数量
                }
                cmdText3.Append("" + modOrder.N_WGT + ",");//主数量
                cmdText3.Append("" + modOrder.N_ORIGINALCURTAXPRICE + ",");//单价
                cmdText3.Append("" + modOrder.N_ORIGINALCURSUMMNY + ","); //订单金额
                cmdText3.Append("to_date('" + modOrder.D_DT + "','yyyy-mm-dd hh24:mi:ss'),");//日计划日期
                cmdText3.Append("to_date('" + modOrder.D_DELIVERY_DT + "','yyyy-mm-dd hh24:mi:ss'),");//定单要求发货日期
                cmdText3.Append("to_date('" + modOrder.D_DELIVERY_DT + "','yyyy-mm-dd hh24:mi:ss'),");//定单要求到货日期
                cmdText3.Append("to_date('" + modOrder.D_DELIVERY_DT + "','yyyy-mm-dd hh24:mi:ss'),");//实际发货日期
                cmdText3.Append("'" + modCon.C_CUSTOMERID + "',");//客户ID
                cmdText3.Append("'" + modCon.C_TRANSMODEID + "',");//发运方式ID
                cmdText3.Append("'" + modCon.C_SALECORPID + "',");//销售组织ID
                cmdText3.Append("'" + modCon.C_EMPLOYEEID + "',");//业务员ID
                cmdText3.Append("'" + modCon.C_DEPTID + "',");//业务部门ID
                cmdText3.Append("'" + empID + "',"); //计划人ID
                cmdText3.Append("'" + empID + "',");//审批人ID
                //cmdText3.Append("'" + modCon.C_APPROVEID + "',");//审批人ID
                cmdText3.Append("to_date('" + modCon.D_APPROVEDATE + "','yyyy-mm-dd hh24:mi:ss'),"); //审批日期
                cmdText3.Append("'" + modCon.C_CRECEIPTAREAID + "',");//到货地区ID
                cmdText3.Append("'" + modCon.C_ADDRESS + "',");//到货地址
                cmdText3.Append("'" + modCon.C_CRECEIPTCUSTOMERID + "',");//收货单位ID
                cmdText3.Append("'" + modCon.C_BIZTYPE + "',");//业务类型ID
                cmdText3.Append("'" + modOrder.C_UNITID + "',");//计量单位ID
                cmdText3.Append("'" + modOrder.C_FREE1 + "',");//自由项1
                cmdText3.Append("'" + modOrder.C_FREE2 + "',");//自由项2
                cmdText3.Append("'" + modOrder.C_PACK + "',");//包装要求
                cmdText3.Append("'" + modOrder.C_VDEF1 + "',");//质量等级
                cmdText3.Append("'" + salecode + "'");//销售单据号
                cmdText3.Append(")");
                arraySql.Add(cmdText3);
                #endregion

                result = DbHelperOra.ExecuteSqlTran(arraySql);

            }

            return result;

        }
        #endregion

        #region //获取销售单据号 
        public DataSet GetSaleCode(string custName, string conNO, string empID, string startTime, string endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"with t as (select distinct c_nc_id,C_NC_SALECODE, D_NC_DATE,C_CON_NO,C_CUST_NAME,C_NCSTATUS 
                                        from TMO_CON_ORDER  where c_nc_id is not null and C_NCSTATUS in (1, 2)");

            if (!string.IsNullOrEmpty(custName))
            {
                strSql.Append("  and C_CUST_NAME like '%" + custName + "%'");
            }
            if (!string.IsNullOrEmpty(conNO))
            {
                strSql.Append("  and C_CON_NO  like '%" + conNO + "%'");
            }
            if (!string.IsNullOrEmpty(empID))
            {
                strSql.Append("  and C_YWY  like '%" + empID + "%'");
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.Append(" and D_NC_DATE between to_date('" + Convert.ToDateTime(startTime).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(endTime).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            strSql.Append(")");
            strSql.Append(@"select c_nc_id,
                           C_NC_SALECODE,
                           D_NC_DATE,
                           C_CON_NO,
                           C_CUST_NAME,
                           decode(C_NCSTATUS,1,'自由状态',2,'已导入NC') N_EXEC_STATUS
                      from t order by D_NC_DATE desc");
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

        #region //获取销售单据号下订单
        public DataSet GetSaleOrder(string saleCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select t.C_ID,
                               t.C_ORDER_NO,
                               t.C_CON_NO,
                               t.C_RECEIPTCORPID,
                               t.C_CON_NAME,
                               t.C_AREA,
                               t.C_CUST_NO,
                               t.C_CUST_NAME,
                               t.C_SALE_CHANNEL,
                               t.C_CURRENCYTYPEID,
                               t.C_RECEIVEADDRESS,
                               t.C_PROD_NAME,
                               t.C_PROD_KIND,
                               t.C_INVBASDOCID,
                               t.C_INVENTORYID,
                               t.C_MAT_CODE,
                               t.C_MAT_NAME,
                               t.C_STL_GRD,
                               t.C_SPEC,
                               t.C_TECH_PROT,
                               t.C_FREE1,
                               t.C_FREE2,
                               t.C_PACK,
                               t.C_STD_CODE,
                               t.C_DESIGN_NO,
                               t.C_STDID,
                               t.C_DESIGNID,
                               t.C_VDEF1,
                               t.C_PRO_USE,
                               t.C_CUST_SQ,
                               t.C_FUNITID,
                               t.C_UNITID,
                               t.N_HSL,
                               t.N_FNUM,
                               t.N_WGT,
                               t.N_PROFIT,
                               t.N_COST,
                               t.N_TAXRATE,
                               t.N_ORIGINALCURPRICE,
                               t.N_ORIGINALCURTAXPRICE,
                               t.N_ORIGINALCURTAXMNY,
                               t.N_ORIGINALCURMNY,
                               t.N_ORIGINALCURSUMMNY,
                               t.D_NEED_DT,
                               t.D_DELIVERY_DT,
                               t.D_DT,
                               t.N_STATUS,
                               t.N_TYPE,
                               t.N_FLAG,
                               t.N_EXEC_STATUS,
                               decode(t.C_NCSTATUS,1,'自由状态',2,'已导入NC') C_NCSTATUS,
                               t.N_USER_LEV,
                               t.C_LEV,
                               t.C_ORDER_LEV,
                               t.C_REMARK,
                               t.C_EMP_ID,
                               t.C_EMP_NAME,
                               t.D_MOD_DT,
                               t.C_SFPJ,
                               t.C_TRANSMODE,
                               t.C_XGID,
                               t.C_NC_ID,
                               t.D_NC_DATE,
                               t.C_YWY,
                               t.C_NC_SALECODE,
                               p.C_PLCODE,
                               p.N_EXEC_STATUS as PLANEXE,
                               decode(p.N_EXEC_STATUS,0,'自由状态',1,'已导入NC')PLANEXE2,
                               p.c_id as PLANID
                               FROM TMO_CON_ORDER t,tmp_dayplan p where t.c_id=p.c_pkbillb
                         and t.C_NC_SALECODE='" + saleCode + "' order by t.C_MAT_NAME,t.C_STL_GRD,t.C_SPEC");




            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

        #region //根据销售单据号更新执行状态
        /// <summary>
        /// 更新销售订单导入NC状态
        /// </summary>
        /// <param name="status">0自由，1已导入NC</param>
        /// <param name="saleCode">销售单据号</param>
        /// <returns></returns>
        public bool UpdateExeStatus(int status, string saleCode)
        {
            StringBuilder strsSql = new StringBuilder();
            strsSql.Append("update TMO_CON_ORDER set C_NCSTATUS='" + status + "',D_NS_SEND_DT=to_date('" + DateTime.Now + "', 'yyyy-mm-dd hh24:mi:ss')  where C_NC_SALECODE='" + saleCode + "'");
            return DbHelperOra.ExecuteSql(strsSql.ToString()) > 0 ? true : false;
        }
        #endregion

        #region //订单跟踪
        /// <summary>
        /// 订单跟踪
        /// </summary>
        /// <param name="conNo">合同号</param>
        /// <param name="startDate">签单开始时间</param>
        /// <param name="endDate">签单截至时间</param>
        /// <param name="custNo">客户编码</param>
        /// <returns></returns>
        public DataSet GetOrderJL(int pageSize, int pageIndex, string conNo, string startDate, string endDate, string custNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select t.c_con_no,
                                           t.c_mat_name,
                                           t.c_stl_grd,
                                           t.c_spec,
                                           t.c_pack,
                                           t.n_wgt,
                                           decode(t.n_status,
                                                  -1,
                                                  '未提交',
                                                  0,
                                                  '待审',
                                                  1,
                                                  '审核中',
                                                  2,
                                                  '生效',
                                                  3,
                                                  '变更',
                                                  4,
                                                  '审核通过') n_status,
                                           (case t.N_EXEC_STATUS
                                             when 6 then
                                              '生产完成'
                                             else
                                              (case t.n_type
                                                when 8 then
                                                 (case t.N_ROLL_PROD_WGT
                                                   when 0 then
                                                    ''
                                                   else
                                                    '生产中'
                                                 end)
                                                when 6 then
                                                 (case t.N_SMS_PROD_WGT
                                                   when 0 then
                                                    ''
                                                   else
                                                    '生产中'
                                                 end)
                                              end)
                                           end) sczt,
                                           (case t.n_type
                                             when 8 then
                                              (select nvl(sum(a.N_WGT), 0)
                                                 from trc_roll_prodcut a
                                                where a.c_mat_code =t.c_mat_code
                                                  and a.C_FYDH in (select distinct b.c_dispatch_id
                                                                     from tmd_dispatchdetails b
                                                                    where b.c_no = t.c_order_no)
                                                  and a.C_MOVE_TYPE = 'S')
                                             when 6 then
                                              (select nvl(sum(c.N_WGT), 0)
                                                 from tsc_slab_main c
                                                where c.c_mat_code = t.c_mat_code
                                                  and c.C_FYDH in (select distinct d.c_dispatch_id
                                                                     from tmd_dispatchdetails d
                                                                    where d.c_no = t.c_order_no)
                                                  and c.C_MOVE_TYPE = 'S')
                                           end) ylxNUM,t.C_ORDER_NO
                                      from TMO_CON_ORDER t where t.c_cust_no='{0}'
                                    ", custNo);
            if (!string.IsNullOrEmpty(conNo))
            {
                strSql.Append(" and t.c_con_no='" + conNo + "'");
            }
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                strSql.Append(" and t.D_DT between to_date('" + startDate + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }


            return DataSetHelper.SplitDataSet(DbHelperOra.Query(strSql.ToString()), pageSize, pageIndex);
        }

        /// <summary>
        /// 订单跟踪
        /// </summary>
        /// <param name="conNo">合同号</param>
        /// <param name="startDate">签单开始时间</param>
        /// <param name="endDate">签单截至时间</param>
        /// <param name="custNo">客户编码</param>
        /// <returns></returns>
        public DataSet GetOrderJL(string conNo, string startDate, string endDate, string custNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select t.c_con_no,
                                           t.c_mat_name,
                                           t.c_stl_grd,
                                           t.c_spec,
                                           t.c_pack,
                                           t.n_wgt,
                                           decode(t.n_status,
                                                  -1,
                                                  '未提交',
                                                  0,
                                                  '待审',
                                                  1,
                                                  '审核中',
                                                  2,
                                                  '生效',
                                                  3,
                                                  '变更',
                                                  4,
                                                  '审核通过') n_status,
                                           (case t.N_EXEC_STATUS
                                             when 6 then
                                              '生产完成'
                                             else
                                              (case t.n_type
                                                when 8 then
                                                 (case t.N_ROLL_PROD_WGT
                                                   when 0 then
                                                    ''
                                                   else
                                                    '生产中'
                                                 end)
                                                when 6 then
                                                 (case t.N_SMS_PROD_WGT
                                                   when 0 then
                                                    ''
                                                   else
                                                    '生产中'
                                                 end)
                                              end)
                                           end) sczt,
                                           (case t.n_type
                                             when 8 then
                                              (select nvl(sum(a.N_WGT),0)
                                                 from trc_roll_prodcut a
                                                where a.c_mat_code =t.c_mat_code
                                                  and a.C_FYDH in (select distinct b.c_dispatch_id
                                                                     from tmd_dispatchdetails b
                                                                    where b.c_no = t.c_order_no)
                                                  and a.C_MOVE_TYPE = 'S')
                                             when 6 then
                                              (select nvl(sum(c.N_WGT),0)
                                                 from tsc_slab_main c
                                                where c.c_mat_code = t.c_mat_code
                                                  and c.C_FYDH in (select distinct d.c_dispatch_id
                                                                     from tmd_dispatchdetails d
                                                                    where d.c_no = t.c_order_no)
                                                  and c.C_MOVE_TYPE = 'S')
                                           end) ylxNUM,t.C_ORDER_NO 
                                      from TMO_CON_ORDER t where t.n_status <>-1 and t.c_cust_no='{0}'
                                    ", custNo);
            if (!string.IsNullOrEmpty(conNo))
            {
                strSql.Append(" and t.c_con_no='" + conNo + "'");
            }
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                strSql.Append(" and t.D_DT between to_date('" + startDate + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }


            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

        #region//合同跟踪

        /// <summary>
        /// 合同跟踪
        /// </summary>
        /// <param name="custName">客户名称</param>
        /// <param name="saleEmp">销售员</param>
        /// <param name="conNo">合同号</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns></returns>
        public DataSet GetConTrace(string custName, string saleEmp, string conNo, string startDate, string endDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
                                with a as
                                 (select t.c_con_no,
                                         t.c_area,
                                         t.c_mat_code,
                                         t.c_mat_name,
                                         t.c_stl_grd,
                                         t.c_spec,
                                         t.c_free1,
                                         t.c_free2,
                                         t.c_pack,
                                         t.n_wgt,
                                         t.N_SMS_PROD_WGT,
                                         t.N_ROLL_PROD_WGT,
                                         t.n_type,
                                         t.C_ORDER_NO,
                                         sum(b.n_wgt) rollwgt,
                                         sum(c.n_wgt) slabwgt,
                                         t.c_cust_name,
                                         t.c_ywy,
                                         t.d_dt,
                                         t.d_delivery_dt
                                    from TMO_CON_ORDER t
                                    left join trc_roll_prodcut b
                                      on b.c_order_no = t.c_order_no
                                    left join tsc_slab_main c
                                      on c.c_ord_no = t.c_order_no
                                   group by t.c_con_no,
                                            t.c_area,
                                            t.c_mat_code,
                                            t.c_mat_name,
                                            t.c_stl_grd,
                                            t.c_spec,
                                            t.c_free1,
                                            t.c_free2,
                                            t.c_pack,
                                            t.n_wgt,
                                            t.N_SMS_PROD_WGT,
                                            t.N_ROLL_PROD_WGT,
                                            t.n_type,
                                            t.C_ORDER_NO,
                                            t.c_cust_name,
                                            t.c_ywy,
                                            t.d_dt,
                                            t.d_delivery_dt)
                                select a.c_con_no,
                                       a.c_area,
                                       a.c_mat_code,
                                       a.c_mat_name,
                                       a.c_stl_grd,
                                       a.c_spec,
                                       a.c_free1,
                                       a.c_free2,
                                       a.c_pack,
                                       a.n_wgt,
                                       a.N_SMS_PROD_WGT,
                                       a.N_ROLL_PROD_WGT,
                                       a.n_type,
                                       a.C_ORDER_NO,
                                       a.c_cust_name,
                                       a.c_ywy,
                                       a.d_dt,
                                       a.d_delivery_dt,
                                       (case a.n_type
                                         when 8 then
                                          rollwgt
                                         when 6 then
                                          slabwgt
                                       end) scwgt
                                  from a where  a.n_type in(8,6)");
            if (!string.IsNullOrEmpty(custName))
            {
                strSql.Append(" and a.c_cust_name like'" + custName + "%'");
            }
            if (!string.IsNullOrEmpty(saleEmp))
            {
                strSql.Append(" and a.c_ywy like'" + saleEmp + "%'");
            }
            if (!string.IsNullOrEmpty(conNo))
            {
                strSql.Append(" and a.c_con_no='" + conNo + "'");
            }
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                strSql.Append(" and a.D_DT between to_date('" + startDate + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据订单号获取线材或钢坯
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public DataSet GetRollAndSlab(string orderNo, string flag)
        {
            StringBuilder strsSql = new StringBuilder();
            switch (flag)
            {
                case "8":
                    #region//线材
                    strsSql.AppendFormat(@"select t.c_batch_no,
                                           t.c_con_no,
                                           t.c_stl_grd,
                                           t.c_spec,
                                           count(0) jianshu,
                                           sum(t.n_wgt) sumwgt,
                                           t.C_JUDGE_LEV_ZH,
                                           t.C_LINEWH_CODE,
                                           a.c_sta_desc
                                      from trc_roll_prodcut t
                                      left join tb_sta a
                                        on t.c_sta_id = a.c_id
                                     where a.n_status = 1 and t.c_order_no='{0}'
                                     group by t.c_batch_no,
                                              t.c_con_no,
                                              t.c_stl_grd,
                                              t.c_spec,
                                              t.C_JUDGE_LEV_ZH,
                                              t.C_LINEWH_CODE,
                                              a.c_sta_desc", orderNo);
                    #endregion
                    break;
                case "6":
                    #region //钢坯
                    strsSql.AppendFormat(@"select t.C_STOVE,
                                       t.c_con_no,
                                       t.c_stl_grd,
                                       t.c_spec,
                                       count(0) jianshu,
                                       sum(t.n_wgt) sumwgt,
                                       t.C_JUDGE_LEV_ZH,
                                       t.C_SLABWH_CODE,
                                       t.C_STA_DESC
                                  from tsc_slab_main t
                                  left join tb_sta a
                                    on t.c_sta_id = a.c_id
                                 where a.n_status = 1 and t.C_ORD_NO='{0}'
                                 group by t.C_STOVE,
                                          t.c_con_no,
                                          t.c_stl_grd,
                                          t.c_spec,
                                          t.C_JUDGE_LEV_ZH,
                                          t.C_SLABWH_CODE,
                                          t.C_STA_DESC ", orderNo);

                    #endregion
                    break;
            }

            return DbHelperOra.Query(strsSql.ToString());
        }

        #endregion

        #region //删除销售订单/日计划
        public bool DelSalePlan(string NCID)
        {
            ArrayList arraySql = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            //删除日计划
            string strcmd = string.Format("DELETE FROM TMP_DAYPLAN T WHERE T.C_PKBILLH='{0}'", NCID);
            arraySql.Add(strcmd);
            //删除销售订单
            string strcmd2 = string.Format("UPDATE TMO_CON_ORDER T SET T.C_NC_SALECODE='',T.D_NC_DATE='',T.C_NC_ID='',T.C_NCSTATUS=0 WHERE T.C_NC_ID='{0}'", NCID);
            arraySql.Add(strcmd2);
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }


        public bool DelDayPlan(List<Mod_TMP_DAYPLAN> list)
        {
            ArrayList arraySql = new ArrayList();
            foreach (var item in list)
            {
                string strSql = $"DELETE FROM TMP_DAYPLAN T WHERE T.C_ID='{item.C_ID}'";
                arraySql.Add(strSql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        ///NC销售订单/日计划是否删除
        /// </summary>
        /// <param name="NCID"></param>
        /// <returns></returns>
        public bool DelNCSalePlan(string NCID)
        {
            bool result = true;

            //NC日计划
            DataTable dtplan = DbHelperOra.Query("select t.c_id,t.c_plcode from tmp_dayplan T WHERE T.C_PKBILLH='" + NCID + "'").Tables[0];
            for (int i = 0; i < dtplan.Rows.Count; i++)
            {
                object objplan = DbHelperNC.GetSingle("select count(*) from XGERP50.dm_delivdaypl  where  vfree9 ='" + dtplan.Rows[i]["C_ID"] + "' and  pksalecorp='1001'  and dr=0");
                if (objplan != null && Convert.ToInt32(objplan) > 0)
                {
                    result = false;
                    break;
                }
            }

            if (result)
            {
                //NC销售订单
                object obj = DbHelperNC.GetSingle("select count(*) from  XGERP50.so_sale where vdef20 ='" + NCID + "'  and pk_corp='1001' and dr =0");
                if (obj != null && Convert.ToInt32(obj) > 0)
                {
                    result = false;
                }
            }
            return result;
        }
        #endregion

        #region //获取原合同剩余总量

        /// <summary>
        /// 获取原合同订单数量
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public string GetOrderWgt(string orderNo)
        {
            string result = "0";
            string strsql = string.Format("SELECT T.N_WGT, T.C_ORDER_NO, T.C_MAT_CODE,T.N_TYPE   FROM TMO_CON_ORDER T WHERE T.C_ORDER_NO = '{0}'", orderNo);
            DataTable dt = DbHelperOra.Query(strsql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                result = dt.Rows[0]["N_WGT"].ToString();
            }
            return result;
        }
        /// <summary>
        /// 获取原始合同剩余总量
        /// </summary>
        /// <param name="conNo">合同号</param>
        /// <returns></returns>
        public string GetConSumWgt(string conNo)
        {
            string strsql = string.Format("SELECT T.N_WGT, T.C_ORDER_NO, T.C_MAT_CODE,T.N_TYPE   FROM TMO_CON_ORDER T WHERE T.C_CON_NO = '{0}'", conNo);
            DataTable dt = DbHelperOra.Query(strsql).Tables[0];

            decimal sumwgt = Convert.ToDecimal(dt.Compute("sum(N_WGT)", "true").ToString());
            decimal ylxwgt = 0;//已履行量

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = GetOrderExeNum(dt.Rows[i]["C_MAT_CODE"].ToString(), dt.Rows[i]["C_ORDER_NO"].ToString(), Convert.ToInt32(dt.Rows[i]["N_TYPE"].ToString()));
                if (dr != null)
                {
                    ylxwgt += Convert.ToDecimal(dr["YLXNUM"].ToString());
                }
            }
            return Convert.ToString(sumwgt - ylxwgt);
        }

        #endregion

        #region //各区域订单提报排产//汇总分析

        #region //是否已发排产计划
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists_OrderPlan(string c_order_no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMO_ORDER");
            strSql.AppendFormat(" where N_EXEC_STATUS IN(-1,0,2,6) AND NVL(SUBSTR(C_ORDER_NO,0,INSTR(C_ORDER_NO,'/')-1),C_ORDER_NO)='{0}'", c_order_no);
            return DbHelperOra.Exists(strSql.ToString());
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="pc_orderNo">排产订单号</param>
        /// <param name="conNo">原订单合同号</param>
        /// <returns></returns>
        public bool Exists_OrderPlan(string pc_orderNo, string conNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMO_ORDER");
            strSql.AppendFormat(" where N_EXEC_STATUS IN(-1,0,2,6) AND C_ORDER_NO='{0}' AND C_CON_NO='{1}'", pc_orderNo, conNo);
            return DbHelperOra.Exists(strSql.ToString());
        }
        #endregion


        #region //获取排产次数

        /// <summary>
        /// 获取订单排产次数号
        /// </summary>
        /// <param name="orderNo">订单号</param>
        /// <param name="conNo">合同号</param>
        /// <returns></returns>
        public int GetOrderPlanNum(string orderNo, string conNo)
        {
            string strSql = $@"SELECT COUNT(0)
                              FROM TMO_ORDER T
                             WHERE NVL(SUBSTR(T.C_ORDER_NO,0,INSTR(T.C_ORDER_NO,'/')-1),T.C_ORDER_NO) = '{orderNo}'
                               AND T.C_CON_NO = '{conNo}'";

            object obj = DbHelperOra.GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return 1;
            }
            else
            {

                return cmdresult + 1;
            }
        }
        #endregion

        #region //各区旬订单列表

        /// <summary>
        /// 各区域订单提报排产//汇总分析
        /// </summary>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matCode">物料编码</param>
        /// <param name="con">合同号</param>
        /// <param name="cust">客户名称</param>
        /// <param name="saleEmp">业务员</param>
        /// <param name="orderType">订单标识：0正常订单，1预测订单</param>
        /// <param name="execStatus">-执行状态: -2各区销售未提交排产,-1销售已提交， 0正常 ，5人为关闭，6生产完成,7库存货</param>
        /// <param name="area">销售区域</param>
        /// <param name="PJ">是否评价Y/N</param>
        /// <param name="startDate">计划日期</param>
        /// <param name="endDate">需求日期</param>
        /// <param name="matName">物料名称</param>
        /// <param name="pack">包装要求</param>
        /// <param name="stdCode">执行标准</param>
        /// <param name="orderStart_DT">订单开始时间</param>
        /// <param name="orderEnd_DT">订单结束时间</param>
        /// <param name="shStart_DT">审核开始时间</param>
        /// <param name="shEnd_DT">审核结束时间</param>
        /// <returns></returns>
        public DataSet GetOrderPlan(string stlGrd, string spec, string matCode, string con, string cust, string saleEmp, string orderType, string execStatus, string area, string startDate, string endDate, string matName, string pack, string stdCode, string orderStart_DT, string orderEnd_DT, string shStart_DT, string shEnd_DT, string orderNo, string PJ)
        {
            StringBuilder strSql = new StringBuilder();


            strSql.AppendFormat(@"SELECT T.C_ID,
                                   T.C_STL_GRD, --钢种
                                   T.C_SPEC,
                                   T.N_WGT,
                                   T.C_MAT_CODE,
                                   T.C_MAT_NAME,
                                   T.C_FREE1,
                                   T.C_FREE2,
                                   T.C_PACK,
                                   T.C_STD_CODE,
                                   T.C_CUST_NAME,
                                   T.C_CON_NO,
                                   T.C_ORDER_NO,
                                   NVL(T.N_SLAB_MATCH_WGT, 0) + NVL(T.N_PROD_WGT, 0) AS WG_WGT,--完工量
                                   T.N_LINE_MATCH_WGT,--分配量
                                   '' D_CONSING_DT, --签署日期
                                   T.D_DELIVERY_DT, --计划交货日期
                                   T.C_AREA,
                                   T.C_YWY, --业务员
                                   T.N_TYPE, --订单类型
                                   DECODE(T.C_SFPJ,'Y','已评价','N','未评价')C_SFPJ, --是否评价
                                   DECODE(T.N_EXEC_STATUS,-2,'未提报',-1,'已提报',0,'已审核',5,'关闭',6,'生产完成',2,'已排轧钢 ')N_EXEC_STATUS, --执行状态: -2各区销售未提交排产,-1销售已提交， 0正常 ，5人为关闭，6生产完成,7库存货
                                   T.C_PCTBEMP, --提报人
                                   T.D_PCTBTS, --计划日期
                                   T.C_REMARK, --评价原因
                                   T.C_REMARK4, --特殊信息
                                   '' C_FLOWID, --审批流程
                                   DECODE(T.N_FLAG,0,'正常订单',1,'预测订单') N_FLAG,--计划类型0正常订单，1虚拟订单,
                                   DECODE(T.N_STATUS,2,'生效') N_STATUS,
                                   T.D_NEED_DT,--需求日期
                                   T.C_ISSUE_EMP_ID,
                                   TO_CHAR(T.D_STL_ROL_DT,'YYYY-MM-DD') D_STL_ROL_DT, --评审时间
                                   TO_CHAR(T.D_DT,'YYYY-MM-DD') D_DT, --提报时间
                                   TRC.OUTWGT
                              FROM TMO_ORDER T

                              LEFT JOIN (SELECT SUM(A.N_WGT) OUTWGT,
                                                A.C_MAT_CODE,
                                                A.C_STD_CODE,
                                                A.C_CON_NO,
                                                A.C_CUST_NAME
                                           FROM TRC_ROLL_PRODCUT A
                                          WHERE A.C_MOVE_TYPE = 'S'
                                          GROUP BY A.C_MAT_CODE, A.C_STD_CODE, A.C_CON_NO, A.C_CUST_NAME) TRC
                                ON T.C_MAT_CODE = TRC.C_MAT_CODE
                               AND T.C_STD_CODE = TRC.C_STD_CODE
                               AND T.C_CON_NO = TRC.C_CON_NO
                               AND T.C_CUST_NAME = TRC.C_CUST_NAME
                            
                             WHERE T.N_STATUS = 2 and t.n_type in(8,6) and T.N_EXEC_STATUS NOT IN(5) ");

            if (!string.IsNullOrEmpty(orderNo))
            {
                strSql.AppendFormat(" AND T.C_ORDER_NO IN({0})", orderNo);
            }

            if (!string.IsNullOrEmpty(stdCode))
            {
                strSql.AppendFormat(" AND T.C_STD_CODE='{0}'", stdCode);
            }
            if (!string.IsNullOrEmpty(matName))
            {
                strSql.AppendFormat(" AND T.C_MAT_NAME='{0}'", matName);
            }
            if (!string.IsNullOrEmpty(pack))
            {
                strSql.AppendFormat(" AND T.C_PACK='{0}'", pack);
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.AppendFormat(" AND T.C_STL_GRD = '{0}'", stlGrd);
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" AND T.C_SPEC = '{0}'", spec);
            }
            if (!string.IsNullOrEmpty(matCode))
            {
                strSql.AppendFormat(" AND T.C_MAT_CODE='{0}'", matCode);
            }
            if (!string.IsNullOrEmpty(con))
            {
                strSql.AppendFormat(" AND T.C_CON_NO like '%{0}%'", con);
            }
            if (!string.IsNullOrEmpty(cust))
            {
                strSql.AppendFormat(" AND T.C_CUST_NAME like '%{0}%'", cust);
            }
            if (!string.IsNullOrEmpty(saleEmp))
            {
                strSql.AppendFormat(" AND T.C_PCTBEMP like '%{0}%'", saleEmp);
            }
            if (!string.IsNullOrEmpty(PJ))
            {
                strSql.AppendFormat(" AND T.C_SFPJ='{0}'", PJ);
            }
            if (!string.IsNullOrEmpty(orderType))
            {
                strSql.AppendFormat(" AND T.N_FLAG={0}", orderType);
            }
            if (!string.IsNullOrEmpty(execStatus))
            {
                strSql.AppendFormat(" AND T.N_EXEC_STATUS IN({0})", execStatus);
            }
            if (!string.IsNullOrEmpty(area))
            {
                strSql.AppendFormat(" AND T.C_AREA='{0}'", area);
            }

            if (!string.IsNullOrEmpty(startDate))//订单排产计划日期
            {
                strSql.Append(" AND T.D_PCTBTS >=TO_DATE('" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND T.D_PCTBTS <=TO_DATE('" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");
            }

            if (!string.IsNullOrEmpty(endDate))//订单排产需求日期
            {
                strSql.Append(" AND T.D_NEED_DT>=TO_DATE('" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND T.D_NEED_DT<= TO_DATE('" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");
            }



            if (!string.IsNullOrEmpty(orderStart_DT) && !string.IsNullOrEmpty(orderEnd_DT))//提报时间
            {
                strSql.Append(" AND T.D_DT>=TO_DATE('" + Convert.ToDateTime(orderStart_DT).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND T.D_DT<= TO_DATE('" + Convert.ToDateTime(orderEnd_DT).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");


            }


            if (!string.IsNullOrEmpty(shStart_DT) && !string.IsNullOrEmpty(shEnd_DT))//审核时间
            {
                strSql.Append(" AND t.D_STL_ROL_DT>=TO_DATE('" + Convert.ToDateTime(shStart_DT).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND T.D_STL_ROL_DT<= TO_DATE('" + Convert.ToDateTime(shEnd_DT).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");

            }

            strSql.Append(" ORDER BY T.D_PCTBTS,T.C_MAT_NAME,T.C_STL_GRD,T.C_SPEC");

            return DbHelperOra.Query(strSql.ToString());
        }

        public DataSet GetOrderPlan(string matcode)
        {

            string strSql = $@"SELECT T.C_MAT_CODE,
                               T.C_MAT_NAME,
                               T.D_PCTBTS, --计划日期
                               T.D_NEED_DT, --需求日期
                               T.C_STL_GRD,
                               T.C_SPEC,
                               T.C_FREE1,
                               T.C_FREE2,
                               T.C_PACK,
                               T.N_WGT,
                               NVL(T.N_SLAB_MATCH_WGT, 0) + NVL(T.N_PROD_WGT, 0) 完工数量,
                               NVL(T.N_WGT, 0) -
                               (NVL(T.N_SLAB_MATCH_WGT, 0) + NVL(T.N_PROD_WGT, 0)) 未执行需求量,
                               T.C_SFPJ 是否评价,
                               CASE
                                 WHEN T.N_ROLL_PROD_WGT = 0 THEN
                                  '未下达'
                                 WHEN T.N_ROLL_PROD_WGT > 0 AND T.N_EXEC_STATUS IN (0, 2) THEN
                                  '已下达'
                                 WHEN N_EXEC_STATUS = 6 THEN
                                  '已完成'
                                 ELSE
                                  ''
                               END 订单状态
                          FROM TMO_ORDER T
                         WHERE T.N_STATUS = 2
                           AND T.N_TYPE = 8
                           AND T.N_EXEC_STATUS IN (0, 2) ";

            if (!string.IsNullOrEmpty(matcode))
            {
                strSql += $" AND T.C_MAT_CODE='{matcode}'";
            }
            return DbHelperOra.Query(strSql);

        }

        #endregion

        #region  旬订单提报钢种汇总分析
        /// <summary>
        /// 旬订单提报汇总分析
        /// </summary>
        /// <param name="jh_dt">计划日期</param>
        /// <param name="xq_dt">需求日期</param>
        /// <param name="shkssj">审核开始时间</param>
        /// <param name="shjssj">审核结束时间</param>
        /// <returns></returns>
        public DataSet GetOrderPlanStlGrd(int flag, string jh_dt, string xq_dt)
        {
            StringBuilder strSql = new StringBuilder();

            switch (flag)
            {
                case 1:
                    #region//钢种分析
                    strSql.AppendFormat(@"SELECT A.C_PROD_KIND,
                                           A.C_PROD_NAME,
                                           DECODE(B.C_FLAG,'','否','Y','是')SFJK,
                                           T.C_STL_GRD,
                                           SUM(T.N_WGT) N_WGT
                                      FROM TMO_ORDER T
                                      LEFT JOIN TQB_STD_MAIN A
                                        ON A.C_STD_CODE = T.C_STD_CODE
                                       AND A.C_STL_GRD = T.C_STL_GRD
                                      LEFT JOIN TMB_MONI_STLGRD B ON B.C_STL_GRD=T.C_STL_GRD
                                     WHERE T.N_STATUS = 2
                                       AND T.N_EXEC_STATUS IN (-1,0,2,6)");

                    strSql.Append(" AND T.D_DT >=TO_DATE('" + Convert.ToDateTime(jh_dt).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                    strSql.Append(" AND T.D_DT <=TO_DATE('" + Convert.ToDateTime(xq_dt).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");

                    strSql.Append(" GROUP BY A.C_PROD_KIND, A.C_PROD_NAME, B.C_FLAG, T.C_STL_GRD");
                    #endregion

                    break;
                case 2:
                    #region//规格统计

                    strSql.AppendFormat(@"SELECT 
                                           T.C_SPEC,
                                           SUM(T.N_WGT) N_WGT
                                      FROM TMO_ORDER T
                                     WHERE T.N_STATUS = 2
                                       AND T.N_EXEC_STATUS IN (-1,0,2,6)");

                    strSql.Append(" AND T.D_DT >=TO_DATE('" + Convert.ToDateTime(jh_dt).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                    strSql.Append(" AND T.D_DT <=TO_DATE('" + Convert.ToDateTime(xq_dt).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                    strSql.Append(" GROUP BY T.C_SPEC");
                    #endregion

                    break;
                case 3:
                    #region//各区域监控/精品/品种钢排产需求
                    strSql.AppendFormat(@"SELECT TA.C_AREA,
                                           NVL(TB.N_WGT, 0) N_WGT_JK, --实际需求监控
                                           NVL(TD.N_WGT, 0) N_WGT_JP, --实际需求精品
                                           NVL(TC.N_WGT, 0) N_WGT_PZ, --实际需求品种
                                           (NVL(TD.N_WGT, 0) + NVL(TC.N_WGT, 0)) SUM_JP_PZ,
                                           NVL(TE.N_WGT, 0) N_WGT_CON, --正常订单
                                           TO_CHAR((case
                                                     WHEN NVL(TE.N_WGT, 0) = 0 THEN
                                                      0
                                                     ELSE
                                                      ROUND(NVL(TE.N_WGT, 0) / (NVL(TC.N_WGT, 0) + NVL(TD.N_WGT, 0)) * 100,
                                                            2)
                                                   END)) || '%' ZB --正常订单 / 当前区域总库存

                                      FROM(SELECT T.C_DETAILNAME AS C_AREA
                                              FROM TS_DIC T
                                             WHERE T.C_TYPECODE = 'ConArea'
                                               AND T.C_DETAILCODE NOT IN('6', '7', '10', '11', '27')
                                             ORDER BY T.C_INDEX) TA--区域
                                     LEFT JOIN(SELECT T.C_AREA, SUM(T.N_WGT) N_WGT

                                                  FROM V_ORDER_PLAN T

                                                 WHERE T.N_EXEC_STATUS IN(-1, 0, 2, 6)

                                                   AND T.D_DT >= TO_DATE('{0}', 'YYYY-MM-DD HH24:MI:SS')

                                                   AND T.D_DT <= TO_DATE('{1}', 'YYYY-MM-DD HH24:MI:SS')

                                                   AND T.C_FLAG = 'Y'

                                                 GROUP BY T.C_AREA) TB--监控
                                      ON TB.C_AREA = TA.C_AREA

                                      LEFT JOIN(SELECT T.C_AREA, SUM(T.N_WGT) N_WGT
                                                   FROM V_ORDER_PLAN T
                                                  WHERE T.N_EXEC_STATUS IN (-1, 0, 2, 6)
                                                    AND T.D_DT >= TO_DATE('{0}', 'YYYY-MM-DD HH24:MI:SS')
                                                    AND T.D_DT <= TO_DATE('{1}', 'YYYY-MM-DD HH24:MI:SS')
                                                    AND T.C_TYPE IN('普碳钢', '高速线材')
                                                  GROUP BY T.C_AREA) TC--品种钢
                                       ON TC.C_AREA = TA.C_AREA
                                      LEFT JOIN(

                                                 SELECT T.C_AREA, SUM(T.N_WGT) N_WGT
                                                   FROM V_ORDER_PLAN T
                                                  WHERE T.N_EXEC_STATUS IN (-1, 0, 2, 6)
                                                    AND T.D_DT >= TO_DATE('{0}', 'YYYY-MM-DD HH24:MI:SS')
                                                    AND T.D_DT <= TO_DATE('{1}', 'YYYY-MM-DD HH24:MI:SS')
                                                    AND T.C_TYPE IN('精品线材')
                                                  GROUP BY T.C_AREA) TD--精品
                                       ON TD.C_AREA = TA.C_AREA
                                      LEFT JOIN(SELECT T.C_AREA, SUM(T.N_WGT) N_WGT
                                                   FROM V_ORDER_PLAN T
                                                  WHERE T.N_EXEC_STATUS IN (-1, 0, 2, 6)
                                                    AND T.D_DT >= TO_DATE('{0}', 'YYYY-MM-DD HH24:MI:SS')
                                                    AND T.D_DT <= TO_DATE('{1}', 'YYYY-MM-DD HH24:MI:SS')
                                                    AND T.ORDER_FLAG = 0
                                                  GROUP BY T.C_AREA) TE--正常订单需求量
                                       ON TE.C_AREA = TA.C_AREA ", jh_dt, xq_dt);

                    #endregion

                    break;
            }


            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion



        #region //规格
        public DataSet GetSpec()
        {
            string strsql = "SELECT DISTINCT T.C_SPEC  FROM TMO_CON_ORDER T  ORDER BY T.C_SPEC";
            return DbHelperOra.Query(strsql);
        }
        #endregion

        #region //订单区域

        public DataSet GetOrderArea()
        {
            string strsql = "SELECT DISTINCT T.C_AREA FROM TMO_CON_ORDER T WHERE T.N_STATUS != -1 AND T.N_FLAG=0 order by T.C_AREA";
            return DbHelperOra.Query(strsql);
        }
        #endregion

        #region //合同区域
        public DataSet GetConArea()
        {
            string strsql = "SELECT DISTINCT T.C_AREA  FROM TMO_CON T WHERE T.N_STATUS != -1  ORDER BY T.C_AREA";
            return DbHelperOra.Query(strsql);
        }
        #endregion

        #region //特殊信息
        public DataSet GetTS()
        {
            string strsql = "SELECT DISTINCT T.C_PCINFO  FROM  TRC_ROLL_PRODCUT T  WHERE T.C_MOVE_TYPE='E'  ORDER BY T.C_PCINFO";
            return DbHelperOra.Query(strsql);
        }
        #endregion

        #region //线材区域


        public DataSet GetCustRollArea(string custname)
        {
            string strSql = $"SELECT DISTINCT T.C_SALE_AREA FROM TRC_ROLL_PRODCUT T WHERE T.C_MOVE_TYPE = 'E' AND T.C_CUST_NAME = '{custname}'";
            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 线材库区域
        /// </summary>
        /// <returns></returns>
        public DataSet GetXCAREA()
        {
            string strsql = "SELECT DISTINCT T.C_SALE_AREA  FROM  TRC_ROLL_PRODCUT T WHERE T.C_MOVE_TYPE='E'  ORDER BY T.C_SALE_AREA";
            return DbHelperOra.Query(strsql);
        }

        /// <summary>
        /// 线材库区域
        /// </summary>
        /// <returns></returns>
        public DataSet GetXCAREA(string JUDGE_LEV_ZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT T.C_SALE_AREA  FROM  TRC_ROLL_PRODCUT T WHERE T.C_MOVE_TYPE='E' ");
            if (!string.IsNullOrEmpty(JUDGE_LEV_ZH))
            {
                strSql.AppendFormat(" AND T.C_JUDGE_LEV_ZH='{0}'", JUDGE_LEV_ZH);
            }

            strSql.Append(" ORDER BY T.C_SALE_AREA");

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 线材库区域
        /// </summary>
        /// <returns></returns>
        public DataSet GetXCAREA_APP(string JUDGE_LEV_ZH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT T.C_SALE_AREA  AS C_DETAILNAME FROM  TRC_ROLL_PRODCUT T WHERE T.C_MOVE_TYPE='E' ");
            if (!string.IsNullOrEmpty(JUDGE_LEV_ZH))
            {
                strSql.AppendFormat(" AND T.C_JUDGE_LEV_ZH='{0}'", JUDGE_LEV_ZH);
            }

            strSql.Append(" ORDER BY T.C_SALE_AREA");

            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

        #region //线材质量等级
        /// <summary>
        /// 线材库质量等级
        /// </summary>
        /// <returns></returns>
        public DataSet GetXC_JUDGE_LEV_ZH(string area)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT T.C_JUDGE_LEV_ZH  FROM  TRC_ROLL_PRODCUT T WHERE 1=1 ");
            if (!string.IsNullOrEmpty(area))
            {
                strSql.AppendFormat(" AND T.C_SALE_AREA='{0}'", area);
            }
            strSql.Append(" ORDER BY T.C_JUDGE_LEV_ZH");


            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion


        #region //订单物料名称
        public DataSet GetOrderMat()
        {
            string strsql = "SELECT DISTINCT T.C_MAT_NAME  FROM TMO_CON_ORDER T  ORDER BY T.C_MAT_NAME";
            return DbHelperOra.Query(strsql);
        }
        #endregion

        #region //旬订单提报

        /// <summary>
        /// 订单排产区域设置
        /// </summary>
        /// <param name="list">参数列表：区域，订单主键</param>
        /// <returns></returns>
        public bool UpdateArea(List<string[]> list)
        {
            ArrayList arraySql = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                string strsql = string.Format("UPDATE TMO_ORDER T SET T.C_AREA='{0}' WHERE T.C_ID='{1}'", list[i]);
                arraySql.Add(strsql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);

        }

        /// <summary>
        /// 订单排产审核操作
        /// </summary>
        /// <param name="list">参数列表：状态，审核人，计划日期，需求日期，订单主键</param>
        /// <returns></returns>
        public bool UpdateCheck(List<string[]> list)
        {
            ArrayList arraySql = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                string strsql = string.Format("UPDATE TMO_ORDER T SET T.N_EXEC_STATUS={0},T.C_ISSUE_EMP_ID='{1}',T.D_PCTBTS=to_date('{2}', 'yyyy-mm-dd hh24:mi:ss'),T.D_NEED_DT=to_date('{3}', 'yyyy-mm-dd hh24:mi:ss'),T.D_STL_ROL_DT=to_date('" + DateTime.Now.ToString() + "', 'yyyy-mm-dd hh24:mi:ss') WHERE T.C_ID='{4}'", list[i]);
                arraySql.Add(strsql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);

        }

        /// <summary>
        /// 提报操作
        /// </summary>
        /// <param name="list">参数列表状态，提报人，订单主键</param>
        /// <returns></returns>
        public bool UpdateSubmission(List<string[]> list)
        {
            ArrayList arraySql = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                string strsql = string.Format("UPDATE TMO_CON_ORDER T SET T.N_EXEC_STATUS={0},T.D_SMS_PROD_DT=to_date('" + DateTime.Now.ToString() + "', 'yyyy-mm-dd hh24:mi:ss'),T.C_PCTBEMP='{1}' WHERE T.C_ID='{2}'", list[i]);
                arraySql.Add(strsql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);

        }

        /// <summary>
        /// 取消提报/取消审核/关闭订单
        /// </summary>
        /// <param name="list">参数列表：状态，订单主键</param>
        /// <returns></returns>
        public bool UpdateCancelSubmission(List<string[]> list)
        {
            ArrayList arraySql = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                string strsql = string.Format("UPDATE TMO_ORDER T SET T.N_EXEC_STATUS={0} WHERE T.C_ID='{1}'", list[i]);
                arraySql.Add(strsql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);

        }
        #endregion


        #region 计划操作日志
        /// <summary>
        /// 插入订单计划排产操作日志
        /// </summary>
        /// <param name="list">参数：操作具体描述，功能描述(页面标题)，操作人，操作IP地址，订单号，订单表主键</param>
        public void InsertOrderPlanLog(List<string[]> list)
        {
            ArrayList arraySql = new ArrayList();

            for (int i = 0; i < list.Count; i++)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat(@"insert into TB_ORDER_LOG (C_OPERATION, C_FUNCTION, C_EMP_ID, C_CP_IP, C_ORDER_NO, C_PLAN_ID) values('{0}','{1}','{2}','{3}','{4}','{5}')", list[i]);
                arraySql.Add(strSql.ToString());
            }
            DbHelperOra.ExecuteSqlTran(arraySql);


        }
        #endregion

        #endregion


        #region //GPS钢种设置

        /// <summary>
        /// 获取GPS钢种
        /// </summary>
        /// <param name="stlGrd">钢种</param>
        /// <returns></returns>
        public DataSet GetStl_Gps(string stlGrd)
        {
            string strSql = $@"SELECT DISTINCT T.C_STL_GRD, A.N_ISGPS
  FROM TMO_CON_ORDER T
  LEFT JOIN TB_MATRL_MAIN A
    ON A.C_STL_GRD = T.C_STL_GRD";

            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql += $@" WHERE T.C_STL_GRD='{stlGrd}'";
            }

            strSql += " ORDER BY T.C_STL_GRD";

            return DbHelperOra.Query(strSql);
        }
        #endregion

    }
}

