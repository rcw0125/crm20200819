<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarNum_Add.aspx.cs" Inherits="CRM.WebForms.Report.CarNum_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>车牌号添加</title>
    <script src="js/jsStye.js"></script>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
    <script type="text/javascript">
        function checkinfo() {
            if ($("#txtCar").val() == "") {
                alert("不能为空！");
                return;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-hover table-condensed">
         <input id="hid" runat="server" type="hidden" />
            <tr>
                <td>类别</td>
                <td>
                       <asp:DropDownList ID="droptype" runat="server">
                        <asp:ListItem>禁止发运</asp:ListItem>
                        <asp:ListItem>邢钢红通</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
            <tr>
                <td>车牌号</td>
                <td>
                    <input id="txtCar" type="text" style="width: 100%" runat="server" /></td>
            </tr>
            
                <td></td>
                <td>
                    <asp:Button ID="btnSave" CssClass="btn btn-primary btn-xs" runat="server" Text="保存" OnClientClick="return checkinfo();" OnClick="btnSave_Click" />

                </td>
            </tr>
        </table>
        <asp:Literal ID="ltlempID" runat="server" Visible="false"></asp:Literal>
    </form>
</body>
</html>
