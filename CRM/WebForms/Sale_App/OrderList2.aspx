<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList2.aspx.cs" Inherits="CRM.WebForms.Sale_App.OrderList2" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>订单查询</title>
    <uc1:common2 runat="server" ID="common2" />
    <script src="../JsDate.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox runat="server" placeholder="客户名称" ID="txtcustname" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtconno" placeholder="合同号" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtyewuyuan" placeholder="业务员" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtstlgrd" placeholder="钢种" runat="server" Width="100%"></asp:TextBox></td>
                  <td>
                    <asp:TextBox ID="txtspec" placeholder="规格" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtmatcode" placeholder="物料编码" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:DropDownList ID="droptype" runat="server">
                        <asp:ListItem Value="8">线材</asp:ListItem>
                        <asp:ListItem Value="6">钢坯</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 80px;">日期</td>
                <td>
                    <input id="txtStart" type="text" style="width: 110px;" readonly="readonly" class=" form-control Wdate" runat="server" /></td>

                <td>
                    <input id="txtEnd" runat="server" type="text" style="width: 110px;" readonly="readonly" class=" form-control Wdate" /></td>
                <td style="width: 100px;">
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" />
                    &nbsp;<asp:Button ID="Button1" CssClass="btn btn-primary btn-xs" runat="server" Text="确定" OnClick="Button1_Click" />

                </td>
            </tr>
        </table>
        <div class="table-responsive" style="width: 100%; height:380px; overflow: auto;">
            <table class="table table-bordered table-hover table-condensed" style="white-space: nowrap;">
                <thead>
                    <tr>
                        <th>选择框</th>
                        <th>合同号</th>
                      
                        <th>钢种</th>
                        <th>规格</th>
                        <th>数量</th>
                        <th>已履行</th>
                        <th>待履行</th>
                        <th>执行标准</th>
                        <th>自由项1</th>
                        <th>自由项2</th>
                        <th>包装要求</th>
                       
                        
                        <th>区域</th>
                        <th>存货编码</th>
                        <th>存货名称</th>
                          <th>计划发货日期</th>
                        <th>订单类型</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <input id="chkOrder"  style="width:15px;"  class="che1" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' type="checkbox" />
                                    <asp:Literal ID="ltlpkplan" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"PKPLAN")%>' runat="server"></asp:Literal>
                                </td>
                                <td>  <asp:Literal ID="ltlC_CON_NO" Text='<%#DataBinder.Eval (Container.DataItem,"C_CON_NO")%>' runat="server"></asp:Literal></td>
                              
                                <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC")%></td>
                                <td>
                                    <asp:Literal ID="ltlorderwgt" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"ORDERWGT")%>'></asp:Literal></td>
                                  <td>
                                    <asp:Literal ID="ltlyfywgt" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"YLXWGT")%>'></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltldlxwgt" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"DLXWGT")%>'></asp:Literal></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_STD_CODE")%></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_FREE1")%></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_FREE2")%></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_PACK")%></td>
                               
                              
                                <td><%#DataBinder.Eval (Container.DataItem,"C_AREA")%></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%></td>
                                  <td><%#DataBinder.Eval (Container.DataItem,"D_DELIVERY_DT","{0:yyy-MM-dd}")%></td>

                                <td>
                                    <asp:Literal ID="ltlN_TYPE" Text='<%#DataBinder.Eval (Container.DataItem,"N_TYPE")%>' runat="server"></asp:Literal></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </tbody>
            </table>
        </div>
        <asp:Literal ID="ltlempid" Visible="false" runat="server">0</asp:Literal>
    </form>
</body>
</html>
