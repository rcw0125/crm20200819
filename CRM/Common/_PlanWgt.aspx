<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_PlanWgt.aspx.cs" Inherits="CRM.Common._PlanWgt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>区域计划量</title>
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       <table class="table table-bordered table-condensed">
           <tr>
               <td>大类</td>
               <td>
                   <asp:DropDownList ID="dropclass" runat="server"></asp:DropDownList></td>
               <td>监控钢种</td>
               <td>
                   <asp:DropDownList ID="dropsfjk" runat="server">
                       <asp:ListItem>全部</asp:ListItem>
                       <asp:ListItem>Y</asp:ListItem>
                       <asp:ListItem>N</asp:ListItem>
                   </asp:DropDownList></td>
               <td>钢类</td>
               <td>
                   <asp:DropDownList ID="dropsubclass" runat="server"></asp:DropDownList></td>
               <td>
                   <asp:Button ID="Button1" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="Button1_Click" /></td>
           </tr>
        </table>
        <table class="table table-bordered table-hover table-condensed">
            <thead>
                <tr>
                    <th>钢种</th>
                    <th>大类</th>
                    <th>监控钢种</th>
                    <th>钢类</th>
                    <th>汇总</th>
                </tr>
            </thead>
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD_CLASS")%></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_SFJK")%></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_PROD_NAME")%></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"wgt")%></td>
                        
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
        <asp:Literal ID="ltlarea" runat="server" Visible="false"></asp:Literal>
    </form>
</body>
</html>
