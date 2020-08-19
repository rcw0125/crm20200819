using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NF.Bussiness.Interface;
using NF.EF.Model;
using NF.Framework;
using NF.Framework.DTO;
using NF.Web.Core;
using Microsoft.Practices.Unity;
using System.IO;
using NF.BLL;
using NF.MODEL;
using System.Web.Http;
using System.Data;
using NF.BLL.Q;
using Newtonsoft.Json;
using NF.MODEL.Q;
using System.Text;

namespace CRM.Controllers
{
    public class QualityController : ApiController
    {

        private Bll_TMQ_QUA_MAIN qua = new Bll_TMQ_QUA_MAIN();
        private Bll_TS_USER ts_user = new Bll_TS_USER();
        protected string Token => Request.Headers.Authorization.Scheme;

        private const string RoleCode = "kh-001";
        private const string KFCode = "z-002";
        private const string SaleCode = "S0002/S0003/S0004/S0005/S0006/S0007";

        [HttpPost]
        [AllowAnonymous]
        public AjaxResult QualityList([FromBody]dynamic Json)
        {
            AjaxResult result = new AjaxResult();
            string AreaID = Json.AreaID;//区域
            string State = Json.State;//状态
            string Type = Json.Type;//类型
            string ObjType = Json.ObjType;//异议分类
            string Distri = Json.Distri;//经销商
            string Start = Json.Start;//发运开始时间
            string End = Json.End;//发运结束时间
            string Grd = Json.Grd;//钢种
            string SalesMan = Json.SalesMan;//业务员
            string strWhere = "";

            if (!string.IsNullOrEmpty(Distri))
            {
                strWhere += " and m.C_DISTRIBUTOR like '%" + Distri + "%' ";
            }
            if (!string.IsNullOrEmpty(Start))
            {
                strWhere += " AND m.D_CRT_DT>=TO_DATE('" + Start + "', 'yyyy-mm-dd hh24:mi:ss')";
            }
            if (!string.IsNullOrEmpty(End))
            {
                strWhere += " AND m.D_CRT_DT<=TO_DATE('" + End + "', 'yyyy-mm-dd hh24:mi:ss')";
            }
            if (AreaID != "0")
            {
                strWhere += " and m.C_AREA_ID=" + AreaID;
            }
            if (Type != "0")
            {
                strWhere += " and m.N_FLAG=" + Type;
            }
            if (!string.IsNullOrEmpty(SalesMan))
            {
                strWhere += " and m.C_SALESMAN like '%" + SalesMan + "%'";
            }
            if (!string.IsNullOrEmpty(Grd))
            {
                strWhere += " and m.C_GRD like '%" + Grd + "%'";
            }
            if (State != "-2")
            {
                strWhere += " and m.N_STATUS=" + State;
            }
            if (!string.IsNullOrEmpty(ObjType))
            {
                strWhere += " and m.C_OBJECTION_TYPE like '%" + ObjType + "%'";
            }
            var vUser = GetUser();
            if (vUser.Roles.Where(x => x.C_CODE == RoleCode).Any())
            {
                strWhere += " and m.C_CRT_ID='" + vUser.C_ID + "' ";
                strWhere += " and m.n_status>=-1 ";
            }
            if (vUser.Roles.Where(x => SaleCode.Contains(x.C_CODE)).Any())
            {
                strWhere += " and m.n_status>=0 and m.C_SALESID='" + vUser.C_ID + "'";
            }
            if (vUser.Roles.Where(x => x.C_CODE == KFCode).Any())
            {
                strWhere += " and m.n_status>=0";
            }
            DataTable dt = qua.GetList(strWhere);
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(dt);
            return result;
        }
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult QualityAdd([FromBody]dynamic Json)
        {
            string AreaID = Json.AreaID;//区域ID
            string Distri = Json.Distri;//经销商
            string tDirectuser = Json.tDirectuser;//直接用户
            string Contact = Json.Contact;//联系人
            string ConPhone = Json.ConPhone;//联系电话
            string Grd = Json.Grd;//钢种
            string Start = Json.Start;//发货时间
            string End = Json.End;//到货时间
            string ProUse = Json.ProUse;//产品用途
            string SaleUser = Json.SaleUser;//业务员名称
            string SaleUserID = Json.SaleUserID;//业务员ID
            string ObjContent = Json.ObjContent;//投诉异议内容
            string TechDesc = Json.TechDesc;//用户工艺流程
            string Bz = Json.Bz;//备注信息
            string StlGrdType = Json.StlGrdType;//钢种类型

            if (Start != "")
            {
                Start += " 00:00:00";
            }
            if (End != "")
            {
                End += " 00:00:00";
            }
            AjaxResult result = new AjaxResult();
            var vUser = GetUser();
            if (vUser == null)
            {
                result.Code = DoResult.Failed;
                result.Result = "添加失败!";
                return result;
            }
            Mod_TMQ_QUA_MAIN mod = new Mod_TMQ_QUA_MAIN();
            mod.C_id = Guid.NewGuid().ToString();
            #region 新增字段
            if (!string.IsNullOrEmpty(AreaID))
            {
                mod.C_area_id = AreaID;
            }
            if (!string.IsNullOrEmpty(Distri))
            {
                mod.C_distributor = Distri;
            }
            if (!string.IsNullOrEmpty(tDirectuser))
            {
                mod.C_directuser = tDirectuser;
            }
            if (!string.IsNullOrEmpty(Contact))
            {
                mod.C_contact = Contact;
            }
            if (!string.IsNullOrEmpty(ConPhone))
            {
                mod.C_con_phone = ConPhone;
            }
            if (!string.IsNullOrEmpty(Grd))
            {
                mod.C_grd = Grd;
            }
            if (!string.IsNullOrEmpty(Start))
            {
                mod.D_ship_start_dt = DateTime.Parse(Start);
            }
            if (!string.IsNullOrEmpty(End))
            {
                mod.D_ship_end_dt = DateTime.Parse(End);
            }
            if (!string.IsNullOrEmpty(ProUse))
            {
                mod.C_prod_use = ProUse;
            }
            if (!string.IsNullOrEmpty(SaleUser))
            {
                mod.C_salesman = SaleUser;
            }
            if (!string.IsNullOrEmpty(SaleUserID))
            {
                mod.C_salesid = SaleUserID;
            }
            if (!string.IsNullOrEmpty(ObjContent))
            {
                mod.C_object_content = ObjContent;
            }
            if (!string.IsNullOrEmpty(TechDesc))
            {
                mod.C_tech_desc = TechDesc;
            }
            if (!string.IsNullOrEmpty(Bz))
            {
                mod.C_remark = Bz;
            }
            mod.C_objection_type = StlGrdType;
            mod.D_crt_dt = DateTime.Now;
            mod.N_status = -1;
            mod.C_emp_id = vUser.C_ID;
            mod.C_emp_name = vUser.C_NAME;
            mod.C_crt_id = vUser.C_ID;
            #endregion
            if (qua.Add(mod))
            {
                result.Code = DoResult.Success;
                result.Result = mod.C_id;
            }
            else
            {
                result.Code = DoResult.Failed;
                result.Result = "添加失败!";
            }
            return result;
        }
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult QualityUpdate([FromBody]dynamic Json)
        {
            string SaveOrSubmit = Json.SaveOrSubmit;//1 保存 2 提交
            string ID = Json.ID;//主表ID
            string AreaID = Json.AreaID;//区域ID
            string Distri = Json.Distri;//经销商
            string tDirectuser = Json.tDirectuser;//直接用户
            string Contact = Json.Contact;//联系人
            string ConPhone = Json.ConPhone;//联系电话
            string Grd = Json.Grd;//钢种
            string Start = Json.Start;//发货时间
            string End = Json.End;//到货时间
            string ProUse = Json.ProUse;//产品用途
            string SaleUser = Json.SaleUser;//业务员名称
            string SaleUserID = Json.SaleUserID;//业务员ID
            string ObjContent = Json.ObjContent;//投诉异议内容
            string TechDesc = Json.TechDesc;//用户工艺流程
            string Bz = Json.Bz;//备注信息
            string SiteContent = Json.SiteContent;//现场调查情况
            string ParentQua = Json.ParentQua;//母材
            string QuestQua = Json.QuestQua;//问题样
            string MidQua = Json.MidQua;//中间样
            string ElseQua = Json.ElseQua;//其他样
            string Dept = Json.Dept;//本部门
            string QualityDept = Json.QualityDept;//质控部
            string Technology = Json.Technology;//技术中心
            string Qt = Json.Qt;//其他
            string TypeID = Json.TypeID;//类型ID
            string SumWGT = Json.SumWGT;//异议数量合计 明细异议数量 汇总和 
            string CustMaking = Json.CustMaking;//制单人
            string CustMakingDT = Json.CustMakingDT;//制单日期
            string QualityResult = Json.QualityResult;//质控部检验结果
            string ObjectionType = Json.ObjectionType;//异议分类
            string OurReaons = Json.OurReaons;//我方原因
            string FeedBackArea = Json.FeedBackArea;//反馈区域时间
            string EffectValid = Json.EffectValid;//效果验证
            string PreccResult = Json.PreccResult;//处理结果
            string Amount = Json.Amount;//赔付金额
            string CompensationDt = Json.CompensationDt;//赔付时间
            string State = Json.State;//状态
            string Cycle = Json.Cycle;//处理周期

            AjaxResult result = new AjaxResult();
            var vUser = GetUser();
            if (vUser == null)
            {
                result.Code = DoResult.Failed;
                result.Result = "修改失败!";
                return result;
            }
            Mod_TMQ_QUA_MAIN mod = qua.GetModel(ID);
            #region 更新字段
            if (!string.IsNullOrEmpty(State))
            {
                mod.C_state = State;
            }
            if (!string.IsNullOrEmpty(Cycle))
            {
                mod.N_cycle = Decimal.Parse(Cycle);
            }
            if (!string.IsNullOrEmpty(AreaID))
            {
                mod.C_area_id = AreaID;
            }
            if (!string.IsNullOrEmpty(Distri))
            {
                mod.C_distributor = Distri;
            }
            if (!string.IsNullOrEmpty(tDirectuser))
            {
                mod.C_directuser = tDirectuser;
            }
            if (!string.IsNullOrEmpty(Contact))
            {
                mod.C_contact = Contact;
            }
            if (!string.IsNullOrEmpty(ConPhone))
            {
                mod.C_con_phone = ConPhone;
            }
            if (!string.IsNullOrEmpty(Grd))
            {
                mod.C_grd = Grd;
            }
            if (!string.IsNullOrEmpty(ProUse))
            {
                mod.C_prod_use = ProUse;
            }
            if (!string.IsNullOrEmpty(Start))
            {
                mod.D_ship_start_dt = DateTime.Parse(Start);
            }
            if (!string.IsNullOrEmpty(End))
            {
                mod.D_ship_end_dt = DateTime.Parse(End);
            }
            if (!string.IsNullOrEmpty(SaleUser))
            {
                mod.C_salesman = SaleUser;
            }
            if (!string.IsNullOrEmpty(SaleUserID))
            {
                mod.C_salesid = SaleUserID;
            }
            if (!string.IsNullOrEmpty(ObjContent))
            {
                mod.C_object_content = ObjContent;
            }
            if (!string.IsNullOrEmpty(TechDesc))
            {
                mod.C_tech_desc = TechDesc;
            }
            if (!string.IsNullOrEmpty(Bz))
            {
                mod.C_remark = Bz;
            }
            if (!string.IsNullOrEmpty(SiteContent))
            {
                mod.C_site_survey_content = SiteContent;
            }
            if (!string.IsNullOrEmpty(ParentQua))
            {
                mod.N_parent_qua = decimal.Parse(ParentQua);
            }
            if (!string.IsNullOrEmpty(QuestQua))
            {
                mod.N_quest_qua = decimal.Parse(QuestQua);
            }
            if (!string.IsNullOrEmpty(MidQua))
            {
                mod.N_middle_qua = decimal.Parse(MidQua);
            }
            if (!string.IsNullOrEmpty(ElseQua))
            {
                mod.N_else_qua = decimal.Parse(ElseQua);
            }
            if (!string.IsNullOrEmpty(Dept))
            {
                mod.C_dept = Dept;
            }
            if (!string.IsNullOrEmpty(QualityDept))
            {
                mod.C_quality_dept = QualityDept;
            }
            if (!string.IsNullOrEmpty(Technology))
            {
                mod.C_technology = Technology;
            }
            if (!string.IsNullOrEmpty(Qt))
            {
                mod.C_qt = Qt;
            }
            if (!string.IsNullOrEmpty(TypeID))
            {
                mod.N_flag = decimal.Parse(TypeID);
            }
            if (!string.IsNullOrEmpty(SumWGT))
            {
                mod.N_object_count_wgt = decimal.Parse(SumWGT);
            }
            if (!string.IsNullOrEmpty(CustMaking))
            {
                mod.C_cust_making = CustMaking;
            }
            if (!string.IsNullOrEmpty(CustMakingDT))
            {
                mod.D_cust_making_dt = DateTime.Parse(CustMakingDT);
            }
            if (!string.IsNullOrEmpty(QualityResult))
            {
                mod.C_quality_result = QualityResult;
            }
            if (!string.IsNullOrEmpty(ObjectionType))
            {
                mod.C_objection_type = ObjectionType;
            }
            if (!string.IsNullOrEmpty(OurReaons))
            {
                mod.C_ourreasons = OurReaons;
            }
            if (!string.IsNullOrEmpty(FeedBackArea))
            {
                mod.D_feedback_area = DateTime.Parse(FeedBackArea);
            }
            if (!string.IsNullOrEmpty(EffectValid))
            {
                mod.C_effect_valid = EffectValid;
            }
            if (!string.IsNullOrEmpty(PreccResult))
            {
                mod.C_precc_result = PreccResult;
            }
            if (!string.IsNullOrEmpty(Amount))
            {
                mod.N_amount = decimal.Parse(Amount);
            }
            if (!string.IsNullOrEmpty(CompensationDt))
            {
                mod.D_compensation_dt = DateTime.Parse(CompensationDt);
            }
            mod.C_emp_id = vUser.C_ID;
            mod.C_emp_name = vUser.C_NAME;
            if (!string.IsNullOrEmpty(SaveOrSubmit) && SaveOrSubmit == "2")
            {
                if (vUser.Roles.Where(x => x.C_CODE == RoleCode).Any())
                {
                    mod.N_status = 0;
                }
                else if (vUser.Roles.Where(x => SaleCode.Contains(x.C_CODE)).Any())
                {
                    mod.N_status = 1;
                }
                else if (vUser.Roles.Where(x => x.C_CODE == KFCode).Any())
                {
                    mod.N_status = 2;
                }
                if (qua.Submit(mod))
                {
                    result.Code = DoResult.Success;
                    result.Result = "提交成功";
                }
                else
                {
                    result.Code = DoResult.Failed;
                    result.Result = "提交失败!";
                }
            }
            else
            {
                #endregion
                if (qua.Update(mod))
                {
                    result.Code = DoResult.Success;
                    result.Result = "修改成功";
                }
                else
                {
                    result.Code = DoResult.Failed;
                    result.Result = "修改失败!";
                }
            }
            return result;
        }
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult QualityDel([FromBody]dynamic Json)
        {
            AjaxResult result = new AjaxResult();
            string ID = Json.ID;//区域
            if (qua.DeleteList("'" + ID + "'"))
            {
                result.Code = DoResult.Success;
                result.Result = "删除成功!";
            }
            else
            {
                result.Code = DoResult.Failed;
                result.Result = "删除失败!";
            }
            return result;
        }
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult QualityGet([FromBody]dynamic Json)
        {
            AjaxResult result = new AjaxResult();
            string ID = Json.ID;//质量异议主表ID
            var mod = qua.GetModel(ID);
            var vUser = GetUser();
            if (vUser.Roles.Where(x => SaleCode.Contains(x.C_CODE)).Any() && string.IsNullOrEmpty(mod.C_cust_making))
            {
                mod.C_cust_making = vUser.C_NAME;
                mod.D_cust_making_dt = DateTime.Now;
            }
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(mod);
            return result;
        }
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetRole([FromBody]dynamic Json)
        {
            AjaxResult result = new AjaxResult();
            var strRes = "";
            var vUser = GetUser();
            if (vUser.Roles.Where(x => x.C_CODE == RoleCode).Any())
            {
                strRes = "KH";
            }
            if (vUser.Roles.Where(x => SaleCode.Contains(x.C_CODE)).Any())
            {
                strRes = "XS";
            }
            if (vUser.Roles.Where(x => x.C_CODE == KFCode).Any())
            {
                strRes = "KF";
            }
            result.Code = DoResult.Success;
            result.Result = strRes;
            return result;
        }
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult QualityPrdList([FromBody]dynamic Json)
        {
            AjaxResult result = new AjaxResult();
            string ParentID = Json.ParentID;//区域

            string strWhere = "";
            if (!string.IsNullOrEmpty(ParentID))
            {
                strWhere += " and c_parentid='" + ParentID + "'";
            }
            DataTable dt = qua.GetItemList(strWhere).Tables[0];
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(dt);
            return result;
        }
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult QualityPrdAdd([FromBody]dynamic Json)
        {
            string ParentID = Json.ParentID;//主表ID
            string Batch = Json.Batch;//批号
            string BrandName = Json.BrandName;//牌号
            string Spec = Json.Spec;//规格
            string ShippedQty = Json.ShippedQty;//发货数量
            string ObjectWgt = Json.ObjectWgt;//异议数量
            string StlCode = Json.StlCode;//执行标准
            AjaxResult result = new AjaxResult();
            var vUser = GetUser();
            if (vUser == null)
            {
                result.Code = DoResult.Failed;
                result.Result = "添加失败!";
                return result;
            }

            Mod_TMQ_QUA_ITEM mod = new Mod_TMQ_QUA_ITEM();
            mod.C_id = Guid.NewGuid().ToString();
            if (!string.IsNullOrEmpty(ParentID))
            {
                mod.C_parentid = ParentID;
            }
            if (!string.IsNullOrEmpty(Batch))
            {
                mod.C_batch = Batch;
            }
            if (!string.IsNullOrEmpty(BrandName))
            {
                mod.C_brand_name = BrandName;
            }
            if (!string.IsNullOrEmpty(Spec))
            {
                mod.C_spec = Spec;
            }
            if (!string.IsNullOrEmpty(ShippedQty))
            {
                mod.N_shippedqty = decimal.Parse(ShippedQty);
            }
            if (!string.IsNullOrEmpty(ObjectWgt))
            {
                mod.N_object_wgt = decimal.Parse(ObjectWgt);
            }
            if (!string.IsNullOrEmpty(StlCode))
            {
                mod.C_stl_code = StlCode;
            }
            mod.D_crt_dt = DateTime.Now;
            mod.N_status = 0;
            mod.C_emp_id = vUser.C_ID;
            mod.C_emp_name = vUser.C_NAME;
            mod.C_emp_dt = DateTime.Now;
            if (qua.AddItem(mod) && qua.UpdateSumWgt(mod.C_parentid))
            {
                result.Code = DoResult.Success;
                result.Result = mod.C_id;
            }
            else
            {
                result.Code = DoResult.Failed;
                result.Result = "添加失败!";
            }

            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        public AjaxResult QualityPrdUpdate([FromBody]dynamic Json)
        {
            string ID = Json.ID;//产品ID
            string ParentID = Json.ParentID;//主表ID
            string Batch = Json.Batch;//批号
            string BrandName = Json.BrandName;//牌号
            string Spec = Json.Spec;//规格
            string ShippedQty = Json.ShippedQty;//发货数量
            string ObjectWgt = Json.ObjectWgt;//异议数量
            string StlCode = Json.StlCode;//执行标准
            AjaxResult result = new AjaxResult();
            var vUser = GetUser();
            if (vUser == null && ID == "")
            {
                result.Code = DoResult.Failed;
                result.Result = "更新失败!";
                return result;
            }
            Mod_TMQ_QUA_ITEM mod = new Mod_TMQ_QUA_ITEM();
            mod.C_id = ID;
            if (!string.IsNullOrEmpty(ParentID))
            {
                mod.C_parentid = ParentID;
            }
            if (!string.IsNullOrEmpty(Batch))
            {
                mod.C_batch = Batch;
            }
            if (!string.IsNullOrEmpty(BrandName))
            {
                mod.C_brand_name = BrandName;
            }
            if (!string.IsNullOrEmpty(Spec))
            {
                mod.C_spec = Spec;
            }
            if (!string.IsNullOrEmpty(ShippedQty))
            {
                mod.N_shippedqty = decimal.Parse(ShippedQty);
            }
            if (!string.IsNullOrEmpty(ObjectWgt))
            {
                mod.N_object_wgt = decimal.Parse(ObjectWgt);
            }
            if (!string.IsNullOrEmpty(StlCode))
            {
                mod.C_stl_code = StlCode;
            }
            mod.C_emp_id = vUser.C_ID;
            mod.C_emp_name = vUser.C_NAME;
            if (qua.UpdateItem(mod))
            {
                result.Code = DoResult.Success;
                result.Result = "更新成功!";
            }
            else
            {
                result.Code = DoResult.Failed;
                result.Result = "更新失败!";
            }
            return result;
        }
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult QualityPrdDel([FromBody]dynamic Json)
        {
            AjaxResult result = new AjaxResult();
            string ID = Json.ID;//质量异议主表ID 
            string ParentID = Json.ParentID;//质量异议主表ID 
            if (qua.DeleteItem(ID) && qua.UpdateSumWgt(ParentID))
            {
                result.Code = DoResult.Success;
                result.Result = "删除成功!";
            }
            else
            {
                result.Code = DoResult.Failed;
                result.Result = "删除失败!";
            }
            return result;
        }
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult SaleList([FromBody]dynamic Json)
        {
            AjaxResult result = new AjaxResult();
            string UserName = Json.UserName;//用户名
            string UserCode = Json.UserCode;//员工编号
            DataTable dt = ts_user.GetSales1(UserName, UserCode).Tables[0];
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(dt);
            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        public AjaxResult AreaList()
        {
            AjaxResult result = new AjaxResult();
            DataTable dt = qua.ListArea().Tables[0];
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(dt);
            return result;
        }
        protected Mod_TS_RoleUSER GetUser()
        {
            Bll_TS_USER ts_user = new Bll_TS_USER();
            return ts_user.GetTokenUserRoleModel(Token);
        }
    }
}