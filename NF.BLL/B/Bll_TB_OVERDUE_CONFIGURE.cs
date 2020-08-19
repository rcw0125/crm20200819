using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// 排班表
    /// </summary>
    public partial class Bll_TB_OVERDUE_CONFIGURE
    {
        private readonly Dal_TB_OVERDUE_CONFIGURE dal = new Dal_TB_OVERDUE_CONFIGURE();
        public Bll_TB_OVERDUE_CONFIGURE()
        { }


        public DataSet GetList()
        {
            return dal.GetList();
        }

        public bool Update(Mod_TB_OVERDUE_CONFIGURE mod)
        {
            return dal.Update(mod);
        }
    }
}
