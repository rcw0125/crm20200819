<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fyd_edit_ch.aspx.cs" Inherits="CRM.WebForms.Sale_App.fyd_edit_ch" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修改车牌号</title>
    <uc1:common2 runat="server" ID="common2" />
    <script type="text/javascript">
        $(function () {

            $("#txtfydt").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true,
                todayBtn: true,//显示今日按钮
                startDate: new Date()
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 100px;">发运单号</td>
                <td>
                    <asp:Literal ID="ltlfyd" runat="server"></asp:Literal>
                </td>
            </tr>
             <tr>
                <td>制单日期</td>
                <td>
                    <asp:TextBox ID="txtfydt" runat="server" Width="150px" class="form-control Wdate"></asp:TextBox></td>
            </tr>
            <tr>
                <td>车牌号</td>
                <td>
                    <asp:TextBox ID="txt_CH" runat="server" Width="204px"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                <td>虚拟车号</td>
                <td>
                    <asp:TextBox ID="txtxnch" runat="server" Width="150"></asp:TextBox></td>
            </tr>
           
            <tr>
                <td>发运方式</td>
                <td>
                    <asp:DropDownList ID="dropfyfs" runat="server" Width="150"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>承运商</td>
                <td>
                     <asp:DropDownList ID="dropcys" runat="server" Width="150"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>到站</td>
                <td><asp:TextBox ID="txtdz" runat="server" Width="150"></asp:TextBox></td>
            </tr>
            <tr>
                <td>GPS设备号</td>
                <td>
                     <asp:TextBox ID="txtgps" runat="server" Width="150" ></asp:TextBox></td>
            </tr>
            <tr>
                <td>客户姓名/电话</td>
                <td>
                     <asp:TextBox ID="txtkhtel" runat="server" Width="150" ></asp:TextBox></td>
            </tr>
            <tr>
                <td>司机姓名/电话</td>
                <td>
                    <asp:TextBox ID="txtsjtel" runat="server" Width="150" ></asp:TextBox></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary btn-xs" OnClientClick="_loading(1);" OnClick="btnSave_Click" />
                    &nbsp;
                  <asp:Button ID="btnNC" runat="server" Text="导入NC" CssClass="btn btn-primary btn-xs" OnClientClick="_loading(1);" OnClick="btnNC_Click" />
                    &nbsp;
                  <asp:Button ID="btnRF" runat="server" Text="导入条码" CssClass="btn btn-primary btn-xs" OnClientClick="_loading(1);" OnClick="btnRF_Click" />
                </td>
            </tr>
        </table>
        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>
        <input id="hidempname" runat="server" type="hidden" />
        <asp:Literal ID="ltlimport_num" runat="server" Visible="false"></asp:Literal>

    </form>
</body>
</html>
