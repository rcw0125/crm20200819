using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NF.EF.Model;
using NF.Framework.DTO;
using NF.Framework;
using System.Web.Mvc;

namespace NF.Bussiness.Interface
{
    public interface IQualityService : IBaseService
    {
        /// <summary>
        ///  获取质量问题反馈列表（分页）
        /// </summary>
        /// <param name="qmDto">质量问题反馈实体DTO</param>
        /// <param name="empID">登录人ID</param>
        /// <returns></returns>
        PageResult<TMQ_QUALITY_MAIN> GetQualitys(TMQ_QUALITY_MAINDTO qmDto, string empID);

        /// <summary>
        ///  获取质量问题反馈列表（分页）
        /// </summary>
        /// <param name="qmDto">质量问题反馈实体DTO</param>
        /// <returns></returns>
        PageResult<TMQ_QUALITY_MAIN> GetQualitys(TMQ_QUALITY_MAINDTO qmDto, int type);

        /// <summary>
        /// 质量异议新增
        /// </summary>
        /// <param name="qmDto"></param>
        TMQ_QUALITY_MAIN QualitysInser(TMQ_QUALITY_MAINDTO qmDto);

        /// <summary>
        /// 质量异议修改
        /// </summary>
        /// <param name="qmDto"></param>
        void QualitysUpdate(TMQ_QUALITY_MAINDTO qmDto);

        /// <summary>
        /// 质量异议修改
        /// </summary>
        /// <param name="qmDto"></param>
        void QualitysUpdate(TMQ_QUALITY_MAIN qmDto);

        /// <summary>
        /// 质量异议详情新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        TMQ_QUALITY_MAIN QualitysInser(TMQ_QUALITY_MAIN dto);

        /// <summary>
        /// 质量异议详情新增
        /// </summary>
        /// <param name="qsgDto"></param>
        void QualitysDetailInser(List<TMQ_QUALITY_STL_GRDDTO> qsgDto);

        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="id"></param>
        void QualitysDetailDelete(string id);

        /// <summary>
        /// 获取质量问题反馈
        /// </summary>
        /// <returns></returns>
        List<TMQ_QUALITY_STL_GRDDTO> GetQualityDetail(string id);

        /// <summary>
        /// 获取地区名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetAreaName(string id);

        /// <summary>
        /// 验证是否重复
        /// </summary>
        /// <param name="qfDto"></param>
        /// <returns></returns>
        bool ValidateIsRepeat(TMQ_QUALITY_FILE qfDto);

        /// <summary>
        /// 获取审批流程
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> GetFlowInfo();

        /// <summary>
        /// 获取流程步骤
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TMB_FLOWSTEP GetFlowStep(string id);

        /// <summary>
        /// 新增流程处理
        /// </summary>
        /// <param name="fileDto"></param>
        TMF_FILEINFO FileInfoInsert(TMF_FILEINFODTO fileDto);

        /// <summary>
        /// 获取质量反馈信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TMQ_QUALITY_MAINDTO GetQuality(string id);

        /// <summary>
        /// 获取质量反馈信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TMQ_QUALITY_MAIN GetQualityMain(string id);


        /// <summary>
        /// 获取质量反馈附件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TMQ_QUALITY_FILE GetQuqlityFile(string id);

        /// <summary>
        /// 获取质量反馈附件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<TMQ_QUALITY_FILE> GetQuqlityFiles(string id);

        /// <summary>
        ///  根据批号获取线材组批信息
        /// </summary>
        /// <param name="batchID"></param>
        /// <returns></returns>
        List<TRC_ROLL_PRODCUT> GetRollProdcut(string batchID, string stove);

        /// <summary>
        /// 根据批号获取钢坯组批信息
        /// </summary>
        /// <param name="batchID"></param>
        /// <returns></returns>
        List<TSC_SLAB_MAIN> GetSlabMain(string batchID, string stove);

    }
}
