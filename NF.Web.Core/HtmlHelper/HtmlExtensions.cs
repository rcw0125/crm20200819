using NF.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Microsoft.Practices.Unity;
using NF.EF.Model;

namespace NF.Web.Core
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString DropDownDic(this HtmlHelper htmlHelper, string name, string code, string optionLabel, object htmlAttributes)
        {
            HtmlAuxiliary auxiliary = new HtmlAuxiliary();
            return htmlHelper.DropDownList(name, new SelectList(auxiliary.Dic(code), "C_DETAILCODE", "C_DETAILNAME"), optionLabel, htmlAttributes);
        }

        public static MvcHtmlString DropDownDicName(this HtmlHelper htmlHelper, string name, string code, string optionLabel, object htmlAttributes)
        {
            HtmlAuxiliary auxiliary = new HtmlAuxiliary();
            return htmlHelper.DropDownList(name, new SelectList(auxiliary.Dic(code), "C_DETAILNAME", "C_DETAILNAME"), optionLabel, htmlAttributes);
        }

        public static MvcHtmlString DropDownDic(this HtmlHelper htmlHelper, string name, string code, object htmlAttributes)
        {
            HtmlAuxiliary auxiliary = new HtmlAuxiliary();
            return htmlHelper.DropDownList(name, new SelectList(auxiliary.Dic(code), "C_DETAILCODE", "C_DETAILNAME"), null, htmlAttributes);
        }

        public static string DetailName(this HtmlHelper htmlHelper, string name, string code)
        {
            HtmlAuxiliary auxiliary = new HtmlAuxiliary();
            return auxiliary.GetDetailName(code, name);
        }

        /// <summary>
        /// 通过主键ID获取各个表格字段值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="htmlHelper">扩展Html</param>
        /// <param name="id">主键ID</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        public static string GetGenerName(this HtmlHelper htmlHelper, string id, string propertyName, string TName)
        {
            string result = "";
            HtmlAuxiliary auxiliary = new HtmlAuxiliary();
            if (!string.IsNullOrWhiteSpace(TName))
            {
                switch (TName)
                {
                    case "User":
                        result = auxiliary.GetGenerName<TS_USER>(id, propertyName);
                        break;
                    case "Dept":
                        result = auxiliary.GetGenerName<TS_DEPT>(id, propertyName);
                        break;
                    case "Menu":
                        result = auxiliary.GetGenerName<TS_MENU>(id, propertyName);
                        break;
                }
            }
            return result;
        }


        /// <summary>
        /// 发运单号获取关联订单号
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="id">发运单号</param>
        /// <returns></returns>
        public static string GetDispatchNo(this HtmlHelper htmlHelper, string id)
        {
            HtmlAuxiliary auxiliary = new HtmlAuxiliary();
            return auxiliary.GetDispatchNo(id);
        }

        /// <summary>
        /// 获取角色名称
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="id">发运单号</param>
        /// <returns></returns>
        public static string GetRoleName(this HtmlHelper htmlHelper, string id)
        {
            HtmlAuxiliary auxiliary = new HtmlAuxiliary();
            return auxiliary.GetRoleName(id);
        }

    }

    public class HtmlAuxiliary
    {
        IHtmlHelperService service = DIFactory.GetContainer().Resolve<IHtmlHelperService>();

        public List<TS_DIC> Dic(string code)
        {
            return service.GetDic(code);
        }

        public string GetDetailName(string typeCode, string detailCode)
        {
            return service.GetDic(typeCode, detailCode);
        }

        public string GetGenerName<T>(string id, string propertyName) where T : class
        {
            return service.GetGenerName<T>(id, propertyName);
        }

        public string GetDispatchNo(string id)
        {
            return service.GetDispatchNo(id);
        }

        public string GetRoleName(string id)
        {
            return service.GetRoleName(id);
        }

    }

}
