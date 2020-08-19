﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_Site.aspx.cs" Inherits="CRM.Common._Site" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <title>站点</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel panel-default">

            <asp:TreeView ID="trv_menu" runat="server" Font-Bold="False" Font-Size="12px" Width="100%"
                OnSelectedNodeChanged="trv_menu_SelectedNodeChanged" ShowLines="True" AutoGenerateDataBindings="False">
                <ParentNodeStyle Font-Bold="False" />
                <HoverNodeStyle Font-Underline="True" ForeColor="Purple" />
                <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                <NodeStyle Font-Names="Tahoma" Font-Size="9pt" ForeColor="DarkBlue" HorizontalPadding="5px"
                    NodeSpacing="0px" VerticalPadding="0px" />
            </asp:TreeView>
        </div>
        <script src="../Assets/js/jquery-1.10.2.min.js"></script>
        <script type="text/javascript">

            function GetSite(siteName, siteID) {
                window.parent.SetSite(siteName, siteID);
            }

            function GetLine(lineName, lineID) {
                window.parent.SetLine(lineName, lineID);
            }

            function GetDWDQ(lineName, lineID) {
                var index = $("#hidindex").val();
                window.parent.SetDWDQ(lineID,lineName, index);
            }

        </script>
        <asp:Literal ID="ltlFlag" Visible="false" runat="server"></asp:Literal>
        <input id="hidindex" type="hidden" runat="server" />
    </form>
</body>
</html>
