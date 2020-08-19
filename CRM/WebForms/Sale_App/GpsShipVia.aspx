<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GpsShipVia.aspx.cs" Inherits="CRM.Sale_App.GpsShipVia" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>GPS设置</title>
    <uc1:common2 runat="server" ID="common2" />
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <ul id="myTab" class="nav nav-tabs">
            <li class="active"><a href="#home" data-toggle="tab">发运方式GPS</a> </li>
            <li><a href="#tab2" data-toggle="tab">客户GPS</a></li>
            <li><a href="#tab3" data-toggle="tab">区域</a></li>
            <li><a href="#tab4" data-toggle="tab">钢种GPS</a></li>

        </ul>
        <div class="tab-content">
            <div class="tab-pane fade    in active" id="home">
                <div class="dv_search" style="margin-top: 10px;">
                    <ul>
                        <li>
                            <asp:Button ID="btnOk" runat="server" Text="发运方式GPS控制" class="btn btn-primary btn-xs" OnClick="btnOk_Click" />
                        </li>
                        <li>
                            <asp:Button ID="btnNo" runat="server" Text="是否下发审核" class="btn btn-primary btn-xs" OnClick="btnNo_Click" />
                        </li>
                    </ul>
                </div>
                <table class="table table-bordered table-hover  table-condensed" id="data_table">
                    <thead>
                        <tr>
                            <th style="width: 30px; text-align: center">
                                <input id="chxAll" type="checkbox" class="qx1" /></th>

                            <th>发运方式</th>
                            <th>是否GPS</th>
                            <th>是否下发审核</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td style="text-align: center">
                                        <input id="chkSelect" class="che1" runat="server" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' />
                                    </td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"C_DETAILNAME") %></td>
                                    <td> <asp:Literal ID="ltlfygps" Text='<%#DataBinder.Eval (Container.DataItem,"N_ISGPS").ToString ()=="0"?"N":"Y" %>' runat="server"></asp:Literal></td>
                                       <td>
                                         <asp:Literal ID="ltlnextcheck" Text='<%#DataBinder.Eval (Container.DataItem,"C_EXTEND2")%>' runat="server"></asp:Literal>
                                    </td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                </table>
            </div>
            <div class="tab-pane fade" id="tab2">

                 <div class="dv_search" style="margin-top: 10px;">
                            <ul>
                                <li>
                                    <input type="text" placeholder="客户编码" runat="server" id="txtCustCode" /></li>
                                <li>
                                    <input type="text" placeholder="客户名称" runat="server" id="txtCustName" /></li>
                                <li>
                                    <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn btn-primary btn-xs btn_w60" OnClick="btnSearch_Click" />
                                </li>
                                <li>
                                    <asp:Button ID="btnOk2" runat="server" Text="是" class="btn btn-primary btn-xs" OnClick="btnOk2_Click" />
                                </li>
                                <li>
                                    <asp:Button ID="btnNo2" runat="server" Text="否" class="btn btn-primary btn-xs" OnClick="btnNo2_Click" /></li>
                            </ul>
                        </div>
                <table class="table table-bordered table-hover  table-condensed" data-toggle="table" data-height="500" style="white-space: nowrap;">
                    <thead>
                        <tr>
                            <th>
                                <input id="chxAll2" type="checkbox" class="qx2" /></th>
                            <th data-sortable="true">客户编码</th>
                            <th data-sortable="true">客户名称</th>
                            <th data-sortable="true">是否GPS</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptCust" runat="server">
                            <ItemTemplate>


                                <tr>
                                    <td>
                                        <input id="chkSelect2" class="che2" runat="server" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' /></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"C_NO") %></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"C_NAME") %></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"N_ISGPS").ToString ()=="0"?"否":"是" %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>


            </div>
            <div class="tab-pane fade " id="tab3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

               
                <div class="dv_search" style="margin-top: 10px;">
                            <ul>
                                <li>
                                    <asp:Button ID="btnOk4" runat="server" Text="区域GPS控制" class="btn btn-primary btn-xs" OnClick="btnOk4_Click" />
                                </li>
                                <li>
                                    <asp:Button ID="btnNo4" runat="server" Text="按客户控制发运" class="btn btn-primary btn-xs" OnClick="btnNo4_Click" />
                                </li>
                            </ul>
                        </div>
                <table class="table table-bordered table-hover  table-condensed" data-toggle="table" data-height="500" style="white-space: nowrap;">
                    <thead>
                        <tr>
                            <th style="width: 30px; text-align: center">
                                <input type="checkbox" class="qx4" /></th>

                            <th data-sortable="true">区域</th>
                            <th data-sortable="true">是否GPS</th>
                            <th data-sortable="true">是否按客户发货</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptArea" runat="server">
                            <ItemTemplate>
                                <tr >
                                    <td style="text-align: center">
                                        <input id="chkSelect4" class="che4" runat="server" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' />
                                    </td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"C_DETAILNAME") %></td>
                                    <td>
                                        <asp:Literal ID="ltlgps" Text='<%#DataBinder.Eval (Container.DataItem,"N_ISGPS").ToString ()=="0"?"N":"Y" %>' runat="server"></asp:Literal> </td>
                                    <td>
                                         <asp:Literal ID="ltlcust" Text='<%#DataBinder.Eval (Container.DataItem,"C_EXTEND2")%>' runat="server"></asp:Literal>
                                    </td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                </table>
                     </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="tab-pane fade " id="tab4">
                <div class="dv_search" style="margin-top: 10px;">
                            <ul>

                                <li>
                                    <input type="text" placeholder="钢种" runat="server" id="txtGRD" /></li>
                                <li>
                                    <asp:Button ID="btnSearch2" runat="server" Text="查询" CssClass="btn btn-primary btn-xs btn_w60" OnClick="btnSearch2_Click" /></li>
                                <li>
                                    <asp:Button ID="btnOk3" runat="server" Text="是" class="btn btn-primary btn-xs" OnClick="btnOk3_Click" />
                                </li>
                                <li>
                                    <asp:Button ID="btnNo3" runat="server" Text="否" class="btn btn-primary btn-xs" OnClick="btnNo3_Click" /></li>
                            </ul>
                        </div>
                <table class="table table-bordered table-hover  table-condensed" data-toggle="table" data-height="500" style="white-space: nowrap;">
                    <thead>
                        <tr>
                            <th>
                                <input id="chxAll3" type="checkbox" class="qx3" /></th>
                            <th data-sortable="true">钢种</th>
                            <th data-sortable="true">是否GPS</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptMat" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <input id="chkSelect3" class="che3" runat="server" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>' /></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"N_ISGPS").ToString ()=="0"?"否":"是" %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                </table>

            </div>

        </div>
        <script type="text/javascript">

            //全选
            selectAll("input.qx1", "input.che1");
            selectAll("input.qx2", "input.che2");
            selectAll("input.qx3", "input.che3");
            selectAll("input.qx4", "input.che4");
        </script>

    </form>
</body>
</html>
