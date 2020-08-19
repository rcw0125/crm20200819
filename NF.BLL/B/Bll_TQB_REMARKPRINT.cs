using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// 质量设计主表信息
    /// </summary>
    public partial class Bll_TQB_REMARKPRINT
    {
        private readonly Dal_TQB_REMARKPRINT dal = new Dal_TQB_REMARKPRINT();
        public Bll_TQB_REMARKPRINT()
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
        public bool Add(Mod_TQB_REMARKPRINT model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TQB_REMARKPRINT model)
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string C_IDlist)
        {
            return dal.DeleteList(C_IDlist);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TQB_REMARKPRINT GetModel(string C_ID)
        {
            return dal.GetModel(C_ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        #endregion  BasicMethod


        public DataSet GetGrdList(string strWhere)
        {
            return dal.GetGrdList(strWhere);
        }

        public bool DeleteGrdList(string C_IDlist)
        {
            return dal.DeleteGrdList(C_IDlist);
        }
        public bool AddGrd(Mod_TMb_MONI_STLGRD model)
        {
            return dal.AddGrd(model);
        }
    }
}

