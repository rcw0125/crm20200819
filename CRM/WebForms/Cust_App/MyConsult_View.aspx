<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyConsult_View.aspx.cs" Inherits="CRM.Cust_App.MyConsult_View" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>技术咨询查看</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <uc1:common runat="server" ID="common" />
   
    
    <style type="text/css">
        .strong {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <tr>
                <td style="width: 90px; text-align: right" class="strong">时间</td>
                <td>
                    <asp:Literal ID="ltlDt" runat="server"></asp:Literal>
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
                <td style="width: 90px; text-align: right" class="strong">产品</td>
                <td colspan="5">
                    <asp:Literal ID="ltlC_STL_GRD" runat="server"></asp:Literal></td>

            </tr>
            <tr>
                <td style="text-align: right" class="strong">用途及工艺</td>
                <td colspan="5">
                    <asp:Literal ID="ltlUseDesc" runat="server"></asp:Literal>

                </td>

            </tr>
            <tr>

                <td style="text-align: right" class="strong">问题描述</td>
                <td colspan="5">
                    <asp:Literal ID="ltlQuestContent" runat="server"></asp:Literal>

                </td>

            </tr>

            <tr>

                <td style="text-align: right" class="strong">计划时间</td>
                <td>

                    <asp:Literal ID="ltlD_PLAN_DT" runat="server"></asp:Literal>

                </td>
                <td style="text-align: right" class="strong">服务专员</td>
                <td>

                    <asp:Literal ID="ltlC_EMP" runat="server"></asp:Literal>

                </td>
                <td style="text-align: right" class="strong">完成时间</td>
                <td>

                    <asp:Literal ID="ltlD_FINISH_DT" runat="server"></asp:Literal>

                </td>

            </tr>

            <tr>

                <td style="text-align: right" class="strong">实时动态</td>
                <td colspan="5">
                    <asp:Literal ID="ltlC_REAL_TIME" runat="server"></asp:Literal>
                </td>

            </tr>

            <tr>

                <td style="text-align: right" class="strong">处理情况</td>
                <td colspan="5">
                    <asp:Literal ID="ltlC_RESULT" runat="server"></asp:Literal>
                </td>

            </tr>

            <tr>

                <td style="text-align: right" class="strong">遗留问题</td>
                <td colspan="5">
                    <asp:Literal ID="ltlC_LEAVE_Q" runat="server"></asp:Literal>
                </td>

            </tr>

            <tr>

                <td style="text-align: right" class="strong">备注</td>
                <td colspan="5">
                    <asp:Literal ID="ltlC_REMARK2" runat="server"></asp:Literal>
                </td>

            </tr>

            <tr>

                <td style="text-align: right" class="strong">服务效果评价</td>
                <td>
                    <div class="form-group">
                        <asp:DropDownList ID="dropNum" runat="server" CssClass="form-control" Width="100px" Height="30px"></asp:DropDownList>
                    </div>
                </td>
                <td style="text-align: right" class="strong">服务工作评价</td>
                <td>
                    <asp:Literal ID="ltlN_XG_EVAL" runat="server"></asp:Literal></td>
                <td class="strong"></td>
                <td></td>


            </tr>

            <tr>

                <td style="text-align: right" class="strong">&nbsp;</td>
                <td colspan="5">
                    <asp:Button ID="btnSave" CssClass="btn btn-primary btn-sm" runat="server" Text="评分" OnClick="btnSave_Click" />
                   
                </td>

            </tr>

        </table>
        <div>注：评价效果 中优（86-100分），良（71-85分），可（60-70分）</div>

        <asp:Literal ID="ltlID" Visible="false" runat="server"></asp:Literal>

        <script type="text/javascript">
            function pingjia(id, index, btn) {
                var txtNum = "#txtNum" + index;
                var num = $(txtNum).val();

                var parm = {
                    id: id,
                    num: num
                };

                $.ajax({
                    type: "Post",
                    url: "MyConsult_View.aspx/SetEval",
                    data: JSON.stringify(parm),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        debugger;
                        if (data.d) {
                            alert("提交成功");
                            $(btn).css("display", "none");
                        }
                    },
                    error: function (err) {
                        alert(err);
                    }
                });
            }
        </script>
    </form>
</body>
</html>
