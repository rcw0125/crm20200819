<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YWTB.aspx.cs" Inherits="CRM.WebForms.PCI.YWTB" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>线材转库同步实绩</title>
    <uc1:common runat="server" ID="common" />
    <script src="../JsDate.js"></script>
    <script>
        $(function () {
            var _h = document.documentElement.clientHeight || document.body.clientHeight;
            var w = document.documentElement.clientWidth || document.body.clientWidth;
            $("#flow1").height(_h * 0.5);
            $("#flow2").height(_h * 0.4);
            $("#flow1").width(w);
            $("#flow2").width(w);
            $("#tb1").width(w);
            $("#tb2").width(w);
            $("#tb3").width(w);
        })
    </script>
</head>
<body onresize="fromsize();">
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 180px">
                    <asp:TextBox ID="txtYWDH" placeholder="移位单号" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="width: 90px">日期</td>
                <td style="width: 180px">
                    <asp:TextBox runat="server" class="form-control Wdate " ID="txtBegTime" Style="height: 100%;"></asp:TextBox></td>
                <td style="width: 180px">
                    <asp:TextBox runat="server" class="form-control Wdate " ID="txtEndTime" Style="height: 100%;"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" OnClientClick="_loading(1)" Style="height: 27px" />
                    &nbsp;
                         <asp:Button ID="btnSync" CssClass="btn btn-danger btn-xs" runat="server" Text="同步条码" OnClick="btnSync_Click" OnClientClick="_loading(1)" Visible="false" />
                </td>
            </tr>
        </table>
        <div style="overflow: auto; width: 100%;" id="flow1">
            <table id="table1" class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="350" style="white-space: nowrap;">
                <thead>
                    <tr>
                         <th data-sortable="true">单号</th>
                        <th data-sortable="true">牌号</th>
                        <th data-sortable="true">状态</th>
                        <th data-sortable="true">备注</th>
                        <th data-sortable="true">操作时间</th>
                        <th data-sortable="true">同步时间</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lblywdh" runat="server" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"ywdh") %>' CommandName="xc"><%#DataBinder.Eval (Container.DataItem,"ywdh") %></asp:LinkButton>
                                    <asp:Literal ID="lblRecord" Text='<%#DataBinder.Eval (Container.DataItem,"pk_SeZJB_Shift_Record") %>' runat="server" Visible="false"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="lblbarcode" Text='<%#DataBinder.Eval (Container.DataItem,"barcode") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblGrd" Text='<%#DataBinder.Eval (Container.DataItem,"ZJBstatus") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblStdCode" Text='<%#DataBinder.Eval (Container.DataItem,"by1") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblSpec" Text='<%#DataBinder.Eval (Container.DataItem,"insertts") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblLevZH" Text='<%#DataBinder.Eval (Container.DataItem,"updatets") %>' runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

        <div style="overflow: auto; width: 100%" id="flow2">

            <table id="table2" class="table table-bordered table-hover table-condensed" data-toggle="table" data-height="300" style="white-space: nowrap;">
                <thead>
                    <tr>
                        <th data-sortable="true">单号</th>
                        <th data-sortable="true">炉号</th>
                        <th data-sortable="true">批号</th>
                        <th data-sortable="true">钩号</th>
                        <th data-sortable="true">打牌序号</th>
                        <th data-sortable="true">物料编码</th>
                        <th data-sortable="true">物料名称</th>
                        <th data-sortable="true">钢种</th>
                        <th data-sortable="true">执行标准</th>
                        <th data-sortable="true">规格</th>
                        <th data-sortable="true">质量等级</th>
                        <th data-sortable="true">重量</th>
                        <th data-sortable="true">仓库</th>
                        <th data-sortable="true">区域</th>
                        <th data-sortable="true">库位</th>
                        <th data-sortable="true">原仓库</th>
                        <th data-sortable="true">原区域</th>
                        <th data-sortable="true">原库位</th>
                        <th data-sortable="true">操作人</th>
                        <th data-sortable="true">操作时间</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList2" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#DataBinder.Eval (Container.DataItem,"C_DH") %>
                                </td>
                                <td>
                                    <%#DataBinder.Eval (Container.DataItem,"C_STOVE") %>
                                </td>
                                <td>
                                    <%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %>
                                </td>
                                <td>
                                    <%#DataBinder.Eval (Container.DataItem,"C_TICK_NO") %></td>

                                <td><%#DataBinder.Eval (Container.DataItem,"C_BARCODE") %></td>

                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_DESC") %>                                   
                                </td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_WGT") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_AREA_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_LINEWH_LOC_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_YLINEWH_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_YLINEWH_AREA_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_YLINEWH_LOC_CODE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_EMP_ID") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"D_CZ_DATE") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlYWDH" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlRecord" runat="server" Visible="false"></asp:Literal>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#txtBegTime").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true,
                todayBtn: true
            });
            $("#txtEndTime").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true,
                todayBtn: true
            });
        });
    </script>
</body>
</html>
