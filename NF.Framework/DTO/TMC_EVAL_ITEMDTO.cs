using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TMC_EVAL_ITEMDTO : BASEDTO
    {
        public string C_ID { get; set; }
        public string C_NAME { get; set; }
        public string C_REMARK { get; set; }
        public int N_STATUS { get; set; }
    }
}
