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
    
    public partial class CPLAN_CASTING
    {
        public string GUID { get; set; }
        public string NAME { get; set; }
        public string PLANID { get; set; }
        public string CONTRACTID { get; set; }
        public Nullable<int> STATUS { get; set; }
        public string PLANDEPT { get; set; }
        public string EXECUTEDEPT { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
        public Nullable<System.DateTime> PLANEXECUTEDATE { get; set; }
        public Nullable<System.DateTime> ACTUALEXECUTEDATE { get; set; }
        public string PLANNER { get; set; }
        public string CASTERID { get; set; }
        public Nullable<int> LENGTH { get; set; }
        public Nullable<int> WIDTH { get; set; }
        public Nullable<int> THICKNESS { get; set; }
        public string PRE_STEELGRADEINDEX { get; set; }
        public string PRE_STEELGRADE { get; set; }
        public string REFINE_TYPE { get; set; }
        public string PRE_LOTNO { get; set; }
        public string PREHEATID { get; set; }
        public Nullable<decimal> AIM_TAPPED_WEIGHT { get; set; }
        public Nullable<int> PROC_SEQ { get; set; }
        public string PLAN_ORD_ID { get; set; }
        public Nullable<int> BLOOM_COUNT { get; set; }
        public Nullable<System.DateTime> AIM_TIME_CASTINGSTART { get; set; }
        public Nullable<short> NEW_BOF_FLAG { get; set; }
        public string BOFID { get; set; }
        public string LFID { get; set; }
        public string RHID { get; set; }
        public Nullable<decimal> ACTWEIGHT { get; set; }
        public string AODID { get; set; }
        public string MATERIALCODE { get; set; }
    }
}