using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TS_CUSTOTCOMPANYDTO : BASEDTO
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string C_ID { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        public string C_CUST_ID { get; set; }

        /// <summary>
        /// 开票单位
        /// </summary>
        [Required(ErrorMessage = "开票单位不能为空。")]
        public string C_OTCOMPANY { get; set; }

        /// <summary>
        /// 开户银行
        /// </summary>
      [Required(ErrorMessage = "开户银行不能为空。")]
        public string C_OPENBANK { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [Required(ErrorMessage = "账号不能为空。")]
        public string C_ACCOUNTBANK { get; set; }

        /// <summary>
        /// 是否默认
        /// </summary>
        public int N_ISDEFAULT { get; set; }


        public List<TS_CUSTOTCOMPANYDTO> Tots { get; set; }
    }
}
