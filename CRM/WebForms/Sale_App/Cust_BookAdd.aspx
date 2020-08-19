<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cust_BookAdd.aspx.cs" Inherits="CRM.WebForms.Sale_App.Cust_BookAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>走访/来访交流台账</title>
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Assets/css/common.css" rel="stylesheet" />
    <script src="../../Assets/js/jquery-1.10.2.min.js"></script>
    <script src="../../Assets/js/bootstrap.min.js"></script>
    <script src="../../Assets/js/My97DatePicker/WdatePicker.js"></script>

</head>
<body>
    <form id="form1" runat="server">

        
       <table class="table table-bordered">
                    <tr>
                        <td class="right">日期</td>
                        <td>
                            <input id="txtD_ZF_DT" type="text" style="width: 110px;" runat="server" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true })" />&nbsp; <asp:DropDownList ID="droptype" runat="server" Width="80px">
                                <asp:ListItem Value="0">走访</asp:ListItem>
                                <asp:ListItem Value="1">来访</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="right">客户</td>
                        <td>
                            <asp:TextBox ID="txtC_CUST_NAME" runat="server" Width="100%"></asp:TextBox></td>
                        <td class="right">区域</td>
                        <td>
                            <asp:DropDownList ID="dropArea" runat="server"></asp:DropDownList>
                        </td>
                        <td class="right">客户经理</td>
                        <td>
                            <asp:TextBox ID="txtC_CUST_MANAGE" runat="server" Width="100%" placeholder="必填"></asp:TextBox></td>
                    </tr>


                    <tr>
                        <td class="right">人员</td>
                        <td>
                            <asp:TextBox ID="txtC_CUST_EMP" runat="server" Width="100%" placeholder="必填"></asp:TextBox></td>
                        <td class="right">人员联系电话</td>
                        <td>
                            <asp:TextBox ID="txtC_CUST_EMP_TEL" runat="server" Width="100%" placeholder="必填"></asp:TextBox></td>
                        <td class="right">参会客户</td>
                        <td>
                            <asp:TextBox ID="txtC_MEETING_CUST" runat="server" Width="100%"></asp:TextBox></td>
                        <td class="right">参会邢钢</td>
                        <td>
                            <asp:TextBox ID="txtC_MEETING_XG" runat="server" Width="100%"></asp:TextBox></td>
                    </tr>


                    <tr>
                        <td class="right">主要交流内容</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtC_MAIN_CONTENT" runat="server" Height="50px" TextMode="MultiLine" Width="100%"></asp:TextBox></td>

                        <td class="right">需解决的问题</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtC_NEED_S_Q" runat="server" Height="50px" TextMode="MultiLine" Width="100%"></asp:TextBox></td>

                    </tr>


                    <tr>
                        <td class="right">遗留问题</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtC_LEAVE_Q" runat="server" Height="50px" TextMode="MultiLine" Width="100%"></asp:TextBox></td>

                        <td class="right">备注</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtC_REMARK" runat="server" Height="50px" TextMode="MultiLine" Width="100%"></asp:TextBox></td>

                    </tr>


                    <tr>
                        <td class="right">钢种</td>
                        <td>
                            <asp:TextBox ID="txtC_STL_GRD" runat="server" Width="100%"></asp:TextBox></td>
                        <td class="right">用途</td>
                        <td>
                            <asp:TextBox ID="txtC_PRO_USE" runat="server" Width="100%"></asp:TextBox></td>
                        <td class="right">交流地点</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtC_SITE" runat="server" Width="100%"></asp:TextBox></td>

                    </tr>
                </table>
                <div style="text-align: center">
                    <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary btn-sm" OnClientClick="return check();" OnClick="btnSave_Click" />
                    <asp:Button ID="btnReset" runat="server" Text="重置" CssClass="btn btn-default btn-sm" OnClick="btnReset_Click" />
                </div>

        <asp:Literal ID="ltlempID" Visible="false" runat="server"></asp:Literal>

        <script type="text/javascript">

            function check() {

                if ($.trim($("#txtC_CUST_MANAGE").val()) == '') {
                    alert("客户经理不能为空");
                    return false;
                }
                if ($.trim($("#txtC_CUST_EMP").val()) == '') {
                    alert("客户接待人员不能为空");
                    return false;
                }
                if ($.trim($("#txtC_CUST_EMP_TEL").val()) == '') {
                    alert("客户接待人员电话不能为空");
                    return false;
                }
                return true;
            }
        </script>
    </form>
</body>
</html>
