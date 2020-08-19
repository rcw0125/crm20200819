using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL.Dto
{
    public class WWBCBZ
    {
        public string BCNAME { get; set; }
        public string PK_WTID { get; set; }

        public bool Selected { get; set; } = false;
    }

    public class WWBZ
    {
        public string BZMC { get; set; }
        public string PK_PGAID { get; set; }

        public bool Selected { get; set; } = false;
    }
}
