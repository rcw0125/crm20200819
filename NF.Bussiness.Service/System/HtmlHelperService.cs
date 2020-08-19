using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Web.Mvc;
using NF.EF.Model;
using NF.Bussiness.Interface;

namespace NF.Bussiness.Service
{
    public class HtmlHelperService : BaseService, IHtmlHelperService
    {
        private DbSet<TS_DIC> _Dic;
        private DbSet<TMD_DIS_CONDET> _DisConDet;
        private DbSet<TMO_CON> _Con;
        private DbSet<TMO_ORDER> _ConDetails;
        private DbSet<TS_USER_ROLE> _UserRole;
        private DbSet<TS_ROLE> _Role;

        public HtmlHelperService(DbContext context) : base(context)
        {
            _Dic = context.Set<TS_DIC>();
            _DisConDet = context.Set<TMD_DIS_CONDET>();
            _Con = context.Set<TMO_CON>();
            _ConDetails = context.Set<TMO_ORDER>();
            _UserRole = context.Set<TS_USER_ROLE>();
            _Role = context.Set<TS_ROLE>();
        }

        /// <summary>
        /// 通过id获取数据字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
                return _Dic.FirstOrDefault(x => x.C_ID.Equals(id)).C_DETAILNAME;
            else
                return "";
        }


        /// <summary>
        /// 根据类别code获取数据字典
        /// </summary>
        /// <param name="code"></param>
        /// <param name="area">地区</param>
        /// <returns></returns>
        public List<TS_DIC> GetDispatchArea(string code, string area)
        {
            if (!string.IsNullOrWhiteSpace(code))
            {
                List<TS_DIC> dics = _Dic.Where(x => x.C_TYPECODE.Equals(code) 
                                                                       && x.C_DETAILNAME != area)
                    .OrderBy(x => x.C_INDEX).ToList();
                return dics;
            }
            else
                return null;
        }

        /// <summary>
        /// 根据类别code获取数据字典
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<TS_DIC> GetDic(string code)
        {
            if (!string.IsNullOrWhiteSpace(code))
            {
                List<TS_DIC> dics = _Dic.Where(x => x.C_TYPECODE.Equals(code)).OrderBy(x => x.C_INDEX).ToList();
                return dics;
            }
            else
                return null;
        }

        /// <summary>
        /// 根据类别code和详情code获取名称
        /// </summary>
        /// <param name="typeCode"></param>
        /// <param name="detailCode"></param>
        /// <returns></returns>
        public string GetDic(string typeCode, string detailCode)
        {
            if (!string.IsNullOrWhiteSpace(typeCode) && !string.IsNullOrWhiteSpace(detailCode))
            {
                var ef = _Dic.Where(x => x.C_TYPECODE == typeCode
            && x.C_DETAILCODE == detailCode).FirstOrDefault();
                if (ef != null)
                    return ef.C_DETAILNAME;
                else
                    return "";
            }
            else
                return "";
        }

        /// <summary>
        /// 发运单号获取关联订单号
        /// </summary>
        /// <param name="id">发运单号</param>
        /// <returns></returns>
        public string GetDispatchNo(string id)
        {
            string result = string.Empty;
            var list = _DisConDet.Where(x => x.C_DISPATCH_ID == id).ToList();
            List<string> strs = new List<string>();
            if (list != null && list.Count > 0)
            {
                foreach (var str in list)
                {
                    strs.Add(str.C_NO);
                }
            }

            var arr = strs.Distinct().ToList();
            if (arr.Count > 0)
            {
                if (arr.Count() > 1)
                {
                    foreach (var item in arr)
                    {
                        var con = _ConDetails.FirstOrDefault(x => x.C_ORDER_NO == item);
                        result += con == null ? "" : con.C_CON_NO + ",";
                    }
                }
                else
                {
                    string item = arr[0];
                    var con = _ConDetails.FirstOrDefault(x => x.C_ORDER_NO == item);
                    result += con == null ? "" : con.C_CON_NO + ",";
                }
            }
            return result;
        }

        /// <summary>
        /// 获取角色名称
        /// </summary>
        /// <returns></returns>
        public string GetRoleName(string id)
        {
            string result = string.Empty;
            var data = from fun in _UserRole
                       join role in _Role on fun.C_ROLE_ID equals role.C_ID
                       where fun.C_USER_ID.Equals(id)
                       select role.C_NAME;
            if (data != null && data.Count() > 0)
                result = string.Join(",", data);
            return result;
        }

        /// <summary>
        /// 通过主键ID获取各个表格字段值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">主键ID</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        public string GetGenerName<T>(string id, string propertyName) where T : class
        {
            string result = "";
            if (id != null)
            {
                T instance = this.Context.Set<T>().Find(id);
                if (instance != null)
                {
                    Type type = instance.GetType();
                    object obj = Activator.CreateInstance(type);
                    obj = instance;
                    Object objValue = type.GetProperty(propertyName).GetValue(obj);
                    if (objValue != null)
                        result = objValue.ToString();
                }
            }
            return result;
        }

    }
}
