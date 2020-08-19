<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Con_CheckList.aspx.cs" Inherits="CRM.Sale_App.Con_CheckList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/jquery-2.0.3.min.js"></script>
    <script src="../Assets/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            fromsize();
        })

        function fromsize() {

            var _w = $("#form1").width();
            var _h = $(window).height();

            $("#_scroll").width(_w - 5);
            $("#_scroll").height(_h - 330);

        }
    </script>
    <title>合同审批</title>
</head>
<body onresize="fromsize();">
    <form id="form1" runat="server">
        <div class="dv_btn" style="margin-top: 5px;">
            <ul>
                <li>
                    <asp:Button ID="btnhref" runat="server" Text="返回" CssClass="btn btn-warning btn-xs" OnClick="btnhref_Click" /></li>
                </ul>
        </div>
        <ul id="myTab" class="nav nav-tabs">
            <li class="active"><a href="#home" data-toggle="tab">合同</a> </li>
            <li><a href="#check" data-toggle="tab">审批</a></li>
        </ul>
        <div class="tab-content">
            <div class="tab-pane fade  in active " id="home">
                <table class="table table-bordered" style="margin-top: 10px;">
                    <tr>

                        <td>合同号 </td>
                        <td>
                            <input id="txtConNO" type="text" class="inputW" runat="server" disabled="disabled" /></td>

                        <td>合同名称</td>
                        <td>
                            <input id="txtConName" runat="server" type="text" class="inputW" disabled="disabled" />
                        </td>
                        <td>合同类型</td>
                        <td>
                            <asp:DropDownList ID="dropConType" runat="server" CssClass="inputW" Enabled="False"></asp:DropDownList></td>
                        <td>客户名称
                        </td>
                        <td>
                            <input id="txtCustName" runat="server" type="text" class="inputW" disabled="disabled" />
                        </td>

                    </tr>

                    <tr>
                        <td>签订日期</td>
                        <td>
                            <input id="txtQianDanDT" type="text" style="width: 140px;" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true })" runat="server" disabled="disabled" /></td>
                        <td>计划生效日期</td>
                        <td>
                            <input id="txtPlanStartDT" type="text" style="width: 140px;" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, maxDate: '#F{$dp.$D(\'txtPlanEndDT\')}' })" runat="server" disabled="disabled" /></td>

                        <td style="color: red">计划失效日期</td>
                        <td>
                            <input id="txtPlanEndDT" type="text" style="width: 140px;" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, minDate: '#F{$dp.$D(\'txtPlanStartDT\')}' })" runat="server" disabled="disabled" /></td>

                        <td style="color: red">系统计划失效日期</td>
                        <td>
                            <input id="txtSysPlanEndDT" type="text" style="width: 140px;" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true })" runat="server" disabled="disabled" />
                        </td>

                    </tr>

                    <tr>
                        <td style="color: red">客户等级</td>
                        <td>
                            <input id="txtCustLEV" runat="server" disabled="disabled" type="text" class="inputW" /></td>
                        <td>发运方式</td>
                        <td>
                            <asp:DropDownList ID="dropFaYun" runat="server" CssClass="inputW" Enabled="False"></asp:DropDownList></td>
                        <td>币种</td>
                        <td>
                            <asp:DropDownList ID="dropBiZhong" runat="server" CssClass="inputW" Enabled="False"></asp:DropDownList>
                        </td>
                        <td style="color: red">业务类型</td>
                        <td>
                            <asp:DropDownList ID="dropYeWuType" runat="server" CssClass="inputW" Enabled="False"></asp:DropDownList></td>
                    </tr>

                    <tr>
                        <td>合同区域</td>
                        <td>
                            <asp:DropDownList ID="dropArea" runat="server" CssClass="inputW" Enabled="False"></asp:DropDownList></td>

                        <td>收货单位</td>
                        <td>
                            <input id="txtShuoHuoCompany" runat="server" type="text" class="inputW" disabled="disabled" /></td>

                        <td>收货地址</td>
                        <td>
                            <input id="txtShuoHuoAddr" runat="server" type="text" class="inputW" disabled="disabled" /></td>
                        <td>开票单位</td>
                        <td>
                            <input id="txtKaiPiaoCompany" runat="server" type="text" class="inputW" disabled="disabled" /></td>


                    </tr>

                    <tr>



                        <td>分类</td>
                        <td>
                            <asp:DropDownList ID="dropClass" runat="server" CssClass="inputW" Enabled="False"></asp:DropDownList></td>
                        <td style="color: red">合同状态</td>
                        <td>
                            <input id="txtState" type="text" class="inputW" disabled="disabled" runat="server" /></td>

                        <td>是否发运</td>

                        <td>&nbsp;<input id="chkIsFaYun" type="checkbox" runat="server" checked="checked" disabled="disabled" /></td>

                        <td style="color: red">&nbsp;</td>
                        <td>&nbsp;</td>

                    </tr>

                    <tr>

                        <td>说明</td>
                        <td colspan="7">
                            <textarea id="txtDESC" runat="server" style="width: 98%; height: 50px;" disabled="disabled"></textarea></td>

                    </tr>





                </table>

                <div style="overflow: auto; margin-top: 10px;" id="_scroll">
                    <table class="table table-bordered table-hover" style="white-space: nowrap;">
                        <thead>
                            <tr>

                                <th>物料编码</th>
                                <th>规格</th>
                                <th>钢种</th>
                                <th>执行标准</th>
                                <th>计量单位</th>
                                <th style="color: red">数量</th>
                                <th>需求日期</th>
                                <th>计划交货日期/系统</th>
                                <th>包装要求</th>
                                <th>产品用途</th>
                                <th style="color: red">无税单价</th>
                                <th>税率</th>
                                <th>含税单价</th>
                                <th>无税金额</th>
                                <th>价税合计</th>
                                <th>税额</th>
                                <th>单品折扣</th>
                                <th>收货单位</th>
                                <th>收货地区</th>
                                <th>收货地址</th>
                                <th>币种</th>
                                <th>折本汇率</th>
                                <th>发货上允差</th>
                                <th>是否发货关闭</th>
                                <th>合同号</th>
                                <th>订单号</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                    <tr>

                                        <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_STD_CODE")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_UNITIS")%></td>
                                        <td style="color: red"><%#DataBinder.Eval (Container.DataItem,"N_WGT")%></td>
                                        <td>
                                            <%#DataBinder.Eval (Container.DataItem,"D_NEED_DT","{0:yyy-MM-dd}")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"D_DELIVERY_DT","{0:yyy-MM-dd}")%>/<%#DataBinder.Eval (Container.DataItem,"D_SYS_DELIVERY_DT","{0:yyy-MM-dd}")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_PACK")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_PRO_USE")%></td>
                                        <td style="color: red"><%#DataBinder.Eval (Container.DataItem,"N_NOTAX_UNITPRICE")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"N_TAX")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"N_INCLUTAX_NETPRICE")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"N_NOMONEY")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"N_PRICETAX_SUM")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"N_AMOUNT_FAX")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"N_ITEM_DIS")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_CGC")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_CGAREA")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_CGADDR")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_CURRENCY_TYPE")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"N_CELING_RATE")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"N_DELIVERY_ALLOWANCE")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"N_IS_DELIVERY_CLOSE")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NO")%></td>
                                        <td>
                                            <asp:Literal ID="ltlOrderNo" Text='<%#DataBinder.Eval (Container.DataItem,"C_NO")%>' runat="server"></asp:Literal></td>

                                    </tr>

                                </ItemTemplate>
                            </asp:Repeater>


                        </tbody>
                        <tfoot>
                            <tr class="info">

                                <td>合计</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Literal ID="ltlWGTSUM" runat="server"></asp:Literal></td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td></td>
                                <td></td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Literal ID="ltlN_NOMONEY" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltlPRICETAX_SUM" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltlN_AMOUNT_FAX" runat="server"></asp:Literal></td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>

                            </tr>

                        </tfoot>

                    </table>
                </div>
            </div>
            <div class="tab-pane fade" id="check">
                <div id="div_check" runat="server"  style="margin-top: 10px;">
                    <table class="table table-bordered">
                        <tr>
                            <td style="text-align: center; width: 100px;">说明</td>
                            <td>
                                <asp:Literal ID="ltlContent" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>

                            <td style="text-align: center">批语</td>
                            <td>
                                <div>
                                    <asp:TextBox ID="txtContent" runat="server" Height="50px" TextMode="MultiLine" Width="99%"></asp:TextBox>
                                </div>
                                <div style="margin-top: 5px;">
                                    <asp:Button ID="btnOk" runat="server" CssClass="btn btn-primary btn-xs" Text="批准" OnClick="btnOk_Click" />&nbsp;&nbsp;
                                    <asp:Button ID="btnNo" runat="server" CssClass="btn btn-primary btn-xs" Text="退回" OnClick="btnNo_Click" /></div>
                            </td>
                        </tr>
                    </table>
                </div>
                <table class="table table-bordered" style="margin-top:10px;">
                    <tbody>
                        <asp:Repeater ID="rptCheckList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 100px; height: 50px; text-align: center; background: #eee; vertical-align: middle">
                                        <%#DataBinder.Eval (Container.DataItem,"c_step_name")%>
                                    </td>
                                    <td>
                                        <%#DataBinder.Eval (Container.DataItem,"c_stepnote")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>


        </div>
        <asp:Literal ID="ltlStepID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlFlowID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlFileID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlTaskID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlUserID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlUserName" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlFlag" runat="server" Visible="false"></asp:Literal>
    </form>
</body>
</html>
