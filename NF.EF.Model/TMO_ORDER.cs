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
    
    public partial class TMO_ORDER
    {
        public string C_ID { get; set; }
        public string C_ORDER_NO { get; set; }
        public string C_CON_NO { get; set; }
        public string C_CON_NAME { get; set; }
        public string C_AREA { get; set; }
        public string C_CUST_NO { get; set; }
        public string C_CUST_NAME { get; set; }
        public string C_SALE_CHANNEL { get; set; }
        public string C_CURRENCYTYPEID { get; set; }
        public string C_RECEIPTAREAID { get; set; }
        public string C_RECEIVEADDRESS { get; set; }
        public string C_RECEIPTCORPID { get; set; }
        public string C_PROD_NAME { get; set; }
        public string C_PROD_KIND { get; set; }
        public string C_INVBASDOCID { get; set; }
        public string C_INVENTORYID { get; set; }
        public string C_MAT_CODE { get; set; }
        public string C_MAT_NAME { get; set; }
        public string C_STL_GRD { get; set; }
        public string C_SPEC { get; set; }
        public string C_TECH_PROT { get; set; }
        public string C_FREE1 { get; set; }
        public string C_FREE2 { get; set; }
        public string C_PACK { get; set; }
        public string C_STD_CODE { get; set; }
        public string C_DESIGN_NO { get; set; }
        public string C_STDID { get; set; }
        public string C_DESIGNID { get; set; }
        public string C_VDEF1 { get; set; }
        public string C_PRO_USE { get; set; }
        public string C_CUST_SQ { get; set; }
        public string C_FUNITID { get; set; }
        public string C_UNITID { get; set; }
        public Nullable<decimal> N_HSL { get; set; }
        public Nullable<decimal> N_FNUM { get; set; }
        public Nullable<decimal> N_WGT { get; set; }
        public Nullable<decimal> N_PROFIT { get; set; }
        public Nullable<decimal> N_COST { get; set; }
        public Nullable<decimal> N_TAXRATE { get; set; }
        public Nullable<decimal> N_ORIGINALCURPRICE { get; set; }
        public Nullable<decimal> N_ORIGINALCURTAXPRICE { get; set; }
        public Nullable<decimal> N_ORIGINALCURTAXMNY { get; set; }
        public Nullable<decimal> N_ORIGINALCURMNY { get; set; }
        public Nullable<decimal> N_ORIGINALCURSUMMNY { get; set; }
        public Nullable<System.DateTime> D_NEED_DT { get; set; }
        public Nullable<System.DateTime> D_DELIVERY_DT { get; set; }
        public Nullable<System.DateTime> D_DT { get; set; }
        public short N_STATUS { get; set; }
        public Nullable<long> N_TYPE { get; set; }
        public Nullable<short> N_FLAG { get; set; }
        public short N_EXEC_STATUS { get; set; }
        public Nullable<short> N_USER_LEV { get; set; }
        public string C_LEV { get; set; }
        public string C_ORDER_LEV { get; set; }
        public string C_REMARK { get; set; }
        public string C_EMP_ID { get; set; }
        public string C_EMP_NAME { get; set; }
        public System.DateTime D_MOD_DT { get; set; }
        public decimal N_SLAB_MATCH_WGT { get; set; }
        public decimal N_LINE_MATCH_WGT { get; set; }
        public decimal N_PROD_WGT { get; set; }
        public decimal N_WARE_WGT { get; set; }
        public decimal N_WARE_OUT_WGT { get; set; }
        public Nullable<decimal> N_MACH_WGT { get; set; }
        public string C_ISSUE_EMP_ID { get; set; }
        public string C_PRD_EMP_ID { get; set; }
        public string C_DESIGN_PROG { get; set; }
        public decimal N_SMS_PROD_WGT { get; set; }
        public string C_SMS_PROD_EMP_ID { get; set; }
        public Nullable<System.DateTime> D_SMS_PROD_DT { get; set; }
        public decimal N_ROLL_PROD_WGT { get; set; }
        public string C_ROLL_PROD_EMP_ID { get; set; }
        public Nullable<System.DateTime> D_STL_ROL_DT { get; set; }
        public string C_LINE_NO { get; set; }
        public string C_CCM_NO { get; set; }
        public Nullable<decimal> N_ISSUE_WGT { get; set; }
        public string C_RH { get; set; }
        public string C_LF { get; set; }
        public string C_KP { get; set; }
        public int N_HL_TIME { get; set; }
        public string C_HL { get; set; }
        public int N_DFP_HL_TIME { get; set; }
        public string C_DFP_HL { get; set; }
        public string C_XM { get; set; }
        public string C_ROUTE { get; set; }
        public string C_MATRL_CODE_SLAB { get; set; }
        public string C_MATRL_NAME_SLAB { get; set; }
        public string C_SLAB_SIZE { get; set; }
        public Nullable<long> N_SLAB_LENGTH { get; set; }
        public Nullable<decimal> N_SLAB_PW { get; set; }
        public string C_MATRL_CODE_KP { get; set; }
        public string C_MATRL_NAME_KP { get; set; }
        public string C_KP_SIZE { get; set; }
        public Nullable<long> N_KP_LENGTH { get; set; }
        public Nullable<decimal> N_KP_PW { get; set; }
        public Nullable<decimal> N_GROUP { get; set; }
        public Nullable<decimal> N_SORT { get; set; }
        public string C_XC { get; set; }
        public string C_SL { get; set; }
        public string C_WL { get; set; }
        public string C_SFPJ { get; set; }
        public string C_TRANSMODE { get; set; }
        public Nullable<decimal> N_MACH_WGT_CCM { get; set; }
        public string C_XGID { get; set; }
        public Nullable<decimal> N_ZJCLS { get; set; }
        public string C_BY1 { get; set; }
        public string C_BY2 { get; set; }
        public string C_BY3 { get; set; }
        public string C_BY4 { get; set; }
        public string C_BY5 { get; set; }
        public string C_NC_ID { get; set; }
        public string C_LGJH { get; set; }
        public string C_ZLDJ_ID { get; set; }
        public string C_ZL_ID { get; set; }
        public string C_LF_ID { get; set; }
        public string C_RH_ID { get; set; }
        public Nullable<decimal> N_SLAB_WIDTH { get; set; }
        public Nullable<decimal> N_SLAB_THICK { get; set; }
        public Nullable<decimal> N_DIAMETER { get; set; }
        public Nullable<System.DateTime> D_NC_DATE { get; set; }
        public string C_YWY { get; set; }
        public string C_NC_SALECODE { get; set; }
        public string C_TRANSMODEID { get; set; }
        public string C_DFP_RZ { get; set; }
        public string C_RZP_RZ { get; set; }
        public string C_DFP_YQ { get; set; }
        public string C_RZP_YQ { get; set; }
        public string C_XM_YQ { get; set; }
        public Nullable<int> N_JRL_WD { get; set; }
        public Nullable<int> N_JRL_SJ { get; set; }
        public Nullable<int> N_KPJRL_WD { get; set; }
        public Nullable<int> N_KPJRL_SJ { get; set; }
        public Nullable<decimal> N_TSL { get; set; }
        public string C_ROLL_CODE { get; set; }
        public string C_CCM_CODE { get; set; }
        public string C_ROLL_DESC { get; set; }
        public string C_CCM_DESC { get; set; }
        public string C_TL { get; set; }
        public Nullable<decimal> N_ZJCLS_MIN { get; set; }
        public Nullable<decimal> N_ZJCLS_MAX { get; set; }
        public string C_NCSTATUS { get; set; }
        public string C_PCLX { get; set; }
        public string C_STL_GRD_TYPE { get; set; }
        public Nullable<System.DateTime> D_NS_SEND_DT { get; set; }
        public string C_ORDER_NO_OLD { get; set; }
        public string C_STL_GRD_SLAB { get; set; }
        public string C_STD_CODE_SLAB { get; set; }
        public string C_PCTBEMP { get; set; }
        public Nullable<System.DateTime> D_PCTBTS { get; set; }
        public string C_SFJK { get; set; }
        public string C_STL_GRD_CLASS { get; set; }
        public Nullable<long> N_LENGTH { get; set; }
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
        public Nullable<decimal> N_SLAB_XC_WGT { get; set; }
        public Nullable<decimal> N_ROLL_XC_WGT { get; set; }
        public Nullable<System.DateTime> D_OLD_DATE { get; set; }
        public Nullable<decimal> N_ROLL_WGT { get; set; }
        public string C_REMARK1 { get; set; }
        public string C_REMARK2 { get; set; }
        public string C_REMARK3 { get; set; }
        public string C_REMARK4 { get; set; }
        public string C_REMARK5 { get; set; }
        public Nullable<System.DateTime> D_SC_MOD_DT { get; set; }
        public Nullable<decimal> N_SLAB_XH_WGT { get; set; }
        public string C_SLAB_TYPE { get; set; }
        public Nullable<System.DateTime> D_OLD_NEED_DATE { get; set; }
        public Nullable<System.DateTime> D_PJ_DATE { get; set; }
        public Nullable<System.DateTime> D_DATE_BY1 { get; set; }
        public Nullable<System.DateTime> D_DATE_BY2 { get; set; }
        public Nullable<System.DateTime> D_DATE_BY3 { get; set; }
        public Nullable<System.DateTime> D_DATE_BY4 { get; set; }
        public Nullable<System.DateTime> D_DATE_BY5 { get; set; }
        public Nullable<System.DateTime> D_DATE_BY6 { get; set; }
        public Nullable<short> N_CLOSE_ORDER { get; set; }
    }
}
