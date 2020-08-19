using System;
using System.Collections.Generic;

namespace NF.Framework
{
    public class PageResult<T>
    {
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPageNum { get; set; }
        public int PageBegin { get; set; }
        public int PageEnd { get; set; }
        public List<T> DataList { get; set; }
    }
}
