using System;
namespace NF.MODEL
{
    /// <summary>
    /// 合同明细
    /// </summary>
    [Serializable]
    public partial class Mod_TMO_CONDETAILS2
    {
        public Mod_TMO_CONDETAILS2()
        { }

        #region Model

        private string c_no;
        private string c_con_no;
        private string c_con_name;
        private string c_area;
        private string c_mat_code;
        private string c_mat_name;
        private string c_tech_prot;
        private string c_spec;
        private string c_stl_grd;
        private string c_free_term;
        private string n_wgt;
        private string c_pack;
   


        /// <summary>
        /// 订单号(主键)
        /// </summary>
        public string C_NO
        {
            set { c_no = value; }
            get { return c_no; }
        }
        /// <summary>
        /// 合同号(外键)
        /// </summary>
        public string C_CON_NO
        {
            set { c_con_no = value; }
            get { return c_con_no; }
        }

        /// <summary>
        /// 合同名称
        /// </summary>
        public string C_CON_NAME
        {
            set { c_con_name = value; }
            get { return c_con_name; }
        }

        /// <summary>
        /// 区域
        /// </summary>
        public string C_AREA {
            set { c_area = value; }
            get { return c_area; }
        }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string C_MAT_CODE
        {
            set { c_mat_code = value; }
            get { return c_mat_code; }
        }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string C_MAT_NAME
        {
            set { c_mat_name = value; }
            get { return c_mat_name; }
        }

        /// <summary>
        /// 客户协议号
        /// </summary>
        public string C_TECH_PROT {
            set { c_tech_prot = value; }
            get { return c_tech_prot; }
        }

        /// <summary>
        /// 规格
        /// </summary>
        public string C_SPEC
        {
            set { c_spec = value; }
            get { return c_spec; }
        }

        /// <summary>
        /// 钢种
        /// </summary>
        public string C_STL_GRD
        {
            set { c_stl_grd = value; }
            get { return c_stl_grd; }
        }

        public string C_FREE_TERM {
            set { c_free_term = value; }
            get { return c_free_term; }
        }

        public string N_WGT
        {
            set { n_wgt = value; }
            get { return n_wgt; }
        }

        public string C_PACK
        {
            set { c_pack = value; }
            get { return c_pack; }
        }

        #endregion Model

    }
}

