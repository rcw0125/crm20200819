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
    public partial class Dal_TQC_ZZS_FILE
    {
        public Dal_TQC_ZZS_FILE()
        { }

        public bool InsertItem(Mod_TQC_ZZS_FILE mod)
        {
            string strSql = $"INSERT INTO TQC_ZZS_FILE (C_BATCH_NO,C_STOVE,C_SPEC,C_STL_GRD,C_STD_CODE,C_PDF_PATCH,C_EMP_ID)VALUES(";
            strSql += $"'{mod.C_BATCH_NO}',";
            strSql += $"'{mod.C_STOVE}',";
            strSql += $"'{mod.C_SPEC}',";
            strSql += $"'{mod.C_STL_GRD}',";
            strSql += $"'{mod.C_STD_CODE}',";
            strSql += $"'{mod.C_PDF_PATCH}',";
            strSql += $"'{mod.C_EMP_ID}'";
            strSql += ")";
            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }

        public bool UpdateItem(Mod_TQC_ZZS_FILE mod)
        {
            string strSql = $@"UPDATE TQC_ZZS_FILE  SET C_PDF_PATCH='{mod.C_PDF_PATCH}'  WHERE C_BATCH_NO='{mod.C_BATCH_NO}' AND C_STOVE='{mod.C_STOVE}' AND C_STL_GRD='{mod.C_STL_GRD}' AND C_STD_CODE='{mod.C_STD_CODE}'";

            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }


        public bool ExistsZZS(string batch, string stlgrd, string stove, string std)
        {
            string strSql = $@"SELECT COUNT(1) FROM TQC_ZZS_FILE T WHERE T.C_BATCH_NO='{batch}' AND T.C_STL_GRD='{stlgrd}' AND T.C_STOVE='{stove}' AND T.C_STD_CODE='{std}'";
            return DbHelperOra.Exists(strSql);
        }

        public DataSet GetList(string batch, string stlgrd, string stove, string std)
        {
            string strSql = $@"SELECT MAX(T.C_PDF_PATCH)PDF FROM TQC_ZZS_FILE T WHERE T.C_BATCH_NO='{batch}' AND T.C_STOVE='{stove}' AND T.C_STL_GRD='{stlgrd}' AND T.C_STD_CODE='{std}' ";
            return DbHelperOra.Query(strSql);
        }
        public DataSet GetList(string batch, string stlgrd, string stove, string kssj, string jssj)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT T.C_MAT_DESC,
                                   T.C_BATCH_NO,
                                   T.C_STOVE,
                                   T.C_STD_CODE,
                                   T.C_STL_GRD,
                                   T.C_SPEC,
                                   T.D_PRODUCE_DATE,
                                   (SELECT MAX(A.C_PDF_PATCH)
                                      FROM TQC_ZZS_FILE A
                                     WHERE A.C_BATCH_NO = T.C_BATCH_NO
                                       AND A.C_STOVE = T.C_STOVE
                                       AND A.C_STL_GRD = T.C_STL_GRD
                                       AND A.C_STD_CODE = T.C_STD_CODE) C_PDF_PATCH,
                                   (SELECT MAX(A.C_EMP_ID)
                                      FROM TQC_ZZS_FILE A
                                     WHERE A.C_BATCH_NO = T.C_BATCH_NO
                                       AND A.C_STOVE = T.C_STOVE
                                       AND A.C_STL_GRD = T.C_STL_GRD
                                       AND A.C_STD_CODE = T.C_STD_CODE) C_EMP_ID,
                                   (SELECT MAX(A.D_QZRQ)
                                      FROM TQC_ZZS_FILE A
                                     WHERE A.C_BATCH_NO = T.C_BATCH_NO
                                       AND A.C_STOVE = T.C_STOVE
                                       AND A.C_STL_GRD = T.C_STL_GRD
                                       AND A.C_STD_CODE = T.C_STD_CODE) D_QZRQ
                              FROM TRC_ROLL_PRODCUT T
                             WHERE T.D_PRODUCE_DATE >= TO_DATE('{0}', 'YYYY-MM-DD HH24:MI:SS')
                               AND T.D_PRODUCE_DATE <= TO_DATE('{1} 23:59:59', 'YYYY-MM-DD HH24:MI:SS')", kssj, jssj);

            if (!string.IsNullOrEmpty(batch))
            {
                strSql.AppendFormat(" AND T.C_BATCH_NO='{0}'", batch);
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql.AppendFormat(" AND T.C_STL_GRD='{0}'", stlgrd);
            }
            if (!string.IsNullOrEmpty(stove))
            {
                strSql.AppendFormat(" AND T.C_STOVE='{0}'", stove);
            }
            strSql.Append(@" GROUP BY T.C_MAT_DESC,
                                      T.C_BATCH_NO,
                                      T.C_STOVE,
                                      T.C_STD_CODE,
                                      T.C_STL_GRD,
                                      T.C_SPEC,
                                      T.D_PRODUCE_DATE");

            return DbHelperOra.Query(strSql.ToString());
        }

    }
}

