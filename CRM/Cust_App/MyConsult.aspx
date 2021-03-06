﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyConsult.aspx.cs" Inherits="CRM.Cust_App.MyConsult" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/My97DatePicker/WdatePicker.js"></script>
    <title>技术咨询</title>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">

            <tr>
                <td style="width: 50px; text-align: center">日期</td>
                <td style="width: 125px; text-align: center">
                    <input id="Start" type="text" style="width: 120px;" runat="server" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, maxDate: '#F{$dp.$D(\'End\')}' })" /></td>
                <td style="width: 125px; text-align: center">
                    <input id="End" runat="server" type="text" style="width: 120px;" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, minDate: '#F{$dp.$D(\'Start\')}' })" /></td>
                <td style="width: 50px; text-align: center">问题</td>
                <td style="width: 150px; text-align: center">
                    <asp:DropDownList ID="dropQuest" runat="server" Width="145px"></asp:DropDownList>
                   
                </td>
                <td style="width: 100px; text-align: center">
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-xs btn_w60" Text="查询" OnClick="btnSearch_Click" /></td>
                <td>
                    <input id="btnOpen" type="button" value="咨 询" class="btn btn-primary btn-xs" onclick="add();" />
                    </td>
            </tr>
        </table>
        <table class="table table-bordered table-hover">
            <thead>
                <tr>
                    <th>产品</th>
                    <th>问题</th>
                    <th>提交日期</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><a href="MyConsult_View.aspx?ID=<%#DataBinder.Eval(Container.DataItem,"C_ID") %>" title="点击查看"> <%#DataBinder.Eval(Container.DataItem,"C_STL_GRD") %></a></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"QUEST_NAME") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"D_MOD_DT") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>

        <div class="div_page">
            <webdiyer:AspNetPager ID="Pager1" runat="server" CssClass="paginator" CurrentPageButtonClass="paginator"
                CurrentPageButtonPosition="End" CustomInfoHTML="总记录：%RecordCount% &nbsp;页码：%CurrentPageIndex% / %pageCount% &nbsp; 每页：%PageSize%"
                CustomInfoSectionWidth="350px" CustomInfoTextAlign="Center" FirstPageText="首页"
                HorizontalAlign="Right" LastPageText="尾页"
                meta:resourcekey="AspNetPager" NextPageText="下一页"
                NumericButtonCount="5" PagingButtonClass=""
                PrevPageText="前一页" showinputbox="Never" ShowNavigationToolTip="True" ShowPageIndexBox="Never"
                Width="100%" PageSize="18" CustomInfoClass="paginator" OnPageChanged="Pager1_PageChanged">
                <span style="color: #000000"></span><strong></strong><span style="color: #000000">&nbsp;&lt;
                            &gt;</span>
            </webdiyer:AspNetPager>

        </div>

        <script src="../Assets/js/jquery-1.10.2.min.js"></script>
        <script src="../Assets/js/common.js"></script>
        <script type="text/javascript">
            function add() {
                openPage("MyConsult_Add.aspx", "700", "420");
            }
        </script>

        <asp:Literal ID="ltlUserID" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
