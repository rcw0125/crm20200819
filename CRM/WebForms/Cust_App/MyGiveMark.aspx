<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyGiveMark.aspx.cs" Inherits="CRM.WebForms.Cust_App.MyGiveMark" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>我的综合评分</title>
    <uc1:common runat="server" ID="common" />
    <script src="../JsDate.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">

            <tr>

                <td class="right">标题</td>
                <td>
                    <input id="txtTitle" style="width: 100%" type="text" runat="server" /></td>
                <td class="right">日期</td>
                <td style="width: 125px;">
                    <input id="Start" type="text" style="width: 120px;" runat="server" readonly="readonly" class="form-control Wdate" />
                   
                </td>
                <td style="width: 125px;">
                    <input id="End" runat="server" type="text" style="width: 120px;" readonly="readonly" class="form-control Wdate" />
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-xs" Text="查询" OnClick="btnSearch_Click" />
                    &nbsp; <a href="GiveMark.aspx" class="btn btn-primary btn-xs">供应商综合评分</a></td>

            </tr>
        </table>
        <table class="table table-bordered table-hover">
            <thead>
                <tr>
                    <td>标题</td>
                    <td>供应材料</td>
                    <td>提交时间</td>
                    <td>提交人</td>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <a href="GiveMark_View.aspx?ID=<%#DataBinder.Eval(Container.DataItem,"C_ID") %>">
                                    <%#DataBinder.Eval(Container.DataItem,"C_TITLE") %>
                                </a>
                            </td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_STLGRD") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"D_TIME") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_EMPNAME") %></td>
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
        <asp:Literal ID="ltluserID" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
