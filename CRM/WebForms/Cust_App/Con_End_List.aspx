<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Con_End_List.aspx.cs" Inherits="CRM.WebForms.Cust_App.Con_End_List" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>合同终止确认</title>
    <uc1:common runat="server" ID="common" />
    <script type="text/javascript">
        $(function () {

            $("#txtStart").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true

            }).on("changeDate", function (ev) {
                $("#txtEnd").datetimepicker('setStartDate', $("#txtStart").val())
            });
            $("#txtEnd").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true
            }).on("changeDate", function (ev) {
                $("#txtStart").datetimepicker('setEndDate', $("#txtEnd").val())
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">

            <tr>
               
                <td style="width: 120px">
                    <asp:TextBox ID="txtconno" placeholder="合同号" runat="server"></asp:TextBox></td>
                <td style="width: 60px">状态</td>
                <td style="width: 100px">
                    <asp:DropDownList ID="dropflag" runat="server">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem Value="0">未确认</asp:ListItem>
                        <asp:ListItem Value="1">已确认</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 80px">日期</td>
                <td style="width: 110px;">
                    <input id="txtStart" type="text" style="width: 110px;" readonly="readonly" class="form-control Wdate" runat="server" />
                </td>
                <td style="width: 110px;">
                    <input id="txtEnd" runat="server" type="text" style="width: 110px;" readonly="readonly" class="form-control Wdate" /></td>
                <td>
                    <asp:Button ID="btncx" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btncx_Click"  />&nbsp;
                    <asp:Button ID="btnendcon" runat="server" Text="合同终止确认" CssClass="btn btn-danger btn-xs"  OnClientClick="return confirm('确定要合同终止操作吗？');" OnClick="btnendcon_Click" /></td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="500" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th data-sortable="true">选择</th>
                    <th data-sortable="true">合同号</th>
                    <th data-sortable="true">数量</th>
                    <th data-sortable="true">已履行</th>
                    <th data-sortable="true">待履行</th>
                    <th data-sortable="true">客户名称</th>
                    <th data-sortable="true">区域</th>
                    <th data-sortable="true">状态</th>
                    <th data-sortable="true">备注说明</th>
                    <th data-sortable="true">发起时间</th>
                    <th data-sortable="true">发起人</th>
                   
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><input id="cbxselect" runat="server" class="che1" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' />
                                <%#Container.ItemIndex+1 %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CONNO") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_WGT") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"YLXWGT") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"DLXWGT") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUSTNAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_AREA") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_FLAG2") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_REMARK") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_SALEDT") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SALEEMPID") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
    </form>
</body>
</html>
