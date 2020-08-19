<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintRecord.aspx.cs" Inherits="CRM.WebForms.Report.PrintRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>打印记录</title>
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
                    alert("请选择要修改的记录！");
                    return false;
                } else {
                    checkBoxValue = checkBoxValue.substring(0, checkBoxValue.length - 1);
                    _iframe('/WebForms/Report/PrintRecordDel.aspx?ID=' + checkBoxValue + '&Type='+$("#ddlCerType").val(), '800', '300', '修改打印记录');
                        return;
                }
        }
    </script>
</head>
<body onresize="fromsize();">
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                     证书类型：
                      <asp:DropDownList ID="ddlCerType" runat="server">
                        <asp:ListItem Value="1">普通质证书</asp:ListItem>
                        <asp:ListItem Value="2">委外质证书</asp:ListItem>              
                    </asp:DropDownList>
                    是否修改：
                      <asp:DropDownList ID="ddlDel" runat="server">
                        <asp:ListItem Value="0">未修改</asp:ListItem>
                        <asp:ListItem Value="1">已修改</asp:ListItem>              
                    </asp:DropDownList>
                      <asp:TextBox ID="txtNo" placeholder="证书号" runat="server" Width="150px"></asp:TextBox>
                    &nbsp;
                     <asp:TextBox ID="txtFYD" placeholder="发运单号" runat="server" Width="200px"></asp:TextBox>
                    &nbsp;
                     <asp:TextBox ID="txtUpdateUser" placeholder="操作人" runat="server" Width="200px"></asp:TextBox>
                    &nbsp;
                     操作日期：<input id="txtStart" runat="server"  type="text" onclick="WdatePicker({ isShowClear: false, readOnly: true })" style="width: 80px;" readonly="readonly" class="Wdate" />-
                    <input id="txtEnd" runat="server" type="text" style="width: 80px;" readonly="readonly" onclick="WdatePicker({ isShowClear: false, readOnly: true })" class="Wdate" />
                   <asp:Button ID="btncx" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btncx_Click" />
                    <input type="button"  class="btn btn-primary btn-xs" onclick="del()" value="修改" />
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
                                    <th>类型</th>
                                    <th>证书号</th>
                                    <th>发运单号</th>
                                    <th>操作日期</th>
                                    <th>操作人</th>
                                    <th style="text-align:left;max-width:200px;width:150px;">证书备注</th>
                                    <th>修改原因</th>
                                    <th>修改次数</th>
                     
                                   <%-- <th>规格</th>
                                    <th>钢种</th>
                                    
                                   
                                    <th>车牌号</th>--%>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptList" runat="server">
                                    <ItemTemplate>
                                        <tr class="trContent">
                                            <td class="tdCheck">
                                                   <input id="chkSelect" runat="server" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' class="che2" />
                                            </td>
                                            <td><%#ShowType(Eval("C_TYPE").ToString()) %></td>
                                            <td>
                                                <%#DataBinder.Eval (Container.DataItem,"C_CERTIFICATE_NO")%>
                                            </td>                                            
                                             <td><%#DataBinder.Eval (Container.DataItem,"C_DISPATCH_ID")%></td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"C_EMP_ID")%></td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"D_MOD_DT")%></td>
                                            <td style="max-width:200px;width:200px; white-space:pre-line;"><%#DataBinder.Eval (Container.DataItem,"C_REMARK")%></td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"C_DEL_REMARK")%></td>
                                             <td><%#DataBinder.Eval (Container.DataItem,"N_UPDATE_TIME")%></td>
                                           <%-- <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC")%></td>
                                               <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"C_STD_CODE")%></td>
                                           
                                             <td><%#DataBinder.Eval (Container.DataItem,"C_LIC_PLA_NO")%></td>   --%>                                           
                                             
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
