<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowStep_View.aspx.cs" Inherits="CRM.WebForms.Sale_App.FlowStep_View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>审批记录</title>
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Assets/css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="right info" style="width: 200px;">
                            <%#DataBinder.Eval (Container.DataItem,"STEPNAME") %>( <%#DataBinder.Eval (Container.DataItem,"c_step_emp_name") %>-<%#DataBinder.Eval (Container.DataItem,"N_PROCRESULT").ToString ()=="1"?"批准":DataBinder.Eval (Container.DataItem,"N_PROCRESULT").ToString ()=="0"?"驳回":"待处理" %>)</td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_STEPNOTE") %>&nbsp;<%#DataBinder.Eval (Container.DataItem,"D_STEP_DT") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
</body>
</html>
