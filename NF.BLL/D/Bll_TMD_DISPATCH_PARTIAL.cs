

using NF.MODEL.D;
using System;
using System.Data;

namespace NF.BLL
{
    public partial class Bll_TMD_DISPATCH
    {
        /// <summary>
        /// 更新打印状态
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdatePrintStatus(string strWhere, int printStatus)
        {
            return dal.UpdatePrintStatus(strWhere, printStatus);
        }
        /// <summary>
        /// 更新打印状态
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateWWPrintStatus(string strWhere,  int printStatus)
        {
            return dal.UpdateWWPrintStatus(strWhere,  printStatus);
        }

        /// <summary>
        /// 添加打印批号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddRePrint(Mod_TMD_ZZS_REPRINT model)
        {
            return dal.AddRePrint(model);
        }

        public DataSet GetRePrintList(string strWhere)
        {
            return dal.GetRePrintList(strWhere);
        }
        public DataSet GetRePrintList(string strWhere, string status)
        {
            return dal.GetRePrintList(strWhere, status);
        }
        public bool UpdateReprint(string strCID, string remark, string udpateUser)
        {
            return dal.UpdateReprint(strCID, remark, udpateUser);
        }
        public bool UpdateWWReprint(string C_IDlist, string remark, string udpateUser)
        {
            return dal.UpdateWWReprint(C_IDlist, remark, udpateUser);
        }
        public bool UpdateWWVTAndAttor(string cer, string attoattestor, DateTime dt)
        {
            return dal.UpdateWWVTAndAttor(cer, attoattestor, dt);
        }
        public bool UpdateReprintRemark(string strWhere, string remark)
        {
            return dal.UpdateReprintRemark(strWhere, remark);
        }
        public DataSet GetCKDRePrintList(string strWhere)
        {
            return dal.GetCKDRePrintList(strWhere);
        }
        public DataSet GetCKDRePrintList(string strWhere, string status)
        {
            return dal.GetCKDRePrintList(strWhere, status);
        }
        public bool AddCKDPrint(Mod_TMD_CKD_REPRINT model)
        {
            return dal.AddCKDPrint(model);
        }
        public bool DeleteCkdRecord(string C_IDlist, string remark)
        {
            return dal.DeleteCkdRecord(C_IDlist, remark);
        }

        public DataSet ListPrintFyd(string fyd)
        {
            return dal.ListPrintFyd(fyd);
        }
    }
}
