using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NF.Bussiness.Interface;
using NF.EF.Model;
using Microsoft.Practices.Unity;
using NF.Framework;
using NF.Web.Core;

namespace CRM.Controllers
{
    public class MenuController : BaseController
    {
        IUserMenuService service = DIFactory.GetContainer().Resolve<IUserMenuService>();

        // GET: Menu
     

    }
}