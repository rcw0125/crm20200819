<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatList4.aspx.cs" Inherits="CRM.WebForms.Cust_App.MatList4" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>产品</title>
    <uc1:common runat="server" ID="common" />

</head>
<body>
    <form id="form1" runat="server">

         <table class="table table-bordered">
                    <tr>
                        <td style="width: 100px">钢种类型</td>
                        <td style="width: 80px;">
                            <asp:DropDownList ID="dropType" runat="server" Width="100%">
                                <asp:ListItem Value="0">线材</asp:ListItem>
                                <asp:ListItem Value="1">钢坯</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtmatcode" placeholder="物料编码" runat="server" Width="100%"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtstlgrd" placeholder="钢种" runat="server" Width="100%"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tstspec" placeholder="规格" runat="server" Width="100%"></asp:TextBox></td>
                        <td style="width: 120px;">
                            <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn btn-primary btn-xs " OnClientClick="_loading(1);" OnClick="btnSearch_Click" />&nbsp;
                      <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="btn  btn-info btn-xs" OnClick="btnAdd_Click" /></td>
                    </tr>
                </table>
               
        
                <table class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="350" style="white-space: nowrap;">
                    <thead>
                        <tr>
                            <th>选择</th>
                            <th data-sortable="true">物料编码</th>
                            <th data-sortable="true">物料名称</th>
                            <th data-sortable="true">钢种</th>
                            <th data-sortable="true">规格</th>
                            <th data-sortable="true">客户协议</th>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <input id="chkMat_Code" style="width: 15px;" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' type="checkbox" /></td>
                                    <td>
                                        <asp:Literal ID="ltlmatcode" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%>'></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlmatname" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%>'></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlstlgrd" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>'></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlspec" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC")%>'></asp:Literal></td>
                                    <td>

                                        <asp:Literal ID="ltlC_CUST_TECH_PROT" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE").ToString()==""?DataBinder.Eval (Container.DataItem,"C_STD_CODE"):DataBinder.Eval (Container.DataItem,"C_CUST_TECH_PROT")%>'></asp:Literal>
                                        <asp:Literal ID="ltlC_STD_CODE" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE")%>'></asp:Literal>
                                        <asp:Literal ID="ltlzyx1" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_ZYX1")%>'></asp:Literal>
                                        <asp:Literal ID="ltlzyx2" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_ZYX2")%>'></asp:Literal>
                                        <asp:Literal ID="ltlC_IS_BXG" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_IS_BXG")%>'></asp:Literal>

                                    </td>


                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>


                </table>
        <asp:Literal ID="ltlCustNo" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlprockind" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlprocname" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
