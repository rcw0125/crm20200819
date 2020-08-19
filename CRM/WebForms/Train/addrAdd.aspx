<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addrAdd.aspx.cs" Inherits="CRM.WebForms.Train.addrAdd" %>

<%@ Register Src="~/WebForms/Train/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>到货地点费用添加</title>
    <uc1:rollControl runat="server" ID="rollControl" />
    <script type="text/javascript">
        $(function () {

            $("#txtStart").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true

            });
            $("#txtEnd").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true

            })

            selectAll("input.qx1", "input.che1");

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 100%">
            <tr>
                <td style="width: 300px; vertical-align: top">
                    <table class="table table-bordered table-condensed">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtcode" placeholder="编码" runat="server" Width="100%"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtname" placeholder="名称" runat="server" Width="100%"></asp:TextBox></td>
                            <td>
                                <asp:Button ID="btncx" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btncx_Click" /></td>
                        </tr>
                    </table>
                    <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="400" id="table" style="white-space: nowrap;">
                        <thead>
                            <tr>

                                <th>
                                    <input id="cbxAll" type="checkbox" class="qx1" />全选/编码</th>
                                <th data-sortable="true">名称</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                    <tr>

                                        <td>
                                            <input id="cbxselect" runat="server" class="che1" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"PK_ADDRESS") %>' /><asp:Literal ID="ltlADDRCODE" Text='<%#DataBinder.Eval (Container.DataItem,"ADDRCODE") %>' runat="server"></asp:Literal></td>
                                        <td>
                                            <asp:Literal ID="ltlADDRNAME" Text='<%#DataBinder.Eval (Container.DataItem,"ADDRNAME") %>' runat="server"></asp:Literal><asp:Literal ID="ltlPK_AREACL" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"PK_AREACL") %>' Visible="false"></asp:Literal></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                        </tbody>
                    </table>
                </td>
                <td style="vertical-align: top">
                    <table class="table table-bordered table-condensed">
                        <tr>
                            <td style="width: 100px;">生效日期</td>
                            <td>
                                <input id="txtStart" type="text" style="width: 120px;" readonly="readonly" class="form-control Wdate" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>失效日期</td>
                            <td>
                                <input id="txtEnd" type="text" style="width: 120px;" readonly="readonly" class="form-control Wdate" runat="server" /></td>
                        </tr>
                       
                        <tr>
                            <td>发运方式</td>
                            <td>
                                <asp:DropDownList ID="dropfyfs" runat="server" Width="200"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>费用</td>
                            <td>
                                <asp:TextBox ID="txtprice" runat="server" CssClass="numJe"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td style="width: 100px;">&nbsp;</td>
                            <td>
                                <asp:Button ID="btnadd" CssClass="btn btn-primary btn-xs" runat="server" Text="保存" OnClick="btnadd_Click" />
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
        </table>
    </form>
</body>
</html>
