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
    public class Mod_TMD_ZZS_REPRINT
    {
        private string _c_id;
        private string _c_certificate_no;
        private string _c_attestor;
        private DateTime? _d_visa_dt;
        private string _c_print_type;
        private string _c_print_templates;
        private decimal? _n_status;
        private string _c_remark;
        private string _c_emp_id;
        private DateTime? _d_mod_dt;
        private string _c_spec;
        private string _c_stl_grd;
        private string _c_std_code;
        private string _c_dispatch_id;
        private string _c_lic_pla_no;

        private decimal? _c_type;

        public string C_id { get => _c_id; set => _c_id = value; }
        public string C_certificate_no { get => _c_certificate_no; set => _c_certificate_no = value; }
        public string C_attestor { get => _c_attestor; set => _c_attestor = value; }
        public DateTime? D_visa_dt { get => _d_visa_dt; set => _d_visa_dt = value; }
        public string C_print_type { get => _c_print_type; set => _c_print_type = value; }
        public string C_print_templates { get => _c_print_templates; set => _c_print_templates = value; }
        public decimal? N_status { get => _n_status; set => _n_status = value; }
        public string C_remark { get => _c_remark; set => _c_remark = value; }
        public string C_emp_id { get => _c_emp_id; set => _c_emp_id = value; }
        public DateTime? D_mod_dt { get => _d_mod_dt; set => _d_mod_dt = value; }
        public string C_spec { get => _c_spec; set => _c_spec = value; }
        public string C_stl_grd { get => _c_stl_grd; set => _c_stl_grd = value; }
        public string C_std_code { get => _c_std_code; set => _c_std_code = value; }
        public string C_dispatch_id { get => _c_dispatch_id; set => _c_dispatch_id = value; }
        public string C_lic_pla_no { get => _c_lic_pla_no; set => _c_lic_pla_no = value; }

        public decimal? N_type { get => _c_type; set => _c_type = value; }
    }
}
