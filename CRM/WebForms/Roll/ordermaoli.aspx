<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ordermaoli.aspx.cs" Inherits="CRM.WebForms.Roll.ordermaoli" %>

<%@ Register Src="~/WebForms/Roll/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>低毛利订单</title>
    <uc1:rollControl runat="server" ID="rollControl" />

    <script type="text/javascript">
        $(function () {

            $("#txtStart").datetimepicker({
                format: 'yyyy-mm',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true,
                todayBtn: true
            });

            selectAll("input.qx1", "input.che1");
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 100px;">
                    <asp:TextBox runat="server" placeholder="客户名称" ID="txtcust" Width="100"></asp:TextBox></td>
                <td style="width: 100px;">
                    <asp:TextBox runat="server" placeholder="钢种" ID="txtstlgrd" Width="100"></asp:TextBox></td>
                <td style="width: 80px;">销售组织</td>
                <td style="width: 150px;">
                    <asp:DropDownList ID="dropsaleorg" runat="server" Width="100%"></asp:DropDownList></td>
                <td style="width: 110px">计划生效日期</td>
                <td style="width: 110px">
                    <input type="text" class="form-control Wdate" runat="server" id="txtStart" style="width: 100px" /></td>
                <td>
                    <asp:Button ID="btnCX" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btnCX_Click" />
                    &nbsp;
                    <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn  btn-success btn-xs" OnClick="btnExport_Click" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="450" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th data-sortable="true">序号</th>
                    <th data-sortable="true">客户名称</th>
                    <th data-sortable="true">合同号</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">毛利</th>
                    <th data-sortable="true">成本价</th>
                    <th data-sortable="true">单价</th>
                    <th data-sortable="true">订单量</th>
                    <th data-sortable="true">合同签署日期</th>
                    <th data-sortable="true">计划生效日期</th>
                    <th data-sortable="true">销售组织</th>                
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Container.ItemIndex+1 %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUSTNAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CONNO") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STLGRD") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAOLI") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_COSTPRICE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_PRICE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_WGT") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONSING_DT","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONEFFE_DT","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SALEORG") %></td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>

    </form>
</body>
</html>
