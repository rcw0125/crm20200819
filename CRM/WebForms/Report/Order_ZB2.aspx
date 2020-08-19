<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order_ZB2.aspx.cs" Inherits="CRM.WebForms.Report.Order_ZB2" %>

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
                <td style="width: 80px">月份</td>
                <td style="width: 100px;">
                    <input id="txtStart" runat="server" type="text" style="width: 100px;" class=" form-control Wdate" />

                </td>
               

                <td style="width: 100px">
                    <asp:Button ID="btnCX" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btnCX_Click" OnClientClick="_loading(1);" />

                </td>


                
                <td>
                    <asp:Button ID="btnZB" runat="server" Text="保存指标" CssClass="btn btn-primary btn-xs" OnClick="btnZB_Click" OnClientClick="_loading(1);" />

                    &nbsp;
                 
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
                   
                    
                </tr>
                <tr>
                    <th ><input id="cbxAll" type="checkbox" class="qx1" />区域</th>
                    <th data-sortable="true">监控钢种</th>
                    <th data-sortable="true">普通精品钢</th>
                    <th data-sortable="true">品种钢</th>
                    <th data-sortable="true">普碳钢</th>
                    <th data-sortable="true">合计</th>
                   
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr >
                            <!--月指标-->
                            <td>
                                <input id="cbxID" style="width: 15px;" class="che1" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' type="checkbox" />
                                 <asp:Literal ID="ltlC_TYPE" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"FLAG")%>'></asp:Literal>
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
                    format: 'yyyy-mm',
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
