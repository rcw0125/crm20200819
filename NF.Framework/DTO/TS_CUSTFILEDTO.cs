using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NF.Framework.DTO
{
    public class TS_CUSTFILEDTO : BASEDTO
    {
        /// <summary>
        /// 编号
        /// </summary>
        [ScaffoldColumn(false)]
        [Display(Name = "编号")]
        public string C_ID { get; set; }

        [ScaffoldColumn(false)]
        public string C_NC_ID { get; set; }

        [ScaffoldColumn(false)]
        public string C_NC_M_ID { get; set; }

        /// <summary>
        /// 是否客户
        /// </summary>
        [Display(Name = "是否客户")]
        public int N_ISFLAG { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        [Display(Name = "客户编号")]
        public string C_NO { get; set; }

        /// <summary>
        /// 客商名称
        /// </summary>
        [Display(Name = "客商名称")]
        public string C_NAME { get; set; }

        /// <summary>
        /// 客商简称
        /// </summary>
        [Display(Name = "客商简称")]
        public string C_SHORNAME { get; set; }

        /// <summary>
        /// 地区分类
        /// </summary>
        [Display(Name = "地区分类")]
        public string C_AREATYPE { get; set; }

        /// <summary>
        /// 法定代表人
        /// </summary>
        [Display(Name = "法定代表人")]
        public string C_LEGALREPRES { get; set; }

        /// <summary>
        /// 委托代理人
        /// </summary>
        [Display(Name = "委托代理人")]
        public string C_AGENT { get; set; }

        /// <summary>
        /// 经办人
        /// </summary>
        [Display(Name = "经办人")]
        public string C_OPERATOR { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [Display(Name = "传真")]
        public string C_FAX { get; set; }

        /// <summary>
        /// 纳税人登记号
        /// </summary>
        [Display(Name = "纳税人登记号")]
        public string C_TAXPAYERNO { get; set; }

        /// <summary>
        /// 客户级别
        /// </summary>
        [Display(Name = "客户级别")]
        public short N_LEVEL { get; set; }

        /// <summary>
        /// 客户状态
        /// </summary>
        [Display(Name = "客户状态")]
        public short N_STATUS { get; set; }

        /// <summary>
        /// 客户类别
        /// </summary>
        [Display(Name = "客户类别")]
        public int N_TYPE { get; set; }

        public string C_EXTEND1 { get; set; }
        public string C_EXTEND2 { get; set; }
        public string C_EXTEND3 { get; set; }
        public string C_EXTEND4 { get; set; }
        public string C_EXTEND5 { get; set; }


        [Display(Name = "是否GPS")]
        public int N_ISGPS { get; set; }

        public List<TS_CUSTFILEDTO> CustFiles { get; set; }

        public TS_CUSTADDRDTO CustAddr { get; set; }

        public List<SelectListItem> AreaMaxs { get; set; }

        /// <summary>
        /// 客户地址
        /// </summary>
        public List<TS_CUSTADDRDTO> CustAddrs { get; set; }

        /// <summary>
        /// 开票信息
        /// </summary>
        public List<TS_CUSTOTCOMPANYDTO> CustTots { get; set; }


        /// <summary>
        /// 区域
        /// </summary>
        public string C_AREAMMAX { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Msg { get; set; }

    }
}
