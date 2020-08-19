<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCon.aspx.cs" Inherits="CRM.Cust_App.MyCon" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/My97DatePicker/WdatePicker.js"></script>
    <title>我的合同</title>



</head>
<body>
    <form runat="server">
        <div class="dv_btn">
            <ul>

                <li>
                    <button type="button" class="btn btn-warning btn-xs" onclick="return edit()">选定修改</button>
                </li>
                <li>
                    <a href="ConAdd.aspx" class="btn btn-warning btn-xs">新增合同</a>
                </li>

            </ul>
        </div>

        <table class="table table-bordered">

            <tr>
               
                <td >
                    <input id="txtCon" runat="server" type="text"  placeholder="合同号" class="input-xlarge" /></td>
              
                <td>
                    <input id="txtConName" runat="server" type="text"  placeholder="合同名称" class="input-xlarge" /></td>
                <td>类型</td>
                <td><asp:DropDownList ID="dropConType" runat="server"></asp:DropDownList></td>
                <td>状态</td>
                <td><asp:DropDownList ID="dropState" runat="server"></asp:DropDownList></td>
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

        <table class="table table-bordered table-hover" id="data_table">
            <thead>
                <tr>
                    <th style="width: 30px; text-align: center">#</th>
                    <th>合同号</th>
                    <th>合同名称</th>
                    <th>客户</th>
                    <th>合同状态</th>
                    <th>合同签署日期</th>
                    <th>计划生效日期</th>
                    <th>计划失效日期</th>
                    <th>货币类型</th>
                    <th>合同类型</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center">
                                <input id="radNO" class="che2" type="radio" name="0" value='<%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %>' />
                            </td>
                            <td><a href="ConView.aspx?ID=<%#DataBinder.Eval (Container.DataItem,"C_CON_NO")%>" title="查看明细"><%#DataBinder.Eval (Container.DataItem,"C_CON_NO")%></a></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NAME")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME")%></td>
                            <td><%#GetOrderState(DataBinder.Eval (Container.DataItem,"N_CON_STATUS"))%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONSING_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONEFFE_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONINVALID_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CON_TYPE")%></td>
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
                if (state == "未提交") {
                    window.location.href = "ConAdd.aspx?ID=" + test.val();
                }
                else {
                    alert("当前状态：暂时无法操作");
                    return false;
                }
            }
        </script>
        <asp:Literal ID="ltlUserID" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
