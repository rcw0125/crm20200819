using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Web.Core
{
    public static class ExtensionList
    {
        /// <summary>
        /// 从列表中检查当前值是否存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ExistsOrDefault<T>(this IList<T> items, Func<T, bool> predicate)
        {
            bool bol = false;
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    bol = true;
                    break;
                }
            }
            return bol;
        }
    }
}
