using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NF.EF.Model;
using NF.Framework.DTO;
using NF.Framework;

namespace NF.Bussiness.Interface
{
    public interface IApiService : IBaseService
    {
        /// <summary>
        /// 验证API Token
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        TS_USER CheckToken(string tokenID);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        TS_USER UserLogin(string account);

        /// <summary>
        /// 获取全部菜单
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        List<TS_MENU> GetMenus(int type);

        /// <summary>
        /// 获取客户档案
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TS_CUSTFILE GetCustFile(string id);

        /// <summary>
        /// 获取客户档案收货地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TS_CUSTADDR GetCustAddr(string id);

        /// <summary>
        /// 用户ID获取所有菜单权限信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        List<TS_FUNCTIONDTO> GetCurrentMenuFun(string userID);


        /// <summary>
        /// 用户ID获取所有按钮权限信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        List<TS_FUNCTIONDTO> GetCurrentButtonFun(string userID);

        /// <summary>
        /// 用户ID获取所有部门信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        List<TS_DEPTDTO> GetCurrentUserDept(string userID);


        /// <summary>
        /// 用户ID获取所有角色信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        List<TS_ROLEDTO> GetCurrentUserRole(string userID);

        /// <summary>
        /// 获取所有角色权限
        /// </summary>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        CurrentUser GetRoleFun(CurrentUser currentUser);

        /// <summary>
        /// 通过角色获取所有菜单权限
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        List<TS_FUNCTIONDTO> GetRoleFun(List<TS_ROLEDTO> roles);

        /// <summary>
        /// 获取质量异议列表
        /// </summary>
        /// <param name="qDto"></param>
        /// <returns></returns>
        List<AppQuality> GetQualitys(AppQuality qDto);


    }
}
