<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YJ_DAY.aspx.cs" Inherits="CRM.WebForms.Report.YJ_DAY" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>线材预警有效天数配置</title>
    <uc1:ReptControl runat="server" ID="ReptControl" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed table-hover">
            <thead>
                <tr>

                    <th style="width:150px;">项目</th>
                    <th style="width:150px;">预警有效天数</th>
                    <th>操作</th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
                    <ItemTemplate>
                        <tr>
                           
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_STL_TYPE")%>    
                            </td>
                            <td>
                                <input id="txtN_YJ_DAYS" class="numJe" style="width: 100px" type="text" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"N_YJ_DAYS")%>' /></td>
                            <td>
                                <asp:Button ID="btnEdit" runat="server" Text="保存" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' CommandName="edit" CssClass="btn btn-primary btn-xs" /></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
    </form>
</body>
</html>
