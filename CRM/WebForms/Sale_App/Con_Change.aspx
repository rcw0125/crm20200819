<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Con_Change.aspx.cs" Inherits="CRM.WebForms.Sale_App.Con_Change" %>

<%@ Register Src="~/WebForms/Sale_App/common2.ascx" TagPrefix="uc1" TagName="common2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>合同变更</title>
    <uc1:common2 runat="server" ID="common2" />
</head>
<body>
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
            </ul>
        </div>

        <div class="btn-group" style="float: right; margin-right: 5px;">
            <button type="button" class="btn btn-primary dropdown-toggle btn-xs"
                data-toggle="dropdown">
                执行 <span class="caret"></span>
            </button>
            <ul class="dropdown-menu" role="menu">
                <li runat="server" id="AA">
                    <asp:Button ID="btnSave" CssClass="btn  btn-link btn-sm" runat="server" Text="保 存" OnClientClick="return checkInfo();" /></li>
                <li runat="server" id="AB">
                    <asp:Button ID="btnCheck" runat="server" Text="送审" CssClass="btn btn-link btn-sm" />
                </li>
            </ul>
        </div>
        <div style="float: right; margin-right: 5px;">
            <asp:Literal ID="ltlWGT" runat="server"></asp:Literal>
        </div>
        <table class="table table-bordered table-condensed" style="margin-top: 10px;">
            <tr>

                <td>合同号 </td>
                <td>
                    <input id="txtConNO" type="text" class="inputW" value="XG-XS-19011240-1" runat="server" disabled="disabled" /></td>

                <td>合同名称</td>
                <td>
                    <input id="txtConName" runat="server" type="text" class="inputW" value="1月份合同" />
                </td>
                <td>合同类型</td>
                <td>
                    <asp:DropDownList ID="dropConType" runat="server" CssClass="inputW">
                        <asp:ListItem>价格数量不控制</asp:ListItem>
                    </asp:DropDownList></td>
                <td>客户名称
                </td>
                <td>
                    <input id="txtCustName" runat="server" type="text" class="inputW"  value="兴化市联强金属材料有限公司" disabled="disabled" />
                </td>

            </tr>

            <tr>
                <td>签订日期</td>
                <td>
                    <input id="txtQianDanDT" type="text" style="width: 140px;" readonly="readonly" class="form-control Wdate" runat="server" /></td>
                <td>计划生效日期</td>
                <td>
                    <input id="txtPlanStartDT" type="text" style="width: 140px;" readonly="readonly" class="form-control Wdate" runat="server" /></td>

                <td style="color: cornflowerblue">计划失效日期</td>
                <td>
                    <input id="txtPlanEndDT" type="text" style="width: 140px;" readonly="readonly" class="form-control Wdate" runat="server" /></td>

                <td style="color: cornflowerblue">计划交货日期</td>
                <td>
                    <input id="txtD_NEED_DT" type="text" style="width: 140px;" readonly="readonly" class="form-control Wdate" runat="server" />
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
                <td style="color: cornflowerblue">业务类型</td>
                <td>
                    <asp:DropDownList ID="dropYeWuType" runat="server" CssClass="inputW"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>收货单位</td>
                <td>
                    <input id="txtShuoHuoCompany" runat="server" type="text" class="inputW" disabled="disabled" /></td>
                <td>开票单位</td>
                <td>
                    <input id="txtKaiPiaoCompany" runat="server" type="text" class="inputW" disabled="disabled" /></td>

                <td>收货地址</td>
                <td>
                    <asp:DropDownList ID="dropAddr" runat="server" CssClass="inputW"></asp:DropDownList>
                </td>

                <td style="color: cornflowerblue">合同类别</td>
                <td>
                    <asp:DropDownList ID="dropClass" runat="server" CssClass="inputW"></asp:DropDownList>
                </td>



            </tr>
            <tr>


                <td>部门</td>
                <td>
                    <input id="txtDept" type="text" class="inputW" runat="server" />
                    <a href="javascript:void(0);" onclick="openWeb(0);"><span class="glyphicon glyphicon-search"></span></a></td>

                <td>业务员</td>
                <td>
                    <input id="txtSaleUser" runat="server" type="text" class="inputW" />
                    <a href="javascript:void(0);" onclick="openWeb(1);"><span class="glyphicon glyphicon-search"></span></a></td>
                <td>销售组织</td>
                <td>
                    <asp:DropDownList ID="dropSale" runat="server" CssClass="inputW"></asp:DropDownList></td>

                <td style="color: cornflowerblue">合同状态</td>
                <td>
                    <input id="txtState" type="text" class="inputW" disabled="disabled" runat="server" />
                    <input id="hidstatus" type="hidden" runat="server" />
                </td>


            </tr>
            <tr>

                <td>备注</td>
                <td colspan="5">
                    <textarea id="txtDESC" runat="server" style="width: 100%; height: 25px;"></textarea></td>
                <td style="color: cornflowerblue">审批流程</td>
                <td>
                    <asp:Literal ID="ltlC_APPROVER_FLOW" runat="server"></asp:Literal></td>

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
                                <th>维护等级</th>
                                <th>优先级别</th>
                                <th>执行状态</th>
                                <th>钢种</th>
                                <th>规格</th>
                                <th>客户协议</th>
                                <th>自由项1</th>
                                <th>自由项2</th>
                                <th>包装要求</th>
                                <th>质量等级</th>
                                <th>原合同数量</th>
                                <th>已履行量</th>
                                <th>原合同剩余数量</th>
                                <th>新合同数量</th>
                                <th>无税单价</th>
                                <th>税率</th>
                                <th>含税单价</th>
                                <th>无税金额</th>
                                <th>价税合计</th>
                                <th>税额</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td style="text-align: center">
                                    <asp:LinkButton ID="lbtDel" ToolTip="删除" runat="server" CommandName="del" CssClass="glyphicon glyphicon-remove" OnClientClick="return confirm('确定删除吗?');"></asp:LinkButton>

                                </td>
                                <td>8010611055</td>
                                <td>热轧热处理高速线材</td>
                                <td>普通
                                </td>
                                <td>优先
                                </td>
                                <td>正常 
                                </td>
                                <td>Cr11S-L
                                </td>
                                <td>φ5.5
                                </td>
                                <td>XG-XY-818035</td>
                                <td>Cr11S-L~协议
                                </td>
                                <td>Cr11S-L~JSKZ-526-100
                                </td>
                                <td>C1</td>

                                <td>A
                                </td>
                                <td>500</td>
                                <td>60
                                    </td>
                                <td>440</td>
                                <td><input id="Text1" type="text" value="" /></td>
                               
                                <td>
                                </td>
                                <td>0.16

                                </td>
                                <td>

                                </td>
                                <td>
                                 
                                </td>
                                <td>
                                  
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:LinkButton ID="LinkButton1" ToolTip="删除" runat="server" CommandName="del" CssClass="glyphicon glyphicon-remove" OnClientClick="return confirm('确定删除吗?');"></asp:LinkButton>

                                </td>
                                <td>8010611055</td>
                                <td>热轧热处理高速线材</td>
                                <td>普通
                                </td>
                                <td>优先
                                </td>
                                <td>正常 
                                </td>
                                <td>Cr11S-L
                                </td>
                                <td>φ6.5
                                </td>
                                <td>XG-XY-818035</td>
                                <td>Cr11S-L~协议
                                </td>
                                <td>Cr11S-L~JSKZ-526-100
                                </td>
                                <td>C1</td>
                                <td>A
                                </td>
                                <td>0</td>
                                <td>0
                                    </td>
                                <td>0</td>
                                <td><input id="Text1" type="text" value="" /></td>
                               
                                <td>
                                </td>
                                <td>0.16

                                </td>
                                <td>

                                </td>
                                <td>
                                 
                                </td>
                                <td>
                                  
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                        </tbody>
                        <tfoot>
                           
                        </tfoot>

                    </table>
                    <asp:ImageButton ID="imgbtnJz" runat="server"  ImageUrl="~/Assets/images/btntm.gif" Height="0px" Width="0px" />
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
