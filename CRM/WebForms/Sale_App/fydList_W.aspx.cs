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

namespace CRM.WebForms.Sale_App
{
    public partial class fydList_W : System.Web.UI.Page
    {
        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    DateTime dt = DateTime.Now;
                    txtStart.Value = DateTime.Now.AddDays(-1).ToString("yyy-MM-dd");
                    txtEnd.Value = dt.ToString("yyy-MM-dd");
                    GetDic();
                }
                catch (Exception ex)
                {
                    WebMsg.MessageBox(ex.Message);
                }
            }
        }


        /// 获取数字字典
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private DataTable GetData(string code)
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = code;
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            return dt;
        }

        /// <summary>
        /// 基础数据
        /// </summary>
        private void GetDic()
        {
            #region//发运方式
            DataTable dt = GetData("ShipVia");
            if (dt.Rows.Count > 0)
            {

                dropfyfs.DataSource = dt;
                dropfyfs.DataTextField = "C_DETAILNAME";
                dropfyfs.DataValueField = "C_DETAILCODE";
                dropfyfs.DataBind();
                dropfyfs.Items.Insert(0, new ListItem("全部", ""));
            }
            else
            {
                dropfyfs.DataSource = null;
                dropfyfs.DataBind();
            }
            #endregion
        }

        private void ByPageBind()
        {
            Pager1.RecordCount = tmd_dispatch.GetRecordCount(txtsendcode.Text, txtch.Text, txtcust.Text, txtzdr.Text, dropfyfs.SelectedItem.Value, dropsfxc.SelectedItem.Text, txtStart.Value, txtEnd.Value);
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
        private void GetListBind()
        {
            rptList.DataSource = tmd_dispatch.GetListByPage(Pager1.PageSize, Pager1.CurrentPageIndex, txtsendcode.Text, txtch.Text, txtcust.Text, txtzdr.Text, dropfyfs.SelectedItem.Value, dropsfxc.SelectedItem.Text, txtStart.Value, txtEnd.Value);
            rptList.DataBind();
        }

        /// <summary>
        /// 获取发运单状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public string GetStatus(object status)
        {
            #region //状态
            string result = "";
            switch (status.ToString())
            {
                case "0":
                    result= "自由状态";
                    break;
                case "2":
                    result = "已导入NC";
                    break;
                case "3":
                    result = "已导入条码";
                    break;
                case "4":
                    result = "已导入物流";
                    break;
                case "7":
                    result = "已做实绩";
                    break;
                case "8":
                    result = "实绩已导入NC";
                    break;
                case "9":
                    result = "实绩已导入NC";
                    break;
                case "10":
                    result = "已审核";
                    break;
            }

            return result;


            #endregion
        }

        protected void Pager1_PageChanged(object sender, EventArgs e)
        {
            GetListBind();
        }

        protected void btncx_Click(object sender, EventArgs e)
        {
            ByPageBind();
        }
    }
}