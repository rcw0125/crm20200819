<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Con_OrderEdit.aspx.cs" Inherits="CRM.Sale_App.Con_OrderEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>订单维护</title>
    <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/common.css" rel="stylesheet" />
    <script src="../Assets/js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Assets/js/jquery-2.0.3.min.js"></script>
    <script src="../Assets/js/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered">
            <tr>
                <td style="width: 100px; text-align: right">订单号</td>
                <td>
                   <input id="txtOrderNo" type="text" class="input1" disabled="disabled"  runat="server" />

                </td>

            </tr>
            <tr>
                <td style="width: 100px; text-align: right">物料编码
                </td>
                <td>
                    <input id="txtMatCode" type="text" class="input1" disabled="disabled" runat="server" />

                </td>

            </tr>
            <tr>
                <td style="text-align: right">物料名称
                </td>
                <td>
                    <input id="txtMatName" type="text" class="input1" disabled="disabled" runat="server" />
                </td>

            </tr>

            <tr>
                <td style="text-align: right">钢种
                </td>
                <td>
                    <input id="txtStlGrd" type="text" class="input1" disabled="disabled" runat="server" />
                </td>

            </tr>
            <tr>
                <td style="text-align: right">规格
                </td>
                <td>
                    <input id="txtSpec" type="text" class="input1" disabled="disabled" runat="server" />
                </td>

            </tr>
            <tr>
                <td style="text-align: right">协议号
                </td>
                <td>
                    <input id="txTechProt" type="text" class="input1" disabled="disabled" runat="server" />
                </td>

            </tr>
            <tr>
                <td style="text-align: right">执行标准</td>
                <td>
                    <input id="txtstdcode" type="text" class="input1" disabled="disabled" runat="server" /></td>

            </tr>
            <tr>
                <td style="text-align: right">包装要求
                </td>
                <td>
                    <input id="txtPack" type="text" class="input1" disabled="disabled" runat="server" />

                </td>

            </tr>
            <tr>
                <td style="text-align: right">产品用途
                </td>
                <td>
                    <input id="txtUse" type="text" class="input1" disabled="disabled" runat="server" />

                </td>

            </tr>
            <tr>
                <td style="text-align: right">计量单位
                </td>
                <td>
                    <input id="txtUnit" type="text" class="input1" disabled="disabled" runat="server" />
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
                    <input id="txtNum" type="text" class="numJe" maxlength="9" runat="server" /></td>

            </tr>
            <tr>
                <td style="text-align: right"><span style="color: red">*</span>计划交货日期
                </td>
                <td>
                    <input id="txtDate" type="text" class="Wdate" onclick="WdatePicker({ isShowClear: true, readOnly: true })" runat="server" />
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
                   
                </td>

            </tr>
            <tr>
                <td style="text-align: right">开票单位</td>
                <td>
                    <input id="txtOTCompany" type="text" class="input1" runat="server" disabled="disabled"  />
                    

            </tr>
            <tr>
                <td style="text-align: center"></td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                   &nbsp;&nbsp; 
                     <button class="btn btn-default" id="btnClose" type="button" onclick="window.close();">关闭</button>
                </td>

            </tr>

        </table>

        <input id="hidSysDate" type="hidden" runat="server" />
        <script src="../Assets/js/jquery-2.0.3.min.js"></script>
        <script src="../Assets/js/common.js"></script>
        <script type="text/javascript">

            
    $("#txtNum").change(function () {
      
        var stdcode =$("#txtstdcode").val();
        var num = $.trim($("#txtNum").val());
        var stlgrd = $("#txtStlGrd").val();
        var spec = $("#txtSpec").val();

        if (matcode == '') {
            alert("请先选择物料编码");
            return false;
        }
        if (protNo == '') {

            alert("请选择协议号");
            return false;
        }
        if (num <= 0) {
            alert("请输入有效数量")
            return false;
        }

        $.ajax({
            type: "Post",
            url: "Con_OrderEdit.aspx/GetTime",
            data: "{'stlgrd':'" + stlgrd + "','spec':'" + spec + "','stdcode':'" + stdcode + "','num':'" + num + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                debugger;
                if (data.d != '') {
                    var time = data.d;
                    $("#txtDate").val(time);
                    $("#hidSysDate").val(time);
                }
            },
            error: function (err) {
                alert(err);
            }
        });

    });
});
        </script>


    </form>
</body>
</html>
