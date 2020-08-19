<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlow_F.aspx.cs" Inherits="CRM.Sale_App.WorkFlow_F" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>待办文件</title>
    <uc1:common2 runat="server" ID="common2" />
    <script src="../JsDate.js"></script>
    <script src="js/jsworkflow_d.js?ver=1.1"></script>
</head>

<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">

            <tr>
                <td class="right">文件名称</td>
                <td class="right">
                    <asp:TextBox ID="txtTitle" runat="server" Width="100%"></asp:TextBox></td>
                <td class="right">日期</td>
                <td style="width:125px;">
                    <input id="txtStart" type="text" style="width: 120px;" runat="server" readonly="readonly" class="form-control Wdate" /></td>
                 <td style="width: 125px;">
                     <input id="txtEnd" runat="server" type="text" style="width: 120px;" readonly="readonly" class="form-control Wdate" />
                </td>

                <td>工作流</td>
                <td>
                    <asp:DropDownList ID="dropFlow" runat="server" Width="100%"></asp:DropDownList></td>
                <td>
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-xs" Text="查 询" OnClick="btnSave_Click" /></td>

            </tr>
        </table>
        <table class="table table-bordered table-hover">
            <thead>
                <tr>
                    <th>文件名称</th>
                    <th>提交人</th>
                    <th>提交时间</th>
                    <th>状态</th>
                    <th>流程/步骤</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr ondblclick="geturl2('<%#DataBinder.Eval (Container.DataItem,"c_id")%>','<%#DataBinder.Eval (Container.DataItem,"n_type")%>');"  title='双击查看'>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_TITLE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"c_emp_id") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"d_sb_dt") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"n_status") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"c_flow_name") %>/<%#GetRole(DataBinder.Eval (Container.DataItem,"C_STEP_ID")) %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
        <asp:Literal ID="ltlEmpID" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
