<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Check_Emp.aspx.cs" Inherits="CRM.WebForms.Sale_App.Check_Emp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>审批人</title>
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Assets/css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel panel-default">


            <div class="panel-heading">
                下一处理人列表(<asp:Literal ID="ltlRoleName" runat="server"></asp:Literal>)
            
            </div>
            <table class="table table-bordered">
                <tr>
                    <td style="width: 120px;">
                        <asp:TextBox ID="txtCode" runat="server" placeholder="编号"></asp:TextBox></td>
                    <td style="width: 120px;">
                        <asp:TextBox ID="txtName" runat="server" placeholder="姓名"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="Button1" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btnok_Click" /></td>
                </tr>
            </table>
            <table class="table table-bordered table-hover">
                <thead>
                    <tr>

                        <th>姓名</th>
                        <th>编码</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>

                                <td style="width:200px;"><a href="javascript:void(0);" onclick="GetEmp('<%#DataBinder.Eval (Container.DataItem,"C_NAME")%>','<%#DataBinder.Eval (Container.DataItem,"C_USER_ID")%>');"><%#DataBinder.Eval (Container.DataItem,"C_NAME")%></a></td>

                                <td>
                                    <%#DataBinder.Eval (Container.DataItem,"c_account")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>

            </table>
        </div>
        <asp:Literal ID="ltlStepID" Visible="false" runat="server"></asp:Literal>
        <script src="../../Assets/js/jquery-2.0.3.min.js"></script>
        <script type="text/javascript">
            function GetEmp(userName, userID) {
                window.parent.SetEmp(userName, userID);
            }

        </script>

    </form>
</body>
</html>
