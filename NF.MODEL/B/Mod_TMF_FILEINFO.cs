using System;
namespace NF.MODEL
{
	/// <summary>
	/// 文件事务信息表(数据主表)
	/// </summary>
	[Serializable]
	public partial class Mod_TMF_FILEINFO
    {
		public Mod_TMF_FILEINFO()
		{}
		#region Model
		private string _c_id;
		private string _c_flow_id;
		private string _c_emp_id;
		private string _c_title;
		private string _c_content;
		private string _c_fileurl;
		private decimal? _n_status=0;
		private DateTime? _d_sb_dt;
		private string _c_remark;
		private decimal? _n_type;
		private string _c_task_id;
		private string _c_step_id;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 流程ID
		/// </summary>
		public string C_FLOW_ID
		{
			set{ _c_flow_id=value;}
			get{return _c_flow_id;}
		}
		/// <summary>
		/// 提交人ID
		/// </summary>
		public string C_EMP_ID
		{
			set{ _c_emp_id=value;}
			get{return _c_emp_id;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string C_TITLE
		{
			set{ _c_title=value;}
			get{return _c_title;}
		}
		/// <summary>
		/// 处理内容
		/// </summary>
		public string C_CONTENT
		{
			set{ _c_content=value;}
			get{return _c_content;}
		}
		/// <summary>
		/// 附件地址
		/// </summary>
		public string C_FILEURL
		{
			set{ _c_fileurl=value;}
			get{return _c_fileurl;}
		}
        /// <summary>
        /// 状态：0未结，1办结
        /// </summary>
        public decimal? N_STATUS
		{
			set{ _n_status=value;}
			get{return _n_status;}
		}
		/// <summary>
		/// 提交时间
		/// </summary>
		public DateTime? D_SB_DT
		{
			set{ _d_sb_dt=value;}
			get{return _d_sb_dt;}
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
		/// 类型：0合同，1质量异议
		/// </summary>
		public decimal? N_TYPE
		{
			set{ _n_type=value;}
			get{return _n_type;}
		}
		/// <summary>
		/// 任务id
		/// </summary>
		public string C_TASK_ID
		{
			set{ _c_task_id=value;}
			get{return _c_task_id;}
		}
		/// <summary>
		/// 步骤id
		/// </summary>
		public string C_STEP_ID
		{
			set{ _c_step_id=value;}
			get{return _c_step_id;}
		}
		#endregion Model

	}
}

