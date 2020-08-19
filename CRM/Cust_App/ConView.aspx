<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConView.aspx.cs" Inherits="CRM.Cust_App.ConView" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Assets/js/jquery-1.10.2.min.js"></script>
    <script src="../Assets/js/bootstrap.min.js"></script>

    <title>新增合同</title>
</head>
<body>
    <form runat="server">
        <div class="dv_btn">
            <ul>
                <li>
                    <button type="button" class="btn btn-warning btn-xs" onclick='window.location.href="MyCon.aspx"'>返回</button></li>
            </ul>
        </div>

        <table class="table table-bordered">

            <tr>
                <td>货币类型</td>
                <td>
                    <asp:DropDownList ID="dropCurrType" runat="server" Width="100px" Enabled="False"></asp:DropDownList>

                </td>

                <td>签署日期</td>
                <td>
                    <input id="txtDate" runat="server" type="text" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true })" disabled="disabled" /></td>
                <td>计划有效日期</td>
                <td>
                    <input id="txtStart" runat="server" type="text" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, maxDate: '#F{$dp.$D(\'txtEnd\')}' })" disabled="disabled" visible="True" />
                </td>
                <td>计划失效日期</td>
                <td>
                    <input id="txtEnd" runat="server" type="text" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, minDate: '#F{$dp.$D(\'txtStart\')}' })" disabled="disabled" visible="True" />
                </td>
            </tr>
            <tr>
                <td>合同类型</td>
                <td>
                    <asp:DropDownList ID="dropConType" runat="server" Width="100px" Enabled="False"></asp:DropDownList>

                </td>
                <td>合同号</td>
                <td>
                    <asp:TextBox ID="txtConNO" runat="server" Enabled="False"></asp:TextBox></td>
                <td>合同名称</td>
                <td>
                    <asp:TextBox ID="txtConName" runat="server" Enabled="False"></asp:TextBox></td>
                <td>客户名称</td>
                <td>
                    <asp:TextBox ID="txtCustName" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td>发运方式</td>
                <td>
                    <asp:DropDownList ID="dropShipVia" runat="server" Width="100px" Enabled="False"></asp:DropDownList>

                </td>
                <td>合同区域</td>
                <td>
                    <asp:DropDownList ID="dropConArea" runat="server" Width="100px" Enabled="False"></asp:DropDownList>

                </td>
                <td>合同状态</td>
                <td>
                    <asp:TextBox ID="txtState" runat="server" Enabled="False"></asp:TextBox>
                    <input id="hidState" runat="server" type="hidden" />
                </td>
                <td>合计数量</td>
                <td>&nbsp;
                    <asp:Label ID="lblSum" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>订单号</th>
                            <th>物料编码</th>
                            <th>物料名称</th>
                            <th>规格</th>
                            <th>钢种</th>
                            <th>协议号</th>
                            <th>包装要求</th>
                            <th>产品用途</th>
                            <th>计量单位</th>
                            <th>计划交货日期</th>
                            <th>数量</th>
                            <th>收货单位</th>
                            <th>开票单位</th>
                            <th>订单状态</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td  title="<%#DataBinder.Eval (Container.DataItem,"C_NO") %>">
                      <%#NF.Framework.StringFormat.SubString(DataBinder.Eval (Container.DataItem,"C_NO").ToString (),10) %>
                    </td>

                    <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"C_TECH_PROT") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"C_PACK") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"C_PRO_USE") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"C_UNITIS") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"D_DELIVERY_DT","{0:yyy-MM-dd}") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"N_WGT") %></td>
                    <td title="<%#DataBinder.Eval (Container.DataItem,"C_CGC") %>"><%#NF.Framework.StringFormat.SubString(DataBinder.Eval (Container.DataItem,"C_CGC").ToString(),10) %></td>
                    <td title="<%#DataBinder.Eval (Container.DataItem,"C_OTC") %>"><%#NF.Framework.StringFormat.SubString(DataBinder.Eval (Container.DataItem,"C_OTC").ToString (),10) %></td>
                    <td><%# GetOrderState(DataBinder.Eval (Container.DataItem,"N_STATUS")) %></td>

                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
               </table>
            </FooterTemplate>

        </asp:Repeater>

        <script>
            $(function () { $("[data-toggle='tooltip']").tooltip(); });
        </script>
    </form>
</body>
</html>
