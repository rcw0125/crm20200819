<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderView_Cust.aspx.cs" Inherits="CRM.WebForms.Report.OrderView_Cust" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>客户合同履行表</title>
    <uc1:common runat="server" ID="common" />
</head>

<body>
    <form id="form1" runat="server">

        <table class="table table-bordered table-condensed">
            <tr>

                <td>
                    <asp:TextBox ID="txtconno" placeholder="合同号" runat="server" Width="100%"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtyewuyuan" placeholder="业务员" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtstlgrd" placeholder="钢种" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtspec" placeholder="规格" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:DropDownList ID="dropArea" runat="server"></asp:DropDownList>
                </td>

                <td>
                    <asp:DropDownList ID="droptype" runat="server">
                        <asp:ListItem Value="8">线材</asp:ListItem>
                        <asp:ListItem Value="6">钢坯</asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td style="width: 80px;">合同状态</td>
                <td>
                    <asp:DropDownList ID="dropstatus" runat="server">
                        <asp:ListItem Value="2">生效</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 200px;">
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" OnClientClick="_loading(1);" />
                    &nbsp;
                    <asp:Button ID="btnExport" CssClass="btn btn-success btn-xs" runat="server" Text="导出" OnClick="btnExport_Click" />

                </td>
            </tr>
        </table>

        <table class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="450" id="table" style="white-space: nowrap;">
            <thead>
                <tr class="info">
                    <th>合计</th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th>
                        <asp:Literal ID="ltlwgt" runat="server"></asp:Literal></th>
                    <th></th>
                    <th></th>
                    <th>
                        <asp:Literal ID="ltlylxwgt" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltldlxwgt" runat="server"></asp:Literal></th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
                <tr>
                    <th data-sortable="true">合同编码</th>
                    <th data-sortable="true">签订日期</th>
                    <th data-sortable="true">计划终止日期</th>
                    <th data-sortable="true">客户名称</th>
                    <th data-sortable="true">合同状态</th>
                    <th data-sortable="true">物料编码</th>
                    <th data-sortable="true">物料名称</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">数量</th>
                    <th data-sortable="true">含税单价</th>
                    <th data-sortable="true">价税合计</th>
                    <th data-sortable="true">已履行</th>
                    <th data-sortable="true">待履行</th>
                    <th data-sortable="true">排产计划量</th>
                    <th data-sortable="true" class="red">排产跟踪</th>
                    <th data-sortable="true">自由项1</th>
                    <th data-sortable="true">自由项2</th>
                    <th data-sortable="true">包装要求</th>
                    <th data-sortable="true">收货单位</th>
                    <th data-sortable="true">发运方式</th>
                    <th data-sortable="true">业务员</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">

                    <ItemTemplate>
                        <tr>

                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %>
                            </td>

                            <td><%#DataBinder.Eval (Container.DataItem,"D_DT","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_DELIVERY_DT","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_STATUS2") %> </td>

                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %>
                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                            <td>
                                <asp:Literal ID="ltlwgt" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT") %>' runat="server"></asp:Literal></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURTAXPRICE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURSUMMNY") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"YLXWGT") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"DLXWGT") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"XFWGT") %></td>
                            <td> <a style='<%#DataBinder.Eval (Container.DataItem,"XFWGT").ToString()=="0"?"display:none":"display:black" %>' href="javascript:void(0);" onclick="geturl_pc_view('<%#DataBinder.Eval (Container.DataItem,"C_ORDER_NO") %>');">查看</a></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_FREE1") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_FREE2") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_PACK") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_RECEIPTCORPID") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_TRANSMODE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EMPLOYEEID") %></td>
                        </tr>
                    </ItemTemplate>

                </asp:Repeater>
            </tbody>

        </table>

        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlcustname" runat="server" Visible="false">0</asp:Literal>
        <script type="text/javascript">

            $(function () {
                $("#table").resizableColumns();
            });

            function geturl_pc_view(id) {

                var url = 'PC_ORDER_VIEW_Cust.aspx?ID=' + id;
                _iframe(url, '900', '500', '线材订单排产执行情况表');
            }
        </script>

    </form>

</body>
</html>
