<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roll_cust.aspx.cs" Inherits="CRM.WebForms.Report.roll_cust" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>客户库存查询</title>
    <uc1:ReptControl runat="server" ID="ReptControl" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 120px">
                    <asp:TextBox ID="txtstlgrd" runat="server" placeholder="批次号"></asp:TextBox></td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtspec" runat="server" placeholder="规格"></asp:TextBox></td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtconno" runat="server" placeholder="合同号"></asp:TextBox></td>
                <td style="width: 120px">
                    <asp:DropDownList ID="dropArea" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" /></td>
            </tr>
        </table>
        <table class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="450" id="table" style="white-space: nowrap;">
            <thead>
                <tr class="info">
                    <th>合计</th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th>
                        <asp:Literal ID="ltlqua" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltlsumwgt" runat="server"></asp:Literal></th>
                    <th></th>
                    <th></th>
                </tr>
                <tr>
                    <th data-sortable="true">序号</th>
                    <th data-sortable="true">物料编码</th>
                    <th data-sortable="true">物料名称</th>
                    <th data-sortable="true">区域</th>
                    <th data-sortable="true">批号</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">质量</th>
                    <th data-sortable="true">包装</th>
                    <th data-sortable="true">件数</th>
                    <th data-sortable="true">吨数</th>
                    <th data-sortable="true">生产日期</th>
                    <th data-sortable="true">合同号</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%#Container.ItemIndex+1 %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_DESC") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SALE_AREA") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_BZYQ") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"QUA") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_WGT") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_PRODUCE_DATE","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %></td>
                           
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </form>
</body>
</html>
