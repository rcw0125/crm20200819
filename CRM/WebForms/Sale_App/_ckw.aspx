<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_ckw.aspx.cs" Inherits="CRM.WebForms.Sale_App._ckw" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>仓库</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <uc1:common2 runat="server" ID="common2" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>

                <td style="width: 120px;">
                    <asp:TextBox ID="txtcode" runat="server" placeholder="仓库编码" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 120px;">
                    <asp:TextBox ID="txtbatch" Width="100%" placeholder="批次号" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnok" runat="server" Text="查询" CssClass="btn btn-primary btn-xs" OnClick="btnok_Click" /></td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th>批次号</th>
                    <th>支数</th>
                    <th>重量</th>
                    <th>仓库编码</th>
                    <th>仓库名称</th>

                    <th>物料编码</th>
                    <th>钢种</th>
                    <th>规格</th>
                    <th>属性</th>
                    <th>包装</th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr title="点击选中" onclick="SetInfo('<%#DataBinder.Eval (Container.DataItem,"C_ID")%>','<%#DataBinder.Eval (Container.DataItem,"C_LINEWH_NAME")%>','<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO")%>');">

                            <td><%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"QUA")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_WGT")%></td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_LINEWH_CODE")%>
                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_LINEWH_NAME")%>
                            </td>

                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_BZYQ")%></td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <input id="hidID" type="hidden" runat="server" />
        <input id="hidfyID" type="hidden" runat="server" />
        <script src="../Assets/js/jquery-2.0.3.min.js"></script>
        <script type="text/javascript">

            function SetInfo(id, name, batch) {
                var index = $("#hidID").val();
                window.parent.SetCK(id, name, index, batch);
            }
        </script>
    </form>
</body>
</html>
