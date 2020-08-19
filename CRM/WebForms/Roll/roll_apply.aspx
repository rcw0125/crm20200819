<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roll_apply.aspx.cs" Inherits="CRM.WebForms.Roll.roll_apply" %>

<%@ Register Src="~/WebForms/Roll/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>资源申请</title>
    <uc1:rollControl runat="server" ID="rollControl" />
    <script type="text/javascript">
        $(function () {
            selectAll("input.qx1", "input.che1");
        });

        function openweb() {

            var id = $("#hid").val();
            var url = "rollList.aspx?ID=" + id;
            _iframe(url, '1024', '450', '线材资源调配');
        }

        function openzt(url) {
            _iframe(url, '900', '450', '可调配量');
        }

        function getflow() {

            var url = '../Sale_App/FlowStep_View.aspx?taskID=' + $("#hid").val();
            _iframe(url, '500', '400', '审批记录');
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="dv_btn">
            <ul>
                
                <li>
                    <input id="btnflow" runat="server" type="button" value="审批记录" class="btn btn-primary btn-xs" onclick="getflow();" />
                </li>
                <li>
                    <input id="btnXC" runat="server" type="button" value="线材" class="btn btn-primary btn-xs" onclick="openweb();" />
                </li>
                <li>
                    <asp:Button ID="btnDelAll" CssClass="btn btn-danger btn-xs" runat="server" Text="删除申请" OnClientClick="return confirm('确定删除吗？')" OnClick="btnDelAll_Click" /></li>
                <li>
                    <asp:Button ID="btnDel" CssClass="btn btn-danger btn-xs" runat="server" Text="删除行" OnClick="btnDel_Click" />
                </li>
                <li>
                    <asp:Button ID="btnCheck" runat="server" Text="送审" CssClass="btn btn-primary btn-xs" OnClick="btnCheck_Click" /></li>
                <li>
                    <asp:Button ID="Button2" runat="server" Text="可调配量" CssClass="btn btn btn-success btn-xs" OnClick="Button2_Click" /></li>
                <li>

                    <a href="myRoll.aspx" class="btn btn-warning btn-xs">返回列表</a>
                </li>
            </ul>
        </div>

        <table class="table table-bordered table-condensed">
            <tr>

                <td>申请人</td>
                <td>
                    <asp:TextBox ID="txtEmpName" runat="server" Width="100%"></asp:TextBox></td>
                <td>申请时间</td>
                <td>
                    <asp:Literal ID="ltldate" runat="server"></asp:Literal></td>

                <td>审批状态</td>
                <td>
                    <asp:Literal ID="ltlcheckstate" runat="server"></asp:Literal></td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="table table-bordered table-condensed" data-toggle="table" data-height="250" id="table" style="white-space: nowrap;">
                    <thead>
                        <tr>
                            <th>合计</th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th>调配量</th>
                            <th>
                                <asp:Literal ID="ltlsumwgt" runat="server"></asp:Literal></th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                        </tr>
                        <tr>
                            <th>
                                <input id="cbxAll" type="checkbox" class="qx1" />全选/序号</th>
                            <th data-sortable="true">物料编码</th>
                            <th data-sortable="true">资源区域</th>
                            <th data-sortable="true">客户信息</th>
                            <th data-sortable="true">合同号</th>
                            <th data-sortable="true">批次号</th>
                            <th data-sortable="true">钢种</th>
                            <th data-sortable="true">规格</th>
                            <th data-sortable="true">重量</th>
                            <th data-sortable="true">质量等级</th>
                            <th data-sortable="true">包装</th>
                            <th data-sortable="true">需求区域</th>
                            <th data-sortable="true">需求客户</th>
                            <th data-sortable="true">需求合同</th>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <input id="cbxselect" runat="server" class="che1" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' />
                                        <%#Container.ItemIndex+1 %></td>
                                    <td>
                                        <asp:Literal ID="ltlmatCode" Text='<%#DataBinder.Eval (Container.DataItem,"C_VFREE2") %>' runat="server"></asp:Literal>
                                        <asp:Literal ID="ltlstdCode" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_REMARK") %>'></asp:Literal>

                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlarea" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_ZYAREA") %>'></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlzycust" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_ZYCUST") %>'></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlzycon" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_ZYCON") %>'></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlbatch" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_VFREE1") %>'></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlstlgrd" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>'></asp:Literal></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                                    <td>
                                        <asp:Literal ID="ltlwgt" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_WGT") %>'></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltllev" Text='<%#DataBinder.Eval (Container.DataItem,"C_VFREE5") %>' runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlpack" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_VFREE4") %>'></asp:Literal></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"C_NEEDAREA") %></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"C_NEEDCUST") %></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"C_QUA") %></td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                </table>
                <asp:ImageButton ID="imgbtnJz" runat="server" OnClick="imgbtnJz_Click" ImageUrl="~/Assets/images/btntm.gif" Height="0px" Width="0px" />
            </ContentTemplate>
        </asp:UpdatePanel>

        <input id="hid" runat="server" type="hidden" />

    </form>
</body>
</html>
