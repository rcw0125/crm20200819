<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demo_rep.aspx.cs" Inherits="CRM.WebForms.Sale_App.demo_rep" %>

<html>
<head>
    <title>FineReport Demo</title>
    <meta http-equiv="Content-Type" content="text/html; charset=GBK" />
    <script type="text/javascript" src="/webroot/decision/view/report?op=emb&resource=finereport.js"></script>
    <link rel="stylesheet" type="text/css" href="/webroot/decision/view/report?op=emb&resource=finereport.css" />
    <script type='text/javascript'>   
        function doPrint() {

            //var printurl="http://localhost:8075/webroot/decision/view/report"; 
            var printurl = "http://192.168.2.96:8080/WebReport/ReportServer?";
            var reportlets = "[{reportlet= " + document.report.cpt.value + "}]";
            var config = {
                printUrl: printurl,
                isPopUp: true,
                // 是否弹出设置窗口，true为弹出，false为不弹出  
                data: {
                    reportlets: reportlets // 需要打印的模版列表  
                },
                printType: 1, // 打印类型，0为零客户端打印，1为本地打印  
                // 以下为本地打印的参数，仅当 printType 为 1 时生效  
                printerName: 'Microsoft Print to PDF', // 打印机名  
                pageType: 2, // 打印页码类型：0：所有页，1：当前页，2：指定页  
                pageIndex: '1-3', // 页码范围。当 pageType 为 2 时有效  
                copy: 3, // 打印份数  
            };
            FR.doURLPrint(config);
        }
    </script>
</head>
<body>
    <form name="report">
        <input id="cpt" type="checkbox" value="con_001.cpt&conno=XG-XS-180500529" />GettingStarted.cpt<br>
    </form>
    <input type="button" name="doprint" onclick="doPrint()" value='doPrint'/>
</body>
</html>
