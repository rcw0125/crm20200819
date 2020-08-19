using System;
namespace NF.MODEL
{
    /// <summary>
    /// 线材资源调配记录
    /// </summary>
    [Serializable]
    public partial class Mod_TMC_ROLL_DEPLOY_LOG
    {
        public Mod_TMC_ROLL_DEPLOY_LOG()
        { }
        /// <summary>
        /// 原客户信息
        /// </summary>
        public string C_OLDCUST { set; get; }
        /// <summary>
        /// 需求客户信息
        /// </summary>
        public string C_NEWCUST { set; get; }
      
        public string C_OLDCON { set; get; }
        public string C_NEWCON { set; get; }

        #region Model
        private string _c_id;
        private string _c_batch_no;
        private string _c_mat_code;
        private string _c_stl_grd;
        private string _c_spec;
        private string _c_oldarea;
        private string _c_newarea;
        private string _c_empid;
        private string _c_empname;
        private DateTime? _d_mod;

        /// <summary>
        /// 包装要求
        /// </summary>
        public string C_PACK { set; get; }
        
        /// <summary>
        /// 质量等级
        /// </summary>
        public string C_JUDGE_LEV { set; get; }

        /// <summary>
        /// 表判等级
        /// </summary>
        public string C_JUDGE_LEV_BP { set; get; }

        /// <summary>
        /// 执行标准
        /// </summary>
        public string C_STD_CODE { set; get; }
        /// <summary>
        /// 件数
        /// </summary>
        public string C_QUA { set; get; }

        /// <summary>
        /// 线材主键
        /// </summary>
        public string C_ROLL_PROCID { set; get; }
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 批号
        /// </summary>
        public string C_BATCH_NO
        {
            set { _c_batch_no = value; }
            get { return _c_batch_no; }
        }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string C_MAT_CODE
        {
            set { _c_mat_code = value; }
            get { return _c_mat_code; }
        }
        /// <summary>
        /// 钢种
        /// </summary>
        public string C_STL_GRD
        {
            set { _c_stl_grd = value; }
            get { return _c_stl_grd; }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string C_SPEC
        {
            set { _c_spec = value; }
            get { return _c_spec; }
        }
        /// <summary>
        /// 原资源所属区域
        /// </summary>
        public string C_OLDAREA
        {
            set { _c_oldarea = value; }
            get { return _c_oldarea; }
        }
        /// <summary>
        /// 新资源所属区域
        /// </summary>
        public string C_NEWAREA
        {
            set { _c_newarea = value; }
            get { return _c_newarea; }
        }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public string C_EMPID
        {
            set { _c_empid = value; }
            get { return _c_empid; }
        }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string C_EMPNAME
        {
            set { _c_empname = value; }
            get { return _c_empname; }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? D_MOD
        {
            set { _d_mod = value; }
            get { return _d_mod; }
        }
        #endregion Model

    }
}

