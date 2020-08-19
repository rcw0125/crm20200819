using NF.BLL;
using NF.Framework;
using NF.MODEL;
using NF.MODEL.D;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CRM.WebForms.PCI
{
    public partial class GPFYD2 : System.Web.UI.Page
    {
        Bll_TMD_DISPATCH bll_TMD_DISPATCH = new Bll_TMD_DISPATCH();
        Bll_TSC_SLAB_MAIN bll_TSC_SLAB_MAIN = new Bll_TSC_SLAB_MAIN();
        Bll_Interface_WL bll_Interface_WL = new Bll_Interface_WL();
        Bll_TMD_GPFY_LOG bll_TMD_GPFY_LOG = new Bll_TMD_GPFY_LOG();
        public static CurrentUser vUser =new CurrentUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    try
                    {
                        txtBegTime.Text = DateTime.Now.AddDays(-1).ToString("yyy-MM-dd");
                        txtEndTime.Text = DateTime.Now.AddDays(1).ToString("yyy-MM-dd");
                        txtFYSJ.Text = DateTime.Now.ToString();
                        // InitCK();
                    }
                    catch (Exception ex)
                    {
                        WebMsg.MessageBox(ex.Message);
                    }
                }
                else
                {
                    //WebMsg.CheckUserLogin();
                }
            }
            
        }

        protected void btncx_Click(object sender, EventArgs e)
        {
            Query();
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
        }
        private void Query()
        {
            try
            {
                string status = "";
                string movetype = "";
                if (ddlIsDo.SelectedValue == "0")
                {
                    status = "4";
                    movetype = "E";
                }
                else
                if (ddlIsDo.SelectedValue == "1")
                {
                    status = "7";
                    movetype = "1";
                }
                else
                {
                    status = "9";
                    movetype = "S";
                }
                DataTable dt = null;
                dt = bll_TMD_DISPATCH.GetFYDList(txtFYD.Text.Trim(), DateTime.Parse(txtBegTime.Text), DateTime.Parse(txtEndTime.Text), status, txtcph.Text.Trim(), movetype).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    rptList.DataSource = dt;
                    rptList.DataBind();
                    rptcs.Text= dt.Compute("count(C_LIC_PLA_NO)", "true").ToString();
                    rptHjWgt.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                    rptHjCount.Text = dt.Compute("sum(N_NUM)", "true").ToString();
                    rptHjJz.Text = dt.Compute("sum(N_JWGT)", "true").ToString();
                }
                else
                {
                    rptcs.Text = "";
                    rptHjWgt.Text = "";
                    rptHjCount.Text = "";
                    rptHjJz.Text = "";
                    rptList.DataSource = null;
                    rptList.DataBind();
                    txtFYD.Text = "";
                }
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.ToString());
            }
        }

        protected void btncxRight_Click(object sender, EventArgs e)
        {
            Detail();
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
        }
        private void Detail()
        {
            try
            {
                if (lblStockCode.Text == "")
                {
                    return;
                }
                DataTable dt = null;
                dt = bll_TSC_SLAB_MAIN.GetList("E", txtLH.Text.Trim(), lblmat.Text, lblCStdCode.Text, lblStockCode.Text, txtKPH.Text.Trim(), lblZLDJ.Text.Trim(),lblzyx1.Text,lblzyx2.Text).Tables[0];
                rptListRight.DataSource = dt;
                rptListRight.DataBind();
                if (dt.Rows.Count > 0)
                {
                    rptRigthHjZS.Text = dt.Compute("sum(N_QUA)", "true").ToString();
                    rptRigthHjZL.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                }
                else
                {
                    rptRigthHjZS.Text = "";
                    rptRigthHjZL.Text = "";
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.ToString());
            }
        }

        protected void btnFSSJ_Click1(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(hidCID.Text))
            {
                string msg = "未选中发运单！";
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + msg + "');</script>", false);
                return;
            }
            string itemid = ltlempid.Text;
            string fydstr = hidCID.Text;
            string num = hidNum.Text;
            string sjnum = hidSJSL.Text;
            if (bll_Interface_WL.GetFYDZT(fydstr) != "4")
            {
                string msg = "该发运单状态已变更！";
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + msg + "');</script>", false);
                Query();
                return;
            }
            if (sjnum == "")
            {
                sjnum = "0";
            }
            int sjzs = 0;
            var list = new List<CommonKC>();
            for (int i = 0; i < rptListRight.Items.Count; i++)
            {
                HtmlInputCheckBox chkMat_Code = (HtmlInputCheckBox)rptListRight.Items[i].FindControl("cbxselect");
                TextBox lstSNum = (TextBox)rptListRight.Items[i].FindControl("lstSNum");
                Literal lstQua = (Literal)rptListRight.Items[i].FindControl("lstQua");
                Literal lstMatCode = (Literal)rptListRight.Items[i].FindControl("lstMatCode");
                Literal lstSlabCode = (Literal)rptListRight.Items[i].FindControl("lstSlabCode");
                Literal lstStove = (Literal)rptListRight.Items[i].FindControl("lstStove");
                Literal lstBatchNo = (Literal)rptListRight.Items[i].FindControl("lstBatchNo");
                Literal lstLevZh = (Literal)rptListRight.Items[i].FindControl("lstLevZh");
                Literal lstGrd = (Literal)rptListRight.Items[i].FindControl("lstGrd");
                Literal lstStdCode = (Literal)rptListRight.Items[i].FindControl("lstStdCode");
                Literal LstSpec = (Literal)rptListRight.Items[i].FindControl("LstSpec");
                Literal lstfydh= (Literal)rptListRight.Items[i].FindControl("lstfydh");
                if (chkMat_Code.Checked)
                {
                    int szs = bll_TSC_SLAB_MAIN.CKKC(lstMatCode.Text, lstSlabCode.Text, "", "", lstStove.Text, lstBatchNo.Text, lstLevZh.Text);
                    if (int.Parse(lstQua.Text) != szs)//验证数量
                    {

                        string msg = "批号：" + lstBatchNo.Text + "库存数量已变更！";
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + msg + "');</script>", false);
                        return;
                    }
                    if (int.Parse(lstQua.Text) < int.Parse(lstSNum.Text))
                    {
                        string msg = "数量超出请修改！";
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + msg + "');</script>", false);
                        return;
                    }
                    sjzs += int.Parse(lstSNum.Text);
                    list.Add(new CommonKC()
                    {
                        id = itemid,
                        batch = lstBatchNo.Text,
                        ck = lstSlabCode.Text,
                        mat = lstMatCode.Text,
                        num = int.Parse(lstSNum.Text),
                        stove = lstStove.Text,
                        zldj = lstLevZh.Text
                    });
                    Mod_TMD_GPFY_LOG mod = new Mod_TMD_GPFY_LOG();
                    mod.C_BATCH_NO = lstBatchNo.Text;
                    mod.C_EMP_ID = vUser.Account;
                    mod.N_NUM = int.Parse(lstSNum.Text);
                    mod.C_FYDH = fydstr;
                    mod.C_LIC_PLA_NO = rptcph.Text;
                    mod.C_SEND_STOCK = lstSlabCode.Text;
                    mod.C_BZYQ = lstBatchNo.Text;
                    mod.C_SPEC = LstSpec.Text;
                    mod.C_STD_CODE = lstStdCode.Text;
                    mod.C_STL_GRD = lstGrd.Text;
                    mod.C_STOVE = lstStove.Text;
                    mod.C_TYPE = "发送实绩";
                    mod.C_ZLDJ = lstLevZh.Text;
                    bll_TMD_GPFY_LOG.Add(mod);
                }
                //else
                //{
                //    string msg = "未选中实绩行！";
                //    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + msg + "');</script>", false);
                //    return;
                //}
            }
            if (bll_TMD_DISPATCH.UPFYD("",vUser.Id,vUser.Name,fydstr)!=1)
            {
                string msg = "变更发运单状态错误！";
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + msg + "');</script>", false);
                return;
            }
            if (bll_TSC_SLAB_MAIN.UPSLABSTATUS(list, fydstr, "1") != 1)
            {
                string msg = "实绩标记失败！";
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + msg + "');</script>", false);
                return;
            }
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('实绩标记成功！');</script>", false);
            //hidCID.Text = "";
            //rptcph.Text = "";
            //rptdqcph.Text = "";
            Detail();
            Query();
            SJQuery();

        }
        protected void btncx3_Click(object sender, EventArgs e)
        {
            SJQuery();
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
        }
        private void SJQuery()
        {
            try
            {
                string status = "";
                if (ddlIsDo1.SelectedValue == "0")
                {
                    status = "4";
                }
                else if(ddlIsDo1.SelectedValue == "1")
                {
                    status = "7";
                }
                else
                {
                    status = "9";
                }
                DataTable dt = null;
               dt = bll_TSC_SLAB_MAIN.GetListByFYDH(txtFYDH.Text.Trim(), "", txtLH2.Text.Trim(), txtKPH2.Text.Trim(), txtck.Text.Trim(), txtGZ.Text.Trim(), txtcph2.Text, status).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    rptList2.DataSource = dt;
                    rptList2.DataBind();

                    rpt2HjZS.Text = dt.Compute("sum(N_QUA)", "true").ToString();
                    rpt2HjZL.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                }
                else
                {
                    rptList2.DataSource = null;
                    rptList2.DataBind();
                    txtLH2.Text = "";
                    txtKPH2.Text = "";
                    rpt2HjZS.Text = "";
                    rpt2HjZL.Text = "";
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.ToString());
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < rptList2.Items.Count; i++)
            {
                HtmlInputCheckBox chkMat_Code = (HtmlInputCheckBox)rptList2.Items[i].FindControl("cbsj");
                if (chkMat_Code.Checked)
                {

                    Literal lstcph = (Literal)rptList2.Items[i].FindControl("lstcph");
                    Literal lstfyid = (Literal)rptList2.Items[i].FindControl("lstfyid");
                    Literal lstfydh = (Literal)rptList2.Items[i].FindControl("lstfydh");
                    Literal lstQua = (Literal)rptList2.Items[i].FindControl("lstqua");
                    Literal lstSlabCode = (Literal)rptList2.Items[i].FindControl("lstck");
                    Literal lstStove = (Literal)rptList2.Items[i].FindControl("lststove");
                    Literal lstBatchNo = (Literal)rptList2.Items[i].FindControl("lstbatchNo");
                    Literal lstLevZh = (Literal)rptList2.Items[i].FindControl("lstzldj");
                    Literal lstGrd = (Literal)rptList2.Items[i].FindControl("lstgrd");
                    Literal lstStdCode = (Literal)rptList2.Items[i].FindControl("lststd");
                    Literal LstSpec = (Literal)rptList2.Items[i].FindControl("lstspec");
                    bll_TMD_DISPATCH.UPFYD("4", vUser.Id, vUser.Name, lstfydh.Text);
                    bll_Interface_WL.DELFYD(lstfydh.Text);
                    bll_Interface_WL.UPSLABSTATUS(lstfyid.Text, "E");
                    Mod_TMD_GPFY_LOG mod = new Mod_TMD_GPFY_LOG();
                    mod.C_BATCH_NO = lstBatchNo == null ? "" : lstBatchNo.Text;
                    mod.C_EMP_ID = vUser.Account;
                    mod.C_FYDH = lstfydh.Text;
                    mod.C_LIC_PLA_NO = lstcph.Text;
                    mod.C_SEND_STOCK = lstSlabCode.Text;
                    mod.C_SPEC = LstSpec.Text;
                    mod.C_STD_CODE = lstStdCode.Text;
                    mod.C_STL_GRD = lstGrd.Text;
                    mod.C_STOVE = lstStove.Text;
                    mod.C_TYPE = "取消实绩";
                    mod.C_ZLDJ = lstLevZh.Text;
                    mod.N_NUM = int.Parse(lstQua.Text);
                    bll_TMD_GPFY_LOG.Add(mod);
                }
                //else
                //{
                //    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('未选中实绩行');</script>", false);
                //    return;
                //}
            }
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('取消标记完成');</script>", false);
            Query();
            Detail();
            SJQuery();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptList2.Items.Count; i++)
            {
                HtmlInputCheckBox chkMat_Code = (HtmlInputCheckBox)rptList2.Items[i].FindControl("cbsj");
                if (chkMat_Code.Checked)
                {

                    Literal lstcph = (Literal)rptList2.Items[i].FindControl("lstcph");
                    Literal lstfyid = (Literal)rptList2.Items[i].FindControl("lstfyid");
                    Literal lstfydh = (Literal)rptList2.Items[i].FindControl("lstfydh");
                    Literal lstQua = (Literal)rptList2.Items[i].FindControl("lstqua");
                    Literal lstSlabCode = (Literal)rptList2.Items[i].FindControl("lstck");
                    Literal lstStove = (Literal)rptList2.Items[i].FindControl("lststove");
                    Literal lstBatchNo = (Literal)rptList2.Items[i].FindControl("lstbatchNo");
                    Literal lstLevZh = (Literal)rptList2.Items[i].FindControl("lstzldj");
                    Literal lstGrd = (Literal)rptList2.Items[i].FindControl("lstgrd");
                    Literal lstStdCode = (Literal)rptList2.Items[i].FindControl("lststd");
                    Literal LstSpec = (Literal)rptList2.Items[i].FindControl("lstspec");
                    Mod_TMD_DISPATCH mod_TMD_DISPATCH = bll_TMD_DISPATCH.GetModel(lstfydh.Text);
                    if (mod_TMD_DISPATCH.C_STATUS == "7")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('实绩已确认不能再次确认');</script>", false);
                        return;
                    }
                    bll_TMD_DISPATCH.UPFYD("7", vUser.Id, vUser.Name, lstfydh.Text);
                    string msg = bll_Interface_WL.ADDFYDToZJB(lstfydh.Text, Convert.ToDateTime(txtFYSJ.Text));
                    if (msg != "1")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + msg + "');</script>", false);
                        return;
                    }
                    Mod_TMD_GPFY_LOG mod = new Mod_TMD_GPFY_LOG();
                    mod.C_EMP_ID = vUser.Account;
                    mod.C_FYDH = lstfydh.Text;
                    mod.C_LIC_PLA_NO = lstcph.Text;
                    mod.C_TYPE = "确认实绩";
                    bll_TMD_GPFY_LOG.Add(mod);
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('实绩已确认');</script>", false);
                    Query();
                    Detail();
                    SJQuery();
                    return;
                }
                //else
                //{
                //    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('未选中实绩行');</script>", false);
                //    return;
                //}
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFYSJ.Text))
            {
                string msg = "发运时间不能为空！";
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + msg + "');</script>", false);
                return;
            }
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (string.IsNullOrEmpty(lblmat.Text))
            {
                string msg = "未选中发运单！";
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + msg + "');</script>", false);
                return;
            }
            string fydstr = hidCID.Text;//发运单号
            string jz = hidJwgt.Text;//净重
            string num = hidNum.Text;//数量
            if (jz == null || jz == "")
            {
                string msg = "该发运单净重未导入！";
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + msg + "');</script>", false);
                return;
            }
            if (bll_Interface_WL.GetFYDZT(fydstr) != "7")
            {
                Query();
                string msg = "该发运单未做实绩或发运单状态已改变！";
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + msg + "');</script>", false);
                return;
            }
            //decimal wgt = Convert.ToDecimal(jz) / Convert.ToDecimal(num);
            //DataTable dt = bll_TSC_SLAB_MAIN.GetListByFYDH(fydstr, "1", "", "", "", "", "", "").Tables[0];
            //if (dt.Rows.Count != bll_TSC_SLAB_MAIN.GetJHCount(fydstr))
            //{
            //    SJQuery();
            //    string msg = "异常！钢坯实绩数量与计划数量不符！";
            //    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + msg + "');</script>", false);
            //    return;
            //}

            string filePath = "~/FileInterface/download/GPSJ" + fydstr + ".xml";

            string xmlFileName = Server.MapPath(filePath);
            string message = bll_Interface_WL.SENDFYD(fydstr, xmlFileName);//待测试
            if (message != "1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + message + "');</script>", false);
                return;
            }
            bll_TMD_DISPATCH.UPFYD("9", vUser.Id, vUser.Name, fydstr);
            for (int i = 0; i < rptList2.Items.Count; i++)
            {
                HtmlInputCheckBox chkMat_Code = (HtmlInputCheckBox)rptList2.Items[i].FindControl("cbsj");
                if (chkMat_Code.Checked)
                {
                    Literal lstcph = (Literal)rptList2.Items[i].FindControl("lstcph");
                    Literal lstfyid = (Literal)rptList2.Items[i].FindControl("lstfyid");
                    Literal lstfydh = (Literal)rptList2.Items[i].FindControl("lstfydh");
                    Literal lstQua = (Literal)rptList2.Items[i].FindControl("lstqua");
                    Literal lstSlabCode = (Literal)rptList2.Items[i].FindControl("lstck");
                    Literal lstStove = (Literal)rptList2.Items[i].FindControl("lststove");
                    Literal lstBatchNo = (Literal)rptList2.Items[i].FindControl("lstbatchNo");
                    Literal lstLevZh = (Literal)rptList2.Items[i].FindControl("lstzldj");
                    Literal lstGrd = (Literal)rptList2.Items[i].FindControl("lstgrd");
                    Literal lstStdCode = (Literal)rptList2.Items[i].FindControl("lststd");
                    Literal LstSpec = (Literal)rptList2.Items[i].FindControl("lstspec");
                    Mod_TMD_GPFY_LOG mod = new Mod_TMD_GPFY_LOG();
                    mod.C_EMP_ID = vUser.Account;
                    mod.C_FYDH = lstfydh.Text;
                    mod.C_LIC_PLA_NO = lstcph.Text;
                    mod.C_TYPE = "发送NC";
                    bll_TMD_GPFY_LOG.Add(mod);
                }
                //else
                //{
                //    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('未选中实绩行');</script>", false);
                //    return;
                //}
            }
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('上传成功！');</script>", false);
            Query();
            Detail();
            SJQuery();
        }
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "xc")
            {
                rptcph.Text = ((Literal)e.Item.FindControl("rptlstcph")).Text;
                txtFYDH.Text = ((Literal)e.Item.FindControl("rptLstCID")).Text;
                txtcph2.Text = ((Literal)e.Item.FindControl("rptlstcph")).Text;
                ltlempid.Text = ((Literal)e.Item.FindControl("rptLstITEMID")).Text;
                lblmat.Text = ((Literal)e.Item.FindControl("rptlstmat")).Text;
                lblZLDJ.Text = ((Literal)e.Item.FindControl("rptlstzldj")).Text;
                lblCStdCode.Text = ((Literal)e.Item.FindControl("rptlstStdCode")).Text;
                lblzyx1.Text = ((Literal)e.Item.FindControl("rptzyx1")).Text;
                lblzyx2.Text = ((Literal)e.Item.FindControl("rptzyx2")).Text;
                lblStockCode.Text = ((Literal)e.Item.FindControl("rptlstStock")).Text;
                hidCID.Text = ((Literal)e.Item.FindControl("rptLstCID")).Text;
                hidNum.Text = ((Literal)e.Item.FindControl("rptlstNum")).Text;
                hidSJSL.Text = ((Literal)e.Item.FindControl("rptlstSjsj")).Text;
                hidJwgt.Text = ((Literal)e.Item.FindControl("rptlstJwgt")).Text;

                ddlIsDo1.SelectedIndex = ddlIsDo1.Items.IndexOf(ddlIsDo1.Items.FindByText(((Literal)e.Item.FindControl("Literal2")).Text));

                Detail();
                SJQuery();
            }
        }

        protected void rptList2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //Literal lstStatus = (Literal)e.Item.FindControl("lstStatus");
            //HtmlInputCheckBox cbsj = (HtmlInputCheckBox)e.Item.FindControl("cbsj");
            //if (lstStatus.Text == "已做实绩")
            //{
            //    cbsj.Visible = true;
            //}
            //else
            //{
            //    cbsj.Visible = false;
            //}
        }
    }
}