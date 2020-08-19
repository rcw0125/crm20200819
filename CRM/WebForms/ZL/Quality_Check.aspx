<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quality_Check.aspx.cs" Inherits="CRM.WebForms.ZL.Quality_Check" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>
<!DOCTYPE html>

<html>
<head>
    <title>质量异议审批</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <uc1:common runat="server" ID="common" />

</head>
<body>
    <form id="form" runat="server">


        <div class="dv_btn">
            <ul>

                <li>
                    <input id="btncustdoc" runat="server" type="button" value="客户附件" class="btn btn-primary btn-xs" onclick="uploadCustDoc();" />
                </li>

                <li>
                    <input id="btndoc" runat="server" type="button" value="上传附件" class="btn btn-primary btn-xs" onclick="uploadDoc();" />
                </li>
            </ul>
        </div>
        <table class="table table-bordered table-hover table-condensed">
            <tr>
                <td>区域<span class="red">*</span></td>
                <td>
                    <asp:Literal ID="ltlArea" runat="server"></asp:Literal>
                </td>
                <td>经销商<span class="red">*</span></td>
                <td>
                    <input id="txtDistributor" runat="server" type="text" style="width: 100%" /></td>
                <td>直接用户</td>
                <td>
                    <input id="txtDirectuser" runat="server" type="text" style="width: 100%" /></td>
                <td>联系人<span class="red">*</span></td>
                <td>
                    <input id="txtContact" runat="server" type="text" style="width: 100%" /></td>
            </tr>
            <tr>
                <td>联系电话<span class="red">*</span></td>
                <td>
                    <input id="txtConPhone" runat="server" type="text" style="width: 100%" /></td>
                <td>钢种分类<span class="red">*</span></td>
                <td>
                    <input id="txtGrd" runat="server" type="text" style="width: 100%" /><input id="txtGrdType" runat="server" type="text" style="width: 100%" /></td>
                <td>发货时间<span class="red">*</span></td>
                <td>
                    <input type="text" class="Wdate" runat="server" onclick="WdatePicker({ isShowClear: false, readOnly: true })" id="txtShipStart" /></td>
                <td>到货时间<span class="red">*</span></td>
                <td>
                    <input type="text" class="Wdate" runat="server" onclick="WdatePicker({ isShowClear: false, readOnly: true })" id="txtShipEnd" /></td>
            </tr>
            <tr>
                <td>产品用途<span class="red">*</span></td>
                <td>
                    <input id="txtProUse" runat="server" type="text" style="width: 100%" /></td>
                <td>业务员<span class="red">*</span></td>
                <td>
                    <input id="txtSaleUser" type="text" runat="server" readonly="readonly" placeholder="必选" style="width: 85%" />
                </td>
                <td>投诉异议内容<span class="red">*</span></td>
                <td colspan="3">
                    <asp:TextBox ID="txtObjContent" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td>用户工艺流程<span class="red">*</span></td>
                <td colspan="3">
                    <asp:TextBox ID="txtTechDesc" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
                <td>备注<span class="red">*</span></td>
                <td colspan="3">
                    <asp:TextBox ID="txtBz" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
            </tr>
            <tr runat="server" id="trSale1">
                <td>现场调查情况</td>
                <td colspan="7">
                    <asp:TextBox ID="txtSite_SURVEY_CONTENT" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr runat="server" id="trSale2">
                <td>母材</td>
                <td>
                    <input id="txtPARENT_QUA" runat="server" class="numJe" type="text" style="width: 80%" />支</td>
                <td>问题样</td>
                <td>
                    <input id="txtQUEST_QUA" runat="server" class="numJe" type="text" style="width: 80%" />支</td>
                <td>中间样</td>
                <td>
                    <input id="txtMIDDLE_QUA" runat="server" class="numJe" type="text" style="width: 80%" />支</td>
                <td>其他</td>
                <td>
                    <input id="txtELSE_QUA" runat="server" class="numJe" type="text" style="width: 100%" /></td>
            </tr>
            <tr runat="server" id="trSale3">
                <td>本部门</td>
                <td>
                    <input id="txtDEPT" runat="server" type="text" style="width: 100%" /></td>
                <td>质控部</td>
                <td>
                    <input id="txtQUALITY_DEPT" runat="server" type="text" style="width: 100%" /></td>
                <td>技术中心</td>
                <td>
                    <input id="txtTECHNOLOGY" runat="server" type="text" style="width: 100%" /></td>
                <td>其他</td>
                <td>
                    <input id="txtQT" runat="server" type="text" style="width: 100%" /></td>
            </tr>
            <tr runat="server" id="trSale4">
                <td>类型</td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" Width="100%">
                        <asp:ListItem Value="-1">请选择</asp:ListItem>
                        <asp:ListItem Value="1">质量异议反馈</asp:ListItem>
                        <asp:ListItem Value="2">客户信息反馈</asp:ListItem>
                        <asp:ListItem Value="3">委托检验</asp:ListItem>
                    </asp:DropDownList></td>
                <td>异议数量合计</td>
                <td>
                    <input id="txtOBJECT_COUNT_WGT" runat="server" readonly="readonly" type="text" style="width: 100%" /></td>
                <td>制单人</td>
                <td>
                    <input id="txtCUST_MAKING" runat="server" type="text" style="width: 100%" /></td>
                <td>制单日期</td>
                <td>
                    <input id="txtCUST_MAKING_DT" class="Wdate" runat="server" onclick="WdatePicker({ isShowClear: false, readOnly: true })" /></td>
            </tr>
            <tr>
                <td>缺陷类别</td>
                <td>
                    <input id="txtQUEXIAN" runat="server" type="text" style="width: 100%" />
                </td>
                <td>赔付日期</td>
                <td>
                    <input id="txtPFDATE" class="Wdate" runat="server" onclick="WdatePicker({ isShowClear: false, readOnly: true })" />
                </td>
                <td>赔付金额(元)</td>
                <td>
                    <input id="txtPFMONEY" runat="server" type="text" class="numJe2" /></td>
                <td>当前状态</td>
                <td>
                    <asp:Literal ID="ltlStat" runat="server"></asp:Literal></td>
            </tr>
            <tr runat="server" id="trCus1">
                <td>质控部检验结果</td>
                <td colspan="7">
                    <input id="txtQUALITY_RESULT" runat="server" type="text" style="width: 100%; height: 50px;" /></td>

            </tr>
        </table>
        <div class="table-responsive" style="width: 100%; overflow: auto;">
            <table class="table table-bordered table-hover table-condensed" style="white-space: nowrap;" id="table1">
                <thead>
                    <tr>
                        <th>选择框</th>
                        <th>牌号</th>
                        <th>规格</th>
                        <th>批号</th>
                        <th>发货数量</th>
                        <th>异议数量</th>
                        <th>执行标准</th>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <input id="chkOrder" class="che1" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' type="checkbox" />
                                    <input id="hidVal" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_PARENTID")%>' type="hidden" />
                                    <span class="rowno"><%#Container.ItemIndex+1 %></span></td>
                                <td>
                                    <asp:TextBox ID="txtBRAND_NAME" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"C_BRAND_NAME")%>'></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtSPEC" CssClass="stdcode" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC")%>'></asp:TextBox>&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBATCH" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"C_BATCH")%>'></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtSHIPPEDQTY" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"N_SHIPPEDQTY")%>'></asp:TextBox></td>
                                <td>
                                    <input type="text" class="Wgt" id="txtOBJECT_WGT" onchange="bindSum()" runat="server" width="100%" value='<%#DataBinder.Eval (Container.DataItem,"N_OBJECT_WGT")%>' />
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtSTL_CODE" CssClass="pack" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_CODE")%>'></asp:TextBox>&nbsp;</td>

                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>

        </div>

        <div id="div_check" runat="server">
            <table class="table table-bordered table-condensed">

                <tr>

                    <td style="width: 80px;">处理建议</td>
                    <td>
                        <div>
                            <asp:TextBox ID="txtContent" runat="server" Height="50px" TextMode="MultiLine" Width="99%"></asp:TextBox>
                        </div>

                    </td>
                </tr>
                <tr runat="server" id="trNextEmp">
                    <td>下一处理人</td>
                    <td>
                        <asp:TextBox ID="txtC_NEXT_EMP_ID" runat="server" Width="200px" Enabled="false"></asp:TextBox><a href="javascritp:void(0);" onclick="openWeb();"><span class="glyphicon glyphicon-search"></span></a>
                        <input id="hidEmpID" runat="server" type="hidden" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>

                        <asp:Button ID="btnOk" runat="server" CssClass="btn btn-primary btn-xs" Text="批准" OnClick="btnOk_Click" OnClientClick="return Check();" />&nbsp;&nbsp;
                                    <asp:Button ID="btnNo" runat="server" CssClass="btn btn-primary btn-xs" Text="驳回" OnClick="btnNo_Click" OnClientClick="return checkBack();" />
                    </td>
                </tr>
            </table>
        </div>
        <table class="table table-bordered table-condensed">
            <tbody>
                <asp:Repeater ID="rptCheckList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="right info" style="width: 200px;">
                                <%#DataBinder.Eval (Container.DataItem,"STEPNAME") %>( <%#DataBinder.Eval (Container.DataItem,"c_step_emp_name") %>-<%#DataBinder.Eval (Container.DataItem,"N_PROCRESULT").ToString ()=="1"?"批准":DataBinder.Eval (Container.DataItem,"N_PROCRESULT").ToString ()=="0"?"驳回":"待处理" %>)</td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_STEPNOTE") %>&nbsp;<%#DataBinder.Eval (Container.DataItem,"D_STEP_DT") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

        <input id="hid" runat="server" type="hidden" />

        <script type="text/javascript">


            $(function () {


                $("input:text").each(function () {
                    $(this).attr("disabled", "disabled")
                });
                $("textarea").each(function () {
                    $(this).attr("disabled", "disabled")
                });

                $("select").each(function () {
                    $(this).attr("disabled", "disabled")
                });

                $("#txtContent").removeAttr("disabled");
                $("#txtQUALITY_RESULT").removeAttr("disabled");
                //$("#txtPFDATE").removeAttr("disabled");
                //$("#txtPFMONEY").removeAttr("disabled");

            });


            function uploadDoc() {
                var url = '/Common/_ConDoc.aspx?pk=' + $("#hid").val();
                _iframe(url, '500', '400', '文档');
            }

            function uploadCustDoc() {
                var url = '/Common/_CustDoc.aspx?pk=' + $("#hid").val();
                _iframe(url, '500', '400', '客户附件');
            }

            function openWeb() {
                var url = '/WebForms/Sale_App/Check_Emp.aspx?ID=' + $("#hidNextSetpID").val();
                _iframe(url, '500', '400', '审批人');
            }
            function Check() {


                if ($("#hidNextSetpID").val() != '0') {
                    if ($.trim($("#hidEmpID").val()) == '') {
                        alert("请选择下一处理人");
                        return false;
                    }
                }
                //else {
                //    if ($("#txtPFDATE").val() == "" || $("#txtPFMONEY").val() == "") {
                //        alert("请输入赔付日期或金额")
                //        return false;
                //    }
                //}
                return true;
            }
            function SetEmp(arrEmpName, arrEmpID) {

                $("#txtC_NEXT_EMP_ID").val(arrEmpName);
                $("#hidEmpID").val(arrEmpID);
                close();
            }
        </script>

        <asp:Literal ID="ltlUserID" Visible="false" runat="server"></asp:Literal>
        <input id="hidNextSetpID" runat="server" type="hidden" />
        <asp:Literal ID="ltlStepID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlFlowID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlFileID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlTaskID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlUserName" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlFlag" runat="server" Visible="false"></asp:Literal>

        <input id="hidstatus" type="hidden" runat="server" />
        <input id="hidroles" type="hidden" runat="server" />


    </form>
</body>
</html>
