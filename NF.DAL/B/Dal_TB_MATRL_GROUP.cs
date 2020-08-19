using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TB_MATRL_GROUP
    /// </summary>
    public partial class Dal_TB_MATRL_GROUP
    {
        public Dal_TB_MATRL_GROUP()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TB_MATRL_GROUP");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TB_MATRL_GROUP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TB_MATRL_GROUP(");
            strSql.Append("C_ID,C_MAT_GROUP_CODE,C_MAT_GROUP_NAME,C_PROD_KIND,C_PROD_NAME,C_EMP_ID,D_MOD_DT,C_MAT_TYPE,C_CLS_TYPE,C_REMARK1,C_REMARK2,C_REMARK3,N_LEV)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_MAT_GROUP_CODE,:C_MAT_GROUP_NAME,:C_PROD_KIND,:C_PROD_NAME,:C_EMP_ID,:D_MOD_DT,:C_MAT_TYPE,:C_CLS_TYPE,:C_REMARK1,:C_REMARK2,:C_REMARK3,:N_LEV)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_GROUP_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_GROUP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_KIND", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_MAT_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CLS_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK1", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_REMARK2", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_REMARK3", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_LEV", OracleDbType.Decimal,5)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_MAT_GROUP_CODE;
            parameters[2].Value = model.C_MAT_GROUP_NAME;
            parameters[3].Value = model.C_PROD_KIND;
            parameters[4].Value = model.C_PROD_NAME;
            parameters[5].Value = model.C_EMP_ID;
            parameters[6].Value = model.D_MOD_DT;
            parameters[7].Value = model.C_MAT_TYPE;
            parameters[8].Value = model.C_CLS_TYPE;
            parameters[9].Value = model.C_REMARK1;
            parameters[10].Value = model.C_REMARK2;
            parameters[11].Value = model.C_REMARK3;
            parameters[12].Value = model.N_LEV;

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
        public bool Update(Mod_TB_MATRL_GROUP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TB_MATRL_GROUP set ");
            strSql.Append("C_MAT_GROUP_CODE=:C_MAT_GROUP_CODE,");
            strSql.Append("C_MAT_GROUP_NAME=:C_MAT_GROUP_NAME,");
            strSql.Append("C_PROD_KIND=:C_PROD_KIND,");
            strSql.Append("C_PROD_NAME=:C_PROD_NAME,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("C_MAT_TYPE=:C_MAT_TYPE,");
            strSql.Append("C_CLS_TYPE=:C_CLS_TYPE,");
            strSql.Append("C_REMARK1=:C_REMARK1,");
            strSql.Append("C_REMARK2=:C_REMARK2,");
            strSql.Append("C_REMARK3=:C_REMARK3,");
            strSql.Append("N_LEV=:N_LEV");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_MAT_GROUP_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_GROUP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_KIND", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_MAT_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CLS_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK1", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_REMARK2", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_REMARK3", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_LEV", OracleDbType.Decimal,5),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_MAT_GROUP_CODE;
            parameters[1].Value = model.C_MAT_GROUP_NAME;
            parameters[2].Value = model.C_PROD_KIND;
            parameters[3].Value = model.C_PROD_NAME;
            parameters[4].Value = model.C_EMP_ID;
            parameters[5].Value = model.D_MOD_DT;
            parameters[6].Value = model.C_MAT_TYPE;
            parameters[7].Value = model.C_CLS_TYPE;
            parameters[8].Value = model.C_REMARK1;
            parameters[9].Value = model.C_REMARK2;
            parameters[10].Value = model.C_REMARK3;
            parameters[11].Value = model.N_LEV;
            parameters[12].Value = model.C_ID;

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
            strSql.Append("delete from TB_MATRL_GROUP ");
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
            strSql.Append("delete from TB_MATRL_GROUP ");
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
        public Mod_TB_MATRL_GROUP GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_MAT_GROUP_CODE,C_MAT_GROUP_NAME,C_PROD_KIND,C_PROD_NAME,C_EMP_ID,D_MOD_DT,C_MAT_TYPE,C_CLS_TYPE,C_REMARK1,C_REMARK2,C_REMARK3,N_LEV from TB_MATRL_GROUP ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TB_MATRL_GROUP model = new Mod_TB_MATRL_GROUP();
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
        public Mod_TB_MATRL_GROUP DataRowToModel(DataRow row)
        {
            Mod_TB_MATRL_GROUP model = new Mod_TB_MATRL_GROUP();
            if (row != null)
            {
               
                if (row["C_MAT_GROUP_CODE"] != null)
                {
                    model.C_MAT_GROUP_CODE = row["C_MAT_GROUP_CODE"].ToString();
                }
                if (row["C_MAT_GROUP_NAME"] != null)
                {
                    model.C_MAT_GROUP_NAME = row["C_MAT_GROUP_NAME"].ToString();
                }
               
                if (row["N_LEV"] != null && row["N_LEV"].ToString() != "")
                {
                    model.N_LEV = decimal.Parse(row["N_LEV"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TB_MATRL_GROUP DataRowToModel2(DataRow row)
        {
            Mod_TB_MATRL_GROUP model = new Mod_TB_MATRL_GROUP();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_MAT_GROUP_CODE"] != null)
                {
                    model.C_MAT_GROUP_CODE = row["C_MAT_GROUP_CODE"].ToString();
                }
                if (row["C_MAT_GROUP_NAME"] != null)
                {
                    model.C_MAT_GROUP_NAME = row["C_MAT_GROUP_NAME"].ToString();
                }
                if (row["C_PROD_KIND"] != null)
                {
                    model.C_PROD_KIND = row["C_PROD_KIND"].ToString();
                }
                if (row["C_PROD_NAME"] != null)
                {
                    model.C_PROD_NAME = row["C_PROD_NAME"].ToString();
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["D_MOD_DT"] != null && row["D_MOD_DT"].ToString() != "")
                {
                    model.D_MOD_DT = DateTime.Parse(row["D_MOD_DT"].ToString());
                }
                if (row["C_MAT_TYPE"] != null)
                {
                    model.C_MAT_TYPE = row["C_MAT_TYPE"].ToString();
                }
                if (row["C_CLS_TYPE"] != null)
                {
                    model.C_CLS_TYPE = row["C_CLS_TYPE"].ToString();
                }
                if (row["C_REMARK1"] != null)
                {
                    model.C_REMARK1 = row["C_REMARK1"].ToString();
                }
                if (row["C_REMARK2"] != null)
                {
                    model.C_REMARK2 = row["C_REMARK2"].ToString();
                }
                if (row["C_REMARK3"] != null)
                {
                    model.C_REMARK3 = row["C_REMARK3"].ToString();
                }
                if (row["N_LEV"] != null && row["N_LEV"].ToString() != "")
                {
                    model.N_LEV = decimal.Parse(row["N_LEV"].ToString());
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
            strSql.Append("select C_ID,C_MAT_GROUP_CODE,C_MAT_GROUP_NAME,C_PROD_KIND,C_PROD_NAME,C_EMP_ID,D_MOD_DT,C_MAT_TYPE,C_CLS_TYPE,C_REMARK1,C_REMARK2,C_REMARK3,N_LEV ");
            strSql.Append(" FROM TB_MATRL_GROUP ");
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
            strSql.Append("select count(1) FROM TB_MATRL_GROUP ");
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
            strSql.Append(")AS Row, T.*  from TB_MATRL_GROUP T ");
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
					new OracleParameter(":PageSize", OracleDbType.Number),
					new OracleParameter(":PageIndex", OracleDbType.Number),
					new OracleParameter(":IsReCount", OracleDbType.Clob),
					new OracleParameter(":OrderType", OracleDbType.Clob),
					new OracleParameter(":strWhere", OracleDbType.Varchar2,1000),
					};
			parameters[0].Value = "TB_MATRL_GROUP";
			parameters[1].Value = "C_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod

        /// <summary>
        /// 获取物料组
        /// </summary>
        /// <returns></returns>
        public DataSet GetMatrlGroup(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select T.N_LEV, T.C_MAT_GROUP_NAME,T.C_MAT_GROUP_CODE
                                              from TB_MATRL_GROUP t
                                             where   (t.c_mat_group_code like '8%'
                                               or t.c_mat_group_code like '6%')");

            if (!string.IsNullOrEmpty(code))
            {
              string str = string.Format(@"select  decode (T.N_LEV,1,2,2,3,3,4,4,5) N_LEV, T.C_MAT_GROUP_NAME, T.C_MAT_GROUP_CODE
              from TB_MATRL_GROUP t where t.C_MAT_GROUP_CODE = '{0}'", code);

                DataRow dr = DbHelperOra.GetDataRow(str);
                if (dr != null)
                {
                    strSql.Append(" and T.C_MAT_GROUP_CODE like '" + code + "%'  and T.N_LEV='" + dr["N_LEV"].ToString() + "'");

                    strSql.Append(" order by  T.C_MAT_GROUP_CODE asc");
                }
            }
            else
            {
                strSql.Append(" and T.C_MAT_GROUP_CODE like '" + code + "%'  and T.N_LEV='1'");
                strSql.Append(" order by  T.C_MAT_GROUP_CODE desc");
            }
            
            return DbHelperOra.Query(strSql.ToString());
        }

    }
}

