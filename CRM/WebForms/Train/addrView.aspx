<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addrView.aspx.cs" Inherits="CRM.WebForms.Train.addrView" %>

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
                
                <td style="width:100px">发运方式
                </t>
                <td>
                    <asp:DropDownList ID="dropfyfs" runat="server" Width="100%"></asp:DropDownList></td>

                <td>
                    <asp:TextBox ID="txtaddr" placeholder="到货地点" Width="100%" runat="server"></asp:TextBox></td>

                <td>
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" />&nbsp;   
                </td>

            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="400" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th data-sortable="true">到货地点</th>
                    <th data-sortable="true">费用</th>
                   
                    <th data-sortable="true">发运方式</th>
                    

                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                  <a href="#" title="点击插入" onclick="SetInfo('<%#DataBinder.Eval (Container.DataItem,"C_ADDRNAME")%>','<%#DataBinder.Eval (Container.DataItem,"N_PRICE")%>');"><%#DataBinder.Eval (Container.DataItem,"C_ADDRNAME")%></a></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_PRICE") %>
                            </td>
                           
                            <td><%#DataBinder.Eval (Container.DataItem,"C_FAYUN") %></td>
                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>

        <input id="hidID" type="hidden" runat="server" />
        <input id="hidfyID" type="hidden" runat="server" />
        <script src="../Assets/js/jquery-2.0.3.min.js"></script>
        <script type="text/javascript">

            function SetInfo(id, name) {
                var index = $("#hidID").val();
                window.parent.SetAddr(id, name, index);
            }
        </script>
    </form>
</body>
</html>
