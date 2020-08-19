<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order_Roll.aspx.cs" Inherits="CRM.WebForms.Sale_App.Order_Roll" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>预测订单</title>
    <uc1:common2 runat="server" ID="common2" />
    <script src="../JsDate.js"></script>
    <script src="js/jsOrder_Roll.js?ver=1.1"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">

                    <a data-toggle="collapse" data-parent="#accordion" style="width: 100%; display: block; text-decoration: none;"
                        href="#collapseOne"><span class="glyphicon glyphicon-align-justify" style="margin-right: 15px;"></span>新增预测订单
                    </a>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table class="table table-bordered table-condensed">
                                <tr>
                                    <td>
                                        <input id="btnAdd" runat="server" type="button" value="产品" class="btn btn-info btn-xs" onclick="openWeb(1);" />

                                        &nbsp;
                                       
                                        <asp:Button ID="btndel" runat="server" Text="删除" CssClass="btn btn-info btn-xs" OnClick="btndel_Click" />
                                        &nbsp;
                                        <asp:Button ID="btnsave" runat="server" Text="提报"  CssClass="btn btn-info btn-xs" OnClick="btnsave_Click" OnClientClick="return checksave();" />
                                    </td>
                                </tr>
                            </table>
                            <table class="table table-bordered table-condensed table-hover">
                                <thead>
                                    <tr>
                                        <th>选择</th>
                                        <th>物料编码</th>
                                        <th>物料名称</th>
                                        <th>钢种</th>
                                        <th>规格</th>
                                        <th>自由项1</th>
                                        <th>自由项2</th>
                                        <th>执行标准</th>
                                        <th>包装要求</th>
                                        <th>数量</th>
                                        <th>销售区域</th>
                                        <th>销售客户信息</th>
                                        <th>不锈钢客户信息</th>
                                        <th>备注说明</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptList_Add" runat="server" OnItemDataBound="rptList_Add_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <input id="chkMat_Code" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' type="checkbox" />
                                                    <%#Container.ItemIndex+1 %>
                                                    <asp:Literal ID="ltlindex" Text='<%#DataBinder.Eval (Container.DataItem,"INDEX")%>' Visible="false" runat="server"></asp:Literal>
                                                    <asp:Literal ID="ltlC_IS_BXG" Visible="false" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_IS_BXG")%>'></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltlC_MAT_CODE" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%>' runat="server"></asp:Literal>

                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltlC_MAT_NAME" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%>' runat="server"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltlC_STL_GRD" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%>' runat="server"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltlC_SPEC" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC")%>' runat="server"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltlZYX1" Text='<%#DataBinder.Eval (Container.DataItem,"ZYX1")%>' runat="server"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltlZYX2" Text='<%#DataBinder.Eval (Container.DataItem,"ZYX2")%>' runat="server"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltlStdCode" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE")%>'></asp:Literal>

                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPack_Code" Text='<%#DataBinder.Eval (Container.DataItem,"Pack")%>' runat="server" Width="40px"></asp:TextBox>&nbsp;<a href="javascript:void(0);" onclick='openWeb2(<%#Container.ItemIndex %>);'><span class="glyphicon glyphicon-search"></span></a></td>
                                                <td>
                                                    <asp:TextBox ID="txtWgt" CssClass="wgt" Text='<%#DataBinder.Eval (Container.DataItem,"WGT")%>' runat="server" Width="60px"></asp:TextBox></td>
                                                <td>
                                                    <asp:DropDownList ID="dropArea" runat="server" Width="120"></asp:DropDownList>
                                                    <asp:Literal ID="ltlArea" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"Area")%>' runat="server"></asp:Literal>
                                                </td>
                                                <td>

                                                    <asp:TextBox ID="txtCustName"  runat="server" Width="80px" Text='<%#DataBinder.Eval (Container.DataItem,"CustName")%>'></asp:TextBox>&nbsp;<a href="javascript:void(0);" onclick='openWeb3(<%#Container.ItemIndex %>);'><span class="glyphicon glyphicon-search"></span></a>

                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtBXGCustName" runat="server" Width="80px" Text='<%#DataBinder.Eval (Container.DataItem,"CustName")%>'></asp:TextBox>&nbsp;<a href="javascript:void(0);" onclick='openWeb4(<%#Container.ItemIndex %>);'><span class="glyphicon glyphicon-search"></span></a>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRemark" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"Remark")%>'></asp:TextBox>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </tbody>
                            </table>
                            <asp:ImageButton ID="imgbtnJz" runat="server" OnClick="imgbtnJz_Click" ImageUrl="~/Assets/images/btntm.gif" Height="10px" Width="10px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <a data-toggle="collapse" data-parent="#accordion" style="width: 100%; display: block; text-decoration: none;"
                        href="#collapseTwo"><span class="glyphicon glyphicon-align-justify" style="margin-right: 15px;"></span>预测订单列表查询
                    </a>
                </div>
                <div id="collapseTwo" class="panel-collapse collapse in">

                    <table class="table table-bordered table-condensed">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtMatCode" runat="server" placeholder="物料编码" Width="100%"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtMatName" runat="server" placeholder="物料名称" Width="100%"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtStlGrd" runat="server" placeholder="钢种" Width="100%"></asp:TextBox>
                            </td>

                            <td>
                                <asp:TextBox ID="txtSpec" runat="server" placeholder="规格" Width="100%"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCustName" runat="server" placeholder="客户信息" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 50px;">日期</td>
                            <td>
                                <input id="txtStart" type="text" style="width: 110px;" readonly="readonly" class=" form-control Wdate" runat="server" /></td>
                            <td>
                                <input id="txtEnd" type="text" style="width: 110px;" readonly="readonly" class=" form-control Wdate" runat="server" /></td>
                            <td style="width: 80px;">区域</td>
                            <td>
                                <asp:DropDownList ID="dropsalearea" runat="server">
                                </asp:DropDownList></td>


                            <td style="width: 150px;">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnxc" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btnxc_Click" OnClientClick="_loading(1);" />
                                        &nbsp;
                                        <asp:Button ID="btnclose" runat="server" Text="关闭订单" CssClass="btn btn-warning btn-xs" OnClick="btnclose_Click" OnClientClick="return confirm('确定删除订单吗');" />
                                        &nbsp;
                                    </ContentTemplate>
                                </asp:UpdatePanel>



                            </td>
                            <td>
                                <asp:Button ID="btnExport" runat="server" Text="导出" CssClass="btn  btn-success btn-xs" OnClick="btnExport_Click" /></td>
                        </tr>
                    </table>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div id="flow1" style="overflow: auto;">
                                <table class="table table-bordered table-condensed table-hover" style="white-space: nowrap;">
                                    <thead>
                                        <tr>
                                            <th>合计</th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                            <th class="red">
                                                <asp:Literal ID="ltlsumwgt" runat="server"></asp:Literal></th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                        </tr>
                                        <tr>
                                            <th>选择</th>
                                            <th>订单号</th>
                                            <th>物料编码</th>
                                            <th>物料名称</th>
                                            <th>钢种</th>
                                            <th>规格</th>
                                            <th>数量</th>
                                            <th class="red">执行状态</th>
                                            <th>自由项1</th>
                                            <th>自由项2</th>
                                            <th>执行标准</th>
                                            <th>包装要求</th>
                                            <th>销售区域</th>
                                            <th>客户信息</th>
                                            <th>业务员</th>
                                            <th>录入时间</th>
                                            <th>备注说明</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptNeedOrder" runat="server" OnItemDataBound="rptNeedOrder_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <input id="cbxID" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' type="checkbox" />
                                                        <%#Container.ItemIndex+1 %>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="ltlC_ORDER_NO" Text='<%#DataBinder.Eval (Container.DataItem,"C_ORDER_NO")%>' runat="server"></asp:Literal></td>
                                                    <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE")%></td>
                                                    <td><%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME")%></td>
                                                    <td><%#DataBinder.Eval (Container.DataItem,"C_STL_GRD")%></td>
                                                    <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC")%></td>
                                                    <td>
                                                        <asp:Literal ID="ltlwgt" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT")%>' runat="server"></asp:Literal>
                                                    </td>
                                                    <td><%#DataBinder.Eval (Container.DataItem,"ZXZT")%>
                                                        <asp:Literal ID="ltlN_EXEC_STATUS" Visible="false" Text='<%#DataBinder.Eval (Container.DataItem,"N_EXEC_STATUS")%>' runat="server"></asp:Literal>
                                                    </td>
                                                    <td><%#DataBinder.Eval (Container.DataItem,"C_FREE1")%></td>
                                                    <td><%#DataBinder.Eval (Container.DataItem,"C_FREE2")%></td>
                                                    <td><%#DataBinder.Eval (Container.DataItem,"C_STD_CODE")%></td>
                                                    <td><%#DataBinder.Eval (Container.DataItem,"C_PACK")%></td>
                                                    <td><%#DataBinder.Eval (Container.DataItem,"C_AREA")%></td>
                                                    <td><%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME")%></td>
                                                    <td><%#DataBinder.Eval (Container.DataItem,"C_EMP_NAME")%></td>
                                                    <td><%#DataBinder.Eval (Container.DataItem,"D_DT")%></td>
                                                    <td><%#DataBinder.Eval (Container.DataItem,"C_REMARK4")%></td>

                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>

        </div>
        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlempname" runat="server" Visible="false"></asp:Literal>

    </form>
</body>
</html>
