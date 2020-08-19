<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order_ZB.aspx.cs" Inherits="CRM.WebForms.Report.Order_ZB" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>订单排产指标</title>
    <uc1:ReptControl runat="server" ID="ReptControl" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed table-hover">
            <tr>
                <td style="width: 80px">提报日期</td>
                <td style="width: 100px;">
                    <input id="txtStart" runat="server" type="text" style="width: 100px;" class=" form-control Wdate" />

                </td>
                <td style="width: 100px">
                    <input id="txtEnd" runat="server" type="text" style="width: 100px;" class=" form-control Wdate" /></td>

                <td>旬指标
                </td>
                <td style="width: 60px;">
                    <asp:DropDownList ID="dropZB" runat="server">
                        <asp:ListItem Value="0">上旬</asp:ListItem>
                        <asp:ListItem Value="1">中旬</asp:ListItem>
                        <asp:ListItem Value="2">下旬</asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td style="width: 100px">
                    <asp:Button ID="btnCX" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btnCX_Click" OnClientClick="_loading(1);" />

                </td>


                <td>监控钢种</td>
                <td>
                    <asp:TextBox ID="txtjkzb" runat="server" Width="40" placeholder="监控钢种" CssClass="numJe" Text="12"></asp:TextBox>
                </td>
                <td>精品钢种</td>
                <td>
                    <asp:TextBox ID="txtjp" runat="server" Width="40" placeholder="普通精品钢种" CssClass="numJe" Text="30"></asp:TextBox>
                </td>
                <td>品种钢</td>
                <td>
                    <asp:TextBox ID="txtpz" runat="server" Width="40" placeholder="品种钢" CssClass="numJe" Text="45"></asp:TextBox>
                </td>
                <td>普碳钢</td>
                <td>
                    <asp:TextBox ID="txtpt" runat="server" Width="40" placeholder="普碳钢" CssClass="numJe" Text="45"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnZB" runat="server" Text="保存指标" CssClass="btn btn-primary btn-xs" OnClick="btnZB_Click" OnClientClick="_loading(1);" />

                    &nbsp;
                 
                   <asp:Button ID="btnFlag" runat="server" CssClass="btn btn-warning btn-xs" Text="指标控制" OnClientClick="_loading(1);" OnClick="btnFlag_Click" />
                    &nbsp;
                      <asp:Button ID="btndel" runat="server" Text="删除指标" CssClass="btn btn-danger btn-xs" OnClientClick="return confirm('确定要删除吗？');" OnClick="btndel_Click" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="450" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th></th>
                    <th colspan="5" style="text-align: center">月预算指标</th>
                    <th colspan="4" style="text-align: center">旬指标</th>
                    <th colspan="5" style="text-align: center">实际需求</th>
                    <th colspan="4" style="text-align: center">差值</th>
                    <th colspan="4" style="text-align: center">单项指标</th>
                    <th></th>
                </tr>
                <tr>
                    <th data-sortable="true"><input id="cbxAll" type="checkbox" class="qx1" />区域</th>
                    <th data-sortable="true">监控钢种</th>
                    <th data-sortable="true">普通精品钢</th>
                    <th data-sortable="true">品种钢</th>
                    <th data-sortable="true">普碳钢</th>
                    <th data-sortable="true">合计</th>
                    <th data-sortable="true">监控钢种</th>
                    <th data-sortable="true">普通精品钢</th>
                    <th data-sortable="true">品种钢</th>
                    <th data-sortable="true">普碳钢</th>
                    <th data-sortable="true">监控钢种</th>
                    <th data-sortable="true">普通精品钢</th>
                    <th data-sortable="true">品种钢</th>
                    <th data-sortable="true">普碳钢</th>
                    <th data-sortable="true">正常订单占比</th>
                    <th data-sortable="true">监控钢种</th>
                    <th data-sortable="true">普通精品钢</th>
                    <th data-sortable="true">品种钢</th>
                    <th data-sortable="true">普碳钢</th>
                    <th data-sortable="true">监控钢种</th>
                    <th data-sortable="true">普通精品钢</th>
                    <th data-sortable="true">品种钢</th>
                    <th data-sortable="true">普碳钢</th>
                    <th data-sortable="true">指标控制</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr class="<%#DataBinder.Eval (Container.DataItem,"C_FLAG").ToString()=="Y"?"danger":""%>">
                            <!--月指标-->
                            <td>
                                <input id="cbxID" style="width: 15px;" class="che1" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' type="checkbox" />

                                <asp:Literal ID="ltlC_AREA" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_AREA")%>'></asp:Literal></td>
                            <td>
                                <input id="txtN_MONTH_JK_ZB" class="numJe" style="width: 100%" type="text" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"N_MONTH_JK_ZB")%>' /></td>

                            <td>
                                <input id="txtN_MONTH_JP_ZB" class="numJe" style="width: 100%" type="text" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"N_MONTH_JP_ZB")%>' />
                            </td>
                            <td>
                                <input id="txtN_MONTH_PZ_ZB" class="numJe" style="width: 100%" type="text" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"N_MONTH_PZ_ZB")%>' />
                            </td>
                            <td>
                                <input id="txtN_MONTH_PT_ZB" class="numJe" style="width: 100%" type="text" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"N_MONTH_PT_ZB")%>' />
                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"SUM_JP_PZ")%></td>

                            <!--旬指标-->
                            <td>
                                <input id="txtN_DAY_JK_ZB" class="numJe" style="width: 100%" type="text" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"N_DAY_JK_ZB")%>' />
                            </td>
                            <td>
                                <input id="txtN_DAY_JP_ZB" class="numJe" style="width: 100%" type="text" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"N_DAY_JP_ZB")%>' />
                            </td>
                            <td>
                                <input id="txtN_DAY_PZ_ZB" class="numJe" style="width: 100%" type="text" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"N_DAY_PZ_ZB")%>' />
                            </td>
                            <td>
                                <input id="txtN_DAY_PT_ZB" class="numJe" style="width: 100%" type="text" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"N_DAY_PT_ZB")%>' />
                            </td>

                            <!--实际需求-->
                            <td><%#DataBinder.Eval (Container.DataItem,"N_WGT_JK")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_WGT_JP")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_WGT_PZ")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_WGT_PT")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"ZB")%></td>

                            <!--差值-->
                            <td><%#DataBinder.Eval (Container.DataItem,"JK_CZ")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"JP_CZ")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"PZ_CZ")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"PT_CZ")%></td>

                            <!--单项指标-->
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"N_PC_JK")%>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"N_PC_JP")%>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"N_PC_PZ")%>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"N_PC_PT")%>
                            </td>
                            <td>
                                <asp:Literal ID="ltlC_FLAG" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_FLAG")%>'></asp:Literal>
                                <asp:Literal ID="ltlC_TYPE" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_TYPE2")%>'></asp:Literal>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
        <asp:Literal ID="ltlEmpName" runat="server" Visible="false"></asp:Literal>
        <script type="text/javascript">

            //全选
            selectAll("input.qx1", "input.che1");

            $(function () {
                $("#txtStart").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true,//显示今日按钮
                });

                $("#txtEnd").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true,//显示今日按钮
                });
            });
        </script>
    </form>
</body>
</html>
