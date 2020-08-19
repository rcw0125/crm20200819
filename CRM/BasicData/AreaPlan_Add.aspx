<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaPlan_Add.aspx.cs" Inherits="CRM.BasicData.AreaPlan_Add" %>

<%@ Register Src="~/BasicData/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>添加区域计划量</title>
    <uc1:common runat="server" ID="common" />

    <script src="../WebForms/JsDate.js"></script>
</head>

<body>

    <form runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 60px">时间</td>
                <td style="width: 120px;">
                    <input id="txtStart" type="text" class="form-control  Wdate" runat="server" style="width: 120px;"></td>
                <td style="width: 120px;">
                    <input id="txtEnd" type="text" class="form-control  Wdate" runat="server" style="width: 120px;"></td>
                <td>
                    <asp:Button ID="btnCx" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btnCx_Click" />
                    &nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="生成签单指标" CssClass="btn btn-primary btn-xs" OnClick="btnSave_Click" />

                    &nbsp;<asp:Button ID="btnEdit" runat="server" Text="修改签单指标" CssClass="btn btn-primary btn-xs" OnClick="btnEdit_Click" />
                    &nbsp;<asp:Button ID="btndel" runat="server" Text="删除指标" CssClass="btn btn-danger btn-xs"  OnClientClick="return confirm('确定要删除吗？');" OnClick="btndel_Click" />
                </td>
            </tr>

        </table>

        <table class="table table-bordered table-condensed">
            <thead>
                <tr>

                    <th>
                        <input id="cbxAll" type="checkbox" class="qx1" />区域</th>
                    <th>普碳指标</th>
                    <th>品种指标</th>
                    <th>精品指标</th>
                    <th>监控指标</th>
                    <th>开始时间</th>
                    <th>截至时间</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input id="cbxID" style="width: 15px;" class="che1" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' type="checkbox" />
                                <asp:Literal ID="ltlArea" Text='<%#DataBinder.Eval (Container.DataItem,"AREA") %>' runat="server"></asp:Literal></td>
                            <td>
                                <asp:TextBox ID="txtPTZB" CssClass="numJe" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT_PT") %>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtPZZB" CssClass="numJe" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT_GS") %>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtJPZB" CssClass="numJe" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT_JP") %>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtJKZB" CssClass="numJe" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT_JK") %>'></asp:TextBox></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_START","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_END","{0:yyy-MM-dd}") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>

        </table>

        <asp:Literal ID="ltlempID" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlempName" Visible="false" runat="server"></asp:Literal>
        <script type="text/javascript">
            selectAll("input.qx1", "input.che1");
        </script>
    </form>
</body>
</html>


