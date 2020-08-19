<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleOrder.aspx.cs" Inherits="CRM.WebForms.Report.SaleOrder" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>销售订单</title>
    <uc1:common runat="server" ID="common" />
    <script src="../JsDate.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 120px;">
                    <asp:TextBox runat="server" placeholder="客户名称" ID="txtcustname" Width="100%"></asp:TextBox></td>
                <td style="width: 120px;">
                    <asp:TextBox ID="txtconno" placeholder="合同号" runat="server" Width="100%"></asp:TextBox></td>
                <td style="width: 120px;">
                    <asp:TextBox ID="txtyewuyuan" placeholder="业务员" runat="server" Width="100%"></asp:TextBox></td>

                <td style="width: 70px;" class="right">日期</td>
                <td>
                    <input id="Start" type="text" style="width: 110px;" readonly="readonly" class=" form-control Wdate" runat="server" />

                </td>

                <td>
                    <input id="End" runat="server" type="text" style="width: 110px;" readonly="readonly" class="form-control Wdate" /></td>
                <td>
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" />
                    <asp:Button ID="btncdr" CssClass="btn btn-warning btn-xs" runat="server" Text="订单导入NC" OnClick="btncdr_Click" OnClientClick="return salemsg();" />
                    <asp:Button ID="btnplan_nc" CssClass="btn btn-warning btn-xs" runat="server" Text="日计划导入NC" OnClick="btnplan_nc_Click" OnClientClick="return planmsg();" />
                    &nbsp;<asp:Button ID="btndel" CssClass="btn btn-warning btn-xs" runat="server" Text="删除销售订单" OnClick="btndel_Click" OnClientClick="return delmsg();" />
                    &nbsp;
                    <asp:Button ID="btndel_day" CssClass="btn btn-warning btn-xs" runat="server" Text="删除日计划"  OnClientClick="return delmsg();" OnClick="btndel_day_Click" Visible="false"  />

                </td>
            </tr>
        </table>
        <table class="table table-bordered table-hover table-condensed" id="table1">
            <thead>
                <tr>
                    <th style="width: 60px;">选择</th>
                    <th>订单号</th>
                    <th>合同号</th>
                    <th>客户名称</th>
                    <th class="red">状态</th>
                    <th class="red">发送时间</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptSale" runat="server" OnItemCommand="rptSale_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>

                                <input id="rdoselect" type="radio" name="group" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_NC_ID") %>' onclick="selectSingleRadio(this, 'group');" />
                            </td>
                            <td>
                                <asp:LinkButton ID="lbtnsalecode" runat="server" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"C_NC_SALECODE") %>' CommandName="xc"><%#DataBinder.Eval (Container.DataItem,"C_NC_SALECODE") %></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Literal ID="ltlsalecode" Text='<%#DataBinder.Eval (Container.DataItem,"C_NC_SALECODE") %>' runat="server" Visible="false"></asp:Literal>
                                <asp:Literal ID="ltlconno" Text='<%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %>' runat="server"></asp:Literal>
                                <asp:Literal ID="ltldate" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"D_NC_DATE") %>' runat="server"></asp:Literal>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %>
                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_EXEC_STATUS")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_NC_DATE")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
        <table>
            <tr><td style="text-align:left"><webdiyer:AspNetPager ID="Pager1" runat="server" CssClass="paginator" CurrentPageButtonClass="paginator"
                CurrentPageButtonPosition="End" CustomInfoHTML="总记录：%RecordCount% &nbsp;页码：%CurrentPageIndex% / %pageCount% &nbsp; 每页：%PageSize%"
                CustomInfoSectionWidth="350px" CustomInfoTextAlign="Center" FirstPageText="首页"
                HorizontalAlign="Right" LastPageText="尾页"
                meta:resourcekey="AspNetPager" NextPageText="下一页"
                NumericButtonCount="5" PagingButtonClass=""
                PrevPageText="前一页" showinputbox="Never" ShowNavigationToolTip="True" ShowPageIndexBox="Never"
                Width="100%" CustomInfoClass="paginator" OnPageChanged="Pager1_PageChanged">
                <span style="color: #000000"></span><strong></strong><span style="color: #000000">&nbsp;&lt;
                            &gt;</span>
            </webdiyer:AspNetPager></td></tr>
     
        </table>
      
        <div id="div1" style="overflow: auto; margin-top: 0px;">

            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table class="table table-bordered table-hover table-condensed" style="white-space: nowrap;" id="table2">
                        <thead>
                            <tr>
                                <th style="width:100px;"><input id="cbxAll" type="checkbox" class="qx1" />全选</th>
                                <th class="red">日计划单据号</th>
                                <th class="red">日计划状态</th>

                                <th>订单号</th>
                                <th>合同号</th>
                                <th>订单状态</th>
                                <th>签订日期</th>
                                <th>计划终止日期</th>
                                <th>客户名称</th>
                                <th>物料编码</th>
                                <th>物料名称</th>
                                <th>规格</th>
                                <th>钢种</th>
                                <th>数量</th>
                                <th>含税单价</th>
                                <th>价税合计</th>
                                <th>自由项1</th>
                                <th>自由项2</th>
                                <th>包装要求</th>
                                <th>发运方式</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <input id="cbxselect" class="che1"  runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' type="checkbox" style='<%#DataBinder.Eval (Container.DataItem,"PLANEXE").ToString()=="0"?"display:block": "display:none"%>' />
                            <%#Container.ItemIndex+1 %>

                        </td>
                        <td>
                            <asp:Literal ID="ltlplancode" Text='<%#DataBinder.Eval (Container.DataItem,"C_PLCODE") %>' runat="server"></asp:Literal>
                        </td>
                        <td>
                            <%#DataBinder.Eval (Container.DataItem,"PLANEXE2") %>
                            <asp:Literal ID="ltlplanexe" Text='<%#DataBinder.Eval (Container.DataItem,"PLANEXE") %>' Visible="false" runat="server"></asp:Literal></td>
                        <td>
                            <%#DataBinder.Eval (Container.DataItem,"C_NC_SALECODE") %>

                        </td>
                        <td>
                            <%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %>
                        </td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_NCSTATUS") %></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"D_DT","{0:yyy-MM-dd}") %></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"D_DELIVERY_DT","{0:yyy-MM-dd}") %></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME") %></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                        <td>
                            <%#DataBinder.Eval (Container.DataItem,"N_WGT") %></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURTAXPRICE") %></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURSUMMNY") %></td>

                        <td><%#DataBinder.Eval (Container.DataItem,"C_FREE1") %></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_FREE2") %></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_PACK") %></td>

                        <td><%#DataBinder.Eval (Container.DataItem,"C_TRANSMODE") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>

        </div>
        <asp:Literal ID="ltlPlanCode" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>
        <script type="text/javascript">

            selectAll("input.qx1", "input.che1");

            function selectSingleRadio(rbtn1, GroupName) {
                $("input[type=radio]").each(function (i) {
                    if (this.name.substring(this.name.length - GroupName.length) == GroupName) {
                        this.checked = false;
                    }
                })
                rbtn1.checked = true;
            }
            function delmsg() {

                var result = false;
                $("#table1 tbody tr").each(function () {
                    var radio = $(this).children("td").find("input[type='radio']");
                    if (radio.is(":checked")) {
                        result = true;
                    }
                });
                if (result) {
                    return confirm("确定要删除吗？");
                }
                else {
                    alert("请先选择需要项！");
                    return false;
                }
            }


            function salemsg() {

                if (confirm('确定要导入NC吗？')) {

                    var result = true;
                    $("#table1 tbody tr").each(function () {
                        var radio = $(this).children("td").find("input[type='radio']");
                        if (radio.is(":checked")) {
                            var status = $.trim($(this).find("td").eq(4).html());
                            if (status != "自由状态") {
                                alert("当前订单号：" + status);
                                result = false;
                            }
                        }
                    });

                    if (result == true) {
                        _loading(1);
                        return true;
                    }
                    else {
                        return false;
                    }

                }
                return false;
            }
            function planmsg() {
                if (confirm('确定要导入NC吗？')) {
                    var result = true;
                    $("#table2 tbody tr").each(function () {
                        var radio = $(this).children("td").find("input[type='checkbox']");
                        if (radio.is(":checked")) {
                            var orderno = $.trim($(this).find("td").eq(3).html());
                            var orderstatus = $.trim($(this).find("td").eq(5).html());
                            //var plancode = $.trim($(this).find("td").eq(1).html());
                            //var planstatus = $.trim($(this).find("td").eq(2).html());
                            if (orderstatus == "自由状态") {
                                alert("订单号：" + orderno + ",请先导入NC");
                                result = false;
                            }
                        }
                    });

                    if (result) {
                        _loading(1);
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                return false;

            }
        </script>

    </form>
</body>
</html>
