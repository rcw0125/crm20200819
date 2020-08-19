<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="train_day_add.aspx.cs" Inherits="CRM.WebForms.Train.train_day_add" %>

<%@ Register Src="~/WebForms/Train/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>火运日计划添加</title>
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
               <td>
                    <asp:TextBox runat="server" placeholder="客户名称" ID="txtcustname" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtconno"  placeholder="合同号"  Width="100%" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtstlgrd" placeholder="钢种" runat="server"></asp:TextBox></td>
                <td><asp:TextBox ID="txtspec" placeholder="规格" runat="server"></asp:TextBox></td>
                <td><asp:DropDownList ID="dropneedarea" runat="server"></asp:DropDownList></td>
                      <td style="width: 80px;">日期</td>
                <td>
                    <input id="txtStart" type="text" style="width: 110px;" readonly="readonly" class=" form-control Wdate" runat="server" /></td>
                <td>
                    <input id="txtEnd" runat="server" type="text" style="width: 110px;" readonly="readonly" class=" form-control Wdate" /></td>
                <td style="width:120px">
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
                  <th data-sortable="true">合同号</th>
                    <th data-sortable="true">收货单位</th>
                    <th data-sortable="true">吨数</th>
                    <th data-sortable="true">备注</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">订单量</th>
                    <th data-sortable="true" class="red">已报计划量</th>
                    <th data-sortable="true">客户编码</th>
                    <th data-sortable="true">客户名称</th>
                    <th data-sortable="true">开户行</th>
                    <th data-sortable="true">税号</th>
                    <th data-sortable="true">账号</th>
                    <th data-sortable="true">电话</th>
                    <th data-sortable="true">地址</th>
                      <th data-sortable="true">区域</th>
                    
                    <th data-sortable="true">订货单位</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input id="cbxselect" runat="server" class="che1" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ORDER_NO")%>' /></td>
                           <td>
                                <asp:Literal ID="ltlC_CONNO" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_CON_NO")%>'></asp:Literal></td>
                            <td>
                                <asp:TextBox ID="txtC_SH_COMPANY" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_DH_COMPANY")%>'></asp:TextBox></td>
                          
                            <td>
                                <asp:TextBox ID="txtN_WGT" Width="50px" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"KCWGT")%>'></asp:TextBox></td>
                          
                            <td>
                                <asp:TextBox ID="txtRemark" runat="server" Width="100%"></asp:TextBox></td>
                            <td>
                                <asp:Literal ID="ltlC_SPEC" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC")%>' runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlC_STL_GRD" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>' runat="server"></asp:Literal></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_WGT")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"PLANWGT")%></td>
                            <td>
                                <asp:TextBox ID="txtC_CUSTNO" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_CUSTNO")%>' Width="80"></asp:TextBox>
                                &nbsp;<a href="javascript:void(0);" onclick="openCust('<%#Container.ItemIndex %>');"><span class="glyphicon glyphicon-search"></span></a></td>
                            <td>
                                <asp:TextBox ID="txtC_CUSTNAME" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_CUSTNAME")%>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtC_KH_BANK" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_KH_BANK")%>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtC_TAXNO" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_TAXNO")%>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtC_ACCOUNT" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_ACCOUNT")%>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtC_TEL" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_TEL")%>'></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtC_ADDRESS" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_ADDRESS")%>'></asp:TextBox></td>
                             <td>
                                <asp:Literal ID="ltlC_AREA" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_AREA")%>'></asp:Literal></td>
                            
                            <td>
                                <asp:Literal ID="ltlC_DH_COMPANY" Text='<%#DataBinder.Eval (Container.DataItem,"C_DH_COMPANY")%>' runat="server"></asp:Literal></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>

        <asp:Literal ID="ltlID" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
