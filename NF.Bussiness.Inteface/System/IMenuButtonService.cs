using NF.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Bussiness.Interface
{
    public interface IMenuButtonService : IBaseService
    {
        /// <summary>
        /// 通过菜单URL获取菜单下所有按钮
        /// </summary>
        /// <param name="url">菜单路径</param>
        /// <returns></returns>
        IQueryable<TS_BUTTON> GetButtons(string url);
    }
}
