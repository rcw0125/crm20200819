<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintCkdRecord.aspx.cs" Inherits="CRM.WebForms.Report.PrintCkdRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>质证书签证人/日期</title>
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Assets/css/common.css" rel="stylesheet" />
    <link href="../../Assets/css/bootstrap-datetimepicker.css" rel="stylesheet" />
    <link href="css/zeroModal.css" rel="stylesheet" />
    <script src="../../Assets/js/My97DatePicker/WdatePicker.js"></script>
    <script src="../../Assets/js/jquery-2.0.3.min.js"></script>

    <script src="../../Assets/js/bootstrap.min.js"></script>
    <script src="../../Assets/js/common.js"></script>
    <script src="js/zeroModal.js"></script>
    <script src="js/zeroModal.min.js"></script>
    <script src="../../Assets/js/_zero.js"></script>
    <style>
        #trHead th {
            text-align: center;
        }

        .trContent td .trContent td input {
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#td1 table tbody tr td").click(function () {
                if ($(this)[0].className == "tdCheck") {
                    return;
                }
                var input = $(this).parent().children(0).find("input");
                var ischecked = input.prop('checked');
                if (ischecked) {
                    input.prop('checked', '');
                }
                else {
                    input.prop('checked', 'checked');
                }
            });
        });

        function refers() {
            close();
            $("#btncx").click();
        }
        function del() {
              var test = $("input[class='che2']:checked");
                var checkBoxValue = "";
                test.each(function () {
                    checkBoxValue += $(this).val() + ",";
                });
                if (checkBoxValue == "") {
                    alert("请选择要删除的记录！");
                    return false;
                } 
        }
    </script>
</head>
<body onresize="fromsize();">
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    是否修改：
                      <asp:DropDownList ID="ddlDel" runat="server">
                        <asp:ListItem Value="1">未删除</asp:ListItem>
                        <asp:ListItem Value="0">已删除</asp:ListItem>              
                    </asp:DropDownList>
                      <asp:TextBox ID="txtFyd" placeholder="发运单号" runat="server" Width="150px"></asp:TextBox>
                    &nbsp;
                     <asp:TextBox ID="txtAttestor" placeholder="签证人" runat="server" Width="200px"></asp:TextBox>
                    &nbsp;
                     签证日期：<input id="txtStart" runat="server"  type="text" onclick="WdatePicker({ isShowClear: false, readOnly: true })"  style="width: 80px;" readonly="readonly" class="Wdate" />-
                    <input id="txtEnd" runat="server" type="text" style="width: 80px;"  onclick="WdatePicker({ isShowClear: false, readOnly: true })"  readonly="readonly" class="Wdate" />
               
                   <asp:Button ID="btncx" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btncx_Click" />
                   <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="btn btn-primary btn-xs" OnClientClick="del()" OnClick="btnDel_Click"  />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed">
            <tr>
                <td id="td1">
                    <div style="overflow: auto; width: 100%" id="flow1">
                        <table class="table table-bordered table-condensed table-hover text-nowrap">
                            <thead>
                                <tr id="trHead">
                                    <th>选择框</th>
                                    <th>发运单号</th>
                                    <th>签证人</th>
                                    <th>签证日期</th>                                   
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptList" runat="server">
                                    <ItemTemplate>
                                        <tr class="trContent">
                                            <td class="tdCheck">
                                                   <input id="chkSelect" runat="server" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' class="che2" />
                                            </td>
                                            <td>
                                                <%#DataBinder.Eval (Container.DataItem,"c_dispatch_id")%>
                                            </td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"C_ATTESTOR")%></td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"D_VISA_DT")%></td>                                             
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </tbody>
                        </table>
                    </div>

                </td>

            </tr>
        </table>
        <input id="hidempname" type="hidden" runat="server" />
    </form>

</body>
</html>
