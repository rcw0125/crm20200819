<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyConsult_Add.aspx.cs" Inherits="CRM.Cust_App.MyConsult_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <title>技术咨询</title>
</head>
<body>
    <form id="form1" runat="server">
          <table class="table table-bordered">
              <tr>
                  <td style="width:80px; text-align:right">问题</td>
                  <td>
                      <asp:DropDownList ID="dropQuest" runat="server"></asp:DropDownList></td>
                  <td style="text-align:right">产品</td>
                  <td>
                      <input id="txt_STL_GRD" type="text" style="width:99%" runat="server" />
                  </td>
                  <td style="text-align:right">客户</td>
                  <td><input id="txtCust" type="text" style="width:99%" runat="server" /></td>
              </tr>
              <tr>
                  <td style="text-align:right">用途及工艺</td>
                  <td colspan="5">
                      <p>
                      <textarea id="txtUseDesc" style=" height:100px; width:99%" maxlength="200" runat="server" cols="20" name="S1" rows="1"></textarea>
                          </p>
                      <p>内容上限为200字符</p>
                  </td>
                 
              </tr>
              <tr>
                 
                  <td style="text-align:right">问题描述</td>
                 <td colspan="5">
                     <p>
                     <textarea id="txtRemark" style=" height:100px; width:99%" maxlength="500" runat="server" ></textarea>
                        </p>
                     <p>
                         内容上限为500字符
                     </p>
                         </td>
                 
              </tr>
               <tr>
                  <td>&nbsp;</td>
                 <td colspan="5">
                     
                     <asp:Button ID="btnSave" runat="server" Text="提交" CssClass="btn btn-primary btn-xs btn_w60" OnClick="btnSave_Click" />
                 </td>
                 
              </tr>
           </table>
        <asp:Literal ID="ltlUserID" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlUserName" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlCustNo"  Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
