using System;
namespace NF.MODEL
{
	/// <summary>
	/// 评分项目
	/// </summary>
	[Serializable]
	public partial class Mod_TMC_GIVEMARK_ITEM
    {
		public Mod_TMC_GIVEMARK_ITEM()
		{}
		#region Model
		private string _c_id=Guid.NewGuid().ToString ();
		private string _c_name;
		private string _c_flag;
		private decimal? _n_score;
		private decimal? _n_status=1;
		private string _c_remark;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string C_NAME
		{
			set{ _c_name=value;}
			get{return _c_name;}
		}
		/// <summary>
		/// 标识
		/// </summary>
		public string C_FLAG
		{
			set{ _c_flag=value;}
			get{return _c_flag;}
		}
		/// <summary>
		/// 分数
		/// </summary>
		public decimal? N_SCORE
		{
			set{ _n_score=value;}
			get{return _n_score;}
		}
		/// <summary>
		/// 状态0停用，1启用
		/// </summary>
		public decimal? N_STATUS
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
		#endregion Model

	}
}

