<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyMoney.aspx.cs" Inherits="CRM.WebForms.Cust_App.MyMoney" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>余额查询</title>
    <uc1:common runat="server" ID="common" />
    <script src="../JsDate.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 80px;">日期</td>
                <td style="width: 125px;">
                    <input id="txtStart" type="text" style="width: 120px;" runat="server" readonly class="form-control Wdate" />
                </td>
                <td style="width: 125px;">
                    <input id="txtEnd" runat="server" type="text" style="width: 120px;" readonly class=" form-control Wdate" /></td>
                <td>
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed">
            <tr>
                <td>账户余额</td>
                <td>日期</td>
                <td>操作</td>
                <td>备注</td>
            </tr>
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Literal ID="ltlMoney" Text='<%#DataBinder.Eval (Container.DataItem,"KHYE")%>' runat="server"></asp:Literal></td>
                        <td><asp:Literal ID="ltlTS" Text='<%#DataBinder.Eval (Container.DataItem,"TS")%>' runat="server"></asp:Literal></td>
                        <td>操作</td>
                        <td>备注</td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
    </form>
</body>
</html>
