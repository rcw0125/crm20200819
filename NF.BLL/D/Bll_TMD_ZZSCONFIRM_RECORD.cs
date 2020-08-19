using NF.MODEL.D;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.BLL
{
    public class Bll_TMD_ZZSCONFIRM_RECORD
    {
        private readonly Dal_TMD_ZZSCONFIRM_RECORD dal = new Dal_TMD_ZZSCONFIRM_RECORD();
        public Bll_TMD_ZZSCONFIRM_RECORD()
        { }
        public bool Add(Mod_TMD_ZZSCONFIRM_RECORD model)
        {
            return dal.Add(model);
        }
        public bool Update(Mod_TMD_ZZSCONFIRM_RECORD model)
        {
            return dal.Update(model);
        }
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public bool AddList(List<Mod_TMD_ZZSCONFIRM_RECORD> ls)
        {
            return dal.AddList(ls);
        }
    }
}
