<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FYCX.aspx.cs" Inherits="CRM.WebForms.PCI.FYCX" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>发运统计查询</title>
    <uc1:common runat="server" ID="common" />
    <script type="text/javascript">
        function getzcsj(fyd) {
            var url = '../Sale_App/fyd_zc_sj.html?key=' + fyd;
            _iframe(url, '800', '350', '发运单装车实绩');
        }
    </script>
</head>
<body onresize="fromsize();">
    <form id="form1" runat="server">
        <div class="dv_btn">
            <ul>

                <li>
                    <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn btn-success btn-xs" OnClick="btnExport_Click" /></li>
                <li>
                    <asp:Button ID="btnTB" runat="server" Text="同步条码执行状态" CssClass="btn btn-success btn-xs" OnClick="btnTB_Click" /></li>
            </ul>
        </div>
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox ID="txtfyd" runat="server" placeholder="发运单号" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtzdr" runat="server" placeholder="制单人" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtcph" runat="server" placeholder="车牌号" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtconno" runat="server" placeholder="合同号" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtcust" runat="server" placeholder="客户" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtmatcode" runat="server" placeholder="物料编码" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtstlgrd" runat="server" placeholder="钢种" Width="100%"></asp:TextBox></td>

            </tr>
            <tr>
                <td>是否线材&nbsp;
                    <asp:DropDownList ID="dropsfxc" runat="server" Width="50px">
                        <asp:ListItem Value="0001NC10000000007H28">是</asp:ListItem>
                        <asp:ListItem Value="0001NC10000000007H29">否</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>质量等级
                     <asp:DropDownList ID="dropzldj" runat="server"></asp:DropDownList>
                </td>
                <td>发运方式</td>
                <td>
                    <asp:DropDownList ID="dropfyfs" runat="server" Width="100%"></asp:DropDownList></td>
                <td>是否包到价&nbsp;<asp:DropDownList ID="dropsfbdj" runat="server" Width="50px">
                    <asp:ListItem>全部</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                    <asp:ListItem Value="1">是</asp:ListItem>
                </asp:DropDownList></td>
                <td>
                    <asp:DropDownList ID="droparea" runat="server" Width="100%"></asp:DropDownList></td>
                <td>
                    <asp:TextBox ID="txtspec" runat="server" placeholder="规格" Width="100%"></asp:TextBox></td>

            </tr>


            <tr>
                <td>
                    <asp:TextBox ID="txtstation" runat="server" placeholder="到站" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtaddr" runat="server" placeholder="到货地点" Width="100%"></asp:TextBox></td>
                <td>是否导入条码&nbsp;<asp:DropDownList ID="dropzt" runat="server">
                    <asp:ListItem>全部</asp:ListItem>
                    <asp:ListItem Value="1">是</asp:ListItem>
                    <asp:ListItem Value="2">否</asp:ListItem>
                </asp:DropDownList>

                </td>
                <td>条码执行状态</td>
                <td>
                    <asp:DropDownList ID="dropzxzt" runat="server">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem Value="未执行">未执行</asp:ListItem>
                        <asp:ListItem Value="已进门">已进门</asp:ListItem>
                        <asp:ListItem Value="装车完毕">装车完毕</asp:ListItem>
                        <asp:ListItem Value="已出门">已出门</asp:ListItem>
                        <asp:ListItem Value="已作废">已作废</asp:ListItem>
                        <asp:ListItem Value="正在装车">正在装车</asp:ListItem>
                    </asp:DropDownList>

                </td>
                <td>
                    <asp:TextBox ID="txtgps" runat="server" placeholder="GPS号" Width="100%"></asp:TextBox></td>
                <td> <asp:DropDownList ID="dropcys" runat="server" Width="100%"></asp:DropDownList></td>

            </tr>
            <tr>
                <td>
                    <input id="cbx_dt" type="checkbox" runat="server" />制单日期
                </td>
                <td>
                    <input id="txtStart" type="text" runat="server" style="cursor: pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td>
                    <input id="txtEnd" runat="server" type="text" style="cursor: pointer" readonly="readonly" class=" form-control Wdate" /></td>
                <td>
                    <input id="cbx_ck_dt" type="checkbox" runat="server" />
                    出库日期</td>
                <td>
                    <input id="txtckkssj" type="text" runat="server" style="cursor: pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td>
                    <input id="txtckjssj" type="text" runat="server" style="cursor: pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td>
                    <asp:Button ID="btnxc" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btnxc_Click" />
                    &nbsp;
                </td>

            </tr>

            <tr>
                <td>
                    <input id="cbx_RFINTIME" type="checkbox" runat="server" />进厂日期</td>
                <td>
                    <input id="txtjckssj" type="text" runat="server" style="cursor: pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td>
                    <input id="txtjcjssj" type="text" runat="server" style="cursor: pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td>
                    <input id="cbx_RFOUTTIME" type="checkbox" runat="server" />出厂日期</td>
                <td>
                    <input id="txtcckssj" type="text" runat="server" style="cursor: pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td>
                    <input id="txtccjssj" type="text" runat="server" style="cursor: pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td>&nbsp;</td>

            </tr>

        </table>
        <div>
            <table class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="450" id="table" style="white-space: nowrap;">
                <thead>
                    <tr class="info">
                        <th>合计</th>
                        <th></th>
                        <th></th>
                         <th></th>
                        <th></th>
                        <th>
                            <asp:Literal ID="ltlsum_jhnum" runat="server"></asp:Literal></th>
                        <th>
                            <asp:Literal ID="ltlsum_sjnum" runat="server"></asp:Literal></th>
                        <th>
                            <asp:Literal ID="ltlsum_jhwgt" runat="server"></asp:Literal></th>
                        <th>
                            <asp:Literal ID="ltlsum_sjwgt" runat="server"></asp:Literal></th>
                        <th></th>
                        <th>实际监控重量</th>
                        <th>
                            <asp:Literal ID="ltlsum_kjwgt" runat="server"></asp:Literal></th>
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
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        
                    </tr>
                    <tr>
                        <th data-sortable="true">发运单号</th>
                        <th data-sortable="true">发运方式</th>
                        <th data-sortable="true">车牌号</th>
                        <th data-sortabel="true">通行证</th>
                        <th data-sortable="true">仓库</th>
                        <th data-sortable="true">计划数量</th>
                        <th data-sortable="true">实际数量</th>
                        <th data-sortable="true">计划重量</th>
                        <th data-sortable="true">实际重量</th>
                        <th data-sortable="true">含税单价</th>
                        <th data-sortable="true">条码执行状态</th>
                        <th data-sortable="true">入厂时间</th>
                        <th data-sortable="true">出厂时间</th>
                        <th data-sortable="true">到站</th>
                        <th data-sortable="true">到货地点</th>
                        <th data-sortable="true">运费</th>
                        <th data-sortable="true">承运商</th>
                        <th data-sortable="true">GPS号</th>
                        <th data-sortable="true">物料编码</th>
                        <th data-sortable="true">物料名称</th>
                        <th data-sortable="true">钢种</th>
                        <th data-sortable="true">规格</th>
                        <th data-sortable="true">执行标准</th>
                        <th data-sortable="true">自由项1</th>
                        <th data-sortable="true">自由项2</th>
                        <th data-sortable="true">质量等级</th>
                        <th data-sortable="true">包装要求</th>
                        <th data-sortable="true">需求提报人</th>
                        <th data-sortable="true">需求提报日期</th>
                        <th data-sortable="true">制单人</th>
                        <th data-sortable="true">制单日期</th>
                        <th data-sortable="true">区域</th>
                        <th data-sortable="true">合同号</th>
                        <th data-sortable="true">客户名称</th>
                        <th data-sortable="true">司机姓名/电话</th>
                        <th data-sortable="true">客户姓名/电话</th>
                        <th data-sortabel="true">收货单位</th>
                        
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><a href="javascript:void(0);" onclick="getzcsj('<%#DataBinder.Eval (Container.DataItem,"C_DISPATCH_ID")%>');"><%#DataBinder.Eval (Container.DataItem,"C_DISPATCH_ID") %></a></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_SHIPVIA") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_LIC_PLA_NO") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"CARTYPE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_SEND_STOCK_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_FYZS") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_NUM") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_FYWGT") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_JZ") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURTAXPRICE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_RFSTATUS") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"D_RFINTIME") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"D_RFOUTTIME") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_ATSTATION") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_AOG_SITE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_PRICE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_COMCAR") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_GPS_NO") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_FREE_TERM") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_FREE_TERM2") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_QUALIRY_LEV") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_PACK") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_CREATE_ID") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"D_CREATE_DT") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_XGEMP") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"D_XGTIME") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_AREA") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_EXTEND3") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_EXTEND4") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"SHDW") %></td>
                                
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        
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

                $("#txtjckssj").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
                $("#txtjcjssj").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
                $("#txtcckssj").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
                $("#txtccjssj").datetimepicker({
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
