using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL.Q
{
   public class Mod_TMQ_QUA_MAIN
    {
        public Mod_TMQ_QUA_MAIN()
        { }
        private string _c_id = Guid.NewGuid().ToString();
        private string _c_area_id;
        private string _c_distributor;
        private string _c_directuser;
        private string _c_contact;
        private string _c_con_phone;
        private string _c_grd;
        private string _c_prod_use;
        private DateTime? _d_ship_start_dt;
        private DateTime? _d_ship_end_dt;
        private decimal? _n_object_count_wgt;
        private string _c_object_content;
        private string _c_tech_desc;
        private string _c_site_survey_content;
        private decimal? _n_parent_qua;
        private decimal? _n_quest_qua;
        private decimal? _n_middle_qua;
        private decimal? _n_else_qua;
        private string _c_dept;
        private string _c_quality_dept;
        private string _c_technology;
        private string _c_qt;
        private string _c_remark;
        private string _c_cust_making;
        private DateTime? _d_cust_making_dt;
        private string _c_quality_result;
        private string _c_objection_type;
        private string _c_ourreasons;
        private DateTime? _d_feedback_area;
        private string _c_effect_valid;
        private string _c_precc_result;
        private decimal? _n_amount;
        private DateTime? _d_compensation_dt;
        private string _c_state;
        private decimal? _n_cycle;
        private string _c_month_average;
        private string _c_salesman;
        private string _c_salesid;
        private decimal? _n_flag;
        private string _c_emp_id;
        private string _c_emp_name;
        private decimal? _n_status;
        private DateTime? _d_emp_dt;
        private string _c_crt_id;
        private DateTime? _d_crt_dt;
        private string _n_statusname;
        private string _n_flagname;
        private string _areaname;
        private string _cno;
        public string C_id { get => _c_id; set => _c_id = value; }
        public string C_area_id { get => _c_area_id; set => _c_area_id = value; }
        public string C_distributor { get => _c_distributor; set => _c_distributor = value; }
        public string C_directuser { get => _c_directuser; set => _c_directuser = value; }
        public string C_contact { get => _c_contact; set => _c_contact = value; }
        public string C_con_phone { get => _c_con_phone; set => _c_con_phone = value; }
        public string C_grd { get => _c_grd; set => _c_grd = value; }
        public string C_prod_use { get => _c_prod_use; set => _c_prod_use = value; }
        public DateTime? D_ship_start_dt { get => _d_ship_start_dt; set => _d_ship_start_dt = value; }
        public DateTime? D_ship_end_dt { get => _d_ship_end_dt; set => _d_ship_end_dt = value; }
        public decimal? N_object_count_wgt { get => _n_object_count_wgt; set => _n_object_count_wgt = value; }
        public string C_object_content { get => _c_object_content; set => _c_object_content = value; }
        public string C_tech_desc { get => _c_tech_desc; set => _c_tech_desc = value; }
        public string C_site_survey_content { get => _c_site_survey_content; set => _c_site_survey_content = value; }
        public decimal? N_parent_qua { get => _n_parent_qua; set => _n_parent_qua = value; }
        public decimal? N_quest_qua { get => _n_quest_qua; set => _n_quest_qua = value; }
        public decimal? N_middle_qua { get => _n_middle_qua; set => _n_middle_qua = value; }
        public decimal? N_else_qua { get => _n_else_qua; set => _n_else_qua = value; }
        public string C_dept { get => _c_dept; set => _c_dept = value; }
        public string C_quality_dept { get => _c_quality_dept; set => _c_quality_dept = value; }
        public string C_technology { get => _c_technology; set => _c_technology = value; }
        public string C_qt { get => _c_qt; set => _c_qt = value; }
        public string C_remark { get => _c_remark; set => _c_remark = value; }
        public string C_cust_making { get => _c_cust_making; set => _c_cust_making = value; }
        public DateTime? D_cust_making_dt { get => _d_cust_making_dt; set => _d_cust_making_dt = value; }
        public string C_quality_result { get => _c_quality_result; set => _c_quality_result = value; }
        public string C_objection_type { get => _c_objection_type; set => _c_objection_type = value; }
        public string C_ourreasons { get => _c_ourreasons; set => _c_ourreasons = value; }
        public DateTime? D_feedback_area { get => _d_feedback_area; set => _d_feedback_area = value; }
        public string C_effect_valid { get => _c_effect_valid; set => _c_effect_valid = value; }
        public string C_precc_result { get => _c_precc_result; set => _c_precc_result = value; }
        public decimal? N_amount { get => _n_amount; set => _n_amount = value; }
        public DateTime? D_compensation_dt { get => _d_compensation_dt; set => _d_compensation_dt = value; }
        public string C_state { get => _c_state; set => _c_state = value; }
        public decimal? N_cycle { get => _n_cycle; set => _n_cycle = value; }
        public string C_month_average { get => _c_month_average; set => _c_month_average = value; }
        public string C_salesman { get => _c_salesman; set => _c_salesman = value; }

        public string C_salesid { get => _c_salesid; set => _c_salesid = value; }
        public decimal? N_flag { get => _n_flag; set => _n_flag = value; }
        public string C_emp_id { get => _c_emp_id; set => _c_emp_id = value; }
        public string C_emp_name { get => _c_emp_name; set => _c_emp_name = value; }
        public decimal? N_status { get => _n_status; set => _n_status = value; }
        public DateTime? D_emp_dt { get => _d_emp_dt; set => _d_emp_dt = value; }
        public string C_crt_id { get => _c_crt_id; set => _c_crt_id = value; }
        public DateTime? D_crt_dt { get => _d_crt_dt; set => _d_crt_dt = value; }
        public string N_statusname { get => _n_statusname; set => _n_statusname = value; }
        public string N_flagname { get => _n_flagname; set => _n_flagname = value; }
        public string C_areaname { get => _areaname; set => _areaname = value; }
        public string C_No { get => _cno; set => _cno = value; }
    }
}
