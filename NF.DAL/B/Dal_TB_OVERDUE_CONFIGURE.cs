using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using NF.DAL;

namespace NF.DAL
{
    /// <summary>
    /// 库存超期与预警配置表
    /// </summary>
    public partial class Dal_TB_OVERDUE_CONFIGURE
    {
        public Dal_TB_OVERDUE_CONFIGURE()
        { }

        public DataSet GetList()
        {
            string cmdText = "SELECT C_ID,C_STL_TYPE,N_YJ_DAYS FROM TB_OVERDUE_CONFIGURE";
            return DbHelperOra.Query(cmdText);
        }

        public bool Update(Mod_TB_OVERDUE_CONFIGURE mod)
        {
            #region //更新
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("UPDATE TB_OVERDUE_CONFIGURE SET ");
            strSql.AppendFormat("N_YJ_DAYS={0}", mod.N_YJ_DAYS);
            strSql.AppendFormat(" WHERE C_ID='{0}'", mod.C_ID);
            #endregion

            return DbHelperOra.ExecuteSql(strSql.ToString()) > 0 ? true : false;
          
        }
    }
}
