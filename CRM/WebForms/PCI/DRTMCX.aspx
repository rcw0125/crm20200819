<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DRTMCX.aspx.cs" Inherits="CRM.WebForms.PCI.DRTMCX" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>条码接口查询</title>
    <uc1:common runat="server" ID="common" />
</head>
<body onresize="fromsize();">
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 180px;">
                    <asp:TextBox ID="txtFYDH" placeholder="发运单号" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 180px;">
                    <asp:TextBox ID="txtGZ" placeholder="钢种" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 180px;">
                    <asp:TextBox ID="txtGG" placeholder="规格" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClientClick="_loading(1)" OnClick="btncx_Click" />
                </td>
            </tr>
        </table>
        <div style="overflow: auto; width: 100%; height: 600px" id="flow1">
            <table id="table1" class="table table-bordered table-hover table-condensed" style="white-space: nowrap;">
                <thead>
                    <tr>
                        <th>发运单号</th>
                        <th>车牌号</th>
                        <th>备注</th>
                        <th>钢种</th>
                        <th>规格</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lblBatchNo" runat="server" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"fydh") %>' CommandName="xc"><%#DataBinder.Eval (Container.DataItem,"fydh") %></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Literal ID="lblcph" Text='<%#DataBinder.Eval (Container.DataItem,"cph") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblBZ" Text='<%#DataBinder.Eval (Container.DataItem,"beizhu") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblGZ" Text='<%#DataBinder.Eval (Container.DataItem,"ph") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblGG" Text='<%#DataBinder.Eval (Container.DataItem,"gg") %>' runat="server"></asp:Literal>
                                </td>

                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
