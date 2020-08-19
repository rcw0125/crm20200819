using System;
namespace NF.MODEL
{
    public class CommonKC
    {
        /// <summary>
        /// id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 物料号
        /// </summary>
        public string mat { get; set; }
        /// <summary>
        /// 仓库
        /// </summary>
        public string ck { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public string qy { get; set; }
        /// <summary>
        /// 库位
        /// </summary>
        public string kw { get; set; }
        /// <summary>
        ///表判等级
        /// </summary>
        public string bpdj { get; set; }
        /// <summary>
        /// 质量等级
        /// </summary>
        public string zldj { get; set; }
        /// <summary>
        /// 包装要求
        /// </summary>
        public string bzyq { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string batch { get; set; }
        /// <summary>
        /// 炉号
        /// </summary>
        public string stove { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int num { get; set; }
    }
}
