<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order_End.aspx.cs" Inherits="CRM.WebForms.Report.Order_End" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>合同终止确认</title>
    <uc1:ReptControl runat="server" ID="ReptControl" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered  table-condensed">
            <tr>
                <td style="width: 120px;">合同号</td>
                <td>
                    <asp:Literal ID="ltlConNO" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>客户编码</td>
                <td>
                    <asp:Literal ID="ltlcustno" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>客户名称</td>
                <td>
                    <asp:Literal ID="ltlcustname" runat="server"></asp:Literal>
                </td>
            </tr>
           
            <tr>
                <td>区域</td>
                <td>
                   <asp:Literal ID="ltlarea" runat="server"></asp:Literal></td>
            </tr>
           
            <tr>
                <td>原因说明</td>
                <td>
                    <asp:TextBox ID="txtremark" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnok" runat="server" Text="确定" CssClass="btn btn-primary btn-xs" OnClick="btnok_Click" />
                    <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
