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
    
    public partial class TQB_STD_CFXN
    {
        public string C_ID { get; set; }
        public string C_STD_MAIN_ID { get; set; }
        public string C_CHARACTER_ID { get; set; }
        public string C_TARGET_MIN { get; set; }
        public string C_TARGET_INTERVAL { get; set; }
        public string C_TARGET_MAX { get; set; }
        public string C_PREWARNING_VALUE { get; set; }
        public string C_TYPE { get; set; }
        public string C_IS_DECIDE { get; set; }
        public string C_IS_PRINT { get; set; }
        public Nullable<short> N_PRINT_ORDER { get; set; }
        public Nullable<decimal> N_SPEC_MIN { get; set; }
        public string C_SPEC_INTERVAL { get; set; }
        public Nullable<decimal> N_SPEC_MAX { get; set; }
        public string C_FORMULA { get; set; }
        public string C_UNIT { get; set; }
        public Nullable<short> N_DIGIT { get; set; }
        public string C_QUANTITATIVE { get; set; }
        public string C_TEST_TEM { get; set; }
        public string C_TEST_CONDITION { get; set; }
        public short N_STATUS { get; set; }
        public string C_REMARK { get; set; }
        public string C_EMP_ID { get; set; }
        public System.DateTime D_MOD_DT { get; set; }
        public string C_ITEM_NAME { get; set; }
    
        public virtual TQB_CHARACTER TQB_CHARACTER { get; set; }
    }
}