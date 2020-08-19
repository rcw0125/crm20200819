using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using NF.BLL;
using NF.MODEL;
using System.Data;
using NF.Framework;

namespace CRM.WebForms.Sale_App
{
    public partial class fyd_w : System.Web.UI.Page
    {
        private static DataTable dtOrder = new DataTable();

        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();
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

        private Bll_GPS bllgps = new Bll_GPS();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlempid.Text = vUser.Id;
                    ltlempname.Text = vUser.Name;
                    txtzdr.Text = vUser.Name;
                    SetData();//初始化数据
                    GetDic();
                    txtfydt.Text = DateTime.Now.ToString("yyy-MM-dd");
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

            #region // 发运量控制
            DataTable dtfywgt = GetData("DM001");
            if (dtfywgt.Rows.Count > 0)
            {
                hidsfwgt.Value = dtfywgt.Rows[0]["C_DETAILCODE"].ToString();
            }
            #endregion

        }

        #region //初始化datatable
        private void SetData()
        {
            Session[ltlempid.Text] = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("C_ID", typeof(string));//订单主键
            dt.Columns.Add("C_CON_NO", typeof(string));//合同号
            dt.Columns.Add("C_STL_GRD", typeof(string));//钢种
            dt.Columns.Add("C_SPEC", typeof(string));//规格
            dt.Columns.Add("C_STD_CODE", typeof(string));//执行标准
            dt.Columns.Add("C_FREE1", typeof(string));//自由项1
            dt.Columns.Add("C_FREE2", typeof(string));//自由项2
            dt.Columns.Add("C_PACK", typeof(string));//包装要求
            dt.Columns.Add("N_WGT", typeof(string));//重量    
            dt.Columns.Add("C_VDEF1", typeof(string));//质量等级
            dt.Columns.Add("C_AREA", typeof(string));//区域
            dt.Columns.Add("C_MAT_CODE", typeof(string));//物料编码
            dt.Columns.Add("C_MAT_NAME", typeof(string));//物料名称
            dt.Columns.Add("C_CUST_NAME", typeof(string));//订货单位
            dt.Columns.Add("SHDW", typeof(string));//收货单位
            dt.Columns.Add("SHDQ", typeof(string));//收货地区
            dt.Columns.Add("C_RECEIVEADDRESS", typeof(string));//收货地址
            dt.Columns.Add("N_TYPE", typeof(string));//订单类型
            dt.Columns.Add("C_CUST_NO", typeof(string));//客户编码
            dt.Columns.Add("PKPLAN", typeof(string));//日计划主键
            dt.Columns.Add("YLXWGT", typeof(string));//已履行量
            dt.Columns.Add("DLXWGT", typeof(string));//待履行量
            dtOrder = dt;
        }
        #endregion

        private void BindOrderList()
        {

            if (Session[ltlempid.Text] != null)
            {
                DataTable dt = (DataTable)Session[ltlempid.Text];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //检测订单是否重复
                    if (getck(dt.Rows[i]["C_ID"].ToString()))
                    {
                        Mod_TMO_ORDER mod = tmo_order.GetModel(dt.Rows[i]["C_ID"].ToString());
                        if (mod != null)
                        {
                            ltltype.Text = mod.N_TYPE.ToString();//发运类型
                            ltlcon_no.Text = mod.C_CON_NO;//合同号
                            ltlcustname.Text = mod.C_CUST_NAME;//客户
                            hidcustno.Value = mod.C_CUST_NO;//客户编码
                            hidmatcode.Value = mod.C_MAT_CODE;//物料编码
                            hidarea.Value = mod.C_AREA;//销售区域

                            dtOrder.Rows.Add(new object[] {
                              dt.Rows[i]["C_ID"],
                              mod.C_CON_NO,
                              mod.C_STL_GRD,
                              mod.C_SPEC,
                              mod.C_STD_CODE,
                              mod.C_FREE1,
                              mod.C_FREE2,
                              mod.C_PACK,
                              mod.N_WGT,
                              mod.C_VDEF1,//质量等级
                              mod.C_AREA,//区域
                              mod.C_MAT_CODE,
                              mod.C_MAT_NAME,
                              mod.C_CUST_NAME,//订货单位
                              mod.C_RECEIPTCORPID,//收货单位
                              mod.C_RECEIPTAREAID,//收货地区
                              mod.C_RECEIVEADDRESS,//收货地址
                              mod.N_TYPE,
                              mod.C_CUST_NO,
                              dt.Rows[i]["PKPLAN"],//日计划主键
                              dt.Rows[i]["YLXWGT"],//已履行量
                              dt.Rows[i]["DLXWGT"],//待履行量
                              });
                        }
                    }
                }
            }
            if (dtOrder.Rows.Count > 0)
            {
                rptList.DataSource = dtOrder;
                rptList.DataBind();
                Session[ltlempid.Text] = null;
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                Session[ltlempid.Text] = null;


                txtcount.Value = "";
                txtsumwgt.Value = "";
            }
        }

        /// <summary>
        /// 检测仓库是否重复
        /// </summary>
        /// <param name="ckcode"></param>
        /// <returns></returns>
        private bool getck(string orderID)
        {
            bool result = true;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkOrder");
                if (orderID.Contains(chkOrder.Value))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        protected void imgbtnJz_Click(object sender, ImageClickEventArgs e)
        {
            BindOrderList();
        }
        //删除行
        protected void btndelrow_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkOrder");
                if (chkOrder.Checked)
                {
                    DataRow[] dr = dtOrder.Select("C_ID='" + chkOrder.Value + "'");
                    if (dr.Length > 0)
                    {
                        int index = dtOrder.Rows.IndexOf(dr[0]);
                        dtOrder.Rows.RemoveAt(index);
                    }
                }
            }
            if (dtOrder.Rows.Count > 0)
            {
                rptList.DataSource = dtOrder;
                rptList.DataBind();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                txtcount.Value = "";
                txtsumwgt.Value = "";
            }
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "sum();", true);

        }



        /// <summary>
        /// 获取收货单位/开票单位
        /// </summary>
        /// <param name="C_NC_M_ID">NC客商管理档案主键</param>
        /// <returns></returns>
        private string GetCust(string C_NC_M_ID)
        {
            string str = string.Empty;
            Mod_TS_CUSTFILE mod = ts_custfile.GetCustModel(C_NC_M_ID);
            if (mod != null)
            {
                str = mod.C_NAME;
            }

            return str;
        }

        private string GetArea(string id)
        {
            string str = string.Empty;
            Mod_TMB_AREA mod = tmb_area.GetModel(id);
            if (mod != null)
            {
                str = mod.C_NAME;
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

            DropDownList dropzldj = (DropDownList)e.Item.FindControl("dropzldj");//质量等级

            DropDownList dropshdz = (DropDownList)e.Item.FindControl("dropshdz");//收货单位

            Literal ltlzldj = (Literal)e.Item.FindControl("ltlzldj");//质量等级
            Literal ltlshdz = (Literal)e.Item.FindControl("ltlshdz");//收货地址
            Literal ltlcustno = (Literal)e.Item.FindControl("ltlcustno");//客户编码

            HtmlInputText txtC_CGC = (HtmlInputText)e.Item.FindControl("txtC_CGC");//收货单位
            HtmlInputText txtshdq = (HtmlInputText)e.Item.FindControl("txtshdq");//收货地区

            txtC_CGC.Value = GetCust(txtC_CGC.Value);
            txtshdq.Value = GetArea(txtshdq.Value);

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

            #region //可发量

            #endregion


        }

        //保存
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (rptList.Items.Count > 0)
            {
                bool result = true;


                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkOrder");//订单ID
                    HtmlInputText txtjhfyl = (HtmlInputText)rptList.Items[i].FindControl("txtjhfyl");//发运数量
                    HtmlInputText txtarea = (HtmlInputText)rptList.Items[i].FindControl("txtarea");//区域
                    TextBox txtPack_Code = (TextBox)rptList.Items[i].FindControl("txtPack_Code");//包装要求
                    TextBox txtStd_Code = (TextBox)rptList.Items[i].FindControl("txtStd_Code");//执行标准
                    DropDownList dropzldj = (DropDownList)rptList.Items[i].FindControl("dropzldj");//质量等级
                    Literal ltlmatcode = (Literal)rptList.Items[i].FindControl("ltlmatcode");//物料编码

                    Literal ltlorderwgt = (Literal)rptList.Items[i].FindControl("ltlorderwgt");//订单量

                    decimal fly = 0;
                    decimal.TryParse(txtjhfyl.Value, out fly);

                    if (!tmo_order.IsFy(fly, ltlmatcode.Text, txtStd_Code.Text, txtarea.Value, txtPack_Code.Text, dropzldj.SelectedItem.Text))
                    {
                        result = false;
                    }
                }

                if (result)
                {
                    if (InsertFyd())
                    {
                        WebMsg.MessageBox("保存成功", "fydEdit.aspx?ID=" + txtsendcode.Text);
                    }
                }
                else
                {
                    WebMsg.MessageBox("当前发运数量已超出可发运量");
                    Session[ltlempid.Text] = null;
                }

            }
            else
            {
                WebMsg.MessageBox("请添加发运明细");
            }

        }

        /// <summary>
        /// 添加发运单
        /// </summary>
        /// <returns></returns>
        private bool InsertFyd()
        {


            decimal fyzs = 0;
            decimal fywgt = 0;

            string sendcode = randomnumber.CreateDispID();//发运单据号

            #region //表体
            List<Mod_TMD_DISPATCHDETAILS> item = new List<Mod_TMD_DISPATCHDETAILS>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkOrder");//订单主键
                HtmlInputText txtfyzs = (HtmlInputText)rptList.Items[i].FindControl("txtfyzs");//发运支数
                HtmlInputText txtjhfyl = (HtmlInputText)rptList.Items[i].FindControl("txtjhfyl");//发运数量
                HtmlInputHidden hidC_CGID = (HtmlInputHidden)rptList.Items[i].FindControl("hidC_CGID");//收货单位
                HtmlInputHidden hidshdq = (HtmlInputHidden)rptList.Items[i].FindControl("hidshdq");//收货地区
                TextBox txtPack_Code = (TextBox)rptList.Items[i].FindControl("txtPack_Code");//包装要求
                DropDownList dropzldj = (DropDownList)rptList.Items[i].FindControl("dropzldj");//质量等级
                DropDownList dropshdz = (DropDownList)rptList.Items[i].FindControl("dropshdz");//收货地址
                Literal ltlpkplan = (Literal)rptList.Items[i].FindControl("ltlpkplan");//日计划主键
                Literal ltlcustno = (Literal)rptList.Items[i].FindControl("ltlcustno");//客户编码

                HtmlInputHidden hidckid = (HtmlInputHidden)rptList.Items[i].FindControl("hidckid");//仓库ID
                HtmlInputText txtckname = (HtmlInputText)rptList.Items[i].FindControl("txtckname");//仓库名称
                HtmlInputText txtqtyq = (HtmlInputText)rptList.Items[i].FindControl("txtqtyq");//其他要求
                HtmlInputText txtremark = (HtmlInputText)rptList.Items[i].FindControl("txtremark");//行备注
                TextBox txtStd_Code = (TextBox)rptList.Items[i].FindControl("txtStd_Code");//执行标准
                TextBox txtC_FREE1 = (TextBox)rptList.Items[i].FindControl("txtC_FREE1");//自由项1
                TextBox txtC_FREE2 = (TextBox)rptList.Items[i].FindControl("txtC_FREE2");//自由项2

                Mod_TMO_ORDER modOrder = tmo_order.GetModel(chkOrder.Value);
                if (modOrder != null)
                {
                    fyzs += Convert.ToDecimal(txtfyzs.Value ?? "0");
                    fywgt += Convert.ToDecimal(txtjhfyl.Value ?? "0");

                    Mod_TMD_DISPATCHDETAILS modfyditem = new Mod_TMD_DISPATCHDETAILS();
                    modfyditem.C_DISPATCH_ID = sendcode;//发运单单据号
                    modfyditem.C_MAT_CODE = modOrder.C_MAT_CODE;//物料编码
                    modfyditem.C_MAT_NAME = modOrder.C_MAT_NAME;//物料名称
                    modfyditem.C_SPEC = modOrder.C_SPEC;//规格
                    modfyditem.C_STL_GRD = modOrder.C_STL_GRD;//钢种
                    modfyditem.C_QUALIRY_LEV = dropzldj.SelectedItem.Value;//质量等级主键-发运单
                    modfyditem.C_JUDGE_LEV_ZH = dropzldj.SelectedItem.Text;//质量等级编码
                    modfyditem.C_FREE_TERM = txtC_FREE1.Text;//自由项
                    modfyditem.C_FREE_TERM2 = txtC_FREE2.Text;//自由项
                    modfyditem.C_PACK = txtPack_Code.Text;//包装要求
                    modfyditem.C_STD_CODE = txtStd_Code.Text;//执行标准
                    modfyditem.C_ELSENEED = txtqtyq.Value;//其他要求?
                    modfyditem.C_REMARK = txtremark.Value;//行备注*****
                    modfyditem.N_COM_AMOUNT_WGT = modOrder.N_FNUM;//原始订单辅数量
                    modfyditem.N_WGT = modOrder.N_WGT;//原始订单数量
                    modfyditem.C_EQUATION_FACTOR = modOrder.N_HSL.ToString();//换算率
                    modfyditem.C_UNITIS = modOrder.C_UNITID;//主计量单位ID
                    modfyditem.C_ORGO_CUST = modOrder.C_CUST_NAME;//订货客户
                    modfyditem.C_CGC = hidC_CGID.Value;//收货单位-发运单
                    modfyditem.C_ORDER_TYPE = modOrder.N_TYPE.ToString() == "8" ? "805" : modOrder.N_TYPE.ToString();//订单类型 8线材 6钢坯 831废乱材  841焦化产品 851渣
                    modfyditem.C_SEND_AREA = hidshdq.Value;//到货地区-发运单
                    modfyditem.C_AREA = dropshdz.SelectedItem?.Value ?? "";//到货地址-发运单
                    modfyditem.C_EMP_ID = ltlempid.Text;
                    modfyditem.C_EMP_NAME = ltlempname.Text;
                    modfyditem.C_CON_NO = modOrder.C_CON_NO;//合同号
                    modfyditem.C_PLAN_ID = ltlpkplan.Text;//日计划主键
                    modfyditem.C_NO = modOrder.C_ORDER_NO;//订单号
                    modfyditem.C_ORDERPK = modOrder.C_ID;//订单主键
                    modfyditem.C_CUSTNO = ltlcustno.Text;//客户编码
                    modfyditem.N_FYZS = Convert.ToDecimal(txtfyzs.Value == "" ? "0" : txtfyzs.Value);//发运支数
                    modfyditem.N_FYWGT = Convert.ToDecimal(txtjhfyl.Value == "" ? "0" : txtjhfyl.Value);//发运数量
                    modfyditem.C_SEND_STOCK = txtckname.Value;//发运仓库名称
                    modfyditem.C_SEND_STOCK_PK = hidckid.Value;//发运仓库ID
                    modfyditem.C_PRODUCT_ID = "";//库存产品ID
                    modfyditem.C_AU_UNITIS = modOrder.C_FUNITID;//辅单位
                    modfyditem.N_PRICE = 0;//到货地点费用

                    item.Add(modfyditem);
                }
            }
            #endregion

            #region//表头
            Mod_TMD_DISPATCH modfyd = new Mod_TMD_DISPATCH();

            modfyd.C_ID = sendcode;//发运单单据号
            modfyd.C_GPS_NO = txtgps.Text;//GPS号
            modfyd.D_DISP_DT = Convert.ToDateTime(txtfydt.Text);//发运日期
            modfyd.C_SHIPVIA = dropfyfs.SelectedItem.Value;//发运方式
            modfyd.C_COMCAR = dropcys.SelectedItem.Value;//承运商
            modfyd.C_IS_WIRESALE = dropsfxc.SelectedItem.Text;//汉字是否线材
            modfyd.C_IS_WIRESALE_ID = dropsfxc.SelectedItem.Value;//是否线材主键
            modfyd.C_LIC_PLA_NO = txtcph.Text;//车牌号
            modfyd.C_ATSTATION = txtdz.Text;//到站
            modfyd.C_CREATE_ID = ltlempid.Text;//制单人
            modfyd.C_EMP_ID = ltlempid.Text;//修改人ID
            modfyd.C_EMP_NAME = ltlempname.Text;//修改人
            modfyd.C_EXTEND5 = ltltype.Text;//订单类型 8线材 6钢坯 831废乱材  841焦化产品 851渣
            modfyd.C_CUSTNAME = ltlcustname.Text;//客户
            modfyd.C_CON_NO = ltlcon_no.Text;//合同号
            modfyd.N_QUA = fyzs;//发运支数
            modfyd.N_WGT = fywgt;//发运量
            modfyd.N_IS_EXPORT = 0;//是否包到价
            modfyd.C_EXTEND2 = txtcph.Text;//虚拟车号
            Mod_TMO_CON modCon = tmo_con.GetModel(ltlcon_no.Text);
            if (modCon != null)
            {
                modfyd.C_BUSINESS_DEPT = modCon.C_DEPTID;//业务部门
                modfyd.C_BUSINESS_ID = modCon.C_EMPLOYEEID;//业务员
            }
            #endregion

            if (tmd_dispatch.InsertFYD(modfyd, item))
            {
                txtsendcode.Text = sendcode;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}