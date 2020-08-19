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
using System.IO;
using Aspose.Cells;

namespace CRM.WebForms.Train
{
    public partial class train_plan_add : System.Web.UI.Page
    {

        private Bll_TMC_TRAIN_ITEM tmc_train_item = new Bll_TMC_TRAIN_ITEM();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");

                BindArea();
            }
        }


        private void BindArea()
        {
            #region //需求区域

            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ConArea";
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropneedarea.DataSource = dt;
                dropneedarea.DataTextField = "C_DETAILNAME";
                dropneedarea.DataValueField = "C_DETAILNAME";
                dropneedarea.DataBind();
            }
            else
            {

                dropneedarea.DataSource = null;
                dropneedarea.DataBind();
            }
            #endregion
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

                var list = new List<Mod_TMC_TRAIN>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    TextBox txttype = (TextBox)rptList.Items[i].FindControl("txttype");
                    TextBox txtcs = (TextBox)rptList.Items[i].FindControl("txtcs");
                    TextBox txtdz = (TextBox)rptList.Items[i].FindControl("txtdz");
                    TextBox txtdj = (TextBox)rptList.Items[i].FindControl("txtdj");
                    TextBox txtplan = (TextBox)rptList.Items[i].FindControl("txtplan");
                    TextBox txtcustname = (TextBox)rptList.Items[i].FindControl("txtcustname");//收货单位
                    TextBox txtarea = (TextBox)rptList.Items[i].FindControl("txtarea");
                    TextBox txtremark = (TextBox)rptList.Items[i].FindControl("txtremark");//专用线
                    TextBox txtdhdw = (TextBox)rptList.Items[i].FindControl("txtdhdw");//订货单位
                    var mod = new Mod_TMC_TRAIN()
                    {
                        C_EMPNAME = vUser.Name,
                        C_FLAG = txttype.Text,
                        N_TRAIN_NUM = Convert.ToDecimal(txtcs.Text),
                        C_STATION = txtdz.Text,
                        C_STATION_J = txtdj.Text,
                        C_PLANNO = txtplan.Text,
                        D_MONTH = Convert.ToDateTime(txtStart.Value),
                        C_CUSTNAME = txtcustname.Text,
                        C_CUSTNO = txtdhdw.Text,
                        C_AREA = txtarea.Text == "" ? dropneedarea.SelectedValue : txtarea.Text,
                        C_REMARK = txtremark.Text,
                        C_TYPE = droptype.SelectedValue
                    };
                    list.Add(mod);
                }
                if (tmc_train_item.AddTrainPlan(list))
                {
                    WebMsg.MessageBox("保存成功");

                    rptList.DataSource = null;
                    rptList.DataBind();
                }

            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }
        }


        /// <summary>
        /// 导入Excel文件
        /// </summary>
        /// <param name="strFileName">文件地址</param>
        /// <returns></returns>
        private DataTable ReadExcel(String strFileName, int index)
        {
            Workbook book = new Workbook(strFileName);

            Worksheet sheet = book.Worksheets[index];
            Cells cells = sheet.Cells;

            return cells.ExportDataTableAsString(0, 0, cells.MaxDataRow + 1, cells.MaxDataColumn + 1, true);
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            string filetype = Path.GetExtension(file1.PostedFile.FileName);
            if (filetype == ".xls" || filetype == ".xlsx")
            {
                string filename = Path.GetFileNameWithoutExtension(file1.PostedFile.FileName);//文件名；
                string newfilename = filename + DateTime.Now.ToString("yyyyMMdd") + filetype;//+ 
                string savepath = System.Web.HttpContext.Current.Server.MapPath("../../Uploads") + newfilename;
                file1.PostedFile.SaveAs(savepath);

                DataTable dt = ReadExcel(savepath, 0);

                if (dt.Rows.Count > 0)
                {
                    rptList.DataSource = dt;
                    rptList.DataBind();

                }
            }
        }
    }
}