<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="custEdit.aspx.cs" Inherits="CRM.WebForms.Train.custEdit" %>

<%@ Register Src="~/WebForms/Train/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>客户档案</title>
    <uc1:rollControl runat="server" id="rollControl" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td><asp:TextBox ID="txtcustcode" placeholder="客户编码/名称" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btncx"  CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" /></td>

            </tr>
        </table>
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width:100px;">客户编码</td>
                <td><asp:TextBox ID="txtcustno" runat="server" Enabled="False" Width="100%"></asp:TextBox></td>    
            </tr>
            <tr>
                <td>客户名称</td>
                <td><asp:TextBox ID="txtcustname" runat="server" Enabled="False" Width="100%"></asp:TextBox></td>    
            </tr>
             <tr>
                <td>开户行</td>
                <td><asp:TextBox ID="txtkhh" runat="server" Width="100%"></asp:TextBox></td>    
            </tr>
             <tr>
                <td>税号</td>
                <td><asp:TextBox ID="txtsh" runat="server" Width="100%"></asp:TextBox></td>    
            </tr>
             <tr>
                <td>账号</td>
                <td><asp:TextBox ID="txtzh" runat="server" Width="100%"></asp:TextBox></td>    
            </tr>
             <tr>
                <td>地址</td>
                <td><asp:TextBox ID="txtdz" runat="server" Width="100%"></asp:TextBox></td>    
            </tr>
             <tr>
                <td>电话</td>
                <td><asp:TextBox ID="txttel" runat="server" Width="100%"></asp:TextBox></td>    
            </tr>
             <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btSave"  CssClass="btn btn-primary btn-xs" runat="server" Text="保存" OnClick="btSave_Click"  /></td>    
            </tr>
        </table>
    </form>
</body>
</html>
