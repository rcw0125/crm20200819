//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NF.EF.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TPA_HL_PLAN
    {
        public string C_ID { get; set; }
        public string C_FK { get; set; }
        public string C_STOVE_NO { get; set; }
        public string C_STL_GRD { get; set; }
        public string C_STD_CODE { get; set; }
        public string C_WH_CODE { get; set; }
        public string C_SLAB_TYPE { get; set; }
        public Nullable<System.DateTime> D_START_TIME { get; set; }
        public Nullable<System.DateTime> D_END_TIME { get; set; }
        public Nullable<decimal> N_HL_TIME { get; set; }
        public Nullable<System.DateTime> D_PLAN_DATE { get; set; }
        public string C_HLYQ { get; set; }
        public string C_REMARK { get; set; }
        public short N_STATUS { get; set; }
        public string C_CCM { get; set; }
        public Nullable<int> N_QUA { get; set; }
        public Nullable<int> N_CAP { get; set; }
        public Nullable<int> N_TOTAL_QUA { get; set; }
        public Nullable<System.DateTime> D_START_TIME_SJ { get; set; }
        public Nullable<System.DateTime> D_END_TIME_SJ { get; set; }
        public Nullable<int> N_QUA_SJ { get; set; }
        public string C_WH_CODE_SJ { get; set; }
        public Nullable<System.DateTime> D_OVER_TIME { get; set; }
        public Nullable<int> N_NUM { get; set; }
    }
}
