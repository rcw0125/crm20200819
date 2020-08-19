<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConAdd.aspx.cs" Inherits="CRM.Cust_App.ConAdd" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>

<!DOCTYPE html>
<html>
<head>
    <title>新增合同</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <uc1:common runat="server" ID="common" />
    <script src="js/jsConAdd.js?ver=1.1"></script>
</head>
<body onresize="fromsize();">
    <form runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="dv_btn">
            <ul>
                <li>
                    <asp:Button ID="btnSubmit" runat="server" OnClientClick="return checkInfo(1);" Text="提交" CssClass="btn btn-primary btn-xs" OnClick="btnSubmit_Click" />
                </li>
                <li>
                    <asp:Button ID="btnSave" runat="server" OnClientClick="return checkInfo(0);" Text="保存" CssClass="btn btn-primary btn-xs" OnClick="btnSave_Click" />
                </li>

               <%--  <li>

                    <input id="btnProc_F" type="button" value="副产品" class="btn btn-warning btn-xs" onclick="openWeb(8);" /></li>--%>

                <li>

                    <input id="btnProc" type="button" value="产品" class="btn btn-primary btn-xs" onclick="openWeb(7);" /></li>
                <li>
                    <input id="btnAdd" runat="server" type="button" value="历史签单" class="btn btn-primary btn-xs" onclick="openWeb(6);" /></li>
                <li runat="server" id="FA" visible="false" >
                    <input id="btn_sf" type="button" value="二级客户" class="btn btn-primary btn-xs" onclick="openWeb(2);" />
                </li>
                <li>
                    <input type="text" readonly="readonly" style="width: 100%; text-align: center; border: 0; background: transparent; text-align: left" runat="server" id="txtCust" /></li>
                <li>当前公司：</li>
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
                    <input id="txtDate" runat="server" type="text" style="width: 100%" disabled="disabled" /></td>
                <td>计划生效日期</td>
                <td>
                    <input id="txtStart" runat="server" type="text" readonly="readonly" class="form-control Wdate" style="width: 100%" />
                </td>
                <td>计划失效日期</td>
                <td>
                    <input id="txtEnd" runat="server" type="text" readonly="readonly" class="form-control Wdate" style="width: 100%" />
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
                    <asp:TextBox ID="txtCustName" runat="server"   Width="100%"></asp:TextBox></td>
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

                    <input id="txtC_CGC" readonly="readonly" runat="server" type="text" style="width: 85%" />
                    <a href="javascript:void(0);" onclick="openWeb(1);"><span class="glyphicon glyphicon-search"></span></a></td>
                <td>开票单位</td>
                <td>
                    <input id="txtC_OTC" runat="server" type="text" style="width: 100%"  readonly="readonly" />
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
                <td>合同政策区域</td>
                <td>
                    <asp:DropDownList ID="dropConPolicyArea" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
                <td>备注</td>
                <td>
                    <input id="txtReamrk" runat="server" type="text" style="width: 100%" maxlength="200" /></td>

            </tr>
        </table>

        <div style="overflow: auto; width: 100%" id="flow1">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="table table-bordered table-hover  table-condensed" id="table1">
                        <thead>
                            <tr>
                                <th>物料编码</th>
                                <th>物料名称</th>
                                <th>钢种</th>
                                <th>规格</th>
                                <th>协议号</th>
                                <th>包装标准</th>
                                <th>质量等级</th>
                                <th>数量(吨)</th>
                                <th>含税单价</th>
                                <th>产品用途</th>
                                <th>特殊要求</th>
                                <th style="width: 50px;"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnItemDataBound="rptList_ItemDataBound">

                                <ItemTemplate>
                                    <tr>

                                        <td>
                                            <asp:Literal ID="ltlC_MAT_CODE" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%> ' runat="server"></asp:Literal>

                                        </td>
                                        <td>
                                            <asp:Literal ID="ltlC_MAT_NAME" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%> ' runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltlC_STL_GRD" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%> ' runat="server"></asp:Literal>

                                        </td>
                                        <td>
                                            <asp:Literal ID="ltlC_SPEC" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC")%> ' runat="server"></asp:Literal>


                                        </td>
                                        <td>
                                            <asp:Literal ID="ltlC_ID" runat="server" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem," C_ID")%>'></asp:Literal>
                                            <asp:Literal ID="ltlC_TECH_PROT" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_TECH_PROT")%>'></asp:Literal>
                                            <asp:Literal ID="ltlC_STD_CODE" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE")%>'></asp:Literal>
                                            <asp:Literal ID="ltlzyx1" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"ZYX1")%>'></asp:Literal>
                                            <asp:Literal ID="ltlzyx2" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"ZYX2")%>'></asp:Literal>
                                            <asp:Literal ID="ltlC_IS_BXG" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_BY4")%>'></asp:Literal>

                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPack_Code" runat="server" Width="50px" Text='<%#DataBinder.Eval (Container.DataItem,"C_PACK")%>'></asp:TextBox>&nbsp;<a href="javascript:void(0);" onclick='openWeb2(<%#Container.ItemIndex %>);'><span class="glyphicon glyphicon-search"></span></a>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="dropZL" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <input id="txtWgt" type="text" style="width: 60px;" class="numJe" maxlength="8" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"N_WGT")%>' />
                                        </td>
                                        <td>

                                            <input id="txtPrice" type="text" style="width: 100px;" maxlength="8" class="price" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"PRICE")%>' />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtC_PRO_USE" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                         <td>
                                            <asp:TextBox ID="txtC_CUST_SQ" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Literal ID="ltlindex" Text='<%#DataBinder.Eval (Container.DataItem,"INDEX")%>' Visible="false" runat="server"></asp:Literal>
                                            <asp:LinkButton ID="lbtDel" ToolTip="删除" runat="server" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"INDEX")%>' CommandName="del" CssClass="glyphicon glyphicon-remove"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>

                            </asp:Repeater>
                        </tbody>

                    </table>

                    <asp:ImageButton ID="imgbtnJz" runat="server" OnClick="imgbtnJz_Click" ImageUrl="~/Assets/images/btntm.gif" Height="0px" Width="0px" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <input id="hiddeptid" type="hidden" runat="server" />
        <input id="hidsaleempid" type="hidden" runat="server" />
        <input id="hidC_CGID" type="hidden" runat="server" />
        <input id="hidC_OTCID" type="hidden" runat="server" />
        <input id="hidCustNO" type="hidden" runat="server" />
        <input id="hidCustID" type="hidden" runat="server" />
        <asp:Literal ID="ltlCustLEV" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlCustType" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlC_EMP_ID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlC_EMP_NAME" runat="server" Visible="false"></asp:Literal>

    </form>
</body>
</html>
