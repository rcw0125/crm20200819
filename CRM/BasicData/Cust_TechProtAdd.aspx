<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cust_TechProtAdd.aspx.cs" Inherits="CRM.BasicData.Cust_TechProtAdd" %>

<%@ Register Src="~/BasicData/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>客户协议添加</title>
    <uc1:common runat="server" ID="common" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="table table-bordered">

                    <tr>
                        <td class="right">钢种</td>
                        <td>
                            <input id="txtstlgrd" runat="server" readonly="readonly" placeholder="必选" type="text" style="width: 50%" />
                            <a href="javascript:void(0);" onclick='_iframe("../../Common/_StrGrd.aspx", "600", "400", "钢种");'><span class="glyphicon glyphicon-search"></span></a>
                        </td>
                    </tr>
                    <tr>
                        <td class="right">执行标准</td>
                        <td>
                            <asp:DropDownList ID="dropstd" runat="server" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="dropstd_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="right">自由项1</td>
                        <td>
                            <asp:DropDownList ID="dropzyx1" runat="server" Width="50%">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td class="right">自由项2</td>
                        <td>
                            <asp:DropDownList ID="dropzyx2" runat="server" Width="50%">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td class="right">质证书</td>
                        <td>
                            <asp:DropDownList ID="dropzzs" runat="server" Width="50%">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px;" class="right">客户名称</td>
                        <td>
                            <input id="txtcustname" runat="server" readonly="readonly" type="text" style="width: 50%" />

                            <a href="javascript:void(0);" onclick='_iframe("../../Common/_CustList.aspx?flag=2", "720", "350", "客户");'><span class="glyphicon glyphicon-search"></span></a></td>
                    </tr>
                    <tr>
                        <td class="right">客户编码</td>
                        <td>
                            <input id="txtcustno" runat="server" readonly="readonly"  type="text" style="width: 100px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="right">客户协议</td>
                        <td>
                            <asp:TextBox ID="txtcust_tech_prot"   runat="server" Width="50%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right">备注</td>
                        <td>
                            <asp:TextBox ID="txtremark" runat="server" Width="50%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right">&nbsp;</td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="保存" OnClientClick="return CheckInof();" CssClass="btn  btn-primary btn-sm" OnClick="btnSave_Click" />&nbsp;<a href="Cust_TechProt.aspx" class="btn  btn-default btn-sm">返回</a>
                        </td>
                    </tr>
                </table>
                <asp:ImageButton ID="imgbtnJz" runat="server" OnClick="imgbtnJz_Click" ImageUrl="~/Assets/images/btntm.gif" Height="1px" Width="1px" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Literal ID="ltlempid" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlempname" Visible="false" runat="server"></asp:Literal>
        <script src="../Assets/js/jquery-2.0.3.min.js"></script>
        <script src="../Assets/js/common.js"></script>
        <script type="text/javascript">
            function SetOT(id, name, code) {
                $("#txtcustname").val(name);
                $("#txtcustno").val(code);
                close();
            }
            function SetStlGrd(str) {
                $("#txtstlgrd").val(str);
                $("#imgbtnJz").click();
                close();
            }
            function CheckInof() {

                if ($.trim($("#txtstlgrd").val()) == "") {
                    alert("请选择钢种");
                    return false;
                }
                 if ($.trim($("#dropstd").val()) == "") {
                    alert("请选择执行标准");
                    return false;
                }
                if ($.trim($("#dropzyx1").val()) == "") {
                    alert("请选择自由项1");
                    return false;
                }
                 if ($.trim($("#dropzyx2").val()) == "") {
                    alert("请选择自由项2");
                    return false;
                }
                return true;
            }
        </script>
    </form>
</body>
</html>
