<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="CRM.WebForms.Cust_App.OrderList" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>历史签单列表</title>
    <uc1:common runat="server" ID="common" />
    <script src="../JsDate.js"></script>
    <script src="../../Assets/js/jsselect.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 80px;" class="right">签单日期：</td>
                <td style="width: 125px;">
                    <input id="Start" runat="server" type="text" readonly="readonly" class="form-control Wdate" style="width: 120px" />

                </td>
                <td style="width: 125px;">
                    <input id="End" runat="server" type="text" readonly="readonly" class="form-control Wdate" style="width: 120px" />
                </td>

                <td>
                    <asp:TextBox ID="txtConNo" placeholder="合同号" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="txtConNo_TextChanged"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtstlgrd" placeholder="钢种" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="txtstlgrd_TextChanged"></asp:TextBox></td>


                <td style="width: 180px;">
                    <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btnSearch_Click" />



                    &nbsp;<asp:Button ID="btnOk" runat="server" Text="加入签单" CssClass="btn btn-info btn-xs" OnClick="btnOk_Click" />
                </td>

            </tr>
        </table>
        <div style="overflow: auto; width: 100%; height: 360px" id="flow1">
            <table class="table table-bordered table-hover table-condensed" style="white-space: nowrap;">
                <thead>
                    <tr>
                        <th>
                            <input id="cbxAll" type="checkbox" class="qx1" />全选</th>
                        <th>合同号</th>

                        <th>物料编码</th>
                        <th>物料名称</th>
                        <th>钢种</th>
                        <th>规格</th>
                        <th>协议号</th>
                        <th>包装标准</th>
                        <th>数量(吨)</th>
                        <th>含税单价</th>
                        <th>价税合计</th>

                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="text-center">
                                    <input id="chkMat_Code" class="che1" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_INVENTORYID")%>' type="checkbox" /></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NO")%></td>

                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC")%></td>
                                <td>
                                    <asp:Literal ID="ltlC_TECH_PROT" Text='<%#DataBinder.Eval (Container.DataItem,"C_TECH_PROT")%>' runat="server"></asp:Literal>
                                    <asp:Literal ID="ltlC_STD_CODE" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE")%>' runat="server"></asp:Literal>
                                    <asp:Literal ID="ltlzyx1" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_FREE1")%>'></asp:Literal>
                                    <asp:Literal ID="ltlzyx2" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_FREE2")%>'></asp:Literal>
                                    <asp:Literal ID="ltlC_IS_BXG" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_BY4")%>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="ltlC_PACK" Text='<%#DataBinder.Eval (Container.DataItem,"C_PACK")%>' runat="server"></asp:Literal></td>
                               
                                <td>
                                    <asp:Literal ID="ltlwgt" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT")%>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="ltlprice" Text='<%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURTAXPRICE")%>' runat="server"></asp:Literal>
                                </td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURSUMMNY")%></td>

                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </tbody>
               
            </table>
        </div>

        <script type="text/javascript">
            //全选
            selectAll("input.qx1", "input.che1");
        </script>
        <asp:Literal ID="ltlcustno" runat="server" Visible="false">0</asp:Literal>
    </form>
</body>
</html>
