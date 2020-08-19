
using NF.BLL;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System;
using NF.MODEL;
using Newtonsoft.Json;
using NF.MODEL.Dto;
using NF.Framework;
using System.Linq.Expressions;

namespace CRM.Controllers
{
    public class OutsourcingController : Controller
    {
        Bll_TMO_ORDER bll = new Bll_TMO_ORDER();
        Bll_TRC_ROLL_PRODCUT bll_Product = new Bll_TRC_ROLL_PRODCUT();

        private void GoToLogin(bool parent = false)
        {
            if (parent == false)
            {
                Response.Write("<script>window.parent.loginOut();</script>");// "/Auth/Login");
                Response.End();
            }
            else
            {
                Response.Redirect("/Auth/Login");
            }
        }

        [AllowAnonymous]
        public ViewResult Plan(PlanSearchCondition condition)
        {
            //string user = Request.Headers.cur
            var list = bll.GetWWOrdList(
                condition?.Gz, condition?.Zxbz, condition?.Gg,
                condition?.Kh, condition?.Wl, condition?.Ht, condition?.LineWhCode,
                condition?.BeginTime, condition?.EndTime);
            //var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            ViewBag.PlanData = list;

            // 委外仓库
            ViewBag.ListCK = bll_Product.GetWWCK();

            return View(condition);
        }

        [AllowAnonymous]
        public ViewResult ZP(string id, string lineCode = "", string errorMsg = "")
        {
            if (!string.IsNullOrEmpty(errorMsg))
            {
                ViewBag.ErrorMsg = errorMsg;
            }

            var mdl = bll.GetModel(id);

            var list = new List<NF.MODEL.Mod_TRC_ROLL_PRODCUT>();

            if (mdl != null)
            {
                list.AddRange(bll_Product.GetByGzAndZxbz(mdl.C_STL_GRD, mdl.C_STD_CODE, mdl.C_SPEC, lineCode));
            }

            ViewBag.ProductData = list.GroupBy(w => new
            {
                w.C_BATCH_NO,
                w.C_STL_GRD,
                w.C_STD_CODE,
                w.C_SPEC,
                w.C_MAT_CODE,
                w.C_MAT_DESC,
                w.C_LINEWH_CODE,
                w.C_BZYQ,
                w.C_JUDGE_LEV_ZH
            }).Select(w => new ProductGrpInfo
            {
                BatchNo = w.Key.C_BATCH_NO,
                Spec = w.Key.C_SPEC,
                StdCode = w.Key.C_STD_CODE,
                StlGrd = w.Key.C_STL_GRD,
                Count = w.Count(),
                Wgt = w.Sum(x => x.N_WGT),
                MtrlCode = w.Key.C_MAT_CODE,
                MtrlName = w.Key.C_MAT_DESC,
                InventoryCode = w.Key.C_LINEWH_CODE,
                BZYQ = w.Key.C_BZYQ,
                ZLDJ = w.Key.C_JUDGE_LEV_ZH
            }).OrderBy(w => w.BatchNo).ThenBy(w => w.StdCode).ThenBy(w => w.Spec).ToList();

            // 合同ID
            ViewBag.ContractId = id;

            GetBcBz();

            return View();
        }

        [AllowAnonymous]
        public RedirectToRouteResult SaveZP(WWZPPlanItemInfo zpInfo)
        {
            try
            {
                zpInfo.BachNo = zpInfo.BachNo.Trim();

                if (zpInfo.BachNo == zpInfo.CBatchNo)
                {
                    throw new Exception("请修改批号后再组批");
                }
                var user = System.Web.HttpContext.Current.Session["CurrentUser"] as CurrentUser;

                if (user == null)
                {
                    GoToLogin();
                    return null;
                }

                bll.SetZpInfo(zpInfo, user?.Id);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
            }

            if (ViewBag.ErrorMsg != null)
            {
                return RedirectToAction(nameof(ZP), new { id = zpInfo.Id, errorMsg = ViewBag.ErrorMsg });
            }

            CloseDialogAndRefreshParentPage();
            return null;
        }

        /// <summary>
        /// 调用Plan页面刷新方法，关闭弹出窗口
        /// </summary>
        private void CloseDialogAndRefreshParentPage()
        {
            Response.Write($"<script>window.parent.btnClick();</script>");
            Response.End();
        }

        [AllowAnonymous]
        public ViewResult ZPManager(string id, string errorMsg = "")
        {
            if (!string.IsNullOrEmpty(errorMsg))
            {
                ViewBag.ErrorMsg = errorMsg;
            }

            var mdl = bll.GetModel(id);

            var list = new List<NF.MODEL.Mod_TRC_ROLL_WW_MAIN>();

            if (mdl != null)
            {
                list.AddRange(bll_Product.GetZPItems(mdl.C_ID));
            }

            ViewBag.ProductData = list;

            // 合同ID
            ViewBag.ContractId = id;
            return View();
        }

        [AllowAnonymous]
        public RedirectToRouteResult CancelZP(string itemId, decimal num, string conractId)
        {
            // 撤批
            try
            {
                bll.CancelZpInfo(itemId, num);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
            }

            if (ViewBag.ErrorMsg != null)
            {
                return RedirectToAction(nameof(ZPManager), new { id = conractId, errorMsg = ViewBag.ErrorMsg });
            }

            CloseDialogAndRefreshParentPage();
            return null;
        }

        [AllowAnonymous]
        public ViewResult Product(ProductSearchCondition condition, string errorMsg = "", bool isloadCondition = false)
        {
            //condition.BeginTime = DateTime.Today;

            if (isloadCondition)
            {
                condition = TempData["condition"] as ProductSearchCondition;
            }

            if (string.IsNullOrEmpty(errorMsg) == false)
            {
                ViewBag.ErrorMsg = errorMsg;
            }

            GetBcBz();

            ViewBag.ListCK = bll_Product.GetWWCK();

            ViewBag.PlanData = bll.GetProductList(
                condition?.Ph, condition?.Gz, condition?.Zxbz, condition?.Gg, condition?.Wl,
                condition?.BeginTime, condition?.EndTime);
            // 质量等级选择框数据源
            ViewBag.CheckStateList = bll.GetCheckstate();

            TempData["condition"] = condition;

            // 外委报工
            return View(condition);
        }

        private void GetBcBz()
        {
            ViewBag.ListBC = bll_Product.GetBc();
            ViewBag.ListBZ = bll_Product.GetBz();
        }

        public RedirectToRouteResult SetFinish(Mod_TRC_ROLL_WW_MAIN model)
        {
            try
            {
                // 验证仓库
                var list = bll_Product.GetWWCK();
                var ckItem = list.FirstOrDefault(x => x.C_LINEWH_CODE == model.C_LINEWH_CODE);
                if (ckItem == null)
                {
                    throw new Exception("入库仓库未输入或不存在，请确认数据正确后再完工");
                }

                model.C_LINEWH_NAME = ckItem.C_LINEWH_NAME;
                var user = System.Web.HttpContext.Current.Session["CurrentUser"] as CurrentUser;

                if (user == null)
                {
                    GoToLogin(true);
                    return null;
                }

                bll.SetFinish(model, user?.Id);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
            }

            return RedirectToAction(nameof(Product), new
            {
                errorMsg = ViewBag.ErrorMsg,
                isloadCondition = true
            });
        }

        public RedirectToRouteResult UpdateBatchNo(string zpId, string zpNewBatchNo)
        {
            try
            {
                bll.UpdateBatchNo(zpId, zpNewBatchNo);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
            }

            return RedirectToAction(nameof(Product), new
            {
                errorMsg = ViewBag.ErrorMsg,
                isloadCondition = true
            });
        }

        public RedirectToRouteResult SetCancel(Mod_TRC_ROLL_WW_MAIN model)
        {
            try
            {
                bll.SetCancel(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
            }

            return RedirectToAction(nameof(Product), new
            {
                errorMsg = ViewBag.ErrorMsg,
                isloadCondition = true
            });
        }

        [AllowAnonymous]
        public RedirectToRouteResult ResetPlan(string cId)
        {
            // 撤销组批计划
            try
            {
                var user = System.Web.HttpContext.Current.Session["CurrentUser"] as CurrentUser;

                bll.ResetPlan(cId);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
            }

            return RedirectToAction(nameof(Product), new
            {
                errorMsg = ViewBag.ErrorMsg,
                isloadCondition = true
            });
        }

        public RedirectToRouteResult SendToNC(string idStr)
        {
            try
            {
                // 上传NC
                bll.SendToNC(idStr.Split(',').ToList());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
            }

            return RedirectToAction(nameof(Product), new
            {
                errorMsg = ViewBag.ErrorMsg
            });

        }

        [AllowAnonymous]
        public ViewResult CfXnManager(string id, string errorMsg = "")
        {
            if (!string.IsNullOrEmpty(errorMsg))
            {
                ViewBag.ErrorMsg = errorMsg;
            }

            var result = bll.GetXNCFInfo(id); ;
            if (result.Any() == false)
            {
                // 添加测试数据
                //result.Add(new WWCFXNInfo { C_CHARACTER_ID = "1", C_ITEM_NAME = "test", C_TYPE = "成分" });
                //result.Add(new WWCFXNInfo { C_CHARACTER_ID = "2", C_ITEM_NAME = "test", C_TYPE = "性能" });
            }
            ViewBag.SourceList = result;
            ViewBag.WWCid = id;
            return View();
        }

        [AllowAnonymous]
        public RedirectToRouteResult SaveCf(string cId, List<WWCFXNInfo> list)
        {
            try
            {
                var user = System.Web.HttpContext.Current.Session["CurrentUser"] as CurrentUser;
                bll.SaveCf(cId, list, user?.Id);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
            }

            if (ViewBag.ErrorMsg != null)
            {
                return RedirectToAction(nameof(CfXnManager), new { id = cId, errorMsg = ViewBag.ErrorMsg });
            }

            CloseDialogAndRefreshParentPage();
            return null;
        }

        [AllowAnonymous]
        public ViewResult InventoryManager(PlanSearchCondition condition, string errorMsg = "", bool isloadCondition = false)
        {
            if (isloadCondition)
            {
                condition = TempData["inventory_condition"] as PlanSearchCondition;
            }

            if (string.IsNullOrEmpty(errorMsg) == false)
            {
                ViewBag.ErrorMsg = errorMsg;
            }

            // 委外仓库
            ViewBag.ListCK = bll_Product.GetWWCK();

            // 委外转库线材
            var list = new List<NF.MODEL.Mod_TRC_ROLL_PRODCUT>();

            list.AddRange(bll_Product.GetByWWCK(condition?.LineWhCode, condition?.Gz, condition?.Zxbz, condition?.Gg, condition?.SearchBatchNo));

            var listzkd = new List<NF.MODEL.ZKDInfoDto>();
            var user = System.Web.HttpContext.Current.Session["CurrentUser"] as CurrentUser;

            listzkd.AddRange(bll_Product.GetWWZKD(user?.Id, condition?.SearchBatchNo));
            ViewBag.ZKDData = listzkd;

            var ncList = bll_Product.GetNCInventory(condition?.LineWhCode, condition?.Gz, condition?.Zxbz, condition?.Gg, condition?.SearchBatchNo);

            ViewBag.InventoryData = list.GroupBy(w => new
            {
                w.C_BATCH_NO,
                w.C_STL_GRD,
                w.C_STD_CODE,
                w.C_SPEC,
                w.C_MAT_CODE,
                w.C_MAT_DESC,
                w.C_LINEWH_CODE,
                w.C_BZYQ,
                w.C_JUDGE_LEV_ZH,
                w.C_SALE_AREA
            }).Select(w =>
            {
                Expression<Func<NCInventoryDto, bool>> expre = x =>
                    x.StdCode == w.Key.C_STD_CODE &
                    x.StlGrd == w.Key.C_STL_GRD &
                    x.MtrlCode == w.Key.C_MAT_CODE &
                    x.ZLDJ == w.Key.C_JUDGE_LEV_ZH;

                if (string.IsNullOrEmpty(w.Key.C_BZYQ))
                {
                    expre = expre.And(x => string.IsNullOrEmpty(x.BZYQ) == string.IsNullOrEmpty(w.Key.C_BZYQ));
                }
                else
                {
                    expre = expre.And(x => x.BZYQ == w.Key.C_BZYQ);
                }

                var expre1 = expre.And(l => l.BatchNo == w.Key.C_BATCH_NO);

                var ncItem = ncList.FirstOrDefault(expre1.Compile());

                if (ncItem == null)
                {
                    var expre2 = expre.And(l => l.BatchNo.Contains(w.Key.C_BATCH_NO));
                    ncItem = ncList.FirstOrDefault(expre2.Compile());
                }

                var item = new ProductGrpInfo
                {
                    BatchNo = w.Key.C_BATCH_NO,
                    Spec = w.Key.C_SPEC,
                    StdCode = w.Key.C_STD_CODE,
                    StlGrd = w.Key.C_STL_GRD,
                    Count = w.Count(),
                    Wgt = w.Sum(x => x.N_WGT),
                    MtrlCode = w.Key.C_MAT_CODE,
                    MtrlName = w.Key.C_MAT_DESC,
                    InventoryCode = w.Key.C_LINEWH_CODE,
                    BZYQ = w.Key.C_BZYQ,
                    ZLDJ = w.Key.C_JUDGE_LEV_ZH,
                    SalesArea = w.Key.C_SALE_AREA,
                    NCCount = ncItem?.Count ?? 0,
                    NCWgt = ncItem?.Wgt ?? 0,
                    NCBatchNO = ncItem?.BatchNo
                };

                ncList.Remove(ncItem);

                return item;
            }).OrderBy(w => w.BatchNo).ThenBy(w => w.StlGrd).ThenBy(w => w.Spec).ToList();

            // 用于在Action中传递查询条件
            TempData["inventory_condition"] = condition;

            return View(condition);
        }

        [AllowAnonymous]
        public RedirectToRouteResult SaveInventory(string lineWhCode, string zkJson)
        {
            // 目标仓库ID,转库JSON数据
            try
            {
                if (string.IsNullOrEmpty(zkJson) == false)
                {
                    var result = JsonConvert.DeserializeObject<List<WWInventoryItem>>(zkJson);

                    if (result.Any(w => w.InventoryCode == lineWhCode))
                    {
                        throw new Exception("仓库不能与转库仓库一样");
                    }
                    var user = System.Web.HttpContext.Current.Session["CurrentUser"] as CurrentUser;

                    if (user == null)
                    {
                        GoToLogin(true);
                        return null;
                    }

                    bll.SaveInventory(lineWhCode, result, user?.Id);
                }
            }
            catch (Exception ex)
            {
                char[] TrimChar = { ' ', '-', '\'', '\"', '\\', '\n' };       //此处使用了转义字符如：\',\",\\，分别表示单引号，双引号，反斜杠
                ViewBag.ErrorMsg = ex.Message.Trim(TrimChar);
            }


            return RedirectToAction(nameof(InventoryManager), new
            {
                errorMsg = ViewBag.ErrorMsg,
                isloadCondition = true
            });
        }

        [AllowAnonymous]
        public RedirectToRouteResult CancelZK()
        {
            return null;
        }

        [AllowAnonymous]
        public RedirectToRouteResult SyncZk(string id)
        {
            try
            {
                var user = System.Web.HttpContext.Current.Session["CurrentUser"] as CurrentUser;

                bll.SyncZKD(id);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
            }

            return RedirectToAction(nameof(InventoryManager), new
            {
                errorMsg = ViewBag.ErrorMsg,
                isloadCondition = true
            });
        }

        [AllowAnonymous]
        public ViewResult NCInventory(PlanSearchCondition condition, string errorMsg = "", bool isloadCondition = false)
        {
            if (isloadCondition)
            {
                condition = TempData["nc_inventory_condition"] as PlanSearchCondition;
            }

            if (string.IsNullOrEmpty(errorMsg) == false)
            {
                ViewBag.ErrorMsg = errorMsg;
            }

            // 委外仓库
            ViewBag.ListCK = bll_Product.GetWWCK();

            // 委外转库线材
            var list = new List<NCInventoryDto>();

            list.AddRange(bll_Product.GetNCInventory(condition?.LineWhCode, condition?.Gz, condition?.Zxbz, condition?.Gg, condition?.SearchBatchNo));

            ViewBag.InventoryData = list.OrderBy(w => w.BatchNo).ThenBy(w => w.StlGrd).ThenBy(w => w.Spec).ToList();

            // 用于在Action中传递查询条件
            TempData["nc_inventory_condition"] = condition;

            return View(condition);
        }

        [AllowAnonymous]
        public RedirectToRouteResult SyncInventory(WWInventoryItem item)
        {
            try
            {
                var user = System.Web.HttpContext.Current.Session["CurrentUser"] as CurrentUser;

                bll_Product.SyncInventory(item, user?.Id);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
            }

            return RedirectToAction(nameof(NCInventory), new
            {
                errorMsg = ViewBag.ErrorMsg,
                isloadCondition = true
            });
        }

        [AllowAnonymous]
        public JsonResult Check(string token)
        {
            var user = System.Web.HttpContext.Current.Session["CurrentUser"] as CurrentUser;
            string account =
            //   "system";
            user?.Account;

            if (string.IsNullOrEmpty(account))
            {
                return Json(new
                {
                    success = false,
                    token = token
                }, JsonRequestBehavior.AllowGet);
            }

            if (new string[] { "system" }.Any(x => x == account))
            {
                return Json(new
                {
                    success = true,
                    token = token
                }, JsonRequestBehavior.AllowGet);
            }

            if (string.IsNullOrEmpty(token))
            {
                // 第一次登录颁发token
                token = Guid.NewGuid().ToString("N");
                bll.LogHeartBeat(account, token);

                return Json(new
                {
                    success = true,
                    token = token
                }, JsonRequestBehavior.AllowGet);
            }

            // 验证是否存在，如果不存在，则强制退出
            var hasBeath = bll.ValidateHeartBeat(account, token);

            if (hasBeath == false)
            {
                this.HttpContext.UserLogOut();
            }

            return Json(new
            {
                success = hasBeath,
                token = token
            }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult SyncDic(string[] arrCode)
        {
            if (arrCode.Any() == false)
            {
                return Json(new { success = false, msg = "未找到同步过程" }, JsonRequestBehavior.AllowGet);
            }
            try
            {
                bll.SyncDic(arrCode);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ViewResult InventoryDetail(InventoryDetailCondition condition, string errorMsg = "", bool isrefreshCondition = false)
        {
            if (isrefreshCondition)
            {
                condition = TempData["INVENTORY_DETIAL_CONDITION"] as InventoryDetailCondition;
            }

            if (string.IsNullOrEmpty(errorMsg) == false)
            {
                ViewBag.ErrorMsg = errorMsg;
            }

            // 库存钢材信息
            var batchInfo = new Bll_TRC_ROLL_PRODCUT().GetByBatchNo(
                condition?.batchNo,
                condition?.gz,
                condition?.zxbz,
                condition?.wl,
                condition?.ck,
                condition?.zldj,
                condition?.bzyq,
                true).OrderBy(w => w.C_ID).ToList();

            ViewBag.ListData = batchInfo;

            TempData["INVENTORY_DETIAL_CONDITION"] = condition;

            return View();
        }

        [AllowAnonymous]
        public RedirectToRouteResult UpdateDetail(
            List<string> arrAllId,
            List<string> arrUpdateId,
            decimal txtamt,
            string moveType)
        {
            try
            {
                bll.UpdateDetail(arrAllId, arrUpdateId, txtamt, moveType);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
            }

            return RedirectToAction(nameof(InventoryDetail), new
            {
                errorMsg = ViewBag.ErrorMsg,
                isrefreshCondition = true,
            });
        }

        public RedirectToRouteResult UpdateToNcBatchNo(InventoryDetailCondition condition)
        {
            try
            {
                // 库存钢材信息
                var batchInfo = new Bll_TRC_ROLL_PRODCUT().GetByBatchNo(
                condition?.batchNo,
                condition?.gz,
                condition?.zxbz,
                condition?.wl,
                condition?.ck,
                condition?.zldj,
                condition?.bzyq,
                true).OrderBy(w => w.C_ID).ToList();

                bll.UpdateToNcBatchNo(condition?.ck, condition?.gz, condition?.zxbz,
                    condition?.gg, condition?.batchNo, condition?.wl,
                    condition?.zldj, condition?.bzyq, batchInfo);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
            }

            return RedirectToAction(nameof(InventoryManager), new
            {
                errorMsg = ViewBag.ErrorMsg,
                isloadCondition = true,
            });
        }
    }

    /// <summary>
    /// 委外排产计划查询条件
    /// </summary>
    public class PlanSearchCondition
    {
        /// <summary>
        /// 钢种
        /// </summary>
        public string Gz { get; set; }
        /// <summary>
        /// 执行标准
        /// </summary>
        public string Zxbz { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Gg { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public string Kh { get; set; }
        /// <summary>
        /// 物料
        /// </summary>
        public string Wl { get; set; }

        /// <summary>
        /// 合同
        /// </summary>
        public string Ht { get; set; }

        /// <summary>
        /// 批号
        /// </summary>
        public string Ph { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string LineWhCode { get; set; }

        /// <summary>
        /// 订单日期，开始日期
        /// </summary>
        public virtual DateTime? BeginTime { get; set; } = DateTime.Today.AddMonths(-2);
        /// <summary>
        /// 订单日期，结束日期
        /// </summary>
        public DateTime? EndTime { get; set; } = DateTime.Today;

        /// <summary>
        /// 查询的批次号
        /// </summary>
        public string SearchBatchNo { get; set; }
    }
    public class ProductSearchCondition : PlanSearchCondition
    {
        public override DateTime? BeginTime { get; set; } = DateTime.Today;
    }

    /// <summary>
    /// 线材按批次汇总信息
    /// </summary>
    public class ProductGrpInfo
    {
        /// <summary>
        /// 批号
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 钢种
        /// </summary>
        public string StlGrd { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Spec { get; set; }

        /// <summary>
        /// 执行标准
        /// </summary>
        public string StdCode { get; set; }

        /// <summary>
        /// 总支数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 总重量
        /// </summary>
        public decimal Wgt { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string MtrlCode { get; set; }

        /// <summary>
        /// 物料描述
        /// </summary>
        public string MtrlName { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string InventoryCode { get; set; }

        /// <summary>
        /// 包装要求
        /// </summary>
        public string BZYQ { get; set; }

        /// <summary>
        /// 质量等级
        /// </summary>
        public string ZLDJ { get; set; }

        /// <summary>
        /// 销售区域
        /// </summary>
        public string SalesArea { get; set; }

        /// <summary>
        /// NC数量
        /// </summary>
        public int NCCount { get; set; }

        /// <summary>
        /// NC重量
        /// </summary>
        public decimal NCWgt { get; set; }

        /// <summary>
        /// NC批号
        /// </summary>
        public string NCBatchNO { get; set; }

        public ProductGrpInfo Clone()
        {
            return new ProductGrpInfo
            {
                Wgt = this.Wgt,
                BatchNo = this.BatchNo + "_1",
                Count = ++this.Count,
                Spec = this.Spec,
                StdCode = this.StdCode,
                StlGrd = this.StlGrd
            };
        }

        public static Func<decimal, string> getStatu = (decimal statu) =>
        {
            switch ((int)statu)
            {
                case 0:
                    return "待执行";
                case 1:
                    return "已完工";
                case 21:
                    return "已传NC_A1";
                case 22:
                    return "已传NC_A2";
                case 23:
                    return "已传NC_A3";
                case 24:
                    return "已传NC_A4";
                case 25:
                    return "已传NC_46";
                case 30:
                    return "完成";
                default: break;
            }

            return string.Empty;
        };
    }

    public class InventoryDetailCondition
    {
        public string batchNo { get; set; }
        public string gz { get; set; }
        public string zxbz { get; set; }
        public string gg { get; set; }
        public string ck { get; set; }
        public string wl { get; set; }
        public string bzyq { get; set; }
        public string zldj { get; set; }
    }
}
