<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="CRM.BasicData.Question" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <title>技术问题</title>
</head>
<body>
    <form id="form1" runat="server">
    <table class="table table-bordered">
        <tr>
            <td style="text-align:center; width:80px;">名称</td>
            <td style=" width:150px;">
                <asp:TextBox ID="txtName" runat="server" Width="145px"></asp:TextBox></td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="保 存" CssClass="btn btn-primary btn-xs" OnClick="btnAdd_Click" /><asp:Literal ID="ltlID" Visible="false" runat="server"></asp:Literal></td>
        </tr>
        </table>
        <table class="table table-bordered table-hover">
            <thead>
                <tr>
                   
                    <th>名称</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
                    <ItemTemplate>
                        <tr>
                           
                            <td>
                                <asp:Literal ID="ltlName" Text='<%#DataBinder.Eval (Container.DataItem,"C_NAME") %>' runat="server"></asp:Literal> </td>
                            <td>
                            <asp:Button ID="Button1" runat="server" Text="编辑" CommandName="edit" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' CssClass="btn btn-default btn-xs" /> 
                                 <asp:Button ID="Button2" runat="server" Text="删除" OnClientClick='return confirm("确定删除吗?")' CommandName="del" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' CssClass="btn btn-default btn-xs" />
                                <input id="btnopen" type="button" value="部门设置" class="btn btn-default btn-xs" onclick="openDept('<%#DataBinder.Eval (Container.DataItem,"C_ID") %>');" />
                               
                                
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
        <script src="../Assets/js/jquery-1.10.2.min.js"></script>
        <script src="../Assets/js/common.js"></script>
        <script type="text/javascript">
            function openDept(id) {
                openPage("Question_Dept.aspx?ID=" + id + "", "500", "550");
            }
        </script>
    </form>
</body>
</html>
