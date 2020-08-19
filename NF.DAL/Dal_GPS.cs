using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;

using System.Data;


namespace NF.DAL
{
    public partial class Dal_GPS
    {



        /// <summary>
        /// 更新是否GPS
        /// </summary>
        public bool UpdateN_ISGPS(int isGPS, String idList, string table)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + table + " set ");
            strSql.Append("N_ISGPS=" + isGPS + "");
            strSql.Append(" where C_ID in(" + idList + ") ");

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
        /// 更新是否GPS
        /// </summary>
        public bool UpdateStlGrd(int isGPS, String idList, string table)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + table + " set ");
            strSql.Append("N_ISGPS=" + isGPS + "");
            strSql.Append(" where C_STL_GRD IN(" + idList + ") ");

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
        /// 发运单校验GPS
        /// </summary>
        /// <param name="custno">客户编码</param>
        /// <param name="fypk">发运主键</param>
        /// <param name="area">区域</param>
        /// <param name="matcode">物料钢种</param>
        /// <returns></returns>
        public bool GpsFyd(string custno, string fypk, string area, string matcode)
        {
            bool result = false;

            if (GetArea(area))//区域
            {
                if (GetCust(custno))//客户
                {
                    if (GetStlGrd(matcode))//钢种
                    {
                        if (Getfyfs(fypk))//发运方式
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        if (Getfyfs(fypk))
                        {
                            result = true;
                        }
                    }
                }
                else
                {
                    if (GetStlGrd(matcode))
                    {
                        if (Getfyfs(fypk))
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        if (Getfyfs(fypk))
                        {
                            result = true;
                        }
                    }
                }
            }

            return result;
        }

        #region //客户GPS
        /// <summary>
        /// 客户
        /// </summary>
        /// <param name="custno">客户编码</param>
        /// <returns></returns>
        public bool GetCust(string custno)
        {
            Dal_TS_CUSTFILE dalcust = new Dal_TS_CUSTFILE();
            string cmd = "select  N_ISGPS from  TS_CUSTFILE where C_NO='" + custno + "'";
            string isgps = DbHelperOra.GetSingle(cmd)?.ToString() ?? "0";

            return isgps == "0" ? false : true;
        }
        /// <summary>
        /// 发运方式
        /// </summary>
        /// <param name="fyfs">主键</param>
        /// <returns></returns>
        public bool Getfyfs(string fyfs)
        {
            Dal_TS_CUSTFILE dalcust = new Dal_TS_CUSTFILE();
            string cmd = "select N_ISGPS from  TS_DIC where C_DETAILCODE='" + fyfs + "'";
            string isgps = DbHelperOra.GetSingle(cmd)?.ToString() ?? "0";

            return isgps == "0" ? false : true;
        }
        /// <summary>
        /// 销售区域
        /// </summary>
        /// <param name="area">区域名称</param>
        /// <returns></returns>
        public bool GetArea(string area)
        {
            Dal_TS_CUSTFILE dalcust = new Dal_TS_CUSTFILE();
            string cmd = "select N_ISGPS from  TS_DIC where C_DETAILNAME='" + area + "'";
            string isgps = DbHelperOra.GetSingle(cmd)?.ToString() ?? "0";

            return isgps == "0" ? false : true;
        }
        /// <summary>
        /// 钢种
        /// </summary>
        /// <param name="matcode">物料编码</param>
        /// <returns></returns>
        public bool GetStlGrd(string matcode)
        {
            Dal_TS_CUSTFILE dalcust = new Dal_TS_CUSTFILE();
            string cmd = "select N_ISGPS from  tb_matrl_main where C_MAT_CODE='" + matcode + "'";
            string isgps = DbHelperOra.GetSingle(cmd)?.ToString() ?? "0";

            return isgps == "0" ? false : true;
        }
        #endregion
    }
}
