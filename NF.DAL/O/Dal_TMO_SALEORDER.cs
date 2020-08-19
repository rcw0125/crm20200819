using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Collections;
using System.Collections.Generic;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMO_SALEORDER
    /// </summary>
    public partial class Dal_TMO_SALEORDER
    {


        public Dal_TMO_SALEORDER()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMO_SALEORDER");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMO_SALEORDER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMO_SALEORDER(");
            strSql.Append("C_ID,C_CODE,C_CONNO,C_INITIALIZE_ID,C_PK_CORP,C_BIZTYPE,D_BILLDATE,C_CUSTOMERID,C_DEPTID,C_EMPLOYEEID,C_OPERATORID,C_COPERATORID,C_SALECORPID,C_CALBODYID,C_RECEIPTCUSTOMERID,C_RECEIVEADDRESS,C_RECEIPTCORPID,C_TRANSMODEID,D_MAKEDATE,C_APPROVEID,D_APPROVEDATE,C_REMARK,N_STATUS)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_CODE,:C_CONNO,:C_INITIALIZE_ID,:C_PK_CORP,:C_BIZTYPE,:D_BILLDATE,:C_CUSTOMERID,:C_DEPTID,:C_EMPLOYEEID,:C_OPERATORID,:C_COPERATORID,:C_SALECORPID,:C_CALBODYID,:C_RECEIPTCUSTOMERID,:C_RECEIVEADDRESS,:C_RECEIPTCORPID,:C_TRANSMODEID,:D_MAKEDATE,:C_APPROVEID,:D_APPROVEDATE,:C_REMARK,:N_STATUS)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CONNO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_INITIALIZE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PK_CORP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BIZTYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_BILLDATE", OracleDbType.Date),
                    new OracleParameter(":C_CUSTOMERID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DEPTID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMPLOYEEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_OPERATORID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_COPERATORID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SALECORPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CALBODYID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RECEIPTCUSTOMERID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RECEIVEADDRESS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RECEIPTCORPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TRANSMODEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MAKEDATE", OracleDbType.Date),
                    new OracleParameter(":C_APPROVEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_APPROVEDATE", OracleDbType.Date),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_CODE;
            parameters[2].Value = model.C_CONNO;
            parameters[3].Value = model.C_INITIALIZE_ID;
            parameters[4].Value = model.C_PK_CORP;
            parameters[5].Value = model.C_BIZTYPE;
            parameters[6].Value = model.D_BILLDATE;
            parameters[7].Value = model.C_CUSTOMERID;
            parameters[8].Value = model.C_DEPTID;
            parameters[9].Value = model.C_EMPLOYEEID;
            parameters[10].Value = model.C_OPERATORID;
            parameters[11].Value = model.C_COPERATORID;
            parameters[12].Value = model.C_SALECORPID;
            parameters[13].Value = model.C_CALBODYID;
            parameters[14].Value = model.C_RECEIPTCUSTOMERID;
            parameters[15].Value = model.C_RECEIVEADDRESS;
            parameters[16].Value = model.C_RECEIPTCORPID;
            parameters[17].Value = model.C_TRANSMODEID;
            parameters[18].Value = model.D_MAKEDATE;
            parameters[19].Value = model.C_APPROVEID;
            parameters[20].Value = model.D_APPROVEDATE;
            parameters[21].Value = model.C_REMARK;
            parameters[22].Value = model.N_STATUS;

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
        public bool Update(Mod_TMO_SALEORDER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMO_SALEORDER set ");
            strSql.Append("C_CODE=:C_CODE,");
            strSql.Append("C_CONNO=:C_CONNO,");
            strSql.Append("C_INITIALIZE_ID=:C_INITIALIZE_ID,");
            strSql.Append("C_PK_CORP=:C_PK_CORP,");
            strSql.Append("C_BIZTYPE=:C_BIZTYPE,");
            strSql.Append("D_BILLDATE=:D_BILLDATE,");
            strSql.Append("C_CUSTOMERID=:C_CUSTOMERID,");
            strSql.Append("C_DEPTID=:C_DEPTID,");
            strSql.Append("C_EMPLOYEEID=:C_EMPLOYEEID,");
            strSql.Append("C_OPERATORID=:C_OPERATORID,");
            strSql.Append("C_COPERATORID=:C_COPERATORID,");
            strSql.Append("C_SALECORPID=:C_SALECORPID,");
            strSql.Append("C_CALBODYID=:C_CALBODYID,");
            strSql.Append("C_RECEIPTCUSTOMERID=:C_RECEIPTCUSTOMERID,");
            strSql.Append("C_RECEIVEADDRESS=:C_RECEIVEADDRESS,");
            strSql.Append("C_RECEIPTCORPID=:C_RECEIPTCORPID,");
            strSql.Append("C_TRANSMODEID=:C_TRANSMODEID,");
            strSql.Append("D_MAKEDATE=:D_MAKEDATE,");
            strSql.Append("C_APPROVEID=:C_APPROVEID,");
            strSql.Append("D_APPROVEDATE=:D_APPROVEDATE,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("N_STATUS=:N_STATUS");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CONNO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_INITIALIZE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PK_CORP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BIZTYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_BILLDATE", OracleDbType.Date),
                    new OracleParameter(":C_CUSTOMERID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DEPTID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMPLOYEEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_OPERATORID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_COPERATORID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SALECORPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CALBODYID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RECEIPTCUSTOMERID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RECEIVEADDRESS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RECEIPTCORPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TRANSMODEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MAKEDATE", OracleDbType.Date),
                    new OracleParameter(":C_APPROVEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_APPROVEDATE", OracleDbType.Date),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_CODE;
            parameters[1].Value = model.C_CONNO;
            parameters[2].Value = model.C_INITIALIZE_ID;
            parameters[3].Value = model.C_PK_CORP;
            parameters[4].Value = model.C_BIZTYPE;
            parameters[5].Value = model.D_BILLDATE;
            parameters[6].Value = model.C_CUSTOMERID;
            parameters[7].Value = model.C_DEPTID;
            parameters[8].Value = model.C_EMPLOYEEID;
            parameters[9].Value = model.C_OPERATORID;
            parameters[10].Value = model.C_COPERATORID;
            parameters[11].Value = model.C_SALECORPID;
            parameters[12].Value = model.C_CALBODYID;
            parameters[13].Value = model.C_RECEIPTCUSTOMERID;
            parameters[14].Value = model.C_RECEIVEADDRESS;
            parameters[15].Value = model.C_RECEIPTCORPID;
            parameters[16].Value = model.C_TRANSMODEID;
            parameters[17].Value = model.D_MAKEDATE;
            parameters[18].Value = model.C_APPROVEID;
            parameters[19].Value = model.D_APPROVEDATE;
            parameters[20].Value = model.C_REMARK;
            parameters[21].Value = model.N_STATUS;
            parameters[22].Value = model.C_ID;

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
            strSql.Append("delete from TMO_SALEORDER ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
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
            strSql.Append("delete from TMO_SALEORDER ");
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
        public Mod_TMO_SALEORDER GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_CODE,C_CONNO,C_INITIALIZE_ID,C_PK_CORP,C_BIZTYPE,D_BILLDATE,C_CUSTOMERID,C_DEPTID,C_EMPLOYEEID,C_OPERATORID,C_COPERATORID,C_SALECORPID,C_CALBODYID,C_RECEIPTCUSTOMERID,C_RECEIVEADDRESS,C_RECEIPTCORPID,C_TRANSMODEID,D_MAKEDATE,C_APPROVEID,D_APPROVEDATE,C_REMARK,N_STATUS from TMO_SALEORDER ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TMO_SALEORDER model = new Mod_TMO_SALEORDER();
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
        public Mod_TMO_SALEORDER DataRowToModel(DataRow row)
        {
            Mod_TMO_SALEORDER model = new Mod_TMO_SALEORDER();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_CODE"] != null)
                {
                    model.C_CODE = row["C_CODE"].ToString();
                }
                if (row["C_CONNO"] != null)
                {
                    model.C_CONNO = row["C_CONNO"].ToString();
                }
                if (row["C_INITIALIZE_ID"] != null)
                {
                    model.C_INITIALIZE_ID = row["C_INITIALIZE_ID"].ToString();
                }
                if (row["C_PK_CORP"] != null)
                {
                    model.C_PK_CORP = row["C_PK_CORP"].ToString();
                }
                if (row["C_BIZTYPE"] != null)
                {
                    model.C_BIZTYPE = row["C_BIZTYPE"].ToString();
                }
                if (row["D_BILLDATE"] != null && row["D_BILLDATE"].ToString() != "")
                {
                    model.D_BILLDATE = DateTime.Parse(row["D_BILLDATE"].ToString());
                }
                if (row["C_CUSTOMERID"] != null)
                {
                    model.C_CUSTOMERID = row["C_CUSTOMERID"].ToString();
                }
                if (row["C_DEPTID"] != null)
                {
                    model.C_DEPTID = row["C_DEPTID"].ToString();
                }
                if (row["C_EMPLOYEEID"] != null)
                {
                    model.C_EMPLOYEEID = row["C_EMPLOYEEID"].ToString();
                }
                if (row["C_OPERATORID"] != null)
                {
                    model.C_OPERATORID = row["C_OPERATORID"].ToString();
                }
                if (row["C_COPERATORID"] != null)
                {
                    model.C_COPERATORID = row["C_COPERATORID"].ToString();
                }
                if (row["C_SALECORPID"] != null)
                {
                    model.C_SALECORPID = row["C_SALECORPID"].ToString();
                }
                if (row["C_CALBODYID"] != null)
                {
                    model.C_CALBODYID = row["C_CALBODYID"].ToString();
                }
                if (row["C_RECEIPTCUSTOMERID"] != null)
                {
                    model.C_RECEIPTCUSTOMERID = row["C_RECEIPTCUSTOMERID"].ToString();
                }
                if (row["C_RECEIVEADDRESS"] != null)
                {
                    model.C_RECEIVEADDRESS = row["C_RECEIVEADDRESS"].ToString();
                }
                if (row["C_RECEIPTCORPID"] != null)
                {
                    model.C_RECEIPTCORPID = row["C_RECEIPTCORPID"].ToString();
                }
                if (row["C_TRANSMODEID"] != null)
                {
                    model.C_TRANSMODEID = row["C_TRANSMODEID"].ToString();
                }
                if (row["D_MAKEDATE"] != null && row["D_MAKEDATE"].ToString() != "")
                {
                    model.D_MAKEDATE = DateTime.Parse(row["D_MAKEDATE"].ToString());
                }
                if (row["C_APPROVEID"] != null)
                {
                    model.C_APPROVEID = row["C_APPROVEID"].ToString();
                }
                if (row["D_APPROVEDATE"] != null && row["D_APPROVEDATE"].ToString() != "")
                {
                    model.D_APPROVEDATE = DateTime.Parse(row["D_APPROVEDATE"].ToString());
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
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
            strSql.Append("select C_ID,C_CODE,C_CONNO,C_INITIALIZE_ID,C_PK_CORP,C_BIZTYPE,D_BILLDATE,C_CUSTOMERID,C_DEPTID,C_EMPLOYEEID,C_OPERATORID,C_COPERATORID,C_SALECORPID,C_CALBODYID,C_RECEIPTCUSTOMERID,C_RECEIVEADDRESS,C_RECEIPTCORPID,C_TRANSMODEID,D_MAKEDATE,C_APPROVEID,D_APPROVEDATE,C_REMARK,N_STATUS ");
            strSql.Append(" FROM TMO_SALEORDER ");
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
            strSql.Append("select count(1) FROM TMO_SALEORDER ");
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
            strSql.Append(")AS Row, T.*  from TMO_SALEORDER T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

        #region 自定义方法

        /// <summary>
        /// 更新销售订单状态
        /// </summary>
        /// <param name="pkID">主键</param>
        /// <param name="status">状态:0停用,1启用,2导入NC成功,3失败</param>
        /// <returns></returns>
        public bool UpdateStatus(string pkID, int status)
        {
            int rows = DbHelperOra.ExecuteSql("update TMO_SALEORDER set N_STATUS="+status+ " where C_ID='"+ pkID + "'");
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
        /// 插入销售订单
        /// </summary>
        /// <param name="parem">合同参数列表,返回DataTable:ID,CODE</param>
        /// <returns></returns>
        public DataTable InsertSaleOrder(List<string> parem)
        {
            //初始化DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));//主键
            dt.Columns.Add("CODE", typeof(string));//单据号


            Dal_TMO_CON tmo_con = new Dal_TMO_CON();
            Dal_TMO_CONDETAILS tmo_condetails = new Dal_TMO_CONDETAILS();
            ArrayList strSql = new ArrayList();


            if (parem.Count > 0)
            {
                for (int i = 0; i < parem.Count; i++)
                {
                    Mod_TMO_CON modCon = tmo_con.GetModel(parem[i]);
                    Mod_TMO_SALEORDER modSale = new Mod_TMO_SALEORDER();

                    #region //销售订单主表
                    string pk_mainid = Guid.NewGuid().ToString("N");//主键ID
                    string code = Dal_RandomNumber.GetSaleCode();//销售单据号

                    dt.Rows.Add(new object[] { pk_mainid, code });

                    StringBuilder cmdText = new StringBuilder();
                    cmdText.Append("insert into TMO_SALEORDER(");
                    cmdText.Append("C_ID,C_CODE,C_CONNO,C_INITIALIZE_ID,C_BIZTYPE,D_BILLDATE,C_CUSTOMERID,C_DEPTID,C_EMPLOYEEID,C_OPERATORID,C_SALECORPID,C_RECEIPTCUSTOMERID,C_RECEIVEADDRESS,C_RECEIPTCORPID,C_TRANSMODEID,D_MAKEDATE,C_APPROVEID,D_APPROVEDATE)");
                    cmdText.Append(" values (");
                    cmdText.Append("'" + pk_mainid + "',");//主键ID
                    cmdText.Append("'" + code + "',");//销售单据号
                    cmdText.Append("'" + modCon.C_CON_NO + "',");//合同号
                    cmdText.Append("'',");//方案表主键
                    cmdText.Append("'" + modCon.C_BIZTYPE + "',");//业务类型ID
                    cmdText.Append("to_date('" + DateTime.Now + "','yyyy-mm-dd hh24:mi:ss'),");//单据日期
                    cmdText.Append("'" + modCon.C_CUSTOMERID + "',");//客户ID-NC客商管理档案主键
                    cmdText.Append("'" + modCon.C_DEPTID + "',");//部门ID
                    cmdText.Append("'" + modCon.C_EMPLOYEEID + "',");//业务员ID
                    cmdText.Append("'" + modCon.C_COPERATORID + "',");//制单人ID
                    cmdText.Append("'" + modCon.C_SALECORPID + "',");//销售组织ID
                    cmdText.Append("'" + modCon.C_CRECEIPTCUSTOMERID + "',");//收货单位
                    cmdText.Append("'" + modCon.C_ADDRESS + "',");//收货地址
                    cmdText.Append("'" + modCon.C_CRECEIPTAREAID + "',");//开票单位ID-来源与客户档案信息
                    cmdText.Append("'" + modCon.C_TRANSMODEID + "',");//发运方式ID
                    cmdText.Append("to_date('" + modCon.D_DMAKEDATE + "','yyyy-mm-dd hh24:mi:ss'),");//制单日期
                    cmdText.Append("'" + modCon.C_APPROVEID + "',");//审批人
                    cmdText.Append("to_date('" + modCon.D_APPROVEDATE + "','yyyy-mm-dd hh24:mi:ss')");//审批日期
                    cmdText.Append(")");
                    strSql.Add(cmdText.ToString());
                    #endregion


                    DataTable dtOrder = tmo_condetails.GetConOrderList(parem[i], "").Tables[0];
                    if (dtOrder.Rows.Count > 0)
                    {
                        for (int k = 0; k < dtOrder.Rows.Count; k++)
                        {
                            #region //插入销售订单子表
                            Mod_TMO_CONDETAILS modOrder = tmo_condetails.GetModel(dtOrder.Rows[k]["C_NO"].ToString());
                            string pk_itemid = Guid.NewGuid().ToString("N");//主键
                            StringBuilder cmdText2 = new StringBuilder();
                            cmdText2.Append("insert into TMO_SALEORDERITEM(");
                            cmdText2.Append("C_ID,C_BILLID,C_ORDERNO,C_CONNO,C_INVBASDOCID,C_INVENTORYID,C_UNITID,C_FUNITID,N_NUMBER,D_CONSIGNDATE,D_DELIVERDATE,C_CURRENCYTYPEID,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,N_ORIGINALCURSUMMNY,C_RECEIPTAREAID,C_RECEIVEADDRESS,C_RECEIPTCORPID,C_VFREE1,C_VFREE2,C_VFREE3,C_VDEF1)");
                            cmdText2.Append(" values (");
                            cmdText2.Append("'" + pk_itemid + "',");//主键
                            cmdText2.Append("'" + pk_mainid + "',");//来源销售主表ID
                            cmdText2.Append("'" + modOrder.C_NO + "',");//订单号
                            cmdText2.Append("'" + modOrder.C_CON_NO + "',");//合同号
                            cmdText2.Append("'" + modOrder.C_INVBASDOCID + "',");//存货档案主键
                            cmdText2.Append("'" + modOrder.C_INVENTORYID + "',");//存货管理档案主键
                            cmdText2.Append("'" + modOrder.C_UNITID + "',");//主计量单位
                            cmdText2.Append("'" + modOrder.C_PACKUNITID + "',");//辅单位
                            cmdText2.Append("" + modOrder.N_WGT + ",");//数量
                            cmdText2.Append("to_date('" + modOrder.D_DELIVERY_DT + "','yyyy-mm-dd hh24:mi:ss'),");//发货日期
                            cmdText2.Append("to_date('" + modOrder.D_DELIVERY_DT + "','yyyy-mm-dd hh24:mi:ss'),");//交货日期
                            cmdText2.Append("'" + modOrder.C_CURRENCYTYPEID + "',");//货币
                            cmdText2.Append("" + modOrder.N_TAXRATE + ",");//税率
                            cmdText2.Append("" + modOrder.N_ORIGINALCURPRICE + ",");//原币无税单价
                            cmdText2.Append("" + modOrder.N_ORIGINALCURTAXPRICE + ",");//原币含税单价
                            cmdText2.Append("" + modOrder.N_ORIGINALCURTAXMNY + ",");//原币税额
                            cmdText2.Append("" + modOrder.N_ORIGINALCURMNY + ",");//原币无税金额
                            cmdText2.Append("" + modOrder.N_ORIGINALCURSUMMNY + ",");//原币价税合计
                            cmdText2.Append("'" + modCon.C_CRECEIPTAREAID + "',");//收货地区
                            cmdText2.Append("'" + modCon.C_ADDRESS + "',");//收货地址
                            cmdText2.Append("'" + modCon.C_CRECEIPTCORPID + "',");//收货单位
                            cmdText2.Append("'" + modOrder.C_FREE_TERM + "',");//自由项1
                            cmdText2.Append("'" + modOrder.C_FREE_TERM2 + "',");//自由项2
                            cmdText2.Append("'" + modOrder.C_PACK + "',");//包装要求
                            cmdText2.Append("'" + modOrder.C_VDEF1 + "'");//质量等级
                            cmdText2.Append(")");

                            strSql.Add(cmdText2.ToString());
                            #endregion

                            #region //日计划
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
                            cmdText3.Append("'" + pk_itemid + "',");//来源销售订单子表ID
                            cmdText3.Append("'" + pk_mainid + "',");//来源销售订单主表ID
                            cmdText3.Append("'" + modOrder.C_CON_NO + "',");//合同号
                            cmdText3.Append("'" + modOrder.C_NO + "',");//订单号
                            cmdText3.Append("'" + modOrder.C_INVENTORYID + "',");//存货主键
                            cmdText3.Append("'" + modOrder.C_PACKUNITID + "',");//辅计量单位ID
                            cmdText3.Append("" + modOrder.N_FNUM + ",");//辅数量
                            cmdText3.Append("" + modOrder.N_WGT + ",");//主数量
                            cmdText3.Append("" + modOrder.N_ORIGINALCURTAXPRICE + ",");//单价
                            cmdText3.Append("" + modOrder.N_ORIGINALCURSUMMNY + ","); //订单金额
                            cmdText3.Append("to_date('" + modOrder.D_DT + "','yyyy-mm-dd hh24:mi:ss'),");//日计划日期
                            cmdText3.Append("to_date('" + modOrder.D_DELIVERY_DT + "','yyyy-mm-dd hh24:mi:ss'),");//定单要求发货日期
                            cmdText3.Append("to_date('" + modOrder.D_DELIVERY_DT + "','yyyy-mm-dd hh24:mi:ss'),");//定单要求到货日期
                            cmdText3.Append("to_date('" + modOrder.D_DELIVERY_DT + "','yyyy-mm-dd hh24:mi:ss'),");//实际发货日期
                            cmdText3.Append("'" + modOrder.C_RECEIPTCORPID + "',");//客户ID
                            cmdText3.Append("'" + modCon.C_TRANSMODEID + "',");//发运方式ID
                            cmdText3.Append("'" + modCon.C_SALECORPID + "',");//销售组织ID
                            cmdText3.Append("'" + modCon.C_EMPLOYEEID + "',");//业务员ID
                            cmdText3.Append("'" + modCon.C_DEPTID + "',");//业务部门ID
                            cmdText3.Append("'" + modCon.C_COPERATORID + "',"); //计划人ID
                            cmdText3.Append("'" + modCon.C_APPROVEID + "',");//审批人ID
                            cmdText3.Append("to_date('" + modCon.D_APPROVEDATE + "','yyyy-mm-dd hh24:mi:ss'),"); //审批日期
                            cmdText3.Append("'" + modCon.C_CRECEIPTAREAID + "',");//到货地区ID
                            cmdText3.Append("'" + modCon.C_ADDRESS + "',");//到货地址
                            cmdText3.Append("'" + modCon.C_CRECEIPTCUSTOMERID + "',");//收货单位ID
                            cmdText3.Append("'" + modCon.C_BIZTYPE + "',");//业务类型ID
                            cmdText3.Append("'" + modOrder.C_UNITID + "',");//计量单位ID
                            cmdText3.Append("'" + modOrder.C_FREE_TERM + "',");//自由项1
                            cmdText3.Append("'" + modOrder.C_FREE_TERM2 + "',");//自由项2
                            cmdText3.Append("'" + modOrder.C_PACK + "',");//包装要求
                            cmdText3.Append("'" + modOrder.C_VDEF1 + "',");//质量等级
                            cmdText3.Append("'"+code+"'");//销售单据号
                            cmdText3.Append(")");
                            strSql.Add(cmdText3);
                            #endregion

                        }
                    }

                }
                DbHelperOra.ExecuteSqlTran(strSql);
            }
            return dt;

        }
        #endregion

        #endregion  BasicMethod

    }
}

