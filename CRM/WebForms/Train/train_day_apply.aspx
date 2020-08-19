<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="train_day_apply.aspx.cs" Inherits="CRM.WebForms.Train.train_day_apply" %>

<%@ Register Src="~/WebForms/Train/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>火运日计划申请</title>
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

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox ID="txtcust" placeholder="订货/收货单位" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtcustno" placeholder="客户编码" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtconno" placeholder="合同号" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtdz" placeholder="到站" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtplancode" placeholder="计划号" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtstlgrd" placeholder="钢种" Style="width: 100%" runat="server"></asp:TextBox></td>
                <td><asp:DropDownList ID="dropneedarea" runat="server"></asp:DropDownList></td>
                <td style="width: 50px;">日期</td>
                <td style="width: 110px;">
                    <input id="txtStart" type="text" style="width: 110px;" readonly="readonly" class="form-control Wdate" runat="server" />
                </td>
                <td style="width: 110px;">
                    <input id="txtEnd" runat="server" type="text" style="width: 110px;" readonly="readonly" class="form-control Wdate" /></td>

                <td style="width:250px">
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" />
                    &nbsp;
                     <asp:Button ID="btnapply" runat="server" Text="计划申请" CssClass="btn  btn-success btn-xs" OnClick="btnapply_Click" />
                   
                    &nbsp;
                    <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn  btn-success btn-xs" OnClick="btnExport_Click" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="500" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th data-sortable="true">序号</th>
                    <th data-sortable="true">单据号</th>
                    <th data-sortable="true">区域</th>
                    <th data-sortable="true">提报人</th>
                    <th data-sortable="true">提报日期</th>
                    <th data-sortable="true">合同号</th>
                    <th data-sortable="true">订货单位</th>
                    <th data-sortable="true">收货单位</th>
                    <th data-sortable="true">到站</th>
                    <th data-sortable="true">计划号</th>
                    <th data-sortable="true">专用线</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">吨数</th>
                    <th data-sortable="true">车数</th>
                    <th data-sortable="true">客户编码</th>
                    <th data-sortable="true">客户名称</th>
                    <th data-sortable="true">开户行</th>
                    <th data-sortable="true">税号</th>
                    <th data-sortable="true">账号</th>
                    <th data-sortable="true">电话</th>
                    <th data-sortable="true">地址</th>
                    <th data-sortable="true">备注</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Container.ItemIndex+1 %>
                              </td>
                            <td><a href="train_day_edit.aspx?ID=<%#DataBinder.Eval (Container.DataItem,"C_ID")%>"> <%#DataBinder.Eval (Container.DataItem,"C_ID")%></a></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_AREA")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EMPNAME")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_DT")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CONNO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_DH_COMPANY")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_REMARK")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STATION")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_PLANNO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_LINE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_WGT")%></td>

                            <td><%#DataBinder.Eval (Container.DataItem,"N_TRAIN_NUM")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUSTNO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUSTNAME")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_KH_BANK")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_TAXNO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ACCOUNT")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_TEL")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ADDRESS")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_REMARK")%></td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

    </form>
</body>
</html>
