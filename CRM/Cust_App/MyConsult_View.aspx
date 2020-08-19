<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyConsult_View.aspx.cs" Inherits="CRM.Cust_App.MyConsult_View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/jquery-1.10.2.min.js"></script>
    <script src="../Assets/js/common.js"></script>
    <title>技术咨询查看</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dv_btn">
            <ul>
                <li><a href="MyConsult.aspx" class="btn  btn-warning btn-xs">返回</a></li>
            </ul>
        </div>
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
        <div>注：评价效果 中优（86-100分），良（71-85分），可（60-70分）</div>
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <table class="table table-bordered">

                    <tr>
                        <td style="width: 90px; text-align: right">计划时间</td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem,"D_PLAN_DT","{0:yyy-MM-dd}") %>
                        </td>
                        <td>服务专员</td>
                        <td>

                            <%# DataBinder.Eval(Container.DataItem,"user_name") %>
                        </td>
                        <td>部门</td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem,"dept_name") %> 
                        </td>
                        <td>完成时间</td>
                        <td>

                            <%# DataBinder.Eval(Container.DataItem,"D_FINISH_DT","{0:yyy-MM-dd}") %>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">实时动态</td>
                        <td colspan="7">

                            <%# DataBinder.Eval(Container.DataItem,"C_REAL_TIME") %> 
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">处理情况</td>
                        <td colspan="7">
                            <%# DataBinder.Eval(Container.DataItem,"C_RESULT") %> </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">遗留问题</td>
                        <td colspan="7">
                            <%# DataBinder.Eval(Container.DataItem,"C_LEAVE_Q") %> 
                        
                        </td>

                    </tr>
                    <tr>
                        <td style="text-align: right">服务效果评价</td>
                        <td>

                            <input id="txtNum<%# Container.ItemIndex%>" type="text" style="width: 100px" class="num" value='<%# DataBinder.Eval(Container.DataItem,"N_CUST_EVAL") %>  
' /></td>
                        <td colspan="6"> 
                            <input id="btnSave" type="button" value="提交评价" onclick='pingjia("<%# DataBinder.Eval(Container.DataItem,"C_ID") %>","<%# Container.ItemIndex%>",this);' class="btn btn-primary btn-xs btn_w60" style='<%# DataBinder.Eval(Container.DataItem,"D_CUST_EVAL_DT").ToString ()==""?"display:block":"display:none" %>' />
                        </td>
                    </tr>

                </table>
            </ItemTemplate>
        </asp:Repeater>

        <div style="padding-left: 100px;"></div>
        <asp:Literal ID="ltlID" Visible="false" runat="server"></asp:Literal>
        <script src="../Assets/js/jquery-1.10.2.min.js"></script>
        <script type="text/javascript">
            function pingjia(id, index,btn) {
                var txtNum = "#txtNum" + index;
                var num = $(txtNum).val();
                $.ajax({
                    type: "Post",
                    url: "MyConsult_View.aspx/SetEval",
                    data: "{'id':'" + id + "','num':'" + num + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        debugger;
                        if (data.d) {
                            alert("提交成功");
                            $(btn).css("display","none");
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
