<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeView.aspx.cs" Inherits="CRM.WebForms.Sale_App.NoticeView" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>公告</title>
    <uc1:common2 runat="server" ID="common2" />
</head>
<body>
    <form id="form1" runat="server">
         <table class="table">
            <tr>
                         
                <td style="text-align:center">
                    <h4><asp:Literal ID="ltltitle" runat="server"></asp:Literal></h4>
                    
                </td>
            </tr>
         <tr>
                  
                <td>
                    <asp:Literal ID="ltlcontent" runat="server"></asp:Literal>
                </td>
                
            </tr>
         
     
    </table>
    </form>
</body>
</html>
