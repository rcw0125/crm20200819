<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="train_day_edit.aspx.cs" Inherits="CRM.WebForms.Train.train_day_edit" %>

<%@ Register Src="~/WebForms/Train/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>火运日计划编辑</title>
    <uc1:rollControl runat="server" ID="rollControl" />
    <script type="text/javascript">
        $(function () {

            $("#txtdate").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true

            });
        });

        function openWeb(index) {

            switch (index) {
                case 1:
                    var url = "train_plan_view.aspx";
                    _iframe(url, '600', '400', '火运计划号');
                    break;
                case 2:
                    var id = $("#txtcode").val();
                    var url = "train_day_add.aspx?ID=" + id;
                    _iframe(url, '1000', '500', '订单查询');
                    break;
                case 3:
                    var id = $("#txtcode").val();
                    var url = "train_day_add_F.aspx?ID=" + id;
                    _iframe(url, '1000', '500', '副产品');
                    break;
            }

        }

        function SetPlan(planno, dz, line,shdw) {

            $("#txtplanno").val(planno);
            $("#txtstation").val(dz);
            $("#txtline").val(line);
            $("#txtshdw").val(shdw);
            close();
        }


        function check() {

            var num = $.trim($("#txtnum").val());
            if (num == "" || num == 0) {
                alert("请输入车数！");
                return false;
            }
            return true;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dv_btn">
            <ul>
                <li>
                    <asp:Button ID="btndelrow" runat="server" Text="删除行" CssClass="btn btn-danger btn-xs" OnClick="btndelrow_Click" />
                </li>
                <li>
                    <asp:Button ID="btndelall" runat="server" Text="删除火运计划" CssClass="btn btn-danger btn-xs" OnClick="btndelall_Click" OnClientClick="return confirm('确定要删除吗？');" /></li>
                <li>
                    <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="btn btn-primary btn-xs" OnClick="btnsave_Click" OnClientClick="return check();" />
                </li>
                 <li>
                    <input id="btnAdd2" type="button" value="副产品" class="btn btn-primary btn-xs" onclick="openWeb(3);" />
                </li>
                <li>
                    <input id="btnAdd" type="button" value="订单查询" class="btn btn-primary btn-xs" onclick="openWeb(2);" />
                </li>
                <li>
                    <a href="train_day_apply.aspx" class="btn btn-warning btn-xs">返回列表</a>
                </li>

            </ul>
        </div>
        <table class="table table-bordered table-condensed">
            <tr>
                <td>单据号</td>
                <td>
                    <asp:TextBox ID="txtcode" Enabled="false" Width="100%" runat="server"></asp:TextBox>
                </td>
                <td>计划号</td>
                <td>
                    <asp:TextBox ID="txtplanno" Width="90%" runat="server"></asp:TextBox>&nbsp;<a href="javascript:void(0);" onclick="openWeb(1);"><span class="glyphicon glyphicon-search"></span></a></td>
                <td>到站</td>
                <td>
                    <asp:TextBox ID="txtstation" Width="100%" runat="server"></asp:TextBox></td>
                <td>专用线</td>
                <td>
                    <asp:TextBox ID="txtline" Width="100%" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>提报时间</td>
                <td>
                     <input id="txtdate" type="text" style="width: 110px;" readonly="readonly" class="form-control Wdate" runat="server" />
                  
                </td>
                <td>最后修改时间</td>
                <td>
                    <asp:TextBox ID="txtdate_edit" Enabled="false" Width="100%" runat="server"></asp:TextBox>
                </td>
                <td>收货单位</td>
                <td>
                    <asp:TextBox ID="txtshdw"  Width="100%" runat="server"></asp:TextBox>
                </td>
                <td>车数</td>
                <td>
                    <asp:TextBox ID="txtnum" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed table-hover" data-toggle="table" data-height="500" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th data-sortable="true">选择</th>
                    <th data-sortable="true">区域</th>

                    <th data-sortable="true">合同号</th>
                    <th data-sortable="true">订货单位</th>
                  
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">吨数</th>
                     <th data-sortable="true">备注</th>
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
                                <input id="cbxselect" runat="server" class="che1" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' /></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_AREA")%></td>

                            <td><%#DataBinder.Eval (Container.DataItem,"C_CONNO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_DH_COMPANY")%></td>
                            
                            <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></td>
                            <td>
                                <asp:TextBox ID="txtwgt" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT")%>'></asp:TextBox></td>
                              <td>  <asp:TextBox ID="txtremark" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_REMARK")%>'></asp:TextBox></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUSTNO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CUSTNAME")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_KH_BANK")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_TAXNO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ACCOUNT")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_TEL")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_ADDRESS")%></td>
                          

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr class="info">
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Literal ID="ltlsumwgt" runat="server"></asp:Literal>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </tfoot>
        </table>
        <asp:ImageButton ID="imgbtnJz" runat="server" OnClick="imgbtnJz_Click" ImageUrl="~/Assets/images/btntm.gif" Height="0px" Width="0px" />
    </form>
</body>
</html>
