using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using NF.MODEL;

namespace NF.DAL
{
    /// <summary>
    /// 物料主数据表
    /// </summary>
    public partial class Dal_TB_MATRL_MAIN
    {
        public Dal_TB_MATRL_MAIN()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TB_MATRL_MAIN");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TB_MATRL_MAIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TB_MATRL_MAIN(");
            strSql.Append("C_ID,C_MAT_CODE,C_MAT_NAME,C_MAT_GROUP_CODE,C_MAT_GROUP_NAME,C_PROD_KIND,C_PROD_NAME,C_STL_GRD,C_SPEC,C_EMP_ID,D_MOD_DT,N_THK,N_WTH,N_LTH,C_MAT_TYPE,C_IS_VISIBLE,C_CLS_TYPE,C_REMARK1,C_REMARK2,C_REMARK3,C_NC_PK,C_PK_INVCL,C_PK_INVBASDOC,C_PK_INVMANDOC,C_PK_PRODUCE,C_PK_MEASDOC,C_PK_TAXITEMS,C_INVSHORTNAME)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_MAT_CODE,:C_MAT_NAME,:C_MAT_GROUP_CODE,:C_MAT_GROUP_NAME,:C_PROD_KIND,:C_PROD_NAME,:C_STL_GRD,:C_SPEC,:C_EMP_ID,:D_MOD_DT,:N_THK,:N_WTH,:N_LTH,:C_MAT_TYPE,:C_IS_VISIBLE,:C_CLS_TYPE,:C_REMARK1,:C_REMARK2,:C_REMARK3,:C_NC_PK,:C_PK_INVCL,:C_PK_INVBASDOC,:C_PK_INVMANDOC,:C_PK_PRODUCE,:C_PK_MEASDOC,:C_PK_TAXITEMS,:C_INVSHORTNAME)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_MAT_GROUP_CODE", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_MAT_GROUP_NAME", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_PROD_KIND", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_PROD_NAME", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":N_THK", OracleDbType.Decimal,15),
                    new OracleParameter(":N_WTH", OracleDbType.Decimal,15),
                    new OracleParameter(":N_LTH", OracleDbType.Decimal,15),
                    new OracleParameter(":C_MAT_TYPE", OracleDbType.Int32,1),
                    new OracleParameter(":C_IS_VISIBLE", OracleDbType.Int32,1),
                    new OracleParameter(":C_CLS_TYPE", OracleDbType.Varchar2,1),
                    new OracleParameter(":C_REMARK1", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_REMARK2", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_REMARK3", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_NC_PK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PK_INVCL", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_PK_INVBASDOC", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_PK_INVMANDOC", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_PK_PRODUCE", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_PK_MEASDOC", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_PK_TAXITEMS", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_INVSHORTNAME", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_MAT_CODE;
            parameters[2].Value = model.C_MAT_NAME;
            parameters[3].Value = model.C_MAT_GROUP_CODE;
            parameters[4].Value = model.C_MAT_GROUP_NAME;
            parameters[5].Value = model.C_PROD_KIND;
            parameters[6].Value = model.C_PROD_NAME;
            parameters[7].Value = model.C_STL_GRD;
            parameters[8].Value = model.C_SPEC;
            parameters[9].Value = model.C_EMP_ID;
            parameters[10].Value = model.D_MOD_DT;
            parameters[11].Value = model.N_THK;
            parameters[12].Value = model.N_WTH;
            parameters[13].Value = model.N_LTH;
            parameters[14].Value = model.C_MAT_TYPE;
            parameters[15].Value = model.C_IS_VISIBLE;
            parameters[16].Value = model.C_CLS_TYPE;
            parameters[17].Value = model.C_REMARK1;
            parameters[18].Value = model.C_REMARK2;
            parameters[19].Value = model.C_REMARK3;
            parameters[20].Value = model.C_NC_PK;
            parameters[21].Value = model.C_PK_INVCL;
            parameters[22].Value = model.C_PK_INVBASDOC;
            parameters[23].Value = model.C_PK_INVMANDOC;
            parameters[24].Value = model.C_PK_PRODUCE;
            parameters[25].Value = model.C_PK_MEASDOC;
            parameters[26].Value = model.C_PK_TAXITEMS;
            parameters[27].Value = model.C_INVSHORTNAME;

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
        public bool Update(Mod_TB_MATRL_MAIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TB_MATRL_MAIN set ");
            strSql.Append("C_MAT_CODE=:C_MAT_CODE,");
            strSql.Append("C_MAT_NAME=:C_MAT_NAME,");
            strSql.Append("C_MAT_GROUP_CODE=:C_MAT_GROUP_CODE,");
            strSql.Append("C_MAT_GROUP_NAME=:C_MAT_GROUP_NAME,");
            strSql.Append("C_PROD_KIND=:C_PROD_KIND,");
            strSql.Append("C_PROD_NAME=:C_PROD_NAME,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_SPEC=:C_SPEC,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("N_THK=:N_THK,");
            strSql.Append("N_WTH=:N_WTH,");
            strSql.Append("N_LTH=:N_LTH,");
            strSql.Append("C_MAT_TYPE=:C_MAT_TYPE,");
            strSql.Append("C_IS_VISIBLE=:C_IS_VISIBLE,");
            strSql.Append("C_CLS_TYPE=:C_CLS_TYPE,");
            strSql.Append("C_REMARK1=:C_REMARK1,");
            strSql.Append("C_REMARK2=:C_REMARK2,");
            strSql.Append("C_REMARK3=:C_REMARK3,");
            strSql.Append("C_NC_PK=:C_NC_PK,");
            strSql.Append("C_PK_INVCL=:C_PK_INVCL,");
            strSql.Append("C_PK_INVBASDOC=:C_PK_INVBASDOC,");
            strSql.Append("C_PK_INVMANDOC=:C_PK_INVMANDOC,");
            strSql.Append("C_PK_PRODUCE=:C_PK_PRODUCE,");
            strSql.Append("C_PK_MEASDOC=:C_PK_MEASDOC,");
            strSql.Append("C_PK_TAXITEMS=:C_PK_TAXITEMS,");
            strSql.Append("C_INVSHORTNAME=:C_INVSHORTNAME");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_MAT_GROUP_CODE", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_MAT_GROUP_NAME", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_PROD_KIND", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_PROD_NAME", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":N_THK", OracleDbType.Decimal,15),
                    new OracleParameter(":N_WTH", OracleDbType.Decimal,15),
                    new OracleParameter(":N_LTH", OracleDbType.Decimal,15),
                    new OracleParameter(":C_MAT_TYPE", OracleDbType.Int32,1),
                    new OracleParameter(":C_IS_VISIBLE", OracleDbType.Int32,1),
                    new OracleParameter(":C_CLS_TYPE", OracleDbType.Varchar2,1),
                    new OracleParameter(":C_REMARK1", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_REMARK2", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_REMARK3", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_NC_PK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PK_INVCL", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_PK_INVBASDOC", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_PK_INVMANDOC", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_PK_PRODUCE", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_PK_MEASDOC", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_PK_TAXITEMS", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_INVSHORTNAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_MAT_CODE;
            parameters[1].Value = model.C_MAT_NAME;
            parameters[2].Value = model.C_MAT_GROUP_CODE;
            parameters[3].Value = model.C_MAT_GROUP_NAME;
            parameters[4].Value = model.C_PROD_KIND;
            parameters[5].Value = model.C_PROD_NAME;
            parameters[6].Value = model.C_STL_GRD;
            parameters[7].Value = model.C_SPEC;
            parameters[8].Value = model.C_EMP_ID;
            parameters[9].Value = model.D_MOD_DT;
            parameters[10].Value = model.N_THK;
            parameters[11].Value = model.N_WTH;
            parameters[12].Value = model.N_LTH;
            parameters[13].Value = model.C_MAT_TYPE;
            parameters[14].Value = model.C_IS_VISIBLE;
            parameters[15].Value = model.C_CLS_TYPE;
            parameters[16].Value = model.C_REMARK1;
            parameters[17].Value = model.C_REMARK2;
            parameters[18].Value = model.C_REMARK3;
            parameters[19].Value = model.C_NC_PK;
            parameters[20].Value = model.C_PK_INVCL;
            parameters[21].Value = model.C_PK_INVBASDOC;
            parameters[22].Value = model.C_PK_INVMANDOC;
            parameters[23].Value = model.C_PK_PRODUCE;
            parameters[24].Value = model.C_PK_MEASDOC;
            parameters[25].Value = model.C_PK_TAXITEMS;
            parameters[26].Value = model.C_INVSHORTNAME;
            parameters[27].Value = model.C_ID;

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
            strSql.Append("delete from TB_MATRL_MAIN ");
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
            strSql.Append("delete from TB_MATRL_MAIN ");
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
        public Mod_TB_MATRL_MAIN GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_MAT_CODE,C_MAT_NAME,C_MAT_GROUP_CODE,C_MAT_GROUP_NAME,C_PROD_KIND,C_PROD_NAME,C_STL_GRD,C_SPEC,C_EMP_ID,D_MOD_DT,N_THK,N_WTH,N_LTH,C_MAT_TYPE,C_CLS_TYPE,C_REMARK1,C_REMARK2,C_REMARK3,C_NC_PK,C_PK_INVCL,C_PK_INVBASDOC,C_PK_INVMANDOC,C_PK_PRODUCE,C_PK_MEASDOC,C_PK_TAXITEMS,C_INVSHORTNAME,N_ISGPS,C_IS_VISIBLE,C_FJLDW,N_HSL,C_ZJLDWMC,C_FJLDWMC from TB_MATRL_MAIN ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = C_ID;

            Mod_TB_MATRL_MAIN model = new Mod_TB_MATRL_MAIN();
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
        /// <param name="C_PK_INVMANDOC">存货管理档案主键</param>
        /// <returns></returns>
        public Mod_TB_MATRL_MAIN GetMatModel(string C_PK_INVMANDOC)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_MAT_CODE,C_MAT_NAME,C_MAT_GROUP_CODE,C_MAT_GROUP_NAME,C_PROD_KIND,C_PROD_NAME,C_STL_GRD,C_SPEC,C_EMP_ID,D_MOD_DT,N_THK,N_WTH,N_LTH,C_MAT_TYPE,C_CLS_TYPE,C_REMARK1,C_REMARK2,C_REMARK3,C_NC_PK,C_PK_INVCL,C_PK_INVBASDOC,C_PK_INVMANDOC,C_PK_PRODUCE,C_PK_MEASDOC,C_PK_TAXITEMS,C_INVSHORTNAME,N_ISGPS,C_IS_VISIBLE,C_FJLDW,N_HSL,C_ZJLDWMC,C_FJLDWMC from TB_MATRL_MAIN ");
            strSql.Append(" where C_PK_INVMANDOC=:C_PK_INVMANDOC ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_PK_INVMANDOC", OracleDbType.Varchar2,100)};
            parameters[0].Value = C_PK_INVMANDOC;

            Mod_TB_MATRL_MAIN model = new Mod_TB_MATRL_MAIN();
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
        public Mod_TB_MATRL_MAIN DataRowToModel(DataRow row)
        {
            Mod_TB_MATRL_MAIN model = new Mod_TB_MATRL_MAIN();
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
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_SPEC"] != null)
                {
                    model.C_SPEC = row["C_SPEC"].ToString();
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["D_MOD_DT"] != null && row["D_MOD_DT"].ToString() != "")
                {
                    model.D_MOD_DT = DateTime.Parse(row["D_MOD_DT"].ToString());
                }
                if (row["N_THK"] != null && row["N_THK"].ToString() != "")
                {
                    model.N_THK = decimal.Parse(row["N_THK"].ToString());
                }
                if (row["N_WTH"] != null && row["N_WTH"].ToString() != "")
                {
                    model.N_WTH = decimal.Parse(row["N_WTH"].ToString());
                }
                if (row["N_LTH"] != null && row["N_LTH"].ToString() != "")
                {
                    model.N_LTH = decimal.Parse(row["N_LTH"].ToString());
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
                if (row["C_NC_PK"] != null)
                {
                    model.C_NC_PK = row["C_NC_PK"].ToString();
                }
                if (row["C_PK_INVCL"] != null)
                {
                    model.C_PK_INVCL = row["C_PK_INVCL"].ToString();
                }
                if (row["C_PK_INVBASDOC"] != null)
                {
                    model.C_PK_INVBASDOC = row["C_PK_INVBASDOC"].ToString();
                }
                if (row["C_PK_INVMANDOC"] != null)
                {
                    model.C_PK_INVMANDOC = row["C_PK_INVMANDOC"].ToString();
                }
                if (row["C_PK_PRODUCE"] != null)
                {
                    model.C_PK_PRODUCE = row["C_PK_PRODUCE"].ToString();
                }
                if (row["C_PK_MEASDOC"] != null)
                {
                    model.C_PK_MEASDOC = row["C_PK_MEASDOC"].ToString();
                }
                if (row["C_PK_TAXITEMS"] != null)
                {
                    model.C_PK_TAXITEMS = row["C_PK_TAXITEMS"].ToString();
                }
                if (row["C_INVSHORTNAME"] != null)
                {
                    model.C_INVSHORTNAME = row["C_INVSHORTNAME"].ToString();
                }
                if (row["N_ISGPS"] != null && row["N_ISGPS"].ToString() != "")
                {
                    model.N_ISGPS = decimal.Parse(row["N_ISGPS"].ToString());
                }
                if (row["C_IS_VISIBLE"] != null && row["C_IS_VISIBLE"].ToString() != "")
                {
                    model.C_IS_VISIBLE = decimal.Parse(row["C_IS_VISIBLE"].ToString());
                }
                if (row["C_FJLDW"] != null)
                {
                    model.C_FJLDW = row["C_FJLDW"].ToString();
                }
                if (row["N_HSL"] != null && row["N_HSL"].ToString() != "")
                {
                    model.N_HSL = decimal.Parse(row["N_HSL"].ToString());
                }
                if (row["C_ZJLDWMC"] != null)
                {
                    model.C_ZJLDWMC = row["C_ZJLDWMC"].ToString();
                }
                if (row["C_FJLDWMC"] != null)
                {
                    model.C_FJLDWMC = row["C_FJLDWMC"].ToString();
                }
            }
            return model;
        }


        /// <summary>
        /// 获取大类钢种
        /// </summary>
        public DataSet GetMaxGRD()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct t.c_prod_name from TB_MATRL_MAIN t where t.c_prod_name is not null");

            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_MAT_CODE,C_MAT_NAME,C_MAT_GROUP_CODE,C_MAT_GROUP_NAME,C_PROD_KIND,C_PROD_NAME,C_STL_GRD,C_SPEC,C_EMP_ID,D_MOD_DT,N_THK,N_WTH,N_LTH,C_MAT_TYPE,C_CLS_TYPE,C_REMARK1,C_REMARK2,C_REMARK3,C_NC_PK,C_PK_INVCL,C_PK_INVBASDOC,C_PK_INVMANDOC,C_PK_PRODUCE,C_PK_MEASDOC,C_PK_TAXITEMS,C_INVSHORTNAME,N_ISGPS,C_IS_VISIBLE,C_FJLDW,N_HSL");
            strSql.Append(" FROM TB_MATRL_MAIN ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取物料数据列表
        /// </summary>
        /// <param name="stlGrd">钢种</param>
        /// <param name="specMin">规格最小值</param>
        /// <param name="specMax">规格最大值</param>
        /// <param name="matClass"></param>
        /// <returns></returns>
        public DataSet GetMatList(string stlGrd, string specMin, string specMax, string matClass, string matType)
        {
            StringBuilder strSql = new StringBuilder();
            if (matType == "8")
            {
                #region //线材
                strSql.Append(@"select C_ID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,C_MAT_GROUP_CODE
                              from TB_MATRL_MAIN t
                             where t.C_MAT_TYPE = 8  and  t.C_IS_VISIBLE=1  
                               and instr(t.c_spec, 'φ') > 0
                               and instr(t.c_spec, '*') = 0");

                if (!string.IsNullOrEmpty(matClass))
                {
                    strSql.Append(" and t.C_MAT_GROUP_CODE='" + matClass + "'");
                }

                if (!string.IsNullOrEmpty(stlGrd))
                {
                    strSql.Append(" and UPPER(t.C_STL_GRD) like  '%" + stlGrd.ToUpper() + "%'");
                }

                if (!string.IsNullOrEmpty(specMin) && !string.IsNullOrEmpty(specMax))
                {
                    strSql.Append(" and to_number(substr(t.c_spec, 2)) >=" + specMin + "  and to_number(substr(t.c_spec, 2)) <= " + specMax + "");
                }
                strSql.Append(" order by  to_number(substr(t.c_spec, 2)) asc,t.c_stl_grd  ");
                #endregion
            }
            else
            {
                #region //钢坯
                strSql.Append(@"select C_ID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,C_MAT_GROUP_CODE
                              from TB_MATRL_MAIN t
                             where t.C_MAT_TYPE = 6  and  t.C_IS_VISIBLE=1");

                if (!string.IsNullOrEmpty(matClass))
                {
                    strSql.Append(" and t.C_MAT_GROUP_CODE='" + matClass + "'");
                }

                if (!string.IsNullOrEmpty(stlGrd))
                {
                    strSql.Append(" and UPPER(t.C_STL_GRD) like  '%" + stlGrd.ToUpper() + "%'");
                }

                strSql.Append(" order by t.c_spec asc,t.c_stl_grd  ");
                #endregion
            }


            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取物料数据列表
        /// </summary>
        /// <param name="matName">物料名称</param>
        /// <param name="matCode">物料编码</param>
        /// <param name="matSTLGRD">钢种</param>
        /// <param name="matSPEC">规格</param>
        /// <param name="groupCode">物料组编码</param>
        /// <returns></returns>
        public DataSet GetList(string matName, string matCode, string matSTLGRD, string matSPEC, string groupCode, string groupName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_MAT_CODE,C_MAT_NAME,C_MAT_GROUP_CODE,C_MAT_GROUP_NAME,C_PROD_KIND,C_PROD_NAME,C_STL_GRD,C_SPEC,C_EMP_ID,D_MOD_DT,N_THK,N_WTH,N_LTH,C_MAT_TYPE,C_IS_VISIBLE,C_CLS_TYPE,C_INVSHORTNAME,(SELECT T.N_TAXRATIO /100 FROM TMB_TAXITEMS T WHERE T.C_ID=C_PK_TAXITEMS) AS N_TAXRATIO ");
            strSql.Append(" FROM TB_MATRL_MAIN  where C_IS_VISIBLE=1");

            if (!string.IsNullOrEmpty(groupCode))
            {
                strSql.Append(" and C_MAT_GROUP_CODE='" + groupCode + "'");
            }

            if (!string.IsNullOrEmpty(groupName))
            {
                strSql.Append(" and C_MAT_GROUP_NAME like '%" + groupName + "%'");
            }

            if (!string.IsNullOrEmpty(matName))
            {
                strSql.Append(" and C_MAT_NAME like '%" + matName + "%'");
            }
            if (!string.IsNullOrEmpty(matCode))
            {
                strSql.Append(" and C_MAT_CODE = '" + matCode + "'");
            }
            if (!string.IsNullOrEmpty(matSTLGRD))
            {
                strSql.Append(" and UPPER(C_STL_GRD) like  '%" + matSTLGRD.ToUpper() + "%'");
            }
            if (!string.IsNullOrEmpty(matSPEC))
            {
                strSql.Append(" and C_SPEC like '%" + matSPEC + "%'");
            }
            strSql.Append(" order by C_MAT_NAME,C_STL_GRD,C_SPEC");

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 批量物料编码查询
        /// </summary>
        /// <param name="matcode"></param>
        /// <returns></returns>
        public DataSet GetList2(string matcode)
        {
            string[] arr = matcode.Split(',');
            List<string> list = new List<string>();
            if (arr.Length > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!string.IsNullOrEmpty(arr[i]))
                    {
                        list.Add("'" + arr[i] + "'");
                    }
                }
            }

            string result = string.Join(",", list);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_MAT_CODE,C_MAT_NAME,C_MAT_GROUP_CODE,C_MAT_GROUP_NAME,C_PROD_KIND,C_PROD_NAME,C_STL_GRD,C_SPEC,C_EMP_ID,D_MOD_DT,N_THK,N_WTH,N_LTH,C_MAT_TYPE,C_IS_VISIBLE,C_CLS_TYPE,C_INVSHORTNAME,(SELECT T.N_TAXRATIO /100 FROM TMB_TAXITEMS T WHERE T.C_ID=C_PK_TAXITEMS) AS N_TAXRATIO ");
            strSql.Append(" FROM TB_MATRL_MAIN  where C_IS_VISIBLE=1");

            if (!string.IsNullOrEmpty(result))
            {
                strSql.AppendFormat(" and C_MAT_CODE in({0})", result);
            }

            strSql.Append(" order by C_MAT_NAME,C_STL_GRD,C_SPEC");

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string matCode, string STLGRD, string SPEC)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TB_MATRL_MAIN where 1=1 ");

            if (!string.IsNullOrEmpty(matCode))
            {
                strSql.Append(" and C_MAT_CODE = '" + matCode + "'");
            }
            if (!string.IsNullOrEmpty(STLGRD))
            {
                strSql.Append(" and UPPER(C_STL_GRD) =  '" + STLGRD.ToUpper() + "'");
            }
            if (!string.IsNullOrEmpty(SPEC))
            {
                strSql.Append(" and C_SPEC like '%" + SPEC + "%'");
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
        public DataSet GetListByPage(int pageSize, int startIndex, string matCode, string STLGRD, string SPEC)
        {
            StringBuilder where = new StringBuilder();

            string item = "C_ID,C_MAT_CODE,C_MAT_NAME,C_MAT_GROUP_CODE,C_MAT_GROUP_NAME,C_PROD_KIND,C_PROD_NAME,C_STL_GRD,C_SPEC,C_EMP_ID,D_MOD_DT,N_THK,N_WTH,N_LTH,C_MAT_TYPE,C_IS_VISIBLE,C_CLS_TYPE,C_REMARK1,C_REMARK2,C_REMARK3,C_NC_PK,C_PK_INVCL,C_PK_INVBASDOC,C_PK_INVMANDOC,C_PK_PRODUCE,C_PK_MEASDOC,C_PK_TAXITEMS,C_INVSHORTNAME,N_ISGPS";
            string table = "TB_MATRL_MAIN";
            string order = " C_MAT_CODE asc";

            if (!string.IsNullOrEmpty(matCode))
            {
                where.Append(" and C_MAT_CODE like '%" + matCode + "%'");
            }
            if (!string.IsNullOrEmpty(STLGRD))
            {
                where.Append(" and UPPER(C_STL_GRD) like '%" + STLGRD.ToUpper() + "%'");
            }
            if (!string.IsNullOrEmpty(SPEC))
            {
                where.Append(" and C_SPEC like '%" + SPEC + "%'");
            }

            string sql = ByPage.GenerateByPageSql(pageSize, startIndex, item, table, order, where.ToString());
            return DbHelperOra.Query(sql);

        }

        #endregion  BasicMethod


        #region //钢种
        /// <summary>
        /// 获取钢种
        /// </summary>
        public DataSet GetStlGrd(string stlgrd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select distinct t.C_STL_GRD
                                  from TB_MATRL_MAIN t
                                 where t.C_STL_GRD is not null and UPPER(t.C_STL_GRD) like  '%{0}%'
                                 order by C_STL_GRD
                                ", stlgrd.ToUpper());

            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

        #region  //执行标准
        /// <summary>
        /// 获取执行标准
        /// </summary>
        /// <param name="stlGrd"></param>
        /// <returns></returns>
        public DataSet GetSTD(string stlGrd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select distinct t.c_id,t.c_std_code from TQB_STD_MAIN t where t.n_status=1 and UPPER(t.c_stl_grd) = '{0}'", stlGrd.ToUpper());
            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion

        #region//自由项1自由项组合

        /// <summary>
        /// 获取自由项
        /// </summary>
        /// <param name="stlgrd">钢种</param>
        /// <param name="std">执行标准</param>
        /// <returns></returns>
        public DataSet GetFree(string stlgrd, string std)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT CASE
         WHEN INSTR(BZ1, '协议') > 0 OR INSTR(BZ2, '普通要求') > 0 THEN
          BZ1
         ELSE
          BZ2
       END ZYX1,
       CASE
         WHEN INSTR(BZ2, '协议') > 0 OR INSTR(BZ1, '普通要求') > 0 THEN
          BZ1
         ELSE
          BZ2
       END ZYX2
  FROM (SELECT N.DOCNAME BZ1,
               CASE
                 WHEN INSTR('{1}', 'JSKZ') > 0 THEN
                  '{0}' || '~协议'
                 ELSE
                  '{0}' || '~普通要求'
               END BZ2
          FROM XGERP50.BD_DEFDOCLIST M, XGERP50.BD_DEFDOC N
         WHERE M.PK_DEFDOCLIST = N.PK_DEFDOCLIST
           AND (N.SEALFLAG = 'N' OR N.SEALFLAG IS NULL)
           AND N.DOCNAME LIKE '{0}~%'
           AND replace( replace( REPLACE(N.DOCNAME, ' ', ''),'（','('),'）',')') LIKE '%{1}')", stlgrd, std);
            return DbHelperNC.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取自由项
        /// </summary>
        /// <param name="stlgrd">钢种</param>
        /// <param name="std">执行标准</param>
        /// <returns></returns>
        public DataSet GetFree2(string stlgrd, string std)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT CASE
         WHEN INSTR(BZ1, '协议') > 0 OR INSTR(BZ2, '普通要求') > 0 THEN
          BZ1
         ELSE
          BZ2
       END ZYX1,
       CASE
         WHEN INSTR(BZ2, '协议') > 0 OR INSTR(BZ1, '普通要求') > 0 THEN
          BZ1
         ELSE
          BZ2
       END ZYX2
  FROM (SELECT N.DOCNAME BZ1,
               CASE
                 WHEN INSTR('{1}', 'JSKZ') > 0 THEN
                  '{0}' || '~协议'
                 ELSE
                  '{0}' || '~普通要求'
               END BZ2
          FROM XGERP50.BD_DEFDOCLIST M, XGERP50.BD_DEFDOC N
         WHERE M.PK_DEFDOCLIST = N.PK_DEFDOCLIST
           AND (N.SEALFLAG = 'N' OR N.SEALFLAG IS NULL)
           AND N.DOCNAME LIKE '{0}%'
           AND replace( replace( REPLACE(N.DOCNAME, ' ', ''),'（','('),'）',')') LIKE '%{1}')", stlgrd, std);
            return DbHelperNC.Query(strSql.ToString());
        }


        #endregion

        #region 自由项1和自由项2
        /// <summary>
        /// 自由项1
        /// </summary>
        /// <param name="stlGrd"></param>
        /// <returns></returns>
        public DataSet GetZYX1(string stlGrd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT N.DOCNAME ZYX1
  FROM XGERP50.BD_DEFDOCLIST M, XGERP50.BD_DEFDOC N
 WHERE M.PK_DEFDOCLIST = N.PK_DEFDOCLIST
   AND (N.SEALFLAG = 'N' OR N.SEALFLAG IS NULL)
   AND N.DOCNAME LIKE '{0}~%'
   AND N.DOCNAME NOT LIKE '%普通要求%'
   AND N.DOCNAME NOT LIKE '%JSKZ%'
   AND (N.DOCNAME LIKE '%协议%' OR N.DOCNAME LIKE '%GB/T%' OR
       N.DOCNAME LIKE '%Q/XG%' OR N.DOCNAME LIKE '%Q/邢钢%')", stlGrd);
            return DbHelperNC.Query(strSql.ToString());
        }
        /// <summary>
        /// 自由项2
        /// </summary>
        /// <param name="stlGrd"></param>
        /// <returns></returns>
        public DataSet GetZYX2(string stlGrd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT N.DOCNAME ZYX2
  FROM XGERP50.BD_DEFDOCLIST M, XGERP50.BD_DEFDOC N
 WHERE M.PK_DEFDOCLIST = N.PK_DEFDOCLIST
   AND (N.SEALFLAG = 'N' OR N.SEALFLAG IS NULL)
   AND N.DOCNAME LIKE '{0}~%'
   AND( N.DOCNAME  LIKE '%普通要求%'
   OR N.DOCNAME  LIKE '%JSKZ%')
   AND N.DOCNAME NOT  LIKE '%协议%' AND N.DOCNAME NOT LIKE '%GB/T%' AND
       N.DOCNAME NOT LIKE '%Q/XG%' AND N.DOCNAME NOT LIKE '%Q/邢钢%'", stlGrd);
            return DbHelperNC.Query(strSql.ToString());
        }
        #endregion

        #region //客户自由项添加

        public bool InsertFree(Mod_TB_STD_CONFIG mod)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TB_STD_CONFIG(");
            strSql.Append("C_STD_CODE,");
            strSql.Append("C_STD_ID,");
            strSql.Append("C_CUST_TECH_PROT,");
            strSql.Append("C_ZYX1,");
            strSql.Append("C_ZYX2,");
            strSql.Append("C_STL_GRD,");
            strSql.Append("C_EMP_ID,");
            strSql.Append("C_REMARK,");
            strSql.Append("C_CUST_NO,");
            strSql.Append("C_CUST_NAME,");
            strSql.Append("C_ZZS");
            strSql.Append(")values(");
            strSql.Append("'" + mod.C_STD_CODE + "',");
            strSql.Append("'" + mod.C_STD_ID + "',");
            strSql.Append("'" + mod.C_CUST_TECH_PROT + "',");
            strSql.Append("'" + mod.C_ZYX1 + "',");
            strSql.Append("'" + mod.C_ZYX2 + "',");
            strSql.Append("'" + mod.C_STL_GRD + "',");
            strSql.Append("'" + mod.C_EMP_ID + "',");
            strSql.Append("'" + mod.C_REMARK + "',");
            strSql.Append("'" + mod.C_CUST_NO + "',");
            strSql.Append("'" + mod.C_CUST_NAME + "',");
            strSql.Append("'" + mod.C_ZZS + "'");
            strSql.Append(")");

            return DbHelperOra.ExecuteSql(strSql.ToString()) > 0 ? true : false;

        }
        #endregion


        #region //物料组
        /// <summary>
        /// 获取物料组
        /// </summary>
        /// <returns></returns>
        public DataSet GetMatrlGroup()
        {
            string strSql = string.Format(@"select T.N_LEV, T.C_MAT_GROUP_NAME,T.C_MAT_GROUP_CODE
                                              from TB_MATRL_GROUP t
                                             where   (t.c_mat_group_code like '8%'
                                               or t.c_mat_group_code like '6%')");
            return DbHelperOra.Query(strSql);
        }
        #endregion

        #region //线材物料组
        /// <summary>
        /// 获取物料组
        /// </summary>
        /// <returns></returns>
        public DataSet GetXCMatrlGroup()
        {
            string strSql = string.Format(@"select T.N_LEV, T.C_MAT_GROUP_NAME,T.C_MAT_GROUP_CODE
                                              from TB_MATRL_GROUP t
                                             where   t.c_mat_group_code like '8%' ");
            return DbHelperOra.Query(strSql);
        }
        #endregion

        /// <summary>
        /// 获取物料组数据
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        public DataSet GetMatGroup(string groupCode)
        {
            string strSql = "select C_MAT_GROUP_CODE,C_MAT_GROUP_NAME from TB_MATRL_GROUP where  C_MAT_GROUP_CODE='" + groupCode + "'";
            return DbHelperOra.Query(strSql);
        }



        #region//预测订单

        /// <summary>
        /// 预测订单线材产品查询
        /// </summary>
        /// <param name="matCode">物料编码</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <returns></returns>
        public DataSet GetStlGrd(string matCode, string stlGrd, string spec)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
SELECT *
  FROM (SELECT A.C_STL_GRD,
               A.C_STD_CODE,
               A.C_ZYX1,
               A.C_ZYX2,
               B.C_SPEC,
               B.C_PROD_KIND,
               B.C_PROD_NAME,
               B.C_USES,
               B.C_IS_BXG
          FROM (SELECT distinct A.C_STL_GRD, A.C_STD_CODE, A.C_ZYX1, A.C_ZYX2
                  FROM TB_STD_CONFIG A
                 WHERE A.N_STATUS = 1) A
          LEFT JOIN (SELECT T.C_STL_GRD,
                           T.C_STD_CODE,
                           T.C_PROD_KIND,
                           T.C_PROD_NAME,
                           T.C_USES,
                           T.C_DELIVERY_STATE,
                           TS.C_SPEC,
                           T.C_IS_BXG
                      FROM TQB_STD_MAIN T
                      LEFT JOIN TQB_STD_SPEC TS
                        ON T.C_ID = TS.C_STD_MAIN_ID
                     WHERE T.N_STATUS = 1
                       AND T.N_IS_CHECK = 1) B
            ON A.C_STL_GRD = B.C_STL_GRD
           AND A.C_STD_CODE = B.C_STD_CODE) M
  LEFT JOIN TB_MATRL_MAIN N
    ON M.C_STL_GRD = N.C_STL_GRD
   AND M.C_SPEC = N.C_SPEC AND ((CASE
  WHEN INSTR(M.C_PROD_KIND, '高速') > 0 THEN
   '801'
  ELSE
   '802'
END )= SUBSTR(N.C_ID, 0, 3) OR SUBSTR(N.C_ID, 0, 3) = '803' OR SUBSTR(N.C_ID, 0, 3) = '805' OR SUBSTR(N.C_ID, 0, 3) = '806' OR SUBSTR(N.C_ID, 0, 3) = '807')   WHERE  N.C_ID IS NOT NULL ");
            if (!string.IsNullOrEmpty(matCode))
            {
                strSql.AppendFormat(" and N.C_MAT_CODE = '{0}'", matCode);
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.AppendFormat(" and N.C_STL_GRD = '{0}'", stlGrd);
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" and N.C_SPEC like  '%{0}'", spec);
            }
            strSql.Append(" order by N.C_MAT_NAME, N.C_STL_GRD, N.C_SPEC");
            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 预测订单钢坯产品查询
        /// </summary>
        /// <param name="matCode">物流编码</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <returns></returns>
        public DataSet GetGP_StlGrd(string matCode, string stlGrd, string spec)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT *
  FROM TB_MATRL_MAIN T
  inner join (SELECT A.C_STL_GRD,
                    A.C_STD_CODE,
                    A.C_ZYX1,
                    A.C_ZYX2,
                    B.C_IS_BXG
               FROM (SELECT distinct A.C_STL_GRD,
                                     A.C_STD_CODE,
                                     A.C_ZYX1,
                                     A.C_ZYX2
                       FROM TB_STD_CONFIG A
                      WHERE A.N_STATUS = 1) A
               INNER JOIN (SELECT T.C_STL_GRD,
                                T.C_STD_CODE,
                                T.C_PROD_KIND,
                                T.C_PROD_NAME,
                                T.C_USES,
                                T.C_DELIVERY_STATE,
                                T.C_IS_BXG
                           FROM TQB_STD_MAIN T
                          WHERE T.N_STATUS = 1
                            AND T.N_IS_CHECK = 1) B
                 ON A.C_STL_GRD = B.C_STL_GRD
                AND A.C_STD_CODE = B.C_STD_CODE) M
    ON M.C_STL_GRD = T.C_STL_GRD
 WHERE  t.c_slab_size IS NOT NULL AND T.C_CLS_TYPE='N'AND T.C_MAT_NAME NOT LIKE '%来料%' AND T.C_MAT_NAME NOT LIKE '%封存%' 
   AND t.n_lth IS NOT NULL
   AND (T.C_ID LIKE '614%' ---热轧钢坯
    OR T.C_ID LIKE '611%' ---小方坯连铸坯
    OR T.C_ID LIKE '612%' ---不锈钢连铸坯
    OR T.C_ID LIKE '613%') ---大方坯连铸坯
");
            if (!string.IsNullOrEmpty(matCode))
            {
                strSql.AppendFormat(" and T.C_MAT_CODE = '{0}'", matCode);
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.AppendFormat(" and T.C_STL_GRD = '{0}'", stlGrd);
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" and T.C_SLAB_SIZE like  '%{0}*'", spec);
            }
            strSql.Append(" order by T.C_MAT_NAME, T.C_STL_GRD, T.C_SPEC");
            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion

        #region 客户产品


        /// <summary>
        /// 获取产品大类
        /// </summary>
        /// <param name="custNo"></param>
        /// <returns></returns>
        public DataSet Get_PROD_KIND(string custNo)
        {
            string strSql = string.Format(@"SELECT DISTINCT N.C_PROD_KIND
  FROM (SELECT A.C_CUST_NO,
               A.C_STL_GRD,
               A.C_STD_CODE,
               A.C_CUST_TECH_PROT,
               A.C_ZYX1,
               A.C_ZYX2
          FROM TB_STD_CONFIG A
         WHERE A.N_STATUS = 1
           AND (A.C_CUST_NO = '{0}' OR A.C_CUST_NO IS NULL)) M
 INNER JOIN (SELECT T.C_STL_GRD,
                    T.C_STD_CODE,
                    T.C_PROD_KIND,
                    T.C_PROD_NAME,
                    T.C_USES,
                    T.C_DELIVERY_STATE,
                    T.C_IS_BXG
               FROM TQB_STD_MAIN T
              WHERE T.N_STATUS = 1
                AND T.N_IS_CHECK = 1 AND (T.C_PROD_KIND LIKE '%线材' OR T.C_PROD_KIND LIKE '%商品坯' )) N
    ON M.C_STL_GRD = N.C_STL_GRD
   AND M.C_STD_CODE = N.C_STD_CODE
 ORDER BY N.C_PROD_KIND ASC
", custNo);

            return DbHelperOra.Query(strSql);

        }

        /// <summary>
        /// 获取钢种小类
        /// </summary>
        /// <param name="custNo"></param>
        /// <param name="C_PROD_KIND"></param>
        /// <returns></returns>
        public DataSet Get_PROD_NAME(string custNo, string C_PROD_KIND)
        {
            string strSql = string.Format(@" SELECT  DISTINCT N.C_PROD_NAME
  FROM (SELECT A.C_CUST_NO,
               A.C_STL_GRD,
               A.C_STD_CODE,
               A.C_CUST_TECH_PROT,
               A.C_ZYX1,
               A.C_ZYX2
          FROM TB_STD_CONFIG A
         WHERE A.N_STATUS = 1
           AND (A.C_CUST_NO = '{0}' OR A.C_CUST_NO IS NULL)) M
 INNER JOIN (SELECT T.C_STL_GRD,
                    T.C_STD_CODE,
                    T.C_PROD_KIND,
                    T.C_PROD_NAME,
                    T.C_USES,
                    T.C_DELIVERY_STATE,
                    T.C_IS_BXG
               FROM TQB_STD_MAIN T
              WHERE T.N_STATUS = 1
                AND T.N_IS_CHECK = 1) N
    ON M.C_STL_GRD = N.C_STL_GRD
   AND M.C_STD_CODE = N.C_STD_CODE
    WHERE N.C_PROD_KIND = '{1}' ORDER BY N.C_PROD_NAME ASC", custNo, C_PROD_KIND);
            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 获取小类钢种
        /// </summary>
        /// <param name="custNo"></param>
        /// <param name="C_PROD_KIND"></param>
        /// <param name="C_PROD_NAME"></param>
        /// <returns></returns>
        public DataSet Get_PROD_NAME_StlGrd(string custNo, string C_PROD_KIND, string C_PROD_NAME)
        {
            string[] arr = { custNo, C_PROD_KIND, C_PROD_NAME };
            string strSql = string.Format(@"SELECT DISTINCT N.C_STL_GRD
  FROM (SELECT A.C_CUST_NO,
               A.C_STL_GRD,
               A.C_STD_CODE,
               A.C_CUST_TECH_PROT,
               A.C_ZYX1,
               A.C_ZYX2
          FROM TB_STD_CONFIG A
         WHERE A.N_STATUS = 1
           AND (A.C_CUST_NO = '{0}' OR A.C_CUST_NO IS NULL)) M
 INNER JOIN (SELECT T.C_STL_GRD,
                    T.C_STD_CODE,
                    T.C_PROD_KIND,
                    T.C_PROD_NAME,
                    T.C_USES,
                    T.C_DELIVERY_STATE,
                    T.C_IS_BXG
               FROM TQB_STD_MAIN T
              WHERE T.N_STATUS = 1
                AND T.N_IS_CHECK = 1) N
    ON M.C_STL_GRD = N.C_STL_GRD
   AND M.C_STD_CODE = N.C_STD_CODE
 WHERE N.C_PROD_KIND = '{1}'
   AND N.C_PROD_NAME = '{2}' ORDER BY N.C_STL_GRD ASC", arr);
            return DbHelperOra.Query(strSql);
        }


        /// <summary>
        /// 手机端获取客户下单钢种
        /// </summary>
        /// <param name="custNo"></param>
        /// <param name="matCode"></param>
        /// <param name="stlGrd"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        public DataSet GetCustStlGrd(string custNo, string matCode, string stlGrd, string spec, string custTechProt, string stdCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT *
  FROM (SELECT A.C_CUST_NO,
               A.C_STL_GRD,
               A.C_STD_CODE,
               A.C_CUST_TECH_PROT,
               A.C_ZYX1,
               A.C_ZYX2,
               B.C_SPEC,
               B.C_PROD_KIND,
               B.C_PROD_NAME,
               B.C_USES,
               B.C_IS_BXG
          FROM (SELECT A.C_CUST_NO,
                       A.C_STL_GRD,
                       A.C_STD_CODE,
                       A.C_CUST_TECH_PROT,
                       A.C_ZYX1,
                       A.C_ZYX2
                  FROM TB_STD_CONFIG A
                 WHERE A.N_STATUS = 1
                   AND (A.C_CUST_NO = '{0}' OR A.C_CUST_NO IS NULL)) A
          LEFT JOIN (SELECT T.C_STL_GRD,
                           T.C_STD_CODE,
                           T.C_PROD_KIND,
                           T.C_PROD_NAME,
                           T.C_USES,
                           T.C_DELIVERY_STATE,
                           TS.C_SPEC,
                           T.C_IS_BXG
                      FROM TQB_STD_MAIN T
                      LEFT JOIN TQB_STD_SPEC TS
                        ON T.C_ID = TS.C_STD_MAIN_ID
                     WHERE T.N_STATUS = 1
                       AND T.N_IS_CHECK = 1) B
            ON A.C_STL_GRD = B.C_STL_GRD
           AND A.C_STD_CODE = B.C_STD_CODE) M
  LEFT JOIN TB_MATRL_MAIN N
    ON M.C_STL_GRD = N.C_STL_GRD
   AND M.C_SPEC = N.C_SPEC AND ((CASE
  WHEN INSTR(M.C_PROD_KIND, '高速') > 0 THEN
   '801'
  ELSE
   '802'
END ） = SUBSTR(N.C_ID, 0, 3) OR SUBSTR(N.C_ID, 0, 3) = '803' OR SUBSTR(N.C_ID, 0, 3) = '805' OR SUBSTR(N.C_ID, 0, 3) = '806' OR SUBSTR(N.C_ID, 0, 3) = '807') WHERE N.C_ID IS NOT NULL ", custNo);

            if (!string.IsNullOrEmpty(stdCode))
            {
                strSql.AppendFormat(" and M.C_STD_CODE = '{0}'", stdCode);
            }


            if (!string.IsNullOrEmpty(custTechProt))
            {
                strSql.AppendFormat(" and M.C_CUST_TECH_PROT = '{0}'", custTechProt);
            }


            if (!string.IsNullOrEmpty(matCode))
            {
                strSql.AppendFormat(" and N.C_MAT_CODE = '{0}'", matCode);
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.AppendFormat(" and UPPER(N.C_STL_GRD)= '{0}'", stlGrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" and N.C_SPEC ='{0}'", spec);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取客户下单钢种
        /// </summary>
        /// <param name="custNo"></param>
        /// <param name="matCode"></param>
        /// <param name="stlGrd"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        public DataSet GetCustStlGrd(string custNo, string matCode, string stlGrd, string spec)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT *
  FROM (SELECT A.C_CUST_NO,
               A.C_STL_GRD,
               A.C_STD_CODE,
               A.C_CUST_TECH_PROT,
               A.C_ZYX1,
               A.C_ZYX2,
               B.C_SPEC,
               B.C_PROD_KIND,
               B.C_PROD_NAME,
               B.C_USES,
               B.C_IS_BXG
          FROM (SELECT A.C_CUST_NO,
                       A.C_STL_GRD,
                       A.C_STD_CODE,
                       A.C_CUST_TECH_PROT,
                       A.C_ZYX1,
                       A.C_ZYX2
                  FROM TB_STD_CONFIG A
                 WHERE A.N_STATUS = 1
                   AND (A.C_CUST_NO = '{0}' OR A.C_CUST_NO IS NULL)) A
          LEFT JOIN (SELECT T.C_STL_GRD,
                           T.C_STD_CODE,
                           T.C_PROD_KIND,
                           T.C_PROD_NAME,
                           T.C_USES,
                           T.C_DELIVERY_STATE,
                           TS.C_SPEC,
                           T.C_IS_BXG
                      FROM TQB_STD_MAIN T
                      LEFT JOIN TQB_STD_SPEC TS
                        ON T.C_ID = TS.C_STD_MAIN_ID
                     WHERE T.N_STATUS = 1
                       AND T.N_IS_CHECK = 1) B
            ON A.C_STL_GRD = B.C_STL_GRD
           AND A.C_STD_CODE = B.C_STD_CODE) M
  LEFT JOIN TB_MATRL_MAIN N
    ON M.C_STL_GRD = N.C_STL_GRD
   AND M.C_SPEC = N.C_SPEC AND ((CASE
  WHEN INSTR(M.C_PROD_KIND, '高速') > 0 THEN
   '801'
  ELSE
   '802'
END ） = SUBSTR(N.C_ID, 0, 3) OR SUBSTR(N.C_ID, 0, 3) = '803' OR SUBSTR(N.C_ID, 0, 3) = '805' OR SUBSTR(N.C_ID, 0, 3) = '806' OR SUBSTR(N.C_ID, 0, 3) = '807') WHERE N.C_ID IS NOT NULL ", custNo);


            if (!string.IsNullOrEmpty(matCode))
            {
                strSql.AppendFormat(" and N.C_MAT_CODE = '{0}'", matCode);
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.AppendFormat(" and UPPER(N.C_STL_GRD) like '%{0}%'", stlGrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" and N.C_SPEC like  '%{0}'", spec);
            }
            strSql.Append(" order by N.C_MAT_NAME, N.C_STL_GRD, N.C_SPEC");

            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 获取客户下单钢种
        /// </summary>
        /// <param name="prodKind"></param>
        /// <param name="prodName"></param>
        /// <param name="custNo"></param>
        /// <param name="matCode"></param>
        /// <param name="stlGrd"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        public DataSet GetCust_StlGrd(string prodKind, string prodName, string custNo, string matCode, string stlGrd, string spec)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT *
  FROM (SELECT A.C_CUST_NO,
               A.C_STL_GRD,
               A.C_STD_CODE,
               A.C_CUST_TECH_PROT,
               A.C_ZYX1,
               A.C_ZYX2,
               B.C_SPEC,
               B.C_PROD_KIND,
               B.C_PROD_NAME,
               B.C_USES,
               B.C_IS_BXG
          FROM (SELECT A.C_CUST_NO,
                       A.C_STL_GRD,
                       A.C_STD_CODE,
                       A.C_CUST_TECH_PROT,
                       A.C_ZYX1,
                       A.C_ZYX2
                  FROM TB_STD_CONFIG A
                 WHERE A.N_STATUS = 1
                   AND (A.C_CUST_NO = '{0}' OR A.C_CUST_NO IS NULL)) A
          LEFT JOIN (SELECT T.C_STL_GRD,
                           T.C_STD_CODE,
                           T.C_PROD_KIND,
                           T.C_PROD_NAME,
                           T.C_USES,
                           T.C_DELIVERY_STATE,
                           TS.C_SPEC,
                           T.C_IS_BXG
                      FROM TQB_STD_MAIN T
                      LEFT JOIN TQB_STD_SPEC TS
                        ON T.C_ID = TS.C_STD_MAIN_ID
                     WHERE T.N_STATUS = 1 AND TS.N_STATUS=1
                       AND T.N_IS_CHECK = 1) B
            ON A.C_STL_GRD = B.C_STL_GRD
           AND A.C_STD_CODE = B.C_STD_CODE) M
  LEFT JOIN TB_MATRL_MAIN N
    ON M.C_STL_GRD = N.C_STL_GRD
   AND M.C_SPEC = N.C_SPEC AND ((CASE
  WHEN INSTR(M.C_PROD_KIND, '高速') > 0 THEN
   '801'
  ELSE
   '802'
END ） = SUBSTR(N.C_ID, 0, 3) OR SUBSTR(N.C_ID, 0, 3) = '803' OR SUBSTR(N.C_ID, 0, 3) = '805' OR SUBSTR(N.C_ID, 0, 3) = '806' OR SUBSTR(N.C_ID, 0, 3) = '807') WHERE N.C_ID IS NOT NULL ", custNo);

            if (!string.IsNullOrEmpty(prodKind))
            {
                strSql.AppendFormat(" and M.C_PROD_KIND = '{0}'", prodKind);
            }
            if (!string.IsNullOrEmpty(prodName))
            {
                strSql.AppendFormat(" and M.C_PROD_NAME = '{0}'", prodName);
            }
            if (!string.IsNullOrEmpty(matCode))
            {
                strSql.AppendFormat(" and N.C_MAT_CODE = '{0}'", matCode);
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.AppendFormat(" and UPPER(N.C_STL_GRD) like '%{0}%'", stlGrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" and N.C_SPEC like  '%{0}'", spec);
            }
            strSql.Append(" order by N.C_MAT_NAME, N.C_STL_GRD, N.C_SPEC");

            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 根据物料编码批量查询
        /// </summary>
        /// <param name="custNo"></param>
        /// <param name="matCode"></param>
        /// <returns></returns>
        public DataSet GetCustStlGrd(string custNo, string matCode)
        {

            string[] arr = matCode.Split(',');
            List<string> list = new List<string>();
            if (arr.Length > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!string.IsNullOrEmpty(arr[i]))
                    {
                        list.Add("'" + arr[i] + "'");
                    }
                }
            }

            string result = string.Join(",", list);

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT *
  FROM (SELECT A.C_CUST_NO,
               A.C_STL_GRD,
               A.C_STD_CODE,
               A.C_CUST_TECH_PROT,
               A.C_ZYX1,
               A.C_ZYX2,
               B.C_SPEC,
               B.C_PROD_KIND,
               B.C_PROD_NAME,
               B.C_USES,
               B.C_IS_BXG
          FROM (SELECT A.C_CUST_NO,
                       A.C_STL_GRD,
                       A.C_STD_CODE,
                       A.C_CUST_TECH_PROT,
                       A.C_ZYX1,
                       A.C_ZYX2
                  FROM TB_STD_CONFIG A
                 WHERE A.N_STATUS = 1
                   AND (A.C_CUST_NO = '{0}' OR A.C_CUST_NO IS NULL)) A
          LEFT JOIN (SELECT T.C_STL_GRD,
                           T.C_STD_CODE,
                           T.C_PROD_KIND,
                           T.C_PROD_NAME,
                           T.C_USES,
                           T.C_DELIVERY_STATE,
                           TS.C_SPEC,
                           T.C_IS_BXG
                      FROM TQB_STD_MAIN T
                      LEFT JOIN TQB_STD_SPEC TS
                        ON T.C_ID = TS.C_STD_MAIN_ID
                     WHERE T.N_STATUS = 1
                       AND T.N_IS_CHECK = 1) B
            ON A.C_STL_GRD = B.C_STL_GRD
           AND A.C_STD_CODE = B.C_STD_CODE) M
  LEFT JOIN TB_MATRL_MAIN N
    ON M.C_STL_GRD = N.C_STL_GRD
   AND M.C_SPEC = N.C_SPEC AND ((CASE
  WHEN INSTR(M.C_PROD_KIND, '高速') > 0 THEN
   '801'
  ELSE
   '802'
END ） = SUBSTR(N.C_ID, 0, 3) OR SUBSTR(N.C_ID, 0, 3) = '803' OR SUBSTR(N.C_ID, 0, 3) = '805' OR SUBSTR(N.C_ID, 0, 3) = '806' OR SUBSTR(N.C_ID, 0, 3) = '807') WHERE N.C_ID IS NOT NULL ", custNo);


            if (!string.IsNullOrEmpty(result))
            {
                strSql.AppendFormat(" and N.C_MAT_CODE IN ({0})", result);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 客户订单钢坯产品查询
        /// </summary>
        /// <param name="matCode">物流编码</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <returns></returns>
        public DataSet GetCustStlGrd_GP(string custNo, string matCode, string stlGrd, string spec)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT *
  FROM TB_MATRL_MAIN T
  inner join (SELECT A.C_STL_GRD,
                    A.C_STD_CODE,
                    A.C_CUST_TECH_PROT,
                    A.C_ZYX1,
                    A.C_ZYX2,
                    B.C_IS_BXG
               FROM (SELECT distinct A.C_STL_GRD,
                                     A.C_STD_CODE,
                                     A.C_CUST_TECH_PROT,
                                     A.C_ZYX1,
                                     A.C_ZYX2
                       FROM TB_STD_CONFIG A
                      WHERE A.N_STATUS = 1 AND (A.C_CUST_NO = '{0}' OR A.C_CUST_NO IS NULL)) A
               LEFT JOIN (SELECT T.C_STL_GRD,
                                T.C_STD_CODE,
                                T.C_PROD_KIND,
                                T.C_PROD_NAME,
                                T.C_USES,
                                T.C_DELIVERY_STATE,
                                T.C_IS_BXG
                           FROM TQB_STD_MAIN T
                          WHERE T.N_STATUS = 1
                            AND T.N_IS_CHECK = 1) B
                 ON A.C_STL_GRD = B.C_STL_GRD
                AND A.C_STD_CODE = B.C_STD_CODE) M
    ON M.C_STL_GRD = T.C_STL_GRD
 WHERE  t.c_slab_size IS NOT NULL
   AND t.n_lth IS NOT NULL
   AND (T.C_ID LIKE '614%' ---热轧钢坯
    OR T.C_ID LIKE '611%' ---小方坯连铸坯
    OR T.C_ID LIKE '612%' ---不锈钢连铸坯
    OR T.C_ID LIKE '613%') ---大方坯连铸坯
", custNo);

            if (!string.IsNullOrEmpty(matCode))
            {
                strSql.AppendFormat(" and T.C_MAT_CODE = '{0}'", matCode);
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.AppendFormat(" and T.C_STL_GRD = '{0}'", stlGrd);
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" and T.C_SLAB_SIZE like  '%{0}*'", spec);
            }
            strSql.Append(" order by T.C_MAT_NAME, T.C_STL_GRD, T.C_SPEC");
            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 客户订单钢坯产品查询
        /// </summary>
        /// <param name="matCode">物流编码</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <returns></returns>
        public DataSet GetCustStlGrd_GP(string prodKind, string prodName, string custNo, string matCode, string stlGrd, string spec)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT *
  FROM TB_MATRL_MAIN T
  inner join (SELECT A.C_STL_GRD,
                    A.C_STD_CODE,
                    A.C_CUST_TECH_PROT,
                    A.C_ZYX1,
                    A.C_ZYX2,
                    B.C_IS_BXG,
                    B.C_PROD_KIND,
                    B.C_PROD_NAME
               FROM (SELECT distinct A.C_STL_GRD,
                                     A.C_STD_CODE,
                                     A.C_CUST_TECH_PROT,
                                     A.C_ZYX1,
                                     A.C_ZYX2
                       FROM TB_STD_CONFIG A
                      WHERE A.N_STATUS = 1 AND (A.C_CUST_NO = '{0}' OR A.C_CUST_NO IS NULL)) A
               LEFT JOIN (SELECT T.C_STL_GRD,
                                T.C_STD_CODE,
                                T.C_PROD_KIND,
                                T.C_PROD_NAME,
                                T.C_USES,
                                T.C_DELIVERY_STATE,
                                T.C_IS_BXG
                           FROM TQB_STD_MAIN T
                          WHERE T.N_STATUS = 1
                            AND T.N_IS_CHECK = 1) B
                 ON A.C_STL_GRD = B.C_STL_GRD
                AND A.C_STD_CODE = B.C_STD_CODE) M
    ON M.C_STL_GRD = T.C_STL_GRD
 WHERE  t.c_slab_size IS NOT NULL
   AND t.n_lth IS NOT NULL
   AND (T.C_ID LIKE '614%' ---热轧钢坯
    OR T.C_ID LIKE '611%' ---小方坯连铸坯
    OR T.C_ID LIKE '612%' ---不锈钢连铸坯
    OR T.C_ID LIKE '613%') ---大方坯连铸坯
", custNo);
            if (!string.IsNullOrEmpty(prodKind))
            {
                strSql.AppendFormat(" and M.C_PROD_KIND = '{0}'", prodKind);
            }
            if (!string.IsNullOrEmpty(prodName))
            {
                strSql.AppendFormat(" and M.C_PROD_NAME = '{0}'", prodName);
            }

            if (!string.IsNullOrEmpty(matCode))
            {
                strSql.AppendFormat(" and T.C_MAT_CODE = '{0}'", matCode);
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.AppendFormat(" and T.C_STL_GRD = '{0}'", stlGrd);
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" and T.C_SLAB_SIZE like  '%{0}*'", spec);
            }
            strSql.Append(" order by T.C_MAT_NAME, T.C_STL_GRD, T.C_SPEC");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 客户副产品查询
        /// </summary>
        /// <returns></returns>
        public DataSet GetCustStlGrd_FCP(string matCode,string matName)
        {
            string strSql = $@"SELECT T.C_ID,
                               T.C_MAT_CODE,
                               T.C_MAT_NAME,
                               T.C_MAT_NAME AS C_STL_GRD,
                               T.C_SPEC,
                               '' AS C_STD_CODE,
                               '' AS C_CUST_TECH_PROT,
                               '' AS C_ZYX1,
                               '' AS C_ZYX2,
                               '0' AS C_IS_BXG
                          FROM TB_MATRL_MAIN T
                         WHERE T.C_MAT_TYPE IN ('841', '851')";

            if(!string .IsNullOrEmpty(matCode))
            {
                strSql += $" AND T.C_MAT_CODE='{matCode}'";
            }
            if (!string.IsNullOrEmpty(matName))
            {
                strSql += $" AND T.C_MAT_NAME='{matName}'";
            }
            strSql += " ORDER BY T.C_MAT_CODE ASC";


            return DbHelperOra.Query(strSql);
        }

        #endregion

        #region //头尾材

        /// <summary>
        /// 合同订单头尾材物料编码批量查询
        /// </summary>
        /// <param name="matCode"></param>
        /// <returns></returns>
        public DataSet GetTWC_StlGrd(string matCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT T.C_MAT_CODE,
                                   T.C_MAT_DESC,
                                   T.C_STL_GRD,
                                   T.C_SPEC,
                                   T.C_STD_CODE,
                                   T.C_ZYX1,
                                   T.C_ZYX2,
                                   DECODE(T.C_JUDGE_LEV_ZH,
                                          'D',
                                          '1001NC1000000047Y2U9',
                                          'B1',
                                          '1001NC100000000052ZO',
                                          'B2',
                                          '1001NC100000000052ZM',
                                          'C1',
                                          '1001NC100000000052ZL',
                                          'C2',
                                          '1001NC100000000052ZN') ZLDJ,
                                   NVL(SUM(T.N_WGT),0) N_WGT
                              FROM TRC_ROLL_PRODCUT T
                             WHERE T.C_MOVE_TYPE = 'E'
                               AND T.C_IS_QR = 'Y'
                               AND T.C_JUDGE_LEV_ZH IN ('D', 'B1', 'B2', 'C1', 'C2')");

            if (!string.IsNullOrEmpty(matCode))
            {
                strSql.AppendFormat(" AND T.C_MAT_CODE IN ({0})", matCode);
            }

            strSql.AppendFormat(@" GROUP BY T.C_MAT_CODE,T.C_MAT_DESC,
          T.C_STL_GRD,
          T.C_SPEC,
          T.C_STD_CODE,
          T.C_JUDGE_LEV_ZH,
          T.C_ZYX1,
          T.C_ZYX2");

            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 合同订单头尾材物料
        /// </summary>
        /// <param name="matCode"></param>
        /// <returns></returns>
        public DataSet GetTWC_StlGrd(string matCode, string stlGrd, string spec)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT T.C_MAT_CODE,
                                   T.C_MAT_DESC,
                                   T.C_STL_GRD,
                                   T.C_SPEC,
                                   T.C_STD_CODE,
                                   T.C_ZYX1,
                                   T.C_ZYX2,
                                    DECODE(T.C_JUDGE_LEV_ZH,
                                          'D',
                                          '1001NC1000000047Y2U9',
                                          'B1',
                                          '1001NC100000000052ZO',
                                          'B2',
                                          '1001NC100000000052ZM',
                                          'C1',
                                          '1001NC100000000052ZL',
                                          'C2',
                                          '1001NC100000000052ZN') ZLDJ,
                                   NVL(SUM(T.N_WGT),0) N_WGT
                              FROM TRC_ROLL_PRODCUT T
                             WHERE T.C_MOVE_TYPE = 'E'
                               AND T.C_IS_QR = 'Y'
                               AND T.C_JUDGE_LEV_ZH IN ('D', 'B1', 'B2', 'C1', 'C2')");

            if (!string.IsNullOrEmpty(matCode))
            {
                strSql.AppendFormat(" AND T.C_MAT_CODE='{0}'", matCode);
            }

            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.AppendFormat(" and UPPER(T.C_STL_GRD) like '%{0}%'", stlGrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" and T.C_SPEC like  '%{0}'", spec);
            }
            strSql.AppendFormat(@" group by T.C_MAT_DESC,
          T.C_STL_GRD,
          T.C_SPEC,
          T.C_STD_CODE,
          T.C_ZYX1,
          T.C_ZYX2");

            return DbHelperOra.Query(strSql.ToString());
        }


        #endregion



        /// <summary>
        /// 钢种规格执行标准检查
        /// </summary>
        /// <param name="stlgrd">钢种</param>
        /// <param name="stdcode">执行标准</param>
        /// <param name="spec">规格</param>
        /// <returns></returns>
        public DataSet GetStd_Grd_Spec(string stlgrd, string stdcode, string spec)
        {
            string[] arr = { stlgrd, stdcode, spec };
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"SELECT T.C_STL_GRD, T.C_STD_CODE, TS.C_SPEC
                              FROM TQB_STD_MAIN T
                              LEFT JOIN TQB_STD_SPEC TS
                                ON T.C_ID = TS.C_STD_MAIN_ID
                             WHERE T.N_STATUS = 1
                               AND T.N_IS_CHECK = 1
                               AND T.C_STL_GRD = '{0}'
                               AND T.C_STD_CODE = '{1}'
                               AND TS.C_SPEC='{2}'", arr);
            return DbHelperOra.Query(strSql.ToString());

        }

    }
}

