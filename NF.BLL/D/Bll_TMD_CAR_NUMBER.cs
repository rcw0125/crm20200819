using NF.DLL.D;
using NF.MODEL.D;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.BLL.D
{
    public class Bll_TMD_CAR_NUMBER
    {
        Dal_TMD_CAR_NUMBER dal = new Dal_TMD_CAR_NUMBER();



        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string car)
        {
            return dal.Exists(car);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMD_CAR_NUMBER model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMD_CAR_NUMBER model)
        {
            return dal.Update(model);
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMD_CAR_NUMBER GetModel()
        {
            return dal.GetModel();
        }




        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string cph, string type)
        {
            return dal.GetList(cph,type);
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        public bool UpdateByWhere(string strwhere)
        {
            return dal.UpdateByWhere(strwhere);
        }
        public bool Delete(string strwhere)
        {
            return dal.Delete(strwhere);
        }
    }
}
