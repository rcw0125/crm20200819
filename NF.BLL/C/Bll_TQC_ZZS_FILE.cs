using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 质证书附件
    /// </summary>
    public partial class Bll_TQC_ZZS_FILE
    {
        private readonly Dal_TQC_ZZS_FILE dal = new Dal_TQC_ZZS_FILE();
        public Bll_TQC_ZZS_FILE()
        { }


        public bool InsertItem(Mod_TQC_ZZS_FILE mod)
        {
            return dal.InsertItem(mod);
        }


        public bool UpdateItem(Mod_TQC_ZZS_FILE mod)
        {
            return dal.UpdateItem(mod);
        }

        public bool ExistsZZS(string batch, string stlgrd, string stove, string std)
        {
            return dal.ExistsZZS(batch, stlgrd, stove, std);
        }


        public DataSet GetList(string batch, string stlgrd, string stove, String std)
        {
            return dal.GetList(batch, stlgrd, stove, std);
        }
        public DataSet GetList(string batch, string stlgrd, string stove, string kssj, string jssj)
        {
            return dal.GetList(batch, stlgrd, stove, kssj, jssj);
        }



    }
}

