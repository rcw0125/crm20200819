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
    
    public partial class TQB_SAMPLING
    {
        public TQB_SAMPLING()
        {
            this.TQB_STD_SAMPLING = new HashSet<TQB_STD_SAMPLING>();
        }
    
        public string C_ID { get; set; }
        public string C_SAMPLING_CODE { get; set; }
        public string C_SAMPLING_NAME { get; set; }
        public short N_STATUS { get; set; }
        public string C_REMARK { get; set; }
        public string C_EMP_ID { get; set; }
        public System.DateTime D_MOD_DT { get; set; }
        public Nullable<int> N_SAMPLING_SN { get; set; }
        public string C_CHECK_DEPMT { get; set; }
    
        public virtual ICollection<TQB_STD_SAMPLING> TQB_STD_SAMPLING { get; set; }
    }
}
