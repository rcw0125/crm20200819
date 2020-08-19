using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;

using NF.MODEL;

namespace NF.DAL
{
    /// <summary>
    /// 地理区域
    /// </summary>
    public partial class Dal_TMB_AREA
    {
        public Dal_TMB_AREA()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMB_AREA");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMB_AREA model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMB_AREA(");
            strSql.Append("C_ID,C_CODE,C_NAME,N_PARENTID,N_SORT,N_DEPTH,C_REMARK,N_STATUS,N_ISGPS,C_EMP_ID,C_EMP_NAME,D_MOD_DT)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_CODE,:C_NAME,:N_PARENTID,:N_SORT,:N_DEPTH,:C_REMARK,:N_STATUS,:N_ISGPS,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_PARENTID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_SORT", OracleDbType.Int32,5),
                    new OracleParameter(":N_DEPTH", OracleDbType.Int32,2),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_STATUS", OracleDbType.Int32,1),
                    new OracleParameter(":N_ISGPS", OracleDbType.Int32,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_CODE;
            parameters[2].Value = model.C_NAME;
            parameters[3].Value = model.N_PARENTID;
            parameters[4].Value = model.N_SORT;
            parameters[5].Value = model.N_DEPTH;
            parameters[6].Value = model.C_REMARK;
            parameters[7].Value = model.N_STATUS;
            parameters[8].Value = model.N_ISGPS;
            parameters[9].Value = model.C_EMP_ID;
            parameters[10].Value = model.C_EMP_NAME;
            parameters[11].Value = model.D_MOD_DT;

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
        /// 更新状态
        /// </summary>
        public bool UpdateStatus(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMB_AREA set ");


            strSql.Append("N_STATUS=0 where C_ID='" + id + "'");

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
        public bool Update(Mod_TMB_AREA model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMB_AREA set ");
            strSql.Append("C_CODE=:C_CODE,");
            strSql.Append("C_NAME=:C_NAME,");
            strSql.Append("N_PARENTID=:N_PARENTID,");
            strSql.Append("N_SORT=:N_SORT,");
            strSql.Append("N_DEPTH=:N_DEPTH,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("N_ISGPS=:N_ISGPS,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_PARENTID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_SORT", OracleDbType.Int32,5),
                    new OracleParameter(":N_DEPTH", OracleDbType.Int32,2),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_STATUS", OracleDbType.Int32,1),
                    new OracleParameter(":N_ISGPS", OracleDbType.Int32,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_CODE;
            parameters[1].Value = model.C_NAME;
            parameters[2].Value = model.N_PARENTID;
            parameters[3].Value = model.N_SORT;
            parameters[4].Value = model.N_DEPTH;
            parameters[5].Value = model.C_REMARK;
            parameters[6].Value = model.N_STATUS;
            parameters[7].Value = model.N_ISGPS;
            parameters[8].Value = model.C_EMP_ID;
            parameters[9].Value = model.C_EMP_NAME;
            parameters[10].Value = model.D_MOD_DT;
            parameters[11].Value = model.C_ID;

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
            strSql.Append("delete from TMB_AREA ");
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
            strSql.Append("delete from TMB_AREA ");
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
        public Mod_TMB_AREA GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_CODE,C_NAME,N_PARENTID,N_SORT,N_DEPTH,C_REMARK,N_STATUS,N_ISGPS,C_EMP_ID,C_EMP_NAME,D_MOD_DT from TMB_AREA ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TMB_AREA model = new Mod_TMB_AREA();
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
        public Mod_TMB_AREA DataRowToModel(DataRow row)
        {
            Mod_TMB_AREA model = new Mod_TMB_AREA();
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
                if (row["C_NAME"] != null)
                {
                    model.C_NAME = row["C_NAME"].ToString();
                }
                if (row["N_PARENTID"] != null)
                {
                    model.N_PARENTID = row["N_PARENTID"].ToString();
                }
                if (row["N_SORT"] != null && row["N_SORT"].ToString() != "")
                {
                    model.N_SORT = decimal.Parse(row["N_SORT"].ToString());
                }
                if (row["N_DEPTH"] != null && row["N_DEPTH"].ToString() != "")
                {
                    model.N_DEPTH = decimal.Parse(row["N_DEPTH"].ToString());
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["N_ISGPS"] != null && row["N_ISGPS"].ToString() != "")
                {
                    model.N_ISGPS = decimal.Parse(row["N_ISGPS"].ToString());
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
        public DataSet GetAreaList(string N_PARENTID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_CODE,C_NAME,N_PARENTID,N_SORT,N_DEPTH,C_REMARK,N_STATUS,N_ISGPS,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
            strSql.Append(" FROM TMB_AREA  where N_STATUS=1");
            if (!string.IsNullOrEmpty(N_PARENTID))
            {
                strSql.Append(" and  N_PARENTID='" + N_PARENTID + "' ");
            }

            strSql.Append(" order by N_SORT asc");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取站点
        /// </summary>
        public DataSet GetStation()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select  C_ID,C_CODE,C_NAME,N_PARENTID,N_SORT,N_DEPTH,C_REMARK,N_STATUS,N_ISGPS,C_EMP_ID,C_EMP_NAME,D_MOD_DT
                              from tmb_area t
                             where t.n_parentid in
                                   (select t.c_id
                                      from tmb_area t
                                     where t.n_parentid = 'dqdaa000000000000001' and t.n_status = 1)");
           
            strSql.Append(" order by t.N_SORT asc");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(Mod_TMB_AREA mod)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_CODE,C_NAME,N_PARENTID,N_SORT,N_DEPTH,C_REMARK,N_STATUS,N_ISGPS,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
            strSql.Append(" FROM TMB_AREA  where N_STATUS=1 ");
           
            if (!string.IsNullOrEmpty(mod.C_CODE))
            {
                strSql.Append(" and C_CODE in(" + mod.C_CODE + ")");
            }
            if (!string.IsNullOrEmpty(mod.C_NAME))
            {
                strSql.Append(" and C_NAME like '%" + mod.C_NAME + "%'");
            }
            if (!string.IsNullOrEmpty(mod.N_PARENTID))
            {
                strSql.Append(" and N_PARENTID='" + mod.N_PARENTID + "'");
            }

            strSql.Append(" order by N_SORT asc");

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_CODE,C_NAME,N_PARENTID,N_SORT,N_DEPTH,C_REMARK,N_STATUS,N_ISGPS,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
            strSql.Append(" FROM TMB_AREA ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ORDER BY N_SORT ASC");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TMB_AREA ");
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
            strSql.Append(")AS Row, T.*  from TMB_AREA T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据区域主键获取地点主键
        /// </summary>
        /// <param name="pk_address"></param>
        /// <returns></returns>
        public DataSet GetAreaAddress(string pk_address)
        {
            string strsql = "SELECT T.ADDRCODE,T.PK_ADDRESS,T.PK_AREACL,T.PROVINCE FROM TMB_NCADDRESS T WHERE T.PK_AREACL='"+pk_address+"'";

            return DbHelperOra.Query(strsql);
        }

        public DataSet GetAddrNCPK(string name)
        {
            string strSql = $"SELECT T.C_ADDR_NCPK FROM  TMB_NCADDRESS_COST  T WHERE T.C_ADDRNAME='{name}'";
            return DbHelperOra.Query(strSql);
        }

        public DataSet GetAddrList(string where)
        {
            string strSql = "SELECT T.C_ID, T.ADDRCODE,T.ADDRNAME AS C_NAME, T.PK_AREACL AS N_PARENTID  FROM TMB_NCADDRESS T";
            return DbHelperOra.Query(strSql);
        }


        public DataSet GetAddrList(string code ,string name)
        {
            string strSql = "SELECT T.C_ID, T.ADDRCODE,T.ADDRNAME,T.PK_ADDRESS, T.PK_AREACL  FROM TMB_NCADDRESS T WHERE 1=1";
            if(!string .IsNullOrEmpty(code))
            {
                strSql += $" AND T.ADDRCODE='{code}'";
            }
            if (!string.IsNullOrEmpty(name))
            {
                strSql += $" AND T.ADDRNAME LIKE '%{name}%'";
            }

            strSql += " ORDER BY T.ADDRCODE ASC";
            return DbHelperOra.Query(strSql);
        }

        #endregion  BasicMethod
    }
}

