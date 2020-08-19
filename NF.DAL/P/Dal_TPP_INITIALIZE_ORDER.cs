using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TPP_INITIALIZE_ORDER
    /// </summary>
    public partial class Dal_TPP_INITIALIZE_ORDER
    {
        public Dal_TPP_INITIALIZE_ORDER()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TPP_INITIALIZE_ORDER");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TPP_INITIALIZE_ORDER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TPP_INITIALIZE_ORDER(");
            strSql.Append("C_INITIALIZE_ID,C_ORDER_ID,N_WGT,N_MACH_WGT,C_DESIGN_NO,N_STATUS,N_FLAG,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_RH,C_LF,C_KP,N_HL_TIME,C_HL,N_DFP_HL_TIME,C_DFP_HL,C_XM,C_ROLL_STA_ID,C_CCM_STA_ID,N_MACH_WGT_CCM,N_LGPC_STATUS,N_EXEC_STATUS,N_ROLL_PROD_WGT,N_SMS_PROD_WGT)");
            strSql.Append(" values (");
            strSql.Append(":C_INITIALIZE_ID,:C_ORDER_ID,:N_WGT,:N_MACH_WGT,:C_DESIGN_NO,:N_STATUS,:N_FLAG,:C_REMARK,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT,:C_RH,:C_LF,:C_KP,:N_HL_TIME,:C_HL,:N_DFP_HL_TIME,:C_DFP_HL,:C_XM,:C_ROLL_STA_ID,:C_CCM_STA_ID,:N_MACH_WGT_CCM,:N_LGPC_STATUS,:N_EXEC_STATUS,:N_ROLL_PROD_WGT,:N_SMS_PROD_WGT)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_INITIALIZE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORDER_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_WGT", OracleDbType.Int16,15),
                    new OracleParameter(":N_MACH_WGT", OracleDbType.Int16,15),
                    new OracleParameter(":C_DESIGN_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,2),
                    new OracleParameter(":N_FLAG", OracleDbType.Int16,2),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_RH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LF", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_KP", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_HL_TIME", OracleDbType.Int16,10),
                    new OracleParameter(":C_HL", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_DFP_HL_TIME", OracleDbType.Int16,10),
                    new OracleParameter(":C_DFP_HL", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_XM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ROLL_STA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CCM_STA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_MACH_WGT_CCM", OracleDbType.Int16,15),
                    new OracleParameter(":N_LGPC_STATUS", OracleDbType.Int16,2),
                    new OracleParameter(":N_EXEC_STATUS", OracleDbType.Int16,2),
                    new OracleParameter(":N_ROLL_PROD_WGT", OracleDbType.Int16,15),
                    new OracleParameter(":N_SMS_PROD_WGT", OracleDbType.Int16,15)};
            parameters[0].Value = model.C_INITIALIZE_ID;
            parameters[1].Value = model.C_ORDER_ID;
            parameters[2].Value = model.N_WGT;
            parameters[3].Value = model.N_MACH_WGT;
            parameters[4].Value = model.C_DESIGN_NO;
            parameters[5].Value = model.N_STATUS;
            parameters[6].Value = model.N_FLAG;
            parameters[7].Value = model.C_REMARK;
            parameters[8].Value = model.C_EMP_ID;
            parameters[9].Value = model.C_EMP_NAME;
            parameters[10].Value = model.D_MOD_DT;
            parameters[11].Value = model.C_RH;
            parameters[12].Value = model.C_LF;
            parameters[13].Value = model.C_KP;
            parameters[14].Value = model.N_HL_TIME;
            parameters[15].Value = model.C_HL;
            parameters[16].Value = model.N_DFP_HL_TIME;
            parameters[17].Value = model.C_DFP_HL;
            parameters[18].Value = model.C_XM;
            parameters[19].Value = model.C_ROLL_STA_ID;
            parameters[20].Value = model.C_CCM_STA_ID;
            parameters[21].Value = model.N_MACH_WGT_CCM;
            parameters[22].Value = model.N_LGPC_STATUS;
            parameters[23].Value = model.N_EXEC_STATUS;
            parameters[24].Value = model.N_ROLL_PROD_WGT;
            parameters[25].Value = model.N_SMS_PROD_WGT;

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
        public bool Update(Mod_TPP_INITIALIZE_ORDER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TPP_INITIALIZE_ORDER set ");
            strSql.Append("C_INITIALIZE_ID=:C_INITIALIZE_ID,");
            strSql.Append("C_ORDER_ID=:C_ORDER_ID,");
            strSql.Append("N_WGT=:N_WGT,");
            strSql.Append("N_MACH_WGT=:N_MACH_WGT,");
            strSql.Append("C_DESIGN_NO=:C_DESIGN_NO,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("N_FLAG=:N_FLAG,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("C_RH=:C_RH,");
            strSql.Append("C_LF=:C_LF,");
            strSql.Append("C_KP=:C_KP,");
            strSql.Append("N_HL_TIME=:N_HL_TIME,");
            strSql.Append("C_HL=:C_HL,");
            strSql.Append("N_DFP_HL_TIME=:N_DFP_HL_TIME,");
            strSql.Append("C_DFP_HL=:C_DFP_HL,");
            strSql.Append("C_XM=:C_XM,");
            strSql.Append("C_ROLL_STA_ID=:C_ROLL_STA_ID,");
            strSql.Append("C_CCM_STA_ID=:C_CCM_STA_ID,");
            strSql.Append("N_MACH_WGT_CCM=:N_MACH_WGT_CCM,");
            strSql.Append("N_LGPC_STATUS=:N_LGPC_STATUS,");
            strSql.Append("N_EXEC_STATUS=:N_EXEC_STATUS,");
            strSql.Append("N_ROLL_PROD_WGT=:N_ROLL_PROD_WGT,");
            strSql.Append("N_SMS_PROD_WGT=:N_SMS_PROD_WGT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_INITIALIZE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORDER_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_WGT", OracleDbType.Int16,15),
                    new OracleParameter(":N_MACH_WGT", OracleDbType.Int16,15),
                    new OracleParameter(":C_DESIGN_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,2),
                    new OracleParameter(":N_FLAG", OracleDbType.Int16,2),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_RH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LF", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_KP", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_HL_TIME", OracleDbType.Int16,10),
                    new OracleParameter(":C_HL", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_DFP_HL_TIME", OracleDbType.Int16,10),
                    new OracleParameter(":C_DFP_HL", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_XM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ROLL_STA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CCM_STA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_MACH_WGT_CCM", OracleDbType.Int16,15),
                    new OracleParameter(":N_LGPC_STATUS", OracleDbType.Int16,2),
                    new OracleParameter(":N_EXEC_STATUS", OracleDbType.Int16,2),
                    new OracleParameter(":N_ROLL_PROD_WGT", OracleDbType.Int16,15),
                    new OracleParameter(":N_SMS_PROD_WGT", OracleDbType.Int16,15),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_INITIALIZE_ID;
            parameters[1].Value = model.C_ORDER_ID;
            parameters[2].Value = model.N_WGT;
            parameters[3].Value = model.N_MACH_WGT;
            parameters[4].Value = model.C_DESIGN_NO;
            parameters[5].Value = model.N_STATUS;
            parameters[6].Value = model.N_FLAG;
            parameters[7].Value = model.C_REMARK;
            parameters[8].Value = model.C_EMP_ID;
            parameters[9].Value = model.C_EMP_NAME;
            parameters[10].Value = model.D_MOD_DT;
            parameters[11].Value = model.C_RH;
            parameters[12].Value = model.C_LF;
            parameters[13].Value = model.C_KP;
            parameters[14].Value = model.N_HL_TIME;
            parameters[15].Value = model.C_HL;
            parameters[16].Value = model.N_DFP_HL_TIME;
            parameters[17].Value = model.C_DFP_HL;
            parameters[18].Value = model.C_XM;
            parameters[19].Value = model.C_ROLL_STA_ID;
            parameters[20].Value = model.C_CCM_STA_ID;
            parameters[21].Value = model.N_MACH_WGT_CCM;
            parameters[22].Value = model.N_LGPC_STATUS;
            parameters[23].Value = model.N_EXEC_STATUS;
            parameters[24].Value = model.N_ROLL_PROD_WGT;
            parameters[25].Value = model.N_SMS_PROD_WGT;
            parameters[26].Value = model.C_ID;

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
            strSql.Append("delete from TPP_INITIALIZE_ORDER ");
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
            strSql.Append("delete from TPP_INITIALIZE_ORDER ");
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
        public Mod_TPP_INITIALIZE_ORDER GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_INITIALIZE_ID,C_ORDER_ID,N_WGT,N_MACH_WGT,C_DESIGN_NO,N_STATUS,N_FLAG,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_RH,C_LF,C_KP,N_HL_TIME,C_HL,N_DFP_HL_TIME,C_DFP_HL,C_XM,C_ROLL_STA_ID,C_CCM_STA_ID,N_MACH_WGT_CCM,N_LGPC_STATUS,N_EXEC_STATUS,N_ROLL_PROD_WGT,N_SMS_PROD_WGT from TPP_INITIALIZE_ORDER ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TPP_INITIALIZE_ORDER model = new Mod_TPP_INITIALIZE_ORDER();
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
        public Mod_TPP_INITIALIZE_ORDER DataRowToModel(DataRow row)
        {
            Mod_TPP_INITIALIZE_ORDER model = new Mod_TPP_INITIALIZE_ORDER();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_INITIALIZE_ID"] != null)
                {
                    model.C_INITIALIZE_ID = row["C_INITIALIZE_ID"].ToString();
                }
                if (row["C_ORDER_ID"] != null)
                {
                    model.C_ORDER_ID = row["C_ORDER_ID"].ToString();
                }
                if (row["N_WGT"] != null && row["N_WGT"].ToString() != "")
                {
                    model.N_WGT = decimal.Parse(row["N_WGT"].ToString());
                }
                if (row["N_MACH_WGT"] != null && row["N_MACH_WGT"].ToString() != "")
                {
                    model.N_MACH_WGT = decimal.Parse(row["N_MACH_WGT"].ToString());
                }
                if (row["C_DESIGN_NO"] != null)
                {
                    model.C_DESIGN_NO = row["C_DESIGN_NO"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["N_FLAG"] != null && row["N_FLAG"].ToString() != "")
                {
                    model.N_FLAG = decimal.Parse(row["N_FLAG"].ToString());
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
                if (row["C_ROLL_STA_ID"] != null)
                {
                    model.C_ROLL_STA_ID = row["C_ROLL_STA_ID"].ToString();
                }
                if (row["C_CCM_STA_ID"] != null)
                {
                    model.C_CCM_STA_ID = row["C_CCM_STA_ID"].ToString();
                }
                if (row["N_MACH_WGT_CCM"] != null && row["N_MACH_WGT_CCM"].ToString() != "")
                {
                    model.N_MACH_WGT_CCM = decimal.Parse(row["N_MACH_WGT_CCM"].ToString());
                }
                if (row["N_LGPC_STATUS"] != null && row["N_LGPC_STATUS"].ToString() != "")
                {
                    model.N_LGPC_STATUS = decimal.Parse(row["N_LGPC_STATUS"].ToString());
                }
                if (row["N_EXEC_STATUS"] != null && row["N_EXEC_STATUS"].ToString() != "")
                {
                    model.N_EXEC_STATUS = decimal.Parse(row["N_EXEC_STATUS"].ToString());
                }
                if (row["N_ROLL_PROD_WGT"] != null && row["N_ROLL_PROD_WGT"].ToString() != "")
                {
                    model.N_ROLL_PROD_WGT = decimal.Parse(row["N_ROLL_PROD_WGT"].ToString());
                }
                if (row["N_SMS_PROD_WGT"] != null && row["N_SMS_PROD_WGT"].ToString() != "")
                {
                    model.N_SMS_PROD_WGT = decimal.Parse(row["N_SMS_PROD_WGT"].ToString());
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
            strSql.Append("select C_ID,C_INITIALIZE_ID,C_ORDER_ID,N_WGT,N_MACH_WGT,C_DESIGN_NO,N_STATUS,N_FLAG,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_RH,C_LF,C_KP,N_HL_TIME,C_HL,N_DFP_HL_TIME,C_DFP_HL,C_XM,C_ROLL_STA_ID,C_CCM_STA_ID,N_MACH_WGT_CCM,N_LGPC_STATUS,N_EXEC_STATUS,N_ROLL_PROD_WGT,N_SMS_PROD_WGT ");
            strSql.Append(" FROM TPP_INITIALIZE_ORDER ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取订单是否已排产 0未排产,1已排产
        /// </summary>
        /// <param name="C_ORDER_ID">订单号</param>
        /// <returns></returns>
        public int GetOrder(string C_ORDER_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_INITIALIZE_ID,C_ORDER_ID,N_WGT,N_MACH_WGT,C_DESIGN_NO,N_STATUS,N_FLAG,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_RH,C_LF,C_KP,N_HL_TIME,C_HL,N_DFP_HL_TIME,C_DFP_HL,C_XM,C_ROLL_STA_ID,C_CCM_STA_ID,N_MACH_WGT_CCM,N_LGPC_STATUS,N_EXEC_STATUS,N_ROLL_PROD_WGT,N_SMS_PROD_WGT ");
            strSql.Append(" FROM TPP_INITIALIZE_ORDER where C_ORDER_ID='" + C_ORDER_ID + "' ");

            DataSet ds = DbHelperOra.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TPP_INITIALIZE_ORDER ");
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
            strSql.Append(")AS Row, T.*  from TPP_INITIALIZE_ORDER T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }



        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 得到已初始化订单信息
        /// </summary>
        /// <param name="strIniID">方案主键</param>
        /// <param name="strGZ">钢种</param>
        /// <param name="strBZ">标准</param>
        /// <param name="strRollID">轧线</param>
        /// <param name="strCCMID">连铸</param>
        /// <param name="rolltype">轧钢是否排产</param>
        /// <param name="ccmtype">炼钢是否排产</param>
        /// <returns></returns>
        public DataTable GetIniOrderByIniID(string strIniID, string strGZ, string strBZ, string strRollID, string strCCMID, int? rolltype, int? ccmtype)
        {
            string sql = "SELECT a.c_id,A.C_INITIALIZE_ID, A.C_ORDER_ID, A.N_WGT, A.C_ROLL_STA_ID, ( SELECT M.C_STA_DESC FROM TB_STA M WHERE M.C_ID= A.C_ROLL_STA_ID) C_ROLL_DESC, A.N_MACH_WGT, A.C_CCM_STA_ID,A.N_ROLL_PROD_WGT,A.N_SMS_PROD_WGT, ( SELECT M.C_STA_DESC FROM TB_STA M WHERE M.C_ID= A.C_CCM_STA_ID) C_CCM_DESC, A.N_MACH_WGT_CCM, A.C_ID, T.C_ORDER_NO, T.C_CON_NO, T.C_CON_NAME, T.C_AREA, T.C_MAT_CODE, T.C_MAT_NAME, T.C_TECH_PROT, T.C_SPEC, T.C_STL_GRD, T.C_STD_CODE, T.C_FREE_TERM, T.C_FREE_TERM2, T.C_PRO_USE, T.D_NEED_DT, T.D_DELIVERY_DT, T.C_PACK, T.C_LEV FROM TPP_INITIALIZE_ORDER A, TMO_CON_ORDER T WHERE A.C_ORDER_ID = T.C_ID AND A.C_INITIALIZE_ID='" + strIniID + "'";
            if (rolltype != null)
            {
                sql = sql + "  AND A.N_EXEC_STATUS=" + rolltype + " ";
            }

            if (ccmtype != null)
            {
                sql = sql + "  AND A.N_LGPC_STATUS=" + ccmtype + " ";
            }
            if (strGZ.Trim().Length > 0)
            {
                sql = sql + "  AND UPPER( T.C_STL_GRD)  LIKE UPPER( '" + strGZ + "') ";

            }

            if (strBZ.Trim().Length > 0)
            {
                sql = sql + "  AND UPPER( T.C_STD_CODE)  LIKE UPPER( '" + strBZ + "') ";

            }
            if (strRollID.Trim().Length > 0)
            {
                sql = sql + "  AND A.C_ROLL_STA_ID = '" + strRollID + "' ";

            }

            if (strCCMID.Trim().Length > 0)
            {
                sql = sql + "  AND A.C_CCM_STA_ID = '" + strCCMID + "' ";

            }
            sql = sql + "  ORDER BY  C_STL_GRD, C_STD_CODE ";

            return DbHelperOra.Query(sql).Tables[0];

        }

        /// <summary>
        /// 获取方案和钢坯库统计结果
        /// </summary>
        /// <param name="strIniID">方案主键</param>
        /// <param name="strGZ">钢种</param>
        /// <param name="strBZ">标准</param>
        /// <returns></returns>
        public DataTable GetOrderAndKCP(string strIniID, string strGZ, string strBZ)
        {
            string sql = @"SELECT M.C_STL_GRD, M.C_STD_CODE, M.N_WGT, N.N_KC_WGT
                         FROM(SELECT SUM(X.N_WGT) N_WGT, X.C_STL_GRD, X.C_STD_CODE
                               FROM(SELECT A.N_WGT, T.C_STL_GRD, T.C_STD_CODE
                                   FROM TPP_INITIALIZE_ORDER A, TMO_CON_ORDER T
                                   WHERE A.C_ORDER_ID = T.C_ID ";
            if (strGZ.Trim() != "")
            {
                sql = sql + " AND  T.C_STL_GRD LIKE '%" + strGZ + "%' ";
            }
            if (strBZ.Trim() != "")
            {
                sql = sql + " AND  T.C_STD_CODE LIKE '%" + strBZ + "%' ";
            }
            sql = sql + "    AND A.C_INITIALIZE_ID = '" + strIniID + "') X";
            sql = sql + "     GROUP BY X.C_STL_GRD, X.C_STD_CODE) M";
            sql = sql + "    LEFT JOIN(SELECT A.C_STL_GRD, A.C_STD_CODE, SUM(A.N_WGT) N_KC_WGT";
            sql = sql + "     FROM TSC_SLAB_MAIN A";
            sql = sql + "     WHERE A.C_CUS_NAME = '邢台钢铁有限责任公司'";
            sql = sql + "     GROUP BY A.C_STL_GRD, A.C_STD_CODE) N";
            sql = sql + "    ON M.C_STL_GRD = N.C_STL_GRD";
            sql = sql + "     AND M.C_STD_CODE = N.C_STD_CODE";


            sql = sql + "   ORDER BY  M.C_STL_GRD, M.C_STD_CODE ";
            return DbHelperOra.Query(sql).Tables[0];
        }

        /// <summary>
        /// 按类统计已初始化订单信息
        /// </summary>
        /// <param name="strIniID">方案主键</param>
        /// <param name="strGZ">钢种</param>
        /// <param name="strBZ">标准</param>
        /// <param name="strRollID">轧线</param>
        /// <param name="strCCMID">连铸</param>
        /// <param name="rolltype">轧钢是否排产</param>
        /// <param name="ccmtype">炼钢是否排产</param>
        /// <param name="strTJ">统计类别:1轧钢2连铸，3钢种,4产线规格</param>
        /// <returns></returns>
        public DataTable GetOrderIniTJ(string strIniID, string strGZ, string strBZ, string strRollID, string strCCMID, int? rolltype, int? ccmtype, string strTJ)
        {
            string sql = "";
            string sql2 = " ";

            if (strTJ == "1")
            {
                sql = sql + "  SELECT SUM(X.N_WGT) N_WGT ,X.C_ROLL_DESC  FROM  ";
                sql2 = sql2 + "  GROUP BY  X.C_ROLL_DESC ORDER BY  X.C_ROLL_DESC  ";
            }
            if (strTJ == "2")
            {
                sql = sql + "  SELECT SUM(X.N_WGT) N_WGT ,X.C_CCM_DESC  FROM   ";
                sql2 = sql2 + "   GROUP BY  X.C_CCM_DESC ORDER BY X.C_CCM_DESC ";
            }
            if (strTJ == "3")
            {
                sql = sql + "  SELECT SUM(X.N_WGT) N_WGT ,X.C_STL_GRD,X.C_STD_CODE  FROM   ";
                sql2 = sql2 + "   GROUP BY   X.C_STL_GRD,X.C_STD_CODE ORDER BY X.C_STL_GRD  ";
            }

            if (strTJ == "4")
            {
                sql = sql + "  SELECT SUM(X.N_WGT) N_WGT, X.C_ROLL_DESC,X.C_SPEC  FROM ";
                sql2 = sql2 + "   GROUP BY X.C_ROLL_DESC,X.C_SPEC ORDER BY X.C_ROLL_DESC,X.C_SPEC  ";
            }

            sql = sql + "(SELECT a.c_id,A.C_INITIALIZE_ID, A.C_ORDER_ID, A.N_WGT, A.C_ROLL_STA_ID, ( SELECT M.C_STA_DESC FROM TB_STA M WHERE M.C_ID= A.C_ROLL_STA_ID) C_ROLL_DESC, A.N_MACH_WGT, A.C_CCM_STA_ID, ( SELECT M.C_STA_DESC FROM TB_STA M WHERE M.C_ID= A.C_CCM_STA_ID) C_CCM_DESC, A.N_MACH_WGT_CCM, A.C_ID, T.C_ORDER_NO, T.C_CON_NO, T.C_CON_NAME, T.C_AREA, T.C_MAT_CODE, T.C_MAT_NAME, T.C_TECH_PROT, T.C_SPEC, T.C_STL_GRD, T.C_STD_CODE, T.C_FREE_TERM, T.C_FREE_TERM2, T.C_PRO_USE, T.D_NEED_DT, T.D_DELIVERY_DT, T.C_PACK, T.C_LEV FROM TPP_INITIALIZE_ORDER A, TMO_CON_ORDER T WHERE A.C_ORDER_ID = T.C_ID AND A.C_INITIALIZE_ID='" + strIniID + "'";
            if (rolltype != null)
            {
                sql = sql + "  AND A.N_EXEC_STATUS=" + rolltype + " ";
            }

            if (ccmtype != null)
            {
                sql = sql + "  AND A.N_LGPC_STATUS=" + ccmtype + " ";
            }
            if (strGZ.Trim().Length > 0)
            {
                sql = sql + "  AND UPPER( T.C_STL_GRD)  LIKE UPPER( '" + strGZ + "') ";

            }

            if (strBZ.Trim().Length > 0)
            {
                sql = sql + "  AND UPPER( T.C_STD_CODE)  LIKE UPPER( '" + strBZ + "') ";

            }
            if (strRollID.Trim().Length > 0)
            {
                sql = sql + "  AND A.C_ROLL_STA_ID = '" + strRollID + "' ";

            }

            if (strCCMID.Trim().Length > 0)
            {
                sql = sql + "  AND A.C_CCM_STA_ID = '" + strCCMID + "' ";

            }
            sql = sql + "  ) X  ";

            sql = sql + sql2;

            return DbHelperOra.Query(sql).Tables[0];

        }


        /// <summary>
        /// 得到已初始化订单信息
        /// </summary>
        /// <param name="strIniID">方案主键</param>
        /// <param name="strGZ">钢种</param>
        /// <param name="strBZ">标准</param>
        /// <param name="strRollID">轧线</param>
        /// <param name="strCCMID">连铸</param>
        /// <param name="rolltype">轧钢是否排产</param>
        /// <param name="ccmtype">炼钢是否排产</param>
        /// <returns></returns>
        public DataTable Get_Order_PC(string strIniID, string strGZ, string strBZ, string strRollID, string strCCMID, int? rolltype, int? ccmtype)
        {
            string sql = "SELECT a.c_id,A.C_INITIALIZE_ID, A.C_ORDER_ID, A.N_WGT, A.C_ROLL_STA_ID, ( SELECT M.C_STA_DESC FROM TB_STA M WHERE M.C_ID= A.C_ROLL_STA_ID) C_ROLL_DESC, A.N_MACH_WGT, A.C_CCM_STA_ID,A.N_ROLL_PROD_WGT,A.N_SMS_PROD_WGT, ( SELECT M.C_STA_DESC FROM TB_STA M WHERE M.C_ID= A.C_CCM_STA_ID) C_CCM_DESC, A.N_MACH_WGT_CCM, A.C_ID, T.C_ORDER_NO, T.C_CON_NO, T.C_CON_NAME, T.C_AREA, T.C_MAT_CODE, T.C_MAT_NAME, T.C_TECH_PROT, T.C_SPEC, T.C_STL_GRD, T.C_STD_CODE, T.C_FREE_TERM, T.C_FREE_TERM2, T.C_PRO_USE, T.D_NEED_DT, T.D_DELIVERY_DT, T.C_PACK, T.C_LEV FROM TPP_INITIALIZE_ORDER A, TMO_CON_ORDER T WHERE A.C_ORDER_ID = T.C_ID and A.C_CCM_STA_ID is not null AND A.C_INITIALIZE_ID='" + strIniID + "'";
            if (rolltype != null)
            {
                sql = sql + "  AND A.N_EXEC_STATUS=" + rolltype + " ";
            }

            if (ccmtype != null)
            {
                sql = sql + "  AND A.N_LGPC_STATUS=" + ccmtype + " ";
            }
            if (strGZ.Trim().Length > 0)
            {
                sql = sql + "  AND UPPER( T.C_STL_GRD)  LIKE UPPER( '" + strGZ + "') ";

            }

            if (strBZ.Trim().Length > 0)
            {
                sql = sql + "  AND UPPER( T.C_STD_CODE)  LIKE UPPER( '" + strBZ + "') ";

            }
            if (strRollID.Trim().Length > 0)
            {
                sql = sql + "  AND A.C_ROLL_STA_ID = '" + strRollID + "' ";

            }

            if (strCCMID.Trim().Length > 0)
            {
                sql = sql + "  AND A.C_CCM_STA_ID = '" + strCCMID + "' ";

            }
            sql = sql + "  ORDER BY  C_STL_GRD, C_STD_CODE ";

            return DbHelperOra.Query(sql).Tables[0];

        }

        #endregion  ExtensionMethod
    }
}

