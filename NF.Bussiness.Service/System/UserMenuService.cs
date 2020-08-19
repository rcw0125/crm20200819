using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using NF.EF.Model;
using NF.Bussiness.Interface;
using NF.Framework.DTO;
using NF.Framework;
using System.Linq.Expressions;
using System.Data.Common;
using System.Web.Mvc;

namespace NF.Bussiness.Service
{
    public class UserMenuService : BaseService, IUserMenuService
    {
        private DbSet<TS_USER> _UserMenu;
        private DbSet<TS_MENU> _MenuUser;
        private DbSet<TS_CUSTFILE> _CustFile;
        private DbSet<TS_DEPT> _Dept;
        private DbSet<TS_USER_DEPT> _UserDept;
        private DbSet<TS_USER_ROLE> _UserRole;
        private DbSet<TS_ROLE> _Role;


        public UserMenuService(DbContext context) : base(context)
        {
            _UserMenu = context.Set<TS_USER>();
            _MenuUser = context.Set<TS_MENU>();
            _CustFile = context.Set<TS_CUSTFILE>();
            _Dept = context.Set<TS_DEPT>();
            _UserDept = context.Set<TS_USER_DEPT>();
            _Role = context.Set<TS_ROLE>();
        }

        /// <summary>
        /// 用户名获取用户
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public TS_USER GetUser(string account)
        {
            return _UserMenu.FirstOrDefault(u => u.C_ACCOUNT.Equals(account)
              && u.N_TYPE != 3);
        }

        /// <summary>
        /// 获取用户列表（分页）
        /// </summary>
        /// <param name="uDto"></param>
        /// <returns></returns>
        public PageResult<TS_USER> GetUsers(TS_USERDTO uDto)
        {
            Expression<Func<TS_USER, bool>> where = null;
            where = where.And<TS_USER>(x => x.N_STATUS == 1);
            where = where.And<TS_USER>(x => x.N_TYPE != 3);

            if (!string.IsNullOrWhiteSpace(uDto.C_NAME))
            {
                where = where.And<TS_USER>(x => x.C_NAME.Contains(uDto.C_NAME));
            }

            if (!string.IsNullOrWhiteSpace(uDto.C_ACCOUNT))
            {
                where = where.And<TS_USER>(x => x.C_ACCOUNT.Contains(uDto.C_ACCOUNT));
            }

            if (!string.IsNullOrWhiteSpace(uDto.C_SHORTNAME))
            {
                where = where.And<TS_USER>(x => x.C_SHORTNAME.Contains(uDto.C_SHORTNAME));
            }

            Expression<Func<TS_USER, DateTime>> order = null;
            order = t => t.D_LASTLOGINTIME ?? DateTime.Now;

            return QueryPage<TS_USER, DateTime>(where, uDto.BasePage.PageSize, uDto.BasePage.PageIndex, order);
        }

        /// <summary>
        /// 获取用户列表（分页）
        /// </summary>
        /// <param name="uDto"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public PageResult<TS_USER> GetUsers(TS_USERDTO uDto, int type)
        {
            string table = "     TS_USER T ";
            string order = "T.D_MOD_DT  desc";
            string where = @"   AND  T.N_TYPE!=3   ";

            if (!string.IsNullOrWhiteSpace(uDto.RoleID))
            {
                table += "LEFT JOIN TS_USER_ROLE  UR ON T.C_ID = UR.C_USER_ID";
                where += string.Format("  AND  UR.C_ROLE_ID='{0}' ", uDto.RoleID);
            }

            if (!string.IsNullOrWhiteSpace(uDto.C_NAME))
            {
                uDto.C_NAME = uDto.C_NAME.Trim();
                where += string.Format("  AND  ( T.C_NAME like '%{0}%'   or  T.C_ACCOUNT like '%{1}%'  )", uDto.C_NAME, uDto.C_NAME);
            }

            if (uDto.N_STATUS != 0)
            {
                where += "  AND  T.N_STATUS=" + uDto.N_STATUS;
            }

            if (!string.IsNullOrWhiteSpace(uDto.C_SHORTNAME))
            {
                where += string.Format("  AND  T.C_SHORTNAME like '%{0}%' ", uDto.C_SHORTNAME);
            }

            if (uDto.N_TYPE != 0)
            {
                where += "  AND  T.N_TYPE=" + uDto.N_TYPE;
            }

            if (!string.IsNullOrWhiteSpace(uDto.C_ACCOUNT))
            {
                where += string.Format("  AND  T.C_ACCOUNT='{0}' ", uDto.C_ACCOUNT);
            }

            //总条数
            int count = 0;
            //数据集合
            var users = GenerateByPageSql<TS_USER>(uDto.BasePage.PageSize, uDto.BasePage.PageIndex, "t.* ", table, order, where, out count).ToList();
            //转换为分页数据
            PageResult<TS_USER> result = new PageResult<TS_USER>()
            {
                DataList = users,
                PageIndex = uDto.BasePage.PageIndex,
                PageSize = uDto.BasePage.PageSize,
                TotalCount = count
            };
            //计算页数
            BaseService.CalculatePage<TS_USER>(result.PageSize, result);

            return result;
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <param name="type">1crm 2app</param>
        /// <returns></returns>
        public List<TS_MENU> GetMenus(int type)
        {
            return _MenuUser.Where(x => x.N_STATUS == 1
            && x.N_TYPE == type).OrderBy(x => x.N_ORDER).ToList();
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <param name="dto">菜单实体DTO</param>
        /// <returns></returns>
        public PageResult<TS_MENU> GetMenus(TS_MENUDTO dto)
        {
            Expression<Func<TS_MENU, bool>> where = null;
            where = where.And<TS_MENU>(x => x.N_STATUS == 1);
            // where = where.And<TS_MENU>(x => x.N_TYPE == 1);

            if (!string.IsNullOrWhiteSpace(dto.C_NAME))
            {
                dto.C_NAME = dto.C_NAME.Trim();
                where = where.And<TS_MENU>(x => x.C_NAME.Contains(dto.C_NAME));
            }

            Expression<Func<TS_MENU, int>> order = null;
            order = t => t.N_SORT ?? 1;

            return QueryPage<TS_MENU, int>(where, dto.BasePage.PageSize, dto.BasePage.PageIndex, order);
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        public List<TS_MENU> GetMenus()
        {
            return _MenuUser
                .Where(x => x.N_STATUS == 1
                && x.N_TYPE == 1
                && x.N_MENULEVEL == 2
                )
               .OrderBy(x => x.N_SORT).ToList();
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        public List<TS_MENU> GetMenus(TS_MENUDTO dto, int type)
        {
            return _MenuUser
                .Where(x => x.N_STATUS == 1
                && x.N_TYPE == 1
                && x.N_MENULEVEL == 2
                )
               .OrderBy(x => x.N_SORT).ToList();

        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menu"></param>
        public void MenuInsert(TS_MENUDTO menu)
        {
            var ef = AutoMapper.Mapper.Map<TS_MENU>(menu);
            if (ef != null)
                Insert(ef);
        }

        /// <summary>
        /// 菜单修改
        /// </summary>
        /// <param name="menu"></param>
        public void MenuUpdate(TS_MENUDTO menu)
        {
            var ef = AutoMapper.Mapper.Map<TS_MENU>(menu);
            if (ef != null)
                Update(ef);
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
        /// 用户登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public TS_USER UserLogin(string account, string id)
        {
            return _UserMenu.FirstOrDefault(
                u => u.C_ACCOUNT.Equals(account)
                && u.C_ID != id
                && u.N_TYPE != 3
            );
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        public void UserRegister(TS_USER user)
        {
            //生产token
            user.C_TOKEN_ID = Guid.NewGuid().ToString("N");
            //关联客户档案
            if (!string.IsNullOrWhiteSpace(user.C_SHORTNAME))
            {
                var custEf = _CustFile.FirstOrDefault(x => x.C_NAME == (user.C_SHORTNAME));
                if (custEf != null)
                    user.C_CUST_ID = custEf.C_ID;
            }
            var userEf = Insert(user);
            if (userEf != null)
            {
                var role = _Role.FirstOrDefault(x => x.C_NAME.Equals("客户"));
                TS_USER_ROLE userRole = new TS_USER_ROLE();
                userRole.C_USER_ID = user.C_ID;
                userRole.C_ROLE_ID = role.C_ID;
                this.Insert(userRole);
            }
        }

        /// <summary>
        /// 用户修改
        /// </summary>
        /// <param name="user"></param>
        public void UserUpdate(TS_USER user)
        {
            Update(user);
        }

        /// <summary>
        /// 用ID获取登录名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TS_USERDTO Get(string id)
        {
            TS_USER user = _UserMenu.FirstOrDefault(u => u.C_ID.Equals(id));
            TS_USERDTO dto = AutoMapper.Mapper.Map<TS_USERDTO>(user);
            List<TS_USER_DEPT> list = _UserDept.Where(x => x.C_USER_ID.Equals(user.C_ACCOUNT)).ToList();
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    string deptid = list[i].C_DEPT_ID;
                    if (i == list.Count - 1)
                    {
                        dto.DeptID += deptid;
                        dto.DeptName += _Dept.FirstOrDefault(x => x.C_ID == deptid).C_NAME;
                    }
                    else
                    {
                        dto.DeptID += list[i].C_DEPT_ID + ",";
                        dto.DeptName += _Dept.FirstOrDefault(x => x.C_ID == deptid).C_NAME + ",";
                    }
                }
            }
            return dto;
        }

        /// <summary>
        /// 关联客户档案
        /// </summary>
        /// <param name="dto"></param>
        public int Relation(TS_CUSTFILEDTO dto, out string msg)
        {
            int result = 0;
            try
            {
                TS_USER user = _UserMenu.First(x => x.C_ID.Equals(dto.C_EXTEND1));
                var ef = _CustFile.FirstOrDefault(x => x.C_ID.Equals(dto.C_EXTEND2));
                if (ef != null && ef.C_NAME == user.C_SHORTNAME)
                {
                    user.C_CUST_ID = dto.C_EXTEND2;
                    UserUpdate(user);
                    result = 1;
                    msg = "关联成功！";
                }
                else
                    msg = "客户档案名称与公司名不一致！";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return 0;
            }
            return result;
        }

        /// <summary>
        /// 取消关联客户档案
        /// </summary>
        /// <returns></returns>
        public int CancelRelation(string id)
        {
            TS_USER user = _UserMenu.First(x => x.C_ID.Equals(id));
            user.C_CUST_ID = null;
            UserUpdate(user);
            return 0;
        }

        /// <summary>
        /// 获取用户部门信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public TS_USERDTO GetDept(TS_USERDTO dto)
        {
            if (dto.Users.Count > 0)
            {
                foreach (var user in dto.Users)
                {
                    List<TS_USER_DEPT> list = _UserDept.Where(x => x.C_USER_ID.Equals(user.C_ACCOUNT)).ToList();
                    if (list.Count > 0)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            string deptid = list[i].C_DEPT_ID;
                            if (i == list.Count - 1)
                            {
                                user.DeptID += deptid;
                                user.DeptName += _Dept.FirstOrDefault(x => x.C_ID == deptid).C_NAME;
                            }
                            else
                            {
                                user.DeptID += list[i].C_DEPT_ID + ",";
                                user.DeptName += _Dept.FirstOrDefault(x => x.C_ID == deptid).C_NAME + ",";
                            }
                        }
                    }
                }
            }
            return dto;
        }

        /// <summary>
        /// 部门信息操作
        /// </summary>
        public void DeptOperation(TS_USERDTO dto)
        {
            TS_USER user = _UserMenu.FirstOrDefault(x => x.C_ACCOUNT.Equals(dto.C_ACCOUNT));
            if (user != null && user.C_ID != null)
            {
                List<TS_USER_DEPT> list = _UserDept.Where(x => x.C_USER_ID.Equals(user.C_ACCOUNT)).ToList();
                this.Delete<TS_USER_DEPT>(list);
                if (dto.DeptID != null)
                {
                    string[] arr = dto.DeptID.Split(',');
                    foreach (var item in arr)
                    {
                        TS_USER_DEPT userDept = new TS_USER_DEPT();
                        userDept.C_USER_ID = user.C_ACCOUNT;
                        userDept.C_DEPT_ID = item;
                        this.Insert(userDept);
                    }
                }
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        public void UserInsert(TS_USER user)
        {
            user.C_TOKEN_ID = Guid.NewGuid().ToString();
            //关联客户档案
            if (!string.IsNullOrWhiteSpace(user.C_SHORTNAME))
            {
                var custEf = _CustFile.FirstOrDefault(x => x.C_NAME == (user.C_SHORTNAME));
                if (custEf != null)
                    user.C_CUST_ID = custEf.C_ID;
            }
            var userEf = Insert(user);
        }

        /// <summary>
        /// 获取菜单等级
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetMenuLevel()
        {
            string sql = @"SELECT  DISTINCT  T.N_MENULEVEL FROM TS_MENU T";
            var result = this.ExcuteQuery<Level>(sql).ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            if (result != null && result.Count() > 0)
            {
                foreach (var r in result)
                {
                    SelectListItem item = new SelectListItem()
                    {
                        Text = r.n_menulevel.ToString(),
                        Value = r.n_menulevel.ToString()
                    };
                    items.Add(item);
                }
            }
            return items;
        }

        /// <summary>
        /// 根据菜单等级获取菜单信息
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetMenu(int level)
        {
            string sql = @"SELECT    T.C_ID,T.C_NAME FROM TS_MENU T   WHERE T.N_MENULEVEL=" + level + " and T.N_STATUS = 1";
            var result = this.ExcuteQuery<Level>(sql).ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            if (result != null && result.Count() > 0)
            {
                foreach (var r in result)
                {
                    SelectListItem item = new SelectListItem()
                    {
                        Text = r.C_NAME.ToString(),
                        Value = r.C_ID.ToString()
                    };
                    items.Add(item);
                }
            }
            return items;
        }

        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TS_MENUDTO GetMenu(string id)
        {
            var ef = _MenuUser.FirstOrDefault(x => x.C_ID.Equals(id));
            TS_MENUDTO dto = new TS_MENUDTO();
            if (ef != null)
                dto = AutoMapper.Mapper.Map<TS_MENUDTO>(ef);
            return dto;
        }

    }


    public class Level
    {
        public int n_menulevel { get; set; }
        public string C_ID { get; set; }
        public string C_NAME { get; set; }

    }

}
