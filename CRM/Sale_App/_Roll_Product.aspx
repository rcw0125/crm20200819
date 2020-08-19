<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_Roll_Product.aspx.cs" Inherits="CRM.Sale_App._Roll_Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <title>线材库</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dv_search">
            <ul>
                <li>
                    <asp:Button ID="btnSave" runat="server" Text="提交" CssClass="btn btn-primary btn-xs" OnClientClick="return confirm('确定挂单吗?'); " OnClick="btnSave_Click" />
                </li>

            </ul>
        </div>
        <div>
            <table class="table table-bordered table-hover" style="white-space: nowrap;">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>库位编号</th>                       
                        <th>炉号</th>
                        <th>批号</th>
                        <th>钩号</th>
                        <th>钢种</th>
                        <th>规格</th>
                        <th>执行标准</th>
                        <th>打牌重量</th>
                        <th>打牌时间</th>
                        <th>质量等级</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                <input id="chkID" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' runat="server" />
                                    <asp:Literal ID="ltlOrderNo" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"C_ORDER_NO") %>' runat="server"></asp:Literal>
                                </td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_LOC_CODE") %></td>      
                                <td><%#DataBinder.Eval (Container.DataItem,"C_STOVE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_TICK_NO") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %></td>
                                <td> <asp:Literal ID="ltlWGT" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT") %>' runat="server"></asp:Literal></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"D_DP_DT") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_BP") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </tbody>
            </table>
            <asp:Literal ID="ltlCustID" Visible="false" runat="server"></asp:Literal>
            <asp:Literal ID="ltlOrderNo" Visible="false" runat="server"></asp:Literal>
            <asp:Literal ID="ltlConNo" Visible="false" runat="server"></asp:Literal>
            <asp:Literal ID="ltlType" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
