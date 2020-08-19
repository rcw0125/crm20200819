using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using NF.BLL;
using NF.MODEL;
using NF.Framework;
using NF.Bussiness.Interface;
using NF.Web.Core;
using Microsoft.Practices.Unity;
using NF.EF.Model;
using System.Web.Services;

namespace CRM.Sale_App
{
    public partial class ConList : System.Web.UI.Page
    {

        private static Bll_TMO_CON con = new Bll_TMO_CON();
        private Bll_TS_DIC dic = new Bll_TS_DIC();
        private static Bll_TMB_FLOWINFO flowinfo = new Bll_TMB_FLOWINFO();

        IComService buttonService = DIFactory.GetContainer().Resolve<IComService>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetFun();

                DateTime dt = DateTime.Now;
                Start.Value = dt.AddDays(-(dt.Day) + 1).ToString("yyy-MM-dd");
                End.Value = dt.AddMonths(1).AddDays(-(dt.Day)).ToString("yyy-MM-dd");
                BindContractType();

                ByPageBind();

            }
        }


        private void GetFun()
        {
            var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (user != null)
            {
                buttonService.RefreshButton(Request.RawUrl, user, Session);
                List<TS_BUTTON> button = (List<TS_BUTTON>)Session["button"];

                foreach (var item in button)
                {
                    if (Page.FindControl(item.C_CODE) != null)
                    {
                        Page.FindControl(item.C_CODE).Visible = true;
                    }
                }
            }
            else
            {
                WebMsg.CheckUserLogin();
            }
        }

        /// <summary>
        /// 合同类型
        /// </summary>
        private void BindContractType()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ContractType";
            DataTable dt = dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropType.DataSource = dt;
                dropType.DataTextField = "C_DETAILNAME";
                dropType.DataValueField = "C_ID";
                dropType.DataBind();
                dropType.Items.Insert(0, new ListItem("全部", ""));
            }
            else
            {
                dropType.DataSource = null;
                dropType.DataBind();
            }
        }

        /// <summary>
        /// 分页绑定
        /// </summary>
        private void ByPageBind()
        {
            Pager1.RecordCount = con.GetRecordCount(txtCon.Value, txtConName.Value, Start.Value, End.Value, dropType.SelectedItem.Value, dropState.SelectedItem.Value == "全部" ? "" : dropState.SelectedItem.Value);
            if (Pager1.RecordCount > 0)
            {
                GetListBind();
            }
            else
            {

                rptList.DataSource = null;
                rptList.DataBind();
            }
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        private void GetListBind()
        {
            rptList.DataSource = con.GetListByPage(Pager1.PageSize, Pager1.CurrentPageIndex, txtCon.Value, txtConName.Value, Start.Value, End.Value, dropType.SelectedItem.Value, dropState.SelectedItem.Value == "全部" ? "" : dropState.SelectedItem.Value);
            rptList.DataBind();
        }

        //查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ByPageBind();
        }



        /// <summary>
        /// 合同状态
        /// </summary>
        /// <param name="OrderStateId">标识</param>
        /// <returns></returns>
        public static string GetOrderState(object OrderStateId)
        {
            string _name = string.Empty;
            int _status = Convert.ToInt32(OrderStateId);

            switch (_status)
            {
                case -1:
                    _name = "未提交";
                    break;
                case 0:
                    _name = "待审";
                    break;
                case 1:
                    _name = "审核中";
                    break;
                case 2:
                    _name = "生效";
                    break;
                case 3:
                    _name = "撤回";
                    break;
                case 4:
                    _name = "冻结";
                    break;
            }
            return _name;

        }

        /// <summary>
        /// 获取流程
        /// </summary>
        /// <returns></returns>
        public static string GetFlow(object id)
        {
            string result = "";
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                Mod_TMB_FLOWINFO mod = flowinfo.GetModel(id.ToString());
                result = mod.C_NAME;
            }
            return result;
        }

        //分页
        protected void Pager1_PageChanged(object sender, EventArgs e)
        {
            GetListBind();
        }

        //合同变更
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hidconNO.Value))
            {
                if (con.UpdateConStatus(0, hidconNO.Value))
                {
                    Response.Redirect("ConEdit.aspx?ID=" + hidconNO.Value);
                }
            }
        }
    }
}