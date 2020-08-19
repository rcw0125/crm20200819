using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
using NF.DLL;
using NF.MODEL.Dto;
using System.Linq;

namespace NF.BLL
{
    /// <summary>
    /// 轧钢实绩
    /// </summary>
    public partial class Bll_TRC_ROLL_PRODCUT
    {
        Dal_TRC_ROLL_WW_MAIN dalWWMain = new Dal_TRC_ROLL_WW_MAIN();
        Dal_TB_BCBZ dalBcBz = new Dal_TB_BCBZ();
        Dal_TMO_ORDER dalOrder = new Dal_TMO_ORDER();
        Dal_TB_STA dalTbSta = new Dal_TB_STA();
        Dal_TPB_LINEWH dalCK = new Dal_TPB_LINEWH();
        Dal_TRC_ROLL_ZKD dalzkd = new Dal_TRC_ROLL_ZKD();
        /// <summary>
        /// 获取线材，根据钢种及执行标准
        /// </summary>
        /// <param name="gz"></param>
        /// <param name="zxbz"></param>
        /// <returns></returns>
        public List<Mod_TRC_ROLL_PRODCUT> GetByGzAndZxbz(string gz, string zxbz, string spec, string lineCode)
        {
            string ww = "QE";
            string sqlWhere = $@"
1=1
AND C_LINEWH_CODE LIKE '68%' 
AND C_SPEC = '{spec}'
AND C_MOVE_TYPE='{ww}' 
AND C_MOVE_TYPE!='{"QS"}'  
AND C_STL_GRD='{gz}' 
AND C_STD_CODE='{zxbz}' ";

            if (string.IsNullOrEmpty(lineCode) == false)
            {
                sqlWhere += $" AND C_LINEWH_CODE='{lineCode}'";
            }

            return GetModelList(sqlWhere);
        }

        /// <summary>
        /// 获取委外仓库库存数据
        /// </summary>
        /// <param name="lineCode"></param>
        /// <param name="gz"></param>
        /// <param name="zxbz"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        public List<Mod_TRC_ROLL_PRODCUT> GetByWWCK(string lineCode, string gz, string zxbz, string spec, string bachno)
        {
            string sqlWhere = $"1=1 AND C_LINEWH_CODE = '{lineCode}' AND C_MOVE_TYPE IN('E','QE')";
            if (!string.IsNullOrEmpty(gz))
            {
                sqlWhere += $" AND C_STL_GRD='{gz}'";
            }
            if (!string.IsNullOrEmpty(zxbz))
            {
                sqlWhere += $" AND C_STD_CODE LIKE '%{zxbz}%'";
            }
            if (!string.IsNullOrEmpty(spec))
            {
                sqlWhere += $" AND C_SPEC = '%{spec}%'";
            }
            if (!string.IsNullOrEmpty(bachno))
            {
                sqlWhere += $" AND c_batch_no LIKE '%{bachno}%'";
            }

            return GetModelList(sqlWhere);
        }

        public List<ZKDInfoDto> GetWWZKD(string userId, string batchNo)
        {
            string sql = $@"
select 
--t.d_mod_dt,t.n_status, t.c_linewh_code,t.c_mblinewh_code,t.c_linewh_id,t.C_MBLINEWH_ID, 
t.*,t1.c_name as UserName from TRC_ROLL_ZKD t
left join ts_user t1 on t.c_emp_id = t1.c_id
where (t.c_linewh_code like '68%' or t.c_linewh_code like '16%') and (t.c_mblinewh_code like '68%' or t.c_mblinewh_code like '16%')
and t.n_status=3
";

            if (string.IsNullOrEmpty(userId) == false && userId != "D68C3BC7690F4E19A5BFE4424E176E88")
            {// 管理员可查询所有的
                sql += $"and t.c_emp_id='{userId}' ";
            }
            if (string.IsNullOrEmpty(batchNo) == false)
            {
                sql += $"and t.c_batch_no like '%{batchNo}%'";
            }

            return dalOrder.GetBySql(sql).DataTableToList2<ZKDInfoDto>();
        }

        /// <summary>
        /// 获取线材，根据钢种及执行标准
        /// </summary>
        /// <param name="gz"></param>
        /// <param name="zxbz"></param>
        /// <returns></returns>
        public List<Mod_TRC_ROLL_PRODCUT> GetByBatchNo(
            string batchNo,
            string gz,
            string zxbz,
            string wl,
            string inventoryCode,
            string zldj,
            string bzyq,
            bool all = false)
        {
            string ww = "QE";
            string allSql = string.Empty;
            if (all == true)
            {
                allSql = "OR C_MOVE_TYPE='E'";
            }
            string sqlWhere = $@"
1=1
AND (C_MOVE_TYPE='{ww}' {allSql}) 
AND C_MOVE_TYPE!='{"QS"}'
AND C_STL_GRD='{gz}' 
AND C_STD_CODE='{zxbz}'
AND C_BATCH_NO='{batchNo}'
AND C_MAT_CODE='{wl}' 
AND c_judge_lev_zh = '{zldj}' 
AND C_LINEWH_CODE='{inventoryCode}'
AND C_BZYQ='{bzyq}'";

            return GetModelList(sqlWhere);
        }

        /// <summary>
        /// 获取已组批数据
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        public List<Mod_TRC_ROLL_WW_MAIN> GetZPItems(string contractId)
        {
            var dbSet = dalWWMain.GetList($"C_ORD_ID='{contractId}' ORDER BY D_MOD_DT");

            var list = dbSet.Tables[0].DataTableToList2<Mod_TRC_ROLL_WW_MAIN>();

            return list;
        }

        public List<WWBCBZ> GetBc()
        {
            // 传入外委物料代码决定工序，获取ERP代码

            var mod_TB_STA = dalTbSta.GetModelByCODE(GetStaCode(""));

            var table = dalBcBz.GetNCBCList(mod_TB_STA.C_STA_ERPCODE, "").Tables[0];

            var current = dalBcBz.GetList(mod_TB_STA.C_PRO_ID, DateTime.Now).Tables[0];
            var currentBCName = current.Rows[0]["C_BC_NAME"].ToString();

            var list = table.DataTableToList2<WWBCBZ>();

            var currentItem = list.FirstOrDefault(w => w.BCNAME == currentBCName);
            if (currentItem != null) currentItem.Selected = true;

            return list;
        }

        public List<WWBZ> GetBz()
        {
            // 传入外委物料代码决定工序，获取ERP代码
            var mod_TB_STA = dalTbSta.GetModelByCODE(GetStaCode(""));

            var table = dalBcBz.GetNCBZList(mod_TB_STA.C_ERP_PK, "").Tables[0];

            var current = dalBcBz.GetList(mod_TB_STA.C_PRO_ID, DateTime.Now).Tables[0];
            var currentBCName = current.Rows[0]["C_BZ_NAME"].ToString();

            var list = table.DataTableToList2<WWBZ>();

            var currentItem = list.FirstOrDefault(w => w.BZMC == currentBCName);
            if (currentItem != null) currentItem.Selected = true;

            return list;
        }

        /// <summary>
        /// 委外仓库数据源
        /// </summary>
        /// <returns></returns>
        public List<Mod_TPB_LINEWH> GetWWCK()
        {
            return dalCK.GetList("C_LINEWH_CODE LIKE '68%' OR C_LINEWH_CODE LIKE '16%'  ORDER BY C_LINEWH_CODE").Tables[0].DataTableToList2<Mod_TPB_LINEWH>();
        }

        public static string GetStaCode(string mtrlCode)
        {
            if (mtrlCode.StartsWith("806"))
            {//不锈委外热处理（一）
                return "RCL";
            }
            else if (mtrlCode.StartsWith("807"))
            {//热处理委外酸洗一车间
                return "RCLSX";
            }
            else if (mtrlCode.StartsWith("805"))
            {//不锈钢委外酸洗一车间

                return "SX";
            }
            else
            {
                return "RCL";
            }
        }

        /// <summary>
        /// 获取NC库存数据
        /// </summary>
        /// <param name="lineWhCode"></param>
        /// <param name="gz"></param>
        /// <param name="zxbz"></param>
        /// <param name="gg"></param>
        /// <param name="searchBatchNo"></param>
        /// <returns></returns>
        public List<NCInventoryDto> GetNCInventory(
            string lineWhCode,
            string gz,
            string zxbz,
            string gg,
            string searchBatchNo)
        {
            return dalOrder.GetNCInventory(lineWhCode, gz, zxbz, gg, searchBatchNo);
        }


        /// <summary>
        /// 同步NC线材库存数据
        /// </summary>
        /// <param name="item"></param>
        /// <param name="userId"></param>
        public void SyncInventory(WWInventoryItem item, string userId)
        {
            // 首先查询NC数据，同步PCI
            // 步骤：验证PCI是否有数据，计算差量->同步（将总量分摊到每支上，保留4位小数）
            // C_SFOB=1 可在PCI系统同步性能成分

            var inventory = GetNCInventory(item.InventoryCode, item.Gz, item.Zxbz, item.Spec, item.BatchNo)
                .Where(w => w.StdCode == item.Zxbz)
                .Where(w => w.ZLDJ == item.ZLDJ)
                .Where(w => w.MtrlCode == item.MtrlCode)
                .Where(w => w.BZYQ == item.BZYQ).FirstOrDefault();

            if (inventory == null || inventory.Count == 0)
            {
                throw new Exception("NC数据不存在，请刷新页面重试");
            }

            // 暂不支持PCI有的数据同步
            if (inventory.PciCount > 0)
            {
                throw new Exception("PCI已存在数据，暂不支持同步");
            }

            var list = new List<Mod_TRC_ROLL_PRODCUT>();

            decimal avgAmt = Math.Round(inventory.Wgt / inventory.Count, 4);
            for (int i = 1; i <= inventory.Count; i++)
            {
                decimal wgt = avgAmt;
                if (i == inventory.Count)
                {
                    // 最后一只，计算余量
                    wgt = inventory.Wgt - avgAmt * (i - 1);
                }
                var mod = new Mod_TRC_ROLL_PRODCUT
                {
                    C_ID = $"{item.BatchNo}{(i).ToString("0000")}",
                    C_BATCH_NO = item.BatchNo,
                    N_WGT = wgt,
                    C_BZYQ = inventory.BZYQ,
                    //C_STA_ID = string.Empty,
                    //C_CON_NO = string.Empty,
                    //C_CUST_AREA =string.Empty,
                    //C_CUST_NAME = string.Empty,
                    //C_CUST_NO = string.Empty,
                    //C_DP_EMP_ID = string.Empty,
                    //C_DP_GROUP = string.Empty,
                    //C_DP_SHIFT = string.Empty,
                    //C_EMP_ID = string.Empty,
                    //C_FLOOR = string.Empty,
                    //C_GROUP = string.Empty,
                    C_ISFREE = "N",
                    C_IS_DEPOT = "Y",
                    C_JUDGE_LEV_ZH = inventory.ZLDJ,
                    C_LINEWH_CODE = inventory.InventoryCode,
                    C_MAT_CODE = inventory.MtrlCode,
                    C_MAT_DESC = inventory.MtrlName,
                    C_MOVE_TYPE = item.MoveType,
                    C_SPEC = inventory.Spec,
                    C_STD_CODE = inventory.StdCode,
                    C_STL_GRD = inventory.StlGrd,
                    C_STOVE = inventory.LuHao,
                    C_ZYX1 = inventory.zyx1,
                    C_ZYX2 = inventory.zyx2,
                    D_MOD_DT = DateTime.Now,
                    D_DP_DT = DateTime.Now,
                };
                list.Add(mod);
            }

            dalOrder.SyncInventory(list);
        }
    }
}

