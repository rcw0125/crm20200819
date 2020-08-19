using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TMD_DISPATCH_LOGDTO
    {
        public string C_ID { get; set; }
        public string C_DISPATCH_ID { get; set; }
        public string C_EMP_ID { get; set; }
        public string C_EMP_NAME { get; set; }
        public DateTime D_MOD_DT { get; set; }
        public string N_TYPE { get; set; }
        public string C_BSTATUS { get; set; }
        public string C_ASTATUS { get; set; }
        public string C_EXPLAIN { get; set; }
        public List<TMD_DISPATCH_LOGDTO> Logs { get; set; }
    }
}
