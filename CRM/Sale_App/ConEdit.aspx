<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConEdit.aspx.cs" Inherits="CRM.Sale_App.ConEdit" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <title>修改合同</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Assets/js/jquery-2.0.3.min.js"></script>
    <script src="../Assets/js/bootstrap.min.js"></script>
    <script src="../Assets/js/common.js"></script>
    <script src="JsConEdit.js"></script>
    <style type="text/css">
        .inputW {
            width: 140px;
        }
    </style>
</head>
<body onresize="fromsize();">
    <form id="form1" runat="server">

        <div class="dv_btn" style="margin-top: 5px;">
            <ul>
                <li>
                    <button type="button" class="btn btn-warning btn-xs" onclick='window.location.href="ConList.aspx"'>返回</button></li>

                <li>
                    <asp:Button ID="btnCheck" runat="server" Text="提交审批" CssClass="btn btn-warning btn-xs" OnClick="btnCheck_Click" />
                </li>


                <li>
                    <asp:Literal ID="ltlWGT" runat="server"></asp:Literal></li>
            </ul>
        </div>

        <ul id="myTab" class="nav nav-tabs">
            <li class="active"><a href="#home" data-toggle="tab">基本信息</a> </li>
            <li><a href="#order" data-toggle="tab">合同明细</a></li>

        </ul>
        <div class="tab-content">
            <div class="tab-pane fade  in active" id="home">
                <div class="dv_search" style="margin-top: 5px">
                    <ul>
                        <li>
                            <asp:Button ID="btnSave" CssClass="btn btn-primary btn-xs" runat="server" Text="保 存" OnClick="btnSave_Click" />
                        </li>
                       

                    </ul>
                </div>
                <table class="table table-bordered" style="margin-top: 10px;">
                    <tr>

                        <td>合同号 </td>
                        <td>
                            <input id="txtConNO" type="text" class="inputW" runat="server" disabled="disabled" /></td>

                        <td>合同名称</td>
                        <td>
                            <input id="txtConName" runat="server" type="text" class="inputW" />
                        </td>
                        <td>合同类型</td>
                        <td>
                            <asp:DropDownList ID="dropConType" runat="server" CssClass="inputW"></asp:DropDownList></td>
                        <td>客户名称
                        </td>
                        <td>
                            <input id="txtCustName" runat="server" type="text" class="inputW" disabled="disabled" />
                        </td>

                    </tr>

                    <tr>
                        <td>签订日期</td>
                        <td>
                            <input id="txtQianDanDT" type="text" style="width: 140px;" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true })" runat="server" /></td>
                        <td>计划生效日期</td>
                        <td>
                            <input id="txtPlanStartDT" type="text" style="width: 140px;" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, maxDate: '#F{$dp.$D(\'txtPlanEndDT\')}' })" runat="server" /></td>

                        <td style="color: red">计划失效日期</td>
                        <td>
                            <input id="txtPlanEndDT" type="text" style="width: 140px;" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true, minDate: '#F{$dp.$D(\'txtPlanStartDT\')}' })" runat="server" /></td>

                        <td style="color: red">系统计划失效日期</td>
                        <td>
                            <input id="txtSysPlanEndDT" type="text" style="width: 140px;" class="Wdate" onclick="WdatePicker({ isShowClear: false, readOnly: true })" runat="server" disabled="disabled" />
                        </td>

                    </tr>

                    <tr>
                        <td style="color: red">客户等级</td>
                        <td>
                            <input id="txtCustLEV" runat="server" disabled="disabled" type="text" class="inputW" /></td>
                        <td>发运方式</td>
                        <td>
                            <asp:DropDownList ID="dropFaYun" runat="server" CssClass="inputW"></asp:DropDownList></td>
                        <td>币种</td>
                        <td>
                            <asp:DropDownList ID="dropBiZhong" runat="server" CssClass="inputW"></asp:DropDownList>
                        </td>
                        <td style="color: red">业务类型</td>
                        <td>
                            <asp:DropDownList ID="dropYeWuType" runat="server" CssClass="inputW"></asp:DropDownList></td>




                    </tr>

                    <tr>


                        <td>部门</td>
                        <td>
                            <input id="txtDept" type="text" class="inputW" runat="server" disabled="disabled" />
                            <a href="#" onclick="openWeb(0);"><span class="glyphicon glyphicon-search"></span></a></td>

                        <td>业务员</td>
                        <td>
                            <input id="txtSaleUser" runat="server" type="text" class="inputW" disabled="disabled" />
                            <a href="#" onclick="openWeb(1);"><span class="glyphicon glyphicon-search"></span></a></td>
                        <td>销售组织</td>
                        <td>
                            <asp:DropDownList ID="dropSale" runat="server" CssClass="inputW"></asp:DropDownList></td>

                        <td style="color: red">分类</td>
                        <td>
                            <asp:DropDownList ID="dropClass" runat="server" CssClass="inputW"></asp:DropDownList></td>


                    </tr>
                    <tr>
                        <td>库存组织</td>
                        <td>
                            <input id="txtKC" runat="server" type="text" class="inputW" /></td>

                        <td>收货单位</td>
                        <td>
                            <input id="txtShuoHuoCompany" runat="server" type="text" class="inputW" disabled="disabled" /></td>

                        <td>收货地址</td>
                        <td>
                            <input id="txtShuoHuoAddr" runat="server" type="text" class="inputW" /></td>
                        <td>开票单位</td>
                        <td>
                            <input id="txtKaiPiaoCompany" runat="server" type="text" class="inputW" disabled="disabled" /></td>


                    </tr>

                    <tr>



                        <td>合同区域</td>
                        <td>
                            <asp:DropDownList ID="dropArea" runat="server" CssClass="inputW"></asp:DropDownList></td>
                        <td style="color: red">合同状态</td>
                        <td>
                            <input id="txtState" type="text" class="inputW" disabled="disabled" runat="server" /></td>

                        <td>是否发运</td>

                        <td>&nbsp;<input id="chkIsFaYun" type="checkbox" runat="server" checked="checked" /></td>

                        <td>&nbsp;</td>
                        <td>&nbsp;</td>

                    </tr>

                    <tr>

                        <td>说明</td>
                        <td colspan="7">
                            <textarea id="txtDESC" runat="server" style="width: 900px; height: 50px;"></textarea></td>

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
                    <tr>



                        <td>审批人</td>
                        <td>
                            <input id="txtCheckUser" runat="server" type="text" class="inputW" disabled="disabled" /></td>
                        <td>审批时间</td>
                        <td>
                            <input id="txtCheckTime" runat="server" type="text" class="inputW" disabled="disabled" /></td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>

                        <td>&nbsp;</td>
                        <td>&nbsp;</td>

                    </tr>
                </table>
            </div>
            <div class="tab-pane fade" id="order">

                <table style="width: 100%; margin-top: 10px;">

                    <tr>
                        <td id="td1" style="vertical-align: top">
                            <div class="panel panel-default">
                                <iframe id="iframe1" style="overflow: auto; border: hidden; width: 100%" runat="server"></iframe>
                            </div>
                        </td>
                        <td style="width: 20px;">&nbsp;</td>
                        <td style="vertical-align: top" id="td2">
                            <ul id="myTab2" class="nav nav-tabs">
                                <li class="active"><a href="#tab1" data-toggle="tab">挂单</a> </li>
                                <li><a href="#tab2" data-toggle="tab">线材计划</a></li>
                                <li><a href="#tab3" data-toggle="tab">车间线材计划</a></li>
                                <li><a href="#tab4" data-toggle="tab">炼钢计划</a></li>

                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane fade  in active" id="tab1">

                                    <div class="panel panel-default" style="margin-top: 10px;">
                                        <iframe id="iframe2" style="overflow: auto; border: hidden; width: 100%" src="_Roll_Product.aspx"></iframe>
                                    </div>

                                </div>
                                <div class="tab-pane fade" id="tab2">
                                    <div class="dv_search" style="margin-top: 10px;">
                                        <ul>
                                            <li>日期：
                                            </li>
                                            <li>
                                                <input id="Text1" type="text" /></li>
                                            <li>
                                                <input id="Text2" type="text" /></li>
                                            <li>
                                                <button type="button" class="btn btn-primary btn-xs">查询</button></li>

                                        </ul>
                                    </div>
                                    <div>
                                        <table class="table table-bordered table-hover" style="white-space: nowrap;">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>线材</th>
                                                    <th>需求总量</th>
                                                    <th>完工数量</th>
                                                    <th>钢坯现存库</th>
                                                    <th>订单执行情况</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <input id="Checkbox4" type="checkbox" /></td>
                                                    <td>普碳钢线材</td>
                                                    <td>12050</td>
                                                    <td>8198.671</td>
                                                    <td>826.761</td>
                                                    <td>-3851.329</td>

                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tab3">
                                    <div class="dv_search" style="margin-top: 10px;">
                                        <ul>
                                            <li>日期：
                                            </li>
                                            <li>
                                                <input id="Text1" type="text" /></li>
                                            <li>
                                                <input id="Text2" type="text" /></li>
                                            <li>
                                                <button type="button" class="btn btn-primary btn-xs">查询</button></li>

                                        </ul>
                                    </div>
                                    <table class="table table-bordered table-hover" style="white-space: nowrap;">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>车间</th>
                                                <th>日期</th>
                                                <th>预测产能</th>
                                                <th>实际排产量</th>
                                                <th>前期剩余量</th>
                                                <th>产品对比</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <input id="Checkbox2" type="checkbox" /></td>
                                                <td>一车间</td>
                                                <td>28</td>
                                                <td>0</td>
                                                <td>0</td>
                                                <td>0</td>
                                                <td>0</td>

                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="tab-pane fade" id="tab4">
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>

            </div>


        </div>

        <input id="hidDeptID" type="hidden" runat="server" />
        <input id="hidEmpID" type="hidden" runat="server" />
        <asp:Literal ID="ltlUserID" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
