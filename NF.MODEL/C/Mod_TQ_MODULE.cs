using System;
namespace NF.MODEL
{
	/// <summary>
	/// 功能模块测试报告
	/// </summary>
	[Serializable]
	public partial class Mod_TQ_MODULE
    {
		public Mod_TQ_MODULE()
		{}
        #region Model
        private string _c_id = Guid.NewGuid().ToString();
		private string _c_class;
		private string _c_module;
		private string _c_conent;
		private string _c_xgemp;
		private string _c_dept;
		private string _c_tel;
		private DateTime? _d_time= Convert.ToDateTime(DateTime.Now);
		private string _c_ict;
		private string _c_result;
		private DateTime? _d_icttime;
		private string _c_reamrk;
		/// <summary>
		/// 主键
		/// </summary>
		public string C_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 模块分类
		/// </summary>
		public string C_CLASS
		{
			set{ _c_class=value;}
			get{return _c_class;}
		}
		/// <summary>
		/// 模块名称
		/// </summary>
		public string C_MODULE
		{
			set{ _c_module=value;}
			get{return _c_module;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string C_CONENT
		{
			set{ _c_conent=value;}
			get{return _c_conent;}
		}
		/// <summary>
		/// 邢钢负责人
		/// </summary>
		public string C_XGEMP
		{
			set{ _c_xgemp=value;}
			get{return _c_xgemp;}
		}
		/// <summary>
		/// 部门
		/// </summary>
		public string C_DEPT
		{
			set{ _c_dept=value;}
			get{return _c_dept;}
		}
		/// <summary>
		/// 联系方式
		/// </summary>
		public string C_TEL
		{
			set{ _c_tel=value;}
			get{return _c_tel;}
		}
		/// <summary>
		/// 提交时间
		/// </summary>
		public DateTime? D_TIME
		{
			set{ _d_time=value;}
			get{return _d_time;}
		}
		/// <summary>
		/// ICT项目组
		/// </summary>
		public string C_ICT
		{
			set{ _c_ict=value;}
			get{return _c_ict;}
		}
		/// <summary>
		/// 处理结果
		/// </summary>
		public string C_RESULT
		{
			set{ _c_result=value;}
			get{return _c_result;}
		}
		/// <summary>
		/// 处理时间
		/// </summary>
		public DateTime? D_ICTTIME
		{
			set{ _d_icttime=value;}
			get{return _d_icttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_REAMRK
		{
			set{ _c_reamrk=value;}
			get{return _c_reamrk;}
		}
		#endregion Model

	}
}

