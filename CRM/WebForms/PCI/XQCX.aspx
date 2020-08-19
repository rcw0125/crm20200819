<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XQCX.aspx.cs" Inherits="CRM.WebForms.PCI.XQCX" %>

<%@ Register Src="~/WebForms/Cust_App/common.ascx" TagPrefix="uc1" TagName="common" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>轧钢计划排产查询</title>
    <uc1:common runat="server" ID="common" />
    <script src="../JsDate.js"></script>
    <script src="../../Assets/js/jsselect.js"></script>
    <script src="../../Assets/js/bootstrap-datetimepicker.min.js"></script>
    <script src="../../Assets/js/bootstrap-datetimepicker.zh-CN.js"></script>
    <script src="../JsDate.js"></script>
</head>

<body onresize="fromsize();">
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">           
            <tr>
                <td>
                     <asp:TextBox runat="server" placeholder="批次号" ID="txtBatchNo" Width="80px"></asp:TextBox>  
                     <asp:TextBox runat="server" placeholder="订单号" ID="txtOrder" Width="80px"></asp:TextBox>  
                    <asp:TextBox runat="server" placeholder="钢种" ID="txtGrd" Width="80px"></asp:TextBox>
                    <asp:TextBox runat="server" placeholder="规格" ID="txtSpec" Width="80px"></asp:TextBox>    
                     生产开始时间：<input id="Start" runat="server"  type="text" style="width: 80px;" readonly="readonly" class="Wdate" />-
                    <input id="End" runat="server" type="text" style="width: 80px;" readonly="readonly" class="Wdate" />
                    产线
                      <asp:DropDownList ID="ddlChanXian" runat="server" Width="80px">         
                   </asp:DropDownList>
                    <asp:Button ID="btncx3" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx3_Click" />
                </td>
            </tr>
        </table>
        <div style="overflow: auto; width: 100%" id="flow2">

            <table id="table2" class="table table-bordered table-hover table-condensed" style="white-space: nowrap;">
                <thead>
                    <tr>
                        <th>批次号</th>
                         <th>产线</th>
                        <th>物料名称</th>
                        <th>物料编码</th>
                        <th>钢种</th>                      
                        <th>规格</th>
                        <th>自由项1</th>
                        <th>自由项2</th>   
                        <th>包装要求</th>
                        <th>区域</th>                       
                          <th>订单特殊信息</th>  
                          <th>生产开始时间</th> 
                        <th>生产结束时间</th> 
                          <th>需求数量</th>      
                        <th>订单日期</th>
                        <th>需求日期</th>
                        <th>生产量</th>             
                         <th>用途</th>
                         <th>运输方式</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList2" runat="server">
                        <ItemTemplate>
                            <tr>      
                                   <td>
                                    <%#DataBinder.Eval (Container.DataItem,"c_batch_no") %>
                                </td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_LINE_DESC") %></td>
                                  <td>
                                    <%#DataBinder.Eval (Container.DataItem,"C_MAT_NAME") %></td>
                                <td>
                                    <%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %>
                                </td>   
                                <td>
                                    <%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>
                                </td>
                              

                                <td><%#DataBinder.Eval (Container.DataItem,"C_SPEC") %></td>

                                <td><%#DataBinder.Eval (Container.DataItem,"C_FREE_TERM") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_FREE_TERM2") %>                                  
                                </td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_PACK") %></td>
                                  <td><%#DataBinder.Eval (Container.DataItem,"C_AREA") %></td>
                                      <td><%#DataBinder.Eval (Container.DataItem,"c_remark4") %></td>
                                  <td>
                                    <%#DataBinder.Eval (Container.DataItem,"D_PRODUCE_DATE_B") %>
                                </td>
                                <td>
                                    <%#DataBinder.Eval (Container.DataItem,"D_PRODUCE_DATE_E") %>
                                </td>
                                    <td>
                                    <%#DataBinder.Eval (Container.DataItem,"N_WGT") %>
                                </td>
                                <td><%#DataBinder.Eval (Container.DataItem,"D_DT") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"D_NEED_DT") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"N_PROD_WGT") %></td>                                                  
                                <td><%#DataBinder.Eval (Container.DataItem,"C_PRO_USE") %></td>
                                <td><%#DataBinder.Eval (Container.DataItem,"C_TRANSMODE") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                   
            </table>
        </div>        
        <script type="text/javascript">
            $(function () {
                fromsize();
            });
            function fromsize() {
                var _h = document.documentElement.clientHeight
                $("#flow2").height( _h-50);
            }
          
        </script>
    </form>

</body>
</html>
