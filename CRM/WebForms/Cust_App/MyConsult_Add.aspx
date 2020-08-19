<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyConsult_Add.aspx.cs" Inherits="CRM.Cust_App.MyConsult_Add" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>技术咨询</title>
    <uc1:common runat="server" ID="common" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <tr>
                <td style="width: 80px; text-align: right">问题</td>
                <td>
                    <asp:DropDownList ID="dropQuest" runat="server"></asp:DropDownList></td>
                <td style="text-align: right">产品</td>
                <td>
                    <asp:TextBox ID="txtgrd" runat="server" Width="85%"></asp:TextBox>

                    &nbsp;
                    <a href="javascript:void(0);" onclick="openWeb(1);"><span class="glyphicon glyphicon-search"></span></a>
                </td>
                <td style="text-align: right">客户</td>
                <td>
                    <asp:TextBox ID="txtcust" runat="server" Enabled="False" Width="100%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align: right">用途及工艺</td>
                <td colspan="5">

                    <textarea id="txtUseDesc" placeholder="内容上限为200字符" style="height: 100px; width: 99%" maxlength="200" runat="server" cols="20"></textarea>
                </td>

            </tr>
            <tr>

                <td style="text-align: right">问题描述</td>
                <td colspan="5">

                    <textarea id="txtRemark" style="height: 150px; width: 99%" placeholder="内容上限为200字符" maxlength="200" runat="server"></textarea>
                </td>

            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="5">

                    <asp:Button ID="btnSave" runat="server" Text="提交" CssClass="btn btn-primary  btn-sm" OnClick="btnSave_Click" OnClientClick="return check();" />
                    &nbsp;
                     <a class="btn btn-default btn-sm" href="MyConsult.aspx">返回</a>
                </td>

            </tr>
        </table>
        <input id="horderNO" runat="server" type="hidden" />
        <asp:Literal ID="ltlID" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlUserID" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlUserName" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlCustNo" Visible="false" runat="server"></asp:Literal>
        <script type="text/javascript">
            function openWeb(index) {
                switch (index) {
                    case 1:
                        _iframe('../../Common/_CustOrder.aspx', '800', '450', '历史签单');
                        break;
                }
            }

            function check() {
                if ($.trim($("#txtgrd").val()) == '') {
                    alert("请选择产品");
                    return false;
                }
                if ($.trim($("#txtUseDesc").val()) == "") {
                    alert("用途及工艺不能为空");
                    return false;
                }
                if ($.trim($("#txtRemark").val()) == "") {
                    alert("问题描述不能为空");
                    return false;
                }
                return true;

            }

            function SetOrder(orderNO, stlGrd) {

                $("#txtgrd").val(stlGrd);
                $("#horderNO").val(orderNO);
                close();
            }

        </script>
    </form>
</body>
</html>
