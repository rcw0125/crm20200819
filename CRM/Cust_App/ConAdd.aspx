<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConAdd.aspx.cs" Inherits="CRM.Cust_App.ConAdd" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/My97DatePicker/WdatePicker.js"></script>
    <title>新增合同</title>
</head>
<body>
    <form runat="server">
        <div class="dv_btn">
            <ul>
                <li>
                    <button type="button" class="btn btn-warning btn-xs" onclick='window.location.href="MyCon.aspx"'>返回</button></li>
                

                   <li>
                    <asp:Button ID="btnSubmit" runat="server" Text="提交合同" CssClass="btn btn-primary btn-xs" OnClick="btnSubmit_Click" OnClientClick="return SubmitCon();" />
                  </li>
                <li>
                    <asp:Button ID="btnDel" runat="server" Text="选定删除"  CssClass="btn btn-warning btn-xs" OnClick="btnDel_Click"  OnClientClick="return delMsg();"  />
                </li>
                <li>
                    <button type="button"  class="btn btn-warning btn-xs" onclick="return edit();" runat="server" id="btnEdit">选定修改</button>
                </li>
             
                <li>
                    <button type="button" class="btn btn-warning btn-xs" onclick="return OpenOrder();" runat="server" id="btnAdd">添加订单</button>
                </li>
                <li>
                    <asp:Button ID="btnSave" runat="server" Text="保存" OnClientClick="return SaveCon();" CssClass="btn btn-warning btn-xs" OnClick="btnSave_Click" />
                </li>
                
            </ul>
        </div>

        <table class="table table-bordered">

            <tr>
                <td>货币类型</td>
                <td>
                    <asp:DropDownList ID="dropCurrType" runat="server" Width="100px"></asp:DropDownList>

                </td>

                <td>签署日期</td>
                <td>
                    <input id="txtDate" runat="server" type="text" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true })" /></td>
                <td>计划有效日期</td>
                <td>
                    <input id="txtStart" runat="server" type="text" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, maxDate: '#F{$dp.$D(\'txtEnd\')}' })" />
                </td>
                <td>计划失效日期</td>
                <td>
                    <input id="txtEnd" runat="server" type="text" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, minDate: '#F{$dp.$D(\'txtStart\')}' })" />
                </td>
            </tr>
            <tr>
                <td>合同类型</td>
                <td>
                    <asp:DropDownList ID="dropConType" runat="server" Width="100px"></asp:DropDownList>

                </td>
                <td>合同号</td>
                <td>
                    <asp:TextBox ID="txtConNO" runat="server" Enabled="False"></asp:TextBox></td>
                <td>合同名称</td>
                <td>
                    <asp:TextBox ID="txtConName" runat="server"></asp:TextBox></td>
                <td>客户名称</td>
                <td>
                    <asp:TextBox ID="txtCustName" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td>发运方式</td>
                <td>
                    <asp:DropDownList ID="dropShipVia" runat="server" Width="100px"></asp:DropDownList>

                </td>
                <td>合同区域</td>
                <td>
                    <asp:DropDownList ID="dropConArea" runat="server" Width="100px"></asp:DropDownList>

                </td>
                <td>合同状态</td>
                <td>
                    <asp:TextBox ID="txtState" runat="server" Enabled="False"></asp:TextBox>
                    <input id="hidState" runat="server" type="hidden" />
                </td>
                <td>合计数量</td>
                <td>&nbsp;
                    <asp:Label ID="lblSum" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th style="width: 30px; text-align: center">
                                <input class="qx1" type="checkbox" name="" value="" /></th>
                            <th>物料编码</th>
                            <th>存货名称</th>
                            <th>规格</th>
                            <th>钢种</th>
                            <th>协议号</th>
                            <th>包装要求</th>
                            <th>产品用途</th>
                            <th>计量单位</th>
                            <th>计划交货日期</th>
                            <th>数量</th>
                            <th>收货单位</th>
                            <th>开票单位</th>
                           
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td style="text-align: center">
                        <input id="chkSelect" class="che2" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_NO") %>' runat="server" />
                    </td>

                    <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"C_TECH_PROT") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"C_PACK") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"C_PRO_USE") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"C_UNITIS") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"D_DELIVERY_DT","{0:yyy-MM-dd}") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"N_WGT") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"C_CGC") %></td>
                    <td><%#DataBinder.Eval (Container.DataItem,"C_OTC") %></td>
                  

                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
               </table>
            </FooterTemplate>

        </asp:Repeater>

        <asp:Button ID="btnSearch" runat="server" Text="" Width="0px" Height="0px" OnClientClick="return Search();" OnClick="btnSearch_Click" />
        <asp:Literal ID="ltlCustName" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlCUST_NO" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlCustLEV" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlSysDate" Visible="false" runat="server"></asp:Literal>

        <script src="../Assets/js/jquery-2.0.3.min.js"></script>
        <script src="../Assets/js/common.js"></script>
        <script type="text/javascript">

            //全选
            selectAll("input.qx1", "input.che2");

            function OpenOrder() {

                var conNo = $.trim($("#txtConNO").val());
                var conState = $.trim($("#hidState").val());

                if (conNo == '') {
                    alert("请先保存基本合同信息");
                    return false;
                }

                if (conState == '-1' || conState == '') {
                    openPage("OrderAdd.aspx", "500", "550");
                }
                else {
                    alert("当前状态,暂时无法操作");
                    return false;
                }
            }

            function edit() {

                var test = $("input[class='che2']:checked");
                var checkBoxValue = "";
                test.each(function () {
                    checkBoxValue += $(this).val() + ",";
                });
                if (checkBoxValue == "") {
                    alert("请任选一项修改");
                    return false;
                } else {
                    checkBoxValue = checkBoxValue.substring(0, checkBoxValue.length - 1);
                    var arr = checkBoxValue.split(',');
                    if (arr.length > 1) {
                        alert("请任选一项修改");
                        return false;
                    } else {

                        var url = "OrderAdd.aspx?ID=" + arr[0];
                        openPage(url, "500", "550");
                    }
                }
            }

            function Search() {
                var conNo = $.trim($("#txtConNO").val());
                if (conNo == '') {
                    return false;
                }
                return true;
            }

            function SaveCon() {


                var conName = $.trim($("#txtConName").val());
                if (conName == '') {
                    alert("合同名称不能为空");
                    return false;
                }
                return true;
            }

            function SubmitCon() {
                var conNO = $.trim($("#txtConNO").val());
                var conName = $.trm($("#txtConName").val());
                var num = $("#lblSum").text();

                if (conNO == '' && conName == '') {
                    alert("请输入合同名称，再点击保存")
                    return false;
                }
                if (num <= 0) {
                    alert("请添加订单");
                    return false;
                }
                return true;
            }

        </script>


    </form>
</body>
</html>
