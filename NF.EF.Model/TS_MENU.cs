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
    
    public partial class TS_MENU
    {
        public string C_ID { get; set; }
        public string C_PARENT_ID { get; set; }
        public string C_NAME { get; set; }
        public string C_DESC { get; set; }
        public string C_URL { get; set; }
        public string N_SOURCEPATH { get; set; }
        public Nullable<short> N_STATUS { get; set; }
        public Nullable<int> N_MENULEVEL { get; set; }
        public string C_ICON { get; set; }
        public Nullable<int> N_SORT { get; set; }
        public string C_EMP_ID { get; set; }
        public string C_EMP_NAME { get; set; }
        public Nullable<System.DateTime> D_MOD_DT { get; set; }
        public Nullable<short> N_TYPE { get; set; }
        public Nullable<short> N_ORDER { get; set; }
    }
}
