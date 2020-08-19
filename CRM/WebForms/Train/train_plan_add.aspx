<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="train_plan_add.aspx.cs" Inherits="CRM.WebForms.Train.train_plan_add" %>

<%@ Register Src="~/WebForms/Train/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>火运报备计划添加</title>
    <uc1:rollControl runat="server" ID="rollControl" />
    <script type="text/javascript">
          $(function () {

              $("#txtStart").datetimepicker({
                  format: 'yyyy-mm-dd',
                  minView: 'month',
                  language: 'zh-CN',
                  autoclose: true

              });
         
        });
        function checkfile() {
            if ($.trim($("#file1").val()) == "") {
                alert("请选择上传文件");
                return false;
            }
            return true;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
               
                <td style="width: 200px;">
                    <input class="fileInp" type="file" name="file" runat="server" id="file1" /></td>
                 <td>类别</td>
                <td>
                    <asp:DropDownList ID="droptype" runat="server">
                        <asp:ListItem>线材</asp:ListItem>
                        <asp:ListItem>钢坯</asp:ListItem>
                        <asp:ListItem>水渣</asp:ListItem>
                    </asp:DropDownList></td>
                <td>日期</td>
                <td style="width:120px"> <input id="txtStart" type="text" style="width: 110px;" readonly="readonly" class="form-control Wdate" runat="server" /></td>
                <td> <asp:DropDownList ID="dropneedarea" runat="server" Width="100%" ></asp:DropDownList></td>
                <td>
                    <asp:Button ID="Button2" CssClass="btn btn-primary btn-xs" runat="server" Text="上传文档" OnClick="Button2_Click" OnClientClick="return checkfile();" />
                    &nbsp;
                    <asp:Button ID="btnsave" CssClass="btn btn-primary btn-xs" runat="server" Text="保存" OnClick="btnsave_Click" />
                    &nbsp;
                      <a href="../../Uploads/planno.xlsx" class="btn btn-info btn-xs">模板下载</a>
                </td>

            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="400" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th data-sortable="true">类型</th>
                    <th data-sortable="true">车数</th>
                    <th data-sortable="true">到站</th>
                    <th data-sortable="true">到局</th>
                    <th data-sortable="true">计划号</th>
                    <th data-sortable="true">收货单位</th>
                    <th data-sortable="true">订货单位</th>
                    <th data-sortable="true">区域</th>
                    <th data-sortable="true">专用线</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:TextBox ID="txttype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "类型")%>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtcs" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "车数")%>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtdz" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "到站")%>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtdj" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "到局")%>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtplan" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "计划号")%>'></asp:TextBox></td>

                            <td>
                                <asp:TextBox ID="txtcustname" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "收货单位")%>'></asp:TextBox></td>
                             <td>
                                <asp:TextBox ID="txtdhdw" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "订货单位")%>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtarea" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "区域")%>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtremark" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "专用线")%>'></asp:TextBox></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>

    </form>
</body>
</html>
