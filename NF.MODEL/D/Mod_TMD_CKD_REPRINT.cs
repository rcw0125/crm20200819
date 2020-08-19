using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL.D
{
    /// <summary>
    /// 打印字段
    /// </summary>
    public class Mod_TMD_CKD_REPRINT
    {
        private string _c_id;
        private string _c_attestor;
        private DateTime? _d_visa_dt;       
        private decimal? _n_status;
        private string _c_dispatch_id;
        private decimal? _c_type;

        public string C_id { get => _c_id; set => _c_id = value; }
        public string C_attestor { get => _c_attestor; set => _c_attestor = value; }
        public DateTime? D_visa_dt { get => _d_visa_dt; set => _d_visa_dt = value; }
        public decimal? N_status { get => _n_status; set => _n_status = value; }
        public string C_dispatch_id { get => _c_dispatch_id; set => _c_dispatch_id = value; }

        public decimal? N_type { get => _c_type; set => _c_type = value; }
    }
}
