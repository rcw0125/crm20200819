<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCon.aspx.cs" Inherits="CRM.Cust_App.MyCon" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <title>我的合同</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <uc1:common runat="server" ID="common" />
    <script src="../JsDate.js"></script>
    <script src="js/jsCon.js"></script>
</head>
<body>
    <form runat="server">

        <table class="table table-bordered table-condensed">

            <tr>

                <td>
                    <input id="txtCon" runat="server" type="text" placeholder="合同号" style="width: 100%" /></td>

                <td>
                    <input id="txtConName" runat="server" type="text" placeholder="合同名称" style="width: 100%" /></td>
                <td>类型</td>
                <td>
                    <asp:DropDownList ID="dropConType" runat="server" Width="100%"></asp:DropDownList></td>
                <td>签署日期</td>
                <td style="width: 125px;">
                    <input id="Start" type="text" style="width: 120px;" runat="server" readonly class="form-control Wdate" />
                </td>
                <td style="width: 125px;">
                    <input id="End" runat="server" type="text" style="width: 120px;" readonly class=" form-control Wdate" /></td>

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
                    <th>合同状态</th>
                    <th>合同签署日期</th>
                    <th>计划生效日期</th>
                    <th>计划失效日期</th>
                    <th>货币</th>
                    <th>合同类型</th>
                    <th>发运方式</th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr title="双击查看">

                            <td><%#DataBinder.Eval (Container.DataItem,"OLDCONNO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NAME")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_WGT")%> </td>
                            <td><%#NF.Framework.StringFormat.GetOrderState(DataBinder.Eval (Container.DataItem,"N_STATUS"))%>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONSING_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONEFFE_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONINVALID_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#GetDic(DataBinder.Eval (Container.DataItem,"C_CURRENCYTYPEID"))%></td>
                            <td><%#GetDic(DataBinder.Eval (Container.DataItem,"C_CONTYPEID"))%></td>
                            <td><%#GetDic(DataBinder.Eval (Container.DataItem,"C_TRANSMODEID"))%>

                                <input id="hlen" class="len" value='<%#DataBinder.Eval (Container.DataItem,"LEN")%>' type="hidden" />
                            </td>


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
                Width="100%" PageSize="18" CustomInfoClass="paginator" OnPageChanged="Pager1_PageChanged">
                <span style="color: #000000"></span><strong></strong><span style="color: #000000">&nbsp;&lt;
                            &gt;</span>
            </webdiyer:AspNetPager>
        </div>

        <asp:Literal ID="ltlUserID" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
