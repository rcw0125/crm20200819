<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Con_OrderList.aspx.cs" Inherits="CRM.Sale_App.Con_OrderList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/My97DatePicker/WdatePicker.js"></script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dv_search">
            <ul>
                <li>
                    <button type="button" class="btn btn-primary btn-xs" onclick="edit();">订单维护</button></li>
                <li>
                    <button type="button" class="btn btn-primary btn-xs" onclick="add();">增加订单</button></li>
            </ul>
        </div>


        <table class="table table-bordered table-hover" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th>序号</th>
                    <th>物料编码</th>
                    <th style="color: red">维护等级</th>
                    <th>规格</th>
                    <th>钢种</th>
                    <th>执行标准</th>
                    <th>计量单位</th>
                    <th style="color: red">数量</th>
                    <th style="color: red">需求日期</th>
                    <th>计划交货日期/系统</th>
                    <th>包装要求</th>
                    <th>产品用途</th>
                    <th style="color: red">无税单价</th>
                    <th>税率</th>
                    <th>含税单价</th>
                    <th>无税金额</th>
                    <th>价税合计</th>
                    <th>税额</th>
                    <th style="color: red">执行状态</th>
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
                            <td>
                                <input id="radIndex" class="rad" type="radio" value='<%#DataBinder.Eval (Container.DataItem,"C_NO")%>' onclick="geturl('<%#DataBinder.Eval (Container.DataItem,"C_NO")%>','<%#DataBinder.Eval (Container.DataItem,"N_TYPE")%>');" name="0"/></td>

                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%></td>
                            <td style="color: red">
                                <%#DataBinder.Eval (Container.DataItem,"C_LEV")%>
                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STD_CODE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_UNITIS")%></td>
                            <td style="color: red">
                                <%#DataBinder.Eval (Container.DataItem,"N_WGT")%>
                            </td>
                            <td style="color: red">
                                <%#DataBinder.Eval (Container.DataItem,"D_NEED_DT","{0:yyy-MM-dd}")%>
                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_DELIVERY_DT","{0:yyy-MM-dd}")%>/<%#DataBinder.Eval (Container.DataItem,"D_SYS_DELIVERY_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_PACK")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_PRO_USE")%></td>
                            <td style="color: red"><%#DataBinder.Eval (Container.DataItem,"N_NOTAX_UNITPRICE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_TAX")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_INCLUTAX_NETPRICE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_NOMONEY")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_PRICETAX_SUM")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_AMOUNT_FAX")%></td>
                            <td><%#getExecStatus(DataBinder.Eval (Container.DataItem,"C_NO").ToString())%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_ITEM_DIS")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CGC")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CGAREA")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CGADDR")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CURRENCY_TYPE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_CELING_RATE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_DELIVERY_ALLOWANCE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_IS_DELIVERY_CLOSE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_NO")%></td>

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
                    <td>&nbsp;</td>

                </tr>

            </tfoot>

        </table>
        <input id="hidconNo" runat="server" type="hidden" />
        <asp:Literal ID="ltlConN0" runat="server" Visible="false"></asp:Literal>
        <script src="../Assets/js/jquery-2.0.3.min.js"></script>
        <script src="../Assets/js/common.js"></script>
        <script type="text/javascript">
            function geturl(order, type) {
                if (type == '8') {
                    window.parent.document.getElementById('iframe2').contentWindow.location.href = "_Roll_Product.aspx?orderNo=" + order;
                }
                else {
                    window.parent.document.getElementById('iframe2').contentWindow.location.href = "_Slab_Product.aspx?orderNo=" + order;
                }

            }

            function edit() {
                var test = $("input[class='rad']:checked");
                var orderNo = test.parent().parent().children("td").get(28).innerHTML;
                 alert(orderNo);
                var url = "Con_OrderAdd.aspx?edit=" + orderNo;
              
                openPage(url, "500", "550");
            }

            function add() {
                var conNo = $("#hidconNo").val();
                var url = "Con_OrderAdd.aspx?add=" + conNo;
                openPage(url, "500", "550");
            }
        </script>
    </form>
</body>
</html>
