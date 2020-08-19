<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaPlanUpdate.aspx.cs" Inherits="CRM.BasicData.AreaPlanUpdate" %>

<%@ Register Src="~/BasicData/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>修改区域计划量</title>
    <uc1:common runat="server" id="common" />
    <script src="JsDate.js"></script>

     <script type="text/javascript">
         $(function () {
             function CheckSave() {
                 var num = $.trim($("#txtNum").val());

                 if (num == '') {
                     alert("请输入计划量");
                     return false;
                 }
                 return true;
             }
    </script>

</head>

<body>

    <form class="form-horizontal" runat="server">
       <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 120px;" class="right">区域</td>
                <td>
                    <asp:DropDownList ID="dropArea" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="right">开始时间</td>
                <td>
                    <input id="Start" type="text" readonly class="form-control  Wdate" runat="server" style="width:120px;"></td>
            </tr>
            <tr>
                <td class="right">结束时间</td>
                <td>
                    <input id="End" type="text" readonly class="form-control  Wdate" runat="server" style="width:120px;"></td>
            </tr>
            <tr>
                <td class="right">计划量(吨)</td>
                <td>
                    <input type="text" class="input-xlarge numJe" id="txtNum" runat="server"></td>
            </tr>
            <tr>
                <td class="right"></td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary btn-sm" OnClick="btnSave_Click" OnClientClick="return CheckSave();" />
                </td>
            </tr>
        </table>
        <input id="hidID" runat="server" type="hidden" />
    </form>
</body>
</html>


