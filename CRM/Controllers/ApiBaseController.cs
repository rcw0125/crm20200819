using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Web.Http;
using CRM.Auth;
using NF.BLL;
using NF.MODEL;
using System.Data;

using Microsoft.Practices.Unity;
using NF.Framework;
using NF.EF.Model;
using NF.Framework.DTO;
using NF.Bussiness.Interface;
using NF.Web.Core;

namespace CRM.Controllers
{

    [RequestAuthorizeAttribute]
    public class ApiBaseController : ApiController
    {
        protected string Token => Request.Headers.Authorization.Scheme;

        IApiService service = DIFactory.GetContainer().Resolve<IApiService>();
        IBasicsDataService basicsService = DIFactory.GetContainer().Resolve<IBasicsDataService>();

        protected CurrentUser BaseUser
        {
            get
            {
                var user = service.CheckToken(Token);
                CurrentUser currentUser = new CurrentUser()
                {
                    Id = user.C_ID,
                    Name = user.C_NAME,
                    Account = user.C_ACCOUNT,
                    Email = user.C_EMAIL,
                    Password = user.C_PASSWORD,
                    LoginTime = DateTime.Now,
                    CustId = user.C_CUST_ID
                };
                //获取客户档案
                TS_CUSTFILE custFile = basicsService.GetCustFile(currentUser.CustId);
                if (custFile != null)
                {
                    currentUser.CustFile = AutoMapper.Mapper.Map<TS_CUSTFILEDTO>(custFile);
                    TS_CUSTADDR custAddr = basicsService.GetCustAddr(currentUser.CustId);
                    if (custAddr != null)
                        currentUser.CustFile.CustAddr = AutoMapper.Mapper.Map<TS_CUSTADDRDTO>(custAddr);
                }
                return currentUser;
            }
        }

        protected Mod_TS_USER GetUserID()
        {
            Bll_TS_USER ts_user = new Bll_TS_USER();
            return ts_user.GetTokenModel(Token);
        }
    }



}