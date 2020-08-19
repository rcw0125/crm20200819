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
    /// 
    /// </summary>
    public partial class Dal_TMC_TRAIN_MAIN
    {
        public Dal_TMC_TRAIN_MAIN()
        { }

        /// <summary>
        /// 删除火运日计划计划
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool Del(string C_ID)
        {

            ArrayList arraySql = new ArrayList();
            string strSql = $"DELETE FROM TMC_TRAIN_MAIN WHERE C_ID='{C_ID}'";
            string strSql2 = $"DELETE FROM TMC_TRAIN_ITEM WHERE C_PKID='{C_ID}'";
            arraySql.Add(strSql);
            arraySql.Add(strSql2);
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        /// <summary>
        /// 批量删除火运计划具体钢种信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Del_ITEM(List<Mod_TMC_TRAIN_ITEM> list)
        {
            ArrayList arraySql = new ArrayList();
            foreach (var item in list)
            {
                string strSql = $"DELETE FROM TMC_TRAIN_ITEM WHERE C_ID='{item.C_ID}'";
                arraySql.Add(strSql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 添加火运日计划单据号
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool Insert(Mod_TMC_TRAIN_MAIN mod)
        {
            string strSql = $@"INSERT INTO TMC_TRAIN_MAIN(C_ID,C_EMPID,C_EMPNAME,C_SHIPVIA)VALUES('{mod.C_ID}','{mod.C_EMPID}','{mod.C_EMPNAME}','火运代垫（销售）')";
            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }

        /// <summary>
        /// 火运发运日计划
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool AddTrainDay(List<Mod_TMC_TRAIN_ITEM> list)
        {
            ArrayList arraySql = new ArrayList();
            foreach (var mod in list)
            {
                #region //参数
                string strSql = $@"INSERT INTO TMC_TRAIN_ITEM
                              (C_EMPNAME,
                               C_PKID,
                               C_AREA,
                               C_CONNO,
                               C_DH_COMPANY,
                               C_SH_COMPANY,
                               C_CUSTNO,
                               C_CUSTNAME,
                               C_KH_BANK,
                               C_TAXNO,
                               C_ADDRESS,
                               C_TEL,
                               C_ACCOUNT,
                               C_FLAG,
                               C_BILLCODE,,
                               C_SPEC,
                               C_STL_GRD,
                               N_WGT,
                               C_REMARK
                               )
                            VALUES(";
                strSql += $"'{mod.C_EMPNAME}',";
                strSql += $"'{mod.C_PKID}',";
                strSql += $"'{mod.C_AREA}',";
                strSql += $"'{mod.C_CONNO}',";
                strSql += $"'{mod.C_DH_COMPANY}',";
                strSql += $"'{mod.C_SH_COMPANY}',";
                strSql += $"'{mod.C_CUSTNO}',";
                strSql += $"'{mod.C_CUSTNAME}',";
                strSql += $"'{mod.C_KH_BANK}',";
                strSql += $"'{mod.C_TAXNO}',";
                strSql += $"'{mod.C_ADDRESS}',";
                strSql += $"'{mod.C_TEL}',";
                strSql += $"'{mod.C_ACCOUNT}',";
                strSql += $"'{mod.C_FLAG}',";
                strSql += $"'{mod.C_BILLCODE}',";
                strSql += $"'{mod.C_SPEC}',";
                strSql += $"'{mod.C_STL_GRD}',";
                strSql += $"{mod.N_WGT},";
                strSql += $"'{mod.C_REMARK}'";
                strSql += ")";

                #endregion
                arraySql.Add(strSql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 更新火运日计划
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool UpdateTrainDay(Mod_TMC_TRAIN_MAIN mod, List<Mod_TMC_TRAIN_ITEM> list)
        {

            ArrayList arraySql = new ArrayList();
            string strSql = $@"UPDATE TMC_TRAIN_MAIN SET C_STATION='{mod.C_STATION}',C_PLANNO='{mod.C_PLANNO}',C_LINE='{mod.C_LINE}',D_EDIT_DT=TO_DATE('{mod.D_EDIT_DT}', 'yyyy-mm-dd hh24:mi:ss'),D_DT=TO_DATE('{mod.D_DT}', 'yyyy-mm-dd hh24:mi:ss'), N_TRAIN_NUM={mod.N_TRAIN_NUM},C_REMARK='{mod.C_REMARK}' WHERE C_ID='{mod.C_ID}'";
            arraySql.Add(strSql);

            foreach (var item in list)
            {
                string cmdtxt = $"UPDATE TMC_TRAIN_ITEM SET N_WGT={item.N_WGT},C_REMARK='{item.C_REMARK}' WHERE C_ID='{item.C_ID}'";
                arraySql.Add(cmdtxt);
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMC_TRAIN_MAIN GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM TMC_TRAIN_MAIN  ");
            strSql.Append(" WHERE C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TMC_TECH_CONSULT model = new Mod_TMC_TECH_CONSULT();
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
        public Mod_TMC_TRAIN_MAIN DataRowToModel(DataRow row)
        {
            Mod_TMC_TRAIN_MAIN model = new Mod_TMC_TRAIN_MAIN();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_EMPID"] != null)
                {
                    model.C_EMPID = row["C_EMPID"].ToString();
                }
                if (row["C_EMPNAME"] != null)
                {
                    model.C_EMPNAME = row["C_EMPNAME"].ToString();
                }
                if (row["C_STATION"] != null)
                {
                    model.C_STATION = row["C_STATION"].ToString();
                }
                if (row["C_PLANNO"] != null)
                {
                    model.C_PLANNO = row["C_PLANNO"].ToString();
                }
                if (row["C_LINE"] != null)
                {
                    model.C_LINE = row["C_LINE"].ToString();
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }

                if (row["D_DT"] != null && row["D_DT"].ToString() != "")
                {
                    model.D_DT = DateTime.Parse(row["D_DT"].ToString());
                }
                if (row["D_EDIT_DT"] != null && row["D_EDIT_DT"].ToString() != "")
                {
                    model.D_EDIT_DT = DateTime.Parse(row["D_EDIT_DT"].ToString());
                }

                if (row["N_TRAIN_NUM"] != null && row["N_TRAIN_NUM"].ToString() != "")
                {
                    model.N_TRAIN_NUM = decimal.Parse(row["N_TRAIN_NUM"].ToString());
                }

            }
            return model;
        }

        /// <summary>
        /// 获取火运日计划数据列表
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="station"></param>
        /// <param name="planno"></param>
        /// <param name="startDT"></param>
        /// <param name="endDT"></param>
        /// <returns></returns>
        public DataSet GetList(string empID, string station, string planno, string startDT, string endDT)
        {
            string strSql = "SELECT * FROM TMC_TRAIN_MAIN T WHERE 1=1";

            if (!string.IsNullOrEmpty(empID))
            {
                strSql += $" AND T.C_EMPID='{empID}'";
            }
            if (!string.IsNullOrEmpty(station))
            {
                strSql += $" AND T.C_STATION='{station}'";
            }
            if (!string.IsNullOrEmpty(planno))
            {
                strSql += $" AND T.C_PLANNO='{planno}'";
            }
            if (!string.IsNullOrEmpty(startDT) && !string.IsNullOrEmpty(endDT))
            {
                strSql += $@" AND T.D_DT BETWEEN TO_DATE('{startDT}', 'yyyy-mm-dd hh24:mi:ss') AND to_date('{endDT} 23:59:59', 'yyyy-mm-dd hh24:mi:ss')";
            }
            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 获取火运计划子表数据
        /// </summary>
        /// <param name="pkID"></param>
        /// <returns></returns>
        public DataSet GetList(string pkID)
        {
            string strSql = $"SELECT * FROM TMC_TRAIN_ITEM T WHERE T.C_PKID='{pkID}'";
            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 批量火运/汽运审核
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateTrainMain(List<string> list, string emp)
        {
            ArrayList arraySql = new ArrayList();

            for (int i = 0; i < list.Count; i++)
            {
                string strSql = $"UPDATE TMC_TRAIN_MAIN SET C_ISCHECK='Y',C_CHECKEMP='{emp}',D_CHECKTIME=TO_DATE('{DateTime.Now}', 'yyyy-mm-dd hh24:mi:ss') WHERE C_ID='{list[i]}'";
                arraySql.Add(strSql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 火运/汽运审核
        /// </summary>
        /// <param name="fyd">发运单</param>
        /// <param name="emp">制单人</param>
        /// <param name="conno">合同号</param>
        /// <param name="cust">客户</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="ischeck">是否审核</param>
        /// <param name="flag">是否监控</param>
        /// <param name="startDT">提报开始时间</param>
        /// <param name="endDT">提报截至时间</param>
        /// <returns></returns>
        public DataSet GetTrainMain(string fyd, string emp, string conno, string cust, string stlgrd, string spec, string ischeck, string flag, string startDT, string endDT, string fyfs, string station, string area,string xfwgt)
        {
            string strSql = $@"SELECT T.C_ID,
                               T.C_STATION,
                               T.C_SHIPVIA,
                               T.D_DT,
                               T.D_CHECKTIME,
                               T.C_CHECKEMP,
                               T.C_EMPNAME,
                               T.C_ISCHECK,
                               A.C_AREA,
                               A.C_CONNO,
                               A.C_DH_COMPANY,
                               A.C_STL_GRD,
                               A.C_SPEC,
                               A.N_WGT,
                               NVL(B.C_FLAG, 'N') C_FLAG,
                               A.C_ID AS  C_ID2
                          FROM TMC_TRAIN_MAIN T
                         INNER JOIN TMC_TRAIN_ITEM A
                            ON A.C_PKID = T.C_ID
                          LEFT JOIN TMB_MONI_STLGRD B
                            ON B.C_STL_GRD = A.C_STL_GRD WHERE T.C_ISCHECK='{ischeck}'";

            if (!string.IsNullOrEmpty(fyd))
            {
                strSql += $" AND T.C_ID = '{fyd}'";
            }
            if (!string.IsNullOrEmpty(emp))
            {
                strSql += $" AND T.C_EMPNAME = '{emp}'";
            }
            if (!string.IsNullOrEmpty(conno))
            {
                strSql += $" AND A.C_CONNO = '{conno}'";
            }
            if (!string.IsNullOrEmpty(cust))
            {
                strSql += $" AND A.C_DH_COMPANY='{cust}'";
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql += $" AND A.C_STL_GRD='{stlgrd}'";
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql += $" AND A.C_SPEC LIKE '%{spec}%'";
            }
            if (!string.IsNullOrEmpty(flag))
            {
                strSql += $" AND B.C_FLAG='{flag}'";
            }
            if (!string.IsNullOrEmpty(startDT) && !string.IsNullOrEmpty(endDT))
            {
                strSql += $@" AND T.D_DT BETWEEN TO_DATE('{startDT}', 'yyyy-mm-dd hh24:mi:ss') AND to_date('{endDT} 23:59:59', 'yyyy-mm-dd hh24:mi:ss')";
            }
            if (!string.IsNullOrEmpty(fyfs))
            {
                strSql += $" AND T.C_SHIPVIA='{fyfs}'";
            }
            if (!string.IsNullOrEmpty(station))
            {
                strSql += $" AND T.C_STATION LIKE '%{station}%'";
            }
            if (!string.IsNullOrEmpty(area))
            {
                strSql += $" AND A.C_AREA = '{area}'";
            }



            if (!string.IsNullOrEmpty(xfwgt))
            {

                DataView dv = DbHelperOra.Query(strSql).Tables[0].DefaultView;
                dv.Sort = "N_WGT ASC";
                DataTable dt = dv.ToTable();
                string listID = "";
                var list = new List<string>();

                decimal wgt = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    wgt = wgt + Convert.ToDecimal(dt.Rows[i]["N_WGT"]);
                    list.Add(dt.Rows[i]["C_ID2"].ToString());

                    if (wgt >= Convert.ToDecimal(xfwgt))
                    {
                        break;
                    }
                }
                listID = "'" + string.Join("','", list.ToArray()) + "'";

                if (!string.IsNullOrEmpty(listID))
                {
                    strSql += $" AND A.C_ID IN({listID})";
                }

                

                return DbHelperOra.Query(strSql);

            }
            else
            {
                return DbHelperOra.Query(strSql);
            }
        }
    }
}

