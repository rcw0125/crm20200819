<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PC_ORDER.aspx.cs" Inherits="CRM.WebForms.Report.PC_ORDER" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>合同订单提报排产</title>
    <uc1:common runat="server" ID="common" />
</head>
<body>
    <form id="form1" runat="server">
       <table  class="table table-bordered  table-condensed">
           <tr>
               <td style="width:120px;">合同号</td>
               <td>
                   <asp:Literal ID="ltlConNO" runat="server"></asp:Literal>
               </td>
           </tr>
           <tr>
               <td>物料编码</td>
               <td>
                   <asp:Literal ID="ltlMatCode" runat="server"></asp:Literal>
               </td>
           </tr>
           <tr>
               <td>物料名称</td>
               <td>
                   <asp:Literal ID="ltlMatName" runat="server"></asp:Literal>
               </td>
           </tr>
           <tr>
               <td>规格</td>
               <td>
                   <asp:Literal ID="ltlSpec" runat="server"></asp:Literal>
               </td>
           </tr>
           <tr>
               <td>钢种</td>
               <td>
                   <asp:Literal ID="ltlStlGrd" runat="server"></asp:Literal>
               </td>
           </tr>
           <tr>
               <td>自由项1</td>
               <td>
                   <asp:Literal ID="ltlFree1" runat="server"></asp:Literal>
               </td>
           </tr>
           <tr>
               <td>自由项2</td>
               <td>
                   <asp:Literal ID="ltlFree2" runat="server"></asp:Literal>
               </td>
           </tr>
           <tr>
               <td>包装</td>
               <td>
                   <asp:TextBox ID="txtPack" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>订单量</td>
               <td>
                   <asp:Literal ID="ltlwgt" runat="server"></asp:Literal>
                  &nbsp;&nbsp;&nbsp; 已履行量：<asp:Literal ID="ltlylxwgt" runat="server"></asp:Literal>
&nbsp;&nbsp; 待履行量：<asp:Literal ID="ltldlxwgt" runat="server"></asp:Literal>
                  </td>
           </tr>
           <tr>
               <td>已下发排产量</td>
               <td>
                   <asp:Literal ID="ltlplanwgt" runat="server"></asp:Literal>
               </td>
           </tr>
           <tr>
               <td>旬排产</td>
               <td>
                      <asp:DropDownList ID="dropZB" runat="server">
                      <asp:ListItem Value="0">上旬</asp:ListItem>
                      <asp:ListItem Value="1">中旬</asp:ListItem>
                      <asp:ListItem Value="2">下旬</asp:ListItem>
                  </asp:DropDownList></td>
           </tr>
           <tr>
               <td>现需求排产量</td>
               <td>
                   <asp:TextBox ID="txtneedwgt" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>备注说明</td>
               <td>
                   <asp:TextBox ID="txtremark" runat="server" Width="200px"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>&nbsp;</td>
               <td>
                   <asp:Button ID="btn_add" runat="server" CssClass="btn btn-primary btn-xs" Text="提报排产" OnClick="btn_add_Click" OnClientClick="return confirm('确定提报吗？');" />
               </td>
           </tr>
       </table>
        <asp:Literal ID="ltlOrderNo" Visible="false" runat="server">0</asp:Literal>
         <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlempname" runat="server" Visible="false"></asp:Literal>
    </form>
</body>
</html>
