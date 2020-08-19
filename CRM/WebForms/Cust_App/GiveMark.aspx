<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GiveMark.aspx.cs" Inherits="CRM.WebForms.Cust_App.GiveMark" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>客户评分</title>
    <uc1:common runat="server" ID="common" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <tr>
                <td colspan="5">
                    <h4 style="text-align: center">供应商综合评分表</h4>
                </td>
            </tr>
            <tr>
                <td>供应商名称：邢台钢铁有限责任公司</td>
                <td class="right">供应材料：</td>
                <td>
                    <asp:TextBox ID="txtgrd" runat="server" Width="85%" Enabled="False"></asp:TextBox>&nbsp; 
                   &nbsp;
                    <a href="javascript:void(0);" onclick="openWeb(1);"><span class="glyphicon glyphicon-search"></span></a></td>
               

            </tr>
            <tr>
                <td colspan="5">

                    <table class="table table-bordered table-hover">
                        <thead>
                            <tr>

                                <th>项目</th>
                                <th style="width: 100px;">分类</th>
                                <th>打分</th>

                            </tr>
                        </thead>

                        <tbody>
                            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
                                <ItemTemplate>
                                    <tr>

                                        <td>
                                            <asp:Literal ID="ltlID" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' runat="server"></asp:Literal>

                                            <%#DataBinder.Eval (Container.DataItem,"C_NAME")%>(<asp:Literal ID="ltlscore" Text='<%#DataBinder.Eval (Container.DataItem,"N_SCORE")%>' runat="server"></asp:Literal>分)</td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_FLAG")%></td>

                                        <td>
                                            <div class="form-group">
                                                <asp:DropDownList ID="dropNum" runat="server" CssClass="form-control" Width="80px" Height="30px"></asp:DropDownList>
                                            </div>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>

                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5">

                    <asp:TextBox ID="txtremark" placeholder="请给予评价" runat="server" Height="40px" TextMode="MultiLine" Width="100%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td colspan="5" class="text-center">
                    <asp:Button ID="btn_save" runat="server" Text="提交" CssClass="btn btn-primary btn-sm" OnClick="btn_save_Click" OnClientClick="return check();" />
                    &nbsp;
                    <a class="btn btn-default btn-sm" href="MyGiveMark.aspx">返回</a></td>
            </tr>

        </table>
        <asp:Literal ID="ltluserID" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltluserName" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlCustNo" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlCustName" Visible="false" runat="server"></asp:Literal>
        <input id="horderNO" runat="server" type="hidden" />
        <input id="hidgrd" runat="server" type="hidden" />
        <script src="../../Assets/js/jquery-2.0.3.min.js"></script>
        <script src="../../Assets/js/common.js"></script>
        <script type="text/javascript">

            function openWeb(index) {
                switch (index) {

                    case 1:
                         _iframe('../../Common/_CustOrder.aspx', '800', '450', '历史签单');
                        break;
                }
            }

            function SetOrder(orderNO, stlGrd) {

                $("#txtgrd").val(stlGrd);
                $("#hidgrd").val(stlGrd);
                $("#horderNO").val(orderNO);
                close();
            }

            function check() {
                if ($.trim($("#txtgrd").val()) == '') {
                    alert("请选择产品");
                    return false;
                }
                return true;

            }
        </script>
    </form>
</body>
</html>
