<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_CustOrder.aspx.cs" Inherits="CRM.WebForms.Cust_App._CustOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>客户历史签单</title>
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Assets/css/common.css" rel="stylesheet" />
    <script src="../../Assets/js/jquery-1.10.2.min.js"></script>
    <script src="../../Assets/js/common.js"></script>
    <script src="../../Assets/js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <tr>
                <td style="width: 80px;" class="right">签单日期：</td>
                <td style="width: 140px;">
                    <input id="txtStart" runat="server" type="text" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, maxDate: '#F{$dp.$D(\'txtEnd\')}' })" style="width: 100%" /></td>
                <td style="width: 140px;">
                    <input id="txtEnd" runat="server" type="text" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, minDate: '#F{$dp.$D(\'txtStart\')}' })" style="width: 100%" /></td>

                <td style="width: 150px;">
                    <asp:TextBox ID="txtConNo" placeholder="合同号" runat="server" Width="100%"></asp:TextBox></td>
                <td style="width: 150px;">
                    <asp:TextBox ID="txtstlgrd" placeholder="钢种" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn btn-primary btn-xs btn_w60" OnClick="btnSearch_Click" />



                </td>

            </tr>
        </table>
        <table class="table table-bordered table-hover">
            <thead>
                <tr>

                    <th>合同号</th>

                    <th>物料编码</th>
                    <th>物料名称</th>
                    <th>钢种</th>
                    <th>规格</th>
                    <th>协议号</th>
                    <th>包装标准</th>
                    <th>税率</th>
                    <th>数量(吨)</th>
                    <th>含税单价</th>

                    <th>价税合计</th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>

                            <td>

                                <a href="#" title="点击插入" onclick="GetOrder('<%#DataBinder.Eval (Container.DataItem,"C_ORDER_NO")%>','<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>','<%#DataBinder.Eval (Container.DataItem,"C_SPEC")%>','<%#DataBinder.Eval (Container.DataItem,"C_PRO_USE")%>');"><%#DataBinder.Eval (Container.DataItem,"C_CON_NO")%></a>

                            </td>

                            <td>

                                <a href="#" title="点击插入" onclick="GetOrder('<%#DataBinder.Eval (Container.DataItem,"C_ORDER_NO")%>','<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>','<%#DataBinder.Eval (Container.DataItem,"C_SPEC")%>','<%#DataBinder.Eval (Container.DataItem,"C_PRO_USE")%>');"><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%></a>

                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%></td>
                            <td>
                                <a href="#" title="点击插入" onclick="GetOrder('<%#DataBinder.Eval (Container.DataItem,"C_ORDER_NO")%>','<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>','<%#DataBinder.Eval (Container.DataItem,"C_SPEC")%>','<%#DataBinder.Eval (Container.DataItem,"C_PRO_USE")%>');"><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></a>
                            </td>
                            <td>

                                <%#DataBinder.Eval (Container.DataItem,"C_SPEC")%></td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_TECH_PROT")%>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_PACK")%></td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"N_TAXRATE")%></td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"N_WGT")%></td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURTAXPRICE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURSUMMNY")%></td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>

        </table>
        <input id="hidflag" runat="server" type="hidden" />
        <asp:Literal ID="ltlcustno" runat="server" Visible="false"></asp:Literal>
        <script src="../Assets/js/jquery-2.0.3.min.js"></script>
        <script type="text/javascript">

            function GetOrder(orderNO, stlGrd, spec, use) {

                var flag = $.trim($("#hidflag").val());
                if (flag == '') {
                    window.parent.SetOrder(orderNO, stlGrd);
                    //window.opener.SetOrder(orderNO, stlGrd);
                    //window.close();
                }
                else {
                    window.parent.SetOrder(stlGrd, spec, use);
                    //window.opener.SetOrder(stlGrd, spec, use);
                    //window.close();
                }
            }

        </script>
    </form>
</body>
</html>
