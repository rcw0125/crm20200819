

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NF.Bussiness.Interface;
using NF.Framework;
using NF.Framework.DTO;
using NF.Web.Core;
using Microsoft.Practices.Unity;
using NF.EF.Model;
using System.Linq.Expressions;
using System.Globalization;

namespace CRM.Controllers
{
    public class BaseController : Controller
    {
        IUserMenuService service = DIFactory.GetContainer().Resolve<IUserMenuService>();
        IComService serviceCom = DIFactory.GetContainer().Resolve<IComService>();
        IMenuButtonService buttonService = DIFactory.GetContainer().Resolve<IMenuButtonService>();
        IBasicsDataService basicsService = DIFactory.GetContainer().Resolve<IBasicsDataService>();

        protected CurrentUser BaseUser
        {
            get
            {
                if (this.HttpContext.Session["CurrentUser"] != null)
                    return (CurrentUser)this.HttpContext.Session["CurrentUser"];
                else
                    return new CurrentUser();
            }
        }

        protected List<TMB_COMDIFF> ComDiffs
        {
            get
            {
                return basicsService.GetComDiffs();
            }
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="queryType">查询类型1 多选 0单选</param>
        /// <param name="htmlApproveId">html审批人标记id</param>
        /// <returns></returns>
        public ActionResult QueryUser(int queryType, string htmlApproveId, string htmlApproveName)
        {
            TS_USERDTO uDto = new TS_USERDTO();
            PageResult<TS_USER> ef = service.GetUsers(uDto);
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            uDto.Users = MAPPING.ConvertEntityToDtoList<TS_USER, TS_USERDTO>(ef.DataList);
            uDto.C_QueryType = queryType;
            uDto.HtmlApproveId = htmlApproveId;
            uDto.HtmlApproveName = htmlApproveName;
            return View(uDto);
        }

        /// <summary>
        /// 查询用户post
        /// </summary>
        /// <param name="uDto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult QueryUser(TS_USERDTO uDto)
        {
            PageResult<TS_USER> ef = service.GetUsers(uDto);
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            uDto.Users = MAPPING.ConvertEntityToDtoList<TS_USER, TS_USERDTO>(ef.DataList);
            return View(uDto);
        }

        /// <summary>
        /// 查询部门
        /// </summary>
        /// <returns></returns>
        public ActionResult QueryDept()
        {
            List<TS_DEPTDTO> list = serviceCom.GetDetp("1");
            List<DEPTDTO> deptDto = MAPPING.ConvertDept(list);
            TS_DEPTDTO dto = new TS_DEPTDTO();
            string strDept = NF.Framework.SerializationHelper.JsonSerialize(deptDto).Replace("\"nodes\":[],", "");
            dto.JsonDept = strDept;
            return View(dto);
        }

        /// <summary>
        /// 查询线材库
        /// </summary>
        /// <param name="no">订单no</param>
        /// <param name="paras">钢种|规格|地区|执行标准</param>
        /// <param name="wareOutWgt">出库量</param>
        /// <param name="wgt">数量</param>
        /// <param name="stoveid">货物ID</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult QueryProduct(string no, string paras, string wareOutWgt, string wgt, string stoveid, string dispatchID)
        {
            TRC_ROLL_PRODCUTDTO rollProductDto = new TRC_ROLL_PRODCUTDTO();

            #region 计算合同工差量
            decimal fantasiWgt = decimal.Parse(wgt);
            var comDiffs = ComDiffs.FirstOrDefault(x => (x.D_MIN <= fantasiWgt &&
            x.D_MAX >= fantasiWgt));
            decimal percentage = decimal.Parse(comDiffs.C_RANGE) / 100m;
            rollProductDto.MaxWgt = fantasiWgt * percentage + fantasiWgt;
            rollProductDto.MinWgt = fantasiWgt - fantasiWgt * percentage;
            #endregion

            rollProductDto.C_ORDER_NO = no;
            rollProductDto.WareOutWgt = decimal.Parse(wareOutWgt);
            rollProductDto.Wgt = decimal.Parse(wgt);
            string[] arr = paras.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length == 4)
            {
                //获取货物仓位信息
                rollProductDto.RollProducts = serviceCom.GetRollProducts(arr[0], arr[1], arr[2], arr[3]);
                //如果在列表中已存在的货物则移除
                if (!string.IsNullOrWhiteSpace(stoveid))
                {
                    var arrStoveIds = stoveid.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (rollProductDto.RollProducts != null && rollProductDto.RollProducts.Count > 0)
                    {
                        foreach (var id in arrStoveIds)
                        {
                            var newDto = rollProductDto.RollProducts.FirstOrDefault(x => x.C_ID.Equals(id));
                            if (newDto != null && !string.IsNullOrWhiteSpace(newDto.C_ID))
                                rollProductDto.RollProducts.Remove(newDto);
                        }
                    }
                }
            }
            return View(rollProductDto);
        }

        /// <summary>
        /// 查询钢坯库
        /// </summary>
        /// <param name="no">订单no</param>
        /// <param name="paras">钢种|规格|地区|执行标准</param>
        /// <param name="wareOutWgt">出库量</param>
        /// <param name="wgt">数量</param>
        /// <param name="stoveid">货物ID</param>
        /// <returns></returns>
        public ActionResult QuerySlabMain(string no, string paras, string wareOutWgt, string wgt, string stoveid, string dispatchID)
        {
            TSC_SLAB_MAINDTO slabMainDto = new TSC_SLAB_MAINDTO();

            #region 计算合同工差量
            decimal fantasiWgt = decimal.Parse(wgt);
            var comDiffs = ComDiffs.FirstOrDefault(x => (x.D_MIN <= fantasiWgt &&
            x.D_MAX >= fantasiWgt));
            decimal percentage = decimal.Parse(comDiffs.C_RANGE) / 100m;
            slabMainDto.MaxWgt = fantasiWgt * percentage + fantasiWgt;
            slabMainDto.MinWgt = fantasiWgt - fantasiWgt * percentage;
            #endregion

            slabMainDto.C_ORD_NO = no;
            slabMainDto.WareOutWgt = decimal.Parse(wareOutWgt);
            slabMainDto.Wgt = decimal.Parse(wgt);
            string[] arr = paras.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length == 4)
            {
                //获取货物仓位信息
                slabMainDto.SlabMains = serviceCom.GetSlabMain(arr[0], arr[1], arr[2], arr[3]);
                //如果在列表中已存在的货物则移除
                if (!string.IsNullOrWhiteSpace(stoveid))
                {
                    var arrStoveIds = stoveid.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (slabMainDto.SlabMains != null && slabMainDto.SlabMains.Count > 0)
                    {
                        foreach (var id in arrStoveIds)
                        {
                            var newDto = slabMainDto.SlabMains.FirstOrDefault(x => x.C_ID.Equals(id));
                            if (newDto != null && !string.IsNullOrWhiteSpace(newDto.C_ID))
                                slabMainDto.SlabMains.Remove(newDto);
                        }
                    }
                }
            }
            return View(slabMainDto);
        }

        /// <summary>
        /// 查找到站地点
        /// </summary>
        /// <returns></returns>
        public ActionResult AtStation()

        {
            IEnumerable<TMB_AREADTO> list = serviceCom.GetStation("09A0D341FD3248539B8D7418966FF534");
            return View();
        }

        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <returns></returns>
        public ContentResult MessageBox(string msg)
        {
            return Content("<script >alert('" + msg + "'); window.opener.document.getElementById('btn_Search').click();  window.close(); </script>");
        }

        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <returns></returns>
        public ContentResult MessageBox(string msg, int type = 0)
        {
            return Content("<script >alert('" + msg + "'); window.opener.document.getElementById('btn_Search').click();   </script>");
        }

        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <param name="url"></param>
        /// <returns></returns>
        public ContentResult MessageBox(string msg, string url)
        {
            return Content("<script >alert('" + msg + "'); document.location=" + url + " </script>");
        }

        /// <summary>
        /// 登录超时刷新页面
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <param name="url"></param>
        /// <returns></returns>
        public void LogOutTimeRefresh()
        {
            Response.Write("<script>parent.location.reload();</script>");
        }

        /// <summary>
        /// 按钮刷新
        /// </summary>
        /// <param name="url"></param>
        public void RefreshButtons(string url)
        {
            List<TS_BUTTON> buttons = buttonService.GetButtons(url).ToList();
            List<TS_BUTTON> useButtons = new List<TS_BUTTON>();
            if (buttons == null)
            {
                buttons = new List<TS_BUTTON>();
            }
            CurrentUser currentUser = (CurrentUser)Request.RequestContext.HttpContext.Session["CurrentUser"];
            List<TS_FUNCTIONDTO> fDtos = currentUser.ButtonFuncs;
            foreach (var m in buttons)
            {
                if (fDtos.Exists(x => x.ButtonID.Equals(m.C_ID)))
                {
                    useButtons.Add(m);
                }
            }
            Request.RequestContext.HttpContext.Session["button"] = useButtons;
        }

        /// <summary>
        /// 查询菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult QueryMenu()
        {
            TS_MENUDTO dto = new TS_MENUDTO();
            dto.Menus = MAPPING.ConvertEntityToDtoList<TS_MENU, TS_MENUDTO>(service.GetMenus());
            return View(dto);
        }

    }
    public class Data
    {
        public string no { get; set; }
        public string paras { get; set; }
        public string wareOutWgt { get; set; }
        public string wgt { get; set; }
        public string stoveid { get; set; }
    }
}