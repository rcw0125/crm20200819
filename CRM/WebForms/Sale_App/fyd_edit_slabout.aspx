<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fyd_edit_slabout.aspx.cs" Inherits="CRM.WebForms.Sale_App.fyd_edit_slabout" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>钢坯销售出库</title>
    <uc1:common2 runat="server" ID="common2" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-hover  table-condensed">
            <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary btn-xs" OnClientClick="_loading(1);" OnClick="btnSave_Click" />
                    &nbsp;
                  <asp:Button ID="btnNC" runat="server" Text="销售出库导入NC" CssClass="btn btn-primary btn-xs" OnClientClick="_loading(1);" OnClick="btnNC_Click" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-hover  table-condensed">
            <thead>
                <tr class="info">
                    <th>合计</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>
                        <asp:Literal ID="ltlsumwgt" runat="server"></asp:Literal>
                    </th>
                    <th>&nbsp;</th>
                </tr>
                <tr>
                    <th>发运单号</th>
                    <th>仓库</th>
                    <th>批次</th>
                    <th>炉号</th>
                    <th>物料编码</th>
                    <th>物料名称</th>
                    <th>钢种</th>
                    <th>规格</th>
                    <th>件数</th>
                    <th>称重</th>
                    <th>出库时间</th>
                </tr>
            </thead>

            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Literal ID="ltlID" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' runat="server"></asp:Literal>
                                <%#DataBinder.Eval (Container.DataItem,"C_DISPATCH_ID")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SEND_STOCK")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STOVE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_NUM")%></td>
                            <td>
                            <asp:TextBox ID="txtN_JZ" runat="server" CssClass="numJe" Text='<%#DataBinder.Eval (Container.DataItem,"N_JZ")%>'></asp:TextBox> </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CKSJ","{0:yyy-MM-dd}")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
        <asp:Literal ID="ltlfyd" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlempName" Visible="false" runat="server"></asp:Literal>

    </form>
</body>
</html>
