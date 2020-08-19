
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using NF.MODEL;

namespace NF.DAL
{
    public partial class Dal_Interface_FR
    {
        public Dal_Interface_FR()
        { }
        #region 向条码发送发运单信息
       
        
        /// <summary>
        /// 向条码发送发运单
        /// </summary>
        /// <param name="idstr">id字符串</param>
        /// <returns>返回int类型 1为转入成功,等于0代码异常-1导入PCI中间表错误-2导入条码中间表错误</returns>
        public int SENDFYD(string fydh)
        {
            string LogSql = "";
            string name = "Dal_Interface_FR.SENDFYD";
            try
            {
                
                return ADDFYDToZJB(fydh);//发送发运单
            }
            catch (Exception ex)
            {
                LogSql = "INSERT INTO TI_RF_LOG(C_TYPE, C_LOG, C_NAME) VALUES('向条码发送发运单','" + ex.ToString() + "','" + name + "')";
                DbHelperOra.ExecuteSql(LogSql);
                return 0;
            }
        }
      

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMD_DISPATCHDETAILS> DataTableToList(DataTable dt)
        {           
            List<Mod_TMD_DISPATCHDETAILS> modelList = new List<Mod_TMD_DISPATCHDETAILS>();
            Dal_TMD_DISPATCHDETAILS dal = new Dal_TMD_DISPATCHDETAILS();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMD_DISPATCHDETAILS model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 发送发运单到中间表
        /// </summary>
        /// <param name="dt">要发送的集合</param>
        /// <returns>返回int类型 大于0为转入成功,等于0发送失败</returns>
        public int ADDFYDToZJB(string sendcode)
        {
            //TransactionHelper_SQL.BeginTransaction();

            List<Mod_TMD_DISPATCHDETAILS> item = new List<Mod_TMD_DISPATCHDETAILS>();

            #region //实例化
            Dal_TMD_DISPATCHDETAILS dalitem = new Dal_TMD_DISPATCHDETAILS();
            Dal_TQB_CHECKSTATE daltqb = new Dal_TQB_CHECKSTATE();
            Dal_TS_DEPT daldetp = new Dal_TS_DEPT();
            Dal_TS_USER daluser = new Dal_TS_USER();          
            Dal_TMD_DISPATCH dalhead = new Dal_TMD_DISPATCH();
            Dal_TS_DIC daldic = new Dal_TS_DIC();
            #endregion

            Mod_TMD_DISPATCH modTmd = dalhead.GetModel(sendcode);//发运单主表

            item = DataTableToList(dalitem.GetList(sendcode).Tables[0]);//发运明细

            StringBuilder strSql = new StringBuilder();          
            for (int i = 0; i < item.Count; i++)
            {
                #region//基础数据
                Mod_TQB_CHECKSTATE modtqb = daltqb.GetModel(item[i].C_QUALIRY_LEV);
                Mod_TS_DEPT moddept = daldetp.GetModel(modTmd.C_BUSINESS_DEPT);//业务部门
                string saleemp= daluser.GetSaleName(modTmd.C_BUSINESS_ID);//业务人
                Mod_TS_USER moduser = daluser.GetModel(modTmd.C_CREATE_ID);//制单人

                //0主计量单位，1辅单位
                DataTable dt = DbHelperOra.Query("SELECT T.C_ID,T.C_MEASNAME FROM TMB_MEAS T WHERE T.C_ID in('" + item[i].C_UNITIS + "','"+ item[i].C_AU_UNITIS + "')").Tables[0];

                DataRow drfyfs = DbHelperOra.GetDataRow("select T.C_INDEX from TS_DIC t where t.c_detailcode='"+modTmd.C_SHIPVIA+"'");

                #endregion

                #region //插入条码中间表
                strSql.Append("insert into ReZJB_FYD(");
                strSql.Append("fydh,");//发运单号-
                strSql.Append("ck,");//仓库主键-
                strSql.Append("khbm,");//客户编码-
                strSql.Append("yslb,");//运输方式主键
                strSql.Append("cph,");//车牌号-
                strSql.Append("wlh,");//物料编码-
                strSql.Append("wlmc,");//物料名称-
                strSql.Append("sx,");//质量等级编码A,B-
                strSql.Append("jhsl,");//支数--
                strSql.Append("jhzl,");//重量--
                strSql.Append("zjldw,");//线材主计量单位名称（件【线材】）-
                strSql.Append("fjldw,");//吨--
                strSql.Append("ywbm,");//业务部门名称--
                strSql.Append("ywry,");//业务员名称--
                strSql.Append("zdr,");//制单人名称--
                strSql.Append("zdrq,");//制单时间--
                strSql.Append("PH,");//钢种--
                strSql.Append("GG,");//规格--
                strSql.Append("ZJBstatus,");//状态默认0--
                strSql.Append("CAPPK,");//发运单明细表主键--
                strSql.Append("insertts,");//插入时间--
                strSql.Append("PCInfo,");//其他要求名称--
                strSql.Append("zyx1,");//自由项1--
                strSql.Append("zyx2,");//自由项2--
                strSql.Append("zyx3,");//包装要求
                strSql.Append("zyx4,");//导入条码次数
                strSql.Append("zldj");//行备注
                strSql.Append(")values(");
                strSql.Append("'"+item[i].C_DISPATCH_ID+ "',");//发运单号
                strSql.Append("'"+item[i].C_SEND_STOCK_PK + "',");//发运仓库主键
                strSql.Append("'"+item[i].C_CUSTNO + "',");//客户编码
                strSql.Append("'"+ drfyfs["C_INDEX"].ToString() + "',");//发运方式主键1汽运  2火运
                strSql.Append("'"+ modTmd.C_LIC_PLA_NO + "',");//车牌号
                strSql.Append("'"+ item[i].C_MAT_CODE+ "',");//物料编码
                strSql.Append("'"+ item[i].C_MAT_NAME + "',");//物料编码
                strSql.Append("'"+ modtqb.C_CHECKSTATE_NAME + "',");//质量等级名称
                strSql.Append("'" + item[i].N_FYZS + "',");//发运支数
                strSql.Append("'" + item[i].N_FYWGT + "',");//发运重量
                strSql.Append("'" + dt.Rows[1]["C_MEASNAME"] + "',");//线材主计量单位名称（件【线材】）
                strSql.Append("'" + dt.Rows[0]["C_MEASNAME"] + "',");//线材主计量单位名称（吨）
                strSql.Append("'" + moddept.C_NAME + "',");//业务部门名称
                strSql.Append("'" + saleemp + "',");//业务员名称
                strSql.Append("'" + moduser.C_NAME + "',");//制单人名称
                strSql.Append("'" + modTmd.D_CREATE_DT + "',");//制单时间
                strSql.Append("'" + item[i].C_STL_GRD + "',");//钢种
                strSql.Append("'" + item[i].C_SPEC + "',");//规格
                strSql.Append("0,");//状态
                strSql.Append("'" + item[i].C_ID + "',");//发运单明细表主键
                strSql.Append("'" + DateTime.Now.ToString ()+ "',");//插入时间
                strSql.Append("'" + item[i].C_ELSENEED + "',");//其他要求
                strSql.Append("'" + item[i].C_FREE_TERM + "',");//自由项1
                strSql.Append("'" + item[i].C_FREE_TERM2+ "',");//自由项2
                strSql.Append("'" + item[i].C_PACK + "',");// 包装要求
                strSql.Append("'" + modTmd.C_EXTEND1 + "',");// 导入条码系统次数
                strSql.Append("'" + item[i].C_REMARK + "'");// 行备注
                strSql.Append(");");
                #endregion
            }

            if (DbHelper_SQL.ExecuteSql(strSql.ToString ()) == 0)
            {
               
                return -2;
            }
            return 1;
        }
        #endregion


    }
}
