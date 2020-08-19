<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_ZTFYD.aspx.cs" Inherits="CRM.WebForms.Roll._ZTFYD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>发运在途量查询</title>
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Assets/css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th>发运单</th>
                    <th>客户名称</th>
                    <th>销售区域</th>
                    <th>物料编码</th>
                    <th>钢种</th>
                    <th>规格</th>
                    <th>已发运数量</th>
                    <th>库存量</th>
                    <th>可发运数量</th>
                    <th>执行标准</th>
                    <th>自由项1</th>
                    <th>自由项2</th>
                    <th>包装要求</th>
                    <th>质量等级</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%#DataBinder.Eval (Container.DataItem,"c_id")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ORGO_CUST")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"c_area")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"c_mat_code")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"c_stl_grd")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"c_spec")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"n_fywgt")%></td>
                            <td></td>
                            <td></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"c_std_code")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"c_free_term")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"c_free_term2")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"c_pack")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
            <tfoot>
                <tr class="info">
                    <td>合计</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Literal ID="ltlsumwgt" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:Literal ID="ltlkcwgt" runat="server"></asp:Literal>
                    </td>
                    <td><asp:Literal ID="ltlkfwgt" runat="server"></asp:Literal></td>
                    <td>&nbsp;</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </tfoot>

        </table>
        <asp:Literal ID="ltlmatcode" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlstdcode" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlarea" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlpack" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltllev" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlcust" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlconno" runat="server" Visible="false"></asp:Literal>
    </form>
</body>
</html>
