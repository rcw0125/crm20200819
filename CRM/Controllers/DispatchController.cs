using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NF.Bussiness.Interface;
using NF.Web.Core;
using Microsoft.Practices.Unity;
using NF.EF.Model;
using NF.Framework.DTO;
using NF.Framework;
using NF.DAL;

namespace CRM.Controllers
{
    public class DispatchController : BaseController
    {
        IPlanService service = DIFactory.GetContainer().Resolve<IPlanService>();
        IComService comService = DIFactory.GetContainer().Resolve<IComService>();
        IBasicsDataService basicsService = DIFactory.GetContainer().Resolve<IBasicsDataService>();

        /// <summary>
        /// 获取合同列表
        /// </summary>
        /// <returns></returns>
        [RenderFilter]
        public ActionResult ConDetails()
        {
            TMO_CONDETAILSDTO conDto = new TMO_CONDETAILSDTO();
            conDto.Dispatch = new TMD_DISPATCHDTO();
            //获取地区信息
            conDto.AreaMaxs = basicsService.GetAreaMax();
            //订单类型8线材 6钢坯
            conDto.N_TYPE = 8;
            //默认发运日期
            conDto.Dispatch.D_DISP_DT = DateTime.Now;
            //计划交货日期
            conDto.Start = DateTime.Now;
            conDto.End = DateTime.Now.AddMonths(2);
            //发运失效日期
            conDto.Dispatch.D_FAILURE = DateTime.Now.AddDays(1);
            //获取订单列表
            PageResult<TMO_ORDER> ef = new PageResult<TMO_ORDER>();
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF转换DTO实体模型
            //conDto.ConDetails = MAPPING.ConvertEntityToDtoList<TMO_CONDETAILS, TMO_CONDETAILSDTO>(ef.DataList);
            return View(conDto);
        }

        /// <summary>
        /// 获取合同列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [RenderFilter]
        public ActionResult ConDetails(TMO_CONDETAILSDTO conDto)
        {
            //获取地区信息
            conDto.AreaMaxs = basicsService.GetAreaMax();
            //获取模型列表
            PageResult<TMO_ORDER> ef = service.GetConDetails(conDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF转换DTO实体模型
            conDto.ConDetails = MAPPING.ConvertEntityToDtoList<TMO_ORDER, TMO_CONDETAILSDTO>(ef.DataList);
            //确认订单类型
            if (conDto.ConDetails != null && conDto.ConDetails.Count > 0)
                conDto.ConfirmOrderType = conDto.ConDetails[0].N_TYPE;
            return View(conDto);
        }

        /// <summary>
        /// 获取发运日计划列表(根据合同号)
        /// </summary>
        /// <param name="no">合同编号</param>
        /// <returns></returns>
        [RenderFilter]
        public ActionResult Plan(string no)
        {
            TMP_PLANDTO planDto = new TMP_PLANDTO();
            planDto.Plans = service.GetPlans(no);
            ViewData["plans"] = planDto;
            ViewData["no"] = no;
            return PartialView("~/Views/Dispatch/_Plan.cshtml");
        }

        /// <summary>
        /// 发运日计划新增
        /// </summary>
        /// <returns></returns>
        public ActionResult PlanInsert(string no)
        {
            TMP_PLANDTO planDto = new TMP_PLANDTO();
            planDto = service.GetPlan(no, BaseUser);
            planDto.Title = "发运计划新增";
            return View(planDto);
        }

        /// <summary>
        /// 发运日计划新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PlanInsert(TMP_PLANDTO planDto)
        {
            planDto.C_EMP_ID = BaseUser.Id;
            planDto.C_EMP_NAME = BaseUser.Name;
            planDto.D_MOD_DT = DateTime.Now;
            service.PlanInsert(planDto);
            return MessageBox("新增成功");
        }

        /// <summary>
        /// 发运日计划修改
        /// </summary>
        /// <returns></returns>
        public ActionResult PlanUpdate(string no)
        {
            TMP_PLANDTO planDto = new TMP_PLANDTO();
            planDto = service.GetPlan(no);
            planDto.Title = "发运计划修改";
            return View("PlanInsert", planDto);
        }

        /// <summary>
        /// 发运日计划修改
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PlanUpdate(TMP_PLANDTO planDto)
        {
            planDto.Title = "发运计划修改";
            service.PlanUpdate(planDto);
            return MessageBox("修改成功");
        }

        /// <summary>
        /// 查询发运计划
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public ActionResult PlanQuery(string no)
        {
            TMP_PLANDTO planDto = new TMP_PLANDTO();
            planDto = service.GetPlan(no);
            planDto.Title = "发运计划修改";
            return View(planDto);
        }

        /// <summary>
        /// 合同详情列表
        /// </summary>
        /// <returns></returns>
        [RenderFilter]
        public ActionResult Details()
        {
            TMO_CONDETAILSDTO conDto = new TMO_CONDETAILSDTO();
            conDto.N_TYPE = 8;
            //获取模型列表
            PageResult<TMO_ORDER> ef = service.GetConDetails(conDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF转换DTO实体模型
            conDto.ConDetails = MAPPING.ConvertEntityToDtoList<TMO_ORDER, TMO_CONDETAILSDTO>(ef.DataList);
            return View(conDto);
        }

        /// <summary>
        /// 合同详情列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [RenderFilter]
        public ActionResult Details(TMO_CONDETAILSDTO conDto)
        {
            //获取模型列表
            PageResult<TMO_ORDER> ef = service.GetConDetails(conDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF转换DTO实体模型
            conDto.ConDetails = MAPPING.ConvertEntityToDtoList<TMO_ORDER, TMO_CONDETAILSDTO>(ef.DataList);
            return View(conDto);
        }

        /// <summary>
        /// 获取发运单列表
        /// </summary>
        /// <returns></returns>
        [RenderFilter]
        public ActionResult Dispatch()
        {
            TMD_DISPATCHDTO dispatchDto = new TMD_DISPATCHDTO();
            dispatchDto.Start = DateTime.Now.AddDays(-5);
            dispatchDto.End = DateTime.Now.AddDays(1);
            //获取模型列表
            PageResult<TMD_DISPATCH> ef = service.GetDispatchs(dispatchDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF转换DTO实体模型
            dispatchDto.Dispatchs = MAPPING.ConvertEntityToDtoList<TMD_DISPATCH, TMD_DISPATCHDTO>(ef.DataList);
            return View(dispatchDto);
        }

        /// <summary>
        ///  获取发运单计划列表
        /// </summary>
        /// <param name="no">发运日计划单据号</param>
        /// <returns></returns>
        [RenderFilter]
        public ActionResult DispatchPlan(string no)
        {
            TMD_DISPATCHDTO dispatchDto = new TMD_DISPATCHDTO();
            dispatchDto.Dispatchs = service.GetDispatchs(no);
            ViewData["dispatch"] = dispatchDto;
            ViewData["no"] = no;
            return PartialView("~/Views/Dispatch/_Dispatch.cshtml");
        }

        /// <summary>
        /// 获取发运单列表
        /// </summary>
        /// <returns></returns>
        [RenderFilter]
        [HttpPost]
        public ActionResult Dispatch(TMD_DISPATCHDTO dispatchDto)
        {
            //获取模型列表
            PageResult<TMD_DISPATCH> ef = service.GetDispatchs(dispatchDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF转换DTO实体模型
            dispatchDto.Dispatchs = MAPPING.ConvertEntityToDtoList<TMD_DISPATCH, TMD_DISPATCHDTO>(ef.DataList);
            return View(dispatchDto);
        }

        /// <summary>
        /// 查询发运计划
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public ActionResult DispatchQuery(string no)
        {
            TMD_DISPATCHDTO dDto = new TMD_DISPATCHDTO();
            dDto = service.GetDispatch(no);
            dDto.Title = "发运单查看";
            return View(dDto);
        }

        /// <summary>
        /// 导出到条码系统
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public string Imports(string no)
        {
            int result = 0;
            Dal_Interface_FR Ifr = new Dal_Interface_FR();
            result = Ifr.SENDFYD(no);
            TMD_DISPATCHDTO dto = service.GetDispatch(no);
            dto.C_STATUS = "3";
            dto.C_EXTEND3 = "1";
            service.DispatchUpdate(dto);
            DispatchLogInsert(dto, "2", "3", "5", "导出发运单");
            return result.ToString();
        }

        /// <summary>
        /// 根据不同订单计算发运单总量
        /// </summary>
        /// <param name="dispatchDto"></param>
        public void SumWgt(TMD_DISPATCHDTO dispatchDto)
        {
            //根据不同订单计算发运总量
            if (dispatchDto.PitchConDetails != null && dispatchDto.PitchConDetails.Count > 0)
            {
                foreach (var conDetail in dispatchDto.PitchConDetails)
                {
                    decimal? wgt = 0;
                    decimal qua = 0;
                    var result = service.GetDispathWgt(conDetail.C_ORDER_NO);
                    wgt += result.Wgt;
                    qua += result.Qua;
                    var dispatchs = dispatchDto.DispatchDetails.Where(x => x.C_NO.Equals(conDetail.C_ORDER_NO));
                    if (dispatchs.Count() > 0)
                    {
                        wgt += dispatchs.Sum(x => x.N_WGT);
                        qua += dispatchs.Count();
                    }
                    conDetail.DispatchSumWgt = wgt;
                    conDetail.DispatchSumQua = qua;
                }
            }
        }

        /// <summary>
        /// 根据不同订单计算发运单总量
        /// </summary>
        /// <param name="dispatchDto"></param>
        public void SumWgtSecond(TMD_DISPATCHDTO dispatchDto)
        {
            //根据不同订单计算发运总量
            if (dispatchDto.PitchConDetails != null && dispatchDto.PitchConDetails.Count > 0)
            {
                foreach (var conDetail in dispatchDto.PitchConDetails)
                {
                    decimal? wgt = 0;
                    decimal qua = 0;
                    var result = service.GetDispathWgt(conDetail.C_ORDER_NO);
                    wgt += result.Wgt;
                    qua += result.Qua;
                    var dispatchs = dispatchDto.DispatchDetails.Where(x => x.C_NO.Equals(conDetail.C_ORDER_NO) && x.Flag == 1);
                    if (dispatchs.Count() > 0)
                    {
                        wgt += dispatchs.Sum(x => x.N_WGT);
                        qua += dispatchs.Count();
                    }
                    conDetail.DispatchSumWgt = wgt;
                    conDetail.DispatchSumQua = qua;
                }
            }
        }

        /// <summary>
        /// 导入NC
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public string TakeEffect(string no)
        {
            string result = string.Empty;
            string[] arr = no.Split(',');
            if (arr.Length > 0)
            {
                foreach (var item in arr)
                {

                    TMD_DISPATCHDTO dto = service.GetDispatch(item);
                    try
                    {
                        if (dto.C_EXTEND2 == "1")
                        {
                            return result += "测试中";
                        }
                        else
                        {
                            string oldStatus = dto.C_STATUS;
                            string flag = dto.DispatchDetails[0].C_ORDER_TYPE;
                            dto.C_STATUS = "2";
                            dto.C_EXTEND2 = "1";
                            string re = service.DispatchImportNc(dto, flag);
                            if (re == "1")
                            {
                                DispatchLogInsert(dto, "", "", "5", "导入NC成功");
                                result += item + "导入NC成功|";
                            }
                            else
                            {
                                DispatchLogInsert(dto, "", "", "5", "导入NC失败");
                                result = re;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        DispatchLogInsert(dto, dto.C_STATUS, dto.C_STATUS, "5", "导入NC失败");
                        result += item + "导入NC失败|";
                        continue;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 导入物流 
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public string ImportLg(string no)
        {
            string result = "0";
            TMD_DISPATCHDTO dto = service.GetDispatch(no);
            try
            {
                if (dto.DispatchDetails.Count > 0)
                {
                    string oldStatus = dto.C_STATUS;
                    dto.C_STATUS = "4";
                    dto.C_EXTEND4 = "1";
                    result = service.DispatchImportLg(dto);
                    DispatchLogInsert(dto, "", "", "5", "导入物流成功");
                }
            }
            catch (Exception ex)
            {
                DispatchLogInsert(dto, dto.C_STATUS, dto.C_STATUS, "5", "导入物流成功");
                result = "0";
            }

            return result;
        }

        /// <summary>
        /// 发运单删除
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public string BackOut(string no)
        {
            string result = string.Empty;
            string[] arr = no.Split(',');
            if (arr.Length > 0)
            {
                foreach (var item in arr)
                {
                    TMD_DISPATCHDTO dto = service.GetDispatch(item);

                    //string orderType = "";
                    //string re = "";
                    //if (dto.DispatchDetails.Count > 0)
                    //{
                    //    orderType = dto.DispatchDetails[0].C_ORDER_TYPE;
                    //}

                    ////8线材 6钢坯
                    //if (orderType == "8")
                    //    re = service.UpdateTRCStoveStatus(dto, 2);
                    //else
                    //    re = service.UpdateTSCStoveStatus(dto, 2);

                    try
                    {
                        if (service.NcDisExist(dto.C_GUID) == 0)
                        {
                            dto.C_STATUS = "5";
                            service.DelDispatch(dto);
                            DispatchLogInsert(dto, "", "", "4", "发运单删除");
                            result += item + "发运单删除成功|";
                        }
                        else
                            result += item + "发运单无法删除，NC已存在此发运单|";
                    }
                    catch (Exception ex)
                    {
                        DispatchLogInsert(dto, "", "", "4", "发运单删除");
                        result += item + "发运单删除失败|";
                        continue;
                    }

                }
            }
            return result;
        }

        /// <summary>
        /// 发运单失效
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public string Failure(string no)
        {
            string result = string.Empty;
            string[] arr = no.Split(',');
            if (arr.Length > 0)
            {
                foreach (var item in arr)
                {
                    TMD_DISPATCHDTO dto = service.GetDispatch(item);
                    try
                    {
                        dto.C_STATUS = "6";
                        service.DelDispatch(dto);
                        DispatchLogInsert(dto, "", "", "6", "发运单失效");
                        result += item + "发运单失效成功|";
                    }
                    catch (Exception ex)
                    {
                        DispatchLogInsert(dto, "", "", "6", "发运单失效");
                        result += item + "发运单失效失败|";
                        continue;
                    }

                }
            }
            return result;
        }

        /// <summary>
        ///审核
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Approve(string id)
        {
            TMD_DISPATCHDTO dto = service.GetDispatch(id);
            var ef = AutoMapper.Mapper.Map<TMD_DISPATCH>(dto);
            ef.C_STATUS = "10";
            ef.C_APPROVE_ID = BaseUser.Id;
            ef.D_APPROVE_DT = DateTime.Now;
            service.Update(ef);
            DispatchLogInsert(dto, "", "", "7", "审核");
            return "1";
        }

        /// <summary>
        ///弃审
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string UnApprove(string id)
        {
            string result = "0";
            TMD_DISPATCHDTO dto = service.GetDispatch(id);
            if (service.NcDisExist(dto.C_GUID) == 0)
            {
                var ef = AutoMapper.Mapper.Map<TMD_DISPATCH>(dto);
                ef.C_STATUS = "0";
                ef.C_APPROVE_ID = BaseUser.Id;
                ef.D_APPROVE_DT = DateTime.Now;
                ef.C_EXTEND2 = null;
                ef.C_EXTEND3 = null;
                ef.C_EXTEND4 = null;
                service.Update(ef);
                DispatchLogInsert(dto, "", "", "8", "弃审");
                result = "1";
            }
            return result;
        }


        /// <summary>
        /// 新增发运单日志
        /// </summary>
        /// <param name="dispatchDto">发运单id</param>
        /// <param name="beforeStatus">原状态</param>
        /// <param name="asStatus">现状态</param>
        /// <param name="type">类型 1.新增 2.修改 3.导入NC(过时) 4.导出(过时) 5.删除 6.失效 7.审核 8.弃审 9.导入nc 10.导入条码 11.导入物流 </param>
        /// <param name="explain">操作说明</param>
        private void DispatchLogInsert(TMD_DISPATCHDTO dto, string beforeStatus, string asStatus, string type, string explain)
        {
            TMD_DISPATCH_LOG log = new TMD_DISPATCH_LOG()
            {
                C_DISPATCH_ID = dto.C_ID,
                N_TYPE = type,
                C_ASTATUS = asStatus,
                C_BSTATUS = beforeStatus,
                C_EMP_ID = BaseUser.Id,
                C_EMP_NAME = BaseUser.Name,
                D_MOD_DT = DateTime.Now,
                C_EXPLAIN = explain
            };
            service.DispatchLogInsert(log, dto);

        }

        /// <summary>
        /// 查群发运单操作记录
        /// </summary>
        /// <param name="no">发运单ID</param>
        /// <returns></returns>
        public ActionResult DispatchLogQuery(string no)
        {
            TMD_DISPATCH_LOGDTO log = new TMD_DISPATCH_LOGDTO();
            log.Logs = MAPPING.ConvertEntityToDtoList<TMD_DISPATCH_LOG, TMD_DISPATCH_LOGDTO>(service.GetDispatchLog(no).OrderBy(x => x.D_MOD_DT).ToList());
            return View(log);
        }

        #region No.2
        /// <summary>
        /// 发运单制作
        /// </summary>
        /// <returns></returns>
        [RenderFilter]
        public ActionResult DispatchManage()
        {
            TMO_CONDETAILSDTO conDto = new TMO_CONDETAILSDTO();
            conDto.TabIndex1 = 0;
            conDto.Dispatch = new TMD_DISPATCHDTO();
            //获取地区信息
            conDto.AreaMaxs = basicsService.GetAreaMax();
            //8线材 6钢坯 831废乱材  841焦化产品 851渣
            conDto.N_TYPE = 8;
            //默认发运日期
            conDto.Dispatch.D_DISP_DT = DateTime.Now;
            //计划交货日期
            conDto.Start = DateTime.Now;
            conDto.End = DateTime.Now.AddMonths(2);
            //发运失效日期
            conDto.Dispatch.D_FAILURE = DateTime.Now.AddDays(1);
            //取属性型验证
            if (conDto.Dispatch.C_SHIPVIA == "0001NC10000000003ILQ")
            {
                ModelState.Remove("Dispatch.C_LIC_PLA_NO");
            }
            else
            {
                ModelState.Remove("Dispatch.C_ATSTATION");
                ModelState.Remove("Dispatch.C_COMCAR");
            }

            //获取订单列表
            PageResult<TMO_ORDER> ef = new PageResult<TMO_ORDER>();
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF转换DTO实体模型
            //conDto.ConDetails = MAPPING.ConvertEntityToDtoList<TMO_CONDETAILS, TMO_CONDETAILSDTO>(ef.DataList);
            return View(conDto);
        }

        /// <summary>
        /// 发运单制作
        /// </summary>
        /// <param name="conDto"></param>
        /// <returns></returns>
        [HttpPost]
        [RenderFilter]
        public ActionResult DispatchManage(TMO_CONDETAILSDTO conDto)
        {
            //获取地区信息
            conDto.AreaMaxs = basicsService.GetAreaMax();

            //验证GPS
            IsGps(conDto);

            //取消属性验证
            if (conDto.Dispatch.C_SHIPVIA == "0001NC10000000003ILQ")
            {
                ModelState.Remove("Dispatch.C_LIC_PLA_NO");
            }
            else
            {
                ModelState.Remove("Dispatch.C_ATSTATION");
                ModelState.Remove("Dispatch.C_COMCAR");
            }

            #region 操作
            if (conDto.OperationType == 1)//查询
            {
                //获取模型列表
                PageResult<TMO_ORDER> ef = service.GetConDetails(conDto);
                //获取分页数据
                BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
                this.HttpContext.Session["Page"] = page;
                //EF转换DTO实体模型
                conDto.ConDetails = MAPPING.ConvertEntityToDtoList<TMO_ORDER, TMO_CONDETAILSDTO>(ef.DataList);
            }
            else if (conDto.OperationType == 2)//选中订单
            {
                if (conDto.Dispatch == null)
                {
                    conDto.Dispatch = new TMD_DISPATCHDTO();
                }
                //选中订单号
                if (!string.IsNullOrWhiteSpace(conDto.PitchConDeitailNo))
                {
                    //如果选中订单集合为空 生成实例
                    if (conDto.Dispatch.PitchConDetails == null)
                        conDto.Dispatch.PitchConDetails = new List<TMO_CONDETAILSDTO>();

                    //新增选中订单 生成发运单
                    PitchConDetailsInsert(conDto);

                    //清空选中单号
                    conDto.PitchConDeitailNo = "";
                }

            }
            else if (conDto.OperationType == 3)//补单
            {
                //如果补单订单号不为空
                if (!string.IsNullOrWhiteSpace(conDto.SupplementNo))
                {
                    var supplements = conDto.Dispatch.SupplementDispatchDetails
                        .Where(x => x.C_NO == conDto.SupplementNo
                                    && x.C_STOVE == conDto.SupplementStove
                                    && x.C_BATCH_NO == conDto.SupplementBatchNo)
                        .Take(conDto.SupplementQua)
                        .ToList();
                    foreach (var item in supplements)
                    {
                        var re = "0";
                        if (conDto.ConfirmOrderType == 8)
                            re = comService.TrcPlace(item.C_PRODUCT_ID);
                        else if (conDto.ConfirmOrderType == 6)
                            re = comService.TscPlace(item.C_PRODUCT_ID);
                        if (re == "1")
                            conDto.Dispatch.DispatchDetails.Add(item);
                    }
                }
            }
            else if (conDto.OperationType == 4)//提交发运单
            {
                ModelState.Remove("Start");
                ModelState.Remove("End");
                ModelState.Remove("BasePage.PageIndex");
                //分组发运单明细
                GourpDispatchDetails(conDto);

                if (!ModelState.IsValid)
                {
                    //确认订单类型
                    if (conDto.Dispatch.PitchConDetails != null && conDto.Dispatch.PitchConDetails.Count > 0)
                        conDto.ConfirmOrderType = conDto.ConDetails[0].N_TYPE;
                    conDto.IsRefresh = "";
                    //计算总件数和数量
                    SumWgt(conDto.Dispatch);
                    conDto.Dispatch.Wgt = conDto.Dispatch.DispatchDetails.Sum(x => x.N_WGT);
                    conDto.Dispatch.Number = conDto.Dispatch.DispatchDetails.Count;
                    return View(conDto);
                }
                conDto.Dispatch.C_ID = service.CreateDispID();
                conDto.Dispatch.D_CREATE_DT = DateTime.Now;
                conDto.Dispatch.C_CREATE_ID = BaseUser.Id;
                conDto.Dispatch.C_CREATE_NAME = BaseUser.Name;
                conDto.Dispatch.C_EMP_ID = BaseUser.Id;
                conDto.Dispatch.C_EMP_NAME = BaseUser.Name;
                conDto.Dispatch.D_MOD_DT = DateTime.Now;
                conDto.Dispatch.OperationType = conDto.OperationType;
                conDto.Dispatch.C_GUID = Guid.NewGuid().ToString("N");
                //conDto.Dispatch.C_STATUS = "1";
                if (conDto.ConfirmOrderType == 8)
                {
                    conDto.Dispatch.C_IS_WIRESALE = "是";
                    conDto.Dispatch.C_IS_WIRESALE_ID = Constant.WireSale[conDto.Dispatch.C_IS_WIRESALE];
                }
                else
                {
                    conDto.Dispatch.C_IS_WIRESALE = "否";
                    conDto.Dispatch.C_IS_WIRESALE_ID = Constant.WireSale[conDto.Dispatch.C_IS_WIRESALE];
                }
                service.DispatchInsert(conDto.Dispatch);
                DispatchLogInsert(conDto.Dispatch, "", conDto.Dispatch.C_STATUS, "1", "新增发运单");
                //修改订单钢坯线材匹配量
                conDto.ResultType = 1;
                //计算总件数和数量
                SumWgt(conDto.Dispatch);
                conDto.Dispatch.Wgt = conDto.Dispatch.DispatchDetails.Sum(x => x.N_WGT);
                conDto.Dispatch.Number = conDto.Dispatch.DispatchDetails.Count;

                return View(conDto);
            }
            else if (conDto.OperationType == 5)//剔除发运单
            {
                if (!string.IsNullOrWhiteSpace(conDto.CancelDispatchOrderID))
                {
                    var dispatchs = conDto.Dispatch.DispatchDetails.Where(x => x.C_NO == conDto.CancelDispatchOrderID && x.C_STOVE == conDto.CancelDispatchStove && x.C_BATCH_NO == conDto.CancelDispatchBatchNo);
                    if (dispatchs != null && dispatchs.Count() > 0)
                    {
                        var items = dispatchs.ToList();
                        for (int i = 0; i < conDto.CancelDispatchQua; i++)
                        {
                            if (conDto.ConfirmOrderType == 8)
                                comService.CancelPlace(items[i].C_PRODUCT_ID);
                            else
                                comService.CancelPlaceSecond(items[i].C_PRODUCT_ID);
                            conDto.Dispatch.DispatchDetails.Remove(items[i]);
                        }
                    }
                }
            }

            #endregion

            //确认订单类型
            if (conDto.Dispatch.PitchConDetails != null && conDto.Dispatch.PitchConDetails.Count > 0)
                conDto.ConfirmOrderType = conDto.Dispatch.PitchConDetails[0].N_TYPE;

            //验证GPS
            IsGps(conDto);

            //分组发运单明细
            GourpDispatchDetails(conDto);

            //计算总件数和数量
            SumWgt(conDto.Dispatch);
            conDto.Dispatch.Wgt = conDto.Dispatch.DispatchDetails.Sum(x => x.N_WGT);
            conDto.Dispatch.Number = conDto.Dispatch.DispatchDetails.Count;
            conDto.IsRefresh = "";

            return View(conDto);
        }

        private static void GourpDispatchDetails(TMO_CONDETAILSDTO conDto)
        {
            conDto.Dispatch.Details.Clear();
            var shows = conDto.Dispatch.DispatchDetails.GroupBy(x => new { x.C_STL_GRD, x.C_SPEC, x.C_MAT_CODE, x.C_NO, x.C_BATCH_NO, x.C_STOVE, x.C_AREA })
                      .Select(y => (new
                      {
                          No = y.Max(item => item.C_CON_NO),
                          OrderNo = y.Key.C_NO,
                          Grd = y.Max(item => item.C_STL_GRD),
                          Spec = y.Max(item => item.C_SPEC),
                          Free = y.Max(item => item.C_FREE_TERM),
                          Free2 = y.Max(item => item.C_FREE_TERM2),
                          Pack = y.Max(item => item.C_PACK),
                          QUALIRY_LEV = y.Max(item => item.C_JUDGE_LEV_ZH),
                          MatCode = y.Key.C_MAT_CODE,
                          BatchNo = y.Key.C_BATCH_NO,
                          Stove = y.Key.C_STOVE,
                          MatName = y.Max(item => item.C_MAT_NAME),
                          Qua = y.Count(),
                          Wgt = y.Sum(item => item.N_WGT),
                          Area = y.Key.C_AREA
                      }));

            foreach (var item in shows)
            {
                DispatchDetailsDisplayDto show = new DispatchDetailsDisplayDto();
                show.No = item.No;
                show.OrderNo = item.OrderNo;
                show.Grd = item.Grd;
                show.Spec = item.Spec;
                show.Free = item.Free;
                show.Free2 = item.Free2;
                show.Pack = item.Pack;
                show.QUALIRY_LEV = item.QUALIRY_LEV;
                show.MatCode = item.MatCode;
                show.MatName = item.MatName;
                show.Qua = item.Qua;
                show.Wgt = item.Wgt;
                show.BatchNo = item.BatchNo;
                show.Stove = item.Stove;
                show.Area = item.Area;
                conDto.Dispatch.Details.Add(show);
            }
        }

        private void IsGps(TMO_CONDETAILSDTO conDto)
        {
            //验证GPS
            if (conDto.Dispatch.PitchConDetails != null && conDto.Dispatch.PitchConDetails.Count > 0)
            {
                foreach (var item in conDto.Dispatch.PitchConDetails)
                {
                    int areaGps = service.GetAreaGps(item.C_AREA);
                    int custNoGps = service.GetCustFileGps(item.C_CUST_NO);
                    int matCodeGps = service.GetMatrlMainGps(item.C_MAT_CODE);
                    if (areaGps == 0 || custNoGps == 0 || matCodeGps == 0)
                    {
                        conDto.IsGps = 0;
                        break;
                    }
                    else
                    {
                        conDto.IsGps = 1;
                    }
                }
            }
        }

        /// <summary>
        /// 发运单修改
        /// </summary>
        /// <param name="id">发运单号</param>
        /// <returns></returns>
        [RenderFilter]
        public ActionResult DispatchUpdate(string id)
        {
            TMO_CONDETAILSDTO conDto = new TMO_CONDETAILSDTO();
            conDto.TabIndex1 = 0;
            conDto.Dispatch = new TMD_DISPATCHDTO();
            //获取地区信息
            conDto.AreaMaxs = basicsService.GetAreaMax();
            //8线材 6钢坯 831废乱材  841焦化产品 851渣
            conDto.N_TYPE = 8;
            //获取发运单信息(主体 明细 订单)
            conDto.Dispatch = service.GetDispatch(id);
            //确认订单类型
            if (conDto.Dispatch.PitchConDetails != null && conDto.Dispatch.PitchConDetails.Count > 0)
                conDto.ConfirmOrderType = conDto.Dispatch.PitchConDetails[0].N_TYPE;
            //计算总件数和数量
            SumWgtSecond(conDto.Dispatch);
            //验证GPS
            IsGps(conDto);
            conDto.Dispatch.Wgt = conDto.Dispatch.DispatchDetails.Sum(x => x.N_WGT);
            conDto.Dispatch.Number = conDto.Dispatch.DispatchDetails.Count;
            //默认发运日期
            conDto.Dispatch.D_DISP_DT = DateTime.Now;
            //计划交货日期
            conDto.Start = DateTime.Now;
            conDto.End = DateTime.Now.AddMonths(2);
            //取属性型验证
            if (conDto.Dispatch.C_SHIPVIA == "0001NC10000000003ILQ")
            {
                ModelState.Remove("Dispatch.C_LIC_PLA_NO");
            }
            else
            {
                ModelState.Remove("Dispatch.C_ATSTATION");
                ModelState.Remove("Dispatch.C_COMCAR");
            }
            //分组发运单明细
            GourpDispatchDetails(conDto);
            return View(conDto);
        }

        /// <summary>
        /// 发运单修改
        /// </summary>
        /// <param name="no">发运日计划单据号</param>
        /// <returns></returns>
        [HttpPost]
        [RenderFilter]
        public ActionResult DispatchUpdate(TMO_CONDETAILSDTO conDto)
        {
            //获取地区信息
            conDto.AreaMaxs = basicsService.GetAreaMax();
            //验证GPS
            IsGps(conDto);

            //取属性型验证
            if (conDto.Dispatch.C_SHIPVIA == "0001NC10000000003ILQ")
            {
                ModelState.Remove("Dispatch.C_LIC_PLA_NO");
            }
            else
            {
                ModelState.Remove("Dispatch.C_ATSTATION");
                ModelState.Remove("Dispatch.C_COMCAR");
            }

            #region 操作
            if (conDto.OperationType == 1)//查询
            {
                //获取模型列表
                PageResult<TMO_ORDER> ef = service.GetConDetails(conDto);
                //获取分页数据
                BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
                this.HttpContext.Session["Page"] = page;
                //EF转换DTO实体模型
                conDto.ConDetails = MAPPING.ConvertEntityToDtoList<TMO_ORDER, TMO_CONDETAILSDTO>(ef.DataList);

            }
            else if (conDto.OperationType == 2)//选中订单
            {
                if (conDto.Dispatch == null)
                {
                    conDto.Dispatch = new TMD_DISPATCHDTO();
                }
                //选中订单号
                if (!string.IsNullOrWhiteSpace(conDto.PitchConDeitailNo))
                {
                    //如果选中订单集合为空 生成实例
                    if (conDto.Dispatch.PitchConDetails == null)
                        conDto.Dispatch.PitchConDetails = new List<TMO_CONDETAILSDTO>();

                    //新增选中订单 生成发运单
                    PitchConDetailsUpdate(conDto);

                    //计算总件数和数量
                    SumWgtSecond(conDto.Dispatch);
                    conDto.Dispatch.Wgt = conDto.Dispatch.DispatchDetails.Sum(x => x.N_WGT);
                    conDto.Dispatch.Number = conDto.Dispatch.DispatchDetails.Count;
                    //清空选中单号
                    conDto.PitchConDeitailNo = "";
                }
            }
            else if (conDto.OperationType == 3)//补单
            {
                //如果补单订单号不为空
                if (!string.IsNullOrWhiteSpace(conDto.SupplementNo))
                {
                    //如果补单订单号不为空
                    if (!string.IsNullOrWhiteSpace(conDto.SupplementNo))
                    {
                        var supplements = conDto.Dispatch.SupplementDispatchDetails
                            .Where(x => x.C_NO == conDto.SupplementNo
                                        && x.C_STOVE == conDto.SupplementStove
                                        && x.C_BATCH_NO == conDto.SupplementBatchNo)
                            .Take(conDto.SupplementQua)
                            .ToList();
                        foreach (var item in supplements)
                        {
                            var re = "0";
                            if (conDto.ConfirmOrderType == 8)
                                re = comService.TrcPlace(item.C_PRODUCT_ID);
                            else if (conDto.ConfirmOrderType == 6)
                                re = comService.TscPlace(item.C_PRODUCT_ID);
                            if (re == "1")
                            {
                                item.Flag = 1;
                                conDto.Dispatch.DispatchDetails.Add(item);
                            }
                        }
                    }
                }
            }
            else if (conDto.OperationType == 4)//提交发运单
            {
                //修改发运单明细地区
                if (conDto.Dispatch.Details.Count > 0)
                {
                    foreach (var item in conDto.Dispatch.Details)
                    {
                        var dispatchs = conDto.Dispatch.DispatchDetails.Where(x => x.C_NO == item.OrderNo
                        && x.C_STOVE == item.Stove
                        && x.C_BATCH_NO == item.BatchNo
                        && x.C_AREA == item.OldArea);
                        foreach (var disItem in dispatchs)
                        {
                            disItem.C_AREA = item.Area;
                        }
                    }
                }

                ModelState.Remove("Start");
                ModelState.Remove("End");
                ModelState.Remove("BasePage.PageIndex");
                //分组发运单明细
                GourpDispatchDetails(conDto);

                if (!ModelState.IsValid)
                {
                    //确认订单类型
                    if (conDto.Dispatch.PitchConDetails != null && conDto.Dispatch.PitchConDetails.Count > 0)
                        conDto.ConfirmOrderType = conDto.Dispatch.PitchConDetails[0].N_TYPE;
                    conDto.IsRefresh = "";
                    //计算总件数和数量
                    conDto.Dispatch.Wgt = conDto.Dispatch.DispatchDetails.Sum(x => x.N_WGT);
                    conDto.Dispatch.Number = conDto.Dispatch.DispatchDetails.Count;
                    return View(conDto);
                }
                conDto.Dispatch.D_CREATE_DT = DateTime.Now;
                conDto.Dispatch.C_EMP_ID = BaseUser.Id;
                conDto.Dispatch.C_EMP_NAME = BaseUser.Name;
                conDto.Dispatch.D_MOD_DT = DateTime.Now;
                conDto.Dispatch.OperationType = conDto.OperationType;
                //conDto.Dispatch.C_STATUS = "1";
                if (conDto.ConfirmOrderType == 8)
                {
                    conDto.Dispatch.C_IS_WIRESALE = "是";
                    conDto.Dispatch.C_IS_WIRESALE_ID = Constant.WireSale[conDto.Dispatch.C_IS_WIRESALE];
                }
                else
                {
                    conDto.Dispatch.C_IS_WIRESALE = "否";
                    conDto.Dispatch.C_IS_WIRESALE_ID = Constant.WireSale[conDto.Dispatch.C_IS_WIRESALE];
                }
                conDto.Dispatch.ConDetType = conDto.ConfirmOrderType.ToString();
                conDto.Dispatch.C_EXTEND5 = conDto.ConfirmOrderType.ToString();
                service.DispatchUpdate(conDto.Dispatch);
                DispatchLogInsert(conDto.Dispatch, "", "", "2", "修改发运单");
                conDto.ResultType = 1;
                //计算总件数和数量
                SumWgtSecond(conDto.Dispatch);
                //验证GPS
                IsGps(conDto);
                conDto.Dispatch.Wgt = conDto.Dispatch.DispatchDetails.Sum(x => x.N_WGT);
                conDto.Dispatch.Number = conDto.Dispatch.DispatchDetails.Count;
                return View(conDto);
            }
            else if (conDto.OperationType == 5)//剔除发运单
            {
                if (!string.IsNullOrWhiteSpace(conDto.CancelDispatchOrderID))
                {
                    var dispatchs = conDto.Dispatch.DispatchDetails.Where(x => x.C_NO == conDto.CancelDispatchOrderID && x.C_STOVE == conDto.CancelDispatchStove && x.C_BATCH_NO == conDto.CancelDispatchBatchNo);
                    if (dispatchs != null && dispatchs.Count() > 0)
                    {
                        var items = dispatchs.ToList();
                        for (int i = 0; i < conDto.CancelDispatchQua; i++)
                        {
                            if (conDto.ConfirmOrderType == 8)
                                comService.CancelPlace(items[i].C_PRODUCT_ID);
                            else
                                comService.CancelPlaceSecond(items[i].C_PRODUCT_ID);
                            conDto.Dispatch.DispatchDetails.Remove(items[i]);
                        }
                    }
                    conDto.CancelDispatchOrderID = "";
                }
            }
            else if (conDto.OperationType == 6)//失效
            { }
            else if (conDto.OperationType == 7)//审核
            {
                Approve(conDto.Dispatch.C_ID);
                conDto.Dispatch = service.GetDispatch(conDto.Dispatch.C_ID);
            }
            else if (conDto.OperationType == 8)//弃审
            {
                if (UnApprove(conDto.Dispatch.C_ID) == "0")
                {
                    conDto.Dispatch = service.GetDispatch(conDto.Dispatch.C_ID);
                    conDto.ErrorMessage = "请检查NC是否已存在发运单";
                    conDto.ResultType = 2;
                }
                else conDto.Dispatch = service.GetDispatch(conDto.Dispatch.C_ID);
            }
            else if (conDto.OperationType == 9)//导入nc
            {
                string ncRe = TakeEffect(conDto.Dispatch.C_ID);
                if (ncRe == "1")
                {
                    conDto.ResultType = 1;
                    conDto.Dispatch = service.GetDispatch(conDto.Dispatch.C_ID);
                }
                else
                {
                    conDto.ResultType = 2;
                    conDto.ErrorMessage = ncRe;
                }
            }
            else if (conDto.OperationType == 10)//导入条码
            {
                string rfRe = Imports(conDto.Dispatch.C_ID);
                if (rfRe == "1")
                {
                    conDto.ResultType = 1;
                    conDto.Dispatch = service.GetDispatch(conDto.Dispatch.C_ID);
                }
                else
                {
                    conDto.ResultType = 2;
                    conDto.ErrorMessage = rfRe;
                }
            }
            else if (conDto.OperationType == 11)//导入物流
            {
                string lgRe = ImportLg(conDto.Dispatch.C_ID);
                if (lgRe == "1")
                {
                    conDto.ResultType = 1;
                    conDto.Dispatch = service.GetDispatch(conDto.Dispatch.C_ID);
                }
                else
                {
                    conDto.ResultType = 2;
                    conDto.ErrorMessage = "导入物流失败";
                }
            }

            #endregion

            //确认订单类型
            if (conDto.Dispatch.PitchConDetails != null && conDto.Dispatch.PitchConDetails.Count > 0)
                conDto.ConfirmOrderType = conDto.Dispatch.PitchConDetails[0].N_TYPE;

            //分组发运单明细
            GourpDispatchDetails(conDto);

            //计算总件数和数量
            SumWgtSecond(conDto.Dispatch);
            conDto.Dispatch.Wgt = conDto.Dispatch.DispatchDetails.Sum(x => x.N_WGT);
            conDto.Dispatch.Number = conDto.Dispatch.DispatchDetails.Count;
            conDto.IsRefresh = "";
            return View(conDto);
        }

        /// <summary>
        /// 选中订单时 创建发运单明细（新增发运单）
        /// </summary>
        /// <param name="conDto"></param>
        private void PitchConDetailsInsert(TMO_CONDETAILSDTO conDto)
        {
            var arrs = conDto.PitchConDeitailNo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var str in arrs)
            {
                TMO_CONDETAILSDTO example = service.GetOrderDetails(str);
                decimal? type = 0m;
                //新增选中订单 只添加不重复数据
                if (!conDto.Dispatch.PitchConDetails.Any(x => x.C_ORDER_NO.Equals(conDto.PitchConDeitailNo)))
                {
                    conDto.Dispatch.PitchConDetails.Add(example);
                }

                if (example != null)
                    type = example.N_TYPE;

                //8线材 6钢坯 831废乱材  841焦化产品 851渣
                if (type == 8)
                {
                    //获取订单已生产商品
                    conDto.Dispatch.Rolls = comService.GetRollProducts(conDto.PitchConDeitailNo);
                    //生成发运单明细
                    conDto.Dispatch = service.CreateDispatchDetailsProduct(conDto.Dispatch, conDto.PitchConDeitailNo);
                }
                else if (type == 6)
                {
                    int fNum = (int)Math.Round((double)example.N_FNUM);
                    //获取订单已生产商品
                    conDto.Dispatch.Slabs = comService.GetSlabMain(example.C_STL_GRD, example.C_SLAB_SIZE, example.N_SLAB_LENGTH, "", example.C_STD_CODE, fNum);
                    //生成发运单明细
                    conDto.Dispatch = service.CreateDispatchDetailsSlab(conDto.Dispatch, conDto.PitchConDeitailNo);
                }
                else if (type == 831)
                {

                }
                else if (type == 841 || type == 851)
                {
                    //生成发运单明细
                    conDto.Dispatch = service.CreateDispatchDetailsOther(conDto.Dispatch, conDto.PitchConDeitailNo);
                }

            }
        }

        /// <summary>
        /// 选中订单时 创建发运单明细（修改发运单）
        /// </summary>
        /// <param name="conDto"></param>
        private void PitchConDetailsUpdate(TMO_CONDETAILSDTO conDto)
        {
            var arrs = conDto.PitchConDeitailNo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var str in arrs)
            {
                TMO_CONDETAILSDTO example = service.GetOrderDetails(str);
                decimal? type = 0m;
                //新增选中订单 只添加不重复数据
                if (!conDto.Dispatch.PitchConDetails.Any(x => x.C_ORDER_NO.Equals(conDto.PitchConDeitailNo)))
                {
                    conDto.Dispatch.PitchConDetails.Add(example);
                }

                if (example != null)
                    type = example.N_TYPE;

                //8线材 6钢坯 831废乱材  841焦化产品 851渣
                if (type == 8)
                {
                    //获取订单已生产商品
                    conDto.Dispatch.Rolls = comService.GetRollProducts(conDto.PitchConDeitailNo);
                    //生成发运单明细
                    conDto.Dispatch = service.CreateDispatchDetailsProduct(conDto.Dispatch, conDto.PitchConDeitailNo, 1);
                }
                else if (type == 6)
                {
                    int fNum = (int)Math.Round((double)example.N_FNUM);
                    //获取订单已生产商品
                    conDto.Dispatch.Slabs = comService.GetSlabMain(example.C_STL_GRD, example.C_SLAB_SIZE, example.N_SLAB_LENGTH, "", example.C_STD_CODE, fNum);
                    //生成发运单明细
                    conDto.Dispatch = service.CreateDispatchDetailsSlab(conDto.Dispatch, conDto.PitchConDeitailNo, 1);
                }
                else if (type == 831)
                {
                }
                else if (type == 841 || type == 851)
                {
                    //生成发运单明细
                    conDto.Dispatch = service.CreateDispatchDetailsOther(conDto.Dispatch, conDto.PitchConDeitailNo);
                }
            }
        }

        /// <summary>
        /// 获取补单数据线材
        /// </summary>
        /// <param name="area">地区</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="stdCode">执行标准</param>
        /// <param name="no">订单号</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult _Supplement(string area, string stlGrd, string spec, string stdCode, string no)
        {
            var areas = area.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var stlGrds = stlGrd.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var specs = spec.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var stdCodes = stdCode.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var nos = no.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            TMO_CONDETAILSDTO conDto = new TMO_CONDETAILSDTO();

            //创建发运单对象
            if (conDto.Dispatch == null)
            {
                conDto.Dispatch = new TMD_DISPATCHDTO();
            }

            //创建补单集合
            if (conDto.Dispatch.SupplementDispatchDetails == null)
                conDto.Dispatch.SupplementDispatchDetails = new List<TMD_DISPATCHDETAILSDTO>();

            if (areas != null && areas.Count() > 0)
            {
                for (int i = 0; i < areas.Count(); i++)
                {
                    //根据钢种 规格 地区 执行标准获取线材
                    conDto.Dispatch.Rolls = comService.GetRollProducts(stlGrds[i]
                        , specs[i]
                        , areas[i]
                        , stdCodes[i]);
                    conDto.Dispatch = service.CreateSupplementProduct(conDto.Dispatch, nos[i]);
                }
            }
            //补单 明细分组
            SupDetailsGroup(conDto);
            Request.RequestContext.HttpContext.Session["Supplement"] = conDto;
            return PartialView();
        }

        private static void SupDetailsGroup(TMO_CONDETAILSDTO conDto)
        {
            conDto.Dispatch.SupplementDetails.Clear();
            var shows = conDto.Dispatch.SupplementDispatchDetails.GroupBy(x => new { x.C_STL_GRD, x.C_SPEC, x.C_MAT_CODE, x.C_NO, x.C_BATCH_NO, x.C_STOVE })
                  .Select(y => (new
                  {
                      No = y.Max(item => item.C_CON_NO),
                      OrderNo = y.Key.C_NO,
                      Grd = y.Max(item => item.C_STL_GRD),
                      Spec = y.Max(item => item.C_SPEC),
                      Free = y.Max(item => item.C_FREE_TERM),
                      Free2 = y.Max(item => item.C_FREE_TERM2),
                      Pack = y.Max(item => item.C_PACK),
                      QUALIRY_LEV = y.Max(item => item.C_JUDGE_LEV_ZH),
                      MatCode = y.Key.C_MAT_CODE,
                      BatchNo = y.Key.C_BATCH_NO,
                      Stove = y.Key.C_STOVE,
                      MatName = y.Max(item => item.C_MAT_NAME),
                      Qua = y.Count(),
                      Wgt = y.Sum(item => item.N_WGT)
                  }));

            foreach (var item in shows)
            {
                DispatchDetailsDisplayDto show = new DispatchDetailsDisplayDto();
                show.No = item.No;
                show.OrderNo = item.OrderNo;
                show.Grd = item.Grd;
                show.Spec = item.Spec;
                show.Free = item.Free;
                show.Free2 = item.Free2;
                show.Pack = item.Pack;
                show.QUALIRY_LEV = item.QUALIRY_LEV;
                show.MatCode = item.MatCode;
                show.MatName = item.MatName;
                show.Qua = item.Qua;
                show.Wgt = item.Wgt;
                show.BatchNo = item.BatchNo;
                show.Stove = item.Stove;
                conDto.Dispatch.SupplementDetails.Add(show);
            }
        }

        /// <summary>
        /// 获取补单数据钢坯
        /// </summary>
        /// <param name="area">地区</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="stdCode">执行标准</param>
        /// <param name="no">订单号</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult _SupplementSecond(string area, string stlGrd, string spec, string len, string stdCode, string no)
        {
            var areas = area.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var stlGrds = stlGrd.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var specs = spec.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var lens = len.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var stdCodes = stdCode.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var nos = no.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            TMO_CONDETAILSDTO conDto = new TMO_CONDETAILSDTO();

            //创建发运单对象
            if (conDto.Dispatch == null)
            {
                conDto.Dispatch = new TMD_DISPATCHDTO();
            }

            //创建补单集合
            if (conDto.Dispatch.SupplementDispatchDetails == null)
                conDto.Dispatch.SupplementDispatchDetails = new List<TMD_DISPATCHDETAILSDTO>();

            if (areas != null && areas.Count() > 0)
            {
                for (int i = 0; i < areas.Count(); i++)
                {
                    //根据钢种 规格 地区 执行标准获取线材
                    conDto.Dispatch.Slabs = comService.GetSlabMain(stlGrds[i]
                        , specs[i]
                        , lens[i]
                        , areas[i]
                        , stdCodes[i]);
                    conDto.Dispatch = service.CreateSupplementSlab(conDto.Dispatch, nos[i]);
                }
            }
            //补单 明细分组
            SupDetailsGroup(conDto);
            Request.RequestContext.HttpContext.Session["SupplementSecond"] = conDto;
            return PartialView();
        }

        /// <summary>
        /// 关闭窗口时刷新操作
        /// </summary>
        /// <param name="isRefresh">判断用户是否操作</param>
        [HttpPost]
        public string ClosePage(string id, string isRefresh, string type)
        {
            if (isRefresh == "")
            {
                var arr = id.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (arr != null && arr.Count() > 0)
                {
                    foreach (var item in arr)
                    {
                        if (type == "6")
                            comService.CancelPlaceSecond(item);
                        else
                            comService.CancelPlace(item);
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// 获取发运方式GPS
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int GetShipviaGps(string shipvia)
        {
            return service.GetShipviaGps(shipvia);
        }
        #endregion

    }

    public class ModelLog
    {

    }

}