using System;
namespace NF.MODEL
{
	/// <summary>
	/// 文档管理
	/// </summary>
	[Serializable]
	public partial class Mod_TB_FILE
	{
		public Mod_TB_FILE()
		{}
		#region Model
		private string _c_id;
		private string _c_filename;
		private string _c_filetype;
		private string _c_filepath;
		private string _c_filelink;
		private DateTime? _d_dt;
		private string _c_empid;
		/// <summary>
		/// 
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 文件名称
		/// </summary>
		public string C_FILENAME
		{
			set{ _c_filename=value;}
			get{return _c_filename;}
		}
		/// <summary>
		/// 文件类型：0合同
		/// </summary>
		public string C_FILETYPE
		{
			set{ _c_filetype=value;}
			get{return _c_filetype;}
		}
		/// <summary>
		/// 文件路径
		/// </summary>
		public string C_FILEPATH
		{
			set{ _c_filepath=value;}
			get{return _c_filepath;}
		}
        /// <summary>
        /// 文件PK主键
        /// </summary>
        public string C_FILELINK
		{
			set{ _c_filelink=value;}
			get{return _c_filelink;}
		}
		/// <summary>
		/// 上传时间
		/// </summary>
		public DateTime? D_DT
		{
			set{ _d_dt=value;}
			get{return _d_dt;}
		}
		/// <summary>
		/// 操作人ID
		/// </summary>
		public string C_EMPID
		{
			set{ _c_empid=value;}
			get{return _c_empid;}
		}
		#endregion Model

	}
}

