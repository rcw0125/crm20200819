<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cust_TechProt.aspx.cs" Inherits="CRM.BasicData.Cust_TechProt" %>

<%@ Register Src="~/BasicData/common.ascx" TagPrefix="uc1" TagName="common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>客户协议-自由项匹配</title>
    <uc1:common runat="server" ID="common" />

</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <tr>
                <td>
                    <asp:TextBox ID="txtcustno" runat="server" placeholder="客户编码" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtcustname" runat="server" placeholder="客户名称" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtstlgrd" runat="server" placeholder="钢种" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txttech_prot" runat="server" placeholder="客户协议" Width="100%"></asp:TextBox>
                </td>

                <td>
                    <asp:TextBox ID="txtstd" runat="server" placeholder="执行标准" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="查询" CssClass="btn  btn-primary btn-xs" OnClick="Button1_Click" />

                    &nbsp;
                    <a href="Cust_TechProtAdd.aspx" class="btn btn-primary btn-xs" id="btn_add" runat="server" visible="false">添加</a>

                    &nbsp;
                    <asp:Button ID="Button3" runat="server" Text="停用"  OnClientClick="return confirm('确定要停用吗')" CssClass="btn  btn-primary btn-xs" OnClick="Button3_Click" Visible="false" />
                      
                </td>
                <td><input id="cbxAll" type="checkbox" class="qx1"  style="height:15px; width:15px;" />全选   &nbsp;<asp:Button ID="btnflag" runat="server" Text="客户协议标记" CssClass="btn  btn-primary btn-xs" OnClick="btnflag_Click" Visible="false" /></td>
            </tr>
        </table>
        <table class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="450" id="table" style="white-space: nowrap;">
            <thead>
                <tr>

                    <th data-sortable="true">
                      钢种</th>
                    <th data-sortable="true">客户协议</th>
                    <th data-sortable="true">自由项1</th>
                    <th data-sortable="true">自由项2</th>
                    <th data-sortable="true">执行标准</th>
                    <th data-sortable="true">客户编码</th>
                    <th data-sortable="true">客户名称</th>
                    <th data-sortable="true">质证书</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr class='<%#DataBinder.Eval (Container.DataItem,"C_FLAG").ToString()=="Y"?"danger":"" %>'>
                            <td>
                                <input runat="server" class="che1" id="cbxselect" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' />
                                <%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_CUST_TECH_PROT") %> <asp:Literal ID="ltlflag" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_FLAG") %>' Visible="false"></asp:Literal>

                               
                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ZYX1") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ZYX2") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %></td>

                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NO") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ZZS") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
        <script type="text/javascript">
            //全选
            selectAll("input.qx1", "input.che1");
        </script>
    </form>
</body>
</html>
