<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webpost.aspx.cs" Inherits="CRM.WebForms.Sale_App.webpost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Assets/css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
      
        

       <table class="table  table-bordered">
           <tr>
               <td style="width:100px;">订单号</td>
               <td>
                   <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
               </td>
           </tr>
             <tr>
               <td style="width:100px;"></td>
               <td> <asp:Button ID="Button2" runat="server" Text="发送post" OnClick="Button2_Click" style="height: 21px" />
                 </td>
           </tr>
       </table>
    </form>
</body>
</html>
