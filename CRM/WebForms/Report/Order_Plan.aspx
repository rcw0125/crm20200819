<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order_Plan.aspx.cs" Inherits="CRM.WebForms.Report.Order_Plan" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>旬订单排产提报</title>
    <uc1:common runat="server" ID="common" />
</head>
<body onresize="fromsize();">
    <form id="form1" runat="server">
        <ul id="myTab" class="nav nav-tabs">
            <li class="active"><a href="#tab1" data-toggle="tab">区域排产订单</a> </li>
            <li><a href="#tab2" data-toggle="tab">线材计划订单执行情况查询</a></li>
        </ul>
        <div id="myTabContent" class="tab-content">
            <div class="tab-pane fade in active" id="tab1">
                <table class="table table-bordered table-condensed" style="margin-top: 5px;">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtStlGrd" runat="server" placeholder="钢种" Width="100%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMatCode" runat="server" placeholder="物料编码" Width="100%"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtcon" runat="server" placeholder="合同号" Width="100%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="dropPack" runat="server" Width="100px"></asp:DropDownList></td>
                        <td style="width: 60px;">订单</td>
                        <td>
                            <asp:DropDownList ID="dropOrderType" runat="server" Width="50px">
                                <asp:ListItem>全部</asp:ListItem>
                                <asp:ListItem Value="0">正常订单</asp:ListItem>
                                <asp:ListItem Value="1">预测订单</asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 60px;">区域</td>
                        <td>
                            <asp:DropDownList ID="dropArea" runat="server" Width="100px"></asp:DropDownList>
                        </td>

                        <td style="width: 100px;">
                            <asp:CheckBox ID="cbx_jh" runat="server" Text="计划日期" /></td>
                        <td>
                            <input id="txtStart" type="text" style="width: 100px;" readonly="readonly" class=" form-control Wdate" runat="server" /></td>

                    </tr>
                    <tr>


                        <td>
                            <asp:DropDownList ID="dropSpec" runat="server" Width="100%"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCust" runat="server" placeholder="客户" Width="100%"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtSaleEmp" runat="server" placeholder="提报人" Width="100%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="dropMatName" runat="server" Width="100px"></asp:DropDownList></td>

                        <td>状态</td>

                        <td>
                            <asp:DropDownList ID="dropStatus" runat="server" Width="100%">
                                <asp:ListItem>全部</asp:ListItem>
                                <asp:ListItem Value="-1">已提报</asp:ListItem>
                                <asp:ListItem Value="0">已审核</asp:ListItem>
                                <asp:ListItem Value="6">已完成</asp:ListItem>
                            </asp:DropDownList></td>


                        <td>评价</td>
                        <td>
                            <asp:DropDownList ID="dropPJ" runat="server" Width="100%">
                                <asp:ListItem>全部</asp:ListItem>
                                <asp:ListItem Value="Y">已评价</asp:ListItem>
                                <asp:ListItem Value="N">未评价</asp:ListItem>
                            </asp:DropDownList>
                        </td>


                        <td>
                            <asp:CheckBox ID="cbx_xq" runat="server" Text="需求日期" />
                        </td>
                        <td>
                            <input id="txtEnd" runat="server" type="text" style="width: 100px;" readonly="readonly" class=" form-control Wdate" /></td>



                    </tr>

                </table>
                <table class="table table-bordered table-condensed">
                    <tr>


                        <td>
                            <asp:TextBox ID="txtstdcode" runat="server" placeholder="执行标准" Width="100%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtorderno" runat="server" placeholder="订单号" Width="100%" Height="50px" TextMode="MultiLine"></asp:TextBox>
                        </td>

                        <td>
                            <asp:CheckBox ID="cbxtb_DT" runat="server" Text="提报时间" /></td>

                        <td>
                            <input id="txttbkssj" runat="server" type="text" style="width: 100px;" readonly="readonly" class=" form-control Wdate" /></td>


                        <td>
                            <input id="txttbjssj" runat="server" type="text" style="width: 100px;" readonly="readonly" class=" form-control Wdate" /></td>
                        <td>
                            <asp:CheckBox ID="cbxsh_DT" runat="server" Text="审核时间" /></td>
                        <td>
                            <input id="txtshkssj" runat="server" type="text" style="width: 100px;" readonly="readonly" class=" form-control Wdate" /></td>

                        <td>
                            <input id="txtshjssj" runat="server" type="text" style="width: 100px;" readonly="readonly" class=" form-control Wdate" /></td>



                    </tr>
                </table>
                <table class="table table-bordered table-condensed">
                    <tr>

                        <td style="text-align: center">
                            <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btnSearch_Click" OnClientClick="_loading(1);" />

                            &nbsp;
                             <asp:Button ID="btnOK" runat="server" Text="审核" CssClass="btn  btn-danger btn-xs" OnClick="btnOK_Click" OnClientClick="return check_ok();" Visible="false" />
                            &nbsp;
                            <asp:Button ID="btnCancelOK" runat="server" Text="弃审" CssClass="btn  btn-info btn-xs" OnClientClick="return check_qxok();" OnClick="btnCancelOK_Click" Visible="false" />
                            &nbsp;
                            <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn  btn-success btn-xs" OnClick="btnExport_Click" />
                            &nbsp; 
                            <asp:Button ID="btnDel" runat="server" Text="关闭订单" CssClass="btn btn-warning btn-xs" Visible="false" OnClick="btnDel_Click" OnClientClick="return confirm('确定要操作吗');" />
                            &nbsp;
                            <asp:Button ID="btnUpdateArea" runat="server" Text="区域置空" CssClass="btn btn-warning btn-xs" Visible="false" OnClientClick="return confirm('确定要操作吗');" OnClick="btnUpdateArea_Click" />
                        </td>
                    </tr>
                </table>
                <div style="overflow: auto; width: 100%; position: relative;" id="flow1">
                    <table class="table table-bordered table-condensed table-hover" style="white-space: nowrap;">
                        <thead>
                            <tr class="info">
                                <th>合计</th>
                                <th></th>
                                <th></th>
                                <th></th>
                                <th></th>
                                <th></th>
                                <th class="red">&nbsp;</th>
                                <th></th>
                                <th>
                                    <asp:Literal ID="ltlsumwgt" runat="server"></asp:Literal></th>

                                <th>
                                    &nbsp;</th>
                                <th>
                                    &nbsp;</th>
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
                                <th></th>
                            </tr>
                            <tr>
                                <th>
                                    <input id="cbxSelectAll" type="checkbox" class="qx1" />全选</th>
                                <th>订单号</th>
                                <th class="red">计划日期</th>
                                <th class="red">需求日期</th>

                                <th>物料名称</th>
                                <th>物料编码</th>
                                <th>规格</th>
                                <th>钢种</th>
                                <th class="red">数量</th>
                                <th class="red">完工量</th>
                                <th class="red">分配量</th>
                                <th class="red">出库量</th>
                                <th>自由项1</th>
                                <th>自由项2</th>
                                <th>执行标准</th>
                                <th>包装要求</th>
                                <th>销售区域</th>
                                <th>处理状态</th>
                                <th>订单类型</th>
                                <th>订单评价</th>

                                <th>提报日期</th>
                                <th>审核日期</th>
                                <th>客户</th>

                                <th>合同号</th>

                                <th>合同状态</th>
                                <th>订单日期</th>
                                <th>业务员</th>
                                <th>提报人</th>
                                <th>审核人</th>
                                <th>评价原因</th>
                                <th>备注说明</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                    <tr onclick="selectcheck(this);">
                                        <td>
                                            <input id="cbxSelect" type="checkbox" runat="server" class="che1" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' />
                                            <span class="rowno"><%#Container.ItemIndex+1 %></span>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltlC_ORDER_NO" Text='<%#DataBinder.Eval (Container.DataItem,"C_ORDER_NO")%>' runat="server"></asp:Literal>
                                        </td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"D_PCTBTS","{0:yyy-MM-dd}") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"D_NEED_DT","{0:yyy-MM-dd}") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %> <a href="javascript:void(0);" onclick="openWeb('<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %>');"><span class="glyphicon glyphicon-search"></span></a></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                                        <td class="red">
                                            <asp:Literal ID="ltlwgt" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT")%>' runat="server"></asp:Literal>
                                        </td>
                                        <td class="red"><%#DataBinder.Eval (Container.DataItem,"WG_WGT")%></td>
                                        <td class="red"><%#DataBinder.Eval (Container.DataItem,"N_LINE_MATCH_WGT")%></td>
                                        <td class="red"><%#DataBinder.Eval (Container.DataItem,"OUTWGT")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_FREE1") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_FREE2") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_PACK") %></td>

                                        <td><%#DataBinder.Eval (Container.DataItem,"C_AREA") %></td>
                                        <td class="darkorange">
                                            <asp:Literal ID="ltlN_EXEC_STATUS" Text='<%#DataBinder.Eval (Container.DataItem,"N_EXEC_STATUS") %>' runat="server"></asp:Literal>
                                        </td>
                                        <td class="darkorange"><%#DataBinder.Eval (Container.DataItem,"N_FLAG") %></td>
                                        <td class="darkorange">
                                            <asp:Literal ID="ltlC_SFPJ" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_SFPJ") %>'></asp:Literal>

                                        </td>

                                        <td><%#DataBinder.Eval (Container.DataItem,"D_DT") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"D_STL_ROL_DT") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %></td>

                                        <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %></td>

                                        <td>
                                            <%#DataBinder.Eval (Container.DataItem,"N_STATUS") %>
                                        </td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"D_DT","{0:yyy-MM-dd}") %></td>

                                        <td><%#DataBinder.Eval (Container.DataItem,"C_YWY") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_PCTBEMP") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_ISSUE_EMP_ID") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_REMARK") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_REMARK4") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                        </tbody>

                    </table>
                </div>


            </div>
            <div class="tab-pane fade" id="tab2">
                <iframe style="width: 100%; border: 0px;" src="../PCI/OrderEQuery.aspx" id="iframe1"></iframe>
            </div>



        </div>

        <asp:Literal ID="ltllempname" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltllempid" runat="server" Visible="false"></asp:Literal>
        <script type="text/javascript">
            $(function () {
                $('#myTab li:eq(0) a').tab('show');
                fromsize();
                //全选
                selectAll("input.qx1", "input.che1");


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

                $("#txttbkssj").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });

                $("#txttbjssj").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
                $("#txtshkssj").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });

                $("#txtshjssj").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
            });

            function fromsize() {
                var _h = document.documentElement.clientHeight
                $("#flow1").height(_h - 230);
                $("#iframe1").height(_h - 50);

            }

            function selectcheck(check) {
                var input = $(check).children(0).find("input:checkbox");
                var ischecked = input.prop('checked');
                if (ischecked) {
                    input.prop('checked', '');
                }
                else {
                    input.prop('checked', 'checked');
                }
            }


            function check_qxok() {
                if (confirm("确定弃审吗")) {
                    _loading(1);
                    return true;
                }
                else {
                    return false;
                }
            }
            function check_ok() {
                if (confirm("请核实当前计划日期与需求日期,无误点击确定！")) {
                    _loading(1);
                    return true;
                }
                else {

                    return false;
                }
            }

            function openWeb(matcode) {

                var url = "order_exe_view.aspx?ID=" + matcode;
                _iframe(url, '600', '400', '计划订单执行情况');
            }
        </script>
    </form>
</body>
</html>
