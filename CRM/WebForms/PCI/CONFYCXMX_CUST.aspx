<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CONFYCXMX_CUST.aspx.cs" Inherits="CRM.WebForms.PCI.CONFYCXMX_CUST" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>客户整批查询</title>
    <uc1:common2 runat="server" ID="common2" />

</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td >
                    <asp:TextBox ID="txtcon" runat="server" placeholder="合同号" Width="100%"></asp:TextBox></td>
                <td >
                    <asp:TextBox ID="txtcust" runat="server" placeholder="客户" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtfyd" runat="server" placeholder="发运单号" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtstlgrd" runat="server"  placeholder="钢种" Width="100%"></asp:TextBox>
                </td>
                 <td>
                    <asp:TextBox ID="txtspec" runat="server"  placeholder="规格" Width="100%"></asp:TextBox>
                </td>
                 <td>
                    <asp:TextBox ID="txtbatch" runat="server"  placeholder="批次" Width="100%"></asp:TextBox>
                </td>
                  <td style="width:100px">
                   <input id="cbx_ck_dt" type="checkbox" runat="server" /> 
                    出库日期</td>
                <td><input id="txtckkssj" type="text" runat="server" style="cursor:pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td><input id="txtckjssj" type="text" runat="server" style="cursor:pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td style="width:120px;">
                    <asp:Button ID="btnxc" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btnxc_Click" />

                    &nbsp;
                    <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn btn-success btn-xs" OnClick="btnExport_Click" />
                </td>

            </tr>
        </table>
        <div style="overflow: auto; width: 100%">
            <table class="table table-bordered table-condensed" style="white-space: nowrap;">
                <thead>
                     <tr class="info">
                        <th>合计</th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th> <asp:Literal ID="ltlsumwgt" runat="server"></asp:Literal></th>
                        <th><asp:Literal ID="ltlsumqua" runat="server"></asp:Literal></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                    </tr>
                    <tr>
                        <th>发运单号</th>
                        <th>车牌号</th>
                        <th>司机姓名</th>
                        <th>司机电话</th>
                        <th>批次号</th>
                        <th>钢种</th>
                        <th>规格</th>
                        <th>重量</th>
                        <th>件数</th>
                        <th>发货时间</th>
                        <th>物料编码</th>
                        <th>物料名称</th>
                        <th>合同号</th>
                        <th>客户</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_FYDH") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_LIC_PLA_NO") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"SJXM") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"SJTEL") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_WGT") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_QUA") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"D_CKSJ","{0:yyy-MM-dd}") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_DESC") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </tbody>
            </table>
        </div>
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

        <asp:Literal ID="ltlempID" Visible="false" runat="server">0</asp:Literal>
    </form>
</body>
</html>
