using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class BASEDTO
    {

        public BASEDTO()
        {
            BasePage = new BASEPAGE();
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public int OperationType { get; set; }

        /// <summary>
        /// 执行结果
        /// </summary>
        public int ResultType { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 维护人ID
        /// </summary>
        [Display(Name = "维护人ID")]
        public string C_EMP_ID { get; set; }

        /// <summary>
        /// 维护人
        /// </summary>
        [Display(Name = "维护人")]
        public string C_EMP_NAME { get; set; }

        /// <summary>
        /// 维护时间
        /// </summary>
        [Display(Name = "维护时间")]
        public DateTime? D_MOD_DT { get; set; }

        public BASEPAGE BasePage { get; set; }

    }

    public class BASEPAGE
    {
        private int _pageIndex = 1;
        private int _pageSize = 10;

        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public int TotalCount { get; set; }

        public int TotalPageNum { get; set; }

        public int PageBegin { get; set; }

        public int PageEnd { get; set; }
    }

}
