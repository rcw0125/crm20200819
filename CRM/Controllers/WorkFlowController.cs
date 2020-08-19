using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NF.Bussiness.Interface;
using NF.Web.Core;
using Microsoft.Practices.Unity;
using NF.Framework.DTO;
using NF.Framework;
using NF.EF.Model;

namespace CRM.Controllers
{
    public class WorkFlowController : BaseController
    {
        IWorkFlowService service = DIFactory.GetContainer().Resolve<IWorkFlowService>();

        /// <summary>
        /// 流程配置列表
        /// </summary>
        /// <returns></returns>
        [RenderFilter]
        public ActionResult FlowInfo()
        {
            TMB_FLOWINFODTO fiDto = new TMB_FLOWINFODTO();
            //获取列表
            PageResult<TMB_FLOWINFO> ef = service.FlowInfos(fiDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体转换DTO
            fiDto.FlowInfos = MAPPING.ConvertEntityToDtoList<TMB_FLOWINFO, TMB_FLOWINFODTO>(ef.DataList);
            return View(fiDto);
        }

        /// <summary>
        /// 流程配置列表
        /// </summary>
        /// <returns></returns>
        [RenderFilter]
        [HttpPost]
        public ActionResult FlowInfo(TMB_FLOWINFODTO fiDto)
        {
            //获取列表
            PageResult<TMB_FLOWINFO> ef = service.FlowInfos(fiDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体转换DTO
            fiDto.FlowInfos = MAPPING.ConvertEntityToDtoList<TMB_FLOWINFO, TMB_FLOWINFODTO>(ef.DataList);
            return View(fiDto);
        }

        /// <summary>
        /// 流程配置新增
        /// </summary>
        /// <returns></returns>
        public ActionResult FlowInfoInsert()
        {
            TMB_FLOWINFODTO fiDto = new TMB_FLOWINFODTO();
            fiDto.Title = "流程配置新增";
            //生成下拉列表
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "顺序处理", Value = "0" });
            items.Add(new SelectListItem() { Text = "并行处理", Value = "1" });
            fiDto.items = items;
            //获取角色生成流程
            fiDto.StepInfos = service.GetStepInfos();
            return View(fiDto);
        }

        /// <summary>
        /// 流程配置新增
        /// </summary>
        /// <returns></returns>
        public ActionResult FlowInfoInsertDouble(int? type)
        {
            TMB_FLOWINFODTO fiDto = new TMB_FLOWINFODTO();
            fiDto.Title = "流程配置新增";
            fiDto.N_TYPE = type;
            //生成下拉列表
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "顺序处理", Value = "0" });
            items.Add(new SelectListItem() { Text = "并行处理", Value = "1" });
            fiDto.items = items;
            //获取角色生成流程
            fiDto.StepInfos = service.GetStepInfos();
            return View("FlowInfoInsert", fiDto);
        }

        /// <summary>
        /// 流程配置新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FlowInfoInsert(TMB_FLOWINFODTO fiDto)
        {
            fiDto.Title = "流程配置新增";
            //生成下拉列表
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "顺序处理", Value = "0" });
            items.Add(new SelectListItem() { Text = "并行处理", Value = "1" });
            fiDto.items = items;
            //验证模型字段
            if (!ModelState.IsValid)
                return View(fiDto);
            //审批步骤必须选择
            else if (!fiDto.StepInfos.Select(x => x.IsCheck == true).Contains(true))
            {
                ModelState.AddModelError("error", "审批步骤不能为空");
                return View(fiDto);
            }
            //验证是否重复
            else if (!service.ValidateIsRepeat(fiDto, 0))
            {
                ModelState.AddModelError("error", "流程名称重复!");
                return View(fiDto);
            }
            //新增
            else
            {
                fiDto.C_EMP_ID = BaseUser.Id;
                fiDto.C_EMP_NAME = BaseUser.Name;
                fiDto.D_MOD_DT = DateTime.Now;
                service.FlowInfoInsert(fiDto);
                fiDto.ResultType = 1;
                return View(fiDto);
            }
        }


        /// <summary>
        /// 流程配置修改
        /// </summary>
        /// <returns></returns>
        public ActionResult FlowInfoUpdate(string id)
        {
            TMB_FLOWINFODTO fiDto = new TMB_FLOWINFODTO();
            fiDto = service.GetFlowInfo(id);
            fiDto.Title = "流程配置修改";
            //生成下拉列表
            //List<SelectListItem> items = new List<SelectListItem>();
            //items.Add(new SelectListItem() { Text = "顺序处理", Value = "0" });
            //items.Add(new SelectListItem() { Text = "并行处理", Value = "1" });
            //fiDto.items = items;
            return View("FlowInfoInsert", fiDto);
        }

        /// <summary>
        /// 流程配置修改
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FlowInfoUpdate(TMB_FLOWINFODTO fiDto)
        {
            fiDto.Title = "流程配置修改";
            //生成下拉列表
            //List<SelectListItem> items = new List<SelectListItem>();
            //items.Add(new SelectListItem() { Text = "顺序处理", Value = "0" });
            //items.Add(new SelectListItem() { Text = "并行处理", Value = "1" });
            //fiDto.items = items;
            //验证模型字段
            if (!ModelState.IsValid)
                return View("FlowInfoInsert", fiDto);
            //审批步骤必须选择
            else if (!fiDto.StepInfos.Select(x => x.IsCheck == true).Contains(true))
            {
                ModelState.AddModelError("error", "审批步骤不能为空");
                return View("FlowInfoInsert", fiDto);
            }
            //验证是否重复
            else if (!service.ValidateIsRepeat(fiDto, 1))
            {
                ModelState.AddModelError("error", "流程名称重复!");
                return View("FlowInfoInsert", fiDto);
            }
            //修改
            else
            {
                fiDto.C_EMP_ID = BaseUser.Id;
                fiDto.C_EMP_NAME = BaseUser.Name;
                fiDto.D_MOD_DT = DateTime.Now;
                service.FlowInfoUpdate(fiDto);
                fiDto.ResultType = 2;
                return View("FlowInfoInsert", fiDto);
            }
        }

        /// <summary>
        /// 流程信息删除
        /// </summary>
        /// <returns></returns>
        public int FlowInfoDel(string ids)
        {
            service.FlowInfoDel(ids, BaseUser);
            return 1;
        }

    }
}