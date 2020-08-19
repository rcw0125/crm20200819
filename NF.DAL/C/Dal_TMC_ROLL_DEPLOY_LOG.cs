using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 线材调配记录
    /// </summary>
    public partial class Dal_TMC_ROLL_DEPLOY_LOG
    {
        public Dal_TMC_ROLL_DEPLOY_LOG()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMC_ROLL_DEPLOY_LOG");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID",OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMC_ROLL_DEPLOY_LOG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMC_ROLL_DEPLOY_LOG(");
            strSql.Append("C_ID,C_BATCH_NO,C_MAT_CODE,C_STL_GRD,C_SPEC,C_OLDAREA,C_NEWAREA,C_EMPID,C_EMPNAME,D_MOD)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_BATCH_NO,:C_MAT_CODE,:C_STL_GRD,:C_SPEC,:C_OLDAREA,:C_NEWAREA,:C_EMPID,:C_EMPNAME,:D_MOD)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_OLDAREA",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NEWAREA",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMPID",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMPNAME",OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD", OracleDbType.Date)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_BATCH_NO;
            parameters[2].Value = model.C_MAT_CODE;
            parameters[3].Value = model.C_STL_GRD;
            parameters[4].Value = model.C_SPEC;
            parameters[5].Value = model.C_OLDAREA;
            parameters[6].Value = model.C_NEWAREA;
            parameters[7].Value = model.C_EMPID;
            parameters[8].Value = model.C_EMPNAME;
            parameters[9].Value = model.D_MOD;

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
        public bool Update(Mod_TMC_ROLL_DEPLOY_LOG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMC_ROLL_DEPLOY_LOG set ");
            strSql.Append("C_BATCH_NO=:C_BATCH_NO,");
            strSql.Append("C_MAT_CODE=:C_MAT_CODE,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_SPEC=:C_SPEC,");
            strSql.Append("C_OLDAREA=:C_OLDAREA,");
            strSql.Append("C_NEWAREA=:C_NEWAREA,");
            strSql.Append("C_EMPID=:C_EMPID,");
            strSql.Append("C_EMPNAME=:C_EMPNAME,");
            strSql.Append("D_MOD=:D_MOD");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_BATCH_NO",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_OLDAREA",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NEWAREA",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMPID",OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMPNAME",OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD", OracleDbType.Date),
                    new OracleParameter(":C_ID",OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_BATCH_NO;
            parameters[1].Value = model.C_MAT_CODE;
            parameters[2].Value = model.C_STL_GRD;
            parameters[3].Value = model.C_SPEC;
            parameters[4].Value = model.C_OLDAREA;
            parameters[5].Value = model.C_NEWAREA;
            parameters[6].Value = model.C_EMPID;
            parameters[7].Value = model.C_EMPNAME;
            parameters[8].Value = model.D_MOD;
            parameters[9].Value = model.C_ID;

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
            strSql.Append("delete from TMC_ROLL_DEPLOY_LOG ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID",OracleDbType.Varchar2,100)          };
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
            strSql.Append("delete from TMC_ROLL_DEPLOY_LOG ");
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
        public Mod_TMC_ROLL_DEPLOY_LOG GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_BATCH_NO,C_MAT_CODE,C_STL_GRD,C_SPEC,C_OLDAREA,C_NEWAREA,C_EMPID,C_EMPNAME,D_MOD from TMC_ROLL_DEPLOY_LOG ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID",OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TMC_ROLL_DEPLOY_LOG model = new Mod_TMC_ROLL_DEPLOY_LOG();
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
        public Mod_TMC_ROLL_DEPLOY_LOG DataRowToModel(DataRow row)
        {
            Mod_TMC_ROLL_DEPLOY_LOG model = new Mod_TMC_ROLL_DEPLOY_LOG();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_BATCH_NO"] != null)
                {
                    model.C_BATCH_NO = row["C_BATCH_NO"].ToString();
                }
                if (row["C_MAT_CODE"] != null)
                {
                    model.C_MAT_CODE = row["C_MAT_CODE"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_SPEC"] != null)
                {
                    model.C_SPEC = row["C_SPEC"].ToString();
                }
                if (row["C_OLDAREA"] != null)
                {
                    model.C_OLDAREA = row["C_OLDAREA"].ToString();
                }
                if (row["C_NEWAREA"] != null)
                {
                    model.C_NEWAREA = row["C_NEWAREA"].ToString();
                }
                if (row["C_EMPID"] != null)
                {
                    model.C_EMPID = row["C_EMPID"].ToString();
                }
                if (row["C_EMPNAME"] != null)
                {
                    model.C_EMPNAME = row["C_EMPNAME"].ToString();
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
            strSql.Append("select C_ID,C_BATCH_NO,C_MAT_CODE,C_STL_GRD,C_SPEC,C_OLDAREA,C_NEWAREA,C_EMPID,C_EMPNAME,D_MOD ");
            strSql.Append(" FROM TMC_ROLL_DEPLOY_LOG ");
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
            strSql.Append("select count(1) FROM TMC_ROLL_DEPLOY_LOG ");
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
            strSql.Append(")AS Row, T.*  from TMC_ROLL_DEPLOY_LOG T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 线材批次查询
        /// </summary>
        /// <param name="batch">批次</param>
        /// <returns></returns>
        public DataSet GetCheckRollProc(string batch)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select t.c_id, t.c_batch_no,
                                       t.c_mat_code,
                                       t.c_stl_grd,
                                       t.c_spec,
                                       t.c_std_code,
                                       t.c_zyx1,
                                       t.c_zyx2,
                                       t.C_IS_QR,
                                       t.c_mat_code,
                                       t.c_std_code,
                                       t.c_sale_area,
                                       t.C_BZYQ,
                                       t.C_JUDGE_LEV_ZH
                                  from trc_roll_prodcut t where t.c_move_type='E' and t.c_batch_no='{0}'
                                ", batch);

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 按批次线材区域调整
        /// </summary>
        /// <param name="list">日志</param>
        /// <returns></returns>
        public bool InsertRoll_Proc(List<Mod_TMC_ROLL_DEPLOY_LOG> list)
        {
            ArrayList arraySql = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into TMC_ROLL_DEPLOY_LOG(C_BATCH_NO,C_MAT_CODE,C_STL_GRD,C_SPEC,C_OLDAREA,C_NEWAREA,C_EMPID,C_EMPNAME,C_ROLL_PROCID,C_QUA,C_PACK,C_JUDGE_LEV,C_STD_CODE,C_REMARK)values(");
                strSql.Append("'" + list[i].C_BATCH_NO + "',");
                strSql.Append("'" + list[i].C_MAT_CODE + "',");
                strSql.Append("'" + list[i].C_STL_GRD + "',");
                strSql.Append("'" + list[i].C_SPEC + "',");
                strSql.Append("'" + list[i].C_OLDAREA + "',");
                strSql.Append("'" + list[i].C_NEWAREA + "',");
                strSql.Append("'" + list[i].C_EMPID + "',");
                strSql.Append("'" + list[i].C_EMPNAME + "',");
                strSql.Append("'" + list[i].C_ROLL_PROCID + "',");
                strSql.Append("'" + list[i].C_QUA + "',");
                strSql.Append("'" + list[i].C_PACK + "',");
                strSql.Append("'" + list[i].C_JUDGE_LEV + "',");
                strSql.Append("'" + list[i].C_STD_CODE + "',");
                strSql.Append("'整批调配'");
                strSql.Append(")");
                arraySql.Add(strSql.ToString());
                StringBuilder strSql2 = new StringBuilder();
                if (!string.IsNullOrEmpty(list[i].C_OLDAREA))
                {
                    if (!string.IsNullOrEmpty(list[i].C_PACK))
                    {
                        strSql2.Append("update trc_roll_prodcut t set t.C_SALE_AREA='" + list[i].C_NEWAREA + "',t.C_CKDH='" + list[i].C_OLDAREA + "' where t.c_batch_no='" + list[i].C_BATCH_NO + "' and t.c_move_type='E' and t.C_SALE_AREA='" + list[i].C_OLDAREA + "' and t.C_STL_GRD='" + list[i].C_STL_GRD + "' and t.C_STD_CODE='" + list[i].C_STD_CODE + "' and t.C_JUDGE_LEV_BP='" + list[i].C_JUDGE_LEV_BP + "' and t.C_BZYQ='" + list[i].C_PACK + "'");
                    }
                    else
                    {
                        strSql2.Append("update trc_roll_prodcut t set t.C_SALE_AREA='" + list[i].C_NEWAREA + "',t.C_CKDH='" + list[i].C_OLDAREA + "' where t.c_batch_no='" + list[i].C_BATCH_NO + "' and t.c_move_type='E' and t.C_SALE_AREA='" + list[i].C_OLDAREA + "' and t.C_STL_GRD='" + list[i].C_STL_GRD + "' and t.C_STD_CODE='" + list[i].C_STD_CODE + "' and t.C_JUDGE_LEV_BP='" + list[i].C_JUDGE_LEV_BP + "' and t.C_BZYQ is null");
                    }

                }
                else
                {
                    if (!string.IsNullOrEmpty(list[i].C_PACK))
                    {

                        strSql2.Append("update trc_roll_prodcut t set t.C_SALE_AREA='" + list[i].C_NEWAREA + "',t.C_CKDH='" + list[i].C_OLDAREA + "'  where t.c_batch_no='" + list[i].C_BATCH_NO + "' and t.c_move_type='E' and t.C_SALE_AREA is null and t.C_STL_GRD='" + list[i].C_STL_GRD + "' and t.C_STD_CODE='" + list[i].C_STD_CODE + "' and t.C_JUDGE_LEV_BP='" + list[i].C_JUDGE_LEV_BP + "' and t.C_BZYQ='" + list[i].C_PACK + "'");
                    }
                    else
                    {
                        strSql2.Append("update trc_roll_prodcut t set t.C_SALE_AREA='" + list[i].C_NEWAREA + "',t.C_CKDH='" + list[i].C_OLDAREA + "'  where t.c_batch_no='" + list[i].C_BATCH_NO + "' and t.c_move_type='E' and t.C_SALE_AREA is null and t.C_STL_GRD='" + list[i].C_STL_GRD + "' and t.C_STD_CODE='" + list[i].C_STD_CODE + "' and t.C_JUDGE_LEV_BP='" + list[i].C_JUDGE_LEV_BP + "' and t.C_BZYQ is null");
                    }
                }

                arraySql.Add(strSql2.ToString());

            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 按单卷线材区域调整
        /// </summary>
        /// <param name="list">日志</param>
        /// <returns></returns>
        public bool InsertRoll_Proc2(List<Mod_TMC_ROLL_DEPLOY_LOG> list)
        {
            ArrayList arraySql = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into TMC_ROLL_DEPLOY_LOG(C_BATCH_NO,C_MAT_CODE,C_STL_GRD,C_SPEC,C_OLDAREA,C_NEWAREA,C_EMPID,C_EMPNAME,C_ROLL_PROCID,C_QUA,C_PACK,C_JUDGE_LEV,C_STD_CODE,C_REMARK)values(");
                strSql.Append("'" + list[i].C_BATCH_NO + "',");
                strSql.Append("'" + list[i].C_MAT_CODE + "',");
                strSql.Append("'" + list[i].C_STL_GRD + "',");
                strSql.Append("'" + list[i].C_SPEC + "',");
                strSql.Append("'" + list[i].C_OLDAREA + "',");
                strSql.Append("'" + list[i].C_NEWAREA + "',");
                strSql.Append("'" + list[i].C_EMPID + "',");
                strSql.Append("'" + list[i].C_EMPNAME + "',");
                strSql.Append("'" + list[i].C_ROLL_PROCID + "',");
                strSql.Append("'1',");
                strSql.Append("'" + list[i].C_PACK + "',");
                strSql.Append("'" + list[i].C_JUDGE_LEV + "',");
                strSql.Append("'" + list[i].C_STD_CODE + "',");
                strSql.Append("'单卷调配'");
                strSql.Append(")");
                arraySql.Add(strSql.ToString());
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("update trc_roll_prodcut t set t.C_SALE_AREA='" + list[i].C_NEWAREA + "',t.C_CKDH='" + list[i].C_OLDAREA + "' where t.C_ID='" + list[i].C_ROLL_PROCID + "' and  t.c_batch_no='" + list[i].C_BATCH_NO + "' and t.c_move_type='E'");
                arraySql.Add(strSql2.ToString());

            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 线材区域客户调整
        /// </summary>
        /// <param name="list">日志</param>
        /// <returns></returns>
        public bool InsertRoll_Proc3(List<Mod_TMC_ROLL_DEPLOY_LOG> list)
        {
            ArrayList arraySql = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into TMC_ROLL_DEPLOY_LOG(C_BATCH_NO,C_MAT_CODE,C_STL_GRD,C_SPEC,C_OLDAREA,C_NEWAREA,C_EMPID,C_EMPNAME,C_ROLL_PROCID,C_QUA,C_PACK,C_JUDGE_LEV,C_STD_CODE,C_REMARK,C_OLDCUST,C_NEWCUST,C_OLDCON,C_NEWCON)values(");
                strSql.Append("'" + list[i].C_BATCH_NO + "',");
                strSql.Append("'" + list[i].C_MAT_CODE + "',");
                strSql.Append("'" + list[i].C_STL_GRD + "',");
                strSql.Append("'" + list[i].C_SPEC + "',");
                strSql.Append("'" + list[i].C_OLDAREA + "',");
                strSql.Append("'" + list[i].C_NEWAREA + "',");
                strSql.Append("'" + list[i].C_EMPID + "',");
                strSql.Append("'" + list[i].C_EMPNAME + "',");
                strSql.Append("'" + list[i].C_ROLL_PROCID + "',");
                strSql.Append("'1',");
                strSql.Append("'" + list[i].C_PACK + "',");
                strSql.Append("'" + list[i].C_JUDGE_LEV + "',");
                strSql.Append("'" + list[i].C_STD_CODE + "',");
                strSql.Append("'单卷调配',");
                strSql.Append("'" + list[i].C_OLDCUST + "',");
                strSql.Append("'" + list[i].C_NEWCUST + "',");
                strSql.Append("'" + list[i].C_OLDCON + "',");
                strSql.Append("'" + list[i].C_NEWCON + "'");
                strSql.Append(")");
                arraySql.Add(strSql.ToString());
                StringBuilder strSql2 = new StringBuilder();

                string str = $@"SELECT MAX(TT.C_ORDER_NO) C_ORDER_NO
                                  FROM (SELECT T.C_ORDER_NO,
                                               T.N_LINE_MATCH_WGT,
                                               T.N_WGT,
                                               (NVL(T.N_WGT, 0) - NVL(T.N_LINE_MATCH_WGT, 0)) MAXWGT,
                                               T.C_MAT_CODE,
                                               T.C_STL_GRD
                                          FROM TMO_ORDER T
                                         WHERE T.C_CON_NO = '{list[i].C_NEWCON}'
                                           AND T.C_MAT_CODE = '{list[i].C_MAT_CODE}' AND T.C_PACK='{list[i].C_PACK}' and t.C_STD_CODE='{list[i].C_STD_CODE}' ) TT
                                 ORDER BY TT.MAXWGT DESC";

                DataTable dt = DbHelperOra.Query(str).Tables[0];

              

                if (dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0]["C_ORDER_NO"].ToString()))
                {

                    #region //排产订单分配量减量
                    string str2 = $@"SELECT T.C_ORDER_NO, T.N_WGT
                                      FROM TRC_ROLL_PRODCUT T
                                     WHERE T.C_ID = '{list[i].C_ROLL_PROCID}'";

                    DataTable dt2 = DbHelperOra.Query(str2).Tables[0];

                    string oldorder = dt2.Rows[0]["C_ORDER_NO"].ToString();

                    string rollwgt = dt2.Rows[0]["N_WGT"].ToString();

                    string updatejian = $@"update tmo_order t set t.n_line_match_wgt=nvl(t.n_line_match_wgt,0)-{rollwgt} where t.C_ORDER_NO='{oldorder}'";

                    arraySql.Add(updatejian);

                    #endregion

                    string neworder = dt.Rows[0]["C_ORDER_NO"].ToString();

                    string updateadd = $@"update tmo_order t set t.n_line_match_wgt=nvl(t.n_line_match_wgt,0)+{rollwgt} where t.C_ORDER_NO='{neworder}'";

                    arraySql.Add(updateadd);

                    strSql2.Append("update trc_roll_prodcut t set t.C_SALE_AREA='" + list[i].C_NEWAREA + "',t.C_CUST_NAME='" + list[i].C_NEWCUST + "',t.C_CKDH='" + list[i].C_OLDAREA + "',t.C_CKRY='" + list[i].C_OLDCUST + "',T.C_CON_NO='" + list[i].C_NEWCON + "',T.C_ORDER_NO='" + neworder + "' where t.C_ID='" + list[i].C_ROLL_PROCID + "' and  t.c_batch_no='" + list[i].C_BATCH_NO + "' and t.c_move_type='E'");

                    arraySql.Add(strSql2.ToString());
                }
                else
                {

                    strSql2.Append("update trc_roll_prodcut t set t.C_SALE_AREA='" + list[i].C_NEWAREA + "',t.C_CUST_NAME='" + list[i].C_NEWCUST + "',t.C_CKDH='" + list[i].C_OLDAREA + "',t.C_CKRY='" + list[i].C_OLDCUST + "',T.C_CON_NO='" + list[i].C_NEWCON + "',T.C_ORDER_NO=NULL where t.C_ID='" + list[i].C_ROLL_PROCID + "' and  t.c_batch_no='" + list[i].C_BATCH_NO + "' and t.c_move_type='E'");
                    arraySql.Add(strSql2.ToString());
                }

            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 待判线材客户需求调配
        /// </summary>
        /// <param name="list">日志</param>
        /// <returns></returns>
        public bool InsertRoll_Proc4(List<Mod_TMC_ROLL_DEPLOY_LOG> list)
        {
            ArrayList arraySql = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into TMC_ROLL_DEPLOY_LOG(C_BATCH_NO,C_MAT_CODE,C_STL_GRD,C_SPEC,C_OLDAREA,C_NEWAREA,C_EMPID,C_EMPNAME,C_ROLL_PROCID,C_QUA,C_PACK,C_JUDGE_LEV,C_STD_CODE,C_REMARK,C_OLDCUST,C_NEWCUST,C_OLDCON,C_NEWCON)values(");
                strSql.Append("'" + list[i].C_BATCH_NO + "',");
                strSql.Append("'" + list[i].C_MAT_CODE + "',");
                strSql.Append("'" + list[i].C_STL_GRD + "',");
                strSql.Append("'" + list[i].C_SPEC + "',");
                strSql.Append("'" + list[i].C_OLDAREA + "',");
                strSql.Append("'" + list[i].C_NEWAREA + "',");
                strSql.Append("'" + list[i].C_EMPID + "',");
                strSql.Append("'" + list[i].C_EMPNAME + "',");
                strSql.Append("'" + list[i].C_ROLL_PROCID + "',");
                strSql.Append("'1',");
                strSql.Append("'" + list[i].C_PACK + "',");
                strSql.Append("'" + list[i].C_JUDGE_LEV + "',");
                strSql.Append("'" + list[i].C_STD_CODE + "',");
                strSql.Append("'单卷调配',");
                strSql.Append("'" + list[i].C_OLDCUST + "',");
                strSql.Append("'" + list[i].C_NEWCUST + "',");
                strSql.Append("'" + list[i].C_OLDCON + "',");
                strSql.Append("'" + list[i].C_NEWCON + "'");
                strSql.Append(")");
                arraySql.Add(strSql.ToString());
                StringBuilder strSql2 = new StringBuilder();

                string str = $@"SELECT MAX(TT.C_ORDER_NO) C_ORDER_NO
                                  FROM (SELECT T.C_ORDER_NO,
                                               T.N_LINE_MATCH_WGT,
                                               T.N_WGT,
                                               (NVL(T.N_WGT, 0) - NVL(T.N_LINE_MATCH_WGT, 0)) MAXWGT,
                                               T.C_MAT_CODE,
                                               T.C_STL_GRD
                                          FROM TMO_ORDER T
                                         WHERE T.C_CON_NO = '{list[i].C_NEWCON}'
                                           AND T.C_MAT_CODE = '{list[i].C_MAT_CODE}' AND T.C_PACK='{list[i].C_PACK}' and t.C_STD_CODE='{list[i].C_STD_CODE}' ) TT
                                 ORDER BY TT.MAXWGT DESC";

                DataTable dt = DbHelperOra.Query(str).Tables[0];

                #region //排产订单分配量减量
                string str2 = $@"SELECT T.C_ORDER_NO, T.N_WGT
                                      FROM TRC_ROLL_PRODCUT T
                                     WHERE T.C_ID = '{list[i].C_ROLL_PROCID}'";

                DataTable dt2 = DbHelperOra.Query(str2).Tables[0];

                string oldorder = dt2.Rows[0]["C_ORDER_NO"].ToString();

                string rollwgt = dt2.Rows[0]["N_WGT"].ToString();

                string updatejian = $@"update tmo_order t set t.n_line_match_wgt=nvl(t.n_line_match_wgt,0)-{rollwgt} where t.C_ORDER_NO='{oldorder}'";

                arraySql.Add(updatejian);

                #endregion

                if (dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0]["C_ORDER_NO"].ToString()))
                {

                    string neworder = dt.Rows[0]["C_ORDER_NO"].ToString();

                    string updateadd = $@"update tmo_order t set t.n_line_match_wgt=nvl(t.n_line_match_wgt,0)+{rollwgt} where t.C_ORDER_NO='{neworder}'";

                    arraySql.Add(updateadd);

                    strSql2.Append("update trc_roll_prodcut t set t.C_SALE_AREA='" + list[i].C_NEWAREA + "',t.C_CUST_NAME='" + list[i].C_NEWCUST + "',t.C_CKDH='" + list[i].C_OLDAREA + "',t.C_CKRY='" + list[i].C_OLDCUST + "',T.C_CON_NO='" + list[i].C_NEWCON + "',T.C_ORDER_NO='" + neworder + "' where t.C_ID='" + list[i].C_ROLL_PROCID + "' and  t.c_batch_no='" + list[i].C_BATCH_NO + "' and t.c_move_type='E'");

                    arraySql.Add(strSql2.ToString());
                }
                else
                {

                    strSql2.Append("update trc_roll_prodcut t set t.C_SALE_AREA='" + list[i].C_NEWAREA + "',t.C_CUST_NAME='" + list[i].C_NEWCUST + "',t.C_CKDH='" + list[i].C_OLDAREA + "',t.C_CKRY='" + list[i].C_OLDCUST + "',T.C_CON_NO='" + list[i].C_NEWCON + "',T.C_ORDER_NO=NULL where t.C_ID='" + list[i].C_ROLL_PROCID + "' and  t.c_batch_no='" + list[i].C_BATCH_NO + "' and t.c_move_type='E'");
                    arraySql.Add(strSql2.ToString());
                }

            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// D质量线材区域分配
        /// </summary>
        /// <returns></returns>
        public bool Update_D_Roll_Proc()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"update TRC_ROLL_PRODCUT t
                                   set t.c_sale_area = '副产品销售部'
                                 where t.c_id in(SELECT T.C_ID
                                  FROM TRC_ROLL_PRODCUT T
                                 WHERE T.C_MOVE_TYPE = 'E'
                                   AND T.C_JUDGE_LEV_ZH IN('D','B1','B2','C1','C2')
                                   AND T.C_SALE_AREA NOT IN ('副产品销售部','不锈钢公司') AND T.C_TYPE NOT IN('不锈钢'))");
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

        #endregion  BasicMethod

    }
}

