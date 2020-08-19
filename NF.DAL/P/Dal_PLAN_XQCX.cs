using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NF.MODEL;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using NF.DAL;

namespace NF.DLL.P
{
    public class Dal_PLAN_XQCX
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(
                @"

SELECT
 d.c_batch_no,
 T.C_ORDER_NO ,
       T.N_WGT ,
       T.C_STL_GRD ,
       T.C_MAT_NAME ,
      T.C_MAT_CODE,
       T.C_SPEC ,
       T.C_FREE_TERM ,
       T.C_FREE_TERM2 ,
       T.C_LINE_DESC ,
       T.D_DT ,
       T.D_NEED_DT ,
       T.N_PROD_WGT ,
       T.C_PACK ,
       T.C_AREA ,
       T.C_REMARK,
       T.c_remark4,---订单特殊信息
       d.D_PRODUCE_DATE_B,
       d.D_PRODUCE_DATE_E,
       (SELECT A.C_PRO_USE
          FROM TRP_PLAN_ROLL A
         WHERE A.C_ID = T.C_PLAN_ROLL_ID) C_PRO_USE ,
       (SELECT  A.C_TRANSMODE
          FROM TRP_PLAN_ROLL A
         WHERE A.C_ID = T.C_PLAN_ROLL_ID) C_TRANSMODE
  from trc_roll_wgd d  
left join  TRP_PLAN_ROLL_ITEM T 
on d.c_plan_id =t.c_id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            strSql.Append("  order by d.c_batch_no desc ");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取产线
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetChanXian()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(
                @"  select distinct(C_LINE_DESC) from TRP_PLAN_ROLL_ITEM ");
            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 线材订单执行情况查询
        /// </summary>
        /// <param name="C_ORDER_NO"></param>
        /// <param name="C_STL_GRD"></param>
        /// <param name="C_SPEC"></param>
        /// <param name="C_STD_CODE"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataSet ListPlanData(string C_ORDER_NO, string C_STL_GRD, string C_SPEC, string C_STD_CODE, string start, string end,string area,string matcode,string cust)
        {
            string sql = @"select * from V_ORDER_PRODUCE_INFO t where 1=1 ";

            if (!string.IsNullOrEmpty(matcode))
            {
                sql = sql + " AND T.物料编码='" + matcode + "'";
            }
            if (!string.IsNullOrEmpty(cust))
            {
                sql = sql + " AND T.客户名称  like '%" + cust + "%'";
            }
            if (!string .IsNullOrEmpty(area))
            {
                sql = sql + " AND T.销售区域='"+area+"'";
            }
            if (C_ORDER_NO.Trim() != "")
            {
                sql = sql + " AND t.计划订单号 like '%" + C_ORDER_NO + "%'  ";
            }

            if (C_STL_GRD.Trim() != "")
            {
                sql = sql + "  and t.钢种 like '%" + C_STL_GRD + "%' ";
            }
            if (C_SPEC.Trim() != "")
            {
                sql = sql + "and t.规格 like '%" + C_SPEC + "%' ";
            }
            if (C_STD_CODE.Trim() != "")
            {
                sql = sql + " and t.执行标准 like '%" + C_STD_CODE + "%'  ";
            }
            if (start.Trim() != "")
            {
                sql = sql + "  AND T.计划日期 >= TO_DATE('" + start + "', 'yyyy-mm-dd hh24:mi:ss') ";
            }
            if (end.Trim() != "")
            {
                sql = sql + "  AND T.计划日期 <= TO_DATE('" + end + "', 'yyyy-mm-dd hh24:mi:ss') ";
            }
            return DbHelperOra.Query(sql.ToString());
        }
        /// <summary>
        /// 线材订单执行情况
        /// </summary>
        /// <param name="C_ORDER_NO">订单号</param>
        /// <returns></returns>
        public DataSet ListPlanData(string C_ORDER_NO)
        {
            string sql = $@"select * from V_ORDER_PRODUCE_INFO2 t where NVL(SUBSTR(t.计划订单号,0,INSTR(t.计划订单号,'/')-1),t.计划订单号) in({C_ORDER_NO})";

            return DbHelperOra.Query(sql.ToString());
        }
        /// <summary>
        /// 线材订单执行情况
        /// </summary>
        /// <param name="C_ORDER_NO">订单号</param>
        /// <returns></returns>
        public DataSet ListPlanData2(string C_ORDER_NO)
        {
            string sql = $@"select * from V_ORDER_PRODUCE_INFO2 t where t.计划订单号='{C_ORDER_NO}'";

            return DbHelperOra.Query(sql.ToString());
        }
    }
}
