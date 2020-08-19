using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using NF.DAL;

namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TB_STA
    /// </summary>
    public partial class Dal_TB_STA
    {
        public Dal_TB_STA()
        { }
        #region  BasicMethod

        /// <summary>
        /// 根据工序id，数据状态加载数据列表
        /// </summary>
        /// <param name="iStatus">状态</param>
        /// <param name="strGXID">工序ID</param>
        /// <returns></returns>
        public DataSet GetListByStatus(int iStatus, string strGXID, string C_STA_DESC)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_ID,C_PRO_ID,C_STA_CODE,C_STA_DESC,C_EMP_ID,D_MOD_DT,C_REMARK,D_START_DATE,D_END_DATE,DECODE(N_STATUS,1,'启用','停用') N_STATUS,C_STA_ERPCODE,C_STA_MESCODE,N_SORT,C_ERP_PK ");
            strSql.Append(" FROM TB_STA WHERE 1=1");
            strSql.Append(" AND N_STATUS='" + iStatus + "'");
            if (strGXID.Trim() != "")
            {
                strSql.Append(" AND C_PRO_ID = '" + strGXID + "'");
            }
            if (C_STA_DESC.Trim() != "")
            {
                strSql.Append(" AND C_STA_DESC LIKE '%" + C_STA_DESC + "%'");
            }
            strSql.Append("  ORDER BY N_SORT");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据备注，数据状态加载数据列表
        /// </summary>
        /// <param name="iStatus">状态</param>
        /// <param name="strBZ">备注</param>
        /// <returns></returns>
        public DataSet GetListByStatusANDBZ(int iStatus, string strBZ)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_ID,C_PRO_ID,C_STA_CODE,C_STA_DESC,C_EMP_ID,D_MOD_DT,C_REMARK,D_START_DATE,D_END_DATE,DECODE(N_STATUS,1,'启用','停用') N_STATUS,C_STA_ERPCODE,C_STA_MESCODE,N_SORT ");
            strSql.Append(" FROM TB_STA WHERE 1=1");
            strSql.Append(" AND N_STATUS='" + iStatus + "'");
            if (strBZ.Trim() != "")
            {
                strSql.Append(" AND C_REMARK = '" + strBZ + "'");
            }
            strSql.Append("  ORDER BY C_STA_CODE, N_SORT");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) from TB_STA");
            strSql.Append(" WHERE C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TB_STA model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TB_STA(");
            strSql.Append("C_PRO_ID,C_STA_CODE,C_STA_DESC,C_EMP_ID,D_MOD_DT,C_REMARK,D_START_DATE,D_END_DATE,N_STATUS,C_STA_ERPCODE,C_STA_MESCODE,C_ERP_PK,N_SORT)");
            strSql.Append(" values (");
            strSql.Append(":C_PRO_ID,:C_STA_CODE,:C_STA_DESC,:C_EMP_ID,:D_MOD_DT,:C_REMARK,:D_START_DATE,:D_END_DATE,:N_STATUS,:C_STA_ERPCODE,:C_STA_MESCODE,:C_ERP_PK,:N_SORT)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_PRO_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STA_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STA_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":D_START_DATE", OracleDbType.Date),
                    new OracleParameter(":D_END_DATE", OracleDbType.Date),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":C_STA_ERPCODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STA_MESCODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ERP_PK", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_SORT", OracleDbType.Decimal,3)};
            parameters[0].Value = model.C_PRO_ID;
            parameters[1].Value = model.C_STA_CODE;
            parameters[2].Value = model.C_STA_DESC;
            parameters[3].Value = model.C_EMP_ID;
            parameters[4].Value = model.D_MOD_DT;
            parameters[5].Value = model.C_REMARK;
            parameters[6].Value = model.D_START_DATE;
            parameters[7].Value = model.D_END_DATE;
            parameters[8].Value = model.N_STATUS;
            parameters[9].Value = model.C_STA_ERPCODE;
            parameters[10].Value = model.C_STA_MESCODE;
            parameters[11].Value = model.C_ERP_PK;
            parameters[12].Value = model.N_SORT;

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
        public bool Update(Mod_TB_STA model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TB_STA set ");
            strSql.Append("C_PRO_ID=:C_PRO_ID,");
            strSql.Append("C_STA_CODE=:C_STA_CODE,");
            strSql.Append("C_STA_DESC=:C_STA_DESC,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("D_START_DATE=:D_START_DATE,");
            strSql.Append("D_END_DATE=:D_END_DATE,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_STA_ERPCODE=:C_STA_ERPCODE,");
            strSql.Append("C_STA_MESCODE=:C_STA_MESCODE,");
            strSql.Append("N_SORT=:N_SORT,");
            strSql.Append("C_ERP_PK=:C_ERP_PK");
            strSql.Append(" WHERE C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_PRO_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STA_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STA_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":D_START_DATE", OracleDbType.Date),
                    new OracleParameter(":D_END_DATE", OracleDbType.Date),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":C_STA_ERPCODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STA_MESCODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_SORT", OracleDbType.Decimal,3),
                    new OracleParameter(":C_ERP_PK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_PRO_ID;
            parameters[1].Value = model.C_STA_CODE;
            parameters[2].Value = model.C_STA_DESC;
            parameters[3].Value = model.C_EMP_ID;
            parameters[4].Value = model.D_MOD_DT;
            parameters[5].Value = model.C_REMARK;
            parameters[6].Value = model.D_START_DATE;
            parameters[7].Value = model.D_END_DATE;
            parameters[8].Value = model.N_STATUS;
            parameters[9].Value = model.C_STA_ERPCODE;
            parameters[10].Value = model.C_STA_MESCODE;
            parameters[11].Value = model.N_SORT;
            parameters[12].Value = model.C_ERP_PK;
            parameters[13].Value = model.C_ID;

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
            strSql.Append("delete from TB_STA ");
            strSql.Append(" WHERE C_ID=:C_ID ");
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
            strSql.Append("delete from TB_STA ");
            strSql.Append(" WHERE C_ID in (" + C_IDlist + ")  ");
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
        public Mod_TB_STA GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * from TB_STA ");
            strSql.Append(" WHERE C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TB_STA model = new Mod_TB_STA();
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
        public Mod_TB_STA DataRowToModel(DataRow row)
        {
            Mod_TB_STA model = new Mod_TB_STA();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_PRO_ID"] != null)
                {
                    model.C_PRO_ID = row["C_PRO_ID"].ToString();
                }
                if (row["C_STA_CODE"] != null)
                {
                    model.C_STA_CODE = row["C_STA_CODE"].ToString();
                }
                if (row["C_STA_DESC"] != null)
                {
                    model.C_STA_DESC = row["C_STA_DESC"].ToString();
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["D_MOD_DT"] != null && row["D_MOD_DT"].ToString() != "")
                {
                    model.D_MOD_DT = DateTime.Parse(row["D_MOD_DT"].ToString());
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["D_START_DATE"] != null && row["D_START_DATE"].ToString() != "")
                {
                    model.D_START_DATE = DateTime.Parse(row["D_START_DATE"].ToString());
                }
                if (row["D_END_DATE"] != null && row["D_END_DATE"].ToString() != "")
                {
                    model.D_END_DATE = DateTime.Parse(row["D_END_DATE"].ToString());
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["C_STA_ERPCODE"] != null)
                {
                    model.C_STA_ERPCODE = row["C_STA_ERPCODE"].ToString();
                }
                if (row["C_STA_MESCODE"] != null)
                {
                    model.C_STA_MESCODE = row["C_STA_MESCODE"].ToString();
                }
                if (row["N_SORT"] != null && row["N_SORT"].ToString() != "")
                {
                    model.N_SORT = decimal.Parse(row["N_SORT"].ToString());
                }
                if (row["C_ERP_PK"] != null)
                {
                    model.C_ERP_PK = row["C_ERP_PK"].ToString();
                }
                if (row["C_SSBMID"] != null)
                {
                    model.C_SSBMID = row["C_SSBMID"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetALLList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT t.C_ID,t.C_PRO_ID,t.C_STA_CODE,t.C_STA_DESC,t.C_EMP_ID,t.D_MOD_DT,t.C_REMARK,t.D_START_DATE,t.D_END_DATE,t.N_STATUS,t.C_STA_ERPCODE,t.C_STA_MESCODE,t.N_SORT ");
            strSql.Append(" FROM TB_STA t WHERE t.n_status=1 ");
            strSql.Append(" ORDER BY t.N_SORT");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWHERE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT t.C_ID,t.C_PRO_ID,t.C_STA_CODE,t.C_STA_DESC,t.C_EMP_ID,t.D_MOD_DT,t.C_REMARK,t.D_START_DATE,t.D_END_DATE,t.N_STATUS,t.C_STA_ERPCODE,t.C_STA_MESCODE,t.N_SORT ");
            strSql.Append(" FROM TB_STA t  join tb_pro a on  t.c_pro_id=a.c_id where a.c_pro_code='ZX' and t.n_status=1 ");
            if (strWHERE.Trim() != "")
            {
                strSql.Append(" and " + strWHERE);
            }
            strSql.Append(" ORDER BY t.N_SORT");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetStaList(string strWHERE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT t.* ");
            strSql.Append(" FROM TB_STA t  where t.n_status=1 ");
            if (strWHERE.Trim() != "")
            {
                strSql.Append(" and " + strWHERE);
            }
            strSql.Append(" ORDER BY t.N_SORT");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string C_PRO_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) FROM TB_STA WHERE N_STATUS=1 AND C_PRO_ID='"+C_PRO_ID + "'");
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
        public DataSet GetListByPage(string strWHERE, string orderby, int startIndex, int endIndex)
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
            strSql.Append(")AS Row, T.*  from TB_STA T ");
            if (!string.IsNullOrEmpty(strWHERE.Trim()))
            {
                strSql.Append(" WHERE " + strWHERE);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} AND {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }


        #endregion  BasicMethod

        #region MyRegion
        /// <summary>
        /// 根据工序类型，数据状态加载数据列表
        /// </summary>
        /// <param name="iStatus">状态</param>
        /// <param name="strGXID">类型 炼钢/轧钢</param>
        /// <returns></returns>
        public DataSet GetListByType(int iStatus, string strType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_ID,C_PRO_ID,C_STA_CODE,C_STA_DESC,C_EMP_ID,D_MOD_DT,C_REMARK,D_START_DATE,D_END_DATE,DECODE(N_STATUS,1,'启用','停用') N_STATUS,C_STA_ERPCODE,C_STA_MESCODE,N_SORT ");
            strSql.Append(" FROM TB_STA WHERE 1=1");
            strSql.Append(" AND N_STATUS='" + iStatus + "'");
            if (strType.Trim() != "")
            {
                strSql.Append(" AND C_REMARK = '" + strType + "'");
            }
            strSql.Append("  ORDER BY C_STA_CODE, N_SORT");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 加载炼钢工位冶炼时间
        /// </summary>
        /// <returns></returns>
        public DataSet GetListGWCN(string grd, string std)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_ID,'' AS N_SMELT_TIME");
            strSql.Append(" FROM TB_STA WHERE N_STATUS=1");
            strSql.Append(" AND C_REMARK='炼钢'");
            strSql.Append(" AND C_ID NOT IN (SELECT C_STA_ID FROM TPB_STEEL_SMELT_TIME WHERE C_STL_GRD='" + grd + "' AND C_STD_CODE='" + std + "')");
            strSql.Append("  ORDER BY C_STA_CODE, N_SORT");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 加载钢坯机试产能
        /// </summary>
        /// <returns></returns>
        public DataSet GetListGPCN(string grd, string std, string spec)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_ID,'' AS N_CAPACITY");
            strSql.Append(" FROM TB_STA WHERE N_STATUS=1");
            strSql.Append(" AND C_PRO_ID IN（SELECT C_ID FROM TB_PRO WHERE C_PRO_DESC='连铸' OR C_PRO_DESC='开坯' OR C_PRO_DESC='修磨'）");
            strSql.Append(" AND C_ID NOT IN (SELECT C_STA_ID FROM TPB_SLAB_CAPACITY WHERE N_STATUS=1 And C_STL_GRD='" + grd + "' AND C_STD_CODE='" + std + "' AND C_SPEC='" + spec + "')");
            strSql.Append("  ORDER BY C_STA_CODE, N_SORT");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据工序加载工位
        /// </summary>
        /// <param name="strGX">工序： 轧制/开坯</param>
        /// <returns></returns>
        public DataSet GetListByGX(string strGX)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT T.C_ID, T.C_STA_CODE, T.C_STA_DESC ");
            strSql.Append(" FROM TB_STA T, TB_PRO A ");
            strSql.Append("  WHERE T.C_PRO_ID = A.C_ID  AND T.N_STATUS = 1 ");
            strSql.Append("  AND A.C_PRO_CODE = '" + strGX + "' ");
            strSql.Append("  ORDER BY T.N_SORT");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 加载转炉工位
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByZLGX()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT T.C_ID, T.C_STA_CODE, T.C_STA_DESC ");
            strSql.Append(" FROM TB_STA T, TB_PRO A ");
            strSql.Append("  WHERE T.C_PRO_ID = A.C_ID  AND T.N_STATUS = 1 ");
            strSql.Append("  AND (A.C_PRO_DESC = '转炉' OR A.C_PRO_DESC = '熔化炉') ");
            strSql.Append(" ORDER BY T.C_STA_DESC, T.N_SORT ");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据工序描述加载工位
        /// </summary>
        /// <param name="strGX">工序： 轧制/开坯</param>
        /// <returns></returns>
        public DataSet GetListByGXStr(string strGX)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT T.C_ID, T.C_STA_CODE, T.C_STA_DESC ");
            strSql.Append(" FROM TB_STA T, TB_PRO A ");
            strSql.Append("  WHERE T.C_PRO_ID = A.C_ID  AND T.N_STATUS = 1 ");
            strSql.Append("  AND A.C_PRO_CODE in（" + strGX + "） ");
            strSql.Append("  ORDER BY A.C_PRO_DESC,t.C_STA_CODE");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据工序代码加载工位
        /// </summary>
        /// <param name="strGXDM">工序代码</param>
        /// <returns></returns>
        public DataSet GetListByGXDM(string strGXDM)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT T.C_ID, T.C_STA_CODE, T.C_STA_DESC ");
            strSql.Append(" FROM TB_STA T, TB_PRO A ");
            strSql.Append("  WHERE T.C_PRO_ID = A.C_ID  AND T.N_STATUS = 1 ");
            strSql.Append("  AND A.C_PRO_CODE = '" + strGXDM + "' ");
            strSql.Append("  ORDER BY T.N_SORT");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TB_STA GetModelByCODE(string C_STA_CODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_ID,C_PRO_ID,C_STA_CODE,C_STA_DESC,C_EMP_ID,D_MOD_DT,C_REMARK,D_START_DATE,D_END_DATE,N_STATUS,C_STA_ERPCODE,C_ERP_PK,C_SSBMID,C_STA_MESCODE,N_SORT from TB_STA ");
            strSql.Append(" WHERE C_STA_CODE=:C_STA_CODE ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_STA_CODE", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_STA_CODE;

            Mod_TB_STA model = new Mod_TB_STA();
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
        /// 检查是否存在重复数据
        /// </summary>
        /// <param name="C_STA_CODE">工位代码</param>
        /// <returns></returns>
        public bool ExistsBySTACode(string C_STA_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TB_STA");
            strSql.Append(" where C_STA_CODE=:C_STA_CODE  AND N_STATUS=1");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_STA_CODE", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_STA_CODE;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据工位代码获取工位主键
        /// </summary>
        /// <param name="C_STA_CODE">工位代码</param>
        /// <returns></returns>
        public string GetStaIdByCode(string C_STA_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_ID from TB_STA ");
            strSql.Append(" where C_STA_CODE=:C_STA_CODE  AND N_STATUS=1");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_STA_CODE", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_STA_CODE;

            object obj = DbHelperOra.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return "0";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 根据工位主键获取工位代码
        /// </summary>
        /// <param name="C_ID">工位主键</param>
        /// <returns></returns>
        public string Get_STA_CODE(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_STA_CODE from TB_STA ");
            strSql.Append(" where C_ID='" + C_ID + "' ");

            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "0";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 根据工位主键获取工位名称
        /// </summary>
        /// <param name="C_ID">工位主键</param>
        /// <returns>工位名称</returns>
        public string Get_STA_DESC(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_STA_DESC from TB_STA ");
            strSql.Append(" where C_ID='" + C_ID + "' ");

            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "0";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 根据工位主键获取NC主键
        /// </summary>
        /// <param name="C_ID">工位主键</param>
        /// <returns>工位名称</returns>
        public string Get_NC_ID(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TB_STA.C_ERP_PK from TB_STA ");
            strSql.Append(" where C_ID='" + C_ID + "' ");

            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "0";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 根据工位主键获取工位代码
        /// </summary>
        /// <param name="C_ID">工位主键</param>
        /// <returns></returns>
        public string Get_MES_CODE(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT NVL(MAX(T.C_STA_MESCODE), '0') from TB_STA T ");
            strSql.Append(" where T.N_STATUS = 1 and  C_ID='" + C_ID + "' ");

            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "0";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 根据工位主键获取工位代码
        /// </summary>
        /// <param name="C_ID">工位主键</param>
        /// <returns></returns>
        public string Get_CODE(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT NVL(MAX(C_STA_CODE), '0') from TB_STA ");
            strSql.Append(" where N_STATUS=1 and C_ID='" + C_ID + "' ");

            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "0";
            }
            else
            {
                return obj.ToString();
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TB_STA GetModelBySoft(string N_SORT,string C_PRO_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_ID,C_PRO_ID,C_STA_CODE,C_STA_DESC,C_EMP_ID,D_MOD_DT,C_REMARK,D_START_DATE,D_END_DATE,N_STATUS,C_STA_ERPCODE,C_STA_MESCODE,N_SORT,C_ERP_PK,C_SSBMID from TB_STA ");
            strSql.Append(" WHERE N_STATUS=1 AND N_SORT=:N_SORT AND C_PRO_ID=:C_PRO_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":N_SORT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRO_ID", OracleDbType.Varchar2,100)  };
            parameters[0].Value = N_SORT;
            parameters[1].Value = C_PRO_ID;

            Mod_TB_STA model = new Mod_TB_STA();
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
        /// 重置顺序
        /// </summary>
        public int CZSORT(string pro)
        {
            DataTable dt = GetListByStatus(1, pro, "").Tables[0];
            TransactionHelper.BeginTransaction();
            if (dt.Rows.Count > 0)
            {
                int sort = 1;
                foreach (DataRow item in dt.Rows)
                {
                    string sql = "";
                    sql = "UPDATE TB_STA SET N_SORT='" + sort + "' WHERE C_ID='" + item["C_ID"] + "' AND C_PRO_ID='"+ pro + "' ";
                    if (TransactionHelper.ExecuteSql(sql) == 1)
                    {
                        sort++;
                    }
                    else
                    {
                        TransactionHelper.RollBack();
                        return 0;
                    }
                }
            }
            TransactionHelper.Commit();
            return 1;
        }
        #endregion
    }
}

