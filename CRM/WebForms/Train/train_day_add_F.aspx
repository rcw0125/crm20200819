<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="train_day_add_F.aspx.cs" Inherits="CRM.WebForms.Train.train_day_add_F" %>

<%@ Register Src="~/WebForms/Train/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>水渣火运日计划添加</title>
    <uc1:rollControl runat="server" ID="rollControl" />
    <script type="text/javascript">


         $(function () {

            $("#txtStart").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true

            }).on("changeDate", function (ev) {
                $("#txtEnd").datetimepicker('setStartDate', $("#txtStart").val())
            });
            $("#txtEnd").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true
            }).on("changeDate", function (ev) {
                $("#txtStart").datetimepicker('setEndDate', $("#txtEnd").val())
            });
        });

        function openCust(ID) {

            var url = "custList.aspx?ID=" + ID;
            _iframe(url, '600', '400', '客户档案');
        }

        function SetCustInfo(custno, custname, kh, tax, zh, addr, tel, id) {
            $("#rptList_txtdhdw_" + id).val(custname);
            $("#rptList_txtC_CUSTNO_" + id).val(custno);
            $("#rptList_txtC_CUSTNAME_" + id).val(custname);
            $("#rptList_txtC_KH_BANK_" + id).val(kh);
            $("#rptList_txtC_TAXNO_" + id).val(tax);
            $("#rptList_txtC_ACCOUNT_" + id).val(zh);
            $("#rptList_txtC_ADDRESS_" + id).val(addr);
            $("#rptList_txtC_TEL_" + id).val(tel);
            close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
               <td style="width: 120px;">
                            <asp:TextBox ID="txtmatcode" placeholder="物料编码" runat="server" Width="100%"></asp:TextBox></td>
                        <td style="width: 120px;">
                            <asp:TextBox ID="txtmatname" placeholder="物料名称" runat="server" Width="100%"></asp:TextBox></td>
                <td >
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" />
                    &nbsp;
                    <asp:Button ID="btnsave" CssClass="btn btn-primary btn-xs" runat="server" Text="确定" OnClick="btnsave_Click" />

                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="400" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th data-sortable="true">选择</th>
                  <th data-sortable="true">物料编码</th>
                    <th data-sortable="true">物料名称</th>
                    <th data-sortable="true">吨数</th>
                    <th data-sortable="true">备注</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">钢种</th>
                     <th data-sortable="true">订货单位</th>
                    <th data-sortable="true">客户编码</th>
                    <th data-sortable="true">客户名称</th>
                    <th data-sortable="true">开户行</th>
                    <th data-sortable="true">税号</th>
                    <th data-sortable="true">账号</th>
                    <th data-sortable="true">电话</th>
                    <th data-sortable="true">地址</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input id="cbxselect" runat="server" class="che1" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' /></td>
                           <td>
                                <%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%></td>
                            <td>
                               <%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%></td>
                          
                            <td>
                                <asp:TextBox ID="txtN_WGT" Width="50px" runat="server" ></asp:TextBox></td>
                          
                            <td>
                                <asp:TextBox ID="txtRemark" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%>'></asp:TextBox></td>
                            <td>
                                <asp:Literal ID="ltlC_SPEC"  runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlC_STL_GRD"  runat="server"></asp:Literal></td>
                             <td><asp:TextBox ID="txtdhdw" runat="server" ></asp:TextBox></td>
                           
                            <td>
                                <asp:TextBox ID="txtC_CUSTNO" runat="server"  Width="80"></asp:TextBox>
                                &nbsp;<a href="javascript:void(0);" onclick="openCust('<%#Container.ItemIndex %>');"><span class="glyphicon glyphicon-search"></span></a></td>
                            <td>
                                <asp:TextBox ID="txtC_CUSTNAME" runat="server" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtC_KH_BANK" runat="server" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtC_TAXNO" runat="server" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtC_ACCOUNT" runat="server" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtC_TEL" runat="server" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtC_ADDRESS" runat="server" ></asp:TextBox></td>
                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>

        <asp:Literal ID="ltlID" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
