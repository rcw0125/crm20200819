<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="THTB.aspx.cs" Inherits="CRM.WebForms.PCI.THTB" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>线材退货同步</title>
    <uc1:common runat="server" ID="common" />
    <script type="text/javascript">
        $(function () {
            var _h = document.documentElement.clientHeight || document.body.clientHeight;
            var w = document.documentElement.clientWidth || document.body.clientWidth;
            $("#flow1").height(_h * 0.4);
            $("#flow2").height(_h * 0.45);
            $("#flow1").width(w);
            $("#flow2").width(w);
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
    <style type="text/css">
        .auto-style1 {
            height: 19px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 180px">
                    <asp:TextBox ID="txtph" placeholder="批号" runat="server" Width="100%"></asp:TextBox>
                </td>
                 <td style="width: 180px">
                    <asp:TextBox ID="txtgh" placeholder="钩号" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" OnClientClick="_loading(1)" />
                </td>
                <td>
                    <asp:Button ID="Button2" CssClass="btn btn-danger btn-xs" runat="server" Text="退货同步" OnClick="btnSync_Click" OnClientClick="_loading(1)" />
                </td>
            </tr>
        </table>
        <div style="overflow: auto; width: 100%;" id="flow1">
            <table id="table1" class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="300" style="white-space: nowrap;">
                <thead>
                    <tr>
                        <th>
                            <input id="cbxAll" type="checkbox" class="qx1" />全选</th>
                        <th data-sortable="true">批号</th>
                        <th data-sortable="true">钩号</th>
                        <th data-sortable="true">单卷号</th>
                        <th data-sortable="true">钢种</th>
                        <th data-sortable="true">仓库</th>
                        <th data-sortable="true">货位</th>
                        <th data-sortable="true">重量</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <input id="cbxselect" class="che1" name="cbx" runat="server" type="checkbox" />
                                </td>
                                <td>
                                    <asp:Literal ID="lblph" Text='<%#DataBinder.Eval (Container.DataItem,"pch") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblgh" Text='<%#DataBinder.Eval (Container.DataItem,"gh") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lbldjh" Text='<%#DataBinder.Eval (Container.DataItem,"barcode") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblgz" Text='<%#DataBinder.Eval (Container.DataItem,"ph") %>' runat="server"></asp:Literal>
                                </td>

                                <td>
                                    <asp:Literal ID="lblck" Text='<%#DataBinder.Eval (Container.DataItem,"ck") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblhw" Text='<%#DataBinder.Eval (Container.DataItem,"hw") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblzl" Text='<%#DataBinder.Eval (Container.DataItem,"zl") %>' runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <div class="div_page">

            <webdiyer:AspNetPager ID="Pager1" runat="server" CssClass="paginator" CurrentPageButtonClass="paginator"
                CurrentPageButtonPosition="End" CustomInfoHTML="总记录：%RecordCount% &nbsp;页码：%CurrentPageIndex% / %pageCount% &nbsp; 每页：%PageSize%"
                CustomInfoSectionWidth="350px" CustomInfoTextAlign="Center" FirstPageText="首页"
                HorizontalAlign="Right" LastPageText="尾页"
                meta:resourcekey="AspNetPager" NextPageText="下一页"
                NumericButtonCount="5" PagingButtonClass=""
                PrevPageText="前一页" showinputbox="Never" ShowNavigationToolTip="True" ShowPageIndexBox="Never"
                Width="100%" PageSize="10" CustomInfoClass="paginator" OnPageChanged="Pager1_PageChanged">
                <span style="color: #000000"></span><strong></strong><span style="color: #000000">&nbsp;&lt;
                            &gt;</span>
            </webdiyer:AspNetPager>
        </div>
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 180px">
                    <asp:TextBox ID="txtphcx" placeholder="批号" runat="server" Width="100%"></asp:TextBox>
                </td>
                   <td style="width: 180px">
                    <asp:TextBox ID="txtghcx" placeholder="钩号" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 90px">日期</td>
                <td style="width: 180px">
                    <asp:TextBox runat="server" class="form-control Wdate " ID="txtBegTime" Style="height: 100%;"></asp:TextBox></td>
                <td style="width: 180px">
                    <asp:TextBox runat="server" class="form-control Wdate " ID="txtEndTime" Style="height: 100%;"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnjlcx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClientClick="_loading(1)" OnClick="btnjlcx_Click" />
                </td>
            </tr>
        </table>
        <div style="overflow: auto; width: 100%" id="flow2">
            <table id="table2" class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="350" style="white-space: nowrap;">
                <thead>
                    <tr>
                        <th data-sortable="true">炉号</th>
                        <th data-sortable="true">批号</th>
                        <th data-sortable="true">钩号</th>
                        <th data-sortable="true">打牌序号</th>
                        <th data-sortable="true">物料编码</th>
                        <th data-sortable="true">物料名称</th>
                        <th data-sortable="true">钢种</th>
                        <th data-sortable="true">执行标准</th>
                        <th data-sortable="true">规格</th>
                        <th data-sortable="true">质量等级</th>
                        <th data-sortable="true">重量</th>
                        <th data-sortable="true">仓库</th>
                        <th data-sortable="true">区域</th>
                        <th data-sortable="true">库位</th>
                        <th data-sortable="true">原仓库</th>
                        <th data-sortable="true">原区域</th>
                        <th data-sortable="true">原库位</th>
                        <th data-sortable="true">操作人</th>
                        <th data-sortable="true">操作时间</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList2" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#DataBinder.Eval (Container.DataItem,"C_STOVE") %>
                                </td>
                                <td>
                                    <%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %>
                                </td>
                                <td>
                                    <%#DataBinder.Eval (Container.DataItem,"C_TICK_NO") %></td>

                                <td><%#DataBinder.Eval (Container.DataItem,"C_BARCODE") %></td>

                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_DESC") %>                                   
                                </td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_WGT") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_AREA_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_LOC_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_YLINEWH_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_YLINEWH_AREA_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_YLINEWH_LOC_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_EMP_ID") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"D_MOD_DT") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="lblFYD" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlRecord" runat="server" Visible="false"></asp:Literal>
    </form>
    <script type="text/javascript">
        selectAll("input.qx1", "input.che1");
        function selectSingleRadio(rbtn1, GroupName) {
            $("input[type=radio]").each(function (i) {
                if (this.name.substring(this.name.length - GroupName.length) == GroupName) {
                    this.checked = false;
                }
            })
            rbtn1.checked = true;
        }
    </script>
</body>
</html>
