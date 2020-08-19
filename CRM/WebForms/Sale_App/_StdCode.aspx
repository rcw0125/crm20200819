<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_StdCode.aspx.cs" Inherits="CRM.WebForms.Sale_App._StdCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>自由项</title>
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Assets/css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="table table-bordered">

                    <tr>
                        <td class="right">钢种</td>
                        <td>
                            <asp:Literal ID="ltlstl_grd" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="right">执行标准</td>
                        <td>
                            <asp:DropDownList ID="dropstd" runat="server" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="dropstd_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="right">自由项1</td>
                        <td>
                            <asp:DropDownList ID="dropzyx1" runat="server" Width="50%">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td class="right">自由项2</td>
                        <td>
                            <asp:DropDownList ID="dropzyx2" runat="server" Width="50%">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    
                   
                    <tr>
                        <td class="right">&nbsp;</td>
                        <td>
                            <input id="btnsave" type="button" value="保存" class="btn btn-primary btn-sm" onclick="SetStdCode();" />
                           
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>

         <input id="hidID" type="hidden" runat="server" />
        <script src="../../Assets/js/jquery-2.0.3.min.js"></script>
        <script type="text/javascript">

            function SetStdCode() {
                var id = $("#hidID").val();
                var std = $("#dropstd").val();
                var zyx1 = $("#dropzyx1").val();
                var zyx2 = $("#dropzyx2").val();
                window.parent.SetStdCode(std, zyx1, zyx2, id);
            }

        </script>
    </form>
</body>
</html>
