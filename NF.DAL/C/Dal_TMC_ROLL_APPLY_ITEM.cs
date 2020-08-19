using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using System.Collections.Generic;
using System.Collections;

namespace NF.DAL
{
    /// <summary>
    /// 资源申请数据列表
    /// </summary>
    public partial class Dal_TMC_ROLL_APPLY_ITEM
    {
        public Dal_TMC_ROLL_APPLY_ITEM()
        { }
        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMC_ROLL_APPLY_ITEM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMC_ROLL_APPLY_ITEM(");
            strSql.Append("C_ID,C_PKID,C_NEEDAREA,C_NEEDCUST,C_ZYAREA,C_ZYCUST,C_SPEC,C_STL_GRD,C_WGT,C_QUA,C_REMARK,C_VFREE1,C_VFREE2,C_VFREE3,C_VFREE4,C_VFREE5,C_ZYCON)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_PKID,:C_NEEDAREA,:C_NEEDCUST,:C_ZYAREA,:C_ZYCUST,:C_SPEC,:C_STL_GRD,:C_WGT,:C_QUA,:C_REMARK,:C_VFREE1,:C_VFREE2,:C_VFREE3,:C_VFREE4,:C_VFREE5,:C_ZYCON)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PKID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NEEDAREA", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_NEEDCUST", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_ZYAREA", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_ZYCUST", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_WGT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_QUA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_VFREE1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_VFREE2", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_VFREE3", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_VFREE4", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_VFREE5", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZYCON", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_PKID;
            parameters[2].Value = model.C_NEEDAREA;
            parameters[3].Value = model.C_NEEDCUST;
            parameters[4].Value = model.C_ZYAREA;
            parameters[5].Value = model.C_ZYCUST;
            parameters[6].Value = model.C_SPEC;
            parameters[7].Value = model.C_STL_GRD;
            parameters[8].Value = model.C_WGT;
            parameters[9].Value = model.C_QUA;
            parameters[10].Value = model.C_REMARK;
            parameters[11].Value = model.C_VFREE1;
            parameters[12].Value = model.C_VFREE2;
            parameters[13].Value = model.C_VFREE3;
            parameters[14].Value = model.C_VFREE4;
            parameters[15].Value = model.C_VFREE5;
            parameters[16].Value = model.C_ZYCON;


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
        public bool Update(Mod_TMC_ROLL_APPLY_ITEM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMC_ROLL_APPLY_ITEM set ");
            strSql.Append("C_ID=:C_ID,");
            strSql.Append("C_PKID=:C_PKID,");
            strSql.Append("C_NEEDAREA=:C_NEEDAREA,");
            strSql.Append("C_NEEDCUST=:C_NEEDCUST,");
            strSql.Append("C_ZYAREA=:C_ZYAREA,");
            strSql.Append("C_ZYCUST=:C_ZYCUST,");
            strSql.Append("C_SPEC=:C_SPEC,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_WGT=:C_WGT,");
            strSql.Append("C_QUA=:C_QUA,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_VFREE1=:C_VFREE1,");
            strSql.Append("C_VFREE2=:C_VFREE2,");
            strSql.Append("C_VFREE3=:C_VFREE3,");
            strSql.Append("C_VFREE4=:C_VFREE4,");
            strSql.Append("C_VFREE5=:C_VFREE5,");
            strSql.Append("D_MOD=:D_MOD");
            strSql.Append(" where ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PKID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NEEDAREA", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_NEEDCUST", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_ZYAREA", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_ZYCUST", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_WGT", OracleDbType.Decimal,100),
                    new OracleParameter(":C_QUA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_VFREE1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_VFREE2", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_VFREE3", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_VFREE4", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_VFREE5", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD", OracleDbType.Date)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_PKID;
            parameters[2].Value = model.C_NEEDAREA;
            parameters[3].Value = model.C_NEEDCUST;
            parameters[4].Value = model.C_ZYAREA;
            parameters[5].Value = model.C_ZYCUST;
            parameters[6].Value = model.C_SPEC;
            parameters[7].Value = model.C_STL_GRD;
            parameters[8].Value = model.C_WGT;
            parameters[9].Value = model.C_QUA;
            parameters[10].Value = model.C_REMARK;
            parameters[11].Value = model.C_VFREE1;
            parameters[12].Value = model.C_VFREE2;
            parameters[13].Value = model.C_VFREE3;
            parameters[14].Value = model.C_VFREE4;
            parameters[15].Value = model.C_VFREE5;
            parameters[16].Value = model.D_MOD;

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
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TMC_ROLL_APPLY_ITEM ");
            strSql.Append(" where ");
            OracleParameter[] parameters = {
            };

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

        public bool DelList(List<Mod_TMC_ROLL_APPLY_ITEM> list)
        {
            ArrayList arraySql = new ArrayList();
            foreach (var item in list)
            {
                arraySql.Add("DELETE FROM TMC_ROLL_APPLY_ITEM WHERE C_ID='" + item.C_ID + "'");
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMC_ROLL_APPLY_ITEM GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_PKID,C_NEEDAREA,C_NEEDCUST,C_ZYAREA,C_ZYCUST,C_SPEC,C_STL_GRD,C_WGT,C_QUA,C_REMARK,C_VFREE1,C_VFREE2,C_VFREE3,C_VFREE4,C_VFREE5,D_MOD from TMC_ROLL_APPLY_ITEM ");
            strSql.Append(" where ");
            OracleParameter[] parameters = {
            };

            Mod_TMC_ROLL_APPLY_ITEM model = new Mod_TMC_ROLL_APPLY_ITEM();
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
        public Mod_TMC_ROLL_APPLY_ITEM DataRowToModel(DataRow row)
        {
            Mod_TMC_ROLL_APPLY_ITEM model = new Mod_TMC_ROLL_APPLY_ITEM();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_PKID"] != null)
                {
                    model.C_PKID = row["C_PKID"].ToString();
                }
                if (row["C_NEEDAREA"] != null)
                {
                    model.C_NEEDAREA = row["C_NEEDAREA"].ToString();
                }
                if (row["C_NEEDCUST"] != null)
                {
                    model.C_NEEDCUST = row["C_NEEDCUST"].ToString();
                }
                if (row["C_ZYAREA"] != null)
                {
                    model.C_ZYAREA = row["C_ZYAREA"].ToString();
                }
                if (row["C_ZYCUST"] != null)
                {
                    model.C_ZYCUST = row["C_ZYCUST"].ToString();
                }
                if (row["C_SPEC"] != null)
                {
                    model.C_SPEC = row["C_SPEC"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_WGT"] != null)
                {
                    model.C_WGT = Convert.ToDecimal(row["C_WGT"].ToString());
                }
                if (row["C_QUA"] != null)
                {
                    model.C_QUA = row["C_QUA"].ToString();
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["C_VFREE1"] != null)
                {
                    model.C_VFREE1 = row["C_VFREE1"].ToString();
                }
                if (row["C_VFREE2"] != null)
                {
                    model.C_VFREE2 = row["C_VFREE2"].ToString();
                }
                if (row["C_VFREE3"] != null)
                {
                    model.C_VFREE3 = row["C_VFREE3"].ToString();
                }
                if (row["C_VFREE4"] != null)
                {
                    model.C_VFREE4 = row["C_VFREE4"].ToString();
                }
                if (row["C_VFREE5"] != null)
                {
                    model.C_VFREE5 = row["C_VFREE5"].ToString();
                }
                if (row["D_MOD"] != null && row["D_MOD"].ToString() != "")
                {
                    model.D_MOD = DateTime.Parse(row["D_MOD"].ToString());
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
            strSql.Append("select * ");
            strSql.Append(" FROM TMC_ROLL_APPLY_ITEM ");
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
            strSql.Append("select count(1) FROM TMC_ROLL_APPLY_ITEM ");
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
            strSql.Append(")AS Row, T.*  from TMC_ROLL_APPLY_ITEM T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }



        #endregion  BasicMethod

    }
}

