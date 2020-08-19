using NF.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.ApiDtos
{
    public class StationDto
    {
        /// <summary>
        /// 站点
        /// </summary>
        public List<Mod_TMB_AREA> StationList { get; set; }
    }
}