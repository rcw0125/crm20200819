using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// 文件事务信息表(数据
    /// </summary>
    public partial class Bll_TMF_FILEINFO
    {
        private readonly Dal_TMF_FILEINFO dal = new Dal_TMF_FILEINFO();
        public Bll_TMF_FILEINFO()
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
        public bool Add(Mod_TMF_FILEINFO model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMF_FILEINFO model)
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
        public Mod_TMF_FILEINFO GetModel(string C_ID)
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
        public List<Mod_TMF_FILEINFO> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMF_FILEINFO> DataTableToList(DataTable dt)
        {
            List<Mod_TMF_FILEINFO> modelList = new List<Mod_TMF_FILEINFO>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMF_FILEINFO model;
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
        /// 最后批准步骤操作
        /// </summary>
        /// <param name="mod">条件参数</param>
        /// <returns></returns>
        public bool UpdateLastStep(Mod_ApproveCon mod)
        {
            return dal.UpdateLastStep(mod);
        }

        /// <summary>
        /// 质量异议-最后批准步骤操作
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool UpdateLastStep_QUA(Mod_ApproveCon mod)
        {
            return dal.UpdateLastStep_QUA(mod);
        }

        /// <summary>
        /// 线材资源-最后批准步骤操作
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool UpdateLastStep_ROLL(Mod_ApproveCon mod)
        {
            return dal.UpdateLastStep_ROLL(mod);
        }


        /// <summary>
        /// 驳回最后步骤操作
        /// </summary>
        /// <param name="mod">条件参数</param>
        /// <returns></returns>
        public bool UpdateBackLastSetp(Mod_ApproveCon mod)
        {
            return dal.UpdateBackLastSetp(mod);
        }

        /// <summary>
        /// 质量异议-驳回最后步骤操作
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool UpdateBackLastSetp_QUA(Mod_ApproveCon mod)
        {
            return dal.UpdateBackLastSetp_QUA(mod);
        }

        /// <summary>
        /// 线材资源-驳回最后步骤操作
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool UpdateBackLastSetp_ROLL(Mod_ApproveCon mod)
        {
            return dal.UpdateBackLastSetp_ROLL(mod);
        }

        /// <summary>
        /// 更新步骤
        /// </summary>
        /// <param name="step">步骤ID</param>
        /// <param name="ID">文件ID</param>
        /// <returns></returns>
        public bool UpdateStep(string step, string ID)
        {
            return dal.UpdateStep(step, ID);
        }

        /// <summary>
        /// 更新步骤/状态
        /// </summary>
        /// <param name="step">步骤</param>
        /// <param name="status">状态</param>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        public bool UpdateStepStatus(string step, int status, string ID)
        {
            return dal.UpdateStepStatus(step, status, ID);
        }

        /// <summary>
        /// 获取文件事务列表
        /// </summary>
        /// <param name="flowID">流程ID</param>
        /// <param name="type">类型:0合同，1质量</param>
        /// <param name="taskID">任务ID</param>
        /// <returns></returns>
        public DataSet GetList(string flowID, int type, string taskID)
        {
            return dal.GetList(flowID, type, taskID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string flowID, int type, string taskID, string empID)
        {
            return dal.GetList(flowID, type, taskID, empID);
        }

        /// <summary>
        /// 获取文件事务处理
        /// </summary>
        /// <param name="title">文件名称</param>
        /// <param name="status">状态：0待办，1已办</param>
        /// <param name="flowID">流程ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="empID">审批人</param>
        /// <returns></returns>
        public DataSet GetFileTran(string title, string status, string flowID, string startTime, string endTime, string empID)
        {
            if (status == "0")//待办
            {
                return dal.GetUntrWork(flowID, empID, title, startTime, endTime);
            }
            else
            {
                return dal.GetFinishWork(flowID, empID, title, startTime, endTime);
            }
        }


        /// <summary>
        ///  获得未处理事务
        /// </summary>
        /// <param name="flowID">流程ID</param>
        /// <param name="empID">审批人</param>
        /// <param name="title">文件名称</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        public DataSet GetUntrWork(string flowID, string empID, string title, string start, string end)
        {
            return dal.GetUntrWork(flowID, empID, title, start, end);
        }

        /// <summary>
        /// 获得已处理的事务
        /// </summary>
        /// <param name="flowID">流程ID</param>
        /// <param name="empID">审批人</param>
        /// <param name="title">文件名称</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        public DataSet GetFinishWork(string flowID, string empID, string title, string start, string end)
        {
            return dal.GetFinishWork(flowID, empID, title, start, end);
        }

        #endregion  ExtensionMethod
    }
}

