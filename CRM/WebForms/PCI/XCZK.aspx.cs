using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using NF.BLL;
using NF.MODEL;
using NF.Framework;

namespace CRM.WebForms.PCI
{
    public partial class XCZK : System.Web.UI.Page
    {
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        Bll_TRC_ROLL_PRODCUT bll_TRC_ROLL_PRODCUT = new Bll_TRC_ROLL_PRODCUT();
        Bll_Interface_FR bll_Interface_FR = new Bll_Interface_FR();
        Bll_TPB_LINEWH bll_TPB_LINEWH = new Bll_TPB_LINEWH();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    try
                    {
                        txtzdrq.Text = DateTime.Now.ToString("yyyy-MM-dd");
                        ltlempid.Text = vUser.Id;
                        initCK();

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
        private void GetList()
        {
            DataTable dt = null;
            dt = bll_TRC_ROLL_PRODCUT.GetXCKC1( txtPiHao.Text.Trim(),txtGangZhong.Text.Trim(), txtZXBZ.Text.Trim(),this.ck.Text.Trim(), "", "", "E", "", "",this.ddlsfdp.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptSL.Text = dt.Compute("sum(N_NUM)", "true").ToString();
                rptZL.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                rptList.DataSource = dt;
                rptList.DataBind();
            }
            else
            {
                rptSL.Text = "";
                rptZL.Text = "";
                rptList.DataSource = null;
                rptList.DataBind();
                txtPiHao.Text = "";
                txtGangZhong.Text = "";
                txtZXBZ.Text = "";
            }
        }
        private void ZKQuery()
        {
            try
            {
                DataTable dt = null;
                dt = bll_Interface_FR.GetZKDList(txtZKD.Text.Trim(),txtck.Text.Trim(),txtMBCK.Text.Trim(), txtGangZhong2.Text.Trim(), txtPiHao2.Text.Trim(),ddlsfdp2.SelectedValue,ddlzt.SelectedValue,txtzdrq.Text).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    rptZKSL.Text = dt.Compute("sum(N_NUM)", "true").ToString();
                    rptZKZL.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                }
                else
                {
                    rptZKSL.Text = "";
                    rptZKZL.Text = "";
                }
                rptList2.DataSource = dt;
                rptList2.DataBind();
            }
            catch (Exception ex)
            {
                rptList2.DataSource = null;
                rptList2.DataBind();
                txtPiHao2.Text = "";
                txtZXBZ2.Text = "";
                txtZKD.Text = "";
            }
        }
        private void initCK()
        {
            ddlCangKu.Items.Clear();
            ddlCangKu2.Items.Clear();
            ddlCangKu.Items.Add(new ListItem("",""));
            DataTable dt = bll_TPB_LINEWH.GetListByStatus(1).Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddlCangKu.Items.Add(new ListItem( dt.Rows[i]["C_LINEWH_NAME"].ToString() + "(" + dt.Rows[i]["C_LINEWH_CODE"].ToString() + ")", dt.Rows[i]["C_LINEWH_CODE"].ToString()));
                    ddlCangKu2.Items.Add(new ListItem(dt.Rows[i]["C_LINEWH_NAME"].ToString() + "(" + dt.Rows[i]["C_LINEWH_CODE"].ToString() + ")", dt.Rows[i]["C_LINEWH_CODE"].ToString()));
                }
            }           
        }

        protected void btncx_Click(object sender, EventArgs e)
        {           
            GetList();
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
        }
        /// <summary>
        /// 转运单查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCX2_Click(object sender, EventArgs e)
        {
            ZKQuery();
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
        }
        /// <summary>
        /// 撤回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRevoke_Click(object sender, EventArgs e)
        {

            try
            {
                var list = new List<CommonKC>();
                for (int i = 0; i < rptList2.Items.Count; i++)
                {
                    HtmlInputRadioButton rdoselect = (HtmlInputRadioButton)rptList2.Items[i].FindControl("rdoselect");
                    if (rdoselect.Checked)
                    {
                        string idstr = rdoselect.Value;
                        if (bll_Interface_FR.CXZKDByDH(idstr) > 0)
                        {
                            GetList();
                            ZKQuery();
                            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('撤销成功!');</script>", false);
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('撤销失败,条码已读取！');</script>", false);
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('"+ex.ToString()+"');</script>", false);
            }
        }
        /// <summary>
        /// 转库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtZK_Click(object sender, EventArgs e)
        {
            var list= new List<CommonKC>();
            string code = "";
            string code1 = "";
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox chkMat_Code = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                Literal lblBatchNo = (Literal)rptList.Items[i].FindControl("lblBatchNo");
                Literal lblGrd = (Literal)rptList.Items[i].FindControl("lblGrd");
                Literal lblStdCode = (Literal)rptList.Items[i].FindControl("lblStdCode");
                Literal lblSpec = (Literal)rptList.Items[i].FindControl("lblSpec");
                Literal lblLevBP = (Literal)rptList.Items[i].FindControl("lblLevBP");
                Literal lblLevZH = (Literal)rptList.Items[i].FindControl("lblLevZH");
                Literal lblBZYQ = (Literal)rptList.Items[i].FindControl("lblBZYQ");
                Literal lblNum = (Literal)rptList.Items[i].FindControl("lblNum");
                Literal lblWGT = (Literal)rptList.Items[i].FindControl("lblWGT");
                Literal lblLineCode = (Literal)rptList.Items[i].FindControl("lblLineCode");
                Literal lblMatCode = (Literal)rptList.Items[i].FindControl("lblMatCode");
                TextBox lblSNum = (TextBox)rptList.Items[i].FindControl("lblSNum");
                if (chkMat_Code.Checked)
                {
                    if (code =="")
                    {
                        code = lblLineCode.Text;
                    }
                    else
                    {
                        code1 = lblLineCode.Text;
                        if (code != code1)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('仓库不一致！');</script>", false);
                            return;
                        }
                    }
                    if (lblLineCode.Text== ddlCangKu2.Text)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('不能库内转库!');</script>", false);
                        return;
                    }
                    var _num = int.Parse(lblNum.Text);
                    int sjzs = bll_Interface_FR.CKKC(lblMatCode.Text, lblLineCode.Text, lblBatchNo.Text, lblLevZH.Text, lblBZYQ.Text, lblLevBP.Text);
                    if (_num != sjzs)//验证数量
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('批号：" + lblBatchNo.Text + "库存数量已变更！');</script>", false);
                        return;
                    }
                    if (_num < int.Parse(lblSNum.Text))
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('数量超出请修改！');</script>", false);
                        return;
                    }
                    list.Add(new CommonKC()
                    {
                        mat = lblMatCode.Text,
                        num = int.Parse(lblSNum.Text),
                        ck = lblLineCode.Text,
                        zldj = lblLevZH.Text,
                        bpdj= lblLevBP.Text,
                        bzyq = lblBZYQ.Text,
                        batch = lblBatchNo.Text
                    });

                }
            }
            string zkd = DateTime.Now.Year.ToString().Substring(2,2) + (Convert.ToInt32(DateTime.Now.Month) > 9 ? DateTime.Now.Month.ToString() : ("0" + DateTime.Now.Month.ToString())) + (Convert.ToInt32(DateTime.Now.Day) > 9 ? DateTime.Now.Day.ToString() : ("0" + DateTime.Now.Day.ToString()));//转库单号
            string maxzkd = bll_Interface_FR.GetZKDNO(zkd);//查询当天最大转库单号
            long no = 0;
            if (maxzkd == "0")
            {
                no = Convert.ToInt64(zkd + "0001");
            }
            else
            {
                no = Convert.ToInt64(maxzkd.Substring(2, maxzkd.Length - 2)) + 1;
            }
            zkd = "ZK" + no;
            if (list.Any())
            {
                var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                string message = bll_Interface_FR.SENDZKD1(list, ddlCangKu2.SelectedValue.ToString(), zkd, user.Id, user.Account);
                if (message == "1")
                {
                    GetList();
                    ZKQuery();
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('发送成功！');</script>", false);
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('"+ message + "');</script>", false);
                    return;
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
            }
            
        }
    }
}