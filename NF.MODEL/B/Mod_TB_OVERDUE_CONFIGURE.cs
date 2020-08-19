using System;
namespace NF.MODEL
{
    /// <summary>
	/// 排班表
	/// </summary>
	[Serializable]
    public partial class Mod_TB_OVERDUE_CONFIGURE
    {
        public Mod_TB_OVERDUE_CONFIGURE()
        { }
         
        public string C_ID { set; get; }
        public decimal N_YJ_DAYS { set; get; }
    }
}
