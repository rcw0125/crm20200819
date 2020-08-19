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
using CRM.Common;

namespace CRM.WebForms.Sale_App
{
    public partial class fydList_WL : System.Web.UI.Page
    {
        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();

        private static DataTable dtOrderEx = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    DateTime dt = DateTime.Now;
                    txtStart.Value = dt.AddDays(-1).ToString("yyy-MM-dd");
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

        private void GetListBind()
        {
            DataTable dt = tmd_dispatch.GetList_WL(txtsendcode.Text, txtch.Text, txtcust.Text, txtzdr.Text, dropfyfs.SelectedItem.Value, dropsfxc.SelectedItem.Text, txtStart.Value, txtEnd.Value,"1","Y").Tables[0];
            if (dt.Rows.Count > 0)
            {
                dtOrderEx = dt;
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
                    result = "自由状态";
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

        protected void btncx_Click(object sender, EventArgs e)
        {
            GetListBind();
        }

        //导出文件

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (dtOrderEx.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("C_ID", "发运单据号 ");
                dic.Add("c_con_no", "合同号 ");
                //dic.Add("D_DISP_DT", "发运日期");
                dic.Add("C_IS_WIRESALE", "是否线材销售");
                dic.Add("C_LIC_PLA_NO", "车牌号");
                dic.Add("C_EXTEND2", "虚拟车号");
                dic.Add("C_ATSTATION", "到站");
                dic.Add("C_GPS_NO", "GPS号");
                dic.Add("C_ORGO_CUST", "客户");
                dic.Add("C_EMP_NAME", "最后修改人");
                //dic.Add("D_MOD_DT", "最后修改时间");
                //dic.Add("C_STATUS", "状态");
                // dic.Add("D_CREATE_DT", "制单日期");
                dic.Add("C_CREATE_ID", "制单人");
                dic.Add("C_SHIPVIA", "发运方式");
                dic.Add("C_COMCAR", "承运商");
                dic.Add("C_EXTEND3", "司机姓名");
                dic.Add("C_EXTEND4", "司机电话");

                ExportHelper.BudgetExport(dtOrderEx, dic, "发运单", Response);
                dtOrderEx = null;
            }
        }
    }
}