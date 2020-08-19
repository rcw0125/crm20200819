using NF.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NF.Bussiness.Interface
{
    public interface IHtmlHelperService : IBaseService
    {
        /// <summary>
        /// 根据类别code获取数据字典
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        List<TS_DIC> GetDic(string code);

        /// <summary>
        /// 根据类别code获取数据字典
        /// </summary>
        /// <param name="code"></param>
        /// <param name="area">地区（清除当前选中地区）</param>
        /// <returns></returns>
        List<TS_DIC> GetDispatchArea(string code, string area);

        /// <summary>
        /// 根据类别code和详情code获取名称
        /// </summary>
        /// <param name="typeCode"></param>
        /// <param name="detailCode"></param>
        /// <returns></returns>
        string GetDic(string typeCode, string detailCode);

        /// <summary>
        /// 通过id获取数据字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string Get(string id);

        /// <summary>
        /// 发运单号获取关联订单号
        /// </summary>
        /// <param name="id">发运单号</param>
        /// <returns></returns>
        string GetDispatchNo(string id);

        /// <summary>
        /// 获取角色名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetRoleName(string id);

        /// <summary>
        ///  通过主键ID获取各个表格字段值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">主键ID</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        string GetGenerName<T>(string id, string propertyName) where T : class;

    }
}
