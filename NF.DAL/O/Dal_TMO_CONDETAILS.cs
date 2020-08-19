using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using System.Collections;
using System.Collections.Generic;

namespace NF.DAL
{
    /// <summary>
    /// 合同明细
    /// </summary>
    public partial class Dal_TMO_CONDETAILS
    {
        public Dal_TMO_CONDETAILS()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_NO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMO_CONDETAILS");
            strSql.Append(" where C_NO=:C_NO ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_NO", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_NO;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMO_CONDETAILS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMO_CONDETAILS(");
            strSql.Append("C_NO,C_CON_NO,C_CON_NAME,C_AREA,C_XGID,C_INVBASDOCID,C_INVENTORYID,C_PROD_NAME,C_PROD_KIND,C_MAT_CODE,C_MAT_NAME,C_SPEC,C_STL_GRD,C_PRO_USE,C_PACKUNITID,C_UNITID,C_CUST_SQ,D_NEED_DT,D_DELIVERY_DT,D_DT,C_TECH_PROT,C_FREE_TERM,C_FREE_TERM2,C_PACK,N_WGT,C_CRECEIPTAREAID,C_ADDRESS,C_RECEIPTCORPID,C_ATSTATION,C_CURRENCYTYPEID,C_STD_CODE,C_DESIGN_NO,C_STDID,C_DESIGNID,N_SLAB_MATCH_WGT,N_LINE_MATCH_WGT,N_STATUS,N_FLAG,N_TYPE,N_EXEC_STATUS,N_USER_LEV,C_EDITEMPLOYEEID,D_EDITDATE,C_REMARK,C_EMP_ID,C_EMP_NAME,C_CUST_NO,C_CUST_NAME,C_SALE_CHANNEL,C_LEV,C_ORDER_LEV,N_COST,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURNETPRICE,N_ORIGINALCURTAXNETPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,N_ORIGINALCURSUMMNY,N_PRICE,N_TAXPRICE,N_NETPRICE,N_TAXNETPRICE,N_TAXMNY,N_MNY,N_SUMMNY,C_NC_STATE,N_FNUM,N_HSL,C_VDEF1)");
            strSql.Append(" values (");
            strSql.Append(":C_NO,:C_CON_NO,:C_CON_NAME,:C_AREA,:C_XGID,:C_INVBASDOCID,:C_INVENTORYID,:C_PROD_NAME,:C_PROD_KIND,:C_MAT_CODE,:C_MAT_NAME,:C_SPEC,:C_STL_GRD,:C_PRO_USE,:C_PACKUNITID,:C_UNITID,:C_CUST_SQ,:D_NEED_DT,:D_DELIVERY_DT,:D_DT,:C_TECH_PROT,:C_FREE_TERM,:C_FREE_TERM2,:C_PACK,:N_WGT,:C_CRECEIPTAREAID,:C_ADDRESS,:C_RECEIPTCORPID,:C_ATSTATION,:C_CURRENCYTYPEID,:C_STD_CODE,:C_DESIGN_NO,:C_STDID,:C_DESIGNID,:N_SLAB_MATCH_WGT,:N_LINE_MATCH_WGT,:N_STATUS,:N_FLAG,:N_TYPE,:N_EXEC_STATUS,:N_USER_LEV,:C_EDITEMPLOYEEID,:D_EDITDATE,:C_REMARK,:C_EMP_ID,:C_EMP_NAME,:C_CUST_NO,:C_CUST_NAME,:C_SALE_CHANNEL,:C_LEV,:C_ORDER_LEV,:N_COST,:N_TAXRATE,:N_ORIGINALCURPRICE,:N_ORIGINALCURTAXPRICE,:N_ORIGINALCURNETPRICE,:N_ORIGINALCURTAXNETPRICE,:N_ORIGINALCURTAXMNY,:N_ORIGINALCURMNY,:N_ORIGINALCURSUMMNY,:N_PRICE,:N_TAXPRICE,:N_NETPRICE,:N_TAXNETPRICE,:N_TAXMNY,:N_MNY,:N_SUMMNY,:C_NC_STATE,:N_FNUM,:N_HSL,:C_VDEF1)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_XGID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_INVBASDOCID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_INVENTORYID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_KIND", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRO_USE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PACKUNITID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_UNITID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_SQ", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_NEED_DT", OracleDbType.Date),
                    new OracleParameter(":D_DELIVERY_DT", OracleDbType.Date),
                    new OracleParameter(":D_DT", OracleDbType.Date),
                    new OracleParameter(":C_TECH_PROT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FREE_TERM", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_FREE_TERM2", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_PACK", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_CRECEIPTAREAID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ADDRESS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RECEIPTCORPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ATSTATION", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CURRENCYTYPEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DESIGN_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STDID", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_DESIGNID", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_SLAB_MATCH_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_LINE_MATCH_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,2),
                    new OracleParameter(":N_FLAG", OracleDbType.Decimal,2),
                    new OracleParameter(":N_TYPE", OracleDbType.Decimal,2),
                    new OracleParameter(":N_EXEC_STATUS", OracleDbType.Decimal,2),
                    new OracleParameter(":N_USER_LEV", OracleDbType.Decimal,2),
                    new OracleParameter(":C_EDITEMPLOYEEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_EDITDATE", OracleDbType.Date),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_SALE_CHANNEL", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LEV", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORDER_LEV", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_COST", OracleDbType.Decimal,15),
                    new OracleParameter(":N_TAXRATE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURTAXPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURNETPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURTAXNETPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURTAXMNY", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURMNY", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURSUMMNY", OracleDbType.Decimal,15),
                    new OracleParameter(":N_PRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_TAXPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_NETPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_TAXNETPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_TAXMNY", OracleDbType.Decimal,15),
                    new OracleParameter(":N_MNY", OracleDbType.Decimal,15),
                    new OracleParameter(":N_SUMMNY", OracleDbType.Decimal,15),
                    new OracleParameter(":C_NC_STATE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_FNUM", OracleDbType.Decimal,15),
                    new OracleParameter(":N_HSL", OracleDbType.Decimal,15),
                    new OracleParameter(":C_VDEF1", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_NO;
            parameters[1].Value = model.C_CON_NO;
            parameters[2].Value = model.C_CON_NAME;
            parameters[3].Value = model.C_AREA;
            parameters[4].Value = model.C_XGID;
            parameters[5].Value = model.C_INVBASDOCID;
            parameters[6].Value = model.C_INVENTORYID;
            parameters[7].Value = model.C_PROD_NAME;
            parameters[8].Value = model.C_PROD_KIND;
            parameters[9].Value = model.C_MAT_CODE;
            parameters[10].Value = model.C_MAT_NAME;
            parameters[11].Value = model.C_SPEC;
            parameters[12].Value = model.C_STL_GRD;
            parameters[13].Value = model.C_PRO_USE;
            parameters[14].Value = model.C_PACKUNITID;
            parameters[15].Value = model.C_UNITID;
            parameters[16].Value = model.C_CUST_SQ;
            parameters[17].Value = model.D_NEED_DT;
            parameters[18].Value = model.D_DELIVERY_DT;
            parameters[19].Value = model.D_DT;
            parameters[20].Value = model.C_TECH_PROT;
            parameters[21].Value = model.C_FREE_TERM;
            parameters[22].Value = model.C_FREE_TERM2;
            parameters[23].Value = model.C_PACK;
            parameters[24].Value = model.N_WGT;
            parameters[25].Value = model.C_CRECEIPTAREAID;
            parameters[26].Value = model.C_ADDRESS;
            parameters[27].Value = model.C_RECEIPTCORPID;
            parameters[28].Value = model.C_ATSTATION;
            parameters[29].Value = model.C_CURRENCYTYPEID;
            parameters[30].Value = model.C_STD_CODE;
            parameters[31].Value = model.C_DESIGN_NO;
            parameters[32].Value = model.C_STDID;
            parameters[33].Value = model.C_DESIGNID;
            parameters[34].Value = model.N_SLAB_MATCH_WGT;
            parameters[35].Value = model.N_LINE_MATCH_WGT;
            parameters[36].Value = model.N_STATUS;
            parameters[37].Value = model.N_FLAG;
            parameters[38].Value = model.N_TYPE;
            parameters[39].Value = model.N_EXEC_STATUS;
            parameters[40].Value = model.N_USER_LEV;
            parameters[41].Value = model.C_EDITEMPLOYEEID;
            parameters[42].Value = model.D_EDITDATE;
            parameters[43].Value = model.C_REMARK;
            parameters[44].Value = model.C_EMP_ID;
            parameters[45].Value = model.C_EMP_NAME;
            parameters[46].Value = model.C_CUST_NO;
            parameters[47].Value = model.C_CUST_NAME;
            parameters[48].Value = model.C_SALE_CHANNEL;
            parameters[49].Value = model.C_LEV;
            parameters[50].Value = model.C_ORDER_LEV;
            parameters[51].Value = model.N_COST;
            parameters[52].Value = model.N_TAXRATE;
            parameters[53].Value = model.N_ORIGINALCURPRICE;
            parameters[54].Value = model.N_ORIGINALCURTAXPRICE;
            parameters[55].Value = model.N_ORIGINALCURNETPRICE;
            parameters[56].Value = model.N_ORIGINALCURTAXNETPRICE;
            parameters[57].Value = model.N_ORIGINALCURTAXMNY;
            parameters[58].Value = model.N_ORIGINALCURMNY;
            parameters[59].Value = model.N_ORIGINALCURSUMMNY;
            parameters[60].Value = model.N_PRICE;
            parameters[61].Value = model.N_TAXPRICE;
            parameters[62].Value = model.N_NETPRICE;
            parameters[63].Value = model.N_TAXNETPRICE;
            parameters[64].Value = model.N_TAXMNY;
            parameters[65].Value = model.N_MNY;
            parameters[66].Value = model.N_SUMMNY;
            parameters[67].Value = model.C_NC_STATE;
            parameters[68].Value = model.N_FNUM;
            parameters[69].Value = model.N_HSL;
            parameters[70].Value = model.C_VDEF1;
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
        /// 更新订单状态
        /// </summary>
        public bool UpdateStatus(int status, string conNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMO_CONDETAILS set ");

            strSql.Append("N_STATUS=:N_STATUS");

            strSql.Append(" where C_CON_NO=:C_CON_NO");
            OracleParameter[] parameters = {
                    new OracleParameter(":N_STATUS", OracleDbType.Int32,2),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100)};
            parameters[0].Value = status;
            parameters[1].Value = conNO;

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
        /// 更新客户处理状态
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="orderNo">订单号</param>
        /// <returns></returns>
        public bool UpdateCustStatus(int status, string orderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMO_CONDETAILS set ");

            strSql.Append("N_CUSTSTATUS=:N_CUSTSTATUS");

            strSql.Append(" where C_NO=:C_NO");
            OracleParameter[] parameters = {
                    new OracleParameter(":N_CUSTSTATUS", OracleDbType.Int32,2),
                    new OracleParameter(":C_NO", OracleDbType.Varchar2,100)};
            parameters[0].Value = status;
            parameters[1].Value = orderNo;

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
        public bool Update(Mod_TMO_CONDETAILS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMO_CONDETAILS set ");
            strSql.Append("C_CON_NO=:C_CON_NO,");
            strSql.Append("C_CON_NAME=:C_CON_NAME,");
            strSql.Append("C_AREA=:C_AREA,");
            strSql.Append("C_XGID=:C_XGID,");
            strSql.Append("C_INVBASDOCID=:C_INVBASDOCID,");
            strSql.Append("C_INVENTORYID=:C_INVENTORYID,");
            strSql.Append("C_PROD_NAME=:C_PROD_NAME,");
            strSql.Append("C_PROD_KIND=:C_PROD_KIND,");
            strSql.Append("C_MAT_CODE=:C_MAT_CODE,");
            strSql.Append("C_MAT_NAME=:C_MAT_NAME,");
            strSql.Append("C_SPEC=:C_SPEC,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_PRO_USE=:C_PRO_USE,");
            strSql.Append("C_PACKUNITID=:C_PACKUNITID,");
            strSql.Append("C_UNITID=:C_UNITID,");
            strSql.Append("C_CUST_SQ=:C_CUST_SQ,");
            strSql.Append("D_NEED_DT=:D_NEED_DT,");
            strSql.Append("D_DELIVERY_DT=:D_DELIVERY_DT,");
            strSql.Append("D_DT=:D_DT,");
            strSql.Append("C_TECH_PROT=:C_TECH_PROT,");
            strSql.Append("C_FREE_TERM=:C_FREE_TERM,");
            strSql.Append("C_FREE_TERM2=:C_FREE_TERM2,");
            strSql.Append("C_PACK=:C_PACK,");
            strSql.Append("N_WGT=:N_WGT,");
            strSql.Append("C_CRECEIPTAREAID=:C_CRECEIPTAREAID,");
            strSql.Append("C_ADDRESS=:C_ADDRESS,");
            strSql.Append("C_RECEIPTCORPID=:C_RECEIPTCORPID,");
            strSql.Append("C_ATSTATION=:C_ATSTATION,");
            strSql.Append("C_CURRENCYTYPEID=:C_CURRENCYTYPEID,");
            strSql.Append("C_STD_CODE=:C_STD_CODE,");
            strSql.Append("C_DESIGN_NO=:C_DESIGN_NO,");
            strSql.Append("C_STDID=:C_STDID,");
            strSql.Append("C_DESIGNID=:C_DESIGNID,");
            strSql.Append("N_SLAB_MATCH_WGT=:N_SLAB_MATCH_WGT,");
            strSql.Append("N_LINE_MATCH_WGT=:N_LINE_MATCH_WGT,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("N_FLAG=:N_FLAG,");
            strSql.Append("N_TYPE=:N_TYPE,");
            strSql.Append("N_EXEC_STATUS=:N_EXEC_STATUS,");
            strSql.Append("N_USER_LEV=:N_USER_LEV,");
            strSql.Append("C_EDITEMPLOYEEID=:C_EDITEMPLOYEEID,");
            strSql.Append("D_EDITDATE=:D_EDITDATE,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("C_CUST_NO=:C_CUST_NO,");
            strSql.Append("C_CUST_NAME=:C_CUST_NAME,");
            strSql.Append("C_SALE_CHANNEL=:C_SALE_CHANNEL,");
            strSql.Append("C_LEV=:C_LEV,");
            strSql.Append("C_ORDER_LEV=:C_ORDER_LEV,");
            strSql.Append("N_COST=:N_COST,");
            strSql.Append("N_TAXRATE=:N_TAXRATE,");
            strSql.Append("N_ORIGINALCURPRICE=:N_ORIGINALCURPRICE,");
            strSql.Append("N_ORIGINALCURTAXPRICE=:N_ORIGINALCURTAXPRICE,");
            strSql.Append("N_ORIGINALCURNETPRICE=:N_ORIGINALCURNETPRICE,");
            strSql.Append("N_ORIGINALCURTAXNETPRICE=:N_ORIGINALCURTAXNETPRICE,");
            strSql.Append("N_ORIGINALCURTAXMNY=:N_ORIGINALCURTAXMNY,");
            strSql.Append("N_ORIGINALCURMNY=:N_ORIGINALCURMNY,");
            strSql.Append("N_ORIGINALCURSUMMNY=:N_ORIGINALCURSUMMNY,");
            strSql.Append("N_PRICE=:N_PRICE,");
            strSql.Append("N_TAXPRICE=:N_TAXPRICE,");
            strSql.Append("N_NETPRICE=:N_NETPRICE,");
            strSql.Append("N_TAXNETPRICE=:N_TAXNETPRICE,");
            strSql.Append("N_TAXMNY=:N_TAXMNY,");
            strSql.Append("N_MNY=:N_MNY,");
            strSql.Append("N_SUMMNY=:N_SUMMNY,");
            strSql.Append("C_NC_STATE=:C_NC_STATE,");
            strSql.Append("N_FNUM=:N_FNUM,");
            strSql.Append("N_HSL=:N_HSL,");
            strSql.Append("C_VDEF1=:C_VDEF1");
            strSql.Append(" where C_NO=:C_NO ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_XGID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_INVBASDOCID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_INVENTORYID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_KIND", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRO_USE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PACKUNITID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_UNITID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_SQ", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_NEED_DT", OracleDbType.Date),
                    new OracleParameter(":D_DELIVERY_DT", OracleDbType.Date),
                    new OracleParameter(":D_DT", OracleDbType.Date),
                    new OracleParameter(":C_TECH_PROT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FREE_TERM", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_FREE_TERM2", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_PACK", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_CRECEIPTAREAID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ADDRESS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RECEIPTCORPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ATSTATION", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CURRENCYTYPEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DESIGN_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STDID", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_DESIGNID", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_SLAB_MATCH_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_LINE_MATCH_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,2),
                    new OracleParameter(":N_FLAG", OracleDbType.Decimal,2),
                    new OracleParameter(":N_TYPE", OracleDbType.Decimal,2),
                    new OracleParameter(":N_EXEC_STATUS", OracleDbType.Decimal,2),
                    new OracleParameter(":N_USER_LEV", OracleDbType.Decimal,2),
                    new OracleParameter(":C_EDITEMPLOYEEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_EDITDATE", OracleDbType.Date),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_CUST_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_SALE_CHANNEL", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LEV", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORDER_LEV", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_COST", OracleDbType.Decimal,15),
                    new OracleParameter(":N_TAXRATE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURTAXPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURNETPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURTAXNETPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURTAXMNY", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURMNY", OracleDbType.Decimal,15),
                    new OracleParameter(":N_ORIGINALCURSUMMNY", OracleDbType.Decimal,15),
                    new OracleParameter(":N_PRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_TAXPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_NETPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_TAXNETPRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_TAXMNY", OracleDbType.Decimal,15),
                    new OracleParameter(":N_MNY", OracleDbType.Decimal,15),
                    new OracleParameter(":N_SUMMNY", OracleDbType.Decimal,15),
                   new OracleParameter(":C_NC_STATE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_FNUM", OracleDbType.Decimal,15),
                    new OracleParameter(":N_HSL", OracleDbType.Decimal,15),
                    new OracleParameter(":C_VDEF1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NO", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_CON_NO;
            parameters[1].Value = model.C_CON_NAME;
            parameters[2].Value = model.C_AREA;
            parameters[3].Value = model.C_XGID;
            parameters[4].Value = model.C_INVBASDOCID;
            parameters[5].Value = model.C_INVENTORYID;
            parameters[6].Value = model.C_PROD_NAME;
            parameters[7].Value = model.C_PROD_KIND;
            parameters[8].Value = model.C_MAT_CODE;
            parameters[9].Value = model.C_MAT_NAME;
            parameters[10].Value = model.C_SPEC;
            parameters[11].Value = model.C_STL_GRD;
            parameters[12].Value = model.C_PRO_USE;
            parameters[13].Value = model.C_PACKUNITID;
            parameters[14].Value = model.C_UNITID;
            parameters[15].Value = model.C_CUST_SQ;
            parameters[16].Value = model.D_NEED_DT;
            parameters[17].Value = model.D_DELIVERY_DT;
            parameters[18].Value = model.D_DT;
            parameters[19].Value = model.C_TECH_PROT;
            parameters[20].Value = model.C_FREE_TERM;
            parameters[21].Value = model.C_FREE_TERM2;
            parameters[22].Value = model.C_PACK;
            parameters[23].Value = model.N_WGT;
            parameters[24].Value = model.C_CRECEIPTAREAID;
            parameters[25].Value = model.C_ADDRESS;
            parameters[26].Value = model.C_RECEIPTCORPID;
            parameters[27].Value = model.C_ATSTATION;
            parameters[28].Value = model.C_CURRENCYTYPEID;
            parameters[29].Value = model.C_STD_CODE;
            parameters[30].Value = model.C_DESIGN_NO;
            parameters[31].Value = model.C_STDID;
            parameters[32].Value = model.C_DESIGNID;
            parameters[33].Value = model.N_SLAB_MATCH_WGT;
            parameters[34].Value = model.N_LINE_MATCH_WGT;
            parameters[35].Value = model.N_STATUS;
            parameters[36].Value = model.N_FLAG;
            parameters[37].Value = model.N_TYPE;
            parameters[38].Value = model.N_EXEC_STATUS;
            parameters[39].Value = model.N_USER_LEV;
            parameters[40].Value = model.C_EDITEMPLOYEEID;
            parameters[41].Value = model.D_EDITDATE;
            parameters[42].Value = model.C_REMARK;
            parameters[43].Value = model.C_EMP_ID;
            parameters[44].Value = model.C_EMP_NAME;
            parameters[45].Value = model.D_MOD_DT;
            parameters[46].Value = model.C_CUST_NO;
            parameters[47].Value = model.C_CUST_NAME;
            parameters[48].Value = model.C_SALE_CHANNEL;
            parameters[49].Value = model.C_LEV;
            parameters[50].Value = model.C_ORDER_LEV;
            parameters[51].Value = model.N_COST;
            parameters[52].Value = model.N_TAXRATE;
            parameters[53].Value = model.N_ORIGINALCURPRICE;
            parameters[54].Value = model.N_ORIGINALCURTAXPRICE;
            parameters[55].Value = model.N_ORIGINALCURNETPRICE;
            parameters[56].Value = model.N_ORIGINALCURTAXNETPRICE;
            parameters[57].Value = model.N_ORIGINALCURTAXMNY;
            parameters[58].Value = model.N_ORIGINALCURMNY;
            parameters[59].Value = model.N_ORIGINALCURSUMMNY;
            parameters[60].Value = model.N_PRICE;
            parameters[61].Value = model.N_TAXPRICE;
            parameters[62].Value = model.N_NETPRICE;
            parameters[63].Value = model.N_TAXNETPRICE;
            parameters[64].Value = model.N_TAXMNY;
            parameters[65].Value = model.N_MNY;
            parameters[66].Value = model.N_SUMMNY;
            parameters[67].Value = model.C_NC_STATE;
            parameters[68].Value = model.N_FNUM;
            parameters[69].Value = model.N_HSL;
            parameters[70].Value = model.C_VDEF1;
            parameters[71].Value = model.C_NO;

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
        public bool Delete(string C_NO)
        {
            ArrayList strSql = new ArrayList();

            strSql.Add("delete from TMO_CONDETAILS where  C_NO='" + C_NO + "'");
            return DbHelperOra.ExecuteSqlTran(strSql);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DelOrder(string C_NO)
        {
            ArrayList strSql = new ArrayList();

            strSql.Add("delete from TMO_CONDETAILS where  C_NO='" + C_NO + "'");//合同明细
            strSql.Add("delete from TMO_ORDER where  C_ORDER_NO='" + C_NO + "'");//订单池
            strSql.Add("delete from TQB_DESIGN_ORDER where C_ORDER_ID='" + C_NO + "'");//质量设计
            strSql.Add("delete from TMP_PLAN where C_NO='" + C_NO + "'");//计划
            strSql.Add("");

            return DbHelperOra.ExecuteSqlTran(strSql);
        }


        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string C_NOlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TMO_CONDETAILS ");
            strSql.Append(" where C_NO in (" + C_NOlist + ")  ");
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
        public Mod_TMO_CONDETAILS GetModel(string C_ORDER_NO)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select t.C_ORDER_NO as C_NO,
                                   t.C_CON_NO,
                                   t.C_CON_NAME,
                                   t.C_AREA,
                                   t.C_XGID,
                                   t.C_INVBASDOCID,
                                   t.C_INVENTORYID,
                                   t.C_PROD_NAME,
                                   t.C_PROD_KIND,
                                   t.C_MAT_CODE,
                                   t.C_MAT_NAME,
                                   t.C_SPEC,
                                   t.C_STL_GRD,
                                   t.C_PRO_USE,
                                   t.C_FUNITID as C_PACKUNITID,
                                   t.C_UNITID,
                                   t.C_CUST_SQ,
                                   t.D_NEED_DT,
                                   t.D_DELIVERY_DT,
                                   t.D_DT,
                                   t.C_TECH_PROT,
                                   t.C_FREE1 as C_FREE_TERM,
                                   t.C_FREE2 as C_FREE_TERM2,
                                   t.C_PACK,
                                   t.N_WGT,
                                   t.C_RECEIPTAREAID as C_CRECEIPTAREAID,
                                   t.C_RECEIVEADDRESS as C_ADDRESS,
                                   t.C_RECEIPTCORPID,
                                   t.C_CURRENCYTYPEID,
                                   t.C_STD_CODE,
                                   t.C_DESIGN_NO,
                                   t.C_STDID,
                                   t.C_DESIGNID,
                                   t.N_SLAB_MATCH_WGT,
                                   t.N_LINE_MATCH_WGT,
                                   t.N_STATUS,
                                   t.N_FLAG,
                                   t.N_TYPE,
                                   t.N_EXEC_STATUS,
                                   t.N_USER_LEV,
                                   t.C_REMARK,
                                   t.C_EMP_ID,
                                   t.C_EMP_NAME,
                                   t.D_MOD_DT,
                                   t.C_CUST_NO,
                                   t.C_CUST_NAME,
                                   t.C_SALE_CHANNEL,
                                   t.C_LEV,
                                   t.C_ORDER_LEV,
                                   t.N_COST,
                                   t.N_TAXRATE,
                                   t.N_ORIGINALCURPRICE,
                                   t.N_ORIGINALCURTAXPRICE,
                                   t.N_ORIGINALCURTAXMNY,
                                   t.N_ORIGINALCURMNY,
                                   t.N_ORIGINALCURSUMMNY,
                                   t.N_FNUM,
                                   t.N_HSL,
                                   t.C_VDEF1,
                                   (select a.c_checkstate_name from tqb_checkstate a where a.c_id=t.C_VDEF1) C_VDEF_NAME,
                                   b.C_MAT_GROUP_CODE,
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
                                           end) ylxwgt
                              from TMO_CON_ORDER t  inner join tb_matrl_main b on b.c_mat_code=t.C_MAT_CODE
                             ");
            strSql.Append(" where t.C_ORDER_NO=:C_ORDER_NO ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ORDER_NO;

            Mod_TMO_CONDETAILS model = new Mod_TMO_CONDETAILS();
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
        public Mod_TMO_CONDETAILS DataRowToModel(DataRow row)
        {
            Mod_TMO_CONDETAILS model = new Mod_TMO_CONDETAILS();
            if (row != null)
            {
                if (row["C_NO"] != null)
                {
                    model.C_NO = row["C_NO"].ToString();
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
                if (row["C_XGID"] != null)
                {
                    model.C_XGID = row["C_XGID"].ToString();
                }
                if (row["C_INVBASDOCID"] != null)
                {
                    model.C_INVBASDOCID = row["C_INVBASDOCID"].ToString();
                }
                if (row["C_INVENTORYID"] != null)
                {
                    model.C_INVENTORYID = row["C_INVENTORYID"].ToString();
                }
                if (row["C_PROD_NAME"] != null)
                {
                    model.C_PROD_NAME = row["C_PROD_NAME"].ToString();
                }
                if (row["C_PROD_KIND"] != null)
                {
                    model.C_PROD_KIND = row["C_PROD_KIND"].ToString();
                }
                if (row["C_MAT_CODE"] != null)
                {
                    model.C_MAT_CODE = row["C_MAT_CODE"].ToString();
                }
                if (row["C_MAT_NAME"] != null)
                {
                    model.C_MAT_NAME = row["C_MAT_NAME"].ToString();
                }
                if (row["C_SPEC"] != null)
                {
                    model.C_SPEC = row["C_SPEC"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_PRO_USE"] != null)
                {
                    model.C_PRO_USE = row["C_PRO_USE"].ToString();
                }
                if (row["C_PACKUNITID"] != null)
                {
                    model.C_PACKUNITID = row["C_PACKUNITID"].ToString();
                }
                if (row["C_UNITID"] != null)
                {
                    model.C_UNITID = row["C_UNITID"].ToString();
                }
                if (row["C_CUST_SQ"] != null)
                {
                    model.C_CUST_SQ = row["C_CUST_SQ"].ToString();
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
                if (row["C_TECH_PROT"] != null)
                {
                    model.C_TECH_PROT = row["C_TECH_PROT"].ToString();
                }
                if (row["C_FREE_TERM"] != null)
                {
                    model.C_FREE_TERM = row["C_FREE_TERM"].ToString();
                }
                if (row["C_FREE_TERM2"] != null)
                {
                    model.C_FREE_TERM2 = row["C_FREE_TERM2"].ToString();
                }
                if (row["C_PACK"] != null)
                {
                    model.C_PACK = row["C_PACK"].ToString();
                }
                if (row["N_WGT"] != null && row["N_WGT"].ToString() != "")
                {
                    model.N_WGT = decimal.Parse(row["N_WGT"].ToString());
                }
                if (row["C_CRECEIPTAREAID"] != null)
                {
                    model.C_CRECEIPTAREAID = row["C_CRECEIPTAREAID"].ToString();
                }
                if (row["C_ADDRESS"] != null)
                {
                    model.C_ADDRESS = row["C_ADDRESS"].ToString();
                }
                if (row["C_RECEIPTCORPID"] != null)
                {
                    model.C_RECEIPTCORPID = row["C_RECEIPTCORPID"].ToString();
                }
                //if (row["C_ATSTATION"] != null)
                //{
                //    model.C_ATSTATION = row["C_ATSTATION"].ToString();
                //}
                if (row["C_CURRENCYTYPEID"] != null)
                {
                    model.C_CURRENCYTYPEID = row["C_CURRENCYTYPEID"].ToString();
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
                if (row["N_SLAB_MATCH_WGT"] != null && row["N_SLAB_MATCH_WGT"].ToString() != "")
                {
                    model.N_SLAB_MATCH_WGT = decimal.Parse(row["N_SLAB_MATCH_WGT"].ToString());
                }
                if (row["N_LINE_MATCH_WGT"] != null && row["N_LINE_MATCH_WGT"].ToString() != "")
                {
                    model.N_LINE_MATCH_WGT = decimal.Parse(row["N_LINE_MATCH_WGT"].ToString());
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["N_FLAG"] != null && row["N_FLAG"].ToString() != "")
                {
                    model.N_FLAG = decimal.Parse(row["N_FLAG"].ToString());
                }
                if (row["N_TYPE"] != null && row["N_TYPE"].ToString() != "")
                {
                    model.N_TYPE = decimal.Parse(row["N_TYPE"].ToString());
                }
                if (row["N_EXEC_STATUS"] != null && row["N_EXEC_STATUS"].ToString() != "")
                {
                    model.N_EXEC_STATUS = decimal.Parse(row["N_EXEC_STATUS"].ToString());
                }
                if (row["N_USER_LEV"] != null && row["N_USER_LEV"].ToString() != "")
                {
                    model.N_USER_LEV = decimal.Parse(row["N_USER_LEV"].ToString());
                }
                //if (row["C_EDITEMPLOYEEID"] != null)
                //{
                //    model.C_EDITEMPLOYEEID = row["C_EDITEMPLOYEEID"].ToString();
                //}
                //if (row["D_EDITDATE"] != null && row["D_EDITDATE"].ToString() != "")
                //{
                //    model.D_EDITDATE = DateTime.Parse(row["D_EDITDATE"].ToString());
                //}
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
                if (row["C_LEV"] != null)
                {
                    model.C_LEV = row["C_LEV"].ToString();
                }
                if (row["C_ORDER_LEV"] != null)
                {
                    model.C_ORDER_LEV = row["C_ORDER_LEV"].ToString();
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
                //if (row["N_ORIGINALCURNETPRICE"] != null && row["N_ORIGINALCURNETPRICE"].ToString() != "")
                //{
                //    model.N_ORIGINALCURNETPRICE = decimal.Parse(row["N_ORIGINALCURNETPRICE"].ToString());
                //}
                //if (row["N_ORIGINALCURTAXNETPRICE"] != null && row["N_ORIGINALCURTAXNETPRICE"].ToString() != "")
                //{
                //    model.N_ORIGINALCURTAXNETPRICE = decimal.Parse(row["N_ORIGINALCURTAXNETPRICE"].ToString());
                //}
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
                //if (row["N_PRICE"] != null && row["N_PRICE"].ToString() != "")
                //{
                //    model.N_PRICE = decimal.Parse(row["N_PRICE"].ToString());
                //}
                //if (row["N_TAXPRICE"] != null && row["N_TAXPRICE"].ToString() != "")
                //{
                //    model.N_TAXPRICE = decimal.Parse(row["N_TAXPRICE"].ToString());
                //}
                //if (row["N_NETPRICE"] != null && row["N_NETPRICE"].ToString() != "")
                //{
                //    model.N_NETPRICE = decimal.Parse(row["N_NETPRICE"].ToString());
                //}
                //if (row["N_TAXNETPRICE"] != null && row["N_TAXNETPRICE"].ToString() != "")
                //{
                //    model.N_TAXNETPRICE = decimal.Parse(row["N_TAXNETPRICE"].ToString());
                //}
                //if (row["N_TAXMNY"] != null && row["N_TAXMNY"].ToString() != "")
                //{
                //    model.N_TAXMNY = decimal.Parse(row["N_TAXMNY"].ToString());
                //}
                //if (row["N_MNY"] != null && row["N_MNY"].ToString() != "")
                //{
                //    model.N_MNY = decimal.Parse(row["N_MNY"].ToString());
                //}
                //if (row["N_SUMMNY"] != null && row["N_SUMMNY"].ToString() != "")
                //{
                //    model.N_SUMMNY = decimal.Parse(row["N_SUMMNY"].ToString());
                //}
                //if (row["C_NC_STATE"] != null)
                //{
                //    model.C_NC_STATE = row["C_NC_STATE"].ToString();
                //}
                if (row["N_FNUM"] != null && row["N_FNUM"].ToString() != "")
                {
                    model.N_FNUM = decimal.Parse(row["N_FNUM"].ToString());
                }
                if (row["N_HSL"] != null && row["N_HSL"].ToString() != "")
                {
                    model.N_HSL = decimal.Parse(row["N_HSL"].ToString());
                }
                if (row["C_VDEF1"] != null)
                {
                    model.C_VDEF1 = row["C_VDEF1"].ToString();
                }
                if (row["C_VDEF_NAME"] != null)
                {
                    model.C_VDEF_NAME = row["C_VDEF_NAME"].ToString();
                }
                if(row["C_MAT_GROUP_CODE"]!=null)
                {
                    model.C_MAT_GROUP_CODE = row["C_MAT_GROUP_CODE"].ToString();
                }
                if (row["SCZT"] != null)
                {
                    model.SCZT = row["SCZT"].ToString();
                }
                if (row["YLXWGT"] != null)
                {
                    model.YLXWGT = row["YLXWGT"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMO_CONDETAILS2 DataRowToModel2(DataRow row)
        {
            Mod_TMO_CONDETAILS2 model = new Mod_TMO_CONDETAILS2();
            if (row != null)
            {
                if (row["C_NO"] != null)
                {
                    model.C_NO = row["C_NO"].ToString();
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
                if (row["C_MAT_CODE"] != null)
                {
                    model.C_MAT_CODE = row["C_MAT_CODE"].ToString();
                }
                if (row["C_MAT_NAME"] != null)
                {
                    model.C_MAT_NAME = row["C_MAT_NAME"].ToString();
                }
                if (row["C_TECH_PROT"] != null)
                {
                    model.C_TECH_PROT = row["C_TECH_PROT"].ToString();
                }
                if (row["C_SPEC"] != null)
                {
                    model.C_SPEC = row["C_SPEC"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }

                if (row["C_FREE_TERM"] != null)
                {
                    model.C_FREE_TERM = row["C_FREE_TERM"].ToString();
                }

                if (row["N_WGT"] != null)
                {
                    model.N_WGT = row["N_WGT"].ToString();
                }

                if (row["C_PACK"] != null)
                {
                    model.C_PACK = row["C_PACK"].ToString();
                }

            }
            return model;
        }
        /// <summary>
        /// 获取订单总数
        /// </summary>
        /// <param name="C_MAT_NAME">订单号</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <param name="C_SPEC">规格</param>
        /// <param name="N_CUSTSTATUS">状态</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="C_EMP_ID">订单人</param>
        /// <returns></returns>
        public int GetOrderCount(string C_MAT_NAME, string C_STL_GRD, string C_SPEC, string N_CUSTSTATUS, string startdate, string enddate, string C_EMP_ID)
        {
            StringBuilder where = new StringBuilder();
            where.Append("select count(1) FROM TMO_CONDETAILS where 1=1 ");

            where.Append(" and C_EMP_ID ='" + C_EMP_ID + "'");

            if (!string.IsNullOrEmpty(N_CUSTSTATUS))
            {
                where.Append(" and N_CUSTSTATUS =" + N_CUSTSTATUS + "");
            }

            if (!string.IsNullOrEmpty(C_MAT_NAME))
            {
                where.Append(" and C_MAT_NAME like'%" + C_MAT_NAME + "%'");
            }
            if (!string.IsNullOrEmpty(C_STL_GRD))
            {
                where.Append(" and C_STL_GRD like '%" + C_STL_GRD + "%'");
            }
            if (!string.IsNullOrEmpty(C_SPEC))
            {
                where.Append(" and C_SPEC like '%" + C_SPEC + "%'");
            }
            if (!string.IsNullOrEmpty(startdate) && !string.IsNullOrEmpty(enddate))
            {
                where.Append(" and D_DT between to_date('" + startdate + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(enddate).AddDays(1).ToString() + "', 'yyyy-mm-dd hh24:mi:ss')");
            }

            object obj = DbHelperOra.GetSingle(where.ToString());
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
        /// 获取订单分页记录
        /// </summary>
        /// <param name="pageSize">显示条数</param>
        /// <param name="startIndex">起始条数</param>
        /// <param name="C_MAT_NAME">物料名称</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <param name="C_SPEC">规格</param>
        /// <param name="N_CUSTSTATUS">状态</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="C_EMP_ID">订单人ID</param>
        /// <returns></returns>
        public DataSet GetOrderByPage(int pageSize, int startIndex, string C_MAT_NAME, string C_STL_GRD, string C_SPEC, string N_CUSTSTATUS, string startdate, string enddate, string C_EMP_ID)
        {
            StringBuilder where = new StringBuilder();
            string item = "C_NO,C_CON_NO,C_CON_NAME,C_AREA,C_XGID,C_INVBASDOCID,C_INVENTORYID,C_PROD_NAME,C_PROD_KIND,C_MAT_CODE,C_MAT_NAME,C_SPEC,C_STL_GRD,C_PRO_USE,C_PACKUNITID,C_UNITID,C_CUST_SQ,D_NEED_DT,D_DELIVERY_DT,D_DT,C_TECH_PROT,C_FREE_TERM,C_FREE_TERM2,C_PACK,N_WGT,C_CRECEIPTAREAID,C_ADDRESS,C_RECEIPTCORPID,C_ATSTATION,C_CURRENCYTYPEID,C_STD_CODE,C_DESIGN_NO,C_STDID,C_DESIGNID,N_SLAB_MATCH_WGT,N_LINE_MATCH_WGT,N_STATUS,N_FLAG,N_TYPE,N_EXEC_STATUS,N_USER_LEV,C_EDITEMPLOYEEID,D_EDITDATE,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_CUST_NO,C_CUST_NAME,C_SALE_CHANNEL,C_LEV,C_ORDER_LEV,N_COST,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURNETPRICE,N_ORIGINALCURTAXNETPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,N_ORIGINALCURSUMMNY,N_PRICE,N_TAXPRICE,N_NETPRICE,N_TAXNETPRICE,N_TAXMNY,N_MNY,N_SUMMNY,C_NC_STATE,N_FNUM,N_HSL,C_VDEF1";
            string table = "TMO_CONDETAILS";
            string order = " D_CUSTNEEDDATE asc";

            where.Append(" and C_EMP_ID ='" + C_EMP_ID + "'");

            if (!string.IsNullOrEmpty(N_CUSTSTATUS))
            {
                where.Append(" and N_CUSTSTATUS =" + N_CUSTSTATUS + "");
            }

            if (!string.IsNullOrEmpty(C_MAT_NAME))
            {
                where.Append(" and C_MAT_NAME like'%" + C_MAT_NAME + "%'");
            }
            if (!string.IsNullOrEmpty(C_STL_GRD))
            {
                where.Append(" and C_STL_GRD like '%" + C_STL_GRD + "%'");
            }
            if (!string.IsNullOrEmpty(C_SPEC))
            {
                where.Append(" and C_SPEC like '%" + C_SPEC + "%'");
            }
            if (!string.IsNullOrEmpty(startdate) && !string.IsNullOrEmpty(enddate))
            {
                where.Append(" and D_DT between to_date('" + startdate + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(enddate).AddDays(1).ToString() + "', 'yyyy-mm-dd hh24:mi:ss')");
            }

            string sql = ByPage.GenerateByPageSql(pageSize, startIndex, item, table, order, where.ToString());
            return DbHelperOra.Query(sql);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetConOrderList(string conNo, string c_no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_NO,C_CON_NO,C_CON_NAME,C_AREA,C_XGID,C_INVBASDOCID,C_INVENTORYID,C_PROD_NAME,C_PROD_KIND,C_MAT_CODE,C_MAT_NAME,C_SPEC,C_STL_GRD,C_PRO_USE,C_PACKUNITID,C_UNITID,C_CUST_SQ,D_NEED_DT,D_DELIVERY_DT,D_DT,C_TECH_PROT,C_FREE_TERM,C_FREE_TERM2,C_PACK,N_WGT,C_CRECEIPTAREAID,C_ADDRESS,C_RECEIPTCORPID,C_ATSTATION,C_CURRENCYTYPEID,C_STD_CODE,C_DESIGN_NO,C_STDID,C_DESIGNID,N_SLAB_MATCH_WGT,N_LINE_MATCH_WGT,N_STATUS,N_FLAG,N_TYPE,N_EXEC_STATUS,N_USER_LEV,C_EDITEMPLOYEEID,D_EDITDATE,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_CUST_NO,C_CUST_NAME,C_SALE_CHANNEL,C_LEV,C_ORDER_LEV,N_COST,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURNETPRICE,N_ORIGINALCURTAXNETPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,N_ORIGINALCURSUMMNY,N_PRICE,N_TAXPRICE,N_NETPRICE,N_TAXNETPRICE,N_TAXMNY,N_MNY,N_SUMMNY,C_NC_STATE,N_FNUM,N_HSL,C_VDEF1 ");
            strSql.Append(" FROM TMO_CONDETAILS where 1=1");
            if (!string.IsNullOrEmpty(conNo))
            {
                strSql.Append(" and C_CON_NO='" + conNo + "'");
            }
            if (!string.IsNullOrEmpty(c_no))
            {
                strSql.Append(" and C_NO='" + c_no + "'");
            }
            strSql.Append(" order by D_DT asc");
            return DbHelperOra.Query(strSql.ToString());
        }





        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_NO,C_CON_NO,C_CON_NAME,C_AREA,C_XGID,C_INVBASDOCID,C_INVENTORYID,C_PROD_NAME,C_PROD_KIND,C_MAT_CODE,C_MAT_NAME,C_SPEC,C_STL_GRD,C_PRO_USE,C_PACKUNITID,C_UNITID,C_CUST_SQ,D_NEED_DT,D_DELIVERY_DT,D_DT,C_TECH_PROT,C_FREE_TERM,C_FREE_TERM2,C_PACK,N_WGT,C_CRECEIPTAREAID,C_ADDRESS,C_RECEIPTCORPID,C_ATSTATION,C_CURRENCYTYPEID,C_STD_CODE,C_DESIGN_NO,C_STDID,C_DESIGNID,N_SLAB_MATCH_WGT,N_LINE_MATCH_WGT,N_STATUS,N_FLAG,N_TYPE,N_EXEC_STATUS,N_USER_LEV,C_EDITEMPLOYEEID,D_EDITDATE,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_CUST_NO,C_CUST_NAME,C_SALE_CHANNEL,C_LEV,C_ORDER_LEV,N_COST,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURNETPRICE,N_ORIGINALCURTAXNETPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,N_ORIGINALCURSUMMNY,N_PRICE,N_TAXPRICE,N_NETPRICE,N_TAXNETPRICE,N_TAXMNY,N_MNY,N_SUMMNY,C_NC_STATE,N_FNUM,N_HSL,C_VDEF1 ");
            strSql.Append(" FROM TMO_CONDETAILS ");
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
            strSql.Append("select count(1) FROM TMO_CONDETAILS ");
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
                strSql.Append("order by T.C_NO desc");
            }
            strSql.Append(")AS Row, T.*  from TMO_CONDETAILS T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion  BasicMethod

        #region  自定义方法

        /// <summary>
        /// 更新订单匹配量
        /// </summary>
        public bool UpdateMatch(decimal WGT, string orderNo, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMO_CONDETAILS set ");
            if (type == 8)
            {
                strSql.Append("N_LINE_MATCH_WGT=N_LINE_MATCH_WGT+" + WGT + "");
            }
            else
            {
                strSql.Append("N_SLAB_MATCH_WGT=N_SLAB_MATCH_WGT+" + WGT + "");
            }

            strSql.Append(" where C_CON_NO='" + orderNo + "'");
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




        #endregion  ExtensionMethod


        #region //手机接口

        #region //合同订单列表

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string C_CON_NO, string C_MAT_CODE, string C_MAT_NAME, string C_SPEC, string C_STL_GRD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select C_ORDER_NO as C_NO,
                                   C_CON_NO,
                                   C_CON_NAME,
                                   C_AREA,
                                   C_MAT_CODE,
                                   C_MAT_NAME,
                                   C_TECH_PROT,
                                   C_SPEC,
                                   C_STL_GRD,
                                   C_FREE1 as C_FREE_TERM,
                                   C_FREE2 as C_FREE_TERM2,
                                   N_WGT,
                                   C_PACK
                                   FROM tmo_con_order where 1=1");
            if (!string.IsNullOrEmpty(C_CON_NO))
            {
                strSql.Append(" and C_CON_NO='" + C_CON_NO + "'");
            }
            if (!string.IsNullOrEmpty(C_MAT_CODE))
            {
                strSql.Append(" and C_MAT_CODE like '%" + C_MAT_CODE + "%'");
            }
            if (!string.IsNullOrEmpty(C_MAT_NAME))
            {
                strSql.Append(" and C_MAT_NAME like '%" + C_MAT_NAME + "%'");
            }
            if (!string.IsNullOrEmpty(C_SPEC))
            {
                strSql.Append(" and C_SPEC like '%" + C_SPEC + "%'");
            }
            if (!string.IsNullOrEmpty(C_STL_GRD))
            {
                strSql.Append(" and UPPER(C_STL_GRD) like '%" + C_STL_GRD.ToUpper() + "%'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion


        #region //客户历史订单
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetConOrderList(string conNo, string c_no, string stlGrd, string start, string end, string custNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select C_ORDER_NO as C_NO,
                                   C_CON_NO,
                                   C_CON_NAME,
                                   C_AREA,
                                   C_XGID,
                                   C_INVBASDOCID,
                                   C_INVENTORYID,
                                   C_PROD_NAME,
                                   C_PROD_KIND,
                                   C_MAT_CODE,
                                   C_MAT_NAME,
                                   C_SPEC,
                                   C_STL_GRD,
                                   C_PRO_USE,
                                   C_FUNITID as C_PACKUNITID,
                                   C_UNITID,
                                   C_CUST_SQ,
                                   D_NEED_DT,
                                   D_DELIVERY_DT,
                                   D_DT,
                                   C_TECH_PROT,
                                   C_FREE1 as C_FREE_TERM,
                                   C_FREE2 as C_FREE_TERM2,
                                   C_PACK,
                                   N_WGT,
                                   C_RECEIPTCORPID,
                                   C_CURRENCYTYPEID,
                                   C_STD_CODE,
                                   C_DESIGN_NO,
                                   C_STDID,
                                   C_DESIGNID,
                                   N_SLAB_MATCH_WGT,
                                   N_LINE_MATCH_WGT,
                                   N_STATUS,
                                   N_FLAG,
                                   N_TYPE,
                                   N_EXEC_STATUS,
                                   N_USER_LEV,
                                   C_REMARK,
                                   C_EMP_ID,
                                   C_EMP_NAME,
                                   D_MOD_DT,
                                   C_CUST_NO,
                                   C_CUST_NAME,
                                   C_SALE_CHANNEL,
                                   C_LEV,
                                   C_ORDER_LEV,
                                   N_COST,
                                   N_TAXRATE,
                                   N_ORIGINALCURPRICE,
                                   N_ORIGINALCURTAXPRICE,
                                   N_ORIGINALCURTAXMNY,
                                   N_ORIGINALCURMNY,
                                   N_ORIGINALCURSUMMNY,
                                   N_FNUM,
                                   N_HSL,
                                   C_VDEF1
                                    FROM tmo_order where 1=1
                             ");
            
            if (!string.IsNullOrEmpty(custNO))
            {
                strSql.Append(" and C_CUST_NO='" + custNO + "'");
            }
            if (!string.IsNullOrEmpty(conNo))
            {
                strSql.Append(" and C_CON_NO='" + conNo + "'");
            }
            if (!string.IsNullOrEmpty(c_no))
            {
                strSql.Append(" and C_ORDER_NO='" + c_no + "'");
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.Append(" and UPPER(C_STL_GRD)='" + stlGrd.ToUpper() + "'");
            }
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                strSql.Append(" and D_DT between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).AddDays(1).ToString() + "', 'yyyy-mm-dd hh24:mi:ss')");
            }


            strSql.Append(" order by D_DT asc");
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

        #endregion

    }
}

