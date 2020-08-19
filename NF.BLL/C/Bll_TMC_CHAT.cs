using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 聊天记录
    /// </summary>
    public partial class Bll_TMC_CHAT
    {
        private readonly Dal_TMC_CHAT dal = new Dal_TMC_CHAT();
        public Bll_TMC_CHAT()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMC_CHAT model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMC_CHAT model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.Delete();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMC_CHAT GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.GetModel();
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
        public List<Mod_TMC_CHAT> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMC_CHAT> DataTableToList(DataTable dt)
        {
            List<Mod_TMC_CHAT> modelList = new List<Mod_TMC_CHAT>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMC_CHAT model;
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
        #region  ExtensionMethod

        /// <summary>
        /// 获取客户列表
        /// </summary>
        /// <param name="fid">接收者</param>
        /// <returns></returns>
        public DataSet GetUID(string fid)
        {
            return dal.GetUID(fid);
        }

        /// <summary>
        /// 获取客户聊天记录(手机接口)
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="LastDT"></param>
        /// <param name="FristDT"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public DataSet GetChatList2(string emp, string LastDT, string FristDT, string Count)
        {
            return dal.GetChatList2(emp, LastDT, FristDT, Count);
        }

        /// <summary>
        ///获取聊天记录
        /// </summary>
        public DataSet GetChatList(string uid, string fid, string LastDT, string FristDT, string Count)
        {
            return dal.GetChatList(uid, fid, LastDT, FristDT, Count);
        }

        /// <summary>
        /// 获取售后聊天记录
        /// </summary>
        /// <param name="uid">发送者</param>
        /// <param name="fid">接收者</param>
        /// <returns></returns>

        public DataSet GetChatList(string uid, string fid)
        {
            return dal.GetChatList(uid, fid);
        }


        #endregion  ExtensionMethod
    }
}

