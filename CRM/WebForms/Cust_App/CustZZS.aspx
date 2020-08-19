<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustZZS.aspx.cs" Inherits="CRM.WebForms.Cust_App.CustZZS" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>客户远程质证书打印</title>
    <uc1:common runat="server" ID="common" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 60px;">
                    <asp:DropDownList ID="droptype" runat="server" Width="100%">
                        <asp:ListItem Value="8">线材</asp:ListItem>
                        <asp:ListItem Value="6">钢坯</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:TextBox ID="txtfyd" runat="server" placeholder="发运单" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtzsh" runat="server" placeholder="证书号" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtcon" runat="server" placeholder="合同号" Width="100%"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtch" runat="server" placeholder="车牌号" Width="100%"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtbatch" runat="server" placeholder="批次" Width="100%"></asp:TextBox>
                </td>

                <td style="width: 100px">出库日期</td>
                <td style="width: 100px;">
                    <input id="txtckkssj" type="text" runat="server" style="cursor: pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td style="width: 100px;">
                    <input id="txtckjssj" type="text" runat="server" style="cursor: pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td>
                    <asp:Button ID="btnxc" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btnxc_Click" />


                </td>

            </tr>
        </table>
        <table class="table table-bordered table-condensed" data-toggle="table" data-height="450" id="table" style="white-space: nowrap;">
            <thead>

                <tr>
                    <th data-sortable="true">操作</th>
                    <th data-sortable="true">证书号</th>
                    <th data-sortable="true">发运单号</th>
                    <th data-sortable="true">车牌号</th>
                    <th data-sortable="true">物料名称</th>
                    <th data-sortable="true">批次号</th>
                    <th data-sortable="true">炉号</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">质量等级</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">重量</th>
                    <th data-sortable="true">件数</th>
                    <th data-sortable="true">发货时间</th>
                    <th data-sortable="true">合同号</th>
                    <th data-sortable="true">客户</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>

                                <%#GetPrint(DataBinder.Eval (Container.DataItem,"C_ZSH"),DataBinder.Eval (Container.DataItem,"C_BATCH_NO"),DataBinder.Eval (Container.DataItem,"C_STD_CODE"),DataBinder.Eval (Container.DataItem,"C_STL_GRD"),DataBinder.Eval (Container.DataItem,"C_FYDH"),DataBinder.Eval (Container.DataItem,"D_QZRQ","{0:yyy-MM-dd}"),DataBinder.Eval (Container.DataItem,"C_ZLDJ"),DataBinder.Eval (Container.DataItem,"C_PDF_PATCH"),DataBinder.Eval (Container.DataItem,"C_STOVE"),DataBinder.Eval (Container.DataItem,"C_BY1")) %>
                                <asp:Button ID="btnPrint" runat="server" Text="打印" CommandName="print" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"C_ZSH") %>' CssClass="btn btn-success btn-xs" Visible='<%#DataBinder.Eval (Container.DataItem,"C_ZSH").ToString()==""?false:true %>' />

                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_ZSH") %>
                            </td>

                            <td>
                                <asp:Literal ID="ltlC_FYDH" Text='<%#DataBinder.Eval (Container.DataItem,"C_FYDH") %>' runat="server"></asp:Literal>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_CH") %>
                            </td>


                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME") %></td>

                            <td>
                                <asp:Literal ID="ltlC_BATCH_NO" Text='<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %>' runat="server"></asp:Literal>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_STOVE") %>
                            </td>

                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>
                            </td>
                            <td>
                                <asp:Literal ID="ltlC_ZLDJ" Text='<%#DataBinder.Eval (Container.DataItem,"C_ZLDJ") %>' runat="server"></asp:Literal>

                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_SPEC") %>
                            </td>
                            <td>

                                <%#DataBinder.Eval (Container.DataItem,"N_JZ") %>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"N_NUM") %>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"D_CKSJ","{0:yyy-MM-dd}") %>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %>
                            </td>



                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
        <asp:Literal ID="ltlemp" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlcustno" runat="server" Visible="false"></asp:Literal>
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
