<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConEdit_BG.aspx.cs" Inherits="CRM.Cust_App.ConEdit_BG" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>
<html>
<head>
    <title>合同变更</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <uc1:common runat="server" ID="common" />
    <script src="js/jsConEdit_BG.js?ver=1.0"></script>
</head>
<body onresize="fromsize();">
    <form runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="dv_btn">
            <ul>

                <li>
                    <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClientClick="return checkInfo2();" CssClass="btn btn-primary btn-xs" OnClick="btnSubmit_Click" />
                </li>

                <li>

                    <input id="btnProc" type="button" runat="server" value="产品" class="btn btn-primary btn-xs" onclick="openWeb(7);" /></li>
                <li>
                    <input id="btnAdd" runat="server" type="button" value="历史签单" class="btn btn-primary btn-xs" onclick="openWeb(6);" /></li>
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
                    <asp:TextBox ID="txtConNO" runat="server" Enabled="False" Width="100%"></asp:TextBox></td>
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

                    <input id="txtC_CGC" runat="server" type="text" style="width: 85%" />
                    <a href="javascript:void(0);" onclick="openWeb(1);"><span class="glyphicon glyphicon-search"></span></a></td>
                <td>开票单位</td>
                <td>
                    <input id="txtC_OTC" runat="server" type="text" style="width: 85%" disabled="disabled" />
                    <a href="javascript:void(0);" onclick="openWeb(2);" style="display: none"><span class="glyphicon glyphicon-search"></span></a></td>
            </tr>
            <tr>

                <td>业务员</td>
                <td>
                    <asp:TextBox ID="txtSaleUser" runat="server" Width="85%" placeholder="必选"></asp:TextBox>
                    <a href="javascript:void(0);" onclick="openWeb(4);"><span class="glyphicon glyphicon-search"></span></a></td>

                <td>收货地址</td>
                <td>
                    <input id="txtAddr" readonly="readonly" runat="server" type="text" style="width: 85%" />
                    <a href="javascript:void(0);" onclick="openWeb(5);"><span class="glyphicon glyphicon-search"></span></a>
                </td>
                <td>备注</td>
                <td>
                    <input id="txtReamrk" runat="server" type="text" style="width: 100%" />
                    <input id="hidstatus" type="hidden" runat="server" />
                </td>
                <td>原合同待履行量</td>
                <td style="color: cornflowerblue">
                    <asp:TextBox ID="txtoldconwgt" runat="server" Enabled="False" Text="0" Width="100%"></asp:TextBox>
                    <input id="hidsf" runat="server" type="hidden" />
                    <input id="hidxf" runat="server" type="hidden" />
                    <input id="hidmsg" runat="server" type="hidden" />
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
                                <th>原合同数量</th>
                                <th>原合同已履行量</th>
                                <th>原合同待履行量</th>
                                <th>新合同数量</th>
                                <th>含税单价</th>
                                <th>价税合计</th>
                                <th style="width: 50px;">操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnItemDataBound="rptList_ItemDataBound">

                                <ItemTemplate>
                                    <tr>

                                        <td>
                                            <asp:Literal ID="ltlmatcode" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%>' runat="server"></asp:Literal>
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
                                            <asp:Literal ID="ltlywgt" runat="server"></asp:Literal></td>
                                        <td>
                                            <asp:Literal ID="ltlyorderno" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"C_ORDER_NO_OLD") %>' runat="server"></asp:Literal>
                                            <asp:Literal ID="ltlN_TYPE" Text='<%#DataBinder.Eval (Container.DataItem,"N_TYPE")%>' runat="server" Visible="false"></asp:Literal>
                                            <asp:Literal ID="ltlylxnum" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltldlxnum" runat="server"></asp:Literal></td>
                                        <td>
                                            <asp:TextBox ID="txtWgt" CssClass="wgt" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT")%>' Width="60px"></asp:TextBox>

                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtN_ORIGINALCURTAXPRICE" CssClass="price" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURTAXPRICE")%>' Width="100px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <input class="sumprice" type="text" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent; text-align: left"
                                                value='<%#DataBinder.Eval(Container.DataItem, "N_ORIGINALCURSUMMNY")%>' />

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
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>
                                    <input id="txtWgtSum" type="text" readonly="readonly" style="border: 0; background: transparent; text-align: left; width: 100%" runat="server" />
                                </td>

                                <td></td>

                                <td>
                                    <input id="txtPriceSum" type="text" readonly="readonly" style="border: 0; background: transparent; text-align: left; width: 100%" runat="server" />

                                </td>

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
        <input id="hidCustNO" type="hidden" runat="server" />
        <asp:Literal ID="ltlCustType" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlC_EMP_ID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlC_EMP_NAME" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlC_PROD_NAME" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="ltlN_CON_STATUS" Visible="false" runat="server"></asp:Literal>

    </form>
</body>
</html>
