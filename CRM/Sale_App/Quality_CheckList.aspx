<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quality_CheckList.aspx.cs" Inherits="CRM.Sale_App.Quality_CheckList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/jquery-2.0.3.min.js"></script>
    <script src="../Assets/js/bootstrap.min.js"></script>
    <title>质量异议预警审批</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dv_btn" style="margin-top: 5px;">
            <ul>
                <li>
                    <asp:Button ID="btnhref" runat="server" Text="返回" CssClass="btn btn-warning btn-xs" OnClick="btnhref_Click" /></li>
            </ul>
        </div>
        <ul id="myTab" class="nav nav-tabs">
            <li class="active"><a href="#home" data-toggle="tab">质量异议</a> </li>
            <li><a href="#check" data-toggle="tab">审批</a></li>
        </ul>
        <div class="tab-content">
            <div class="tab-pane fade   in active" id="home">
                <table class="table table-bordered" style="margin-top: 10px;">
                    <tr>
                        <td>区域</td>
                        <td>
                            <asp:TextBox ID="txtArea" runat="server" Enabled="False" Width="99%"></asp:TextBox>
                        </td>
                        <td>客户名称</td>
                        <td>
                            <asp:TextBox ID="txtCustName" runat="server" Enabled="False" Width="99%"></asp:TextBox>
                        </td>
                        <td>联系人</td>
                        <td>
                            <asp:TextBox ID="txtUser" runat="server" Enabled="False" Width="99%"></asp:TextBox>
                        </td>
                        <td>联系电话</td>
                        <td>
                            <asp:TextBox ID="txtTel" runat="server" Enabled="False" Width="99%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>钢种分类</td>
                        <td>
                            <asp:TextBox ID="txtSTL_GRD" runat="server" Enabled="False" Width="99%"></asp:TextBox>
                        </td>
                        <td>产品用途</td>
                        <td>
                            <asp:TextBox ID="txtUse" runat="server" Enabled="False" Width="99%"></asp:TextBox>
                        </td>
                        <td>发货时间</td>
                        <td>
                            <asp:TextBox ID="txtFHTime" runat="server" Enabled="False" Width="99%"></asp:TextBox>
                        </td>
                        <td>到货时间</td>
                        <td>
                            <asp:TextBox ID="txtDHTime" runat="server" Enabled="False" Width="99%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>投诉异议内容</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtTouSu" runat="server" Enabled="False" Height="50px" TextMode="MultiLine" Width="99%"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>用户工艺流程</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtGongYi" runat="server" Enabled="False" Height="50px" TextMode="MultiLine" Width="99%"></asp:TextBox>
                        </td>

                    </tr>
                </table>
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>钢种</th>
                            <th>规格(mm)</th>
                            <th>批号</th>
                            <th>发货数量(吨)</th>
                            <th>异议数量(吨)</th>
                            <th>执行标准</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptSTL_GRD" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC")%></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO")%></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"N_SHIP_WGT")%></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"N_OBJEC_WGT")%></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"C_STD_CODE")%></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                    <tfoot>
                        <tr class="info">
                            <td>合计</td>
                            <td></td>
                            <td></td>
                            <td style="color: red">
                                <asp:Literal ID="ltlShipSum" runat="server"></asp:Literal></td>
                            <td style="color: red">
                                <asp:Literal ID="ltlObjecSum" runat="server"></asp:Literal></td>
                            <td></td>
                        </tr>
                    </tfoot>
                </table>
                <table class="table table-bordered">
                    <tr>
                        <td style="width: 100px;">现场调查情况</td>
                        <td>
                            <asp:TextBox ID="txtXinaChang" runat="server" Enabled="False" Height="50px" TextMode="MultiLine" Width="99%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>取样情况</td>
                        <td>

                            <span>母材&nbsp;
                                <asp:TextBox ID="txtMuCai" runat="server" Enabled="False" Width="50px"></asp:TextBox>&nbsp;支</span>
                            <span>&nbsp;&nbsp;&nbsp;&nbsp; 问题样&nbsp;
                                <asp:TextBox ID="txtWenTi" runat="server" Enabled="False" Width="50px"></asp:TextBox>&nbsp; 支</span>
                            <span>&nbsp;&nbsp; 中间样&nbsp;
                                <asp:TextBox ID="txtZhongJian" runat="server" Enabled="False" Width="50px"></asp:TextBox>&nbsp; 支</span>
                            <span>其他&nbsp;
                                <asp:TextBox ID="txtQiTa" runat="server" Enabled="False" Width="50px"></asp:TextBox>&nbsp; 支</span>

                        </td>
                    </tr>
                    <tr>
                        <td>现场调查人员</td>
                        <td>本部门 
                            <asp:TextBox ID="txtDept" runat="server" Enabled="False" Width="150px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp; 质控部 
                            <asp:TextBox ID="txtZKDept" runat="server" Enabled="False" Width="150px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp; 技术心 
                            <asp:TextBox ID="txtJSDept" runat="server" Enabled="False" Width="150px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 其他 
                            <asp:TextBox ID="txtQTDept" runat="server" Enabled="False" Width="150px"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td>备注</td>
                        <td>

                            <asp:TextBox ID="txtRemark" runat="server" Enabled="False" Height="50px" TextMode="MultiLine" Width="99%"></asp:TextBox>

                        </td>
                    </tr>
                </table>
            </div>
            <div class="tab-pane fade" id="check">
                <div id="div_check" runat="server" style="margin-top: 10px;">
                    <table class="table table-bordered">
                        <tr>
                            <td style="text-align: center; width: 100px;">说明</td>
                            <td>
                                <asp:Literal ID="ltlContent" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="text-align: center; width: 100px;">附件</td>
                            <td>
                                <asp:Repeater ID="rptDown" runat="server" OnItemCommand="rptDown_ItemCommand">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnFile" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_TITLE")%>' CommandArgument='<%#DataBinder.Eval (Container.DataItem,"C_PATH")%>' CommandName="down"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </td>
                        </tr>
                        <tr>

                            <td style="text-align: center">批语</td>
                            <td>
                                <div>
                                    <asp:TextBox ID="txtContent" runat="server" Height="50px" TextMode="MultiLine" Width="99%"></asp:TextBox>
                                </div>
                                <div style="margin-top: 5px;">
                                    <asp:Button ID="btnOk" runat="server" CssClass="btn btn-primary btn-xs" Text="批准" OnClick="btnOk_Click" />&nbsp;&nbsp;
                                    <asp:Button ID="btnNo" runat="server" CssClass="btn btn-primary btn-xs" Text="退回" OnClick="btnNo_Click" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>

                <table class="table table-bordered" style="margin-top: 10px;">
                    <tbody>
                        <asp:Repeater ID="rptCheckList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 100px; height: 50px; text-align: center; background: #eee; vertical-align: middle">
                                        <%#DataBinder.Eval (Container.DataItem,"c_step_name")%>
                                    </td>
                                    <td>
                                        <%#DataBinder.Eval (Container.DataItem,"c_stepnote")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>

        <asp:Literal ID="ltlStepID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlFlowID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlFileID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlTaskID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlUserID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlUserName" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlFlag" runat="server" Visible="false"></asp:Literal>
    </form>
</body>
</html>
