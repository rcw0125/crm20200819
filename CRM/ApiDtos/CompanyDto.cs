using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NF.MODEL;

namespace CRM.ApiDtos
{
    public class CompanyDto
    {

        /// <summary>
        /// 客户收货单位
        /// </summary>
        public List<Mod_TS_CUSTADDR> CustAddrList { get; set; }

        /// <summary>
        /// 客户开票单位
        /// </summary>
        public List<Mod_TS_CUSTOTCOMPANY> CustOtcList { get; set; }
    }
}