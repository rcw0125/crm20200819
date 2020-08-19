using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TMQ_QUALITY_FILEDTO : BASEDTO
    {
        public string C_ID { get; set; }
        public string C_QUALITY_ID { get; set; }
        public string C_TITLE { get; set; }
        public string C_PATH { get; set; }
        public string C_REMARK { get; set; }
        public DateTime D_DT { get; set; }

        public List<TMQ_QUALITY_FILEDTO> Files;

        /// <summary>
        /// 操作状态
        /// </summary>
        public string OperationStatus { get; set; }
    }
}
