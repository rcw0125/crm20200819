<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pack.aspx.cs" Inherits="CRM.Cust_App.Pack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Assets/css/common.css" rel="stylesheet" />
    <title>包装要求</title>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">

            <tr>
                <td style="width: 150px;">
                    <input type="text" placeholder="包装类型代码" class="input-xlarge" runat="server" id="txtName" /></td>
                <td style="width: 150px;">
                    <input type="text" placeholder="包装类型名称" class="input-xlarge" runat="server" id="txtCode" /></td>

                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn btn-primary btn-xs btn_w60" OnClick="btnSearch_Click" />

                </td>

            </tr>
        </table>
        <table class="table table-bordered table-hover">
            <tr>

                <th>包装类型代码</th>
                <th>包装类型名称</th>
                <th>包装方式说明</th>
                <th>备注</th>
            </tr>
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr>

                        <td><a href="#" title="点击插入" onclick="SetInfo('<%#DataBinder.Eval (Container.DataItem,"C_PACK_TYPE_CODE")%>');"><%#DataBinder.Eval (Container.DataItem,"C_PACK_TYPE_CODE")%></a></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_PACK_TYPE_NAME")%></td>
                        <td><a href="#" title="点击插入" onclick="SetInfo('<%#DataBinder.Eval (Container.DataItem,"C_PACK_TYPE_CODE")%>');"><%#DataBinder.Eval (Container.DataItem,"C_PACK_DESC")%></a></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_REMARK")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <input id="hidID" type="hidden" runat="server" />
        <script src="../../Assets/js/jquery-2.0.3.min.js"></script>
        <script type="text/javascript">

            function SetInfo(pack) {
                var id = $("#hidID").val();
                window.parent.SetPack(pack, id);
                //window.opener.SetPack(pack,id);
                //window.close();
            }

        </script>
    </form>
</body>
</html>
