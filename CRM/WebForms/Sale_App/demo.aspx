<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demo.aspx.cs" Inherits="CRM.WebForms.Sale_App.demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Assets/css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <tr>
                <td class="right" style="width:120px;">销售合同导入NC</td>
                <td style="width:150px;">
                    <asp:TextBox ID="txtCON" runat="server" placeholder="合同号"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button6" runat="server" Text="导入" CssClass="btn btn-primary  btn-xs" OnClick="Button6_Click" /></td>
                
                
            </tr>
            <tr>
                <td class="right" style="width:120px;">销售订单导入NC</td>
                <td style="width:150px;">
                    <asp:TextBox ID="txtConNo"  placeholder="SO销售单据号" runat="server" Width="140px"></asp:TextBox></td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="导入" CssClass="btn btn-primary  btn-xs" OnClick="Button1_Click" /></td>
                
                
            </tr>
            <tr>
                <td class="right" >发运日计划导入NC</td>
                <td >
                    <asp:TextBox ID="txtDayPlanCode"  placeholder="日计划单据号" runat="server" Width="140px"></asp:TextBox></td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="导入" CssClass="btn btn-primary  btn-xs" OnClick="Button2_Click" /></td>
                
                
            </tr>
            <tr>
                <td class="right" >发运单导入NC</td>
                <td >
                    <asp:TextBox ID="txtFYD"  placeholder="发运单据号" runat="server" Width="140px"></asp:TextBox></td>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="导入" CssClass="btn btn-primary  btn-xs" OnClick="Button3_Click" /></td>
                
                
            </tr>
            <tr>
                <td class="right" >发运单导入WL</td>
                <td >
                    <asp:TextBox ID="txtFYD0"  placeholder="发运单据号" runat="server" Width="140px"></asp:TextBox></td>
                <td>
                    <asp:Button ID="Button4" runat="server" Text="导入" CssClass="btn btn-primary  btn-xs" OnClick="Button4_Click" /></td>
                
                
            </tr>
            <tr>
                <td class="right" >物流实绩导入NC</td>
                <td >
                    <asp:TextBox ID="txtFYD1"  placeholder="发运单据号" runat="server" Width="140px"></asp:TextBox></td>
                <td>
                    <asp:Button ID="Button5" runat="server" Text="导入" CssClass="btn btn-primary  btn-xs" OnClick="Button5_Click" /></td>
                
                
            </tr>
            </table>
        
    </form>
</body>
</html>
