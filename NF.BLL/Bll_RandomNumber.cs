using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NF.DAL;

namespace NF.BLL
{
    public class Bll_RandomNumber
    {
        private readonly Dal_RandomNumber dal = new Dal_RandomNumber();


        /// <summary>
        ///  火运报备计划
        /// </summary>
        /// <returns></returns>
        public string GetTrainDayCode()
        {
            return dal.GetTrainDayCode();
        }

        /// <summary>
        ///  火运报备计划
        /// </summary>
        /// <returns></returns>
        public string GetTrainCode()
        {
            return dal.GetTrainCode();
        }

        /// <summary>
        ///  发运单单据号
        /// </summary>
        /// <returns></returns>
        public string CreateDispID()
        {
            return dal.CreateDispID();
        }
        /// <summary>
        /// 合同号
        /// </summary>
        /// <param name="area">区域代码</param>
        /// <returns></returns>
        public string CreateConNo(string area)
        {
            return dal.CreateConNo(area);
        }

        /// <summary>
        /// 需求订单号
        /// </summary>
        /// <param name="conNO"></param>
        /// <returns></returns>
        public string CreateNeedOrderNo(string conNO)
        {
            return dal.CreateNeedOrderNo(conNO);
        }

        /// <summary>
        /// 订单号
        /// </summary>
        /// <param name="conNO">合同号</param>
        /// <returns></returns>
        public string CreateOrderNo(string conNO)
        {
            return dal.CreateOrderNo(conNO);
        }

        /// <summary>
        /// 质证书号
        /// </summary>
        /// <returns></returns>
        public string GetZZS()
        {
            return dal.GetZZS();
        }

        /// <summary>
        /// 远程质证书号
        /// </summary>
        /// <returns></returns>
        public string GetZSH()
        {
            return dal.GetZSH();
        }
    }
}
