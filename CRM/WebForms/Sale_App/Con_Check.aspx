<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Con_Check.aspx.cs" Inherits="CRM.Sale_App.Con_Check" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>合同审批</title>
    <uc1:common2 runat="server" id="common2" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <tr>
                <td style="width: 100px;">标题</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>说明</td>
                <td>
                    <asp:TextBox ID="txtContent" runat="server" Height="100px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>合同号</td>
                <td>
                    <asp:Literal ID="ltlConN0" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td>审批流</td>
                <td>
                    <asp:DropDownList ID="dropFlow" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>下一处理人</td>
                <td>

                    <asp:TextBox ID="txtC_NEXT_EMP_ID" runat="server" Width="250px" ReadOnly="True"></asp:TextBox>
               

                    <a href="javascript:void(0)" onclick="openWeb();"><span class="glyphicon glyphicon-search"></span></a>
                    <input id="hidEmpID" runat="server" type="hidden" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnSave_Click" Text="提 交" OnClientClick="return Check();" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn btn-default btn-sm" OnClick="btnBack_Click" />
                </td>
            </tr>
        </table>
        <input id="hidSetpID" runat="server" type="hidden" />
       
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
                        var url = 'Check_Emp.aspx?ID='+$("#hidSetpID").val();
                        _iframe(url,'500', '400','审批人');
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
    </form>
</body>
</html>
