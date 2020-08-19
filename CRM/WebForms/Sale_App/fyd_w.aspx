<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fyd_w.aspx.cs" Inherits="CRM.WebForms.Sale_App.fyd_w" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>发运安排-委外</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <uc1:common2 runat="server" ID="common2" />
    <script src="js/jsfyd_W.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="dv_btn">
            <ul>
                <li runat="server">
                    <asp:Button ID="btndelrow" runat="server" Text="删除行" CssClass="btn btn-primary btn-xs" OnClick="btndelrow_Click" />
                </li>
                <li runat="server">
                    <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="btn btn-primary btn-xs" OnClick="btnsave_Click" OnClientClick="return save();" />

                </li>
                <li runat="server">
                    <input id="btnAdd" runat="server" type="button" value="订单查询" class="btn btn-primary btn-xs" onclick="openWeb(2);" />
                </li>
                <li>
                    <input id="Button1" type="button" value="可发运量" class="btn btn-primary btn-xs" onclick="openWeb(3);" /></li>
            </ul>
        </div>
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 110px;">发运单单据号</td>
                <td>
                    <asp:TextBox ID="txtsendcode" runat="server" Width="100%" Enabled="False"></asp:TextBox></td>
                <td style="width: 100px;">发运日期</td>
                <td>
                    <asp:TextBox ID="txtfydt" runat="server" Width="100%" class="form-control Wdate"></asp:TextBox></td>
                <td style="width: 100px;">发运方式</td>
                <td>
                    <asp:DropDownList ID="dropfyfs" runat="server" Width="100%"></asp:DropDownList></td>
                <td style="width: 100px;">承运商</td>
                <td>
                    <asp:DropDownList ID="dropcys" runat="server" Width="100%"></asp:DropDownList></td>

            </tr>
            <tr>
                <td>是否线材销售</td>
                <td>
                    <asp:DropDownList ID="dropsfxc" runat="server" Width="50px">
                        <asp:ListItem Value="0001NC10000000007H28">是</asp:ListItem>
                        <asp:ListItem Value="0001NC10000000007H29">否</asp:ListItem>
                    </asp:DropDownList>

                </td>
                <td>到站</td>
                <td>
                    <asp:TextBox ID="txtdz" runat="server" Width="90%"></asp:TextBox><a href="javascript:void(0);" onclick="openWeb(1);"><span class="glyphicon glyphicon-search"></span></a></td>
                <td>车牌号</td>
                <td>
                    <asp:TextBox ID="txtcph" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>GPS设备号</td>
                <td>
                    <asp:TextBox ID="txtgps" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>制单人</td>
                <td>
                    <asp:TextBox ID="txtzdr" runat="server" Width="100%" Enabled="False"></asp:TextBox></td>
                <td>制单日期</td>
                <td>
                    <asp:TextBox ID="txtzddt" runat="server" Width="100%" Enabled="False"></asp:TextBox></td>
                <td>最后修改人</td>
                <td>
                    <asp:TextBox ID="txtxgr" runat="server" Width="100%" Enabled="False"></asp:TextBox></td>
                <td>最后修改时间</td>
                <td>
                    <asp:TextBox ID="txtxgtime" runat="server" Width="100%" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td>审批人</td>
                <td>
                    <asp:TextBox ID="txtspr" runat="server" Width="100%" Enabled="False"></asp:TextBox></td>
                <td>审批日期</td>
                <td>
                    <asp:TextBox ID="txtspdt" runat="server" Width="100%" Enabled="False"></asp:TextBox></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div class="table-responsive" style="width: 100%; overflow: auto;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="table table-bordered table-hover table-condensed" style="white-space: nowrap;" id="table1">
                        <thead>
                            <tr>
                                <th>选择框</th>
                                <th>合同号</th>
                                <th>钢种</th>
                                <th>规格</th>
                                <th>执行标准</th>
                                <th>自由项1</th>
                                <th>自由项2</th>
                                <th>包装要求</th>
                                <th>数量</th>
                                <th>已出库量</th>
                              <%--  <th>待履行</th>--%>
                                <th>仓库</th>
                                <th class="red">发运支数</th>
                                <th class="red">发运量</th>
                                <th>区域</th>
                                <th>质量等级</th>
                                <th>其他要求</th>
                                <th>存货编码</th>
                                <th>存货名称</th>
                                <th>订货客户</th>
                                <th>收货单位</th>
                                <th>到货地区</th>
                                <th>到货地址</th>
                                <th>订单类型</th>
                                <th>行备注</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
                                <ItemTemplate>
                                    <tr onclick="selectcheck(this);">
                                        <td>

                                            <input id="chkOrder" class="che1" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' type="checkbox" />
                                            <span class="rowno" runat="server" id="hanghao"><%#Container.ItemIndex+1 %></span>
                                        </td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NO")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC")%></td>
                                        <td>
                                            <asp:TextBox ID="txtStd_Code" CssClass="stdcode" runat="server" Width="100px" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE")%>'></asp:TextBox>&nbsp;<a href="javascript:void(0);" onclick="openstd(<%#Container.ItemIndex %>,'<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>')"><span class="glyphicon glyphicon-search"></span></a>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtC_FREE1" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_FREE1")%>'></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtC_FREE2" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_FREE2")%>'></asp:TextBox>

                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPack_Code" class="pack" runat="server" Width="40px" Text='<%#DataBinder.Eval (Container.DataItem,"C_PACK")%>'></asp:TextBox>&nbsp;<a href="javascript:void(0);"  onclick='openWeb2(1,<%#Container.ItemIndex %>);'><span class="glyphicon glyphicon-search"></span></a></td>
                                        <td>
                                            <asp:Literal ID="ltlorderwgt" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT")%>'></asp:Literal>
                                        </td>

                                        <td>
                                            <asp:Literal ID="ltlyfywgt" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"YLXWGT")%>'></asp:Literal></td>
                                     <%--   <td>

                                            <input id="txtsywgt" class="sywgt" type="text" runat="server" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent; text-align: left" value='<%#DataBinder.Eval (Container.DataItem,"DLXWGT")%>' />
                                        </td>--%>

                                        <td>
                                            <input id="txtckname" class="ckname" type="text" runat="server" readonly="readonly" style="width: 50px; text-align: center; border: 0; background: transparent; text-align: left" />
                                            <a href="javascript:void(0);" onclick='openWeb2(4,<%#Container.ItemIndex %>);' style="margin-left: 5px; margin-right: 5px"><span class="glyphicon glyphicon-search"></span></a>
                                            <input id="hidckid" class="ckid" runat="server" value='' type="hidden" />
                                        </td>

                                        <td>
                                            <input id="txtfyzs" runat="server" type="text" class="fyzs" style="width: 100px;" /></td>
                                        <td>
                                            <input id="txtjhfyl" class="jhfyl" type="text" runat="server" style="width: 100px;" />
                                        </td>
                                        <td>
                                            <input id="txtarea" class="area" type="text" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_AREA")%>' readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent; text-align: left" /></td>

                                        <td>
                                            <asp:DropDownList ID="dropzldj" runat="server"  CssClass="lev"></asp:DropDownList>
                                            <asp:Literal ID="ltlzldj" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"C_VDEF1")%>' runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <input id="txtqtyq" type="text" runat="server" style="width: 100px; text-align: center; border: 0; background: transparent; text-align: left" />
                                        </td>
                                        <td>

                                            <input id="hidmatcode" class="matcode" value='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%>' type="hidden" />

                                            <asp:Literal ID="ltlmatcode" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%>' runat="server"></asp:Literal>
                                        </td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME")%></td>
                                        <td>
                                            <input id="txtC_CGC" value='<%#DataBinder.Eval (Container.DataItem,"SHDW")%>' type="text" runat="server" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent; text-align: left" />
                                            <a href="javascript:void(0);" style="margin-right: 5px;" onclick='openWeb2(2,<%#Container.ItemIndex %>);'><span class="glyphicon glyphicon-search"></span></a>
                                            <input id="hidC_CGID" type="hidden" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"SHDW")%>' />
                                        </td>
                                        <td>
                                            <input id="txtshdq" value='<%#DataBinder.Eval (Container.DataItem,"SHDQ")%>' type="text" runat="server" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent; text-align: left" />
                                            <a href="javascript:void(0);" style="margin-right: 5px;" onclick='openWeb2(3,<%#Container.ItemIndex %>);'><span class="glyphicon glyphicon-search"></span></a>
                                            <input id="hidshdq" type="hidden" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"SHDQ")%>' />

                                        </td>
                                        <td>
                                            <asp:DropDownList ID="dropshdz"  runat="server"></asp:DropDownList>
                                            <asp:Literal ID="ltlshdz" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"C_RECEIVEADDRESS")%>' runat="server"></asp:Literal>
                                            <asp:Literal ID="ltlcustno" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"C_CUST_NO")%>' runat="server"></asp:Literal>
                                            <asp:Literal ID="ltlpkplan" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"PKPLAN")%>' runat="server"></asp:Literal>

                                        </td>
                                        <td>
                                            <input id="txttype" value='<%#DataBinder.Eval (Container.DataItem,"N_TYPE")%>' class="type" type="text" runat="server" readonly="readonly" style="width: 100%; text-align: center; border: 0; background: transparent; text-align: left" />
                                        </td>
                                        <td>
                                            <input id="txtremark" type="text" runat="server" style="width: 200px; text-align: center; border: 0; background: transparent; text-align: left" /></td>
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
                            <%--    <td></td>--%>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>
                                    <input id="txtcount" runat="server" type="text" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent; text-align: left" />
                                </td>
                                <td>
                                    <input id="txtsumwgt" runat="server" type="text" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent; text-align: left" />
                                </td>
                                <td></td>
                                <td></td>
                                <td></td>

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
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <asp:Literal ID="ltlempname" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltltype" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlcustname" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlcon_no" runat="server" Visible="false"></asp:Literal>
        <input id="hidcustno" runat="server" type="hidden" />
        <input id="hidarea" runat="server" type="hidden" />
        <input id="hidmatcode" runat="server" type="hidden" />
        <input id="hidsfwgt" runat="server" type="hidden" />
    </form>
</body>
</html>
