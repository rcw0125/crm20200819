<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="train_add.aspx.cs" Inherits="CRM.WebForms.Train.train_add" %>

<%@ Register Src="~/WebForms/Train/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>火运报备计划添加</title>
    <uc1:rollControl runat="server" ID="rollControl" />
    <script type="text/javascript">

         $(function () {

            $("#txtStart").datetimepicker({
                format: 'yyyy-mm',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true

            })
          
        });

        function check() {
           
            if ($.trim($("#txtC_DH_COMPANY").val()) == "") {
                alert("订货单位不能为空");
                return false;
            }

            if ($.trim($("#txtC_SH_COMPANY").val()) == "") {
                alert("收货单位不能为空");
                return false;
            }
            if ($.trim($("#txtC_STATION").val()) == "") {
                alert("到站不能为空");
                return false;
            }
            if ($.trim($("#txtN_TRAIN_NUM").val()) == "") {
                alert("车数不能为空");
                return false;
            }
            if ($.trim($("#txtC_CUSTNO").val()) == "") {
                alert("客户编码不能为空");
                return false;
            }
            if ($.trim($("#txtC_CUSTNAME").val()) == "") {
                alert("客户名称不能为空");
                return false;
            }
            if ($.trim($("#txtC_KH_BANK").val()) == "") {
                alert("开户行不能为空");
                return false;
            }
            if ($.trim($("#txtC_TAXNO").val()) == "") {
                alert("税号不能为空");
                return false;
            }
            if ($.trim($("#txtC_ACCOUNT").val()) == "") {
                alert("账号不能为空");
                return false;
            }
            if ($.trim($("#txtC_TEL").val()) == "") {
                alert("电话不能为空");
                return false;
            }
            if ($.trim($("#txtC_ADDRESS").val()) == "") {
                alert("地址不能为空");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 80px;">
                 合同号</td>
                <td>
                    <asp:TextBox ID="txtconno" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td style="width: 80px;">
                  客户编码</td>
                <td>
                    <asp:TextBox ID="txtcustno" Style="width: 100%" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" /></td>

            </tr>
        </table>
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 100px;">计划月份</td>
                <td>
                    <input id="txtStart" type="text" style="width: 120px;" readonly="readonly" class="form-control Wdate" runat="server" /></td>
                <td style="width: 100px;">类型</td>
                <td>
                    <asp:DropDownList ID="dropflag" runat="server">
                        <asp:ListItem Value="0">计划内</asp:ListItem>
                        <asp:ListItem Value="2">计划外</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px;">区域</td>
                <td>
                    <asp:DropDownList ID="droparea" runat="server" Width="150px">
                    </asp:DropDownList>
                   
                </td>
                <td style="width: 100px;">合同号</td>
                <td>
                    <asp:TextBox ID="txtC_CONNO" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td>订货单位</td>
                <td>
                    <asp:TextBox ID="txtC_DH_COMPANY" runat="server" Width="100%"></asp:TextBox></td>
                <td>收货单位</td>
                <td>
                    <asp:TextBox ID="txtC_SH_COMPANY" runat="server" Width="100%"></asp:TextBox></td>
            </tr>

            <tr>
                <td>到站</td>
                <td>
                    <asp:TextBox ID="txtC_STATION" runat="server" Width="100%"></asp:TextBox></td>
                <td>车数</td>
                <td>
                    <asp:TextBox ID="txtN_TRAIN_NUM" runat="server" Width="100" CssClass="numJe2"></asp:TextBox></td>
            </tr>

            <tr>
                <td>客户编码</td>
                <td>
                    <asp:TextBox ID="txtC_CUSTNO" runat="server" Width="100%"></asp:TextBox></td>
                <td>客户名称</td>
                <td>
                    <asp:TextBox ID="txtC_CUSTNAME" runat="server" Width="100%"></asp:TextBox></td>
            </tr>

            <tr>
                <td>开户行</td>
                <td>
                    <asp:TextBox ID="txtC_KH_BANK" runat="server" Width="100%"></asp:TextBox></td>
                <td>税号</td>
                <td>
                    <asp:TextBox ID="txtC_TAXNO" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td>账号</td>
                <td>
                    <asp:TextBox ID="txtC_ACCOUNT" runat="server" Width="100%"></asp:TextBox></td>
                <td>电话</td>
                <td>
                    <asp:TextBox ID="txtC_TEL" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td>地址</td>
                <td>
                    <asp:TextBox ID="txtC_ADDRESS" runat="server" Width="100%"></asp:TextBox></td>
                <td>专用线</td>
                <td>
                    <asp:TextBox ID="txtLine"  Width="100%" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td colspan="3">
                    <asp:Button ID="btSave" CssClass="btn btn-primary btn-xs" runat="server" Text="保存" OnClick="btSave_Click"  OnClientClick="return check();" /></td>
            </tr>
        </table>
      
    </form>
</body>
</html>
