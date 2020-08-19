<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zzs_file.aspx.cs" Inherits="CRM.WebForms.Report.zzs_file" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>产品质量证明附件</title>
    <uc1:ReptControl runat="server" ID="ReptControl" />

    <script type="text/javascript">

          $(function () {

            $("#Text1").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true

            }).on("changeDate", function (ev) {
                $("#txtjssj").datetimepicker('setStartDate', $("#Text1").val())
            });
            $("#txtjssj").datetimepicker({
                format: 'yyyy-mm-dd',
                minView: 'month',
                language: 'zh-CN',
                autoclose: true
            }).on("changeDate", function (ev) {
                $("#Text1").datetimepicker('setEndDate', $("#txtjssj").val())
            });
        });

        function checkfile() {
            if ($.trim($("#file1").val()) == "") {
                alert("请选择上传文件");
                return false;
            }
            return true;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox ID="txtbatch" runat="server" placeholder="批号" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtstove" runat="server" placeholder="炉号" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtstlgrd" runat="server" placeholder="钢种" Width="100%"></asp:TextBox></td>

                <td style="width: 80px">生产日期</td>
                <td style="width: 100px;">
                   <input id="Text1" type="text" runat="server" style="cursor: pointer" class="form-control Wdate" />
                    </td>
                <td style="width: 100px;">
                    <input id="txtjssj" type="text" runat="server" style="cursor: pointer" class="form-control Wdate" />
                  </td>
                <td style="width: 100px;">
                    <asp:Button ID="btnxc" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btnxc_Click" />
                </td>
                <td style="width: 200px;">
                    <input class="fileInp" type="file" name="file" runat="server" id="file1" /></td>
                <td>
                    <asp:Button ID="Button2" CssClass="btn btn-primary btn-xs" runat="server" Text="上传文档" OnClick="Button2_Click" OnClientClick="return checkfile();" /></td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed" data-toggle="table" data-height="450" id="table" style="white-space: nowrap;">
            <thead>

                <tr>
                    <th data-sortable="true">选择框</th>
                    <th data-sortable="true">操作</th>
                    <th data-sortable="true">物料名称</th>
                    <th data-sortable="true">批次号</th>
                    <th data-sortable="true">炉号</th>
                    <th data-sortable="true">执行标准</th>
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">生产日期</th>
                    <th data-sortable="true">最后操作人</th>
                    <th data-sortable="true">最后操作时间</th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>

                                <input id="cbxID" style="width: 15px;" class="che1" runat="server" type="checkbox" value="" />
                                <%#Container.ItemIndex+1 %>

                            </td>
                            <td><%#GetPrint(DataBinder.Eval (Container.DataItem,"C_BATCH_NO"),DataBinder.Eval (Container.DataItem,"C_STOVE"),DataBinder.Eval (Container.DataItem,"C_STL_GRD"),DataBinder.Eval (Container.DataItem,"C_SPEC"),DataBinder.Eval (Container.DataItem,"C_PDF_PATCH")) %>
                                
                            </td>
                            <td><%# DataBinder.Eval (Container.DataItem,"C_MAT_DESC") %></td>

                            <td>
                                <asp:Literal ID="ltlC_BATCH_NO" Text='<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %>' runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltlC_STOVE" Text='<%#DataBinder.Eval (Container.DataItem,"C_STOVE") %>' runat="server"></asp:Literal>

                            </td>
                            <td>
                                <asp:Literal ID="ltlC_STD_CODE" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %>' runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltlC_STL_GRD" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>' runat="server"></asp:Literal>

                            </td>
                            <td>
                                <asp:Literal ID="ltlC_SPEC" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC") %>' runat="server"></asp:Literal>

                            </td>
                            <td>
                                <%#DataBinder.Eval (Container.DataItem,"D_PRODUCE_DATE") %>
                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_EMP_ID") %>  </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_QZRQ") %>  </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
        <asp:Literal ID="ltlempName" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
