<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_ConDoc.aspx.cs" Inherits="CRM.Common._ConDoc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>合同文档</title>
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        function checkfile() {
            if ($.trim($("#file1").val())=="") {
                alert("请选择上传文件");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>

                <td style="width: 250px;">
                    <input class="fileInp" type="file" name="file" runat="server" id="file1" />
                </td>
                <td>
                    <asp:Button ID="Button2" CssClass="btn btn-primary btn-xs" runat="server" Text="上传文档" OnClick="Button2_Click"  OnClientClick="return checkfile();"/></td>
            </tr>
        </table>
        <table class="table table-bordered table-hover table-condensed">
            <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_FILENAME")%></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"D_DT")%></td>
                        <td>
                            <asp:Button ID="btndown" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"C_FILEPATH") %>' CommandName="down" runat="server" Text="文档下载" CssClass="btn btn-info btn-xs" /></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
        <asp:Literal ID="ltlempid" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlpk" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
