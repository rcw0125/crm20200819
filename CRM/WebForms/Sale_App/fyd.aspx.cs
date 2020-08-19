﻿using System;
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
using NF.BLL.D;

namespace CRM.WebForms.Sale_App
{
    public partial class fyd : System.Web.UI.Page
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
                    Session["DT" + vUser.Id] = null;
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
            DataTable dt = CreateTable();
            dtOrder = dt;
        }

        private static DataTable CreateTable()
        {
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
            dt.Columns.Add("KFYWGT", typeof(string));//可发运量
            dt.Columns.Add("KFYQUA", typeof(string));//可发支数
            return dt;
        }
        #endregion

        private void BindOrderList()
        {
            DataTable tmpDT = new DataTable();
            if (Session["DT" + ltlempid.Text] != null)
            {
                tmpDT = Session["DT" + ltlempid.Text] as DataTable;
            }
            else
            {
                tmpDT = CreateTable();
            }
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

                            string areafalg = ts_dic.GetAreaFlag(mod.C_AREA);//获取区域是否按客户发运Y/N

                            //线材
                            if (dropsfxc.SelectedItem.Text == "是")
                            {
                                if (mod.C_STL_GRD == "GCr15")
                                {
                                    tmpDT.Rows.Add(new object[] {
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
                                                  "",//可发运量
                                                  ""//可发支数
                                                  });
                                }
                                else
                                {
                                    #region //引用线材自由项
                                    DataTable dtroll = tmo_order.GetFyd_Roll_Prodcut(mod.C_MAT_CODE, mod.C_STD_CODE, mod.C_AREA).Tables[0];

                                    if (dtroll.Rows.Count > 0)
                                    {
                                        #region//可发运量/可发支数

                                        decimal sumztwgt = 0;//在途总量
                                        decimal sumztzs = 0;//在途总支数
                                        decimal sumkcwgt = 0;//库存总量
                                        decimal sumkczs = 0;//库存总支数
                                        decimal kfwgt = 0;//可发重量
                                        decimal kfzs = 0;//可发支数

                                        Mod_TQB_CHECKSTATE modzl = tqb_checkstate.GetModel(mod.C_VDEF1);

                                        DataTable dtztwgt = areafalg == "N" ? tmo_order.ZTWGT(mod.C_MAT_CODE, dtroll.Rows[0]["C_STD_CODE"].ToString(), mod.C_AREA, dtroll.Rows[0]["C_BZYQ"].ToString(), modzl.C_CHECKSTATE_NAME).Tables[0] : tmo_order.ZTWGT(mod.C_MAT_CODE, dtroll.Rows[0]["C_STD_CODE"].ToString(), mod.C_AREA, dtroll.Rows[0]["C_BZYQ"].ToString(), modzl.C_CHECKSTATE_NAME, mod.C_CUST_NAME, mod.C_CON_NO).Tables[0];
                                        if (dtztwgt.Rows.Count > 0)
                                        {
                                            sumztwgt = Convert.ToDecimal(dtztwgt.Compute("sum(N_FYWGT)", "true"));//在途量
                                            sumztzs = Convert.ToDecimal(dtztwgt.Compute("sum(N_FYZS)", "true"));//在途支数
                                        }
                                        DataTable dtkcwgt = areafalg == "N" ? tmo_order.KCWGT(mod.C_MAT_CODE, dtroll.Rows[0]["C_STD_CODE"].ToString(), mod.C_AREA, dtroll.Rows[0]["C_BZYQ"].ToString(), modzl.C_CHECKSTATE_NAME).Tables[0] : tmo_order.KCWGT(mod.C_MAT_CODE, dtroll.Rows[0]["C_STD_CODE"].ToString(), mod.C_AREA, dtroll.Rows[0]["C_BZYQ"].ToString(), modzl.C_CHECKSTATE_NAME, mod.C_CUST_NAME, mod.C_CON_NO).Tables[0];
                                        if (dtkcwgt.Rows.Count > 0)
                                        {
                                            sumkcwgt = Convert.ToDecimal(dtkcwgt.Rows[0]["N_WGT"]);//库存量
                                            sumkczs = Convert.ToDecimal(dtkcwgt.Rows[0]["jianshu"]);//库存支数
                                        }
                                        kfwgt = sumkcwgt - sumztwgt;
                                        kfzs = sumkczs - sumztzs;
                                        #endregion

                                        tmpDT.Rows.Add(new object[] {
                                                      dt.Rows[i]["C_ID"],
                                                      mod.C_CON_NO,
                                                      mod.C_STL_GRD,
                                                      mod.C_SPEC,
                                                      mod.C_STD_CODE,
                                                      dtroll.Rows[0]["C_ZYX1"].ToString(),
                                                      dtroll.Rows[0]["C_ZYX2"].ToString(),
                                                      dtroll.Rows[0]["C_BZYQ"].ToString(),
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
                                                      kfwgt.ToString(),//可发运量
                                                      kfzs.ToString()//可发支数
                                                      });
                                    }
                                    else
                                    {
                                        #region//可发运量/可发支数

                                        decimal sumztwgt = 0;//在途总量
                                        decimal sumztzs = 0;//在途总支数
                                        decimal sumkcwgt = 0;//库存总量
                                        decimal sumkczs = 0;//库存总支数
                                        decimal kfwgt = 0;//可发重量
                                        decimal kfzs = 0;//可发支数

                                        Mod_TQB_CHECKSTATE modzl = tqb_checkstate.GetModel(mod.C_VDEF1);

                                        DataTable dtztwgt = areafalg == "N" ? tmo_order.ZTWGT(mod.C_MAT_CODE, mod.C_STD_CODE, mod.C_AREA, mod.C_PACK, modzl.C_CHECKSTATE_NAME).Tables[0] : tmo_order.ZTWGT(mod.C_MAT_CODE, mod.C_STD_CODE, mod.C_AREA, mod.C_PACK, modzl.C_CHECKSTATE_NAME, mod.C_CUST_NAME, mod.C_CON_NO).Tables[0];
                                        if (dtztwgt.Rows.Count > 0)
                                        {
                                            sumztwgt = Convert.ToDecimal(dtztwgt.Compute("sum(N_FYWGT)", "true"));
                                            sumztzs = Convert.ToDecimal(dtztwgt.Compute("sum(N_FYZS)", "true"));
                                        }
                                        DataTable dtkcwgt = areafalg == "N" ? tmo_order.KCWGT(mod.C_MAT_CODE, mod.C_STD_CODE, mod.C_AREA, mod.C_PACK, modzl.C_CHECKSTATE_NAME).Tables[0] : tmo_order.KCWGT(mod.C_MAT_CODE, mod.C_STD_CODE, mod.C_AREA, mod.C_PACK, modzl.C_CHECKSTATE_NAME, mod.C_CUST_NAME, mod.C_CON_NO).Tables[0];
                                        if (dtkcwgt.Rows.Count > 0)
                                        {
                                            sumkcwgt = Convert.ToDecimal(dtkcwgt.Rows[0]["N_WGT"]);
                                            sumkczs = Convert.ToDecimal(dtkcwgt.Rows[0]["jianshu"]);
                                        }
                                        kfwgt = sumkcwgt - sumztwgt;
                                        kfzs = sumkczs - sumztzs;
                                        #endregion

                                        tmpDT.Rows.Add(new object[] {
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
                                                      kfwgt.ToString(),//可发运量
                                                      kfzs.ToString()//可发支数
                                                      });
                                    }
                                    #endregion
                                }
                            }
                            else
                            {
                                #region //钢坯
                                tmpDT.Rows.Add(new object[] {
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
                                              "",//可发运量
                                              ""//可发支数
                                              });

                                #endregion
                            }

                        }
                    }
                }
            }
            if (tmpDT.Rows.Count > 0)
            {
                rptList.DataSource = tmpDT;
                Session["DT" + ltlempid.Text] = tmpDT;
                rptList.DataBind();
                Session[ltlempid.Text] = null;
            }
            else
            {
                rptList.DataSource = null;
                Session["DT" + ltlempid.Text] = null;
                rptList.DataBind();
                txtcount.Value = "";
                txtsumwgt.Value = "";

                Session[ltlempid.Text] = null;
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
            Mod_TMO_ORDER mod = tmo_order.GetModel(orderID);

            #region //客户余额查询
            Mod_TS_CUSTFILE modCustInfo = ts_custfile.GetModelCode(mod.C_CUST_NO);
            DataTable dt = ts_custfile.GetCusetMoney(modCustInfo.C_ID).Tables[0];
            if (dt.Rows.Count > 0)
            {
                lblcustmoney.Text = modCustInfo.C_NAME + ",余额：" + decimal.Parse(dt.Rows[0]["KHYE"].ToString()).ToString("###,##0.00") + "&nbsp;更新时间：" + Convert.ToDateTime(dt.Rows[0]["TS"].ToString()).ToString();
            }
            else
            {
                lblcustmoney.Text = "";
            }


            #endregion

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkOrder");
                Literal ltlC_STL_GRD = (Literal)rptList.Items[i].FindControl("ltlC_STL_GRD");
                Literal ltlC_SPEC = (Literal)rptList.Items[i].FindControl("ltlC_SPEC");
                if (ltlC_STL_GRD.Text == mod.C_STL_GRD && ltlC_SPEC.Text == mod.C_SPEC)
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
            try
            {


                DataTable dtTmp = new DataTable();
                if (Session["DT" + ltlempid.Text] != null)
                {
                    dtTmp = (DataTable)Session["DT" + ltlempid.Text];
                }
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkOrder");
                    if (chkOrder.Checked)
                    {
                        DataRow[] dr = dtTmp.Select("C_ID='" + chkOrder.Value + "'");
                        if (dr.Length > 0)
                        {
                            int index = dtTmp.Rows.IndexOf(dr[0]);
                            dtTmp.Rows.RemoveAt(index);
                        }
                    }
                }
                if (dtTmp.Rows.Count > 0)
                {
                    rptList.DataSource = dtTmp;
                    Session["DT" + ltlempid.Text] = dtTmp;
                    rptList.DataBind();
                }
                else
                {
                    rptList.DataSource = null;
                    Session["DT" + ltlempid.Text] = null;
                    rptList.DataBind();
                    txtcount.Value = "";
                    txtsumwgt.Value = "";
                }
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "sum();", true);
            }
            catch (Exception)
            {

                throw;
            }
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
            Bll_TMD_CAR_NUMBER tmd_car_number = new Bll_TMD_CAR_NUMBER();

            Session["DT" + ltlempid.Text] = null;

            bool result6 = tmd_car_number.Exists(txtcph.Text.Trim());//判断车号禁止发运

            if (result6)
            {
                WebMsg.MessageBox("该车号已经连续3次未接受GPS任务，已被禁止制作发运单");
            }
            else
            {
                if (rptList.Items.Count > 0)
                {
                    bool result = true;//判断当前发运数量已超出可发运量

                    bool result2 = true;//计划发运量是否超出原订单量

                    bool result3 = true;//计划发运量是否超出当日发运总指标

                    bool result4 = true;//钢坯发运

                    bool result5 = true;//是否GPS

                    bool result7 = true;//是包到价，到货地点必须

                    bool sfxc = dropsfxc.SelectedItem.Text == "是" ? true : false;//是否线材销售

                    int row = 0;//行号

                    for (int i = 0; i < rptList.Items.Count; i++)
                    {
                        HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkOrder");//订单ID
                        HtmlInputText txtjhfyl = (HtmlInputText)rptList.Items[i].FindControl("txtjhfyl");//发运数量
                        HtmlInputText txtarea = (HtmlInputText)rptList.Items[i].FindControl("txtarea");//区域
                        HtmlInputHidden hidckid = (HtmlInputHidden)rptList.Items[i].FindControl("hidckid");//仓库主键
                        TextBox txtPack_Code = (TextBox)rptList.Items[i].FindControl("txtPack_Code");//包装要求
                        TextBox txtStd_Code = (TextBox)rptList.Items[i].FindControl("txtStd_Code");//执行标准
                        DropDownList dropzldj = (DropDownList)rptList.Items[i].FindControl("dropzldj");//质量等级
                        Literal ltlmatcode = (Literal)rptList.Items[i].FindControl("ltlmatcode");//物料编码
                        Literal ltlorderwgt = (Literal)rptList.Items[i].FindControl("ltlorderwgt");//订单量
                        Literal ltlcustno = (Literal)rptList.Items[i].FindControl("ltlcustno");//客户编码
                        Literal ltlC_CON_NO = (Literal)rptList.Items[i].FindControl("ltlC_CON_NO");//合同号
                        Literal ltlC_CUST_NAME = (Literal)rptList.Items[i].FindControl("ltlC_CUST_NAME");//客户信息
                        HtmlInputText txtaddr = (HtmlInputText)rptList.Items[i].FindControl("txtaddr");//到货地点费用

                        if (dropsfbdj.SelectedValue == "0")//判定是否包到价
                        {
                            //校验是否GPS
                            if (bllgps.GpsFyd(ltlcustno.Text, dropfyfs.SelectedValue, txtarea.Value, ltlmatcode.Text))
                            {
                                if (string.IsNullOrEmpty(txtgps.Text))
                                {
                                    result5 = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(txtaddr.Value))
                            {
                                result7 = false;
                                break;
                            }
                        }

                        //订单原始量+订单可超出量合计数
                        decimal orderwgt = (Convert.ToDecimal(ltlorderwgt.Text) * Convert.ToDecimal(hidsfwgt.Value ?? "0")) + Convert.ToDecimal(ltlorderwgt.Text);

                        //订单已出库量+订单在途量+在做计划量
                        decimal fysumwgt = tmo_order.GetYLX_YFWGT(chkOrder.Value) + Convert.ToDecimal(txtjhfyl.Value ?? "0");

                        if (sfxc)//钢坯发运
                        {
                            if (!string.IsNullOrEmpty(hidckid.Value))//仓库不能为空
                            {
                                row = i + 1;
                                result4 = false;
                                break;
                            }
                        }

                        //判断当前区域发运量是否超出当日发运总指标
                        if (tmd_dispatch.GetAreaFyZb(txtarea.Value, Convert.ToDecimal(txtjhfyl.Value ?? "0")))
                        {
                            //判断当前计划发运量是否超出原订单量
                            if (fysumwgt > orderwgt)
                            {
                                row = i + 1;
                                result2 = false;
                                break;
                            }
                            else
                            {
                                if (sfxc)//是否线材销售
                                {
                                    string areafalg = ts_dic.GetAreaFlag(txtarea.Value);//获取区域是否按客户发运Y/N
                                    if (areafalg == "N")
                                    {
                                        //判断当前发运数量已超出可发运量
                                        if (!tmo_order.IsFy(Convert.ToDecimal(txtjhfyl.Value ?? "0"), ltlmatcode.Text, txtStd_Code.Text, txtarea.Value, txtPack_Code.Text, dropzldj.SelectedItem.Text))
                                        {
                                            result = false;
                                            break;
                                        }
                                    }
                                    else//按区域客户控制发运
                                    {
                                        //判断当前发运数量已超出可发运量
                                        if (!tmo_order.IsFy(Convert.ToDecimal(txtjhfyl.Value ?? "0"), ltlmatcode.Text, txtStd_Code.Text, txtarea.Value, txtPack_Code.Text, dropzldj.SelectedItem.Text, ltlC_CUST_NAME.Text, ltlC_CON_NO.Text))
                                        {
                                            result = false;
                                            break;
                                        }
                                    }

                                }
                            }
                        }
                        else
                        {
                            row = i + 1;
                            result3 = false;
                            break;
                        }

                    }

                    if (result7)//是包到价，到货地点必须
                    {
                        if (result5)//校验是否GPS
                        {

                            if (result4)//判定是否钢坯发运
                            {
                                if (result3)//计划发运量是否超出当日发运总指标
                                {
                                    if (result2)//计划发运量是否超出原订单量
                                    {
                                        if (sfxc)//是否线材销售
                                        {
                                            if (result)//判断当前发运数量已超出可发运量
                                            {
                                                if (InsertFyd())
                                                {
                                                    WebMsg.MessageBox("保存成功", "fydEdit.aspx?ID=" + txtsendcode.Text);
                                                }
                                            }
                                            else
                                            {
                                                WebMsg.MessageBox("当前发运数量已超出可发运量");
                                            }
                                        }
                                        else
                                        {
                                            if (InsertFyd())
                                            {
                                                WebMsg.MessageBox("保存成功", "fydEdit.aspx?ID=" + txtsendcode.Text);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        decimal pl = Convert.ToDecimal(hidsfwgt.Value) * 100;
                                        WebMsg.MessageBox("当前第" + row + "行,计划发运数量已超出订单数量" + pl + "%");

                                    }
                                }
                                else
                                {
                                    WebMsg.MessageBox("当前第" + row + "行,计划发运数量已超出发运指标,请联系相关负责人进行处理！");
                                }
                            }
                            else
                            {
                                WebMsg.MessageBox("当前第" + row + "行,仓库不能为空！");
                            }
                        }
                        else
                        {
                            WebMsg.MessageBox("GPS号或到站不能为空！");
                        }
                    }
                    else
                    {
                        WebMsg.MessageBox("表体行到货地点不能为空");
                    }
                }
                else
                {
                    WebMsg.MessageBox("请添加发运明细");
                }
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
            List<Mod_TMD_DISPATCHDETAILS> item = new List<Mod_TMD_DISPATCHDETAILS>();//发运明显
            List<Mod_TMC_TRAIN_ITEM> trainList = new List<Mod_TMC_TRAIN_ITEM>();//火运计划申请明显
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
                HtmlInputText txtaddr = (HtmlInputText)rptList.Items[i].FindControl("txtaddr");//到货地点
                HtmlInputText txtprice = (HtmlInputText)rptList.Items[i].FindControl("txtprice");//费用
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
                    modfyditem.C_ORDER_TYPE = modOrder.N_TYPE.ToString();//订单类型 8线材 6钢坯 831废乱材  841焦化产品 851渣
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
                    modfyditem.C_AOG_SITE = txtaddr.Value;//到货地点
                    modfyditem.N_PRICE = Convert.ToDecimal(txtprice.Value == "" ? "0" : txtprice.Value);//到货地点费用
                    item.Add(modfyditem);

                    #region //火运计划明细

                    Mod_TS_CUSTFILE modCustInfo = ts_custfile.GetCustInfo(txtkpdwcode.Text == "" ? modOrder.C_CUST_NO : txtkpdwcode.Text);

                    var modTrainItem = new Mod_TMC_TRAIN_ITEM()
                    {
                        C_EMPNAME = ltlempname.Text,//提报人
                        C_PKID = sendcode,//发运单号
                        C_AREA = modOrder.C_AREA,//区域
                        C_CONNO = modOrder.C_CON_NO,//合同号
                        C_DH_COMPANY = modOrder.C_CUST_NAME,//订货单位
                        C_SH_COMPANY = txtshdw.Text == "" ? modOrder.C_CUST_NAME : txtshdw.Text,//收货单位
                        C_CUSTNO = modCustInfo.C_NO,//客户编码
                        C_CUSTNAME = modCustInfo.C_NAME,//客户名称
                        C_KH_BANK = modCustInfo.C_EXTEND1,//开户行
                        C_TAXNO = modCustInfo.C_TAXPAYERNO,//税号
                        C_ADDRESS = modCustInfo.C_EXTEND3,//地址
                        C_TEL = modCustInfo.C_EXTEND4,//电话
                        C_ACCOUNT = modCustInfo.C_EXTEND2,//账号
                        C_FLAG = "1",
                        C_BILLCODE = modOrder.C_ORDER_NO,//订单号
                        C_SPEC = modOrder.C_SPEC,//规格
                        C_STL_GRD = modOrder.C_STL_GRD,//钢种
                        N_WGT = Convert.ToDecimal(txtjhfyl.Value == "" ? "0" : txtjhfyl.Value),//发运量
                        C_REMARK = txtremark.Value//行备注
                    };
                    trainList.Add(modTrainItem);
                    #endregion
                }
            }
            #endregion

            #region//发运表头
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

            //0001NC10000000003ILQ-火运代垫，0001NC10000000003ILR-汽运代垫，0001NC10000000003ILV-自提运输
            modfyd.N_IS_EXPORT = dropfyfs.SelectedValue == "0001NC10000000003ILQ" ? 1 : Convert.ToDecimal(dropsfbdj.SelectedValue);//是否包到价

            modfyd.C_EXTEND2 = txtxnch.Text == "" ? txtcph.Text : txtxnch.Text;//虚拟车号
            modfyd.C_EXTEND4 = txtcust_tel.Text;//客户姓名/电话
            modfyd.C_EXTEND3 = txtsjtel.Text;//司机姓名/电话

            Mod_TMO_CON modCon = tmo_con.GetModel(ltlcon_no.Text);
            if (modCon != null)
            {
                modfyd.C_BUSINESS_DEPT = modCon.C_DEPTID;//业务部门
                modfyd.C_BUSINESS_ID = modCon.C_EMPLOYEEID;//业务员
            }
            #endregion

            #region //火运计划表头

            string fyfalg = ts_dic.GetDicFlag("ShipVia", dropfyfs.SelectedItem.Text);//获取是否下发审核（泰翔）Y/N

            var modtrain = new Mod_TMC_TRAIN_MAIN()
            {

                C_ID = sendcode,
                C_EMPID = modfyd.C_CREATE_ID,
                C_EMPNAME = modfyd.C_EMP_NAME,
                C_STATION = modfyd.C_ATSTATION,
                C_PLANNO = txtplanno.Text,
                C_LINE = txtline.Text,
                C_REMARK = txtshdw.Text,
                N_TRAIN_NUM = 1,
                C_SHIPVIA = dropfyfs.SelectedItem.Text,
                C_ISCHECK = fyfalg == "N" ? "Y" : "N"//Y通过/N未通过
            };
            #endregion

            if (tmd_dispatch.InsertFYD(modfyd, item))
            {
                txtsendcode.Text = sendcode;
                //汽运代垫自动生成汽运计划/火运计划
                if (dropfyfs.SelectedValue == "0001NC10000000003ILR" || cbx_sftrain.Checked == true)
                {
                    #region //自动生成火运/汽运日计划申请
                    try
                    {
                        tmd_dispatch.AddTrainPlan(modtrain, trainList);
                    }
                    catch (Exception)
                    {
                        return true;
                    }
                    #endregion
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}