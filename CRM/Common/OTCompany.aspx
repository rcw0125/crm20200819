<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OTCompany.aspx.cs" Inherits="CRM.Common.OTCompany" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <title>开票单位</title>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <tr>
                <th>开票单位</th>
                <th>开户银行</th>
                <th>账号</th>
            </tr>
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><a href="#" onclick="SetInfo('<%#DataBinder.Eval (Container.DataItem,"C_ID")%>',' <%#DataBinder.Eval (Container.DataItem,"C_OTCOMPANY")%>');"><%#DataBinder.Eval (Container.DataItem,"C_OTCOMPANY")%></a> </td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_OPENBANK")%></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_ACCOUNTBANK")%></td>

                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
        <script src="../Assets/js/jquery-2.0.3.min.js"></script>
        <script type="text/javascript">
            function SetInfo(id, name) {
                window.opener.SetOT(id, name);
                window.close();
            }
        </script>
    </form>
</body>
</html>
