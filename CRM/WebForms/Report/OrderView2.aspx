<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderView2.aspx.cs" Inherits="CRM.WebForms.Report.OrderView2" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>销售合同履行表</title>
    <uc1:ReptControl runat="server" ID="ReptControl" />

</head>

<body>
    <form id="form1" runat="server">

        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox runat="server" placeholder="客户名称" ID="txtcustname" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtconno" placeholder="合同号" runat="server" Width="100%"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtyewuyuan" placeholder="业务员" runat="server" Width="100%"></asp:TextBox></td>
                <td><asp:TextBox ID="txtmatcode" placeholder="物料编码" Width="100%" runat="server"></asp:TextBox></td>
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

                
                <td>
                    <asp:DropDownList ID="dropstatus" runat="server">
                        <asp:ListItem Value="2">生效</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" OnClientClick="_loading(1);" /></td>
                
                <td>
                    <asp:DropDownList ID="dropZB" runat="server">
                        <asp:ListItem Value="0">上旬</asp:ListItem>
                        <asp:ListItem Value="1">中旬</asp:ListItem>
                        <asp:ListItem Value="2">下旬</asp:ListItem>
                    </asp:DropDownList>

                </td>
                <td style="width: 370px;">&nbsp;
                    <asp:Button ID="btnPLPC" runat="server" Text="批量排产" CssClass="btn btn-danger btn-xs" OnClick="btnPLPC_Click" />

                    &nbsp;
                     <input id="btnNeedPC" runat="server" visible="false" type="button" class="btn btn-danger btn-xs" value="下发排产" onclick="geturl_pc();" />
                    &nbsp;
                    <input id="btnKCOrder" runat="server" visible="false" type="button" class="btn btn-danger btn-xs" value="库存订单" onclick="geturl();" />
                    &nbsp;
                     <input id="btnEndCon" runat="server" visible="false" type="button" class="btn btn-danger btn-xs" value="合同终止通知" onclick="geturl_end();" />
                    &nbsp;
                    <asp:Button ID="btnExport" CssClass="btn btn-success btn-xs" runat="server" Text="导出" OnClick="btnExport_Click" />

                </td>
            </tr>
        </table>

        <table class="table table-bordered table-hover table-condensed" data-toggle="table" id="table" style="white-space: nowrap;">
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
                    <th></th>
                    <th></th>
                    <th></th>
                    <th>
                        <asp:Literal ID="ltlwgt" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltlpcwgt" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltlylxwgt" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltldlxwgt" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltlprice" runat="server" Visible="false"></asp:Literal></th>

                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
                <tr>

                    <th data-field="name" data-sortable="true">合同编码</th>
                    <th data-sortable="true">签订日期</th>
                    <th data-sortable="true">计划终止日期</th>
                    <th data-sortable="true">审批类型</th>
                    <th data-sortable="true">部门</th>
                    <th data-sortable="true">客户名称</th>
                    <th data-sortable="true">合同状态</th>
                    <th data-sortable="true" class="red">合同终止通知</th>
                    <th data-sortable="true">物料编码</th>
                    <th data-sortable="true">物料名称</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">数量</th>
                    <th data-sortable="true">已下发排产量</th>
                    <th data-sortable="true">已履行</th>
                    <th data-sortable="true">待履行</th>
                    <th data-sortable="true">含税单价</th>
                    <th data-sortable="true">价税合计</th>

                    <th data-sortable="true">自由项1</th>
                    <th data-sortable="true">自由项2</th>
                    <th data-sortable="true">包装要求</th>
                    <th data-sortable="true">收货单位</th>
                    <th data-sortable="true">发运方式</th>
                    <th data-sortable="true">业务员</th>
                    <th data-sortable="true">审批人</th>
                    <th data-sortable="true">订单号</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">

                    <ItemTemplate>
                        <tr>

                            <td>
                                <input id="cbx_order" runat="server" class="order" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' type="checkbox" />
                                <%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %>
                            </td>

                            <td><%#DataBinder.Eval (Container.DataItem,"D_DT","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_DELIVERY_DT","{0:yyy-MM-dd}") %></td>

                            <td><%#DataBinder.Eval (Container.DataItem,"C_FLOWID") %><%--审批类型--%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_DEPTID") %><%--部门--%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_STATUS2") %>
                                <asp:Literal ID="ltlN_STATUS" Text='<%#DataBinder.Eval (Container.DataItem,"N_STATUS") %>' runat="server" Visible="false"></asp:Literal>
                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"TONGZHI") %></td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %>
                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                            <td>
                                <asp:Literal ID="ltlwgt" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT") %>' runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlpcwgt" Text='<%#DataBinder.Eval (Container.DataItem,"XFWGT") %>' runat="server"></asp:Literal>
                                <a href="javascript:void(0);" onclick="geturl_pc_view('<%#DataBinder.Eval (Container.DataItem,"C_ORDER_NO") %>');"><span class="glyphicon glyphicon-search"></span></a></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"YLXWGT") %></td>
                            <td>
                                <asp:Literal ID="ltldlxwgt" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"DLXWGT") %>'></asp:Literal>
                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURTAXPRICE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURSUMMNY") %></td>

                            <td><%#DataBinder.Eval (Container.DataItem,"C_FREE1") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_FREE2") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_PACK") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_RECEIPTCORPID") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_TRANSMODE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EMPLOYEEID") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_APPROVEID") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ORDER_NO") %></td>
                        </tr>
                    </ItemTemplate>

                </asp:Repeater>
            </tbody>

        </table>

        <div>

            <webdiyer:AspNetPager ID="Pager1" runat="server" CssClass="paginator" CurrentPageButtonClass="paginator"
                CurrentPageButtonPosition="End" CustomInfoHTML="总记录：%RecordCount% &nbsp;页码：%CurrentPageIndex% / %pageCount% &nbsp; 每页：%PageSize%"
                CustomInfoSectionWidth="350px" CustomInfoTextAlign="Center" FirstPageText="首页"
                HorizontalAlign="Right" LastPageText="尾页"
                meta:resourcekey="AspNetPager" NextPageText="下一页"
                NumericButtonCount="5" PagingButtonClass=""
                PrevPageText="前一页" showinputbox="Never" ShowNavigationToolTip="True"
                Width="100%" PageSize="15" CustomInfoClass="paginator" OnPageChanged="Pager1_PageChanged" ShowCustomInfoSection="Right">
                <span style="color: #000000"></span><strong></strong><span style="color: #000000">&nbsp;&lt;
                            &gt;</span>
            </webdiyer:AspNetPager>
        </div>
        <script type="text/javascript">

            $(function () {
                $("#table").resizableColumns();

            });

            function geturl_end() {
                var ID = "";
                $('input[type=checkbox]:checked').each(function () {
                    ID = $.trim($(this).parent().parent().find("input.order").val());
                });
                var url = 'Order_End.aspx?ID=' + ID;
                _iframe(url, '500', '400', '合同终止通知');
            }

            function geturl() {
                var ID = "";
                $('input[type=checkbox]:checked').each(function () {
                    ID = $.trim($(this).parent().parent().find("input.order").val());
                });
                var url = 'KC_ORDER.aspx?ID=' + ID;
                _iframe(url, '500', '400', '库存订单');
            }

            function geturl_pc() {
                var ID = "";
                $('input[type=checkbox]:checked').each(function () {
                    ID = $.trim($(this).parent().parent().find("input.order").val());
                });
                var url = 'PC_ORDER.aspx?ID=' + ID;
                _iframe(url, '500', '450', '下发排产');
            }

            function geturl_pc_view(id) {

                var url = 'PC_ORDER_VIEW.aspx?ID=' + id;
                _iframe(url, '900', '500', '线材订单排产执行情况表');
            }
        </script>

        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlempName" runat="server" Visible="false"></asp:Literal>


    </form>

</body>
</html>
