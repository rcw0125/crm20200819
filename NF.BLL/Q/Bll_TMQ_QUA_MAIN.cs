using NF.DLL.Q;
using NF.MODEL;
using NF.MODEL.Q;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.BLL.Q
{
    public class Bll_TMQ_QUA_MAIN
    {
        Dal_TMQ_QUA_MAIN dal = new Dal_TMQ_QUA_MAIN();
        public bool Add(Mod_TMQ_QUA_MAIN model)
        {
            return dal.Add(model);
        }
        public bool Update(Mod_TMQ_QUA_MAIN model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新质量异议赔付金额与赔付日期
        /// </summary>
        /// <param name="N_AMOUNT"></param>
        /// <param name="DATE"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateMoneyAndDate(string N_AMOUNT, string DATE, string ID)
        {
            return dal.UpdateMoneyAndDate(N_AMOUNT, DATE, ID);
        }
        public bool Submit(Mod_TMQ_QUA_MAIN model)
        {
            return dal.Submit(model);
        }
        public bool Delete(string C_ID)
        {
            return dal.Delete(C_ID);
        }
        public bool DeleteList(string C_IDlist)
        {
            return dal.DeleteList(C_IDlist);
        }
        public Mod_TMQ_QUA_MAIN GetModel(string C_ID)
        {
            return dal.GetModel(C_ID);
        }
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public bool AddItem(Mod_TMQ_QUA_ITEM model)
        {
            return dal.AddItem(model);
        }
        public bool DeleteItem(string ID)
        {
            return dal.DeleteItem(ID);
        }
        public bool UpdateItem(Mod_TMQ_QUA_ITEM model)
        {
            return dal.UpdateItem(model);
        }
        public bool AddListItem(List<Mod_TMQ_QUA_ITEM> list, string parentID)
        {
            return dal.AddListItem(list, parentID);
        }
        public DataSet GetItemList(string strWhere)
        {
            return dal.GetItemList(strWhere);
        }
        public bool UpdateSumWgt(string parentId)
        {
            return dal.UpdateSumWgt(parentId);
        }
        public DataSet ListArea()
        {
            return dal.ListArea();
        }

        /// <summary>
        /// 质量异议送审
        /// </summary>
        /// <param name="modFile">文件</param>
        /// <param name="modNextEmp">步骤操作人</param>
        /// <returns></returns>
        public bool ApproveQua(Mod_TMF_FILEINFO modFile, Mod_TMB_FILE_NEXT_EMP modNextEmp)
        {
            return dal.ApproveQua(modFile, modNextEmp);
        }

        /// <summary>
        /// 更新质量批号物料编码/生产日期
        /// </summary>
        public void UpdateMatCode()
        {
            dal.UpdateMatCode();
        }
    }
}
