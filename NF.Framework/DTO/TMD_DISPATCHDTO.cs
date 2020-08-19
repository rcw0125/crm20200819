using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TMD_DISPATCHDTO : BASEDTO
    {
        /// <summary>
        /// 发运单单据号
        /// </summary>
        public string C_ID
        {
            set;
            get;
        }

        /// <summary>
        /// 日计划单据号
        /// </summary>
        public string C_PLAN_ID
        {
            set;
            get;
        }

        /// <summary>
        /// GPS设备号
        /// </summary>
        public string C_GPS_NO
        {
            set;
            get;
        }

        /// <summary>
        /// 订单号
        /// </summary>
        public string C_NO
        {
            set;
            get;
        }

        /// <summary>
        /// 合同号
        /// </summary>
        public string C_CON_NO
        {
            set;
            get;
        }

        /// <summary>
        /// 发运日期
        /// </summary>
        [Required(ErrorMessage = "*")]
        public DateTime? D_DISP_DT
        {
            set;
            get;
        }

        /// <summary>
        /// 发运方式
        /// </summary>
        public string C_SHIPVIA
        {
            set;
            get;
        }

        /// <summary>
        /// 承运商
        /// </summary>
        [Required(ErrorMessage = "*")]
        public string C_COMCAR
        {
            set;
            get;
        }

        ///// <summary>
        ///// 路线
        ///// </summary>
        //[Required(ErrorMessage = "路线不能为空")]
        //public string C_PATH
        //{
        //    set;
        //    get;
        //}

        /// <summary>
        /// 路线描述
        /// </summary>
        public string C_PATH_DESC
        {
            set;
            get;
        }

        /// <summary>
        /// 发运组织
        /// </summary>
        public string C_SEND_DEPT
        {
            set;
            get;
        }

        /// <summary>
        /// 业务部门
        /// </summary>
        ///[Required(ErrorMessage = "业务部门不能为空")]
        public string C_BUSINESS_DEPT
        {
            set;
            get;
        }

        /// <summary>
        /// 业务部门名称
        /// </summary>
        public string C_BUSINESS_DEPT_NAME
        {
            set;
            get;
        }

        /// <summary>
        /// 业务员
        /// </summary>
        public string C_BUSINESS_ID
        {
            set;
            get;
        }

        /// <summary>
        /// 业务员名称
        /// </summary>
        public string C_BUSINESS_NAME
        {
            set;
            get;
        }

        /// <summary>
        /// 是否线材销售
        /// </summary>
        public string C_IS_WIRESALE { get; set; }

        /// <summary>
        /// 是否已导出
        /// </summary>
        public decimal? N_IS_EXPORT
        {
            set;
            get;
        }

        /// <summary>
        /// 车牌号
        /// </summary>
        [Required(ErrorMessage = "*")]
        public string C_LIC_PLA_NO
        {
            set;
            get;
        }

        /// <summary>
        /// 到站
        /// </summary>
        [Required(ErrorMessage = "*")]
        public string C_ATSTATION
        {
            set;
            get;
        }

        /// <summary>
        /// 发运单审批日期
        /// </summary>
        public DateTime? D_APPROVE_DT
        {
            set;
            get;
        }

        /// <summary>
        /// 发运单制单日期
        /// </summary>
        public DateTime? D_CREATE_DT
        {
            set;
            get;
        }

        /// <summary>
        /// 审批人
        /// </summary>
        public string C_APPROVE_ID
        {
            set;
            get;
        }

        /// <summary>
        /// 审批人名称
        /// </summary>
        public string C_APPROVE_NAME
        {
            set;
            get;
        }

        /// <summary>
        /// 制单人
        /// </summary>
        public string C_CREATE_ID
        {
            set;
            get;
        }

        /// <summary>
        /// 制单人名称
        /// </summary>
        public string C_CREATE_NAME
        {
            set;
            get;
        }

        /// <summary>
        /// 发运总量
        /// </summary>
        public decimal? DispatchSumWgt { get; set; }


        /// <summary>
        /// 发运单状态 0自由状态 1金额不足 2已导入NC 3已导入条码 4已导入物流 5失效 6删除,7 已做实绩，8线材实绩已导入NC，9钢坯实绩已导入NC
        /// </summary>
        public string C_STATUS { get; set; }


        /// <summary>
        /// 发运单列表
        /// </summary>
        public List<TMD_DISPATCHDTO> Dispatchs { get; set; }

        /// <summary>
        /// 订单列表
        /// </summary>
        public List<TMO_CONDETAILSDTO> ConDetails { get; set; }

        /// <summary>
        /// 选中订单
        /// </summary>
        public List<TMO_CONDETAILSDTO> PitchConDetails { get; set; }

        /// <summary>
        /// 发运单明细
        /// </summary>
        public List<TMD_DISPATCHDETAILSDTO> DispatchDetails { get; set; }

        /// <summary>
        /// 发运单明细(汇总数据)
        /// </summary>
        public List<DispatchDetailsDisplayDto> Details { get; set; }

        /// <summary>
        /// 补单
        /// </summary>
        public List<TMD_DISPATCHDETAILSDTO> SupplementDispatchDetails { get; set; }

        /// <summary>
        /// 补单明细(汇总数据)
        /// </summary>
        public List<DispatchDetailsDisplayDto> SupplementDetails { get; set; }

        /// <summary>
        /// 线材货物库位信息
        /// </summary>
        public List<TRC_ROLL_PRODCUTDTO> Rolls { get; set; }

        /// <summary>
        /// 钢坯货物库位信息
        /// </summary>
        public List<TSC_SLAB_MAINDTO> Slabs { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public string C_STOVEID { get; set; }

        /// <summary>
        /// 订单类型(8线材,6钢坯)
        /// </summary>
        public string ConDetType { get; set; }

        /// <summary>
        /// 总件数
        /// </summary>
        public decimal? Number { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        public decimal? Wgt { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public string C_GUID { get; set; }

        /// <summary>
        /// 是否线材销售
        /// </summary>
        public string C_IS_WIRESALE_ID { get; set; }

        public string C_REMARK { get; set; }

        public string C_REMARK2 { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime? D_FAILURE
        {
            set;
            get;
        }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        /// <summary>
        /// 审核状态 1审核
        /// </summary>
        public string C_EXTEND1 { get; set; }
        public string C_EXTEND2 { get; set; }
        public string C_EXTEND3 { get; set; }
        public string C_EXTEND4 { get; set; }
        public string C_EXTEND5 { get; set; }

        public TMD_DISPATCHDTO()
        {
            DispatchDetails = new List<TMD_DISPATCHDETAILSDTO>();
            Details = new List<DispatchDetailsDisplayDto>();
            SupplementDetails = new List<DispatchDetailsDisplayDto>();
        }

    }
}
