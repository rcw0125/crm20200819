  

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roll_prodcut.aspx.cs" Inherits="CRM.WebForms.Report.roll_prodcut" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>线材仓库查询</title>
    <uc1:common runat="server" ID="common" />

</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox runat="server" placeholder="批次号" ID="txtbatchno" Width="100"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="钢种" ID="txtstlgrd" Width="100"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="物料编码" ID="txtmatcode" Width="100"></asp:TextBox></td>
                <td><asp:TextBox runat="server" placeholder="合同号" ID="txtcon" Width="80"></asp:TextBox></td>
                <td>
                    <asp:DropDownList ID="droptsxx" runat="server" Width="100"></asp:DropDownList></td>
                <td>质量</td>
                <td>
                    <asp:DropDownList ID="dropzldj" runat="server" OnSelectedIndexChanged="dropzldj_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                <td>
                    <asp:DropDownList ID="dropsfsn" runat="server">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem Value="室内">室内</asp:ListItem>
                        <asp:ListItem Value="室外">室外</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="text-align: right">
                    <input id="cbx_dt" type="checkbox" runat="server" />
                    生产日期</td>
                <td>
                    <input id="txtkssj" type="text" runat="server" style="cursor: pointer; width: 100px;" readonly="readonly" class="form-control Wdate" /></td>
                <td>
                    <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn btn-success btn-xs" OnClick="btnExport_Click" /></td>


            </tr>

            <tr>
                <td>
                    <asp:TextBox runat="server" placeholder="仓库编码" ID="txtckcode" Width="100"></asp:TextBox></td>

                <td>
                    <asp:TextBox runat="server" placeholder="规格" ID="txtspec" Width="100"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="客户名称" ID="txtcustname" Width="100"></asp:TextBox></td>
                <td>待判</td>
                <td>
                    <asp:DropDownList ID="dropflag" runat="server" Width="100">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem Value="Y">已判</asp:ListItem>
                        <asp:ListItem Value="N">待判</asp:ListItem>
                    </asp:DropDownList></td>
                <td>部门</td>
                <td>
                    <asp:DropDownList ID="dropsalearea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropsalearea_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="dropMinArea" runat="server"></asp:DropDownList></td>
                <td style="text-align: right">截至日期</td>

                <td>
                    <input id="txtjssj" type="text" runat="server" style="cursor: pointer; width: 100px;" readonly="readonly" class="form-control Wdate" /></td>
                <td>
                    <asp:Button ID="btn_xc" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btn_xc_Click" OnClientClick="_loading(1);" />
                </td>


            </tr>

        </table>


        <table class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="450" id="table" style="white-space: nowrap;">
            <thead>
                <tr class="info">

                    <th>合计</th>
                    <th>总吨数</th>
                    <th></th>
                    <th></th>
                    <th>
                        <asp:Literal ID="ltlsumwgt" runat="server"></asp:Literal>
                    </th>
                    <th>总件数</th>
                    <th>
                        <asp:Literal ID="ltlcount" runat="server"></asp:Literal>
                    </th>
                    <th>监控吨数</th>
                    <th>
                        <asp:Literal ID="ltlsum_kjwgt" runat="server"></asp:Literal>
                    </th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>

                </tr>
                <tr>

                    <th data-sortable="true">批次号</th>
                    <th data-sortable="true">仓库</th>
                    <th data-sortable="true">货位</th>
                    <th data-sortable="true">是否室内</th>
                    <th data-sortable="true">销售区域</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">质量等级</th>
                    <th data-sortable="true">物料编码</th>
                    <th data-sortable="true">物料名称</th>
                    <th data-sortable="true">自由项1</th>
                    <th data-sortable="true">自由项2</th>
                    <th data-sortable="true">包装要求</th>
                    <th data-sortable="true">特殊信息</th>
                    <th data-sortable="true">件数</th>
                    <th data-sortable="true">吨数</th>
                    <th data-sortable="true">生产日期</th>
                    <th data-sortable="true">终判时间</th>
                    <th data-sortable="true">判定耗时</th>
                    <th data-sortable="true">库龄</th>
                    <th data-sortable="true">是否预警</th>
                    <th data-sortable="true">是否超期</th>
                    <th data-sortable="true">是否监控</th>
                    <th data-sortable="true">客户信息</th>
                    <th data-sortable="true">合同号</th>
                    <th data-sortable="true">订单号</th>


                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr class='<%#DataBinder.Eval (Container.DataItem,"SF_YJ").ToString()=="Y"?DataBinder.Eval (Container.DataItem,"sf_cq").ToString()=="Y"?"danger":"warning":"" %>'>

                            <td>
                                <asp:Literal ID="ltlbatch" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %>'></asp:Literal></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_CODE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_LOC_CODE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ISOUT") %></td>
                            <td>
                                <asp:Literal ID="ltlsalearea" Text='<%#DataBinder.Eval (Container.DataItem,"C_SALE_AREA") %>' runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlstlgrd" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>' runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlspec" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC") %>' runat="server"></asp:Literal></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH").ToString()==""?"DP":DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %></td>
                            <td>
                                <asp:Literal ID="ltlmatcode" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %>' runat="server"></asp:Literal></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_DESC") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ZYX1") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ZYX2") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_BZYQ") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_PCINFO") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"JIANSHU") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_WGT") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_PRODUCE_DATE","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_QR_DATE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"PD_TIME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_DAY") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"SF_YJ") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"SF_CQ") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_FLAG") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ORDER_NO") %>&nbsp;<a href="javascript:void(0);" onclick="geturl_pc_view('<%#DataBinder.Eval (Container.DataItem,"C_ORDER_NO") %>');"><span class="glyphicon glyphicon-search"></span></a></td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>


        <script type="text/javascript">
            $(function () {


                $("#table").resizableColumns();

                $("#txtkssj").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
                $("#txtjssj").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
            });

            function geturl_pc_view(id) {

                var url = 'PC_ORDER_VIEW2.aspx?ID=' + id;
                _iframe(url, '900', '400', '线材订单排产执行情况表');
            }

        </script>

    </form>

</body>
</html>
