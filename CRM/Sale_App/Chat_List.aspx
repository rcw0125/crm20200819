<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat_List.aspx.cs" Inherits="CRM.Sale_App.Chat_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />

    <title>在线咨询</title>

    <script src="../Assets/js/jquery-2.0.3.min.js"></script>
    <script type="text/javascript">

     
        function sorll() {
            $("#_scroll").scrollTop($("#_scroll")[0].scrollHeight);
        }

        function check() {
            var str = $.trim($("#txtContent").val());
            if (str == '') {
                return false;
            }
            return true;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>


                <table class="table table-bordered" style="width: 800px; margin-left: 150px; margin-top: 20px;">
                    <tr>
                        <td colspan="2" style="background: #f5f5f5">售前售后服务</td>

                    </tr>
                    <tr>
                        <td>
                            <div style="overflow-y: auto; height:450px" id="_scroll">
                                <asp:Literal ID="ltlContent" runat="server"></asp:Literal>
                            </div>
                        </td>
                        <td style="width: 200px;" rowspan="2">
                            <asp:Repeater ID="rptChat" runat="server" OnItemCommand="rptChat_ItemCommand">
                                <ItemTemplate>
                                    <p>
                                        <asp:Button ID="btnchat" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"cust") %>' CssClass=" btn btn-info btn-sm" CommandName="send" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"c_id") %>' />
                                    </p>
                                </ItemTemplate>
                            </asp:Repeater>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>
                                <textarea id="txtContent" runat="server" style="width: 100%; border: solid 1px #cccccc; height: 50px; vertical-align: top; resize: none;"></textarea>
                            </p>
                            <p style="margin-top: 5px;">
                                <asp:Button ID="btnInsert" runat="server" Text="发 送" CssClass="btn btn-primary btn-sm" OnClick="btnInsert_Click" OnClientClick="return check();" />
                            </p>
                        </td>

                    </tr>
                </table>
                <input id="hidUserID" runat="server" type="hidden" />
                <asp:Literal ID="ltlUID" Visible="false" runat="server"></asp:Literal>
                <asp:Timer ID="Timer1" runat="server" Interval="4000" OnTick="Timer1_Tick">
                </asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
