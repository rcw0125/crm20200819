<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZZS.aspx.cs" Inherits="CRM.WebForms.Report.ZZS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>质证书/出库单打印</title>
    <link href="../../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Assets/css/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../Assets/css/jquery.resizableColumns.css" rel="stylesheet" />
    <link href="../../Assets/css/common.css" rel="stylesheet" />
    <link href="../../Assets/css/bootstrap-datetimepicker.css" rel="stylesheet" />
    <link href="css/zeroModal.css" rel="stylesheet" />
    <script src="../../Assets/js/My97DatePicker/WdatePicker.js"></script>
    <script src="../../Assets/js/jquery-2.0.3.min.js"></script>
    <script src="../../Assets/js/jquery.resizableColumns.min.js"></script>
    <script src="../../Assets/js/bootstrap.min.js"></script>
    <script src="../../Assets/js/bootstrap-table.min.js"></script>
    <script src="../../Assets/js/bootstrap-table-zh-CN.min.js"></script>
    <script src="../../Assets/js/common.js"></script>
    <script src="js/zeroModal.js"></script>
    <script src="js/zeroModal.min.js"></script>
    <script src="../../Assets/js/_zero.js"></script>
    <script src="js/jszzs.js?ver=1.1"></script>
    <script type="text/javascript" src="http://192.168.2.96:8080/WebReport/ReportServer?op=resource&resource=/com/fr/web/jquery.js"></script>
    <script type="text/javascript" src="http://192.168.2.96:8080/WebReport/ReportServer?op=emb&resource=finereport.js"></script>
    <style>
        #trHead th {
            text-align: center;
        }

        .trContent td .trContent td input {
            text-align: center;
        }
    </style>
    <script type="text/javascript">

        $(function () {
            //$("#td1 table tbody tr td").click(function () {
            //    if ($(this)[0].className == "tdCheck") {
            //        return;
            //    }
            //    var input = $(this).parent().children(0).find("input");
            //    var ischecked = input.prop('checked');
            //    if (ischecked) {
            //        input.prop('checked', '');
            //    }
            //    else {
            //        input.prop('checked', 'checked');
            //    }
            //});

            $('input[name=LineWhCode]').bind('input propertychange', function () {
                var val = $(this).val();
                $(this).parent().children('ul:first').children("li").each(function () {
                    if (val) {
                        if ($(this).text().indexOf(val) >= 0) {
                            $(this).show();
                            return;
                        }
                        else {
                            $(this).hide();
                        }
                    } else {
                        $(this).show();
                    }
                });
            });
            //    document.getElementById('ulSelectRemark').addEventListener('change',function(){
            //setRemark();
            //},false);
            $("#ddlType").change(function () {
                ddlSelectChange();
            });
        });


        function selectedCK(ckCode, $div, cVal) {
            var $a = $($div.children()).eq(0);
            $a.val(ckCode);
            $a.focus();
            $("#txtremark").val(cVal);
        }
        function ddlSelectChange() {
            var parm = { type: $("#ddlType").val() };
            $("#ulSelectRemark").empty();
            $.ajax({
                url: "/api/ApiOrderGZ/GetRemarkddl",
                type: "POST",
                data: JSON.stringify(parm),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var code = JSON.parse(data.Code);
                    var content = '';
                    content += "<li><a href='javascript:void(0)' onclick='selectedCK(\"清空\",$(this).parent().parent().parent())'>--清空--";
                    content += " </a></li>";
                    content += "</li>";
                    if (code == "1") {
                        var jsonobj = JSON.parse(data.Result);
                        $.each(jsonobj, function (i, item) {
                            content += "<li><a href='javascript:void(0)' onclick='selectedCK(\"" + item.C_KEY + "\",$(this).parent().parent().parent(),\"" + item.C_VALUE + "\")'>" + item.C_KEY;
                            content += " </a></li>";
                            content += "</li>";
                        });
                        $("#ulSelectRemark").append(content);
                    }
                    else {
                        $("#ulSelectRemark").append(content);
                    }
                },
                error: function (err) {
                    alert(err);
                }
            });
        }

        function setRemark() {
            if ($("#ddlSelRemark").val() != "-1") {
                $("#txtremark").val($("#ddlSelRemark").val());
            }
            else {
                $("#txtremark").val("");
            }
        }

    </script>
</head>
<body onresize="fromsize();">
    <form id="form1" runat="server">
        <input id="hidempname" type="hidden" runat="server" />
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:CheckBox ID="chkIsGP" runat="server" Text="是否钢坯" AutoPostBack="true" OnCheckedChanged="chkIsGP_CheckedChanged" />
                    &nbsp;  
                    <asp:TextBox ID="txtbatch" placeholder="批次号" runat="server" Width="150px"></asp:TextBox>
                    &nbsp;
                      <asp:TextBox ID="txtCNo" placeholder="证书号" runat="server" Width="150px"></asp:TextBox>
                    &nbsp;
                    <asp:TextBox ID="txtfyd" placeholder="发运单号" runat="server" Width="150px"></asp:TextBox>
                    &nbsp;
                    <asp:TextBox ID="txtcph" placeholder="车牌号" runat="server" Width="150px"></asp:TextBox>
                    &nbsp;
                    <asp:TextBox ID="txtAttrstor" placeholder="签证人" runat="server" Width="150px"></asp:TextBox>
                    运输方式：
                    <asp:DropDownList ID="dropysfs" runat="server"></asp:DropDownList>&nbsp;
                    <asp:CheckBox ID="cbxcktime" runat="server" Text="出库时间" Checked="true" />
                    <input type="text" class="Wdate" runat="server" onclick="WdatePicker({ isShowClear: false, readOnly: true })" id="txtStart" />-
                    <input type="text" class="Wdate" runat="server" onclick="WdatePicker({ isShowClear: false, readOnly: true })" id="txtEnd" />
                    质证书模板：                  
                     <asp:DropDownList ID="dropmb" runat="server" Width="120">
                         <asp:ListItem Value="1">线材</asp:ListItem>
                         <asp:ListItem Value="3">认证</asp:ListItem>
                         <asp:ListItem Value="5">空白</asp:ListItem>
                         <asp:ListItem Value="2">特殊</asp:ListItem>
                     </asp:DropDownList>
                    打印状态：
                     <asp:DropDownList ID="ddlQPrint" runat="server">
                         <asp:ListItem Value="0">未打印</asp:ListItem>
                         <asp:ListItem Value="2">异常项</asp:ListItem>
                         <asp:ListItem Value="3">补打</asp:ListItem>

                     </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="text-align: left">&nbsp;&nbsp;<asp:Button ID="btncx" runat="server" Text="查询" Style="height: 30px; width: 80px; font-size: 14px;" CssClass="btn btn-primary btn-xs" OnClick="btncx_Click" OnClientClick="_loading(1);" />
                    <input id="btnprint1" type="button" value="质证书打印" class="btn btn-danger btn-xs" style="height: 30px; margin-right: 10px; margin-left: 10px; font-size: 14px;" onclick="_print_zzs(1);" />
                    <input id="btnprint6" type="button" value="发运明细(碳钢)" class="btn btn-danger btn-xs" style="height: 30px; margin-right: 10px; font-size: 14px;" onclick="print_zcmx();" />
                    <input id="btnprint7" type="button" value="发运明细(不锈钢)" class="btn btn-warning btn-xs" style="height: 30px; margin-right: 10px; font-size: 14px;" onclick="print_bxg_zcmx();" />
                    <asp:DropDownList ID="ddlPrintStatus" runat="server">
                        <asp:ListItem Value="-1">全部</asp:ListItem>
                        <asp:ListItem Value="0">未打印</asp:ListItem>
                        <asp:ListItem Value="1">已打印</asp:ListItem>
                        <asp:ListItem Value="2">异常项</asp:ListItem>
                        <asp:ListItem Value="3">补打</asp:ListItem>
                    </asp:DropDownList>

                    <div class="btn-group" style="width: 280px; display: block; float: left;">
                        <asp:DropDownList ID="ddlType" runat="server">
                        </asp:DropDownList>
                        备注框： 
                        <input type="text" autocomplete="off" name="LineWhCode" data-toggle="dropdown" aria-expanded="false" value="" style="width: 150px" />
                        <ul id="ulSelectRemark" class="dropdown-menu pre-scrollable">
                        </ul>
                    </div>
                   
                    <input id="btnprint5" type="button" value="确认状态" style="width: 80px; height: 30px; font-size: 14px; margin-left:100px" onclick="UpdatePrintStatus();" class="btn btn-primary btn-xs" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 60px;">备注</td>
                <td>
                    <asp:TextBox ID="txtremark" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>
        </table>

        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 250px;">
                    <table class="table table-bordered table-condensed table-hover">
                        <thead style="display: block; overflow-y: scroll;">
                            <tr>
                                <th style="width: 10px;"></th>
                                <th style="width: 140px;">项目名称</th>
                                <th style="width: 100px;">项目值</th>
                            </tr>
                        </thead>
                        <tbody style="display: block; overflow-y: scroll; max-height: 500px;" id="content2">
                        </tbody>
                    </table>
                </td>
                <td id="td1">
                    <div style="overflow: auto; width: 100%" id="flow1">
                        <table class="table table-bordered table-condensed table-hover text-nowrap">
                            <thead>
                                <tr class="info">
                                    <th>份数：</th>
                                    <th>
                                        <asp:Literal ID="lstHJ" runat="server"></asp:Literal></th>
                                    <th>车数：</th>
                                    <th>
                                        <asp:Literal ID="lstCPH" runat="server"></asp:Literal></th>
                                    <th>发运单数：</th>
                                    <th>
                                        <asp:Literal ID="lstFYDH" runat="server"></asp:Literal></th>
                                    <th>重量：</th>
                                    <th>
                                        <asp:Literal ID="lstWgt" runat="server"></asp:Literal></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                    <th style="display: none;"></th>
                                    <th></th>
                                    <th></th>
                                </tr>
                                <tr id="trHead">
                                    <th>序号</th>
                                    <th>
                                        <input id="cbxAll" type="checkbox" class="qx1" />全选</th>
                                    <th data-sortable="true">是否打印</th>
                                    <th data-sortable="true">厂外时效</th>
                                    <th data-sortable="true">存货名称</th>
                                    <th data-sortable="true">车牌号</th>
                                    <th data-sortable="true">证书号</th>
                                    <th data-sortable="true">发运单号</th>
                                    <th data-sortable="true">批号</th>
                                    <th data-sortable="true">钢种</th>
                                    <th data-sortable="true">执行标准</th>
                                    <th data-sortable="true">规格</th>
                                    <th data-sortable="true">件数</th>
                                    <th data-sortable="true">重量</th>
                                    <th data-sortable="true">炉号</th>
                                    <th data-sortable="true">仓库</th>
                                    <th data-sortable="true">质量等级</th>
                                    <th style="text-align: left; max-width: 150px; width: 150px;">钩号</th>
                                    <th data-sortable="true">出库时间</th>
                                    <th data-sortable="true">收货单位</th>
                                    <th data-sortable="true">制单人</th>
                                    <th style="display: none;">出库单</th>
                                    <th data-sortable="true">签证人</th>
                                    <th data-sortable="true">签证日期</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptList" runat="server">
                                    <ItemTemplate>
                                        <tr class="trContent" ondblclick="GetCFXN('<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO")%>','<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>'
                                            ,'<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE")%>','<%#DataBinder.Eval (Container.DataItem,"C_STOVE")%>')">
                                            <td><%# this.rptList.Items.Count + 1%> </td>

                                            <td class="tdCheck">
                                                <input id="cbxselect" class="che1" type="checkbox" /></td>

                                            <td><%#ShowPrintStaus(Eval("N_PRINT_STATUS").ToString()) %></td>
                                            <td><%# DataBinder.Eval (Container.DataItem,"isOK")%></td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%></td>
                                            <td>
                                                <input class="flaNo" type="text" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent;"
                                                    value='<%#DataBinder.Eval(Container.DataItem, "C_LIC_PLA_NO")%>' />
                                            </td>
                                            <td>
                                                <input class="flaNo" type="text" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent;"
                                                    value='<%#DataBinder.Eval(Container.DataItem, "c_certificate_no")%>' />
                                            </td>
                                            <td>
                                                <input class="fyd" type="text" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent;"
                                                    value='<%#DataBinder.Eval(Container.DataItem, "C_DISPATCH_ID")%>' />
                                            </td>
                                            <td>
                                                <input class="batch" type="text" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent;"
                                                    value='<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO")%>' />
                                            </td>
                                            <td>
                                                <input class="stlgrd" type="text" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent;"
                                                    value='<%#DataBinder.Eval(Container.DataItem, "C_STL_GRD")%>' />
                                            </td>
                                            <td>
                                                <input class="stdcode" type="text" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent;"
                                                    value='<%#DataBinder.Eval(Container.DataItem, "C_STD_CODE")%>' />
                                            </td>
                                            <td>
                                                <input class="spec" type="text" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent;"
                                                    value='<%#DataBinder.Eval(Container.DataItem, "C_SPEC")%>' />
                                            </td>
                                            <td style="text-align: left;"><%#DataBinder.Eval (Container.DataItem,"N_NUM")%></td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"N_JZ")%></td>
                                            <td>
                                                <input class="stove" type="text" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent;"
                                                    value='<%#DataBinder.Eval(Container.DataItem, "C_STOVE")%>' />
                                            </td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"C_SEND_STOCK")%></td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"C_ZLDJ")%></td>
                                            <td style="max-width: 150px; width: 150px; white-space: pre-line;"><%#DataBinder.Eval (Container.DataItem,"C_TICK_STR")%></td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"D_CKSJ")%></td>

                                            <td><%#DataBinder.Eval (Container.DataItem,"C_ORGO_CUST")%></td>
                                            <td><%#DataBinder.Eval (Container.DataItem,"C_EMP_NAME")%></td>
                                            <td style="display: none;">
                                                <input class="ckd" type="text" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent;"
                                                    value='<%#DataBinder.Eval(Container.DataItem, "C_CKDH")%>' />
                                            </td>
                                            <td><%# DataBinder.Eval (Container.DataItem,"c_attestor")%></td>
                                            <td><%# DataBinder.Eval (Container.DataItem,"d_visa_dt")%></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </tbody>
                        </table>
                    </div>

                </td>

            </tr>
        </table>
        <script type="text/javascript">
            selectAll("input.qx1", "input.che1");
            ddlSelectChange();
            $(function () {
                //$("#table").resizableColumns();
            });
        </script>
    </form>

</body>
</html>
