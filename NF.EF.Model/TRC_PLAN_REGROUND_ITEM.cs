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
    
    public partial class TRC_PLAN_REGROUND_ITEM
    {
        public string C_ID { get; set; }
        public string C_PLAN_REGROUND_ID { get; set; }
        public string C_SLAB_MAIN_ID { get; set; }
        public string C_REMARK { get; set; }
        public Nullable<short> N_STEP { get; set; }
        public Nullable<short> N_TOTALSTEP { get; set; }
        public string N_STEPNAME { get; set; }
        public short N_STATUS { get; set; }
        public string C_EMP_ID { get; set; }
        public System.DateTime D_MOD_DT { get; set; }
        public string C_STA_ID { get; set; }
    }
}