<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrdInfo.aspx.cs" Inherits="CRM.WebForms.Report.GrdInfo" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>监控钢种维护</title>
    <uc1:ReptControl runat="server" ID="ReptControl" />
    <script type="text/javascript">

        function openDialog() {
            var cId = "";
            _iframe('/WebForms/Report/Grd_Add.aspx?' + cId, '400', '400', '监控钢种添加');
            return;
        }
        function refers() {
            close();
            $("#btncx").click();
        }
    </script>
</head>
<body onresize="fromsize();">
    <form id="form1" runat="server">
        <input id="hidempname" type="hidden" runat="server" />
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 150px;">
                    <asp:TextBox ID="txtGrd" placeholder="钢种" runat="server" Width="150px"></asp:TextBox>

                </td>
                <td>
                    <asp:Button ID="btncx" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btncx_Click" />
                    &nbsp;
                   <button id="btnAdd" class="btn btn-primary btn-xs" onclick="openDialog()" type="button">添加</button>
                    &nbsp;
                    <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="btn btn-primary btn-xs" OnClick="btnDel_Click" OnClientClick="confirm('确定要删除吗');" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover text-nowrap" data-toggle="table" data-height="450" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th style="width: 50px;">
                        <input id="cbxAll" type="checkbox" class="qx1" />序号</th>
                    <th data-sortable="true">钢种</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr class="trContent">
                            <td>
                                <input runat="server" class="che1" id="cbxselect" type="checkbox" />
                                <%# this.rptList.Items.Count + 1%> </td>

                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>
                                <asp:Literal ID="lblCID" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' runat="server"></asp:Literal>

                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>

        <script type="text/javascript">
            //全选
            selectAll("input.qx1", "input.che1");
        </script>

    </form>

</body>
</html>
