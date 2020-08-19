using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NF.DAL;


namespace NF.BLL
{
    public partial class Bll_GPS
    {
        private readonly Dal_GPS dal = new Dal_GPS();

        public bool UpdateGPS(int isGPS, String idList, string table)
        {
            return dal.UpdateN_ISGPS(isGPS, idList, table);
        }

        /// <summary>
        /// 钢种更新是否GPS
        /// </summary>
        public bool UpdateStlGrd(int isGPS, String idList, string table)
        {
            return dal.UpdateStlGrd(isGPS, idList, table);
        }

        /// <summary>
        /// 发运单校验GPS
        /// </summary>
        /// <param name="custno">客户编码</param>
        /// <param name="fypk">发运主键</param>
        /// <param name="area">区域</param>
        /// <param name="matcode">物料钢种</param>
        /// <returns></returns>
        public bool GpsFyd(string custno, string fypk, string area, string matcode)
        {
            return dal.GpsFyd(custno, fypk, area, matcode);
        }
    }
}
