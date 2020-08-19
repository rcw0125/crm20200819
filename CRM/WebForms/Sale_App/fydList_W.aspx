<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fydList_W.aspx.cs" Inherits="CRM.WebForms.Sale_App.fydList_W" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>发运单-委外</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <uc1:common2 runat="server" ID="common2" />
    <script src="../JsDate.js"></script>
    <script src="js/jsfydList_W.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox ID="txtsendcode" placeholder="发运单号" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtch" placeholder="车牌号" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtcust" placeholder="客户" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtzdr" placeholder="制单人" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td style="width: 80px">发运方式</td>
                <td>
                    <asp:DropDownList ID="dropfyfs" runat="server" Width="100%"></asp:DropDownList></td>
                <td style="width: 100px">是否线材销售</td>
                <td>
                    <asp:DropDownList ID="dropsfxc" runat="server" Width="50px">
                        <asp:ListItem Value="0001NC10000000007H28">是</asp:ListItem>
                        <asp:ListItem Value="0001NC10000000007H29">否</asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td style="width: 50px;">日期</td>
                <td style="width: 120px;">
                    <input id="txtStart" type="text" style="width: 120px;" readonly="readonly" class="form-control Wdate" runat="server" />
                </td>
                <td style="width: 120px;">
                    <input id="txtEnd" runat="server" type="text" style="width: 120px;" readonly="readonly" class="form-control Wdate" /></td>

                <td style="width: 100px">
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover">
            <thead>
                <tr>
                    <th>发运单据号</th>
                    <th>发运日期</th>
                    <th>发运方式</th>
                    <th>承运商</th>
                    <th>是否线材销售</th>
                    <th>车牌号</th>
                    <th>到站</th>
                    <th>最后修改人</th>
                    <th>最后修改时间</th>
                    <th>状态</th>
                    <th>制单日期</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr title="双击查看">
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ID")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_DISP_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SHIPVIA")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_COMCAR")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_IS_WIRESALE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_LIC_PLA_NO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ATSTATION")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EMP_NAME")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_MOD_DT")%></td>
                            <td><%#GetStatus(DataBinder.Eval (Container.DataItem,"C_STATUS"))%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CREATE_DT","{0:yyy-MM-dd}")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
        <div class="div_page">

            <webdiyer:AspNetPager ID="Pager1" runat="server" CssClass="paginator" CurrentPageButtonClass="paginator"
                CurrentPageButtonPosition="End" CustomInfoHTML="总记录：%RecordCount% &nbsp;页码：%CurrentPageIndex% / %pageCount% &nbsp; 每页：%PageSize%"
                CustomInfoSectionWidth="350px" CustomInfoTextAlign="Center" FirstPageText="首页"
                HorizontalAlign="Right" LastPageText="尾页"
                meta:resourcekey="AspNetPager" NextPageText="下一页"
                NumericButtonCount="5" PagingButtonClass=""
                PrevPageText="前一页" showinputbox="Never" ShowNavigationToolTip="True" ShowPageIndexBox="Never"
                Width="100%" PageSize="15" CustomInfoClass="paginator" OnPageChanged="Pager1_PageChanged">
                <span style="color: #000000"></span><strong></strong><span style="color: #000000">&nbsp;&lt;
                            &gt;</span>
            </webdiyer:AspNetPager>
        </div>
    </form>
</body>
</html>
