<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_exe_view.aspx.cs" Inherits="CRM.WebForms.Report.order_exe_view" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>计划订单执行情况</title>
    <uc1:ReptControl runat="server" ID="ReptControl" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed" data-toggle="table" data-height="350" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th>物料名称</th>
                    <th>计划日期</th>
                    <th>需求日期</th>
                    <th>计划需求量</th>
                    <th>完工量</th>
                    <th>未执行需求量</th>
                    <th>钢种</th>
                    <th>规格</th>
                    <th>包装</th>
                    <th>自由项1</th>
                    <th>自由项2</th>
                    <th>状态</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>

                        <tr>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_PCTBTS","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_NEED_DT","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_WGT") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"完工数量") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"未执行需求量") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_PACK") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_FREE1") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_FREE2") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"订单状态") %></td>
                           
                        </tr>

                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </form>
</body>
</html>
