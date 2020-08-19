using NF.EF.Model;
using NF.Framework;
using NF.Framework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Bussiness.Interface
{
    public interface IWorkFlowService : IBaseService
    {
        /// <summary>
        /// 流程信息列表
        /// </summary>
        /// <param name="siDto">流程信息实体DTO</param>
        /// <returns></returns>
        PageResult<TMB_FLOWINFO> FlowInfos(TMB_FLOWINFODTO fiDto);

        /// <summary>
        /// 流程信息新增
        /// </summary>
        /// <param name="fiDto">流程信息实体DTO</param>
        void FlowInfoInsert(TMB_FLOWINFODTO fiDto);

        /// <summary>
        /// 验证流程信息是否重复
        /// </summary>
        /// <param name="fiDto">流程信息实体DTO</param>
        /// <returns></returns>
        bool ValidateIsRepeat(TMB_FLOWINFODTO fiDto);

        /// <summary>
        ///  验证流程信息是否重复
        /// </summary>
        /// <param name="fiDto">流程信息实体DTO</param>
        /// <param name="type">操作方式1修改 0新增</param>
        /// <returns></returns>
        bool ValidateIsRepeat(TMB_FLOWINFODTO fiDto, int type);

        /// <summary>
        /// 获取流程信息
        /// </summary>
        /// <param name="id">流程ID</param>
        /// <returns></returns>
        TMB_FLOWINFODTO GetFlowInfo(string id);

        /// <summary>
        /// 流程信息修改
        /// </summary>
        /// <param name="fiDto">流程信息实体DTO</param>
        void FlowInfoUpdate(TMB_FLOWINFODTO fiDto);

        /// <summary>
        /// 流程信息删除
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="user"></param>
        void FlowInfoDel(string ids, CurrentUser user);

        /// <summary>
        /// 角色生成步骤信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        List<TMB_STEPINFODTO> GetStepInfos();

    }
}
