<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderEQuery.aspx.cs" Inherits="CRM.WebForms.PCI.OrderEQuery" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>线材计划订单执行情况查询</title>
    <uc1:common runat="server" ID="common" />

    <script src="../JsDate.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>

                <td>
                    <asp:TextBox runat="server" placeholder="订单号" ID="txtOrder" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" placeholder="物料编码" ID="txtmatcode" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" placeholder="钢种" ID="txtGrd" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" placeholder="规格" ID="txtSpec" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" placeholder="客户名称" ID="txtcust" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" placeholder="执行标准" ID="txtExcuteB" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 100px">订单日期
                </td>
                <td>
                    <input id="Start" runat="server" type="text" style="width: 120px;" readonly="readonly" class="Wdate" />

                </td>
                <td>
                    <input id="End" runat="server" type="text" style="width: 120px;" readonly="readonly" class="Wdate" /></td>
                <td>
                    <asp:DropDownList ID="dropsalearea" runat="server"></asp:DropDownList>
                </td>

                <td style="width: 150px">
                    <asp:Button ID="btncx3" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx3_Click" />
                    &nbsp;<asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn  btn-success btn-xs" OnClick="btnExport_Click" />
                </td>
            </tr>
        </table>
        <table id="table2" class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="450" style="white-space: nowrap;">
            <thead>
                <tr class="info">
                    <th>合计：</th>
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
                    <th>
                        <asp:Literal ID="lstJHXQ" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstWG" runat="server"></asp:Literal>
                    </th>
                    <th><asp:Literal ID="ltlfpsum" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstKC" runat="server"></asp:Literal></th>

                    <th>
                        <asp:Literal ID="lstCK" runat="server"></asp:Literal></th>

                    <th>
                        <asp:Literal ID="lstGPXCL" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstXCK" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstXD" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstHG" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstDJ" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstGP" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstXY" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstTWC" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstBHG" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstHGP" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstGPRK" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstXYRK" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstTWCRK" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstBHGRK" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstHGCK" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstGPCK" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstXYCK" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstTWCK" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="lstBHGCK" runat="server"></asp:Literal></th>
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
                    <th data-sortable="true">订单号</th>
                    <th data-sortable="true">原计划日期</th>
                    <th data-sortable="true">计划日期</th>
                    <th data-sortable="true">需求日期</th>
                    <th data-sortable="true">销售区域</th>
                    <th data-sortable="true">合同号</th>
                    <th data-sortable="true">客户名称</th>
                    <th data-sortable="true">物料编码</th>
                    <th data-sortable="true">物料名称</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">自由项1</th>
                    <th data-sortable="true">自由项2</th>
                    <th data-sortable="true">包装要求</th>
                    <th data-sortable="true">计划需求量</th>
                    <th data-sortable="true">完工数量</th>
                    <th data-sortable="true">分配量</th>
                    <th data-sortable="true">库存数量</th>
                    <th data-sortable="true">出库数量</th>

                    <th data-sortable="true">钢坯现存量</th>
                    <th data-sortable="true">线材库存量</th>
                    <th data-sortable="true">计划下达量</th>
                    <th data-sortable="true">合格数量</th>
                    <th data-sortable="true">待检数量</th>
                    <th data-sortable="true">改判数量</th>
                    <th data-sortable="true">协议品数量</th>
                    <th data-sortable="true">头尾材数量</th>
                    <th data-sortable="true">不合格品数量</th>
                    <th data-sortable="true">合格品入库数量</th>
                    <th data-sortable="true">改判入库数量</th>
                    <th data-sortable="true">协议品入库数量</th>
                    <th data-sortable="true">头尾材入库数量</th>
                    <th data-sortable="true">不合格品入库数量</th>
                    <th data-sortable="true">合格品出库数量</th>
                    <th data-sortable="true">改判出库数量</th>
                    <th data-sortable="true">协议品出库数量</th>
                    <th data-sortable="true">头尾材出库数量</th>
                    <th data-sortable="true">不合格品出库数量</th>
                    <th data-sortable="true">销售出库最小时间</th>
                    <th data-sortable="true">销售出库最大时间</th>
                    <th data-sortable="true">生产最小时间</th>
                    <th data-sortable="true">生产最大时间</th>

                    <th data-sortable="true">运输方式</th>
                    <th data-sortable="true">修磨要求</th>

                    <th data-sortable="true">到站</th>
                    <th data-sortable="true">产品类型</th>
                    <th data-sortable="true">产品分类</th>
                    <th data-sortable="true">是否不锈钢</th>
                    <th data-sortable="true">执行标准</th>
                    <th data-sortable="true">用途</th>
                    <th data-sortable="true">特殊要求</th>
                    <th data-sortable="true">是否线材</th>
                    <th data-sortable="true">备注</th>
                    <th data-sortable="true">执行状态</th>
                    <th data-sortable="true">是否出口</th>
                    <th data-sortable="true">监控钢种</th>
                    <th data-sortable="true">工艺路线</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList2" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%#DataBinder.Eval (Container.DataItem,"计划订单号") %>    </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"原计划日期","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"计划日期","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"需求日期","{0:yyy-MM-dd}") %>   </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"销售区域") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"客户名称") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"物料编码") %>    </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"物料名称") %> </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"钢种") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"规格") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"自由项1") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"自由项2") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"包装要求") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"计划需求量") %>
                                <td><%#DataBinder.Eval (Container.DataItem,"完工数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"分配量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"库存数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"出库数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"钢坯现存量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"线材库存量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"计划下达量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"合格数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"待检数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"改判数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"协议品数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"头尾材数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"不合格品数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"合格品入库数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"改判入库数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"协议品入库数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"头尾材入库数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"不合格品入库数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"合格品出库数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"改判出库数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"协议品出库数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"头尾材出库数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"不合格品出库数量") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"销售出库最小时间") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"销售出库最大时间") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"生产最小时间") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"生产最大时间") %></td>

                                <td><%#DataBinder.Eval (Container.DataItem,"运输方式") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"修磨要求") %></td>

                                <td><%#DataBinder.Eval (Container.DataItem,"到站") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"产品类型") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"产品分类") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"是否不锈钢") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"执行标准") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"用途") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"特殊要求") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"是否线材") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"备注") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"执行状态") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"是否出口") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"监控钢种") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"工艺路线") %>  </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>

        </table>

    </form>

</body>
</html>
