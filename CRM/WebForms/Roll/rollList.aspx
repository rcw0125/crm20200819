<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rollList.aspx.cs" Inherits="CRM.WebForms.Roll.rollList" %>

<%@ Register Src="~/WebForms/Roll/rollControl.ascx" TagPrefix="uc1" TagName="rollControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>线材资源申请</title>
    <uc1:rollControl runat="server" ID="rollControl" />
    <script type="text/javascript">
        $(function () {
            selectAll("input.qx1", "input.che1");
        });

        function openWeb() {
            _iframe('../../Common/_CustList.aspx?flag=1', '490', '350', '客户');
        }

        function SetAddr(id, name) {

            $("#txtC_CGC").val(name);
            close();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-bordered table-condensed">
            <tr>
                <td style="width:60px">需求区域</td>
                <td>
                    <asp:DropDownList ID="dropneedarea" runat="server" Width="100%" ></asp:DropDownList></td>
                <td style="width:60px">需求客户</td>
                <td>
                    <input id="txtC_CGC" runat="server" type="text" style="width:85%" readonly="readonly" />
                    <a href="javascript:void(0);" onclick="openWeb();"><span class="glyphicon glyphicon-search"></span></a>
                </td>
                <td style="width:60px">搜索条件</td>
                <td>
                    <asp:TextBox runat="server" placeholder="批次号" ID="txtbatchno" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="钢种" ID="txtstlgrd" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" placeholder="客户信息" ID="txtcustname" Width="100%"></asp:TextBox>
                   </td>
              
               
                <td>
                    <asp:DropDownList ID="dropsalearea" runat="server"></asp:DropDownList></td>
                <td style="width:120px;">
                    <asp:Button ID="btncx" CssClass="btn btn-primary btn-xs" runat="server" Text="查询" OnClick="btncx_Click" />
                    &nbsp;
                    <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="btn  btn-info btn-xs" OnClick="btnAdd_Click"  OnClientClick="return confirm('需求区域选对了吗？')" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td >需求合同</td>
                <td>
                    <asp:TextBox ID="txtNeedCon" runat="server" Width="100%"></asp:TextBox></td>
                <td>&nbsp;</td>
                <td>
                     <asp:TextBox runat="server" placeholder="物料编码" ID="txtmatcode" Width="100%"></asp:TextBox></td>
                <td>
                     <asp:TextBox runat="server" placeholder="规格" ID="txtspec" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtcon" placeholder="合同号" runat="server" Width="100%"></asp:TextBox></td>
               
               
                <td>
                    <asp:DropDownList ID="dropzldj" runat="server" ></asp:DropDownList>&nbsp;
                  
                  </td>
                <td>
                      <asp:TextBox ID="txtrow" placeholder="显示条数" CssClass="numJe" runat="server" Width="60"></asp:TextBox>
                    </td>
            </tr>
        </table>
        <table class="table table-bordered table-condensed" data-toggle="table" data-height="350" style="white-space: nowrap;">
            <thead>
                <tr>
                    <th>
                        <input id="cbxAll" type="checkbox" class="qx1" />全选/序号</th>
                    <th data-sortable="true">区域</th>
                    <th data-sortable="true">批次号</th>
                    <th data-sortable="true">客户信息</th>
                    <th data-sortable="true">合同号</th>
                    
                    <th data-sortable="true">钢种</th>
                    <th data-sortable="true">规格</th>
                    <th data-sortable="true">重量</th>
                    
                    <th data-sortable="true">质量等级</th>
                    <th data-sortable="true">包装</th>
                    <th data-sortable="true">执行标准</th>
                    <th data-sortable="true">物料编码</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input id="cbxselect" runat="server" class="che1" type="checkbox"  value='<%#DataBinder.Eval (Container.DataItem,"C_ID") %>' />
                                <%#Container.ItemIndex+1 %></td>
                            <td>
                                <asp:Literal ID="ltlsalearea" Text='<%#DataBinder.Eval (Container.DataItem,"C_SALE_AREA") %>' runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlbatch" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_BATCH_NO") %>'></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltlC_CUST_NAME" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_CUST_NAME") %>'></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltlC_CON_NO" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"C_CON_NO") %>'></asp:Literal>
                            </td>
                            
                            <td>
                                <asp:Literal ID="ltlstlgrd" Text='<%#DataBinder.Eval (Container.DataItem,"C_STL_GRD") %>' runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlspec" Text='<%#DataBinder.Eval (Container.DataItem,"C_SPEC") %>' runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlN_WGT" runat="server" Text='<%#DataBinder.Eval (Container.DataItem,"N_WGT") %>'></asp:Literal></td>
                          
                            <td>
                                <asp:Literal ID="ltllev" Text='<%#DataBinder.Eval (Container.DataItem,"C_JUDGE_LEV_ZH") %>' runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltlpack" Text='<%#DataBinder.Eval (Container.DataItem,"C_BZYQ") %>' runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltlstdcode" Text='<%#DataBinder.Eval (Container.DataItem,"C_STD_CODE") %>' runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltlmatcode" Text='<%#DataBinder.Eval (Container.DataItem,"C_MAT_CODE") %>' runat="server"></asp:Literal></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
        <asp:Literal ID="ltlID" runat="server" Visible="false"></asp:Literal>
    </form>
</body>
</html>
