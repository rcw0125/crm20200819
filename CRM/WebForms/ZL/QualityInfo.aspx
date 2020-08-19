<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QualityInfo.aspx.cs" Inherits="CRM.WebForms.ZL.QualityInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>质量异议信息</title>
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Assets/css/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../Assets/css/jquery.resizableColumns.css" rel="stylesheet" />
    <link href="../../Assets/css/common.css" rel="stylesheet" />
    <link href="../../Assets/css/bootstrap-datetimepicker.css" rel="stylesheet" />
    <link href="css/zeroModal.css" rel="stylesheet" />
    <script src="../../Assets/js/My97DatePicker/WdatePicker.js"></script>
    <script src="../../Assets/js/jquery-2.0.3.min.js"></script>
    <script src="../../Assets/js/jquery.resizableColumns.min.js"></script>
    <script src="../../Assets/js/bootstrap.min.js"></script>
    <script src="../../Assets/js/bootstrap-table.min.js"></script>
    <script src="../../Assets/js/bootstrap-table-zh-CN.min.js"></script>
    <script src="../../Assets/js/common.js"></script>
    <script src="../../Assets/js/bootstrap-datetimepicker.min.js"></script>
    <script src="../../Assets/js/bootstrap-datetimepicker.zh-CN.js"></script>
    <script src="js/zeroModal.js"></script>
    <script src="js/zeroModal.min.js"></script>
    <script src="../../Assets/js/_zero.js"></script>

    <style>
        #trHead th {
            text-align: center;
        }

        .trContent td .trContent td input {
            text-align: center;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <input id="hidempname" type="hidden" runat="server" />
        <table class="table table-bordered table-condensed">
            <tr>
                <td>区域</td>
                <td>
                    <asp:DropDownList ID="ddlArea" runat="server">
                    </asp:DropDownList></td>
                <td>状态</td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server">
                        <asp:ListItem Value="-2">全部</asp:ListItem>
                        <asp:ListItem Value="-1">未提交</asp:ListItem>
                        <asp:ListItem Value="0">待处理</asp:ListItem>
                        <asp:ListItem Value="1">审批中</asp:ListItem>
                        <asp:ListItem Value="2">已完成</asp:ListItem>
                    </asp:DropDownList></td>
                <td>类型</td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server">
                        <asp:ListItem Value="0">全部</asp:ListItem>
                        <asp:ListItem Value="1">质量异议反馈</asp:ListItem>
                        <asp:ListItem Value="2">客户信息反馈</asp:ListItem>
                        <asp:ListItem Value="3">委托检验</asp:ListItem>
                    </asp:DropDownList></td>

                <td>
                    <asp:TextBox ID="txtDistributor" placeholder="经销商" runat="server" Width="80px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtGrd" placeholder="钢种" runat="server" Width="80px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtSaleMan" placeholder="业务员" runat="server" Width="80px"></asp:TextBox></td>
                <td>发货时间</td>
                <td>
                    <input type="text" class="form-control Wdate" runat="server" id="txtStart" style="width: 90px" /></td>
                <td>
                    <input type="text" class="form-control Wdate" runat="server" id="txtEnd" style="width: 90px" /></td>
                <td>
                    <asp:Button ID="btncx" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btncx_Click" />
                    &nbsp;
                      <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn btn-primary btn-xs" OnClick="btnExport_Click" />
                    &nbsp;
                     <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="btn btn-primary btn-xs" OnClick="btnDel_Click" OnClientClick="return confirm('确定要删除吗？');" />
                    &nbsp;
                   <button id="btnAdd" class="btn btn-primary btn-xs" onclick="add()" type="button">添加</button>

                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="450" id="table" style="white-space: nowrap;">
            <thead>
                <tr id="trHead">
                    <th data-sortable="true">行号</th>
                    <th data-sortable="true">编号</th>
                    <th data-sortable="true">反馈类型</th>
                    <th data-sortable="true">提交日期</th>
                    <th data-sortable="true">状态</th>
                    <th data-sortable="true">区域</th>
                    <th data-sortable="true">业务员</th>
                    <th data-sortable="true">经销商</th>
                    <th data-sortable="true">用户</th>
                    <th data-sortable="true">发运日期</th>
                    <th data-sortable="true">到货日期</th>
                    <th data-sortable="true">钢种分类</th>
                    <th data-sortable="true">线材用途</th>
                    <th data-sortable="true">生产工艺</th>
                    <th data-sortable="true">用户异议简述</th>
                    <th data-sortable="true">备注</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr class="trContent <%#DataBinder.Eval (Container.DataItem,"N_STATUSNAME").ToString()=="已完成"?"info":""%>">
                            <td class="tdCheck">
                                
                                <input runat="server" id="cbxselect" type="checkbox" />
                                <%# this.rptList.Items.Count + 1%>

                                <input id="hidCID" class="oldcon" runat="server" type="hidden" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' />
                            </td>

                            <td><%#DataBinder.Eval (Container.DataItem,"C_NO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_FLAGNAME ")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CRT_DT","{0:yyy-MM-dd}")%></td>
                            <td>
                                <asp:Literal ID="ltlN_STATUSNAME" Text='<%#DataBinder.Eval (Container.DataItem,"N_STATUSNAME")%>' runat="server"></asp:Literal>
                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_AREA_ID")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SALESMAN")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_DISTRIBUTOR")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_DIRECTUSER")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_SHIP_START_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_SHIP_END_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_GRD")%></td>

                            <td><%#DataBinder.Eval (Container.DataItem,"C_PROD_USE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_TECH_DESC")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_OBJECT_CONTENT")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_REMARK")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
        <script type="text/javascript">
            $(function () {



                $("#txtStart").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
                $("#txtEnd").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });

                $("#td1 table tbody tr td").click(function () {
                    if ($(this)[0].className == "tdCheck") {
                        return;
                    }
                    var input = $(this).parent().children(0).find("input");
                    var ischecked = input.prop('checked');
                    if (ischecked) {
                        input.prop('checked', '');
                    }
                    else {
                        input.prop('checked', 'checked');
                    }
                });
                $(".table-hover tbody tr").dblclick(function () {
                    var oldCID = $(this).find("input.oldcon").val();//原合同号               
                    window.location.href = "/WebForms/ZL/Quality_Add.aspx?ID=" + oldCID;
                });
            });
            function add() {
                window.location.href = "/WebForms/ZL/Quality_Add.aspx";
            }
            function refers() {
                alert("删除成功!");
                $("#btncx").click();
            }

        </script>
    </form>

</body>
</html>
