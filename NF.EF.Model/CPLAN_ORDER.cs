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
    
    public partial class CPLAN_ORDER
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
        public Nullable<int> LENGTH { get; set; }
        public Nullable<int> WIDTH { get; set; }
        public Nullable<int> THICKNESS { get; set; }
        public string STEELGRADE { get; set; }
        public string UNIT { get; set; }
        public string ASSIST_UNIT { get; set; }
        public Nullable<decimal> WEIGHT { get; set; }
        public Nullable<decimal> ASSISI_WEIGHT { get; set; }
        public Nullable<System.DateTime> PLANREC_DATE { get; set; }
        public Nullable<System.DateTime> REQUEST_DATE { get; set; }
        public string CORP { get; set; }
        public string FACTORY { get; set; }
        public string WORK_CENTER { get; set; }
        public string CLIENT { get; set; }
        public string TECH_REQUEST { get; set; }
        public string INSIDE_NOTE { get; set; }
        public string IMM_FLAG { get; set; }
        public string CASTERID { get; set; }
        public Nullable<short> NEW_BOF_FLAG { get; set; }
        public string PROTOCOL { get; set; }
        public string PRODUCESTD { get; set; }
        public string PK_POID { get; set; }
        public Nullable<decimal> ACTWEIGHT { get; set; }
        public Nullable<decimal> SPAREWEIGHT { get; set; }
        public string MATERIALCODE { get; set; }
        public string MATERIALCODE_ID { get; set; }
        public string PRODUCT_ROUTE { get; set; }
        public string OTHER_TECH_REQUEST { get; set; }
    }
}
