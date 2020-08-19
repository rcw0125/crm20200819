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
                    try
                    {

                        ltlUserID.Text = BaseUser.Id;

                        DateTime dt = DateTime.Now;
                        Start.Value = dt.AddMonths(-3).ToString("yyy-MM-dd");
                        End.Value = dt.ToString("yyy-MM-dd");
                        BindContractType();
                    }
                    catch (Exception ex)
                    {
                        WebMsg.MessageBox(ex.Message);
                    }

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
                dropConType.DataValueField = "C_ID";
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
        /// 获取数据列表
        /// </summary>
        private void GetListBind()
        {
            DataTable dt = con.GetConList(txtCon.Value, txtConName.Value, Start.Value, End.Value, ltlUserID.Text, dropConType.SelectedValue,"").Tables[0];

            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = dt.DefaultView;
            Pager1.RecordCount = ps.Count;
            if (Pager1.RecordCount > 0)
            {
                ps.AllowPaging = true;
                ps.PageSize = Pager1.PageSize;
                ps.CurrentPageIndex = Pager1.CurrentPageIndex - 1;

                rptList.DataSource = ps;
                rptList.DataBind();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
            }
               
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetListBind();
        }

        protected void Pager1_PageChanged(object sender, EventArgs e)
        {
            GetListBind();
        }

        /// <summary>
        /// 获取数字字典名称
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public string  GetDic(object id)
        {
            string str;
            Mod_TS_DIC mod = ts_dic.GetModel(id.ToString ());
            str = mod.C_DETAILNAME;
            return str;
        }
    }
}