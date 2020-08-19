<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatList5.aspx.cs" Inherits="CRM.WebForms.Cust_App.MatList5" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>产品</title>

    <uc1:common runat="server" ID="common" />
    <link href="js/tree_themes/SimpleTree.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {

            var str = getQueryString("custno");
            $("#iframe1").attr("src", "MatList4.aspx?custno=" + str);
        });

        function getQueryString(name) {
            var result = window.location.search.match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));
            if (result == null || result.length < 1) {
                return "";
            }
            return result[1];
        }

        function closeWeb() {

            window.parent.document.getElementById('imgbtnJz').click();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">


        <table class="table table-bordered">
            <tr>
                <td style="width: 200px">
                    <div class="st_tree" id="dv_tree" style="overflow: auto; max-height: 400px;">

                        <asp:Literal ID="ltlmenu" runat="server"></asp:Literal>
                    </div>

                </td>
                <td>
                    <iframe id="iframe1" name="right" style="width: 100%; height: 400px; overflow: scroll" frameborder="no" scrolling="no" target="_self"></iframe>
                </td>
            </tr>
        </table>

        <asp:Literal ID="ltlCustNo" Visible="false" runat="server">0</asp:Literal>

        <script type="text/javascript">

            function getstlgrd(stlgrd) {
                $("#txtstlgrd").val(stlgrd);
                $('#btnSearch').click();
            }

        </script>
    </form>
</body>
</html>
