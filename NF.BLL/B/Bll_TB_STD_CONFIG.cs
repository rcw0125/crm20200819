using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 标准匹配表
    /// </summary>
    public partial class Bll_TB_STD_CONFIG
    {
        private readonly Dal_TB_STD_CONFIG dal = new Dal_TB_STD_CONFIG();
        public Bll_TB_STD_CONFIG()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string stlGrd, string custNo, string custXY)
        {
            return dal.Exists(stlGrd, custNo, custXY);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TB_STD_CONFIG model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TB_STD_CONFIG model)
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
        public Mod_TB_STD_CONFIG GetModel(string C_ID)
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.GetModel(C_ID);
        }


        /// <summary>
        /// 获取自由项
        /// </summary>
        /// <param name="stdCode">执行标准</param>
        /// <param name="stlGrd">钢种</param>
        /// <returns></returns>
        public DataRow GetFREE(string stdCode, string stlGrd)
        {
            return dal.GetFREE(stdCode, stlGrd);
        }

        /// <summary>
        /// 获取自由项
        /// </summary>
        /// <param name="C_CUST_TECH_PROT">客户协议</param>
        /// <param name="stdCode">执行标准</param>
        /// <param name="stlGrd">钢种</param>
        /// <returns></returns>
        public DataRow GetFREE2(string C_CUST_TECH_PROT, string stlGrd)
        {
            return dal.GetFREE2(C_CUST_TECH_PROT, stlGrd);
        }

        /// <summary>
        /// 获取技术协议
        /// </summary>
        /// <param name="c_stl_grd">钢种</param>
        /// <param name="c_cust_no">客户编码</param>
        /// <returns></returns>
        public DataSet GetCUST_TECH_PROT(string c_stl_grd, string c_cust_no)
        {
            return dal.GetCUST_TECH_PROT(c_stl_grd, c_cust_no);
        }

        /// <summary>
        /// 获取技术协议
        /// </summary>
        /// <param name="c_stl_grd">钢种</param>
        /// <returns></returns>
        public DataSet GetCUST_TECH_PROT(string c_stl_grd)
        {
            return dal.GetCUST_TECH_PROT(c_stl_grd);
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
        public DataSet GetList(string custNo, string custName, string stlGrd, string techProt, string std)
        {
            return dal.GetList(custNo, custName, stlGrd, techProt, std);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TB_STD_CONFIG> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TB_STD_CONFIG> DataTableToList(DataTable dt)
        {
            List<Mod_TB_STD_CONFIG> modelList = new List<Mod_TB_STD_CONFIG>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TB_STD_CONFIG model;
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
        /// 获取记录总数
        /// </summary>
        /// <param name="custNo">客户编码</param>
        /// <param name="custName">客户名称</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="techProt">客户协议</param>
        /// <param name="std">执行标准</param>
        /// <returns></returns>
        public int GetRecordCount(string custNo, string custName, string stlGrd, string techProt, string std)
        {
            return dal.GetRecordCount(custNo, custName, stlGrd, techProt, std);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageSize">显示页数</param>
        /// <param name="startIndex">起始页数</param>
        /// <param name="custNo">客户编码</param>
        /// <param name="custName">客户名称</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="techProt">客户协议</param>
        /// <param name="std">执行标准</param>
        /// <returns></returns>
        public DataSet GetListByPage(int pageSize, int startIndex, string custNo, string custName, string stlGrd, string techProt, string std)
        {
            return dal.GetListByPage(pageSize, startIndex, custNo, custName, stlGrd, techProt, std);
        }

        #endregion  BasicMethod

        #region //停用


        public bool UpdateFlag(List<Mod_TB_STD_CONFIG> list)
        {
            return dal.UpdateFlag(list);
        }

        public bool UpdateStatus(List<string> listID, int status)
        {
            return dal.UpdateStatus(listID, status);
        }

        /// <summary>
        /// 删除客户协议
        /// </summary>
        /// <param name="listID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool DelList(List<string> listID)
        {
            return dal.DelList(listID);
        }
        #endregion

    }
}

