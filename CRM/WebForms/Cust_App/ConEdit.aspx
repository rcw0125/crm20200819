<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConEdit.aspx.cs" Inherits="CRM.Cust_App.ConEdit" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>
<html>
<head>
    <title>修改合同</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <uc1:common runat="server" ID="common" />
    <script src="js/jsConEdit.js?ver=1.1"></script>
</head>
<body onresize="fromsize();">
    <form runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="dv_btn">
            <ul>
                <li>
                    <asp:Button ID="btnConBg" runat="server" Text="合同变更" CssClass="btn btn-primary btn-xs" OnClientClick="return confirm('确定变更吗');" OnClick="btnConBg_Click" /></li>
                <li>
                    <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClientClick="return checkInfo(1);" CssClass="btn btn-primary btn-xs" OnClick="btnSubmit_Click" />
                </li>
                <li>
                    <asp:Button ID="btnSave" runat="server" Text="保存" OnClientClick="return checkInfo(0);" CssClass="btn btn-primary btn-xs" OnClick="btnSave_Click" />
                </li>
                <%-- <li>

                    <input id="btnProc_F" runat="server" type="button" value="副产品" class="btn btn-warning btn-xs" onclick="openWeb(8);" /></li>--%>
                <li>

                    <input id="btnProc" type="button" runat="server" value="产品" class="btn btn-primary btn-xs" onclick="openWeb(7);" /></li>
                <li>
                    <input id="btnAdd" runat="server" type="button" value="历史签单" class="btn btn-primary btn-xs" onclick="openWeb(6);" /></li>
                <li>
                    <input type="button" value="返回列表" class="btn btn-warning btn-xs" onclick='history.go(-<%= (int)ViewState["back_no"] %>)' />
                </li>
            </ul>
        </div>

        <table class="table table-bordered table-condensed" style="margin-top: 5px;">

            <tr>
                <td>货币类型</td>
                <td>
                    <asp:DropDownList ID="dropCurrType" runat="server" Width="100%"></asp:DropDownList>

                </td>

                <td>签署日期</td>
                <td>
                    <input id="txtDate" runat="server" type="text" class="form-control Wdate" style="width: 100%" /></td>
                <td>计划生效日期</td>
                <td>
                    <input id="txtStart" runat="server" type="text" readonly class="form-control Wdate" style="width: 100%" />
                </td>
                <td>计划失效日期</td>
                <td>
                    <input id="txtEnd" runat="server" type="text" readonly class="form-control Wdate" style="width: 100%" />
                </td>
            </tr>
            <tr>
                <td>合同类型</td>
                <td>
                    <asp:DropDownList ID="dropConType" runat="server" Width="100%"></asp:DropDownList>

                </td>
                <td>合同号</td>
                <td>
                    <asp:TextBox ID="txtConNO" runat="server"   Enabled="False" Width="100%"></asp:TextBox></td>
                <td>合同名称</td>
                <td>
                    <asp:TextBox ID="txtConName" runat="server" Width="100%"></asp:TextBox></td>
                <td>客户名称</td>
                <td>
                    <asp:TextBox ID="txtCustName" runat="server" Enabled="False" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td>发运方式</td>
                <td>
                    <asp:DropDownList ID="dropShipVia" runat="server" Width="100%"></asp:DropDownList>

                </td>
                <td>到站</td>
                <td>
                    <input id="txtC_STATION" runat="server" type="text" style="width: 85%" />
                    <a href="javascript:void(0);" onclick="openWeb(3);"><span class="glyphicon glyphicon-search"></span></a></td>

                <td>收货单位</td>
                <td>

                    <input id="txtC_CGC" runat="server" type="text" style="width: 85%" readonly="readonly" />
                    <a href="javascript:void(0);" onclick="openWeb(1);"><span class="glyphicon glyphicon-search"></span></a></td>
                <td>开票单位</td>
                <td>
                    <input id="txtC_OTC" runat="server" type="text" style="width: 85%"  readonly="readonly" />
                    <a href="javascript:void(0);" onclick="openWeb(2);" style="display: none"><span class="glyphicon glyphicon-search"></span></a></td>
            </tr>
            <tr>

                <td>业务员</td>
                <td>
                    <input id="txtSaleUser" type="text" runat="server"   readonly="readonly" placeholder="必选"  style="width:85%" />
                   
                    <a href="javascript:void(0);" onclick="openWeb(4);"><span class="glyphicon glyphicon-search"></span></a></td>

                <td>收货地址</td>
                <td>
                    <input id="txtAddr" readonly="readonly" runat="server" type="text" style="width: 85%" />
                    <a href="javascript:void(0);" onclick="openWeb(5);"><span class="glyphicon glyphicon-search"></span></a>
                </td>
                <td>备注</td>
                <td colspan="3">
                    <input id="txtReamrk" runat="server" type="text" style="width: 100%" />
                    <input id="hidstatus" type="hidden" runat="server" />
                </td>

            </tr>
        </table>


        <div style="overflow: auto; width: 100%" id="flow1">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <table class="table table-bordered table-hover table-condensed" style="white-space: nowrap;" id="table1">
                        <thead>
                            <tr>
                                <th>物料编码</th>
                                <th>物料名称</th>
                                <th>钢种</th>
                                <th>规格</th>
                                <th>协议号</th>
                                <th>包装标准</th>
                                <th>质量</th>
                                <th>数量(吨)</th>
                                <th>含税单价</th>
                                <th>价税合计</th>
                                <th>产品用途</th>
                                <th>特殊要求</th>
                                <th style="width: 50px;">操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnItemDataBound="rptList_ItemDataBound">

                                <ItemTemplate>
                                    <tr>

                                        <td>
                                            <%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltlC_NO" runat="server" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem," C_ID")%>'></asp:Literal>
                                            <%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%></td>
                                        <td>
                                            <%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>
                                        </td>
                                        <td>
                                            <%#DataBinder.Eval (Container.DataItem,"C_SPEC")%>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltlC_TECH_PROT" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_TECH_PROT")%>'></asp:Literal>

                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPack_Code" Text='<%#DataBinder.Eval (Container.DataItem,"C_PACK")%>' runat="server" Width="50px"></asp:TextBox>
                                            &nbsp;<a href="javascript:void(0);" onclick='openWeb2(<%#Container.ItemIndex %>);'><span class="glyphicon glyphicon-search"></span></a>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="dropZL" runat="server"></asp:DropDownList>
                                            <asp:Literal ID="ltlC_VDEF1" Text='<%#DataBinder.Eval (Container.DataItem,"C_VDEF1")%>' runat="server" Visible="false"></asp:Literal>

                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtWgt" CssClass="numJe" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT")%>' Width="60px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtN_ORIGINALCURTAXPRICE" CssClass="price" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURTAXPRICE")%>' Width="100px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <%#DataBinder.Eval(Container.DataItem, "N_ORIGINALCURSUMMNY")%>
                                        </td>

                                          <td>
                                            <asp:TextBox ID="txtC_PRO_USE"  Text='<%#DataBinder.Eval (Container.DataItem,"C_PRO_USE")%>' runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                         <td>
                                            <asp:TextBox ID="txtC_CUST_SQ" Text='<%#DataBinder.Eval (Container.DataItem,"C_CUST_SQ")%>' runat="server" Width="100%"></asp:TextBox>
                                        </td>

                                        <td style="text-align: center">
                                            <asp:LinkButton ID="lbtDel" ToolTip="删除" runat="server" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' CommandName="del" CssClass="glyphicon glyphicon-remove"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>

                            </asp:Repeater>
                        </tbody>
                        <tfoot>
                            <tr class="info">
                                <td style="text-align: center;">合计</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Literal ID="ltlWGT_SUM" runat="server"></asp:Literal>
                                </td>

                                <td></td>

                                <td>
                                    <asp:Literal ID="ltlN_ORIGINALCURSUMMNY" runat="server"></asp:Literal>

                                </td>

                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </tfoot>
                    </table>
                    <asp:ImageButton ID="imgbtnJz" runat="server" OnClick="imgbtnJz_Click" ImageUrl="~/Assets/images/btntm.gif" Height="0px" Width="0px" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <asp:Literal ID="ltlcon_bgNo" Visible="false" runat="server">0</asp:Literal>
        <input id="hiddeptid" type="hidden" runat="server" />
        <input id="hidsaleempid" type="hidden" runat="server" />
        <input id="hidC_CGID" type="hidden" runat="server" />
        <input id="hidC_OTCID" type="hidden" runat="server" />
        <input id="hidCustID" type="hidden" runat="server" />
        <input id="hidCustNO" type="hidden" runat="server" />
        <asp:Literal ID="ltlCustType" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlC_EMP_ID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlC_EMP_NAME" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlC_PROD_NAME" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlN_CON_STATUS" Visible="false" runat="server"></asp:Literal>

    </form>
</body>
</html>
