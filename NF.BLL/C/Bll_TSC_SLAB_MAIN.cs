using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 坯料主表
    /// </summary>
    public partial class Bll_TSC_SLAB_MAIN
    {
        private readonly Dal_TSC_SLAB_MAIN dal = new Dal_TSC_SLAB_MAIN();
        private readonly Dal_TSC_SLAB_MAIN dalR = new Dal_TSC_SLAB_MAIN();
        public Bll_TSC_SLAB_MAIN()
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
        public bool Add(Mod_TSC_SLAB_MAIN model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TSC_SLAB_MAIN model)
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
        /// 得到一个对象实体
        /// </summary>
        public Mod_TSC_SLAB_MAIN GetModel(string C_ID)
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
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TSC_SLAB_MAIN> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TSC_SLAB_MAIN> DataTableToList(DataTable dt)
        {
            List<Mod_TSC_SLAB_MAIN> modelList = new List<Mod_TSC_SLAB_MAIN>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TSC_SLAB_MAIN model;
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
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod


        #region //钢坯库存查询
        /// <summary>
        /// 获取钢坯数据列表
        /// </summary>
        /// <param name="matCode">物料编码</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="startDate">入库开始时间</param>
        /// <param name="endDate">入库截至时间</param>
        /// <returns></returns>
        public DataSet GetSlabList(string matCode, string stlGrd, string spec, string startDate, string endDate, string slabCK)
        {
            return dal.GetSlabList(matCode, stlGrd, spec, startDate, endDate, slabCK);
        }
        #endregion

        #region PCI
        /// <summary>
        /// 获取钢坯库存数据
        /// </summary>
        /// <param name="C_MOVE_TYPE">状态</param>
        /// <param name="C_STOVE">炉号</param>
        /// <param name="C_MAT_CODE">物料号</param>
        /// <param name="C_STD_CODE">执行标准</param>
        /// <param name="C_SLABWH_CODE">仓库</param>
        /// <param name="C_BATCH_NO">开坯号</param>
        /// <param name="C_JUDGE_LEV_ZH">质量等级</param>
        /// <returns></returns>
        public DataSet GetList(string C_MOVE_TYPE, string C_STOVE, string C_MAT_CODE, string C_STD_CODE, string C_SLABWH_CODE, string C_BATCH_NO, string C_JUDGE_LEV_ZH,string zyx1,string zyx2)
        {
            return dal.GetList(C_MOVE_TYPE, C_STOVE, C_MAT_CODE, C_STD_CODE, C_SLABWH_CODE, C_BATCH_NO, C_JUDGE_LEV_ZH, zyx1, zyx2);
        }


        /// <summary>
        /// 根据发运单号获取数据
        /// </summary>
        /// <param name="C_FYDH">发运单号</param>
        /// <param name="C_MOVE_TYPE">状态</param>
        /// <param name="C_STOVE">炉号</param>
        /// <param name="C_BATCH_NO">批号</param>
        /// <param name="C_SLABWH_CODE">仓库</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <returns></returns>
        public DataSet GetListByFYDH(string C_FYDH, string C_MOVE_TYPE, string C_STOVE, string C_BATCH_NO, string C_SLABWH_CODE,string C_STL_GRD, string C_LIC_PLA_NO, string status)
        {
            return dal.GetListByFYDH(C_FYDH, C_MOVE_TYPE, C_STOVE, C_BATCH_NO, C_SLABWH_CODE,C_STL_GRD, C_LIC_PLA_NO, status);
        }
        /// <summary>
        /// 检测库存是否变更
        /// </summary>
        /// <param name="mat">物料号</param>
        /// <param name="ck">仓库</param>
        /// <param name="ckarea">区域</param>
        /// <param name="ckloc">库位</param>
        /// <param name="stove">炉号</param>
        /// <param name="batch">批号</param>
        /// <param name="zldj">质量等级</param>
        /// <returns></returns>
        public int CKKC(string mat, string ck, string ckarea, string ckloc, string stove, string batch, string zldj)
        {
            return dal.CKKC(mat, ck, ckarea, ckloc, stove, batch, zldj);
        }
        /// <summary>
        /// 修改钢坯状态
        /// </summary>
        /// <param name="list">List<CommonKC>通用库存处理类</param>
        /// <param name="status">状态</param>
        /// <returns>0失败1成功</returns>
        public int UPSLABSTATUS(List<CommonKC> list, string fydh, string status)
        {
            return dal.UPSLABSTATUS(list, fydh, status);
        }
        /// <summary>
        /// 根据发运单号获取已做实绩数量
        /// </summary>
        /// <param name="fydh">发运单号</param>
        /// <returns></returns>
        public int GetSJCount(string fydh)
        {
            return dal.GetSJCount(fydh);
        }
        /// <summary>
        /// 根据发运单号获取该发运单计划总数
        /// </summary>
        /// <param name="fydh">发运单号</param>
        /// <returns></returns>
        public int GetJHCount(string fydh)
        {

            return dal.GetJHCount(fydh);
        }
            #endregion
        }
}

