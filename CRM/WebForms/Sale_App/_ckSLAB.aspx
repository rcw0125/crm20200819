<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_ckSLAB.aspx.cs" Inherits="CRM.WebForms.Sale_App._ckSLAB" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>钢坯仓库</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <uc1:common2 runat="server" ID="common2" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td>仓库类型</td>
                <td>
                    <asp:DropDownList ID="droptype" runat="server">
                        <asp:ListItem Value="1">钢坯</asp:ListItem>
                        <asp:ListItem Value="0">线材</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 100px">编码/名称</td>
                <td>
                    <asp:TextBox ID="txtcode" runat="server" placeholder="仓库编码" Width="120" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btn_cx" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btn_cx_Click" />&nbsp;&nbsp; <input id="btnqx" type="button" value="清空发运单仓库"  onclick="SetInfo('','');" class="btn btn-primary btn-xs" /></td>
                    
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover">
            <tr>
                <td>仓库编码</td>
                <td>仓库名称</td>
            </tr>
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr title="点击选中" onclick="SetInfo('<%#DataBinder.Eval (Container.DataItem,"C_ID")%>','<%#DataBinder.Eval (Container.DataItem,"CKCODE")%>');">
                        <td>
                            <%#DataBinder.Eval (Container.DataItem,"CKCODE")%>
                        </td>
                        <td><%#DataBinder.Eval (Container.DataItem,"CKNAME")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
        <input id="hidID" type="hidden" runat="server" />
        <input id="hidfyID" type="hidden" runat="server" />
        <script src="../Assets/js/jquery-2.0.3.min.js"></script>
        <script type="text/javascript">

            function SetInfo(id, name) {
                var index = $("#hidID").val();
                window.parent.SetCK(id, name, index);
            }
        </script>
    </form>
</body>
</html>
