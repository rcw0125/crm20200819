using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL
{
    public class Mod_TQC_COMPRE_ITEM_RESULT
    {
        public string C_ID { get; set; }
        public string C_STOVE { get; set; }
        public string C_BATCH_NO { get; set; }
        public string C_STL_GRD { get; set; }
        public string C_SPEC { get; set; }
        public string C_STD_CODE { get; set; }
        public string C_CHARACTER_ID { get; set; }
        public string C_ITEM_NAME { get; set; }
        public string C_TARGET_MIN { get; set; }
        public string C_TARGET_INTERVAL { get; set; }
        public string C_TARGET_MAX { get; set; }
        public string C_TYPE { get; set; }
        public string C_UNIT { get; set; }
        public string C_QUANTITATIVE { get; set; }
        public string C_VALUE { get; set; }
        public string C_RESULT { get; set; }
        public string C_CHECK_STATE { get; set; } = "0";
        public decimal N_STATUS { get; set; }
        public string C_REMARK { get; set; }
        public string C_EMP_ID { get; set; }
        public DateTime D_MOD_DT { get; set; }
        public string C_DESIGN_NO { get; set; }
        public decimal N_PRINT_ORDER { get; set; }
        public string C_TICK_NO { get; set; }
        public string C_IS_SHOW { get; set; }
        public string C_IS_DECIDE { get; set; }
        public string C_GROUP { get; set; }
        public string C_TB { get; set; }

        public Mod_TQC_COMPRE_ITEM_RESULT Clone()
        {
            return new Mod_TQC_COMPRE_ITEM_RESULT
            {
                C_BATCH_NO = this.C_BATCH_NO,
                C_CHARACTER_ID = this.C_CHARACTER_ID,
                C_CHECK_STATE = this.C_CHECK_STATE,
                C_DESIGN_NO = this.C_DESIGN_NO,
                C_EMP_ID = this.C_EMP_ID,
                C_GROUP = this.C_GROUP,
                C_ID = Guid.NewGuid().ToString("N"),
                C_IS_DECIDE = this.C_IS_DECIDE,
                C_IS_SHOW = this.C_IS_SHOW,
                C_ITEM_NAME = this.C_ITEM_NAME,
                C_QUANTITATIVE = this.C_QUANTITATIVE,
                C_REMARK = this.C_REMARK,
                C_RESULT = this.C_RESULT,
                C_SPEC = this.C_SPEC,
                C_STD_CODE = this.C_STD_CODE,
                C_STL_GRD = this.C_STL_GRD,
                C_STOVE = this.C_STOVE,
                C_TARGET_INTERVAL = this.C_TARGET_INTERVAL,
                C_TARGET_MAX = this.C_TARGET_MAX,
                C_TARGET_MIN = this.C_TARGET_MIN,
                C_TB = this.C_TB,
                C_TICK_NO = this.C_TICK_NO,
                C_TYPE = this.C_TYPE,
                C_UNIT = this.C_UNIT,
                C_VALUE = this.C_VALUE,
                D_MOD_DT = this.D_MOD_DT,
                N_PRINT_ORDER = this.N_PRINT_ORDER,
                N_STATUS = this.N_STATUS
            };
        }

    }
}
