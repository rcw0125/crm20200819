using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.BLL;
using NF.MODEL;
using NF.Framework;
using NF.NC.Interface;
using NF.DAL;
using System.Data;

namespace CRM.WebForms.Sale_App
{
    public partial class fyd_edit_ch : System.Web.UI.Page
    {

        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlempid.Text = vUser.Id;
                    hidempname.Value = vUser.Name;
                   
                    if (!string.IsNullOrEmpty(Request.QueryString["fyd"]))
                    {
                        GetDic();

                        ltlfyd.Text = Request.QueryString["fyd"];
                        Mod_TMD_DISPATCH mod = tmd_dispatch.GetModel(ltlfyd.Text);
                        txt_CH.Text = mod.C_LIC_PLA_NO;
                        txtfydt.Text = Convert.ToDateTime(mod.D_DISP_DT).ToString("yyy-MM-dd");
                        ltlimport_num.Text = mod.C_EXTEND1.ToString();//记录导入条码系统次数
                        dropfyfs.SelectedIndex = dropfyfs.Items.IndexOf(dropfyfs.Items.FindByValue(mod.C_SHIPVIA));
                        dropcys.SelectedIndex = dropcys.Items.IndexOf(dropcys.Items.FindByValue(mod.C_COMCAR));
                        txtgps.Text = mod.C_GPS_NO;
                        txtdz.Text = mod.C_ATSTATION;
                        txtsjtel.Text = mod.C_EXTEND3;//司机姓名/电话
                        txtkhtel.Text = mod.C_EXTEND4;//客户姓名/电话
                    }
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }

        }

        /// <summary>
        /// 获取数字字典
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private DataTable GetData(string code)
        {
            Mod_TS_DIC moddic = new Mod_TS_DIC();
            moddic.C_TYPECODE = code;
            DataTable dt = ts_dic.GetList(moddic).Tables[0];
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
            }
            else
            {
                dropfyfs.DataSource = null;
                dropfyfs.DataBind();
            }
            #endregion

            #region//承运商
            DataTable dt2 = GetData("TRANCUST");
            if (dt.Rows.Count > 0)
            {

                dropcys.DataSource = dt2;
                dropcys.DataTextField = "C_DETAILNAME";
                dropcys.DataValueField = "C_DETAILCODE";
                dropcys.DataBind();
                dropcys.Items.Insert(0, new ListItem("", ""));
            }
            else
            {
                dropcys.DataSource = null;
                dropcys.DataBind();
            }
            #endregion
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Mod_TMD_DISPATCH mod = new Mod_TMD_DISPATCH();
                mod.C_ID = ltlfyd.Text;
                mod.C_LIC_PLA_NO = txt_CH.Text;
                mod.C_EXTEND2 = txtxnch.Text;
                mod.D_CREATE_DT = Convert.ToDateTime(txtfydt.Text);
                mod.D_DISP_DT = Convert.ToDateTime(txtfydt.Text);
                mod.C_EMP_ID = ltlempid.Text;
                mod.C_EMP_NAME = hidempname.Value;
                mod.C_ATSTATION = txtdz.Text;
                mod.C_GPS_NO = txtgps.Text;//GPS号
                mod.C_SHIPVIA = dropfyfs.SelectedItem.Value;//发运方式
                mod.C_COMCAR = dropcys.SelectedItem.Value;//承运商
                mod.C_EXTEND3 = txtsjtel.Text;//司机姓名/电话
                mod.C_EXTEND4 = txtkhtel.Text;//客户姓名/电话
                if (tmd_dispatch.UpdateFyd_CH(mod))
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('保存成功');</script>", false);

                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }


        private string GetNCError(List<string> arrstr)
        {
            if (arrstr.Count < 2) { return "上传NC失败，请联系管理员"; }
            var result = arrstr[1].Replace("\r\n", "<br/>").Replace("\r", "<br/>").Replace("\n", "<br/>").Replace(" ", "&nbsp;");

            return result;
        }

        protected void btnNC_Click(object sender, EventArgs e)
        {
            string result = "";
            ApiDispatchOrder apifyd = new ApiDispatchOrder();
            string filePath = "~/FileInterface/download/nc_" + ltlfyd.Text + ".xml";
            string xmlFileName = System.Web.HttpContext.Current.Server.MapPath(filePath);
            List<string> resList = apifyd.SendXmlApiDispatchOrder(ltlfyd.Text, xmlFileName, ltlempid.Text, 8);

            string jg = resList[0].ToString() == "1" ? "导入NC成功" : GetNCError(resList);
            result = "单据号：" + ltlfyd.Text + ",结果：" + jg;

            if (resList[0].ToString() == "1")
            {

                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + result + "');</script>", false);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + result + "');</script>", false);

            }
        }

        protected void btnRF_Click(object sender, EventArgs e)
        {


            bool result = tmd_dispatch.UpdateFydRF_Num(ltlfyd.Text, ltlimport_num.Text);

            Dal_Interface_FR dal = new Dal_Interface_FR();
            if (dal.SENDFYD(ltlfyd.Text) > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('导入成功');window.parent.document.getElementById('imgbtnInfo').click();window.parent.close();</script>", false);
                //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('导入成功');window.parent.document.getElementById('txtcph').value='" + txt_CH.Text + "';window.parent.close();</script>", false);

                //Response.Write("<script>alert('导入成功');window.parent.document.getElementById('txtcph').value='" + txt_CH.Text + "';window.parent.close();</script>");

            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('导入失败');</script>", false);
            }
        }
    }
}