<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fydEdit_WL.aspx.cs" Inherits="CRM.WebForms.Sale_App.fydEdit_WL" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>发运单编辑-物流</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <uc1:common2 runat="server" ID="common2" />
    <script src="js/jsfydedit_WL.js?ver=1.0"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="dv_btn">
            <ul>

                <li>
                    <input type="button" value="返回列表" class="btn btn-warning btn-xs" onclick='history.go(-<%= (int)ViewState["back_no"] %>)' />
                </li>
                <li>
                    <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="btn btn-primary btn-xs" OnClick="btnsave_Click" OnClientClick="return save();" />
                </li>
                <li>
                    <input id="btnprint" type="button" value="打印" onclick="_print();" class="btn btn-primary btn-xs" /></li>
            </ul>
        </div>

        <div class="btn-group" style="float: right; margin-right: 5px;">
            <button type="button" class="btn btn-primary dropdown-toggle btn-xs"
                data-toggle="dropdown">
                执行 <span class="caret"></span>
            </button>
            <ul class="dropdown-menu" role="menu">
                <li>
                    <asp:Button ID="btnOK" CssClass="btn  btn-link btn-sm" runat="server" Text="审核" OnClick="btnOK_Click" />
                </li>
                <li>
                    <asp:Button ID="btnedit" runat="server" Text="弃审" CssClass="btn btn-link btn-sm" OnClick="btnedit_Click" OnClientClick="return confirm('确定要弃审吗？');" />
                </li>
                <li>
                    <asp:Button ID="btnnc" runat="server" Text="导入NC" CssClass="btn btn-link btn-sm" OnClick="btnnc_Click" OnClientClick="return importNC();" />
                </li>
                <li>
                    <asp:Button ID="btntm" runat="server" Text="导入条码" CssClass="btn btn-link btn-sm" OnClick="btntm_Click" OnClientClick="return importRF();" />
                </li>
                <li>
                    <asp:Button ID="btnwl" runat="server" Text="虚拟导入物流" CssClass="btn btn-link btn-sm" OnClick="btnwl_Click" OnClientClick="return importWL();" />
                </li>
            </ul>
        </div>
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width: 110px;">发运单单据号</td>
                <td>
                    <asp:TextBox ID="txtsendcode" runat="server" Width="100%" Enabled="False"></asp:TextBox>
                    <asp:Literal ID="ltlpkid" Visible="false" runat="server"></asp:Literal>
                </td>
                <td style="width: 100px;">发运日期</td>
                <td>
                    <asp:TextBox ID="txtfydt" runat="server" Width="100%" Enabled="False" class="form-control Wdate"></asp:TextBox></td>
                <td style="width: 100px;">发运方式</td>
                <td>
                    <asp:DropDownList ID="dropfyfs" runat="server" Width="100%" Enabled="False"></asp:DropDownList></td>
                <td style="width: 100px;">承运商</td>
                <td>
                    <asp:DropDownList ID="dropcys" runat="server" Width="100%"></asp:DropDownList></td>

            </tr>
            <tr>
                <td>是否线材销售</td>
                <td>
                    <asp:DropDownList ID="dropsfxc" runat="server" Width="50px" Enabled="False">
                        <asp:ListItem Value="0001NC10000000007H28">是</asp:ListItem>
                        <asp:ListItem Value="0001NC10000000007H29">否</asp:ListItem>
                    </asp:DropDownList></td>
                <td>到站</td>
                <td>
                    <asp:TextBox ID="txtdz" runat="server" Width="90%" Enabled="False"></asp:TextBox></td>
                <td>车牌号</td>
                <td>
                    <asp:TextBox ID="txtcph" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>GPS设备号</td>
                <td>
                    <asp:TextBox ID="txtgps" runat="server" Width="100%" ></asp:TextBox>
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
                <td>状态</td>
                <td>
                    <asp:Literal ID="ltlstatus" runat="server"></asp:Literal>

                    <input id="hidstatus" type="hidden" runat="server" />
                </td>
                <td>发运支数/量</td>
                <td>
                    <input id="txtfyqua" type="text" style="width: 50px" disabled="disabled" runat="server" />&nbsp;支&nbsp;
                    <input id="txtfywgt" type="text" style="width: 50%" disabled="disabled" runat="server" />&nbsp;吨
                    <input id="hidsf" runat="server" type="hidden" />
                    <input id="hidxf" runat="server" type="hidden" />
                    <input id="hidmsg" runat="server" type="hidden" />
                </td>
            </tr>
            <tr>
                <td>是否包到</td>
                <td>
                    <asp:DropDownList ID="dropsfbdj" runat="server" Width="50px" Enabled="False">
                        <asp:ListItem Value="0">否</asp:ListItem>
                        <asp:ListItem Value="1">是</asp:ListItem>
                    </asp:DropDownList></td>
                <td>虚拟车号</td>
                <td>
                    <asp:TextBox ID="txtxnch" runat="server" Width="100%" Enabled="False"></asp:TextBox></td>
                <td>司机姓名/电话</td>
                <td>
                    <asp:TextBox ID="txtsjxm" runat="server" Width="100%" ></asp:TextBox>

                </td>
                <td>客户姓名/电话</td>
                <td>
                    <asp:TextBox ID="txtsjtel" runat="server" Width="100%" Enabled="False" ></asp:TextBox>

                </td>
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
                                <th>自由项1</th>
                                <th>自由项2</th>
                                <th>包装要求</th>
                                <th>仓库</th>
                                <th class="red">发运支数</th>
                                <th class="red">发运量</th>
                                <th class="red">到货地点</th>
                                <th class="red">运费</th>
                                <th>行备注</th>
                                <th>区域</th>
                                <th>已出库量</th>
                                <th>质量等级</th>
                                <th>其他要求</th>
                                <th>存货编码</th>
                                <th>存货名称</th>
                                <th>订货客户</th>
                                <th>收货单位</th>
                                <th>到货地区</th>
                              
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <input id="hidpkid" runat="server" class="pkid" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' type="hidden" />

                                            <input id="chkOrder" class="che1" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ORDERPK")%>' type="checkbox" />
                                            <span class="rowno"><%#Container.ItemIndex+1 %></span></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NO")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_FREE_TERM")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_FREE_TERM2")%></td>
                                        <td>
                                            <%#DataBinder.Eval (Container.DataItem,"C_PACK")%>  
                                        </td>

                                        <td>
                                            <%#DataBinder.Eval (Container.DataItem,"C_SEND_STOCK_CODE")%>
                                        </td>

                                        <td>
                                            <%#DataBinder.Eval (Container.DataItem,"N_FYZS")%>

                                        </td>
                                        <td>
                                            <%#DataBinder.Eval (Container.DataItem,"N_FYWGT")%>

                                        </td>
                                        <td> <%#DataBinder.Eval (Container.DataItem,"C_AOG_SITE")%></td>
                                        <td> <%#DataBinder.Eval (Container.DataItem,"N_PRICE")%></td>
                                        <td>
                                            <%#DataBinder.Eval (Container.DataItem,"C_REMARK")%>
                                        </td>
                                        <td>  <input id="txtarea" runat="server" class="area" type="text" value='<%#GetConArea(DataBinder.Eval (Container.DataItem,"C_ORDERPK"))%>' readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent; text-align: left" />
                                               <asp:Literal ID="ltlcustno" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"C_CUSTNO")%>' runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltlyckwtg" runat="server"></asp:Literal></td>
                                        <td>

                                            <%# GetCheck(DataBinder.Eval (Container.DataItem,"C_QUALIRY_LEV"))%>
                                        </td>
                                        <td>

                                            <%#DataBinder.Eval (Container.DataItem,"C_ELSENEED")%>
                                        </td>
                                        <td>  <asp:Literal ID="ltlmatcode" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%>' runat="server"></asp:Literal></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%></td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_ORGO_CUST")%></td>
                                        <td>
                                            <%#GetCust(DataBinder.Eval (Container.DataItem,"C_CGC"))%>
                                        </td>
                                        <td>
                                            <%#GetArea(DataBinder.Eval (Container.DataItem,"C_SEND_AREA"))%>
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
                                <td>&nbsp;</td>
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

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <input id="hidempname" runat="server" type="hidden" />
        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltltype" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlimport_num" runat="server" Visible="false"></asp:Literal>
    </form>
</body>
</html>
