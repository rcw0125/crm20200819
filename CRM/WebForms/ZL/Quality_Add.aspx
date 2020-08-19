<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quality_Add.aspx.cs" Inherits="CRM.WebForms.ZL.Quality_Add" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>
<!DOCTYPE html>

<html>
<head>
    <title>添加质量异议</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <uc1:common runat="server" ID="common" />


</head>
<body>
    <form id="form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="dv_btn">
            <ul>
                <li>
                    <asp:Button ID="btndelrow" runat="server" Text="删除行" CssClass="btn btn-danger btn-xs" OnClick="btndelrow_Click" OnClientClick="return DeleteRow();" />
                </li>
                <li>
                    <asp:Button ID="btnAdd" runat="server" Text="添加行" CssClass="btn btn-primary btn-xs" OnClick="btnAdd_Click" />
                </li>

                <li>
                    <input id="btndoc" runat="server" type="button" value="文档" class="btn btn-primary btn-xs" onclick="uploadDoc();" />
                </li>
                <li>
                    <input id="btncustdoc" runat="server" type="button" value="客户附件" class="btn btn-primary btn-xs" onclick="uploadCustDoc();" />
                </li>
                <li>
                    <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="btn btn-primary btn-xs" OnClick="btnSave_Click" OnClientClick="return checkSave();" />
                </li>
                <li>
                    <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="btn btn-primary btn-xs" OnClientClick="return checSubmit();" OnClick="btnSubmit_Click" />
                </li>
                <li>
                    <asp:Button ID="btnCheck" runat="server" Text="送审" CssClass="btn btn-primary btn-xs" OnClick="btnCheck_Click" OnClientClick="return checkSave()" />
                </li>
                <li>
                    <input id="btnflow" runat="server" type="button" value="审批记录" class="btn btn-primary btn-xs" onclick="getflow();" />
                </li>
                <li>
                    <input type="button" value="返回列表" class="btn btn-warning btn-xs" onclick='history.go(-<%= (int)ViewState["back_no"] %>);' /></li>
            </ul>
        </div>
        <table class="table table-bordered table-hover table-condensed">
            <tr>
                <td>区域<span class="red">*</span></td>
                <td>
                    <asp:DropDownList ID="ddlArea" runat="server" Width="100%"></asp:DropDownList></td>
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
                    <asp:DropDownList ID="ddlGrd" runat="server">
                        <asp:ListItem>常规精品钢</asp:ListItem>
                        <asp:ListItem>品种钢</asp:ListItem>
                        <asp:ListItem>监控钢种</asp:ListItem>
                        <asp:ListItem>普碳钢</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                      <asp:DropDownList ID="dropGrdType" runat="server">
                          <asp:ListItem>冷镦钢</asp:ListItem>
                          <asp:ListItem>硬线</asp:ListItem>
                          <asp:ListItem>轴承钢</asp:ListItem>
                          <asp:ListItem>弹簧钢</asp:ListItem>
                          <asp:ListItem>悬索用钢</asp:ListItem>
                          <asp:ListItem>纯铁类</asp:ListItem>
                          <asp:ListItem>帘线钢</asp:ListItem>
                      </asp:DropDownList>
                </td>
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
                    <a href="javascript:void(0);" onclick="openWeb();"><span class="glyphicon glyphicon-search"></span></a></td>
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
                <td class="auto-style1">本部门</td>
                <td class="auto-style1">
                    <input id="txtDEPT" runat="server" type="text" style="width: 100%" /></td>
                <td class="auto-style1">质控部</td>
                <td class="auto-style1">
                    <input id="txtQUALITY_DEPT" runat="server" type="text" style="width: 100%" /></td>
                <td class="auto-style1">技术中心</td>
                <td class="auto-style1">
                    <input id="txtTECHNOLOGY" runat="server" type="text" style="width: 100%" /></td>
                <td class="auto-style1">其他</td>
                <td class="auto-style1">
                    <input id="txtQT" runat="server" type="text" style="width: 100%" /></td>
            </tr>

            <tr runat="server" id="trSale4">
                <td>类型</td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" Width="100%">

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
            <tr runat="server" id="trSale5">
                <td>缺陷类别</td>
                <td>
                    <asp:DropDownList ID="dropQUEXIAN" runat="server" Width="100%">
                        <asp:ListItem>冷镦开裂</asp:ListItem>
                        <asp:ListItem>组织问题</asp:ListItem>
                        <asp:ListItem>表面不圆</asp:ListItem>
                        <asp:ListItem>表面裂纹</asp:ListItem>
                        <asp:ListItem>在线划伤</asp:ListItem>
                        <asp:ListItem>离线擦划伤</asp:ListItem>
                        <asp:ListItem>面缩不合</asp:ListItem>
                        <asp:ListItem>脆断</asp:ListItem>
                        <asp:ListItem>多头</asp:ListItem>
                        <asp:ListItem>混料</asp:ListItem>
                        <asp:ListItem>夹杂</asp:ListItem>
                        <asp:ListItem>拉拔断裂</asp:ListItem>
                        <asp:ListItem>乱线</asp:ListItem>
                        <asp:ListItem>脱碳超标</asp:ListItem>
                        <asp:ListItem>芯部硬度低</asp:ListItem>
                        <asp:ListItem>氧化皮去不净</asp:ListItem>
                        <asp:ListItem>自断</asp:ListItem>
                        <asp:ListItem>表面锈蚀</asp:ListItem>
                        <asp:ListItem>表面油污</asp:ListItem>
                    </asp:DropDownList></td>
                <td>赔付日期</td>
                <td>
                    <input id="txtPFDATE" class="Wdate" runat="server" onclick="WdatePicker({ isShowClear: false, readOnly: true })" /></td>
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
                    <input id="txtQUALITY_RESULT" runat="server" type="text" style="width: 100%; height: 50px" /></td>

            </tr>
        </table>
        <div class="table-responsive" style="width: 100%; overflow: auto;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
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
                                            <asp:TextBox ID="txtBATCH" MaxLength="9" CssClass="numJe2" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"C_BATCH")%>'></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtSHIPPEDQTY" CssClass="price3" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"N_SHIPPEDQTY")%>'></asp:TextBox></td>
                                        <td>
                                            <input type="text" class="price3" id="txtOBJECT_WGT" onchange="bindSum()" runat="server" width="100%" value='<%#DataBinder.Eval (Container.DataItem,"N_OBJECT_WGT")%>' />
                                            &nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="txtSTL_CODE" CssClass="pack" runat="server" Width="100%" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_CODE")%>'></asp:TextBox>&nbsp;</td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <input id="hid" runat="server" type="hidden" />
        <input id="hidQNO" runat="server" type="hidden" />
        <input id="hidsaleempid" runat="server" type="hidden" />
        <input id="hidstatus" type="hidden" runat="server" value="-1" />
        <input id="hidroles" type="hidden" runat="server" />

        <script type="text/javascript">
            $(function () {
                var status = $("#hidstatus").val();
                var role = $("#hidroles").val();

                if (role == "kh-001") {
                    $("input:text").each(function () {
                        if (status != "-1") {

                            $(this).attr("disabled", "disabled")
                        }
                        else {

                            $(this).removeAttr("disabled");
                        }
                    });
                    $("textarea").each(function () {
                        if (status != "-1") {

                            $(this).attr("disabled", "disabled")
                        }
                        else {

                            $(this).removeAttr("disabled");
                        }
                    });

                    $("select").each(function () {
                        if (status != "-1") {

                            $(this).attr("disabled", "disabled")
                        }
                        else {

                            $(this).removeAttr("disabled");
                        }
                    });
                }
                else {

                    $("input:text").each(function () {

                        if (status == "1" || status == "2") {

                            $(this).attr("disabled", "disabled")
                        }
                        else {

                            $(this).removeAttr("disabled");
                        }
                    });
                    $("textarea").each(function () {
                        if (status == "1" || status == "2") {

                            $(this).attr("disabled", "disabled")
                        }
                        else {

                            $(this).removeAttr("disabled");
                        }
                    });

                    $("select").each(function () {
                        if (status == "1" || status == "2") {

                            $(this).attr("disabled", "disabled")
                        }
                        else {

                            $(this).removeAttr("disabled");
                        }
                    });

                    $("#txtPFDATE").removeAttr("disabled");
                    $("#txtPFMONEY").removeAttr("disabled");

                }
            });

            function DeleteRow() {
                if (confirm("确认删除行吗？")) {
                    return true;
                }
                else {
                    return false;
                }
            }
            function openWeb() {
                _iframe('../../Common/_Sales_Emp1.aspx', '490', '350', '业务员');
            }
            function SetEmp(userName, saleEmpID) {
                $("#txtSaleUser").val(userName);
                $("#hidsaleempid").val(saleEmpID);
                //$("#hiddeptid").val(deptID);
                close();
            }
            function checkSave() {
                if ($("#txtDistributor").val().trim() == "" || $("#txtContact").val().trim() == ""
                    || $("#txtConPhone").val().trim() == "" || $("#txtGrd").val().trim() == "" || $("#txtShipStart").val().trim() == ""
                    || $("#txtShipEnd").val().trim() == "" || $("#txtProUse").val().trim() == "" || $("#txtSaleUser").val().trim() == ""
                    || $("#txtObjContent").val().trim() == "" || $("#txtTechDesc").val().trim() == "" || $("#txtBz").val().trim() == "") {
                    alert("带*号不能为空！");
                    return false;
                }
                else {
                    return true;
                }
            }
            function bindSum() {
                var valSum = 0;
                $("#table1 tbody tr").each(function () {
                    var input = $(this).find("input");
                    valSum += parseInt(input[6].value);
                });
                $("#txtOBJECT_COUNT_WGT").val(valSum);
            }
            function checSubmit() {
                if (confirm("确认提交吗？提交后不可修改！")) {
                    if ($("#txtDistributor").val().trim() == "" || $("#txtContact").val().trim() == ""
                        || $("#txtConPhone").val().trim() == "" || $("#txtGrd").val().trim() == "" || $("#txtShipStart").val().trim() == ""
                        || $("#txtShipEnd").val().trim() == "" || $("#txtProUse").val().trim() == "" || $("#txtSaleUser").val().trim() == ""
                        || $("#txtObjContent").val().trim() == "" || $("#txtTechDesc").val().trim() == "" || $("#txtBz").val().trim() == "") {
                        alert("带*号不能为空！");
                        return false;
                    }
                    else {
                        return true;
                    }
                }
                else {
                    return false;
                }
            }
            function uploadDoc() {
                var url = '/Common/_ConDoc.aspx?pk=' + $("#hid").val();
                _iframe(url, '500', '400', '文档');
            }

            function uploadCustDoc() {
                var url = '/Common/_CustDoc.aspx?pk=' + $("#hid").val();
                _iframe(url, '500', '400', '客户附件');
            }
            function getflow() {

                var url = '../Sale_App/FlowStep_View.aspx?taskID=' + $("#hid").val();
                _iframe(url, '500', '400', '审批记录');
            }
        </script>
    </form>
</body>
</html>
