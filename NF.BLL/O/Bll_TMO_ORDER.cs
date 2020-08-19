using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 订单池
    /// </summary>
    public partial class Bll_TMO_ORDER
    {
        private readonly Dal_TMO_ORDER dal = new Dal_TMO_ORDER();
        public Bll_TMO_ORDER()
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
        public bool Add(Mod_TMO_ORDER model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMO_ORDER model)
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
        public Mod_TMO_ORDER GetModel(string C_ID)
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
        public List<Mod_TMO_ORDER> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMO_ORDER> DataTableToList(DataTable dt)
        {
            List<Mod_TMO_ORDER> modelList = new List<Mod_TMO_ORDER>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMO_ORDER model;
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

        #region //自定义方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMO_ORDER GetOrderModel(string C_ORDER_NO)
        {
            return dal.GetOrderModel(C_ORDER_NO);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMO_ORDER GetOrderModel_Plan(string C_ORDER_NO)
        {
            return dal.GetOrderModel_Plan(C_ORDER_NO);
        }

        /// <summary>
        /// 获取单行数据
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public DataRow GetRowOrder(string orderNo, string orderID)
        {
            return dal.GetRowOrder(orderNo, orderID);
        }
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="conNo">合同号</param>
        /// <param name="orderNo">订单号</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="start">签署开始时间</param>
        /// <param name="end">签署结束时间</param>
        /// <param name="custNO">客户编码</param>
        /// <returns></returns>
        public DataSet GetConOrderList(string conNo, string orderNo, string stlGrd, string start, string end, string custNO)
        {
            return dal.GetConOrderList(conNo, orderNo, stlGrd, start, end, custNO);
        }

        /// <summary>
        /// 获取合同明细
        /// </summary>
        /// <param name="custName">客户名称</param>
        /// <param name="conNo">合同号</param>
        /// <param name="empID">业务员</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="start">签署开始时间</param>
        /// <param name="end">签署结束时间</param>
        /// <param name="orderStatus">订单是否评价</param>
        /// <param name="exeStatus">执行状态</param>
        /// <param name="orderType">订单类型8线材，6钢坯，辅产品</param>
        /// <returns></returns>
        public DataSet GetConOrderList(string custName, string conNo, string empID, string stlGrd, string start, string end, string orderStatus, string exeStatus, string area, string status, int orderType, string spec)
        {
            return dal.GetConOrderList(custName, conNo, empID, stlGrd, start, end, orderStatus, exeStatus, area, status, orderType, spec);
        }
        /// <summary>
        /// 获取合同明细
        /// </summary>
        /// <param name="custName">客户名称</param>
        /// <param name="conNo">合同号</param>
        /// <param name="empID">业务员</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="start">签署开始时间</param>
        /// <param name="end">签署结束时间</param>
        /// <param name="orderStatus">订单是否评价</param>
        /// <param name="exeStatus">执行状态</param>
        /// <param name="orderType">订单类型8线材，6钢坯，辅产品</param>
        /// <returns></returns>
        public DataSet GetConOrderList(string custName, string conNo, string empID, string stlGrd, string start, string end, string orderStatus, string exeStatus, string area, string status, int orderType, string spec,string matcode)
        {
            return dal.GetConOrderList(custName, conNo, empID, stlGrd, start, end, orderStatus, exeStatus, area, status, orderType, spec,matcode);
        }

        /// <summary>
        /// 获取需求订单
        /// </summary>
        /// <param name="matCode">物料编码</param>
        /// <param name="matName">物料名称</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="empname">业务员</param>
        /// <param name="saleArea">销售区域</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="status">订单状态</param>
        /// <param name="exeStatus">生产执行状态</param>
        /// <returns></returns>
        public DataSet GetNeedOrderList(string matCode, string matName, string stlGrd, string spec, string empname, string saleArea, string start, string end, string exeStatus, string custName)
        {
            return dal.GetNeedOrderList(matCode, matName, stlGrd, spec, empname, saleArea, start, end, exeStatus, custName);
        }

        /// <summary>
        /// 日计划订单
        /// </summary>
        /// <param name="custName">客户名称</param>
        /// <param name="conno">合同号</param>
        /// <param name="saleEmp">业务员</param>
        /// <param name="strGrd">钢种</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <returns></returns>
        public DataSet GetDayPlanOrder(string custName, string conno, string saleEmp, string stlGrd, string startTime, string endTime, string type, string spec, string matcode)
        {
            return dal.GetDayPlanOrder(custName, conno, saleEmp, stlGrd, startTime, endTime, type, spec, matcode);
        }

        /// <summary>
        /// 检测是否可发运(发运单自由状态下保存校验)
        /// </summary>
        /// <param name="oldfywgt">原发运计划量</param>
        /// <returns></returns>
        public bool IsFy_Edit(decimal fywgt, decimal oldfywgt, string matcode, string stdcode, string area, string pack, string lev)
        {
            return dal.IsFy_Edit(fywgt, oldfywgt, matcode, stdcode, area, pack, lev);
        }

        /// <summary>
        /// 检测是否可发运
        /// </summary>
        /// <param name="fywgt"></param>
        /// <returns></returns>
        public bool IsFy(decimal fywgt, string matcode, string stdcode, string area, string pack, string lev)
        {
            return dal.IsFy(fywgt, matcode, stdcode, area, pack, lev);
        }
        /// <summary>
        /// 检测是否可发运
        /// </summary>
        /// <param name="fywgt"></param>
        /// <returns></returns>
        public bool IsFy(decimal fywgt, string matcode, string stdcode, string area, string pack, string lev, string custName, string con)
        {
            return dal.IsFy(fywgt, matcode, stdcode, area, pack, lev, custName, con);
        }

        /// <summary>
        /// 发运在途量查询
        /// </summary>
        /// <param name="matcode"></param>
        /// <param name="stdcode"></param>
        /// <param name="area"></param>
        /// <param name="pack"></param>
        /// <param name="dj"></param>
        /// <returns></returns>
        public DataSet ZTWGT(string matcode, string stdcode, string area, string pack, string dj)
        {
            return dal.ZTWGT(matcode, stdcode, area, pack, dj);
        }
        /// <summary>
        /// 区域客户发运在途量查询
        /// </summary>
        /// <param name="matcode"></param>
        /// <param name="stdcode"></param>
        /// <param name="area"></param>
        /// <param name="pack"></param>
        /// <param name="dj"></param>
        /// <returns></returns>
        public DataSet ZTWGT(string matcode, string stdcode, string area, string pack, string dj, string custName, string con)
        {
            return dal.ZTWGT(matcode, stdcode, area, pack, dj, custName, con);
        }

        /// <summary>
        /// 库存量查询
        /// </summary>
        /// <returns></returns>
        public DataSet KCWGT(string matcode, string stdcode, string area, string pack, string dj)
        {
            return dal.KCWGT(matcode, stdcode, area, pack, dj);
        }
        /// <summary>
        /// 库存量查询
        /// </summary>
        /// <returns></returns>
        public DataSet KCWGT(string matcode, string stdcode, string area, string pack, string dj, string custName, string con)
        {
            return dal.KCWGT(matcode, stdcode, area, pack, dj, custName, con);
        }


        /// <summary>
        /// 获取订单已出库量+订单在途已发量
        /// </summary>
        /// <param name="orderID">订单主键</param>
        /// <returns></returns>
        public decimal GetYLX_YFWGT(string orderID)
        {
            return dal.GetYLX_YFWGT(orderID);
        }
        /// <summary>
        /// 获取订单已发数量
        /// </summary>
        /// <param name="orderID">订单主键</param>
        /// <returns></returns>
        public DataSet GetYFYWGT(string orderID)
        {
            return dal.GetYFYWGT(orderID);
        }

        /// <summary>
        /// 获取已出库量
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public DataTable GetOUTSTOCKWGT(string orderID,string fyd)
        {
            return dal.GetOUTSTOCKWGT(orderID,fyd);
        }


        /// <summary>
        /// 实时获取可发库存量
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public DataTable GetKCWGT(string orderID)
        {
            return dal.GetKCWGT(orderID);
        }
        /// <summary>
        /// 获取可发支数总量
        /// </summary>
        /// <param name="orderID">订单主键</param>
        /// <param name="top">发运支数</param>
        /// <returns></returns>
        public DataTable GetKCWGT(string orderID, string top)
        {
            return dal.GetKCWGT(orderID, top);
        }

        /// <summary>
        /// 获取发运单原本支数重量
        /// </summary>
        /// <param name="type">订单类型</param>
        /// <param name="fydid">发运单ID</param>
        /// <param name="top"></param>
        /// <returns></returns>
        public DataTable GetFydWgt(string type, string fydid, string top)
        {
            return dal.GetFydWgt(type, fydid, top);
        }

        /// <summary>
        /// 储运获取发运单原本支数重量
        /// </summary>
        /// <param name="type">订单类型8,6</param>
        /// <param name="fydid">发运单明细主键</param>
        /// <param name="procid">其他产品ID</param>
        /// <param name="delprocid">排除其他产品ID</param>
        /// <param name="top"></param>
        /// <returns></returns>
        public DataTable GetCyFydWgt(string type, string fydid, string procid, string delprocid, string top)
        {
            return dal.GetCyFydWgt(type, fydid, procid, delprocid, top);
        }

        /// <summary>
        /// 不锈钢委外仓库
        /// </summary>
        /// <param name="key">仓库编码</param>
        /// <param name="fydID">发运明细主键</param>
        /// <param name="batch">批次号</param>
        /// <returns></returns>
        public DataSet GetCKW(string key, string fydID, string batch)
        {
            return dal.GetCKW(key, fydID, batch);
        }

        /// <summary>
        /// 获取仓库位置
        /// </summary>
        /// <returns></returns>
        public DataSet GetLine_Slab_CK(string key, string type)
        {
            return dal.GetLine_Slab_CK(key, type);
        }

        /// <summary>
        /// 获取仓库位置
        /// </summary>
        /// <param name="key">仓库编码或仓库名称</param>
        /// <param name="fyID">发运明细ID</param>
        /// <returns></returns>
        public DataSet GetCK(string key, string fyID)
        {
            return dal.GetCK(key, fyID);
        }


        /// <summary>
        /// 获取可发仓库线材量
        /// </summary>
        /// <param name="fydID">发运单明细主键</param>
        /// <returns></returns>
        public DataSet GetKFCK(string fydID)
        {

            return dal.GetKFCK(fydID);
        }

        /// <summary>
        /// 线材仓库区域查询
        /// </summary>
        /// <param name="fydID">发运单主键</param>
        /// <param name="ckCode">仓库编码</param>
        /// <returns></returns>
        public DataSet GetKFCK_Area(string fydID, string ckCode)
        {
            return dal.GetKFCK_Area(fydID, ckCode);
        }

        /// <summary>
        /// 获取订单已履行数量
        /// </summary>
        /// <param name="matCode">物料编码</param>
        /// <param name="orderNo">订单号</param>
        /// <param name="flag">钢种类型6钢坯，8线材</param>
        /// <returns></returns>
        public DataRow GetOrderExeNum(string matCode, string orderNo, int flag)
        {
            return dal.GetOrderExeNum(matCode, orderNo, flag);
        }


        #region //发运单头尾材线材引入
        /// <summary>
        /// 发运单头尾材线材自由项引入
        /// </summary>
        /// <param name="matcode"></param>
        /// <param name="stdcode"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public DataSet GetFyd_Roll_Prodcut(string matcode, string stdcode, string area)
        {
            return dal.GetFyd_Roll_Prodcut(matcode, stdcode, area);
        }

        /// <summary>
        /// 发运单头尾材线材自由项引入
        /// </summary>
        /// <param name="matcode"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public DataSet GetFyd_Roll_Prodcut_TWC(string matcode, string area)
        {
            return dal.GetFyd_Roll_Prodcut_TWC(matcode, area);
        }
        #endregion


        #region //客户订单跟踪
        /// <summary>
        /// 订单跟踪
        /// </summary>
        /// <param name="conNo">合同号</param>
        /// <param name="startDate">签单开始时间</param>
        /// <param name="endDate">签单截至时间</param>
        /// <param name="custNo">客户编码</param>
        /// <returns></returns>
        public DataSet GetOrderJL(int pageSize, int pageIndex, string conNo, string startDate, string endDate, string custNo)
        {
            return dal.GetOrderJL(pageSize, pageIndex, conNo, startDate, endDate, custNo);
        }

        /// <summary>
        /// 订单跟踪
        /// </summary>
        /// <param name="conNo">合同号</param>
        /// <param name="startDate">签单开始时间</param>
        /// <param name="endDate">签单截至时间</param>
        /// <param name="custNo">客户编码</param>
        /// <returns></returns>
        public DataSet GetOrderJL(string conNo, string startDate, string endDate, string custNo)
        {
            return dal.GetOrderJL(conNo, startDate, endDate, custNo);
        }
        #endregion

        #region //合同跟踪
        /// <summary>
        /// 合同跟踪
        /// </summary>
        /// <param name="custName">客户名称</param>
        /// <param name="saleEmp">销售员</param>
        /// <param name="conNo">合同号</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns></returns>
        public DataSet GetConTrace(string custName, string saleEmp, string conNo, string startDate, string endDate)
        {
            return dal.GetConTrace(custName, saleEmp, conNo, startDate, endDate);
        }

        /// <summary>
        /// 根据订单号获取线材或钢坯
        /// </summary>
        /// <param name="orderNO"></param>
        /// <returns></returns>
        public DataSet GetRollAndSlab(string orderNO, string flag)
        {
            return dal.GetRollAndSlab(orderNO, flag);
        }
        #endregion

        #region//生成销售订单&日计划

        /// <summary>
        /// 生成销售订单&日计划
        /// </summary>
        /// <param name="empID">操作人ID</param>
        /// <param name="orderList">订单主键ID</param>
        /// <returns></returns>
        public bool CreateSaleOrderDayPlan(string empID, List<string> orderList)
        {
            return dal.CreateSaleOrderDayPlan(empID, orderList);
        }
        #endregion

        #region //获取销售单据号
        /// <summary>
        /// 获取销售单据号
        /// </summary>
        /// <param name="pageSize">显示页数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="custName">客户名称</param>
        /// <param name="conNO">合同号</param>
        /// <param name="empID">业务员</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public DataSet GetSaleCode(string custName, string conNO, string empID, string startTime, string endTime)
        {
            return dal.GetSaleCode(custName, conNO, empID, startTime, endTime);
        }
        #endregion

        #region //获取销售单据号下订单
        public DataSet GetSaleOrder(string saleCode)
        {
            return dal.GetSaleOrder(saleCode);
        }
        #endregion

        #region //根据销售单据号更新执行状态
        public bool UpdateExeStatus(int status, string saleCode)
        {
            return dal.UpdateExeStatus(status, saleCode);
        }
        #endregion

        #region //删除销售订单/日计划
        public bool DelSalePlan(string NCID)
        {
            return dal.DelSalePlan(NCID);
        }

        /// <summary>
        /// 删除日计划
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DelDayPlan(List<Mod_TMP_DAYPLAN> list)
        {
            return dal.DelDayPlan(list);
        }

        /// <summary>
        ///NC销售订单/日计划是否删除
        /// </summary>
        /// <param name="NCID"></param>
        /// <returns></returns>
        public bool DelNCSalePlan(string NCID)
        {
            return dal.DelNCSalePlan(NCID);
        }
        #endregion

        #region //获取原合同剩余总量


        /// <summary>
        /// 获取原合同订单数量
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public string GetOrderWgt(string orderNo)
        {
            return dal.GetOrderWgt(orderNo);
        }

        /// <summary>
        /// 获取原始合同剩余总量
        /// </summary>
        /// <param name="conNo">合同号</param>
        /// <returns></returns>
        public string GetConSumWgt(string conNo)
        {
            return dal.GetConSumWgt(conNo);
        }
        #endregion

        #region //各区域订单提报排产//汇总分析


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists_OrderPlan(string c_order_no)
        {
            return dal.Exists_OrderPlan(c_order_no);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="pc_orderNo">排产订单号</param>
        /// <param name="conNo">原订单合同号</param>
        /// <returns></returns>
        public bool Exists_OrderPlan(string pc_orderNo, string conNo)
        {
            return dal.Exists_OrderPlan(pc_orderNo, conNo);
        }

        /// <summary>
        /// 获取订单排产次数号
        /// </summary>
        /// <param name="orderNo">订单号</param>
        /// <param name="conNo">合同号</param>
        /// <returns></returns>
        public int GetOrderPlanNum(string orderNo, string conNo)
        {
            return dal.GetOrderPlanNum(orderNo, conNo);
        }

        /// <summary>
        /// 各区域订单提报排产//汇总分析
        /// </summary>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matCode">物料编码</param>
        /// <param name="con">合同号</param>
        /// <param name="cust">客户名称</param>
        /// <param name="saleEmp">业务员</param>
        /// <param name="orderType">订单标识：0正常订单，1预测订单</param>
        /// <param name="execStatus">-执行状态: -2各区销售未提交排产,-1销售已提交， 0正常 ，5人为关闭，6生产完成,7库存货</param>
        /// <param name="area">销售区域</param>
        /// <param name="PJ">是否评价Y/N</param>
        /// <param name="startDate">计划日期</param>
        /// <param name="endDate">需求日期</param>
        /// <param name="matName">物料名称</param>
        /// <param name="pack">包装要求</param>
        /// <param name="stdCode">执行标准</param>
        /// <param name="orderStart_DT">订单开始时间</param>
        /// <param name="orderEnd_DT">订单结束时间</param>
        /// <param name="shStart_DT">审核开始时间</param>
        /// <param name="shEnd_DT">审核结束时间</param>
        /// <returns></returns>
        public DataSet GetOrderPlan(string stlGrd, string spec, string matCode, string con, string cust, string saleEmp, string orderType, string execStatus, string area, string startDate, string endDate, string matName, string pack, string stdCode, string orderStart_DT, string orderEnd_DT, string shStart_DT, string shEnd_DT, string orderNo, string PJ)
        {
            return dal.GetOrderPlan(stlGrd, spec, matCode, con, cust, saleEmp, orderType, execStatus, area, startDate, endDate, matName, pack, stdCode, orderStart_DT, orderEnd_DT, shStart_DT, shEnd_DT, orderNo, PJ);
        }
        /// <summary>
        /// 查询当前钢种是否下达排产
        /// </summary>
        /// <param name="matcode"></param>
        /// <returns></returns>
        public DataSet GetOrderPlan(string matcode)
        {
            return dal.GetOrderPlan(matcode);
        }

        /// <summary>
        /// 旬订单提报汇总分析
        /// </summary>
        /// <param name="jh_dt">计划日期</param>
        /// <param name="xq_dt">需求日期</param>
        /// <param name="shkssj">审核开始时间</param>
        /// <param name="shjssj">审核结束时间</param>
        /// <returns></returns>
        public DataSet GetOrderPlanStlGrd(int flag, string jh_dt, string xq_dt)
        {
            return dal.GetOrderPlanStlGrd(flag, jh_dt, xq_dt);
        }
        /// <summary>
        /// 规格
        /// </summary>
        /// <returns></returns>
        public DataSet GetSpec()
        {
            return dal.GetSpec();
        }
        /// <summary>
        /// 订单区域
        /// </summary>
        /// <returns></returns>
        public DataSet GetOrderArea()
        {
            return dal.GetOrderArea();
        }
        /// <summary>
        /// 合同区域
        /// </summary>
        /// <returns></returns>
        public DataSet GetConArea()
        {
            return dal.GetConArea();
        }
        /// <summary>
        /// 线材特殊信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetTS()
        {
            return dal.GetTS();
        }

        /// <summary>
        /// 客户线材区域
        /// </summary>
        /// <param name="custname"></param>
        /// <returns></returns>
        public DataSet GetCustRollArea(string custname)
        {
            return dal.GetCustRollArea(custname);
        }

        /// <summary>
        /// 线材区域
        /// </summary>
        /// <returns></returns>
        public DataSet GetXCAREA()
        {
            return dal.GetXCAREA();
        }
        /// <summary>
        /// 线材库区域
        /// </summary>
        /// <returns></returns>
        public DataSet GetXCAREA(string JUDGE_LEV_ZH)
        {
            return dal.GetXCAREA(JUDGE_LEV_ZH);
        }

        /// <summary>
        ///线材质量-区域
        /// </summary>
        /// <returns></returns>
        public DataSet GetXCAREA_APP(string JUDGE_LEV_ZH)
        {
            return dal.GetXCAREA_APP(JUDGE_LEV_ZH);
        }

        /// <summary>
        /// 线材库质量等级
        /// </summary>
        /// <returns></returns>
        public DataSet GetXC_JUDGE_LEV_ZH(string area)
        {
            return dal.GetXC_JUDGE_LEV_ZH(area);
        }

        /// <summary>
        /// 订单物料名称
        /// </summary>
        /// <returns></returns>
        public DataSet GetOrderMat()
        {
            return dal.GetOrderMat();
        }

        /// <summary>
        /// 订单排产区域设置
        /// </summary>
        /// <param name="list">参数列表：区域，订单主键</param>
        /// <returns></returns>
        public bool UpdateArea(List<string[]> list)
        {
            return dal.UpdateArea(list);
        }

        /// <summary>
        /// 订单排产审核操作
        /// </summary>
        /// <param name="list">参数列表：状态，审核人，计划日期，需求日期，订单主键</param>
        /// <returns></returns>
        public bool UpdateCheck(List<string[]> list)
        {
            return dal.UpdateCheck(list);
        }

        /// <summary>
        /// 提报操作
        /// </summary>
        /// <param name="list">参数列表状态，提报人，订单主键</param>
        /// <returns></returns>
        public bool UpdateSubmission(List<string[]> list)
        {
            return dal.UpdateSubmission(list);
        }

        /// <summary>
        /// 取消提报/取消审核/关闭订单
        /// </summary>
        /// <param name="list">参数列表：状态，订单主键</param>
        /// <returns></returns>
        public bool UpdateCancelSubmission(List<string[]> list)
        {
            return dal.UpdateCancelSubmission(list);
        }


        /// <summary>
        /// 插入订单计划排产操作日志
        /// </summary>
        /// <param name="list">参数：操作具体描述，功能描述(页面标题)，操作人，操作IP地址，订单号，订单表主键</param>
        public void InsertOrderPlanLog(List<string[]> list)
        {
            dal.InsertOrderPlanLog(list);
        }

        #endregion

        #region //GPS钢种设置

        /// <summary>
        /// 获取GPS钢种
        /// </summary>
        /// <param name="stlGrd">钢种</param>
        /// <returns></returns>
        public DataSet GetStl_Gps(string stlGrd)
        {
            return dal.GetStl_Gps(stlGrd);
        }
        #endregion

        #endregion


    }
}

