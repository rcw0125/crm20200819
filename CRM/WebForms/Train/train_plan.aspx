<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="train_plan.aspx.cs" Inherits="CRM.WebForms.Train.train_plan" %>

<%@ Register Src="~/WebForms/Train/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>火车计划号录入</title>
    <uc1:rollControl runat="server" ID="rollControl" />
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

        function openweb(index) {

            switch (index) {

                case 1:
                    var url = "train_plan_add.aspx";
                    _iframe(url, '1040', '500', '火运计划号录入');
                    break;
            }

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox ID="txtplancode" placeholder="计划号" Width="100%" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtdz" placeholder="到站" Width="100%" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtcust" placeholder="收货/订货单位" Width="100%" runat="server"></asp:TextBox></td>
                <td>类别</td>
                <td><asp:DropDownList ID="droptype" runat="server">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>线材</asp:ListItem>
                        <asp:ListItem>钢坯</asp:ListItem>
                        <asp:ListItem>水渣</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 50px;">日期</td>
                <td style="width: 110px;">
                    <input id="txtStart" type="text" style="width: 110px;" readonly="readonly" class="form-control Wdate" runat="server" />
                </td>
                <td style="width: 110px;">
                    <input id="txtEnd" runat="server" type="text" style="width: 110px;" readonly="readonly" class="form-control Wdate" /></td>

                <td>
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" />&nbsp;   
                     <input id="btnadd" type="button" class="btn  btn-success btn-xs" value="录入计划号" onclick="openweb(1);" />&nbsp;<asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-danger btn-xs" OnClientClick="return confirm('确定要删除吗？');" OnClick="btndel_Click" /></td>

            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="500" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th data-sortable="true">选择</th>
                    <th data-sortable="true">类型</th>
                    <th data-sortable="true">车数</th>
                    <th data-sortable="true">已发车数</th>
                    <th data-sortable="true">剩余车数</th>
                    <th data-sortable="true">到站</th>
                    <th data-sortable="true">到局</th>
                    <th data-sortable="true">计划号</th>
                    <th data-sortable="true">收货单位</th>
                    <th data-sortable="true">订货单位</th>
                    <th data-sortable="true">区域</th>
                    <th data-sortable="true">专用线</th>
                    <th data-sortable="true">提报人</th>
                    <th data-sortable="true">提报时间</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><input id="cbxselect" runat="server" class="che1" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' />
                                <%#Container.ItemIndex+1 %>
                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_FLAG") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_TRAIN_NUM") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"YFNUM") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"SYNUM") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STATION") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STATION_J") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_PLANNO") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUSTNAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUSTNO") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_AREA") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_REMARK") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EMPNAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_DATE","{0:yyy-MM-dd}") %></td>
                           
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
    </form>
</body>
</html>
