using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.DAL
{
    public partial class Dal_RandomNumber
    {

        public Dal_RandomNumber()
        {

        }

        /// <summary>
        ///  火运日计划
        /// </summary>
        /// <returns></returns>
        public string GetTrainDayCode()
        {
            try
            {
                #region 火运日计划
                string maxfyd = string.Empty;

                string no = DateTime.Now.Year.ToString().Substring(2, 2) + (Convert.ToInt32(DateTime.Now.Month) > 9 ? DateTime.Now.Month.ToString() : ("0" + DateTime.Now.Month.ToString())) + (Convert.ToInt32(DateTime.Now.Day) > 9 ? DateTime.Now.Day.ToString() : ("0" + DateTime.Now.Day.ToString()));

                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT MAX(C_ID)  FROM TMC_TRAIN_MAIN WHERE  C_ID LIKE 'TP" + no + "%'");

                object obj = DbHelperOra.GetSingle(strSql.ToString());
                if (obj != null)
                {
                    maxfyd = obj.ToString();
                }
                if (!string.IsNullOrEmpty(maxfyd))
                {
                    no = (Convert.ToInt64(maxfyd.Substring(2, maxfyd.Length - 2)) + 1).ToString();
                }
                else
                {
                    no = no + "0001";
                }
                no = "TP" + no;
                #endregion

                return no;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        ///  火运报备计划
        /// </summary>
        /// <returns></returns>
        public string GetTrainCode()
        {
            try
            {
                #region 火运报备计划
                string maxfyd = string.Empty;

                string no = DateTime.Now.Year.ToString().Substring(2, 2) + (Convert.ToInt32(DateTime.Now.Month) > 9 ? DateTime.Now.Month.ToString() : ("0" + DateTime.Now.Month.ToString())) + (Convert.ToInt32(DateTime.Now.Day) > 9 ? DateTime.Now.Day.ToString() : ("0" + DateTime.Now.Day.ToString()));

                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT MAX(C_BILLCODE)  FROM TMC_TRAIN_ITEM WHERE  C_BILLCODE LIKE 'T" + no + "%'");

                object obj = DbHelperOra.GetSingle(strSql.ToString());
                if (obj != null)
                {
                    maxfyd = obj.ToString();
                }
                if (!string.IsNullOrEmpty(maxfyd))
                {
                    no = (Convert.ToInt64(maxfyd.Substring(1, maxfyd.Length - 1)) + 1).ToString();
                }
                else
                {
                    no = no + "0001";
                }
                no = "T" + no;
                #endregion

                return no;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        ///  发运单单据号
        /// </summary>
        /// <returns></returns>
        public string CreateDispID()
        {
            try
            {
                #region 获取发运单
                string maxfyd = string.Empty;

                string no = DateTime.Now.Year.ToString().Substring(2, 2) + (Convert.ToInt32(DateTime.Now.Month) > 9 ? DateTime.Now.Month.ToString() : ("0" + DateTime.Now.Month.ToString())) + (Convert.ToInt32(DateTime.Now.Day) > 9 ? DateTime.Now.Day.ToString() : ("0" + DateTime.Now.Day.ToString()));

                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT MAX(C_ID)  FROM TMD_DISPATCH WHERE  C_ID LIKE 'DMC" + no + "%'");

                object obj = DbHelperOra.GetSingle(strSql.ToString());
                if (obj != null)
                {
                    maxfyd = obj.ToString();
                }
                if (!string.IsNullOrEmpty(maxfyd))
                {
                    no = (Convert.ToInt64(maxfyd.Substring(3, maxfyd.Length - 3)) + 1).ToString();
                }
                else
                {
                    no = no + "0001";
                }
                no = "DMC" + no;
                #endregion

                return no;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 合同号
        /// </summary>
        /// <param name="area">区域代码</param>
        /// <returns></returns>
        public string CreateConNo(string area)
        {
            try
            {
                #region //获取合同号
                string max_no = string.Empty;

                string no = DateTime.Now.Year.ToString().Substring(2, 2) + area;

                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT MAX(C_CON_XH) FROM TMO_CON  WHERE length(C_CON_XH)=15 and  C_CON_XH LIKE 'XG-XS-" + no + "%'");

                object obj = DbHelperOra.GetSingle(strSql.ToString());
                if (obj != null)
                {
                    max_no = obj.ToString();
                }
                if (!string.IsNullOrEmpty(max_no) && max_no.Length <= 15)
                {
                    no = (Convert.ToInt64(max_no.Substring(6, max_no.Length - 6)) + 1).ToString();
                }
                else
                {
                    switch (area)
                    {
                        case "01"://北方
                            no = no + "00001";
                            break;
                        case "02"://南方
                            no = no + "00001";
                            break;
                        case "03"://出口
                            no = no + "00001";
                            break;
                        case "07"://不锈钢
                            no = no + "00001";
                            break;
                        case "09"://不良品
                            no = no + "00001";
                            break;
                        case "04"://钢坯
                            no = no + "00001";
                            break;
                        case "05"://副产品
                            no = no + "00001";
                            break;
                    }

                }
                no = "XG-XS-" + no;

                #endregion

                return no;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 需求订单号
        /// </summary>
        /// <param name="conNO"></param>
        /// <returns></returns>
        public string CreateNeedOrderNo(string conNO)
        {

            string orderNO = conNO;
            orderNO += FillVacancy(DbHelperOra.GetSingle(" select SEQ_NEEDNO.NEXTVAL No   from  sys.dual  ").ToString());
            return orderNO;
        }

        /// <summary>
        /// 订单号
        /// </summary>
        /// <param name="conNO"></param>
        /// <returns></returns>
        public string CreateOrderNo(string conNO)
        {

            string orderNO = conNO;
            orderNO += FillVacancy(DbHelperOra.GetSingle(" select SEQ_NORTHID.NEXTVAL No   from  sys.dual  ").ToString());
            return orderNO;
        }

        /// <summary>
        /// 排产订单号
        /// </summary>
        /// <param name="conNO"></param>
        /// <returns></returns>
        public string CreatePlanOrderNo(string conNO)
        {

            string orderNO = conNO;
            orderNO += FillVacancy(DbHelperOra.GetSingle(" select SEQ_NORTHID.NEXTVAL No   from  sys.dual  ").ToString());
            return orderNO;
        }

        /// <summary>
        /// 获取销售单据号
        /// </summary>
        /// <returns></returns>
        public static string GetSaleCode()
        {

            #region //获取单据号
            string max_no = string.Empty;

            string no = DateTime.Now.Year.ToString().Substring(2, 2) + (Convert.ToInt32(DateTime.Now.Month) > 9 ? DateTime.Now.Month.ToString() : ("0" + DateTime.Now.Month.ToString())) + (Convert.ToInt32(DateTime.Now.Day) > 9 ? DateTime.Now.Day.ToString() : ("0" + DateTime.Now.Day.ToString()));

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(C_NC_SALECODE) FROM TMO_CON_ORDER  WHERE  C_NC_SALECODE LIKE 'SOC" + no + "%'");

            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj != null)
            {
                max_no = obj.ToString();
            }
            if (!string.IsNullOrEmpty(max_no))
            {
                no = (Convert.ToInt64(max_no.Substring(3, max_no.Length - 3)) + 1).ToString();
            }
            else
            {
                no = no + "0001";
            }
            no = "SOC" + no;

            #endregion

            return no;
        }

        /// <summary>
        /// 获取日计划单据号
        /// </summary>
        /// <returns></returns>
        public static string GetDayPlanCode()
        {

            #region //获取单据号
            string max_no = string.Empty;

            string no = DateTime.Now.Year.ToString().Substring(2, 2) + (Convert.ToInt32(DateTime.Now.Month) > 9 ? DateTime.Now.Month.ToString() : ("0" + DateTime.Now.Month.ToString())) + (Convert.ToInt32(DateTime.Now.Day) > 9 ? DateTime.Now.Day.ToString() : ("0" + DateTime.Now.Day.ToString()));

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(C_PLCODE) FROM TMP_DAYPLAN  WHERE  C_PLCODE LIKE 'DMD" + no + "%'");

            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj != null)
            {
                max_no = obj.ToString();
            }
            if (!string.IsNullOrEmpty(max_no))
            {
                no = (Convert.ToInt64(max_no.Substring(3, max_no.Length - 3)) + 1).ToString();
            }
            else
            {
                no = no + "0001";
            }
            no = "DMD" + no;

            #endregion


            return no;
        }

        /// <summary>
        /// 质证书号
        /// </summary>
        /// <returns></returns>
        public string GetZZS()
        {
            DateTime dtime = DateTime.Now;
            string year = dtime.Year.ToString().Substring(2);
            string month = dtime.Month.ToString();
            string day = dtime.Day.ToString();
            string planNo = year;
            planNo += FillVacancy3(DbHelperOra.GetSingle(" select SEQ_PLANID.NEXTVAL No   from  sys.dual  ").ToString());
            return planNo;
        }

        /// <summary>
        /// 远程质证书号
        /// </summary>
        /// <returns></returns>
        public string GetZSH()
        {
            #region 获取发运单
            string maxfyd = string.Empty;

            string no = DateTime.Now.Year.ToString().Substring(2, 2) + (Convert.ToInt32(DateTime.Now.Month) > 9 ? DateTime.Now.Month.ToString() : ("0" + DateTime.Now.Month.ToString())) + (Convert.ToInt32(DateTime.Now.Day) > 9 ? DateTime.Now.Day.ToString() : ("0" + DateTime.Now.Day.ToString()));

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(C_ZSH)  FROM TQC_ZZS_INFO WHERE  C_ZSH LIKE '" + no + "%'");

            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj != null)
            {
                maxfyd = obj.ToString();
            }
            if (!string.IsNullOrEmpty(maxfyd))
            {
                no = (Convert.ToInt64(maxfyd) + 1).ToString();
            }
            else
            {
                no = no + "0001";
            }
            #endregion


            return no;
        }


        public static string FillVacancy3(string serNum)
        {
            if (serNum.Length == 1)
                serNum = "00000" + serNum;
            else if (serNum.Length == 2)
                serNum = "0000" + serNum;
            else if (serNum.Length == 3)
                serNum = "000" + serNum;
            else if (serNum.Length == 4)
                serNum = "00" + serNum;
            else if (serNum.Length == 5)
                serNum = "0" + serNum;

            return serNum;
        }

        public static string FillVacancy2(string serNum)
        {
            if (serNum.Length == 1)
                serNum = "0000" + serNum;
            else if (serNum.Length == 2)
                serNum = "00" + serNum;
            else if (serNum.Length == 3)
                serNum = "0" + serNum;

            return serNum;
        }

        public static string FillVacancy(string serNum)
        {
            if (serNum.Length == 1)
                serNum = "000" + serNum;
            else if (serNum.Length == 2)
                serNum = "00" + serNum;
            else if (serNum.Length == 3)
                serNum = "0" + serNum;

            return serNum;
        }
    }
}
