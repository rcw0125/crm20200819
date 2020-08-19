<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatList5.aspx.cs" Inherits="CRM.WebForms.Sale_App.MatList5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>头尾材产品</title>
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Assets/css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>


                <table class="table table-bordered">
                    <tr>
                        <td style="width: 80px;">
                            <asp:CheckBox ID="cbxmatcode" Text="批量" runat="server" /></td>
                        <td>
                            <asp:TextBox ID="txtmatcode" placeholder="物料编码" runat="server" Width="100%" TextMode="MultiLine"  Height="50px"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtstlgrd" placeholder="钢种" runat="server" Width="100%"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tstspec" placeholder="规格" runat="server" Width="100%"></asp:TextBox></td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn btn-primary btn-xs " OnClick="btnSearch_Click" />&nbsp;
                      <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="btn  btn-info btn-xs" OnClick="btnAdd_Click" /></td>
                    </tr>
                </table>
                <table class="table table-bordered table-hover table-condensed">
                    <thead>
                        <tr>
                            <td> <input id="cbxAll" type="checkbox" class="qx1" style="width: 15px;" />全选</td>
                            <td>物料编码</td>
                            <td>物料名称</td>
                            <td>钢种</td>
                            <td>规格</td>
                            <td>库存量</td>
                            <td>自由项1</td>
                            <td>自由项2</td>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <input id="chkMat_Code" class="che1" style="width: 15px;" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%>' type="checkbox" />
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlmatcode" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%>'></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlmatname" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_DESC")%>'></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlstlgrd" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>'></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlspec" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC")%>'></asp:Literal></td>
                                     <td>
                                        <asp:Literal ID="ltlwgt" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT")%>'></asp:Literal>

                                    </td>
                                    <td>
                                        <asp:Literal ID="ltlzyx1" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_ZYX1")%>'></asp:Literal>

                                    </td>
                                    <td>

                                        <asp:Literal ID="ltlzyx2" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_ZYX2")%>'></asp:Literal>
                                        <asp:Literal ID="ltlC_STD_CODE" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE")%>'></asp:Literal>
                                         <asp:Literal ID="ltlzldj" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"ZLDJ")%>'></asp:Literal>
                                      
                                    </td>
                                 

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>


                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <script src="../../Assets/js/jquery-1.10.2.min.js"></script>
        <script src="../../Assets/js/common.js"></script>

             <script type="text/javascript">
            //全选
            selectAll("input.qx1", "input.che1");
        </script>

        <asp:Literal ID="ltlCustNo" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlCon_No" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlC_EMP_ID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlC_EMP_NAME" runat="server" Visible="false"></asp:Literal>
    </form>
</body>
</html>
