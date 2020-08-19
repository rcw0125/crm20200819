<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XCQTCK.aspx.cs" Inherits="CRM.WebForms.PCI.XCQTCK" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>线材其他出库</title>
    <uc1:common runat="server" ID="common" />
    <script>
        $(function () {
            var _w = window.screen.availWidth;
            var _h = window.screen.availHeight;
            $("#flow1").height(_h * 0.3);
            $("#flow2").height(_h * 0.3);
            $("#flow1").width(_w * 0.8473);
            $("#flow2").width(_w*0.8473);

        })

    </script>
    <script src="js/qtck.js"></script>
</head>

<body onresize="fromsize();">
    <form id="form1" runat="server">

        <table class="table table-bordered table-condensed" id="tb1">
            <tr>
                <td style="width: 60px;">当前仓库</td>
                <td style="width: 150px;">
                    <asp:DropDownList ID="ddlCangKu" runat="server" onchange="document.all['dqck'].value=this.options[this.selectedIndex].value" Style="width: 130px; height: 20px; position: absolute">
                    </asp:DropDownList>
                    <asp:TextBox runat="server" ID="dqck" Width="110px" Style="height: 20px; position: absolute"></asp:TextBox>
                </td>
                <td style="width: 150px;">
                    <asp:TextBox runat="server" placeholder="批号" ID="txtPiHao" Width="100%"></asp:TextBox></td>
                <td style="width: 150px;">
                    <asp:TextBox ID="txtGangZhong" placeholder="钢种" runat="server" Width="100%"></asp:TextBox></td>
                <td style="width: 150px;">
                    <asp:TextBox ID="txtZXBZ" placeholder="执行标准" runat="server" Width="100%"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlsfdp" runat="server">
                        <asp:ListItem Value="全部">全部</asp:ListItem>
                        <asp:ListItem Value="0">已判</asp:ListItem>
                        <asp:ListItem Value="1">待判</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" OnClientClick="_loading(1)" />
                </td>
            </tr>
        </table>
        <div style="overflow: auto; width: 100%;" id="flow1">
            <table id="table1" class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="300" style="white-space: nowrap;">
                <thead>
                    <tr class="info">
                        <th>合计</th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th>
                            <asp:Literal ID="rptSL" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="rptZL" runat="server"></asp:Literal>
                        </th>
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
                        <th data-sortable="true">质量等级</th>
                        <th data-sortable="true">包装要求</th>
                        <th data-sortable="true">数量</th>
                        <th data-sortable="true">重量</th>
                        <th data-sortable="true">计划数量</th>
                        <th data-sortable="true">仓库</th>
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
                                    <asp:TextBox ID="lblSNum" Text='<%#DataBinder.Eval (Container.DataItem,"N_SNUM") %>' runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Literal ID="lblLineCode" Text='<%#DataBinder.Eval (Container.DataItem,"C_LINEWH_CODE") %>' runat="server"></asp:Literal>
                                    <asp:Literal ID="lblMatCode" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %>' runat="server" Visible="false"></asp:Literal>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <table class="table table-bordered table-condensed" id="tb2">
            <tr>
                <td>目标仓库 </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddlCangKu2" runat="server" onchange="document.all['mbck'].value=this.options[this.selectedIndex].value" Style="width: 130px; height: 20px; position: absolute">
                    </asp:DropDownList>
                    <asp:TextBox runat="server" ID="mbck" Width="110px" Style="height: 20px; position: absolute"></asp:TextBox>
                </td>
                <td>出库类型 
                </td>
                <td>
                    <asp:DropDownList ID="ddlcklx" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
                <td>承运商 
                </td>
                <td>
                    <asp:DropDownList ID="ddlcys" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox runat="server" placeholder="车牌号" ID="txtCPH" Width="100%"></asp:TextBox>
                </td>
                <td>地址 
                </td>
                <td style="width: 150px">
                    <asp:DropDownList ID="ddldz" runat="server" onchange="document.all['txtdz'].value=this.options[this.selectedIndex].text" Style="width: 130px; height: 20px; position: absolute">
                    </asp:DropDownList>
                    <asp:TextBox runat="server" ID="txtdz" Width="110px" Style="height: 20px; position: absolute"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>收货单位 
                </td>
                <td>
                    <asp:DropDownList ID="ddlshdw" runat="server" onchange="document.all['txtshdw'].value=this.options[this.selectedIndex].text" Style="width: 130px; height: 20px; position: absolute">
                    </asp:DropDownList>
                    <asp:TextBox runat="server" ID="txtshdw" Width="110px" Style="height: 20px; position: absolute"></asp:TextBox>
                </td>
                <td style="width: 15%">
                    <asp:TextBox runat="server" placeholder="发运时间" class="form-control Wdate" ID="txtFysj" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" CssClass="btn btn-danger btn-xs" runat="server" Text="出库" OnClick="btnCK_Click" OnClientClick="_loading(1)" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed" id="tb3">
            <tr>
                <td style="width: 120px;">
                    <asp:TextBox runat="server" placeholder="其他出库单" ID="txtQTCKD2" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 120px;">
                    <asp:TextBox runat="server" placeholder="原仓库" ID="txtck" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 120px;">
                    <asp:TextBox runat="server" placeholder="目标仓库" ID="txtmbck" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 120px;">
                    <asp:TextBox runat="server" placeholder="批号" ID="txtPiHao2" Width="100%"></asp:TextBox></td>
                <td style="width: 120px;">
                    <asp:TextBox ID="txtGangZhong2" placeholder="钢种" runat="server" Width="100%"></asp:TextBox></td>
                <td style="width: 120px;">
                    <asp:TextBox ID="txtZXBZ2" placeholder="执行标准" runat="server" Width="100%"></asp:TextBox></td>
                      <td>是否待判</td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlsfdp2" runat="server">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem Value="0">已判</asp:ListItem>
                        <asp:ListItem Value="1">待判</asp:ListItem>
                    </asp:DropDownList></td>
                      <td>状态 </td>
                <td style="width: 100px">
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
                    <asp:Button ID="btnCX2" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btnCX2_Click" OnClientClick="_loading(1)" /></td>
                <td>
                    <asp:Button ID="Button2" CssClass="btn btn-danger btn-xs" runat="server" Text="撤回" OnClick="btnRevoke_Click" OnClientClick="_loading(1)" />
                </td>
                <td>
                    <asp:Button ID="Button6" CssClass="btn btn-danger btn-xs" runat="server" Text="打印" OnClientClick="_print_qtck();" />
                </td>
            </tr>
        </table>
        <div style="overflow: auto; width: 100%;" id="flow2">
            <table class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="300" style="white-space: nowrap;">

                <thead>
                    <tr class="info">
                        <th>合计</th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th>&nbsp;</th>
                        <th>&nbsp;</th>
                        <th>
                            <asp:Literal ID="rptZKSL" runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="rptZKZL" runat="server"></asp:Literal>
                        </th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                    </tr>
                    <tr>
                        <th data-sortable="true">选择</th>
                        <th data-sortable="true">其他出库单</th>
                        <th data-sortable="true">批号</th>
                        <th data-sortable="true">钢种</th>
                        <th data-sortable="true">执行标准</th>
                        <th data-sortable="true">规格</th>
                        <th data-sortable="true">表判等级</th>
                        <th data-sortable="true">质量等级</th>
                        <th data-sortable="true">数量</th>
                        <th data-sortable="true">重量</th>
                        <th data-sortable="true">原仓库</th>
                        <th data-sortable="true">目标仓库</th>
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
                                    <input id="rdoselect" type="radio" class="ckd" name="group" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_QTCKD_NO") %>' onclick="selectSingleRadio(this, 'group');" />
                                </td>
                                <td>
                                    <%#DataBinder.Eval (Container.DataItem,"C_QTCKD_NO") %>
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
                                <td><%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_BP") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_NUM") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_WGT") %>                                   
                                </td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_MBWH_ID") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_STATUS") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_CREATE_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"D_CREATE_DT") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltluseracc" runat="server" Visible="false"></asp:Literal>

        <script type="text/javascript">
            $(function () {
                $("#txtzdrq").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
                //fromsize();
            });
            selectAll("input.qx1", "input.che1");
            function selectSingleRadio(rbtn1, GroupName) {
                $("input[type=radio]").each(function (i) {
                    if (this.name.substring(this.name.length - GroupName.length) == GroupName) {
                        this.checked = false;
                    }
                })
                rbtn1.checked = true;
            }
            $("#txtFysj").datetimepicker({
                format: 'yyyy-mm-dd hh:ii:ss',
                language: 'zh-CN',
                minView: 0,
                minuteStep: 1,
                autoclose: true,
                todayBtn: true
            });
        </script>

    </form>

</body>
</html>
