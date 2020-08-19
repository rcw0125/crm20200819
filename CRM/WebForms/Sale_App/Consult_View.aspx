<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consult_View.aspx.cs" Inherits="CRM.Sale_App.Consult_View" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>技术咨询查看</title>
    <uc1:common2 runat="server" ID="common2" />
    <style type="text/css">
        .strong {
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#Start").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true,
                todayBtn: true,//显示今日按钮
                startDate: new Date()
            });

            $("#End").datetimepicker({
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


        <table class="table table-bordered">
            <tr>
                <td style="width: 90px; text-align: right" class="strong">时间</td>
                <td>
                    <asp:Literal ID="ltlDT" runat="server"></asp:Literal>
                </td>
                <td style="text-align: right;" class="strong">用户</td>
                <td>
                    <asp:Literal ID="ltlCust" runat="server"></asp:Literal>
                </td>

                <td style="text-align: right" class="strong">录入人</td>
                <td>
                    <asp:Literal ID="ltlC_EMP_NAME" runat="server"></asp:Literal>

                </td>
                <td style="text-align: right" class="strong">问题类型</td>
                <td>
                    <asp:Literal ID="ltlQuest" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td style="text-align: right" class="strong">产品</td>
                <td colspan="7">
                    <asp:Literal ID="ltlSTL_GRD" runat="server"></asp:Literal></td>


            </tr>
            <tr>
                <td style="text-align: right" class="strong">用途及工艺</td>
                <td colspan="7">
                    <asp:Literal ID="ltlUseDesc" runat="server"></asp:Literal>

                </td>

            </tr>
            <tr>

                <td style="text-align: right" class="strong">问题描述</td>
                <td colspan="7">
                    <asp:Literal ID="ltlQuestContent" runat="server"></asp:Literal>


                </td>

            </tr>

        </table>
        <table class="table table-bordered">
            <tr>
                <td style="width: 90px; text-align: right" class="strong">计划时间</td>
                <td>
                    <input id="Start" type="text" style="width: 120px;" runat="server" readonly="readonly" class="form-control Wdate" />
                </td>
                <td style="text-align: right" class="strong">服务专员</td>
                <td>
                    <input id="txtEmp" type="text" style="width: 99%" runat="server" readonly="readonly" /></td>


                <td style="text-align: right" class="strong">完成时间</td>

                <td>
                    <input id="End" runat="server" type="text" style="width: 120px;"   readonly="readonly" class="form-control Wdate" /></td>


            </tr>
            <tr>
                <td style="text-align: right" class="strong">实时动态</td>
                <td colspan="5">

                    <textarea id="txtTIMECONTENT" style="height: 50px; width: 99%" runat="server"></textarea></td>



            </tr>
            <tr>
                <td style="text-align: right" class="strong">处理情况</td>
                <td colspan="5">

                    <textarea id="txtRESULTCONTENT" style="height: 50px; width: 99%" runat="server"></textarea></td>
            </tr>
            <tr>
                <td style="text-align: right" class="strong">遗留问题</td>
                <td colspan="5">

                    <textarea id="txtQUESTCONTENT" style="height: 50px; width: 99%" runat="server"></textarea></td>

            </tr>
            <tr>
                <td style="text-align: right" class="strong">备注</td>
                <td colspan="5">
                    <textarea id="txtRemark" style="height: 50px; width: 99%" runat="server"></textarea>
                </td>

            </tr>
            <tr>
                <td style="text-align: right" class="strong">服务效果评价</td>
                <td>
                    <asp:Literal ID="ltlCUSTEVAL" runat="server"></asp:Literal>
                </td>
                <td style="text-align: right" class="strong">服务工作评价</td>
                <td>
                    <div class="form-group">
                        <asp:DropDownList ID="dropNum" runat="server" CssClass="form-control" Width="100px" Height="30px"></asp:DropDownList>
                    </div>
                </td>
                <td colspan="2">注：评价效果中优（86-100分），良（71-85），可（60-70分）</td>

            </tr>
            <tr>
                <td style="text-align: right" class="strong">&nbsp;</td>
                <td colspan="5">
                    <asp:Button ID="EA" runat="server" Text="保存" CssClass="btn btn-primary btn-sm" OnClick="EA_Click" Visible="false" />&nbsp;<asp:Button ID="EB" runat="server" Text="评分" CssClass="btn btn-primary btn-sm" OnClick="EB_Click" Visible="false" />
                    <a href="Consult_List.aspx" class="btn  btn-default btn-sm">返回</a>
                </td>


            </tr>
        </table>

        <asp:Literal ID="ltlUserName" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlID" Visible="false" runat="server"></asp:Literal>

    </form>
</body>
</html>
