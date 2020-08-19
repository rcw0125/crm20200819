<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cust_Book.aspx.cs" Inherits="CRM.WebForms.Sale_App.Cust_Book" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>走访/来访交流台账</title>
    <uc1:common2 runat="server" ID="common2" />
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

            selectAll("input.qx1", "input.che1");
        });

        function openweb() {

            var url = "Cust_BookAdd.aspx";
            _iframe(url, '800', '500', '档案录入');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 150px;">
                    <asp:TextBox ID="txtcust" placeholder="客户名称" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td style="width: 150px;">
                    <asp:TextBox ID="txtstlgrd" placeholder="钢种" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td style="width: 50px;">日期</td>
                <td style="width: 110px;">
                    <input id="txtStart" type="text" style="width: 110px;" readonly="readonly" class="form-control Wdate" runat="server" />
                </td>
                <td style="width: 110px;">
                    <input id="txtEnd" runat="server" type="text" style="width: 110px;" readonly="readonly" class="form-control Wdate" /></td>

                <td>
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" />
                    &nbsp;
                     <input id="btnadd" type="button" class="btn  btn-success btn-xs" value="档案录入" onclick="openweb();" />

                    &nbsp;
                    <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn  btn-success btn-xs" OnClick="btnExport_Click" />

                    &nbsp;
                    <asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-danger btn-xs" OnClientClick="return confirm('确定要删除吗？');" OnClick="btndel_Click" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="500" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th>
                        <input id="cbxAll" type="checkbox" class="qx1" />全选</th>
                    <th data-sortable="true">日期</th>
                    <th data-sortable="true">类型</th>
                    <th data-sortable="true">客户名称</th>
                    <th data-sortable="true">区域</th>
                    <th data-sortable="true">区域经理</th>
                    <th data-sortable="true">人员</th>
                    <th data-sortable="true">电话</th>
                    <th data-sortable="true">参会客户</th>
                    <th data-sortable="true">参会邢钢</th>
                    <th data-sortable="true">主要交流内容</th>
                    <th data-sortable="true">需解决问题</th>
                    <th data-sortable="true">遗留问题</th>
                    <th data-sortable="true">备注</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">用途</th>
                    <th data-sortable="true">交流地点</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input id="cbxselect" runat="server" class="che1" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' /></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"D_ZF_DT","{0:yyy-MM-dd}") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"N_TYPE") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_CUST_NAME") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_AREA") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_CUST_MANAGE") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_CUST_EMP") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_CUST_EMP_TEL") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_MEETING_CUST") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_MEETING_XG") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_MAIN_CONTENT") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_NEED_S_Q") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_LEAVE_Q") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_REMARK") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_STL_GRD") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_PRO_USE") %></td>
                            <td><%#DataBinder.Eval(Container.DataItem,"C_SITE") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
    </form>
</body>
</html>
