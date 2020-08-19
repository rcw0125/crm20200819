<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZZS_List.aspx.cs" Inherits="CRM.WebForms.Report.ZZS_List" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>质证书二维码生成</title>
    <uc1:ReptControl runat="server" ID="ReptControl" />
    <script type="text/javascript">
        function uploadDoc() {

            var zsh = "";
            var fyd = "";

            $('input[type=checkbox]:checked').each(function () {
                zsh = $.trim($(this).parent().parent().find("input.zsh").val());
                fyd = $.trim($(this).parent().parent().find("input.fyd").val());
            });
            if (zsh == "") {

                alert("请先审核");
            }
            else {
                var url = '/Common/_ZZSDoc.aspx?pk=' + fyd + '&zsh=' + zsh;
                _iframe(url, '500', '400', '上传文件');
            }


        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox ID="txtfyd" runat="server" placeholder="发运单号" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtch" runat="server" placeholder="车牌号" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtcust" runat="server" placeholder="客户" Width="100%"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtstlgrd" runat="server" placeholder="钢种" Width="100%"></asp:TextBox>
                </td>
               
                <td>
                    <asp:TextBox ID="txtbatch" runat="server" placeholder="批次" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="dropprint" runat="server">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem Value="0">未打印</asp:ListItem>
                        <asp:ListItem Value="1">已打印</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 80px">出库日期</td>
                <td style="width: 100px;">
                    <input id="txtckkssj" type="text" runat="server" style="cursor: pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td style="width: 100px;">
                    <input id="txtckjssj" type="text" runat="server" style="cursor: pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td style="width: 60px">
                    <asp:CheckBox ID="cbxww" Text="委外" runat="server" /></td>
                <td style="width: 60px;">
                    <asp:DropDownList ID="droptype" runat="server" Width="100%">
                        <asp:ListItem Value="8">线材</asp:ListItem>
                        <asp:ListItem Value="6">钢坯</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width:320px;">
                    <asp:Button ID="btnxc" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btnxc_Click" />
                    &nbsp;
                   <asp:Button ID="btnExport" Visible="false" runat="server" Text="审核" CssClass="btn btn-success btn-xs" OnClick="btnExport_Click" />
                    &nbsp;
                    <input id="btnfile"   runat="server" visible="false" type="button" value="上传文件" class="btn btn-success btn-xs" onclick="uploadDoc();" />
                    &nbsp;
                  <asp:Button ID="btncsh"  Visible="false" runat="server" Text="初始化" CssClass="btn btn-success btn-xs" OnClientClick="return confirm('确定操作吗')" OnClick="btncsh_Click" />
                    &nbsp;
                    <asp:Button ID="btnOut" runat="server" Text="导出" CssClass="btn btn-success btn-xs" OnClick="btnOut_Click" />
                </td>

            </tr>
        </table>
        <table class="table table-bordered table-condensed" data-toggle="table" data-height="450" id="table" style="white-space: nowrap;">
            <thead>

                <tr>
                    <th data-sortable="true">选择框</th>
                    <th data-sortable="true">操作</th>
                    <th data-sortable="true">证书号</th>

                    <th data-sortable="true">发运单号</th>
                    <th data-sortable="true">车牌号</th>
                    <th data-sortable="true">物料名称</th>
                    <th data-sortable="true">批次号</th>
                    <th data-sortable="true">炉号</th>
                    <th data-sortable="true">执行标准</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">质量等级</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">重量</th>
                    <th data-sortable="true">件数</th>
                    <th data-sortable="true">发货时间</th>
                    <th data-sortable="true">客户</th>
                    <th data-sortable="true">制单人</th>
                    <th data-sortable="true">审批人</th>
                    <th data-sortable="true">审批时间</th>
                    <th data-sortable="true">打印次数</th>
                    <th data-sortable="true">最后打印人</th>
                    <th data-sortable="true">最后打印时间</th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
                    <ItemTemplate>
                        <tr class='<%#DataBinder.Eval (Container.DataItem,"D_PRINT_DT").ToString()==""?"":"info" %>'>
                            <td>

                                <input id="cbxID" style="width: 15px;" class="che1" runat="server" type="checkbox" value="" />
                                <%#Container.ItemIndex+1 %>

                            </td>
                            <td><%#GetPrint(DataBinder.Eval (Container.DataItem,"C_ZSH"),DataBinder.Eval (Container.DataItem,"C_BATCH_NO"),DataBinder.Eval (Container.DataItem,"C_STD_CODE"),DataBinder.Eval (Container.DataItem,"C_STL_GRD"),DataBinder.Eval (Container.DataItem,"C_FYDH"),DataBinder.Eval (Container.DataItem,"D_QZRQ"),DataBinder.Eval (Container.DataItem,"C_TYPE"),DataBinder.Eval (Container.DataItem,"C_STOVE"),DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH"),DataBinder.Eval (Container.DataItem,"C_PDF_PATCH")) %>
                                <asp:Button ID="btnPrint" runat="server" Text="打印" CommandName="print" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"C_ZSH") %>' CssClass="btn btn-success btn-xs" Visible='<%#DataBinder.Eval (Container.DataItem,"C_ZSH").ToString()==""?false:true %>' />
                            </td>
                            <td>
                                <input id="hidzsh" value='<%#DataBinder.Eval (Container.DataItem,"C_ZSH") %>' class="zsh" type="hidden" />
                                <asp:Literal ID="ltlzsh" Text='<%#DataBinder.Eval (Container.DataItem,"C_ZSH") %>' runat="server"></asp:Literal></td>
                            <td>
                                <input id="hidfyd" value='<%#DataBinder.Eval (Container.DataItem,"C_FYDH") %>' class="fyd" type="hidden" />
                                <asp:Literal ID="ltlC_FYDH" Text='<%#DataBinder.Eval (Container.DataItem,"C_FYDH") %>' runat="server"></asp:Literal>
                                <asp:Literal ID="ltlN_PRINT_NUM" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"N_PRINT_NUM") %>' runat="server"></asp:Literal>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_CH") %>
                            </td>


                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_DESC") %></td>

                            <td>
                                <asp:Literal ID="ltlC_BATCH_NO" Text='<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %>' runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltlC_STOVE" Text='<%#DataBinder.Eval (Container.DataItem,"C_STOVE") %>' runat="server"></asp:Literal>

                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %></td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>
                            </td>
                            <td>
                                <asp:Literal ID="ltlC_JUDGE_LEV_ZH" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %>'></asp:Literal>
                                <asp:Literal ID="ltlC_TYPE" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_TYPE") %>'></asp:Literal>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_SPEC") %>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"N_WGT") %>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"QUA") %>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"D_CKSJ","{0:yyy-MM-dd}") %>
                            </td>

                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %>
                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"ZDR") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_QZR") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_QZRQ","{0:yyy-MM-dd}") %>  </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_PRINT_NUM") %>  </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_PRINT_EMP") %>  </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_PRINT_DT","{0:yyy-MM-dd}") %>  </td>


                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
        <asp:ImageButton ID="imgbtnJz" runat="server" OnClick="imgbtnJz_Click" ImageUrl="~/Assets/images/btntm.gif" Height="0px" Width="0px" />
        <asp:Literal ID="ltlC_QZR" runat="server" Visible="false"></asp:Literal>
        <script type="text/javascript">
            $(function () {
                $("#txtckkssj").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
                $("#txtckjssj").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
            });


        </script>
    </form>
</body>
</html>
