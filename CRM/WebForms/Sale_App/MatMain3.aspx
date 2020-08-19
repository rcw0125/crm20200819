<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatMain3.aspx.cs" Inherits="CRM.WebForms.Sale_App.MatMain3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>预测订单钢种</title>
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
                <td style="width:100px">钢种类型</td>
                <td style="width:80px;">
                    <asp:DropDownList ID="dropType" runat="server" Width="100%">
                        <asp:ListItem Value="0">线材</asp:ListItem>
                        <asp:ListItem Value="1">钢坯</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txtmatcode" placeholder="物料编码" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtstlgrd" placeholder="钢种" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tstspec" placeholder="规格" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn btn-primary btn-xs " OnClick="btnSearch_Click" />&nbsp;
                      <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="btn  btn-info btn-xs" OnClick="btnAdd_Click" /></td>
            </tr>
        </table>
        <table class="table table-bordered table-hover table-condensed">
            <thead>
                <tr>
                    <td>选择</td>
                    <td>物料编码</td>
                    <td>物料名称</td>
                    <td>钢种</td>
                    <td>规格</td>
                    <td>自由项1</td>
                    <td>自由项2</td>
                    <td>执行标准</td>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input id="chkMat_Code"  style="width:15px;" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' type="checkbox" /></td>
                            <td>
                                <asp:Literal ID="ltlmatcode" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlmatname" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlstlgrd" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlspec" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC")%>'></asp:Literal></td>
                          
                            <td>
                                <asp:Literal ID="ltlzyx1" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_ZYX1")%>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlzyx2" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_ZYX2")%>'></asp:Literal>
                                <asp:Literal ID="ltlC_IS_BXG" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_IS_BXG")%>'></asp:Literal>
                            </td>
                              <td>
                                <asp:Literal ID="ltlstdcode" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE")%>'></asp:Literal></td>
                            
                      

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>


        </table>
                  </ContentTemplate>
        </asp:UpdatePanel>

        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>
    </form>
</body>
</html>
