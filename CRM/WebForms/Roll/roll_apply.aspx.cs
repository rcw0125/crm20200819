using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using NF.BLL;
using NF.MODEL;
using NF.Framework;
using System.Data;

namespace CRM.WebForms.Roll
{
    public partial class roll_apply : System.Web.UI.Page
    {

        private Bll_TMC_ROLL_APPLY tmc_roll_apply = new Bll_TMC_ROLL_APPLY();
        private Bll_TMC_ROLL_APPLY_ITEM tmc_roll_apply_item = new Bll_TMC_ROLL_APPLY_ITEM();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    hid.Value = Request.QueryString["ID"];

                    Mod_TMC_ROLL_APPLY mod = tmc_roll_apply.GetModel(hid.Value);
                    if (mod != null)
                    {

                        txtEmpName.Text = mod.C_EMPNAME;
                        ltlcheckstate.Text = GetState(mod.C_STATUS);
                        ltldate.Text = mod.D_MOD.ToString();

                        #region //按钮

                        string[] zt = { "-1", "0" };

                        if (zt.Contains(mod.C_STATUS))
                        {
                            btnCheck.Enabled = true;
                            btnDel.Enabled = true;
                            btnDelAll.Enabled = true;
                            btnXC.Disabled = false;
                        }
                        else
                        {
                            btnCheck.Enabled = false;
                            btnDel.Enabled = false;
                            btnDelAll.Enabled = false;
                            btnXC.Disabled = true;
                        }

                        #endregion

                        GetList();
                    }
                }
            }

        }

        private void GetList()
        {
            string strSql = $@" C_PKID='{hid.Value}'";
            DataTable dt = tmc_roll_apply_item.GetList(strSql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();

                ltlsumwgt.Text = dt.Compute("sum(C_WGT)", "true").ToString();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                ltlsumwgt.Text = "";
            }
        }

        private string GetState(string state)
        {
            string res = string.Empty;
            switch (state)
            {
                case "-1":
                    res = "未提交";
                    break;
                case "0":
                    res = "待处理";
                    break;
                case "1":
                    res = "审批中";
                    break;
                case "2":
                    res = "已完成";
                    break;
            }
            return res;
        }

        protected void imgbtnJz_Click(object sender, ImageClickEventArgs e)
        {
            GetList();
        }

        //删除全部
        protected void btnDelAll_Click(object sender, EventArgs e)
        {
            if (tmc_roll_apply.Delete(hid.Value))
            {
                WebMsg.MessageBox("删除成功", "myRoll.aspx");
            }
        }

        //删除行
        protected void btnDel_Click(object sender, EventArgs e)
        {

            List<Mod_TMC_ROLL_APPLY_ITEM> list = new List<Mod_TMC_ROLL_APPLY_ITEM>();

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                if (cbxselect.Checked)
                {
                    var mod = new Mod_TMC_ROLL_APPLY_ITEM()
                    {
                        C_ID = cbxselect.Value
                    };

                    list.Add(mod);
                }
            }
            if (tmc_roll_apply_item.DelList(list))
            {
                GetList();
            }
        }


        //送审

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            bool result = true;//判断当前发运数量已超出可发运量
            string stlgrd = string.Empty;

            #region //初始化DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("matCode", typeof(string));//物料编码
            dt.Columns.Add("stdCode", typeof(string));//执行标准
            dt.Columns.Add("area", typeof(string));//区域
            dt.Columns.Add("pack", typeof(string));//包装
            dt.Columns.Add("lev", typeof(string));//等级
            dt.Columns.Add("custname", typeof(string));//客户名称
            dt.Columns.Add("conno", typeof(string));//合同号
            dt.Columns.Add("stlgrd", typeof(string));//钢种
            dt.Columns.Add("wgt", typeof(string));//重量
            #endregion

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                Literal ltlmatCode = (Literal)rptList.Items[i].FindControl("ltlmatCode");
                Literal ltlstdCode = (Literal)rptList.Items[i].FindControl("ltlstdCode");
                Literal ltlarea = (Literal)rptList.Items[i].FindControl("ltlarea");
                Literal ltlpack = (Literal)rptList.Items[i].FindControl("ltlpack");
                Literal ltllev = (Literal)rptList.Items[i].FindControl("ltllev");
                Literal ltlzycust = (Literal)rptList.Items[i].FindControl("ltlzycust");
                Literal ltlzycon = (Literal)rptList.Items[i].FindControl("ltlzycon");
                Literal ltlwgt = (Literal)rptList.Items[i].FindControl("ltlwgt");
                Literal ltlbatch = (Literal)rptList.Items[i].FindControl("ltlbatch");
                Literal ltlstlgrd = (Literal)rptList.Items[i].FindControl("ltlstlgrd");

                #region //插入值
                if (ts_dic.GetAreaFlag(ltlarea.Text) == "N")//获取区域是否按客户发运Y/N
                {

                    DataRow[] dr = dt.Select("matCode='" + ltlmatCode.Text + "' and stdCode='" + ltlstdCode.Text + "' and area='" + ltlarea.Text + "' and pack='" + ltlpack.Text + "' and lev='" + ltllev.Text + "'");
                    if (dr.Length <= 0)
                    {
                        dt.Rows.Add(new object[] { ltlmatCode.Text, ltlstdCode.Text, ltlarea.Text, ltlpack.Text, ltllev.Text, "", "", ltlstlgrd.Text, ltlwgt.Text });
                    }
                    else
                    {
                        foreach (var item in dr)
                        {
                            

                            item["wgt"] = Convert.ToString(Convert.ToDecimal(item["wgt"]) + Convert.ToDecimal(ltlwgt.Text));
                        }
                    }
                }
                else
                {
                    DataRow[] dr = dt.Select("matCode='" + ltlmatCode.Text + "' and stdCode='" + ltlstdCode.Text + "' and area='" + ltlarea.Text + "' and pack='" + ltlpack.Text + "' and lev='" + ltllev.Text + "' and custname='" + ltlzycust.Text + "' and conno='" + ltlzycon.Text + "'");
                    if (dr.Length <= 0)
                    {
                        dt.Rows.Add(new object[] { ltlmatCode.Text, ltlstdCode.Text, ltlarea.Text, ltlpack.Text, ltllev.Text, ltlzycust.Text, ltlzycon.Text, ltlstlgrd.Text, ltlwgt.Text });
                    }
                    else
                    {
                        foreach (var item in dr)
                        {
                           

                            item["wgt"] = Convert.ToString(Convert.ToDecimal(item["wgt"]) + Convert.ToDecimal(ltlwgt.Text));
                        }
                    }
                }
                #endregion
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (ts_dic.GetAreaFlag(dt.Rows[i]["area"].ToString()) == "N")//获取区域是否按客户发运Y/N
                {
                    //判断当前发运数量已超出可发运量
                    if (!tmo_order.IsFy(Convert.ToDecimal(dt.Rows[i]["wgt"].ToString()), dt.Rows[i]["matCode"].ToString(), dt.Rows[i]["stdCode"].ToString(), dt.Rows[i]["area"].ToString(), dt.Rows[i]["pack"].ToString(), dt.Rows[i]["lev"].ToString()))
                    {
                        stlgrd = dt.Rows[i]["stlgrd"].ToString();
                        result = false;
                        break;
                    }
                }
                else
                {
                    //判断当前发运数量已超出可发运量
                    if (!tmo_order.IsFy(Convert.ToDecimal(dt.Rows[i]["wgt"].ToString()), dt.Rows[i]["matCode"].ToString(), dt.Rows[i]["stdCode"].ToString(), dt.Rows[i]["area"].ToString(), dt.Rows[i]["pack"].ToString(), dt.Rows[i]["lev"].ToString(), dt.Rows[i]["custname"].ToString(), dt.Rows[i]["conno"].ToString()))
                    {
                        stlgrd = dt.Rows[i]["stlgrd"].ToString();
                        result = false;
                        break;
                    }
                }
            }
            if (result)
            {
                Response.Redirect("rollCheck.aspx?ID=" + hid.Value);
            }
            else
            {
                string msg = stlgrd + ",存在发运单占用该资源量";
                WebMsg.MessageBox(msg);
            }

        }

        //可调配量查询

        protected void Button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                if (cbxselect.Checked)
                {
                    Literal ltlmatCode = (Literal)rptList.Items[i].FindControl("ltlmatCode");
                    Literal ltlstdCode = (Literal)rptList.Items[i].FindControl("ltlstdCode");
                    Literal ltlarea = (Literal)rptList.Items[i].FindControl("ltlarea");
                    Literal ltlpack = (Literal)rptList.Items[i].FindControl("ltlpack");
                    Literal ltllev = (Literal)rptList.Items[i].FindControl("ltllev");
                    Literal ltlzycust = (Literal)rptList.Items[i].FindControl("ltlzycust");
                    Literal ltlzycon = (Literal)rptList.Items[i].FindControl("ltlzycon");

                    #region //跳转
                    string url = $@"_ZTFYD.aspx?matcode={ltlmatCode.Text}&stdcode={ltlstdCode.Text}&area={ltlarea.Text}&pack={ltlpack.Text}&lev={ltllev.Text}&cust={ltlzycust.Text}&conno={ltlzycon.Text}";

                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "openzt('" + url + "');", true);
                    #endregion

                }
            }
        }
    }
}