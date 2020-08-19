using DAL;
using MODEL;
using NF.DAL;
using NF.DLL;
using NF.MODEL;
using NF.MODEL.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.BLL
{
    /// <summary>
    /// 订单池
    /// </summary>
    public partial class Bll_TMO_ORDER
    {
        Bll_TRC_ROLL_PRODCUT bllProduct = new Bll_TRC_ROLL_PRODCUT();
        Dal_TRC_ROLL_WW_MAIN dalWWMain = new Dal_TRC_ROLL_WW_MAIN();

        Dal_TMO_ORDER dalOrder = new Dal_TMO_ORDER();
        Dal_TPB_LINEWH dalLineWh = new Dal_TPB_LINEWH();
        Dal_TS_USER dalUser = new Dal_TS_USER();

        Dal_Interface_NC_Roll_A1 dalA1 = new Dal_Interface_NC_Roll_A1();
        Dal_Interface_NC_Roll_A2 dalA2 = new Dal_Interface_NC_Roll_A2();
        Dal_Interface_NC_Roll_A3 dalA3 = new Dal_Interface_NC_Roll_A3();
        Dal_Interface_NC_Roll_A4 dalA4 = new Dal_Interface_NC_Roll_A4();
        Dal_Interface_NC_Roll_46 dal46 = new Dal_Interface_NC_Roll_46();

        Bll_TB_MATRL_MAIN bll_TB_MATRL_MAIN = new Bll_TB_MATRL_MAIN();

        Dal_TB_STA dalTbSta = new Dal_TB_STA();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<WWContractInfo> GetWWOrdList(
            string mtrlType,
            string zxbz,
            string gg,
            string customer,
            string mtrlCode,
            string ht,
            string linewhCode,
            DateTime? beginTime,
            DateTime? endTime
            )
        {
            #region 条件sql
            // 合同生效条件
            string strWhere = "t.N_STATUS = '2'";

            if (!string.IsNullOrEmpty(mtrlType))
            {
                strWhere += $"And t.C_STL_GRD LIKE '{mtrlType}'";
            }


            if (!string.IsNullOrEmpty(zxbz))
            {
                strWhere += $"And t.C_STD_CODE LIKE '%{zxbz}%'";
            }


            if (!string.IsNullOrEmpty(gg))
            {
                strWhere += $"And t.C_SPEC LIKE '%{gg}%'";
            }


            if (!string.IsNullOrEmpty(customer))
            {
                strWhere += $"And (t.C_CUST_NAME LIKE '%{customer}%' OR t.C_CUST_NO LIKE '%{customer}%')";
            }


            if (!string.IsNullOrEmpty(mtrlCode))
            {
                strWhere += $"And (t.C_MAT_NAME LIKE '%{mtrlCode}%' OR t.C_MAT_CODE LIKE '%{mtrlCode}%')";
            }

            if (!string.IsNullOrEmpty(ht))
            {
                strWhere += $"And (t.C_CON_NO LIKE '%{ht}%' OR t.C_CON_NAME LIKE '%{ht}%')";
            }

            if (beginTime.HasValue)
            {
                strWhere += $"And t.D_DT >= to_date({beginTime.Value.ToString("yyyyMMdd")},'yyyyMMdd')";
            }
            if (endTime.HasValue)
            {
                strWhere += $"And t.D_DT < to_date({endTime.Value.AddDays(1).ToString("yyyyMMdd")},'yyyyMMdd')";
            }

            #endregion

            strWhere += "ORDER BY T.D_DT DESC,t.C_CON_NO,T.C_ORDER_NO";

            DataSet ds = dal.GetWWZP(strWhere, linewhCode);
            return ds.Tables[0].DataTableToList2<WWContractInfo>();
        }

        /// <summary>
        /// 外委加工组批
        /// </summary>
        /// <param name="zpInfo"></param>
        public void SetZpInfo(WWZPPlanItemInfo zpInfo, string userId)
        {
            // 合同订单信息
            var ordInfo = GetModel(zpInfo.Id);
            // 库存钢材信息
            var batchInfo = bllProduct.GetByBatchNo(
                zpInfo.CBatchNo,
                ordInfo.C_STL_GRD,
                ordInfo.C_STD_CODE,
                zpInfo.MtrlCode,
                zpInfo.InventoryCode,
                zpInfo.ZLDJ,
                zpInfo.BZYQ);

            if (batchInfo.Count < zpInfo.Num)
            {
                throw new Exception("库存支数不够，请刷新数据后重试!");
            }

            var sum = batchInfo.Sum(w => w.N_WGT);
            if (sum < zpInfo.ZpAmt || (batchInfo.Count != zpInfo.Num && sum == zpInfo.ZpAmt))
            {
                throw new Exception("库存总量不够，请刷新数据后重试!");
            }

            dalWWMain.SetZpInfo(ordInfo, zpInfo, batchInfo, userId);
        }

        public void UpdateToNcBatchNo(string lineCode,
            string stlGrd,
            string stdCode,
            string sepc,
            string batchNo,
            string mtrlCode,
            string zldj,
            string bzyq,
            List<Mod_TRC_ROLL_PRODCUT> batchInfos)
        {
            dalWWMain.UpdateBatchSameToNcAndSyncXNCF(lineCode, stlGrd, stdCode, sepc, batchNo, mtrlCode, zldj, bzyq, batchInfos);
        }

        /// <summary>
        /// 撤销组批
        /// </summary>
        /// <param name="itemId">组批主键ID</param>
        /// <param name="num">撤销支数</param>
        public void CancelZpInfo(string itemId, decimal num)
        {
            dalWWMain.CancelZpInfo(itemId, num);
        }

        /// <summary>
        /// 获取组批计划
        /// </summary>
        /// <returns></returns>
        public List<WWPlanInfo> GetProductList(string ph, string gz, string zxbz, string gg, string wl,
            DateTime? beginTime, DateTime? endTime, string cId = "")
        {
            #region 条件sql
            // 合同生效条件
            string strWhere = "1=1";

            if (!string.IsNullOrEmpty(ph))
            {
                strWhere += $"And (C_BATCH_NO LIKE '%{ph}%' OR C_XC_BATCH_NO LIKE '%{ph}%')";
            }

            if (!string.IsNullOrEmpty(zxbz))
            {
                strWhere += $"And C_STD_CODE LIKE '%{zxbz}%'";
            }

            if (!string.IsNullOrEmpty(gz))
            {
                strWhere += $"And C_STL_GRD_SLAB LIKE '%{gz}%'";
            }

            if (!string.IsNullOrEmpty(gg))
            {
                strWhere += $"And C_SPEC_SLAB LIKE '%{gg}%'";
            }

            if (!string.IsNullOrEmpty(wl))
            {
                strWhere += $"And (C_MAT_SLAB_NAME LIKE '%{wl}%' OR C_MAT_SLAB_CODE LIKE '%{wl}%'" +
                    $"OR C_MAT_XC_NAME LIKE '%{wl}%' OR C_MAT_XC_CODE LIKE '%{wl}%')";
            }

            if (beginTime.HasValue)
            {
                strWhere += $"And D_MOD_DT >= to_date({beginTime.Value.ToString("yyyyMMdd")},'yyyyMMdd')";
            }
            if (endTime.HasValue)
            {
                strWhere += $"And D_MOD_DT < to_date({endTime.Value.AddDays(1).ToString("yyyyMMdd")},'yyyyMMdd')";
            }

            if (string.IsNullOrEmpty(cId) == false)
            {
                strWhere += $"AND C_ID='{cId}'";
            }

            strWhere += " ORDER BY D_MOD_DT DESC";

            #endregion

            var list = dalWWMain.GetList(strWhere).Tables[0].DataTableToList2<WWPlanInfo>();

            FillNCState(list);

            return list;
        }

        public class NCExsitDto
        {
            public string Data { get; set; }

            public int Count { get; set; }
        }

        private void FillNCState(List<WWPlanInfo> list)
        {
            var ids = list.Select(w => w.C_ID);
            var batchNos = list.Select(w => w.C_BATCH_NO);

            string idStr = $"'{string.Join("','", ids)}'";
            string batchStr = $"'{string.Join("','", batchNos)}'";

            // 制单人
            var userIds = list.SelectMany(w =>
            {
                return new string[] { w.C_EMP_ID, w.C_PRODUCE_EMP_ID };
            }).Distinct().ToList();
            string userStr = $"'{string.Join("','", userIds)}'";

            string userSql = $@"
select t.c_id,t.c_name from  ts_user t where t.c_id in ({userStr})
";
            var userInfos = dal.GetBySql(userSql).DataTableToList2<Mod_TS_USER>();

            // 验证NC单据是否删除，如果都被删除，则设置可撤销计划

            #region a1,a2,a3,a4,46查询SQL
            string a1Sql = $@"
select mm_po.zyx5 as data,count(1) as count from XGERP50.mm_po@CAP_ERP  where 
mm_po.dr=0 and pk_corp='1001' and mm_po.zyx5 in ({idStr}) 
group by  mm_po.zyx5
";
            string a2Sql = $@"
select mm_mo.pch as data,count(1) as count from XGERP50.mm_mo@CAP_ERP where mm_mo.dr=0 and pk_corp='1001' 
and mm_mo.pch in ({batchStr}) 
group by mm_mo.pch
";

            string a3Sql = $@"
select vuserdef20 as data,count(1) as count from XGERP50.ic_general_b@CAP_ERP where 
ic_general_b.dr=0 and pk_corp='1001' and ic_general_b.cbodybilltypecode='4D'
and ic_general_b.vuserdef20 in ({batchStr}) 
group by ic_general_b.vuserdef20
";

            string a4Sql = $@"
select pch as data,count(*) count from XGERP50.mm_wr_b@CAP_ERP where mm_wr_b.dr=0 and pk_corp='1001' and 
mm_wr_b.pch in ({batchStr}) 
group by mm_wr_b.pch
";

            string a46Sql = $@"
select vbatchcode as data,count(*) count from XGERP50.ic_general_b@CAP_ERP where ic_general_b.dr=0 and 
ic_general_b.cbodybilltypecode='46' and pk_corp='1001' and ic_general_b.vbatchcode in ({batchStr}) 
group by ic_general_b.vbatchcode
";

            #endregion

            var a1List = dal.GetBySql(a1Sql).DataTableToList2<NCExsitDto>();
            var a2List = dal.GetBySql(a2Sql).DataTableToList2<NCExsitDto>();
            var a3List = dal.GetBySql(a3Sql).DataTableToList2<NCExsitDto>();
            var a4List = dal.GetBySql(a4Sql).DataTableToList2<NCExsitDto>();
            var a46List = dal.GetBySql(a46Sql).DataTableToList2<NCExsitDto>();

            foreach (var item in list)
            {
                item.A1Count = a1List.FirstOrDefault(w => w.Data == item.C_ID)?.Count ?? 0;
                item.A2Count = a2List.FirstOrDefault(w => w.Data == item.C_BATCH_NO)?.Count ?? 0;
                item.A3Count = a3List.FirstOrDefault(w => w.Data == item.C_BATCH_NO)?.Count ?? 0;
                item.A4Count = a4List.FirstOrDefault(w => w.Data == item.C_BATCH_NO)?.Count ?? 0;
                item.A46Count = a46List.FirstOrDefault(w => w.Data == item.C_BATCH_NO)?.Count ?? 0;
                item.CreateUser = userInfos.FirstOrDefault(w => w.C_ID == item.C_EMP_ID)?.C_NAME;
                item.ProductUser = userInfos.FirstOrDefault(w => w.C_ID == item.C_PRODUCE_EMP_ID)?.C_NAME;
            }
        }

        /// <summary>
        /// 设置外委加工完工
        /// </summary>
        /// <param name="model">数据包含完工的ID，重量，支数</param>
        public void SetFinish(Mod_TRC_ROLL_WW_MAIN info, string userId)
        {
            var model = dalWWMain.GetModel(info.C_ID);

            if (model == null) throw new Exception("数据不存在,可能该计划已撤销，请刷新页面重试");

            if (model.N_QUA_TOTAL < info.N_QUA_REMOVE)
            {
                throw new Exception($"完工支数不能大于{model.N_QUA_TOTAL}");
            }

            //if (model.N_WGT_TOTAL < info.N_WGT_REMOVE)
            //{
            //    throw new Exception($"完工重量不能大于{model.N_WGT_TOTAL}");
            //}

            // 修改后默认可以多50%，目前先这样，后续可以使用字典表维护超出比例
            var percent = 1.5m;
            if ((model.N_WGT_TOTAL * percent) < info.N_WGT_REMOVE)
            {
                throw new Exception($"完工重量不能大于{model.N_WGT_TOTAL}的{(percent - 1) * 100}%");
            }

            if (model.N_STATUS != 0)
            {
                throw new Exception($"该计划已经被完工，请刷新页面重试");
            }

            model.N_WGT_REMOVE = Math.Round(info.N_WGT_REMOVE ?? 0, 4);
            model.N_QUA_REMOVE = info.N_QUA_REMOVE;
            model.N_STATUS = 1;
            model.C_PRODUCE_GROUP = info.C_PRODUCE_GROUP;
            model.C_PRODUCE_SHIFT = info.C_PRODUCE_SHIFT;
            model.C_CHECKSTATE_NAME = info.C_CHECKSTATE_NAME;
            model.C_LINEWH_CODE = info.C_LINEWH_CODE;
            model.C_LINEWH_NAME = info.C_LINEWH_NAME;
            model.C_PRODUCE_EMP_ID = userId;

            dalWWMain.SetFinish(model);
        }

        /// <summary>
        /// 修改批次号
        /// </summary>
        /// <param name="zpId"></param>
        /// <param name="zpNewBatchNo"></param>
        public void UpdateBatchNo(string zpId, string zpNewBatchNo)
        {
            var model = dalWWMain.GetModel(zpId);

            if (model == null)
            {
                throw new Exception("数据不存在，请刷新页面后重试");
            }

            if (model.C_BATCH_NO == zpNewBatchNo)
            {
                throw new Exception("请修改批号后再提交");
            }

            // 验证批号唯一
            if (dalWWMain.ExistBatchNo(zpNewBatchNo))
            {
                throw new Exception("批次号重复，请修改批次号后再提交");
            }

            // 修改批次号，如果录入了成分，需要把成分的批次号更新
            dalWWMain.UpdateBatchNo(model, zpNewBatchNo);
        }

        /// <summary>
        /// 撤销委外完工
        /// </summary>
        /// <param name="info"></param>
        public void SetCancel(Mod_TRC_ROLL_WW_MAIN info)
        {
            var model = dalWWMain.GetModel(info.C_ID);

            if (model == null) throw new Exception("数据不存在,可能该计划已撤销，请刷新页面重试");

            if (model.N_STATUS != 1)
            {
                throw new Exception($"未完工状态不能撤销");
            }

            model.N_STATUS = 0;
            model.N_WGT_REMOVE = null;
            model.N_QUA_REMOVE = null;
            var a = dalWWMain.SetCancel(model);

            if (a == false)
            {
                throw new Exception("操作失败，请刷新页面重试，可能该计划已撤销");
            }
        }

        /// <summary>
        /// 撤销成分转换
        /// </summary>
        /// <param name="cId">组批计划ID</param>
        public void ResetPlan(string cId)
        {
            if (string.IsNullOrEmpty(cId))
            {
                throw new Exception("组批计划不存在");
            }
            var mod = GetProductList(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null, null, cId).FirstOrDefault();

            if (mod == null)
            {
                throw new Exception("组批计划不存在");
            }

            if (mod.IsNcCancel == false)
            {
                throw new Exception("请先删除NC中的计划后再撤销");
            }


            var oldXCLst = dalWWMain.GetWWItemByZpId(cId);
            var xcLst = dalWWMain.GetProductsByZpId(mod.C_BATCH_NO);

            if (oldXCLst.Any() == false || oldXCLst.Count != mod.N_QUA_TOTAL ||
                oldXCLst.Sum(w => w.N_WGT) != mod.N_WGT_TOTAL)
            {
                throw new Exception("组批线材数据不存在,或线材重量支数不匹配，不能撤销");
            }

            // 还原半成品线材，设置成品线材为撤销状态
            // 验证线材状态
            if (xcLst.Any(w => w.C_MOVE_TYPE != "E"))
            {
                throw new Exception("线材数据状态错误，不能撤销");
            }

            dalWWMain.ResetZP(cId, oldXCLst, xcLst);

            // 还原线材数据，删除成品数据
        }

        /// <summary>
        /// 上传NC
        /// </summary>
        /// <param name="list">委外组批计划ID（组批计划包含完工信息）</param>
        public void SendToNC(List<string> list)
        {
            if (list.Any() == false) throw new Exception("请选择后再上传");

            var ids = "('" + string.Join("','", list) + "')";
            var updateMods = dalWWMain.GetList($"C_ID IN {ids}").Tables[0].DataTableToList2<Mod_TRC_ROLL_WW_MAIN>();

            if (updateMods.Any() == false)
            {
                throw new Exception("没有需要上传NC的数据");
            }

            if (updateMods.Any(w => w.N_STATUS < 1 || w.N_STATUS == 30))
            {
                throw new Exception("只有状态为已完工或未上传完毕的，才能上传NC");
            }

            foreach (var item in updateMods)
            {
                if (string.IsNullOrEmpty(item.C_PRODUCE_EMP_ID))
                {
                    item.C_PRODUCE_EMP_ID = "1001NC100000002SS9XB";
                }

                if (string.IsNullOrEmpty(item.C_EMP_ID))
                {
                    item.C_EMP_ID = "1001NC100000002SS9XB";
                }

                // 获取用户信息
                var planUser = dalUser.GetModel(item.C_EMP_ID);// 组批计划员
                var productUser = dalUser.GetModel(item.C_PRODUCE_EMP_ID);// 生产人员

                // 合同信息
                var contractInfo = dalOrder.GetModel(item.C_ORD_ID);

                if (contractInfo == null) continue;

                // 订单物料信息
                var ordMatrl = bll_TB_MATRL_MAIN.GetModel(contractInfo.C_MAT_CODE);

                if (contractInfo == null) continue;

                // 耗用线材物料信息
                var consumeMatrl = bll_TB_MATRL_MAIN.GetModel(item.C_MAT_XC_CODE);

                if (consumeMatrl == null) continue;
                // 线材批次信息
                var xcBatchInfo = dalWWMain.GetItemList(item.C_ID).FirstOrDefault();
                if (xcBatchInfo == null) continue;

                if (contractInfo == null || ordMatrl == null) continue;

                // 传入外委物料代码决定工序，获取ERP代码
                var mod_TB_STA = dalTbSta.GetModelByCODE(Bll_TRC_ROLL_PRODCUT.GetStaCode(contractInfo.C_MAT_CODE));

                if (item.N_STATUS == 1)
                {
                    // 上传NC
                    var itemA1 = GetA1(contractInfo, ordMatrl, item, mod_TB_STA, planUser);
                    var a1Result = dalA1.SendXml_ROLL_A1(item.C_ID, string.Empty, "A1.xml", itemA1, AppDomain.CurrentDomain.BaseDirectory);

                    if (NCInterface.NCConfig.IsSendToNC)
                    {
                        // 状态0创建,10完工,21已传NC_A1,22已传NC_A2,23已传NC_A3,24已传NC_A4,25已传NC_A46，30上传NC完毕,
                        if (a1Result[0] == "1")
                        {
                            // 上传成功，更新状态
                            item.N_STATUS = 21;
                            dalWWMain.SetStatu(item);
                        }
                        else throw new Exception(GetNCError(a1Result));
                    }
                }

                if (item.N_STATUS == 21)
                {
                    // 上传NC
                    var itemA2 = GetA2(contractInfo, ordMatrl, item, mod_TB_STA, planUser);
                    var a2Result = dalA2.SendXml_ROLL_A2(item.C_ID, string.Empty, "A2.xml", itemA2, AppDomain.CurrentDomain.BaseDirectory);

                    if (NCInterface.NCConfig.IsSendToNC)
                    {
                        if (a2Result[0] == "1")
                        {
                            item.N_STATUS = 22;
                            // 上传成功，更新状态
                            dalWWMain.SetStatu(item);
                        }
                        else throw new Exception(GetNCError(a2Result));
                    }
                }

                if (item.N_STATUS == 22)
                {
                    // 上传NC
                    var itemA3 = GetA3(contractInfo, ordMatrl, consumeMatrl, item, mod_TB_STA, xcBatchInfo);
                    var a3Result = dalA3.SendXml_ROLL_A3(item.C_ID, string.Empty, "A3.xml", itemA3, AppDomain.CurrentDomain.BaseDirectory);

                    if (NCInterface.NCConfig.IsSendToNC)
                    {
                        if (a3Result[0] == "1")
                        {
                            // 上传成功，更新状态
                            item.N_STATUS = 23;
                            dalWWMain.SetStatu(item);
                        }
                        else throw new Exception(GetNCError(a3Result));
                    }
                }

                if (item.N_STATUS == 23)
                {
                    // 上传NC
                    var itemA4 = GetA4(contractInfo, ordMatrl, item, mod_TB_STA, productUser);
                    var a4Result = dalA4.SendXml_ROLL_A4(item.C_ID, string.Empty, item.C_ID + "A4.xml", itemA4, AppDomain.CurrentDomain.BaseDirectory);

                    if (NCInterface.NCConfig.IsSendToNC)
                    {
                        if (a4Result[0] == "1")
                        {
                            item.N_STATUS = 24;
                            // 上传成功，更新状态
                            dalWWMain.SetStatu(item);
                        }
                        else throw new Exception(GetNCError(a4Result));
                    }
                }

                if (item.N_STATUS == 24)
                {
                    // 上传NC
                    var item46 = Get46(contractInfo, ordMatrl, item, mod_TB_STA, productUser);
                    var a46Result = dal46.SendXml_ROLL_46(item.C_ID, string.Empty, "A46.xml", new List<NcRoll46> { item46 }, AppDomain.CurrentDomain.BaseDirectory);

                    if (NCInterface.NCConfig.IsSendToNC)
                    {
                        if (a46Result[0] == "1")
                        {
                            item.N_STATUS = 25;
                            dalWWMain.SetStatu(item);
                        }
                        else throw new Exception(GetNCError(a46Result));
                    }
                }
                if (item.N_STATUS == 25)
                {
                    // 入库操作
                    RuKu(item, mod_TB_STA, contractInfo);
                    // 更新状态
                    item.N_STATUS = 30;
                    dalWWMain.SetStatu(item);

                    dalWWMain.SetDesignNo(item);
                }
                else
                {
                    throw new Exception("上传NC失败");
                }
            }
        }

        /// <summary>
        /// 完工，入库
        /// </summary>
        /// <param name="item">委外计划</param>
        private void RuKu(Mod_TRC_ROLL_WW_MAIN item, Mod_TB_STA tBSta, Mod_TMO_ORDER contractInfo)
        {
            var xcItems = dalWWMain.GetItemList(item.C_ID);
            if (xcItems.Any() == false) throw new Exception("未找到组批信息");

            List<Mod_TRC_ROLL_PRODCUT> addItems = new List<Mod_TRC_ROLL_PRODCUT>();

            // 单支完工量
            var singleAmt = item.N_WGT_REMOVE / item.N_QUA_REMOVE;
            foreach (var xcItem in xcItems)
            {
                // 如果已经满足完工支数退出
                if (addItems.Count == item.N_QUA_REMOVE) continue;
                xcItem.C_ID = $"{item.C_BATCH_NO}{(addItems.Count + 1).ToString("0000")}";
                xcItem.C_BATCH_NO = item.C_BATCH_NO;
                xcItem.N_WGT = singleAmt ?? 0;
                xcItem.C_MOVE_TYPE = "E";
                xcItem.C_SHIFT = item.C_PRODUCE_SHIFT;
                xcItem.C_GROUP = item.C_PRODUCE_GROUP;
                xcItem.C_STA_ID = tBSta.C_ID;
                xcItem.C_IS_DEPOT = "Y";
                xcItem.C_MAT_CODE = contractInfo.C_MAT_CODE;//item.C_MAT_XC_CODE;
                xcItem.C_MAT_CODE_BEFORE = string.Empty;
                xcItem.C_MAT_DESC = contractInfo.C_MAT_NAME; //item.C_MAT_XC_NAME;
                xcItem.C_CON_NO = contractInfo.C_CON_NO;
                xcItem.C_ORDER_NO = contractInfo.C_ORDER_NO;
                xcItem.C_LINEWH_CODE = item.C_LINEWH_CODE;
                xcItem.C_LINEWH_LOC_CODE = string.Empty;
                xcItem.C_WWBATCH_NO = item.C_XC_BATCH_NO;
                xcItem.C_JUDGE_LEV_ZH = item.C_CHECKSTATE_NAME;
                xcItem.C_BZYQ = contractInfo.C_PACK;
                xcItem.D_DP_DT = DateTime.Now;
                bllProduct.Add(xcItem);

                addItems.Add(xcItem);
            }

        }

        private string GetNCError(List<string> arrstr)
        {
            char[] TrimChar = { ' ', '-', '\'', '\"', '\\', '\n' };       //此处使用了转义字符如：\',\",\\，分别表示单引号，双引号，反斜杠

            if (arrstr.Count < 2) { return "上传NC失败，请联系管理员"; }
            var str = arrstr[1];
            var result = string.Join("", str.Skip(str.LastIndexOf("：") + 1)).Trim(TrimChar).Replace("<", "").Replace(">", "");

            return result;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order">合同信息</param>
        /// <param name="matrl">成品物料信息</param>
        /// <param name="item">组批信息</param>
        /// <param name="ssBmid">部门ID</param>
        /// <returns></returns>
        private NcRollA1 GetA1(Mod_TMO_ORDER order, Mod_TB_MATRL_MAIN matrl, Mod_TRC_ROLL_WW_MAIN item, Mod_TB_STA tBSta, Mod_TS_USER user)
        {
            var ncRollA1 = new NcRollA1
            {
                bmid = tBSta.C_SSBMID,//部门ID
                jhrq = item.D_MOD_DT,//计划日期
                jhxxsl = (item.N_WGT_TOTAL ?? 0).ToString(),//下限数量
                jhyid = matrl.C_PLANEMP,// 计划员ID
                jldwid = matrl.C_PK_MEASDOC,//计量单位
                memo = item.C_REMARK,//备注
                pk_produce = matrl.C_PK_PRODUCE,//物料PK,
                scbmid = tBSta.C_SSBMID,//生产部门ID
                shrid = item.C_PRODUCE_EMP_ID,//操作员
                shrq = DateTime.Now,//审核日期
                slrq = order.D_DT ?? DateTime.Now,//需求日期
                wlbmid = matrl.C_PK_INVBASDOC,// 存货档案主键
                xdrq = item.D_MOD_DT,//下单日期
                xqrq = order.D_DELIVERY_DT ?? DateTime.Now,//交货日期
                xqsl = (item.N_WGT_TOTAL ?? 0).ToString(),//计划量
                zdrq = DateTime.Now,//制单日期
                zyx1 = order.C_FREE1,//自由项1
                zyx2 = order.C_FREE2,//自由项2
                zyx3 = order.C_PACK,//包装要求
                zyx5 = item.C_ID,//PCI主键

            };

            return ncRollA1;
        }
        private NcRollA2 GetA2(Mod_TMO_ORDER order, Mod_TB_MATRL_MAIN matrl, Mod_TRC_ROLL_WW_MAIN item, Mod_TB_STA tBSta, Mod_TS_USER user)
        {
            var ncRollA2 = new NcRollA2
            {
                bcid = item.C_SHIFT,// 班次ID
                bzid = item.C_GROUP,// 班组ID
                fjhsl = (item.N_QUA_REMOVE ?? 0).ToString(),// 辅计量数量
                fjlid = matrl.C_FJLDW,// 辅计量ID
                freeitemvalue1 = order.C_FREE1,// 自由项1
                freeitemvalue2 = order.C_FREE2,//自由项2
                freeitemvalue3 = order.C_PACK,// 包装要求,
                freeitemvalue5 = item.C_ID,//PCI计划主键
                gzzxid = tBSta.C_ERP_PK,//工作中心ID
                invcode = matrl.C_ID,//物料编码
                jhjssj = item.D_PRODUCE_DATE_E ?? DateTime.Now,// 计划完工时间
                jhkgrq = item.D_PRODUCE_DATE_B ?? DateTime.Now,//计划开工日期
                jhkssj = item.D_PRODUCE_DATE_B ?? DateTime.Now,//计划开始时间
                jhwgrq = item.D_PRODUCE_DATE_E ?? DateTime.Now,//计划完工日期
                jhwgsl = (item.N_WGT_TOTAL ?? 0).ToString(),//计划完工数量
                jldwid = matrl.C_PK_MEASDOC,//计量单位ID
                pch = item.C_BATCH_NO,//批次号
                pk_produce = matrl.C_PK_PRODUCE,//物料PK
                scbmid = tBSta.C_SSBMID,//生产部门ID
                sjjssj = item.D_PRODUCE_DATE_E ?? DateTime.Now,//实际结束时间
                sjkgrq = item.D_PRODUCE_DATE_E ?? DateTime.Now,//完工单日期
                sjkssj = item.D_PRODUCE_DATE_B ?? DateTime.Now,//实际开始日期
                sjwgrq = item.D_PRODUCE_DATE_E ?? DateTime.Now,//实际完工日期
                sjwgsl = (item.N_WGT_REMOVE ?? 0).ToString(),//实际完工数量
                wlbmid = matrl.C_PK_INVBASDOC,//存货档案主键
                zdrid = user.C_ACCOUNT// "17384",//item.C_PRODUCE_EMP_ID,//操作人，用户编码工号
            };

            return ncRollA2;
        }
        private NcRollA3 GetA3(Mod_TMO_ORDER order, Mod_TB_MATRL_MAIN ordMatrl, Mod_TB_MATRL_MAIN matrl, Mod_TRC_ROLL_WW_MAIN item, Mod_TB_STA tBSta, Mod_TRC_ROLL_PRODCUT xcItem)
        {
            var lineWhItem = dalLineWh.GetModelByCode(item.C_XC_LINEWH_CODE);
            var ncRollA3 = new NcRollA3
            {
                ckckid = lineWhItem.C_ID,//出库仓库ID(TPB_LINEWH线材库ID)
                fjldwid = matrl.C_FJLDW,//辅助计量单位ID,
                fljcksl = (item.N_QUA_TOTAL ?? 0).ToString(),// 出库数量
                flrq = DateTime.Now.ToString("yyyy-MM-dd"),
                freeitemvalue1 = xcItem.C_ZYX1,//order.C_FREE1,// 线材自由项1(暂认为委外与线材自由项一致)
                freeitemvalue2 = xcItem.C_ZYX2,//order.C_FREE2,//线材自由项2(暂认为委外与线材自由项一致)
                freeitemvalue3 = item.C_XC_BZYQ,// 线材包装要求
                gzzxid = tBSta.C_ERP_PK,//工作中心ID
                hfreeitemvalue1 = order.C_FREE1,// 成品自由项1
                hfreeitemvalue2 = order.C_FREE2,//成品自由项2
                hfreeitemvalue3 = order.C_PACK,// 成品包装要求,
                hjldwid = ordMatrl.C_PK_MEASDOC,//主计量单位ID
                hpch = item.C_BATCH_NO,//批号
                hwlbmid = ordMatrl.C_PK_INVBASDOC,//存货档案主键
                hzdrid = item.C_PRODUCE_EMP_ID,//操作人
                hzdrq = item.D_PRODUCE_DATE_B ?? DateTime.Now,//制单日期
                jldwid = matrl.C_PK_MEASDOC,//计量单位
                kgyid = item.C_PRODUCE_EMP_ID,//库管员
                ljcksl = (item.N_WGT_TOTAL ?? 0).ToString(),//累计出库数量
                pch = item.C_XC_BATCH_NO,//线材批号
                wlbmid = matrl.C_PK_INVBASDOC,//存货档案主键
                zdrq = DateTime.Now,
            };

            return ncRollA3;
        }
        private NcRollA4 GetA4(Mod_TMO_ORDER order, Mod_TB_MATRL_MAIN ordMatrl, Mod_TRC_ROLL_WW_MAIN item, Mod_TB_STA tBSta, Mod_TS_USER user)
        {
            var ncRollA4 = new NcRollA4
            {
                ccxh = item.C_BATCH_NO,//批号
                fhgsl = (item.N_QUA_REMOVE ?? 0).ToString(),//完工数量
                freeitemvalue1 = order.C_FREE1,//自由项1
                freeitemvalue2 = order.C_FREE2,//自由项2
                freeitemvalue3 = order.C_PACK,//包装要求
                gzzxbmid = tBSta.C_STA_ERPCODE,//工作中心代码
                gzzxid = tBSta.C_ERP_PK,//工作中心ID
                hgsl = (item.N_WGT_REMOVE ?? 0).ToString(),//合格数量
                jldwid = ordMatrl.C_PK_MEASDOC,//计量单位ID
                jsrq = item.D_PRODUCE_DATE_E ?? DateTime.Now,//生产结束日期
                ksrq = item.D_PRODUCE_DATE_B ?? DateTime.Now,//生产开始日期
                pch = item.C_BATCH_NO,//批次号,
                pk_produce = ordMatrl.C_PK_PRODUCE,//物料PK
                rq = item.D_PRODUCE_DATE_E ?? DateTime.Now,//完工日期
                scbmid = tBSta.C_SSBMID,//生产部门ID
                sffsgp = "N",//是否发生改判
                sflfcp = "N",//是否联产品
                sj = DateTime.Now,//报告时间
                wlbmid = ordMatrl.C_PK_INVBASDOC,//物料编码ID
                zdrid = user.C_ACCOUNT,//item.C_PRODUCE_EMP_ID,//操作人员
            };

            return ncRollA4;
        }


        Dal_TQB_CHECKSTATE dal_TQB_CHECKSTATE = new Dal_TQB_CHECKSTATE();
        private NcRoll46 Get46(Mod_TMO_ORDER order, Mod_TB_MATRL_MAIN ordMatrl, Mod_TRC_ROLL_WW_MAIN item, Mod_TB_STA tBSta, Mod_TS_USER user)
        {
            Mod_TQB_CHECKSTATE mod_TQB_CHECKSTATE = dal_TQB_CHECKSTATE.GetModelByName(item.C_CHECKSTATE_NAME, "1001");

            var lineWhItem = dalLineWh.GetModelByCode(item.C_LINEWH_CODE);
            var ncRoll46 = new NcRoll46
            {
                castunitid = ordMatrl.C_FJLDW,//辅助计量单位ID
                ccheckstate_bid = mod_TQB_CHECKSTATE.C_ID,//"1001NC100000000052Z3",//质量等级ID
                cinvbasid = ordMatrl.C_PK_INVBASDOC,//存货基本ID
                coperatorid = user.C_ACCOUNT,//"17384",//item.C_PRODUCE_EMP_ID,//入库人
                cwarehouseid = lineWhItem.C_ID,//仓库ID
                cworkcenterid = tBSta.C_ERP_PK,
                dbizdate = DateTime.Now,//入库日期
                ninassistnum = (item.N_QUA_REMOVE ?? 0).ToString(),//入库件数
                ninnum = (item.N_WGT_REMOVE ?? 0).ToString(),//入库数量
                pk_produce = ordMatrl.C_PK_PRODUCE,//物料PK
                taccounttime = DateTime.Now,//入库签字时间
                vbatchcode = item.C_BATCH_NO,
                vfree1 = order.C_FREE1,
                vfree2 = order.C_FREE2,
                vfree3 = order.C_PACK,

            };

            return ncRoll46;
        }
        /// <summary>
        /// 获取质量等级
        /// </summary>
        /// <returns></returns>
        public List<Mod_TQB_CHECKSTATE> GetCheckstate()
        {
            var list = dal_TQB_CHECKSTATE.GetList(" C_REMARK='1001'").Tables[0].DataTableToList2<Mod_TQB_CHECKSTATE>();
            return list;
        }

        /// <summary>
        /// 获取成分录入清单
        /// </summary>
        /// <param name="c_id">外委计划ID</param>
        /// <returns></returns>
        public List<WWCFXNInfo> GetXNCFInfo(string c_id)
        {
            var wwItem = dalWWMain.GetModel(c_id);
            //wwItem.C_STL_GRD_SLAB
            var contractInfp = dalOrder.GetModel(wwItem.C_ORD_ID);

            if (contractInfp == null || wwItem == null)
            {
                return new List<WWCFXNInfo>();
            }

            // 基本成分及性能
            string basicSql = $@"
SELECT DISTINCT TSC.C_CHARACTER_ID,TC.C_NAME C_ITEM_NAME,TSC.N_DIGIT,TSC.C_TYPE,TSC.N_PRINT_ORDER,TSC.C_IS_PRINT,TSC.C_IS_DECIDE 
FROM TQB_STD_MAIN TSM 
INNER JOIN TQB_STD_CFXN TSC ON TSM.C_ID=TSC.C_STD_MAIN_ID 
INNER JOIN TQB_CHARACTER TC ON TC.C_ID=TSC.C_CHARACTER_ID 
WHERE TSM.C_IS_BXG='1' AND TSM.N_IS_CHECK=1 AND TSM.N_STATUS=1 
AND TSM.C_STL_GRD='{contractInfp.C_STL_GRD}' AND TSM.C_STD_CODE='{contractInfp.C_STD_CODE}' 
ORDER BY TSC.C_TYPE,TSC.N_PRINT_ORDER
";
            // 批次已经填写的成分
            string getWWiNFO = @"
SELECT T.C_CHARACTER_ID,T.C_ITEM_NAME,T.C_VALUE,T.C_REMARK 
FROM TQC_COMPRE_ITEM_RESULT T WHERE T.C_BATCH_NO='{0}' 
AND T.C_STL_GRD='{1}' AND T.C_STD_CODE='{2}' AND (T.C_TYPE in('成分','性能') OR T.C_TYPE IS NULL OR T.C_TYPE = '')
";

            var list = dal.GetBySql(basicSql).DataTableToList2<WWCFXNInfo>();

            var wwInfoSql = string.Format(getWWiNFO, wwItem.C_BATCH_NO, contractInfp.C_STL_GRD, contractInfp.C_STD_CODE);
            var values = dal.GetBySql(wwInfoSql).DataTableToList2<WWCFXNInfo>();

            if (values.Any() == false)
            {
                // 如果没有保存，则使用线材成分性能填充数据
                var xcInfoSql = string.Format(getWWiNFO, wwItem.C_XC_BATCH_NO.Substring(0, 9), contractInfp.C_STL_GRD, contractInfp.C_STD_CODE);

                var infoValues = dal.GetBySql(xcInfoSql).DataTableToList2<WWCFXNInfo>();

                values.AddRange(infoValues);
            }
            else
            {
                var grp = values.GroupBy(w => new { w.C_CHARACTER_ID, w.C_ITEM_NAME, w.C_REMARK })
                    .Select(x => new WWCFXNInfo
                    {
                        C_CHARACTER_ID = x.Key.C_CHARACTER_ID,
                        C_ITEM_NAME = x.Key.C_ITEM_NAME,
                        C_REMARK = x.Key.C_REMARK,
                        C_VALUE = x.ElementAtOrDefault(0)?.C_VALUE,
                        C_VALUE1 = x.ElementAtOrDefault(1)?.C_VALUE,
                        C_VALUE2 = x.ElementAtOrDefault(2)?.C_VALUE,
                        C_VALUE3 = x.ElementAtOrDefault(3)?.C_VALUE,
                    }).ToList();
                values.Clear();
                values.AddRange(grp);
            }

            foreach (var item in list)
            {
                var valueItem = values.FirstOrDefault(w =>
                    w.C_CHARACTER_ID == item.C_CHARACTER_ID &&
                    w.C_ITEM_NAME == item.C_ITEM_NAME);

                if (valueItem != null)
                {
                    item.C_VALUE = valueItem.C_VALUE;
                    item.C_VALUE1 = valueItem.C_VALUE1;
                    item.C_VALUE2 = valueItem.C_VALUE2;
                    item.C_VALUE3 = valueItem.C_VALUE3;
                    item.C_REMARK = valueItem.C_REMARK;
                }
            }

            return list;
        }

        /// <summary>
        /// 保存录入成分
        /// </summary>
        /// <param name="cId"></param>
        /// <param name="list"></param>
        public void SaveCf(string cId, List<WWCFXNInfo> list, string userId)
        {
            var wwItem = dalWWMain.GetModel(cId);
            //wwItem.C_STL_GRD_SLAB
            var contractInfp = dalOrder.GetModel(wwItem.C_ORD_ID);

            if (contractInfp == null || wwItem == null)
            {
                throw new Exception("数据不存在，请刷新页面重试");
            }

            if (list.Any() == false)
            {
                throw new Exception("没有数据可以保存");
            }

            // 查询质量标准号
            var designNo = dalWWMain.GetDesignNo(wwItem.C_STD_CODE, wwItem.C_STL_GRD_SLAB); ;

            List<Mod_TQC_COMPRE_ITEM_RESULT> addItems = new List<Mod_TQC_COMPRE_ITEM_RESULT>();
            foreach (var item in list)
            {
                var addItem = new Mod_TQC_COMPRE_ITEM_RESULT
                {
                    C_ID = Guid.NewGuid().ToString("N"),
                    C_STOVE = string.Empty,//炉号
                    C_BATCH_NO = wwItem.C_BATCH_NO,//批号
                    C_STL_GRD = contractInfp.C_STL_GRD,//钢种
                    C_SPEC = contractInfp.C_SPEC,//规格
                    C_STD_CODE = contractInfp.C_STD_CODE,//执行标准
                    C_CHARACTER_ID = item.C_CHARACTER_ID,//检验基础数据外键
                    C_ITEM_NAME = item.C_ITEM_NAME,//项目名称
                    C_TYPE = item.C_TYPE,
                    C_VALUE = item.C_VALUE,
                    D_MOD_DT = DateTime.Now,
                    C_EMP_ID = userId,//操作人
                    C_TB = "N",
                    N_STATUS = 1,
                    C_REMARK = item.C_REMARK,
                    C_GROUP = "1",
                    C_DESIGN_NO = designNo,
                    C_IS_DECIDE = item.C_IS_DECIDE,
                    C_IS_SHOW = item.C_IS_PRINT
                };
                addItems.Add(addItem);

                if (string.IsNullOrEmpty(item.C_VALUE1) == false)
                {
                    var item1 = addItem.Clone();
                    item1.C_VALUE = item.C_VALUE1;
                    item1.C_GROUP = "2";
                    addItems.Add(item1);
                }
                if (string.IsNullOrEmpty(item.C_VALUE2) == false)
                {
                    var item1 = addItem.Clone();
                    item1.C_VALUE = item.C_VALUE2;
                    item1.C_GROUP = "3";
                    addItems.Add(item1);
                }
                if (string.IsNullOrEmpty(item.C_VALUE3) == false)
                {
                    var item1 = addItem.Clone();
                    item1.C_VALUE = item.C_VALUE3;
                    item1.C_GROUP = "4";
                    addItems.Add(item1);
                }
            }

            dal.AddCompreItem(cId, wwItem.C_BATCH_NO, addItems);
        }

        /// <summary>
        /// 委外转库
        /// </summary>
        /// <param name="lineCode">目标仓库</param>
        /// <param name="inventoryItems">转库数据</param>
        public void SaveInventory(string lineCode, List<WWInventoryItem> inventoryItems, string userId)
        {
            // 目标仓库验证
            var listCk = bllProduct.GetWWCK();

            if (listCk.Any(x => x.C_LINEWH_CODE == lineCode) == false)
            {
                throw new Exception("外委仓库不存在");
            }

            if (inventoryItems.Any() == false)
            {
                throw new Exception("没有要操作的数据");
            }

            dal.SaveInventory(lineCode, inventoryItems, userId);
        }

        /// <summary>
        /// 转库
        /// </summary>
        /// <param name="arrId"></param>
        public void SyncZKD(params string[] arrId)
        {
            // 验证转库单
            dal.SyncWWZKD(arrId);
        }

        /// <summary>
        /// 钢种统计查询
        /// </summary>
        /// <param name="stdGrd"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public object StatiChartGrd(string stdGrd, DateTime begin, DateTime end)
        {
            string sqlwhere = string.Empty;

            if (!string.IsNullOrEmpty(stdGrd))
            {
                sqlwhere += $"and (t.c_stl_grd like '%{stdGrd}%' or c_mat_name like '%{stdGrd}%')";
            }

            string sql = $@"
select *
  from (select t.C_MAT_NAME, t.C_STL_GRD, sum(t.n_wgt) N_WGT
          from TMO_CON_ORDER t
         where t.N_STATUS = 2
           and t.D_DT between to_date('{begin.ToString("yyyy-MM-dd")}', 'yyyy-MM-dd HH24:mi:ss') 
           and to_date('{end.ToString("yyyy-MM-dd")}', 'yyyy-MM-dd HH24:mi:ss')
           {sqlwhere}
         group by t.C_STL_GRD, t.c_mat_name)
 order by c_mat_name desc, C_STL_GRD desc
";
            var table = dal.GetBySql(sql);

            return table.Select().Select(w => new
            {
                C_MAT_NAME = w[0],
                C_STL_GRD = w[1],
                N_WGT = w[2]
            }).ToList();
        }
        /// <summary>
        /// 客户统计查询
        /// </summary>
        /// <param name="cus"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public object GetCusChart(string cus, DateTime begin, DateTime end)
        {
            string sqlwhere = string.Empty;
            if (!string.IsNullOrEmpty(cus))
            {
                sqlwhere += $"and t.c_name like '%{cus}%'";
            }
            string sql = $@"
select t.C_NAME, a.N_WGT  from ts_custfile t,
       (select c_cust_no, sum(n_wgt) as n_wgt
          from TMO_CON_ORDER
         where N_STATUS = 2 
         and D_DT between to_date('{begin.ToString("yyyy-MM-dd")}', 'yyyy-MM-dd HH24:mi:ss') 
         and to_date('{end.ToString("yyyy-MM-dd")}', 'yyyy-MM-dd HH24:mi:ss')
         group by c_cust_no) a
 where t.c_no = a.c_cust_no and t.n_status = 1
 {sqlwhere}
 group by t.c_name, a.n_wgt, t.c_areammax
";
            var table = dal.GetBySql(sql);

            return table.Select().Select(w => new
            {
                C_NAME = w[0],
                N_WGT = w[1]
            }).ToList();
        }

        public void LogHeartBeat(string user, string token)
        {
            dal.RemoveTimeOutUser();
            dal.LoginToHeartBeat(user, token);
        }

        /// <summary>
        /// 验证用户心跳
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool ValidateHeartBeat(string user, string token)
        {
            if (dal.HasHeartBeat(user, token))
            {
                dal.RefreshHeartBeat(user, token);

                return true;
            }

            return false;
        }

        public bool HasOtherUser(string account)
        {
            return dal.HasOtherUser(account);
        }

        /// <summary>
        /// 同步数据字典配置的同步存储过程
        /// </summary>
        /// <param name="arr"></param>
        public void SyncDic(params string[] arr)
        {
            dal.SyncDic(arr);
        }

        public object GetProduct(string type, string keyword, int pageIndex, int pageSize)
        {
            return dal.GetProduct(type, keyword, pageIndex, pageSize);
        }

        public object GetProductType()
        {
            return dal.GetProductType();
        }

        public void UpdateDetail(
            List<string> arrAllId,
            List<string> arrUpdateId,
            decimal txtamt,
            string moveType)
        {
            dal.UpdateDetail(arrAllId, arrUpdateId, txtamt, moveType);
        }
    }
}
