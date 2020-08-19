<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CRM.Sale_App.WebForm1" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <title>修改合同</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Assets/js/jquery-2.0.3.min.js"></script>
    <script src="../Assets/js/bootstrap.min.js"></script>
    <script>
        $(function () {
            $('#myTab li:eq(1) a').tab('show');
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dv_btn">
            <ul>
                <li>
                    <button type="button" class="btn btn-warning btn-xs" onclick='window.location.href="MyCon.aspx"'>返回</button></li>
                <li>
                    <button type="button" class="btn btn-warning btn-xs">提交审批</button></li>
                <li>
                    <button type="button" class="btn btn-warning btn-xs">保存</button></li>
                <li>
                    <button type="button" class="btn btn-warning btn-xs">新增订单</button></li>
                <li>
                    <button type="button" class="btn btn-warning btn-xs">变更订单</button></li>
            </ul>
        </div>

        <ul id="myTab" class="nav nav-tabs">
            <li class="active"><a href="#home" data-toggle="tab">合同基本信息</a> </li>
            <li><a href="#ios" data-toggle="tab">订单列表</a></li>

        </ul>
        <div id="myTabContent" class="tab-content">
            <div class="tab-pane fade in active" id="home">
            撒旦范德萨分
            </div>
            <div class="tab-pane fade" id="ios">
           撒打发士大夫
            </div>
        

        </div>

    </form>
</body>
</html>
