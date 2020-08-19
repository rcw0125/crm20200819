<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyConsult.aspx.cs" Inherits="CRM.Cust_App.MyConsult" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>技术咨询</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <uc1:common runat="server" ID="common" />
    <script src="../JsDate.js"></script>
    <script type="text/javascript">
       
        function add(id) {

            window.location.href = "MyConsult_Add.aspx?ID=" + id;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">

            <tr>
                <td style="text-align: right">问题</td>
                <td>
                    <asp:DropDownList ID="dropQuest" runat="server" Width="100%"></asp:DropDownList>

                </td>
                <td class="right">状态</td>
                <td>
                    <asp:DropDownList ID="dropState" runat="server" Width="100%">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem Value="0">未处理</asp:ListItem>
                        <asp:ListItem Value="1">已处理</asp:ListItem>
                        <asp:ListItem Value="2">已评分</asp:ListItem>
                        <asp:ListItem Value="3">办结</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="text-align: right">日期</td>
                <td style="width: 125px;">
                    <input id="Start" type="text" style="width: 120px;" runat="server"  readonly="readonly" class="form-control Wdate" />
                </td>
                <td  style="width: 125px;">
                     <input id="End" runat="server" type="text" style="width: 120px;" readonly="readonly" class="form-control Wdate" />
                </td>

                <td>

                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-xs" Text="查询" OnClick="btnSearch_Click" />
                    &nbsp;
                    <input id="btnOpen" type="button" value="咨 询" class="btn btn-primary btn-xs" onclick="add('');" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-hover">
            <thead>
                <tr>
                    <th>产品</th>
                    <th>问题</th>
                    <th>提交日期</th>
                    <th>状态</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound" OnItemCommand="rptList_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_STL_GRD") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"QUEST_NAME") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"D_MOD_DT","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"N_STATE2") %></td>
                            <td>
                                <asp:Literal ID="ltlN_STATE" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"N_STATE") %>' runat="server"></asp:Literal>
                                <a href="MyConsult_View.aspx?ID=<%#DataBinder.Eval(Container.DataItem,"C_ID") %>" class="btn btn-info btn-xs">查看</a>

                                <a class="btn btn-info btn-xs" href="javascript:void(0);" onclick='<%#DataBinder.Eval(Container.DataItem,"C_ID","add(&apos;{0}&apos;)") %>' runat="server" id="btnEdit">修改</a>
                                <asp:Button ID="btnDel" CssClass="btn btn-info btn-xs" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"C_ID") %>' CommandName="del" Text="删除" OnClientClick='return confirm("确定删除吗?")' />
                            </td>
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


        <asp:Literal ID="ltlUserID" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
