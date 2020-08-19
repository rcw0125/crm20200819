<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KC_ORDER.aspx.cs" Inherits="CRM.WebForms.Report.KC_ORDER" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>库存订单</title>
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
                   <asp:Literal ID="ltlPack" runat="server"></asp:Literal>
               </td>
           </tr>
           <tr>
               <td>数量</td>
               <td>
                   <input id="txtNum" type="text" runat="server" /></td>
           </tr>
           <tr>
               <td>税率</td>
               <td>
                   <asp:Literal ID="ltlTaxRate" runat="server"></asp:Literal>
               </td>
           </tr>
           <tr>
               <td>含税单价</td>
               <td>
                   <asp:Literal ID="ltlPrice" runat="server"></asp:Literal>
                </td>
           </tr>
           <tr>
               <td>&nbsp;</td>
               <td>
                   <asp:Button ID="btn_add" runat="server" CssClass="btn btn-primary btn-xs" Text="提交订单" OnClick="btn_add_Click" OnClientClick="return confirm('确定提交吗？');" />
               </td>
           </tr>
       </table>
        <asp:Literal ID="ltlOrderNo" Visible="false" runat="server">0</asp:Literal>
    </form>
</body>
</html>
