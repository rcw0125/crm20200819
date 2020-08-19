using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.Practices.Unity;
using NF.Bussiness.Interface;
using NF.EF.Model;
using NF.Framework;
using NF.Web.Core;

namespace CRM.Controllers
{
    public class HomeController : BaseController
    {
        [RenderFilter]
        public ActionResult Index()
        {         
            return View();
        }
    }
}