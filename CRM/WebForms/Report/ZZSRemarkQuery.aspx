<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZZSRemarkQuery.aspx.cs" Inherits="CRM.WebForms.Report.ZZSRemarkQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加质证书打印</title>
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
         text-align:center;
        }
        .trContent td .trContent td input{
            text-align:center;
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
        function openDialog(id) {
            if (id == "") {
                var cId = "";
                _iframe('/WebForms/Report/ZZSR_Add.aspx?' + cId, '800', '400', '质证书备注添加');
                return;
            }
            else {                
                _iframe('/WebForms/Report/ZZSR_Add.aspx?ID=' + id, '800', '400', '质证书备注修改');
                return;
            }
        }
        function refers() {
            close();
            $("#btncx").click();
        }      
    </script>
</head>
<body onresize="fromsize();">
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    类型：                  
                     <asp:DropDownList ID="ddlType" runat="server" Width="120">                        
                    </asp:DropDownList>
                    <asp:TextBox ID="txtKey" placeholder="执行标准+钢种" runat="server" Width="150px"></asp:TextBox>
                    &nbsp;
                    <asp:TextBox ID="txtValue" placeholder="备注" runat="server" Width="200px"></asp:TextBox>
                    &nbsp;
                   <asp:Button ID="btncx" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btncx_Click" />
                    &nbsp;
                   <button id="btnAdd" class="btn btn-primary btn-xs" onclick="openDialog('')" type="button" >添加</button>

                    <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="btn btn-primary btn-xs" OnClick="btnDel_Click"/>
                  </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed">
            <tr>                
                <td id="td1">
                    <div style="overflow: auto; width: 100%" id="flow1">
                        <table class="table table-bordered table-condensed table-hover text-nowrap" >
                            <thead>
                                <tr id="trHead">
                                    <th>序号</th> 
                                    <th>选择框</th> 
                                    <th>执行标准+钢种</th>  
                                    <th  style="text-align:left;max-width:200px;width:200px;">备注</th>
                                     <th>操作人</th>  
                                    <th>操作时间</th>
                                     <th>操作</th>                                                
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptList" runat="server">
                                    <ItemTemplate>
                                        <tr class="trContent" >
                                           <td> <%# this.rptList.Items.Count + 1%> </td>
                                            <td class="tdCheck">
                                                <input runat="server"   id="cbxselect" type="checkbox"  />
                                         <asp:Literal ID="lblCID"  Visible="false"  Text='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' runat="server"></asp:Literal>
                                            </td>        
                                             <td>
                                                <%#DataBinder.Eval (Container.DataItem,"C_KEY")%>
                                            </td>
                                            <td style="max-width:200px;width:200px; white-space:pre-line;"><%#DataBinder.Eval (Container.DataItem,"C_VALUE")%></td>                                            
                                            <td><%#DataBinder.Eval (Container.DataItem,"C_EMP_ID")%></td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"D_MOD_DT")%></td>         
                                             <td><a href="#" onclick="openDialog('<%# DataBinder.Eval (Container.DataItem,"C_ID")%>')">修改</a></td>   
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
