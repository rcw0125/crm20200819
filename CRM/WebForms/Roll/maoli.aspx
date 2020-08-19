<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="maoli.aspx.cs" Inherits="CRM.WebForms.Roll.maoli" %>

<%@ Register Src="~/WebForms/Roll/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>低毛利限量指标</title>
    <uc1:rollControl runat="server" ID="rollControl" />

    <script type="text/javascript">
        $(function () {

            $("#txtStart").datetimepicker({
                format: 'yyyy-mm',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true,
                todayBtn: true
            });

            selectAll("input.qx1", "input.che1");
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 100px;">
                    <asp:TextBox runat="server" placeholder="物料组名称" ID="txtmatname" Width="100"></asp:TextBox></td>
                <td style="width: 80px;">销售组织</td>
                <td style="width: 150px;">
                    <asp:DropDownList ID="dropsaleorg" runat="server" Width="100%"></asp:DropDownList></td>
                <td style="width: 80px">月份</td>
                <td style="width: 110px">
                    <input type="text" class="form-control Wdate" runat="server" id="txtStart" style="width: 100px" /></td>
                <td>
                    <asp:Button ID="btnCX" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btnCX_Click" />
                    &nbsp;
                    <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="btn btn-primary btn-xs" OnClick="btnsave_Click" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="500" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th>
                        <input id="cbxAll" type="checkbox" class="qx1" />选择</th>
                    <th>月份</th>
                    <th>物料组编码</th>
                    <th>物料组名称</th>
                    <th>品种</th>
                    <th>规格最小值</th>
                    <th>规格最大值</th>
                    <th>销售组织</th>
                    <th>限量</th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input id="cbxselect" runat="server" class="che1" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' />
                                <%#Container.ItemIndex+1 %></td>
                            <td>
                                <asp:Literal ID="ltlC_DAY" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"D_MONTH","{0:yyy-MM}") %>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlC_MAT_GROUP_CODE" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_GROUP_CODE") %>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlC_MAT_GROUP_NAME" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_GROUP_NAME") %>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlC_PROD_KIND" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_PROD_KIND") %>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlC_SPEC_MIN" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC_MIN") %>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlC_SPEC_MAX" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC_MAX") %>'></asp:Literal></td>
                           
                            <td>
                                <asp:Literal ID="ltlC_SALESORG" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_SALESORG") %>'></asp:Literal></td>
                            <td>
                                <asp:TextBox ID="txtwgt" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT") %>'></asp:TextBox></td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>

    </form>
</body>
</html>
