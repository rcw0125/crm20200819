
﻿using Aspose.Cells;
using NF.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CRM.Common
{
    public class ExportHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dic">列于字段字典表 key为字段，value为导出列名</param>
        /// <param name="tableName"></param>
        /// <param name="Response"></param>
        public static void BudgetExport(DataTable dt,Dictionary<string,string> dic, string tableName,HttpResponse Response)
        {

            Workbook workbook = new Workbook(); //工作簿 
            Worksheet sheet = workbook.Worksheets[0]; //工作表 
            Cells cells = sheet.Cells;//单元格 

            #region//表格样式

            //为标题设置样式    
            Aspose.Cells.Style style1 = workbook.Styles[workbook.Styles.Add()];//新增样式
            style1.HorizontalAlignment = TextAlignmentType.Center;//文字居中
            style1.Font.Name = "宋体";//文字字体
            style1.Font.Size = 16;//文字大小
            style1.Font.IsBold = true;//粗体


            //为标题设置样式2
            Aspose.Cells.Style style2 = workbook.Styles[workbook.Styles.Add()];//新增样式 
            style2.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style2.Font.Name = "宋体";//文字字体 
            style2.Font.Size = 10;//文字大小 
            style2.Font.IsBold = true;//粗体 
            style2.IsTextWrapped = true;//自动换行
            style2.Pattern = BackgroundType.Solid; //设置背景样式
            style2.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin; //应用边界线 左边界线
            style2.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin; //应用边界线 右边界线
            style2.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin; //应用边界线 上边界线
            style2.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin; //应用边界线 下边界线

            //为标题设置样式3
            Aspose.Cells.Style style3 = workbook.Styles[workbook.Styles.Add()];//新增样式 
            style3.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style3.Font.Name = "宋体";//文字字体 
            style3.Font.Size = 10;//文字大小 
            style3.IsTextWrapped = true;//自动换行
            style3.Pattern = BackgroundType.Solid; //设置背景样式
            style3.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin; //应用边界线 左边界线
            style3.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin; //应用边界线 右边界线
            style3.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin; //应用边界线 上边界线
            style3.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin; //应用边界线 下边界线

            Aspose.Cells.Style style4 = workbook.Styles[workbook.Styles.Add()];//新增样式 
            style4.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style4.Number = 1;
            style4.Pattern = BackgroundType.Solid; //设置背景样式
            style4.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin; //应用边界线 左边界线
            style4.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin; //应用边界线 右边界线
            style4.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin; //应用边界线 上边界线
            style4.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin; //应用边界线 下边界线

            //字体样式
            Aspose.Cells.Style font1 = workbook.Styles[workbook.Styles.Add()];//新增样式
            font1.HorizontalAlignment = TextAlignmentType.Left;//文字居中
            font1.Font.Name = "宋体";//文字字体
            font1.Font.Size = 10;//文字大小
            font1.Font.IsBold = true;//粗体
            font1.IsTextWrapped = true;//自动换行
            font1.Pattern = BackgroundType.Solid; //设置背景样式
            font1.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin; //应用边界线 左边界线
            font1.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin; //应用边界线 右边界线
            font1.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin; //应用边界线 上边界线
            font1.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin; //应用边界线 下边界线

            //字体样式
            Aspose.Cells.Style font2 = workbook.Styles[workbook.Styles.Add()];//新增样式
            font2.HorizontalAlignment = TextAlignmentType.Left;//文字居中
            font2.Font.Name = "宋体";//文字字体
            font2.Font.Size = 10;//文字大小
            font2.IsTextWrapped = true;//自动换行
            font2.Pattern = BackgroundType.Solid; //设置背景样式
            font2.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin; //应用边界线 左边界线
            font2.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin; //应用边界线 右边界线
            font2.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin; //应用边界线 上边界线
            font2.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin; //应用边界线 下边界线

            #endregion

            int Rownum = dt.Rows.Count;//表格行数
            var exportColumns = dic.Values.ToArray();
            var exportFields = dic.Keys.ToArray();
            for (int i = 0; i < exportColumns.Length; i++)
            {
                cells[0, i].PutValue(exportColumns[i].Replace("*",""));
                cells[0, i].SetStyle(style2);
            }
            cells.SetRowHeight(0, 18);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < exportFields.Length; j++)
                {                   
                    if (exportColumns[j].IndexOf("*") > -1)
                    {
                        cells[1 + i, j].PutValue(dt.Rows[i][exportFields[j]]);                       
                    }
                    else
                    {
                        cells[1 + i, j].PutValue(dt.Rows[i][exportFields[j]].ToString());                       
                    }
                    cells[1 + i, j].SetStyle(style3);
                }
                cells.SetRowHeight(1 + i, 18);
            }
            setColumnWithAuto(sheet);
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "utf-8";
            string strTemp = System.Web.HttpUtility.UrlEncode(tableName, System.Text.Encoding.UTF8);//解决文件名乱码
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + strTemp + ".xls");
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/ms-excel";
            Response.BinaryWrite(workbook.SaveToStream().ToArray());
            Response.End();
            WebMsg.MessageBox("下载成功！");
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dic"></param>
        /// <param name="fullPath"></param>
        public static void BudgetSaveExport(DataTable dt, Dictionary<string, string> dic, string fullPath)
        {

            Workbook workbook = new Workbook(); //工作簿 
            Worksheet sheet = workbook.Worksheets[0]; //工作表 
            Cells cells = sheet.Cells;//单元格 

            #region//表格样式

            //为标题设置样式    
            Aspose.Cells.Style style1 = workbook.Styles[workbook.Styles.Add()];//新增样式
            style1.HorizontalAlignment = TextAlignmentType.Center;//文字居中
            style1.Font.Name = "宋体";//文字字体
            style1.Font.Size = 16;//文字大小
            style1.Font.IsBold = true;//粗体


            //为标题设置样式2
            Aspose.Cells.Style style2 = workbook.Styles[workbook.Styles.Add()];//新增样式 
            style2.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style2.Font.Name = "宋体";//文字字体 
            style2.Font.Size = 10;//文字大小 
            style2.Font.IsBold = true;//粗体 
            style2.IsTextWrapped = true;//自动换行
            style2.Pattern = BackgroundType.Solid; //设置背景样式
            style2.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin; //应用边界线 左边界线
            style2.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin; //应用边界线 右边界线
            style2.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin; //应用边界线 上边界线
            style2.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin; //应用边界线 下边界线

            //为标题设置样式3
            Aspose.Cells.Style style3 = workbook.Styles[workbook.Styles.Add()];//新增样式 
            style3.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style3.Font.Name = "宋体";//文字字体 
            style3.Font.Size = 10;//文字大小 
            style3.IsTextWrapped = true;//自动换行
            style3.Pattern = BackgroundType.Solid; //设置背景样式
            style3.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin; //应用边界线 左边界线
            style3.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin; //应用边界线 右边界线
            style3.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin; //应用边界线 上边界线
            style3.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin; //应用边界线 下边界线

            //字体样式
            Aspose.Cells.Style font1 = workbook.Styles[workbook.Styles.Add()];//新增样式
            font1.HorizontalAlignment = TextAlignmentType.Left;//文字居中
            font1.Font.Name = "宋体";//文字字体
            font1.Font.Size = 10;//文字大小
            font1.Font.IsBold = true;//粗体
            font1.IsTextWrapped = true;//自动换行
            font1.Pattern = BackgroundType.Solid; //设置背景样式
            font1.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin; //应用边界线 左边界线
            font1.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin; //应用边界线 右边界线
            font1.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin; //应用边界线 上边界线
            font1.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin; //应用边界线 下边界线

            //字体样式
            Aspose.Cells.Style font2 = workbook.Styles[workbook.Styles.Add()];//新增样式
            font2.HorizontalAlignment = TextAlignmentType.Left;//文字居中
            font2.Font.Name = "宋体";//文字字体
            font2.Font.Size = 10;//文字大小
            font2.IsTextWrapped = true;//自动换行
            font2.Pattern = BackgroundType.Solid; //设置背景样式
            font2.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin; //应用边界线 左边界线
            font2.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin; //应用边界线 右边界线
            font2.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin; //应用边界线 上边界线
            font2.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin; //应用边界线 下边界线

            #endregion

            int Rownum = dt.Rows.Count;//表格行数
            var exportColumns = dic.Values.ToArray();
            var exportFields = dic.Keys.ToArray();
            for (int i = 0; i < exportColumns.Length; i++)
            {
                cells[0, i].PutValue(exportColumns[i]);
                cells[0, i].SetStyle(style2);
            }
            cells.SetRowHeight(0, 18);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < exportFields.Length; j++)
                {
                    if (exportColumns[j].IndexOf("*") > -1)
                    {
                        cells[1 + i, j].PutValue(dt.Rows[i][exportFields[j]]);
                    }
                    else
                    {
                        cells[1 + i, j].PutValue(dt.Rows[i][exportFields[j]].ToString());
                    }                    
                    cells[1 + i, j].SetStyle(style3);
                }
                cells.SetRowHeight(1 + i, 18);
            }
            setColumnWithAuto(sheet);            
            workbook.Save(fullPath);
        }
        /// <summary>       
        /// 
        /// 设置表页的列宽度自适应   
        /// /// </summary>       
        /// /// <param name="sheet">worksheet对象</param>  
        /// 
        public static void setColumnWithAuto(Worksheet sheet)
        {
            Cells cells = sheet.Cells;
            int columnCount = cells.MaxColumn;  //获取表页的最大列数   
            int rowCount = cells.MaxRow;        //获取表页的最大行数      
            for (int col = 0; col <= columnCount; col++)
            {
                sheet.AutoFitColumn(col, 0, rowCount);
            }
            for (int col = 0; col <= columnCount; col++)
            {
                int width = 50;
                cells.SetColumnWidthPixel(col, cells.GetColumnWidthPixel(col) + width);
            }
        }
    }
}
