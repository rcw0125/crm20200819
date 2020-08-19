<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConList.aspx.cs" Inherits="CRM.Sale_App.ConList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <title>销售合同</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/My97DatePicker/WdatePicker.js"></script>


</head>
<body>
    <form runat="server">
        <div class="dv_btn">
            <ul>

                <li id="BA" runat="server">
                    <asp:Button ID="btnEdit" runat="server" Text="合同变更" CssClass="btn btn-warning btn-xs" OnClientClick="return SetCon();" OnClick="btnEdit_Click" />
                   

                </li>
                <li id="BB" runat="server">
                    <button type="button" class="btn btn-warning btn-xs" onclick="return edit();">合同维护</button>
                </li>

            </ul>
        </div>
        <table class="table table-bordered">

            <tr>

                <td>
                    <input id="txtCon" runat="server" type="text" placeholder="合同号" /></td>

                <td>
                    <input id="txtConName" runat="server" type="text" placeholder="合同名称" /></td>
                <td>合同类型</td>
                <td>
                    <asp:DropDownList ID="dropType" runat="server"></asp:DropDownList></td>
                <td>合同状态</td>
                <td>
                    <asp:DropDownList ID="dropState" runat="server">
                        <asp:ListItem Value="全部">全部</asp:ListItem>
                        <asp:ListItem Value="-1">未提交</asp:ListItem>
                        <asp:ListItem Value="0">待审</asp:ListItem>
                        <asp:ListItem Value="1">审核中</asp:ListItem>
                        <asp:ListItem Value="2">生效</asp:ListItem>
                    </asp:DropDownList></td>

                <td>签署日期</td>
                <td>
                    <input id="Start" type="text" style="width: 110px;" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, maxDate: '#F{$dp.$D(\'End\')}' })" runat="server" /></td>

                <td>
                    <input id="End" runat="server" type="text" style="width: 110px;" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, minDate: '#F{$dp.$D(\'Start\')}' })" /></td>
                <td>


                    <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn btn-primary btn-xs btn_w60" OnClick="btnSearch_Click" />
                </td>

            </tr>
        </table>

        <table class="table table-bordered table-hover">
            <thead>
                <tr>
                    <th>#</th>
                    <th>合同号</th>
                    <th>合同名称</th>
                    <th>客户/等级</th>
                    <th>合同状态</th>
                    <th>合同签署日期</th>
                    <th>计划生效日期</th>
                    <th>计划失效日期/系统</th>
                    <th>合同类型</th>

                    <th>货币类型</th>
                    <th>发运方式</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>

                            <td style="text-align: center">
                                <input id="radNO" class="che2" type="radio" name="0" value='<%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %>' />
                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NAME")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME")%><%#DataBinder.Eval (Container.DataItem,"N_CUST_LEV")%></td>
                            <td><%#GetOrderState(DataBinder.Eval (Container.DataItem,"N_CON_STATUS"))%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONSING_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONEFFE_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONINVALID_DT","{0:yyy-MM-dd}")%>&nbsp;/&nbsp;<span style="color: red"><%#DataBinder.Eval (Container.DataItem,"D_SYS_CONINVALID_DT","{0:yyy-MM-dd}")%></span></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CON_TYPE")%></td>

                            <td><%#DataBinder.Eval (Container.DataItem,"C_CURRENCY_TYPE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SHIPVIA")%></td>

                        </tr>
                    </ItemTemplate>

                </asp:Repeater>


            </tbody>
        </table>
        <div class="div_page">

            <webdiyer:AspNetPager ID="Pager1" runat="server" CssClass="paginator" CurrentPageButtonClass="paginator"
                CurrentPageButtonPosition="End" CustomInfoHTML="总记录：%RecordCount% &nbsp;页码：%CurrentPageIndex% / %pageCount% &nbsp; 每页：%PageSize%"
                CustomInfoSectionWidth="350px" CustomInfoTextAlign="Center" FirstPageText="首页"
                HorizontalAlign="Right" LastPageText="尾页"
                meta:resourcekey="AspNetPager" NextPageText="下一页"
                NumericButtonCount="5" PagingButtonClass=""
                PrevPageText="前一页" showinputbox="Never" ShowNavigationToolTip="True" ShowPageIndexBox="Never"
                Width="100%" PageSize="18" CustomInfoClass="paginator" OnPageChanged="Pager1_PageChanged">
                <span style="color: #000000"></span><strong></strong><span style="color: #000000">&nbsp;&lt;
                            &gt;</span>
            </webdiyer:AspNetPager>
        </div>
        <script src="../Assets/js/jquery-2.0.3.min.js"></script>
        <script src="../Assets/js/common.js"></script>
        <script type="text/javascript">

            function edit() {

                var test = $("input[class='che2']:checked");
                var state = test.parent().parent().children("td").get(4).innerHTML;
                if (state == "待审" || state == "撤回") {
                    window.location.href = "ConEdit.aspx?ID=" + test.val();
                }
                else {
                    alert("当前状态：暂时无法操作");
                    return false;
                }
            }

        function SetCon() {

            if (confirm("确定变更吗")) {

                var conNo = $("input[class='che2']:checked");
                $("#hidconNO").val(conNo.val());
                return true;
            }
            return false;
        }


        </script>
        <input id="hidconNO" runat="server" type="hidden" />
    </form>
</body>
</html>
