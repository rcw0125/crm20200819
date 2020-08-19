<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FYZB_DAY.aspx.cs" Inherits="CRM.WebForms.Report.FYZB_DAY" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>发运指标日报表</title>
    <uc1:ReptControl runat="server" ID="ReptControl" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 50px;">日期</td>
                <td style="width: 120px;">
                    <input id="txtDate" type="text" style="width: 110px;" class=" form-control Wdate" runat="server" /></td>


                <td style="width:100px;">
                    <asp:Button ID="btncx" runat="server" CssClass="btn btn-primary btn-xs" Text="查询" OnClick="btncx_Click" OnClientClick="_loading(1);" />
                </td>
                <td style="width: 80px;">

                    <asp:TextBox ID="txtzzb" runat="server" Width="80" placeholder="总指标" CssClass="numJe"></asp:TextBox>
                </td>
                <td style="width: 80px;">
                    <asp:TextBox ID="txtjkzb" runat="server" Width="80" placeholder="监控指标" CssClass="numJe"></asp:TextBox>
                </td>
                <td style="width: 80px;">
                    <asp:TextBox ID="txtcqzb" runat="server" Width="80" placeholder="超期指标" CssClass="numJe"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnZbView" runat="server" CssClass="btn btn-primary btn-xs" Text="总指标分配预览" OnClick="btnZbView_Click" OnClientClick="_loading(1);" Visible="false" />
                    &nbsp;
                     <asp:Button ID="btnZbAdd" runat="server" CssClass="btn btn-primary btn-xs" Text="生成发运指标日报表" OnClick="btnZbAdd_Click" OnClientClick="_loading(1);"  Visible="false" />
                    &nbsp;
                    <asp:Button ID="btnZbEdit" runat="server" CssClass="btn btn-primary btn-xs" Text="区域总指标修改" OnClick="btnZbEdit_Click" OnClientClick="_loading(1);" Visible="false" />
                    &nbsp;
                    <asp:Button ID="btnKzFy" runat="server" CssClass="btn btn-warning btn-xs" Text="控制发运" OnClick="btnKzFy_Click" OnClientClick="_loading(1);" Visible="false" />
                    &nbsp;
                    <asp:Button ID="btnQyHyAdd" runat="server" CssClass="btn btn-primary btn-xs" Text="汽运/火运/超期发运录入" OnClick="btnQyHyAdd_Click" OnClientClick="_loading(1);"  Visible="false" />

                    &nbsp;

                    <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-success btn-xs" Text="导出" OnClick="btnPrint_Click" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed" style="white-space: nowrap;">
            <thead>
                 <tr class="info">
                    <th>合计</th>
                    <th>
                        <asp:Literal ID="ltlsumzkc" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltlsumjkkc" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltlsumcqkc" runat="server"></asp:Literal></th>
                    <th><asp:Literal ID="ltlsumdpkc" runat="server"></asp:Literal></th>
                    <th><asp:Literal ID="ltlsumkfl" runat="server"></asp:Literal></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th>
                        <asp:Literal ID="ltlsumzzb" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltlsumjkzb" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltlsumcqzb" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltlsumqyfy" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltlsumqyfy_jk" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltlsumhyfy" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltlsumhyfy_jk" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltlsumfy_cq" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltlsumfy_cz" runat="server"></asp:Literal></th>
                    <th>
                        <asp:Literal ID="ltlsumfyjk_cz" runat="server"></asp:Literal></th>
                    <th></th>
                </tr>
                <tr>
                    <th class="text-center"></th>
                    <th colspan="8" class="text-center">库存</th>
                    <th colspan="3" class="text-center">发运指标</th>
                    <th colspan="2" class="text-center">汽运制单</th>
                    <th colspan="2" class="text-center">火车待装</th>
                    <th class="text-center"></th>
                    <th colspan="2" class="text-center">与指标差值</th>
                    <th></th>
                </tr>
                <tr>
                    <th> <input id="cbxAll" type="checkbox" class="qx1" />区域</th>
                    <th>总库存</th>
                    <th>监控库存</th>
                    <th>超期库存</th>
                    <th>待判库存</th>
                    <th>可发运库存</th>
                    <th>总占比</th>
                    <th>监控占比</th>
                    <th>超期占比</th>
                    <th>总指标</th>
                    <th>监控指标</th>
                    <th>超期指标</th>
                    <th>总发运量</th>
                    <th>监控发运</th>
                    <th>总发运量</th>
                    <th>监控发运</th>
                    <th>超期库存发运</th>
                    <th>总发运量</th>
                    <th>监控发运</th>
                    <th>是否控制发运</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>

                            <td>
                                <input id="cbxID"  style="width: 15px;" class="che1" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' type="checkbox" />
                                <asp:Literal ID="ltlC_DEPT" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_DEPT")%>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlN_ZKWGT" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_ZKWGT")%>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlN_JKWGT" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_JKWGT")%>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlN_CQWGT" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_CQWGT")%>'></asp:Literal></td>
                              <td>
                                <asp:Literal ID="ltlN_DPWGT" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_DPWGT")%>'></asp:Literal></td>
                             <td>
                                <asp:Literal ID="ltlN_KFY" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_KFY")%>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlN_KCZB" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_KCZB")%>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlN_JKZB" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_JKZB")%>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlN_CQZB" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_CQZB")%>'></asp:Literal></td>
                            <td>
                                <input id="txtN_WGT" class="numJe" style="width: 100%" type="text" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"N_WGT")%>' />
                            </td>
                            <td>
                                <asp:Literal ID="ltlN_FYJKZB" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_FYJKZB")%>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlN_FYCQZB" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_FYCQZB")%>'></asp:Literal></td>
                            <td>
                                <input id="txtN_QYFY" class="numJe" style="width: 100%" runat="server" type="text" value='<%#DataBinder.Eval (Container.DataItem,"N_QYFY")%>' /></td>

                            <td>
                                <input id="txtN_QYJKFY" runat="server" class="numJe" style="width: 100%" type="text" value='<%#DataBinder.Eval (Container.DataItem,"N_QYJKFY")%>' />
                            </td>
                            <td>
                                <input id="txtN_HYFY" runat="server" class="numJe" style="width: 100%" type="text" value='<%#DataBinder.Eval (Container.DataItem,"N_HYFY")%>' />
                            </td>
                            <td>
                                <input id="txtN_HYJKFY" runat="server" class="numJe" style="width: 100%" type="text" value='<%#DataBinder.Eval (Container.DataItem,"N_HYJKFY")%>' />
                            </td>
                            <td>
                                <input id="txtN_CQFY" runat="server" class="numJe" style="width: 100%" type="text" value='<%#DataBinder.Eval (Container.DataItem,"N_CQFY")%>' />
                            </td>
                            <td>
                                <asp:Literal ID="ltlN_FY_CZ" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_FY_CZ")%>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlN_JK_CZ" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_JK_CZ")%>'></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlC_FLAG" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_FLAG")%>'></asp:Literal>
                                <asp:Literal ID="ltlC_TYPE" runat="server" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"C_TYPE")%>'></asp:Literal>
                            </td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
         <script type="text/javascript">
            //全选
            selectAll("input.qx1", "input.che1");
             
            $(function () {
                $("#txtDate").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true,//显示今日按钮
                });
            });
        </script>
    </form>
</body>
</html>
