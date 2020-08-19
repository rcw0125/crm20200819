<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roll_apply.aspx.cs" Inherits="CRM.WebForms.Report.roll_apply" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <uc1:common runat="server" ID="common" />
    <title>资源申请</title>
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed table-hover">
            <tr>
                <td style="width: 120px;">标题</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" Width="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>说明</td>
                <td>
                    <asp:TextBox ID="txtContent" runat="server" Height="50px" TextMode="MultiLine" Width="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>审批流</td>
                <td>
                    <asp:DropDownList ID="dropFlow" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>下一处理人</td>
                <td>
                    <asp:TextBox ID="txtC_NEXT_EMP_ID" runat="server" Width="250px" ReadOnly="True"></asp:TextBox>


                    <a href="javascript:void(0)" onclick="openWeb();"><span class="glyphicon glyphicon-search"></span></a>
                    <input id="hidEmpID" runat="server" type="hidden" />
                    <input id="hidSetpID" runat="server" type="hidden" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnok" runat="server" Text="提交申请" CssClass="btn btn-primary btn-xs" OnClick="btnok_Click" OnClientClick="return Check();" /><a href="roll_prodcut.aspx" class="btn btn-default btn-xs" style="margin-left: 10px;">返回</a></td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover">
            <thead>
                <tr>
                    <th>
                        <asp:Button ID="btnadd" runat="server" Text="增行" CssClass="btn btn-info btn-xs" OnClick="btnadd_Click" /></th>
                    <th>需求区域</th>
                    <th>需求客户</th>
                    <th>资源所属区域</th>
                    <th>资源所属客户</th>
                    <th>规格</th>
                    <th>钢种</th>
                    <th>需求吨数</th>
                    <th>件数</th>
                    <th>说明</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Button ID="btn" runat="server" Text="删除" CssClass="btn btn-info btn-xs" /></td>
                            <td>
                                <asp:TextBox ID="txtneedarea" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"NEEDAREA") %>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtneedcust" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"NEEDCUST") %>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtzyarea" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"ZYAREA") %>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtzycust" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"ZYCUST") %>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtspec" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"SPEC") %>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtstl_grd" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"STL_GRD") %>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtwgt" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"NEEDWGT") %>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtqua" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"QUA") %>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtremark" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"REMARK") %>'></asp:TextBox></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>

        </table>

        <script type="text/javascript">

            function openWeb() {
                var _w = 600;
                var _h = 500;
                var flowID = $("#dropFlow option:selected").val()
                var parm = { flowID: flowID };

                $.ajax({
                    type: "Post",
                    url: "Con_Check.aspx/GetStep",
                    data: JSON.stringify(parm),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //debugger;
                        $("#hidSetpID").val(data.d);
                        var url = 'Check_Emp.aspx?ID=' + $("#hidSetpID").val();
                        _iframe(url, '500', '400', '审批人');
                    },
                    error: function (err) {
                        alert(err);
                    }
                });

            }
            function Check() {
                var title = $.trim($("#txtTitle").val());
                if (title == '') {
                    alert("标题不能为空");
                    return false;
                }
                if ($.trim($("#txtC_NEXT_EMP_ID").val()) == '') {

                    alert("请选择下一处理人");
                    return false;
                }
                return true;
            }
            function SetEmp(arrEmpName, arrEmpID) {

                $("#txtC_NEXT_EMP_ID").val(arrEmpName);
                $("#hidEmpID").val(arrEmpID);
                close();
            }
        </script>
        <asp:Literal ID="ltlUserID" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlbatch" Visible="false" runat="server"></asp:Literal>

    </form>
</body>
</html>
