<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addrList.aspx.cs" Inherits="CRM.WebForms.Train.addrList" %>

<%@ Register Src="~/WebForms/Train/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>到货地点费用管理</title>
    <uc1:rollControl runat="server" ID="rollControl" />
    <script type="text/javascript">
         $(function () {
            selectAll("input.qx1", "input.che1");
        });
        function openweb(index) {

            switch (index) {

                case 1:
                    var url = "addrAdd.aspx";
                    _iframe(url, '600', '500', '到货地点费用录入');
                    break;
            }

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                
                <td  style="width: 60px;">
                    发运方式
                   </td>
                <td style="width:200px"><asp:DropDownList ID="dropfyfs" runat="server" Width="200"></asp:DropDownList></td>
              
                <td style="width: 110px;">
                  <asp:TextBox ID="txtaddr" placeholder="到货地点" Width="100%" runat="server"></asp:TextBox></td>

                <td>
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" />&nbsp;   
                     <input id="btnadd" type="button" class="btn  btn-success btn-xs" value="添加" onclick="openweb(1);" />&nbsp;<asp:Button ID="btnsave" runat="server" Text="保存" CssClass="btn  btn-success btn-xs" OnClick="btnsave_Click" />&nbsp;<asp:Button ID="btndel" runat="server" Text="关闭" CssClass="btn btn-danger btn-xs" OnClientClick="return confirm('确定要关闭吗？');" OnClick="btndel_Click" />

                </td>

            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="500" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th> <input id="cbxAll" type="checkbox" class="qx1" />选择</th>
                   
                    <th data-sortable="true">发运方式</th>
                    <th data-sortable="true">到货地点</th>
                    <th data-sortable="true">费用</th>
                    <th data-sortable="true">生效日期</th>
                    <th data-sortable="true">失效日期</th>
                    <th data-sortable="true">制单人</th>
                    <th data-sortable="true">制单日期</th>
                    <th data-sortable="true">最后修改人</th>
                    <th data-sortable="true">最后修改时间</th>
                  
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><input id="cbxselect" runat="server" class="che1" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' />
                                <%#Container.ItemIndex+1 %>
                            </td>
                         
                            <td> <asp:Literal ID="ltlC_FAYUN" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_FAYUN") %>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlC_ADDRNAME" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_ADDRNAME") %>'></asp:Literal></td>
                            <td>
                             <asp:TextBox ID="txtprice" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_PRICE") %>'></asp:TextBox></td>
                            <td><input id="txtStart" type="text" style="width: 120px;" readonly="readonly" class="form-control Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true })" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"D_START_DT","{0:yyyy-MM-dd}") %>' /></td>
                            <td><input id="txtEnd" type="text" style="width: 120px;" readonly="readonly" class="form-control Wdate"  onclick="WdatePicker({ isShowClear: false, readOnly: true })" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"D_END_DT","{0:yyyy-MM-dd}") %>'/></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CREATE_EMP") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CREATE_DT","{0:yyyy-MM-dd}") %></td>
                             <td><%#DataBinder.Eval (Container.DataItem,"C_EMP") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_EMP") %></td>
                          
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>

          <asp:ImageButton ID="imgbtnJz" runat="server" OnClick="imgbtnJz_Click" ImageUrl="~/Assets/images/btntm.gif" Height="0px" Width="0px" />
    </form>
</body>
</html>
