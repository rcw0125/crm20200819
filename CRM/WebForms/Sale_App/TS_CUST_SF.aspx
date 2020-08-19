<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TS_CUST_SF.aspx.cs" Inherits="CRM.WebForms.Sale_App.TS_CUST_SF" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>三方客户关系维护</title>
    <uc1:common2 runat="server" ID="common2" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <tr>

                <td style="width: 150px;">
                    <asp:TextBox ID="txt_twocust" placeholder="二级客户编码" runat="server"></asp:TextBox></td>

                <td style="width: 150px;">
                    <asp:TextBox ID="txt_threecust" placeholder="三级客户编码" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btncx" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btncx_Click" />&nbsp;
                    <asp:Button ID="btnsave" runat="server" Text="确认关联" OnClientClick="return checksave();" CssClass="btn btn-info btn-xs" OnClick="btnsave_Click" />&nbsp;
                    <asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-danger btn-xs" OnClientClick="return confirm('确定要删除吗？');" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-hover">
            <thead>
                <tr>
                    <th>序号</th>
                    <th>三级客户</th>
                    <th>二级客户</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="width:100px">
                                <input id="cbxID" style="width: 15px;" class="che1" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' type="checkbox" />
                                <%# Container.ItemIndex+1%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"TWONAME")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"THREENAME")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>

        </table>
        <asp:Literal ID="ltlemp" runat="server"></asp:Literal>
    </form>
</body>
</html>
