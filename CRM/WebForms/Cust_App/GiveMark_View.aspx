<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GiveMark_View.aspx.cs" Inherits="CRM.WebForms.Cust_App.GiveMark_View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>供应商综合评分查看</title>
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Assets/css/common.css" rel="stylesheet" />
    <script src="../../Assets/js/My97DatePicker/WdatePicker.js"></script>
    <script src="../../Assets/js/jquery-2.0.3.min.js"></script>
    <script src="../../Assets/js/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <tr>
                <td colspan="5">
                    <h4 style="text-align: center">
                        <asp:Literal ID="ltltitle" runat="server"></asp:Literal></h4>
                </td>
            </tr>
            <tr>
                <td>供应商名称：邢台钢铁有限责任公司</td>
                <td class="right">供应材料：</td>
                <td>
                    <asp:Literal ID="ltlstlgrd" runat="server"></asp:Literal>
                </td>
                <td  class="right">时间：</td>
                <td>
                    <asp:Literal ID="ltltime" runat="server"></asp:Literal></td>

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
                            <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                    <tr>

                                        <td>

                                            <%#DataBinder.Eval (Container.DataItem,"C_NAME")%>(<%#DataBinder.Eval (Container.DataItem,"N_SCORE")%>)</td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_FLAG")%></td>
                                        <td>
                                            <%#DataBinder.Eval (Container.DataItem,"defen")%>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>


                        </tbody>

                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5">评价：<asp:Literal ID="ltlremark" runat="server"></asp:Literal>


                </td>
            </tr>
            <tr>
                <td colspan="5" class="text-center">

                    <a class="btn btn-default btn-sm" href="MyGiveMark.aspx">返回</a></td>
            </tr>

        </table>

    </form>
</body>
</html>
