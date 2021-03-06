//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NF.EF.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TRP_PLAN_ROLL_ITEM_INFO
    {
        public string C_ID { get; set; }
        public string C_PLAN_ROLL_ID { get; set; }
        public Nullable<short> N_STATUS { get; set; }
        public string C_INITIALIZE_ITEM_ID { get; set; }
        public string C_ORDER_NO { get; set; }
        public Nullable<decimal> N_WGT { get; set; }
        public string C_MAT_CODE { get; set; }
        public string C_MAT_NAME { get; set; }
        public string C_TECH_PROT { get; set; }
        public string C_SPEC { get; set; }
        public string C_STL_GRD { get; set; }
        public string C_STD_CODE { get; set; }
        public Nullable<short> N_USER_LEV { get; set; }
        public Nullable<short> N_STL_GRD_LEV { get; set; }
        public Nullable<short> N_ORDER_LEV { get; set; }
        public string C_QUALIRY_LEV { get; set; }
        public Nullable<System.DateTime> D_NEED_DT { get; set; }
        public Nullable<System.DateTime> D_DELIVERY_DT { get; set; }
        public Nullable<System.DateTime> D_DT { get; set; }
        public string C_LINE_DESC { get; set; }
        public string C_LINE_CODE { get; set; }
        public Nullable<System.DateTime> D_P_START_TIME { get; set; }
        public Nullable<System.DateTime> D_P_END_TIME { get; set; }
        public Nullable<decimal> N_PROD_TIME { get; set; }
        public Nullable<short> N_SORT { get; set; }
        public Nullable<short> N_ROLL_PROD_WGT { get; set; }
        public string C_ROLL_PROD_EMP_ID { get; set; }
        public string C_STL_ROL_DT { get; set; }
        public Nullable<decimal> N_PROD_WGT { get; set; }
        public Nullable<decimal> N_WARE_WGT { get; set; }
        public Nullable<decimal> N_WARE_OUT_WGT { get; set; }
        public Nullable<long> N_FLAG { get; set; }
        public Nullable<decimal> N_ISSUE_WGT { get; set; }
        public string C_CUST_NO { get; set; }
        public string C_CUST_NAME { get; set; }
        public string C_SALE_CHANNEL { get; set; }
        public string C_PACK { get; set; }
        public string C_DESIGN_NO { get; set; }
        public Nullable<decimal> N_GROUP_WGT { get; set; }
        public string C_STA_ID { get; set; }
        public Nullable<System.DateTime> D_START_TIME { get; set; }
        public Nullable<System.DateTime> D_END_TIME { get; set; }
        public string C_EMP_ID { get; set; }
        public System.DateTime D_MOD_DT { get; set; }
        public Nullable<decimal> N_ROLL_WGT { get; set; }
        public Nullable<decimal> N_MACH_WGT { get; set; }
        public string C_CAST_NO { get; set; }
        public string C_INITIALIZE_ID { get; set; }
        public string C_FREE_TERM { get; set; }
        public string C_FREE_TERM2 { get; set; }
        public string C_AREA { get; set; }
        public string C_PCLX { get; set; }
        public string C_SFHL { get; set; }
        public Nullable<System.DateTime> D_HL_START_TIME { get; set; }
        public Nullable<System.DateTime> D_HL_END_TIME { get; set; }
        public string C_SFHL_D { get; set; }
        public Nullable<System.DateTime> D_DHL_START_TIME { get; set; }
        public Nullable<System.DateTime> D_DHL_END_TIME { get; set; }
        public string C_SFKP { get; set; }
        public Nullable<System.DateTime> D_KP_START_TIME { get; set; }
        public Nullable<System.DateTime> D_KP_END_TIME { get; set; }
        public string C_SFXM { get; set; }
        public Nullable<System.DateTime> D_XM_START_TIME { get; set; }
        public Nullable<System.DateTime> D_XM_END_TIME { get; set; }
        public Nullable<short> N_UPLOADSTATUS { get; set; }
        public string C_MATRL_CODE_SLAB { get; set; }
        public string C_MATRL_NAME_SLAB { get; set; }
        public string C_SLAB_SIZE { get; set; }
        public Nullable<long> N_SLAB_LENGTH { get; set; }
        public Nullable<decimal> N_SLAB_PW { get; set; }
        public Nullable<System.DateTime> D_CAN_ROLL_TIME { get; set; }
        public string C_ROUTE { get; set; }
        public Nullable<decimal> N_DIAMETER { get; set; }
        public string C_XM_YQ { get; set; }
        public Nullable<int> N_JRL_WD { get; set; }
        public Nullable<int> N_JRL_SJ { get; set; }
        public string C_STL_GRD_SLAB { get; set; }
        public string C_STD_CODE_SLAB { get; set; }
        public string C_REMARK { get; set; }
        public Nullable<decimal> N_HG_WGT { get; set; }
        public Nullable<decimal> N_DP_WGT { get; set; }
        public Nullable<decimal> N_GP_WGT { get; set; }
        public Nullable<decimal> N_XY_WGT { get; set; }
        public Nullable<decimal> N_TW_WGT { get; set; }
        public Nullable<decimal> N_BHG_WGT { get; set; }
        public Nullable<decimal> N_HG_WGT_IN { get; set; }
        public Nullable<decimal> N_GP_WGT_IN { get; set; }
        public Nullable<decimal> N_XY_WGT_IN { get; set; }
        public Nullable<decimal> N_TW_WGT_IN { get; set; }
        public Nullable<decimal> N_BHG_WGT_IN { get; set; }
        public Nullable<decimal> N_HG_WGT_OUT { get; set; }
        public Nullable<decimal> N_GP_WGT_OUT { get; set; }
        public Nullable<decimal> N_XY_WGT_OUT { get; set; }
        public Nullable<decimal> N_TW_WGT_OUT { get; set; }
        public Nullable<decimal> N_BHG_WGT_OUT { get; set; }
        public Nullable<System.DateTime> D_SALE_TIME_MIN { get; set; }
        public Nullable<System.DateTime> D_SALE_TIME_MAX { get; set; }
        public Nullable<System.DateTime> D_PRODUCE_DATE_MIN { get; set; }
        public Nullable<System.DateTime> D_PRODUCE_DATE_MAX { get; set; }
        public Nullable<decimal> N_SLAB_XH_WGT { get; set; }
        public string C_SLAB_TYPE { get; set; }
        public string C_REMARK1 { get; set; }
        public string C_REMARK2 { get; set; }
        public string C_REMARK3 { get; set; }
        public string C_REMARK4 { get; set; }
        public string C_REMARK5 { get; set; }
        public string C_ITEM_ID { get; set; }
    }
}
