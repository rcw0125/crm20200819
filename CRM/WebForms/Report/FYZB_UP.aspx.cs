using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.IO;
using NF.BLL;
using NF.MODEL;
using NF.Framework;

namespace CRM.WebForms.Report
{
    public partial class FYZB_UP : System.Web.UI.Page
    {
        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtDate.Value = DateTime.Now.ToString("yyy-MM-dd");
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

        //导入
        protected void Button1_Click(object sender, EventArgs e)
        {
            string filetype = Path.GetExtension(file1.PostedFile.FileName);
            if (filetype == ".xls" || filetype == ".xlsx")
            {
                string filename = Path.GetFileNameWithoutExtension(file1.PostedFile.FileName);//文件名；
                string newfilename = filename + DateTime.Now.ToString("yyyyMMdd") + filetype;//+ 
                string savepath = System.Web.HttpContext.Current.Server.MapPath("../../Uploads") + newfilename;
                file1.PostedFile.SaveAs(savepath);

                DataTable dtOrder = ReadExcel(savepath, 0);

                if (dtOrder.Rows.Count > 0)
                {
                    rptList.DataSource = dtOrder;
                    rptList.DataBind();
                   
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<Mod_TMD_FYZB> list = new List<Mod_TMD_FYZB>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    Literal ltlDT = (Literal)rptList.Items[i].FindControl("ltlDT");
                    Literal ltlJT1_DETP = (Literal)rptList.Items[i].FindControl("ltlJT1_DETP");//精特钢销售一部
                    Literal ltlJT2_DEPT = (Literal)rptList.Items[i].FindControl("ltlJT2_DEPT");//精特钢销售二部
                    Literal ltlZCG_DEPT = (Literal)rptList.Items[i].FindControl("ltlZCG_DEPT");//轴承钢销售部
                    Literal ltlTHG_DEPT = (Literal)rptList.Items[i].FindControl("ltlTHG_DEPT");//弹簧钢销售部
                    Literal ltl_CT_DEPT = (Literal)rptList.Items[i].FindControl("ltl_CT_DEPT");//纯铁销售部
                    Literal ltl_CK_DEPT = (Literal)rptList.Items[i].FindControl("ltl_CK_DEPT");//国际贸易部
                    Literal ltl_FCP_DEPT = (Literal)rptList.Items[i].FindControl("ltl_FCP_DEPT");//副产品销售部
                    Literal ltl_BFONE_DEPT = (Literal)rptList.Items[i].FindControl("ltl_BFONE_DEPT");//北方一区
                    Literal ltl_BFTWO_DEPT = (Literal)rptList.Items[i].FindControl("ltl_BFTWO_DEPT");//北方二区
                    Literal ltl_BFPT_DEPT = (Literal)rptList.Items[i].FindControl("ltl_BFPT_DEPT");//北方普碳区域
                    Literal ltl_YX_DEPT = (Literal)rptList.Items[i].FindControl("ltl_YX_DEPT");//硬线区域
                    Literal ltl_SH_DEPT = (Literal)rptList.Items[i].FindControl("ltl_SH_DEPT");//上海区域
                    Literal ltl_HZ_DEPT = (Literal)rptList.Items[i].FindControl("ltl_HZ_DEPT");//杭州区域
                    Literal ltl_NB_DEPT = (Literal)rptList.Items[i].FindControl("ltl_NB_DEPT");//宁波区域
                    Literal ltl_CQ_DEPT = (Literal)rptList.Items[i].FindControl("ltl_CQ_DEPT");//重庆区域
                    Literal ltl_GZ_DEPT = (Literal)rptList.Items[i].FindControl("ltl_GZ_DEPT");//广州区域

                    list.Add(GetMod(ltlDT.Text, ltlJT1_DETP.Text ?? "0", "精特钢销售一部"));
                    list.Add(GetMod(ltlDT.Text, ltlJT2_DEPT.Text ?? "0", "精特钢销售二部"));
                    list.Add(GetMod(ltlDT.Text, ltlZCG_DEPT.Text ?? "0", "轴承钢销售部"));
                    list.Add(GetMod(ltlDT.Text, ltlTHG_DEPT.Text ?? "0", "弹簧钢销售部"));
                    list.Add(GetMod(ltlDT.Text, ltl_CT_DEPT.Text ?? "0", "纯铁销售部"));
                    list.Add(GetMod(ltlDT.Text, ltl_CK_DEPT.Text ?? "0", "国际贸易部"));
                    list.Add(GetMod(ltlDT.Text, ltl_FCP_DEPT.Text ?? "0", "副产品销售部"));
                    list.Add(GetMod(ltlDT.Text, ltl_BFONE_DEPT.Text ?? "0", "北方一区"));
                    list.Add(GetMod(ltlDT.Text, ltl_BFTWO_DEPT.Text ?? "0", "北方二区"));
                    list.Add(GetMod(ltlDT.Text, ltl_BFPT_DEPT.Text ?? "0", "北方普碳区域"));
                    list.Add(GetMod(ltlDT.Text, ltl_YX_DEPT.Text ?? "0", "硬线区域"));
                    list.Add(GetMod(ltlDT.Text, ltl_SH_DEPT.Text ?? "0", "上海区域"));
                    list.Add(GetMod(ltlDT.Text, ltl_HZ_DEPT.Text ?? "0", "杭州区域"));
                    list.Add(GetMod(ltlDT.Text, ltl_NB_DEPT.Text ?? "0", "宁波区域"));
                    list.Add(GetMod(ltlDT.Text, ltl_CQ_DEPT.Text ?? "0", "重庆区域"));
                    list.Add(GetMod(ltlDT.Text, ltl_GZ_DEPT.Text ?? "0", "广州区域"));
                }

                if (tmd_dispatch.InsertFYZB(list))
                {
                    WebMsg.MessageBox("导入成功");
                    
                    rptList.DataSource = null;
                    rptList.DataBind();
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }

        private Mod_TMD_FYZB GetMod(string dt, string wgt, string dept)
        {
            Mod_TMD_FYZB mod = new Mod_TMD_FYZB();
            mod.D_DAY = Convert.ToDateTime(dt);
            mod.C_DEPT = dept;
            mod.N_WGT = Convert.ToDecimal(wgt);
            return mod;
        }

        private void GetList()
        {
            DataTable dt = tmd_dispatch.GetAreaFyZbList(txtDate.Value).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList2.DataSource = dt;
                rptList2.DataBind();
            }
            else
            {
                rptList2.DataSource = null;
                rptList2.DataBind();
            }
        }

        protected void btncx_Click(object sender, EventArgs e)
        {
            GetList();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new List<Mod_TMD_FYZB>();

                for (int i = 0; i < rptList2.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxID = (HtmlInputCheckBox)rptList2.Items[i].FindControl("cbxID");
                    TextBox txtwgt = (TextBox)rptList2.Items[i].FindControl("txtwgt");
                    if (cbxID.Checked)
                    {
                        Mod_TMD_FYZB mod = new Mod_TMD_FYZB();
                        mod.C_ID = cbxID.Value;
                        mod.N_WGT = Convert.ToDecimal(txtwgt.Text ?? "0");
                        list.Add(mod);
                    }
                }

                if (list.Count > 0)
                {
                    if (tmd_dispatch.UpdateAreaFyZb(list,0))
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel2, this.Page.GetType(), "", "alert('保存成功');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel2, this.Page.GetType(), "", "alert('"+ex.Message+"');", true);
            }
            
        }
    }
}