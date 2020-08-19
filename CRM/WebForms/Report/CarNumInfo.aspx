<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarNumInfo.aspx.cs" Inherits="CRM.WebForms.Report.CarNumInfo" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>车牌号维护</title>
    <uc1:ReptControl runat="server" ID="ReptControl" />
    <script type="text/javascript">

        function openDialog() {
            _iframe('/WebForms/Report/CarNum_Add.aspx', '400', '400', '添加车牌号');
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
                    <asp:TextBox ID="txtCar" placeholder="车牌号" runat="server" Width="150px"></asp:TextBox>

                </td>
                <td style="width: 80px;">类别</td>
                <td style="width: 150px;">
                    <asp:DropDownList ID="droptype" runat="server" Width="145">
                        <asp:ListItem>禁止发运</asp:ListItem>
                        <asp:ListItem>邢钢红通</asp:ListItem>
                    </asp:DropDownList>
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
                    <th data-sortable="true">车牌号</th>
                     <th data-sortable="true">类别</th>
                     <th data-sortable="true">操作人</th>
                       <th data-sortable="true">操作时间</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr class="trContent">
                            <td>
                                <input runat="server" class="che1" id="cbxselect" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' />
                                <%# this.rptList.Items.Count + 1%> </td>

                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_NUMBER")%>
                               
                            </td>
                             <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_TYPE")%>
                               </td>
                             <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_EMP_ID")%>
                               
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"D_MOD_DT")%>                              

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
