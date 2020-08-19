using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using NF.DAL;

namespace NF.DAL
{
    /// <summary>
	/// 数据访问类:TRC_ROLL_QTCKD
	/// </summary>
	public partial class Dal_TRC_ROLL_QTCKD
    {
        public Dal_TRC_ROLL_QTCKD()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TRC_ROLL_QTCKD");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TRC_ROLL_QTCKD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TRC_ROLL_QTCKD(");
            strSql.Append("C_QTCKD_NO,C_LIC_PLA_NO,C_ADDRESS,C_CREATE_ID,D_CREATE_DT,C_CHANGE_ID,D_CHANGE_DT,N_STATUS,C_TYPE,C_NCDJ,C_CYS,C_SHDW,D_FYSJ,C_MBWH_ID,C_MBWH_NAME)");
            strSql.Append(" values (");
            strSql.Append(":C_QTCKD_NO,:C_LIC_PLA_NO,:C_ADDRESS,:C_CREATE_ID,:D_CREATE_DT,:C_CHANGE_ID,:D_CHANGE_DT,:N_STATUS,:C_TYPE,:C_NCDJ,:C_CYS,:C_SHDW,:D_FYSJ,:C_MBWH_ID,:C_MBWH_NAME)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_QTCKD_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LIC_PLA_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ADDRESS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CREATE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_CREATE_DT", OracleDbType.Date),
                    new OracleParameter(":C_CHANGE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_CHANGE_DT", OracleDbType.Date),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":C_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NCDJ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CYS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SHDW", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_FYSJ", OracleDbType.Date),
                    new OracleParameter(":C_MBWH_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MBWH_NAME", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_QTCKD_NO;
            parameters[1].Value =  model.C_LIC_PLA_NO;
            parameters[2].Value =  model.C_ADDRESS;
            parameters[3].Value =  model.C_CREATE_ID;
            parameters[4].Value =  model.D_CREATE_DT;
            parameters[5].Value =  model.C_CHANGE_ID;
            parameters[6].Value =  model.D_CHANGE_DT;
            parameters[7].Value =  model.N_STATUS;
            parameters[8].Value =  model.C_TYPE;
            parameters[9].Value =   model.C_NCDJ;
            parameters[10].Value =  model.C_CYS;
            parameters[11].Value =  model.C_SHDW;
            parameters[12].Value =  model.D_FYSJ;
            parameters[13].Value =  model.C_MBWH_ID;
            parameters[14].Value =  model.C_MBWH_NAME;

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
        public bool Update(Mod_TRC_ROLL_QTCKD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TRC_ROLL_QTCKD set ");
            strSql.Append("C_QTCKD_NO=:C_QTCKD_NO,");
            strSql.Append("C_LIC_PLA_NO=:C_LIC_PLA_NO,");
            strSql.Append("C_ADDRESS=:C_ADDRESS,");
            strSql.Append("C_CREATE_ID=:C_CREATE_ID,");
            strSql.Append("D_CREATE_DT=:D_CREATE_DT,");
            strSql.Append("C_CHANGE_ID=:C_CHANGE_ID,");
            strSql.Append("D_CHANGE_DT=:D_CHANGE_DT,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_TYPE=:C_TYPE,");
            strSql.Append("C_NCDJ=:C_NCDJ,");
            strSql.Append("C_CYS=:C_CYS,");
            strSql.Append("C_SHDW=:C_SHDW,");
            strSql.Append("D_FYSJ=:D_FYSJ,");
            strSql.Append("C_MBWH_ID=:C_MBWH_ID,");
            strSql.Append("C_MBWH_NAME=:C_MBWH_NAME");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_QTCKD_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LIC_PLA_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ADDRESS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CREATE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_CREATE_DT", OracleDbType.Date),
                    new OracleParameter(":C_CHANGE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_CHANGE_DT", OracleDbType.Date),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":C_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NCDJ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CYS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SHDW", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_FYSJ", OracleDbType.Date),
                    new OracleParameter(":C_MBWH_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MBWH_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_QTCKD_NO;
            parameters[1].Value = model.C_LIC_PLA_NO;
            parameters[2].Value = model.C_ADDRESS;
            parameters[3].Value = model.C_CREATE_ID;
            parameters[4].Value = model.D_CREATE_DT;
            parameters[5].Value = model.C_CHANGE_ID;
            parameters[6].Value = model.D_CHANGE_DT;
            parameters[7].Value = model.N_STATUS;
            parameters[8].Value = model.C_TYPE;
            parameters[9].Value = model.C_NCDJ;
            parameters[10].Value = model.C_CYS;
            parameters[11].Value = model.C_SHDW;
            parameters[12].Value = model.D_FYSJ;
            parameters[13].Value = model.C_MBWH_ID;
            parameters[14].Value = model.C_MBWH_NAME;
            parameters[15].Value = model.C_ID;

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
            strSql.Append("delete from TRC_ROLL_QTCKD ");
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
            strSql.Append("delete from TRC_ROLL_QTCKD ");
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
        public Mod_TRC_ROLL_QTCKD GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_QTCKD_NO,C_LIC_PLA_NO,C_ADDRESS,C_CREATE_ID,D_CREATE_DT,C_CHANGE_ID,D_CHANGE_DT,N_STATUS,C_TYPE,C_NCDJ,C_CYS,C_SHDW,D_FYSJ,C_MBWH_ID,C_MBWH_NAME from TRC_ROLL_QTCKD ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            Mod_TRC_ROLL_QTCKD model = new Mod_TRC_ROLL_QTCKD();
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
        public Mod_TRC_ROLL_QTCKD DataRowToModel(DataRow row)
        {
            Mod_TRC_ROLL_QTCKD model = new Mod_TRC_ROLL_QTCKD();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_QTCKD_NO"] != null)
                {
                    model.C_QTCKD_NO = row["C_QTCKD_NO"].ToString();
                }
                if (row["C_LIC_PLA_NO"] != null)
                {
                    model.C_LIC_PLA_NO = row["C_LIC_PLA_NO"].ToString();
                }
                if (row["C_ADDRESS"] != null)
                {
                    model.C_ADDRESS = row["C_ADDRESS"].ToString();
                }
                if (row["C_CREATE_ID"] != null)
                {
                    model.C_CREATE_ID = row["C_CREATE_ID"].ToString();
                }
                if (row["D_CREATE_DT"] != null && row["D_CREATE_DT"].ToString() != "")
                {
                    model.D_CREATE_DT = DateTime.Parse(row["D_CREATE_DT"].ToString());
                }
                if (row["C_CHANGE_ID"] != null)
                {
                    model.C_CHANGE_ID = row["C_CHANGE_ID"].ToString();
                }
                if (row["D_CHANGE_DT"] != null && row["D_CHANGE_DT"].ToString() != "")
                {
                    model.D_CHANGE_DT = DateTime.Parse(row["D_CHANGE_DT"].ToString());
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["C_TYPE"] != null)
                {
                    model.C_TYPE = row["C_TYPE"].ToString();
                }
                if (row["C_NCDJ"] != null)
                {
                    model.C_NCDJ = row["C_NCDJ"].ToString();
                }
                if (row["C_CYS"] != null)
                {
                    model.C_CYS = row["C_CYS"].ToString();
                }
                if (row["C_SHDW"] != null)
                {
                    model.C_SHDW = row["C_SHDW"].ToString();
                }
                if (row["D_FYSJ"] != null && row["D_FYSJ"].ToString() != "")
                {
                    model.D_FYSJ = DateTime.Parse(row["D_FYSJ"].ToString());
                }
                if (row["C_MBWH_ID"] != null)
                {
                    model.C_MBWH_ID = row["C_MBWH_ID"].ToString();
                }
                if (row["C_MBWH_NAME"] != null)
                {
                    model.C_MBWH_NAME = row["C_MBWH_NAME"].ToString();
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
            strSql.Append("select C_ID,C_QTCKD_NO,C_LIC_PLA_NO,C_ADDRESS,C_CREATE_ID,D_CREATE_DT,C_CHANGE_ID,D_CHANGE_DT,N_STATUS,C_TYPE,C_NCDJ,C_CYS,C_SHDW,D_FYSJ,C_MBWH_ID,C_MBWH_NAME ");
            strSql.Append(" FROM TRC_ROLL_QTCKD ");
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
            strSql.Append("select count(1) FROM TRC_ROLL_QTCKD ");
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
            strSql.Append(")AS Row, T.*  from TRC_ROLL_QTCKD T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OracleParameter[] parameters = {
					new OracleParameter(":tblName", OracleDbType.Varchar2, 255),
					new OracleParameter(":fldName", OracleDbType.Varchar2, 255),
					new OracleParameter(":PageSize", OracleDbType.Int16),
					new OracleParameter(":PageIndex", OracleDbType.Int16),
					new OracleParameter(":IsReCount", OracleType.Clob),
					new OracleParameter(":OrderType", OracleType.Clob),
					new OracleParameter(":strWhere", OracleDbType.Varchar2,1000),
					};
			parameters[0].Value = "TRC_ROLL_QTCKD";
			parameters[1].Value = "C_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 根据其他出库单单号获取model
        /// </summary>
        /// <param name="C_QTCKD_NO">出库单单号</param>
        /// <returns></returns>
        public Mod_TRC_ROLL_QTCKD GetModelByQTCKD(string C_QTCKD_NO)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_QTCKD_NO,C_LIC_PLA_NO,C_ADDRESS,C_CREATE_ID,D_CREATE_DT,C_CHANGE_ID,D_CHANGE_DT,N_STATUS,C_TYPE,C_NCDJ,C_CYS,C_SHDW,D_FYSJ,C_MBWH_ID,C_MBWH_NAME from TRC_ROLL_QTCKD ");
            strSql.Append(" where C_QTCKD_NO=:C_QTCKD_NO ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_QTCKD_NO", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_QTCKD_NO;

            Mod_TRC_ROLL_QTCKD model = new Mod_TRC_ROLL_QTCKD();
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
        #endregion  ExtensionMethod
    }
}
