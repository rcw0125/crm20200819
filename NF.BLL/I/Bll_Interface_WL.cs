using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// ReZJB_FYD
    /// </summary>
    public partial class Bll_Interface_WL
    {
        private readonly Dal_Interface_WL dal = new Dal_Interface_WL();
        /// <summary>
        /// 向NC发送发运单
        /// </summary>
        /// <param name="idstr">id字符串</param>
        /// <param name="fydid">发运单id</param>
        /// <returns>返回int类型 1为转入成功,等于0代码异常-1导入PCI中间表错误-2导入条码中间表错误</returns>
        public string SENDFYD(string fydid, string path)
        {
            return dal.SENDFYD(fydid, path);
        }
        /// <summary>
        /// 删除发运单中间表数据
        /// </summary>
        /// <param name="dh">发运单号</param>
        /// <returns></returns>
        public int DELFYD(string dh)
        {
            return dal.DELFYD(dh);
        }
        /// <summary>
        /// 更新发运单状态
        /// </summary>
        /// <param name="dh">发运单号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int UPFYDSTATUS(string dh, string status)
        {
            return dal.UPFYDSTATUS(dh, status);
        }
        /// <summary>
        /// 根据idstr更新钢坯库存状态
        /// </summary>
        /// <param name="idstr">库存钢坯id字符串</param>
        /// <returns></returns>
        public string GPFY(string dh)
        {
            return dal.GPFY(dh);
        }
        /// <summary>
        /// 更新钢坯库存状态
        /// </summary>
        /// <param name="dh">发运单号</param>
        /// <param name="type">状态</param>
        /// <param name="status">要变更的状态</param>
        /// <returns></returns>
        public int UPSLABSTATUS(string dh, string status)
        {
            return dal.UPSLABSTATUS(dh, status);
        }
        /// <summary>
        /// 发送发运单到中间表
        /// </summary>
        /// <param name="idstr">id字符串</param>
        /// <param name="fydid">要发送的发运单号</param>
        /// <returns>返回int类型 1转入成功-1发送失败</returns>
        public string ADDFYDToZJB(string fydid, DateTime dateTime)
        {
            return dal.ADDFYDToZJB(fydid, dateTime);
        }
        /// <summary>
        /// 根据发运单号获取发运单状态
        /// </summary>
        /// <param name="fydh">发运单</param>
        /// <returns></returns>
        public string GetFYDZT(string fydh)
        {
            return dal.GetFYDZT(fydh);
        }
    }
}
