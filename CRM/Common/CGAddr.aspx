<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CGAddr.aspx.cs" Inherits="CRM.Common.CGAddr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <title>收货地址</title>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr>

                        <td><a href="#" title="点击插入" onclick="SetInfo('<%#DataBinder.Eval (Container.DataItem,"C_CGAREA")%>');"><%#DataBinder.Eval (Container.DataItem,"C_CGAREA")%></a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>

        <script src="../Assets/js/jquery-2.0.3.min.js"></script>
        <script type="text/javascript">


            function SetInfo(name) {
                window.parent.SetAddr2(name);
                //window.opener.SetAddr2(name);
                //window.close();
            }
        </script>
    </form>
</body>
</html>
