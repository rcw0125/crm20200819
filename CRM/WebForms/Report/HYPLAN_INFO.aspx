<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HYPLAN_INFO.aspx.cs" Inherits="CRM.WebForms.Report.HYPLAN_INFO" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>厂内车皮信息</title>
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
                        <asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-danger btn-xs" OnClientClick="return confirm('确定要删除吗？');" OnClick="btndel_Click" />
                </td>

            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover">
            <thead>
                <tr>
                    <th style="width: 80px">选择框</th>
                    <th style="width: 150px">空车</th>
                    <th style="width: 150px">重车</th>
                    <th style="width: 150px">到达预报</th>
                    <th>日期</th>
                 
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input id="cbxID" style="width: 15px;" class="che1" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' type="checkbox" />
                              
                            </td>
                            <td>
                                <input id="txtN_KC_NUM" class="numJe" style="width: 100px" type="text" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"N_KC_NUM")%>' /></td>
                            <td>
                                <input id="txtN_ZC_NUM" class="numJe" style="width: 100px" type="text" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"N_ZC_NUM")%>' /></td>
                            <td>
                                <input id="txtN_YB_NUM" class="numJe" style="width: 100px" type="text" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"N_YB_NUM")%>' /></td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"D_DT","{0:yyy-MM-dd}")%>
                                <asp:Literal ID="ltlC_TYPE" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_TYPE")%>'></asp:Literal>
                            </td>
                         
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>


         <asp:Literal ID="ltlEmpName" runat="server" Visible="false"></asp:Literal>

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
