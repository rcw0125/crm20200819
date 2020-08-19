using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class DEPTDTO
    {
        public DEPTDTO() { nodes = new List<DEPTDTO>(); }
        public string id { get; set; }
        public string text { get; set; }
        public string code { get; set; }
        public List<DEPTDTO> nodes { get; set; }
    }
}
