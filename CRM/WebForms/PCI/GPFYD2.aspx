<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GPFYD2.aspx.cs" Inherits="CRM.WebForms.PCI.GPFYD2" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>钢坯发运</title>
    <uc1:common runat="server" ID="common" />
    
</head>

<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width:400px;">
                    <table class="table table-bordered table-condensed ">
                        <tr>
                            <td>日期</td>
                            <td>
                                <asp:TextBox runat="server" class="form-control Wdate " ID="txtBegTime" Width="110px"></asp:TextBox></td>
                            <td >
                                <asp:TextBox runat="server" class="form-control Wdate " ID="txtEndTime" Width="110px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFYD" placeholder="发运单号" runat="server" Width="110px"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtcph" placeholder="车牌号" runat="server" Width="90px"></asp:TextBox></td>
                            <td >状态</td>
                            <td>
                                <asp:DropDownList ID="ddlIsDo" runat="server">
                                    <asp:ListItem Value="0">未做实绩</asp:ListItem>
                                    <asp:ListItem Value="1">已做实绩</asp:ListItem>
                                    <asp:ListItem Value="2">实绩已回NC</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClientClick="_loading(1)" OnClick="btncx_Click" /></td>
                        </tr>
                    </table>
                          <table class="table table-bordered table-hover table-condensed" data-toggle="table"  data-height="250" style="white-space: nowrap;">
                            <thead>
                                <tr class="info">
                                    <th>合计</th>
                                    <th>车数：<asp:Literal ID="rptcs" runat="server"></asp:Literal></th>
                                    <th>重量：<asp:Literal ID="rptHjWgt" runat="server"></asp:Literal></th>
                                    <th>数量：<asp:Literal ID="rptHjCount" runat="server"></asp:Literal></th>
                                    <th>净重：<asp:Literal ID="rptHjJz" runat="server"></asp:Literal></th>
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
                                    <th data-sortable="true">发运单号</th>
                                    <th data-sortable="true">车牌号</th>
                                    <th data-sortable="true">钢种</th>
                                    <th data-sortable="true">支数</th>
                                    <th data-sortable="true">重量</th>
                                    <th data-sortable="true">净重</th>
                                    <th data-sortable="true">实绩数量</th>
                                    <th data-sortable="true">状态</th>
                                    <th data-sortable="true">执行标准</th>
                                    <th data-sortable="true">仓库</th>
                                    <th data-sortable="true">物料号</th>
                                    <th data-sortable="true">规格</th>
                                    <th data-sortable="true">质量等级</th>
                                    <th data-sortable="true">自由项1</th>
                                    <th data-sortable="true">自由项2</th>
                                    <th data-sortable="true">创建时间</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="rptlinkCid" runat="server" CommandArgument='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' CommandName="xc"><%#DataBinder.Eval (Container.DataItem,"C_ID") %></asp:LinkButton>
                                                <asp:Literal ID="rptLstCID" Text='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' runat="server" Visible="false"></asp:Literal>
                                                <asp:Literal ID="rptLstITEMID" Text='<%#DataBinder.Eval (Container.DataItem,"ITEMID") %>' runat="server" Visible="false"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="rptlstcph" Text='<%#DataBinder.Eval (Container.DataItem,"C_LIC_PLA_NO") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="rptlstGrd" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="rptlstNum" Text='<%#DataBinder.Eval (Container.DataItem,"N_NUM") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="rptlstNWgt" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="rptlstJwgt" Text='<%#DataBinder.Eval (Container.DataItem,"N_JWGT") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="rptlstSjsj" Text='<%#DataBinder.Eval (Container.DataItem,"SJSL") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="Literal2" Text='<%#DataBinder.Eval (Container.DataItem,"C_STATUS") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="rptlstStdCode" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="rptlstStock" Text='<%#DataBinder.Eval (Container.DataItem,"C_SEND_STOCK_CODE") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="rptlstmat" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="rptLstSpec" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="rptLstZLDJ" Text='<%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="rptzyx1" Text='<%#DataBinder.Eval (Container.DataItem,"C_FREE_TERM") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="rptzyx2" Text='<%#DataBinder.Eval (Container.DataItem,"C_FREE_TERM2") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="rptlstDt" Text='<%#DataBinder.Eval (Container.DataItem,"D_CREATE_DT") %>' runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>

                        </table>
                </td>
                <td>
                    <table class="table table-bordered table-condensed">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtLH" placeholder="炉号" runat="server" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtKPH" placeholder="开坯号" runat="server"></asp:TextBox></td>
                            <td >
                                <asp:Button ID="btncxRight" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClientClick="_loading(1)" OnClick="btncxRight_Click" /></td>
                            <td>发运时间 </td>
                            <td >
                                <asp:TextBox runat="server" class="form-control Wdate" ID="txtFYSJ"></asp:TextBox></td>
                            <td >
                                <asp:Button ID="btnFSSJ" CssClass="btn btn-danger btn-xs" runat="server" Text="发送实绩" OnClientClick="_loading(1)" OnClick="btnFSSJ_Click1" />
                            </td>
                        </tr>
                    </table>
                        <table class="table table-bordered table-hover table-condensed"  data-toggle="table" data-height="250" style="white-space: nowrap;">
                            <thead>
                                <tr class="info">
                                    <th>当前车牌号：</th>
                                    <th>
                                        <asp:Literal ID="rptcph" runat="server"></asp:Literal></th>
                                    <th>合计</th>
                                    <th>
                                        <asp:Literal ID="rptRigthHjZS" runat="server"></asp:Literal>
                                    </th>
                                    <th>
                                        <asp:Literal ID="rptRigthHjZL" runat="server"></asp:Literal>
                                    </th>
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
                                    <th></th>
                                    <th></th>
                                </tr>
                                <tr>
                                    <th data-sortable="true">选择</th>
                                    <th data-sortable="true">开坯号</th>
                                    <th data-sortable="true">炉号</th>
                                    <th data-sortable="true">支数</th>
                                    <th data-sortable="true">重量</th>
                                    <th data-sortable="true">实绩数量</th>
                                    <th data-sortable="true">物料编码</th>
                                    <th data-sortable="true">物料名称</th>
                                    <th data-sortable="true">钢种</th>
                                    <th data-sortable="true">执行标准</th>
                                    <th data-sortable="true">断面</th>
                                    <th data-sortable="true">长度</th>
                                    <th data-sortable="true">质量等级</th>
                                    <th data-sortable="true">自由项1</th>
                                    <th data-sortable="true">自由项2</th>
                                    <th data-sortable="true">仓库编码</th>
                                    <th data-sortable="true">仓库区域编码</th>
                                    <th data-sortable="true">库位编码</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptListRight" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <input id="cbxselect" class="che1" name="cbx" runat="server" type="checkbox" />
                                            </td>
                                            <td>
                                                <asp:Literal ID="lstBatchNo" Text='<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lstStove" Text='<%#DataBinder.Eval (Container.DataItem,"C_STOVE") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lstQua" Text='<%#DataBinder.Eval (Container.DataItem,"N_QUA") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lstWgt" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="lstSNum" Text='<%#DataBinder.Eval (Container.DataItem,"N_SNUM") %>' CssClass="numJe" Width="50" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lstMatCode" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lstMatName" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME") %>' runat="server"></asp:Literal>
                                            </td>

                                            <td>
                                                <asp:Literal ID="lstGrd" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lstStdCode" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lstSpec" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lstLen" Text='<%#DataBinder.Eval (Container.DataItem,"N_LEN") %>' runat="server"></asp:Literal>
                                            </td>

                                            <td>
                                                <asp:Literal ID="lstLevZh" Text='<%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lstzyx1" Text='<%#DataBinder.Eval (Container.DataItem,"C_ZYX1") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lstzyx2" Text='<%#DataBinder.Eval (Container.DataItem,"C_ZYX2") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lstSlabCode" Text='<%#DataBinder.Eval (Container.DataItem,"C_SLABWH_CODE") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lstAreaCode" Text='<%#DataBinder.Eval (Container.DataItem,"C_SLABWH_AREA_CODE") %>' runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="lstLocCode" Text='<%#DataBinder.Eval (Container.DataItem,"C_SLABWH_LOC_CODE") %>' runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                   
                </td>
            </tr>
          
            <tr>
                <td colspan="2">
                    
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    <asp:TextBox runat="server" placeholder="发运单号" ID="txtFYDH" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtcph2" placeholder="车牌号" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtck" placeholder="仓库" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtLH2" placeholder="炉号" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtKPH2" placeholder="开坯号" runat="server" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtGZ" placeholder="钢种" runat="server" Width="100%"></asp:TextBox></td>
                <td>状态</td>
                <td>
                    <asp:DropDownList ID="ddlIsDo1" runat="server">
                        <asp:ListItem Value="0">未做实绩</asp:ListItem>
                        <asp:ListItem Value="1">已做实绩</asp:ListItem>
                        <asp:ListItem Value="2">实绩已回NC</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:Button ID="btncx3" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClientClick="_loading(1)" OnClick="btncx3_Click" />
                    &nbsp;
                    <asp:Button ID="Button2" CssClass="btn btn-danger btn-xs" runat="server" Text="取消标记" OnClientClick="_loading(1)" OnClick="Button2_Click" />
                    &nbsp;
                     <asp:Button ID="Button1" CssClass="btn btn-primary btn-xs" runat="server" Text="确认" OnClientClick="_loading(1)" OnClick="Button1_Click" />
                    &nbsp;
                      <asp:Button ID="Button4" CssClass="btn btn-danger btn-xs" runat="server" Text="发送NC" OnClientClick="_loading(1)" OnClick="Button4_Click"  />
                </td>
            </tr>
        </table>
     
            <table class="table table-bordered table-hover table-condensed" data-toggle="table"  data-height="250" >
                <thead>
                    <tr class="info">
                        <th>合计</th>
                        <th>支数：<asp:Literal ID="rpt2HjZS" runat="server"></asp:Literal></th>
                        <th>重量：<asp:Literal ID="rpt2HjZL" runat="server"></asp:Literal></th>
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
                        <th></th>
                        <th></th>
                    </tr>
                    <tr>
                        <th data-sortable="true">选择</th>
                        <th data-sortable="true">状态</th>
                        <th data-sortable="true">发运单号</th>
                        <th data-sortable="true">车牌号</th>
                        <th data-sortable="true">炉号</th>
                        <th data-sortable="true">开坯号</th>
                        <th data-sortable="true">钢种</th>
                        <th data-sortable="true">执行标准</th>
                        <th data-sortable="true">断面</th>
                        <th data-sortable="true">长度</th>
                        <th data-sortable="true">支数</th>
                        <th data-sortable="true">重量</th>
                        <th data-sortable="true">仓库编码</th>
                        <th data-sortable="true">仓库区域编码</th>
                        <th data-sortable="true">库位编码</th>
                        <th data-sortable="true">质量等级</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList2" runat="server" OnItemDataBound="rptList2_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <%--       <td>
                                    <input id="rdoselect" type="radio" name="group" runat="server" value='<%#DataBinder.Eval (Container.DataItem,"C_FYDH") %>' onclick="selectSingleRadio(this, 'group');" />
                                </td>--%>
                                <td>
                                    <input id="cbsj" class="che1" name="cbx" runat="server" type="checkbox" /><asp:Literal ID="lstfyid" Text='<%#DataBinder.Eval (Container.DataItem,"C_FYID") %>' runat="server" Visible="false"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lstStatus" Text='<%#DataBinder.Eval (Container.DataItem,"C_STATUS") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lstfydh" Text='<%#DataBinder.Eval (Container.DataItem,"C_FYDH") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lstcph" Text='<%#DataBinder.Eval (Container.DataItem,"C_LIC_PLA_NO") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lststove" Text='<%#DataBinder.Eval (Container.DataItem,"C_STOVE") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lstbatch" Text='<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lstgrd" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>' runat="server"></asp:Literal>

                                </td>
                                <td>
                                    <asp:Literal ID="lststd" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %>' runat="server"></asp:Literal>
                                </td>

                                <td>
                                    <asp:Literal ID="lstspec" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lstlen" Text='<%#DataBinder.Eval (Container.DataItem,"N_LEN") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lstqua" Text='<%#DataBinder.Eval (Container.DataItem,"N_QUA") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lstwgt" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lstck" Text='<%#DataBinder.Eval (Container.DataItem,"C_SLABWH_CODE") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lstqy" Text='<%#DataBinder.Eval (Container.DataItem,"C_SLABWH_AREA_CODE") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lstkw" Text='<%#DataBinder.Eval (Container.DataItem,"C_SLABWH_LOC_CODE") %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lstzldj" Text='<%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %>' runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>

            </table>

                </td>
            </tr>
        </table>

       
        <asp:Literal ID="ltlempid" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="hidCID" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="hidNum" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="hidJwgt" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="hidSJSL" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="lblmat" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="lblCStdCode" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="lblStockCode" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="lblZLDJ" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="lblzyx1" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="lblzyx2" runat="server" Visible="false"></asp:Literal>
        <script type="text/javascript">
            $(function () {
              
                $("#txtBegTime").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
                $("#txtEndTime").datetimepicker({
                    format: 'yyyy-mm-dd',
                    minView: 'month',
                    language: 'zh-CN',
                    autoclose: true,
                    todayBtn: true
                });
                $("#txtFYSJ").datetimepicker({
                    format: 'yyyy-mm-dd hh:ii:ss',
                    language: 'zh-CN',
                    minView: 0,
                    minuteStep: 1,
                    autoclose: true,
                    todayBtn: true
                });
            });
           
            function selectSingleRadio(rbtn1, GroupName) {
                $("input[type=radio]").each(function (i) {
                    if (this.name.substring(this.name.length - GroupName.length) == GroupName) {
                        this.checked = false;
                    }
                })
                rbtn1.checked = true;
            }

        </script>
        <asp:Literal ID="lblcph" runat="server" Visible="False"></asp:Literal>
    </form>
</body>
</html>
