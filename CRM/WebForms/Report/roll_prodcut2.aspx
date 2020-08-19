<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roll_prodcut2.aspx.cs" Inherits="CRM.WebForms.Report.roll_prodcut2" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>整批次自由分配</title>
    <uc1:common runat="server" ID="common" />
    <script src="js/jsroll_prodcut.js?ver=2"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox runat="server" placeholder="批次号" ID="txtbatchno" Width="100"></asp:TextBox></td>

                <td>
                    <asp:TextBox runat="server" placeholder="钢种" ID="txtstlgrd" Width="100"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="规格" ID="txtspec" Width="100"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="物料编码" ID="txtmatcode" Width="100"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="客户名称" ID="txtcustname" Width="100"></asp:TextBox></td>
                <td ><asp:DropDownList ID="dropgp" runat="server">
                    <asp:ListItem>全部改判/超订单</asp:ListItem>
                    <asp:ListItem>Y</asp:ListItem>
                    <asp:ListItem>N</asp:ListItem>
                    </asp:DropDownList></td>
                <td>质量&nbsp;
                    <asp:DropDownList ID="dropzldj" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropzldj_SelectedIndexChanged"></asp:DropDownList></td>
                <td style="width: 70px;">区域</td>
                <td>
                    <asp:DropDownList ID="dropsalearea" runat="server"></asp:DropDownList>
                </td>

                <td>
                    <asp:DropDownList ID="droptsxx" runat="server" Width="120px"></asp:DropDownList></td>
                <td style="width: 50px;">待判</td>
                <td>
                    <asp:DropDownList ID="dropflag" runat="server">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem Value="Y">已判</asp:ListItem>
                        <asp:ListItem Value="N">待判</asp:ListItem>
                    </asp:DropDownList></td>



            </tr>

            <tr>
                <td>
                    <input id="cbx_dt" type="checkbox" runat="server" />
                    生产日期</td>

                <td>
                    <input id="txtkssj" type="text" runat="server" style="cursor: pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td>
                    <input id="txtjssj" type="text" runat="server" style="cursor: pointer" readonly="readonly" class="form-control Wdate" /></td>
                <td><asp:TextBox runat="server" placeholder="合同号" ID="txtconno" Width="100"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btn_xc" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btn_xc_Click" OnClientClick="_loading(1);" />
                </td>
                <td style="width: 80px">需求区域</td>
                <td style="width: 150px;">
                    <asp:DropDownList ID="dropneedarea" runat="server" Width="100%"></asp:DropDownList></td>
                <td>
                    <asp:Button ID="btnedit" CssClass="btn btn-primary btn-xs" runat="server" Text="修改" OnClick="btnedit_Click" OnClientClick="return _eidt();" />

                </td>
                <td>
                    <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn btn-success btn-xs" OnClick="btnExport_Click" />


                </td>
                <td><a href="http://192.168.2.93:8685/webroot/decision/view/report?viewlet=xgcap/CPT_LOG.cpt&bypagesize=false" class="btn btn-success btn-xs" target="_blank">日志查询</a></td>
                <td><a href="http://192.168.2.93:8685/webroot/decision/view/report?viewlet=xgcap/cpt_roll_log.cpt&bypagesize=false" class="btn btn-success btn-xs" target="_blank">资源申请日志</a></td>
                <td><a href="http://192.168.2.93:8685/webroot/decision/view/report?viewlet=xgcap/DDFP.cpt&bypagesize=false" class="btn btn-success btn-xs" target="_blank">资源分配日志</a></td>
               
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
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                </tr>
                <tr>
                    <th>
                        <input id="cbxAll" type="checkbox" class="qx1" />全选</th>
                    <th data-sortable="true">批次号</th>
                    <th data-sortable="true">仓库</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">生产日期</th>
                    <th data-sortable="true">质量等级</th>
                    <th data-sortable="true">待判结果</th>
                    <th data-sortable="true">件数</th>
                    <th data-sortable="true">重量</th>
                    <th data-sortable="true">销售区域</th>
                    <th data-sortable="true">客户信息</th>
                    <th data-sortable="true">特殊信息</th>
                    <th data-sortable="true">物料名称</th>
                    <th data-sortable="true">物料编码</th>
                    <th data-sortable="true">执行标准</th>
                    <th data-sortable="true">自由项1</th>
                    <th data-sortable="true">自由项2</th>
                    <th data-sortable="true">包装要求</th>

                    <th data-sortable="true">备注</th>
                    <th data-sortable="true">合同号</th>
                    <th data-sortable="true">订单号</th>
                    <th data-sortable="true">计划需求量</th>
                    <th data-sortable="true">完工数量</th>
                    <th data-sortable="true">计划日期</th>
                    <th data-sortable="true">需求日期</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input id="cbxselect" runat="server" class="che1" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %>' /></td>

                            <td>
                                <asp:Literal ID="ltlbatch" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %>'></asp:Literal>
                                &nbsp;<a href="javascript:void(0);" onclick="openWeb2('<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO")%>','<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%>','<%#DataBinder.Eval (Container.DataItem,"C_SALE_AREA")%>','<%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH").ToString()=="DP"?"":DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH")%>')"><span class="glyphicon glyphicon-search"></span></a>

                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_CODE") %></td>
                            <td>
                                <asp:Literal ID="ltlstlgrd" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>' runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlspec" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC") %>' runat="server"></asp:Literal></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_PRODUCE_DATE","{0:yyy-MM-dd}") %></td>
                            <td>
                                <asp:Literal ID="ltllev" Text='<%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %>' runat="server"></asp:Literal>
                                <asp:Literal ID="ltllev_bp" Text='<%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_BP") %>' Visible="false" runat="server"></asp:Literal>

                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %></td>
                            <td>
                                <asp:Literal ID="ltlqua" Text='<%#DataBinder.Eval (Container.DataItem,"JIANSHU") %>' runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlN_WGT" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT") %>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlsalearea" Text='<%#DataBinder.Eval (Container.DataItem,"C_SALE_AREA") %>' runat="server"></asp:Literal></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %></td>
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
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ORDER_NO") %>&nbsp;<a href="javascript:void(0);" onclick="geturl_pc_view('<%#DataBinder.Eval (Container.DataItem,"C_ORDER_NO") %>');"><span class="glyphicon glyphicon-search"></span></a>&nbsp</td>
                            <td><%#DataBinder.Eval (Container.DataItem,"计划需求量") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"完工数量") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"计划日期") %></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"需求日期") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>


        <script type="text/javascript">
            $(function () {

                $("#table").resizableColumns();

                $("#txtkssj").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
                $("#txtjssj").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
            });

            function geturl_pc_view(id) {

                var url = 'PC_ORDER_VIEW2.aspx?ID=' + id;
                _iframe(url, '900', '400', '线材订单排产执行情况表');
            }

        </script>

        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlempname" runat="server" Visible="false"></asp:Literal>
    </form>

</body>
</html>
