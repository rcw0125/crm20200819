<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="F001.aspx.cs" Inherits="CRM.WebForms.Sale_App.F001" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>发运单下发审核</title>
    <uc1:common2 runat="server" ID="common2" />
    <script type="text/javascript">
        $(function () {

            $("#txtStart").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true,
                todayBtn: true
            });
            $("#txtEnd").datetimepicker({
                format: 'yyyy-mm-dd',
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
        <div class="dv_btn">
            <ul>

                <li>
                    <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn btn-success btn-xs" /></li>
                <li>
                    <asp:Button ID="btnCheck" runat="server" Text="审核通过" CssClass="btn btn-primary btn-xs" OnClick="btnCheck_Click" /></li>
                <li>
                    <asp:Button ID="btnxc" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btnxc_Click" /></li>
            </ul>
        </div>
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox ID="txtfyd" runat="server" placeholder="发运单号" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtzdr" runat="server" placeholder="提报人" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtconno" runat="server" placeholder="合同号" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtcust" runat="server" placeholder="客户" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtstlgrd" runat="server" placeholder="钢种" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtspec" runat="server" placeholder="规格" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtxfwgt" runat="server" placeholder="计划下发量" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td>是否审核&nbsp;<asp:DropDownList ID="dropcheck" runat="server">
                    <asp:ListItem>N</asp:ListItem>
                    <asp:ListItem>Y</asp:ListItem>
                </asp:DropDownList></td>
                <td>
                    <asp:DropDownList ID="dropfyfs" runat="server" Width="100%"></asp:DropDownList></td>
                <td>
                    <asp:DropDownList ID="droparea" runat="server" Width="100%"></asp:DropDownList></td>
                <td>
                    <asp:TextBox ID="txtstation" runat="server" placeholder="到站" Width="100%"></asp:TextBox></td>
                <td>是否监控&nbsp;<asp:DropDownList ID="dropsfjk" runat="server">
                    <asp:ListItem>全部</asp:ListItem>
                    <asp:ListItem>N</asp:ListItem>
                    <asp:ListItem>Y</asp:ListItem>
                </asp:DropDownList></td>
                <td>
                    <input id="txtStart" type="text" runat="server" style="cursor: pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td>
                    <input id="txtEnd" runat="server" type="text" style="cursor: pointer" readonly="readonly" class=" form-control Wdate" /></td>
            </tr>
        </table>
        <table class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="450" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    
                    <th >合计</th>
                    <th >&nbsp;</th>
                    <th >
                        <asp:Literal ID="ltlsumwgt" runat="server"></asp:Literal>
                    </th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                </tr>
                <tr>
                    <th data-sortable="true">
                        <input id="cbxAll" type="checkbox" class="qx1" />发运单</th>
                    <th data-sortable="true">发运方式</th>
                    <th data-sortable="true">计划重量</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">区域</th>
                    <th data-sortable="true">客户</th>
                    <th data-sortable="true">到站</th>
                    <th data-sortable="true">提报人</th>
                    <th data-sortable="true">提报时间</th>
                    <th data-sortable="true">最后操作人</th>
                    <th data-sortable="true">最后操作时间</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>


                        <tr>
                            <td>
                                <input id="cbxselect" runat="server" class="che1" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' /><%#DataBinder.Eval (Container.DataItem,"C_ID") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SHIPVIA") %></td>
                            <td>
                                <asp:Literal ID="ltlwgt" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT") %>' runat="server"></asp:Literal></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_AREA") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_DH_COMPANY") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STATION") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EMPNAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_DT") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CHECKEMP") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CHECKTIME") %></td>                          
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </form>
</body>
</html>
