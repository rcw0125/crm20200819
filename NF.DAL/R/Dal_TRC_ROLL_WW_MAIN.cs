using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using NF.DAL;
using NF.DLL;
using NF.MODEL;
using Oracle.ManagedDataAccess.Client;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:Mod_TRC_ROLL_WW_MAIN
    /// </summary>
    public partial class Dal_TRC_ROLL_WW_MAIN
    {
        public Dal_TRC_ROLL_WW_MAIN()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TRC_ROLL_WW_MAIN");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
            new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TRC_ROLL_WW_MAIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TRC_ROLL_WW_MAIN(");
            strSql.Append("C_ID,C_STA_ID,C_PLANT,C_ORD_ID,C_BATCH_NO,N_QUA_TOTAL,N_WGT_TOTAL,C_STL_GRD_SLAB,C_SPEC_SLAB,C_EMP_ID,C_SHIFT,C_GROUP,D_MOD_DT,N_QUA_REMOVE,N_WGT_REMOVE,C_MAT_SLAB_CODE,C_MAT_SLAB_NAME,C_REMARK,N_STATUS,C_STD_CODE,D_PRODUCE_DATE_B,C_PRODUCE_EMP_ID,C_PRODUCE_SHIFT,C_PRODUCE_GROUP,D_PRODUCE_DATE_E,C_MAT_XC_CODE,C_MAT_XC_NAME,C_XC_BATCH_NO,C_XC_LINEWH_CODE,C_CHECKSTATE_NAME,C_LINEWH_CODE,C_LINEWH_NAME,C_XC_BZYQ)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_STA_ID,:C_PLANT,:C_ORD_ID,:C_BATCH_NO,:N_QUA_TOTAL,:N_WGT_TOTAL,:C_STL_GRD_SLAB,:C_SPEC_SLAB,:C_EMP_ID,:C_SHIFT,:C_GROUP,:D_MOD_DT,:N_QUA_REMOVE,:N_WGT_REMOVE,:C_MAT_SLAB_CODE,:C_MAT_SLAB_NAME,:C_REMARK,:N_STATUS,:C_STD_CODE,:D_PRODUCE_DATE_B,:C_PRODUCE_EMP_ID,:C_PRODUCE_SHIFT,:C_PRODUCE_GROUP,:D_PRODUCE_DATE_E,:C_MAT_XC_CODE,:C_MAT_XC_NAME,:C_XC_BATCH_NO,:C_XC_LINEWH_CODE,:C_CHECKSTATE_NAME,:C_LINEWH_CODE,:C_LINEWH_NAME,:C_XC_BZYQ)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLANT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORD_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_QUA_TOTAL", OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_TOTAL", OracleDbType.Decimal,15),
                    new OracleParameter(":C_STL_GRD_SLAB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC_SLAB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SHIFT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GROUP", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":N_QUA_REMOVE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_REMOVE", OracleDbType.Decimal,15),
                    new OracleParameter(":C_MAT_SLAB_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_SLAB_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,15),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PRODUCE_DATE_B", OracleDbType.Date),
                    new OracleParameter(":C_PRODUCE_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRODUCE_SHIFT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRODUCE_GROUP", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PRODUCE_DATE_E", OracleDbType.Date),
                    new OracleParameter(":C_MAT_XC_CODE", OracleDbType.Varchar2, 100),
                    new OracleParameter(":C_MAT_XC_NAME", OracleDbType.Varchar2, 100),
                    new OracleParameter(":C_XC_BATCH_NO", OracleDbType.Varchar2, 100),
                    new OracleParameter(":C_XC_LINEWH_CODE",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CHECKSTATE_NAME",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_CODE",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_NAME",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_XC_BZYQ",OracleDbType.Varchar2,100),
            };
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_STA_ID;
            parameters[2].Value = model.C_PLANT;
            parameters[3].Value = model.C_ORD_ID;
            parameters[4].Value = model.C_BATCH_NO;
            parameters[5].Value = model.N_QUA_TOTAL;
            parameters[6].Value = model.N_WGT_TOTAL;
            parameters[7].Value = model.C_STL_GRD_SLAB;
            parameters[8].Value = model.C_SPEC_SLAB;
            parameters[9].Value = model.C_EMP_ID;
            parameters[10].Value = model.C_SHIFT;
            parameters[11].Value = model.C_GROUP;
            parameters[12].Value = model.D_MOD_DT;
            parameters[13].Value = model.N_QUA_REMOVE;
            parameters[14].Value = model.N_WGT_REMOVE;
            parameters[15].Value = model.C_MAT_SLAB_CODE;
            parameters[16].Value = model.C_MAT_SLAB_NAME;
            parameters[17].Value = model.C_REMARK;
            parameters[18].Value = model.N_STATUS;
            parameters[19].Value = model.C_STD_CODE;
            parameters[20].Value = model.D_PRODUCE_DATE_B;
            parameters[21].Value = model.C_PRODUCE_EMP_ID;
            parameters[22].Value = model.C_PRODUCE_SHIFT;
            parameters[23].Value = model.C_PRODUCE_GROUP;
            parameters[24].Value = model.D_PRODUCE_DATE_E;
            parameters[25].Value = model.C_MAT_XC_CODE;
            parameters[26].Value = model.C_MAT_XC_NAME;
            parameters[27].Value = model.C_XC_BATCH_NO;
            parameters[28].Value = model.C_XC_LINEWH_CODE;
            parameters[29].Value = model.C_CHECKSTATE_NAME;
            parameters[30].Value = model.C_LINEWH_CODE;
            parameters[31].Value = model.C_LINEWH_NAME;
            parameters[32].Value = model.C_XC_BZYQ;


            int rows = TransactionHelper.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(Mod_TRC_ROLL_WW_MAIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TRC_ROLL_WW_MAIN set ");
            strSql.Append("C_STA_ID=:C_STA_ID,");
            strSql.Append("C_PLANT=:C_PLANT,");
            strSql.Append("C_ORD_ID=:C_ORD_ID,");
            strSql.Append("C_BATCH_NO=:C_BATCH_NO,");
            strSql.Append("N_QUA_TOTAL=:N_QUA_TOTAL,");
            strSql.Append("N_WGT_TOTAL=:N_WGT_TOTAL,");
            strSql.Append("C_STL_GRD_SLAB=:C_STL_GRD_SLAB,");
            strSql.Append("C_SPEC_SLAB=:C_SPEC_SLAB,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_SHIFT=:C_SHIFT,");
            strSql.Append("C_GROUP=:C_GROUP,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("N_QUA_REMOVE=:N_QUA_REMOVE,");
            strSql.Append("N_WGT_REMOVE=:N_WGT_REMOVE,");
            strSql.Append("C_MAT_SLAB_CODE=:C_MAT_SLAB_CODE,");
            strSql.Append("C_MAT_SLAB_NAME=:C_MAT_SLAB_NAME,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_STD_CODE=:C_STD_CODE,");
            strSql.Append("D_PRODUCE_DATE_B=:D_PRODUCE_DATE_B,");
            strSql.Append("C_PRODUCE_EMP_ID=:C_PRODUCE_EMP_ID,");
            strSql.Append("C_PRODUCE_SHIFT=:C_PRODUCE_SHIFT,");
            strSql.Append("C_PRODUCE_GROUP=:C_PRODUCE_GROUP,");
            strSql.Append("D_PRODUCE_DATE_E=:D_PRODUCE_DATE_E,");
            strSql.Append("C_MAT_XC_CODE=:C_MAT_XC_CODE,");
            strSql.Append("C_MAT_XC_NAME=:C_MAT_XC_NAME,");
            strSql.Append("C_XC_BATCH_NO=:C_XC_BATCH_NO,");
            strSql.Append("C_XC_LINEWH_CODE=:C_XC_LINEWH_CODE,");
            strSql.Append("C_CHECKSTATE_NAME=:C_CHECKSTATE_NAME,");
            strSql.Append("C_LINEWH_CODE=:C_LINEWH_CODE,");
            strSql.Append("C_LINEWH_NAME=:C_LINEWH_NAME,");
            strSql.Append("C_XC_BZYQ=:C_XC_BZYQ,");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_STA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLANT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORD_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_QUA_TOTAL", OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_TOTAL", OracleDbType.Decimal,15),
                    new OracleParameter(":C_STL_GRD_SLAB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC_SLAB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SHIFT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GROUP", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":N_QUA_REMOVE", OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_REMOVE", OracleDbType.Decimal,15),
                    new OracleParameter(":C_MAT_SLAB_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_SLAB_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,15),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PRODUCE_DATE_B", OracleDbType.Date),
                    new OracleParameter(":C_PRODUCE_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRODUCE_SHIFT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRODUCE_GROUP", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PRODUCE_DATE_E", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_XC_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_XC_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_XC_BATCH_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_XC_LINEWH_CODE",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CHECKSTATE_NAME",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_CODE",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_NAME",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_XC_BZYQ",OracleDbType.Varchar2,100),
            };

            parameters[0].Value = model.C_STA_ID;
            parameters[1].Value = model.C_PLANT;
            parameters[2].Value = model.C_ORD_ID;
            parameters[3].Value = model.C_BATCH_NO;
            parameters[4].Value = model.N_QUA_TOTAL;
            parameters[5].Value = model.N_WGT_TOTAL;
            parameters[6].Value = model.C_STL_GRD_SLAB;
            parameters[7].Value = model.C_SPEC_SLAB;
            parameters[8].Value = model.C_EMP_ID;
            parameters[9].Value = model.C_SHIFT;
            parameters[10].Value = model.C_GROUP;
            parameters[11].Value = model.D_MOD_DT;
            parameters[12].Value = model.N_QUA_REMOVE;
            parameters[13].Value = model.N_WGT_REMOVE;
            parameters[14].Value = model.C_MAT_SLAB_CODE;
            parameters[15].Value = model.C_MAT_SLAB_NAME;
            parameters[16].Value = model.C_REMARK;
            parameters[17].Value = model.N_STATUS;
            parameters[18].Value = model.C_STD_CODE;
            parameters[19].Value = model.D_PRODUCE_DATE_B;
            parameters[20].Value = model.C_PRODUCE_EMP_ID;
            parameters[21].Value = model.C_PRODUCE_SHIFT;
            parameters[22].Value = model.C_PRODUCE_GROUP;
            parameters[23].Value = model.D_PRODUCE_DATE_E;
            parameters[24].Value = model.C_ID;
            parameters[25].Value = model.C_MAT_XC_CODE;
            parameters[26].Value = model.C_MAT_XC_NAME;
            parameters[27].Value = model.C_XC_BATCH_NO;
            parameters[28].Value = model.C_XC_LINEWH_CODE;
            parameters[29].Value = model.C_CHECKSTATE_NAME;
            parameters[30].Value = model.C_LINEWH_CODE;
            parameters[31].Value = model.C_LINEWH_NAME;
            parameters[32].Value = model.C_XC_BZYQ;

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
        /// 撤销组批计划，删除成品线材,还原组批计划状态到完工
        /// </summary>
        /// <param name="cId">组批计划ID</param>
        /// <param name="oldXCLst"></param>
        /// <param name="xcLst"></param>
        public void ResetZP(string cId, List<TRC_ROLL_WW_MAIN_ITEM> oldXCLst, List<Mod_TRC_ROLL_PRODCUT> xcLst)
        {
            try
            {
                TransactionHelper.BeginTransaction();

                foreach (var item in xcLst)
                {
                    string updateSql = $"UPDATE TRC_ROLL_PRODCUT SET C_MOVE_TYPE='QD' WHERE C_ID='{item.C_ID}'";
                    TransactionHelper.ExecuteSql(updateSql);
                }

                // 设置组批计划状态为完工
                TransactionHelper.ExecuteSql($"UPDATE TRC_ROLL_WW_MAIN SET N_STATUS=1 WHERE C_ID='{cId}'");

                TransactionHelper.Commit();
            }
            catch (Exception ex)
            {
                TransactionHelper.RollBack();
                throw ex;
            }
            //foreach (var item in oldXCLst)
            //{
            //    string updateSql = $"UPDATE TRC_ROLL_PRODCUT SET C_MOVE_TYPE='QE' WHERE C_ID='{item.C_SLAB_MAIN_ID}'";
            //    TransactionHelper.ExecuteSql(updateSql);
            //}
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TRC_ROLL_WW_MAIN ");
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
            strSql.Append("delete from TRC_ROLL_WW_MAIN ");
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
        public Mod_TRC_ROLL_WW_MAIN GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_STA_ID,C_PLANT,C_ORD_ID,C_BATCH_NO,N_QUA_TOTAL,N_WGT_TOTAL,C_STL_GRD_SLAB,C_SPEC_SLAB,C_EMP_ID,C_SHIFT,C_GROUP,D_MOD_DT,N_QUA_REMOVE,N_WGT_REMOVE,C_MAT_SLAB_CODE,C_MAT_SLAB_NAME,C_REMARK,N_STATUS,C_STD_CODE,D_PRODUCE_DATE_B,C_PRODUCE_EMP_ID,C_PRODUCE_SHIFT,C_PRODUCE_GROUP,D_PRODUCE_DATE_E,C_MAT_XC_CODE,C_MAT_XC_NAME,C_XC_BATCH_NO,C_XC_LINEWH_CODE,C_CHECKSTATE_NAME,C_LINEWH_CODE,C_LINEWH_NAME,C_XC_BZYQ from TRC_ROLL_WW_MAIN ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TRC_ROLL_WW_MAIN model = new Mod_TRC_ROLL_WW_MAIN();
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
        public Mod_TRC_ROLL_WW_MAIN DataRowToModel(DataRow row)
        {
            Mod_TRC_ROLL_WW_MAIN model = new Mod_TRC_ROLL_WW_MAIN();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_STA_ID"] != null)
                {
                    model.C_STA_ID = row["C_STA_ID"].ToString();
                }
                if (row["C_PLANT"] != null)
                {
                    model.C_PLANT = row["C_PLANT"].ToString();
                }
                if (row["C_ORD_ID"] != null)
                {
                    model.C_ORD_ID = row["C_ORD_ID"].ToString();
                }
                if (row["C_BATCH_NO"] != null)
                {
                    model.C_BATCH_NO = row["C_BATCH_NO"].ToString();
                }
                if (row["N_QUA_TOTAL"] != null && row["N_QUA_TOTAL"].ToString() != "")
                {
                    model.N_QUA_TOTAL = decimal.Parse(row["N_QUA_TOTAL"].ToString());
                }
                if (row["N_WGT_TOTAL"] != null && row["N_WGT_TOTAL"].ToString() != "")
                {
                    model.N_WGT_TOTAL = decimal.Parse(row["N_WGT_TOTAL"].ToString());
                }
                if (row["C_STL_GRD_SLAB"] != null)
                {
                    model.C_STL_GRD_SLAB = row["C_STL_GRD_SLAB"].ToString();
                }
                if (row["C_SPEC_SLAB"] != null)
                {
                    model.C_SPEC_SLAB = row["C_SPEC_SLAB"].ToString();
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["C_SHIFT"] != null)
                {
                    model.C_SHIFT = row["C_SHIFT"].ToString();
                }
                if (row["C_GROUP"] != null)
                {
                    model.C_GROUP = row["C_GROUP"].ToString();
                }
                if (row["D_MOD_DT"] != null && row["D_MOD_DT"].ToString() != "")
                {
                    model.D_MOD_DT = DateTime.Parse(row["D_MOD_DT"].ToString());
                }
                if (row["N_QUA_REMOVE"] != null && row["N_QUA_REMOVE"].ToString() != "")
                {
                    model.N_QUA_REMOVE = decimal.Parse(row["N_QUA_REMOVE"].ToString());
                }
                if (row["N_WGT_REMOVE"] != null && row["N_WGT_REMOVE"].ToString() != "")
                {
                    model.N_WGT_REMOVE = decimal.Parse(row["N_WGT_REMOVE"].ToString());
                }
                if (row["C_MAT_SLAB_CODE"] != null)
                {
                    model.C_MAT_SLAB_CODE = row["C_MAT_SLAB_CODE"].ToString();
                }
                if (row["C_MAT_SLAB_NAME"] != null)
                {
                    model.C_MAT_SLAB_NAME = row["C_MAT_SLAB_NAME"].ToString();
                }
                if (row["C_MAT_XC_CODE"] != null)
                {
                    model.C_MAT_XC_CODE = row["C_MAT_XC_CODE"].ToString();
                }
                if (row["C_MAT_XC_NAME"] != null)
                {
                    model.C_MAT_XC_NAME = row["C_MAT_XC_NAME"].ToString();
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["C_STD_CODE"] != null)
                {
                    model.C_STD_CODE = row["C_STD_CODE"].ToString();
                }
                if (row["D_PRODUCE_DATE_B"] != null && row["D_PRODUCE_DATE_B"].ToString() != "")
                {
                    model.D_PRODUCE_DATE_B = DateTime.Parse(row["D_PRODUCE_DATE_B"].ToString());
                }
                if (row["C_PRODUCE_EMP_ID"] != null)
                {
                    model.C_PRODUCE_EMP_ID = row["C_PRODUCE_EMP_ID"].ToString();
                }
                if (row["C_PRODUCE_SHIFT"] != null)
                {
                    model.C_PRODUCE_SHIFT = row["C_PRODUCE_SHIFT"].ToString();
                }
                if (row["C_PRODUCE_GROUP"] != null)
                {
                    model.C_PRODUCE_GROUP = row["C_PRODUCE_GROUP"].ToString();
                }
                if (row["D_PRODUCE_DATE_E"] != null && row["D_PRODUCE_DATE_E"].ToString() != "")
                {
                    model.D_PRODUCE_DATE_E = DateTime.Parse(row["D_PRODUCE_DATE_E"].ToString());
                }
                if (row["C_XC_BATCH_NO"] != null)
                {
                    model.C_XC_BATCH_NO = row["C_XC_BATCH_NO"].ToString();
                }
                if (row["C_XC_LINEWH_CODE"] != null)
                {
                    model.C_XC_LINEWH_CODE = row["C_XC_LINEWH_CODE"].ToString();
                }
                if (row["C_CHECKSTATE_NAME"] != null)
                {
                    model.C_XC_LINEWH_CODE = row["C_CHECKSTATE_NAME"].ToString();
                }
                if (row["C_LINEWH_CODE"] != null)
                {
                    model.C_LINEWH_CODE = row["C_LINEWH_CODE"].ToString();
                }
                if (row["C_LINEWH_NAME"] != null)
                {
                    model.C_LINEWH_NAME = row["C_LINEWH_NAME"].ToString();
                }
                if (row["C_XC_BZYQ"] != null)
                {
                    model.C_XC_BZYQ = row["C_XC_BZYQ"].ToString();
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
            strSql.Append("select C_ID,C_STA_ID,C_PLANT,C_ORD_ID,C_BATCH_NO,N_QUA_TOTAL,N_WGT_TOTAL,C_STL_GRD_SLAB,C_SPEC_SLAB,C_EMP_ID,C_SHIFT,C_GROUP,D_MOD_DT,N_QUA_REMOVE,N_WGT_REMOVE,C_MAT_SLAB_CODE,C_MAT_SLAB_NAME,C_REMARK,N_STATUS,C_STD_CODE,D_PRODUCE_DATE_B,C_PRODUCE_EMP_ID,C_PRODUCE_SHIFT,C_PRODUCE_GROUP,D_PRODUCE_DATE_E,C_MAT_XC_CODE,C_MAT_XC_NAME,C_XC_BATCH_NO,C_XC_LINEWH_CODE,C_CHECKSTATE_NAME,C_LINEWH_CODE,C_LINEWH_NAME,C_XC_BZYQ ");
            strSql.Append(" FROM TRC_ROLL_WW_MAIN ");
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
            strSql.Append("select count(1) FROM TRC_ROLL_WW_MAIN ");
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
            strSql.Append(")AS Row, T.*  from TRC_ROLL_WW_MAIN T ");
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
					new OracleParameter(":PageSize", OracleDbType.Decimal),
					new OracleParameter(":PageIndex", OracleDbType.Decimal),
					new OracleParameter(":IsReCount", OracleDbType.Clob),
					new OracleParameter(":OrderType", OracleDbType.Clob),
					new OracleParameter(":strWhere", OracleDbType.Varchar2,1000),
					};
			parameters[0].Value = "TRC_ROLL_WW_MAIN";
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

        #region 自定义
        /// <summary>
        /// 外委加工组批
        /// </summary>
        /// <param name="zpInfo"></param>
        public void SetZpInfo(
            Mod_TMO_ORDER order,
            WWZPPlanItemInfo zpInfo,
            List<Mod_TRC_ROLL_PRODCUT> batchInfo,
            string userId)
        {
            UpdateBatchSameToNc(
                zpInfo.InventoryCode,
                order.C_STL_GRD,
                order.C_STD_CODE,
                order.C_SPEC,
                zpInfo.CBatchNo,
                zpInfo.MtrlCode,
                zpInfo.ZLDJ,
                zpInfo.BZYQ,
                batchInfo);

            TransactionHelper.BeginTransaction();

            if (zpInfo.Num < batchInfo.Count)
            {
                // 如果组批支数等于库存支数，相当于耗用所有库存，则实际重量等于库存重量
                new Dal_TMO_ORDER().UpdateInventory(batchInfo, zpInfo.ZpAmt, zpInfo.Num);
            }

            var zpAmt = batchInfo.Take(zpInfo.Num).Sum(w => w.N_WGT);

            // 生成批次号
            var batchInfoItem = batchInfo.FirstOrDefault();
            // 构造外委加工组批主表记录
            var mainItem = new Mod_TRC_ROLL_WW_MAIN
            {
                C_ID = Guid.NewGuid().ToString("N"),
                C_ORD_ID = zpInfo.Id,
                N_WGT_TOTAL = zpAmt,
                N_STATUS = 0,
                C_EMP_ID = userId,
                C_GROUP = zpInfo.BZ,
                C_REMARK = zpInfo.Remark,
                C_SHIFT = zpInfo.BC,
                C_SPEC_SLAB = batchInfoItem.C_SPEC,
                C_CHECKSTATE_NAME = zpInfo.ZLDJ,
                C_STD_CODE = batchInfoItem.C_STD_CODE,
                C_STL_GRD_SLAB = batchInfoItem.C_STL_GRD,
                D_MOD_DT = DateTime.Now,
                N_QUA_TOTAL = zpInfo.Num,
                C_MAT_SLAB_CODE = order.C_MAT_CODE,
                C_MAT_SLAB_NAME = order.C_MAT_NAME,
                C_MAT_XC_CODE = batchInfoItem.C_MAT_CODE,
                C_MAT_XC_NAME = batchInfoItem.C_MAT_DESC,
                C_XC_BATCH_NO = batchInfoItem.C_BATCH_NO,
                C_XC_LINEWH_CODE = batchInfoItem.C_LINEWH_CODE,// zpInfo.InventoryCode,
                C_XC_BZYQ = batchInfoItem.C_BZYQ
            };

            if (string.IsNullOrEmpty(zpInfo.BachNo) == false)
            {
                var a = ExistBatchNo(zpInfo.BachNo);
                // 验证批号
                //string existsSql = $"SELECT COUNT(C_ID) FROM TRC_ROLL_WW_MAIN WHERE C_BATCH_NO='{zpInfo.BachNo}'";
                //var count = int.Parse(TransactionHelper.Query(existsSql).Tables[0].Rows[0][0]?.ToString() ?? "0");
                if (a)//count > 0)
                {
                    TransactionHelper.RollBack();
                    throw new Exception("批次号重复，请重新输入");
                }

                mainItem.C_BATCH_NO = zpInfo.BachNo;
            }
            else
            {
                mainItem.C_BATCH_NO = GetMAXWWBatchNo();
            }

            bool success = this.Add(mainItem);

            if (success == false)
            {
                TransactionHelper.RollBack();
                throw new Exception("组批失败");
            }
            try
            {
                for (int i = 0; i < zpInfo.Num; i++)
                {
                    // 更新线材库存状态
                    string updateSql = $"UPDATE TRC_ROLL_PRODCUT SET C_MOVE_TYPE = 'QS' WHERE C_ID='{batchInfo[i].C_ID}'";

                    TransactionHelper.ExecuteSql(updateSql);

                    // 插入外委加工组批子表记录
                    string insertSql = $"insert into TRC_ROLL_WW_MAIN_ITEM(C_ID,C_ROLL_WW_MAIN_ID,C_SLAB_MAIN_ID,N_WGT) " +
                        $"VALUES('{Guid.NewGuid().ToString("N")}','{mainItem.C_ID}','{batchInfo[i].C_ID}',{batchInfo[i].N_WGT})";

                    TransactionHelper.ExecuteSql(insertSql);
                }
            }
            catch (Exception ex)
            {
                TransactionHelper.RollBack();
                throw ex;
            }

            TransactionHelper.Commit();
        }

        /// <summary>
        /// 将线材修改为与NC一致,验证NC批号与组批线材批号是否一致
        /// </summary>
        private void UpdateBatchSameToNc(
            string lineCode,
            string stlGrd,
            string stdCode,
            string sepc,
            string batchNo,
            string mtrlCode,
            string zldj,
            string bzyq,
            List<Mod_TRC_ROLL_PRODCUT> batchInfos)
        {
            // 验证NC线材批号与组批批号是否一致，如果不一致则要求先修改批号后再上传NC
            var ncDatas = new Dal_TMO_ORDER().GetNCInventory(
                lineCode,//zpInfo.InventoryCode,
                stlGrd,//order.C_STL_GRD,
                stdCode,//order.C_STD_CODE,
                sepc,//order.C_SPEC,
                batchNo//zpInfo.CBatchNo
                ).Where(w =>
                w.MtrlCode == mtrlCode &&//zpInfo.MtrlCode &&
                w.ZLDJ == zldj//zpInfo.ZLDJ
                ).Where(w => w.BZYQ == bzyq).ToList();

            // 如果nc不存在
            if (ncDatas.Any() == false)
            {
                throw new Exception("NC不存在组批线材批号");
            }
            // 如果与NC批号一致，不处理
            if (ncDatas.Exists(w => w.BatchNo == batchNo)) { return; }

            var newBatchNo = ncDatas.Select(w => w.BatchNo).FirstOrDefault();

            // 更新线材批号
            foreach (var item in batchInfos)
            {
                // 更新线材批号
                string updateSql = $"UPDATE TRC_ROLL_PRODCUT SET C_BATCH_NO = '{newBatchNo}' WHERE C_ID='{item.C_ID}'";
                DbHelperOra.ExecuteSql(updateSql);
                item.C_BATCH_NO = newBatchNo;
            }
        }

        public void UpdateBatchSameToNcAndSyncXNCF(string lineCode,
            string stlGrd,
            string stdCode,
            string sepc,
            string batchNo,
            string mtrlCode,
            string zldj,
            string bzyq,
            List<Mod_TRC_ROLL_PRODCUT> batchInfos)
        {
            this.UpdateBatchSameToNc(lineCode, stlGrd, stdCode, sepc, batchNo, mtrlCode, zldj, bzyq, batchInfos);

            if (batchInfos.Any())
            {
                if (batchNo == batchInfos.FirstOrDefault().C_BATCH_NO)
                {
                    throw new Exception("批号一致不需要修改!");
                }

                // 更新批号后再线材成分性能
                string updateSql = $@"insert into tqc_compre_item_result(
c_stove,c_batch_no,c_stl_grd,c_spec,c_std_code,c_character_id,
c_item_name,c_target_min,c_target_interval,c_target_max,c_type,c_unit,
c_quantitative,c_value,c_result,c_check_state,n_status,c_remark,c_emp_id,d_mod_dt,
c_design_no,n_print_order,c_tick_no,c_is_show,c_is_decide,c_group,c_tb,c_source,n_recheck,c_zzs_use)
select 
c_stove,'{batchInfos.FirstOrDefault().C_BATCH_NO}',c_stl_grd,c_spec,c_std_code,c_character_id,
c_item_name,c_target_min,c_target_interval,c_target_max,c_type,c_unit,
c_quantitative,c_value,c_result,c_check_state,n_status,c_remark,c_emp_id,d_mod_dt,
c_design_no,n_print_order,c_tick_no,c_is_show,c_is_decide,c_group,c_tb,c_source,n_recheck,c_zzs_use
from TQC_COMPRE_ITEM_RESULT where c_batch_no = '{batchNo}' ";
                DbHelperOra.ExecuteSql(updateSql);
            }
        }


        /// <summary>
        /// 获取委外最大批次号（最大流水号，最多支持一天9999999）
        /// </summary>
        /// <returns></returns>
        private string GetMAXWWBatchNo()
        {
            string datePart = DateTime.Now.ToString("yyMMdd");
            string header = $"WW{datePart}";
            string sql = $"SELECT MAX(C_BATCH_NO) FROM TRC_ROLL_WW_MAIN WHERE C_BATCH_NO LIKE '{header}%'";
            var obj = DbHelperOra.GetSingle(sql)?.ToString();

            if (string.IsNullOrEmpty(obj))
            {
                obj = $"{header}0000001";
            }
            else
            {
                int seq = int.Parse(obj.Replace(header, ""));
                obj = $"{header}{(seq + 1).ToString("0000000")}";
            }

            return obj;
        }

        /// <summary>
        /// 撤销外委组批
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="num"></param>
        public void CancelZpInfo(string itemId, decimal num)
        {
            var zpInfo = GetModel(itemId);

            if (zpInfo == null) throw new Exception("未找到组批数据，请重试");

            if (zpInfo.N_STATUS != 0)
            {
                throw new Exception("不能撤销，数据已经被操作");
            }

            if (zpInfo.N_QUA_TOTAL < num) throw new Exception($"退库数量不能大于{zpInfo.N_QUA_TOTAL}");

            TransactionHelper.BeginTransaction();
            try
            {
                var lstItems = GetWWItemByZpId(zpInfo.C_ID);

                // 部分撤销
                if (lstItems.Count < num)
                {
                    throw new Exception($"数据错误,退库数量不能大于{zpInfo.N_QUA_TOTAL}");
                }

                var delItems = lstItems.Take((int)num);

                if (zpInfo.N_QUA_TOTAL == num)
                {
                    // 全部撤销，删除子表及主表记录
                    string delItemSql = $"DELETE TRC_ROLL_WW_MAIN_ITEM WHERE C_ROLL_WW_MAIN_ID='{zpInfo.C_ID}'";
                    TransactionHelper.ExecuteSql(delItemSql);
                    string delSql = $"DELETE TRC_ROLL_WW_MAIN WHERE C_ID='{zpInfo.C_ID}'";
                    TransactionHelper.ExecuteSql(delSql);

                    // 退库
                }
                else
                {
                    // 剩余的重量，用于更新
                    var wgt = lstItems.Skip((int)num).Sum(w => w.N_WGT);

                    // 删除的ID
                    var delIds = "('" + string.Join("','", delItems.Select(w => w.C_ID)) + "')";
                    var delSql = $"DELETE TRC_ROLL_WW_MAIN_ITEM WHERE C_ID IN{delIds}";
                    TransactionHelper.ExecuteSql(delSql);

                    // 更新主表支数，重量
                    string updateSql = $"UPDATE TRC_ROLL_WW_MAIN " +
                        $"SET N_QUA_TOTAL={lstItems.Count - num},N_WGT_TOTAL={wgt} WHERE C_ID='{zpInfo.C_ID}'";
                    TransactionHelper.ExecuteSql(updateSql);
                }

                // 退库
                var updateIds = "('" + string.Join("','", delItems.Select(w => w.C_SLAB_MAIN_ID)) + "')";
                string updateProductSql = $"UPDATE TRC_ROLL_PRODCUT SET C_MOVE_TYPE = 'QE' WHERE C_ID IN{updateIds}";
                TransactionHelper.ExecuteSql(updateProductSql);

            }
            catch (Exception ex)
            {
                TransactionHelper.RollBack();
                throw ex;
            }

            TransactionHelper.Commit();
        }

        public List<TRC_ROLL_WW_MAIN_ITEM> GetWWItemByZpId(string cId)
        {
            var selItemsSql = $"SELECT T.* FROM TRC_ROLL_WW_MAIN_ITEM T WHERE T.C_ROLL_WW_MAIN_ID='{cId}'";
            var lstItems = DbHelperOra.Query(selItemsSql).Tables[0].DataTableToList2<TRC_ROLL_WW_MAIN_ITEM>();

            return lstItems;
        }

        /// <summary>
        /// 获取成分转换成品线材
        /// </summary>
        /// <param name="batchNo"></param>
        /// <returns></returns>
        public List<Mod_TRC_ROLL_PRODCUT> GetProductsByZpId(string batchNo)
        {
            var selItemsSql = $"SELECT T.* FROM TRC_ROLL_PRODCUT T WHERE T.C_BATCH_NO='{batchNo}'";
            var lstItems = DbHelperOra.Query(selItemsSql).Tables[0].DataTableToList2<Mod_TRC_ROLL_PRODCUT>();

            return lstItems;
        }

        /// <summary>
        /// 获取组批信息
        /// </summary>
        /// <returns></returns>
        public List<Mod_TRC_ROLL_PRODCUT> GetItemList(string zpId)
        {
            var selItemsSql = $"select t.*  from   TRC_ROLL_PRODCUT T WHERE T.C_ID in(" +
                $"select T1.C_SLAB_MAIN_ID from  TRC_ROLL_WW_MAIN_ITEM T1 WHERE T1.C_ROLL_WW_MAIN_ID = '{zpId}' )";
            return DbHelperOra.Query(selItemsSql).Tables[0].DataTableToList2<Mod_TRC_ROLL_PRODCUT>();

        }

        public string GetDesignNo(string c_std_code, string c_stl_grd)
        {
            string sql = $@"
select ta.c_design_no from tqb_design ta 
inner join tqb_std_main tb on ta.c_std_main_id=tb.c_id 
where tb.n_is_check=1 and tb.n_status=1 and tb.c_std_code='{c_std_code}' and tb.c_stl_grd='{c_stl_grd}'
";

            return DbHelperOra.GetSingle(sql) as string;
        }

        public void SetFinish(Mod_TRC_ROLL_WW_MAIN model)
        {
            try
            {
                TransactionHelper.BeginTransaction();

                string sql = $"UPDATE TRC_ROLL_WW_MAIN SET N_WGT_REMOVE={model.N_WGT_REMOVE}" +
                    $",N_QUA_REMOVE={model.N_QUA_REMOVE}" +
                    $",N_STATUS={model.N_STATUS}" +
                    $",C_PRODUCE_GROUP='{model.C_PRODUCE_GROUP}'" +
                    $",C_CHECKSTATE_NAME='{model.C_CHECKSTATE_NAME}'" +
                    $",C_LINEWH_CODE='{model.C_LINEWH_CODE}'" +
                    $",C_LINEWH_NAME='{model.C_LINEWH_NAME}'" +
                    $",C_PRODUCE_EMP_ID='{model.C_PRODUCE_EMP_ID}'" +
                    $",C_PRODUCE_SHIFT='{model.C_PRODUCE_SHIFT}' WHERE C_ID='{model.C_ID}'";

                //                // 完工量不等于组批量，回写库存重量
                //                var amt = model.N_WGT_TOTAL - model.N_WGT_REMOVE;
                //                if (amt > 0)
                //                {
                //                    string whereSql = $@"
                //SELECT MAX(C_ID) FROM TRC_ROLL_PRODCUT  
                //WHERE C_BATCH_NO='{model.C_XC_BATCH_NO}' AND C_LINEWH_CODE='{model.C_XC_LINEWH_CODE}' 
                //AND C_MAT_CODE='{model.C_MAT_XC_CODE}' AND C_BZYQ='{model.C_XC_BZYQ}' 
                //AND C_MOVE_TYPE='QE'
                //";
                //                    var cId = TransactionHelper.GetSingle(whereSql)?.ToString();

                //                    if (string.IsNullOrEmpty(cId))
                //                    {
                //                        throw new Exception("找不到记录库存");
                //                    }

                //                    var updateSql = $"UPDATE TRC_ROLL_PRODCUT SET N_WGT={amt} WHERE C_ID='{cId}'";

                //                    var updateRlt = TransactionHelper.ExecuteSql(updateSql);

                //                    if (updateRlt != 1)
                //                    {
                //                        throw new Exception("更新库存失败");
                //                    }
                //                }

                var rlt = TransactionHelper.ExecuteSql(sql) > 0;

                if (!rlt)
                {
                    throw new Exception("完工失败");
                }

                TransactionHelper.Commit();
            }
            catch (Exception ex)
            {
                TransactionHelper.RollBack();
                throw ex;
            }
        }

        /// <summary>
        /// 验证批次号唯一
        /// </summary>
        /// <param name="newBatchNo"></param>
        /// <returns></returns>
        public bool ExistBatchNo(string newBatchNo)
        {
            // 委外表
            var existSql1 = $"SELECT COUNT(1) FROM trc_roll_ww_main WHERE C_BATCH_NO='{newBatchNo}'";
            // 线材库表，之前存在的批次
            var existSql2 = $"SELECT COUNT(1) FROM trc_roll_prodcut WHERE C_BATCH_NO='{newBatchNo}'";
            return Convert.ToInt32(DbHelperOra.GetSingle(existSql1)) > 0 || Convert.ToInt32(DbHelperOra.GetSingle(existSql2)) > 0;
        }

        /// <summary>
        /// 修改批次号，如果录入了成分，需要把成分的批次号更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="newBatchNo"></param>
        public void UpdateBatchNo(Mod_TRC_ROLL_WW_MAIN model, string newBatchNo)
        {
            try
            {
                // 采取事物控制
                TransactionHelper.BeginTransaction();
                // 更新成分信息
                string updateSql1 = $"UPDATE TQC_COMPRE_ITEM_RESULT SET C_BATCH_NO='{newBatchNo}' WHERE C_BATCH_NO='{model.C_BATCH_NO}'";
                // 组批计划更新批号
                string updateSql2 = $"UPDATE TRC_ROLL_WW_MAIN SET C_BATCH_NO='{newBatchNo}' WHERE C_BATCH_NO='{model.C_BATCH_NO}'";

                TransactionHelper.ExecuteSql(updateSql1);
                TransactionHelper.ExecuteSql(updateSql2);
                TransactionHelper.Commit();
            }
            catch (Exception ex)
            {
                TransactionHelper.RollBack();

                throw new Exception("修改批次号失败");
            }
        }

        public bool SetCancel(Mod_TRC_ROLL_WW_MAIN model)
        {
            string sql = $"UPDATE TRC_ROLL_WW_MAIN SET N_WGT_REMOVE={model.N_WGT_REMOVE ?? 0}" +
                $",N_QUA_REMOVE={model.N_QUA_REMOVE ?? 0}" +
                $",N_STATUS={model.N_STATUS}" +
                $" WHERE C_ID='{model.C_ID}'";

            return DbHelperOra.ExecuteSql(sql) > 0;
        }

        public bool SetStatu(Mod_TRC_ROLL_WW_MAIN model)
        {
            string cId = model.C_ID;
            decimal status = model.N_STATUS;

            string sql = $"UPDATE TRC_ROLL_WW_MAIN SET " +
                $"N_STATUS={status}" +
                $" WHERE C_ID='{cId}'";

            return DbHelperOra.ExecuteSql(sql) > 0;
        }

        /// <summary>
        /// 设置质量标准号
        /// </summary>
        /// <param name="model"></param>
        public void SetDesignNo(Mod_TRC_ROLL_WW_MAIN model)
        {
            string designNo = GetDesignNo(model.C_STD_CODE, model.C_STL_GRD_SLAB);
            string sql = $"UPDATE trc_roll_prodcut SET " +
                $"c_design_no='{designNo}'" +
                $" WHERE c_batch_no='{model.C_BATCH_NO}'";

            DbHelperOra.ExecuteSql(sql);
        }

        #endregion

    }
}

