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
    
    public partial class TQB_CHARACTER
    {
        public TQB_CHARACTER()
        {
            this.TQB_STD_CFXN = new HashSet<TQB_STD_CFXN>();
        }
    
        public string C_ID { get; set; }
        public string C_TYPE_ID { get; set; }
        public string C_CODE { get; set; }
        public string C_NAME { get; set; }
        public string C_UNIT { get; set; }
        public string C_DIGIT { get; set; }
        public string C_BOOK_SHOW { get; set; }
        public string C_FORMULA { get; set; }
        public string C_QUANTITATIVE { get; set; }
        public short N_STATUS { get; set; }
        public string C_REMARK { get; set; }
        public string C_EMP_ID { get; set; }
        public System.DateTime D_MOD_DT { get; set; }
        public Nullable<short> N_ORDER { get; set; }
        public string C_SHOW_YC { get; set; }
    
        public virtual ICollection<TQB_STD_CFXN> TQB_STD_CFXN { get; set; }
    }
}
