<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SlabMain.aspx.cs" Inherits="CRM.WebForms.Report.SlabMain" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>商品库存坯</title>
    <uc1:ReptControl runat="server" ID="ReptControl" />
    <script src="../JsDate.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>

                <td>
                    <input type="text" id="txtmatcode" placeholder="物料编码" runat="server" />
                </td>

                <td>
                    <input type="text" id="txtstlgrd" placeholder="钢种" runat="server" /></td>

                <td>
                    <input type="text" id="txtspec" placeholder="规格" runat="server" /></td>
                <td>仓库编码</td>
                <td>
                    <asp:DropDownList ID="dropSlabCK" runat="server">
                        <asp:ListItem>591</asp:ListItem>
                        <asp:ListItem>592</asp:ListItem>
                        <asp:ListItem>593</asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td>入库时间</td>
                <td>
                    <input type="text" class="form-control Wdate" readonly="readonly" id="txtStart" runat="server" /></td>
                <td>
                    <input type="text" class="form-control Wdate" readonly="readonly" id="txtEnd" runat="server" /></td>
                <td>
                    <asp:Button ID="btnCX" runat="server" Text="查询"  CssClass="btn btn-primary btn-xs" OnClick="btnCX_Click"/>
                    &nbsp;
                    <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn btn-success btn-xs" OnClick="btnExport_Click" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered  table-hover table-condensed" data-toggle="table" data-height="450" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th data-sortable="true">仓库</th>
                    <th data-sortable="true">库位</th>
                    <th data-sortable="true">批号</th>
                    <th data-sortable="true">炉号</th>
                    <th data-sortable="true">物料编码</th>
                    <th data-sortable="true">物料名称</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">长度</th>
                    <th data-sortable="true">重量(吨)</th>
                    <th data-sortable="true">支数</th>
                    <th data-sortable="true">执行标准</th>
                    <th data-sortable="true">自由项1</th>
                    <th data-sortable="true">自由项2</th>
                    <th data-sortable="true">质量等级</th>
                    <th data-sortable="true">入库时间</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SLABWH_CODE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SLABWH_LOC_CODE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STOVE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_LEN") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"SUMWGT") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"SUMQUA") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ZYX1") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ZYX2") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_WE_DATE") %></td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
    </form>
</body>
</html>
