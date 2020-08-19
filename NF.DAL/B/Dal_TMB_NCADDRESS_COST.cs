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
    /// 到货费用
    /// </summary>
    public partial class Dal_TMB_NCADDRESS_COST
    {
        public Dal_TMB_NCADDRESS_COST()
        { }

        /// <summary>
        /// 获取到货地点档案
        /// </summary>
        /// <param name="areaID"></param>
        /// <returns></returns>
        public DataSet GetList(string areaID)
        {
            string strSql = $"SELECT C_ID,ADDRCODE,ADDRNAME,PK_ADDRESS,PK_AREACL FROM TMB_NCADDRESS WHERE C_ID='{areaID}'";
            return DbHelperOra.Query(strSql);
        }
        /// <summary>
        /// 获取到货地点运费信息
        /// </summary>
        /// <param name="cys">承运商</param>
        /// <param name="fy">发运方式</param>
        /// <param name="addr">到货地点</param>
        /// <returns></returns>
        public DataSet GetList( string fy, string addr)
        {
            string strSql = $"SELECT * FROM TMB_NCADDRESS_COST WHERE N_STATUS=0";
           
            if (!string.IsNullOrEmpty(fy))
            {
                strSql += $" AND C_FAYUN='{fy}'";
            }
            if (!string.IsNullOrEmpty(addr))
            {
                strSql += $" AND C_ADDRNAME LIKE '%{addr}%'";
            }
            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 获取到货地点运费信息
        /// </summary>
        /// <param name="cys">承运商</param>
        /// <param name="fy">发运方式</param>
        /// <param name="addr">到货地点</param>
        /// <returns></returns>
        public DataSet GetAddr(string fy, string addr)
        {
            string strSql = $@"SELECT * FROM TMB_NCADDRESS_COST T WHERE  N_STATUS=0 AND  TO_CHAR(sysdate,'yyyy-mm-dd') >= TO_CHAR(t.d_start_dt, 'yyyy-mm-dd') and TO_CHAR(sysdate,'yyyy-mm-dd') <=to_char(t.d_end_dt, 'yyyy-mm-dd')";
          
            if (!string.IsNullOrEmpty(fy))
            {
                strSql += $" AND T.C_FAYUN='{fy}'";
            }
            if (!string.IsNullOrEmpty(addr))
            {
                strSql += $" AND T.C_ADDRNAME LIKE '%{addr}%'";
            }
            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists( string fyfs, string addr)
        {
            string strSql = $"SELECT COUNT(0) FROM TMB_NCADDRESS_COST WHERE N_STATUS=0 AND C_ADDRNAME='{addr}'  AND C_FAYUN='{fyfs}'";

            return DbHelperOra.Exists(strSql);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Add(List<Mod_TMB_NCADDRESS_COST> list)
        {
            ArrayList arraySql = new ArrayList();

            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    string strSql = $@"INSERT INTO TMB_NCADDRESS_COST(C_FAYUN,C_ADDRCODE,C_ADDRNAME,N_PRICE,D_START_DT,D_END_DT,C_CREATE_EMP,C_ADDR_NCPK,C_AREA_PK,C_EMP,D_EMP)VALUES('{item.C_FAYUN}','{item.C_ADDRCODE}','{item.C_ADDRNAME}',{item.N_PRICE},TO_DATE('{item.D_START_DT}','yyyy-mm-dd hh24:mi:ss'),TO_DATE('{item.D_END_DT}','yyyy-mm-dd hh24:mi:ss'),'{item.C_CREATE_EMP}','{item.C_ADDR_NCPK}','{item.C_AREA_PK}','{item.C_EMP}',TO_DATE('{item.D_EMP}','yyyy-mm-dd hh24:mi:ss'))";
                    arraySql.Add(strSql);
                }
                return DbHelperOra.ExecuteSqlTran(arraySql);
            }
            else
            {
                return false;
            }


        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mod">修改参数：费用，生效日期，失效日期，修改人</param>
        /// <returns></returns>
        public bool Update(Mod_TMB_NCADDRESS_COST mod)
        {
            string strSql = $@"UPDATE TMB_NCADDRESS_COST SET N_PRICE={mod.N_PRICE},D_START_DT=TO_DATE('{mod.D_START_DT}','yyyy-mm-dd hh24:mi:ss'),D_END_DT=TO_DATE('{mod.D_END_DT}','yyyy-mm-dd hh24:mi:ss'),D_EMP=TO_DATE('{DateTime.Now.ToString()}','yyyy-mm-dd hh24:mi:ss'),C_EMP='{mod.C_CREATE_EMP}' WHERE C_ID='{mod.C_ID}'";

            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="mod">修改参数：费用，生效日期，失效日期，修改人</param>
        /// <returns></returns>
        public bool UpdateList(List<Mod_TMB_NCADDRESS_COST> list)
        {
            ArrayList arraySql = new ArrayList();
            foreach (var item in list)
            {
                string strSql = $@"UPDATE TMB_NCADDRESS_COST SET N_PRICE={item.N_PRICE},D_START_DT=TO_DATE('{item.D_START_DT}','yyyy-mm-dd hh24:mi:ss'),D_END_DT=TO_DATE('{item.D_END_DT}','yyyy-mm-dd hh24:mi:ss'),D_EMP=TO_DATE('{DateTime.Now.ToString()}','yyyy-mm-dd hh24:mi:ss'),C_EMP='{item.C_CREATE_EMP}' WHERE C_ID='{item.C_ID}'";
                arraySql.Add(strSql);

            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        public bool Del(List<Mod_TMB_NCADDRESS_COST> list)
        {
            ArrayList arraySql = new ArrayList();
            foreach (var item in list)
            {
                string strSql = $"UPDATE TMB_NCADDRESS_COST SET N_STATUS=1,D_EMP=TO_DATE('{DateTime.Now.ToString()}','yyyy-mm-dd hh24:mi:ss'),C_EMP='{item.C_EMP}' WHERE C_ID='{item.C_ID}'";
                arraySql.Add(strSql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
    }
}

