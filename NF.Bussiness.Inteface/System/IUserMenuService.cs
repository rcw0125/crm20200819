using NF.EF.Model;
using NF.Framework;
using NF.Framework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NF.Bussiness.Interface
{
    public interface IUserMenuService : IBaseService
    {
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="account">登录名</param>
        /// <returns></returns>
        TS_USER UserLogin(string account);

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="account"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        TS_USER UserLogin(string account, string id);

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user">用户实体</param>
        void UserRegister(TS_USER user);

        /// <summary>
        /// 用户添加
        /// </summary>
        /// <param name="user"></param>
        void UserInsert(TS_USER user);

        /// <summary>
        /// 用户修改
        /// </summary>
        /// <param name="user">用户实体</param>
        void UserUpdate(TS_USER user);

        /// <summary>
        /// 用户名获取用户
        /// </summary>
        /// <param name="account">登录名</param>
        /// <returns></returns>
        TS_USER GetUser(string account);

        /// <summary>
        /// 用ID获取登录名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TS_USERDTO Get(string id);

        /// <summary>
        /// 获取用户列表（分页）
        /// </summary>
        /// <param name="uDto"></param>
        /// <returns></returns>
        PageResult<TS_USER> GetUsers(TS_USERDTO uDto);

        /// <summary>
        /// 获取用户列表（分页）
        /// </summary>
        /// <param name="uDto"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        PageResult<TS_USER> GetUsers(TS_USERDTO uDto, int type);


        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        List<TS_MENU> GetMenus(int type);

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        PageResult<TS_MENU> GetMenus(TS_MENUDTO dto);

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        List<TS_MENU> GetMenus();

        /// <summary>
        /// 菜单添加
        /// </summary>
        /// <param name="menu">菜单实体</param>
        /// <returns></returns>
        void MenuInsert(TS_MENUDTO menu);

        /// <summary>
        /// 菜单修改
        /// </summary>
        /// <param name="menu">菜单实体</param>
        /// <returns></returns>
        void MenuUpdate(TS_MENUDTO menu);

        /// <summary>
        /// 关联客户档案
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="msg">错误消息</param>
        int Relation(TS_CUSTFILEDTO dto, out string msg);

        /// <summary>
        /// 取消关联客户档案
        /// </summary>
        /// <returns></returns>
        int CancelRelation(string id);

        /// <summary>
        /// 获取用户部门信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        TS_USERDTO GetDept(TS_USERDTO dto);

        /// <summary>
        /// 部门信息操作
        /// </summary>
        /// <param name="dto"></param>
        void DeptOperation(TS_USERDTO dto);

        /// <summary>
        /// 获取菜单级别
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> GetMenuLevel();

        /// <summary>
        /// 根据菜单等级获取菜单信息
        /// </summary>
        /// <param name="level">菜单等级</param>
        /// <returns></returns>
        List<SelectListItem> GetMenu(int level);

        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TS_MENUDTO GetMenu(string id);

    }
}
