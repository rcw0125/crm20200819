<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XCKCX.aspx.cs" Inherits="CRM.WebForms.PCI.XCKCX" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>线材仓库</title>
    <uc1:common runat="server" ID="common" />
    <script>
        $(function () {
            var _h = document.documentElement.clientHeight || document.body.clientHeight;
            $("#flow1").height(_h * 0.8);
            $("#txtBegTime").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true,
                todayBtn: true
            });
            $("#txtEndTime").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true,
                todayBtn: true
            });
        })

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox runat="server" placeholder="仓库编码" ID="txtckcode" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="区域编码" ID="txtqy" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="库位编码" ID="txtkwcode" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="钢种" ID="txtstlgrd" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="标准" ID="txtbz" Width="100%"></asp:TextBox></td>

                <td>是否待判</td>
                <td>
                    <asp:DropDownList ID="ddlsfdp" runat="server">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem Value="0">已判</asp:ListItem>
                        <asp:ListItem Value="1">待判</asp:ListItem>
                    </asp:DropDownList></td>
                <td>质量等级</td>
                <td>
                    <asp:DropDownList ID="ddlzldj" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox runat="server" placeholder="规格" ID="txtGG" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="批次号" ID="txtbatchno" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="单卷号" ID="txtbarcode" Width="100%"></asp:TextBox></td>
                <td>生产日期</td>
                <td>
                    <asp:TextBox runat="server" class="form-control Wdate " ID="txtBegTime" Style="height: 100%;"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" class="form-control Wdate " ID="txtEndTime" Style="height: 100%;"></asp:TextBox>
                </td>
                <td>库存状态</td>
                <td>
                    <asp:DropDownList ID="ddlkczt" runat="server">
                        <asp:ListItem Value="E">在库</asp:ListItem>
                        <asp:ListItem Value="M">转库</asp:ListItem>
                        <asp:ListItem Value="S">已销售</asp:ListItem>
                        <asp:ListItem Value="QC">其他出库</asp:ListItem>
                        <asp:ListItem Value="QE">其他入库</asp:ListItem>
                        <asp:ListItem Value="QS">其他销售</asp:ListItem>
                        <asp:ListItem>全部</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:Button CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btn_xc_Click" OnClientClick="_loading(1);" Style="height: 27px" />
                    <asp:Button CssClass="btn btn-primary btn-xs" runat="server" Text="导出" OnClick="btnExport_Click" Style="height: 27px" /></td>
            </tr>
        </table>
        <div style="overflow: auto; width: 100%;" id="flow1">
            <table class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="550"  style="white-space: nowrap;">
                <thead> 
                    <tr class="info">
                        <th>合计:</th>
                        <th>卷数
                                        <asp:Literal ID="rptSL" runat="server"></asp:Literal>
                        </th>
                        <th>重量
                                        <asp:Literal ID="rptZL" runat="server"></asp:Literal></th>
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
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                    </tr>
                    <tr>
                        <th>
                            <input id="cbxAll" type="checkbox" class="qx1" />全选</th>
                        <th data-sortable="true">仓库</th>
                        <th data-sortable="true">区域</th>
                        <th data-sortable="true">库位</th>
                        <th data-sortable="true">批次号</th>
                        <th data-sortable="true">单卷号</th>
                        <th data-sortable="true">钩号</th>
                        <th data-sortable="true">钢种</th>
                        <th data-sortable="true">执行标准</th>
                        <th data-sortable="true">规格</th>
                        <th data-sortable="true">物料名称</th>
                        <th data-sortable="true">物料编码</th>
                        <th data-sortable="true">质量等级</th>
                        <th data-sortable="true">自由项1</th>
                        <th data-sortable="true">自由项2</th>
                        <th data-sortable="true">包装要求</th>
                        <th data-sortable="true">库存状态</th>
                        <th data-sortable="true">销售区域</th>
                        <th data-sortable="true">生产日期</th>
                        <th data-sortable="true">卷重</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <input id="cbxselect" runat="server" class="che1" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' type="checkbox" /></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_AREA_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_LOC_CODE") %></td>
                                <td>
                                    <asp:Literal ID="ltlbatch" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %>'></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="Literal1" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_BARCODE") %>'></asp:Literal></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_TICK_NO") %></td>

                                <td>
                                    <asp:Literal ID="ltlstlgrd" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>' runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="Literal2" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %>' runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltlspec" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC") %>' runat="server"></asp:Literal></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_DESC") %></td>
                                <td>
                                    <asp:Literal ID="ltlmatcode" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %>' runat="server"></asp:Literal></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_ZYX1") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_ZYX2") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_BZYQ") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_MOVE_TYPE") %></td>
                                <td>
                                    <asp:Literal ID="ltlsalearea" Text='<%#DataBinder.Eval (Container.DataItem,"C_SALE_AREA") %>' runat="server"></asp:Literal></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"D_PRODUCE_DATE","{0:yyy-MM-dd}") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_WGT") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <asp:Literal ID="ltlempid" runat="server"></asp:Literal>
        <asp:Literal ID="ltlempname" runat="server"></asp:Literal>
        <div class="div_page">

            <webdiyer:AspNetPager ID="Pager1" runat="server" CssClass="paginator" CurrentPageButtonClass="paginator"
                CurrentPageButtonPosition="End" CustomInfoHTML="总记录：%RecordCount% &nbsp;页码：%CurrentPageIndex% / %pageCount% &nbsp; 每页：%PageSize%"
                CustomInfoSectionWidth="350px" CustomInfoTextAlign="Center" FirstPageText="首页"
                HorizontalAlign="Right" LastPageText="尾页"
                meta:resourcekey="AspNetPager" NextPageText="下一页"
                NumericButtonCount="5" PagingButtonClass=""
                PrevPageText="前一页" showinputbox="Never" ShowNavigationToolTip="True" ShowPageIndexBox="Never"
                Width="100%" PageSize="15" CustomInfoClass="paginator" OnPageChanged="Pager1_PageChanged">
                <span style="color: #000000"></span><strong></strong><span style="color: #000000">&nbsp;&lt;
                            &gt;</span>
            </webdiyer:AspNetPager>
        </div>
    </form>

</body>
</html>
