using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TMC_CHAT
	/// </summary>
	public partial class Dal_TMC_CHAT
    {
		public Dal_TMC_CHAT()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TMC_CHAT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TMC_CHAT(");
			strSql.Append("C_UID,C_FID,C_CONTENT)");
			strSql.Append(" values (");
			strSql.Append(":C_UID,:C_FID,:C_CONTENT)");
			OracleParameter[] parameters = {
					new OracleParameter(":C_UID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_FID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_CONTENT", OracleDbType.Varchar2,300)};
			parameters[0].Value = model.C_UID;
			parameters[1].Value = model.C_FID;
			parameters[2].Value = model.C_CONTENT;

			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(Mod_TMC_CHAT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TMC_CHAT set ");
			strSql.Append("C_UID=:C_UID,");
			strSql.Append("C_FID=:C_FID,");
			strSql.Append("C_CONTENT=:C_CONTENT,");
			strSql.Append("D_DT=:D_DT");
			strSql.Append(" where C_ID=:C_ID");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_UID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_FID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_CONTENT", OracleDbType.Varchar2,200),
					new OracleParameter(":D_DT", OracleDbType.Date)};
			parameters[0].Value = model.C_ID;
			parameters[1].Value = model.C_UID;
			parameters[2].Value = model.C_FID;
			parameters[3].Value = model.C_CONTENT;
			parameters[4].Value = model.D_DT;

			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TMC_CHAT ");
			strSql.Append(" where ");
			OracleParameter[] parameters = {
			};

			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
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
		public Mod_TMC_CHAT GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_UID,C_FID,C_CONTENT,D_DT from TMC_CHAT ");
			strSql.Append(" where ");
			OracleParameter[] parameters = {
			};

			Mod_TMC_CHAT model=new Mod_TMC_CHAT();
			DataSet ds=DbHelperOra.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public Mod_TMC_CHAT DataRowToModel(DataRow row)
		{
			Mod_TMC_CHAT model=new Mod_TMC_CHAT();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_UID"]!=null)
				{
					model.C_UID=row["C_UID"].ToString();
				}
				
				if(row["C_FID"]!=null)
				{
					model.C_FID=row["C_FID"].ToString();
				}
				if(row["C_CONTENT"]!=null)
				{
					model.C_CONTENT=row["C_CONTENT"].ToString();
				}
				if(row["D_DT"] !=null && row["D_DT"].ToString()!="")
				{
					model.D_DT = DateTime.Parse(row["D_DT"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_UID,C_FID,C_CONTENT,D_DT");
			strSql.Append(" FROM TMC_CHAT ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOra.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM TMC_CHAT ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from TMC_CHAT T ");
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
        /// 获取客户列表
        /// </summary>
        /// <param name="fid">接收者</param>
        /// <returns></returns>
        public DataSet GetUID(string fid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select (select b.c_name from ts_custfile b where b.c_id = a.c_cust_id) cust,a.c_id
                                  from ts_user a
                                 where a.c_id in (select distinct t.c_uid
                                                    from TMC_CHAT t
                                                   where t.c_fid = '{0}'
                                                     and trunc(t.d_dt) = trunc(sysdate))", fid);
            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 获取客户聊天记录(手机接口)
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="LastDT"></param>
        /// <param name="FristDT"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public DataSet GetChatList2(string emp,string LastDT,string FristDT,string Count)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"with tt as
                                         (select t.c_id,
                                                 t.c_uid,
                                                 a.c_name as userName,
                                                 t.c_fid,
                                                 t.c_content,
                                                 t.d_dt
                                            from TMC_CHAT t inner join ts_user a on a.c_id=t.c_uid
                                           where t.c_uid = '{0}'
                                          union all
                                          select t.c_id,
                                                 t.c_uid,
                                                 a.c_name as userName,
                                                 t.c_fid,
                                                 t.c_content,
                                                 t.d_dt
                                            from TMC_CHAT t inner join ts_user a on a.c_id=t.c_uid
                                           where t.c_fid = '{0}')
                                        select *
                                          from (select c_id,
                                                       c_uid,
                                                       userName,
                                                       c_fid,
                                                       c_content,
                                                       d_dt,
                                                       ROW_NUMBER() OVER(ORDER BY d_dt desc)
                                                  from tt)
                                         where 1 = 1", emp);

            if(!string .IsNullOrEmpty(LastDT))
            {
                strSql.Append(" and d_dt>= to_date('" + LastDT + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            if (!string.IsNullOrEmpty(FristDT))
            {
                strSql.Append(" and d_dt<= to_date('" + FristDT + "', 'yyyy-mm-dd hh24:mi:ss') ");
            }
            strSql.Append(" and  rownum <=" + Count+" ");
           

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        ///获取客户聊天记录
        /// </summary>
        public DataSet GetChatList(string uid,string fid, string LastDT, string FristDT, string Count)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"with tt as
                                     (select t.c_id, t.c_uid, a.c_name as userName, t.c_fid, t.c_content, t.d_dt
                                        from TMC_CHAT t
                                       inner join ts_user a
                                          on a.c_id = t.c_uid
                                       where t.c_uid = '{0}' and t.c_fid='{1}'
                                      union 
                                      select t.c_id, t.c_uid, a.c_name as userName, t.c_fid, t.c_content, t.d_dt
                                        from TMC_CHAT t
                                       inner join ts_user a
                                          on a.c_id = t.c_uid
                                       where  t.c_uid = '{1}' and   t.c_fid = '{0}')
                                    select *
                                      from (select c_id,
                                                   c_uid,
                                                   userName,
                                                   c_fid,
                                                   c_content,
                                                   d_dt,
                                                   ROW_NUMBER() OVER(ORDER BY d_dt asc)
                                              from tt)
                                     where 1 = 1", uid,fid);

            if (!string.IsNullOrEmpty(LastDT))
            {
                strSql.Append(" and d_dt>= to_date('" + FristDT + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            if (!string.IsNullOrEmpty(FristDT))
            {
                strSql.Append(" and d_dt<= to_date('" + LastDT  + "', 'yyyy-mm-dd hh24:mi:ss') ");
            }
            //strSql.Append(" and  rownum <=" + Count + " ");


            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取售后聊天记录
        /// </summary>
        /// <param name="uid">发送者</param>
        /// <param name="fid">接收者</param>
        /// <returns></returns>

        public DataSet GetChatList(string uid,string fid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"with tt as
                                 (select t.c_id,
                                         t.c_uid,
                                         (select b.c_remark from TMC_CHAT_EMP b where b.c_user_id = t.c_uid) userName,
                                         t.c_fid,
                                         t.c_content,
                                         t.d_dt
                                    from TMC_CHAT t
                                   where t.c_uid = '{0}'
                                  union all
                                  select t.c_id,
                                         t.c_uid,
                                         (select a.c_name from ts_user a where a.c_id = t.c_uid) userName,
                                         t.c_fid,
                                         t.c_content,
                                         t.d_dt
                                    from TMC_CHAT t
                                   where t.c_uid = '{1}')
                                select c_id, c_uid, userName, c_fid, c_content, d_dt
                                  from tt
                                 where trunc(d_dt) = trunc(sysdate)
                                 order by d_dt asc",uid, fid);

            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion  ExtensionMethod
    }
}

