<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintRecordDel.aspx.cs" Inherits="CRM.WebForms.Report.PrintRecordDel" %>

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
    <script>
        function checkinfo() {
            if ($("#txtremark").val() == "") {
                alert("请填写备注！");
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
         <input id="hid" runat="server" type="hidden" />
         <input id="hidType" runat="server" type="hidden" />
        <table class="table table-bordered table-hover table-condensed">           
            <tr>
                <td>修改原因</td>
                <td>
                    <textarea id="txtremark" style="width: 100%; height: 50px;" runat="server"></textarea></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSave" CssClass="btn btn-primary btn-xs" runat="server" Text="修改" OnClientClick="return checkinfo();" OnClick="btnSave_Click" />

                </td>
            </tr>
        </table>
       
    </form>
</body>
</html>
