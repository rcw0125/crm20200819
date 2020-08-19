<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderView.aspx.cs" Inherits="CRM.WebForms.Report.OrderView" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>合同明细查询</title>
    <uc1:common runat="server" ID="common" />
    <script src="../JsDate.js"></script>

</head>

<body>
    <form id="form1" runat="server">
        <div class="dv_btn" style="margin-top: 5px;">
            <ul>
                <li>
                     <asp:Button ID="btnExport" CssClass="btn btn-success btn-xs" runat="server" Text="导出" OnClick="btnExport_Click" />
                </li>
                <li>
                    <asp:Button ID="btnscorder" CssClass="btn btn-warning btn-xs" runat="server" Text="生成销售订单&日计划" OnClientClick="return checkcf();" OnClick="btnscorder_Click" /></li>
            </ul>
        </div>

        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox runat="server" placeholder="客户名称" ID="txtcustname" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtconno" placeholder="合同号" runat="server" Width="100%"></asp:TextBox></td>
               
                <td>
                    <asp:TextBox ID="txtyewuyuan" placeholder="业务员" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtstlgrd" placeholder="钢种" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtspec" placeholder="规格" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:DropDownList ID="dropArea" runat="server"></asp:DropDownList>
                </td>
                <td style="width: 70px;">签单日期</td>
                <td>
                    <input id="Start" type="text" style="width: 110px;" readonly="readonly" class=" form-control Wdate" runat="server" /></td>

                <td>
                    <input id="End" runat="server" type="text" style="width: 110px;" readonly="readonly" class=" form-control Wdate" /></td>
                <td>
                     <asp:DropDownList ID="droptype" runat="server">
                        <asp:ListItem Value="8">线材</asp:ListItem>
                        <asp:ListItem Value="6">钢坯</asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td style="width: 80px;">合同状态</td>
                <td>
                    <asp:DropDownList ID="dropstatus" runat="server">
                        <asp:ListItem Value="全部">全部</asp:ListItem>
                        <asp:ListItem Value="0">待审</asp:ListItem>
                        <asp:ListItem Value="1">审核中</asp:ListItem>
                        <asp:ListItem Value="4">审核通过</asp:ListItem>
                        <asp:ListItem Value="2">生效</asp:ListItem>
                        <asp:ListItem Value="5">冻结</asp:ListItem>
                        <asp:ListItem Value="6">终止</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 80px;">执行状态</td>
                <td>
                    <asp:DropDownList ID="dropexestatus" runat="server">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem Value="0">自由状态</asp:ListItem>
                        <asp:ListItem Value="1">销售订单</asp:ListItem>
                        <asp:ListItem Value="2">导入NC</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" OnClientClick="_loading(1);" />
                  
                </td>
            </tr>
        </table>
        <div style="overflow: auto; width: 100%; max-height:450px;">
            <table id="table1" class="table table-bordered table-hover table-condensed" style="white-space: nowrap;">
                <thead>
                    <tr class="info">
                        <td>合计</td>
                       
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>
                            <asp:Literal ID="ltlwgt" runat="server"></asp:Literal></td>
                        <td></td>
                        <td>
                            <asp:Literal ID="ltlprice" runat="server" Visible="false"></asp:Literal></td>
                        <td>
                            <asp:Literal ID="ltlylxwgt" runat="server"></asp:Literal></td>
                        <td>
                            <asp:Literal ID="ltldlxwgt" runat="server"></asp:Literal></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <th>
                            <input id="cbxAll" type="checkbox" class="qx1" />全选</th>
                        <th>合同编码</th>
                        <th class="red">NC状态</th>
                        <th class="red">执行状态</th>
                        <th>签订日期</th>
                        <th>计划终止日期</th>
                        <th>审批类型</th>
                        <th>部门</th>
                        <th>客户名称</th>
                        <th class="red">合同状态</th>
                        <th>物料编码</th>
                        <th>物料名称</th>
                        <th>规格</th>
                        <th>钢种</th>
                        <th>数量</th>
                        <th>含税单价</th>
                        <th>价税合计</th>
                        <th class="red">已履行</th>
                        <th>待履行</th>
                        <th>自由项1</th>
                        <th>自由项2</th>
                        <th>包装要求</th>
                        <th>收货单位</th>
                        <th>发运方式</th>
                        <th>业务员</th>
                        <th>审批人</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">

                        <ItemTemplate>
                            <tr>
                                <td>
                                    <input id="cbxselect" class="che1" name="cbx" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' type="checkbox" />
                                </td>
                                <td>
                                    <%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %>
                                </td>
                                <td>
                                    <%#DataBinder.Eval (Container.DataItem,"C_NCSTATUS2") %>
                                    <asp:Literal ID="ltlncstatus" Text='<%#DataBinder.Eval (Container.DataItem,"C_NCSTATUS") %>' runat="server" Visible="false"></asp:Literal>
                                
                                </td>
                                <td>
                                    <%#DataBinder.Eval (Container.DataItem,"SCZT") %>
                                    <asp:Literal ID="ltlexestatus" Text='<%#DataBinder.Eval (Container.DataItem,"N_EXEC_STATUS") %>' runat="server" Visible="false"></asp:Literal></td>

                                <td><%#DataBinder.Eval (Container.DataItem,"D_DT","{0:yyy-MM-dd}") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"D_DELIVERY_DT","{0:yyy-MM-dd}") %></td>

                                <td><%#DataBinder.Eval (Container.DataItem,"C_FLOWID") %><%--审批类型--%></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_AREA") %><%--部门--%></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_STATUS2") %>
                                    <asp:Literal ID="ltlN_STATUS" Text='<%#DataBinder.Eval (Container.DataItem,"N_STATUS") %>' runat="server" Visible="false"></asp:Literal>
                                </td>
                                <td>
                                 <%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %>
                                </td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                                <td>
                                    <asp:Literal ID="ltlwgt" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT") %>' runat="server"></asp:Literal></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURTAXPRICE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURSUMMNY") %></td>
                                <td> <%#DataBinder.Eval (Container.DataItem,"YLXWGT") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"DLXWGT") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_FREE1") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_FREE2") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_PACK") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_RECEIPTCORPID") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_TRANSMODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_EMPLOYEEID") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_APPROVEID") %></td>
                            </tr>
                        </ItemTemplate>

                    </asp:Repeater>
                </tbody>
              
            </table>
        </div>
        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>

        <script type="text/javascript">

            selectAll("input.qx1", "input.che1");

            function checkcf() {
                var arr = [];
                $(".table tbody tr").find("td:first input:checkbox").each(function () {
                    var ischecked = $(this).prop("checked");
                    if (ischecked) {
                        var conno = $.trim($(this).parent().next().text());
                        arr.push(conno);
                    }
                });
                var result = true;
                for (var i = 0; i < arr.length - 1; i++) {
                    if (arr[i] != arr[i + 1]) {
                        result = false;
                        break;
                    }
                }
                if (result) {
                    return result;
                }
                else {
                    alert("请按相同合同号进行生成销售订单与日计划");
                    return false;
                }
            }
        </script>
    </form>

</body>
</html>
