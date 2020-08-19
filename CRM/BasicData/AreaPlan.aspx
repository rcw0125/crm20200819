<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaPlan.aspx.cs" Inherits="CRM.BasicData.AreaPlan" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/BasicData/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- 上述3个meta标签*必须*放在最前面，任何其他内容都*必须*跟随其后！ -->
    <title>区域计划量</title>
    <uc1:common runat="server" id="common" />

</head>

<body>

    <form runat="server">
        <div class="dv_btn">
            <ul>
                <li runat="server" id="CC">
                    <asp:Button ID="btn_Del" runat="server" Text="删除" class="btn btn-warning btn-xs" OnClientClick="return delMsg();" OnClick="btn_Del_Click" />
                </li>
                <li runat="server" id="CB">
                    <button type="button" class="btn btn-warning btn-xs" onclick="edit();">修改</button>
                </li>
                <li runat="server" id="CA">
                    <button type="button" class="btn btn-warning btn-xs" onclick="add();">添加</button>
                </li>

            </ul>
        </div>
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width:50px;">区域</td>
                <td style="width:140px;"> <asp:DropDownList ID="dropArea" runat="server" Width="120px"></asp:DropDownList></td>
               
                <td>
 <asp:Button runat="server" Text="查 询 " ID="btn_Search" class="btn btn-primary btn-xs btn_w60" OnClick="btn_Search_Click" />
                </td>
            </tr>
            </table>
         <table class="table table-bordered table-hover  table-condensed">
                        <thead>
                            <tr>
                                <th style="width: 40px">
                                    <input class="qx1" type="checkbox" name="" value="" /></th>
                                <th>区域</th>
                                <th>计划量(吨)</th>
                                <th>开始时间</th>
                                <th>结束时间</th>
                                <th>操作人</th>
                                <th>操作时间</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpt_List" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <input class="che2" type="checkbox" name="" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' runat="server" id="chkSelect" />
                                        </td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_AERA_ID") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"N_WGT") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"D_START","{0:yyy-MM-dd}") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"D_END","{0:yyy-MM-dd}") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_EMP_NAME") %></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"D_MOD_DT") %></td>
                                    </tr>
                                </ItemTemplate>

                            </asp:Repeater>
                        </tbody>
                    </table>
           <div >
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
        <script type="text/javascript">

            //全选
            selectAll("input.qx1", "input.che2");

            function add() {
                 _iframe('AreaPlan_Add.aspx', '500', '400', '区域计划量');

            }
            function edit() {

                var test = $("input[class='che2']:checked");
                var checkBoxValue = "";
                test.each(function () {
                    checkBoxValue += $(this).val() + ",";
                });
                if (checkBoxValue == "") {
                    alert("请任选一项修改");
                    return false;
                } else {
                    checkBoxValue = checkBoxValue.substring(0, checkBoxValue.length - 1);
                    var arr = checkBoxValue.split(',');
                    if (arr.length > 1) {
                        alert("请任选一项修改");
                        return false;
                    } else {
                        var url = 'AreaPlanUpdate.aspx?ID='+arr[0];
                        _iframe(url, '500', '400', '区域计划量');
                    }
                }
            }
        </script>
    </form>
</body>
</html>


