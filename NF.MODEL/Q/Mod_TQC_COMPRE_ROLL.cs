using System;
namespace NF.MODEL
{
	/// <summary>
	/// 线材综合判定信息表
	/// </summary>
	[Serializable]
	public partial class Mod_TQC_COMPRE_ROLL
	{
		public Mod_TQC_COMPRE_ROLL()
		{}
		#region Model
		private string _c_id;
		private string _c_stove;
		private string _c_batch_no;
		private string _c_stl_grd;
		private decimal _n_wgt=0;
		private decimal? _n_qua;
		private string _c_std_code;
		private string _c_spec;
		private string _c_mat_code;
		private string _c_mat_name;
		private string _c_shift;
		private string _c_group;
		private string _c_result_face;
		private string _c_reason_name;
		private string _c_reason_code;
		private DateTime? _d_dp_dt;
		private string _c_result_ele;
		private string _c_result_phy;
		private string _c_result_all;
		private DateTime? _d_resall_dt;
		private string _c_result_people;
		private DateTime? _d_respeo_dt;
		private string _c_qr_state="N";
		private string _c_emp_id;
		private DateTime? _d_mod_dt;
		private string _c_result_physec;
		private string _c_result_phyfinal;
		private string _c_design_no;
		private decimal _n_status=1;
		private string _c_remark;
        private string _c_kp_no;
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 炉号
		/// </summary>
		public string C_STOVE
		{
			set{ _c_stove=value;}
			get{return _c_stove;}
		}
		/// <summary>
		/// 批号
		/// </summary>
		public string C_BATCH_NO
		{
			set{ _c_batch_no=value;}
			get{return _c_batch_no;}
		}
		/// <summary>
		/// 钢种
		/// </summary>
		public string C_STL_GRD
		{
			set{ _c_stl_grd=value;}
			get{return _c_stl_grd;}
		}
		/// <summary>
		/// 重量
		/// </summary>
		public decimal N_WGT
		{
			set{ _n_wgt=value;}
			get{return _n_wgt;}
		}
		/// <summary>
		/// 件数
		/// </summary>
		public decimal? N_QUA
		{
			set{ _n_qua=value;}
			get{return _n_qua;}
		}
		/// <summary>
		/// 执行标准
		/// </summary>
		public string C_STD_CODE
		{
			set{ _c_std_code=value;}
			get{return _c_std_code;}
		}
		/// <summary>
		/// 规格
		/// </summary>
		public string C_SPEC
		{
			set{ _c_spec=value;}
			get{return _c_spec;}
		}
		/// <summary>
		/// 物料编码
		/// </summary>
		public string C_MAT_CODE
		{
			set{ _c_mat_code=value;}
			get{return _c_mat_code;}
		}
		/// <summary>
		/// 物料描述
		/// </summary>
		public string C_MAT_NAME
		{
			set{ _c_mat_name=value;}
			get{return _c_mat_name;}
		}
		/// <summary>
		/// 班次
		/// </summary>
		public string C_SHIFT
		{
			set{ _c_shift=value;}
			get{return _c_shift;}
		}
		/// <summary>
		/// 班组
		/// </summary>
		public string C_GROUP
		{
			set{ _c_group=value;}
			get{return _c_group;}
		}
		/// <summary>
		/// 表面判定等级
		/// </summary>
		public string C_RESULT_FACE
		{
			set{ _c_result_face=value;}
			get{return _c_result_face;}
		}
		/// <summary>
		/// 不合格原因名称
		/// </summary>
		public string C_REASON_NAME
		{
			set{ _c_reason_name=value;}
			get{return _c_reason_name;}
		}
		/// <summary>
		/// 不合格原因代码
		/// </summary>
		public string C_REASON_CODE
		{
			set{ _c_reason_code=value;}
			get{return _c_reason_code;}
		}
		/// <summary>
		/// 打牌时间
		/// </summary>
		public DateTime? D_DP_DT
		{
			set{ _d_dp_dt=value;}
			get{return _d_dp_dt;}
		}
		/// <summary>
		/// 成分判定结果
		/// </summary>
		public string C_RESULT_ELE
		{
			set{ _c_result_ele=value;}
			get{return _c_result_ele;}
		}
		/// <summary>
		/// 性能初检结果
		/// </summary>
		public string C_RESULT_PHY
		{
			set{ _c_result_phy=value;}
			get{return _c_result_phy;}
		}
		/// <summary>
		/// 系统综合判定结果
		/// </summary>
		public string C_RESULT_ALL
		{
			set{ _c_result_all=value;}
			get{return _c_result_all;}
		}
		/// <summary>
		/// 系统综合判定时间
		/// </summary>
		public DateTime? D_RESALL_DT
		{
			set{ _d_resall_dt=value;}
			get{return _d_resall_dt;}
		}
		/// <summary>
		/// 人工综合判定结果
		/// </summary>
		public string C_RESULT_PEOPLE
		{
			set{ _c_result_people=value;}
			get{return _c_result_people;}
		}
		/// <summary>
		/// 人工综合判定时间
		/// </summary>
		public DateTime? D_RESPEO_DT
		{
			set{ _d_respeo_dt=value;}
			get{return _d_respeo_dt;}
		}
		/// <summary>
		/// 确认状态
		/// </summary>
		public string C_QR_STATE
		{
			set{ _c_qr_state=value;}
			get{return _c_qr_state;}
		}
		/// <summary>
		/// 确认人
		/// </summary>
		public string C_EMP_ID
		{
			set{ _c_emp_id=value;}
			get{return _c_emp_id;}
		}
		/// <summary>
		/// 确认时间
		/// </summary>
		public DateTime? D_MOD_DT
		{
			set{ _d_mod_dt=value;}
			get{return _d_mod_dt;}
		}
		/// <summary>
		/// 性能复检结果
		/// </summary>
		public string C_RESULT_PHYSEC
		{
			set{ _c_result_physec=value;}
			get{return _c_result_physec;}
		}
		/// <summary>
		/// 性能评审结果
		/// </summary>
		public string C_RESULT_PHYFINAL
		{
			set{ _c_result_phyfinal=value;}
			get{return _c_result_phyfinal;}
		}
		/// <summary>
		/// 质量设计号
		/// </summary>
		public string C_DESIGN_NO
		{
			set{ _c_design_no=value;}
			get{return _c_design_no;}
		}
		/// <summary>
		/// 使用状态   1-可用；0-停用
		/// </summary>
		public decimal N_STATUS
		{
			set{ _n_status=value;}
			get{return _n_status;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string C_REMARK
		{
			set{ _c_remark=value;}
			get{return _c_remark;}
		}
        /// <summary>
		/// 开坯号
		/// </summary>
		public string C_KP_NO
        {
            set { _c_kp_no = value; }
            get { return _c_kp_no; }
        }
        #endregion Model

    }
}

