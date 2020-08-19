<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consult_List.aspx.cs" Inherits="CRM.Sale_App.Consult_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>技术咨询</title>
    <uc1:common2 runat="server" ID="common2" />
    <script src="../JsDate.js"></script>

</head>

<body>
    <form id="form1" runat="server">

        <table class="table table-bordered">

            <tr>
                <td class="right" style="width:80px;">问题类型</td>
                <td><asp:DropDownList ID="dropQuest" runat="server" Width="100%"></asp:DropDownList></td>
                 <td class="right" style="width:80px;">状态</td>
                <td>
                    <asp:DropDownList ID="dropState" runat="server" Width="100%">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem Value="0">未处理</asp:ListItem>
                        <asp:ListItem Value="1">已处理</asp:ListItem>
                        <asp:ListItem Value="2">已评分</asp:ListItem>
                        <asp:ListItem Value="3">办结</asp:ListItem>
                    </asp:DropDownList></td>
                <td class="right" style="width:80px;">日期</td>
                <td style="width:125px;">
                    <input id="Start" type="text" style="width: 120px;" runat="server" class="form-control Wdate" readonly="readonly"/>
                   
                </td>
                <td style="width:125px;"><input id="End" runat="server" type="text" style="width: 120px;" class="form-control Wdate" readonly="readonly" /></td>
                
                <td>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-xs" Text="查询" OnClick="btnSearch_Click" /></td>

            </tr>
        </table>

        <table class="table table-bordered table-hover">
            <thead>
                <tr>

                    <th>产品</th>
                    <th>问题</th>
                    <th>客户</th>
                    <th>部门</th>
                    <th>提交人</th>
                    <th>提交日期</th>
                    <th>服务专员</th>
                    <th>完成时间</th>
                     <th>状态</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td> 
                                <a href='Consult_View.aspx?ID=<%#DataBinder.Eval (Container.DataItem,"C_ID") %>'>
                                <%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></a></td>

                            <td><%#DataBinder.Eval (Container.DataItem,"QUEST_NAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_DEPT") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EMP_NAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_MOD_DT","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EMP") %></td>                        
                            <td><%#DataBinder.Eval (Container.DataItem,"d_finish_dt","{0:yyy-MM-dd}") %></td>
                             <td><%#DataBinder.Eval(Container.DataItem,"N_STATE2") %></td>
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
    </form>
</body>
</html>
