using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.ApiDtos
{
    /// <summary>
    /// 产、销报表
    /// </summary>
    public class Prod_Sale_Dto
    {
        /// <summary>
        /// 钢坯产量
        /// </summary>
        public List<ModCX> ProdSlabList { set; get; }

        /// <summary>
        /// 线材产量
        /// </summary>
        public List<ModCX> ProdRollList { set; get; }

        /// <summary>
        /// 销售发运方式
        /// </summary>
        public List<ModCX> SaleShipList { set; get; }

        /// <summary>
        /// 销售线材
        /// </summary>
        public List<ModCX> SaleRollList { set; get; }

        /// <summary>
        /// 销售钢坯
        /// </summary>
        public List<ModCX> SaleSlabList { set; get; }
    }

    /// <summary>
    /// 产量
    /// </summary>
    public class ModCX
    {

        /// <summary>
        /// 产品
        /// </summary>
        public string C_TYPE { set; get; }

        //日产、销量
        public string N_WGT_DAY { set; get; }
        /// <summary>
        /// 月产、销量
        /// </summary>
        public string N_WGT_MONTH { set; get; }

        /// <summary>
        /// 库存量
        /// </summary>
        public string N_WGT_CK { set; get; }

        public string FLAG { set; get; }
    }
}