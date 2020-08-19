<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Balance.aspx.cs" Inherits="CRM.WebForms.Cust_App.Balance" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>余额查询</title>
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Assets/css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       <div class="panel panel-default">
   <div class="panel-heading">
      <h3 class="panel-title">
        余额查询：<asp:Literal ID="ltltime" runat="server"></asp:Literal>(更新)
      </h3>
   </div>
   <div class="panel-body">
    
         <h4><asp:Literal ID="ltlMoney" runat="server"></asp:Literal></h4>
   </div>
</div>

    </form>
</body>
</html>
