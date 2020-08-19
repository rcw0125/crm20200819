<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roll_applyCheck.aspx.cs" Inherits="CRM.WebForms.Roll.roll_applyCheck" %>

<%@ Register Src="~/WebForms/Roll/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>资源审批</title>
    <uc1:rollControl runat="server" ID="rollControl" />

</head>
<body>
    <form id="form1" runat="server">



        <table class="table table-bordered table-condensed">
            <tr>

                <td>申请人</td>
                <td>
                    <asp:TextBox ID="txtEmpName" runat="server" Width="100%"></asp:TextBox></td>
                <td>申请时间</td>
                <td>
                    <asp:Literal ID="ltldate" runat="server"></asp:Literal></td>

                <td>审批状态</td>
                <td>
                    <asp:Literal ID="ltlcheckstate" runat="server"></asp:Literal></td>
            </tr>
        </table>

        <table class="table table-bordered table-condensed" data-toggle="table" data-height="250" id="table" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th>序号</th>
                    <th data-sortable="true">物料编码</th>
                    <th data-sortable="true">资源区域</th>
                    <th data-sortable="true">客户信息</th>
                    <th data-sortable="true">合同号</th>
                    <th data-sortable="true">批次号</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">重量</th>
                    <th data-sortable="true">质量等级</th>
                    <th data-sortable="true">包装</th>
                    <th data-sortable="true">执行标准</th>
                    <th data-sortable="true">需求区域</th>
                    <th data-sortable="true">需求客户</th>
                    <th data-sortable="true">需求合同号</th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                             <tr>
                                    <td>
                                        <input id="cbxselect" runat="server" class="che1" type="checkbox" value='<%#DataBinder.Eval (Container.DataItem,"C_VFREE3") %>' />
                                        <%#Container.ItemIndex+1 %></td>
                                    <td>
                                        <asp:Literal ID="ltlmatcode" Text='<%#DataBinder.Eval (Container.DataItem,"C_VFREE2") %>' runat="server"></asp:Literal> </td>
                                    <td><asp:Literal ID="ltlsalearea" Text='<%#DataBinder.Eval (Container.DataItem,"C_ZYAREA") %>' runat="server"></asp:Literal></td>
                                    <td><asp:Literal ID="ltlzycust" Text='<%#DataBinder.Eval (Container.DataItem,"C_ZYCUST") %>' runat="server"></asp:Literal></td>
                                    <td><asp:Literal ID="ltlzycon" Text='<%#DataBinder.Eval (Container.DataItem,"C_ZYCON") %>' runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlbatch" Text='<%#DataBinder.Eval (Container.DataItem,"C_VFREE1") %>' runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlstlgrd" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>' runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlspec" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC") %>' runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlN_WGT" Text='<%#DataBinder.Eval (Container.DataItem,"C_WGT") %>' runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltllev" Text='<%#DataBinder.Eval (Container.DataItem,"C_VFREE5") %>' runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlpack" Text='<%#DataBinder.Eval (Container.DataItem,"C_VFREE4") %>' runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlstdcode" Text='<%#DataBinder.Eval (Container.DataItem,"C_REMARK") %>' runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltlneedarea" Text='<%#DataBinder.Eval (Container.DataItem,"C_NEEDAREA") %>' runat="server"></asp:Literal></td>
                                  <td>
                                        <asp:Literal ID="ltlneedcust" Text='<%#DataBinder.Eval (Container.DataItem,"C_NEEDCUST") %>' runat="server"></asp:Literal></td>
                                  <td>
                                        <asp:Literal ID="ltlneedcon" Text='<%#DataBinder.Eval (Container.DataItem,"C_QUA") %>' runat="server"></asp:Literal></td>

                                </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>

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
