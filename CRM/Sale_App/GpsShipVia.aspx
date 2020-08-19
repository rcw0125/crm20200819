<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GpsShipVia.aspx.cs" Inherits="CRM.Sale_App.GpsShipVia" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html lang="zh-CN">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />


    <title>GPS设置</title>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <ul id="myTab" class="nav nav-tabs">
            <li class="active"><a href="#home" data-toggle="tab">发运方式</a> </li>
            <li><a href="#tab2" data-toggle="tab">客户</a></li>
            <li><a href="#tab3" data-toggle="tab">区域</a></li>
            <li><a href="#tab4" data-toggle="tab">钢种</a></li>

        </ul>
        <div class="tab-content">
            <div class="tab-pane fade   in active" id="home">
                <div class="dv_search" style="margin-top: 10px;">
                    <ul>
                        <li>
                            <asp:Button ID="btnOk" runat="server" Text="是" class="btn btn-primary btn-xs" OnClick="btnOk_Click" />
                        </li>
                        <li>
                            <asp:Button ID="btnNo" runat="server" Text="否" class="btn btn-primary btn-xs" OnClick="btnNo_Click" />
                        </li>
                    </ul>
                </div>
                <table class="table table-bordered table-hover" id="data_table">
                    <thead>
                        <tr>
                            <th style="width: 30px; text-align: center">
                                <input id="chxAll" type="checkbox" class="qx1" /></th>

                            <th>发运方式</th>
                            <th>是否GPS</th>
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
                                    <td><%#DataBinder.Eval (Container.DataItem,"N_ISGPS").ToString ()=="0"?"否":"是" %></td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                </table>
            </div>
            <div class="tab-pane fade" id="tab2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>


                        <div class="dv_search" style="margin-top: 10px;">
                            <ul>
                                <li>
                                    <input type="text" placeholder="客户编码" class="input-xlarge" runat="server" id="txtCustCode" /></li>
                                <li>
                                    <input type="text" placeholder="客户名称" class="input-xlarge" runat="server" id="txtCustName" /></li>
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
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>
                                        <input id="chxAll2" type="checkbox" class="qx2" /></th>
                                    <th>客户编码</th>
                                    <th>客户名称</th>
                                    <th>是否GPS</th>
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
                        <div class="div_page">
                            <webdiyer:AspNetPager ID="Pager1" runat="server" CssClass="paginator" CurrentPageButtonClass="paginator"
                                CurrentPageButtonPosition="End" CustomInfoHTML="总记录：%RecordCount% &nbsp;页码：%CurrentPageIndex% / %pageCount% &nbsp; 每页：%PageSize%"
                                CustomInfoSectionWidth="350px" CustomInfoTextAlign="Center" FirstPageText="首页"
                                HorizontalAlign="Right" LastPageText="尾页"
                                meta:resourcekey="AspNetPager" NextPageText="下一页"
                                NumericButtonCount="5" PagingButtonClass=""
                                PrevPageText="前一页" showinputbox="Never" ShowNavigationToolTip="True" ShowPageIndexBox="Never"
                                Width="100%" PageSize="12" CustomInfoClass="paginator" OnPageChanged="Pager1_PageChanged">
                                <span style="color: #000000"></span><strong></strong><span style="color: #000000">&nbsp;&lt;
                            &gt;</span>
                            </webdiyer:AspNetPager>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="tab-pane fade" id="tab3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="panel panel-default" style="margin-top:10px;">
                            <div class="panel-heading">
                                <asp:Button ID="btnSave" runat="server" Text="保 存" CssClass="btn btn-primary btn-xs btn_w60" OnClick="btnSave_Click" />
                            </div>
                            <asp:TreeView ID="trv_menu" runat="server" Font-Bold="False" Font-Size="12px" Width="100%" ShowLines="True" AutoGenerateDataBindings="False">
                                <ParentNodeStyle Font-Bold="False" />
                                <HoverNodeStyle Font-Underline="True" ForeColor="Purple" />
                                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                <NodeStyle Font-Names="Tahoma" Font-Size="9pt" ForeColor="DarkBlue" HorizontalPadding="5px"
                                    NodeSpacing="0px" VerticalPadding="0px" />
                            </asp:TreeView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="tab-pane fade " id="tab4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="dv_search" style="margin-top: 10px;">
                            <ul>
                                <li> <input type="text" placeholder="物料编码" class="input-xlarge" runat="server" id="txtMatCode" /></li>
                                <li> <input type="text" placeholder="钢种" class="input-xlarge" runat="server" id="txtGRD" /></li>
                                <li><input type="text" placeholder="规格" class="input-xlarge" runat="server" id="txtSpec" /></li>
                                <li> <asp:Button ID="btnSearch2" runat="server" Text="查询" CssClass="btn btn-primary btn-xs btn_w60" OnClick="btnSearch2_Click" /></li>
                                 <li>
                                    <asp:Button ID="btnOk3" runat="server" Text="是" class="btn btn-primary btn-xs" OnClick="btnOk3_Click"  />
                                </li>
                                <li>
                                    <asp:Button ID="btnNo3" runat="server" Text="否" class="btn btn-primary btn-xs" OnClick="btnNo3_Click" /></li>
                            </ul>
                        </div>
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th><input id="chxAll3" type="checkbox" class="qx3" /></th>
                                    <th>物料编码</th>
                                    <th>钢种</th>
                                    <th>规格</th>
                                    <th>是否GPS</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptMat" runat="server">
                                    <ItemTemplate>
                                         <tr>
                                    <td> <input id="chkSelect3" class="che3" runat="server" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' /></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"N_ISGPS").ToString ()=="0"?"否":"是" %></td>
                                </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                               
                            </tbody>
                        </table>
                          <div class="div_page">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="paginator" CurrentPageButtonClass="paginator"
                                CurrentPageButtonPosition="End" CustomInfoHTML="总记录：%RecordCount% &nbsp;页码：%CurrentPageIndex% / %pageCount% &nbsp; 每页：%PageSize%"
                                CustomInfoSectionWidth="350px" CustomInfoTextAlign="Center" FirstPageText="首页"
                                HorizontalAlign="Right" LastPageText="尾页"
                                meta:resourcekey="AspNetPager" NextPageText="下一页"
                                NumericButtonCount="5" PagingButtonClass=""
                                PrevPageText="前一页" showinputbox="Never" ShowNavigationToolTip="True" ShowPageIndexBox="Never"
                                Width="100%" PageSize="12" CustomInfoClass="paginator" OnPageChanged="AspNetPager1_PageChanged">
                                <span style="color: #000000"></span><strong></strong><span style="color: #000000">&nbsp;&lt;
                            &gt;</span>
                            </webdiyer:AspNetPager>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>
        <script src="../Assets/js/jquery-2.0.3.min.js"></script>

        <script src="../Assets/js/bootstrap.min.js"></script>
        <script src="../Assets/js/common.js"></script>
        <script type="text/javascript">

            //全选
            selectAll("input.qx1", "input.che1");
            selectAll("input.qx2", "input.che2");
            selectAll("input.qx3", "input.che3");
        </script>

    </form>
</body>
</html>
