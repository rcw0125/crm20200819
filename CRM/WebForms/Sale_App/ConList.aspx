<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConList.aspx.cs" Inherits="CRM.Sale_App.ConList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <title>销售合同</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Assets/css/common.css" rel="stylesheet" />
    <link href="../../Assets/css/bootstrap-datetimepicker.css" rel="stylesheet" />
    <link href="css/zeroModal.css" rel="stylesheet" />
    <script src="../../Assets/js/My97DatePicker/WdatePicker.js"></script>
    <script src="../../Assets/js/jquery-2.0.3.min.js"></script>
    <script src="../../Assets/js/bootstrap.min.js"></script>
    <script src="../../Assets/js/common.js"></script>
    <script src="../../Assets/js/bootstrap-datetimepicker.min.js"></script>
    <script src="../../Assets/js/bootstrap-datetimepicker.zh-CN.js"></script>
    <script src="js/zeroModal.js"></script>
    <script src="js/zeroModal.min.js"></script>
    <script src="../../Assets/js/_zero.js"></script>
    <script src="../JsDate.js"></script>
    <script src="js/jsconlist.js"></script>
</head>
<body>
    <form runat="server">
        <table class="table table-bordered table-condensed">

            <tr>

                <td>
                    <input id="txtCon" runat="server" type="text" placeholder="合同号" style="width: 100%" /></td>

                <td>
                    <input id="txtConName" runat="server" type="text" placeholder="合同名称" style="width: 100%" /></td>
                <td>
                    <input id="txtcustcode" runat="server" type="text" placeholder="客户编码" style="width: 100%" />
                </td>
                <td>
                    <input id="txtcustname" runat="server" type="text" placeholder="客户名称" style="width: 100%" /></td>
                <td class="right" style="width:60px;">区域</td>
                <td>
                    <asp:DropDownList ID="dropType" runat="server"></asp:DropDownList></td>
                <td class="right" style="width:60px;">状态</td>
                <td>
                    <asp:DropDownList ID="dropState" runat="server">
                        <asp:ListItem Value="全部">全部</asp:ListItem>
                        <asp:ListItem Value="0">待审</asp:ListItem>
                        <asp:ListItem Value="1">审核中</asp:ListItem>
                        <asp:ListItem Value="4">审核通过</asp:ListItem>
                        <asp:ListItem Value="2">生效</asp:ListItem>
                        <asp:ListItem Value="5">冻结</asp:ListItem>
                        <asp:ListItem Value="6">终止</asp:ListItem>
                    </asp:DropDownList></td>

                <td class="right" style="width:60px;">日期</td>
                <td style="width: 115px;">
                    <input id="Start" type="text" style="width: 110px;" readonly="readonly" class="form-control Wdate" runat="server" />

                </td>
                <td style="width: 115px;">
                    <input id="End" runat="server" type="text" style="width: 110px;" readonly="readonly" class="form-control Wdate" /></td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btnSearch_Click" />
                </td>

            </tr>
        </table>

        <table class="table table-bordered table-hover table-condensed">
            <thead>
                <tr>
                    <th>合同号</th>
                    <th>合同名称</th>
                     <th>合同数量</th>
                    <th>客户</th>
                    <th>合同状态</th>
                    <th>合同签署日期</th>
                    <th>计划生效日期</th>
                    <th>计划失效日期</th>
                    <th>区域</th>                   
                    <th>发运方式</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr title="双击查看">
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NAME")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_WGT")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUSTNAME")%></td>
                            <td><%#NF.Framework.StringFormat.GetOrderState(DataBinder.Eval (Container.DataItem,"N_STATUS"))%>
                                <input id="hidstatus" class="status" type="hidden" value='<%#DataBinder.Eval (Container.DataItem,"N_STATUS")%>' /><input id="hidycon" class="oldcon" type="hidden" value='<%#DataBinder.Eval (Container.DataItem,"C_CON_NO_OLD")%>' /></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONSING_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONEFFE_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONINVALID_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_AREA")%></td>
                            
                            <td><%#GetDic(DataBinder.Eval (Container.DataItem,"C_TRANSMODEID"))%></td>

                        </tr>
                    </ItemTemplate>

                </asp:Repeater>


            </tbody>
     
        </table>
        <div>

            <webdiyer:AspNetPager ID="Pager1" runat="server" CssClass="paginator" CurrentPageButtonClass="paginator"
                CurrentPageButtonPosition="End" CustomInfoHTML="总记录：%RecordCount% &nbsp;页码：%CurrentPageIndex% / %pageCount% &nbsp; 每页：%PageSize%"
                CustomInfoSectionWidth="350px" CustomInfoTextAlign="Center" FirstPageText="首页"
                HorizontalAlign="Right" LastPageText="尾页"
                meta:resourcekey="AspNetPager" NextPageText="下一页"
                NumericButtonCount="5" PagingButtonClass=""
                PrevPageText="前一页" showinputbox="Never" ShowNavigationToolTip="True"
                Width="100%" PageSize="15" CustomInfoClass="paginator" OnPageChanged="Pager1_PageChanged" ShowCustomInfoSection="Right" PageIndexBoxType="DropDownList" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                <span style="color: #000000"></span><strong></strong><span style="color: #000000">&nbsp;&lt;
                            &gt;</span>
            </webdiyer:AspNetPager>
        </div>
    </form>
</body>
</html>
