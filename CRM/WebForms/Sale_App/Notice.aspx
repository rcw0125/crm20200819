<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notice.aspx.cs" Inherits="CRM.Sale_App.Notice" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>公告</title>
    <uc1:common2 runat="server" ID="common2" />
    <script src="../JsDate.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dv_btn">
            <ul>
                <li id="BC"  runat="server" visible="false">
                 <asp:Button ID="btnDel" runat="server" Text="删除" class="btn btn-warning btn-xs" OnClientClick="return delMsg();" OnClick="btnDel_Click" />   
                </li>
                <li id="BB"  runat="server" visible="false">
                    <button type="button" class="btn btn-warning btn-xs" onclick="edit();">修改</button>
                </li>
                <li id="BA"  runat="server" visible="false">
                    <a href="NoticeAdd.aspx" class="btn btn-warning btn-xs">发布</a>
                </li>
            </ul>
        </div>

        <table class="table table-bordered table-condensed">

            <tr>
                <td  class="right">分类</td>
                <td>
                    <asp:DropDownList ID="dropClass" runat="server"></asp:DropDownList></td>
                <td  class="right">标题</td>
                <td>
                    <input id="txtTitle" type="text" runat="server" style="width:100%" /></td>
                <td  class="right">日期</td>
                <td style="width: 125px;">
                    <input id="Start" type="text" style="width: 120px;" runat="server" readonly="readonly" class="form-control Wdate" />
                </td>  
               <td style="width: 125px;">

                   <input id="End" type="text"  style="width: 120px;" runat="server" readonly="readonly" class="form-control Wdate" />
               </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-xs" Text="查询" OnClick="btnSearch_Click" /> </td>

            </tr>
        </table>

        <table class="table table-bordered table-hover table-condensed" id="data_table">
            <thead>
                <tr>
                    <th style="width: 30px; text-align: center"><input class="qx1" type="checkbox" name="" value="" /></th>

                    <th>标题</th>
                    <th>发布时间</th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center">
                                <input id="chkSelect" runat="server" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' class="che2" />
                            </td>
                            <td>
                                <a href='NoticeView.aspx?ID=<%#DataBinder.Eval (Container.DataItem,"C_ID") %>'>
                                <%#DataBinder.Eval (Container.DataItem,"C_TITLE") %>
                                    </a></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_MOD_DT") %></td>
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
          <script src="../../Assets/js/jquery-2.0.3.min.js"></script>
        <script src="../../Assets/js/common.js"></script>
        <script type="text/javascript">

            //全选
            selectAll("input.qx1", "input.che2");
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

                        var url = "NoticeEdit.aspx?ID=" + arr[0];
                        $(location).attr('href',url);
                    }
                }
            }
        </script>
    </form>
</body>
</html>
