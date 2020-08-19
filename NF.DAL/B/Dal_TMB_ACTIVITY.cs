using System;
using System.Data;
using System.Text;
using NF.MODEL;
using Oracle.ManagedDataAccess.Client;
using System.Collections;
using System.Collections.Generic;

namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMB_ACTIVITY
    /// </summary>
    public partial class Dal_TMB_ACTIVITY
    {
        public Dal_TMB_ACTIVITY()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMB_ACTIVITY");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMB_ACTIVITY model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMB_ACTIVITY(");
            strSql.Append("C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,N_PRICE,N_PRICE2,C_EMP_ID,C_EMP_NAME,C_AREAMAX,C_PROD_NAME,D_START_DT,D_END_DT)");
            strSql.Append(" values (");
            strSql.Append(":C_MAT_CODE,:C_MAT_NAME,:C_STL_GRD,:C_SPEC,:N_PRICE,:N_PRICE2,:C_EMP_ID,:C_EMP_NAME,:C_AREAMAX,:C_PROD_NAME,:D_START_DT,:D_END_DT)");
            OracleParameter[] parameters = {

                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_PRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_PRICE2", OracleDbType.Decimal,15),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AREAMAX", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_START_DT", OracleDbType.Date),
                    new OracleParameter(":D_END_DT", OracleDbType.Date)};

            parameters[0].Value = model.C_MAT_CODE;
            parameters[1].Value = model.C_MAT_NAME;
            parameters[2].Value = model.C_STL_GRD;
            parameters[3].Value = model.C_SPEC;
            parameters[4].Value = model.N_PRICE;
            parameters[5].Value = model.N_PRICE2;
            parameters[6].Value = model.C_EMP_ID;
            parameters[7].Value = model.C_EMP_NAME;
            parameters[8].Value = model.C_AREAMAX;
            parameters[9].Value = model.C_PROD_NAME;
            parameters[10].Value = model.D_START_DT;
            parameters[11].Value = model.D_END_DT;

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
        public bool Update(Mod_TMB_ACTIVITY model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMB_ACTIVITY set ");
            strSql.Append("C_MAT_CODE=:C_MAT_CODE,");
            strSql.Append("C_MAT_NAME=:C_MAT_NAME,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_SPEC=:C_SPEC,");
            strSql.Append("N_PRICE=:N_PRICE,");
            strSql.Append("N_PRICE2=:N_PRICE2,");
            strSql.Append("C_STATUS=:C_STATUS,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("C_AREAMAX=:C_AREAMAX,");
            strSql.Append("C_PROD_NAME=:C_PROD_NAME,");
            strSql.Append("D_START_DT=:D_START_DT,");
            strSql.Append("D_END_DT=:D_END_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_PRICE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_PRICE2", OracleDbType.Decimal,15),
                    new OracleParameter(":C_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_AREAMAX", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_START_DT", OracleDbType.Date),
                    new OracleParameter(":D_END_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_MAT_CODE;
            parameters[1].Value = model.C_MAT_NAME;
            parameters[2].Value = model.C_STL_GRD;
            parameters[3].Value = model.C_SPEC;
            parameters[4].Value = model.N_PRICE;
            parameters[5].Value = model.N_PRICE2;
            parameters[6].Value = model.C_STATUS;
            parameters[7].Value = model.C_REMARK;
            parameters[8].Value = model.C_EMP_ID;
            parameters[9].Value = model.C_EMP_NAME;
            parameters[10].Value = model.D_MOD_DT;
            parameters[11].Value = model.C_AREAMAX;
            parameters[12].Value = model.C_PROD_NAME;
            parameters[13].Value = model.D_START_DT;
            parameters[14].Value = model.D_END_DT;
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
            strSql.Append("delete from TMB_ACTIVITY ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
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
            strSql.Append("delete from TMB_ACTIVITY ");
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
        public Mod_TMB_ACTIVITY GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,N_PRICE,N_PRICE2,C_STATUS,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_AREAMAX,C_PROD_NAME,D_START_DT,D_END_DT from TMB_ACTIVITY ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TMB_ACTIVITY model = new Mod_TMB_ACTIVITY();
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
        public Mod_TMB_ACTIVITY DataRowToModel(DataRow row)
        {
            Mod_TMB_ACTIVITY model = new Mod_TMB_ACTIVITY();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_MAT_CODE"] != null)
                {
                    model.C_MAT_CODE = row["C_MAT_CODE"].ToString();
                }
                if (row["C_MAT_NAME"] != null)
                {
                    model.C_MAT_NAME = row["C_MAT_NAME"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_SPEC"] != null)
                {
                    model.C_SPEC = row["C_SPEC"].ToString();
                }
                if (row["N_PRICE"] != null && row["N_PRICE"].ToString() != "")
                {
                    model.N_PRICE = decimal.Parse(row["N_PRICE"].ToString());
                }
                if (row["N_PRICE2"] != null && row["N_PRICE2"].ToString() != "")
                {
                    model.N_PRICE2 = decimal.Parse(row["N_PRICE2"].ToString());
                }
                if (row["C_STATUS"] != null && row["C_STATUS"].ToString() != "")
                {
                    model.C_STATUS = decimal.Parse(row["C_STATUS"].ToString());
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
                if (row["C_AREAMAX"] != null)
                {
                    model.C_AREAMAX = row["C_AREAMAX"].ToString();
                }
                if (row["C_PROD_NAME"] != null)
                {
                    model.C_PROD_NAME = row["C_PROD_NAME"].ToString();
                }
                if (row["D_START_DT"] != null && row["D_START_DT"].ToString() != "")
                {
                    model.D_START_DT = DateTime.Parse(row["D_START_DT"].ToString());
                }
                if (row["D_END_DT"] != null && row["D_END_DT"].ToString() != "")
                {
                    model.D_END_DT = DateTime.Parse(row["D_END_DT"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获取钢种单价-税率-折扣
        /// </summary>
        /// <param name="C_MAT_CODE">物料编码</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <param name="C_SPEC">规格</param>
        /// <returns></returns>
        public DataRow GetActivityRow(string c_mat_code, string c_stl_grd, string c_spec)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,N_PRICE,N_PRICE2,C_STATUS,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_AREAMAX,C_PROD_NAME,D_START_DT,D_END_DT ");
            strSql.Append(" FROM TMB_ACTIVITY where C_STATUS=1");
            if (!string.IsNullOrEmpty(c_mat_code))
            {
                strSql.Append(" and C_MAT_CODE='" + c_mat_code + "'");
            }
            if (!string.IsNullOrEmpty(c_stl_grd))
            {
                strSql.Append(" and UPPER(C_STL_GRD) like '%" + c_stl_grd.ToUpper() + "%'");
            }
            if (!string.IsNullOrEmpty(c_spec))
            {
                strSql.Append(" and C_SPEC like '%" + c_spec + "%'");
            }

            strSql.Append(" and to_date('" + DateTime.Now + "', 'yyyy-MM-dd HH24:mi:ss') >=D_START_DT");
            strSql.Append(" and to_date('" + DateTime.Now + "', 'yyyy-MM-dd HH24:mi:ss') <=D_END_DT");

            return DbHelperOra.GetDataRow(strSql.ToString());
        }

        /// <summary>
        /// 获取钢种单价-税率-折扣
        /// </summary>
        /// <param name="C_MAT_CODE">物料编码</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <param name="C_SPEC">规格</param>
        /// <returns></returns>
        public DataSet GetActivityList(string c_mat_code, string c_stl_grd, string c_spec)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,N_PRICE,N_PRICE2,C_STATUS,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_AREAMAX,C_PROD_NAME,D_START_DT,D_END_DT ");
            strSql.Append(" FROM TMB_ACTIVITY where C_STATUS=1");
            if (!string.IsNullOrEmpty(c_mat_code))
            {
                strSql.Append(" and C_MAT_CODE='" + c_mat_code + "'");
            }
            if (!string.IsNullOrEmpty(c_stl_grd))
            {
                strSql.Append(" and UPPER(C_STL_GRD) like '%" + c_stl_grd.ToUpper() + "%'");
            }
            if (!string.IsNullOrEmpty(c_spec))
            {
                strSql.Append(" and C_SPEC like '%" + c_spec + "%'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string Start, string End, string AreaMax)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,N_PRICE,N_PRICE2,C_STATUS,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_AREAMAX,C_PROD_NAME,D_START_DT,D_END_DT ");
            strSql.Append(" FROM TMB_ACTIVITY where  C_STATUS=1");

            strSql.Append(" and C_AREAMAX='" + AreaMax + "'");
            strSql.Append(" and to_date('" + Start + "', 'yyyy-MM-dd HH24:mi:ss')>=D_START_DT");
            strSql.Append(" and to_date('" + End + "', 'yyyy-MM-dd HH24:mi:ss')<=D_END_DT");

            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string C_PROD_NAME, string AreaMax, string C_MAT_CODE, string C_STL_GRD, string C_SPEC, string Start, string End)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,N_PRICE,N_PRICE2,C_STATUS,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_AREAMAX,C_PROD_NAME,D_START_DT,D_END_DT ");
            strSql.Append(" FROM TMB_ACTIVITY where 1=1");

            if (!string.IsNullOrEmpty(C_PROD_NAME))
            {
                strSql.Append(" and C_PROD_NAME='" + C_PROD_NAME + "'");
            }
            if (!string.IsNullOrEmpty(AreaMax))
            {
                strSql.Append(" and C_AREAMAX='" + AreaMax + "'");
            }
            if (!string.IsNullOrEmpty(C_MAT_CODE))
            {
                strSql.Append(" and C_MAT_CODE like '%" + C_MAT_CODE + "%'");
            }
            if (!string.IsNullOrEmpty(C_STL_GRD))
            {
                strSql.Append(" and UPPER(C_STL_GRD) like '%" + C_STL_GRD.ToUpper() + "%'");
            }
            if (!string.IsNullOrEmpty(C_SPEC))
            {
                strSql.Append(" and C_SPEC like '%" + C_SPEC + "%'");
            }

            if (!string.IsNullOrEmpty(Start) && !string.IsNullOrEmpty(End))
            {
                strSql.Append(" and D_START_DT>= to_date('" + Start + "', 'yyyy-MM-dd HH24:mi:ss')");
                strSql.Append(" and D_END_DT<=  to_date('" + End + "', 'yyyy-MM-dd HH24:mi:ss')");
            }



            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,N_PRICE,N_DISCOUNT,N_RATE,N_ORIMOTO,C_STATUS,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,D_START_DT,D_END_DT,C_AREAMAX,N_PRICE2,C_INVSHORTNAME ");
            strSql.Append(" FROM TMB_ACTIVITY ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }



        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string matCode, string STLGRD, string SPEC, string start_dt, string end_dt, string matName, string Area)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM  TMB_ACTIVITY   where 1=1");

            if (!string.IsNullOrEmpty(Area))
            {
                strSql.Append(" and C_AREAMAX='" + Area + "'");
            }


            if (!string.IsNullOrEmpty(matName))
            {
                strSql.Append(" and C_PROD_NAME='" + matName + "'");
            }

            if (!string.IsNullOrEmpty(matCode))
            {
                strSql.Append(" and C_MAT_CODE like '%" + matCode + "%'");
            }
            if (!string.IsNullOrEmpty(STLGRD))
            {
                strSql.Append(" and UPPER(C_STL_GRD) like '%" + STLGRD.ToUpper() + "%'");
            }
            if (!string.IsNullOrEmpty(SPEC))
            {
                strSql.Append(" and C_SPEC like '%" + SPEC + "%'");
            }
            if (!string.IsNullOrEmpty(start_dt) && !string.IsNullOrEmpty(end_dt))
            {
                strSql.Append(" and to_date('" + start_dt + "', 'yyyy-MM-dd HH24:mi:ss') >=D_START_DT");
                strSql.Append(" and to_date('" + end_dt + "', 'yyyy-MM-dd HH24:mi:ss') <=D_END_DT");
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
        public DataSet GetListByPage(int pageSize, int startIndex, string matCode, string STLGRD, string SPEC, string start_dt, string end_dt, string matName, string Area)
        {
            StringBuilder where = new StringBuilder();

            string item = "C_ID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,N_PRICE,N_PRICE2,C_STATUS,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_AREAMAX,C_PROD_NAME,D_START_DT,D_END_DT";
            string table = "TMB_ACTIVITY";

            string order = " D_MOD_DT asc";

            if (!string.IsNullOrEmpty(Area))
            {
                where.Append(" and C_AREAMAX='" + Area + "'");
            }

            if (!string.IsNullOrEmpty(matName))
            {
                where.Append(" and C_INVSHORTNAME='" + matName + "'");
            }

            if (!string.IsNullOrEmpty(matCode))
            {
                where.Append(" and C_MAT_CODE like '%" + matCode + "%'");
            }
            if (!string.IsNullOrEmpty(STLGRD))
            {
                where.Append(" and C_STL_GRD like '%" + STLGRD + "%'");
            }
            if (!string.IsNullOrEmpty(SPEC))
            {
                where.Append(" and C_SPEC like '%" + SPEC + "%'");
            }

            if (!string.IsNullOrEmpty(start_dt) && !string.IsNullOrEmpty(end_dt))
            {
                where.Append(" and to_date('" + start_dt + "', 'yyyy-MM-dd HH24:mi:ss') >=D_START_DT");
                where.Append(" and to_date('" + end_dt + "', 'yyyy-MM-dd HH24:mi:ss') <=D_END_DT");
            }


            string sql = ByPage.GenerateByPageSql(pageSize, startIndex, item, table, order, where.ToString());
            return DbHelperOra.Query(sql);

        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="activityList"></param>
        /// <returns></returns>
        public bool UpdateMatCode(List<Mod_TMB_ACTIVITY> activityList)
        {
            ArrayList arraySql = new ArrayList();

            for (int i = 0; i < activityList.Count; i++)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update TMB_ACTIVITY set ");
                strSql.Append("N_PRICE=" + activityList[i].N_PRICE + ",");
                strSql.Append("N_PRICE2=" + activityList[i].N_PRICE + ",");
                strSql.Append("C_EMP_ID='" + activityList[i].C_EMP_ID + "',");
                strSql.Append("C_EMP_NAME='" + activityList[i].C_EMP_NAME + "'");
                strSql.Append(" where C_ID='" + activityList[i].C_ID + "' ");
                arraySql.Add(strSql.ToString());
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        #endregion  BasicMethod

    }
}

