using System;
namespace NF.MODEL
{
    public partial class Mod_TRC_ROLL_WGD_ITEM
    {
        public Mod_TRC_ROLL_WGD_ITEM()
        { }

        #region Model
        private string _c_id = "sys_guid";
        private string _c_main_id;
        private string _c_roll_wgd_id;
        private string _c_batch_no;
        private decimal _n_status = 0;
        private string _c_std_code;
        private string _c_stl_grd;
        private string _c_spec;
        private string _c_mat_code;
        private string _c_mat_desc;
        private string _c_sale_area;
        private string _c_zyx1;
        private string _c_zyx2;
        private string _c_bzyq;
        private string _c_mrsx;
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 组批主表主键（完工单号）
        /// </summary>
        public string C_MAIN_ID
        {
            set { _c_main_id = value; }
            get { return _c_main_id; }
        }
        /// <summary>
        /// 完工单主表id
        /// </summary>
        public string C_ROLL_WGD_ID
        {
            set { _c_roll_wgd_id = value; }
            get { return _c_roll_wgd_id; }
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
        /// 状态
        /// </summary>
        public decimal N_STATUS
        {
            set { _n_status = value; }
            get { return _n_status; }
        }
        /// <summary>
        /// 执行标准
        /// </summary>
        public string C_STD_CODE
        {
            set { _c_std_code = value; }
            get { return _c_std_code; }
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
        /// 物料编码
        /// </summary>
        public string C_MAT_CODE
        {
            set { _c_mat_code = value; }
            get { return _c_mat_code; }
        }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string C_MAT_DESC
        {
            set { _c_mat_desc = value; }
            get { return _c_mat_desc; }
        }
        /// <summary>
        /// 销售区域
        /// </summary>
        public string C_SALE_AREA
        {
            set { _c_sale_area = value; }
            get { return _c_sale_area; }
        }
        /// <summary>
        /// 自由向1
        /// </summary>
        public string C_ZYX1
        {
            set { _c_zyx1 = value; }
            get { return _c_zyx1; }
        }
        /// <summary>
        /// 自由向2
        /// </summary>
        public string C_ZYX2
        {
            set { _c_zyx2 = value; }
            get { return _c_zyx2; }
        }
        /// <summary>
        /// 包装标准
        /// </summary>
        public string C_BZYQ
        {
            set { _c_bzyq = value; }
            get { return _c_bzyq; }
        }
        /// <summary>
        /// 默认属性
        /// </summary>
        public string C_MRSX
        {
            set { _c_mrsx = value; }
            get { return _c_mrsx; }
        }

        #endregion Model
    }
}
