<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Con_Check.aspx.cs" Inherits="CRM.Sale_App.Con_Check" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <title>合同审批</title>
</head>
<body>
    <form id="form1" runat="server">
        
       
       <table class="table table-bordered">
           <tr>
               <td style="width:80px;">标题</td>
               <td>
                   <asp:TextBox ID="txtTitle" runat="server" Width="500px"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>说明</td>
               <td>
                   <asp:TextBox ID="txtContent" runat="server" Height="100px" TextMode="MultiLine" Width="500px"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>合同号</td>
               <td><asp:Literal ID="ltlConN0" runat="server"></asp:Literal></td>
           </tr>
           <tr>
               <td>审批流</td>
               <td>
                            <asp:DropDownList ID="dropFlow" runat="server" CssClass="inputW"></asp:DropDownList></td>
           </tr>
           <tr>
               <td>&nbsp;</td>
               <td >
                   <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-xs" OnClick="btnSave_Click" Text="提 交" OnClientClick="return Check();" /> &nbsp;&nbsp; <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn btn-default btn-xs" OnClick="btnBack_Click" />
               </td>
           </tr>
       </table>
        <script src="../Assets/js/jquery-1.10.2.min.js"></script>
        <script type="text/javascript">
            function Check() {
                var title = $.trim($("#txtTitle").val());
                alert(title);
                if (title =='') {
                    alert("标题不能为空");
                    return false;
                }
                return true;
            }
        </script>
        <asp:Literal ID="ltlUserID" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
