<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XCZK.aspx.cs" Inherits="CRM.WebForms.PCI.XCZK" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>线材转库</title>
    <uc1:common runat="server" ID="common" />
    <script>
        $(function () {
            var _h = document.documentElement.clientHeight || document.body.clientHeight;
            var w = document.documentElement.clientWidth || document.body.clientWidth;
            $("#flow1").height(_h * 0.4);
            $("#flow2").height(_h * 0.37);
            $("#flow1").width(w);
            $("#flow2").width(w);
        })

    </script>
</head>
<body onresize="fromsize();">
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed" style="height: 100%">
            <tr>
                <td>
                    <table class="table table-bordered table-condensed">
                        <tr>
                            <td style="width: 8%">当前仓库</td>
                            <td style="width: 150px">
                                <asp:DropDownList ID="ddlCangKu" runat="server" onclick="document.all['ck'].value=this.options[this.selectedIndex].value" Style="width: 130px; height: 20px; position: absolute">
                                </asp:DropDownList>
                                <asp:TextBox runat="server" ID="ck" Width="110px" Style="height: 20px; position: absolute"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox runat="server" placeholder="批号" ID="txtPiHao" Width="100%"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtGangZhong" placeholder="钢种" runat="server" Width="100%"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtZXBZ" placeholder="执行标准" runat="server" Width="100%"></asp:TextBox></td>
                            <td>是否待判</td>
                            <td>
                                <asp:DropDownList ID="ddlsfdp" runat="server">
                                    <asp:ListItem>全部</asp:ListItem>
                                    <asp:ListItem Value="0">已判</asp:ListItem>
                                    <asp:ListItem Value="1">待判</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" OnClientClick="_loading(1)" />
                            </td>
                            <td style="width: 8%">目标仓库</td>
                            <td>
                                <asp:DropDownList ID="ddlCangKu2" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="txtZK" CssClass="btn btn-danger btn-xs" runat="server" Text="转库" OnClick="txtZK_Click" OnClientClick="_loading(1)" /></td>
                        </tr>
                    </table>
                    <div style="overflow: auto; width: 100%;" id="flow1">
                        <table id="table1" class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="300" style="white-space: nowrap;">
                            <thead>
                                <tr class="info">
                                    <th>合计</th>
                                    <th>数量：<asp:Literal ID="rptSL" runat="server"></asp:Literal></th>
                                    <th>重量：<asp:Literal ID="rptZL" runat="server"></asp:Literal></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                </tr>
                                <tr>
                                    <th>
                                        <input id="cbxAll" type="checkbox" class="qx1" />全选</th>
                                    <th data-sortable="true">批号</th>
                                    <th data-sortable="true">钢种</th>
                                    <th data-sortable="true">执行标准</th>
                                    <th data-sortable="true">规格</th>
                                    <th data-sortable="true">表判等级</th>
                                    <th data-sortable="true">综判等级</th>
                                    <th data-sortable="true">包装要求</th>
                                    <th data-sortable="true">数量</th>
                                    <th data-sortable="true">重量</th>
                                    <th data-sortable="true">仓库</th>
                                    <th data-sortable="true">计划数量</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptList" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <input id="cbxselect" class="che1" name="cbx" runat="server" type="checkbox" />
                                            </td>
                                            <td>
                                                <asp:Literal ID="lblBatchNo" Text='<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lblGrd" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lblStdCode" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lblSpec" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lblLevBP" Text='<%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_BP") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lblLevZH" Text='<%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lblBZYQ" Text='<%#DataBinder.Eval (Container.DataItem,"C_BZYQ") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lblNum" Text='<%#DataBinder.Eval (Container.DataItem,"N_NUM") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lblWGT" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT") %>' runat="server"></asp:Literal>

                                            </td>
                                            <td>
                                                <asp:Literal ID="lblLineCode" Text='<%#DataBinder.Eval (Container.DataItem,"C_LINEWH_CODE") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="lblSNum" Width="100" Text='<%#DataBinder.Eval (Container.DataItem,"N_SNUM") %>' CssClass="numJe" runat="server"></asp:TextBox>
                                                <asp:Literal ID="lblMatCode" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %>' runat="server" Visible="false"></asp:Literal>
                                            </td>

                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </tbody>
                        </table>
                    </div>
                    <table class="table table-bordered table-hover table-condensed">
                        <tr>
                            <td style="width: 150px;">
                                <asp:TextBox runat="server" placeholder="转库单" ID="txtZKD" Width="100%"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox runat="server" placeholder="原仓库" ID="txtck" Width="100%"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox runat="server" placeholder="目标仓库" ID="txtMBCK" Width="100%"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox runat="server" placeholder="批号" ID="txtPiHao2" Width="100%"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtGangZhong2" placeholder="钢种" runat="server" Width="100%"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtZXBZ2" placeholder="执行标准" runat="server" Width="100%"></asp:TextBox></td>
                            <td>是否待判</td>
                            <td>
                                <asp:DropDownList ID="ddlsfdp2" runat="server">
                                    <asp:ListItem>全部</asp:ListItem>
                                    <asp:ListItem Value="0">已判</asp:ListItem>
                                    <asp:ListItem Value="1">待判</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>状态</td>
                            <td>
                                <asp:DropDownList ID="ddlzt" runat="server">
                                    <asp:ListItem>全部</asp:ListItem>
                                    <asp:ListItem Value="1">未回实绩</asp:ListItem>
                                    <asp:ListItem Value="2">已回实绩</asp:ListItem>
                                    <asp:ListItem Value="0">已撤回</asp:ListItem>
                                    <asp:ListItem>异常</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>制单日期 </td>
                            <td>
                                <asp:TextBox runat="server" class="form-control Wdate" ID="txtzdrq" Style="height: 100%;"></asp:TextBox></td>
                            <td>
                                <asp:Button ID="btnCX2" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btnCX2_Click" OnClientClick="_loading(1)" />
                            </td>
                            <td>
                                <asp:Button ID="Button2" CssClass="btn btn-danger btn-xs" runat="server" Text="撤回" OnClick="btnRevoke_Click" OnClientClick="_loading(1)" />
                            </td>
                        </tr>
                    </table>
                    <div style="overflow: auto; width: 100%;" id="flow2">
                        <table id="table2" class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="280" style="white-space: nowrap;">
                            <thead>
                                <tr class="info">
                                    <th>合计</th>
                                    <th>数量：<asp:Literal ID="rptZKSL" runat="server"></asp:Literal></th>
                                    <th>重量：<asp:Literal ID="rptZKZL" runat="server"></asp:Literal></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                </tr>
                                <tr>
                                    <th data-sortable="true">选择</th>
                                    <th data-sortable="true">转库单</th>
                                    <th data-sortable="true">批号</th>
                                    <th data-sortable="true">钢种</th>
                                    <th data-sortable="true">执行标准</th>
                                    <th data-sortable="true">规格</th>
                                    <th data-sortable="true">数量</th>
                                    <th data-sortable="true">重量</th>
                                    <th data-sortable="true">仓库</th>
                                    <th data-sortable="true">目标仓库</th>
                                    <th data-sortable="true">表判等级</th>
                                    <th data-sortable="true">综判等级</th>
                                    <th data-sortable="true">状态</th>
                                    <th data-sortable="true">制单人</th>
                                    <th data-sortable="true">制单时间</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptList2" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <input id="rdoselect" type="radio" name="group" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ZKD_NO") %>' onclick="selectSingleRadio(this, 'group');" />
                                            </td>
                                            <td>
                                                <%#DataBinder.Eval (Container.DataItem,"C_ZKD_NO") %>
                                            </td>
                                            <td>
                                                <%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %>
                                            </td>
                                            <td>
                                                <%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>
                                            </td>
                                            <td>
                                                <%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %></td>

                                            <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>

                                            <td><%#DataBinder.Eval (Container.DataItem,"N_NUM") %></td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"N_WGT") %>                                   
                                            </td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_CODE") %></td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"C_MBLINEWH_CODE") %></td>
                                            <td>
                                                <asp:Literal ID="lblLevBP" Text='<%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_BP") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lblLevZH" Text='<%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"N_STATUS") %></td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"C_CREATE_CODE") %></td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"D_CREATE_DATE") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
        </table>

        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>

        <script type="text/javascript">
            $(function () {
                $("#txtzdrq").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
            });
            selectAll("input.qx1", "input.che1");

            selectAll("input.qx2", "input.che2");
            function selectSingleRadio(rbtn1, GroupName) {
                $("input[type=radio]").each(function (i) {
                    if (this.name.substring(this.name.length - GroupName.length) == GroupName) {
                        this.checked = false;
                    }
                })
                rbtn1.checked = true;
            }
        </script>
    </form>

</body>
</html>
