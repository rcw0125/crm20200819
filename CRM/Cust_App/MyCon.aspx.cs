using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using NF.BLL;
using NF.Framework;
using NF.MODEL;


namespace CRM.Cust_App
{
    public partial class MyCon : System.Web.UI.Page
    {

        private Bll_TMO_CON con = new Bll_TMO_CON();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    ltlUserID.Text = BaseUser.Id;

                    DateTime dt = DateTime.Now;
                    Start.Value = dt.AddDays(-(dt.Day) + 1).ToString("yyy-MM-dd");
                    End.Value = dt.AddMonths(1).AddDays(-(dt.Day)).ToString("yyy-MM-dd");
                    BindContractType();
                    BindConSate();


                    ByPageBind();

                }
                else
                {
                    WebMsg.CheckUserLogin();
                }

            }
        }

        /// <summary>
        /// 合同类型
        /// </summary>
        private void BindContractType()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ContractType";
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropConType.DataSource = dt;
                dropConType.DataTextField = "C_DETAILNAME";
                dropConType.DataValueField = "C_DETAILNAME";
                dropConType.DataBind();
                dropConType.Items.Insert(0, new ListItem("全部", ""));
            }
            else
            {
                dropConType.DataSource = null;
                dropConType.DataBind();
            }
        }

        /// <summary>
        /// 合同状态
        /// </summary>
        private void BindConSate()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ContractStatus";
            DataTable dt = ts_dic.GetList(mod).Tables[0];

            if (dt.Rows.Count > 0)
            {
                dropState.DataSource = dt;
                dropState.DataTextField = "C_DETAILNAME";
                dropState.DataValueField = "C_DETAILCODE";
                dropState.Items.Insert(0, new ListItem("全部", ""));
            }
            else
            {
                dropState.DataSource = null;
                dropState.DataBind();
            }
        }


        /// <summary>
        /// 分页绑定
        /// </summary>
        private void ByPageBind()
        {
            Pager1.RecordCount = con.GetRecordCount(txtCon.Value, txtConName.Value, Start.Value, End.Value, ltlUserID.Text,dropConType.SelectedValue,dropState.SelectedValue);
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
            rptList.DataSource = con.GetListByPage(Pager1.PageSize, Pager1.CurrentPageIndex, txtCon.Value, txtConName.Value, Start.Value, End.Value, ltlUserID.Text,dropConType.SelectedValue,dropState.SelectedValue);
            rptList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ByPageBind();
        }

        protected void Pager1_PageChanged(object sender, EventArgs e)
        {
            GetListBind();
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
            }
            return _name;

        }
    }
}