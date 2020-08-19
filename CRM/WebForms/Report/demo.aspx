<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demo.aspx.cs" Inherits="CRM.WebForms.Report.demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="js/jsStye.js"></script>
    <script type="text/javascript">
        function _loading(type) {
          
        zeroModal.loading(type);
        }
        function _close() {
            zeroModal.closeAll();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="等待提示" OnClick="Button1_Click" OnClientClick="_loading(2);" />
            <a href="javascript:_loading(2)">等待框1 (loading)</a>
        </div>
    </form>

</body>
</html>
