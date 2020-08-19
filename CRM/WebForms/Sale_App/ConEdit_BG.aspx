<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConEdit_BG.aspx.cs" Inherits="CRM.Sale_App.ConEdit_BG" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <title>合同变更</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <uc1:common2 runat="server" ID="common2" />
    <script src="js/JsConEdit_BG.js?ver=1.0"></script>
     <script type="text/javascript" src="http://192.168.2.96:8080/WebReport/ReportServer?op=resource&resource=/com/fr/web/jquery.js"></script>
    <script type="text/javascript" src="http://192.168.2.96:8080/WebReport/ReportServer?op=emb&resource=finereport.js"></script>
    <style type="text/css">
        .inputW {
            width: 90%;
        }
    </style>

</head>
<body onresize="fromsize();">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="dv_btn">
            <ul>
                <li>
                    <input id="btnimport" runat="server" type="button" value="导出合同" class="btn btn-primary btn-xs" onclick="openWeb(5);" />
                </li>
                <li runat="server" id="AG">
                    <input id="btndoc" runat="server" type="button" value="文档" class="btn btn-primary btn-xs" onclick="openWeb(4);" />
                </li>
                <li runat="server" id="AF">
                    <input id="btnAdd" runat="server" type="button" value="产品" class="btn btn-primary btn-xs" onclick="openWeb(3);" />
                </li>
                  <li>
                    <input id="btnAdd_TWC" runat="server" type="button" value="产品(头尾材)" class="btn btn-primary btn-xs" onclick="openWeb(7);" />
                </li>
                <li>
                    <asp:Button ID="btnCheck" runat="server" Text="送审" CssClass="btn btn-primary btn-xs" OnClick="btnCheck_Click" OnClientClick="return checkInfo_bg();" />
                </li>
                  <li>
                    <asp:Button ID="btnSave" CssClass="btn btn btn-primary btn-xs" runat="server" Text="保 存" OnClick="btnSave_Click" OnClientClick="return checkInfo();" /></li>
                <li>
                     <asp:Button ID="btncondel" runat="server" Text="合同删除"  CssClass="btn btn btn-primary btn-xs" OnClientClick="return CheckMsg();" OnClick="btncondel_Click"/>
                </li>
                <li>
                     <asp:Button ID="btncancel" runat="server" Text="撤回客户" CssClass="btn btn btn-primary btn-xs" OnClientClick="return CheckMsg();" OnClick="btncancel_Click" />
                </li>
            </ul>
        </div>

    
        <table class="table table-bordered table-condensed" style="margin-top: 10px;">
            <tr>

                <td>合同号 </td>
                <td>
                   <input id="txtConNO" type="text" class="inputW" runat="server"  readonly="readonly" />
                    <input id="hidyconno" type="hidden" runat="server" />
                    <input id="hidconno" type="hidden" runat="server" />
                    <a href="javascript:void(0);" onclick="openWeb(6);"><span class="glyphicon glyphicon-search"></span></a>
                </td>

                <td>合同名称</td>
                <td>
                    <input id="txtConName" runat="server" type="text" class="inputW" />
                </td>
                <td>合同类型</td>
                <td>
                    <asp:DropDownList ID="dropConType" runat="server" CssClass="inputW">
                    </asp:DropDownList></td>
                <td>客户名称
                </td>
                <td>
                    <input id="txtCustName" runat="server" type="text" class="inputW" disabled="disabled" />
                </td>

            </tr>

            <tr>
                <td>签订日期</td>
                <td>
                    <input id="txtQianDanDT" type="text" style="width: 140px;" readonly="readonly" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true })" runat="server" /></td>
                <td>计划生效日期</td>
                <td>
                    <input id="txtPlanStartDT" type="text" style="width: 140px;" readonly="readonly" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true })" runat="server" /></td>

                <td style="color: cornflowerblue">计划失效日期</td>
                <td>
                    <input id="txtPlanEndDT" type="text" style="width: 140px;" readonly="readonly" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true })" runat="server" /></td>

                <td style="color: cornflowerblue">业务类型</td>
                <td>
                   
                    <asp:DropDownList ID="dropYeWuType" runat="server" CssClass="inputW"></asp:DropDownList>
                   
                </td>

            </tr>

            <tr>
                <td>币种</td>
                <td>
                    <asp:DropDownList ID="dropBiZhong" runat="server" CssClass="inputW"></asp:DropDownList>
                </td>
                <td>发运方式</td>
                <td>
                    <asp:DropDownList ID="dropFaYun" runat="server" CssClass="inputW"></asp:DropDownList></td>
                <td>到站</td>
                <td>
                    <input id="txtC_STATION" runat="server" type="text" class="inputW" />
                    <a href="javascript:void(0);" onclick="openWeb(2);"><span class="glyphicon glyphicon-search"></span></a>
                </td>
                <td style="color: cornflowerblue">合同状态</td>
                <td>
                    <input id="txtState" type="text" class="inputW" disabled="disabled" runat="server" />
                    <input id="hidstatus" type="hidden" runat="server" /></td>
            </tr>
            <tr>
                <td>收货单位</td>
                <td>
                    <input id="txtShuoHuoCompany" runat="server" type="text" class="inputW" readonly="readonly" disabled="disabled" /></td>
                <td>开票单位</td>
                <td>
                    <input id="txtKaiPiaoCompany" runat="server" type="text" class="inputW" readonly="readonly" disabled="disabled" /></td>

                <td>收货地址</td>
                <td>
                    <asp:DropDownList ID="dropAddr" runat="server" CssClass="inputW"></asp:DropDownList>
                </td>

                <td >审批人</td>
                <td>
                    <input id="txtC_APPROVEID" runat="server" type="text" class="inputW" disabled="disabled" />
                </td>
            </tr>
            <tr>


                <td>部门</td>
                <td>
                    <input id="txtDept" type="text" class="inputW" runat="server" />
                    <a href="javascript:void(0);" onclick="openWeb(0);"><span class="glyphicon glyphicon-search"></span></a></td>

                <td>业务员</td>
                <td>
                    <input id="txtSaleUser" runat="server" type="text" class="inputW"  readonly="readonly" />
                    <a href="javascript:void(0);" onclick="openWeb(1);"><span class="glyphicon glyphicon-search"></span></a></td>
                <td>销售组织</td>
                <td>
                    <asp:DropDownList ID="dropSale" runat="server" CssClass="inputW"></asp:DropDownList></td>

                <td>审批时间</td>
                <td>
                    <input id="txtD_APPROVEDATE" runat="server" type="text" class="inputW" disabled="disabled" />
                </td>


            </tr>
            <tr>

                <td>备注</td>
                <td colspan="5">
                    <textarea id="txtDESC" runat="server" style="width: 100%; height: 25px;"></textarea></td>
                <td style="color: cornflowerblue">原合同待履行量</td>
                <td>
                    <asp:TextBox ID="txtoldconwgt" runat="server" Enabled="False" Text="0"></asp:TextBox>
                  
                    <input id="hidsf" runat="server" type="hidden" />
                    <input id="hidxf" runat="server" type="hidden" />
                    <input id="hidmsg" runat="server" type="hidden" />
                </td>

            </tr>
            <tr>
                <td>制单人</td>
                <td>
                    <input id="txtZhiDanRen" runat="server" type="text" class="inputW" disabled="disabled" /></td>
                <td>制单时间</td>
                <td>
                    <input id="txtZhiDanTime" runat="server" type="text" class="inputW" disabled="disabled" /></td>
                <td>最后修改人</td>
                <td>&nbsp;<input id="txtLastEditUser" runat="server" type="text" class="inputW" disabled="disabled" /></td>
                <td>最后修改时间</td>
                <td>
                    <input id="txtLastEditTime" runat="server" type="text" class="inputW" disabled="disabled" /></td>

            </tr>

        </table>

        <div style="overflow: auto; width: 100%" id="flow1">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="table table-bordered table-hover table-condensed" style="white-space: nowrap;">
                        <thead>
                            <tr>
                                <th style="width: 35px;"></th>
                                <th>物料编码</th>
                                <th>物料名称</th>
                              
                                <th>执行状态</th>
                                <th>钢种</th>
                                <th>规格</th>
                               
                                <th>自由项1</th>
                                <th>自由项2</th>
                                <th>包装要求</th>
                                <th>质量等级</th>
                                <th>原合同数量</th>
                                <th>原合同已履行量</th>
                                <th>原合同待履行量</th>
                                <th>新合同数量</th>
                                <th>无税单价</th>
                                <th>税率</th>
                                <th>含税单价</th>
                                <th>无税金额</th>
                                <th>价税合计</th>
                                <th>税额</th>
                                <th>计划交货日期</th>
                                <th>合同号</th>
                                <th>行备注</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound" OnItemCommand="rptList_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center">
                                            <asp:LinkButton ID="lbtDel" ToolTip="删除" runat="server" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' CommandName="del" CssClass="glyphicon glyphicon-remove" OnClientClick="return confirm('确定删除吗?');"></asp:LinkButton>

                                        </td>
                                        <td>
                                            <asp:Literal ID="ltlmatcode" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%>' runat="server"></asp:Literal> </td>
                                        <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%></td>
                                    
                                       
                                        <td>
                                            <asp:DropDownList ID="dropzxzt" runat="server">
                                                <asp:ListItem Value="-2">正常</asp:ListItem>
                                                <asp:ListItem Value="7">库存货</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Literal ID="ltlzxzt" runat="server" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"N_EXEC_STATUS")%>'></asp:Literal>

                                        </td>
                                        <td>

                                            <asp:Literal ID="ltlC_STL_GRD" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>' runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltlC_SPEC" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC")%>' runat="server"></asp:Literal>
                                        </td>
                                       
                                        <td>
                                            <%#DataBinder.Eval (Container.DataItem,"C_FREE1")%></td>
                                        <td>
                                            <%#DataBinder.Eval (Container.DataItem,"C_FREE2")%>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPack_Code" runat="server" Width="40px" Text='<%#DataBinder.Eval (Container.DataItem,"C_PACK")%>'></asp:TextBox>&nbsp;<a href="javascript:void(0);" onclick='openWeb2(<%#Container.ItemIndex %>);'><span class="glyphicon glyphicon-search"></span></a></td>

                                        <td>
                                            <asp:DropDownList ID="dropZL" runat="server"></asp:DropDownList>
                                            <asp:Literal ID="ltlC_VDEF1" Text='<%#DataBinder.Eval (Container.DataItem,"C_VDEF1")%>' runat="server" Visible="false"></asp:Literal>
                                            <asp:Literal ID="ltlN_TYPE" Text='<%#DataBinder.Eval (Container.DataItem,"N_TYPE")%>' runat="server" Visible="false"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltlywgt"  runat="server"></asp:Literal></td>
                                        <td>
                                            <asp:Literal ID="ltlyorderno" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"C_ORDER_NO_OLD") %>' runat="server"></asp:Literal>
                                            <asp:Literal ID="ltlylxnum" runat="server"></asp:Literal>

                                        </td>
                                        <td><asp:Literal ID="ltldlxnum" runat="server"></asp:Literal></td>
                                        <td>
                                            <asp:TextBox ID="txtWgt" runat="server" Width="60px" CssClass="price3" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT")%>'></asp:TextBox></td>
                                        <td>
                                            <input class="amount" type="text" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent; text-align: left"
                                                value='<%#DataBinder.Eval(Container.DataItem, "N_ORIGINALCURPRICE")%>' />

                                        </td>
                                        <td>
                                            <input class="taxrate" type="text"  style="width: 50px; text-align: center;"
                                                value='<%#DataBinder.Eval(Container.DataItem, "N_TAXRATE")%>'
                                                id="txtN_TAXRATE"  runat="server" />

                                        </td>
                                        <td>

                                            <asp:TextBox ID="txtN_ORIGINALCURTAXPRICE" runat="server" Width="80px" CssClass="price" Text='<%#DataBinder.Eval (Container.DataItem,"N_ORIGINALCURTAXPRICE")%>'></asp:TextBox>

                                        </td>
                                        <td>
                                            <input class="amount2" type="text" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent; text-align: left"
                                                value='<%#DataBinder.Eval(Container.DataItem, "N_ORIGINALCURMNY")%>' />
                                        </td>
                                        <td>
                                            <input class="amount3" type="text" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent; text-align: left"
                                                value='<%#DataBinder.Eval(Container.DataItem, "N_ORIGINALCURSUMMNY")%>' />
                                        </td>
                                        <td>
                                            <input class="amount4" type="text" readonly="readonly" style="width: 100px; text-align: center; border: 0; background: transparent; text-align: left"
                                                value='<%#DataBinder.Eval(Container.DataItem, "N_ORIGINALCURTAXMNY")%>' />
                                        </td>

                                        <td>
                                             <input id="txtD_DELIVERY_DT" value='<%#DataBinder.Eval (Container.DataItem,"D_DELIVERY_DT","{0:yyy-MM-dd}")%> ' type="text" style="width: 110px;" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true })" runat="server"  />
                                        </td>
                                        <td>
                                            <%#DataBinder.Eval (Container.DataItem,"C_CON_NO")%>
                                            <asp:Literal ID="ltlC_NO" Text='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' runat="server" Visible="false"></asp:Literal>
                                        </td>
                                         <td>
                                              <asp:TextBox ID="txtRemark"  Text='<%#DataBinder.Eval (Container.DataItem,"C_REMARK")%>' runat="server"></asp:TextBox>
                                            <asp:Literal ID="ltlsfpj" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"C_SFPJ")%>' runat="server"></asp:Literal>

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
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>
                                    <input id="txtWGT_SUM" type="text" readonly="readonly" style="border: 0; background: transparent; text-align: left; width: 100%" runat="server" /></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>
                                    <input id="txtN_ORIGINALCURMNY" type="text" readonly="readonly" style="border: 0; background: transparent; text-align: left; width: 100%" runat="server" />
                                </td>
                                <td>
                                    <input id="txtN_ORIGINALCURSUMMNY" type="text" readonly="readonly" style="border: 0; background: transparent; text-align: left; width: 100%" runat="server" />

                                </td>

                                <td>
                                    <input id="txtN_ORIGINALCURTAXMNY" type="text" readonly="readonly" style="border: 0; background: transparent; text-align: left; width: 100%" runat="server" /></td>
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
        <input id="hidC_DEPT_ID" type="hidden" runat="server" />
        <input id="hidC_SALESMAN" type="hidden" runat="server" />
        <asp:Literal ID="ltlCustNo" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlC_EMP_ID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlC_EMP_NAME" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlN_CON_STATUS" Visible="false" runat="server"></asp:Literal>


    </form>
</body>
</html>
