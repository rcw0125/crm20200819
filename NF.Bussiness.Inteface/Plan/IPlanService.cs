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
    public interface IPlanService : IBaseService
    {
        /// <summary>
        /// 获取发运方式GPS是否启用
        /// </summary>
        /// <param name="shipvia"></param>
        /// <returns></returns>
        int GetShipviaGps(string shipvia);

        /// <summary>
        /// 获取钢种GPS是否启用
        /// </summary>
        /// <param name="matCode"></param>
        /// <returns></returns>
        int GetMatrlMainGps(string matCode);

        /// <summary>
        /// 获取地区GPS是否启用
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        int GetAreaGps(string area);

        /// <summary>
        /// 获取客户编码GPS是否启用
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        int GetCustFileGps(string no);

        /// <summary>
        /// 合同详情信息列表（分页）
        /// </summary>
        /// <param name="siDto">合同详情实体DTO</param>
        /// <returns></returns>
        PageResult<TMO_ORDER> GetConDetails(TMO_CONDETAILSDTO conDto);

        /// <summary>
        /// 获取发运计划列表
        /// </summary>
        /// <param name="no">订单编号</param>
        /// <returns></returns>
        List<TMP_PLANDTO> GetPlans(string no);

        /// <summary>
        /// 发运计划新增（订单信息转换为计划）
        /// </summary>
        /// <param name="no">订单编号</param>
        /// <param name="baseUser">登陆人信息</param>
        /// <returns></returns>
        TMP_PLANDTO GetPlan(string no, CurrentUser baseUser);

        /// <summary>
        /// 发运计划修改
        /// </summary>
        /// <param name="no">发运计划号</param>
        /// <returns></returns>
        TMP_PLANDTO GetPlan(string no);

        /// <summary>
        /// 发运计划新增
        /// </summary>
        /// <param name="pDto"></param>
        void PlanInsert(TMP_PLANDTO pDto);

        /// <summary>
        /// 发运计划修改
        /// </summary>
        /// <param name="pDto"></param>
        void PlanUpdate(TMP_PLANDTO pDto);

        /// <summary>
        /// 发运计划列表（分页）
        /// </summary>
        /// <param name="siDto">合同详情实体DTO</param>
        /// <returns></returns>
        PageResult<TMP_PLAN> GetPlans(TMP_PLANDTO pDto);


        /// <summary>
        /// 获取发运单列表
        /// </summary>
        /// <returns></returns>
        PageResult<TMD_DISPATCH> GetDispatchs(TMD_DISPATCHDTO dispatchDto);

        /// <summary>
        /// 获取发运单列表
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        List<TMD_DISPATCHDTO> GetDispatchs(string no);

        /// <summary>
        /// 创建发运单明细(线材)
        /// </summary>
        /// <param name="dispatchDto"></param>
        /// <param name="no"></param>
        /// <returns></returns>
        TMD_DISPATCHDTO CreateDispatchDetailsProduct(TMD_DISPATCHDTO dispatchDto, string no);

        /// <summary>
        /// 创建发运单明细(线材修改使用)
        /// </summary>
        /// <param name="dispatchDto"></param>
        /// <param name="no"></param>
        /// <returns></returns>
        TMD_DISPATCHDTO CreateDispatchDetailsProduct(TMD_DISPATCHDTO dispatchDto, string no, int type);

        /// <summary>
        /// 创建补单明细(线材)
        /// </summary>
        /// <param name="dDto">发运单实体DTO</param>
        /// <returns></returns>
        TMD_DISPATCHDTO CreateSupplementProduct(TMD_DISPATCHDTO dispatchDto, string no);

        /// <summary>
        /// 创建发运单明细(钢坯)
        /// </summary>
        /// <param name="dispatchDto">发运单DTO</param>
        /// <returns></returns>
        TMD_DISPATCHDTO CreateDispatchDetailsSlab(TMD_DISPATCHDTO dispatchDto, string no);

        /// <summary>
        /// 创建发运单明细(钢坯修改使用)
        /// </summary>
        /// <param name="dispatchDto"></param>
        /// <param name="no"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        TMD_DISPATCHDTO CreateDispatchDetailsSlab(TMD_DISPATCHDTO dispatchDto, string no, int type);

        /// <summary>
        /// 创建发运单明细(钢坯补单)
        /// </summary>
        /// <param name="dispatchDto"></param>
        /// <param name="no"></param>
        /// <returns></returns>
        TMD_DISPATCHDTO CreateSupplementSlab(TMD_DISPATCHDTO dispatchDto, string no);

        /// <summary>
        /// 创建发运单明细(渣 焦化产品)
        /// </summary>
        /// <param name="dispatchDto">发运单DTO</param>
        /// <param name="no">订单编号</param>
        /// <returns></returns>
        TMD_DISPATCHDTO CreateDispatchDetailsOther(TMD_DISPATCHDTO dispatchDto, string no);

        /// <summary>
        /// 发运单添加
        /// </summary>
        /// <param name="dDto">发运单实体DTO</param>
        void DispatchInsert(TMD_DISPATCHDTO dDto);

        /// <summary>
        /// 发运单修改(获取发运单信息)
        /// </summary>
        /// <param name="id">发运单据号</param>
        /// <returns></returns>
        TMD_DISPATCHDTO GetDispatch(string id);

        /// <summary>
        /// 获取发运单详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<TMD_DISPATCHDETAILSDTO> GetDispatchDetails(string id);

        /// <summary>
        /// 修改发运单
        /// </summary>
        /// <param name="dDto"></param>
        void DispatchUpdate(TMD_DISPATCHDTO dDto);


        /// <summary>
        /// 通过合同详情id获取合同详情信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        List<TMO_CONDETAILSDTO> GetDispatchConDetails(List<string> ids);

        /// <summary>
        /// 修改线材库存状态
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="type">1生效发运单，2撤销发运单</param>
        /// <returns></returns>
        string UpdateTRCStoveStatus(TMD_DISPATCHDTO dto, int type);


        /// <summary>
        /// 修改钢坯库存状态
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="type">1生效发运单，2撤销发运单</param>
        /// <returns></returns>
        string UpdateTSCStoveStatus(TMD_DISPATCHDTO dto, int type);

        /// <summary>
        /// 添加发运单日志
        /// </summary>
        /// <param name="disLog"></param>
        void DispatchLogInsert(TMD_DISPATCH_LOG disLog, TMD_DISPATCHDTO conDto);

        /// <summary>
        /// 获取发运单操作记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<TMD_DISPATCH_LOG> GetDispatchLog(string id);

        /// <summary>
        /// 根据订单获取所有发运单重量
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        Result GetDispathWgt(string no);

        /// <summary>
        /// 删除发运单明细
        /// </summary>
        /// <param name="id"></param>
        void DispatchDeitalDelete(string id);

        /// <summary>
        /// NC发运单是否已存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int NcDisExist(string id);

        /// <summary>
        /// 删除发运单
        /// </summary>
        void DelDispatch(TMD_DISPATCHDTO dto);

        /// <summary>
        /// 导入NC
        /// </summary>
        /// <param name="dDto"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        string DispatchImportNc(TMD_DISPATCHDTO dDto, string flag);

        /// <summary>
        /// 导入物流
        /// </summary>
        /// <param name="dDto"></param>
        /// <returns></returns>
        string DispatchImportLg(TMD_DISPATCHDTO dDto);

        /// <summary>
        /// 获取订单明细
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        TMO_CONDETAILSDTO GetOrderDetails(string orderNo);

    }
}
