<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebSocketServer.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button Text="刷新" OnClick="Unnamed_Click" runat="server"/>
            <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="false" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:BoundField HeaderText="SESSIONID" DataField="SessionID" ReadOnly="true" />
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <asp:Literal ID="Literal1" runat="server" Text='<%# (Container.DataItemIndex+1) %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="用户" DataField="Account" ReadOnly="true" />
                    <asp:BoundField HeaderText="客户端IP" DataField="Address" ReadOnly="true" />
                    <asp:BoundField HeaderText="连接时间" DataField="ConnectedTimeStr" ReadOnly="true" />
                    <asp:BoundField HeaderText="最后时间" DataField="LastTimeStr" ReadOnly="true" />
                    <asp:CommandField HeaderText="操作" ShowDeleteButton="true"
                        DeleteText="<input type='button' value='下线' onclick=&quot;JavaScript:return confirm('确认强制下线吗？')&quot;>" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
