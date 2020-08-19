using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NF.MODEL;

namespace CRM.ApiDtos
{
    public class OrderDto
    {
        public string count { get; set; }
        
        public List<Mod_TMO_CONDETAILS2> OrderList { get; set; }
    }
}