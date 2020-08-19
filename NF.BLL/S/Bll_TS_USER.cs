using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// 用户表
    /// </summary>
    public partial class Bll_TS_USER
    {
        private readonly Dal_TS_USER dal = new Dal_TS_USER();
        public Bll_TS_USER()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            return dal.Exists(C_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TS_USER model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        public bool UpdatePwd(Mod_TS_USER model)
        {
            return dal.UpdatePwd(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateInfo(Mod_TS_USER model)
        {
            return dal.UpdateInfo(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TS_USER model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string C_ID)
        {

            return dal.Delete(C_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_IDlist)
        {
            return dal.DeleteList(C_IDlist);
        }

        /// <summary>
        /// 获取合同区域
        /// </summary>
        /// <param name="saleEmpID">业务员ID</param>
        /// <returns></returns>
        public DataSet GetConArea(string saleEmpID)
        {
            return dal.GetConArea(saleEmpID);
        }

        /// <summary>
        /// 获取业务员姓名
        /// </summary>
        /// <param name="id">PKID</param>
        /// <returns></returns>
        public string GetSaleName(string id)
        {
            return dal.GetSaleName(id);
        }

        /// <summary>
        /// 根据用户主键ID获取当前部门
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public DataSet GetSaleDept(string userID)
        {
            return dal.GetSaleDept(userID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TS_USER GetModel(string C_ID)
        {

            return dal.GetModel(C_ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TS_USER GetTokenModel(string C_TOKEN_ID)
        {
            return dal.GetTokenModel(C_TOKEN_ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TS_RoleUSER GetTokenUserRoleModel(string C_TOKEN_ID)
        {
            return dal.GetTokenUserRoleModel(C_TOKEN_ID);
        }
        /// <summary>
        /// 业务员
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="code">编号</param>
        /// <returns></returns>
        public DataSet GetSales(string name, string code)
        {
            return dal.GetSales(name, code);
        }
        public DataSet GetSales1(string name, string code)
        {
            return dal.GetSales1(name, code);
        }

        /// <summary>
        /// 根据登录登录账号获取当前部门
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public string GetDept(string account)
        {
            return dal.GetDept(account);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TS_USER> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TS_USER> DataTableToList(DataTable dt)
        {
            List<Mod_TS_USER> modelList = new List<Mod_TS_USER>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TS_USER model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        #endregion  BasicMethod

    }
}

