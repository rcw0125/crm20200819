using System;
namespace NF.MODEL
{
	/// <summary>
	/// 聊天记录
	/// </summary>
	[Serializable]
	public partial class Mod_TMC_CHAT
    {
		public Mod_TMC_CHAT()
		{}
        #region Model
        private string _c_id = Guid.NewGuid().ToString();
		private string _c_uid;
        private string _c_fid;
        private string _c_content;
		private DateTime? _d_dt;
		/// <summary>
		/// C_ID
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 发送者
		/// </summary>
		public string C_UID
		{
			set{ _c_uid=value;}
			get{return _c_uid;}
		}
        /// <summary>
		/// 接收者
		/// </summary>
		public string C_FID
        {
            set { _c_fid = value; }
            get { return _c_fid; }
        }
        /// <summary>
        /// 发送内容
        /// </summary>
        public string C_CONTENT
		{
			set{ _c_content=value;}
			get{return _c_content;}
		}
		/// <summary>
		/// 发送时间
		/// </summary>
		public DateTime? D_DT
        {
			set{ _d_dt = value;}
			get{return _d_dt; }
		}
		#endregion Model

	}
}

