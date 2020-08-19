<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="custList.aspx.cs" Inherits="CRM.WebForms.Sale_App.custList" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>收货单位</title>
    <uc1:common2 runat="server" ID="common2" />
</head>
<body>
    <form id="form1" runat="server">
          <table class="table table-bordered">
            <tr>

                <td style="width: 200px;">
                    <asp:TextBox ID="txtName" runat="server" placeholder="请输入公司全称" Width="100%" AutoPostBack="True" OnTextChanged="txtName_TextChanged"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btnok" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btnok_Click" /></td>
            </tr>
        </table>
        <table class="table table-bordered table-hover">
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href="#" title="点击插入" onclick="SetInfo('<%#DataBinder.Eval (Container.DataItem,"C_NC_M_ID")%>','<%#DataBinder.Eval (Container.DataItem,"C_NAME")%>','<%#DataBinder.Eval (Container.DataItem,"C_NO")%>');"><%#DataBinder.Eval (Container.DataItem,"C_NAME")%></a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
         <input id="hidID" type="hidden" runat="server" />
        <script type="text/javascript">

            function SetInfo(id, name, code) {

                var index = $("#hidID").val();
                window.parent.SetSHDW(id, name,index);
            }

        </script>
    </form>
</body>
</html>
