<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roll_prodcut3.aspx.cs" Inherits="CRM.WebForms.Report.roll_prodcut3" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>单卷线材自由分配</title>
    <uc1:common runat="server" ID="common" />
    <script src="js/jsroll_prodcut.js?ver=1.0"></script>
    <script type="text/javascript">
        function openWeb() {
            _iframe('../../Common/_CustList.aspx?flag=1', '490', '350', '客户');
        }

        function SetAddr(id, name) {

            $("#txtC_CGC").val(name);
            close();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox runat="server" placeholder="批次号" ID="txtbatchno" Width="80"></asp:TextBox></td>

                <td>
                    <asp:TextBox runat="server" placeholder="钢种" ID="txtstlgrd" Width="80"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="规格" ID="txtspec" Width="80"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="物料编码" ID="txtmatcode" Width="80"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="客户名称" ID="txtcustname" Width="80"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="合同号" ID="txtcon" Width="80"></asp:TextBox></td>
                <td><asp:TextBox ID="txtrow" placeholder="显示条数" CssClass="numJe" runat="server" Width="50"></asp:TextBox></td>
                <td style="width: 70px;">质量</td>
                <td>
                    <asp:DropDownList ID="dropzldj" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropzldj_SelectedIndexChanged"></asp:DropDownList></td>
                <td style="width: 70px;">区域</td>
                <td>
                    <asp:DropDownList ID="dropsalearea" runat="server"></asp:DropDownList>
                </td>

                <td>
                    <asp:DropDownList ID="droptsxx" runat="server" Width="100px"></asp:DropDownList></td>
                <td style="width: 60px;">待判</td>
                <td>
                    <asp:DropDownList ID="dropflag" runat="server" Height="17px">
                        <asp:ListItem Value="Y">已判</asp:ListItem>
                        <asp:ListItem Value="N">待判</asp:ListItem>
                    </asp:DropDownList></td>


                <td style="width: 200px;">
                    <asp:Button ID="btn_xc" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btn_xc_Click" OnClientClick="_loading(1);" />&nbsp;&nbsp;
                </td>
            </tr>

        </table>
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 80px">需求区域</td>
                <td style="width: 150px;">
                    <asp:DropDownList ID="dropneedarea" runat="server" Width="100%"></asp:DropDownList></td>
                <td style="width: 80px">需求客户</td>
                <td>
                    <input id="txtC_CGC" runat="server" type="text" style="width: 85%" readonly="readonly" />
                    <a href="javascript:void(0);" onclick="openWeb();"><span class="glyphicon glyphicon-search"></span></a>
                </td>
                <td style="width: 80px">需求合同</td>
                <td><asp:TextBox ID="txtNeedCon" runat="server" Width="100%"></asp:TextBox></td>
                <td style="width:500px">
                    <asp:Button ID="btnedit" Visible="false" CssClass="btn btn-primary btn-xs" runat="server" Text="单卷调配(10卷)" OnClick="btnedit_Click" OnClientClick="return _eidt();" />
                    &nbsp;
                   <asp:Button ID="btneditAll" Visible="false" CssClass="btn btn-primary btn-xs" runat="server" Text="多卷调配" OnClientClick="return _eidt();" OnClick="btneditAll_Click" />
                    &nbsp;
                    <asp:Button ID="btneditCust" Visible="false" runat="server" Text="客户及合同调配" CssClass="btn btn-primary btn-xs" OnClientClick="return _eidtCust();" OnClick="btneditCust_Click" />
                    &nbsp;
                   <asp:Button ID="btnD" runat="server" Text="质量(D,B1,B2,C1,C2)调配" CssClass="btn  btn-warning btn-xs" OnClick="btnD_Click" OnClientClick=" _loading(1);" />
                    &nbsp;
                     <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn btn-success btn-xs" OnClick="btnExport_Click" />
                </td>
            </tr>
        </table>


        <table class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="450" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th>合计</th>

                    <th>&nbsp;</th>
                    <th>总吨数</th>
                    <th>
                        <asp:Literal ID="ltlsumwgt" runat="server"></asp:Literal></th>
                    <th>总件数</th>
                    <th>
                        <asp:Literal ID="ltlsumqua" runat="server"></asp:Literal></th>
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
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                </tr>
                <tr>
                    <th>
                        <input id="cbxAll" type="checkbox" class="qx1" />全选/序号</th>
                    <th data-sortable="true">批次号</th>
                    <th data-sortable="true">仓库</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">重量</th>
                    <th data-sortable="true">生产日期</th>
                    <th data-sortable="true">质量等级</th>
                    <th data-sortable="true">待判结果</th>
                    <th data-sortable="true">销售区域</th>
                    <th data-sortable="true">客户信息</th>
                    <th data-sortable="true">合同号</th>
                    <th data-sortable="true">特殊信息</th>
                    <th data-sortable="true">物料名称</th>
                    <th data-sortable="true">物料编码</th>
                    <th data-sortable="true">执行标准</th>
                    <th data-sortable="true">自由项1</th>
                    <th data-sortable="true">自由项2</th>
                    <th data-sortable="true">包装要求</th>

                    <th data-sortable="true">原区域</th>
                    <th data-sortable="true">原客户</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input id="cbxselect" runat="server" class="che1" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' />
                                <%#Container.ItemIndex+1 %>
                            </td>

                            <td>
                                <asp:Literal ID="ltlbatch" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %>'></asp:Literal>


                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_CODE") %></td>
                            <td>
                                <asp:Literal ID="ltlstlgrd" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>' runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlspec" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC") %>' runat="server"></asp:Literal></td>

                            <td>
                                <asp:Literal ID="ltlN_WGT" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT") %>'></asp:Literal></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_PRODUCE_DATE","{0:yyy-MM-dd}") %></td>
                            <td>
                                <asp:Literal ID="ltllev" Text='<%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %>' runat="server"></asp:Literal></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH").ToString()==""?"待判":"" %></td>

                            <td>
                                <asp:Literal ID="ltlsalearea" Text='<%#DataBinder.Eval (Container.DataItem,"C_SALE_AREA") %>' runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlC_CUST_NAME" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %>'></asp:Literal></td>
                             <td>
                                <asp:Literal ID="ltlC_CON_NO" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %>'></asp:Literal></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_PCINFO") %></td>

                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_DESC") %></td>
                            <td>
                                <asp:Literal ID="ltlmatcode" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %>' runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlstdcode" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %>' runat="server"></asp:Literal></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ZYX1") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ZYX2") %></td>
                            <td>
                                <asp:Literal ID="ltlpack" Text='<%#DataBinder.Eval (Container.DataItem,"C_BZYQ") %>' runat="server"></asp:Literal>

                                <asp:Literal ID="ltlC_IS_QR" Text='<%#DataBinder.Eval (Container.DataItem,"C_IS_QR") %>' runat="server" Visible="false"></asp:Literal>

                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CKDH") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CKRY") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlempname" runat="server" Visible="false"></asp:Literal>
    </form>

</body>
</html>
