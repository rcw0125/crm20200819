<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcAdd.aspx.cs" Inherits="CRM.WebForms.Report.ProcAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>产品添加</title>
    <script src="js/jsStye.js"></script>
    <script type="text/javascript">
        //下面用于图片上传预览功能
        function setImagePreview(avalue) {
            var docObj = document.getElementById("File1");

            var imgObjPreview = document.getElementById("preview");
            if (docObj.files && docObj.files[0]) {

                //火狐下，直接设img属性
                imgObjPreview.style.display = 'block';
                imgObjPreview.style.width = '120px';
                imgObjPreview.style.height = '120px';
                //火狐7以上版本不能用上面的getAsDataURL()方式获取，需要一下方式
                imgObjPreview.src = window.URL.createObjectURL(docObj.files[0]);
            }
            else {
                //IE下，使用滤镜
                docObj.select();
                var imgSrc = document.selection.createRange().text;
                var localImagId = document.getElementById("localImag");
                //必须设置初始大小
                localImagId.style.width = "120px";
                localImagId.style.height = "120px";
                //图片异常的捕捉，防止用户修改后缀来伪造图片
                try {
                    localImagId.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale)";
                    localImagId.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = imgSrc;
                }
                catch (e) {
                    alert("您上传的图片格式不正确，请重新选择!");
                    return false;
                }
                imgObjPreview.style.display = 'none';
                document.selection.empty();
            }
            return true;
        }

        function checkinfo() {
            if ($.trim($("#txtstlgrd").val()) == '') {
                alert('钢种不能为空');
                return false;
            }
            if ($.trim($("#txtspec").val()) == '') {
                alert('规格不能为空');
                return false;
            }
            if ($.trim($("#txtstdcode").val()) == '') {
                alert('执行标准不能为空');
                return false;
            }
            if ($.trim($("#txtdesc").val()) == '') {
                alert('使用范围不能为空');
                return false;
            }
            if ($.trim($("#txtremark").val()) == '') {
                alert('产品介绍不能为空');
                return false;
            }
            var fileSize1 = document.getElementById('File1').files[0]; //获得文件大小；
            if (fileSize1 != undefined) {
                if (fileSize1.size > 2097152)
                    return false;
            }

            return true;

        }
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-hover table-condensed">
            <tr>
                <td style="width: 100px;">产品类型</td>
                <td>
                    <asp:DropDownList ID="dropproctype" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>钢种</td>
                <td>
                    <input id="txtstlgrd" type="text" style="width: 100%" runat="server" /></td>
            </tr>
            <tr>
                <td>规格</td>
                <td>
                    <input id="txtspec" type="text" style="width: 100%" runat="server" /></td>
            </tr>
            <tr>
                <td>执行标准</td>
                <td>
                    <input id="txtstdcode" type="text" style="width: 100%" runat="server" /></td>
            </tr>
            <tr>
                <td>使用范围</td>
                <td>
                    <input id="txtdesc" type="text" style="width: 100%" runat="server" /></td>
            </tr>
            <tr>
                <td>介绍</td>
                <td>
                    <textarea id="txtremark" style="width: 100%; height: 50px;" runat="server"></textarea></td>
            </tr>
            <tr>
                <td class="auto-style1">产品图片</td>
                <td class="auto-style1">
                    <input id="File1" type="file" onchange="javascript:setImagePreview();" runat="server" /></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <div id="localImag">

                        <img id="preview" src="../../Assets/images/login_img/login_banner03.jpg" style="display: block; width: 120px; height: 120px;" runat="server">
                    </div>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSave" CssClass="btn btn-primary btn-xs" runat="server" Text="保存" OnClientClick="return checkinfo();" OnClick="btnSave_Click" />

                </td>
            </tr>
        </table>
        <input id="hid" runat="server" type="hidden" />
         <input id="hidimg" runat="server" type="hidden" />
    </form>
</body>
</html>
