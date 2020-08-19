<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Con_CheckList.aspx.cs" Inherits="CRM.Sale_App.Con_CheckList" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>合同审批</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <uc1:common2 runat="server" ID="common2" />


</head>
<body onresize="fromsize();">
    <form id="form1" runat="server">

        <div class="dv_btn">
            <ul>
                <li>
                    <asp:Button ID="btnhref" runat="server" Text="返回" CssClass="btn btn-warning btn-xs" OnClick="btnhref_Click" />
                </li>
                <li>
                    <input id="btndoc" runat="server" type="button" value="文档" class="btn btn-primary btn-xs" onclick="openWebDoc();" />
                </li>
                <li>
                    <a href="http://192.168.2.93:8685/webroot/decision/view/report?viewlet=xgcap/cpt_qd_fx.cpt&emp=<%=ltlUserID.Text %>&bypagesize__=false" class="btn btn-info btn-xs" target="_blank">签单指标分析</a>
                </li>
            </ul>
        </div>
        

        <table class="table table-bordered table-condensed">
            <tr>

                <td>合同号 </td>
                <td>
                    <asp:Literal ID="ltlConNo" runat="server"></asp:Literal>
                    <input id="hidcon" runat="server" type="hidden" />
                </td>

                <td>合同名称</td>
                <td>
                    <asp:Literal ID="ltlConName" runat="server"></asp:Literal>

                </td>
                <td>合同类型</td>
                <td>
                    <asp:Literal ID="ltlConType" runat="server"></asp:Literal>
                </td>
                <td>客户名称
                </td>
                <td>
                    <asp:Literal ID="ltlCustName" runat="server"></asp:Literal>

                </td>

            </tr>

            <tr>
                <td>签订日期</td>
                <td>
                    <asp:Literal ID="ltlD_CONSING_DT" runat="server"></asp:Literal>
                </td>
                <td>计划生效日期</td>
                <td>
                    <asp:Literal ID="ltlD_CONEFFE_DT" runat="server"></asp:Literal>
                </td>

                <td style="color: cornflowerblue">计划失效日期</td>
                <td>

                    <asp:Literal ID="ltlD_CONINVALID_DT" runat="server"></asp:Literal>
                </td>

                <td style="color: cornflowerblue">业务类型</td>
                <td>
                    <asp:Literal ID="ltlC_BUSINESS_TYPE" runat="server"></asp:Literal>

                </td>

            </tr>

            <tr>
                <td>合同区域</td>
                <td>
                    <asp:Literal ID="ltlConArea" runat="server"></asp:Literal>

                </td>
                <td>发运方式</td>
                <td>
                    <asp:Literal ID="ltlC_SHIPVIA" runat="server"></asp:Literal>
                </td>
                <td>币种</td>
                <td>
                    <asp:Literal ID="ltlC_CURRENCY_TYPE" runat="server"></asp:Literal>

                </td>
                <td style="color: cornflowerblue">合同状态</td>
                <td>
                    <asp:Literal ID="ltlConState" runat="server"></asp:Literal>

                </td>
            </tr>
            <tr>
                <td>收货单位</td>
                <td>
                    <asp:Literal ID="ltlC_CGC" runat="server"></asp:Literal>
                </td>
                <td>开票单位</td>
                <td>
                    <asp:Literal ID="ltlC_OTC" runat="server"></asp:Literal>
                </td>
                <td>到站</td>
                <td>
                    <asp:Literal ID="ltlC_STATION" runat="server"></asp:Literal>

                </td>



                <td style="color: cornflowerblue">审批流程</td>
                <td>
                   <asp:Literal ID="ltlC_APPROVER_FLOW" runat="server"></asp:Literal></td>
            </tr>
            <tr>


                <td>部门</td>
                <td>
                    <asp:Literal ID="ltlDept" runat="server"></asp:Literal>

                </td>

                <td>业务员</td>
                <td>
                    <asp:Literal ID="ltlSaleUser" runat="server"></asp:Literal>

                </td>
                <td>销售组织</td>
                <td>
                    <asp:Literal ID="ltlC_SALE_DEPT" runat="server"></asp:Literal>
                </td>

                <td style="color: cornflowerblue">&nbsp;</td>
                <td>
                    &nbsp;</td>


            </tr>


            <tr>

                <td>说明</td>
                <td colspan="7">
                    <asp:Literal ID="ltlDESC" runat="server"></asp:Literal>
                </td>
            </tr>

        </table>

        <div style="overflow: auto;" id="_scroll">
            <table class="table table-bordered table-hover table-condensed" style="white-space: nowrap;">
                <thead>
                    <tr>

                      
                        
                        <th>物料编码</th>
                        <th>物料名称</th>
                        <th>钢种</th>
                        <th>规格</th>
                        <th class="auto-style1">客户协议号</th>
                        <th>自由项1</th>
                        <th>自由项2</th>
                        <th>包装要求</th>
                        <th>数量(吨)</th>
                        <th>计划交货日期</th>

                        <th>无税单价</th>
                        <th>税率</th>
                        <th>含税单价</th>
                        <th>无税金额</th>
                        <th>价税合计</th>
                        <th>税额</th>


                        <th>合同号</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>

                               
                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%></td>
                                <td>
                                    <%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>
                                                  
                                                </th>
                                                    <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC")%>
                                                </th>
                                                    <td>
                                                        <%#DataBinder.Eval (Container.DataItem,"C_TECH_PROT")%>
                                                    </td>
                                                        <td><%#DataBinder.Eval (Container.DataItem,"C_FREE1")%></td>
                                                        <td><%#DataBinder.Eval (Container.DataItem,"C_FREE2")%></td>
                                                        <td>
                                                            <%#DataBinder.Eval (Container.DataItem,"C_PACK")%></td>
                                                        <td>
                                                            <%#DataBinder.Eval (Container.DataItem,"N_WGT")%></td>
                                                        <td>
                                                            <%#DataBinder.Eval (Container.DataItem,"D_NEED_DT","{0:yyy-MM-dd}")%>
                                                        </td>




                                                    </td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURPRICE")%></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"N_TAXRATE")%></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURTAXPRICE")%></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURMNY")%></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURSUMMNY")%></td>
                                    <td><%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURTAXMNY")%></td>

                                    <td>
                                        <asp:Literal ID="ltlOrderNo" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' runat="server"></asp:Literal>

                                        <%#DataBinder.Eval (Container.DataItem,"C_CON_NO")%>
                                                  
                                    </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>


                </tbody>
                <tfoot>
                    <tr class="info">

                       
                        <td>合计</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>
                            </td>
                        <td><asp:Literal ID="ltlWGT_SUM" runat="server"></asp:Literal></td>
                        <td></td>


                        <td></td>
                        <td></td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Literal ID="ltlN_ORIGINALCURMNY" runat="server"></asp:Literal></td>
                        <td>
                            <asp:Literal ID="ltlN_ORIGINALCURSUMMNY" runat="server"></asp:Literal></td>


                        <td>
                            <asp:Literal ID="ltlN_ORIGINALCURTAXMNY" runat="server"></asp:Literal></td>
                        <td></td>
                    </tr>
                </tfoot>

            </table>
        </div>

        <div id="div_check" runat="server">
            <table class="table table-bordered table-condensed">
                <tr>
                    <td style="width: 80px;">说明</td>
                    <td>
                        <asp:Literal ID="ltlContent" runat="server"></asp:Literal></td>
                </tr>
                <tr>

                    <td>批语</td>
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

        <script type="text/javascript">
            $(function () {

                fromsize();
            })
            function fromsize() {

                var _w = $("#form1").width();
                var _h = document.documentElement.clientHeight
                $("#_scroll").width(_w);
                $("#_scroll").height(_h - 200);
            }

            function openWebDoc() {
                var con = $("#hidcon").val();
                var url = '../../Common/_ConDoc.aspx?pk=' + con;
                _iframe(url, '500', '400', '文档');
            }
            function openWeb() {
                var url = 'Check_Emp.aspx?ID=' + $("#hidNextSetpID").val();
                _iframe(url, '500', '400', '审批人');
            }
            function openWeb3(area) {
                var url = '../../Common/_PlanWgt.aspx?area=' + area;
                _iframe(url, '600', '350', area);
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
            function checkBack() {

                var content = $("#txtContent");
                if ($.trim(content.val()) == "") {
                    alert("请输入批语");
                    return false;
                }
                return true;
            }

        </script>
        <input id="hidTask" runat="server" type="hidden" />
        <input id="hidNextSetpID" runat="server" type="hidden" />
        <asp:Literal ID="ltlStepID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlFlowID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlFileID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlTaskID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlUserID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlUserName" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlFlag" runat="server" Visible="false"></asp:Literal>
    </form>
</body>
</html>
