<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlow_D.aspx.cs" Inherits="CRM.Sale_App.WorkFlow_D" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/My97DatePicker/WdatePicker.js"></script>
    <title>待办文件</title>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">

            <tr>
                <td style="width:80px;">文件名称</td>
                <td style="width:120px;">
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td>
                <td style="width:50px;">日期</td>
                <td style="width:120px;">
                    <input id="Start" type="text" style="width: 120px;" runat="server" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, maxDate: '#F{$dp.$D(\'End\')}' })" /></td>
                <td style="width:120px;">
                    <input id="End" runat="server" type="text" style="width: 120px;" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, minDate: '#F{$dp.$D(\'Start\')}' })" /></td>
                <td style="width:80px;">工作流</td>
                <td style="width:120px;">
                    <asp:DropDownList ID="dropFlow" runat="server" CssClass="inputW" ></asp:DropDownList></td>
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
                    <th>流程</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><a href='<%#GetUrl(DataBinder.Eval (Container.DataItem,"n_type"),DataBinder.Eval (Container.DataItem,"c_id"),DataBinder.Eval (Container.DataItem,"c_task_id"),DataBinder.Eval (Container.DataItem,"C_FLOW_ID"),DataBinder.Eval (Container.DataItem,"C_STEP_ID"))%>'><%#DataBinder.Eval (Container.DataItem,"C_TITLE") %></a></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"c_emp_id") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"d_sb_dt") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"n_status") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"c_flow_name") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
        <asp:Literal ID="ltlEmpID" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
