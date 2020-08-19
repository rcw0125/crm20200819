using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class MENUDTO : BASEDTO
    {
        public MENUDTO() { menus = new List<MENUDTO>(); }
        public string id { get; set; }
        public string text { get; set; }
        public string icon { get; set; }
        public string url { get; set; }
        public List<MENUDTO> menus { get; set; }
    }
}
