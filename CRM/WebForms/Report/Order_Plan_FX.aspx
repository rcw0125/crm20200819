<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order_Plan_FX.aspx.cs" Inherits="CRM.WebForms.Report.Order_Plan_FX" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>旬订单分析</title>
    <uc1:common runat="server" ID="common" />
</head>
<body>
    <form id="form1" runat="server">

        <table class="table table-bordered table-condensed" style="margin-top: 5px;">
            <tr>

                <td style="width: 100px;">
                   提报日期</td>
                <td style="width: 120px;">
                    <input id="txtStart" type="text" style="width: 100px;" readonly="readonly" class=" form-control Wdate" runat="server" />

                </td>
                
                <td style="width: 120px;">
                    <input id="txtEnd" runat="server" type="text" style="width: 100px;" readonly="readonly" class=" form-control Wdate" />
                </td>
               

                <td>
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" />
                </td>

            </tr>
        </table>
        <table class=" table table-bordered table-condensed">
            <tr>
                <td style="width:500px;">
                    <table class="table table-bordered table-hover table-condensed"  id="table1" data-toggle="table" data-height="300" style="white-space: nowrap; ">
                        <thead>
                             <tr class="info">
                                <th>合计</th>
                                <th></th>
                                <th></th>
                                <th></th>
                                <th>
                                    <asp:Literal ID="ltlStlGrdSum" runat="server"></asp:Literal></th>
                            </tr>
                            <tr>
                                <th data-sortable="true">钢种</th>
                                <th data-sortable="true">大类</th>
                                <th data-sortable="true">钢类</th>
                                <th data-sortable="true">监控</th>
                                <th data-sortable="true">汇总</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptStlGrd" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_PROD_KIND") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_PROD_NAME") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"SFJK") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"N_WGT") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                      
                    </table>
                </td>
                <td>

                     <table class="table table-bordered table-hover table-condensed" data-toggle="table" data-width="400" data-height="300" style="white-space: nowrap;">
                        <thead>
                              <tr class="info">
                                <th>合计</th>
                             
                                <th>
                                    <asp:Literal ID="ltlSpecSum" runat="server"></asp:Literal></th>
                            </tr>
                            <tr>
                                <th data-sortable="true">规格</th>
                            
                                <th data-sortable="true">汇总</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptSpec" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                                      
                                        <td><%#DataBinder.Eval (Container.DataItem,"N_WGT") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                     
                    </table>
                </td>
              
            </tr>
            <tr>
                <td colspan="2">
                    <table class="table table-bordered table-hover table-condensed"  data-toggle="table" data-height="300" style="white-space: nowrap; ">
                        <thead>
                             <tr class="info">
                                <th>合计</th>
                                <th><asp:Literal ID="ltlsumjk" runat="server"></asp:Literal></th>
                                <th><asp:Literal ID="ltlsumpz" runat="server"></asp:Literal></th>
                                <th><asp:Literal ID="ltlsumjp" runat="server"></asp:Literal></th>
                                <th><asp:Literal ID="ltlsum_jp_pz" runat="server"></asp:Literal></th>
                                <th></th>
                                    
                            </tr>
                            <tr>
                                <th data-sortable="true">区域</th>
                                <th data-sortable="true">监控</th>
                                <th data-sortable="true">品种钢</th>
                                <th data-sortable="true">普通精品钢</th>
                                <th data-sortable="true">汇总</th>
                                <th data-sortable="true">正常订单占比</th>
     
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptArea" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_AREA") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"N_WGT_JK") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"N_WGT_PZ") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"N_WGT_JP") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"SUM_JP_PZ") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"ZB") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                      
                    </table>
                   
                </td>
             
            </tr>
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


            });


            function openweb(index) {
                if (index == "1") {
                    _iframe('Order_Plan_View.html', '700', '400', '品种数据详情');
                }
                else {
                    _iframe('Order_Plan_View2.html', '700', '400', '销售区域数据详情');
                }
            }
        </script>

    </form>
</body>
</html>
