using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using NF.BLL;
using NF.DAL;
using NF.MODEL;
using System.Data;
using NF.Framework;
using NF.NC.Interface;

namespace CRM.WebForms.Sale_App
{
    public partial class fydEdit_CY : System.Web.UI.Page
    {
        private static DataTable dtOrder = new DataTable();

        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_TQB_CHECKSTATE tqb_checkstate = new Bll_TQB_CHECKSTATE();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TS_CUSTADDR ts_custaddr = new Bll_TS_CUSTADDR();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private Bll_TMB_AREA tmb_area = new Bll_TMB_AREA();
        private Bll_RandomNumber randomnumber = new Bll_RandomNumber();
        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();
        private Bll_TMD_DISPATCHDETAILS tmd_dispatchdetails = new Bll_TMD_DISPATCHDETAILS();
        private Bll_TS_USER ts_user = new Bll_TS_USER();
        private Bll_TS_DEPT ts_dept = new Bll_TS_DEPT();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["back_no"] = 0;
                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlempid.Text = vUser.Id;
                    hidempname.Value = vUser.Name;
                    txtzdr.Text = vUser.Name;
                    GetDic();

                    if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                    {
                        txtsendcode.Text = Request.QueryString["ID"];
                        BindList();
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
        /// 加载发运单信息
        /// </summary>
        private void BindList()
        {
            dtOrder.Clear();

            if (!string.IsNullOrEmpty(txtsendcode.Text))
            {
                #region //加载表头信息
                Mod_TMD_DISPATCH mod = tmd_dispatch.GetModel(txtsendcode.Text);
                if (mod != null)
                {
                    ltlpkid.Text = mod.C_GUID;//NC主键
                    txtfydt.Text = Convert.ToDateTime(mod.D_DISP_DT).ToString("yyy-MM-dd");
                    dropfyfs.SelectedIndex = dropfyfs.Items.IndexOf(dropfyfs.Items.FindByValue(mod.C_SHIPVIA));

                    txtcph.Enabled = mod.C_SHIPVIA == "0001NC10000000003ILQ" ? true : false; //火运

                    dropsfxc.SelectedIndex = dropsfxc.Items.IndexOf(dropsfxc.Items.FindByValue(mod.C_IS_WIRESALE_ID));

                    dropcys.SelectedIndex = dropcys.Items.IndexOf(dropcys.Items.FindByValue(mod.C_COMCAR));

                    if (dropsfxc.SelectedItem.Text == "是")
                    {
                        btntm.Visible = true;
                        btnwl.Visible = false;
                    }
                    else
                    {
                        btntm.Visible = false;
                        btnwl.Visible = true;
                    }

                    txtdz.Text = mod.C_ATSTATION;
                    txtcph.Text = mod.C_LIC_PLA_NO;
                    txtgps.Text = mod.C_GPS_NO;
                    txtzdr.Text = GetUserName(mod.C_CREATE_ID);//制单人
                    txtzddt.Text = Convert.ToDateTime(mod.D_CREATE_DT).ToString("yyy-MM-dd");
                    txtxgr.Text = GetUserName(mod.C_EMP_ID);//修改人
                    txtxgtime.Text = Convert.ToDateTime(mod.D_MOD_DT).ToString();
                    txtspr.Text = GetUserName(mod.C_APPROVE_ID);//审批人
                    if (Convert.ToDateTime(mod.D_APPROVE_DT).ToString("yyy-MM-dd") != "001-01-01")
                    {
                        txtspdt.Text = Convert.ToDateTime(mod.D_APPROVE_DT).ToString("yyy-MM-dd");
                    }
                    hidstatus.Value = mod.C_STATUS;
                    ltltype.Text = mod.C_EXTEND5;
                    txtfyqua.Value = mod.N_QUA.ToString();//发运支数
                    txtfywgt.Value = mod.N_WGT.ToString();//发运重量

                    ltlimport_num.Text = mod.C_EXTEND1.ToString();//记录导入条码系统次数

                    #region //发运量控制
                    //DataTable dtfywgt = GetData("DM001");
                    //if (dtfywgt.Rows.Count > 0)
                    //{
                    //    decimal num = 0;
                    //    if (!string.IsNullOrEmpty(dtfywgt.Rows[0]["C_DETAILCODE"].ToString()) && !string.IsNullOrEmpty(txtfywgt.Value))
                    //    {
                    //        num = Convert.ToDecimal(dtfywgt.Rows[0]["C_DETAILCODE"].ToString());
                    //        decimal fywgt = Convert.ToDecimal(txtfywgt.Value);
                    //        decimal fd = fywgt * num;
                    //        hidsf.Value = Convert.ToString(fywgt + fd);//上幅数
                    //        hidxf.Value = Convert.ToString(fywgt - fd);//下幅数
                    //        hidmsg.Value = dtfywgt.Rows[0]["C_DETAILNAME"].ToString();//提示发运数量总和幅度上下5%
                    //    }
                    //}
                    #endregion

                    #region//操作按钮/输入框权限显示

                    txtcph.Enabled = mod.C_STATUS == "0" ? true : false;//车牌号
                    btn(mod.C_STATUS);//按钮状态
                    #endregion

                    #region //加载表体信息
                    DataTable dt = tmd_dispatchdetails.GetList(txtsendcode.Text).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        txtcount.Value = dt.Compute("sum(N_FYZS)", "true").ToString();
                        txtsumwgt.Value = dt.Compute("sum(N_FYWGT)", "true").ToString();
                        rptList.DataSource = dt;
                        rptList.DataBind();
                    }
                    else
                    {
                        rptList.DataSource = null;
                        rptList.DataBind();
                        txtcount.Value = "";
                        txtsumwgt.Value = "";
                    }
                    #endregion
                }
                #endregion


            }
        }

        private void btn(string status)
        {
            #region //状态//按钮显示
            switch (status)
            {
                case "0":
                    ltlstatus.Text = "自由状态";
                    btndelrow.Enabled = true;
                    btnsave.Enabled = true;
                    btnOK.Enabled = true;
                    btnedit.Enabled = false;
                    btnnc.Enabled = false;
                    btntm.Enabled = false;
                    btnwl.Enabled = false;
                    btnaddrow.Enabled = true;

                    break;
                case "2":
                    ltlstatus.Text = "已导入NC";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnOK.Enabled = false;
                    btnedit.Enabled = true;
                    btnnc.Enabled = false;
                    btntm.Enabled = true;
                    btnwl.Enabled = true;
                    btnaddrow.Enabled = false;
                    break;
                case "3":
                    ltlstatus.Text = "已导入条码";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnOK.Enabled = false;
                    btnedit.Enabled = true;
                    btnnc.Enabled = false;
                    btntm.Enabled = false;
                    btnwl.Enabled = false;
                    btnaddrow.Enabled = false;
                    break;
                case "4":
                    ltlstatus.Text = "已导入物流";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnOK.Enabled = false;
                    btnedit.Enabled = true;
                    btnnc.Enabled = false;
                    btntm.Enabled = false;
                    btnwl.Enabled = false;
                    btnaddrow.Enabled = false;
                    break;
                case "7":
                    ltlstatus.Text = "已做实绩";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnOK.Enabled = false;
                    btnedit.Enabled = false;
                    btnnc.Enabled = false;
                    btntm.Enabled = false;
                    btnwl.Enabled = false;
                    btnaddrow.Enabled = false;
                    break;
                case "8":
                    ltlstatus.Text = "实绩已导入NC";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnOK.Enabled = false;
                    btnedit.Enabled = false;
                    btnnc.Enabled = false;
                    btntm.Enabled = false;
                    btnwl.Enabled = false;
                    btnaddrow.Enabled = false;
                    break;
                case "9":
                    ltlstatus.Text = "实绩已导入NC";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnOK.Enabled = false;
                    btnedit.Enabled = false;
                    btnnc.Enabled = false;
                    btntm.Enabled = false;
                    btnwl.Enabled = false;
                    btnaddrow.Enabled = false;
                    break;
                case "10":
                    ltlstatus.Text = "已审核";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnOK.Enabled = false;
                    btnedit.Enabled = true;
                    btnnc.Enabled = true;
                    btntm.Enabled = false;
                    btnwl.Enabled = false;
                    btnaddrow.Enabled = false;
                    break;
            }


            #endregion
        }


        #region //获取基础数据
        /// <summary>
        /// 获取销售区域部门名称
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public string GetDeptName(object id)
        {
            string name = string.Empty;
            Mod_TS_DEPT mod = ts_dept.GetModel(id.ToString());
            if (mod != null)
            {
                name = mod.C_NAME;
            }
            return name;
        }


        /// <summary>
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

        /// <summary>
        /// 获取用户姓名
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        private string GetUserName(string id)
        {
            string name = string.Empty;
            Mod_TS_USER mod = ts_user.GetModel(id);
            if (mod != null)
            {
                name = mod.C_NAME;
            }
            return name;
        }

        /// <summary>
        /// 根据地址主键获取名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetAddrName(object id)
        {
            string result = "";
            DataRow dr = ts_custaddr.GetAddrName(id.ToString());
            if (dr != null)
            {
                result = dr["C_CGAREA"].ToString();
            }
            return result;
        }

        /// <summary>
        /// 获取质量等级
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetCheck(object id)
        {
            string result = "";
            DataTable dt = tqb_checkstate.GetCheckState("", id.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                result = dt.Rows[0]["C_CHECKSTATE_NAME"].ToString();
            }
            return result;
        }


        /// <summary>
        /// 获取收货单位/开票单位
        /// </summary>
        /// <param name="C_NC_M_ID">NC客商管理档案主键</param>
        /// <returns></returns>
        public string GetCust(object C_NC_M_ID)
        {
            string str = string.Empty;
            Mod_TS_CUSTFILE mod = ts_custfile.GetCustModel(C_NC_M_ID.ToString());
            if (mod != null)
            {
                str = mod.C_NAME;
            }

            return str;
        }

        /// <summary>
        /// 获取区域
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetArea(object id)
        {
            string str = string.Empty;
            Mod_TMB_AREA mod = tmb_area.GetModel(id.ToString());
            if (mod != null)
            {
                str = mod.C_NAME;
            }
            return str;

        }
        #endregion


        //删除行
        protected void btndelrow_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = false;
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkOrder");
                    HtmlInputHidden hidpkid = (HtmlInputHidden)rptList.Items[i].FindControl("hidpkid");

                    if (chkOrder.Checked)
                    {
                        result = tmd_dispatchdetails.Delete(hidpkid.Value);
                    }
                }
                if (result)
                {
                    WebMsg.MessageBox("删除成功");
                    BindList();
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }
        }


        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)e.Item.FindControl("chkOrder");
            Literal ltlyckwtg = (Literal)e.Item.FindControl("ltlyckwtg");//已出库量


            #region//已出库量

            string outwgt = "";
            //获取订单具体发运明细实际出库量
            DataTable dtOut = tmo_order.GetOUTSTOCKWGT(chkOrder.Value, txtsendcode.Text);
            if (dtOut.Rows.Count > 0)
            {
                outwgt = dtOut.Rows[0]["N_WGT"].ToString();//已出库量
            }

            ltlyckwtg.Text = outwgt;
            #endregion
        }

        //保存
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal num1 = Convert.ToDecimal(txtsumwgt.Value);//发运数量
                decimal num2 = Convert.ToDecimal(txtfywgt.Value ?? "0"); //原数量
                if (Convert.ToDecimal(txtcount.Value) != Convert.ToDecimal(txtfyqua.Value))
                {
                    WebMsg.MessageBox("发运单发运支数总和不能改变");
                    return;
                }
                if (num1 > num2)
                {
                    WebMsg.MessageBox("发运量已超原先发运量！");
                    return;
                }

                if (updateFyd("Y"))
                {
                    WebMsg.MessageBox("保存成功");
                    BindList();
                }

            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }

        }

        /// <summary>
        /// 修改发运单
        /// </summary>
        /// <returns></returns>
        private bool updateFyd(string flag)
        {
            decimal fyzs = 0;//发运支数
            decimal fywgt = 0;//发运量

            #region //表体
            List<Mod_TMD_DISPATCHDETAILS> item = new List<Mod_TMD_DISPATCHDETAILS>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputHidden hidpkid = (HtmlInputHidden)rptList.Items[i].FindControl("hidpkid");//发运单明细主键
                HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkOrder");//订单主键
                HtmlInputHidden hidckid = (HtmlInputHidden)rptList.Items[i].FindControl("hidckid");//仓库ID
                HtmlInputText txtckname = (HtmlInputText)rptList.Items[i].FindControl("txtckname");//仓库名称
                //HtmlInputText txtflag = (HtmlInputText)rptList.Items[i].FindControl("txtflag");//标识：Y/N
                HtmlInputText txtfyzs = (HtmlInputText)rptList.Items[i].FindControl("txtfyzs");//发运支数
                HtmlInputText txtjhfyl = (HtmlInputText)rptList.Items[i].FindControl("txtjhfyl");//发运数量

                fyzs += Convert.ToDecimal(txtfyzs.Value ?? "0");
                fywgt += Convert.ToDecimal(txtjhfyl.Value ?? "0");

                if (flag == "N")//增行
                {
                    if (chkOrder.Checked)
                    {
                        #region //insert 
                        Mod_TMD_DISPATCHDETAILS modfyditem = tmd_dispatchdetails.GetModel(hidpkid.Value);
                        modfyditem.C_EMP_ID = ltlempid.Text;
                        modfyditem.C_EMP_NAME = hidempname.Value;
                        modfyditem.N_FYZS = 0;//发运支数
                        modfyditem.N_FYWGT = 0;//发运数量
                        modfyditem.C_SEND_STOCK = "";//发运仓库名称
                        modfyditem.C_SEND_STOCK_PK = "";//发运仓库ID
                        modfyditem.FLAG = flag;
                        item.Add(modfyditem);
                        #endregion
                    }
                }
                else
                {
                    #region //update
                    Mod_TMD_DISPATCHDETAILS modfyditem = tmd_dispatchdetails.GetModel(hidpkid.Value);
                    modfyditem.C_ID = hidpkid.Value;//主键
                    modfyditem.C_EMP_ID = ltlempid.Text;
                    modfyditem.C_EMP_NAME = hidempname.Value;
                    modfyditem.N_FYZS = Convert.ToDecimal(txtfyzs.Value);//发运支数
                    modfyditem.N_FYWGT = Convert.ToDecimal(txtjhfyl.Value);//发运数量

                    if (!string.IsNullOrEmpty(txtckname.Value))
                    {
                        modfyditem.C_SEND_STOCK = txtckname.Value;//发运仓库名称
                        modfyditem.C_SEND_STOCK_PK = hidckid.Value;//发运仓库ID
                    }
                    else
                    {
                        modfyditem.C_SEND_STOCK = "";//发运仓库名称
                        modfyditem.C_SEND_STOCK_PK = "";//发运仓库ID
                    }

                    modfyditem.FLAG = flag;
                    item.Add(modfyditem);

                    #endregion
                }

            }
            #endregion

            #region//表头
            Mod_TMD_DISPATCH modfyd = tmd_dispatch.GetModel(txtsendcode.Text);
            //modfyd.C_ID = txtsendcode.Text;//发运单单据号
            //modfyd.C_GPS_NO = txtgps.Text;//GPS号
            //modfyd.D_DISP_DT = Convert.ToDateTime(txtfydt.Text);//发运日期
            //modfyd.C_SHIPVIA = dropfyfs.SelectedItem.Value;//发运方式
            //modfyd.C_COMCAR = dropcys.SelectedItem.Value;//承运商
            //modfyd.C_IS_WIRESALE = dropsfxc.SelectedItem.Text;//汉字是否线材
            //modfyd.C_IS_WIRESALE_ID = dropsfxc.SelectedItem.Value;//是否线材主键
            modfyd.C_LIC_PLA_NO = txtcph.Text;//车牌号
            //modfyd.C_ATSTATION = txtdz.Text;//到站
            modfyd.C_EMP_ID = ltlempid.Text;//修改人ID
            modfyd.C_EMP_NAME = hidempname.Value;//修改人
            //modfyd.C_EXTEND5 = ltltype.Text;//订单类型 8线材 6钢坯 831废乱材  841焦化产品 851渣
            //modfyd.N_QUA =Convert.ToDecimal(txtfyqua.Value);//发运支数
            //modfyd.N_WGT = Convert.ToDecimal(txtfywgt.Value);//发运量
            #endregion

            if (tmd_dispatch.UpdateFYD(modfyd, item))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //审核
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (tmd_dispatch.UpdateFydStatus(txtsendcode.Text, 10, ltlempid.Text, hidempname.Value, "2"))
            {
                BindList();
            }
        }

        //弃审
        protected void btnedit_Click(object sender, EventArgs e)
        {
            UpdateStatus();
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <returns></returns>
        private void UpdateStatus()
        {
            if (tmd_dispatch.UpdateFydStatus(txtsendcode.Text, 0, ltlempid.Text, hidempname.Value, "3"))
            {
                BindList();
            }
        }


        private string GetNCError(List<string> arrstr)
        {
            if (arrstr.Count < 2) { return "上传NC失败，请联系管理员"; }
            var result = arrstr[1].Replace("\r\n", "<br/>").Replace("\r", "<br/>").Replace("\n", "<br/>").Replace(" ", "&nbsp;");

            return result;
        }

        //导入NC
        protected void btnnc_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                ApiDispatchOrder apifyd = new ApiDispatchOrder();
                string filePath = "~/FileInterface/download/nc_" + txtsendcode.Text + ".xml";
                string xmlFileName = System.Web.HttpContext.Current.Server.MapPath(filePath);
                List<string> resList = apifyd.SendXmlApiDispatchOrder(txtsendcode.Text, xmlFileName, ltlempid.Text, 8);

                string jg = resList[0].ToString() == "1" ? "导入NC成功" : GetNCError(resList);
                result = "单据号：" + txtsendcode.Text + ",结果：" + jg;

                if (resList[0].ToString() == "1")
                {
                    if (tmd_dispatch.UpdateFydStatus(txtsendcode.Text, 2, ltlempid.Text, hidempname.Value, "3"))
                    {
                        //WebMsg.MessageBox(result);
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + result + "');</script>", false);
                        BindList();
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + result + "');</script>", false);

                    BindList();
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }
        //导入条码
        protected void btntm_Click(object sender, EventArgs e)
        {
            try
            {

                bool result = tmd_dispatch.UpdateFydRF_Num(txtsendcode.Text, ltlimport_num.Text);

                Dal_Interface_FR dal = new Dal_Interface_FR();
                if (dal.SENDFYD(txtsendcode.Text) > 0)
                {
                    if (tmd_dispatch.UpdateFydStatus(txtsendcode.Text, 3, ltlempid.Text, hidempname.Value, "3"))
                    {
                        //WebMsg.MessageBox("导入成功");
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('导入成功');</script>", false);
                        BindList();
                    }
                    else
                    {
                        //WebMsg.MessageBox("导入失败");
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('导入失败');</script>", false);
                    }
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }


        }
        //导入物流
        protected void btnwl_Click(object sender, EventArgs e)
        {
            if (tmd_dispatch.UpdateFydStatus(txtsendcode.Text, 4, ltlempid.Text, hidempname.Value, "3"))
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('虚拟导入物流状态设置成功');</script>", false);
                BindList();
            }

        }

        //增加行
        protected void btnaddrow_Click(object sender, EventArgs e)
        {
            if (updateFyd("N"))
            {
                BindList();
            }
        }
    }
}