<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qualCert.aspx.cs" Inherits="CRM.Common.qualCert" %>

<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<meta name="viewport" content="maximum-scale=1.0,minimum-scale=1.0,user-scalable=0,width=device-width,initial-scale=1.0"/>
		<meta name="format-detection" content="telephone=no,email=no,date=no,address=no">
		<title>邢台钢铁有限责任公司</title>
		<style>
			html, body {
				width: 100%;
				background: #F4F4F4;
			}
			html, body, div {
				margin: 0;
				border: 0;
				padding: 0;
				font-style: normal;
			}
			table {
				border-collapse: collapse;
				border-spacing: 0;
			}
			td, th {
				padding: 0;
			}
			.x_average {
				display: -webkit-box;
				display: -webkit-flex;
				display: flex;
			}
			.average {
				-webkit-box-flex: 1;
				-webkit-flex: 1;
				flex: 1;
			}
			.newFirst {
				position: relative;
			}
			.newTitle {
				text-align: center;
				padding-top: 10px;
				font-size: 23px;
			}
			.sanrenIcon {
				position: absolute;
				top: 10px;
				left: 5px;
			}
			/*主要信息*/
			.firstblock {
				color: #999999;
				margin: 0 5px;
				background: #FFFFFF;
				border-radius: 6px;
				border: 1px solid #c8c7cc;
				font-size: 14px;
			}
			.first_he {
				padding: 0 10px;
				height: 40px;
				line-height: 40px;
				border-bottom: 1px solid #c8c7cc;
			}
			.first_main {
				padding: 0 10px;
				line-height: 25px;
				border-bottom: 1px solid #c8c7cc;
			}
			.first_fo {
				border-radius: 6px;
				padding: 10px;
				color: #999;
				text-align: right;
				background: #f4f4f4;
			}
			/*表格*/
			.table_box {
				width: 100%;
				text-align: center;
				overflow: hidden;
				background: #FFFFFF;
			}
			.table_box_he {
				width: 100%;
				font-size: 15px;
				height: 30px;
				line-height: 30px;
			}
			.table_box > table tbody thead tr {
				width: 100%;
			}
			.table_tbody_box {
				width: 100%;
			}
			.table_box > td {
				line-height: 25px;
				height: 25px;
			}
			.table_Bg_hui {
				/*color: #4D4D4D;*/
				background: #f4f4f4;
			}
			.table_Bg_Qianlan {
				color: #FFFFFF;
				background: #00B2EE;
			}
			.title_ch {
				color: #000000;
				padding-top: 3px;
				font-size: 14px;
			}
			.title_en {
				color: #4D4D4D;
				padding-bottom: 3px;
				font-size: 14px;
				line-height: 20px;
			}
			.table_box > table {
				border: 1px solid #eeeeee;
			}
			.table_box > table {
				border: 1px solid #eeeeee;
			}
			.table_box > table thead tr th {
				border-right: 1px solid #eeeeee;
			}
			.table_box > table tbody tr td {
				border-right: 1px solid #eeeeee;
				border-bottom: 1px solid #eeeeee;
			}
			.tableTdMore {
				padding: 0px 5px;
				line-height: 25px;
				word-break: break-all;
			}
		</style>
	</head>
	<body>
		<div id="wrapMain">
			<div class="newFirst">
				<div class="newTitle">
					<div>
						简要信息
					</div>
					<div>
						BRIEF INFORMATION
					</div>
				</div>
				<div class="sanrenIcon">
					<img src="image/logo.png" style="height: 28px;"/>
				</div>
			</div>
				<div style="height:5px; width: 100%;"></div>
			<div class="firstblock">
				<div class="first_he x_average">
					<div>
						证书号(Certificate No.):
					</div>
					<div style="color: #00B2EE;">
                        <asp:Literal ID="ltlzsh" runat="server"></asp:Literal>
					</div>
				</div>
				<div class="first_main">
					<div class="x_average">
						<div >
							车号(Train No.)：
						</div>
						<div style="color: #ff9966;">
                            <asp:Literal ID="ltlch" runat="server"></asp:Literal>
						</div>
					</div>
					<div class="x_average">
						<div >
							盘数合计(Total Qty)：
						</div>
						<div style="color: #ff9966;">
                            <asp:Literal ID="ltlqua" runat="server"></asp:Literal>件
						</div>
					</div>
					<div class="x_average">
						<div>
							重量合计(Total Weight)：
						</div>
						<div style="color: #ff9966;">
                            <asp:Literal ID="ltlwgt" runat="server"></asp:Literal>吨
						</div>
					</div>
				</div>
				<div class="first_fo">
					开证日期(Date Of Issue):<span><asp:Literal ID="ltlkzrq" runat="server"></asp:Literal></span>
				</div>
                <div class="first_fo">注册后可查详细内容</div>
			</div>
			<div style="height:5px; width: 100%;"></div>
			<div class="table_box">
				<table class="table_box_he table_Bg_Qianlan" id="table_box_he">
					<thead>
						<tr class="x_average" id="heTableTh">
							<th style="width:120px;">名称</th>
							<th class="tableTdMore average">项目</th>
						</tr>
					</thead>
				</table>
				<table class="table_tbody_box">
					<tbody>
						<tr class="x_average">
							<td class="table_Bg_hui" style="width:120px;">
							<div class="title_ch">
								订货单位
							</div>
							<div class="title_en">
								Customer
							</div></td>
							<td class="tableTdMore average">
                                <asp:Literal ID="ltlcustname" runat="server"></asp:Literal></td>
						</tr>
						<tr class="x_average">
							<td class="table_Bg_hui" style="width:120px;">
							<div class="title_ch">
								收货单位
							</div>
							<div class="title_en">
								Purchaser
							</div></td>
							<td class="average"> <asp:Literal ID="ltlshcust" runat="server"></asp:Literal></td>
						</tr>
						<tr class="x_average">
							<td class="table_Bg_hui" style="width:120px;">
							<div class="title_ch">
								产品名称
							</div>
							<div class="title_en">
								Product Name
							</div></td>
							<td class="average"> <asp:Literal ID="ltlmatname" runat="server"></asp:Literal></td>
						</tr>
						<tr class="x_average">
							<td class="table_Bg_hui" style="width:120px;">
							<div class="title_ch">
								牌号
							</div>
							<div class="title_en">
								Steel Grade
							</div></td>
							<td class="average"> <asp:Literal ID="ltlstlgrd" runat="server"></asp:Literal></td>
						</tr>
						<tr class="x_average">
							<td class="table_Bg_hui" style="width:120px;">
							<div class="title_ch">
								批号
							</div>
							<div class="title_en">
								Heat No.
							</div></td>
							<td class="average"> <asp:Literal ID="ltlbatch" runat="server"></asp:Literal></td>
						</tr>
						<tr class="x_average">
							<td class="table_Bg_hui" style="width:120px;">
							<div class="title_ch">
								交货标准
							</div>
							<div class="title_en">
								Specifcation
							</div></td>
							<td class="average"> <asp:Literal ID="ltljhstd" runat="server"></asp:Literal></td>
						</tr>
						<tr class="x_average">
							<td class="table_Bg_hui" style="width:120px;">
							<div class="title_ch">
								炉号
							</div>
							<div class="title_en">
								He at No.
							</div></td>
							<td class="average">
                                <asp:Literal ID="ltlstove" runat="server"></asp:Literal></td>
						</tr>
						<tr class="x_average">
							<td class="table_Bg_hui" style="width:120px;">
							<div class="title_ch">
								规格(mm)
							</div>
							<div class="title_en">
								Sise
							</div></td>
							<td class="average">
                                <asp:Literal ID="ltlspec" runat="server"></asp:Literal></td>
						</tr>
						<tr class="x_average">
							<td class="table_Bg_hui" style="width:120px;">
							<div class="title_ch">
								等级
							</div>
							<div class="title_en">
								Grade
							</div></td>
							<td class="average">
                                <asp:Literal ID="ltldj" runat="server"></asp:Literal></td>
						</tr>
						<tr class="x_average">
							<td class="table_Bg_hui" style="width:120px;">
							<div class="title_ch">
								交货状态
							</div>
							<div class="title_en">
								Delivery Conditions
							</div></td>
							<td class="average">
                                <asp:Literal ID="ltljhstate" runat="server"></asp:Literal></td>
						</tr>
					</tbody>
				</table>
			</div>
		</div>
	</body>
	
</html>
