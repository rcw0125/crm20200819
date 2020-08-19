using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TQB_DESIGN_ORDER
    /// </summary>
    public partial class Dal_TQB_DESIGN_ORDER
    {
        public Dal_TQB_DESIGN_ORDER()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TQB_DESIGN_ORDER");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TQB_DESIGN_ORDER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TQB_DESIGN_ORDER(");
            strSql.Append("C_ORDER_ID,C_DESIGN_ID,C_DELIVERY_STATE,N_STATUS,C_REMARK,C_EMP_ID,C_EMP_ID_BG,D_MOD_DT_BG,C_EMP_ID_SH,D_MOD_DT_SH)");
            strSql.Append(" values (");
            strSql.Append(":C_ORDER_ID,:C_DESIGN_ID,:C_DELIVERY_STATE,:N_STATUS,:C_REMARK,:C_EMP_ID,:C_EMP_ID_BG,:D_MOD_DT_BG,:C_EMP_ID_SH,:D_MOD_DT_SH)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ORDER_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DESIGN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DELIVERY_STATE", OracleDbType.Varchar2,20),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_EMP_ID_BG", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT_BG", OracleDbType.Date),
                    new OracleParameter(":C_EMP_ID_SH", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT_SH", OracleDbType.Date)};
            parameters[0].Value = model.C_ORDER_ID;
            parameters[1].Value = model.C_DESIGN_ID;
            parameters[2].Value = model.C_DELIVERY_STATE;
            parameters[3].Value = model.N_STATUS;
            parameters[4].Value = model.C_REMARK;
            parameters[5].Value = model.C_EMP_ID;
            parameters[6].Value = model.C_EMP_ID_BG;
            parameters[7].Value = model.D_MOD_DT_BG;
            parameters[8].Value = model.C_EMP_ID_SH;
            parameters[9].Value = model.D_MOD_DT_SH;

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
        public bool Update(Mod_TQB_DESIGN_ORDER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TQB_DESIGN_ORDER set ");
            strSql.Append("C_ORDER_ID=:C_ORDER_ID,");
            strSql.Append("C_DESIGN_ID=:C_DESIGN_ID,");
            strSql.Append("C_DELIVERY_STATE=:C_DELIVERY_STATE,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("C_EMP_ID_BG=:C_EMP_ID_BG,");
            strSql.Append("D_MOD_DT_BG=:D_MOD_DT_BG,");
            strSql.Append("C_EMP_ID_SH=:C_EMP_ID_SH,");
            strSql.Append("D_MOD_DT_SH=:D_MOD_DT_SH");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ORDER_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DESIGN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DELIVERY_STATE", OracleDbType.Varchar2,20),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_EMP_ID_BG", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT_BG", OracleDbType.Date),
                    new OracleParameter(":C_EMP_ID_SH", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT_SH", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_ORDER_ID;
            parameters[1].Value = model.C_DESIGN_ID;
            parameters[2].Value = model.C_DELIVERY_STATE;
            parameters[3].Value = model.N_STATUS;
            parameters[4].Value = model.C_REMARK;
            parameters[5].Value = model.C_EMP_ID;
            parameters[6].Value = model.D_MOD_DT;
            parameters[7].Value = model.C_EMP_ID_BG;
            parameters[8].Value = model.D_MOD_DT_BG;
            parameters[9].Value = model.C_EMP_ID_SH;
            parameters[10].Value = model.D_MOD_DT_SH;
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
        /// 更新一条数据
        /// </summary>
        public bool UpdateDesign(string C_ORDER_ID, string C_DESIGN_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TQB_DESIGN_ORDER set ");

            strSql.Append("C_DESIGN_ID=:C_DESIGN_ID ");

            strSql.Append(" where C_ORDER_ID=:C_ORDER_ID ");
            OracleParameter[] parameters = {

                    new OracleParameter(":C_DESIGN_ID", OracleDbType.Varchar2,100),
             new OracleParameter(":C_ORDER_ID", OracleDbType.Varchar2,100)};

            parameters[0].Value = C_DESIGN_ID;
            parameters[1].Value = C_ORDER_ID;



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
        /// 根据订单号删除订单质量
        /// </summary>
        public bool DeleteOder(string C_ORDER_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TQB_DESIGN_ORDER ");
            strSql.Append(" where C_ORDER_ID=:C_ORDER_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ORDER_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ORDER_ID;

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
            strSql.Append("delete from TQB_DESIGN_ORDER ");
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
            strSql.Append("delete from TQB_DESIGN_ORDER ");
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
        public Mod_TQB_DESIGN_ORDER GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_ORDER_ID,C_DESIGN_ID,C_DELIVERY_STATE,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT,C_EMP_ID_BG,D_MOD_DT_BG,C_EMP_ID_SH,D_MOD_DT_SH from TQB_DESIGN_ORDER ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TQB_DESIGN_ORDER model = new Mod_TQB_DESIGN_ORDER();
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
        public Mod_TQB_DESIGN_ORDER DataRowToModel(DataRow row)
        {
            Mod_TQB_DESIGN_ORDER model = new Mod_TQB_DESIGN_ORDER();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_ORDER_ID"] != null)
                {
                    model.C_ORDER_ID = row["C_ORDER_ID"].ToString();
                }
                if (row["C_DESIGN_ID"] != null)
                {
                    model.C_DESIGN_ID = row["C_DESIGN_ID"].ToString();
                }
                if (row["C_DELIVERY_STATE"] != null)
                {
                    model.C_DELIVERY_STATE = row["C_DELIVERY_STATE"].ToString();
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
                if (row["C_EMP_ID_BG"] != null)
                {
                    model.C_EMP_ID_BG = row["C_EMP_ID_BG"].ToString();
                }
                if (row["D_MOD_DT_BG"] != null && row["D_MOD_DT_BG"].ToString() != "")
                {
                    model.D_MOD_DT_BG = DateTime.Parse(row["D_MOD_DT_BG"].ToString());
                }
                if (row["C_EMP_ID_SH"] != null)
                {
                    model.C_EMP_ID_SH = row["C_EMP_ID_SH"].ToString();
                }
                if (row["D_MOD_DT_SH"] != null && row["D_MOD_DT_SH"].ToString() != "")
                {
                    model.D_MOD_DT_SH = DateTime.Parse(row["D_MOD_DT_SH"].ToString());
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
            strSql.Append("select C_ID,C_ORDER_ID,C_DESIGN_ID,C_DELIVERY_STATE,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT,C_EMP_ID_BG,D_MOD_DT_BG,C_EMP_ID_SH,D_MOD_DT_SH ");
            strSql.Append(" FROM TQB_DESIGN_ORDER ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据订单号获取质量设计信息
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns></returns>
        public DataSet GetDesignByOrder(string strOrderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ta.C_ID,ta.C_DELIVERY_STATE,tc.c_design_no as 质量设计号,td.c_std_code as 执行标准,tb.C_NO as 订单号,tb.c_stl_grd as 钢种,tb.c_mat_code as 物料编码,tb.c_mat_name as 物料名称, (select t.c_name from TS_USER t where t.c_account=ta.c_emp_id_bg)as 变更人,ta.d_mod_dt_bg as 变更时间,(select t.c_name from TS_USER t where t.c_account=ta.c_emp_id_sh)as 审核人,ta.d_mod_dt_sh as 审核时间,decode(ta.n_status,0,'停用',1,'可用',2,'待审核')as 状态  from TQB_DESIGN_ORDER ta inner join tmo_condetails tb on ta.c_order_id=tb.c_no inner join tqb_design tc on ta.c_design_id=tc.c_id inner join tb_std_config td on td.c_std_id=tc.c_std_main_id where ta.n_status in (1,2) ");

            if (strOrderNo.Trim() != "")
            {
                strSql.Append(" and tb.c_no='" + strOrderNo + "' ");
            }
            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 根据执行标准和钢种查询质量设计信息
        /// </summary>
        /// <param name="strStdcode"></param>
        /// <param name="strGrd"></param>
        /// <returns></returns>
        public DataSet GetDesignByStdGrd(string strStdcode, string strGrd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ta.C_ID,ta.c_design_no as 质量设计号,tb.c_std_code as 执行标准,tb.c_stl_grd as 钢种 from tqb_design ta inner join tqb_std_main tb on ta.c_std_main_id=tb.c_id where ta.n_status='1' ");

            if (strStdcode.Trim() != "")
            {
                strSql.Append(" and tb.c_std_code like '" + strStdcode + "%' ");
            }

            if (strGrd.Trim() != "")
            {
                strSql.Append(" and tb.c_stl_grd like '" + strGrd + "%' ");
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据订单号获取质量设计变更信息
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns></returns>
        public DataSet GetDesignChange(string strOrderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ta.C_ID,ta.C_DELIVERY_STATE,tc.c_design_no as 质量设计号,td.c_std_code as 执行标准,tb.C_NO as 订单号,tb.c_stl_grd as 钢种,tb.c_mat_code as 物料编码,tb.c_mat_name as 物料名称, (select t.c_name from TS_USER t where t.c_account=ta.c_emp_id_bg)as 变更人,ta.d_mod_dt_bg as 变更时间,(select t.c_name from TS_USER t where t.c_account=ta.c_emp_id_sh)as 审核人,ta.d_mod_dt_sh as 审核时间,decode(ta.n_status,0,'停用',1,'可用',2,'待审核')as 状态  from TQB_DESIGN_ORDER ta inner join tmo_condetails tb on ta.c_order_id=tb.c_no inner join tqb_design tc on ta.c_design_id=tc.c_id inner join tb_std_config td on td.c_std_id=tc.c_std_main_id where 1=1 ");

            if (strOrderNo.Trim() != "")
            {
                strSql.Append(" and tb.c_no='" + strOrderNo + "' ");
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TQB_DESIGN_ORDER ");
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
            strSql.Append(")AS Row, T.*  from TQB_DESIGN_ORDER T ");
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
					new OracleParameter(":PageSize", OracleType.Number),
					new OracleParameter(":PageIndex", OracleType.Number),
					new OracleParameter(":IsReCount", OracleType.Clob),
					new OracleParameter(":OrderType", OracleType.Clob),
					new OracleParameter(":strWhere", OracleDbType.Varchar2,1000),
					};
			parameters[0].Value = "TQB_DESIGN_ORDER";
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

