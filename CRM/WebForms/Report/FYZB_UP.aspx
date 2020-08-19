<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FYZB_UP.aspx.cs" Inherits="CRM.WebForms.Report.FYZB_UP" %>

<%@ Register Src="~/WebForms/Report/ReptControl.ascx" TagPrefix="uc1" TagName="ReptControl" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <uc1:ReptControl runat="server" ID="ReptControl" />
    <title>发运指标上传</title>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">

                    <a data-toggle="collapse" data-parent="#accordion" style="width: 100%; display: block; text-decoration: none;"
                        href="#collapseOne"><span class="glyphicon glyphicon-align-justify" style="margin-right: 15px;"></span>发运指标Execl文件导入
                    </a>
                </div>
                <div id="collapseOne" class="panel-collapse collapse">
                    <table class="table table-bordered">
                        <tr>
                            <td style="width: 80px;">选择文件</td>
                            <td style="width: 250px;">
                                <input class="fileInp" onchange="fileUpLoad(this);" type="file" name="file" runat="server" id="file1" />
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="上传" CssClass="btn btn-primary btn-xs" OnClick="Button1_Click" OnClientClick="_loading(1);" />
                                &nbsp;<asp:Button ID="Button2" CssClass="btn btn-success btn-xs" runat="server" Text="发运指标数据导入" OnClick="Button2_Click" OnClientClick="_loading(1);" />

                                &nbsp;
                    <a href="../../Uploads/tmp001.rar" class="btn btn-info btn-xs">模板下载</a>

                            </td>
                        </tr>
                    </table>
                    <table class="table table-bordered table-hover table-condensed"
                        data-toggle="table"
                        data-height="450" style="white-space: nowrap;" id="table">
                        <thead>
                            <tr>
                                <th data-sortable="true">日期</th>
                                <th data-sortable="true">精特钢销售一部</th>
                                <th data-sortable="true">精特钢销售二部</th>
                                <th data-sortable="true">轴承钢销售部</th>
                                <th data-sortable="true">弹簧钢销售部</th>
                                <th data-sortable="true">纯铁销售部</th>
                                <th data-sortable="true">国际贸易部</th>
                                <th data-sortable="true">副产品销售部</th>
                                <th data-sortable="true">北方一区</th>
                                <th data-sortable="true">北方二区</th>
                                <th data-sortable="true">北方普碳区域</th>
                                <th data-sortable="true">硬线区域</th>
                                <th data-sortable="true">上海区域</th>
                                <th data-sortable="true">杭州区域</th>
                                <th data-sortable="true">宁波区域</th>
                                <th data-sortable="true">重庆区域</th>
                                <th data-sortable="true">广州区域</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="ltlDT" Text='<%#DataBinder.Eval(Container.DataItem, "日期")%>' runat="server"></asp:Literal></td>
                                        <td>
                                            <asp:Literal ID="ltlJT1_DETP" Text='<%#DataBinder.Eval(Container.DataItem, "精特钢销售一部")%>' runat="server"></asp:Literal></td>
                                        <td>
                                            <asp:Literal ID="ltlJT2_DEPT" Text='<%#DataBinder.Eval(Container.DataItem, "精特钢销售二部")%>' runat="server"></asp:Literal></td>
                                        <td>
                                            <asp:Literal ID="ltlZCG_DEPT" Text='<%#DataBinder.Eval(Container.DataItem, "轴承钢销售部")%>' runat="server"></asp:Literal></td>
                                        <td>
                                            <asp:Literal ID="ltlTHG_DEPT" Text='<%#DataBinder.Eval(Container.DataItem, "弹簧钢销售部")%>' runat="server"></asp:Literal></td>
                                        <td>
                                            <asp:Literal ID="ltl_CT_DEPT" Text='<%#DataBinder.Eval(Container.DataItem, "纯铁销售部")%>' runat="server"></asp:Literal></th>
				
                                 <td>
                                     <asp:Literal ID="ltl_CK_DEPT" Text='<%#DataBinder.Eval(Container.DataItem, "国际贸易部")%>' runat="server"></asp:Literal></td>
                                            <td>
                                                <asp:Literal ID="ltl_FCP_DEPT" Text='<%#DataBinder.Eval(Container.DataItem, "副产品销售部")%>' runat="server"></asp:Literal></td>
                                            <td>
                                                <asp:Literal ID="ltl_BFONE_DEPT" Text='<%#DataBinder.Eval(Container.DataItem, "北方一区")%>' runat="server"></asp:Literal></td>
                                            <td>
                                                <asp:Literal ID="ltl_BFTWO_DEPT" Text='<%#DataBinder.Eval(Container.DataItem, "北方二区")%>' runat="server"></asp:Literal></td>
                                            <td>
                                                <asp:Literal ID="ltl_BFPT_DEPT" Text='<%#DataBinder.Eval(Container.DataItem, "北方普碳区域")%>' runat="server"></asp:Literal></td>
                                            <td>
                                                <asp:Literal ID="ltl_YX_DEPT" Text='<%#DataBinder.Eval(Container.DataItem, "硬线区域")%>' runat="server"></asp:Literal></td>
                                            <td>
                                                <asp:Literal ID="ltl_SH_DEPT" Text='<%#DataBinder.Eval(Container.DataItem, "上海区域")%>' runat="server"></asp:Literal></td>
                                            <td>
                                                <asp:Literal ID="ltl_HZ_DEPT" Text='<%#DataBinder.Eval(Container.DataItem, "杭州区域")%>' runat="server"></asp:Literal></td>
                                            <td>
                                                <asp:Literal ID="ltl_NB_DEPT" Text='<%#DataBinder.Eval(Container.DataItem, "宁波区域")%>' runat="server"></asp:Literal></td>
                                            <td>
                                                <asp:Literal ID="ltl_CQ_DEPT" Text='<%#DataBinder.Eval(Container.DataItem, "重庆区域")%>' runat="server"></asp:Literal></td>
                                            <td>
                                                <asp:Literal ID="ltl_GZ_DEPT" Text='<%#DataBinder.Eval(Container.DataItem, "广州区域")%>' runat="server"></asp:Literal></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                        </tbody>
                    </table>

                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <a data-toggle="collapse" data-parent="#accordion" style="width: 100%; display: block; text-decoration: none;"
                        href="#collapseTwo"><span class="glyphicon glyphicon-align-justify" style="margin-right: 15px;"></span>每日发运指标管理
                    </a>
                </div>
                <div id="collapseTwo" class="panel-collapse collapse">


                    <table class="table table-bordered table-condensed">
                        <tr>

                            <td style="width: 50px;">日期</td>
                            <td style="width: 150px;">
                                <input id="txtDate" type="text" style="width: 110px;" class=" form-control Wdate" runat="server" /></td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>

                                   
                                <asp:Button ID="btncx" runat="server" CssClass="btn btn-primary btn-xs" Text="查询" OnClick="btncx_Click" />
                                &nbsp;
                                 <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary btn-xs" Text="保存" OnClick="btnsave_Click" />
                                 </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>

                        </tr>
                    </table>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div id="flow1" style="overflow: auto; max-height: 400px;">
                                <table class="table table-bordered table-condensed table-hover">
                                    <thead>

                                        <tr>
                                            <th>
                                                <input id="cbxall" class="qx1" type="checkbox" />行号</th>
                                            <th>区域</th>
                                            <th>发运指标</th>
                                            <th>时间</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptList2" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <input id="cbxID" class="che1" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_ID")%>' type="checkbox" />
                                                        <%#Container.ItemIndex+1 %>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="ltlc_dept" Text='<%#DataBinder.Eval (Container.DataItem,"C_DEPT")%>' runat="server"></asp:Literal></td>
                                                    <td>
                                                        <asp:TextBox ID="txtwgt" CssClass="numJe" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT")%>' runat="server"></asp:TextBox>
                                                    </td>
                                                    <td><%#DataBinder.Eval (Container.DataItem,"D_DAY","{0:yyy-MM-dd}")%></td>


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

        <script type="text/javascript">

            $(function () {

                //全选
                selectAll("input.qx1", "input.che1");
                $("#txtDate").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true,//显示今日按钮
                    startDate: new Date()
                });
            });
        </script>
    </form>
</body>
</html>
