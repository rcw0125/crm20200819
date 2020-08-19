<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consult_View.aspx.cs" Inherits="CRM.Sale_App.Consult_View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/My97DatePicker/WdatePicker.js"></script>
    <title>技术咨询查看</title>

</head>
<body>
    <form id="form1" runat="server">


        <table class="table table-bordered">
            <tr>
                <td style="width: 90px; text-align: right">问题</td>
                <td>
                    <asp:Literal ID="ltlQuest" runat="server"></asp:Literal>
                </td>
                <td style="text-align: right">产品</td>
                <td>
                    <asp:Literal ID="ltlSTL_GRD" runat="server"></asp:Literal>

                </td>
                <td style="text-align: right">客户</td>
                <td>
                    <asp:Literal ID="ltlCust" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">用途及工艺</td>
                <td colspan="5">
                    <asp:Literal ID="ltlUseDesc" runat="server"></asp:Literal>

                </td>

            </tr>
            <tr>

                <td style="text-align: right">问题描述</td>
                <td colspan="5">
                    <asp:Literal ID="ltlQuestContent" runat="server"></asp:Literal>


                </td>

            </tr>

        </table>
        <table class="table table-bordered">
            <tr>
                <td style="width: 90px; text-align: right">计划时间</td>
                <td>
                    <input id="Start" type="text" style="width: 120px;" runat="server" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, maxDate: '#F{$dp.$D(\'End\')}' })" />
                </td>
                <td>服务专员</td>
                <td>
                    <input id="txtEmp" type="text" style="width: 99%" runat="server" /></td>
                
                
                <td>完成时间</td>
               
                <td>
                    <input id="End" runat="server" type="text" style="width: 120px;" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, minDate: '#F{$dp.$D(\'Start\')}' })" /></td>


            </tr>
            <tr>
                <td style="text-align: right">实时动态</td>
                <td colspan="5">

                    <textarea id="txtTIMECONTENT" style="height: 50px; width: 99%" runat="server"></textarea></td>



            </tr>
            <tr>
                <td style="text-align: right">处理情况</td>
                <td colspan="5">

                    <textarea id="txtRESULTCONTENT" style="height: 50px; width: 99%" runat="server"></textarea></td>
            </tr>
            <tr>
                <td style="text-align: right">遗留问题</td>
                <td colspan="5">

                    <textarea id="txtQUESTCONTENT" style="height: 50px; width: 99%"  runat="server"></textarea></td>

            </tr>
            <tr>
                <td style="text-align: right">服务效果评价</td>
                <td>
                    <input id="txtCUSTEVAL" type="text" style="width: 50%" disabled="disabled" runat="server" /></td>
                <td>服务工作评价</td>
                <td>
                    <input id="txtXGEVAL" type="text" style="width: 50%" disabled="disabled" runat="server" /></td>
                <td colspan="2">注：评价效果中优（86-100分），良（71-85），可（60-70分）</td>

            </tr>
            <tr>
                <td style="text-align: right">&nbsp;</td>
                <td colspan="5">
                    <asp:Button ID="btnSubmit" runat="server" Text="提交处理" CssClass="btn btn-primary btn-xs" OnClick="btnSubmit_Click" />&nbsp;&nbsp;
                    <a href="Consult_List.aspx" class="btn btn-warning btn-xs">返回</a>
                </td>


            </tr>
        </table>
      
        <asp:Literal ID="ltlEmpID" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlQuestID" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlDeptID" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlID" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
