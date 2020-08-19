using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using NF.EF.Model;
using NF.Framework;
using NF.Framework.DTO;
using System.Web.Mvc;

namespace NF.Bussiness.Interface
{
    public partial interface IBasicsDataService : IBaseService
    {
        /// <summary>
        ///  获取完成完工差列表
        /// </summary>
        /// <param name="cdDto">完成完工差实体DTO</param>
        /// <returns></returns>
        PageResult<TMB_COMDIFF> GetComDiffs(TMB_COMDIFFDTO cdDto);

        /// <summary>
        /// 获取完成完工差列表
        /// </summary>
        /// <returns></returns>
        List<TMB_COMDIFF> GetComDiffs();

        /// <summary>
        /// 合同工差新增
        /// </summary>
        /// <param name="cdDto">完成完工差实体DTO</param>
        void ComDiffInsert(TMB_COMDIFFDTO cdDto);

        /// <summary>
        /// 合同工差修改
        /// </summary>
        /// <param name="cdDto">完成完工差实体DTO</param>
        void ComDiffUpdate(TMB_COMDIFFDTO cdDto);

        /// <summary>
        /// 合同工差删除
        /// </summary>
        /// <param name="ids">工差ID</param>
        /// <param name="user">当前登录用户</param>
        void ComDiffDel(string ids, CurrentUser user);

        /// <summary>
        /// 验证合同工差是否重复
        /// </summary>
        /// <param name="cdDto">完成完工差实体DTO</param>
        /// <returns></returns>
        bool ValidateIsRepeat(TMB_COMDIFFDTO cdDto);

        /// <summary>
        /// 验证合同工差是否重复
        /// </summary>
        /// <param name="cdDto">完成完工差实体DTO</param>
        /// <param name="type">操作方式1修改 0新增</param>
        /// <returns></returns>
        bool ValidateIsRepeat(TMB_COMDIFFDTO cdDto, int type);

        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <param name="dicDto">数据字典实体DTO</param>
        /// <returns></returns>
        PageResult<TS_DIC> GetDics(TS_DICDTO dicDto);

        /// <summary>
        /// 数据字典新增
        /// </summary>
        /// <param name="dicDto">数据字典实体DTO</param>
        void DicInsert(TS_DICDTO dicDto);

        /// <summary>
        /// 数据字典修改
        /// </summary>
        /// <param name="dicDto">数据字典实体DTO</param>
        void DicUpdate(TS_DICDTO dicDto);


        /// <summary>
        /// 数据字典删除
        /// </summary>
        /// <param name="ids">数据字典ID</param>
        /// <param name="user">当前登录用户</param>
        void DicDel(string ids, CurrentUser user);

        /// <summary>
        /// 验证合同工差是否重复
        /// </summary>
        /// <param name="dicDto">数据字典实体DTO</param>
        /// <returns></returns>
        bool ValidateIsRepeat(TS_DICDTO dicDto);

        /// <summary>
        /// 验证合同工差是否重复
        /// </summary>
        /// <param name="dicDto">数据字典实体DTO</param>
        /// <param name="type">操作方式1修改 0新增</param>
        /// <returns></returns>
        bool ValidateIsRepeat(TS_DICDTO dicDto, int type);

        /// <summary>
        /// 部门列表
        /// </summary>
        /// <param name="dDto">数据字典实体DTO</param>
        /// <returns></returns>
        PageResult<TS_DEPT> GetDepts(TS_DEPTDTO dDto);

        /// <summary>
        /// 客户档案列表
        /// </summary>
        /// <param name="cfDto">客户档案实体DTO</param>
        /// <returns></returns>
        PageResult<TS_CUSTFILE> GetCustFiles(TS_CUSTFILEDTO cfDto);

        /// <summary>
        /// 修改客户档案
        /// </summary>
        /// <param name="cfDto">客户档案实体DTO</param>
        void CustFileUpdate(TS_CUSTFILEDTO cfDto);

        /// <summary>
        /// 获取客户档案收货地址
        /// </summary>
        /// <param name="id">客户档案ID</param>
        /// <returns></returns>
        List<TS_CUSTADDR> GetCustAddrs(string id);

        /// <summary>
        /// 获取客户档案开票单位
        /// </summary>
        /// <param name="id">客户档案ID</param>
        /// <returns></returns>
        List<TS_CUSTOTCOMPANY> GetCustTots(string id);

        /// <summary>
        /// 获取客户档案
        /// </summary>
        /// <param name="id">客户档案ID</param>
        /// <returns></returns>
        TS_CUSTFILE GetCustFile(string id);

        /// <summary>
        /// 获取客户档案收货地址
        /// </summary>
        /// <param name="id">客户档案ID</param>
        /// <returns></returns>
        TS_CUSTADDR GetCustAddr(string id);

        /// <summary>
        /// 用户使用报告添加
        /// </summary>
        /// <param name="crDto"></param>
        void CustReportInsert(TMC_CUST_REPORTDTO crDto);

        /// <summary>
        /// 用户使用报告列表
        /// </summary>
        /// <returns></returns>
        PageResult<TMC_CUST_REPORT> GetCustReports(TMC_CUST_REPORTDTO crDto);

        /// <summary>
        /// 用户使用报告
        /// </summary>
        /// <param name="id">用户使用报告ID</param>
        /// <returns></returns>
        TMC_CUST_REPORTDTO GetCustReport(string id);

        /// <summary>
        /// 获取评价项目
        /// </summary>
        /// <returns></returns>
        List<TMC_EVAL_ITEMDTO> GetEvalItems(string type = "1");

        /// <summary>
        /// 满意度调查新增
        /// </summary>
        /// <param name="ceDto"></param>
        void CustEvalInsert(TMC_CUST_EVALDTO ceDto);

        /// <summary>
        /// 获取钢种大类
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> GetStdMain();


        /// <summary>
        /// 满意度调查列表
        /// </summary>
        /// <returns></returns>
        PageResult<TMC_CUST_EVAL> GetCustEvals(TMC_CUST_EVALDTO ceDto);

        /// <summary>
        /// 满意度调查
        /// </summary>
        /// <param name="id">满意度调查id</param>
        /// <returns></returns>
        TMC_CUST_EVALDTO GetCustEval(string id);

        /// <summary>
        /// 保存客户档案地址
        /// </summary>
        /// <param name="dto">客户档案地址实体DTO</param>
        void SaveCustAddr(TS_CUSTFILEDTO dto);

        /// <summary>
        ///  保存客户开票单位
        /// </summary>
        /// <param name="dto">开票单位实体DTO</param>
        void SaveCustTot(TS_CUSTFILEDTO dto);

        /// <summary>
        /// 权限列表
        /// </summary>
        /// <param name="fcDto">权限实体DTO</param>
        /// <returns></returns>
        PageResult<TS_FUNCTION> GetFunctions(TS_FUNCTIONDTO fcDto);

        /// <summary>
        /// 权限添加
        /// </summary>
        /// <param name="fcDto">权限实体DTO</param>
        void FunctionInsert(TS_FUNCTIONDTO fcDto);

        /// <summary>
        /// 验证权限是否重复
        /// </summary>
        /// <param name="fcDto">权限实体DTO</param>
        /// <param name="type">1修改 0新增</param>
        /// <returns></returns>
        bool ValidateIsRepeat(TS_FUNCTIONDTO fcDto, int type);

        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <param name="id">权限ID</param>
        /// <returns></returns>
        TS_FUNCTIONDTO GetFunction(string id);

        /// <summary>
        /// 修改权限信息
        /// </summary>
        /// <param name="fcDto">权限实体DTO</param>
        void FunctionUpdate(TS_FUNCTIONDTO fcDto);

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="rDto">角色实体DTO</param>
        /// <returns></returns>
        PageResult<TS_ROLE> GetRoles(TS_ROLEDTO rDto);

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <returns></returns>
        List<TS_ROLEDTO> GetRoles();

        /// <summary>
        /// 角色新增
        /// </summary>
        /// <param name="rDto">角色实体DTO</param>
        void RoleInsert(TS_ROLEDTO rDto);

        /// <summary>
        /// 验证角色是否重复
        /// </summary>
        /// <param name="fcDto">角色实体DTO</param>
        /// <param name="type">1修改 0新增</param>
        /// <returns></returns>
        bool ValidateIsRepeat(TS_ROLEDTO fcDto, int type);

        /// <summary>
        ///获取角色信息
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <returns></returns>
        TS_ROLEDTO GetRole(string id);

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="fcDto">角色信息DTO</param>
        void RoleUpdate(TS_ROLEDTO fcDto);

        /// <summary>
        /// 获取菜单权限列表
        /// </summary>
        /// <returns></returns>
        List<TS_FUNCTIONDTO> GetMenuFuncs();

        /// <summary>
        /// 获取按钮权限列表
        /// </summary>
        /// <returns></returns>
        List<TS_FUNCTIONDTO> GetButtonFuncs();

        /// <summary>
        /// 关联用户权限
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="funcID">权限ID</param>
        string RelationUserFunc(string userID, string funcID);

        /// <summary>
        /// 获取所有用户权限ID
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        string GetUserFun(string userID);

        /// <summary>
        /// 用户ID获取所有菜单权限信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        List<TS_FUNCTIONDTO> GetCurrentMenuFun(string userID);

        /// <summary>
        /// 用户ID获取所有按钮权限信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        List<TS_FUNCTIONDTO> GetCurrentButtonFun(string userID);

        /// <summary>
        /// 用户ID获取所有部门信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        List<TS_DEPTDTO> GetCurrentUserDept(string userID);

        /// <summary>
        /// 用户ID获取所有角色信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        List<TS_ROLEDTO> GetCurrentUserRole(string userID);

        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns></returns>
        string GetRoleFun(string roleID);

        /// <summary>
        /// 关联角色权限
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="funcID">权限ID</param>
        /// <returns></returns>
        string RelationRoleFunc(string roleID, string funcID);

        /// <summary>
        /// 关联用户角色
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="roleID">角色ID</param>
        /// <returns></returns>
        string RelationUserRole(string userID, string roleID);

        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        string GetUserRole(string userID);

        /// <summary>
        /// 获取所有角色权限
        /// </summary>
        /// <param name="currentUser">用户</param>
        /// <returns></returns>
        CurrentUser GetRoleFun(CurrentUser currentUser);

        /// <summary>
        /// 获取区域信息
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> GetAreaMax();

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> GetRoleDropDown();

        /// <summary>
        /// 获取按钮列表
        /// </summary>
        /// <param name="bDto"></param>
        /// <returns></returns>
        PageResult<TS_BUTTON> GetButtons(TS_BUTTONDTO bDto);

        /// <summary>
        /// 按钮添加
        /// </summary>
        /// <param name="bDto"></param>
        void ButtonInsert(TS_BUTTONDTO bDto);

        /// <summary>
        /// 获取按钮权限
        /// </summary>
        /// <param name="id">按钮id</param>
        /// <returns></returns>
        string GetButtonFun(string id);

        /// <summary>
        /// 关联按钮权限
        /// </summary>
        /// <param name="buttonID">按钮id</param>
        /// <param name="funcID">权限id</param>
        /// <returns></returns>
        string RelationButtonFunc(string buttonID, string funcID);

        /// <summary>
        /// 获取按钮信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TS_BUTTONDTO GetButton(string id);

        /// <summary>
        /// 按钮修改
        /// </summary>
        /// <param name="bDto"></param>
        void ButtonUpdate(TS_BUTTONDTO bDto);

        /// <summary>
        /// 获取二级权限
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userID">登录用户id</param>
        void GetSecondFuncs(TS_FUNCTIONDTO dto, string userID);

        /// <summary>
        /// 获取所有菜单权限ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetMenuFun(string id);

        /// <summary>
        /// 关联菜单权限
        /// </summary>
        /// <param name="menuID"></param>
        /// <param name="funcID"></param>
        /// <returns></returns>
        string RelationMenuFunc(string menuID, string funcID);

    }
}
