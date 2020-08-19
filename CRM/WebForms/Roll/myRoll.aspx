<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myRoll.aspx.cs" Inherits="CRM.WebForms.Roll.myRoll" %>

<%@ Register Src="~/WebForms/Roll/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>我的资源申请记录</title>
    <uc1:rollControl runat="server" id="rollControl" />

    <script type="text/javascript">
        $(function () {

            $("#txtStart").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true,
                todayBtn: true
            });
            $("#txtEnd").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true,
                todayBtn: true
            });


        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 60px;">日期</td>
                <td style="width: 110px">
                    <input type="text" class="form-control Wdate" runat="server" id="txtStart" style="width: 100px" /></td>
                <td style="width: 110px">
                    <input type="text" class="form-control Wdate" runat="server" id="txtEnd" style="width: 100px" /></td>
                <td style="width: 60px;">状态</td>
                <td style="width: 100px;">
                    <asp:DropDownList ID="dropStatus" runat="server">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem Value="-1">未提交</asp:ListItem>
                        <asp:ListItem Value="0">待处理</asp:ListItem>
                        <asp:ListItem Value="1">审批中</asp:ListItem>
                        <asp:ListItem Value="2">已完成</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:Button ID="btnCX" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btnCX_Click" />
                    &nbsp;
                    <asp:Button ID="btnSQ" runat="server" Text="资源申请" CssClass="btn btn-primary btn-xs" OnClick="btnSQ_Click" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="500" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th data-sortable="true">序号</th>
                    <th data-sortable="true">标题</th>
                    <th data-sortable="true">申请日期</th>
                    <th data-sortable="true">申请人</th>
                    <th data-sortable="true">状态</th>
                    <th data-sortable="true">备注</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Container.ItemIndex +1 %></td>
                            <td><a href='roll_apply.aspx?ID=<%#DataBinder.Eval(Container.DataItem,"C_ID") %>' style="cursor:pointer"><%#DataBinder.Eval(Container.DataItem,"C_TITLE") %></a> </td>
                            <td><%#DataBinder.Eval(Container.DataItem,"D_MOD") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_EMPNAME") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_STATUS2") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_CONTENT") %></td>
                 
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <asp:Literal ID="ltlempID" runat="server" Visible="false"></asp:Literal>
    </form>
</body>
</html>
