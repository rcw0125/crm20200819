<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_StrGrd.aspx.cs" Inherits="CRM.Common._StrGrd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>钢种</title>
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 50px;" class="right">钢种</td>
                <td style="width: 150px;">
                    <asp:TextBox ID="txtstlgrd" runat="server"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btnxc" runat="server" Text="查询" CssClass="btn btn-primary  btn-xs" OnClick="btnxc_Click" /></td>
            </tr>
        </table>
        <table class="table table-bordered table-hover">
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href="#" title="点击插入" onclick="SetInfo('<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>');"><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
        <script src="../Assets/js/jquery-2.0.3.min.js"></script>
        <script type="text/javascript">

            function SetInfo(stlgrd) {

                window.parent.SetStlGrd(stlgrd);
            }

        </script>
    </form>
</body>
</html>
