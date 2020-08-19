using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Collections;
using NF.MODEL;
using NF.DLL;
using System.Linq;
using NF.MODEL.D;

namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMD_GPFY_LOG
    /// </summary>
    public partial class Dal_TMD_GPFY_LOG
    {
        public Dal_TMD_GPFY_LOG()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMD_GPFY_LOG");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMD_GPFY_LOG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMD_GPFY_LOG(");
            strSql.Append("C_FYDH,C_TYPE,C_EMP_ID,N_NUM,N_WGT,C_SEND_STOCK,C_BATCH_NO,C_STOVE,C_STL_GRD,C_STD_CODE,C_SPEC,C_ZLDJ,C_BZYQ,C_LIC_PLA_NO)");
            strSql.Append(" values (");
            strSql.Append(":C_FYDH,:C_TYPE,:C_EMP_ID,:N_NUM,:N_WGT,:C_SEND_STOCK,:C_BATCH_NO,:C_STOVE,:C_STL_GRD,:C_STD_CODE,:C_SPEC,:C_ZLDJ,:C_BZYQ,:C_LIC_PLA_NO)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_FYDH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_NUM", OracleDbType.Decimal,5),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_SEND_STOCK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STOVE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZLDJ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BZYQ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LIC_PLA_NO", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_FYDH;
            parameters[1].Value = model.C_TYPE;
            parameters[2].Value = model.C_EMP_ID;
            parameters[3].Value = model.N_NUM;
            parameters[4].Value =model.N_WGT; 
            parameters[5].Value =model.C_SEND_STOCK; 
            parameters[6].Value =model.C_BATCH_NO; 
            parameters[7].Value =model.C_STOVE; 
            parameters[8].Value = model.C_STL_GRD; 
            parameters[9].Value = model.C_STD_CODE; 
            parameters[10].Value = model.C_SPEC;
            parameters[11].Value=  model.C_ZLDJ;
            parameters[12].Value=  model.C_BZYQ;
            parameters[13].Value=  model.C_LIC_PLA_NO;

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
        public bool Update(Mod_TMD_GPFY_LOG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMD_GPFY_LOG set ");
            strSql.Append("C_FYDH=:C_FYDH,");
            strSql.Append("C_TYPE=:C_TYPE,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("N_NUM=:N_NUM,");
            strSql.Append("N_WGT=:N_WGT,");
            strSql.Append("C_SEND_STOCK=:C_SEND_STOCK,");
            strSql.Append("C_BATCH_NO=:C_BATCH_NO,");
            strSql.Append("C_STOVE=:C_STOVE,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_STD_CODE=:C_STD_CODE,");
            strSql.Append("C_SPEC=:C_SPEC,");
            strSql.Append("C_ZLDJ=:C_ZLDJ,");
            strSql.Append("C_BZYQ=:C_BZYQ,");
            strSql.Append("C_LIC_PLA_NO=:C_LIC_PLA_NO");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_FYDH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":N_NUM", OracleDbType.Decimal,5),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_SEND_STOCK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STOVE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZLDJ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BZYQ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LIC_PLA_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_FYDH;
            parameters[1].Value = model.C_TYPE;
            parameters[2].Value = model.C_EMP_ID;
            parameters[3].Value = model.D_MOD_DT;
            parameters[4].Value = model.N_NUM;
            parameters[5].Value = model.N_WGT;
            parameters[6].Value = model.C_SEND_STOCK;
            parameters[7].Value = model.C_BATCH_NO;
            parameters[8].Value = model.C_STOVE;
            parameters[9].Value = model.C_STL_GRD;
            parameters[10].Value = model.C_STD_CODE;
            parameters[11].Value = model.C_SPEC;
            parameters[12].Value = model.C_ZLDJ;
            parameters[13].Value = model.C_BZYQ;
            parameters[14].Value = model.C_LIC_PLA_NO;
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
            strSql.Append("delete from TMD_GPFY_LOG ");
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
            strSql.Append("delete from TMD_GPFY_LOG ");
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
        public Mod_TMD_GPFY_LOG GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_FYDH,C_TYPE,C_EMP_ID,D_MOD_DT,N_NUM,N_WGT,C_SEND_STOCK,C_BATCH_NO,C_STOVE,C_STL_GRD,C_STD_CODE,C_SPEC,C_ZLDJ,C_BZYQ,C_LIC_PLA_NO from TMD_GPFY_LOG ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            Mod_TMD_GPFY_LOG model = new Mod_TMD_GPFY_LOG();
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
        public Mod_TMD_GPFY_LOG DataRowToModel(DataRow row)
        {
            Mod_TMD_GPFY_LOG model = new Mod_TMD_GPFY_LOG();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_FYDH"] != null)
                {
                    model.C_FYDH = row["C_FYDH"].ToString();
                }
                if (row["C_TYPE"] != null)
                {
                    model.C_TYPE = row["C_TYPE"].ToString();
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["D_MOD_DT"] != null && row["D_MOD_DT"].ToString() != "")
                {
                    model.D_MOD_DT = DateTime.Parse(row["D_MOD_DT"].ToString());
                }
                if (row["N_NUM"] != null && row["N_NUM"].ToString() != "")
                {
                    model.N_NUM = decimal.Parse(row["N_NUM"].ToString());
                }
                if (row["N_WGT"] != null && row["N_WGT"].ToString() != "")
                {
                    model.N_WGT = decimal.Parse(row["N_WGT"].ToString());
                }
                if (row["C_SEND_STOCK"] != null)
                {
                    model.C_SEND_STOCK = row["C_SEND_STOCK"].ToString();
                }
                if (row["C_BATCH_NO"] != null)
                {
                    model.C_BATCH_NO = row["C_BATCH_NO"].ToString();
                }
                if (row["C_STOVE"] != null)
                {
                    model.C_STOVE = row["C_STOVE"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_STD_CODE"] != null)
                {
                    model.C_STD_CODE = row["C_STD_CODE"].ToString();
                }
                if (row["C_SPEC"] != null)
                {
                    model.C_SPEC = row["C_SPEC"].ToString();
                }
                if (row["C_ZLDJ"] != null)
                {
                    model.C_ZLDJ = row["C_ZLDJ"].ToString();
                }
                if (row["C_BZYQ"] != null)
                {
                    model.C_BZYQ = row["C_BZYQ"].ToString();
                }
                if (row["C_LIC_PLA_NO"] != null)
                {
                    model.C_LIC_PLA_NO = row["C_LIC_PLA_NO"].ToString();
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
            strSql.Append("select C_ID,C_FYDH,C_TYPE,C_EMP_ID,D_MOD_DT,N_NUM,N_WGT,C_SEND_STOCK,C_BATCH_NO,C_STOVE,C_STL_GRD,C_STD_CODE,C_SPEC,C_ZLDJ,C_BZYQ,C_LIC_PLA_NO ");
            strSql.Append(" FROM TMD_GPFY_LOG ");
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
            strSql.Append("select count(1) FROM TMD_GPFY_LOG ");
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
            strSql.Append(")AS Row, T.*  from TMD_GPFY_LOG T ");
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
					new OracleParameter(":PageSize", OracleDbType.Decimal),
					new OracleParameter(":PageIndex", OracleDbType.Decimal),
					new OracleParameter(":IsReCount", OracleType.Clob),
					new OracleParameter(":OrderType", OracleType.Clob),
					new OracleParameter(":strWhere", OracleDbType.Varchar2,1000),
					};
			parameters[0].Value = "TMD_GPFY_LOG";
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

        #endregion  ExtensionMethod
    }
}
