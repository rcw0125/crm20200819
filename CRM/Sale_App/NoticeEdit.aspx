<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeEdit.aspx.cs" Inherits="CRM.Sale_App.NoticeEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <!--king css-->
    <link rel="stylesheet" href="../kind/themes/default/default.css" />
    <link rel="stylesheet" href="../kind/plugins/code/prettify.css" />
    <script charset="utf-8" src="../kind/kindeditor.js"></script>
    <script charset="utf-8" src="../kind/lang/zh_CN.js"></script>
    <script charset="utf-8" src="../kind/plugins/code/prettify.js"></script>
    <script charset="utf-8" src="js_default.js"></script>

    <title>添加公告</title>
</head>
<body>
    <form id="form1" runat="server">
      
    <table class="table table-bordered">

      
            <tr>
                <td style="text-align:right; width:100px;">
                  分类
                </td>           
                <td><asp:DropDownList ID="dropClass" runat="server" CssClass="form-control input1"></asp:DropDownList></td>
                
            </tr>
            <tr>
                <td style="text-align:right;">
                  
                    标题
                </td>           
                <td>
                    <asp:TextBox ID="txtTitle" runat="server"  CssClass="form-control"></asp:TextBox></td>
            </tr>
         <tr>
                <td style="text-align:right;">
                  
                    内容
                </td>           
                <td>  <textarea id="content1" style=" height: 300px; visibility: hidden;"
                        runat="server" class="form-control"></textarea></td>
                
            </tr>
         <tr>
          <td style="text-align:right;">
                  
                  
                </td>           
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="提 交" OnClientClick="return Check();"  CssClass="btn btn-primary" OnClick="btnSave_Click" />
                     &nbsp; 
                    <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn btn-default" OnClick="btnBack_Click" />
                </td>
                
            </tr>
     
    </table>
        <script src="../Assets/js/jquery-2.0.3.min.js"></script>
        <script type="text/javascript">

            function Check() {
                var title = $.trim($("#txtTitle").val());
                if (title == "") {
                    alert("标题不能为空！");
                    return false;
                }
                return true;
            }
        </script>

        <asp:Literal ID="ltlID" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
