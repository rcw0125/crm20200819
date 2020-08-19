using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NF.Bussiness.Interface;
using NF.EF.Model;
using NF.Framework.DTO;
using NF.Framework;
using System.Linq.Expressions;

namespace NF.Bussiness.Service
{
    public class ApiService : BaseService, IApiService
    {
        private DbSet<TS_USER> _UserMenu;
        private DbSet<TS_MENU> _MenuUser;
        private DbSet<TMB_AREAPLAN> _AreaPlan;
        private DbSet<TS_CUSTFILE> _CustFile;
        private DbSet<TS_CUSTADDR> _CustAddr;
        private DbSet<TMC_CUST_REPORT> _CustReport;
        private DbSet<TMC_EVAL_ITEM> _EvalItem;
        private DbSet<TMC_CUST_EVAL> _CustEval;
        private DbSet<TMC_CUST_EVAL_SUB> _CustEvalSub;
        private DbSet<TS_CUSTOTCOMPANY> _CustTot;
        private DbSet<TS_FUNCTION> _Func;
        private DbSet<TS_ROLE> _Role;
        private DbSet<TS_USER_FUN> _UserFunc;
        private DbSet<TS_DEPT> _Dept;
        private DbSet<TS_USER_DEPT> _UserDept;
        private DbSet<TS_USER_ROLE> _UserRole;
        private DbSet<TS_MENU_FUN> _MenuFun;
        private DbSet<TS_BUTTON_FUN> _ButtonFun;
        private DbSet<TS_ROLE_FUN> _RoleFun;
        private DbSet<TMQ_QUALITY_MAIN> _QualityMain;

        public ApiService(DbContext context) : base(context)
        {
            _UserMenu = context.Set<TS_USER>();
            _MenuUser = context.Set<TS_MENU>();
            _AreaPlan = context.Set<TMB_AREAPLAN>();
            _CustFile = context.Set<TS_CUSTFILE>();
            _CustAddr = context.Set<TS_CUSTADDR>();
            _CustReport = context.Set<TMC_CUST_REPORT>();
            _EvalItem = context.Set<TMC_EVAL_ITEM>();
            _CustEval = context.Set<TMC_CUST_EVAL>();
            _CustEvalSub = context.Set<TMC_CUST_EVAL_SUB>();
            _CustTot = context.Set<TS_CUSTOTCOMPANY>();
            _Func = context.Set<TS_FUNCTION>();
            _Role = context.Set<TS_ROLE>();
            _UserFunc = context.Set<TS_USER_FUN>();
            _Dept = context.Set<TS_DEPT>();
            _UserDept = context.Set<TS_USER_DEPT>();
            _UserRole = context.Set<TS_USER_ROLE>();
            _MenuFun = context.Set<TS_MENU_FUN>();
            _ButtonFun = context.Set<TS_BUTTON_FUN>();
            _RoleFun = context.Set<TS_ROLE_FUN>();
            _QualityMain = context.Set<TMQ_QUALITY_MAIN>();
        }

        /// <summary>
        /// 验证API Token
        /// </summary>
        /// <param name="tokenID"></param>
        /// <returns></returns>
        public TS_USER CheckToken(string tokenID)
        {
            return _UserMenu.FirstOrDefault(u => u.C_TOKEN_ID.Equals(tokenID));
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public TS_USER UserLogin(string account)
        {
            TS_USER user = _UserMenu.FirstOrDefault(
                u => u.C_ACCOUNT.Equals(account)
                && u.N_TYPE != 3
            );

            if (user != null && !string.IsNullOrWhiteSpace(user.C_ID))
            {
                user.D_LASTLOGINTIME = DateTime.Now;
                Update(user);
            }
            return user;
        }

        /// <summary>
        /// 获取全部菜单
        /// </summary>
        /// <returns></returns>
        public List<TS_MENU> GetMenus(int type)
        {
            return _MenuUser.Where(x => x.N_STATUS == 1
            && x.N_TYPE == type).ToList().OrderBy(x => x.N_SORT).ToList();
        }

        /// <summary>
        /// 获取客户档案
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TS_CUSTFILE GetCustFile(string id)
        {
            return _CustFile.Where(x => x.C_ID.Equals(id)).FirstOrDefault();
        }

        /// <summary>
        /// 获取客户档案收货地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TS_CUSTADDR GetCustAddr(string id)
        {
            return _CustAddr.Where(x => x.C_ID.Equals(id) && x.N_ISDEFAULT == 0).FirstOrDefault();
        }

        /// <summary>
        /// 用户ID获取所有菜单权限信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<TS_FUNCTIONDTO> GetCurrentMenuFun(string userID)
        {
            var data = from userFun in _UserFunc
                       join fun in _Func on userFun.C_FUN_ID equals fun.C_ID
                       join menu in _MenuFun on fun.C_ID equals menu.C_FUN_ID
                       where userFun.C_USER_ID.Equals(userID) & fun.C_TYPE == 1
                       select new TS_FUNCTIONDTO
                       {
                           C_ID = fun.C_ID,
                           C_CODE = fun.C_CODE,
                           C_CONTROLLERCODE = fun.C_CONTROLLERCODE,
                           C_ACTIONCODE = fun.C_ACTIONCODE,
                           C_TYPE = fun.C_TYPE,
                           C_DESC = fun.C_DESC,
                           N_STATUS = fun.N_STATUS,
                           C_NAME = fun.C_NAME,
                           C_EMP_ID = fun.C_EMP_ID,
                           C_EMP_NAME = fun.C_EMP_NAME,
                           D_MOD_DT = fun.D_MOD_DT,
                           MenuID = menu.C_MENU_ID
                       };
            List<TS_FUNCTIONDTO> list = data.ToList();
            return list;
        }


        /// <summary>
        /// 用户ID获取所有按钮权限信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<TS_FUNCTIONDTO> GetCurrentButtonFun(string userID)
        {
            var data = from userFun in _UserFunc
                       join fun in _Func on userFun.C_FUN_ID equals fun.C_ID
                       join button in _ButtonFun on fun.C_ID equals button.C_FUN_ID
                       where userFun.C_USER_ID.Equals(userID) & fun.C_TYPE == 2
                       select new TS_FUNCTIONDTO
                       {
                           C_ID = fun.C_ID,
                           C_CODE = fun.C_CODE,
                           C_CONTROLLERCODE = fun.C_CONTROLLERCODE,
                           C_ACTIONCODE = fun.C_ACTIONCODE,
                           C_TYPE = fun.C_TYPE,
                           C_DESC = fun.C_DESC,
                           N_STATUS = fun.N_STATUS,
                           C_NAME = fun.C_NAME,
                           C_EMP_ID = fun.C_EMP_ID,
                           C_EMP_NAME = fun.C_EMP_NAME,
                           D_MOD_DT = fun.D_MOD_DT,
                           ButtonID = button.C_BUTTON_ID
                       };
            List<TS_FUNCTIONDTO> list = data.ToList();
            return list;
        }


        /// <summary>
        /// 用户ID获取所有部门信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<TS_DEPTDTO> GetCurrentUserDept(string userID)
        {
            var data = from userDept in _UserDept
                       join dept in _Dept on userDept.C_DEPT_ID equals dept.C_ID
                       where userDept.C_USER_ID.Equals(userID)
                       select new TS_DEPTDTO
                       {
                           C_ID = dept.C_ID,
                           C_PARENT_ID = dept.C_PARENT_ID,
                           C_CODE = dept.C_CODE,
                           C_NAME = dept.C_NAME,
                           C_DESC = dept.C_DESC,
                           N_STATUS = dept.N_STATUS,
                           C_DEPTH = dept.C_DEPTH,
                           N_DEPTATTR = dept.N_DEPTATTR,
                           C_EMP_ID = dept.C_EMP_ID,
                           C_EMP_NAME = dept.C_EMP_NAME,
                           D_MOD_DT = dept.D_MOD_DT
                       };
            return data.ToList();
        }

        /// <summary>
        /// 用户ID获取所有角色信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<TS_ROLEDTO> GetCurrentUserRole(string userID)
        {
            var data = from userRole in _UserRole
                       join role in _Role on userRole.C_ROLE_ID equals role.C_ID
                       where userRole.C_USER_ID.Equals(userID)
                       select new TS_ROLEDTO
                       {
                           C_ID = role.C_ID,
                           C_CODE = role.C_CODE,
                           C_DESC = role.C_DESC,
                           C_NAME = role.C_NAME,
                           N_STATUS = role.N_STATUS,
                           C_EMP_ID = role.C_EMP_ID,
                           C_EMP_NAME = role.C_EMP_NAME,
                           D_MOD_DT = role.D_MOD_DT,
                       };
            return data.ToList();
        }

        /// <summary>
        /// 获取所有角色权限
        /// </summary>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public CurrentUser GetRoleFun(CurrentUser currentUser)
        {

            if (currentUser.Roles != null && currentUser.Roles.Count > 0)
            {
                string sql = @"    SELECT  tf.*,mf.c_menu_id  MenuID  FROM  ts_role_fun rf
                                        JOIN ts_function tf ON tf.c_id=rf.c_fun_id
                                        JOIN ts_menu_fun mf ON mf.c_fun_id=tf.c_id
                                        WHERE    ";

                for (int i = 0; i < currentUser.Roles.Count; i++)
                {
                    if (i == currentUser.Roles.Count - 1)
                    {
                        sql += "  rf.c_role_id =  '" + currentUser.Roles[i].C_ID + "' ";
                    }
                    else
                    {
                        sql += "  rf.c_role_id =  '" + currentUser.Roles[i].C_ID + "'  or";
                    }
                }

                sql += "   UNION   ";

                sql += @"     SELECT  tf.*,bf.c_button_id  MenuID FROM  ts_role_fun rf
                                JOIN ts_function tf ON tf.c_id=rf.c_fun_id
                                JOIN ts_button_fun bf ON bf.c_fun_id=rf.c_fun_id
                                WHERE    ";

                for (int i = 0; i < currentUser.Roles.Count; i++)
                {
                    if (i == currentUser.Roles.Count - 1)
                    {
                        sql += "  rf.c_role_id =  '" + currentUser.Roles[i].C_ID + "' ";
                    }
                    else
                    {
                        sql += "  rf.c_role_id =  '" + currentUser.Roles[i].C_ID + "'  or";
                    }
                }

                List<TS_FUNCTIONDTO> funs = this.ExcuteQuery<TS_FUNCTIONDTO>(sql).ToList();
                List<TS_FUNCTIONDTO> menuFuns = funs.Where(x => x.C_TYPE == 1).ToList();
                List<TS_FUNCTIONDTO> btnFuns = funs.Where(x => x.C_TYPE == 2).ToList();

                foreach (var menu in menuFuns)
                {
                    if (!currentUser.MenuFuncs.Exists(x => x.C_ID.Equals(menu.C_ID)))
                    {
                        currentUser.MenuFuncs.Add(menu);
                    }
                }

                foreach (var btn in btnFuns)
                {
                    if (!currentUser.ButtonFuncs.Exists(x => x.C_ID.Equals(btn.C_ID)))
                    {
                        btn.ButtonID = btn.MenuID;
                        btn.MenuID = null;
                        currentUser.ButtonFuncs.Add(btn);
                    }
                }

                return currentUser;
            }
            else
            {
                return currentUser;
            }
        }

        /// <summary>
        /// 通过角色获取所有菜单权限
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public List<TS_FUNCTIONDTO> GetRoleFun(List<TS_ROLEDTO> roles)
        {
            List<TS_FUNCTIONDTO> menuFuns = new List<TS_FUNCTIONDTO>();

            if (roles != null && roles.Count > 0)
            {
                string sql = @"    SELECT  tf.*,mf.c_menu_id  MenuID  FROM  ts_role_fun rf
                                        JOIN ts_function tf ON tf.c_id=rf.c_fun_id
                                        JOIN ts_menu_fun mf ON mf.c_fun_id=tf.c_id
                                        WHERE    ";

                for (int i = 0; i < roles.Count; i++)
                {
                    if (i == roles.Count - 1)
                    {
                        sql += "  rf.c_role_id =  '" + roles[i].C_ID + "' ";
                    }
                    else
                    {
                        sql += "  rf.c_role_id =  '" + roles[i].C_ID + "'  or";
                    }
                }

                sql += "   UNION   ";

                sql += @"     SELECT  tf.*,bf.c_button_id  MenuID FROM  ts_role_fun rf
                                JOIN ts_function tf ON tf.c_id=rf.c_fun_id
                                JOIN ts_button_fun bf ON bf.c_fun_id=rf.c_fun_id
                                WHERE    ";

                for (int i = 0; i < roles.Count; i++)
                {
                    if (i == roles.Count - 1)
                    {
                        sql += "  rf.c_role_id =  '" + roles[i].C_ID + "' ";
                    }
                    else
                    {
                        sql += "  rf.c_role_id =  '" + roles[i].C_ID + "'  or";
                    }
                }

                List<TS_FUNCTIONDTO> funs = this.ExcuteQuery<TS_FUNCTIONDTO>(sql).ToList();
                menuFuns = funs.Where(x => x.C_TYPE == 1).ToList();
                return menuFuns;
            }
            else
            {
                return menuFuns;
            }
        }

        /// <summary>
        /// 获取质量问题反馈列表（分页）
        /// </summary>
        /// <param name="qmDto"></param>
        /// <returns></returns>
        public List<AppQuality> GetQualitys(AppQuality qDto)
        {
            Expression<Func<TMQ_QUALITY_MAIN, bool>> where = null;
            where = where.And<TMQ_QUALITY_MAIN>(x => x.N_STATUS <= 0);

            if (qDto.Start != DateTime.MinValue)
            {
                DateTime startTime = Convert.ToDateTime(qDto.Start.ToString("yyyy-MM-dd"));
                where = where.And<TMQ_QUALITY_MAIN>(x => x.D_MOD_DT > startTime);
            }
            else
            {
                DateTime startTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                where = where.And<TMQ_QUALITY_MAIN>(x => x.D_MOD_DT > startTime);
            }

            if (qDto.End != DateTime.MinValue)
            {
                DateTime endTime = Convert.ToDateTime(qDto.End.AddDays(1).ToString("yyyy-MM-dd"));
                where = where.And<TMQ_QUALITY_MAIN>(x => x.D_SHIP_START_DT < endTime);
            }
            else
            {
                DateTime startTime = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
                where = where.And<TMQ_QUALITY_MAIN>(x => x.D_SHIP_START_DT > startTime);
            }

            if (qDto.N_FLAG != null)
            {
                where = where.And<TMQ_QUALITY_MAIN>(x => x.N_FLAG == qDto.N_FLAG);
            }

            if (qDto.C_CUST_NAME != null)
            {
                where = where.And<TMQ_QUALITY_MAIN>(x => x.C_CUST_NAME == qDto.C_CUST_NAME);
            }

            if (qDto.C_TEL != null)
            {
                where = where.And<TMQ_QUALITY_MAIN>(x => x.C_TEL == qDto.C_TEL);
            }

            var efs = _QualityMain.Where(where).OrderByDescending(x => x.D_MOD_DT).ToList();
            return MAPPING.ConvertEntityToDtoList<TMQ_QUALITY_MAIN, AppQuality>(efs);
        }

    }
}
