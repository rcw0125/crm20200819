<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consult_List.aspx.cs" Inherits="CRM.Sale_App.Consult_List" %>

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

                <td>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-xs btn_w60" Text="查询" OnClick="btnSearch_Click" /></td>

            </tr>
        </table>

        <table class="table table-bordered table-hover">
            <thead>
                <tr>

                    <th>产品</th>
                    <th>问题</th>
                    <th>客户</th>
                    <th>提交日期</th>
                    <th>处理部门</th>
                    <th>处理人</th>
                    <th>计划时间</th>
                    <th>完成时间</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td> 
                                <a href='Consult_View.aspx?ID=<%#DataBinder.Eval (Container.DataItem,"C_ID") %>&dept=<%#DataBinder.Eval (Container.DataItem,"c_dept") %>'>
                                <%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></a></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"QUEST_NAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_MOD_DT","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"deptName") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"deptEmp") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"d_plan_dt","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"d_finish_dt","{0:yyy-MM-dd}") %></td>
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
        <asp:Literal ID="ltlDeptID" runat="server" Visible="false"></asp:Literal>
    </form>
</body>
</html>
