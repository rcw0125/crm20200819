<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatCode.aspx.cs" Inherits="CRM.Common.MatCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <title>物料编码</title>
</head>
<body>
    <form id="form1" runat="server">

        <table class="table table-bordered">

            <tr>
                <td>
                      <asp:DropDownList ID="ddl_mat" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <input type="text" placeholder="物料编码" class="input-xlarge" runat="server" id="txtCode" /></td>
                <td>
                    <input type="text" placeholder="物料名称" class="input-xlarge" runat="server" id="txtName" /></td>
                
                <td>
                    <input type="text" placeholder="钢种" class="input-xlarge" runat="server" id="txt_GRD" /></td>
                <td>
                    <input type="text" placeholder="规格" class="input-xlarge" runat="server" id="txtSPEC" /></td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn btn-primary btn-xs btn_w60" OnClick="btnSearch_Click" />
                 
                </td>

            </tr>
        </table>
        <table class="table table-bordered table-hover">
            <tr>
               
                <th>物料编码</th>
                <th>物料名称</th>
                <th>钢种</th>
                <th>规格</th>
                <th>直径</th>

            </tr>
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <tr>
                       
                        <td><a href="#" title="点击插入" onclick="SetInfo('<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%>','<%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%>','<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>','<%#DataBinder.Eval (Container.DataItem,"C_SPEC")%>','<%#DataBinder.Eval (Container.DataItem,"C_MAT_TYPE")%>','<%#DataBinder.Eval (Container.DataItem,"N_THK")%>');"><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%></a></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%></td>
                        <td>
                            <a href="#" title="点击插入" onclick="SetInfo('<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%>','<%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%>','<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>','<%#DataBinder.Eval (Container.DataItem,"C_SPEC")%>','<%#DataBinder.Eval (Container.DataItem,"C_MAT_TYPE")%>','<%#DataBinder.Eval (Container.DataItem,"N_THK")%>');"><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></a>
                            </td>
                        <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC")%></td>
                        <td><%#DataBinder.Eval (Container.DataItem,"N_THK")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <script src="../Assets/js/jquery-2.0.3.min.js"></script>
        <script type="text/javascript">

            function SetInfo(code, name, grd, spec, type, dia) {
                
                window.opener.SetMat(code, name, grd, spec, type, dia);
                 window.close();

            }
            
        </script>
    </form>
</body>
</html>
