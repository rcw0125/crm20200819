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
    
    public partial class TMQ_QUA_ITEM
    {
        public string C_ID { get; set; }
        public string C_PARENTID { get; set; }
        public string C_BRAND_NAME { get; set; }
        public string C_SPEC { get; set; }
        public string C_BATCH { get; set; }
        public Nullable<decimal> N_SHIPPEDQTY { get; set; }
        public Nullable<decimal> N_OBJECT_WGT { get; set; }
        public string C_STL_CODE { get; set; }
        public string C_EMP_ID { get; set; }
        public string C_EMP_NAME { get; set; }
        public short N_STATUS { get; set; }
        public Nullable<System.DateTime> C_EMP_DT { get; set; }
        public string C_CRT_ID { get; set; }
        public Nullable<System.DateTime> D_CRT_DT { get; set; }
        public Nullable<System.DateTime> D_PRODUCE_DATE { get; set; }
        public string C_MAT_CODE { get; set; }
    }
}
