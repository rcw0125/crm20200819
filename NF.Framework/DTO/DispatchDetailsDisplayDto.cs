using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class DispatchDetailsDisplayDto
    {
        public string No { get; set; }

        public string OrderNo { get; set; }

        public string Grd { get; set; }

        public string Spec { get; set; }

        public string Free { get; set; }

        public string Free2 { get; set; }

        public string Pack { get; set; }

        public string QUALIRY_LEV { get; set; }

        public string MatCode { get; set; }

        public string MatName { get; set; }

        public int Qua { get; set; }

        public decimal? Wgt { get; set; }

        public int? OperationQua { get; set; }
        public int? OperationQuaValue { get; set; }

        public int? SupOperationQua { get; set; }
        public int? SupOperationQuaValue { get; set; }

        public string BatchNo { get; set; }
        public string Stove { get; set; }
        public string Area { get; set; }
        public string OldArea { get; set; }


        public DispatchDetailsDisplayDto()
        {
            OperationQua = 0;
            OperationQuaValue = 0;
        }

    }
}
