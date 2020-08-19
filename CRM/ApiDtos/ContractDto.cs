using NF.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.ApiDtos
{
    public class ContractDto
    {

        #region 合同基本信息


        /// <summary>
        /// 货币
        /// </summary>
        public List<Mod_TS_DIC> CurrencyList { get; set; }

        /// <summary>
        /// 合同类型
        /// </summary>
        public List<Mod_TS_DIC> ConTypeList { get; set; }

        /// <summary>
        /// 发运方式
        /// </summary>
        public List<Mod_TS_DIC> ShipViaList { get; set; }


        /// <summary>
        /// 合同区域
        /// </summary>
        public List<Mod_TMB_AREAMAX> ConAreaList { get; set; }

      

        #endregion

    }
}