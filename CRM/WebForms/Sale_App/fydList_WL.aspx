<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fydList_WL.aspx.cs" Inherits="CRM.WebForms.Sale_App.fydList_WL" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>发运单-物流</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <uc1:common2 runat="server" ID="common2" />
    <script src="../JsDate.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox ID="txtsendcode" placeholder="发运单号" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtch" placeholder="车牌号/虚拟车号" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtcust" placeholder="客户" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtzdr" placeholder="制单人" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td style="width: 80px">发运方式</td>
                <td>
                    <asp:DropDownList ID="dropfyfs" runat="server" Width="100%"></asp:DropDownList></td>
                <td style="width: 100px">是否线材销售</td>
                <td>
                    <asp:DropDownList ID="dropsfxc" runat="server" Width="50px">
                        <asp:ListItem Value="0001NC10000000007H28">是</asp:ListItem>
                        <asp:ListItem Value="0001NC10000000007H29">否</asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td style="width: 50px;">日期</td>
                <td style="width: 120px;">
                    <input id="txtStart" type="text" style="width: 120px;" readonly="readonly" class="form-control Wdate" runat="server" />
                </td>
                <td style="width: 120px;">
                    <input id="txtEnd" runat="server" type="text" style="width: 120px;" readonly="readonly" class="form-control Wdate" /></td>

                <td style="width: 120px">
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" />
                    &nbsp;
                    <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn  btn-success btn-xs" OnClick="btnExport_Click" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="560" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th data-sortable="true">操作</th>
                    <th data-sortable="true">行号</th>
                    <th data-sortable="true">发运单据号</th>
                    <th data-sortable="true">合同号</th>
                    <th data-sortable="true">发运日期</th>
                    <th data-sortable="true">发运方式</th>
                    <th data-sortable="true">车牌号</th>
                    <th data-sortable="true">虚拟车号</th>
                    <th data-sortable="true">司机姓名/电话</th>
                    <th data-sortable="true">客户姓名/电话</th>
                    <th data-sortable="true">到站</th>
                    <th data-sortable="true">GPS号</th>
                    <th data-sortable="true">客户</th>
                    <th data-sortable="true">最后修改人</th>
                    <th data-sortable="true">最后修改时间</th>
                    <th data-sortable="true">状态</th>
                    <th data-sortable="true">制单日期</th>
                    <th data-sortable="true">制单人</th>
                    <th data-sortable="true">承运商</th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><a href='fydEdit_WL.aspx?ID=<%#DataBinder.Eval (Container.DataItem,"C_ID")%>'>查看</a></td>
                            <td><%# Container.ItemIndex+1%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ID")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"c_con_no")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_DISP_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SHIPVIA")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_LIC_PLA_NO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EXTEND2")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EXTEND3")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EXTEND4")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ATSTATION")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_GPS_NO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ORGO_CUST")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EMP_NAME")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_MOD_DT")%></td>
                            <td><%#GetStatus(DataBinder.Eval (Container.DataItem,"C_STATUS"))%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CREATE_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CREATE_ID")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_COMCAR")%></td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
    </form>
</body>
</html>
