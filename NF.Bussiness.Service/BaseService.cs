using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using System.Linq.Expressions;
using System.Data.SqlClient;
using NF.Framework;
using NF.Bussiness.Interface;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Text;

namespace NF.Bussiness.Service
{
    public class BaseService : IBaseService
    {
        #region Identity
        protected DbContext Context { get; private set; }

        public BaseService(DbContext context)
        {
            this.Context = context;
        }
        #endregion Identity

        #region 新增
        public T Insert<T>(T t) where T : class
        {
            try
            {
                this.Context.Set<T>().Add(t);
                this.Commit();
                return t;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var item in tList)
            {
                this.Context.Set<T>().Add(item);
            }
            this.Commit();
            return tList;
        }
        #endregion

        #region 删除
        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            try
            {
                foreach (var item in tList)
                {
                    this.Context.Set<T>().Remove(item);
                    this.Commit();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete<T>(T t) where T : class
        {
            try
            {
                if (t == null) throw new Exception("t is null");
                this.Context.Set<T>().Remove(t);
                this.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete<T>(string Id) where T : class
        {
            try
            {
                T t = this.Find<T>(Id);
                if (t == null) throw new Exception("t is null");
                this.Context.Set<T>().Remove(t);
                this.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 修改
        /*
 public enum EntityState
{
// 摘要:
//     对象存在，但未由对象服务跟踪。在创建实体之后、但将其添加到对象上下文之前，该实体处于此状态。通过调用 System.Data.Objects.ObjectContext.Detach(System.Object)
//     方法从上下文中移除实体后，或者使用 System.Data.Objects.MergeOption.NoTrackingSystem.Data.Objects.MergeOption
//     加载实体后，该实体也会处于此状态。
Detached = 1,
//
// 摘要:
//     自对象加载到上下文中后，或自上次调用 System.Data.Objects.ObjectContext.SaveChanges() 方法后，此对象尚未经过修改。
Unchanged = 2,
//
// 摘要:
//     对象已添加到对象上下文，但尚未调用 System.Data.Objects.ObjectContext.SaveChanges() 方法。对象是通过调用
//     System.Data.Objects.ObjectContext.AddObject(System.String,System.Object)
//     方法添加到对象上下文中的。
Added = 4,
//
// 摘要:
//     使用 System.Data.Objects.ObjectContext.DeleteObject(System.Object) 方法从对象上下文中删除了对象。
Deleted = 8,
//
// 摘要:
//     对象已更改，但尚未调用 System.Data.Objects.ObjectContext.SaveChanges() 方法。
Modified = 16,
}
 */
        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            try
            {
                foreach (var t in tList)
                {
                    this.Context.Set<T>().Attach(t);
                    this.Context.Entry<T>(t).State = EntityState.Modified;
                }
                this.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update<T>(T t) where T : class
        {
            try
            {
                DetachedAllEntities();
                if (t == null) throw new Exception("t is null");
                this.Context.Set<T>().Attach(t);//将数据附加到上下文，支持实体修改和新实体，重置为UnChanged       
                this.Context.Entry<T>(t).State = EntityState.Modified;
                this.Commit();//保存 然后重置为UnChanged
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 保存
        public void Commit()
        {
            try
            {
                this.Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 查询
        public T Find<T>(string id) where T : class
        {
            try
            {
                return this.Context.Set<T>().Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 这才是合理的做法，上端给条件，这里查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <returns></returns>
        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            try
            {
                return this.Context.Set<T>().Where<T>(funcWhere);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<T> Set<T>() where T : class
        {
            try
            {
                return this.Context.Set<T>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOrderby, bool isAsc = true) where T : class
        {
            try
            {
                var list = this.Set<T>();
                if (funcWhere != null)
                {
                    list = list.Where<T>(funcWhere);
                }
                if (isAsc)
                {
                    list = list.OrderBy(funcOrderby);
                }
                else
                {
                    list = list.OrderByDescending(funcOrderby);
                }
                PageResult<T> result = new PageResult<T>()
                {
                    DataList = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    TotalCount = list.Count(),
                };

                CalculatePage(pageSize, result);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void CalculatePage<T>(int pageSize, PageResult<T> result) where T : class
        {
            #region 计算显示分页
            result.TotalPageNum = result.TotalCount % pageSize == 0 ? result.TotalCount / pageSize : result.TotalCount / pageSize + 1;
            int number = result.PageSize / 2;
            int last = number % 2;
            if (last != 0)
            {
                result.PageBegin = result.PageIndex - number;
                result.PageEnd = result.PageIndex + number;
            }
            else
            {
                result.PageBegin = result.PageIndex - number - 1;
                result.PageEnd = result.PageIndex + number;
            }
            //计算启示和结束的值 不允许负数和超出  

            //如果begin为负数 就取绝对值给end  
            if (result.PageBegin < 0)
            {
                result.PageEnd += Math.Abs(result.PageBegin);
                result.PageBegin = result.PageEnd - result.PageSize;
            }
            //如果end大于总页数 就等于总页数  
            if (result.PageEnd > result.TotalPageNum)
            {
                result.PageEnd = result.TotalPageNum;
            }

            //页码从1开始  
            result.PageBegin += 1;

            //保留第一页和最后一页  
            //result.PageBegin += 1;
            //result.PageEnd = result.PageEnd + 1 < result.TotalPageNum ? result.PageEnd + 1 : result.TotalPageNum - 1;
            #endregion
        }



        #endregion

        #region 释放资源
        public void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }
        #endregion

        #region 执行sql
        /// <summary>
        /// 执行sql反回集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IQueryable<T> ExcuteQuery<T>(string sql, SqlParameter[] parameters) where T : class
        {
            try
            {
                return this.Context.Database.SqlQuery<T>(sql, parameters).AsQueryable();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 执行sql反回集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IQueryable<T> ExcuteQuery<T>(string sql) where T : class
        {
            try
            {
                return this.Context.Database.SqlQuery<T>(sql).AsQueryable();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 执行sql
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        public int Excute<T>(string sql, SqlParameter[] parameters) where T : class
        {
            try
            {
                return this.Context.Database.ExecuteSqlCommand(sql, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Excute<T>(string sql) where T : class
        {
            try
            {
                return this.Context.Database.ExecuteSqlCommand(sql);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /**/
        /// <summary>
        /// 生成分页查询语句
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GenerateByPageSql<T>(int pageSize, int pageIndex, string item, string table, string order, string where, out int count) where T : class
        {
            try
            {
                count = 0;
                int start_row_num = (pageIndex - 1) * pageSize + 1;
                StringBuilder sb = new StringBuilder();
                if (string.IsNullOrEmpty(item))
                    item = "*";
                sb.AppendFormat(" from {0}", table);
                if (where.Length > 0)
                    sb.AppendFormat(" where 1=1 {0}", where);

                string execSql = string.Format(
                          "WITH t AS (SELECT ROW_NUMBER() OVER(ORDER BY {0}) as row_number,{1}{2}) Select * from t where row_number >= {3} and row_number<= {4}",
                          order, item, sb, start_row_num, (start_row_num + pageSize - 1));

                string execCount = string.Format(" SELECT COUNT(T.C_ID) No  {0}", sb);
                var efCount = this.ExcuteQuery<Con>(execCount).First();
                count = int.Parse(efCount.No.ToString());
                return this.ExcuteQuery<T>(execSql);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region 清除ef缓存上下文
        /// <summary>
        /// 清空DB上下文中所有缓存的实体对象
        /// </summary>
        private void DetachedAllEntities()
        {
            try
            {
                var objectContext = ((IObjectContextAdapter)this.Context).ObjectContext;
                List<ObjectStateEntry> entries = new List<ObjectStateEntry>();
                var states = new[] { EntityState.Added, EntityState.Deleted, EntityState.Modified, EntityState.Unchanged };
                foreach (var state in states)
                {
                    entries.AddRange(objectContext.ObjectStateManager.GetObjectStateEntries(state));
                }

                foreach (var item in entries)
                {
                    objectContext.Detach(item.Entity);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string CreateConNo(string area)
        {
            try
            {
                string year = DateTime.Now.Year.ToString().Substring(2);
                string conNo = "XG-XS-" + year;
                conNo += area + FillVacancy(this.ExcuteQuery<Con>(" select   SEQ_NORTHID.NEXTVAL No   from  sys.dual  ").First().No.ToString());

                return conNo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string FillVacancy(string serNum)
        {
            if (serNum.Length == 1)
                serNum = "0000" + serNum;
            else if (serNum.Length == 2)
                serNum = "000" + serNum;
            else if (serNum.Length == 3)
                serNum = "00" + serNum;
            else if (serNum.Length == 4)
                serNum = "0" + serNum;
            return serNum;
        }

        public string CreatePlanID()
        {
            try
            {
                string id = string.Empty;
                string year = DateTime.Now.Year.ToString().Substring(2);
                string month = DateTime.Now.Month.ToString();
                id += "DM" + year + month;
                id += FillVacancy(this.ExcuteQuery<Con>(" select   SEQ_PLANID.NEXTVAL No   from  sys.dual  ").First().No.ToString());
                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string CreateDispID()
        {
            try
            {
                string id = string.Empty;
                string year = DateTime.Now.Year.ToString().Substring(2);
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();
                id += "DM" + year + month + day;
                id += FillVacancy(this.ExcuteQuery<Con>("  select   SEQ_DISPID.NEXTVAL No   from  sys.dual  ").First().No.ToString());
                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

    }

    class Con
    {
        public decimal No { get; set; }
    }
}
