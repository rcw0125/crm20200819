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
    public partial class MyCon_Sub : System.Web.UI.Page
    {

        private Bll_TMO_CON con = new Bll_TMO_CON();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();

        protected void Page_Load(object sender, EventArgs e)
        {

           

            if (!IsPostBack)
            {
                ViewState["back_no"] = 0;

                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    try
                    {

                        ltlUserID.Text = BaseUser.Id;

                        if(!string.IsNullOrEmpty(Request .QueryString["ID"]))
                        {
                            GetListBind(Request.QueryString["ID"]);
                        }
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

            ViewState["back_no"] = Convert.ToInt32(ViewState["back_no"]) + 1;
        }


        


        /// <summary>
        /// 获取数据列表
        /// </summary>
        private void GetListBind(string conNO)
        {
            DataTable dt = con.GetConListSub(conNO).Tables[0];

            if(dt.Rows.Count>0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
            }
               
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