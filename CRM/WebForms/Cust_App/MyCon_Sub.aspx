<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCon_Sub.aspx.cs" Inherits="CRM.Cust_App.MyCon_Sub" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <title>我的合同</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <uc1:common runat="server" ID="common" />
    <script src="js/jsConSub.js"></script>
</head>
<body>
    <form runat="server">
        <div class="dv_btn">
            <ul>
                <li>
                    <input type="button" value="返回列表" class="btn btn-warning btn-xs" onclick='history.go(-<%= (int)ViewState["back_no"] %>)' />
                </li>
            </ul>
        </div>
        <table class="table table-bordered table-hover table-condensed">
            <thead>
                <tr>

                    <th>合同号</th>
                    <th>合同名称</th>
                    <th>合同数量</th>
                    <th>合同状态</th>
                    <th>合同签署日期</th>
                    <th>计划生效日期</th>
                    <th>计划失效日期</th>
                    <th>货币</th>
                    <th>合同类型</th>
                    <th>发运方式</th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr title="双击查看">

                            <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NO")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"C_CON_NAME")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"N_WGT")%></td>
                            <td><%#NF.Framework.StringFormat.GetOrderState(DataBinder.Eval (Container.DataItem,"N_STATUS"))%>

                                <input id="hidstatus" class="status" type="hidden" value='<%#DataBinder.Eval (Container.DataItem,"N_STATUS")%>' /><input id="hidycon" class="oldcon" type="hidden" value='<%#DataBinder.Eval (Container.DataItem,"C_CON_NO_OLD")%>' />
                            </td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONSING_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONEFFE_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#DataBinder.Eval (Container.DataItem,"D_CONINVALID_DT","{0:yyy-MM-dd}")%></td>
                            <td><%#GetDic(DataBinder.Eval (Container.DataItem,"C_CURRENCYTYPEID"))%></td>
                            <td><%#GetDic(DataBinder.Eval (Container.DataItem,"C_CONTYPEID"))%></td>
                            <td><%#GetDic(DataBinder.Eval (Container.DataItem,"C_TRANSMODEID"))%></td>


                        </tr>
                    </ItemTemplate>

                </asp:Repeater>


            </tbody>
        </table>
        <div class="div_page">
        </div>

        <asp:Literal ID="ltlUserID" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
