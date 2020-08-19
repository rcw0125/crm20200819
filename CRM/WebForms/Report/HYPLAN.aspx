<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HYPLAN.aspx.cs" Inherits="CRM.WebForms.Report.HYPLAN" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>火运车皮计划执行情况</title>
    <uc1:ReptControl runat="server" ID="ReptControl" />

</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed table-hover">
            <tr>
                <td style="width: 80px;">日期</td>
                <td style="width: 120px;">
                    <input id="txtStart" runat="server" type="text" style="width: 100px;" class=" form-control Wdate" /></td>
                <td>
                    <asp:Button ID="btnCX" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btnCX_Click" />
                    &nbsp;
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="btn btn-primary btn-xs" OnClick="btnAdd_Click" />

                    &nbsp;
                        <asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-danger btn-xs" OnClientClick="return confirm('确定要删除吗？');" OnClick="btndel_Click" Visible="false" />
                </td>

            </tr>
        </table>

        <table class="table table-bordered table-condensed table-hover">
            
            <tr>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server" Height="200px" TextMode="MultiLine" Width="650"></asp:TextBox>
                </td>
            </tr>
           
        </table>



        <asp:Literal ID="ltlEmpName" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlID" runat="server" Visible="false"></asp:Literal>

        <script type="text/javascript">

            $(function () {
                $("#txtStart").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true,//显示今日按钮
                });
            });
        </script>
    </form>
</body>
</html>
