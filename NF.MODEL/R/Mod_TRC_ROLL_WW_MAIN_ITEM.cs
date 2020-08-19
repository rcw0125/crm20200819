using System;
namespace NF.MODEL
{
    /// <summary>
    /// 外委组批计划子项
    /// </summary>
    [Serializable]
    public partial class TRC_ROLL_WW_MAIN_ITEM
    {
        public TRC_ROLL_WW_MAIN_ITEM()
        { }

        public string C_ID { get; set; }

        /// <summary>
        /// 组批计划ID
        /// </summary>
        public string C_ROLL_WW_MAIN_ID { get; set; }

        /// <summary>
        /// 线材ID
        /// </summary>
        public string C_SLAB_MAIN_ID { get; set; }

        /// <summary>
        /// 线材重量
        /// </summary>
        public decimal N_WGT { get; set; }

    }
}

