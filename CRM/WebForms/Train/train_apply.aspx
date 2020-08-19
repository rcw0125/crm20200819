<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="train_apply.aspx.cs" Inherits="CRM.WebForms.Train.train_apply" %>

<%@ Register Src="~/WebForms/Train/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>火运报备计划</title>
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
                case 0:
                    var url = "custEdit.aspx";
                    _iframe(url, '500', '500', '客户档案');
                    break;
                case 1:
                    var url = "train_add.aspx";
                    _iframe(url, '600', '500', '火运计划（内/外）申请');
                    break;
            }

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 150px">
                    <asp:TextBox ID="txtcust" placeholder="订货单位/收货单位" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtcustno" placeholder="客户编码" Style="width: 100%" runat="server"></asp:TextBox></td>
                 <td style="width: 100px">
                    <asp:TextBox ID="txtconno" placeholder="合同号" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtdz" placeholder="到站" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td><asp:DropDownList ID="dropflag" runat="server">
                     
                        <asp:ListItem>全部</asp:ListItem>
                     
                        <asp:ListItem Value="0">计划内</asp:ListItem>
                        <asp:ListItem Value="2">计划外</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 50px;">日期</td>
                <td style="width: 120px;">
                    <input id="txtStart" type="text" style="width: 120px;" readonly="readonly" class="form-control Wdate" runat="server" />
                </td>
                <td style="width: 120px;">
                    <input id="txtEnd" runat="server" type="text" style="width: 120px;" readonly="readonly" class="form-control Wdate" /></td>

                <td>
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" />
                    &nbsp;
                     <input id="btnadd" type="button" class="btn  btn-success btn-xs" value="计划申请" onclick="openweb(1);" />
                    &nbsp;
                    <asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-danger btn-xs" OnClientClick="return confirm('确定要删除吗？');" OnClick="btndel_Click" />
                    &nbsp;
                    <input id="Button1" type="button" class="btn  btn-success btn-xs" value="客户档案" onclick="openweb(0);" />

                    &nbsp;
                    <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn  btn-success btn-xs" OnClick="btnExport_Click" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="500" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th data-sortable="true">单据号</th>
                    <th data-sortable="true">区域</th>
                    <th data-sortable="true">计划月份</th>
                   
                    <th data-sortable="true">合同号</th>
                    <th data-sortable="true">订货单位</th>
                    <th data-sortable="true">收货单位</th>
                    <th data-sortable="true">到站</th>
                    <th data-sortable="true">车数</th>
                    <th data-sortable="true">专用线</th>
                    <th data-sortable="true">客户编码</th>
                    <th data-sortable="true">客户名称</th>
                    <th data-sortable="true">开户行</th>
                    <th data-sortable="true">税号</th>
                    <th data-sortable="true">账号</th>
                    <th data-sortable="true">电话</th>
                    <th data-sortable="true">地址</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><input id="cbxselect" runat="server" class="che1" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' /><%#DataBinder.Eval (Container.DataItem,"C_BILLCODE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_AREA")%></td>
                           
                            <td><%#DataBinder.Eval (Container.DataItem,"D_MONTH","{0:yyy-MM}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CONNO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_DH_COMPANY")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SH_COMPANY")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STATION")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_TRAIN_NUM")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_LINE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUSTNO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUSTNAME")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_KH_BANK")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_TAXNO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ACCOUNT")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_TEL")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ADDRESS")%></td>
                           
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
      
    </form>
</body>
</html>
