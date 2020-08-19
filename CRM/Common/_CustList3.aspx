<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_CustList3.aspx.cs" Inherits="CRM.Common._CustList3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>预测订单使用</title>
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <tr>

                <td style="width: 200px;">
                    <asp:TextBox ID="txtName" runat="server" placeholder="请输入公司全称" Width="100%" AutoPostBack="True" OnTextChanged="txtName_TextChanged"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btnok" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btnok_Click" /></td>
            </tr>
        </table>
        <table class="table table-bordered table-hover">
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href="#" title="点击插入" onclick="SetInfo('<%#DataBinder.Eval (Container.DataItem,"C_NAME")%>');"><%#DataBinder.Eval (Container.DataItem,"C_NAME")%></a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
      
        <input id="hidID" type="hidden" runat="server" />
        <script src="../../Assets/js/jquery-2.0.3.min.js"></script>
        <script type="text/javascript">

            function SetInfo(name) {
                var id = $("#hidID").val();
                window.parent.SetCustName_bxg(name,id);
            }

        </script>
    </form>
</body>
</html>
