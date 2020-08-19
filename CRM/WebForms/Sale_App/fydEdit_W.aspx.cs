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
using ZXing;
using System.Drawing;

namespace CRM.WebForms.Sale_App
{
    public partial class fydEdit_W : System.Web.UI.Page
    {
        private static DataTable dtOrder = new DataTable();


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
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();

        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();


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


            if (!string.IsNullOrEmpty(txtsendcode.Text))
            {
                #region //加载表头信息
                Mod_TMD_DISPATCH mod = tmd_dispatch.GetModel(txtsendcode.Text);
                if (mod != null)
                {
                    ltlpkid.Text = mod.C_GUID;//NC主键
                    txtfydt.Text = Convert.ToDateTime(mod.D_DISP_DT).ToString("yyy-MM-dd");
                    dropfyfs.SelectedIndex = dropfyfs.Items.IndexOf(dropfyfs.Items.FindByValue(mod.C_SHIPVIA));
                    dropsfxc.SelectedIndex = dropsfxc.Items.IndexOf(dropsfxc.Items.FindByValue(mod.C_IS_WIRESALE_ID));
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
                    btnaddrow.Enabled = true;
                    btndel.Enabled = true;
                    Button1.Enabled = false;
                    break;
                case "2":
                    ltlstatus.Text = "已导入NC";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnOK.Enabled = false;
                    btnedit.Enabled = true;
                    btnnc.Enabled = false;
                    btntm.Enabled = true;
                    btnaddrow.Enabled = false;
                    btndel.Enabled = false;
                    Button1.Enabled = true;
                    break;
                case "8":
                    ltlstatus.Text = "实绩已导入NC";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnOK.Enabled = false;
                    btnedit.Enabled = true;
                    btnnc.Enabled = false;
                    btntm.Enabled = false;
                    btnaddrow.Enabled = false;
                    btndel.Enabled = false;
                    Button1.Enabled = false;
                    break;

                case "10":
                    ltlstatus.Text = "已审核";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnOK.Enabled = false;
                    btnedit.Enabled = true;
                    btnnc.Enabled = true;
                    btntm.Enabled = true;
                    btnaddrow.Enabled = false;
                    btndel.Enabled = false;
                    Button1.Enabled = false;
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

        //刷新
        protected void imgbtnJz_Click(object sender, ImageClickEventArgs e)
        {

        }
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
            if (updateFyd("Y"))
            {
                BindList();

                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('保存成功');</script>", false);


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
                HtmlInputText txtbatch = (HtmlInputText)rptList.Items[i].FindControl("txtbatch");//批次号


                fyzs += Convert.ToDecimal(txtfyzs.Value ?? "0");
                fywgt += Convert.ToDecimal(txtjhfyl.Value ?? "0");



                if (flag == "N")
                {
                    if (chkOrder.Checked)
                    {
                        #region //insert 
                        Mod_TMD_DISPATCHDETAILS modfyditem = tmd_dispatchdetails.GetModel(hidpkid.Value);
                        modfyditem.C_EMP_ID = ltlempid.Text;
                        modfyditem.C_EMP_NAME = hidempname.Value;
                        modfyditem.N_FYZS = Convert.ToDecimal(txtfyzs.Value ?? "0");//发运支数
                        modfyditem.N_FYWGT = Convert.ToDecimal(txtjhfyl.Value ?? "0");//发运数量
                        modfyditem.C_BATCH_NO = txtbatch.Value.Trim();//批次号
                        modfyditem.C_SEND_STOCK = txtckname.Value;//发运仓库名称
                        modfyditem.C_SEND_STOCK_PK = hidckid.Value;//发运仓库ID
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
                    modfyditem.C_BATCH_NO = txtbatch.Value.Trim();//批次号
                    modfyditem.C_SEND_STOCK = txtckname.Value;//发运仓库名称
                    modfyditem.C_SEND_STOCK_PK = hidckid.Value;//发运仓库ID
                    modfyditem.FLAG = flag;
                    item.Add(modfyditem);

                    #endregion
                }

            }
            #endregion

            #region//表头
            Mod_TMD_DISPATCH modfyd = new Mod_TMD_DISPATCH();
            modfyd.C_ID = txtsendcode.Text;//发运单单据号
            modfyd.C_GPS_NO = txtgps.Text;//GPS号
            modfyd.D_DISP_DT = Convert.ToDateTime(txtfydt.Text);//发运日期
            modfyd.C_SHIPVIA = dropfyfs.SelectedItem.Value;//发运方式
            modfyd.C_COMCAR = dropcys.SelectedItem.Value;//承运商
            modfyd.C_IS_WIRESALE = dropsfxc.SelectedItem.Text;//汉字是否线材
            modfyd.C_IS_WIRESALE_ID = dropsfxc.SelectedItem.Value;//是否线材主键
            modfyd.C_LIC_PLA_NO = txtcph.Text;//车牌号
            modfyd.C_ATSTATION = txtdz.Text;//到站
            modfyd.C_EMP_ID = ltlempid.Text;//修改人ID
            modfyd.C_EMP_NAME = hidempname.Value;//修改人
            //modfyd.C_EXTEND5 = ltltype.Text;//订单类型 8线材 6钢坯 831废乱材  841焦化产品 851渣
            modfyd.N_QUA = fyzs;//发运支数
            modfyd.N_WGT = fywgt;//发运量
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
        private string GetNCError(List<string> arrstr)
        {


            if (arrstr.Count < 2) { return "上传NC失败，请联系管理员"; }
            var result = arrstr[1].Replace("\r\n", "<br/>").Replace("\r", "<br/>").Replace("\n", "<br/>").Replace(" ", "&nbsp;");

            return result;

        }

        //导入实绩到NC
        protected void btntm_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                ApiDispatchOrder_SJ apifyd = new ApiDispatchOrder_SJ();
                string filePath = "~/FileInterface/download/nc_" + txtsendcode.Text + ".xml";
                string xmlFileName = System.Web.HttpContext.Current.Server.MapPath(filePath);
                List<string> resList = apifyd.SendXmlApiDispatchOrder(txtsendcode.Text, xmlFileName, ltlempid.Text, 8);

                string jg = resList[0].ToString() == "1" ? "导入NC成功" : GetNCError(resList);
                result = "单据号：" + txtsendcode.Text + ",结果：" + jg;

                if (resList[0].ToString() == "1")
                {
                    var logger = Logger.CreateLogger(this.GetType());
                    logger.Info("导入NC成功发运单号：" + txtsendcode.Text);

                    if (tmd_dispatch.UpdateFydWW(txtsendcode.Text, 8, ltlempid.Text, hidempname.Value))
                    {
                        try
                        {
                            #region //生成远程质证书


                            DataTable dt = tmd_dispatchdetails.GetList(txtsendcode.Text).Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    Mod_TMD_DISPATCHDETAILS moditem = tmd_dispatchdetails.GetModel(dt.Rows[i]["C_ID"].ToString());

                                    string[] dj = { "A", "AA", "AAA", "CK", "A1", "合格品", "B1", "B2", "C1", "C2" };
                                    if (dj.Contains(moditem.C_JUDGE_LEV_ZH))
                                    {
                                        bool res = trc_roll_prodcut.ExistsZZS(moditem.C_DISPATCH_ID, moditem.C_BATCH_NO);
                                        //检查是否重复批次
                                        if (!res)
                                        {
                                            DataTable dtRoll = trc_roll_prodcut.GetZZS("", "", moditem.C_DISPATCH_ID, "", "", moditem.C_BATCH_NO, "", "", "Y", "8", "", "").Tables[0];
                                            if (dtRoll.Rows.Count > 0)
                                            {

                                                DataTable dtCustStd = trc_roll_prodcut.GetCustStd_JH(dtRoll.Rows[0]["C_STD_CODE"].ToString(), dtRoll.Rows[0]["C_STL_GRD"].ToString(), dtRoll.Rows[0]["C_ZYX1"].ToString(), dtRoll.Rows[0]["C_ZYX2"].ToString()).Tables[0];

                                                DataTable dtJSXYH = trc_roll_prodcut.GetCustStd_JH(dtRoll.Rows[0]["C_STD_CODE"].ToString(), dtRoll.Rows[0]["C_STL_GRD"].ToString(), dtRoll.Rows[0]["C_TECH_PROT"].ToString(), dtRoll.Rows[0]["C_ZYX1"].ToString(), dtRoll.Rows[0]["C_ZYX2"].ToString()).Tables[0];

                                                #region //添加参数
                                                Mod_TQC_ZZS_INFO mod = new Mod_TQC_ZZS_INFO();
                                                mod.C_FYDH = moditem.C_DISPATCH_ID;
                                                mod.C_BATCH_NO = moditem.C_BATCH_NO;
                                                mod.C_STOVE = dtRoll.Rows[0]["C_STOVE"].ToString();
                                                mod.C_SPEC = dtRoll.Rows[0]["C_SPEC"].ToString();
                                                mod.C_STL_GRD = dtRoll.Rows[0]["C_STL_GRD"].ToString();
                                                mod.C_STD_CODE = dtRoll.Rows[0]["C_STD_CODE"].ToString();
                                                mod.D_CKSJ = Convert.ToDateTime(dtRoll.Rows[0]["D_CKSJ"].ToString());
                                                mod.N_JZ = Convert.ToDecimal(dtRoll.Rows[0]["N_WGT"].ToString());
                                                mod.N_NUM = Convert.ToDecimal(dtRoll.Rows[0]["QUA"].ToString());
                                                mod.C_CH = dtRoll.Rows[0]["C_CH"].ToString();

                                                mod.C_ZSH = randomnumber.GetZSH();//证书号

                                                mod.C_QZR = "02";//签证人


                                                #region //生成二维码

                                                string msg = $@"http://60.6.254.51:808/Common/qualCert.aspx?fyd={mod.C_FYDH}&zsh={mod.C_ZSH}";

                                                Bitmap bt = GenByZXingNet(msg);//调用生成二维码方法

                                                mod.C_IMG = $@"D:/QRCode/{mod.C_ZSH}.jpg";//生成二维码图片命名

                                                string upPath = $@"~/QRCode/{mod.C_ZSH}.jpg";

                                                bt.Save(Server.MapPath(upPath));//保存二维码图片

                                                #endregion

                                                Mod_TS_CUSTFILE mod_TS_CUSTFILE = ts_custfile.GetCustModel(dtRoll.Rows[0]["C_CGC"].ToString());

                                                mod.C_CUST_NO = mod_TS_CUSTFILE.C_NO;
                                                mod.C_CON_NO = dtRoll.Rows[0]["C_CON_NO"].ToString();
                                                mod.C_CUST_NAME = dtRoll.Rows[0]["C_CUST_NAME"].ToString();
                                                mod.C_SH_NAME = mod_TS_CUSTFILE.C_NAME;
                                                mod.C_MAT_NAME = dtRoll.Rows[0]["C_MAT_DESC"].ToString();
                                                mod.C_STD_JH = dtCustStd.Rows[0]["C_STD_JH"].ToString();
                                                mod.C_ZLDJ = dtRoll.Rows[0]["C_JUDGE_LEV_ZH"].ToString();
                                                mod.C_JH_STATE = dtRoll.Rows[0]["C_JH_STATE"].ToString();
                                                mod.C_JSXYH = dtJSXYH.Rows[0]["C_JSXYH"].ToString();
                                                mod.C_XKZH = dtRoll.Rows[0]["C_XKZH"].ToString();
                                                mod.C_BY1 = "8";

                                                #endregion

                                                trc_roll_prodcut.InsertZZS(mod);
                                            }
                                        }

                                    }
                                }
                            }


                            #endregion

                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + result + "');</script>", false);
                        BindList();
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + result + "');</script>", false);
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }


        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private Bitmap GenByZXingNet(string msg)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");//编码问题
            writer.Options.Hints.Add(
            EncodeHintType.ERROR_CORRECTION,
            ZXing.QrCode.Internal.ErrorCorrectionLevel.H

            );
            const int codeSizeInPixels = 500; //设置图片长宽
            writer.Options.Height = writer.Options.Width = codeSizeInPixels;
            writer.Options.Margin = 0;//设置边框
            ZXing.Common.BitMatrix bm = writer.Encode(msg);
            Bitmap img = writer.Write(bm);
            return img;
        }


        //增加行
        protected void btnaddrow_Click(object sender, EventArgs e)
        {
            if (updateFyd("N"))
            {
                BindList();
            }
        }

        //删除发运单
        protected void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                if (tmd_dispatch.DelNCFYD(ltlpkid.Text))
                {
                    if (tmd_dispatch.DelFYD(txtsendcode.Text, ltlempid.Text))
                    {
                        var logger = Logger.CreateLogger(this.GetType());
                        logger.Info("用户ID" + ltlempid.Text + DateTime.Now.ToString() + ";发运单号" + txtsendcode.Text);

                        WebMsg.MessageBox("删除成功", "fydList.aspx");
                    }
                }
                else
                {
                    WebMsg.MessageBox("请先同步删除NC发运单！");
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }
        //异常批次导入NC
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                ApiDispatchOrder_SJ apifyd = new ApiDispatchOrder_SJ();
                string filePath = "~/FileInterface/download/nc_" + txtsendcode.Text + ".xml";
                string xmlFileName = System.Web.HttpContext.Current.Server.MapPath(filePath);
                List<string> resList = apifyd.SendXmlApiDispatchOrder(txtsendcode.Text, xmlFileName, ltlempid.Text, 8);

                string jg = resList[0].ToString() == "1" ? "导入NC成功" : GetNCError(resList);
                result = "单据号：" + txtsendcode.Text + ",结果：" + jg;

                if (resList[0].ToString() == "1")
                {
                    var logger = Logger.CreateLogger(this.GetType());

                    logger.Info("异常批次量修改处理成功：" + txtsendcode.Text);

                    if (tmd_dispatch.UpdateFydStatus(txtsendcode.Text, 8, ltlempid.Text, hidempname.Value, "3"))
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + result + "');</script>", false);
                        BindList();
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + result + "');</script>", false);
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}