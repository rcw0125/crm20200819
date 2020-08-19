using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NF.DAL
{
   public abstract class ByPage
    {

         
       

        #region //生成分页查询组合

        /**/
        /// <summary>
        /// 生成分页查询语句
        /// </summary>
        /// <returns></returns>
        public static string GenerateByPageSql(int pageSize, int pageIndex, string item, string table, string order, string where)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(item))
                item = "*";

            int start_row_num = (pageIndex - 1) * pageSize + 1;

            sb.AppendFormat(" from {0}", table);
            if (where.Length > 0)
                sb.AppendFormat(" where 1=1 {0}", where);


            return
                string.Format(
                    "WITH t AS (SELECT ROW_NUMBER() OVER(ORDER BY {0}) as row_number,{1}{2}) Select * from t where row_number BETWEEN {3} and {4}",
                    order, item, sb, start_row_num, (start_row_num + pageSize - 1));
        }
        #endregion
    }
}
