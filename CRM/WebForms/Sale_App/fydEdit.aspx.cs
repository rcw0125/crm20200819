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
using NF.BLL.D;

namespace CRM.WebForms.Sale_App
{
    public partial class fydEdit : System.Web.UI.Page
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

        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();

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
                    dropcys.SelectedIndex = dropcys.Items.IndexOf(dropcys.Items.FindByValue(mod.C_COMCAR));



                    #region//判断是否线材销售是条码，否物流
                    if (dropsfxc.SelectedItem.Text == "是")
                    {
                        btntm.Visible = true;
                        btnwl.Visible = false;
                        btnwl2.Visible = false;
                    }
                    else
                    {
                        btntm.Visible = false;
                        btnwl.Visible = true;
                        btnwl2.Visible = true;
                    }
                    #endregion

                    txtdz.Text = mod.C_ATSTATION;
                    txtcph.Text = mod.C_LIC_PLA_NO;
                    txtgps.Text = mod.C_GPS_NO;
                    txtzdr.Text = GetUserName(mod.C_CREATE_ID);//制单人
                    ltlzdrID.Text = mod.C_CREATE_ID;//制单人ID
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

                    dropsfbdj.SelectedIndex = dropsfbdj.Items.IndexOf(dropsfbdj.Items.FindByValue(mod.N_IS_EXPORT.ToString()));//是否包到价

                    txtcph.Enabled = mod.N_IS_EXPORT == 1 ? false : true;

                    txtxnch.Text = mod.C_EXTEND2;//虚拟车号
                    txtsjxm.Text = mod.C_EXTEND3;//司机姓名/电话
                    txtsjtel.Text = mod.C_EXTEND4;//客户姓名/电话



                    #region //发运量控制
                    DataTable dtfywgt = GetData("DM001");
                    if (dtfywgt.Rows.Count > 0)
                    {
                        hidsf.Value = dtfywgt.Rows[0]["C_DETAILCODE"].ToString();
                    }
                    #endregion

                    #region//操作按钮/输入框权限显示

                    getbtn(mod.C_STATUS);//按钮状态
                    getinput(mod.C_STATUS);//控件
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
        /// <summary>
        /// 输入框控件
        /// </summary>
        /// <param name="status"></param>
        private void getinput(string status)
        {
            switch (status)
            {
                case "0"://自由状态
                    dropfyfs.Enabled = true;//发运方式
                    dropcys.Enabled = true;//承运商
                    //dropsfxc.Enabled = true;
                    txtdz.Enabled = true;//站点
                    txtcph.Enabled = true;//车牌号
                    txtgps.Enabled = true;//GPS
                    break;
                default:
                    dropfyfs.Enabled = false;
                    dropcys.Enabled = false;
                    //dropsfxc.Enabled = false;
                    txtdz.Enabled = false;
                    txtcph.Enabled = false;
                    txtgps.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// 按钮控件
        /// </summary>
        /// <param name="status"></param>
        private void getbtn(string status)
        {
            #region //状态//按钮显示
            switch (status)
            {
                case "0":
                    ltlstatus.Text = "自由状态";
                    btndelrow.Enabled = true;
                    btnsave.Enabled = true;
                    btnAdd.Disabled = false;
                    btnOK.Enabled = true;
                    btnedit.Enabled = false;
                    btnnc.Enabled = false;
                    btntm.Enabled = false;
                    btnwl.Enabled = false;
                    btnwl2.Enabled = false;
                    btndel.Enabled = true;
                    btnedit_CH.Disabled = false;
                    btnEditSaleOut.Disabled = true;
                    break;
                case "2":
                    ltlstatus.Text = "已导入NC";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnAdd.Disabled = true;
                    btnOK.Enabled = false;
                    btnedit.Enabled = true;
                    btnnc.Enabled = false;
                    btntm.Enabled = true;
                    btnwl.Enabled = true;
                    btnwl2.Enabled = true;
                    btndel.Enabled = false;
                    btnedit_CH.Disabled = false;
                    btnEditSaleOut.Disabled = true;
                    break;
                case "3":
                    ltlstatus.Text = "已导入条码";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnAdd.Disabled = true;
                    btnOK.Enabled = false;
                    btnedit.Enabled = true;
                    btnnc.Enabled = false;
                    btntm.Enabled = false;
                    btnwl.Enabled = false;
                    btnwl2.Enabled = false;
                    btndel.Enabled = false;
                    btnedit_CH.Disabled = false;
                    btnEditSaleOut.Disabled = true;
                    break;
                case "4":
                    ltlstatus.Text = "已导入物流";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnAdd.Disabled = true;
                    btnOK.Enabled = false;
                    btnedit.Enabled = true;
                    btnnc.Enabled = false;
                    btntm.Enabled = false;
                    btnwl.Enabled = false;
                    btnwl2.Enabled = false;
                    btndel.Enabled = false;
                    btnedit_CH.Disabled = true;
                    btnEditSaleOut.Disabled = true;
                    break;
                case "7":
                    ltlstatus.Text = "已做实绩";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnAdd.Disabled = true;
                    btnOK.Enabled = false;
                    btnedit.Enabled = false;
                    btnnc.Enabled = false;
                    btntm.Enabled = false;
                    btnwl.Enabled = false;
                    btnwl2.Enabled = false;
                    btndel.Enabled = false;
                    btnedit_CH.Disabled = true;
                    btnEditSaleOut.Disabled = true;
                    break;
                case "8":
                    ltlstatus.Text = "实绩已导入NC";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnAdd.Disabled = true;
                    btnOK.Enabled = false;
                    btnedit.Enabled = false;
                    btnnc.Enabled = false;
                    btntm.Enabled = false;
                    btnwl.Enabled = false;
                    btnwl2.Enabled = false;
                    btndel.Enabled = false;
                    btnedit_CH.Disabled = true;
                    btnEditSaleOut.Disabled = true;
                    break;
                case "9":
                    ltlstatus.Text = "实绩已导入NC";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnAdd.Disabled = true;
                    btnOK.Enabled = false;
                    btnedit.Enabled = false;
                    btnnc.Enabled = false;
                    btntm.Enabled = false;
                    btnwl.Enabled = false;
                    btnwl2.Enabled = false;
                    btndel.Enabled = false;
                    btnedit_CH.Disabled = true;
                    btnEditSaleOut.Disabled = ltlzdrID.Text == ltlempid.Text ? false : true;
                    break;
                case "10":
                    ltlstatus.Text = "已审核";
                    btndelrow.Enabled = false;
                    btnsave.Enabled = false;
                    btnAdd.Disabled = true;
                    btnOK.Enabled = false;
                    btnedit.Enabled = true;
                    btnnc.Enabled = true;
                    btntm.Enabled = false;
                    btnwl.Enabled = false;
                    btnwl2.Enabled = false;
                    btndel.Enabled = false;
                    btnedit_CH.Disabled = false;
                    btnEditSaleOut.Disabled = true;
                    break;
                default:
                    break;
            }
            #endregion
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

        /// <summary>
        /// 检测钢种是否重复
        /// </summary>
        /// <param name="ckcode"></param>
        /// <returns></returns>
        private bool getck(string orderID)
        {
            bool result = true;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkOrder");
                if (chkOrder.Value == orderID)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        //新增钢种
        private void AddOrderList()
        {

            try
            {
                if (Session[ltlempid.Text] != null)
                {
                    DataTable dt = (DataTable)Session[ltlempid.Text];

                    List<Mod_TMD_DISPATCHDETAILS> item = new List<Mod_TMD_DISPATCHDETAILS>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //检测订单是否重复
                        if (getck(dt.Rows[i]["C_ID"].ToString()))
                        {
                            Mod_TMO_ORDER modOrder = tmo_order.GetModel(dt.Rows[i]["C_ID"].ToString());

                            if (modOrder != null)
                            {
                                #region //insert 
                                Mod_TMD_DISPATCHDETAILS modfyditem = new Mod_TMD_DISPATCHDETAILS();
                                modfyditem.C_DISPATCH_ID = txtsendcode.Text;//发运单单据号
                                modfyditem.C_MAT_CODE = modOrder.C_MAT_CODE;//物料编码
                                modfyditem.C_MAT_NAME = modOrder.C_MAT_NAME;//物料名称
                                modfyditem.C_SPEC = modOrder.C_SPEC;//规格
                                modfyditem.C_STL_GRD = modOrder.C_STL_GRD;//钢种
                                modfyditem.C_QUALIRY_LEV = modOrder.C_VDEF1;//质量等级主键-发运单
                                modfyditem.C_FREE_TERM = modOrder.C_FREE1;//自由项1
                                modfyditem.C_FREE_TERM2 = modOrder.C_FREE2;//自由项2
                                modfyditem.C_PACK = modOrder.C_PACK;//包装要求
                                modfyditem.C_STD_CODE = modOrder.C_STD_CODE;//执行标准
                                modfyditem.N_COM_AMOUNT_WGT = modOrder.N_FNUM;//原始订单辅数量
                                modfyditem.N_WGT = modOrder.N_WGT;//原始订单数量
                                modfyditem.C_EQUATION_FACTOR = modOrder.N_HSL.ToString();//换算率
                                modfyditem.C_UNITIS = modOrder.C_UNITID;//主计量单位ID
                                modfyditem.C_ORGO_CUST = modOrder.C_CUST_NAME;//订货客户
                                modfyditem.C_CGC = modOrder.C_RECEIPTCORPID;//收货单位-发运单
                                modfyditem.C_ORDER_TYPE = modOrder.N_TYPE.ToString();//订单类型 8线材 6钢坯 831废乱材  841焦化产品 851渣
                                modfyditem.C_SEND_AREA = modOrder.C_RECEIPTAREAID;//到货地区-发运单
                                modfyditem.C_AREA = modOrder.C_RECEIVEADDRESS;//到货地址-发运单
                                modfyditem.C_EMP_ID = ltlempid.Text;
                                modfyditem.C_EMP_NAME = hidempname.Value;
                                modfyditem.C_CON_NO = modOrder.C_CON_NO;//合同号
                                modfyditem.C_PLAN_ID = dt.Rows[i]["PKPLAN"].ToString();//日计划主键
                                modfyditem.C_NO = modOrder.C_ORDER_NO;//订单号
                                modfyditem.C_ORDERPK = modOrder.C_ID;//订单主键
                                modfyditem.C_CUSTNO = modOrder.C_CUST_NO;//客户编码
                                modfyditem.C_AU_UNITIS = modOrder.C_FUNITID;//辅单位
                                modfyditem.C_EMP_ID = ltlempid.Text;//操作人ID
                                modfyditem.C_EMP_NAME = hidempname.Value;//操作人ID
                                item.Add(modfyditem);
                                #endregion
                            }
                        }
                    }
                    if (item.Count > 0)
                    {
                        if (tmd_dispatch.InsertFYD_ITEM(item))
                        {
                            Session[ltlempid.Text] = null;
                            BindList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }
        //刷新
        protected void imgbtnJz_Click(object sender, ImageClickEventArgs e)
        {
            AddOrderList();

        }
        //删除行
        protected void btndelrow_Click(object sender, EventArgs e)
        {
            bool result = false;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkOrder");
                HtmlInputText txtflag = (HtmlInputText)rptList.Items[i].FindControl("txtflag");
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



        /// <summary>
        /// 获取收货单位/开票单位
        /// </summary>
        /// <param name="C_NC_M_ID">NC客商管理档案主键</param>
        /// <returns></returns>
        public string GetCust(string C_NC_M_ID)
        {
            string str = string.Empty;
            Mod_TS_CUSTFILE mod = ts_custfile.GetCustModel(C_NC_M_ID);
            if (mod != null)
            {
                str = mod.C_NAME;
            }
            return str;
        }

        public string GetArea(object orderID)
        {
            string str = string.Empty;
            Mod_TMO_ORDER mod = tmo_order.GetModel(orderID.ToString());
            if (mod != null)
            {
                str = mod.C_AREA;
            }
            return str;

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

        string[] mattype = { "6", "8", "805", "806", "807" };

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)e.Item.FindControl("chkOrder");
            DropDownList dropzldj = (DropDownList)e.Item.FindControl("dropzldj");
            DropDownList dropshdz = (DropDownList)e.Item.FindControl("dropshdz");

            Literal ltlzldj = (Literal)e.Item.FindControl("ltlzldj");//质量等级
            Literal ltlshdz = (Literal)e.Item.FindControl("ltlshdz");//收货地址
            Literal ltlcustno = (Literal)e.Item.FindControl("ltlcustno");//客户编码
            Literal ltlyfywgt = (Literal)e.Item.FindControl("ltlyfywgt");//订单已发数量

            #region //订单出库量


            decimal yfywgt = 0;

            DataTable dtorder = tmo_order.GetOUTSTOCKWGT(chkOrder.Value, txtsendcode.Text);
            if (dtorder.Rows.Count > 0)
            {
                yfywgt = Convert.ToDecimal(dtorder.Rows[0]["N_WGT"]);

            }
            ltlyfywgt.Text = yfywgt.ToString();


            #endregion


            #region //质量
            DataTable dtzl = tqb_checkstate.GetCheckState("").Tables[0];
            if (dtzl.Rows.Count > 0)
            {
                dropzldj.DataSource = dtzl;
                dropzldj.DataTextField = "C_CHECKSTATE_NAME";
                dropzldj.DataValueField = "C_ID";
                dropzldj.DataBind();
                dropzldj.SelectedIndex = dropzldj.Items.IndexOf(dropzldj.Items.FindByValue(ltlzldj.Text));
            }
            #endregion

            #region //收货地址
            //收货地址
            DataTable dtaddr = ts_custaddr.GetAddr("", "", "", ltlcustno.Text, "").Tables[0];
            if (dtaddr.Rows.Count > 0)
            {
                dropshdz.DataSource = dtaddr;
                dropshdz.DataTextField = "C_CGAREA";
                dropshdz.DataValueField = "C_CGAREA";
                dropshdz.DataBind();
                dropshdz.SelectedIndex = dropshdz.Items.IndexOf(dropshdz.Items.FindByValue(ltlshdz.Text));
            }
            #endregion


        }

        //保存
        protected void btnsave_Click(object sender, EventArgs e)
        {

            if (ltlempid.Text == ltlzdrID.Text)
            {


                Bll_TMD_CAR_NUMBER tmd_car_number = new Bll_TMD_CAR_NUMBER();

                bool result6 = tmd_car_number.Exists(txtcph.Text.Trim());//判断车号禁止发运

                if (result6)
                {
                    WebMsg.MessageBox("该车号已经连续3次未接受GPS任务，已被禁止制作发运单");
                }
                else
                {

                    bool result = true;
                    bool result2 = true;//计划发运量是否超出原订单量
                    bool sfxc = dropsfxc.SelectedItem.Text == "是" ? true : false;//是否线材销售
                    int row = 0;//行号

                    #region//数据操作
                    for (int i = 0; i < rptList.Items.Count; i++)
                    {
                        HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkOrder");//订单ID
                        HtmlInputText txtjhfyl = (HtmlInputText)rptList.Items[i].FindControl("txtjhfyl");//发运数量
                        HtmlInputText txtarea = (HtmlInputText)rptList.Items[i].FindControl("txtarea");//区域
                        HtmlInputText txtflag = (HtmlInputText)rptList.Items[i].FindControl("txtflag");//标识Y/N  原订单/新订单
                        TextBox txtPack_Code = (TextBox)rptList.Items[i].FindControl("txtPack_Code");//包装要求
                        TextBox txtStd_Code = (TextBox)rptList.Items[i].FindControl("txtStd_Code");//执行标准
                        DropDownList dropzldj = (DropDownList)rptList.Items[i].FindControl("dropzldj");//质量等级
                        Literal ltlmatcode = (Literal)rptList.Items[i].FindControl("ltlmatcode");//物料编码
                        Literal ltloldfyl = (Literal)rptList.Items[i].FindControl("ltloldfyl");//原发运计划量

                        Literal ltlorderwgt = (Literal)rptList.Items[i].FindControl("ltlorderwgt");//订单量

                        //订单可超出量
                        decimal orderwgt = (Convert.ToDecimal(ltlorderwgt.Text) * Convert.ToDecimal(hidsf.Value)) + Convert.ToDecimal(ltlorderwgt.Text);

                        //订单已出库量+订单在途量+在做计划量
                        decimal fysumwgt = tmo_order.GetYLX_YFWGT(chkOrder.Value) + Convert.ToDecimal(txtjhfyl.Value ?? "0");

                        if (fysumwgt > orderwgt)
                        {
                            row = i + 1;
                            result2 = false;
                            break;
                        }
                        else
                        {
                            if (sfxc)//线材
                            {
                                if (!tmo_order.IsFy_Edit(Convert.ToDecimal(txtjhfyl.Value ?? "0"), Convert.ToDecimal(ltloldfyl.Text == "" ? "0" : ltloldfyl.Text), ltlmatcode.Text, txtStd_Code.Text, txtarea.Value, txtPack_Code.Text, dropzldj.SelectedItem.Text))
                                {
                                    result = false;
                                }
                            }
                        }
                    }
                    #endregion

                    if (result2)
                    {
                        if (sfxc)//线材
                        {
                            if (result)
                            {
                                if (UpdateFyd())
                                {
                                    WebMsg.MessageBox("保存成功");
                                    BindList();
                                }
                            }
                            else
                            {
                                WebMsg.MessageBox("当前发运数量已超出可发运量");
                            }
                        }
                        else
                        {
                            if (UpdateFyd())
                            {
                                WebMsg.MessageBox("保存成功");
                                BindList();
                            }
                        }

                    }
                    else
                    {
                        decimal pl = Convert.ToDecimal(hidsf.Value) * 100;
                        WebMsg.MessageBox("当前第" + row + "行,计划发运数量已超出订单数量" + pl + "%");

                    }
                }
            }
            else
            {
                WebMsg.MessageBox("当前用户与发运制单人不符，无权限操作！");
            }


        }

        /// <summary>
        /// 修改发运单
        /// </summary>
        /// <returns></returns>
        private bool UpdateFyd()
        {


            decimal fyzs = 0;//发运支数
            decimal fywgt = 0;//发运量

            #region //表体
            List<Mod_TMD_DISPATCHDETAILS> item = new List<Mod_TMD_DISPATCHDETAILS>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                //HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkOrder");//订单主键
                HtmlInputText txtfyzs = (HtmlInputText)rptList.Items[i].FindControl("txtfyzs");//发运支数
                HtmlInputText txtjhfyl = (HtmlInputText)rptList.Items[i].FindControl("txtjhfyl");//发运数量
                HtmlInputHidden hidC_CGID = (HtmlInputHidden)rptList.Items[i].FindControl("hidC_CGID");//收货单位
                HtmlInputHidden hidshdq = (HtmlInputHidden)rptList.Items[i].FindControl("hidshdq");//收货地区
                TextBox txtPack_Code = (TextBox)rptList.Items[i].FindControl("txtPack_Code");//包装要求
                DropDownList dropzldj = (DropDownList)rptList.Items[i].FindControl("dropzldj");//质量等级
                HtmlInputText txtqtyq = (HtmlInputText)rptList.Items[i].FindControl("txtqtyq");//其他要求
                DropDownList dropshdz = (DropDownList)rptList.Items[i].FindControl("dropshdz");//收货地址
                HtmlInputHidden hidckid = (HtmlInputHidden)rptList.Items[i].FindControl("hidckid");//仓库ID
                HtmlInputText txtckname = (HtmlInputText)rptList.Items[i].FindControl("txtckname");//仓库名称
                HtmlInputHidden hidpkid = (HtmlInputHidden)rptList.Items[i].FindControl("hidpkid");//发运单明细主键
                HtmlInputText txtremark = (HtmlInputText)rptList.Items[i].FindControl("txtremark");//行备注
                TextBox txtStd_Code = (TextBox)rptList.Items[i].FindControl("txtStd_Code");//执行标准
                TextBox txtC_FREE1 = (TextBox)rptList.Items[i].FindControl("txtC_FREE1");//自由项1
                TextBox txtC_FREE2 = (TextBox)rptList.Items[i].FindControl("txtC_FREE2");//自由项2

                if (!string.IsNullOrEmpty(txtfyzs.Value) & !string.IsNullOrEmpty(txtjhfyl.Value))
                {
                    fyzs += Convert.ToDecimal(txtfyzs.Value);
                    fywgt += Convert.ToDecimal(txtjhfyl.Value);
                }


                #region //update
                Mod_TMD_DISPATCHDETAILS modfyditem = tmd_dispatchdetails.GetModel(hidpkid.Value);
                modfyditem.C_ID = hidpkid.Value;//主键
                modfyditem.C_QUALIRY_LEV = dropzldj.SelectedItem.Value;//质量等级主键-发运单
                modfyditem.C_JUDGE_LEV_ZH = dropzldj.SelectedItem.Text;//质量等级编码-发运单
                modfyditem.C_FREE_TERM = txtC_FREE1.Text;//自由项1
                modfyditem.C_FREE_TERM2 = txtC_FREE2.Text;//自由项2
                modfyditem.C_STD_CODE = txtStd_Code.Text;//执行标准
                modfyditem.C_PACK = txtPack_Code.Text;//包装要求
                modfyditem.C_ELSENEED = txtqtyq.Value;//其他要求?
                modfyditem.C_REMARK = txtremark.Value;//行备注*****
                modfyditem.C_CGC = hidC_CGID.Value;//收货单位-发运单
                modfyditem.C_SEND_AREA = hidshdq.Value;//到货地区-发运单
                modfyditem.C_AREA = dropshdz.SelectedItem?.Value ?? "";//到货地址-发运单
                modfyditem.C_EMP_ID = ltlempid.Text;
                modfyditem.C_EMP_NAME = hidempname.Value;
                modfyditem.N_FYZS = Convert.ToDecimal(txtfyzs.Value == "" ? "0" : txtfyzs.Value);//发运支数
                modfyditem.N_FYWGT = Convert.ToDecimal(txtjhfyl.Value == "" ? "0" : txtjhfyl.Value);//发运数量
                modfyditem.C_SEND_STOCK = txtckname.Value;//发运仓库名称
                modfyditem.C_SEND_STOCK_PK = hidckid.Value;//发运仓库ID
                modfyditem.FLAG = "Y";
                item.Add(modfyditem);
                #endregion
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
            modfyd.C_EXTEND5 = ltltype.Text;//订单类型 8线材 6钢坯 831废乱材  841焦化产品 851渣
            modfyd.N_QUA = fyzs;//发运支数
            modfyd.N_WGT = fywgt;//发运量

            modfyd.N_IS_EXPORT = Convert.ToDecimal(dropsfbdj.SelectedValue);//是否包到价
            modfyd.C_EXTEND2 = txtxnch.Text;//虚拟车号
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
        //删除发运单
        protected void btndel_Click(object sender, EventArgs e)
        {
            if (ltlempid.Text == ltlzdrID.Text)
            {
                bool sfxc = dropsfxc.SelectedItem.Text == "是" ? true : false;//是否线材销售

                if (sfxc)
                {
                    if (ltlstatus.Text == "自由状态")
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
                        if (tmd_dispatch.DelRFFYD(ltlpkid.Text))
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
                        else
                        {
                            WebMsg.MessageBox("请先同步删除RF发运单");
                        }
                    }
                }
                else
                {
                    if (ltlstatus.Text == "自由状态")
                    {
                        if (tmd_dispatch.DelFYD(txtsendcode.Text, ltlempid.Text))
                        {

                            var logger = Logger.CreateLogger(this.GetType());
                            logger.Info("用户ID" + ltlempid.Text + DateTime.Now.ToString() + ";删除发运单号" + txtsendcode.Text);

                            WebMsg.MessageBox("删除成功", "fydList.aspx");
                        }
                    }
                    else
                    {
                        if (tmd_dispatch.DelNCFYD_GP(txtsendcode.Text))
                        {
                            if (tmd_dispatch.DelFYD(txtsendcode.Text, ltlempid.Text))
                            {

                                var logger = Logger.CreateLogger(this.GetType());
                                logger.Info("用户ID" + ltlempid.Text + DateTime.Now.ToString() + ";删除发运单号" + txtsendcode.Text);

                                WebMsg.MessageBox("删除成功", "fydList.aspx");
                            }
                        }
                        else
                        {
                            WebMsg.MessageBox("请先同步关闭NC发运单！");
                        }
                    }
                }
            }
            else
            {
                WebMsg.MessageBox("当前用户与发运制单人不符，无权限操作！");
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
            string result = "";
            ApiDispatchOrder apifyd = new ApiDispatchOrder();
            string filePath = "~/FileInterface/download/nc_" + txtsendcode.Text + ".xml";
            string xmlFileName = System.Web.HttpContext.Current.Server.MapPath(filePath);
            List<string> resList = apifyd.SendXmlApiDispatchOrder(txtsendcode.Text, xmlFileName, ltlempid.Text, Convert.ToInt32(ltltype.Text));

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
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + ex.Message + "');</script>", false);
            }


        }
        //导入物流
        protected void btnwl_Click(object sender, EventArgs e)
        {
            string result = "";
            ApiWL apiwl = new ApiWL();
            string filePath = "~/FileInterface/download/wl_" + txtsendcode.Text + ".xml";
            string xmlFileName = System.Web.HttpContext.Current.Server.MapPath(filePath);
            string resList = apiwl.SendXmlApiDispatchOrder(txtsendcode.Text, xmlFileName, ltlempid.Text);//success

            string jg = resList == "success" ? "导入物流成功" : "导入物流失败";

            result = "单据号：" + txtsendcode.Text + ",结果：" + jg;

            if (resList == "success")
            {
                if (tmd_dispatch.UpdateFydStatus(txtsendcode.Text, 4, ltlempid.Text, hidempname.Value, "3"))
                {
                    //WebMsg.MessageBox(result);
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + result + "');</script>", false);
                    BindList();
                }
            }
            else
            {
                //WebMsg.MessageBox(result);
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + result + "');</script>", false);
            }
        }

        //发运基本信息加载
        protected void imgbtnInfo_Click(object sender, ImageClickEventArgs e)
        {
            BindList();
        }

        //虚拟导入物流
        protected void btnwl2_Click(object sender, EventArgs e)
        {
            if (tmd_dispatch.UpdateFydStatus(txtsendcode.Text, 4, ltlempid.Text, hidempname.Value, "3"))
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('虚拟导入物流成功');</script>", false);
                BindList();
            }
        }
    }
}