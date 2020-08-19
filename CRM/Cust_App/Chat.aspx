<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="CRM.Cust_App.Chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <title>在线咨询</title>
    <script src="../Assets/js/jquery-2.0.3.min.js"></script>
    <script src="JsChat.js"></script>
    
</head>
<body onresize="fromsize();">
    <form id="form1" runat="server">
        <div class="panel panel-default" style="width: 650px; margin-left: 200px; margin-top: 20px;">
            <div class="panel-heading">为您提供专业、及时的售前售后咨询服务</div>
            <div class="panel-body" style="background: #f9f9f9">

                <div style="overflow-y: auto;" id="_scroll">
                    <div id="dv_content"></div>

                </div>
            </div>
            <div class="panel-footer" style="background: #ffffff;">
                <p>
                    <textarea id="txtContent" style="width: 100%; border: solid 1px #cccccc; height: 50px; vertical-align: top; resize: none;"></textarea>
                
                </p>
                <p style="margin-top: 5px;">
                    <input id="btnSave" type="button" value="发 送" class="btn btn-primary btn-sm" onclick="insert();" />
                </p>
            </div>
        </div>
        <input id="hidUserID" runat="server" type="hidden" />
        
    </form>
</body>
</html>
