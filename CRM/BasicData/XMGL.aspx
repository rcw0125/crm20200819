<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMGL.aspx.cs" Inherits="CRM.BasicData.XMGL" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>评分项目管理</title>
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/jquery-2.0.3.min.js"></script>
    <script src="../Assets/js/common.js"></script>
    <script type="text/javascript">
        function check() {
            if ($.trim($("#txtname").val()) == "") {
                alert("请输入项目名称");
                return false;
            }
            return true;

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <tr>
                <td style="width: 50px;" class="right">项目</td>
                <td style="width: 300px;">
                    <asp:TextBox ID="txtname" runat="server" Width="200px"></asp:TextBox>&nbsp;<asp:TextBox ID="txtscroe" placeholder="分数" runat="server" CssClass="numJe" Width="60px"></asp:TextBox></td>
                <td style="width: 100px;">
                    <asp:DropDownList ID="dropclass" runat="server" Width="100%">
                    </asp:DropDownList></td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="添加" CssClass=" btn btn-primary btn-xs" OnClick="Button1_Click" OnClientClick="return check();" /></td>
            </tr>
        </table>
        <table class="table table-bordered table-hover">
            <thead>
                <tr>
                    <th>项目</th>
                    <th>分数</th>
                    <th>分类</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnItemDataBound="rptList_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtname" Text='<%#DataBinder.Eval (Container.DataItem,"C_NAME") %>' Width="95%" runat="server"></asp:TextBox>

                            </td>
                            <td>
                                <asp:TextBox ID="txtscore" Text='<%#DataBinder.Eval (Container.DataItem,"N_SCORE") %>' runat="server" Width="50%" CssClass="numJe"></asp:TextBox>

                            </td>
                            <td>
                                <asp:DropDownList ID="dropclass" runat="server" Width="80%">
                                 
                                </asp:DropDownList>
                                <asp:Literal ID="ltlclass" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"C_FLAG") %>' runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="保存" CommandName="save" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' CssClass="btn btn-default btn-xs" />
                                <asp:Button ID="Button2" runat="server" Text="删除" OnClientClick='return confirm("确定删除吗?")' CommandName="del" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' CssClass="btn btn-default btn-xs" /></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>

        </table>
    </form>
</body>
</html>
