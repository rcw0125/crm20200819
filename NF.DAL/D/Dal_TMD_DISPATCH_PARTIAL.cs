

using NF.MODEL.D;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Text;

namespace NF.DAL
{
    public partial class Dal_TMD_DISPATCH
    {
        /// <summary>
        /// 更新打印状态
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdatePrintStatus(string strWhere, int printStatus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($@"update tmd_dispatch set N_PRINT_STATUS={printStatus},N_PRINT_DT=to_date('{ DateTime.Now}','yyyy-MM-dd HH24:mi:ss')  where C_ID in(
 select  a.c_id from  tmd_dispatch_sjzjb t
 left join tmd_dispatch a
 on t.c_dispatch_id=a.c_id 
 where  {strWhere})");

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
        /// 更新打印状态
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateWWPrintStatus(string strWhere, int printStatus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($@"update tmd_dispatch set N_PRINT_STATUS={printStatus},N_PRINT_DT=to_date('{ DateTime.Now}','yyyy-MM-dd HH24:mi:ss')  where 1=1 and   {strWhere}");

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
        /// 添加打印批号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddRePrint(Mod_TMD_ZZS_REPRINT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"insert into tmd_zzs_reprint (
                             c_certificate_no, 
                             c_attestor, 
                             d_visa_dt, 
                             c_print_type, 
                             c_print_templates, 
                             n_status, 
                             c_remark, 
                             c_emp_id, 
                             d_mod_dt, 
                             c_spec, 
                             c_stl_grd, 
                             c_std_code, 
                             c_dispatch_id, 
                             c_lic_pla_no,
                         C_TYPE)
                       values(
                        :c_certificate_no, 
                            :c_attestor, 
                            :d_visa_dt, 
                            :c_print_type, 
                            :c_print_templates, 
                            :n_status, 
                            :c_remark, 
                            :c_emp_id, 
                            :d_mod_dt, 
                            :c_spec, 
                            :c_stl_grd, 
                            :c_std_code, 
                            :c_dispatch_id, 
                            :c_lic_pla_no,
                            :C_TYPE )");
            OracleParameter[] parameters = {
                    new OracleParameter(":c_certificate_no", OracleDbType.Varchar2,100),
                    new OracleParameter(":c_attestor", OracleDbType.Varchar2,100),
                     new OracleParameter(":d_visa_dt", OracleDbType.Date),
                    new OracleParameter(":c_print_type", OracleDbType.Varchar2,100),
                    new OracleParameter(":c_print_templates", OracleDbType.Varchar2,100),
                    new OracleParameter(":n_status", OracleDbType.Decimal,1),
                    new OracleParameter(":c_remark", OracleDbType.Varchar2,500),
                    new OracleParameter(":c_emp_id", OracleDbType.Varchar2,100),
                    new OracleParameter(":d_mod_dt", OracleDbType.Date),
                    new OracleParameter(":c_spec", OracleDbType.Varchar2,100),
                    new OracleParameter(":c_stl_grd", OracleDbType.Varchar2,100),
                    new OracleParameter(":c_std_code", OracleDbType.Varchar2,100),
                    new OracleParameter(":c_dispatch_id", OracleDbType.Varchar2,100),
                    new OracleParameter(":c_lic_pla_no", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TYPE", OracleDbType.Decimal,1)
            };
            parameters[0].Value = model.C_certificate_no;
            parameters[1].Value = model.C_attestor;
            parameters[2].Value = model.D_visa_dt;
            parameters[3].Value = model.C_print_type;
            parameters[4].Value = model.C_print_templates;
            parameters[5].Value = model.N_status;
            parameters[6].Value = model.C_remark;
            parameters[7].Value = model.C_emp_id;
            parameters[8].Value = model.D_mod_dt;
            parameters[9].Value = model.C_spec;
            parameters[10].Value = model.C_stl_grd;
            parameters[11].Value = model.C_std_code;
            parameters[12].Value = model.C_dispatch_id;
            parameters[13].Value = model.C_lic_pla_no;
            parameters[14].Value = model.N_type;
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetRePrintList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select t.C_ID,t.c_certificate_no,t.c_attestor,t.d_visa_dt,t.C_REMARK,t.C_TYPE,t.C_SPEC,t.C_STL_GRD,t.C_STD_CODE,t.C_DISPATCH_ID,t.C_LIC_PLA_NO,t.N_UPDATE_TIME,t.N_UPDATE from tmd_zzs_reprint t     
           where t.n_status=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("  " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetRePrintList(string strWhere,string status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select t.C_ID,t.c_certificate_no,t.c_attestor,t.d_visa_dt,t.C_REMARK,t.C_TYPE,t.C_SPEC,t.C_STL_GRD,t.C_STD_CODE,t.C_DISPATCH_ID,t.C_LIC_PLA_NO,t.C_DEL_REMARK,t.N_UPDATE_TIME,t.C_EMP_ID,t.D_MOD_DT from tmd_zzs_reprint t     
           where t.N_UPDATE=" + status);
            if (strWhere.Trim() != "")
            {
                strSql.Append("  " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 更新打印状态
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateReprint(string C_IDlist,string remark, string udpateUser)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMD_ZZS_REPRINT set N_UPDATE=1,C_DEL_REMARK='" + remark+ "',N_UPDATE_TIME=N_UPDATE_TIME+1,C_REMARK='',C_EMP_ID='" + udpateUser + "',D_MOD_DT=to_date('" + DateTime.Now + "','yyyy-MM-dd hh24:mi:ss')  ");
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
        /// 更新打印状态
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateWWReprint(string C_IDlist, string remark, string udpateUser)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMD_ZZS_REPRINT set C_ATTESTOR='',D_VISA_DT=null, N_UPDATE=1,C_DEL_REMARK='" + remark + "',N_UPDATE_TIME=N_UPDATE_TIME+1,C_REMARK='',C_EMP_ID='" + udpateUser + "',D_MOD_DT=to_date('" + DateTime.Now + "','yyyy-MM-dd hh24:mi:ss')  ");
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
        /// 更新委外签证日期 签证人
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateWWVTAndAttor(string cer, string attoattestor, DateTime dt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMD_ZZS_REPRINT set C_ATTESTOR='"+attoattestor+ "',D_VISA_DT=to_date('" +dt + "','yyyy-MM-dd hh24:mi:ss') ");
            strSql.Append(" where C_CERTIFICATE_NO='"+cer+"'  ");
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
        /// 更新打印状态
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateReprintRemark(string strWhere, string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMD_ZZS_REPRINT t  set  t.C_REMARK='" + remark + "'");
            strSql.Append(" where 1=1 "+strWhere);
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
        #region 出库单签证人签证日期操作
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetCKDRePrintList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select  t.c_dispatch_id, 
                            t.c_attestor, 
                            t.d_visa_dt, 
                            t.n_status, 
                            t.c_type   from tmd_ckd_reprint t
           where t.n_status=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("  " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetCKDRePrintList(string strWhere,string status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select  t.c_id,t.c_dispatch_id, 
                            t.c_attestor, 
                            t.d_visa_dt, 
                            t.n_status, 
                            t.c_type   from tmd_ckd_reprint t
           where t.n_status="+ status);
            if (strWhere.Trim() != "")
            {
                strSql.Append("  " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        public DataSet ListPrintFyd(string fyd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select c_dispatch_id,D_VISA_DT,C_ATTESTOR from TMD_CKD_REPRINT
            where n_status=1 and c_dispatch_id='" + fyd+"'");
            return  DbHelperOra.Query(strSql.ToString());           
        }
        /// <summary>
        /// 添加打印批号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddCKDPrint(Mod_TMD_CKD_REPRINT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"insert into tmd_ckd_reprint (
                             c_dispatch_id, 
                            c_attestor, 
                            d_visa_dt, 
                            n_status, 
                            c_type)
                       values(
                             :c_dispatch_id, 
                            :c_attestor, 
                            :d_visa_dt, 
                            :n_status,                            
                            :C_TYPE )");
            OracleParameter[] parameters = {
                     new OracleParameter(":c_dispatch_id", OracleDbType.Varchar2,100),
                    new OracleParameter(":c_attestor", OracleDbType.Varchar2,100),
                     new OracleParameter(":d_visa_dt", OracleDbType.Date),
                    new OracleParameter(":n_status", OracleDbType.Decimal,1),
                    new OracleParameter(":C_TYPE", OracleDbType.Decimal,1)
            };
            parameters[0].Value = model.C_dispatch_id;
            parameters[1].Value = model.C_attestor;
            parameters[2].Value = model.D_visa_dt;
            parameters[3].Value = model.N_status;
            parameters[4].Value = model.N_type;
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
        /// 删除签证人签证日期
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool DeleteCkdRecord(string C_IDlist, string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tmd_ckd_reprint set n_status=0 ");
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
        #endregion 


    }
}
