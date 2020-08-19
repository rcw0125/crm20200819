<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="D002.aspx.cs" Inherits="CRM.WebForms.Report.D002" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>销售出库管理</title>
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

                        <asp:ListItem Value="0">未打印</asp:ListItem>
                        <asp:ListItem Value="1">已打印</asp:ListItem>
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
                    &nbsp;
                    &nbsp;
                    <asp:Button ID="btnOut" runat="server" Text="导出" CssClass="btn btn-success btn-xs" OnClick="btnOut_Click" />
                </td>

            </tr>
            <tr>
                <td>补打/初始化说明</td>
                <td colspan="9">
                    <asp:TextBox ID="txtremark" placeholder="只能输入20个字符" runat="server" TextMode="MultiLine" Width="95%" MaxLength="100"></asp:TextBox>
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
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
                <tr>
                    <th data-sortable="true">操作</th>
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
                    <th data-sortable="true">打印次数</th>
                    <th data-sortable="true">最后打印人</th>
                    <th data-sortable="true">最后打印时间</th>
                    <th data-sortable="true">最后操作人</th>
                    <th data-sortable="true">最后操作时间</th>
                    <th data-sortable="true">说明</th>
                </tr>
            </thead>
            <tbody>


                <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
                    <ItemTemplate>
                        <tr class='<%#Convert.ToBoolean( Convert.ToInt32(Container.ItemIndex+1)%2)==true?"info":""%>'>
                            <td>
                                <asp:Button ID="btnPrint" runat="server" Text="补打设置" CommandName="print" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"C_DISPATCH_ID") %>' CssClass="btn btn-success btn-xs" />
                                &nbsp;
                                 <asp:Button ID="btnPrint2" runat="server" Text="初始化设置" CommandName="print2" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"C_DISPATCH_ID") %>' CssClass="btn btn-success btn-xs" />
                            </td>
                            <td><a href="http://192.168.2.96:8080/WebReport/ReportServer?reportlet=<%#DataBinder.Eval (Container.DataItem,"C_PRINTTYPE").ToString()=="1"?"ZZS_FYMX.cpt":"ZZS_BXGFYMX.cpt" %>&fyd=<%#DataBinder.Eval (Container.DataItem,"C_DISPATCH_ID") %>" target="_blank" title="预览"><%#DataBinder.Eval (Container.DataItem,"C_DISPATCH_ID") %></a> </td>
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
                            <td><%#DataBinder.Eval (Container.DataItem,"N_PRINT_NUM") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_PRINTEMP") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_PRINTTIME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_PDEMP") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_PDTIME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_REMARK") %></td>
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
