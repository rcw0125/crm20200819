using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TPB_STEEL_PRO_CONDITION
    /// </summary>
    public partial class Dal_TPB_STEEL_PRO_CONDITION
    {
        public Dal_TPB_STEEL_PRO_CONDITION()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TPB_STEEL_PRO_CONDITION");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TPB_STEEL_PRO_CONDITION model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TPB_STEEL_PRO_CONDITION(");
            strSql.Append("C_ID,C_STL_GRD_TYPE,C_STL_GRD_RANK,C_STL_GRD,C_STD_CODE,C_STL_SCRAP_TYPE,C_STL_SCRAP_FLIJ,C_GOUTE,C_TEASE_PERSON,C_ADV_PRO_REQUIRE,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_STL_GRD_TYPE,:C_STL_GRD_RANK,:C_STL_GRD,:C_STD_CODE,:C_STL_SCRAP_TYPE,:C_STL_SCRAP_FLIJ,:C_GOUTE,:C_TEASE_PERSON,:C_ADV_PRO_REQUIRE,:N_STATUS,:C_REMARK,:C_EMP_ID,:D_MOD_DT)");
            OracleParameter[] parameters = {
                new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                     new OracleParameter(":C_STL_GRD_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD_RANK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_SCRAP_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_SCRAP_FLIJ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GOUTE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TEASE_PERSON", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ADV_PRO_REQUIRE", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_STL_GRD_TYPE;
            parameters[2].Value = model.C_STL_GRD_RANK;
            parameters[3].Value = model.C_STL_GRD;
            parameters[4].Value = model.C_STD_CODE;
            parameters[5].Value = model.C_STL_SCRAP_TYPE;
            parameters[6].Value = model.C_STL_SCRAP_FLIJ;
            parameters[7].Value = model.C_GOUTE;
            parameters[8].Value = model.C_TEASE_PERSON;
            parameters[9].Value = model.C_ADV_PRO_REQUIRE;
            parameters[10].Value = model.N_STATUS;
            parameters[11].Value = model.C_REMARK;
            parameters[12].Value = model.C_EMP_ID;
            parameters[13].Value = model.D_MOD_DT;

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
        public bool Update(Mod_TPB_STEEL_PRO_CONDITION model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TPB_STEEL_PRO_CONDITION set ");
            strSql.Append("C_STL_GRD_TYPE=:C_STL_GRD_TYPE,");
            strSql.Append("C_STL_GRD_RANK=:C_STL_GRD_RANK,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_STD_CODE=:C_STD_CODE,");
            strSql.Append("C_STL_SCRAP_TYPE=:C_STL_SCRAP_TYPE,");
            strSql.Append("C_STL_SCRAP_FLIJ=:C_STL_SCRAP_FLIJ,");
            strSql.Append("C_GOUTE=:C_GOUTE,");
            strSql.Append("C_TEASE_PERSON=:C_TEASE_PERSON,");
            strSql.Append("C_ADV_PRO_REQUIRE=:C_ADV_PRO_REQUIRE,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_STL_GRD_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD_RANK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_SCRAP_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_SCRAP_FLIJ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GOUTE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TEASE_PERSON", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ADV_PRO_REQUIRE", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_STL_GRD_TYPE;
            parameters[1].Value = model.C_STL_GRD_RANK;
            parameters[2].Value = model.C_STL_GRD;
            parameters[3].Value = model.C_STD_CODE;
            parameters[4].Value = model.C_STL_SCRAP_TYPE;
            parameters[5].Value = model.C_STL_SCRAP_FLIJ;
            parameters[6].Value = model.C_GOUTE;
            parameters[7].Value = model.C_TEASE_PERSON;
            parameters[8].Value = model.C_ADV_PRO_REQUIRE;
            parameters[9].Value = model.N_STATUS;
            parameters[10].Value = model.C_REMARK;
            parameters[11].Value = model.C_EMP_ID;
            parameters[12].Value = model.D_MOD_DT;
            parameters[13].Value = model.C_ID;

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
            strSql.Append("delete from TPB_STEEL_PRO_CONDITION ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
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
            strSql.Append("delete from TPB_STEEL_PRO_CONDITION ");
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
        public Mod_TPB_STEEL_PRO_CONDITION GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_STL_GRD_TYPE,C_STL_GRD_RANK,C_STL_GRD,C_STD_CODE,C_STL_SCRAP_TYPE,C_STL_SCRAP_FLIJ,C_GOUTE,C_TEASE_PERSON,C_ADV_PRO_REQUIRE,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT from TPB_STEEL_PRO_CONDITION ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TPB_STEEL_PRO_CONDITION model = new Mod_TPB_STEEL_PRO_CONDITION();
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
        public Mod_TPB_STEEL_PRO_CONDITION DataRowToModel(DataRow row)
        {
            Mod_TPB_STEEL_PRO_CONDITION model = new Mod_TPB_STEEL_PRO_CONDITION();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_STL_GRD_TYPE"] != null)
                {
                    model.C_STL_GRD_TYPE = row["C_STL_GRD_TYPE"].ToString();
                }
                if (row["C_STL_GRD_RANK"] != null)
                {
                    model.C_STL_GRD_RANK = row["C_STL_GRD_RANK"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_STD_CODE"] != null)
                {
                    model.C_STD_CODE = row["C_STD_CODE"].ToString();
                }
                if (row["C_STL_SCRAP_TYPE"] != null)
                {
                    model.C_STL_SCRAP_TYPE = row["C_STL_SCRAP_TYPE"].ToString();
                }
                if (row["C_STL_SCRAP_FLIJ"] != null)
                {
                    model.C_STL_SCRAP_FLIJ = row["C_STL_SCRAP_FLIJ"].ToString();
                }
                if (row["C_GOUTE"] != null)
                {
                    model.C_GOUTE = row["C_GOUTE"].ToString();
                }
                if (row["C_TEASE_PERSON"] != null)
                {
                    model.C_TEASE_PERSON = row["C_TEASE_PERSON"].ToString();
                }
                if (row["C_ADV_PRO_REQUIRE"] != null)
                {
                    model.C_ADV_PRO_REQUIRE = row["C_ADV_PRO_REQUIRE"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["D_MOD_DT"] != null && row["D_MOD_DT"].ToString() != "")
                {
                    model.D_MOD_DT = DateTime.Parse(row["D_MOD_DT"].ToString());
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表_条件模糊查询
        /// </summary>
        /// <param name="C_STL_GRD">钢种</param>
        /// <param name="C_STD_CODE">执行标准</param>
        /// <returns></returns>
        public DataSet GetList_Query(string C_STL_GRD, string C_STD_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_STL_GRD_TYPE,C_STL_GRD_RANK,C_STL_GRD,C_STD_CODE,C_STL_SCRAP_TYPE,C_STL_SCRAP_FLIJ,C_GOUTE,C_TEASE_PERSON,C_ADV_PRO_REQUIRE,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT ");
            strSql.Append(" FROM TPB_STEEL_PRO_CONDITION where 1=1");
            if (C_STL_GRD.Trim() != "")
            {
                strSql.Append(" and C_STL_GRD like '%" + C_STL_GRD + "%' ");
            }
            if (C_STD_CODE.Trim() != "")
            {
                strSql.Append(" and C_STD_CODE like '%" + C_STD_CODE + "%' ");
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_STL_GRD_TYPE,C_STL_GRD_RANK,C_STL_GRD,C_STD_CODE,C_STL_SCRAP_TYPE,C_STL_SCRAP_FLIJ,C_GOUTE,C_TEASE_PERSON,C_ADV_PRO_REQUIRE,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT ");
            strSql.Append(" FROM TPB_STEEL_PRO_CONDITION ");
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
            strSql.Append("select count(1) FROM TPB_STEEL_PRO_CONDITION ");
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
            strSql.Append(")AS Row, T.*  from TPB_STEEL_PRO_CONDITION T ");
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
			parameters[0].Value = "TPB_STEEL_PRO_CONDITION";
			parameters[1].Value = "C_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        
    }
}

