using NF.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace NF.Bussiness.Interface
{
    public interface IBaseService : IDisposable
    {/// <summary>
     /// 根据id查询实体
     /// </summary>
     /// <param name="id"></param>
     /// <returns></returns>
        T Find<T>(string id) where T : class;

        /// <summary>
        /// 提供对单表的查询，
        /// </summary>
        /// <returns>IQueryable类型集合</returns>
        IQueryable<T> Set<T>() where T : class;

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <returns></returns>
        IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class;

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="funcWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="funcOrderby"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOrderby, bool isAsc = true) where T : class;

        /// <summary>
        /// 新增数据，即时Commit
        /// </summary>
        /// <param name="t"></param>
        /// <returns>返回带主键的实体</returns>
        T Insert<T>(T t) where T : class;

        /// <summary>
        ///  新增数据，即时Commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        /// <returns></returns>
        IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class;

        /// <summary>
        /// 更新数据，即时Commit
        /// </summary>
        /// <param name="t"></param>
        void Update<T>(T t) where T : class;

        /// <summary>
        /// 更新数据，即时Commit
        /// </summary>
        /// <param name="tList"></param>
        void Update<T>(IEnumerable<T> tList) where T : class;

        /// <summary>
        /// 根据主键删除数据，即时Commit
        /// </summary>
        /// <param name="t"></param>
        void Delete<T>(string Id) where T : class;

        /// <summary>
        /// 删除数据，即时Commit
        /// </summary>
        /// <param name="t"></param>
        void Delete<T>(T t) where T : class;

        /// <summary>
        /// 删除数据，即时Commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        void Delete<T>(IEnumerable<T> tList) where T : class;

        /// <summary>
        /// 立即保存全部修改
        /// </summary>
        void Commit();

        /// <summary>
        /// 执行sql反回集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<T> ExcuteQuery<T>(string sql, SqlParameter[] parameters) where T : class;

        /// <summary>
        /// 执行sql反回集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<T> ExcuteQuery<T>(string sql) where T : class;

        /// <summary>
        /// 执行sql
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        int Excute<T>(string sql, SqlParameter[] parameters) where T : class;

        /// <summary>
        /// 执行sql
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        int Excute<T>(string sql) where T : class;

        /// <summary>
        /// 生成合同号
        /// </summary>
        /// <param name="area">1北方 2南方 3海外</param>
        /// <returns></returns>
        string CreateConNo(string area);

        /// <summary>
        /// 生成日计划单据号
        /// </summary>
        /// <returns></returns>
        string CreatePlanID();

        /// <summary>
        /// 生成发运单号
        /// </summary>
        /// <returns></returns>
        string CreateDispID();

        /// <summary>
        /// 生成分页查询语句
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="item"></param>
        /// <param name="table"></param>
        /// <param name="order"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<T> GenerateByPageSql<T>(int pageSize, int pageIndex, string item, string table, string order, string where, out int count) where T : class;

    }
}
