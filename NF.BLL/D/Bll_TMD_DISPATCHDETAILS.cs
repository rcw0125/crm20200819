using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 发运单详情
    /// </summary>
    public partial class Bll_TMD_DISPATCHDETAILS
    {
        private readonly Dal_TMD_DISPATCHDETAILS dal = new Dal_TMD_DISPATCHDETAILS();
        public Bll_TMD_DISPATCHDETAILS()
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
        public bool Add(Mod_TMD_DISPATCHDETAILS model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMD_DISPATCHDETAILS model)
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
        public Mod_TMD_DISPATCHDETAILS GetModel(string C_ID)
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
        public List<Mod_TMD_DISPATCHDETAILS> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMD_DISPATCHDETAILS> DataTableToList(DataTable dt)
        {
            List<Mod_TMD_DISPATCHDETAILS> modelList = new List<Mod_TMD_DISPATCHDETAILS>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMD_DISPATCHDETAILS model;
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

        #region//自定义方法

        /// <summary>
        /// 获取质量等级NC主键
        /// </summary>
        /// <param name="checkname">质量名称</param>
        /// <param name="flag">8线材，6钢坯</param>
        /// <returns></returns>
        public DataSet GetCheck(string checkname, int flag)
        {
            return dal.GetCheck(checkname, flag);
        }

        /// <summary>
        /// 根据订单号获取发运单据
        /// </summary>
        /// <param name="orderNO"></param>
        /// <returns></returns>
        public DataSet GetOrderFYD(string orderNO)
        {
            return dal.GetOrderFYD(orderNO);
        }

        /// <summary>
        /// 根据发运单获取明细
        /// </summary>
        /// <param name="sendCode">发运单据号</param>
        /// <param name="orderType">钢种类型</param>
        /// <returns></returns>
        public DataSet GetOrderFYDList(string sendCode, string orderType)
        {
            return dal.GetOrderFYDList(sendCode, orderType);
        }

        /// <summary>
        /// 更新导入NC生成新主键
        /// </summary>
        /// <returns></returns>
        public bool UpdateNCID(List<apiPkDto> list, int flag)
        {
            return dal.UpdateNCID(list, flag);
        }
        /// <summary>
        /// 发运单钢坯
        /// </summary>
        public DataSet GetDispatchGP(string dispatchCode)
        {
            return dal.GetDispatchGP(dispatchCode);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDispatchList(string dispatchCode, int flag)
        {
            return dal.GetDispatchList(dispatchCode, flag);
        }

        /// <summary>
        /// 物流钢坯实绩
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool WL_SJ_F(List<ApiDispDto> list)
        {
            return dal.WL_SJ_F(list);
        }

        /// <summary>
        /// 物流钢坯实绩
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int WL_SJ(List<ApiDispDto> list)
        {
            return dal.WL_SJ(list);
        }

        /// <summary>
        /// 获取未生成钢坯质证书
        /// </summary>
        /// <returns></returns>
        public DataTable GetGPZZS()
        {
            return dal.GetGPZZS();
        }

        /// <summary>
        /// 更新销售出库打印状态
        /// </summary>
        /// <param name="fyd">发运单号</param>
        /// <param name="printemp">打印人</param>
        /// <returns></returns>
        public bool UpdateZJB(string fyd, string printemp, string printtype)
        {
            return dal.UpdateZJB(fyd, printemp,printtype);
        }

        /// <summary>
        /// 出库单补打设置
        /// </summary>
        /// <param name="fyd">发运单号</param>
        /// <param name="printemp">打印人</param>
        /// <param name="zt">0未打印，1已打印，2补打</param>
        /// <returns></returns>
        public bool UpdatePDSet(string fyd, string printemp, string zt,string remark)
        {
            return dal.UpdatePDSet(fyd, printemp,zt, remark);
        }

        /// <summary>
        /// 根据发运单号获取中间表数据
        /// </summary>
        /// <param name="sendcode">发运单号</param>
        /// <returns></returns>
        public DataSet GetZJBList(string sendcode)
        {
            return dal.GetZJBList(sendcode);
        }

        /// <summary>
        /// 线材/钢坯销售出库净重
        /// </summary>
        /// <param name="sendcode">发运单</param>
        /// <param name="ch">车号</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="bs">批次号/炉号</param>
        /// <param name="printEmp">打印人</param>
        /// <param name="startDate">出库开始时间</param>
        /// <param name="endDate">出库截至时间</param>
        /// <returns></returns>
        public DataSet GetZJBList(string sendcode, string ch, string stlgrd, string bs, string printEmp, string outStartTime, string outEndTime, string printstatus)
        {
            return dal.GetZJBList(sendcode, ch, stlgrd, bs, printEmp, outStartTime, outEndTime, printstatus);
        }

        /// <summary>
        /// 更新钢坯状态
        /// </summary>
        /// <param name="sendcode"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateGPStatus(string sendcode, int status)
        {
            return dal.UpdateGPStatus(sendcode, status);
        }

        /// <summary>
        /// 更新钢坯状态
        /// </summary>
        /// <param name="sendcode"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateFydStatus(string sendcode, int status)
        {
            return dal.UpdateFydStatus(sendcode, status);
        }
        #endregion


        #region//质证书打印

        /// <summary>
        /// 根据发运单号获取基本信息
        /// </summary>
        /// <param name="sendCode"></param>
        /// <returns></returns>
        public DataSet GetFydInfo(string sendCode)
        {
            return dal.GetFydInfo(sendCode);
        }

        /// <summary>
        /// 根据发运单号获取钢种
        /// </summary>
        /// <param name="sendCode"></param>
        /// <returns></returns>
        public DataSet GetFydStlGrd(string sendCode)
        {
            return dal.GetFydStlGrd(sendCode);
        }
        /// <summary>
        /// 根据发运单与钢种获取执行标准
        /// </summary>
        /// <param name="sendCode">发运单号</param>
        /// <param name="stlGrd">钢种</param>
        /// <returns></returns>
        public DataSet GetFydStdCode(string sendCode, string stlGrd)
        {
            return dal.GetFydStdCode(sendCode, stlGrd);
        }

        /// <summary>
        /// 根据发运单获取明细
        /// </summary>
        /// <param name="sendCode">发运单据号</param>
        /// <param name="orderType">钢种类型</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="stdCode">执行标准</param>
        /// <returns></returns>
        public DataSet GetFYDList(string sendCode, string orderType, string stlGrd, string stdCode)
        {

            return dal.GetFYDList(sendCode, orderType, stlGrd, stdCode);
        }

        /// <summary>
        /// 根据批号获取性能成分
        /// </summary>
        /// <param name="batchNo"></param>
        /// <returns></returns>
        public DataSet GetBatchCFXN(string batchNo, string stlgrd, string stdcode, string stove, string type)
        {
            return dal.GetBatchCFXN(batchNo, stlgrd, stdcode, stove, type);
        }
        #endregion

    }
}

