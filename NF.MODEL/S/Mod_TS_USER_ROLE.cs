using System;
namespace NF.MODEL
{
	/// <summary>
	/// TS_USER_ROLE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Mod_TS_USER_ROLE
    {
		public Mod_TS_USER_ROLE()
		{}
        #region Model
        private string _c_id = Guid.NewGuid().ToString();
		private string _c_user_id;
		private string _c_role_id;
		/// <summary>
		/// 
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_USER_ID
		{
			set{ _c_user_id=value;}
			get{return _c_user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_ROLE_ID
		{
			set{ _c_role_id=value;}
			get{return _c_role_id;}
		}
		#endregion Model

	}
}

