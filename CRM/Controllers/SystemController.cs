using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NF.Bussiness.Interface;
using Microsoft.Practices.Unity;
using NF.Framework;
using NF.Framework.DTO;
using NF.Web.Core;
using System.Linq.Expressions;
using NF.EF.Model;
using System.Xml.Linq;

namespace CRM.Controllers
{
    public partial class SystemController : BaseController
    {

        IBasicsDataService service = DIFactory.GetContainer().Resolve<IBasicsDataService>();
        IQualityService qualityService = DIFactory.GetContainer().Resolve<IQualityService>();

        /// <summary>
        /// 完成公差
        /// </summary>
        /// <returns></returns>
        [RenderFilter]
        public ActionResult ComDiff()
        {
            TMB_COMDIFFDTO cdDto = new TMB_COMDIFFDTO();
            //获取完成工差列表
            PageResult<TMB_COMDIFF> ef = service.GetComDiffs(cdDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            cdDto.ComDiffs = MAPPING.ConvertEntityToDtoList<TMB_COMDIFF, TMB_COMDIFFDTO>(ef.DataList);
            return View(cdDto);
        }

        /// <summary>
        ///  完成公差
        /// </summary>
        /// <param name="cdDto">完成公差实体DTO</param>
        /// <returns></returns>
        [RenderFilter]
        [HttpPost]
        public ActionResult ComDiff(TMB_COMDIFFDTO cdDto)
        {
            //获取完成工差列表
            PageResult<TMB_COMDIFF> ef = service.GetComDiffs(cdDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            cdDto.ComDiffs = MAPPING.ConvertEntityToDtoList<TMB_COMDIFF, TMB_COMDIFFDTO>(ef.DataList);
            return View(cdDto);
        }

        /// <summary>
        ///  完成公差新增
        /// </summary>
        /// <returns></returns>
        public ActionResult ComDiffInsert()
        {
            TMB_COMDIFFDTO cdDto = new TMB_COMDIFFDTO();
            cdDto.Title = " 完成公差新增";
            return View(cdDto);
        }

        /// <summary>
        ///  完成公差新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ComDiffInsert(TMB_COMDIFFDTO cdDto)
        {
            //验证实体字段
            if (!ModelState.IsValid)
                return View(cdDto);
            //验证是否重复
            else if (!service.ValidateIsRepeat(cdDto, 0))
            {
                ModelState.AddModelError("error", "最大值与最小值重复");
                return View(cdDto);
            }
            //新增
            else
            {
                cdDto.C_EMP_ID = BaseUser.Id;
                cdDto.C_EMP_NAME = BaseUser.Name;
                cdDto.D_MOD_DT = DateTime.Now;
                cdDto.N_STATUS = 1;
                service.ComDiffInsert(cdDto);
                cdDto.ResultType = 1;
                return View(cdDto);
            }
        }

        /// <summary>
        /// 完成公差修改
        /// </summary>
        /// <param name="id">完成公差id</param>
        /// <returns></returns>
        public ActionResult ComDiffUpdate(string id)
        {
            TMB_COMDIFFDTO cdDto = new TMB_COMDIFFDTO();
            cdDto = AutoMapper.Mapper.Map<TMB_COMDIFFDTO>(service.Find<TMB_COMDIFF>(id));
            cdDto.Title = " 完成公差";
            return View("ComDiffInsert", cdDto);
        }

        /// <summary>
        /// 完成公差修改
        /// </summary>
        /// <param name="cdDto">完成公差实体DTO</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ComDiffUpdate(TMB_COMDIFFDTO cdDto)
        {
            //验证实体字段
            if (!ModelState.IsValid)
                return View("ComDiffInsert", cdDto);
            //验证是否重复
            else if (!service.ValidateIsRepeat(cdDto, 1))
            {
                ModelState.AddModelError("error", "最大值与最小值重复");
                return View("ComDiffInsert", cdDto);
            }
            //修改
            else
            {
                cdDto.C_EMP_ID = BaseUser.Id;
                cdDto.C_EMP_NAME = BaseUser.Name;
                cdDto.D_MOD_DT = DateTime.Now;
                service.ComDiffUpdate(cdDto);
                cdDto.ResultType = 2;
                return View("ComDiffInsert", cdDto);
            }
        }

        /// <summary>
        /// 完成公差删除
        /// </summary>
        /// <param name="ids">id串以逗号连接</param>
        /// <returns></returns>
        public int ComDiffDel(string ids)
        {
            service.ComDiffDel(ids, BaseUser);
            return 1;
        }

        /// <summary>
        /// 数据字典
        /// </summary>
        /// <returns></returns>
        [RenderFilter]
        public ActionResult Dic()
        {
            TS_DICDTO dicDto = new TS_DICDTO();
            //获取数据字典列表
            PageResult<TS_DIC> ef = service.GetDics(dicDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            dicDto.Dics = MAPPING.ConvertEntityToDtoList<TS_DIC, TS_DICDTO>(ef.DataList.OrderBy(x => x.C_TYPECODE).ThenBy(x => x.C_DETAILCODE).ToList());
            return View(dicDto);
        }

        /// <summary>
        ///  数据字典
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [RenderFilter]
        [HttpPost]
        public ActionResult Dic(TS_DICDTO dicDto)
        {
            //获取数据字典列表
            PageResult<TS_DIC> ef = service.GetDics(dicDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            dicDto.Dics = MAPPING.ConvertEntityToDtoList<TS_DIC, TS_DICDTO>(ef.DataList.OrderBy(x => x.C_INDEX).ToList());
            return View(dicDto);
        }

        /// <summary>
        /// 数据字典新增
        /// </summary>
        /// <returns></returns>
        public ActionResult DicInsert()
        {
            TS_DICDTO dicDto = new TS_DICDTO();
            dicDto.Title = "数据字典新增";
            dicDto.N_STATUS = 1;
            return View(dicDto);
        }

        /// <summary>
        /// 数据字典新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DicInsert(TS_DICDTO dicDto)
        {
            dicDto.Title = "数据字典新增";
            //验证模型字段
            if (!ModelState.IsValid)
            {
                return View(dicDto);
            }
            //验证数据重复
            else if (!service.ValidateIsRepeat(dicDto, 0))
            {
                ModelState.AddModelError("error", "数据重复");
                return View(dicDto);
            }
            //新增
            else
            {
                dicDto.C_EMP_ID = BaseUser.Id;
                dicDto.C_EMP_NAME = BaseUser.Name;
                dicDto.D_MOD_DT = DateTime.Now;
                service.DicInsert(dicDto);
                dicDto.ResultType = 1;
                return View(dicDto);
            }
        }

        /// <summary>
        ///  数据字典修改
        /// </summary>
        /// <returns></returns>
        public ActionResult DicUpdate(string id)
        {
            TS_DICDTO dicDto = new TS_DICDTO();
            //EF实体转换DTO
            dicDto = AutoMapper.Mapper.Map<TS_DICDTO>(service.Find<TS_DIC>(id));
            dicDto.Title = " 数据字典修改";
            return View("DicInsert", dicDto);
        }

        /// <summary>
        /// 数据字典修改
        /// </summary>
        /// <param name="dicDto">数据字典实体</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DicUpdate(TS_DICDTO dicDto)
        {
            dicDto.Title = "数据字典修改";
            //验证实体字段
            if (!ModelState.IsValid)
            {
                return View(dicDto);
            }
            //验证数据是否重复
            else if (!service.ValidateIsRepeat(dicDto, 1))
            {
                ModelState.AddModelError("error", "数据重复");
                return View("DicInsert", dicDto);
            }
            //修改
            else
            {
                dicDto.C_EMP_ID = BaseUser.Id;
                dicDto.C_EMP_NAME = BaseUser.Name;
                dicDto.D_MOD_DT = DateTime.Now;
                service.DicUpdate(dicDto);
                dicDto.ResultType = 2;
                return View("DicInsert", dicDto);
            }
        }

        /// <summary>
        /// 数据字典删除
        /// </summary>
        /// <returns></returns>
        public int DicDel(string ids)
        {
            service.DicDel(ids, BaseUser);
            return 1;
        }

        /// <summary>
        /// 客户档案
        /// </summary>
        /// <returns></returns>
        [RenderFilter]
        public ActionResult CustFile()
        {
            TS_CUSTFILEDTO cfDto = new TS_CUSTFILEDTO();
            //获取数据字典列表
            PageResult<TS_CUSTFILE> ef = service.GetCustFiles(cfDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            cfDto.CustFiles = MAPPING.ConvertEntityToDtoList<TS_CUSTFILE, TS_CUSTFILEDTO>(ef.DataList);
            return View(cfDto);
        }

        /// <summary>
        /// 客户档案
        /// </summary>
        /// <returns></returns>
        [RenderFilter]
        [HttpPost]
        public ActionResult CustFile(TS_CUSTFILEDTO cfDto)
        {
            //获取数据字典列表
            PageResult<TS_CUSTFILE> ef = service.GetCustFiles(cfDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            cfDto.CustFiles = MAPPING.ConvertEntityToDtoList<TS_CUSTFILE, TS_CUSTFILEDTO>(ef.DataList);
            return View(cfDto);
        }

        /// <summary>
        /// 客户档案修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CustFileUpdate(string id)
        {
            TS_CUSTFILEDTO cfDto = new TS_CUSTFILEDTO();
            //EF实体转换DTO
            cfDto = AutoMapper.Mapper.Map<TS_CUSTFILEDTO>(service.Find<TS_CUSTFILE>(id));
            cfDto.Title = " 客户档案修改";
            cfDto.AreaMaxs = service.GetAreaMax();
            cfDto.CustAddrs = MAPPING.ConvertEntityToDtoList<TS_CUSTADDR, TS_CUSTADDRDTO>(service.GetCustAddrs(id));
            cfDto.CustTots = MAPPING.ConvertEntityToDtoList<TS_CUSTOTCOMPANY, TS_CUSTOTCOMPANYDTO>(service.GetCustTots(id));
            return View(cfDto);
        }

        /// <summary>
        /// 客户档案修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CustFileUpdate(TS_CUSTFILEDTO cfDto)
        {
            //EF实体转换DTO
            cfDto.Title = " 客户档案修改";
            cfDto.AreaMaxs = service.GetAreaMax();
            if (!ModelState.IsValid)
                return View(cfDto);

            if (cfDto.OperationType == 1)
            {
                if (cfDto.CustAddrs == null)
                {
                    cfDto.CustAddrs = new List<TS_CUSTADDRDTO>();
                }

                if (cfDto.CustAddrs.Count > 0)
                {
                    foreach (var item in cfDto.CustAddrs)
                    {
                        item.N_ISDEFAULT = 0;
                    }
                }

                TS_CUSTADDRDTO addr = new TS_CUSTADDRDTO();
                addr.C_CUST_ID = cfDto.C_ID;
                addr.N_ISDEFAULT = 1;
                cfDto.CustAddrs.Add(addr);
                return View(cfDto);
            }

            else if (cfDto.OperationType == 2)
            {
                if (cfDto.CustTots == null)
                {
                    cfDto.CustTots = new List<TS_CUSTOTCOMPANYDTO>();
                }

                if (cfDto.CustTots.Count > 0)
                {
                    foreach (var item in cfDto.CustTots)
                    {
                        item.N_ISDEFAULT = 0;
                    }
                }

                TS_CUSTOTCOMPANYDTO tot = new TS_CUSTOTCOMPANYDTO();
                tot.C_CUST_ID = cfDto.C_ID;
                tot.N_ISDEFAULT = 1;
                cfDto.CustTots.Add(tot);
                return View(cfDto);
            }

            if (cfDto.OperationType == 3)
            {
                service.CustFileUpdate(cfDto);
                service.SaveCustAddr(cfDto);
                service.SaveCustTot(cfDto);
                cfDto.ResultType = 1;
                return View(cfDto);
            }

            return View(cfDto);
        }

        /// <summary>
        /// 用户使用报告新增
        /// </summary>
        /// <returns></returns>
        public ActionResult CustReportInsert()
        {
            TMC_CUST_REPORTDTO crDto = new TMC_CUST_REPORTDTO();
            if (BaseUser.CustFile != null)
            {
                crDto.C_CUST_NAME = BaseUser.CustFile.C_NAME;
                crDto.C_CUST_NO = BaseUser.CustFile.C_NO;
            }
            return View(crDto);
        }

        /// <summary>
        /// 用户使用报告新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CustReportInsert(TMC_CUST_REPORTDTO crDto)
        {
            if (!ModelState.IsValid)
            {
                return View(crDto);
            }
            crDto.C_EMP_ID = BaseUser.Id;
            crDto.C_EMP_NAME = BaseUser.Name;
            crDto.D_MOD_DT = DateTime.Now;
            crDto.ResultType = 1;
            service.CustReportInsert(crDto);
            return View(crDto);
        }

        /// <summary>
        /// 用户使用报告
        /// </summary>
        /// <returns></returns>
        public ActionResult CustReport()
        {
            TMC_CUST_REPORTDTO crDto = new TMC_CUST_REPORTDTO();
            crDto.Start = DateTime.Now.AddDays(-5);
            crDto.End = DateTime.Now.AddDays(1);
            //获取完成工差列表
            PageResult<TMC_CUST_REPORT> ef = service.GetCustReports(crDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            crDto.CustReports = MAPPING.ConvertEntityToDtoList<TMC_CUST_REPORT, TMC_CUST_REPORTDTO>(ef.DataList);
            return View(crDto);
        }

        /// <summary>
        /// 用户使用报告
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CustReport(TMC_CUST_REPORTDTO crDto)
        {
            //获取完成工差列表
            PageResult<TMC_CUST_REPORT> ef = service.GetCustReports(crDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            crDto.CustReports = MAPPING.ConvertEntityToDtoList<TMC_CUST_REPORT, TMC_CUST_REPORTDTO>(ef.DataList);
            return View(crDto);
        }

        /// <summary>
        /// 用户使用报告
        /// </summary>
        /// <returns></returns>
        public ActionResult QueryCustReport(string id)
        {
            TMC_CUST_REPORTDTO dto = new TMC_CUST_REPORTDTO();
            dto = service.GetCustReport(id);
            return View(dto);
        }

        /// <summary>
        /// 客户满意度新增
        /// </summary>
        /// <returns></returns>
        public ActionResult CustEvalInsert()
        {
            TMC_CUST_EVALDTO dto = new TMC_CUST_EVALDTO();
            dto.EvalSubs = new List<TMC_CUST_EVAL_SUBDTO>();

            dto.StdMains = service.GetStdMain();
            dto.C_TEL = BaseUser.C_MOBILE;
            dto.C_EMP_NAME = BaseUser.Name;

            if (BaseUser.CustFile != null)
            {
                dto.C_CUST = BaseUser.CustFile.C_NAME;
                dto.N_CUST_TYPE =0;
                //dto.C_AREA = qualityService.GetAreaName(BaseUser.CustFile.C_AREATYPE);
                dto.EvalItems = service.GetEvalItems("0");
            }
            else
            {
                dto.C_CUST = BaseUser.Name;
                dto.N_CUST_TYPE =0;
                dto.C_EMP_NAME = BaseUser.Name;
                dto.EvalItems = service.GetEvalItems("0");
            }

            if (dto.EvalItems != null && dto.EvalItems.Count > 0)
            {
                foreach (var item in dto.EvalItems)
                {
                    TMC_CUST_EVAL_SUBDTO newDto = new TMC_CUST_EVAL_SUBDTO();
                    newDto.C_ITEM_ID = item.C_ID;
                    newDto.C_ITEM_NAME = item.C_NAME;
                    dto.EvalSubs.Add(newDto);
                }
            }
            return View(dto);
        }

        /// <summary>
        /// 客户满意度新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CustEvalInsert(TMC_CUST_EVALDTO dto)
        {
            if (!ModelState.IsValid)
            { return View(dto); }
            dto.StdMains = service.GetStdMain();
            dto.C_ID = Guid.NewGuid().ToString();
            dto.C_EMP_ID = BaseUser.Id;
            dto.C_EMP_NAME = BaseUser.Name;
            dto.D_MOD_DT = DateTime.Now;
            service.CustEvalInsert(dto);
            dto.ResultType = 1;
            return View(dto);
        }

        /// <summary>
        /// 客户满意度列表
        /// </summary>
        /// <returns></returns>
        public ActionResult CustEval()
        {
            TMC_CUST_EVALDTO ceDto = new TMC_CUST_EVALDTO();
            ceDto.StdMains = service.GetStdMain();
            ceDto.Start = DateTime.Now.AddDays(-5);
            ceDto.End = DateTime.Now.AddDays(1);
            //获取完成工差列表
            PageResult<TMC_CUST_EVAL> ef = service.GetCustEvals(ceDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            ceDto.CustEvals = MAPPING.ConvertEntityToDtoList<TMC_CUST_EVAL, TMC_CUST_EVALDTO>(ef.DataList);
            //钢种大类ID转换汉字
            if (ceDto.CustEvals != null && ceDto.CustEvals.Count > 0)
            {
                foreach (var item in ceDto.CustEvals)
                {
                    if (item.C_PROD != null)
                    {
                        SelectListItem listItem = ceDto.StdMains.FirstOrDefault(x => x.Value.Equals(item.C_PROD));
                        if (listItem != null)
                            item.C_PROD_NAME = listItem.Text;
                    }
                }
            }
            return View(ceDto);
        }

        /// <summary>
        /// 客户满意度列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CustEval(TMC_CUST_EVALDTO ceDto)
        {
            ceDto.StdMains = service.GetStdMain();
            //获取完成工差列表
            PageResult<TMC_CUST_EVAL> ef = service.GetCustEvals(ceDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            ceDto.CustEvals = MAPPING.ConvertEntityToDtoList<TMC_CUST_EVAL, TMC_CUST_EVALDTO>(ef.DataList);
            return View(ceDto);
        }

        /// <summary>
        /// 查看客户满意度
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult QueryCustEval(string id)
        {

            TMC_CUST_EVALDTO ceDto = service.GetCustEval(id);
            ceDto.StdMains = service.GetStdMain();
            ceDto.EvalItems = service.GetEvalItems(ceDto.N_CUST_TYPE.ToString());
            if (ceDto.EvalSubs != null && ceDto.EvalSubs.Count > 0)
            {
                foreach (var item in ceDto.EvalSubs)
                {
                    TMC_EVAL_ITEMDTO evalItem = ceDto.EvalItems.FirstOrDefault(x => x.C_ID == item.C_ITEM_ID);
                    if (evalItem != null)
                    {
                        item.C_ITEM_NAME = evalItem.C_NAME;
                        item.Desc = evalItem.C_EMP_NAME;
                    }
                }
                ceDto.EvalSubs = ceDto.EvalSubs.OrderBy(x => x.Desc).ToList();
            }
            return View(ceDto);
        }

    }
}