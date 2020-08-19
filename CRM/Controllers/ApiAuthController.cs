using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


using Newtonsoft.Json.Linq;
using NF.Bussiness.Interface;
using NF.Framework;
using NF.Web.Core;
using Microsoft.Practices.Unity;
using NF.EF.Model;
using System.Web.Http;
using NF.Framework.DTO;
using Newtonsoft.Json;
using NF.BLL;
using System.Data;

namespace CRM.Controllers
{
    public class ApiAuthController : ApiBaseController
    {
        IApiService service = DIFactory.GetContainer().Resolve<IApiService>();
        IBasicsDataService basicsService = DIFactory.GetContainer().Resolve<IBasicsDataService>();
        IQualityService qualityService = DIFactory.GetContainer().Resolve<IQualityService>();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();

        [HttpPost]
        [AllowAnonymous]
        public AjaxResult Login(JObject jData)
        {
            AjaxResult result = new AjaxResult();
            try
            {
                var cUser = jData.ToObject<CurrentUser>();
                TS_USER user = service.UserLogin(cUser.Account);

                string pw = cUser.Password == "rv@admin" ? user.C_PASSWORD : Encrypt.MD5(cUser.Password);
                if (user == null)
                {
                    result.Code = DoResult.Failed;
                    result.Result = LoginResult.NoUser.GetRemark();
                }
                else if (user.C_PASSWORD != pw)
                {
                    result.Code = DoResult.Failed;
                    result.Result = LoginResult.WrongPwd.GetRemark();
                }
                else if (user.N_STATUS == (int)LoginResult.Frozen)
                {
                    result.Code = DoResult.Failed;
                    result.Result = LoginResult.WrongVerify.GetRemark();
                }
                else
                {

                    CurrentUser currentUser = new CurrentUser()
                    {
                        Id = user.C_ID,
                        Name = user.C_NAME,
                        Account = user.C_ACCOUNT,
                        Email = user.C_EMAIL,
                        Password = user.C_PASSWORD,
                        LoginTime = DateTime.Now,
                        C_TOKEN_ID = user.C_TOKEN_ID
                    };

                    string token = currentUser.C_TOKEN_ID;
                    result.Code = DoResult.Success;
                    //保存cookie
                    HttpCookie myCookie = new HttpCookie("CurrentUser");
                    myCookie.Value = SerializationHelper.JsonSerialize<CurrentUser>(currentUser);
                    myCookie.Expires = DateTime.Now.AddHours(5);
                    HttpContext.Current.Response.Cookies.Add(myCookie);

                    //保存Session
                    HttpContext.Current.Session["CurrentUser"] = currentUser;
                    HttpContext.Current.Session.Timeout = 1440;
                    result.Result = token;
                }
            }
            catch (Exception ex)
            {
                result.Code = DoResult.Failed;
                result.Result = ex.Message;
            }
            return result;
        }

        /// <summary>  
        /// 上传文件  
        /// </summary>  
        /// <returns></returns>      
        [HttpPost]
        public AjaxResult PostFiles()
        {
            AjaxResult result = new AjaxResult();
            HttpFileCollection filelist = HttpContext.Current.Request.Files;
            if (filelist != null && filelist.Count > 0)
            {
                for (int i = 0; i < filelist.Count; i++)
                {
                    HttpPostedFile file = filelist[i];
                    String Tpath = "/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";
                    string filename = file.FileName;
                    string FileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                    string FilePath = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + Tpath + "\\";
                    DirectoryInfo di = new DirectoryInfo(FilePath);
                    if (!di.Exists) { di.Create(); }
                    try
                    {
                        file.SaveAs(FilePath + FileName);
                        result.Result = (Tpath + FileName).Replace("\\", "/");
                        result.Code = DoResult.Success;
                    }
                    catch (Exception ex)
                    {
                        result.Result = "上传文件写入失败：" + ex.Message;
                    }
                }
            }
            else
            {
                result.Code = DoResult.Failed;
                result.Result = "上传的文件信息不存在！";
            }

            return result;
        }

        /// <summary>
        /// 登出
        /// </summary>
        [HttpPost]
        public AjaxResult UserLogOut()
        {
            AjaxResult result = new AjaxResult();
            try
            {
                HttpCookie cookie = NF.Framework.Cookie.Get("CurrentUser");
                IEnumerable<string> s = Request.Headers.GetValues("Authorization");
                if (cookie != null)
                {
                    NF.Framework.Cookie.Remove(cookie);
                    CurrentUser currentUser = (CurrentUser)HttpContext.Current.Session["CurrentUser"];
                }
                HttpContext.Current.Session.Remove("CurrentUser");
                result.Code = DoResult.Success;
                result.Result = "拜拜!";
            }
            catch (Exception ex)
            {
                result.Code = DoResult.Failed;
                result.Result = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <param name="jData"></param>
        /// <returns></returns>
        [HttpPost]
        public AjaxResult Menus(JObject jData)
        {
            AjaxResult result = new AjaxResult();
            try
            {
                //获取EF用户
                TS_USER user = service.CheckToken(Token);
                //用户信息
                AppCurrentUser currentUser = new AppCurrentUser()
                {
                    Id = user.C_ID,
                    Name = user.C_NAME,
                    Account = user.C_ACCOUNT,
                    CustId = user.C_CUST_ID
                };

                //菜单
                List<TS_MENU> menus = service.GetMenus(2).ToList().OrderBy(x => x.N_SORT).ToList();
                //获取用户角色
                List<TS_ROLEDTO> roles = service.GetCurrentUserRole(currentUser.Id);
                //获取所有菜单权限
                List<TS_FUNCTIONDTO> menuFuns = service.GetRoleFun(roles);
                //拥有权限的菜单
                List<TS_MENU> newMenus = new List<TS_MENU>();

                foreach (var m in menus)
                {
                    if (menuFuns.ExistsOrDefault<TS_FUNCTIONDTO>(x => x.MenuID == m.C_ID))
                    {
                        newMenus.Add(m);
                    }
                }

                result.Code = DoResult.Success;
                result.Result = JsonConvert.SerializeObject(newMenus);
            }
            catch (Exception ex)
            {
                result.Code = DoResult.Failed;
                result.Result = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public AjaxResult PostUser(JObject jData)
        {
            AjaxResult result = new AjaxResult();

            try
            {
                //获取EF用户
                TS_USER user = service.CheckToken(Token);

                //用户信息
                AppCurrentUser currentUser = new AppCurrentUser()
                {
                    Id = user.C_ID,
                    Name = user.C_NAME,
                    Account = user.C_ACCOUNT,
                    CustId = user.C_CUST_ID,
                    CustTel = user.C_MOBILE,
                    Type = user.N_TYPE.ToString()
                };

                //获取客户档案
                TS_CUSTFILE custFile = service.GetCustFile(currentUser.CustId);
                if (custFile != null)
                {
                    currentUser.C_NC_M_ID = custFile.C_NC_M_ID;
                    currentUser.CustName = custFile.C_NAME;
                    currentUser.CustNo = custFile.C_NO;
                    TS_CUSTADDR custAddr = service.GetCustAddr(currentUser.CustId);
                    if (custAddr != null)
                    {
                        //currentUser.CustTel = custAddr.C_CGMOBILE;
                        currentUser.CustAddress = custAddr.C_CGADDR;
                    }
                }
                //获取用户菜单权限
                //currentUser.MenuFuncs = service.GetCurrentMenuFun(currentUser.Id);
                //获取用户按钮权限
                //currentUser.ButtonFuncs = service.GetCurrentButtonFun(currentUser.Id);
                //获取用户部门信息
                //currentUser.Depts = service.GetCurrentUserDept(currentUser.Id);
                //获取角色信息
                //currentUser.Roles = service.GetCurrentUserRole(currentUser.Id);
                //获取角色权限
                //currentUser = service.GetRoleFun(currentUser);

                //保存cookie
                HttpCookie myCookie = new HttpCookie("CurrentUser");
                myCookie.Value = SerializationHelper.JsonSerialize<AppCurrentUser>(currentUser);
                myCookie.Expires = DateTime.Now.AddHours(24);
                //myCookie.Expires = DateTime.Now.AddMinutes(1);
                HttpContext.Current.Response.Cookies.Add(myCookie);
                //保存Session
                HttpContext.Current.Session["CurrentUser"] = currentUser;
                HttpContext.Current.Session.Timeout = 1440;

                result.Code = DoResult.Success;
                result.Result = JsonConvert.SerializeObject(currentUser);

            }
            catch (Exception e)
            {
                result.Code = DoResult.Failed;
                result.Result = e.Message;
            }
            return result;
        }

        /// <summary>
        /// 添加用户使用报告
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public AjaxResult CustReportInsert(JObject jData)
        {
            AjaxResult result = new AjaxResult();
            try
            {
                var custReport = jData.ToObject<TMC_CUST_REPORTDTO>();
                custReport.C_EMP_ID = BaseUser.Id;
                custReport.C_EMP_NAME = BaseUser.Name;
                custReport.D_MOD_DT = DateTime.Now;
                if (BaseUser.CustFile != null)
                {
                    custReport.C_CUST_NAME = BaseUser.CustFile.C_NAME;
                    custReport.C_CUST_NO = BaseUser.CustFile.C_NO;
                }
                basicsService.CustReportInsert(custReport);
                result.Code = DoResult.Success;
                result.Result = "添加成功";
            }
            catch (Exception e)
            {
                result.Code = DoResult.Failed;
                result.Result = e.Message;
            }
            return result;
        }

        [HttpPost]
        public AjaxResult GetEvalItem(JObject jData)
        {
            AjaxResult result = new AjaxResult();
            try
            {
                List<AppEvalItem> appItems = new List<AppEvalItem>();
                List<TMC_EVAL_ITEMDTO> items = basicsService.GetEvalItems("0");
                foreach (var item in items)
                {
                    appItems.Add(AutoMapper.Mapper.Map<AppEvalItem>(item));
                }
                result.Code = DoResult.Success;
                result.Result = JsonConvert.SerializeObject(appItems);
            }
            catch (Exception e)
            {
                result.Code = DoResult.Failed;
                result.Result = e.Message;
            }
            return result;
        }

        /// <summary>
        /// 添加问卷满意度调查
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public AjaxResult CustEvalInsert(JObject jData)
        {
            AjaxResult result = new AjaxResult();
            try
            {
                var custEval = jData.ToObject<TMC_CUST_EVALDTO>();
                custEval.C_ID = Guid.NewGuid().ToString();
                custEval.D_MOD_DT = DateTime.Now;
                if (BaseUser.CustFile != null)
                {
                    custEval.C_CUST = BaseUser.CustFile.C_NAME;
                    custEval.N_CUST_TYPE = BaseUser.CustFile.N_TYPE;
                    if (BaseUser.CustFile.CustAddr != null)
                        custEval.C_TEL = BaseUser.CustFile.CustAddr.C_CGMOBILE;
                    custEval.C_EMP_NAME = BaseUser.Name;
                    custEval.C_AREA = qualityService.GetAreaName(BaseUser.CustFile.C_AREATYPE);
                }
                else
                {
                    custEval.C_CUST = BaseUser.Name;
                    custEval.N_CUST_TYPE = 1;
                    custEval.C_EMP_NAME = BaseUser.Name;
                }
                basicsService.CustEvalInsert(custEval);
                result.Code = DoResult.Success;
                result.Result = "添加成功";
            }
            catch (Exception e)
            {
                result.Code = DoResult.Failed;
                result.Result = e.Message;
            }
            return result;
        }

        /// <summary>
        /// 质量异议返馈列表
        /// </summary>
        /// <param name="jData"></param>
        /// <returns></returns>
        [HttpPost]
        public AjaxResult GetQualitys(JObject jData)
        {
            AjaxResult result = new AjaxResult();
            try
            {
                var cQuality = jData.ToObject<AppQuality>();

                List<AppQuality> dtos = new List<AppQuality>();
                dtos = service.GetQualitys(cQuality);
                result.Code = DoResult.Success;
                result.Result = JsonConvert.SerializeObject(dtos);
            }
            catch (Exception e)
            {
                result.Code = DoResult.Failed;
                result.Result = e.Message;
            }
            return result;
        }

        /// <summary>
        /// 质量返馈新增
        /// </summary>
        /// <param name="jData"></param>
        /// <returns></returns>
        public AjaxResult QualityInsert(JObject jData)
        {
            AjaxResult result = new AjaxResult();
            try
            {
                var cQuality = jData.ToObject<AppQuality>();
                var ef = AutoMapper.Mapper.Map<TMQ_QUALITY_MAIN>(cQuality);
                ef.C_ID = Guid.NewGuid().ToString();
                ef.C_EMP_ID = BaseUser.Id;
                ef.C_EMP_NAME = BaseUser.Name;
                ef.D_MOD_DT = DateTime.Now;
                ef = qualityService.QualitysInser(ef);
                List<TRC_ROLL_PRODCUT> products = new List<TRC_ROLL_PRODCUT>();
                List<TSC_SLAB_MAIN> slabs = new List<TSC_SLAB_MAIN>();
                List<TMQ_QUALITY_STL_GRDDTO> stlGrds = new List<TMQ_QUALITY_STL_GRDDTO>();
                if (cQuality.N_ORDERTYPE == "8")
                {
                    if (cQuality.Details != null && cQuality.Details.Count > 0)
                    {
                        foreach (var item in cQuality.Details)
                        {
                            products = qualityService.GetRollProdcut(item.BatchNO, "");
                            if (products != null && products.Count > 0)
                            {
                                foreach (var p in products)
                                {
                                    TMQ_QUALITY_STL_GRDDTO newStl = new TMQ_QUALITY_STL_GRDDTO();
                                    newStl.C_QUALITY_ID = ef.C_ID;
                                    newStl.C_BATCH_NO = item.BatchNO;
                                    newStl.C_STL_GRD = p.C_STL_GRD;
                                    newStl.C_STD_CODE = p.C_STD_CODE;
                                    newStl.C_SPEC = p.C_SPEC;
                                    newStl.N_SHIP_WGT = item.N_SHIP_WGT;
                                    newStl.N_OBJEC_WGT = item.N_OBJEC_WGT;
                                    stlGrds.Add(newStl);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (cQuality.Details != null && cQuality.Details.Count > 0)
                    {
                        foreach (var item in cQuality.Details)
                        {
                            slabs = qualityService.GetSlabMain(item.BatchNO, "");
                            if (slabs != null && slabs.Count > 0)
                            {
                                foreach (var p in products)
                                {
                                    TMQ_QUALITY_STL_GRDDTO newStl = new TMQ_QUALITY_STL_GRDDTO();
                                    newStl.C_QUALITY_ID = ef.C_ID;
                                    newStl.C_BATCH_NO = item.BatchNO;
                                    newStl.C_STL_GRD = p.C_STL_GRD;
                                    newStl.C_STD_CODE = p.C_STD_CODE;
                                    newStl.C_SPEC = p.C_SPEC;
                                    newStl.N_SHIP_WGT = item.N_WGT;
                                    stlGrds.Add(newStl);
                                }
                            }
                        }
                    }
                }

                qualityService.QualitysDetailInser(stlGrds);

                result.Code = DoResult.Success;
                result.Result = "添加成功!";
            }
            catch (Exception e)
            {
                result.Code = DoResult.Failed;
                result.Result = e.Message;
            }
            return result;
        }

        /// <summary>
        /// 质量异议返馈
        /// </summary>
        /// <param name="jData"></param>
        /// <returns></returns>
        [HttpPost]
        public AjaxResult GetQuality(JObject jData)
        {
            AjaxResult result = new AjaxResult();
            try
            {
                var cQuality = jData.ToObject<AppQuality>();
                var dtos = qualityService.GetQuality(cQuality.C_ID);
                var appQ = AutoMapper.Mapper.Map<AppQuality>(dtos);
                List<AppQuality_STL_GRD> stlGrds = new List<AppQuality_STL_GRD>();
                if (dtos != null && dtos.QualityStlGrds != null && dtos.QualityStlGrds.Count > 0)
                {
                    foreach (var item in dtos.QualityStlGrds)
                    {
                        AppQuality_STL_GRD stlGrd = new AppQuality_STL_GRD();
                        stlGrd.BatchNO = item.C_BATCH_NO;
                        stlGrd.N_OBJEC_WGT = item.N_OBJEC_WGT;
                        stlGrd.N_SHIP_WGT = item.N_SHIP_WGT;
                        stlGrd.N_WGT = item.N_WGT;
                        stlGrds.Add(stlGrd);
                    }
                    appQ.Details = stlGrds;
                }

                result.Code = DoResult.Success;
                result.Result = JsonConvert.SerializeObject(appQ);
            }
            catch (Exception e)
            {
                result.Code = DoResult.Failed;
                result.Result = e.Message;
            }
            return result;
        }

        /// <summary>
        /// 质量异议返馈
        /// </summary>
        /// <param name="jData"></param>
        /// <returns></returns>
        [HttpPost]
        public AjaxResult QualityUpdate(JObject jData)
        {
            AjaxResult result = new AjaxResult();
            try
            {
                var cQuality = jData.ToObject<AppQuality>();
                var ef = AutoMapper.Mapper.Map<TMQ_QUALITY_MAIN>(cQuality);
                ef.C_EMP_ID = BaseUser.Id;
                ef.C_EMP_NAME = BaseUser.Name;
                ef.D_MOD_DT = DateTime.Now;
                qualityService.QualitysUpdate(ef);
                List<TRC_ROLL_PRODCUT> products = new List<TRC_ROLL_PRODCUT>();
                List<TSC_SLAB_MAIN> slabs = new List<TSC_SLAB_MAIN>();
                List<TMQ_QUALITY_STL_GRDDTO> stlGrds = new List<TMQ_QUALITY_STL_GRDDTO>();
                if (cQuality.N_ORDERTYPE == "8")
                {
                    if (cQuality.Details != null && cQuality.Details.Count > 0)
                    {
                        foreach (var item in cQuality.Details)
                        {
                            products = qualityService.GetRollProdcut(item.BatchNO, "");
                            if (products != null && products.Count > 0)
                            {
                                foreach (var p in products)
                                {
                                    TMQ_QUALITY_STL_GRDDTO newStl = new TMQ_QUALITY_STL_GRDDTO();
                                    newStl.C_QUALITY_ID = ef.C_ID;
                                    newStl.C_BATCH_NO = item.BatchNO;
                                    newStl.C_STL_GRD = p.C_STL_GRD;
                                    newStl.C_STD_CODE = p.C_STD_CODE;
                                    newStl.C_SPEC = p.C_SPEC;
                                    newStl.N_SHIP_WGT = item.N_SHIP_WGT;
                                    newStl.N_OBJEC_WGT = item.N_OBJEC_WGT;
                                    stlGrds.Add(newStl);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (cQuality.Details != null && cQuality.Details.Count > 0)
                    {
                        foreach (var item in cQuality.Details)
                        {
                            slabs = qualityService.GetSlabMain(item.BatchNO, "");
                            if (slabs != null && slabs.Count > 0)
                            {
                                foreach (var p in products)
                                {
                                    TMQ_QUALITY_STL_GRDDTO newStl = new TMQ_QUALITY_STL_GRDDTO();
                                    newStl.C_QUALITY_ID = ef.C_ID;
                                    newStl.C_BATCH_NO = item.BatchNO;
                                    newStl.C_STL_GRD = p.C_STL_GRD;
                                    newStl.C_STD_CODE = p.C_STD_CODE;
                                    newStl.C_SPEC = p.C_SPEC;
                                    newStl.N_SHIP_WGT = item.N_WGT;
                                    stlGrds.Add(newStl);
                                }
                            }
                        }
                    }
                }
                qualityService.QualitysDetailDelete(ef.C_ID);
                qualityService.QualitysDetailInser(stlGrds);
                result.Code = DoResult.Success;
                result.Result = "修改成功";
            }
            catch (Exception e)
            {
                result.Code = DoResult.Failed;
                result.Result = e.Message;
            }
            return result;
        }


        [HttpPost]
        public AjaxResult PasswordUpdate(JObject jData)
        {
            AjaxResult result = new AjaxResult();
            try
            {
                //获取EF用户
                TS_USER user = service.CheckToken(Token);
                var appUser = jData.ToObject<AppCurrentUser>();
                if (user.C_PASSWORD == Encrypt.MD5(appUser.OldPw))
                {
                    user.C_PASSWORD = Encrypt.MD5(appUser.NewPw);
                    service.Update(user);
                    result.Code = DoResult.Success;
                    result.Result = "修改成功";
                }
                else
                {
                    result.Code = DoResult.Failed;
                    result.Result = "旧密码错误";
                }
            }
            catch (Exception e)
            {
                result.Code = DoResult.Failed;
                result.Result = e.Message;
            }

            return result;
        }

        [HttpPost]
        public AjaxResult GetUserInfo(JObject jData)
        {
            AjaxResult result = new AjaxResult();

            try
            {
                //获取EF用户
                TS_USER user = service.CheckToken(Token);

                AppUser appUser = new AppUser()
                {
                    Name = user.C_NAME,
                    Tel = user.C_PHONE,
                    Phone = user.C_MOBILE,
                    Fax = user.C_MOBILE2,
                    EMail = user.C_EMAIL
                };
                if (user.C_CUST_ID == null)
                {
                    appUser.Money = decimal.Parse("0").ToString("###,##0.00");
                }
                else
                {
                    DataTable dt = ts_custfile.GetCusetMoney(user.C_CUST_ID).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        appUser.Money = decimal.Parse(dt.Rows[0]["KHYE"].ToString()).ToString("###,##0.00");
                    }
                }
                result.Code = DoResult.Success;
                result.Result = JsonConvert.SerializeObject(appUser);
            }
            catch (Exception e)
            {
                result.Code = DoResult.Failed;
                result.Result = e.Message;
            }
            return result;
        }

        [HttpPost]
        public AjaxResult UserInfoUpdate(JObject jData)
        {
            AjaxResult result = new AjaxResult();

            try
            {
                var cUser = jData.ToObject<AppUser>();
                //获取EF用户
                TS_USER user = service.CheckToken(Token);
                user.C_NAME = cUser.Name;
                user.C_PHONE = cUser.Tel;
                user.C_MOBILE = cUser.Phone;
                user.C_MOBILE2 = cUser.Fax;
                user.C_EMAIL = cUser.EMail;
                service.Update(user);
                result.Code = DoResult.Success;
                result.Result = "修改成功";
            }
            catch (Exception e)
            {
                result.Code = DoResult.Failed;
                result.Result = e.Message;
            }
            return result;
        }

        [HttpPost]
        public AjaxResult GetCompanyInfo(JObject jData)
        {
            AjaxResult result = new AjaxResult();

            try
            {
                //获取EF用户
                TS_USER user = service.CheckToken(Token);
                TS_CUSTFILE custFile = service.GetCustFile(user.C_CUST_ID);
                if (custFile != null)
                {
                    user.C_CJNAME = custFile.C_NAME;
                }
                AppCompany appCompany = new AppCompany()
                {
                    C_CJNAME = user.C_CJNAME,
                    C_CJINTRO = user.C_CJINTRO,
                    C_STL_GRD = user.C_STL_GRD,
                    C_LEGALREPRES = user.C_LEGALREPRES,
                    C_CGJCR = user.C_CGJCR,
                    C_JOB = user.C_JOB,
                    C_JCTEL = user.C_JCTEL,
                    C_ADDRESS = user.C_ADDRESS,
                    C_AREA = user.C_AREA,
                    C_MANAGER = user.C_MANAGER
                };


                result.Code = DoResult.Success;
                result.Result = JsonConvert.SerializeObject(appCompany);
            }
            catch (Exception e)
            {
                result.Code = DoResult.Failed;
                result.Result = e.Message;
            }
            return result;
        }

        [HttpPost]
        public AjaxResult CompanyInfoUpdate(JObject jData)
        {
            AjaxResult result = new AjaxResult();

            try
            {
                var cCompany = jData.ToObject<AppCompany>();
                //获取EF用户
                TS_USER user = service.CheckToken(Token);

                user.C_CJNAME = cCompany.C_CJNAME;
                user.C_CJINTRO = cCompany.C_CJINTRO;
                user.C_STL_GRD = cCompany.C_STL_GRD;
                user.C_LEGALREPRES = cCompany.C_LEGALREPRES;
                user.C_CGJCR = cCompany.C_CGJCR;
                user.C_JOB = cCompany.C_JOB;
                user.C_JCTEL = cCompany.C_JCTEL;
                user.C_ADDRESS = cCompany.C_ADDRESS;
                user.C_AREA = cCompany.C_AREA;
                user.C_MANAGER = cCompany.C_MANAGER;
                service.Update(user);
                result.Code = DoResult.Success;
                result.Result = "修改成功";
            }
            catch (Exception e)
            {
                result.Code = DoResult.Failed;
                result.Result = e.Message;
            }
            return result;
        }

    }
}