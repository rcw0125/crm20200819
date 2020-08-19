<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="custList.aspx.cs" Inherits="CRM.WebForms.Train.custList" %>

<%@ Register Src="~/WebForms/Train/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <uc1:rollControl runat="server" ID="rollControl" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <tr>
                <td>
                    <asp:TextBox ID="txtcustNo" runat="server" placeholder="客户编码" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txtName" runat="server" placeholder="请输入客户全称" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btnok" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btnok_Click" /></td>
            </tr>
        </table>
        <table  class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="300" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th data-sortable="true">客户编码</th>
                    <th data-sortable="true">客户名称</th>
                    <th data-sortable="true">开户行</th>
                    <th data-sortable="true">税号</th>
                    <th data-sortable="true">账号</th>
                    <th data-sortable="true">地址</th>
                    <th data-sortable="true">电话</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>

                        <tr>
                            <td>
                                <a href="#" title="点击插入" onclick="SetInfo('<%#DataBinder.Eval (Container.DataItem,"C_NO")%>','<%#DataBinder.Eval (Container.DataItem,"C_NAME")%>','<%#DataBinder.Eval (Container.DataItem,"C_EXTEND1")%>','<%#DataBinder.Eval (Container.DataItem,"C_TAXPAYERNO")%>','<%#DataBinder.Eval (Container.DataItem,"C_EXTEND2")%>','<%#DataBinder.Eval (Container.DataItem,"C_EXTEND3")%>','<%#DataBinder.Eval (Container.DataItem,"C_EXTEND4")%>');"><%#DataBinder.Eval (Container.DataItem,"C_NAME")%></a>
                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_NAME")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EXTEND1")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_TAXPAYERNO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EXTEND2")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EXTEND3")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EXTEND4")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>

        </table>
        <input id="hidID" type="hidden" runat="server" />
        <script type="text/javascript">

            function SetInfo(custno, custname, kh, tax, zh, addr, tel) {

                var id = $("#hidID").val();
                window.parent.SetCustInfo(custno, custname, kh, tax, zh, addr, tel, id);
            }

        </script>
    </form>
</body>
</html>
