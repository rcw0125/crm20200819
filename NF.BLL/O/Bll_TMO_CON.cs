using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;

namespace NF.BLL
{
    /// <summary>
    /// 合同表
    /// </summary>
    public partial class Bll_TMO_CON
    {
        private readonly Dal_TMO_CON dal = new Dal_TMO_CON();
        public Bll_TMO_CON()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_CON_NO)
        {
            return dal.Exists(C_CON_NO);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMO_CON model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新审批人
        /// </summary>
        /// <param name="conNO">合同号</param>
        /// <param name="empID">审批人</param>
        /// <param name="time">审批时间</param>
        /// <returns></returns>
        public bool UpdateCheckEmp(string conNO, string empID, DateTime time)
        {
            return dal.UpdateCheckEmp(conNO, empID, time);
        }


        /// <summary>
        /// 更新合同状态
        /// </summary>
        /// <param name="status">合同状态：-1未提交，0待审，1审核中，2生效，3撤回，4冻结</param>
        /// <param name="conNO">合同号</param>
        /// <returns></returns>
        public bool UpdateConStatus(int status, string conNO)
        {
            return dal.UpdateConStatus(status, conNO);
        }
        /// <summary>
        /// 更新合同状态/流程
        /// </summary>
        /// <param name="status">合同状态：-1未提交，0待审，1审核中，2生效，3撤回，4冻结</param>
        /// <param name="conNO">合同号</param>
        /// <param name="flowID">流程</param>
        /// <returns></returns>
        public bool UpdateConStatus(int status, string conNO, string flowID)
        {
            return dal.UpdateConStatus(status, conNO, flowID);
        }

        /// <summary>
        /// 更新发送NC状态
        /// </summary>
        /// <param name="C_NC_STATE">状态</param>
        /// <param name="conNO">合同号</param>
        /// <returns></returns>
        public bool UpdateNC(string C_NC_STATE, string conNO)
        {
            return dal.UpdateNC(C_NC_STATE, conNO);
        }

        /// <summary>
        /// 合同变更
        /// </summary>
        /// <param name="status">合同状态：-1未提交，0待审，1审核中，2生效，3变更, 4 审核通过,5冻结,6终止 </param>
        /// <param name="conNO">合同号</param>
        /// <param name="empID">操作人</param>
        /// <returns></returns>
        public bool AlterationCon(int status, string conNO, string empID)
        {
            return dal.AlterationCon(status, conNO, empID);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMO_CON model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string C_CON_NO)
        {

            return dal.Delete(C_CON_NO);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_CON_NOlist)
        {
            return dal.DeleteList(C_CON_NOlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMO_CON GetModel(string C_CON_NO)
        {

            return dal.GetModel(C_CON_NO);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetConList(string C_EMP_ID)
        {
            return dal.GetConList(C_EMP_ID);
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
        public List<Mod_TMO_CON> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMO_CON> DataTableToList(DataTable dt)
        {
            List<Mod_TMO_CON> modelList = new List<Mod_TMO_CON>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMO_CON model;
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
        ///  获取记录总数
        /// </summary>
        /// <param name="con_no">合同号</param>
        /// <param name="con_name">合同名称</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="type">合同类型</param>
        /// <param name="state">合同状态</param>
        /// <returns></returns>
        public int GetRecordCount2(string con_no, string con_name, string start, string end, string type, string state, string custname)
        {
            return dal.GetRecordCount2(con_no, con_name, start, end, type, state, custname);
        }


        /// <summary>
        ///  获取记录总数
        /// </summary>
        /// <param name="con_no">合同号</param>
        /// <param name="con_name">合同名称</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="emp_id">用户ID</param>
        /// <param name="type">合同类型</param>
        /// <param name="state">合同状态</param>
        /// <returns></returns>
        public int GetRecordCount(string con_no, string con_name, string start, string end, string emp_id, string type, string state)
        {
            return dal.GetRecordCount(con_no, con_name, start, end, emp_id, type, state);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage3(string con_no, string con_name, string start, string end, string type, string state, string custname, string custcode)
        {
            return dal.GetListByPage3(con_no, con_name, start, end, type, state, custname, custcode);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="pageSize">页数</param>
        /// <param name="startIndex">起始页</param>
        /// <param name="con_no">合同号</param>
        /// <param name="con_name">合同名称</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>

        /// <returns></returns>
        public DataSet GetListByPage2(int pageSize, int startIndex, string con_no, string con_name, string start, string end, string type, string state, string custname)
        {
            return dal.GetListByPage2(pageSize, startIndex, con_no, con_name, start, end, type, state, custname);
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="pageSize">页数</param>
        /// <param name="startIndex">起始页</param>
        /// <param name="con_no">合同号</param>
        /// <param name="con_name">合同名称</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="emp_id">用户ID</param>
        /// <param name="type">合同类型</param>
        /// <param name="state">合同状态</param>
        /// <returns></returns>
        public DataSet GetListByPage(int pageSize, int startIndex, string con_no, string con_name, string start, string end, string emp_id, string type, string state)
        {
            return dal.GetListByPage(pageSize, startIndex, con_no, con_name, start, end, emp_id, type, state);
        }

        /// <summary>
        /// 获取客户原始合同列表
        /// </summary>
        /// <param name="con_no">合同号</param>
        /// <param name="con_name">合同名称</param>
        /// <param name="start">签署开始时间</param>
        /// <param name="end">签署结束时间</param>
        /// <param name="emp_id">操作人</param>
        /// <param name="type">合同类型</param>
        /// <param name="state">合同状态</param>
        /// <returns></returns>
        public DataSet GetConList(string con_no, string con_name, string start, string end, string emp_id, string type, string state)
        {
            return dal.GetConList(con_no, con_name, start, end, emp_id, type, state);
        }
        /// <summary>
        /// 获取客户原始合同变更记录
        /// </summary>
        /// <param name="conNO">合同号</param>
        /// <returns></returns>
        public DataSet GetConListSub(string conNO)
        {
            return dal.GetConListSub(conNO);
        }


        #endregion  BasicMethod

        #region //自定义方法
        /// <summary>
        /// 插入合同与合同明细数据
        /// </summary>
        /// <param name="modCon"></param>
        /// <param name="orderList"></param>
        /// <returns></returns>
        public bool InsertConOrder(Mod_TMO_CON modCon, List<Mod_TMO_ORDER> orderList)
        {
            return dal.InsertConOrder(modCon, orderList);
        }

        /// <summary>
        /// 更新合同与合同明细数据
        /// </summary>
        /// <param name="modCon"></param>
        /// <param name="orderList"></param>
        /// <returns></returns>
        public bool UpdateConOrder(Mod_TMO_CON modCon, List<Mod_TMO_ORDER> orderList)
        {
            return dal.UpdateConOrder(modCon, orderList);
        }

        /// <summary>
        /// 删除订单&质量
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public bool DelConOrder(string orderID)
        {
            return dal.DelConOrder(orderID);
        }

        /// <summary>
        /// 根据订单号删除
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public bool DelOrderNo(string orderNo)
        {
            return dal.DelOrderNo(orderNo);
        }

        /// <summary>
        /// 插入订单
        /// </summary>
        /// <param name="orderList"></param>
        /// <returns></returns>
        public bool InsertFirstOrder(List<Mod_TMO_ORDER> orderList)
        {
            return dal.InsertFirstOrder(orderList);
        }

        /// <summary>
        /// 插入库存超订单
        /// </summary>
        /// <param name="orderList"></param>
        /// <returns></returns>
        public bool InsertKCFirstOrder(List<Mod_TMO_ORDER> orderList)
        {
            return dal.InsertKCFirstOrder(orderList);
        }

        /// <summary>
        /// 预测订单排产
        /// </summary>
        /// <param name="orderList"></param>
        /// <returns></returns>
        public bool InsertNeedOrder(List<Mod_TMO_ORDER> orderList)
        {
            return dal.InsertNeedOrder(orderList);
        }

        /// <summary>
        /// 获取合同订单已下发排产量
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public string GetOrderPCWGT(string orderNO)
        {
            return dal.GetOrderPCWGT(orderNO);
        }

        /// <summary>
        /// 合同提交审批
        /// </summary>
        /// <param name="modFile">文件</param>
        /// <param name="modNextEmp">步骤操作人</param>
        /// <returns></returns>
        public bool ApproveCon(Mod_TMF_FILEINFO modFile, Mod_TMB_FILE_NEXT_EMP modNextEmp)
        {
            return dal.ApproveCon(modFile, modNextEmp);
        }

        /// <summary>
        /// 修改变更合同制单人/修改人/录入原始合同号
        /// </summary>
        /// <param name="conNo">变更新合同号</param>
        /// <param name="y_conNO">原始合同号</param>
        /// <param name="empid">操作人</param>
        /// <returns></returns>
        public bool UpdateEditEmp(string conNo, string y_conNo, string empid)
        {
            return dal.UpdateEditEmp(conNo, y_conNo, empid);
        }


        /// <summary>
        /// 更新合同状态
        /// </summary>
        /// <param name="status">合同状态：-1未提交，0待审，1审核中，2生效，3变更, 4 审核通过,5冻结,6终止 </param>
        /// <param name="conNO">合同号</param>
        /// <param name="empid">操作人ID</param>
        /// <returns></returns>
        public bool UpdateStatus(int status, string conNO, string empid)
        {
            return dal.UpdateStatus(status, conNO, empid);
        }

        /// <summary>
        /// 冻结合同状态
        /// </summary>
        /// <param name="status">合同状态：-1未提交，0待审，1审核中，2生效，3变更, 4 审核通过,5冻结,6终止</param>
        /// <param name="conNO">合同号</param>
        /// <returns></returns>
        public bool UpdateFreezeStatus(int status, string conNO, string empid)
        {
            return dal.UpdateFreezeStatus(status, conNO, empid);
        }

        /// <summary>
        /// 解冻合同状态
        /// </summary>
        /// <param name="conNO">合同号</param>
        /// <returns></returns>
        public bool UpdateUnfreezeStatus(string conNO)
        {
            return dal.UpdateUnfreezeStatus(conNO);
        }

        /// <summary>
        /// 获取销售合同发送NC状态
        /// </summary>
        /// <param name="conNo"></param>
        /// <returns></returns>
        public string GetSaleCon(string conNo)
        {
            return dal.GetSaleCon(conNo);
        }

        #endregion


        #region //操作日志

        /// <summary>
        /// 合同操作日志
        /// </summary>
        /// <param name="con">合同号</param>
        /// <param name="empID">操作人ID</param>
        /// <param name="empName">操作人姓名</param>
        /// <returns></returns>
        public bool InsertConOrderLog(string con, string empID, string empName)
        {
            return dal.InsertConOrderLog(con, empID, empName);
        }
        #endregion

        #region //客户合同终止确认

        /// <summary>
        /// 获取客户合同终止确认数据列表
        /// </summary>
        /// <param name="custNo"></param>
        /// <returns></returns>
        public DataSet GetCustCon_End_List(string conno, string custNo, string flag, string kssj, string jssj)
        {
            return dal.GetCustCon_End_List(conno, custNo, flag, kssj, jssj);
        }

        /// <summary>
        /// 获取客户合同终止确认数据列表
        /// </summary>
        /// <param name="custNo"></param>
        /// <returns></returns>
        public DataSet GetCustCon_End_List(string C_ID)
        {
            return dal.GetCustCon_End_List(C_ID);
        }

        /// <summary>
        /// 插入客户合同终止信息
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool InsertCustCon_End(Mod_TMO_CON_END mod)
        {
            return dal.InsertCustCon_End(mod);
        }

        /// <summary>
        /// 批准合同终止通知
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool CheckCustCon_End(string id, string empID)
        {
            return dal.CheckCustCon_End(id, empID);
        }

        /// <summary>
        /// 修改客户合同终止信息
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool UpdateCustCon_End(string id, string empID)
        {
            return dal.UpdateCustCon_End(id, empID);
        }
        #endregion

    }
}

