using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TMB_AREADTO : BASEDTO
    {
        public string C_ID { get; set; }
        public string C_CODE { get; set; }
        public string C_NAME { get; set; }
        public string N_PARENTID { get; set; }
        public int? N_SORT { get; set; }
        public int? N_DEPTH { get; set; }
        public string C_REMARK { get; set; }
        public int? N_ISGPS { get; set; }
        public string C_MAXAREA { get; set; }
        public decimal? N_STATUS { get; set; }
        public List<TMB_AREADTO> Areas { get; set; }

    }
}
