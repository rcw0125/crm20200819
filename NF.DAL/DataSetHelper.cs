using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NF.DAL
{
   public class DataSetHelper
    {
        public static DataSet SplitDataSet(DataSet ds, int pageSize, int pageIndex)
        {
            DataSet vds = new DataSet();
            vds = ds.Clone();
            if (pageIndex < 1) pageIndex = 1;//如果小于1，取第一页
            //if ((ds.Tables[0].Rows.Count + pageSize) <= (pageSize * pageIndex)) pageIndex = 1;
            int fromIndex = pageSize * (pageIndex - 1);//开始行
            int toIndex = pageSize * pageIndex - 1; //结束行
            for (int i = fromIndex; i <= toIndex; i++)
            {
                if (i >= (ds.Tables[0].Rows.Count)) //到达这一行，退出
                    break;
                vds.Tables[0].ImportRow(ds.Tables[0].Rows[i]);
            }
            ds.Dispose();
            return vds;
        }


        /// <summary>
        /// 根据索引和pagesize返回记录
        /// </summary>
        /// <param name="dt">记录集 DataTable</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="pagesize">一页的记录数</param>
        /// <returns></returns>
        public static DataTable SplitDataTable(DataTable dt, int PageIndex, int PageSize)
        {
            if (dt == null)
            {
                return null;
            }
            if (PageIndex == 0)
                return dt;
            DataTable newdt = dt.Clone();
            //newdt.Clear();
            int rowbegin = (PageIndex - 1) * PageSize;
            int rowend = PageIndex * PageSize;

            if (rowbegin >= dt.Rows.Count)
                return newdt;

            if (rowend > dt.Rows.Count)
                rowend = dt.Rows.Count;
            for (int i = rowbegin; i <= rowend - 1; i++)
            {
                DataRow newdr = newdt.NewRow();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dt.Columns)
                {
                    newdr[column.ColumnName] = dr[column.ColumnName];
                }
                newdt.Rows.Add(newdr);
            }

            return newdt;
        }

        public static DataTable ToDataTable(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0) return null;
            DataTable tmp = rows[0].Table.Clone();  // 复制DataRow的表结构
            foreach (DataRow row in rows)
                tmp.Rows.Add(row.ItemArray);  // 将DataRow添加到DataTable中
            return tmp;
        }
    }
}
