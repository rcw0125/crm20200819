using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NF.EF.Model;
using NF.Bussiness.Interface;
using System.Data.Entity;

namespace NF.Bussiness.Service
{
    public class MenuButtonService : BaseService, IMenuButtonService
    {
        private DbSet<TS_BUTTON> _ButtonMenu;
        private DbSet<TS_MENU> _MenuButton;

        public MenuButtonService(DbContext context) : base(context)
        {
            _ButtonMenu = context.Set<TS_BUTTON>();
            _MenuButton = context.Set<TS_MENU>();
        }


        /// <summary>
        /// 通过菜单URL获取菜单下所有按钮
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public IQueryable<TS_BUTTON> GetButtons(string url)
        {
            var query = from menu in _MenuButton
                        join button in _ButtonMenu on menu.C_ID equals button.C_MENU_ID
                        where menu.C_URL.Equals(url) & button.N_STATUS == 1
                        orderby button.N_INDEX
                        select button;
            return query;
        }
    }
}
