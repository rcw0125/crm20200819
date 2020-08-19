<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZZSConfimRecord.aspx.cs" Inherits="CRM.WebForms.Report.ZZSConfimRecord" %>

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
                    <asp:TextBox ID="txtCKD" placeholder="出库单" runat="server" Width="150px"></asp:TextBox>
                    &nbsp;
                    <asp:TextBox ID="txtFYD" placeholder="发运单" runat="server" Width="200px"></asp:TextBox>
                    &nbsp;
                      <asp:TextBox ID="txtBatch" placeholder="批号" runat="server" Width="200px"></asp:TextBox>
                   <asp:Button ID="btncx" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btncx_Click" />
                  
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
                                    <th>出库单</th>  
                                    <th>批号</th>
                                    <th>发运单</th>   
                                    <th>修改后状态</th>    
                                    <th>操作人</th>  
                                    <th>操作时间</th>                
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptList" runat="server">
                                    <ItemTemplate>
                                        <tr class="trContent" >
                                           <td> <%# this.rptList.Items.Count + 1%> </td>                                         
                                             <td>
                                                <%#DataBinder.Eval (Container.DataItem,"C_CKD")%>
                                            </td>
                                            <td ><%#DataBinder.Eval (Container.DataItem,"C_BATCH")%></td>                                            
                                            <td><%#DataBinder.Eval (Container.DataItem,"C_FYD")%></td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"C_STATE")%></td>         
                                            <td><%#DataBinder.Eval (Container.DataItem,"C_EMP_NAME")%></td>         
                                             <td><%#DataBinder.Eval (Container.DataItem,"D_MOD_DT")%></td>         
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
