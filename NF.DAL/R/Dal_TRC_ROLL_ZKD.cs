using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using NF.DAL;

namespace NF.DAL
{
    /// <summary>
	/// 数据访问类:TRC_ROLL_ZKD
	/// </summary>
	public partial class Dal_TRC_ROLL_ZKD
    {
        public Dal_TRC_ROLL_ZKD()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TRC_ROLL_ZKD");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TRC_ROLL_ZKD model, bool flag = false)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TRC_ROLL_ZKD(");
            strSql.Append("C_ZKD_NO,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_MBLINEWH_CODE,C_STL_GRD,C_JUDGE_LEV_ZH,N_NUM,N_WGT,C_Z_DW,C_F_DW,C_BATCH_NO,C_SPEC,C_STOVE,C_ZYX1,C_ZYX2,C_BZYQ,C_ZYX4,N_STATUS,C_EMP_ID,D_MOD_DT,D_PRODUCE_DATE,C_TB,C_JUDGE_LEV_BP,C_STD_CODE,C_LINEWH_ID,C_MBLINEWH_ID,C_CREATE_CODE,D_CREATE_DATE,N_SJNUM,N_SJWGT)");
            strSql.Append(" values (");
            strSql.Append(":C_ZKD_NO,:C_MAT_CODE,:C_MAT_DESC,:C_LINEWH_CODE,:C_MBLINEWH_CODE,:C_STL_GRD,:C_JUDGE_LEV_ZH,:N_NUM,:N_WGT,:C_Z_DW,:C_F_DW,:C_BATCH_NO,:C_SPEC,:C_STOVE,:C_ZYX1,:C_ZYX2,:C_BZYQ,:C_ZYX4,:N_STATUS,:C_EMP_ID,:D_MOD_DT,:D_PRODUCE_DATE,:C_TB,:C_JUDGE_LEV_BP,:C_STD_CODE,:C_LINEWH_ID,:C_MBLINEWH_ID,:C_CREATE_CODE,:D_CREATE_DATE,:N_SJNUM,:N_SJWGT)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ZKD_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MBLINEWH_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_ZH", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_NUM", OracleDbType.Int16,15),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_Z_DW", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_F_DW", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STOVE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZYX1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZYX2", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BZYQ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZYX4", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":D_PRODUCE_DATE", OracleDbType.Date),
                    new OracleParameter(":C_TB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_BP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MBLINEWH_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CREATE_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_CREATE_DATE", OracleDbType.Date),
                    new OracleParameter(":N_SJNUM", OracleDbType.Int16,15),
                    new OracleParameter(":N_SJWGT", OracleDbType.Decimal,15)};
            parameters[0].Value = model.C_ZKD_NO;
            parameters[1].Value = model.C_MAT_CODE;
            parameters[2].Value = model.C_MAT_DESC;
            parameters[3].Value = model.C_LINEWH_CODE;
            parameters[4].Value = model.C_MBLINEWH_CODE;
            parameters[5].Value = model.C_STL_GRD;
            parameters[6].Value = model.C_JUDGE_LEV_ZH;
            parameters[7].Value = model.N_NUM;
            parameters[8].Value = model.N_WGT;
            parameters[9].Value = model.C_Z_DW;
            parameters[10].Value = model.C_F_DW;
            parameters[11].Value = model.C_BATCH_NO;
            parameters[12].Value = model.C_SPEC;
            parameters[13].Value = model.C_STOVE;
            parameters[14].Value = model.C_ZYX1;
            parameters[15].Value = model.C_ZYX2;
            parameters[16].Value = model.C_BZYQ;
            parameters[17].Value = model.C_ZYX4;
            parameters[18].Value = model.N_STATUS;
            parameters[19].Value = model.C_EMP_ID;
            parameters[20].Value = model.D_MOD_DT;
            parameters[21].Value = model.D_PRODUCE_DATE;
            parameters[22].Value = model.C_TB;
            parameters[23].Value = model.C_JUDGE_LEV_BP;
            parameters[24].Value = model.C_STD_CODE;
            parameters[25].Value = model.C_LINEWH_ID;
            parameters[26].Value = model.C_MBLINEWH_ID;
            parameters[27].Value = model.C_CREATE_CODE;
            parameters[28].Value = model.D_CREATE_DATE;
            parameters[29].Value = model.N_SJNUM;
            parameters[30].Value = model.N_SJWGT;

            int rows = 0;
            if (flag)
            {
                rows = TransactionHelper.ExecuteSql(strSql.ToString(), parameters);
            }
            else
            {
                rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            }
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
        public bool Update(Mod_TRC_ROLL_ZKD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TRC_ROLL_ZKD set ");
            strSql.Append("C_ZKD_NO=:C_ZKD_NO,");
            strSql.Append("C_MAT_CODE=:C_MAT_CODE,");
            strSql.Append("C_MAT_DESC=:C_MAT_DESC,");
            strSql.Append("C_LINEWH_CODE=:C_LINEWH_CODE,");
            strSql.Append("C_MBLINEWH_CODE=:C_MBLINEWH_CODE,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_JUDGE_LEV_ZH=:C_JUDGE_LEV_ZH,");
            strSql.Append("N_NUM=:N_NUM,");
            strSql.Append("N_WGT=:N_WGT,");
            strSql.Append("C_Z_DW=:C_Z_DW,");
            strSql.Append("C_F_DW=:C_F_DW,");
            strSql.Append("C_BATCH_NO=:C_BATCH_NO,");
            strSql.Append("C_SPEC=:C_SPEC,");
            strSql.Append("C_STOVE=:C_STOVE,");
            strSql.Append("C_ZYX1=:C_ZYX1,");
            strSql.Append("C_ZYX2=:C_ZYX2,");
            strSql.Append("C_BZYQ=:C_BZYQ,");
            strSql.Append("C_ZYX4=:C_ZYX4,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("D_PRODUCE_DATE=:D_PRODUCE_DATE,");
            strSql.Append("C_TB=:C_TB,");
            strSql.Append("C_JUDGE_LEV_BP=:C_JUDGE_LEV_BP,");
            strSql.Append("C_STD_CODE=:C_STD_CODE,");
            strSql.Append("C_LINEWH_ID=:C_LINEWH_ID,");
            strSql.Append("C_MBLINEWH_ID=:C_MBLINEWH_ID,");
            strSql.Append("C_CREATE_CODE=:C_CREATE_CODE,");
            strSql.Append("D_CREATE_DATE=:D_CREATE_DATE,");
            strSql.Append("N_SJNUM=:N_SJNUM,");
            strSql.Append("N_SJWGT=:N_SJWGT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ZKD_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MBLINEWH_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_ZH", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_NUM", OracleDbType.Int16,15),
                    new OracleParameter(":N_WGT", OracleDbType.Int16,15),
                    new OracleParameter(":C_Z_DW", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_F_DW", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STOVE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZYX1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZYX2", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BZYQ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZYX4", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":D_PRODUCE_DATE", OracleDbType.Date),
                    new OracleParameter(":C_TB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_BP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MBLINEWH_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CREATE_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_CREATE_DATE", OracleDbType.Date),
                    new OracleParameter(":N_SJNUM", OracleDbType.Int16,15),
                    new OracleParameter(":N_SJWGT", OracleDbType.Int16,15),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_ZKD_NO;
            parameters[1].Value = model.C_MAT_CODE;
            parameters[2].Value = model.C_MAT_DESC;
            parameters[3].Value = model.C_LINEWH_CODE;
            parameters[4].Value = model.C_MBLINEWH_CODE;
            parameters[5].Value = model.C_STL_GRD;
            parameters[6].Value = model.C_JUDGE_LEV_ZH;
            parameters[7].Value = model.N_NUM;
            parameters[8].Value = model.N_WGT;
            parameters[9].Value = model.C_Z_DW;
            parameters[10].Value = model.C_F_DW;
            parameters[11].Value = model.C_BATCH_NO;
            parameters[12].Value = model.C_SPEC;
            parameters[13].Value = model.C_STOVE;
            parameters[14].Value = model.C_ZYX1;
            parameters[15].Value = model.C_ZYX2;
            parameters[16].Value = model.C_BZYQ;
            parameters[17].Value = model.C_ZYX4;
            parameters[18].Value = model.N_STATUS;
            parameters[19].Value = model.C_EMP_ID;
            parameters[20].Value = model.D_MOD_DT;
            parameters[21].Value = model.D_PRODUCE_DATE;
            parameters[22].Value = model.C_TB;
            parameters[23].Value = model.C_JUDGE_LEV_BP;
            parameters[24].Value = model.C_STD_CODE;
            parameters[25].Value = model.C_LINEWH_ID;
            parameters[26].Value = model.C_MBLINEWH_ID;
            parameters[27].Value = model.C_CREATE_CODE;
            parameters[28].Value = model.D_CREATE_DATE;
            parameters[29].Value = model.N_SJNUM;
            parameters[30].Value = model.N_SJWGT;
            parameters[31].Value = model.C_ID;

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
            strSql.Append("delete from TRC_ROLL_ZKD ");
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
            strSql.Append("delete from TRC_ROLL_ZKD ");
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
        public Mod_TRC_ROLL_ZKD GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_ZKD_NO,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_MBLINEWH_CODE,C_STL_GRD,C_JUDGE_LEV_ZH,N_NUM,N_WGT,C_Z_DW,C_F_DW,C_BATCH_NO,C_SPEC,C_STOVE,C_ZYX1,C_ZYX2,C_BZYQ,C_ZYX4,N_STATUS,C_EMP_ID,D_MOD_DT,D_PRODUCE_DATE,C_TB,C_JUDGE_LEV_BP,C_STD_CODE,C_LINEWH_ID,C_MBLINEWH_ID,C_CREATE_CODE,D_CREATE_DATE,N_SJNUM,N_SJWGT from TRC_ROLL_ZKD ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            Mod_TRC_ROLL_ZKD model = new Mod_TRC_ROLL_ZKD();
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
        public Mod_TRC_ROLL_ZKD GetModeltran(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_ZKD_NO,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_MBLINEWH_CODE,C_STL_GRD,C_JUDGE_LEV_ZH,N_NUM,N_WGT,C_Z_DW,C_F_DW,C_BATCH_NO,C_SPEC,C_STOVE,C_ZYX1,C_ZYX2,C_BZYQ,C_ZYX4,N_STATUS,C_EMP_ID,D_MOD_DT,D_PRODUCE_DATE,C_TB,C_JUDGE_LEV_BP,C_STD_CODE,C_LINEWH_ID,C_MBLINEWH_ID,C_CREATE_CODE,D_CREATE_DATE,N_SJNUM,N_SJWGT from TRC_ROLL_ZKD ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            Mod_TRC_ROLL_ZKD model = new Mod_TRC_ROLL_ZKD();
            DataSet ds = TransactionHelper.Query(strSql.ToString(), parameters);
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
        public Mod_TRC_ROLL_ZKD DataRowToModel(DataRow row)
        {
            Mod_TRC_ROLL_ZKD model = new Mod_TRC_ROLL_ZKD();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_ZKD_NO"] != null)
                {
                    model.C_ZKD_NO = row["C_ZKD_NO"].ToString();
                }
                if (row["C_MAT_CODE"] != null)
                {
                    model.C_MAT_CODE = row["C_MAT_CODE"].ToString();
                }
                if (row["C_MAT_DESC"] != null)
                {
                    model.C_MAT_DESC = row["C_MAT_DESC"].ToString();
                }
                if (row["C_LINEWH_CODE"] != null)
                {
                    model.C_LINEWH_CODE = row["C_LINEWH_CODE"].ToString();
                }
                if (row["C_MBLINEWH_CODE"] != null)
                {
                    model.C_MBLINEWH_CODE = row["C_MBLINEWH_CODE"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_JUDGE_LEV_ZH"] != null)
                {
                    model.C_JUDGE_LEV_ZH = row["C_JUDGE_LEV_ZH"].ToString();
                }
                if (row["N_NUM"] != null && row["N_NUM"].ToString() != "")
                {
                    model.N_NUM = decimal.Parse(row["N_NUM"].ToString());
                }
                if (row["N_WGT"] != null && row["N_WGT"].ToString() != "")
                {
                    model.N_WGT = decimal.Parse(row["N_WGT"].ToString());
                }
                if (row["C_Z_DW"] != null)
                {
                    model.C_Z_DW = row["C_Z_DW"].ToString();
                }
                if (row["C_F_DW"] != null)
                {
                    model.C_F_DW = row["C_F_DW"].ToString();
                }
                if (row["C_BATCH_NO"] != null)
                {
                    model.C_BATCH_NO = row["C_BATCH_NO"].ToString();
                }
                if (row["C_SPEC"] != null)
                {
                    model.C_SPEC = row["C_SPEC"].ToString();
                }
                if (row["C_STOVE"] != null)
                {
                    model.C_STOVE = row["C_STOVE"].ToString();
                }
                if (row["C_ZYX1"] != null)
                {
                    model.C_ZYX1 = row["C_ZYX1"].ToString();
                }
                if (row["C_ZYX2"] != null)
                {
                    model.C_ZYX2 = row["C_ZYX2"].ToString();
                }
                if (row["C_BZYQ"] != null)
                {
                    model.C_BZYQ = row["C_BZYQ"].ToString();
                }
                if (row["C_ZYX4"] != null)
                {
                    model.C_ZYX4 = row["C_ZYX4"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["D_MOD_DT"] != null && row["D_MOD_DT"].ToString() != "")
                {
                    model.D_MOD_DT = DateTime.Parse(row["D_MOD_DT"].ToString());
                }
                if (row["D_PRODUCE_DATE"] != null && row["D_PRODUCE_DATE"].ToString() != "")
                {
                    model.D_PRODUCE_DATE = DateTime.Parse(row["D_PRODUCE_DATE"].ToString());
                }
                if (row["C_TB"] != null)
                {
                    model.C_TB = row["C_TB"].ToString();
                }
                if (row["C_JUDGE_LEV_BP"] != null)
                {
                    model.C_JUDGE_LEV_BP = row["C_JUDGE_LEV_BP"].ToString();
                }
                if (row["C_STD_CODE"] != null)
                {
                    model.C_STD_CODE = row["C_STD_CODE"].ToString();
                }
                if (row["C_LINEWH_ID"] != null)
                {
                    model.C_LINEWH_ID = row["C_LINEWH_ID"].ToString();
                }
                if (row["C_MBLINEWH_ID"] != null)
                {
                    model.C_MBLINEWH_ID = row["C_MBLINEWH_ID"].ToString();
                }
                if (row["C_CREATE_CODE"] != null)
                {
                    model.C_CREATE_CODE = row["C_CREATE_CODE"].ToString();
                }
                if (row["D_CREATE_DATE"] != null && row["D_CREATE_DATE"].ToString() != "")
                {
                    model.D_CREATE_DATE = DateTime.Parse(row["D_CREATE_DATE"].ToString());
                }
                if (row["N_SJNUM"] != null && row["N_SJNUM"].ToString() != "")
                {
                    model.N_SJNUM = decimal.Parse(row["N_SJNUM"].ToString());
                }
                if (row["N_SJWGT"] != null && row["N_SJWGT"].ToString() != "")
                {
                    model.N_SJWGT = decimal.Parse(row["N_SJWGT"].ToString());
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
            strSql.Append("select C_ID,C_ZKD_NO,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_MBLINEWH_CODE,C_STL_GRD,C_JUDGE_LEV_ZH,N_NUM,N_WGT,C_Z_DW,C_F_DW,C_BATCH_NO,C_SPEC,C_STOVE,C_ZYX1,C_ZYX2,C_BZYQ,C_ZYX4,N_STATUS,C_EMP_ID,D_MOD_DT,D_PRODUCE_DATE,C_TB,C_JUDGE_LEV_BP,C_STD_CODE,C_LINEWH_ID,C_MBLINEWH_ID,C_CREATE_CODE,D_CREATE_DATE,N_SJNUM,N_SJWGT ");
            strSql.Append(" FROM TRC_ROLL_ZKD ");
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
            strSql.Append("select count(1) FROM TRC_ROLL_ZKD ");
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
            strSql.Append(")AS Row, T.*  from TRC_ROLL_ZKD T ");
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
					new OracleParameter(":PageSize", OracleDbType.Int16),
					new OracleParameter(":PageIndex", OracleDbType.Int16),
					new OracleParameter(":IsReCount", OracleType.Clob),
					new OracleParameter(":OrderType", OracleType.Clob),
					new OracleParameter(":strWhere", OracleDbType.Varchar2,1000),
					};
			parameters[0].Value = "TRC_ROLL_ZKD";
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
        /// <summary>
        /// 获取最新的转库单号
        /// </summary>
        /// <param name="C_ZKD_NO">转库单</param>
        /// <returns></returns>
        public long GetZKDNO(string C_ZKD_NO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MAX(C_ZKD_NO) ");
            strSql.Append(" FROM TRC_ROLL_ZKD WHERE N_STATUS=1 ");
            if (C_ZKD_NO.Trim() != "")
            {
                strSql.Append(" AND C_ZKD_NO LIKE '" + C_ZKD_NO + "%' ");
            }
            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }
        /// <summary>
        /// 根据转库单获取数据
        /// </summary>
        /// <param name="dh"></param>
        /// <returns></returns>
        public DataSet GetListBydh(string dh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_ZKD_NO,C_MAT_CODE,C_MAT_DESC,C_LINEWH_ID,C_MBLINEWH_ID,C_LINEWH_CODE,C_MBLINEWH_CODE,C_STL_GRD,C_JUDGE_LEV_ZH,N_NUM,N_WGT,C_Z_DW,C_F_DW,C_BATCH_NO,C_SPEC,C_STOVE,C_ZYX1,C_ZYX2,C_BZYQ,C_ZYX4,N_STATUS,C_EMP_ID,D_MOD_DT ,N_SJNUM,N_SJWGT");
            strSql.Append(" FROM TRC_ROLL_ZKD WHERE N_STATUS<>2");
            if (dh.Trim() != "")
            {
                strSql.Append(" AND C_ZKD_NO ='" + dh + "' ");
            }
            return TransactionHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据转库单号得到一个对象实体
        /// </summary>
        /// <param name="C_ZKD_NO">转库单号</param>
        /// <returns></returns>
        public Mod_TRC_ROLL_ZKD GetModelByZKD(string C_ZKD_NO)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_ZKD_NO,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_MBLINEWH_CODE,C_STL_GRD,C_JUDGE_LEV_ZH,N_NUM,N_WGT,C_Z_DW,C_F_DW,C_BATCH_NO,C_SPEC,C_STOVE,C_ZYX1,C_ZYX2,C_BZYQ,C_ZYX4,N_STATUS,C_EMP_ID,D_MOD_DT,D_PRODUCE_DATE from TRC_ROLL_ZKD ");
            strSql.Append(" where C_ZKD_NO=:C_ZKD_NO ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ZKD_NO", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ZKD_NO;

            Mod_TRC_ROLL_ZKD model = new Mod_TRC_ROLL_ZKD();
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

        #endregion  ExtensionMethod
    }
}
