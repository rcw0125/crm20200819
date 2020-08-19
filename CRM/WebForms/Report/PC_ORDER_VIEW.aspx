<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PC_ORDER_VIEW.aspx.cs" Inherits="CRM.WebForms.Report.PC_ORDER_VIEW" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>下发排产明细查询</title>
    <uc1:ReptControl runat="server" ID="ReptControl" />
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript">
        function openWeb(matcode) {
            var url = "order_exe_view.aspx?ID=" + matcode;
            _iframe(url, '600', '400', '计划订单执行情况');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered  table-hover table-condensed" data-height="450" data-toggle="table" style="white-space: nowrap;">
            <thead>

                <tr>

                    <th data-sortable="true">物料编码</th>
                    <th data-sortable="true">物料名称</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">规格</th>

                    <th data-sortable="true">计划需求量</th>
                    <th data-sortable="true">完工量</th>
                    <th data-sortable="true">分配量</th>
                    <th data-sortable="true">计划日期</th>
                    <th data-sortable="true">需求日期</th>
                    <th data-sortable="true">执行状态</th>
                    <th data-sortable="true">自由项1</th>
                    <th data-sortable="true">自由项2</th>
                    <th data-sortable="true">包装</th>
                    <th data-sortable="true">销售区域</th>
                    <th data-sortable="true">客户名称</th>

                    <th data-sortable="true">提报时间</th>
                    <th data-sortable="true">提报人</th>
                    <th data-sortable="true">订单号</th>
                    <th data-sortable="true">合同号</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>

                            <td><%#DataBinder.Eval (Container.DataItem,"物料编码") %><a href="javascript:void(0);" onclick="openWeb('<%#DataBinder.Eval (Container.DataItem,"物料编码") %>');"><span class="glyphicon glyphicon-search"></span></a></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"物料名称") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"型号") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"规格") %></td>

                            <td><%#DataBinder.Eval (Container.DataItem,"计划需求量") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"完工数量") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"分配量") %></td>

                            <td><%#DataBinder.Eval (Container.DataItem,"计划日期","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"需求日期","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"订单状态") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"自由项1") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"自由项2") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"包装要求") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"销售区域") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"客户名称") %></td>

                            <td><%#DataBinder.Eval (Container.DataItem,"D_DT") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_PCTBEMP") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"计划订单号") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
            <tfoot>
                <tr class="info">
                    <td>合计</td>
                    <td></td>
                    <td></td>

                    <td></td>

                    <td>
                        <asp:Literal ID="ltlNEEDWGT" runat="server"></asp:Literal></td>
                    <td>
                        <asp:Literal ID="ltlWGWGT" runat="server"></asp:Literal></td>
                    <td>
                        <asp:Literal ID="ltlHGWGT" runat="server"></asp:Literal></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </tfoot>
        </table>
    </form>
</body>
</html>
