using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL.Q
{
    public class Mod_TMQ_QUA_ITEM
    {
        public Mod_TMQ_QUA_ITEM()
        { }
        private string _c_id = Guid.NewGuid().ToString();
        private string _c_parentid;
        private string _c_brand_name;
        private string _c_spec;
        private string _c_batch;
        private decimal? _n_shippedqty;
        private decimal? _n_object_wgt;
        private string _c_stl_code;
        private string _c_emp_id;
        private string _c_emp_name;
        private decimal? _n_status;
        private DateTime? _c_emp_dt;
        private string _c_crt_id;
        private DateTime? _d_crt_dt;
        public string C_id { get => _c_id; set => _c_id = value; }
        public string C_parentid { get => _c_parentid; set => _c_parentid = value; }
        public string C_brand_name { get => _c_brand_name; set => _c_brand_name = value; }
        public string C_spec { get => _c_spec; set => _c_spec = value; }
        public string C_batch { get => _c_batch; set => _c_batch = value; }
        public decimal? N_shippedqty { get => _n_shippedqty; set => _n_shippedqty = value; }
        public decimal? N_object_wgt { get => _n_object_wgt; set => _n_object_wgt = value; }
        public string C_stl_code { get => _c_stl_code; set => _c_stl_code = value; }
        public string C_emp_id { get => _c_emp_id; set => _c_emp_id = value; }
        public string C_emp_name { get => _c_emp_name; set => _c_emp_name = value; }
        public decimal? N_status { get => _n_status; set => _n_status = value; }
        public DateTime? C_emp_dt { get => _c_emp_dt; set => _c_emp_dt = value; }
        public string C_crt_id { get => _c_crt_id; set => _c_crt_id = value; }
        public DateTime? D_crt_dt { get => _d_crt_dt; set => _d_crt_dt = value; }
    }
}
