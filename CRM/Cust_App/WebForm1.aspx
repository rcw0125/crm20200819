<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CRM.Cust_App.WebForm1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
     <script src="../Assets/js/My97DatePicker/WdatePicker.js"></script>
    <title>顾客满意度调查</title>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">

            <tr>
                <td style="width:50px; text-align:right">日期</td>
                <td style="width:125px;">
                    <input id="Start" type="text" style="width: 120px;" runat="server" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, maxDate: '#F{$dp.$D(\'End\')}' })" /></td>
                <td style="width:125px;"> <input id="End" runat="server" type="text" style="width: 120px;"  class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, minDate: '#F{$dp.$D(\'Start\')}' })" /></td>
               
                <td style="width:60px; text-align:right">
                   钢种类别
                </td>
                 <td style="width:150px;">
                     <select id="Select1" style="width:145px;">
                         <option>全部</option>

                     </select></td>
                <td>
                    <input id="Button1" type="button" value="查询" class="btn btn-primary btn-xs btn_w60" /></td>
            </tr>

        </table>
        <table class="table table-bordered table-hover">
            <thead>
            <tr>
                <th>操作</th>
                <th>类别</th>
                <th>客户单位</th>
                <th>直销/经销</th>
                <th>填表人</th>
                <th>联系电话</th>
                <th>提交时间</th>
                </tr>
                </thead>
            <tbody>
                <tr>
                    <td>查看</td>
                    <td>冷镦钢</td>
                    <td>北京中铁</td>
                     <td>经销</td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </tbody>
                </table>
        <div>分页</div>
    </form>
</body>
</html>

