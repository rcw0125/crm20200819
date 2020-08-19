<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreInfo.aspx.cs" Inherits="CRM.Common.PreInfo" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>个人资料</title>

    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/jquery-2.0.3.min.js"></script>
    <script src="../Assets/js/bootstrap.min.js"></script>
    <script>
        $(function () {
            $('#myTab li:eq(0) a').tab('show');
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <ul id="myTab" class="nav nav-tabs">
            <li class="active"><a href="#tab1" data-toggle="tab">个人信息</a> </li>
            <li><a href="#tab2" data-toggle="tab">公司资料</a></li>
            <li><a href="#tab3" data-toggle="tab">密码修改</a></li>
        </ul>
        <div id="myTabContent" class="tab-content">
            <div class="tab-pane fade in active" id="tab1" style="margin-top: 10px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table class="table">
                            <tr>
                                <td style="width: 150px; text-align: right">余额(<asp:Literal ID="ltltime" runat="server"></asp:Literal>)</td>
                                <td>
                                    <input type="text" runat="server" id="txtMoney" class="form-control" disabled="disabled"></td>
                            </tr>
                            <tr>
                                <td style="text-align: right">真实姓名</td>
                                <td>
                                    <input type="text" runat="server" id="txtName" class="form-control" placeholder="必填" maxlength="50"></td>
                            </tr>
                            <tr>
                                <td style="text-align: right">固定电话</td>
                                <td>
                                    <input type="text" runat="server" id="txtTel" class="form-control" maxlength="10"></td>
                            </tr>
                            <tr>
                                <td style="text-align: right">手机号码</td>
                                <td>
                                    <input type="text" runat="server" id="txtPhone" class="form-control" maxlength="11" placeholder="必填" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: right">传真</td>
                                <td>
                                    <input type="text" runat="server" id="txtFax" class="form-control" maxlength="10"></td>
                            </tr>
                            <tr>
                                <td style="text-align: right">邮箱</td>
                                <td>
                                    <input type="text" runat="server" id="txtEMail" class="form-control" placeholder="必填" maxlength="50"></td>
                            </tr>
                            <tr>
                                <td style="text-align: right"></td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="保 存" CssClass="btn btn-primary btn-sm" OnClick="btnSave_Click" OnClientClick="return check();" />
                                </td>
                            </tr>

                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="tab-pane fade " id="tab2" style="margin-top: 10px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table class=" table">
                            <tr>
                                <td style="width: 150px; text-align: right">厂家名称</td>
                                <td>
                                    <asp:TextBox ID="txtC_CJNAME" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">使用钢种</td>
                                <td>
                                    <asp:TextBox ID="txtC_STL_GRD" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">法人代表</td>
                                <td>
                                    <asp:TextBox ID="txtC_LEGALREPRES" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">采购决策人员姓名</td>
                                <td>
                                    <asp:TextBox ID="txtC_CGJCR" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">采购决策人员职务</td>
                                <td>
                                    <asp:TextBox ID="txtC_JOB" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">采购决策人员电话</td>
                                <td>
                                    <asp:TextBox ID="txtC_JCTEL" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">区域</td>
                                <td>
                                    <asp:DropDownList ID="dropArea" runat="server" class="form-control" Width="200px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">客户经理</td>
                                <td>
                                    <asp:TextBox ID="txtC_MANAGER" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">具体地址</td>
                                <td>
                                    <asp:TextBox ID="txtC_ADDRESS" runat="server" Width="500px" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">厂家简介</td>
                                <td>
                                    <asp:TextBox ID="txtC_CJINTRO" runat="server" Height="50px" TextMode="MultiLine" Width="500px" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right"></td>
                                <td>
                                    <asp:Button ID="btnSave2" CssClass="btn btn-primary btn-sm" runat="server" Text="保存" OnClick="btnSave2_Click" /></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>



            <div class="tab-pane fade" id="tab3" style="margin-top: 10px">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>


                        <table class=" table">
                            <tr>
                                <td style="width: 100px; text-align: right">用户名</td>
                                <td>
                                    <input type="text" class="form-control" style="width: 300px;" readonly="readonly" runat="server" id="txtUserName"></td>
                            </tr>
                            <tr>
                                <td style="width: 100px; text-align: right">新密码</td>
                                <td>
                                    <input type="password" class="form-control" style="width: 300px;" placeholder="必填" runat="server" id="txtPwd"></td>
                            </tr>
                            <tr>
                                <td style="width: 100px; text-align: right"></td>
                                <td>
                                    <asp:Button ID="btnSavePwd" runat="server" Text="保 存" OnClientClick="return check5();" CssClass="btn btn-primary btn-sm" OnClick="btnSavePwd_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>



        <input id="hCustID" type="hidden" runat="server" />
        <asp:Literal ID="ltlUserID" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlCustID" Visible="false" runat="server"></asp:Literal>

        <script type="text/javascript">

            function isPone(pone) {
                var myreg = /^[1][3,4,5,7,8][0-9]{9}$/;
                if (!myreg.test(pone)) {
                    return false;
                } else {
                    return true;
                }
            }

            function isMail() {
                var temp = $.trim($("#txtEMail").val());                //对电子邮件的验证   
                var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
                if (!myreg.test(temp.value)) {
                    return false;
                }
                else {
                    return true;
                }
            }

            function check() {

                if ($.trim($("#txtName").val()) == '') {
                    alert("姓名不能为空");
                    return false;
                }

                if ($.trim($("#txtPhone").val()) == '') {
                    alert("手机号码不能为空");
                    return false;
                }

                if ($.trim($("#txtEMail").val()) == '') {
                    alert("邮箱不能为空");
                    return false;
                }

                if (isPone($.trim($("#txtPhone").val())) == false) {
                    alert("请输入有效号码");
                    return false;
                }
                return true;
            }

            function check5() {
                if ($.trim($("#txtPwd").val()) == '') {
                    alert("新密码不能为空");
                    return false;
                }
                return true;
            }


        </script>
    </form>
</body>
</html>
