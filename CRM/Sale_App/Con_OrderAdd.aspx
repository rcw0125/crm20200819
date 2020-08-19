<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Con_OrderAdd.aspx.cs" Inherits="CRM.Sale_App.Con_OrderAdd" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/My97DatePicker/WdatePicker.js"></script>


    <title>订单</title>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <tr>
                <td style="width: 100px; text-align: right"><span style="color: red">*</span>物料编码
                </td>
                <td>
                    <input id="txtMatCode" type="text" class="input1" disabled="disabled" />
                    <a href="#" onclick="openWeb(0);"><span class="glyphicon glyphicon-search"></span></a>
                </td>

            </tr>
            <tr>
                <td style="text-align: right">物料名称
                </td>
                <td>
                    <input id="txtMatName" type="text" class="input1" disabled="disabled" /><input id="hidOrderType" type="hidden" /><input id="hiddia" type="hidden" />
                </td>

            </tr>

            <tr>
                <td style="text-align: right">钢种
                </td>
                <td>
                    <input id="txtStlGrd" type="text" class="input1" disabled="disabled" />
                </td>

            </tr>
            <tr>
                <td style="text-align: right">规格
                </td>
                <td>
                    <input id="txtSpec" type="text" class="input1" disabled="disabled" />
                </td>

            </tr>
            <tr>
                <td style="text-align: right"><span style="color: red">*</span>协议号
                </td>
                <td>
                    <select id="selectTechProt" class="input1">
                    </select>
                </td>

            </tr>
            <tr>
                <td style="text-align: right"><span style="color: red">*</span>包装要求
                </td>
                <td>
                    <input id="txtPack" type="text" class="input1" disabled="disabled" />
                    <a href="javascript:void(0);" onclick="openWeb(3);"><span class="glyphicon glyphicon-search"></span></a>
                </td>

            </tr>
            <tr>
                <td style="text-align: right">产品用途
                </td>
                <td>
                    <input id="txtUse" type="text" class="input1" />

                </td>

            </tr>
            <tr>
                <td style="text-align: right">计量单位
                </td>
                <td>
                    <asp:DropDownList ID="dropUnit" runat="server" Width="122px">
                        <asp:ListItem>吨</asp:ListItem>
                    </asp:DropDownList>

                </td>

            </tr>
            <tr>
                <td style="text-align: right"><span style="color: red">*</span>维护等级</td>
                <td>
                    <asp:DropDownList ID="dropLEV" runat="server">
                        <asp:ListItem>普通</asp:ListItem>
                        <asp:ListItem>买断</asp:ListItem>
                        <asp:ListItem>重点钢种</asp:ListItem>
                        <asp:ListItem>重点钢种买断</asp:ListItem>
                    </asp:DropDownList>

                </td>

            </tr>
            <tr>
                <td style="text-align: right"><span style="color: red">*</span>数量
                </td>
                <td>
                    <input id="txtNum" type="text" class="numJe" maxlength="9" />

                </td>

            </tr>
            <tr>
                <td style="text-align: right"><span style="color: red">*</span>计划交货日期
                </td>
                <td>
                    <input id="txtDate" type="text" class="Wdate" onclick="WdatePicker({ isShowClear: true, readOnly: true })" />
                </td>

            </tr>
            <tr>
                <td style="text-align: right"><span style="color: red">*</span>需求日期</td>
                <td>
                    <input id="txtNeedDate" type="text" class="Wdate" onclick="WdatePicker({ isShowClear: true, readOnly: true })" runat="server" /></td>

            </tr>

            <tr>
                <td style="text-align: right">收货单位</td>
                <td>
                    <input id="txtAddress" type="text" class="input1" runat="server" disabled="disabled" />
                    <a href="javascript:void(0);" onclick="openWeb(1);"><span class="glyphicon glyphicon-search"></span></a>
                    <input id="hidAddrID" type="hidden" runat="server" />
                </td>

            </tr>
            <tr>
                <td style="text-align: right">开票单位</td>
                <td>
                    <input id="txtOTCompany" type="text" class="input1" runat="server" disabled="disabled" />
                    <a href="#" onclick="openWeb(2);"><span class="glyphicon glyphicon-search"></span></a></td>

            </tr>
            <tr>
                <td style="text-align: center"></td>
                <td>
                    <button class="btn btn-primary" type="button" id="btnSave" onclick="return SavaData();">保存</button>&nbsp;&nbsp; 
                     <button class="btn btn-default" id="btnClose" type="button" onclick="window.close();">关闭</button>
                </td>

            </tr>

        </table>

        <input id="hidOrderNo" type="hidden" runat="server" />
        <input id="hidShipVia" type="hidden" runat="server" />
        <input id="hidConArea" type="hidden" runat="server" />
        <input id="hidCurrType" type="hidden" runat="server" />
        <input id="hidConName" type="hidden" runat="server" />
        <input id="hidconNo" type="hidden" runat="server" />
        <input id="hidCustNO" type="hidden" runat="server" />
        <input id="hidCustName" type="hidden" runat="server" />
        <input id="hidCustLEV" type="hidden" runat="server" />
        <input id="hidCustType" type="hidden" runat="server" />
        <input id="hidSysDate" type="hidden" runat="server" />
        <script src="../Assets/js/jquery-2.0.3.min.js"></script>
        <script src="../Assets/js/common.js"></script>
        <script src="_JsOrder.js"></script>
   
    </form>
</body>
</html>
