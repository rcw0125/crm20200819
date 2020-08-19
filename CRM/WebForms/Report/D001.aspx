<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="D001.aspx.cs" Inherits="CRM.WebForms.Report.D001" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>销售出库</title>
    <uc1:ReptControl runat="server" ID="ReptControl" />

</head>
<body>
    <form id="form1" runat="server">


        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox ID="txtfyd" runat="server" placeholder="发运单号" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtch" runat="server" placeholder="车牌号" Width="100%"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtstlgrd" runat="server" placeholder="钢种" Width="100%"></asp:TextBox>
                </td>

                <td>
                    <asp:TextBox ID="txtbatch" runat="server" placeholder="批次/炉号" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtprintemp" runat="server" placeholder="打印人" Width="100%"></asp:TextBox></td>

                <td>
                    <asp:DropDownList ID="dropprint" runat="server">

                        <asp:ListItem Value="0">正常</asp:ListItem>
                        <asp:ListItem Value="2">补打</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 80px">出库日期</td>
                <td style="width: 100px;">
                    <input id="txtckkssj" type="text" runat="server" style="cursor: pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td style="width: 100px;">
                    <input id="txtckjssj" type="text" runat="server" style="cursor: pointer" readonly="readonly" class="form-control Wdate" /></td>

                <td style="width: 320px;">
                    <asp:Button ID="btnxc" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btnxc_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnOut" runat="server" Text="导出" CssClass="btn btn-success btn-xs" OnClick="btnOut_Click" Visible="False" />
                </td>

            </tr>
        </table>
        <table class="table table-bordered table-condensed" data-toggle="table" data-height="450" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th>合计</th>
                    <th>
                        <asp:Literal ID="ltlsumfyd" runat="server"></asp:Literal></th>

                    <th>
                        <asp:Literal ID="ltlsumch" runat="server"></asp:Literal></th>
                    <th></th>
                    <th></th>
                    <th>
                        <asp:Literal ID="ltlsumwgt" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltlsumqua" runat="server"></asp:Literal></th>
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
                    <th>碳钢打印</th>
                    <th data-sortable="true">发运单号</th>
                    <th data-sortable="true">车牌号</th>
                    <th data-sortable="true">批次号</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">重量</th>
                    <th data-sortable="true">件数</th>
                    <th data-sortable="true">炉号</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">质量等级</th>
                    <th data-sortable="true">物料名称</th>
                    <th data-sortable="true">执行标准</th>
                    <th data-sortable="true">发货时间</th>
                    <th data-sortable="true">制单人</th>
                    <th>不锈钢打印</th>

                </tr>
            </thead>
            <tbody>


                <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
                    <ItemTemplate>
                        <tr class='<%#Convert.ToBoolean( Convert.ToInt32(Container.ItemIndex+1)%2)==true?"info":""%>'>
                            <td>
                                <asp:Button ID="btnPrint" runat="server" Text="碳钢打印" CommandName="print" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"C_DISPATCH_ID") %>' CssClass="btn btn-success btn-xs" />

                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_DISPATCH_ID") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_LIC_PLA_NO") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_JZ") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_NUM") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STOVE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ZLDJ") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CKSJ") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_NAME") %></td>
                            <td>
                                <asp:Button ID="btnPrint2" runat="server" Text="不锈钢打印" CommandName="print2" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"C_DISPATCH_ID") %>' CssClass="btn btn-warning btn-xs" /></td>



                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>


        <script type="text/javascript">
            $(function () {
                $("#txtckkssj").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
                $("#txtckjssj").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
            });


        </script>
    </form>
</body>
</html>
