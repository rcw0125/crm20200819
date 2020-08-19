<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CRM.Cust_App.WebForm1" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Assets/js/jquery-1.10.2.min.js"></script>
    <script src="../../Assets/js/bootstrap.min.js"></script>
    <script src="../../Assets/js/jquery.dragsort-0.5.2.min.js"></script>
    <style>
        #field_list_table tr, th, td {
            text-align: center;
            height: 4.5em;
        }

        #field_list_table {
            margin-bottom: 0px;
            border-collapse: collapse;
        }
    </style>
</head>
<body>

    <div class="btn-group">
   <button type="button" class="btn btn-primary">原始</button>
   <button type="button" class="btn btn-primary dropdown-toggle" 
      data-toggle="dropdown">
      <span class="caret"></span>
      <span class="sr-only">切换下拉菜单</span>
   </button>
   <ul class="dropdown-menu" role="menu">
      <li><a href="#">功能</a></li>
      <li><a href="#">另一个功能</a></li>
      <li><a href="#">其他</a></li>
      <li class="divider"></li>
      <li><a href="#">分离的链接</a></li>
   </ul>
</div>


    <input id="Button1" type="button" value="button" onclick="tj();" />
    <table id="table1">

        <tbody>

            <tr>
                <td>
                    <input id="cbxselect" value="1" type="checkbox" name="1" /></td>
                <td>a</td>
            </tr>
            <tr>
                <td>
                    <input id="cbxselect1" value="2" type="checkbox" name="1" /></td>
                <td>b</td>
            </tr>
            <tr>
                <td>3</td>
                <td>b</td>
            </tr>
        </tbody>
    </table>
    <script>
        $(function () {
            var leng = $("#table1 tbody tr").length;
            for (var i = 0; i < leng; i++) {
                var cbxselect = $("#table1 tbody tr").eq(i).children().find("input[type=checkbox]");
                // $(cbxselect).attr("disabled", true);
            }

        });

        function tj() {
            var number = '';
            $('input:checkbox[name=1]:checked').each(function () { 
                var arr = $(this).parent().parent().children().eq(1).html();
            })           
        }
    </script>
</body>
</html>
