using System;
namespace NF.MODEL
{
	/// <summary>
	/// 质量-附件
	/// </summary>
	[Serializable]
	public partial class Mod_TMQ_QUALITY_FILE
    {
		public Mod_TMQ_QUALITY_FILE()
		{}
        #region Model
        private string _c_id = Guid.NewGuid().ToString();
		private string _c_quality_id;
		private string _c_title;
		private string _c_path;
		private string _c_remark;
		private DateTime? _d_dt= Convert.ToDateTime(DateTime.Now);
		/// <summary>
		/// 
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 质量外键ID
		/// </summary>
		public string C_QUALITY_ID
		{
			set{ _c_quality_id=value;}
			get{return _c_quality_id;}
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
		/// 路径
		/// </summary>
		public string C_PATH
		{
			set{ _c_path=value;}
			get{return _c_path;}
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
		/// 时间
		/// </summary>
		public DateTime? D_DT
		{
			set{ _d_dt=value;}
			get{return _d_dt;}
		}
		#endregion Model

	}
}

