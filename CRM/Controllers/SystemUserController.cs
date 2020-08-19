using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NF.EF.Model;
using NF.Framework.DTO;
using NF.Bussiness.Interface;
using NF.Web.Core;
using Microsoft.Practices.Unity;
using NF.Framework;

namespace CRM.Controllers
{
    public class SystemUserController : BaseController
    {
        IUserMenuService service = DIFactory.GetContainer().Resolve<IUserMenuService>();
        IBasicsDataService basicsService = DIFactory.GetContainer().Resolve<IBasicsDataService>();
        IHtmlHelperService helperService = DIFactory.GetContainer().Resolve<IHtmlHelperService>();


        /// <summary>
        /// 用户管理列表
        /// </summary>
        /// <returns></returns>
        [RenderFilter]
        public ActionResult UserManage()
        {
            TS_USERDTO dto = new TS_USERDTO();
            //获取完成工差列表
            PageResult<TS_USER> ef = service.GetUsers(dto, 1);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            dto.Users = MAPPING.ConvertEntityToDtoList<TS_USER, TS_USERDTO>(ef.DataList);
            //获取客户档案
            foreach (var item in dto.Users)
            {
                if (item.C_CUST_ID != null)
                    item.CustFile = basicsService.GetCustFile(item.C_CUST_ID);
                else
                    item.CustFile = new TS_CUSTFILE();
            }
            //角色列表
            dto.Roles = basicsService.GetRoleDropDown();
            //获取部门
            dto = service.GetDept(dto);
            return View(dto);
        }

        /// <summary>
        /// 用户管理列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [RenderFilter]
        public ActionResult UserManage(TS_USERDTO dto)
        {
            //获取完成工差列表
            PageResult<TS_USER> ef = service.GetUsers(dto, 1);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            dto.Users = MAPPING.ConvertEntityToDtoList<TS_USER, TS_USERDTO>(ef.DataList);
            //获取客户档案
            foreach (var item in dto.Users)
            {
                if (item.C_CUST_ID != null)
                    item.CustFile = basicsService.GetCustFile(item.C_CUST_ID);
                else
                    item.CustFile = new TS_CUSTFILE();
            }
            //角色列表
            dto.Roles = basicsService.GetRoleDropDown();
            //获取部门
            dto = service.GetDept(dto);
            return View(dto);
        }

        /// <summary>
        /// 用户新增
        /// </summary>
        /// <returns></returns>
        public ActionResult UserInsert()
        {
            TS_USERDTO dto = new TS_USERDTO();
            dto.Title = "用户添加";
            return View(dto);
        }

        /// <summary>
        /// 用户新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UserInsert(TS_USERDTO dto)
        {
            dto.Title = "用户添加";
            //验证数据模型
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            //用户是否重复
            if (service.GetUser(dto.C_ACCOUNT) != null)
            {
                ModelState.AddModelError("error", "登录名重复");
                return View(dto);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(dto.C_ACCOUNT))
                    dto.C_ACCOUNT = dto.C_ACCOUNT.Trim();
                if (!string.IsNullOrWhiteSpace(dto.C_PASSWORD))
                    dto.C_PASSWORD = Encrypt.MD5(dto.C_PASSWORD.Trim());
                dto.C_EMP_ID = BaseUser.Id;
                dto.C_EMP_NAME = BaseUser.Name;
                dto.D_MOD_DT = DateTime.Now;
                TS_USER user = AutoMapper.Mapper.Map<TS_USER>(dto);
                //用户类别1客户 2内部
                user.N_TYPE = 2;
                //新增用户
                service.UserInsert(user);
                //部门信息更新
                service.DeptOperation(dto);
                dto.ResultType = 1;
                return View(dto);
            }
        }

        /// <summary>
        /// 用户修改
        /// </summary>
        /// <returns></returns>
        public ActionResult UserUpdate(string id)
        {
            TS_USERDTO dto = new TS_USERDTO();
            dto.Title = "用户修改";
            dto = service.Get(id);
            return View(dto);
        }

        /// <summary>
        /// 用户修改
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UserUpdate(TS_USERDTO dto)
        {
            //验证数据模型
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            //用户是否重复
            if (service.UserLogin(dto.C_ACCOUNT, dto.C_ID) != null)
            {
                ModelState.AddModelError("error", "登录名重复");
                return View(dto);
            }
            else
            {
                dto.C_EMP_ID = BaseUser.Id;
                dto.C_EMP_NAME = BaseUser.Name;
                dto.D_MOD_DT = DateTime.Now;
                TS_USER user = AutoMapper.Mapper.Map<TS_USER>(dto);
                //修改用户
                service.UserUpdate(user);
                //部门信息更新
                service.DeptOperation(dto);
                dto.ResultType = 1;
                return View(dto);
            }
        }

        /// <summary>
        /// 删除用户（逻辑删除）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public int UserDel(string id)
        {
            int i = 0;
            try
            {
                var dto = service.Get(id);
                dto.N_STATUS = 5;
                TS_USER user = AutoMapper.Mapper.Map<TS_USER>(dto);
                service.UserUpdate(user);
                i = 1;
            }
            catch (Exception ex)
            {
                i = 0;
            }
            return i;
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        public ActionResult SetPw(string id)
        {
            ViewBag.id = id;
            return View();
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SetPw(string pw, string confirmPw, string id)
        {
            if (string.IsNullOrWhiteSpace(pw) || string.IsNullOrWhiteSpace(confirmPw))
            {
                ModelState.AddModelError("pw", "密码不能为空");
                ModelState.AddModelError("confirmPw", "确认密码不能为空");
                return View();
            }

            if (pw != confirmPw)
            {
                ModelState.AddModelError("error", "密码输入不一致");
                return View();
            }

            var dto = service.Get(id);
            dto.C_PASSWORD = Encrypt.MD5(pw);
            TS_USER user = AutoMapper.Mapper.Map<TS_USER>(dto);
            service.UserUpdate(user);
            ViewBag.ResultType = 1;
            return View();
        }


        /// <summary>
        /// 关联客户档案
        /// </summary>
        /// <returns></returns>
        public ActionResult Relation(string id)
        {
            TS_CUSTFILEDTO cfDto = new TS_CUSTFILEDTO();
            cfDto.C_EXTEND1 = id;
            //获取数据字典列表
            PageResult<TS_CUSTFILE> ef = basicsService.GetCustFiles(cfDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            cfDto.CustFiles = MAPPING.ConvertEntityToDtoList<TS_CUSTFILE, TS_CUSTFILEDTO>(ef.DataList);
            return View(cfDto);
        }

        /// <summary>
        /// 关联客户档案
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Relation(TS_CUSTFILEDTO cfDto)
        {
            //关联客户档案
            if (cfDto.OperationType == 1)
            {
                string msg = "";
                int result = service.Relation(cfDto, out msg);
                //获取数据字典列表
                PageResult<TS_CUSTFILE> ef = basicsService.GetCustFiles(cfDto);
                //获取分页数据
                BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
                this.HttpContext.Session["Page"] = page;
                //EF实体数据转换为DTO
                cfDto.CustFiles = MAPPING.ConvertEntityToDtoList<TS_CUSTFILE, TS_CUSTFILEDTO>(ef.DataList);
                if (result == 1)
                    cfDto.ResultType = 1;
                else
                    cfDto.ResultType = 2;

                cfDto.Msg = msg;

                return View(cfDto);
            }
            else
            {
                //获取数据字典列表
                PageResult<TS_CUSTFILE> ef = basicsService.GetCustFiles(cfDto);
                //获取分页数据
                BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
                this.HttpContext.Session["Page"] = page;
                //EF实体数据转换为DTO
                cfDto.CustFiles = MAPPING.ConvertEntityToDtoList<TS_CUSTFILE, TS_CUSTFILEDTO>(ef.DataList);
                return View(cfDto);
            }
        }

        /// <summary>
        /// 取消关联客户档案
        /// </summary>
        /// <returns></returns>
        public int CancelRelation(string id)
        {
            return service.CancelRelation(id);
        }

        /// <summary>
        /// 权限列表
        /// </summary>
        /// <returns></returns>
        [RenderFilter]
        public ActionResult Function()
        {
            TS_FUNCTIONDTO fcDto = new TS_FUNCTIONDTO();
            //获取完成工差列表
            PageResult<TS_FUNCTION> ef = basicsService.GetFunctions(fcDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            fcDto.Functions = MAPPING.ConvertEntityToDtoList<TS_FUNCTION, TS_FUNCTIONDTO>(ef.DataList);
            return View(fcDto);
        }

        /// <summary>
        /// 权限列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [RenderFilter]
        public ActionResult Function(TS_FUNCTIONDTO fcDto)
        {
            //获取完成工差列表
            PageResult<TS_FUNCTION> ef = basicsService.GetFunctions(fcDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            fcDto.Functions = MAPPING.ConvertEntityToDtoList<TS_FUNCTION, TS_FUNCTIONDTO>(ef.DataList);
            return View(fcDto);
        }

        /// <summary>
        /// 权限新增
        /// </summary>
        /// <returns></returns>
        public ActionResult FunctionInsert()
        {
            TS_FUNCTIONDTO fcDto = new TS_FUNCTIONDTO();
            fcDto.Title = "权限添加";
            fcDto.N_STATUS = 1;
            return View(fcDto);
        }

        /// <summary>
        /// 权限新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FunctionInsert(TS_FUNCTIONDTO fcDto)
        {
            fcDto.Title = "权限添加";
            if (!ModelState.IsValid)
            {
                return View(fcDto);
            }
            else if (!basicsService.ValidateIsRepeat(fcDto, 0))
            {
                ModelState.AddModelError("error", "权限重复");
                return View(fcDto);
            }
            else
            {
                fcDto.C_EMP_ID = BaseUser.Id;
                fcDto.C_EMP_NAME = BaseUser.Name;
                fcDto.D_MOD_DT = DateTime.Now;
                basicsService.FunctionInsert(fcDto);
                fcDto.ResultType = 1;
                return View(fcDto);
            }
        }

        /// <summary>
        /// 权限修改
        /// </summary>
        /// <returns></returns>
        public ActionResult FunctionUpdate(string id)
        {
            TS_FUNCTIONDTO fcDto = new TS_FUNCTIONDTO();
            fcDto.Title = "权限修改";
            fcDto = basicsService.GetFunction(id);
            return View("FunctionInsert", fcDto);
        }

        /// <summary>
        /// 权限修改
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FunctionUpdate(TS_FUNCTIONDTO fcDto)
        {
            fcDto.Title = "权限修改";
            if (!ModelState.IsValid)
            {
                return View(fcDto);
            }
            else if (!basicsService.ValidateIsRepeat(fcDto, 1))
            {
                ModelState.AddModelError("error", "权限重复");
                return View(fcDto);
            }
            else
            {
                fcDto.C_EMP_ID = BaseUser.Id;
                fcDto.C_EMP_NAME = BaseUser.Name;
                fcDto.D_MOD_DT = DateTime.Now;
                basicsService.FunctionUpdate(fcDto);
                fcDto.ResultType = 2;
                return View("FunctionInsert", fcDto);
            }
        }

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        [RenderFilter]
        public ActionResult Role()
        {
            TS_ROLEDTO rDto = new TS_ROLEDTO();
            //获取完成工差列表
            PageResult<TS_ROLE> ef = basicsService.GetRoles(rDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            rDto.Roles = MAPPING.ConvertEntityToDtoList<TS_ROLE, TS_ROLEDTO>(ef.DataList);
            return View(rDto);
        }

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [RenderFilter]
        public ActionResult Role(TS_ROLEDTO rDto)
        {
            //获取完成工差列表
            PageResult<TS_ROLE> ef = basicsService.GetRoles(rDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            rDto.Roles = MAPPING.ConvertEntityToDtoList<TS_ROLE, TS_ROLEDTO>(ef.DataList);
            return View(rDto);
        }

        /// <summary>
        /// 角色新增
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleInsert()
        {
            TS_ROLEDTO rDto = new TS_ROLEDTO();
            rDto.N_STATUS = 1;
            rDto.Title = "角色新增";
            return View(rDto);
        }

        /// <summary>
        /// 角色新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RoleInsert(TS_ROLEDTO rDto)
        {
            rDto.Title = "角色新增";
            if (!ModelState.IsValid)
            {
                return View(rDto);
            }
            else if (!basicsService.ValidateIsRepeat(rDto, 0))
            {
                ModelState.AddModelError("error", "权限重复");
                return View(rDto);
            }
            else
            {
                rDto.C_EMP_ID = BaseUser.Id;
                rDto.C_EMP_NAME = BaseUser.Name;
                rDto.D_MOD_DT = DateTime.Now;
                basicsService.RoleInsert(rDto);
                rDto.ResultType = 1;
                return View(rDto);
            }
        }

        /// <summary>
        /// 角色修改
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleUpdate(string id)
        {
            TS_ROLEDTO rDto = new TS_ROLEDTO();
            rDto.Title = "角色修改";
            rDto = basicsService.GetRole(id);
            return View("RoleInsert", rDto);
        }

        /// <summary>
        /// 角色修改
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RoleUpdate(TS_ROLEDTO rDto)
        {
            rDto.Title = "角色修改";
            if (!ModelState.IsValid)
            {
                return View("RoleInsert", rDto);
            }
            else if (!basicsService.ValidateIsRepeat(rDto, 1))
            {
                ModelState.AddModelError("error", "权限重复");
                return View("RoleInsert", rDto);
            }
            else
            {
                rDto.C_EMP_ID = BaseUser.Id;
                rDto.C_EMP_NAME = BaseUser.Name;
                rDto.D_MOD_DT = DateTime.Now;
                basicsService.RoleUpdate(rDto);
                rDto.ResultType = 2;
                return View("RoleInsert", rDto);
            }
        }

        /// <summary>
        /// 用户关联权限
        /// </summary>
        /// <returns></returns>
        public ActionResult RelationFunc(string id)
        {
            TS_FUNCTIONDTO fcDto = new TS_FUNCTIONDTO();
            fcDto.UserID = id;
            fcDto.MenuFuncs = basicsService.GetMenuFuncs();
            fcDto.ButtonFuncs = basicsService.GetButtonFuncs();
            fcDto.FunID = basicsService.GetUserFun(id);
            return View(fcDto);
        }

        /// <summary>
        /// 用户关联权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string RelationUserFunc(string userID, string funcID)
        {
            string result = basicsService.RelationUserFunc(userID, funcID);
            return result;
        }

        /// <summary>
        ///角色关联权限
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleFunc(string id)
        {
            TS_FUNCTIONDTO fcDto = new TS_FUNCTIONDTO();
            fcDto.RoleID = id;
            fcDto.MenuFuncs = basicsService.GetMenuFuncs();
            fcDto.ButtonFuncs = basicsService.GetButtonFuncs();
            fcDto.FunID = basicsService.GetRoleFun(id);
            return View(fcDto);
        }

        /// <summary>
        /// 角色关联权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string RelationRoleFunc(string roleID, string funcID)
        {
            string result = basicsService.RelationRoleFunc(roleID, funcID);
            return result;
        }

        /// <summary>
        ///用户关联角色
        /// </summary>
        /// <returns></returns>
        public ActionResult RelationRole(string id)
        {
            TS_ROLEDTO rDto = new TS_ROLEDTO();
            rDto.UserID = id;
            rDto.Roles = basicsService.GetRoles();
            rDto.RoleID = basicsService.GetUserRole(id);
            return View(rDto);
        }

        /// <summary>
        ///用户关联角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string RelationRole(string userID, string roleID)
        {
            string result = basicsService.RelationUserRole(userID, roleID);
            return result;
        }

        /// <summary>
        /// 按钮管理
        /// </summary>
        /// <returns></returns>
        [RenderFilter]
        public ActionResult ButtonManage()
        {
            TS_BUTTONDTO bDto = new TS_BUTTONDTO();
            //获取完成工差列表
            PageResult<TS_BUTTON> ef = basicsService.GetButtons(bDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            bDto.Buttons = MAPPING.ConvertEntityToDtoList<TS_BUTTON, TS_BUTTONDTO>(ef.DataList.OrderBy(x => x.C_MENU_ID).ThenBy(x => x.N_INDEX).ToList());
            return View(bDto);
        }

        /// <summary>
        /// 按钮管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [RenderFilter]
        public ActionResult ButtonManage(TS_BUTTONDTO btDto)
        {
            //获取完成工差列表
            PageResult<TS_BUTTON> ef = basicsService.GetButtons(btDto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            btDto.Buttons = MAPPING.ConvertEntityToDtoList<TS_BUTTON, TS_BUTTONDTO>(ef.DataList.OrderBy(x => x.C_MENU_ID).ThenBy(x => x.N_INDEX).ToList());
            return View(btDto);
        }

        /// <summary>
        /// 按钮新增
        /// </summary>
        /// <returns></returns>
        public ActionResult ButtonInsert()
        {
            TS_BUTTONDTO bDto = new TS_BUTTONDTO();
            bDto.Title = "按钮添加";
            bDto.N_STATUS = 1;
            return View(bDto);
        }

        /// <summary>
        /// 按钮新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ButtonInsert(TS_BUTTONDTO bDto)
        {
            bDto.Title = "按钮添加";
            if (!ModelState.IsValid)
            {
                return View(bDto);
            }
            else
            {
                bDto.C_EMP_ID = BaseUser.Id;
                bDto.C_EMP_NAME = BaseUser.Name;
                bDto.D_MOD_DT = DateTime.Now;
                basicsService.ButtonInsert(bDto);
                bDto.ResultType = 1;
            }
            return View(bDto);
        }

        /// <summary>
        /// 按钮关联权限
        /// </summary>
        /// <param name="id">按钮ID</param>
        /// <returns></returns>
        public ActionResult RelationButton(string id)
        {
            TS_FUNCTIONDTO fcDto = new TS_FUNCTIONDTO();
            fcDto.ButtonID = id;
            fcDto.MenuFuncs = basicsService.GetMenuFuncs();
            fcDto.ButtonFuncs = basicsService.GetButtonFuncs();
            fcDto.FunID = basicsService.GetButtonFun(id);
            return View(fcDto);
        }

        /// <summary>
        /// 关联按钮权限
        /// </summary>
        /// <returns></returns>
        public string RelationButtonFunc(string buttonID, string funcID)
        {
            string result = basicsService.RelationButtonFunc(buttonID, funcID);
            return result;
        }

        /// <summary>
        /// 按钮新增
        /// </summary>
        /// <returns></returns>
        public ActionResult ButtonUpdate(string id)
        {
            TS_BUTTONDTO bDto = new TS_BUTTONDTO();
            bDto.Title = "按钮修改";
            bDto = basicsService.GetButton(id);
            bDto.C_MENU_NAME = helperService.GetGenerName<TS_MENU>(bDto.C_MENU_ID, "C_NAME");
            return View("ButtonInsert", bDto);
        }

        /// <summary>
        /// 按钮新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ButtonUpdate(TS_BUTTONDTO bDto)
        {
            bDto.Title = "按钮修改";
            if (!ModelState.IsValid)
            {
                return View("ButtonInsert", bDto);
            }
            else
            {
                bDto.C_EMP_ID = BaseUser.Id;
                bDto.C_EMP_NAME = BaseUser.Name;
                bDto.D_MOD_DT = DateTime.Now;
                basicsService.ButtonUpdate(bDto);
                bDto.ResultType = 2;
            }
            return View("ButtonInsert", bDto);
        }

        /// <summary>
        /// 二级权限
        /// </summary>
        /// <returns></returns>
        public ActionResult SecondFunc(string userID)
        {
            TS_FUNCTIONDTO dto = new TS_FUNCTIONDTO();
            dto.Title = "二级权限";
            dto.UserID = userID;
            //当前登录用户id
            basicsService.GetSecondFuncs(dto, BaseUser.Id);
            return View(dto);
        }

        /// <summary>
        /// 赋值二级权限
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="funcID"></param>
        /// <returns></returns>
        public string SecondRelationFunc(string userID, string funcID)
        {
            string result = basicsService.RelationUserFunc(userID, funcID);
            return result;
        }

        /// <summary>
        /// 查询菜单
        /// </summary>
        /// <returns></returns>
        [RenderFilter]
        public ActionResult MenuManage()
        {
            TS_MENUDTO dto = new TS_MENUDTO();
            //获取完成工差列表
            PageResult<TS_MENU> ef = service.GetMenus(dto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            dto.Menus = MAPPING.ConvertEntityToDtoList<TS_MENU, TS_MENUDTO>(ef.DataList);
            return View(dto);
        }

        /// <summary>
        /// 查询菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [RenderFilter]
        public ActionResult MenuManage(TS_MENUDTO dto)
        {
            //获取完成工差列表
            PageResult<TS_MENU> ef = service.GetMenus(dto);
            //获取分页数据
            BASEPAGE page = AUTOMAPING.Mapping<BASEPAGE>(ef);
            this.HttpContext.Session["Page"] = page;
            //EF实体数据转换为DTO
            dto.Menus = MAPPING.ConvertEntityToDtoList<TS_MENU, TS_MENUDTO>(ef.DataList);
            return View(dto);
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult MenuInsert()
        {
            TS_MENUDTO dto = new TS_MENUDTO();
            dto.Title = "菜单添加";
            dto.Levels = service.GetMenuLevel();
            dto.MenuItems = service.GetMenu(1);
            return View(dto);
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MenuInsert(TS_MENUDTO dto)
        {
            dto.Levels = service.GetMenuLevel();
            dto.MenuItems = service.GetMenu(1);
            dto.Title = "菜单添加";
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            else
            {
                dto.C_EMP_ID = BaseUser.Id;
                dto.C_EMP_NAME = BaseUser.Name;
                dto.D_MOD_DT = DateTime.Now;
                dto.N_STATUS = 1;
                dto.N_TYPE = 1;
                if (string.IsNullOrWhiteSpace(dto.C_PARENT_ID))
                    dto.N_MENULEVEL = 1;
                else
                    dto.N_MENULEVEL = 2;
                service.MenuInsert(dto);
                dto.ResultType = 1;
                return View(dto);
            }
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult MenuUpdate(string id)
        {
            TS_MENUDTO dto = new TS_MENUDTO();
            dto = service.GetMenu(id);
            dto.Title = "菜单修改";
            dto.Levels = service.GetMenuLevel();
            dto.MenuItems = service.GetMenu(1);
            return View("MenuInsert", dto);
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MenuUpdate(TS_MENUDTO dto)
        {
            dto.Title = "菜单修改";
            dto.Levels = service.GetMenuLevel();
            dto.MenuItems = service.GetMenu(1);
            dto.C_EMP_ID = BaseUser.Id;
            dto.C_EMP_NAME = BaseUser.Name;
            dto.D_MOD_DT = DateTime.Now;
            if (string.IsNullOrWhiteSpace(dto.C_PARENT_ID))
                dto.N_MENULEVEL = 1;
            else
                dto.N_MENULEVEL = 2;
            service.MenuUpdate(dto);
            dto.ResultType = 2;
            return View("MenuInsert", dto);
        }

        /// <summary>
        /// 菜单关联权限
        /// </summary>
        /// <param name="id">按钮ID</param>
        /// <returns></returns>
        public ActionResult RelationMenu(string id)
        {
            TS_FUNCTIONDTO fcDto = new TS_FUNCTIONDTO();
            fcDto.MenuID = id;
            fcDto.MenuFuncs = basicsService.GetMenuFuncs();
            fcDto.ButtonFuncs = basicsService.GetButtonFuncs();
            fcDto.FunID = basicsService.GetMenuFun(id);
            return View(fcDto);
        }

        /// <summary>
        /// 菜单关联权限
        /// </summary>
        /// <returns></returns>
        public string RelationMenuFunc(string menuID, string funcID)
        {
            string result = basicsService.RelationMenuFunc(menuID, funcID);
            return result;
        }


    }
}