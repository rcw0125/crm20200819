using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class TS_CUSTADDRDTO : BASEDTO
    {
        /// <summary>
        /// 编号
        /// </summary>
        [ScaffoldColumn(false)]
        [Display(Name = "编号")]
        public string C_ID { get; set; }

        /// <summary>
        /// 客户档案主键
        /// </summary>
        [Display(Name = "客户档案主键")]
        public string C_CUST_ID { get; set; }

        /// <summary>
        /// 收货公司
        /// </summary>
        [Display(Name = "收货公司")]
        [Required(ErrorMessage = "收货公司不能为空。")]
        public string C_CGC { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        [Display(Name = "收货地址")]
        [Required(ErrorMessage = "收货地址不能为空。")]
        public string C_CGADDR { get; set; }

        /// <summary>
        /// 收货地区
        /// </summary>
        [Display(Name = "收货地区")]
        public string C_CGAREA { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        [Display(Name = "收货人")]
        [Required(ErrorMessage = "收货人不能为空。")]
        public string C_CGMAN { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        [Display(Name = "邮政编码")]
        [StringLength(6, ErrorMessage = "请输入正确邮政编码")]
        public string C_POSTCODE { get; set; }

        /// <summary>
        /// 收货电话
        /// </summary>
        [Display(Name = "收货电话")]
        [RegularExpression(@"^(13[0-9]|15[0|3|6|7|8|9]|18[8|9])\d{8}$",
           ErrorMessage = "格式不正确。")]
        public string C_CGMOBILE { get; set; }

        /// <summary>
        /// 收货电话2
        /// </summary>
        [Display(Name = "收货电话2")]
        [RegularExpression(@"^(13[0-9]|15[0|3|6|7|8|9]|18[8|9])\d{8}$",
                  ErrorMessage = "格式不正确。")]
        public string C_CGMOBILE2 { get; set; }

        /// <summary>
        /// 是否默认
        /// </summary>
        [Display(Name = "是否默认")]
        public int N_ISDEFAULT { get; set; }

        public List<TS_CUSTADDRDTO> Addrs { get; set; }
    }
}
