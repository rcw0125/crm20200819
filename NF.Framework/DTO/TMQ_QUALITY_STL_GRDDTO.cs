using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TMQ_QUALITY_STL_GRDDTO : BASEDTO
    {
        /// <summary>
		/// 
		/// </summary>
		public string C_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 质量异议主表ID
        /// </summary>
        public string C_QUALITY_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 物料大类
        /// </summary>
        public string C_MAT_TYPE
        {
            set;
            get;
        }
        /// <summary>
        /// 物料次类
        /// </summary>
        public string C_MAT_TYPE_N
        {
            set;
            get;
        }

        /// <summary>
        /// 钢种
        /// </summary>
        [Required(ErrorMessage = "钢种不能为空。")]
        public string C_STL_GRD
        {
            set;
            get;
        }


        /// <summary>
        ///规格
        /// </summary>
        [Required(ErrorMessage = "规格不能为空。")]
        public string C_SPEC
        {
            set;
            get;
        }

        /// <summary>
        ///批号
        /// </summary>
        public string C_BATCH_NO
        {
            set;
            get;
        }

        /// <summary>
        ///炉号
        /// </summary>
        public string C_STOVE
        {
            set;
            get;
        }

        /// <summary>
        ///执行标准
        /// </summary>
        public string C_STD_CODE
        {
            set;
            get;
        }

        /// <summary>
        ///发货数量
        /// </summary>
        public decimal? N_SHIP_WGT
        {
            set;
            get;
        }

        /// <summary>
        ///异议数量
        /// </summary>

        public decimal? N_OBJEC_WGT
        {
            set;
            get;
        }


        /// <summary>
        ///数量
        /// </summary>
        public decimal? N_WGT
        {
            set;
            get;
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_REMARK
        {
            set;
            get;
        }
        /// <summary>
        /// 状态：-1未提交,0待处理,1处理中,2已完成
        /// </summary>
        public decimal? N_STATUS
        {
            set;
            get;
        }
        /// <summary>
        /// 标识：0 质量异议，1客户信息反馈
        /// </summary>
        public decimal? N_FLAG
        {
            set;
            get;
        }

        /// <summary>
        /// 订单类型
        /// </summary>
        public decimal? N_ORDERTYPE { get; set; }

    }
}
