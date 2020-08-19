<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_Sales_Emp1.aspx.cs" Inherits="CRM.Common._Sales_Emp1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>业务员</title>
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <tr>
                <td style="width: 120px;">
                    <asp:TextBox ID="txtCode" runat="server" placeholder="编号"></asp:TextBox></td>
                <td style="width: 120px;">
                    <asp:TextBox ID="txtName" runat="server" placeholder="姓名" AutoPostBack="True" OnTextChanged="txtName_TextChanged"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btnok" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btnok_Click" /></td>
            </tr>
        </table>
        <table class="table table-bordered table-hover">
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><a href="#" onclick="GetEmp('<%#DataBinder.Eval (Container.DataItem,"C_NAME")%>','<%#DataBinder.Eval (Container.DataItem,"c_id")%>');"><%#DataBinder.Eval (Container.DataItem,"C_NAME")%></a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <script src="../Assets/js/jquery-1.10.2.min.js"></script>
        <script type="text/javascript">
            function GetEmp(userName, saleEmpID) {
                window.parent.SetEmp(userName, saleEmpID); 
            }

        </script>
    </form>
</body>
</html>
