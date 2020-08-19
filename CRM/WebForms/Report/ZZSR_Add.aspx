<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZZSR_Add.aspx.cs" Inherits="CRM.WebForms.Report.ZZSR_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>产品添加</title>
    <script src="js/jsStye.js"></script>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-hover table-condensed">
            <tr>
                <td style="width: 100px;">类型</td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server">                        
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>执行标准+钢种</td>
                <td>
                    <input id="txtKey" type="text" style="width: 100%" runat="server" /></td>
            </tr>
            <tr>
                <td>备注</td>
                <td>
                    <textarea id="txtremark" style="width: 100%; height: 50px;" runat="server"></textarea></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSave" CssClass="btn btn-primary btn-xs" runat="server" Text="保存" OnClientClick="return checkinfo();" OnClick="btnSave_Click" />

                </td>
            </tr>
        </table>
        <input id="hid" runat="server" type="hidden" />
    </form>
</body>
</html>
