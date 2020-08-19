using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NF.MODEL;

namespace CRM.ApiDtos
{
    public class TechProtDto
    {
        /// <summary>
        /// 客户协议号
        /// </summary>
        public List<Mod_TB_STD_CONFIG> TechProtList { get; set; }

    }
}