<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roll_prodcut2_sub.aspx.cs" Inherits="CRM.WebForms.Report.roll_prodcut2_sub" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>批次单卷线材仓库调配</title>
    <uc1:common runat="server" ID="common" />
    <script src="js/jsroll_prodcut.js"></script>

</head>
<body>
    <form id="form1" runat="server">

        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 80px">需求区域</td>
                <td style="width: 150px;">
                    <asp:DropDownList ID="dropneedarea" runat="server" Width="100%"></asp:DropDownList></td>
                <td>
                    <asp:Button ID="btnedit" CssClass="btn btn-primary btn-xs" runat="server" Text="修改" OnClick="btnedit_Click" OnClientClick="confi" />

                </td>
            </tr>
        </table>

        <div style="overflow: auto; width: 100%" id="flow1">
            <table class="table table-bordered table-hover table-condensed" style="white-space: nowrap;">
                <thead>
                    <tr>
                        <th>合计</th>

                        <th>&nbsp;</th>
                        <th>&nbsp;</th>
                        <th>&nbsp;</th>
                        <th></th>
                        <th>&nbsp;</th>
                        <th>
                            <asp:Literal ID="ltlsumwgt" runat="server"></asp:Literal></th>
                        <th>&nbsp;</th>
                        <th>&nbsp;</th>
                        <th>&nbsp;</th>
                        <th>&nbsp;</th>
                        <th>&nbsp;</th>
                        <th>&nbsp;</th>
                        <th>&nbsp;</th>
                        <th>&nbsp;</th>
                        <th>&nbsp;</th>
                        <th>&nbsp;</th>
                        <th>&nbsp;</th>
                    </tr>
                    <tr>
                        <th>
                            <input id="cbxAll" type="checkbox" class="qx1" />全选/序号</th>

                        <th>批次号</th>
                        <th>仓库</th>
                        <th>钢种</th>
                        <th>质量等级</th>
                        <th>待判结果</th>
                        <th>重量</th>
                        <th>销售区域</th>
                        <th>特殊信息</th>
                        <th>规格</th>
                        <th>物料名称</th>
                        <th>物料编码</th>
                        <th>执行标准</th>
                        <th>自由项1</th>
                        <th>自由项2</th>
                        <th>包装要求</th>
                        <th>生产日期</th>
                        <th>客户信息</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <input id="cbxselect" runat="server" class="che1" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' />

                                    <%# Container.ItemIndex+1 %>
                                </td>

                                <td>
                                    <asp:Literal ID="ltlbatch" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %>'></asp:Literal>
                                </td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_CODE") %></td>
                                <td>
                                    <asp:Literal ID="ltlstlgrd" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>' runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltllev" Text='<%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %>' runat="server"></asp:Literal></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH").ToString()==""?"待判":"" %></td>
                                <td>
                                    <asp:Literal ID="ltlN_WGT" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="ltlsalearea" Text='<%#DataBinder.Eval (Container.DataItem,"C_SALE_AREA") %>' runat="server"></asp:Literal></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_PCINFO") %></td>
                                <td>
                                    <asp:Literal ID="ltlspec" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC") %>' runat="server"></asp:Literal></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_DESC") %></td>
                                <td>
                                    <asp:Literal ID="ltlmatcode" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %>' runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltlstdcode" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %>' runat="server"></asp:Literal></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_ZYX1") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_ZYX2") %></td>
                                <td>
                                    <asp:Literal ID="ltlpack" Text='<%#DataBinder.Eval (Container.DataItem,"C_BZYQ") %>' runat="server"></asp:Literal></td>

                                <td><%#DataBinder.Eval (Container.DataItem,"D_PRODUCE_DATE","{0:yyy-MM-dd}") %></td>

                                <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <asp:Literal ID="ltlbatch" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlmatcode" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlarea" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltllev" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlpack" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlempname" runat="server" Visible="false"></asp:Literal>
    </form>

</body>
</html>
