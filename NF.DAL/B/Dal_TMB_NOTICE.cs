using System;
using System.Data;
using System.Text;
using NF.MODEL;
using Oracle.ManagedDataAccess.Client;

namespace NF.DAL
{
	/// <summary>
	///公共
	/// </summary>
	public partial class Dal_TMB_NOTICE
    {
		public Dal_TMB_NOTICE()
		{}
        #region  BasicMethod



        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMB_NOTICE");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMB_NOTICE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMB_NOTICE(");
            strSql.Append("C_ID,C_CLASS,C_TITLE,C_PICURL,C_LINK,C_CONTENT,C_FILE,N_SORT,C_REMARK,N_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_CLASS,:C_TITLE,:C_PICURL,:C_LINK,:C_CONTENT,:C_FILE,:N_SORT,:C_REMARK,:N_STATUS,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CLASS", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_TITLE", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_PICURL", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_LINK", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_CONTENT", OracleDbType.NVarchar2,1000),
                    new OracleParameter(":C_FILE", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_SORT", OracleDbType.Int32,5),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_STATUS", OracleDbType.Int32,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_CLASS;
            parameters[2].Value = model.C_TITLE;
            parameters[3].Value = model.C_PICURL;
            parameters[4].Value = model.C_LINK;
            parameters[5].Value = model.C_CONTENT;
            parameters[6].Value = model.C_FILE;
            parameters[7].Value = model.N_SORT;
            parameters[8].Value = model.C_REMARK;
            parameters[9].Value = model.N_STATUS;
            parameters[10].Value = model.C_EMP_ID;
            parameters[11].Value = model.C_EMP_NAME;
            parameters[12].Value = model.D_MOD_DT;

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
        public bool UpdateStatus(string IDList, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMB_NOTICE set ");
            strSql.Append("N_STATUS=" + status + "");
            strSql.Append(" where C_ID in(" + IDList + ") ");
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMB_NOTICE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMB_NOTICE set ");
            strSql.Append("C_CLASS=:C_CLASS,");
            strSql.Append("C_TITLE=:C_TITLE,");
            strSql.Append("C_PICURL=:C_PICURL,");
            strSql.Append("C_LINK=:C_LINK,");
            strSql.Append("C_CONTENT=:C_CONTENT,");
            strSql.Append("C_FILE=:C_FILE,");
            strSql.Append("N_SORT=:N_SORT,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_CLASS", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_TITLE", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_PICURL", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_LINK", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_CONTENT", OracleDbType.NVarchar2,1000),
                    new OracleParameter(":C_FILE", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_SORT", OracleDbType.Int32,5),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_STATUS", OracleDbType.Int32,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_CLASS;
            parameters[1].Value = model.C_TITLE;
            parameters[2].Value = model.C_PICURL;
            parameters[3].Value = model.C_LINK;
            parameters[4].Value = model.C_CONTENT;
            parameters[5].Value = model.C_FILE;
            parameters[6].Value = model.N_SORT;
            parameters[7].Value = model.C_REMARK;
            parameters[8].Value = model.N_STATUS;
            parameters[9].Value = model.C_EMP_ID;
            parameters[10].Value = model.C_EMP_NAME;
            parameters[11].Value = model.D_MOD_DT;
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
            strSql.Append("delete from TMB_NOTICE ");
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
            strSql.Append("delete from TMB_NOTICE ");
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
        public Mod_TMB_NOTICE GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_CLASS,C_TITLE,C_PICURL,C_LINK,C_CONTENT,C_FILE,N_SORT,C_REMARK,N_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT from TMB_NOTICE ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TMB_NOTICE model = new Mod_TMB_NOTICE();
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
        public Mod_TMB_NOTICE DataRowToModel(DataRow row)
        {
            Mod_TMB_NOTICE model = new Mod_TMB_NOTICE();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_CLASS"] != null)
                {
                    model.C_CLASS = row["C_CLASS"].ToString();
                }
                if (row["C_TITLE"] != null)
                {
                    model.C_TITLE = row["C_TITLE"].ToString();
                }
                if (row["C_PICURL"] != null)
                {
                    model.C_PICURL = row["C_PICURL"].ToString();
                }
                if (row["C_LINK"] != null)
                {
                    model.C_LINK = row["C_LINK"].ToString();
                }
                if (row["C_CONTENT"] != null)
                {
                    model.C_CONTENT = row["C_CONTENT"].ToString();
                }
                if (row["C_FILE"] != null)
                {
                    model.C_FILE = row["C_FILE"].ToString();
                }
                if (row["N_SORT"] != null && row["N_SORT"].ToString() != "")
                {
                    model.N_SORT = decimal.Parse(row["N_SORT"].ToString());
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_CLASS,C_TITLE,C_PICURL,C_LINK,C_CONTENT,C_FILE,N_SORT,C_REMARK,N_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
            strSql.Append(" FROM TMB_NOTICE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string top,string type)
        {

            string strSql = $@"select *
                                  from (select C_ID,
                                               C_CLASS,
                                               C_TITLE,
                                               C_PICURL,
                                               C_LINK,
                                               C_CONTENT,
                                               C_FILE,
                                               N_SORT,
                                               C_REMARK,
                                               N_STATUS,
                                               C_EMP_ID,
                                               C_EMP_NAME,
                                               D_MOD_DT
                                          FROM TMB_NOTICE
                                         order by d_mod_dt desc) t
                                 where rownum <={top}";

            
            return DbHelperOra.Query(strSql);
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string classID, string title, string start, string end)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM TMB_NOTICE where N_STATUS=1");

            if (!string.IsNullOrEmpty(classID))
            {
                strSql.Append(" and C_CLASS='" + classID + "'");
            }
            if (!string.IsNullOrEmpty(title))
            {
                strSql.Append(" and C_TITLE like '%" + title + "%'");
            }
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                strSql.Append(" and D_MOD_DT between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).AddDays(1).ToString() + "', 'yyyy-mm-dd hh24:mi:ss')");
            }

            object obj =DbHelperOra.GetSingle(strSql.ToString());
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
        public DataSet GetListByPage(int pageSize, int startIndex,string classID,string title,string start,string end)
        {
            StringBuilder where = new StringBuilder();

            string item = "C_ID,C_CLASS,C_TITLE,C_PICURL,C_LINK,C_CONTENT,C_FILE,N_SORT,C_REMARK,N_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT";
            string table = "TMB_NOTICE";
            string order = "D_MOD_DT  desc";

            where.Append(" and N_STATUS=1");

            if (!string.IsNullOrEmpty(classID))
            {
                where.Append(" and C_CLASS='" + classID + "'");
            }
            if(!string .IsNullOrEmpty(title))
            {
                where.Append(" and C_TITLE like '%"+title+"%'");
            }
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                where.Append(" and D_MOD_DT between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).AddDays(1).ToString() + "', 'yyyy-mm-dd hh24:mi:ss')");
            }

            string sql = ByPage.GenerateByPageSql(pageSize, startIndex, item, table, order, where.ToString());
            return DbHelperOra.Query(sql);

        }

        #endregion  BasicMethod

    }
}

