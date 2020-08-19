using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Collections;
using System.Collections.Generic;
using NF.MODEL;
using System.Linq;
using NF.MODEL.Dto;
using NF.DLL;
using System.IO;
using NF.DAL.I;

namespace NF.DAL
{
    /// <summary>
    /// 订单池
    /// </summary>
    public partial class Dal_TMO_ORDER
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetWWZP(string strWhere, string lineWhCode)
        {
            string sql = $@"
with t1 as (
select a1.c_stl_grd,a1.c_std_code,a1.c_spec,sum(a1.N_WGT) sum  from  TRC_ROLL_PRODCUT a1 where a1.c_move_type!='QS' AND a1.c_move_type='QE' 
{(string.IsNullOrEmpty(lineWhCode) == false ? $"and a1.c_linewh_code='{lineWhCode}'" : $"and a1.c_linewh_code like '68%'")}
group by a1.c_stl_grd,a1.c_std_code,a1.c_spec
), t2 as (
select a2.c_ord_id,sum(a2.N_WGT_TOTAL) sum from TRC_ROLL_WW_MAIN a2 group by a2.c_ord_id
)   
--select t1.* from t1  
select tt.sum SumWgt,tt2.sum as HasSumWgt,t.c_stl_grd,t.c_std_code,tt3.c_checkstate_name as ZLDJ, t.*  from  TMO_CON_ORDER t
left join t1 tt on t.c_stl_grd=tt.c_stl_grd and t.c_std_code=tt.c_std_code and t.c_spec=tt.c_spec 
left join t2 tt2 on t.C_ID = tt2.c_ord_id 
left join tqb_checkstate tt3 on t.c_vdef1=tt3.c_id and tt3.c_remark='1001'
where 1=1 and (t.c_mat_code like '805%' or t.c_mat_code like '806%' or t.c_mat_code like '807%')
";
            if (string.IsNullOrEmpty(strWhere) == false)
            {
                sql += " AND " + strWhere;
            }
            return DbHelperOra.Query(sql);
        }

        /// <summary>
        /// 获取工位ERP代码
        /// </summary>
        /// <param name="staCode"></param>
        /// <returns></returns>
        public string GetStaErpCode(string staCode)
        {
            string sql = $"SELECT MAX(C_STA_ERPCODE) FROM TB_STA WHERE C_STA_CODE='{staCode}'";
            return TransactionHelper.Query(sql).Tables[0].Rows[0][0]?.ToString();
        }

        public DataTable GetBySql(string sql)
        {
            return DbHelperOra.Query(sql).Tables[0];
        }

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="cId"></param>
        /// <param name="batchNo"></param>
        /// <param name="addItems"></param>
        public void AddCompreItem(string cId, string batchNo, List<Mod_TQC_COMPRE_ITEM_RESULT> addItems)
        {
            // 删除之前的成分
            TransactionHelper.BeginTransaction();
            try
            {
                TransactionHelper.ExecuteSql($"DELETE TQC_COMPRE_ITEM_RESULT WHERE C_BATCH_NO='{batchNo}'");
                foreach (var item in addItems)
                {
                    #region sql

                    string sql = $@"
INSERT INTO TQC_COMPRE_ITEM_RESULT(
C_ID
,C_STOVE
,C_BATCH_NO
,C_STL_GRD
,C_SPEC
,C_STD_CODE
,C_CHARACTER_ID
,C_ITEM_NAME
,C_TARGET_MIN
,C_TARGET_INTERVAL
,C_TARGET_MAX
,C_TYPE
,C_UNIT
,C_QUANTITATIVE
,C_VALUE
,C_RESULT
,C_CHECK_STATE
,N_STATUS
,C_REMARK
,C_EMP_ID
,D_MOD_DT
,C_DESIGN_NO
,N_PRINT_ORDER
,C_TICK_NO
,C_IS_SHOW
,C_IS_DECIDE
,C_GROUP
,C_TB)  
VALUES (
'{item.C_ID}'
,'{item.C_STOVE}'
,'{item.C_BATCH_NO}'
,'{item.C_STL_GRD}'
,'{item.C_SPEC}'
,'{item.C_STD_CODE}'
,'{item.C_CHARACTER_ID}'
,'{item.C_ITEM_NAME}'
,'{item.C_TARGET_MIN}'
,'{item.C_TARGET_INTERVAL}'
,'{item.C_TARGET_MAX}'
,'{item.C_TYPE}'
,'{item.C_UNIT}'
,'{item.C_QUANTITATIVE}'
,'{item.C_VALUE}'
,'{item.C_RESULT}'
,'{item.C_CHECK_STATE}'
,'{item.N_STATUS}'
,'{item.C_REMARK}'
,'{item.C_EMP_ID}'
,to_date('{item.D_MOD_DT}','yyyy-mm-dd hh24:mi:ss')
,'{item.C_DESIGN_NO}'
,'{item.N_PRINT_ORDER}'
,'{item.C_TICK_NO}'
,'{item.C_IS_SHOW}'
,'{item.C_IS_DECIDE}'
,'{item.C_GROUP}'
,'{item.C_TB}')
";

                    #endregion

                    var a = TransactionHelper.ExecuteSql(sql);

                    if (a <= 0)
                    {
                        throw new Exception("操作失败");
                    }

                }

                TransactionHelper.Commit();
            }
            catch
            {
                TransactionHelper.RollBack();
                throw new Exception("操作失败，请联系管理员");
            }
        }

        Dal_TRC_ROLL_ZKD dalZkd = new Dal_TRC_ROLL_ZKD();
        Dal_TB_MATRL_MAIN dal_TB_MATRL_MAIN = new Dal_TB_MATRL_MAIN();
        Dal_Interface_NC_Roll_ZK4I dal_zk4i = new Dal_Interface_NC_Roll_ZK4I();
        Dal_Interface_NC_Roll_ZK4A dal_zk4a = new Dal_Interface_NC_Roll_ZK4A();
        //NF.DAL.I.Dal_Interface_FR bll_Interface_FR = new NF.DAL.I.Dal_Interface_FR();

        /// <summary>
        /// 转矩操作
        /// </summary>
        /// <param name="lineCode">目标仓库</param>
        /// <param name="inventoryItems">转库数据</param>
        public void SaveInventory2(string lineCode, List<WWInventoryItem> inventoryItems)
        {
            List<string> zkIds = new List<string>();
            TransactionHelper.BeginTransaction();
            try
            {

                foreach (var item in inventoryItems)
                {
                    string sql = $@"
select t.*  from  TRC_ROLL_PRODCUT T
WHERE T.C_BATCH_NO='{item.BatchNo}' AND T.C_STL_GRD='{item.Gz}' AND T.C_STD_CODE='{item.Zxbz}'
AND T.C_SPEC='{item.Spec}'
AND T.C_LINEWH_CODE = '{item.InventoryCode}'
";
                    // 验证库存是否足够
                    var list = TransactionHelper.Query(sql).Tables[0].DataTableToList2<Mod_TRC_ROLL_PRODCUT>();

                    if (list.Count < item.Number)
                    {
                        throw new Exception("库存不够，不能转库");
                    }

                    foreach (var pItem in list.Take(item.Number))
                    {
                        // 设置转库及未上传NC状态
                        TransactionHelper.ExecuteSql($"UPDATE TRC_ROLL_PRODCUT SET " +
                            $"C_LINEWH_CODE='{lineCode}',C_IS_TB='N' WHERE C_ID='{pItem.C_ID}'");
                    }

                    // 订单物料信息
                    var mtrlItem = dal_TB_MATRL_MAIN.GetModel(item.MtrlCode);
                    var batchItem = list.FirstOrDefault();


                    string zkd = (DateTime.Now.Year.ToString().Substring(2, 2)) + (Convert.ToInt32(DateTime.Now.Month) > 9 ? DateTime.Now.Month.ToString() : ("0" + DateTime.Now.Month.ToString())) + (Convert.ToInt32(DateTime.Now.Day) > 9 ? DateTime.Now.Day.ToString() : ("0" + DateTime.Now.Day.ToString()));//转库单号
                    string maxzkd = GetZKDNO(zkd);//查询当天最大转库单号
                    long no = 0;
                    if (maxzkd == "0")
                    {
                        no = Convert.ToInt64(zkd + "0001");
                    }
                    else
                    {
                        no = Convert.ToInt64(maxzkd.Substring(2, maxzkd.Length - 2)) + 1;
                    }
                    zkd = "ZK" + no;

                    var zkId = zkd;
                    zkIds.Add(zkId);

                    // 转换仓库code为ID
                    string getLinewhId = "select t.C_ID from TPB_LINEWH T WHERE T.C_LINEWH_CODE='{0}'";
                    var targetLinewhId = TransactionHelper.GetSingle(string.Format(getLinewhId, lineCode)) as string;
                    var lineWhId = TransactionHelper.GetSingle(string.Format(getLinewhId, item.InventoryCode)) as string;

                    dalZkd.Add(new Mod_TRC_ROLL_ZKD
                    {
                        C_BATCH_NO = item.BatchNo,
                        C_BZYQ = item.BZYQ,
                        C_EMP_ID = "1001NC100000002SS9XB",
                        C_F_DW = mtrlItem.C_PK_MEASDOC,
                        C_JUDGE_LEV_ZH = batchItem.C_JUDGE_LEV_ZH,
                        C_LINEWH_CODE = item.InventoryCode,
                        C_MAT_CODE = item.MtrlCode,
                        C_MAT_DESC = batchItem.C_MAT_DESC,
                        C_MBLINEWH_CODE = lineCode,
                        C_SPEC = batchItem.C_SPEC,
                        C_STL_GRD = batchItem.C_STL_GRD,
                        C_STOVE = batchItem.C_STOVE,
                        C_ZKD_NO = zkId,//转库单号
                        C_ZYX1 = batchItem.C_ZYX1,
                        C_ZYX2 = batchItem.C_ZYX2,
                        C_ZYX4 = batchItem.C_STD_CODE,
                        C_Z_DW = mtrlItem.C_PK_MEASDOC,
                        D_MOD_DT = DateTime.Now,
                        D_PRODUCE_DATE = batchItem.D_MOD_DT,
                        N_NUM = item.Number,
                        N_STATUS = 1,
                        N_WGT = list.Take(item.Number).Sum(w => w.N_WGT),
                        C_LINEWH_ID = lineWhId,
                        C_MBLINEWH_ID = targetLinewhId,

                    }, true);
                }

                TransactionHelper.Commit();
            }
            catch (Exception ex)
            {
                TransactionHelper.RollBack();
                throw ex;
            }

            // 发送NC
            foreach (var item in zkIds)
            {
                string directory = $"{AppDomain.CurrentDomain.BaseDirectory}";
                if (Directory.Exists(directory) == false)
                {
                    Directory.CreateDirectory(directory);
                }
                var result4i = dal_zk4i.SendXml_GP(directory, item);
                var result4a = dal_zk4a.SendXml_GP(directory, item);

                if (result4i != "1")
                {
                    throw new Exception(GetNCError(result4i));
                }
                if (result4a != "1")
                {
                    throw new Exception(GetNCError(result4a));
                }
            }

        }

        private List<string> GetZKId(int count)
        {
            string zkd = (DateTime.Now.Year.ToString().Substring(2, 2)) + (Convert.ToInt32(DateTime.Now.Month) > 9 ? DateTime.Now.Month.ToString() : ("0" + DateTime.Now.Month.ToString())) + (Convert.ToInt32(DateTime.Now.Day) > 9 ? DateTime.Now.Day.ToString() : ("0" + DateTime.Now.Day.ToString()));//转库单号
            string maxzkd = GetZKDNO(zkd);//查询当天最大转库单号
            long no = 0;
            if (maxzkd == "0")
            {
                no = Convert.ToInt64(zkd + "0001");
            }
            else
            {
                no = Convert.ToInt64(maxzkd.Substring(2, maxzkd.Length - 2)) + 1;
            }

            var list = new List<string>();
            for (int i = 0; i < count; i++)
            {
                list.Add($"ZK{no + i}");
            }

            return list;
        }

        public void SaveInventory2(string lineCode, List<WWInventoryItem> inventoryItems, string userId)
        {
            List<string> zkIds = new List<string>();
            // 转库单ID对应的转库数据
            Dictionary<string, List<Mod_TRC_ROLL_PRODCUT>> dic = new Dictionary<string, List<Mod_TRC_ROLL_PRODCUT>>();
            TransactionHelper.BeginTransaction();
            try
            {
                var arrZkId = GetZKId(inventoryItems.Count);

                // 验证
                foreach (var item in inventoryItems)
                {
                    List<Mod_TRC_ROLL_PRODCUT> list = new List<Mod_TRC_ROLL_PRODCUT>();

                    string sql = $@"
select t.*  from  TRC_ROLL_PRODCUT T
WHERE T.C_BATCH_NO='{item.BatchNo}' AND T.C_STL_GRD='{item.Gz}' AND T.C_STD_CODE='{item.Zxbz}'
AND T.C_SPEC='{item.Spec}'
AND T.c_judge_lev_zh = '{item.ZLDJ}' 
AND T.C_LINEWH_CODE = '{item.InventoryCode}'
";
                    list.AddRange(DbHelperOra.Query(sql).Tables[0].DataTableToList2<Mod_TRC_ROLL_PRODCUT>());

                    // 验证库存是否足够
                    if (list.Count < item.Number)
                    {
                        throw new Exception("库存不够，不能转库");
                    }

                    if (list.Count > item.Number && list.Sum(w => w.N_WGT) <= item.Amt)
                    {
                        throw new Exception("库存量不够，请确认支数与重量");
                    }

                    if (list.Count == item.Number)
                    {
                        // 如果全部转库，则转库总重量等于库存重量
                        item.Amt = list.Sum(w => w.N_WGT);
                    }
                    else
                    {
                        // 更新库存量（将支数与转库的重量分摊到每支上重新计算结余的重量）
                        UpdateInventory(list, item.Amt, item.Number);
                    }

                    // 订单物料信息
                    var mtrlItem = dal_TB_MATRL_MAIN.GetModel(item.MtrlCode);
                    var batchItem = list.FirstOrDefault();


                    var zkId = arrZkId[inventoryItems.IndexOf(item)];
                    zkIds.Add(zkId);

                    // 转换仓库code为ID
                    string getLinewhId = "select t.C_ID from TPB_LINEWH T WHERE T.C_LINEWH_CODE='{0}'";
                    var targetLinewhId = TransactionHelper.GetSingle(string.Format(getLinewhId, lineCode)) as string;
                    var lineWhId = TransactionHelper.GetSingle(string.Format(getLinewhId, item.InventoryCode)) as string;

                    if (string.IsNullOrEmpty(userId))
                    {
                        userId = "1001NC100000002SS9XB";
                    }

                    // 添加转库单
                    dalZkd.Add(new Mod_TRC_ROLL_ZKD
                    {
                        C_BATCH_NO = item.BatchNo,
                        C_BZYQ = item.BZYQ,
                        C_EMP_ID = userId,
                        C_F_DW = mtrlItem.C_PK_MEASDOC,
                        C_JUDGE_LEV_ZH = batchItem.C_JUDGE_LEV_ZH,
                        C_LINEWH_CODE = item.InventoryCode,
                        C_MAT_CODE = item.MtrlCode,
                        C_MAT_DESC = batchItem.C_MAT_DESC,
                        C_MBLINEWH_CODE = lineCode,
                        C_SPEC = batchItem.C_SPEC,
                        C_STL_GRD = batchItem.C_STL_GRD,
                        C_STOVE = batchItem.C_STOVE,
                        C_ZKD_NO = zkId,//转库单号
                        C_ZYX1 = batchItem.C_ZYX1,
                        C_ZYX2 = batchItem.C_ZYX2,
                        C_ZYX4 = batchItem.C_STD_CODE,
                        C_Z_DW = mtrlItem.C_PK_MEASDOC,
                        D_MOD_DT = DateTime.Now,
                        D_PRODUCE_DATE = batchItem.D_MOD_DT,
                        N_NUM = item.Number,
                        N_STATUS = 1,
                        N_WGT = item.Amt,//list.Take(item.Number).Sum(w => w.N_WGT),
                        C_LINEWH_ID = lineWhId,
                        C_MBLINEWH_ID = targetLinewhId,

                    }, true);
                    dic.Add(zkId, list);
                }

                TransactionHelper.Commit();
            }
            catch (Exception ex)
            {
                TransactionHelper.RollBack();
                throw ex;
            }

            // 发送NC
            foreach (var item in zkIds)
            {
                var zkdItem = dalZkd.GetListBydh(item).Tables[0].DataTableToList2<Mod_TRC_ROLL_ZKD>().FirstOrDefault();
                try
                {
                    string directory = $"{AppDomain.CurrentDomain.BaseDirectory}";
                    if (Directory.Exists(directory) == false)
                    {
                        Directory.CreateDirectory(directory);
                    }
                    var result4i = dal_zk4i.SendXml_GP(directory, item);
                    var result4a = dal_zk4a.SendXml_GP(directory, item);

                    if (result4i != "1")
                    {
                        throw new Exception(GetNCError(result4i));
                    }
                    if (result4a != "1")
                    {
                        throw new Exception(GetNCError(result4a));
                    }
                }
                catch (Exception ex)
                {
                    // 上传NC异常删除转库单
                    dalZkd.Delete(zkdItem.C_ID);
                    throw new Exception(ex.Message);
                }

                foreach (var pItem in dic[zkdItem.C_ZKD_NO].Take((int)(zkdItem.N_NUM ?? 0)))
                {
                    // 设置转库及未上传NC状态
                    DbHelperOra.ExecuteSql($"UPDATE TRC_ROLL_PRODCUT SET " +
                        $"C_LINEWH_CODE='{lineCode}',C_IS_TB='N' WHERE C_ID='{pItem.C_ID}'");
                }
            }

        }

        /// <summary>
        /// 转库操作，分摊重量到每一支，创建转库单并入库NC
        /// </summary>
        /// <param name="lineCode"></param>
        /// <param name="inventoryItems"></param>
        /// <param name="userId"></param>
        public void SaveInventory(string lineCode, List<WWInventoryItem> inventoryItems, string userId)
        {
            List<string> zkIds = new List<string>();
            // 转库单ID对应的转库数据
            Dictionary<string, List<Mod_TRC_ROLL_PRODCUT>> dic = new Dictionary<string, List<Mod_TRC_ROLL_PRODCUT>>();
            TransactionHelper.BeginTransaction();
            try
            {
                var arrZkId = GetZKId(inventoryItems.Count);

                // 验证
                foreach (var item in inventoryItems)
                {
                    List<Mod_TRC_ROLL_PRODCUT> list = new List<Mod_TRC_ROLL_PRODCUT>();

                    string sql = $@"
select t.*  from  TRC_ROLL_PRODCUT T
WHERE T.C_BATCH_NO='{item.BatchNo}' AND T.C_STL_GRD='{item.Gz}' AND T.C_STD_CODE='{item.Zxbz}'
AND T.C_SPEC='{item.Spec}'
AND T.c_judge_lev_zh = '{item.ZLDJ}' 
AND T.C_LINEWH_CODE = '{item.InventoryCode}'
AND T.c_move_type IN ('QE','E')
";
                    list.AddRange(DbHelperOra.Query(sql).Tables[0].DataTableToList2<Mod_TRC_ROLL_PRODCUT>());

                    // 验证库存是否足够
                    if (list.Count < item.Number)
                    {
                        throw new Exception("库存不够，不能转库");
                    }

                    if (list.Count > item.Number && list.Sum(w => w.N_WGT) <= item.Amt)
                    {
                        throw new Exception("库存量不够，请确认支数与重量");
                    }

                    if (list.Count == item.Number)
                    {
                        // 如果全部转库，则转库总重量等于库存重量
                        item.Amt = list.Sum(w => w.N_WGT);
                    }
                    else
                    {
                        // 更新库存量（将支数与转库的重量分摊到每支上重新计算结余的重量）
                        UpdateInventory(list, item.Amt, item.Number);
                    }

                    // 订单物料信息
                    var mtrlItem = dal_TB_MATRL_MAIN.GetModel(item.MtrlCode);
                    var batchItem = list.FirstOrDefault();


                    var zkId = arrZkId[inventoryItems.IndexOf(item)];
                    zkIds.Add(zkId);

                    // 转换仓库code为ID
                    string getLinewhId = "select t.C_ID from TPB_LINEWH T WHERE T.C_LINEWH_CODE='{0}'";
                    var targetLinewhId = TransactionHelper.GetSingle(string.Format(getLinewhId, lineCode)) as string;
                    var lineWhId = TransactionHelper.GetSingle(string.Format(getLinewhId, item.InventoryCode)) as string;

                    if (string.IsNullOrEmpty(userId))
                    {
                        userId = "1001NC100000002SS9XB";
                    }

                    // 添加转库单
                    dalZkd.Add(new Mod_TRC_ROLL_ZKD
                    {
                        C_BATCH_NO = item.BatchNo,
                        C_BZYQ = item.BZYQ,
                        C_EMP_ID = userId,
                        C_F_DW = mtrlItem.C_PK_MEASDOC,
                        C_JUDGE_LEV_ZH = batchItem.C_JUDGE_LEV_ZH,
                        C_LINEWH_CODE = item.InventoryCode,
                        C_MAT_CODE = item.MtrlCode,
                        C_MAT_DESC = batchItem.C_MAT_DESC,
                        C_MBLINEWH_CODE = lineCode,
                        C_SPEC = batchItem.C_SPEC,
                        C_STL_GRD = batchItem.C_STL_GRD,
                        C_STOVE = batchItem.C_STOVE,
                        C_ZKD_NO = zkId,//转库单号
                        C_ZYX1 = batchItem.C_ZYX1,
                        C_ZYX2 = batchItem.C_ZYX2,
                        C_ZYX4 = batchItem.C_STD_CODE,
                        C_Z_DW = mtrlItem.C_PK_MEASDOC,
                        D_MOD_DT = DateTime.Now,
                        D_PRODUCE_DATE = batchItem.D_MOD_DT,
                        N_NUM = item.Number,
                        N_SJNUM = item.Number,
                        N_SJWGT = item.Amt,
                        N_STATUS = 3,
                        N_WGT = item.Amt,//list.Take(item.Number).Sum(w => w.N_WGT),
                        C_LINEWH_ID = lineWhId,
                        C_MBLINEWH_ID = targetLinewhId,

                    }, true);
                    dic.Add(zkId, list);
                }

                TransactionHelper.Commit();
            }
            catch (Exception ex)
            {
                TransactionHelper.RollBack();
                throw ex;
            }

            // 发送NC
            foreach (var item in zkIds)
            {
                var zkdItem = dalZkd.GetListBydh(item).Tables[0].DataTableToList2<Mod_TRC_ROLL_ZKD>().FirstOrDefault();
                try
                {
                    string directory = $"{AppDomain.CurrentDomain.BaseDirectory}\\NCXML";
                    if (Directory.Exists(directory) == false)
                    {
                        Directory.CreateDirectory(directory);
                    }
                    var result4i = dal_zk4i.SendXml_GP(directory, item);
                    //var result4a = dal_zk4a.SendXml_GP(directory, item);

                    if (result4i != "1")
                    {
                        throw new Exception(GetNCError(result4i));
                    }
                    //if (result4a != "1")
                    //{
                    //    throw new Exception(GetNCError(result4a));
                    //}
                }
                catch (Exception ex)
                {
                    // 上传NC异常删除转库单
                    dalZkd.Delete(zkdItem.C_ID);
                    throw new Exception(ex.Message);
                }

                foreach (var pItem in dic[zkdItem.C_ZKD_NO].Take((int)(zkdItem.N_NUM ?? 0)))
                {
                    // 设置转库及未上传NC状态
                    DbHelperOra.ExecuteSql($@"UPDATE TRC_ROLL_PRODCUT SET " +
                        // 标记转库单号，用于撤销
                        $"C_ZKD_NO='{item}', " +
                        // 标记委外出库状态
                        $"C_MOVE_TYPE='QM_{pItem.C_MOVE_TYPE}'," +
                        $"C_LINEWH_CODE='{lineCode}',C_IS_TB='N' WHERE C_ID='{pItem.C_ID}'");
                }
            }

        }

        /// <summary>
        /// 转库操作，同步实绩到NC,
        /// 支持分批转库及回滚
        /// </summary>
        public void SyncWWZKD(string[] arrZkdId)
        {
            foreach (var item in arrZkdId)
            {
                var zkdItem = dalZkd.GetListBydh(item).Tables[0].DataTableToList2<Mod_TRC_ROLL_ZKD>().FirstOrDefault();

                if (zkdItem == null)
                {
                    throw new Exception("转库单不存在");
                }

                try
                {
                    string directory = $"{AppDomain.CurrentDomain.BaseDirectory}\\NCXML";
                    if (Directory.Exists(directory) == false)
                    {
                        Directory.CreateDirectory(directory);
                    }
                    var result4a = dal_zk4a.SendXml_GP(directory, item);
                    if (result4a != "1")
                    {
                        throw new Exception(GetNCError(result4a));
                    }
                }
                catch (Exception ex)
                {
                    // 上传NC异常删除转库单
                    //dalZkd.Delete(zkdItem.C_ID);
                    throw new Exception(ex.Message);
                }

                var listData = GetBySql(
                    $"SELECT T.* FROM TRC_ROLL_PRODCUT T WHERE T.C_ZKD_NO='{item}' AND T.C_MOVE_TYPE LIKE 'QM_%'"
                    ).DataTableToList2<Mod_TRC_ROLL_PRODCUT>();

                if (listData.Any(w => w.C_LINEWH_CODE != zkdItem.C_MBLINEWH_CODE))
                {
                    throw new Exception("转库单线材仓库与库存线材仓库不一致");
                }

                TransactionHelper.BeginTransaction();
                try
                {
                    foreach (var pItem in listData)
                    {
                        string oldStatu = pItem.C_MOVE_TYPE.Replace("QM_", "");
                        // 设置转库及未上传NC状态
                        TransactionHelper.ExecuteSql($@"UPDATE TRC_ROLL_PRODCUT SET " +
                            // 标记转库单号，用于撤销
                            //$"C_ZKD_NO='{item}', " +
                            // 标记委外出库状态
                            $"C_MOVE_TYPE='{oldStatu}'," +
                            $"C_LINEWH_CODE='{zkdItem.C_MBLINEWH_CODE}',C_IS_TB='Y' WHERE C_ID='{pItem.C_ID}'");
                    }

                    // 更新转库单状态
                    TransactionHelper.ExecuteSql($"UPDATE TRC_ROLL_ZKD SET N_STATUS=2 WHERE C_ID='{zkdItem.C_ID}'");

                    TransactionHelper.Commit();
                }
                catch (Exception ex)
                {
                    TransactionHelper.RollBack();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 根据实际填写的重量，更新线材支数的重量
        /// </summary>
        /// <param name="batchInfo">线材批次数据集合</param>
        /// <param name="amt">重量</param>
        /// <param name="num">支数</param>
        public void UpdateInventory(List<Mod_TRC_ROLL_PRODCUT> batchInfo, decimal amt, int num)
        {
            decimal zpAmt = amt;//zpInfo.ZpAmt;

            // 组批临时总量，用于计算剩余的组批量，摊到最后一只
            decimal zpTotal = 0;
            // 组批平均值
            decimal zpAvg = Math.Round(zpAmt / num, 4);

            // 剩余总量，用于计算剩余库存量
            decimal lastTotal = (batchInfo.Sum(w => w.N_WGT) - zpAmt);
            decimal lastTmpTotal = 0;
            decimal lastAvg = 0;

            if (batchInfo.Count > num)
            {
                lastAvg = Math.Round(lastTotal / (batchInfo.Count - num), 4);
            }

            for (int i = 1; i <= batchInfo.Count; i++)
            {
                if (i == num)
                {
                    // 组批最后一只
                    batchInfo[i - 1].N_WGT = zpAmt - zpTotal;
                }
                else if (i > num)
                {
                    // 剩余的库存
                    if (i == batchInfo.Count)
                    {
                        batchInfo[i - 1].N_WGT = lastTotal - lastTmpTotal;
                    }
                    else
                    {
                        batchInfo[i - 1].N_WGT = lastAvg;
                        lastTmpTotal += lastAvg;
                    }
                }
                else
                {
                    // 组批的支数等于平均值
                    batchInfo[i - 1].N_WGT = zpAvg;
                    zpTotal += zpAvg;
                }

                // 更新线材库存量
                string updateSql = $"UPDATE TRC_ROLL_PRODCUT SET N_WGT = {batchInfo[i - 1].N_WGT} WHERE C_ID='{batchInfo[i - 1].C_ID}'";

                TransactionHelper.ExecuteSql(updateSql);
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

            if (string.IsNullOrEmpty(lineWhCode) &&
                string.IsNullOrEmpty(gz) &&
                string.IsNullOrEmpty(zxbz) &&
                string.IsNullOrEmpty(gg) &&
                string.IsNullOrEmpty(searchBatchNo))
            {
                return new List<NCInventoryDto>();
            }

            string pcisqlWhere = string.Empty;
            if (string.IsNullOrEmpty(lineWhCode) == false)
            {
                pcisqlWhere += $"AND t.c_linewh_code = '{lineWhCode}'";
            }

            string ncsqlWhere = string.Empty;
            if (string.IsNullOrEmpty(lineWhCode) == false)
            {
                ncsqlWhere += $"AND t.storcode = '{lineWhCode}'";
            }

            string sql = $@"
with pciInventory as
 (select t.c_batch_no,
         t.c_stl_grd,
         t.c_std_code,
         t.c_zyx1,
         t.c_zyx2,
         t.c_mat_code,
         t.c_mat_desc,
         t.c_bzyq,
         t.c_spec,
         t.c_judge_lev_zh,
         count(1) as count,
         sum(t.n_wgt) as sum,
         t.c_linewh_code,
         t.c_sale_area
    from trc_roll_prodcut t
   where 1=1 {pcisqlWhere}
   and t.c_move_type in ('E','QE')
   group by t.c_batch_no,
            t.c_stl_grd,
            t.c_std_code,
            t.c_zyx1,
            t.c_zyx2,
            t.c_mat_code,
            t.c_mat_desc,
            t.c_bzyq,
            t.c_judge_lev_zh,
            t.c_linewh_code,
            t.c_sale_area,
            t.c_spec
            )
--select *from pciInventory
        select t.批次号          as BatchNo,
               t.INVTYPE         as StlGrd,
               t.INVSPEC         as Spec,
               t.辅数量          as Count,
               t.数量            as Wgt,
               t.INVCODE         as MtrlCode,
               t.INVNAME         as MtrlName,
               t.STORCODE        as InventoryCode,
               t.VFREE3          as BZYQ,
               t.CCHECKSTATENAME as ZLDJ,
               t.VFREE1          as zyx1,
               t.VFREE2          as zyx2,
               tt.count          as pciCount,
               tt.sum            as pciSum,
               t.连铸炉号        as LuHao,
               tt.c_sale_area as SaleArea,
               t.*
          from XGERP50.V_ONHAND_wwjg@CAP_ERP t
          left join pciInventory tt
            on (tt.c_batch_no = t.批次号 )--or tt.c_batch_no like t.批次号 || '%')
           and tt.c_stl_grd = t.INVTYPE
           and tt.c_zyx1 = t.VFREE1
           and tt.c_zyx2 = t.VFREE2
           and tt.c_mat_code = t.INVCODE
           and tt.c_judge_lev_zh = t.CCHECKSTATENAME
           and tt.c_linewh_code = t.STORCODE
           and (tt.c_spec || 'mm' = t.INVSPEC OR tt.c_spec = t.INVSPEC )
         where 1=1 {ncsqlWhere}
--select count(1) from  XGERP50.V_ONHAND_wwjg@CAP_ERP t ;
";

            if (string.IsNullOrEmpty(gz) == false)
            {
                sql += $" AND t.INVTYPE = '{gz}'";
            }
            if (string.IsNullOrEmpty(gg) == false)
            {
                sql += $" AND t.INVSPEC like '%{gg}%'";
            }
            if (string.IsNullOrEmpty(searchBatchNo) == false)
            {
                sql += $" AND t.批次号 like '%{searchBatchNo}%'";
            }

            sql += " order by t.批次号, T.INVTYPE, T.INVSPEC";

            return GetBySql(sql).DataTableToList2<NCInventoryDto>();
        }

        /// <summary>
        /// 同步NC线材库存数据
        /// </summary>
        /// <param name="item"></param>
        /// <param name="userId"></param>
        public void SyncInventory(List<Mod_TRC_ROLL_PRODCUT> list)
        {
            TransactionHelper.BeginTransaction();
            try
            {
                for (int i = 1; i <= list.Count; i++)
                {
                    var mod = list[i - 1];
                    #region sql
                    string sql = $@"
insert into TRC_ROLL_PRODCUT(C_ID,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_EMP_ID,D_MOD_DT,C_STA_ID,C_JUDGE_LEV_BP,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_ZH,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_BZYQ,C_WWBATCH_NO,C_ZYX1,C_ZYX2,C_IS_QR,N_SFOB) 
values
  (
   '{mod.C_ID}',
   '{mod.C_TRC_ROLL_MAIN_ID }',
   '{mod.C_STOVE           }',
   '{mod.C_BATCH_NO          }',
   '{mod.C_TICK_NO          }',
   '{mod.C_STL_GRD           }',
   '{mod.C_STL_GRD_BEFORE   }',
   '{mod.N_WGT            }',
   '{mod.C_STD_CODE          }',
   '{mod.C_STD_CODE_BEFORE   }',
   '{mod.C_MOVE_TYPE         }',
   '{mod.C_SPEC            }',
   '{mod.C_SHIFT             }',
   '{mod.C_GROUP             }',
   '{mod.C_EMP_ID           }',
   to_date('{mod.D_MOD_DT}','yyyy/MM/dd hh24:mi:ss'),
   '{mod.C_STA_ID            }',
   '{mod.C_JUDGE_LEV_BP      }',
   '{mod.C_JUDGE_LEV_CF      }',
   '{mod.C_JUDGE_LEV_XN      }',
   '{mod.C_JUDGE_LEV_ZH      }',
   '{mod.C_DP_SHIFT       }',
   '{mod.C_DP_GROUP          }',
   '{mod.C_DP_EMP_ID         }',
   to_date('{mod.D_DP_DT}','yyyy/MM/dd hh24:mi:ss'),
   '{mod.C_PLANT_ID          }',
   '{mod.C_PLANT_DESC        }',
   '{mod.C_MAT_CODE          }',
   '{mod.C_MAT_CODE_BEFORE   }',
   '{mod.C_MAT_DESC      }',
   '{mod.C_MAT_DESC_BEFORE   }',
   '{mod.C_IS_DEPOT    }',
   '{mod.C_PLAN_ID           }',
   '{mod.C_ORDER_NO}',
   '{mod.C_CON_NO           }',
   '{mod.C_CUST_NO}',
   '{mod.C_CUST_NAME}',
   '{mod.C_ISFREE            }',
   '{mod.C_LINEWH_CODE}',
   '{mod.C_LINEWH_AREA_CODE}',
   '{mod.C_LINEWH_LOC_CODE   }',
   '{mod.C_FLOOR    }',
   '{mod.C_CUST_AREA         }',
   '{mod.C_SALE_AREA         }',
   '{mod.C_BZYQ          }',
   '{mod.C_WWBATCH_NO        }',
   '{mod.C_ZYX1         }',
   '{mod.C_ZYX2}',
   '{"Y"}',
   '{1}')
";

                    #endregion

                    TransactionHelper.ExecuteSql(sql);
                }
            }
            catch (Exception ex)
            {
                TransactionHelper.RollBack();
                throw ex;
            }
            TransactionHelper.Commit();
        }


        private string GetNCError(string str)
        {
            var result2 = str.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace(" ", "&nbsp;");
            return result2;

            char[] TrimChar = { ' ', '-', '\'', '\"', '\\', '\n' };       //此处使用了转义字符如：\',\",\\，分别表示单引号，双引号，反斜杠

            var result = string.Join("", str.Skip(str.LastIndexOf("：") + 1)).Trim(TrimChar).Replace("<", "").Replace(">", "");

            return result;

        }

        public string GetZKDNO(string zkdstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MAX(C_ZKD_NO) ");
            strSql.Append(" FROM TRC_ROLL_ZKD WHERE 1=1 ");
            if (zkdstr.Trim() != "")
            {
                strSql.Append(" AND C_ZKD_NO LIKE 'ZK" + zkdstr + "%' ");
            }
            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "0";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 移除超期的用户心跳信息(1分钟)
        /// </summary>
        public void RemoveTimeOutUser()
        {
            string sql = $@"
DELETE TS_HEARTBEAT WHERE D_TIME <= 
to_date('{DateTime.Now.AddMinutes(-1).ToString("yyyy-MM-dd HH:mm:ss")}','yyyy-MM-dd HH24:MI:SS')
";

            DbHelperOra.ExecuteSql(sql);
        }

        /// <summary>
        /// 刷新用户心跳信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        public void RefreshHeartBeat(string user, string token)
        {
            string sql = $@"
UPDATE TS_HEARTBEAT SET D_TIME = sysdate
WHERE C_UID= '{user}' AND C_TOKEN='{token}'
";

            DbHelperOra.ExecuteSql(sql);
        }

        /// <summary>
        /// 验证用户是否正常
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool HasHeartBeat(string user, string token)
        {
            string sql = $@"SELECT Max(N_USED) FROM TS_HEARTBEAT T 
WHERE T.C_UID= '{user}' AND T.C_TOKEN='{token}'";

            var used = DbHelperOra.GetSingle(sql)?.ToString();
            if (string.IsNullOrEmpty(used) == false)
            {
                // used ==1为正常状态，0为被强登录状态
                return used == "1";
            }

            return false;
        }

        public bool HasOtherUser(string user)
        {
            string sql = $@"SELECT Count(1) FROM TS_HEARTBEAT T 
        WHERE T.C_UID= '{user}' AND T.N_USED=1";

            return Convert.ToInt32(DbHelperOra.GetSingle(sql)) > 0;
        }

        /// <summary>
        /// 登录用户并记录心跳
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        public void LoginToHeartBeat(string user, string token)
        {
            // 设置用户被占用
            string setUsedSql = $@"UPDATE TS_HEARTBEAT SET N_USED=0 WHERE C_UID='{user}'";
            DbHelperOra.ExecuteSql(setUsedSql);

            // 添加心跳信息
            string sql = $@"
INSERT INTO TS_HEARTBEAT(C_ID,C_UID,C_TOKEN,D_TIME) 
VALUES('{Guid.NewGuid().ToString("N")}','{user}','{token}',sysdate)
";
            DbHelperOra.ExecuteSql(sql);
        }

        public void SyncDic(params string[] arr)
        {
            foreach (var item in arr)
            {
                DbHelperOra.RunProcedure(item, new OracleParameter[] { });
            }
        }

        /// <summary>
        /// 邢钢网站产品信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="keyword"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public object GetProduct(string type, string keyword, int pageIndex, int pageSize)
        {
            string sqlwhere = string.Empty;

            if (!string.IsNullOrEmpty(type))
            {
                sqlwhere += $"AND t3.nodeid = {type}";
            }

            string sql = $@"
SELECT t2.nodeid AS 'typeid', t2.nodename AS 'typeName', t1.Pmodel AS 'xh', t1.Specification AS 'gg', t1.Producer AS 'zxbz'
	, t1.MainExplanation AS 'syfw', t1.PexhibitionPic AS 'tpdz', t1.content AS 'cpjs'
FROM PE_CommonModel t
	LEFT JOIN PE_U_Exhibition t1 ON t.itemId = t1.Id
	LEFT JOIN PE_Nodes t2 ON t.nodeid = t2.nodeid
WHERE t.tableName = 'PE_U_Exhibition'
	AND t.nodeid IN (
		SELECT t3.nodeid
		FROM dbo.PE_Nodes t3
		WHERE CAST(t3.parentdir AS nvarchar) = '/Article/Products/xccp/'
			AND t3.showonmenu = 1 {sqlwhere}
	)
ORDER BY t.nodeid
";
            var websiturl = string.Empty;
            try
            {
                var fr = new Dal_TS_DIC().GetDis("XG_WEB_SITE_IMG_URL").Tables[0].Select().FirstOrDefault();
                websiturl = fr?["c_detailcode"]?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {

            }

            websiturl = string.Concat(websiturl, "/UploadFiles/");

            var products = DbHelper_SQL2.Query(sql).Tables[0].Select().Select((x) =>
            {
                var dz = x[6]?.ToString();
                dz = dz.Substring(dz.IndexOf('|') + 1);
                dz = string.Concat(websiturl, dz);

                var fw = x[5]?.ToString().Replace("<p>", "").Replace("</p>", "").Replace("\r\n", "");
                var js = x[7]?.ToString().Replace("<p>", "").Replace("</p>", "").Replace("\r\n", "");

                return new
                {
                    // 类型id
                    typeid = x[0],
                    // 类型名称
                    typename = x[1],
                    // 型号
                    xh = x[2],
                    // 规格
                    gg = x[3],
                    // 执行标准
                    zxbz = x[4],
                    // 使用范围
                    stfw = fw,
                    // 图片地址
                    tpdz = dz,
                    // 产品介绍
                    cpjs = js
                };
            }).ToList();

            return products;
        }

        /// <summary>
        /// 产品分类
        /// </summary>
        /// <returns></returns>
        public object GetProductType()
        {
            string sql = $@"
		SELECT t3.nodeid,t3.nodename
		FROM dbo.PE_Nodes t3
		WHERE CAST(t3.parentdir AS nvarchar) = '/Article/Products/xccp/'
		AND t3.showonmenu = 1 ORDER BY t3.nodeid
";

            return DbHelper_SQL2.Query(sql).Tables[0].Select().Select(x => new
            {
                NodeName = x[1],
                NodeId = x[0]
            }).ToList();
        }

        /// <summary>
        /// 更新线材详情
        /// </summary>
        /// <param name="arrAllId"></param>
        /// <param name="arrUpdateId"></param>
        /// <param name="txtamt"></param>
        /// <param name="moveType"></param>
        public void UpdateDetail(
            List<string> arrAllId,
            List<string> arrUpdateId,
            decimal txtamt,
            string moveType)
        {
            var states = new string[] { "QE", "E" };

            if (arrUpdateId.Count > arrAllId.Count)
            {
                throw new Exception("数据错误，请刷新页面重试");
            }

            if (states.Concat(new string[] { "S" }).Any(x => x == moveType) == false)
            {
                throw new Exception("数据错误，请刷新页面重试");
            }

            var listUpdateMoveType = new List<Mod_TRC_ROLL_PRODCUT>();

            var allIds = string.Join("','", arrAllId);
            var updateIds = string.Join("','", arrUpdateId);

            var selectSql = @"SELECT * FROM trc_roll_prodcut where c_id in ('{0}') order by c_id";

            string allSql = string.Format(selectSql, allIds);
            string updateSql = string.Format(selectSql, updateIds);

            TransactionHelper.BeginTransaction();
            try
            {
                var allData = DbHelperOra.Query(allSql).Tables[0].DataTableToList2<Mod_TRC_ROLL_PRODCUT>();

                if (allData.Any(l => states.Any(x => x == l.C_MOVE_TYPE) == false))
                {
                    throw new Exception("系统检测到数据状态已发生变化，请重试");
                }

                if (arrAllId.Count == arrUpdateId.Count)
                {
                    var s2 = arrAllId.OrderBy(w => w).Zip(arrUpdateId.OrderBy(w => w), (x, y) =>
                    {
                        return new { x, y };
                    }).Any(l => l.x != l.y);

                    if (s2)
                    {
                        throw new Exception("数据错误，请刷新页面重试");
                    }

                    // 修改所有线材的重量
                    var totalAmt = allData.Sum(w => w.N_WGT);

                    // 如果重量一致不修改
                    if (totalAmt != txtamt)
                    {
                        UpdateInventory(allData, txtamt, arrAllId.Count);
                    }

                    listUpdateMoveType.AddRange(allData);
                }
                else
                {
                    var uptData = DbHelperOra.Query(updateSql).Tables[0].DataTableToList2<Mod_TRC_ROLL_PRODCUT>();

                    if (uptData.Any(l => states.Any(x => x == l.C_MOVE_TYPE) == false))
                    {
                        throw new Exception("系统检测到数据状态已发生变化，请重试");
                    }

                    // 如果重量一致不修改
                    if (uptData.Sum(w => w.N_WGT) != txtamt)
                    {
                        // 修改了重量
                        allData = allData.OrderBy(w => uptData.Any(l => w.C_ID == l.C_ID) == false).ToList();

                        if (allData.Count != arrAllId.Count || uptData.Count != arrUpdateId.Count)
                        {
                            throw new Exception("数据错误，请刷新页面重试");
                        }

                        var s = arrAllId.OrderBy(w => w).Zip(allData.OrderBy(w => w.C_ID), (x, y) =>
                        {
                            return new
                            {
                                x,
                                y.C_ID
                            };
                        }).Any(p => p.x != p.C_ID);
                        var s1 = arrUpdateId.OrderBy(w => w).Zip(uptData.OrderBy(w => w.C_ID), (x, y) =>
                        {
                            return new
                            {
                                x,
                                y.C_ID
                            };
                        }).Any(p => p.x != p.C_ID);

                        if (s | s1)
                        {
                            throw new Exception("数据错误，请刷新页面重试");
                        }

                        var totalamt = allData.Sum(x => x.N_WGT);
                        if (txtamt >= totalamt)
                        {
                            throw new Exception($"不得超过总重量:{totalamt}");
                        }

                        UpdateInventory(allData, txtamt, uptData.Count);
                    }

                    listUpdateMoveType.AddRange(uptData);
                }

                // 修改批次状态
                foreach (var item in listUpdateMoveType)
                {
                    string uptMoveTypeSql = $"UPDATE TRC_ROLL_PRODCUT SET C_MOVE_TYPE='{moveType}' WHERE C_ID='{item.C_ID}'";
                    TransactionHelper.ExecuteSql(uptMoveTypeSql);
                }

                TransactionHelper.Commit();
            }
            catch (Exception ex)
            {
                TransactionHelper.RollBack();
                throw ex;
            }
        }
    }
}

