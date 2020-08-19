<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="train_plan_view.aspx.cs" Inherits="CRM.WebForms.Train.train_plan_view" %>

<%@ Register Src="~/WebForms/Train/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>火车计划号查询</title>
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

        function SetInfo(pack, dz, line, shdw, num) {
            if (num > 0) {
                window.parent.SetPlan(pack, dz, line, shdw);
            }
            else {
                 alert("当前计划号车数不足");
                 window.parent.SetPlan("", "", "", "");
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
                </td>

            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="300" id="table" style="white-space: nowrap;">
            <thead>
                <tr>

                    <th data-sortable="true">类型</th>
                    <th data-sortable="true">计划号</th>
                    <th data-sortable="true">车数</th>
                    <th data-sortable="true">已发车数</th>
                    <th data-sortable="true">剩余车数</th>
                    <th data-sortable="true">到站</th>
                    <th data-sortable="true">到局</th>
                    <th data-sortable="true">专用线</th>
                    <th data-sortable="true">收货单位</th>
                    <th data-sortable="true">订货单位</th>
                    <th data-sortable="true">区域</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>

                            <td><%#DataBinder.Eval (Container.DataItem,"C_FLAG") %></td>
                            <td><a href="#" title="点击插入" onclick="SetInfo('<%#DataBinder.Eval (Container.DataItem,"C_PLANNO")%>','<%#DataBinder.Eval (Container.DataItem,"C_STATION") %>','<%#DataBinder.Eval (Container.DataItem,"C_REMARK") %>','<%#DataBinder.Eval (Container.DataItem,"C_CUSTNAME") %>','<%#DataBinder.Eval (Container.DataItem,"SYNUM") %>');"><%#DataBinder.Eval (Container.DataItem,"C_PLANNO")%></a></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_TRAIN_NUM") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"YFNUM") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"SYNUM") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STATION") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STATION_J") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_REMARK") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUSTNAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUSTNO") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_AREA") %></td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
        <input id="hidID" type="hidden" runat="server" />
      
    </form>
</body>
</html>
