using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.BLL;
using NF.MODEL;
using NF.Framework;

namespace CRM.WebForms.Report
{
    public partial class PC_ORDER : System.Web.UI.Page
    {
        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_RandomNumber randomnumber = new Bll_RandomNumber();
        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();
        private Bll_TMO_ORDER_PCZB tmo_order_pczb = new Bll_TMO_ORDER_PCZB();
        private Bll_TQB_CHECKSTATE tqb_checkstate = new Bll_TQB_CHECKSTATE();

        private Bll_TQB_PACK tqb_pack = new Bll_TQB_PACK();


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

                    if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                    {
                        GetZb();

                        ltlOrderNo.Text = Request.QueryString["ID"];
                        Mod_TMO_ORDER mod = tmo_order.GetModel(ltlOrderNo.Text);
                        if (mod != null)
                        {

                            ltlConNO.Text = mod.C_CON_NO;
                            ltlMatCode.Text = mod.C_MAT_CODE;
                            ltlMatName.Text = mod.C_MAT_NAME;
                            ltlSpec.Text = mod.C_SPEC;
                            ltlStlGrd.Text = mod.C_STL_GRD;
                            ltlFree1.Text = mod.C_FREE1;
                            ltlFree2.Text = mod.C_FREE2;
                            txtPack.Text = mod.C_PACK;
                            ltlwgt.Text = mod.N_WGT.ToString();

                            #region//获取订单已履行/待履行量
                            decimal dlxwgt = 0;//待履行量
                            DataRow dr = tmo_order.GetOrderExeNum(mod.C_MAT_CODE, mod.C_ORDER_NO, Convert.ToInt32(mod.N_TYPE));
                            if (dr != null)
                            {
                                ltlylxwgt.Text = dr["YLXNUM"].ToString();
                                dlxwgt = Convert.ToDecimal(dr["YLXNUM"].ToString());

                            }
                            ltldlxwgt.Text = Convert.ToString(Convert.ToDecimal(mod.N_WGT) - dlxwgt);

                            #endregion

                            #region//已下发排产

                            string order = "'" + mod.C_ORDER_NO + "'";
                            //if (!string.IsNullOrEmpty(mod.C_ORDER_NO_OLD))
                            //{
                            //    order += ",'" + mod.C_ORDER_NO_OLD + "'";
                            //}

                            ltlplanwgt.Text = tmo_con.GetOrderPCWGT(order);//获取总下发排产量

                            txtneedwgt.Text = Convert.ToString(Convert.ToDecimal(mod.N_WGT) - Convert.ToDecimal(ltlplanwgt.Text));//  ltldlxwgt.Text;

                            if (Convert.ToDecimal(ltlplanwgt.Text) > Convert.ToDecimal(ltlwgt.Text))
                            {
                                btn_add.Enabled = false;
                            }
                            else
                            {
                                btn_add.Enabled = true;
                            }
                            #endregion
                        }
                    }
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }

        private void GetZb()
        {
            int day = Convert.ToInt32((DateTime.Now.Day - 1) / 10);
            switch (day)
            {
                case 0:
                    dropZB.SelectedIndex = 0;
                    break;
                case 1:
                    dropZB.SelectedIndex = 1;
                    break;
                default:
                    dropZB.SelectedIndex = 2;
                    break;
            }
        }

        //合同订单排产
        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {

                decimal sumwgt = Convert.ToDecimal(txtneedwgt.Text) + Convert.ToDecimal(ltlplanwgt.Text);

                //if (sumwgt > Convert.ToDecimal(ltlwgt.Text) || Convert.ToDecimal(txtneedwgt.Text) > Convert.ToDecimal(ltldlxwgt.Text))
                //{
                //    WebMsg.MessageBox("需求排产量已超原合同订单量或已超待履行量");
                //}

                if (sumwgt > Convert.ToDecimal(ltlwgt.Text))
                {
                    WebMsg.MessageBox("需求排产量已超原合同订单量或已超待履行量");
                }
                else
                {

                    List<Mod_TMO_ORDER> orderList = new List<Mod_TMO_ORDER>();
                    List<string[]> list_log = new List<string[]>();

                    decimal wgt = 0;
                    decimal.TryParse(txtneedwgt.Text, out wgt);

                    if (wgt > 0)
                    {
                        if (!string.IsNullOrEmpty(txtPack.Text) && tqb_pack.Exists(txtPack.Text))
                        {
                            #region Insert

                            Mod_TMO_ORDER modOrder = tmo_order.GetModel(ltlOrderNo.Text);


                            //校验是否满足排产指标
                            if (tmo_order_pczb.CheckStl_Grd_ZB(wgt, modOrder.C_AREA, modOrder.C_ORDER_NO, dropZB.SelectedItem.Value))
                            {

                                #region //生产订单号
                                int no = tmo_order.GetOrderPlanNum(modOrder.C_ORDER_NO, modOrder.C_CON_NO);
                                string pc = modOrder.C_ORDER_NO + "/" + no.ToString();

                                if (tmo_order.Exists_OrderPlan(pc, modOrder.C_CON_NO))
                                {
                                    no += 1;
                                    pc = modOrder.C_ORDER_NO + "/" + no.ToString();
                                }
                                #endregion

                                modOrder.C_ORDER_NO = pc;
                                modOrder.N_WGT = wgt;//需求排产量
                                modOrder.N_EXEC_STATUS = -1;//执行状态：提报订单
                                modOrder.C_REMARK4 = txtremark.Text;//特殊信息
                                modOrder.C_PCTBEMP = ltlempname.Text;//提报人
                                modOrder.C_PACK = txtPack.Text;//包装要求

                                orderList.Add(modOrder);

                                string[] arr_log = { "提报订单", "合同履行表页面", GetClientIP(), ltlempid.Text, ltlOrderNo.Text, modOrder.C_ID };
                                list_log.Add(arr_log);
                                if (tmo_con.InsertNeedOrder(orderList))
                                {
                                    //日志
                                    tmo_order.InsertOrderPlanLog(list_log);
                                    Response.Write("<script>alert('提交成功');window.parent.document.getElementById('btncx').click();window.parent.close();</script>");
                                }
                            }
                            else
                            {
                                WebMsg.MessageBox("当前排产量,不符合当月当旬排产指标！");
                            }

                            #endregion
                        }
                        else
                        {
                            WebMsg.MessageBox("包装不能为空或与实际包装不符");
                        }

                    }
                    else
                    {
                        WebMsg.MessageBox("请输入有效需求排产量！");
                    }

                }

            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }

        private string GetClientIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            return result;

        }
    }
}