using NF.DAL;
using NF.MODEL;
using NF.MODEL.Q;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.DLL.Q
{
    public class Dal_TMQ_QUA_MAIN
    {

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMQ_QUA_MAIN model)
        {
            #region 新增主表
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMQ_QUA_MAIN(");
            strSql.Append(@" c_area_id, 
                            c_distributor, 
                            c_directuser, 
                            c_contact, 
                            c_con_phone, 
                            c_grd, 
                            c_prod_use, 
                            d_ship_start_dt, 
                            d_ship_end_dt, 
                            n_object_count_wgt, 
                            c_object_content, 
                            c_tech_desc, 
                            c_site_survey_content, 
                            n_parent_qua, 
                            n_quest_qua, 
                            n_middle_qua, 
                            n_else_qua, 
                            c_dept, 
                            c_quality_dept, 
                            c_technology, 
                            c_qt, 
                            c_remark, 
                            c_cust_making, 
                            d_cust_making_dt, 
                            c_quality_result, 
                            c_objection_type, 
                            c_ourreasons, 
                            d_feedback_area, 
                            c_effect_valid, 
                            c_precc_result, 
                            n_amount, 
                            d_compensation_dt, 
                            c_state, 
                            n_cycle, 
                            c_month_average, 
                            c_salesman, 
                            n_flag, 
                            c_emp_id, 
                            c_emp_name, 
                            n_status, 
                            c_crt_id,
                          C_ID,C_SALESID)    values (   :c_area_id, 
                            :c_distributor, 
                            :c_directuser, 
                            :c_contact, 
                            :c_con_phone, 
                            :c_grd, 
                            :c_prod_use, 
                            :d_ship_start_dt, 
                            :d_ship_end_dt, 
                            :n_object_count_wgt, 
                            :c_object_content, 
                            :c_tech_desc, 
                            :c_site_survey_content, 
                            :n_parent_qua, 
                            :n_quest_qua, 
                            :n_middle_qua, 
                            :n_else_qua, 
                            :c_dept, 
                            :c_quality_dept, 
                            :c_technology, 
                            :c_qt, 
                            :c_remark, 
                            :c_cust_making, 
                            :d_cust_making_dt, 
                            :c_quality_result, 
                            :c_objection_type, 
                            :c_ourreasons, 
                            :d_feedback_area, 
                            :c_effect_valid, 
                            :c_precc_result, 
                            :n_amount, 
                            :d_compensation_dt, 
                            :c_state, 
                            :n_cycle, 
                            :c_month_average, 
                            :c_salesman, 
                            :n_flag, 
                            :c_emp_id, 
                            :c_emp_name, 
                            :n_status,                              
                            :c_crt_id,
                            :C_ID,:C_SALESID)");
            OracleParameter[] parameters = {
                            new OracleParameter(":c_area_id", OracleDbType.Varchar2,100), //区域ID
                            new OracleParameter(":c_distributor", OracleDbType.Varchar2,100), //经销商
                            new OracleParameter(":c_directuser", OracleDbType.Varchar2,100), //直接用户
                            new OracleParameter(":c_contact", OracleDbType.Varchar2,100), //联系人
                            new OracleParameter(":c_con_phone", OracleDbType.Varchar2,100), //联系电话
                            new OracleParameter(":c_grd", OracleDbType.Varchar2,100), //钢种大类
                            new OracleParameter(":c_prod_use", OracleDbType.Varchar2,100), //产品用途
                            new OracleParameter(":d_ship_start_dt", OracleDbType.Date), //发货开始时间
                            new OracleParameter(":d_ship_end_dt", OracleDbType.Date), //发货到货时间
                            new OracleParameter(":n_object_count_wgt", OracleDbType.Decimal,15),//异议数量合计
                            new OracleParameter(":c_object_content", OracleDbType.Varchar2,1000), //投诉异议内容/信息内容
                            new OracleParameter(":c_tech_desc", OracleDbType.Varchar2,1000), //用户工艺流程/生产工艺
                            new OracleParameter(":c_site_survey_content", OracleDbType.Varchar2,1000), //现场调查情况
                            new OracleParameter(":n_parent_qua", OracleDbType.Decimal,2), //母材支数(取样)/原始盘条样
                            new OracleParameter(":n_quest_qua", OracleDbType.Decimal,2), //问题样支数(取样)/问题产品
                            new OracleParameter(":n_middle_qua", OracleDbType.Decimal,2), //中间样支数(取样)/中间产品样
                            new OracleParameter(":n_else_qua", OracleDbType.Decimal,2), //其他支数(取样)
                            new OracleParameter(":c_dept", OracleDbType.Varchar2,100), //部门
                            new OracleParameter(":c_quality_dept", OracleDbType.Varchar2,100), //质控部
                            new OracleParameter(":c_technology", OracleDbType.Varchar2,100), //技术中心
                            new OracleParameter(":c_qt", OracleDbType.Varchar2,100), //其他
                            new OracleParameter(":c_remark", OracleDbType.Varchar2,1000), //备注
                            new OracleParameter(":c_cust_making", OracleDbType.Varchar2,100), //制单人
                            new OracleParameter(":d_cust_making_dt", OracleDbType.Date), //制单时间
                            new OracleParameter(":c_quality_result", OracleDbType.Varchar2,100), //质控部结果
                            new OracleParameter(":c_objection_type", OracleDbType.Varchar2,100), //钢种类型--------------****
                            new OracleParameter(":c_ourreasons", OracleDbType.Varchar2,500), //缺陷类别-------------------****
                            new OracleParameter(":d_feedback_area", OracleDbType.Date), //反馈区域时间
                            new OracleParameter(":c_effect_valid", OracleDbType.Varchar2,200), //效果验证
                            new OracleParameter(":c_precc_result", OracleDbType.Varchar2,500), //处理结果
                            new OracleParameter(":n_amount", OracleDbType.Decimal,15), //赔付金额
                            new OracleParameter(":d_compensation_dt", OracleDbType.Date), //赔付时间
                            new OracleParameter(":c_state", OracleDbType.Varchar2,100), //状态
                            new OracleParameter(":n_cycle", OracleDbType.Decimal,2), //处理周期
                            new OracleParameter(":c_month_average", OracleDbType.Varchar2,100), //月平均处理周期
                            new OracleParameter(":c_salesman", OracleDbType.Varchar2,100), //业务员
                            new OracleParameter(":n_flag", OracleDbType.Decimal,1), //标识：1 质量异议，2客户信息反馈 3:委托检验
                            new OracleParameter(":c_emp_id", OracleDbType.Varchar2,100), //系统操作人编号
                            new OracleParameter(":c_emp_name", OracleDbType.Varchar2,100), //系统操作人姓名
                            new OracleParameter(":n_status", OracleDbType.Decimal,1),   //状态：-1未提交,0待处理,1审批中,2已完成                           
                            new OracleParameter(":c_crt_id", OracleDbType.Varchar2,100),//创建人ID
                            new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                            new OracleParameter(":C_SALESID", OracleDbType.Varchar2,100)};//业务员ID                  
            parameters[0].Value = model.C_area_id;
            parameters[1].Value = model.C_distributor;
            parameters[2].Value = model.C_directuser;
            parameters[3].Value = model.C_contact;
            parameters[4].Value = model.C_con_phone;
            parameters[5].Value = model.C_grd;
            parameters[6].Value = model.C_prod_use;
            parameters[7].Value = model.D_ship_start_dt;
            parameters[8].Value = model.D_ship_end_dt;
            parameters[9].Value = model.N_object_count_wgt;
            parameters[10].Value = model.C_object_content;
            parameters[11].Value = model.C_tech_desc;
            parameters[12].Value = model.C_site_survey_content;
            parameters[13].Value = model.N_parent_qua;
            parameters[14].Value = model.N_quest_qua;
            parameters[15].Value = model.N_middle_qua;
            parameters[16].Value = model.N_else_qua;
            parameters[17].Value = model.C_dept;
            parameters[18].Value = model.C_quality_dept;
            parameters[19].Value = model.C_technology;
            parameters[20].Value = model.C_qt;
            parameters[21].Value = model.C_remark;
            parameters[22].Value = model.C_cust_making;
            parameters[23].Value = model.D_cust_making_dt;
            parameters[24].Value = model.C_quality_result;
            parameters[25].Value = model.C_objection_type;
            parameters[26].Value = model.C_ourreasons;
            parameters[27].Value = model.D_feedback_area;
            parameters[28].Value = model.C_effect_valid;
            parameters[29].Value = model.C_precc_result;
            parameters[30].Value = model.N_amount;
            parameters[31].Value = model.D_compensation_dt;
            parameters[32].Value = model.C_state;
            parameters[33].Value = model.N_cycle;
            parameters[34].Value = model.C_month_average;
            parameters[35].Value = model.C_salesman;
            parameters[36].Value = model.N_flag;
            parameters[37].Value = model.C_emp_id;
            parameters[38].Value = model.C_emp_name;
            parameters[39].Value = model.N_status;
            parameters[40].Value = model.C_crt_id;
            parameters[41].Value = model.C_id;
            parameters[42].Value = model.C_salesid;
            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            #endregion
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMQ_QUA_MAIN model)
        {
            #region 更新数据
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"update TMQ_QUA_MAIN set 
                            c_area_id=:c_area_id, 
                            c_distributor=:c_distributor, 
                            c_directuser=:c_directuser, 
                            c_contact=:c_contact, 
                            c_con_phone=:c_con_phone, 
                            c_grd=:c_grd, 
                            c_prod_use=:c_prod_use, 
                            d_ship_start_dt=:d_ship_start_dt, 
                            d_ship_end_dt=:d_ship_end_dt, 
                            n_object_count_wgt=:n_object_count_wgt, 
                            c_object_content=:c_object_content, 
                            c_tech_desc=:c_tech_desc, 
                            c_site_survey_content=:c_site_survey_content, 
                            n_parent_qua=:n_parent_qua, 
                            n_quest_qua=:n_quest_qua, 
                            n_middle_qua=:n_middle_qua, 
                            n_else_qua=:n_else_qua, 
                            c_dept=:c_dept, 
                            c_quality_dept=:c_quality_dept, 
                            c_technology=:c_technology, 
                            c_qt=:c_qt, 
                            c_remark=:c_remark, 
                            c_cust_making=:c_cust_making, 
                            d_cust_making_dt=:d_cust_making_dt, 
                            c_quality_result=:c_quality_result, 
                            c_objection_type=:c_objection_type, 
                            c_ourreasons=:c_ourreasons, 
                            d_feedback_area=:d_feedback_area, 
                            c_effect_valid=:c_effect_valid, 
                            c_precc_result=:c_precc_result, 
                            n_amount=:n_amount, 
                            d_compensation_dt=:d_compensation_dt, 
                            c_state=:c_state, 
                            n_cycle=:n_cycle, 
                            c_month_average=:c_month_average, 
                            c_salesman=:c_salesman, 
                            n_flag=:n_flag, 
                            c_emp_id=:c_emp_id, 
                            c_emp_name=:c_emp_name, 
                            n_status=:n_status, 
                            c_salesid=:c_salesid");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                            new OracleParameter(":c_area_id", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_distributor", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_directuser", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_contact", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_con_phone", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_grd", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_prod_use", OracleDbType.Varchar2,100),
                            new OracleParameter(":d_ship_start_dt", OracleDbType.Date),
                            new OracleParameter(":d_ship_end_dt", OracleDbType.Date),
                            new OracleParameter(":n_object_count_wgt", OracleDbType.Decimal,15),
                            new OracleParameter(":c_object_content", OracleDbType.Varchar2,1000),
                            new OracleParameter(":c_tech_desc", OracleDbType.Varchar2,1000),
                            new OracleParameter(":c_site_survey_content", OracleDbType.Varchar2,1000),
                            new OracleParameter(":n_parent_qua", OracleDbType.Decimal,2),
                            new OracleParameter(":n_quest_qua", OracleDbType.Decimal,2),
                            new OracleParameter(":n_middle_qua", OracleDbType.Decimal,2),
                            new OracleParameter(":n_else_qua", OracleDbType.Decimal,2),
                            new OracleParameter(":c_dept", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_quality_dept", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_technology", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_qt", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_remark", OracleDbType.Varchar2,1000),
                            new OracleParameter(":c_cust_making", OracleDbType.Varchar2,100),
                            new OracleParameter(":d_cust_making_dt", OracleDbType.Date),
                            new OracleParameter(":c_quality_result", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_objection_type", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_ourreasons", OracleDbType.Varchar2,500),
                            new OracleParameter(":d_feedback_area", OracleDbType.Date),
                            new OracleParameter(":c_effect_valid", OracleDbType.Varchar2,200),
                            new OracleParameter(":c_precc_result", OracleDbType.Varchar2,500),
                            new OracleParameter(":n_amount", OracleDbType.Decimal,15),
                            new OracleParameter(":d_compensation_dt", OracleDbType.Date),
                            new OracleParameter(":c_state", OracleDbType.Varchar2,100),
                            new OracleParameter(":n_cycle", OracleDbType.Decimal,2),
                            new OracleParameter(":c_month_average", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_salesman", OracleDbType.Varchar2,100),
                            new OracleParameter(":n_flag", OracleDbType.Decimal,1),
                            new OracleParameter(":c_emp_id", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_emp_name", OracleDbType.Varchar2,100),
                            new OracleParameter(":n_status", OracleDbType.Decimal,1),
                             new OracleParameter(":c_salesid", OracleDbType.Varchar2,100),
                                new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_area_id;
            parameters[1].Value = model.C_distributor;
            parameters[2].Value = model.C_directuser;
            parameters[3].Value = model.C_contact;
            parameters[4].Value = model.C_con_phone;
            parameters[5].Value = model.C_grd;
            parameters[6].Value = model.C_prod_use;
            parameters[7].Value = model.D_ship_start_dt;
            parameters[8].Value = model.D_ship_end_dt;
            parameters[9].Value = model.N_object_count_wgt;
            parameters[10].Value = model.C_object_content;
            parameters[11].Value = model.C_tech_desc;
            parameters[12].Value = model.C_site_survey_content;
            parameters[13].Value = model.N_parent_qua;
            parameters[14].Value = model.N_quest_qua;
            parameters[15].Value = model.N_middle_qua;
            parameters[16].Value = model.N_else_qua;
            parameters[17].Value = model.C_dept;
            parameters[18].Value = model.C_quality_dept;
            parameters[19].Value = model.C_technology;
            parameters[20].Value = model.C_qt;
            parameters[21].Value = model.C_remark;
            parameters[22].Value = model.C_cust_making;
            parameters[23].Value = model.D_cust_making_dt;
            parameters[24].Value = model.C_quality_result;
            parameters[25].Value = model.C_objection_type;
            parameters[26].Value = model.C_ourreasons;
            parameters[27].Value = model.D_feedback_area;
            parameters[28].Value = model.C_effect_valid;
            parameters[29].Value = model.C_precc_result;
            parameters[30].Value = model.N_amount;
            parameters[31].Value = model.D_compensation_dt;
            parameters[32].Value = model.C_state;
            parameters[33].Value = model.N_cycle;
            parameters[34].Value = model.C_month_average;
            parameters[35].Value = model.C_salesman;
            parameters[36].Value = model.N_flag;
            parameters[37].Value = model.C_emp_id;
            parameters[38].Value = model.C_emp_name;
            parameters[39].Value = model.N_status;
            parameters[40].Value = model.C_salesid;
            parameters[41].Value = model.C_id;
            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            #endregion
        }

        /// <summary>
        /// 更新质量异议赔付金额与赔付日期
        /// </summary>
        /// <param name="N_AMOUNT"></param>
        /// <param name="DATE"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateMoneyAndDate(string N_AMOUNT, string DATE, string ID)
        {
            string strSql = $"UPDATE TMQ_QUA_MAIN SET N_AMOUNT={N_AMOUNT},D_COMPENSATION_DT=TO_DATE('{DATE}','yyyy-mm-dd hh24:mi:ss') WHERE C_ID='{ID}'";
            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }

        public bool Submit(Mod_TMQ_QUA_MAIN model)
        {
            #region 更新数据
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"update TMQ_QUA_MAIN set                             
                            n_status=:n_status");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                            new OracleParameter(":n_status", OracleDbType.Decimal,1),
                                new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};

            parameters[0].Value = model.N_status;
            parameters[1].Value = model.C_id;
            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            #endregion
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  TMQ_QUA_MAIN set  N_STATUS=-2 ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;
            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string C_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  TMQ_QUA_MAIN set  N_STATUS=-2  ");
            strSql.Append(" where C_ID in (" + C_IDlist + ")  ");
            int rows = DbHelperOra.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMQ_QUA_MAIN GetModel(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select m.C_ID,m.C_NO,c_area_id, area.c_detailname areaname,c_distributor, c_directuser, c_contact, c_con_phone, c_grd, 
c_prod_use, d_ship_start_dt, d_ship_end_dt, n_object_count_wgt, c_object_content, c_tech_desc, c_site_survey_content, n_parent_qua, 
n_quest_qua, n_middle_qua, n_else_qua, c_dept, c_quality_dept, c_technology, c_qt, c_remark, c_cust_making, d_cust_making_dt, 
c_quality_result, c_objection_type, c_ourreasons, d_feedback_area, c_effect_valid, c_precc_result, n_amount, d_compensation_dt, 
c_state, N_CYCLE, c_month_average, c_salesman,c_salesid, n_flag, m.c_emp_id, m.c_emp_name, m.n_status, m.c_crt_id,D_EMP_DT,m.D_CRT_DT, decode(n_flag,1,'质量异议反馈',2,'客户信息反馈',3,'委托检验') n_flagname
, decode(m.n_status,-1,'未提交',0,'待处理',1,'审核中',2,'已完成') n_statusname from TMQ_QUA_MAIN m
left join (select t.* ,t.rowid from  ts_dic t where t.c_typecode ='ConArea' and t.n_status=1) area
on m.c_area_id=area.c_detailcode ");
            strSql.Append(" where m.C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;
            Mod_TMQ_QUA_MAIN model = new Mod_TMQ_QUA_MAIN();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMQ_QUA_MAIN DataRowToModel(DataRow row)
        {
            Mod_TMQ_QUA_MAIN model = new Mod_TMQ_QUA_MAIN();
            if (row != null)
            {
                #region 转换实体
                if (row["C_ID"] != null)
                {
                    model.C_id = row["C_ID"].ToString();
                }
                if (row["C_NO"] != null)
                {
                    model.C_No = row["C_NO"].ToString();
                }
                if (row["c_area_id"] != null)
                {
                    model.C_area_id = row["c_area_id"].ToString();
                }
                if (row["c_distributor"] != null)
                {
                    model.C_distributor = row["c_distributor"].ToString();
                }
                if (row["c_directuser"] != null)
                {
                    model.C_directuser = row["c_directuser"].ToString();
                }
                if (row["areaname"] != null)
                {
                    model.C_areaname = row["areaname"].ToString();
                }

                if (row["n_flagname"] != null)
                {
                    model.N_flagname = row["n_flagname"].ToString();
                }
                if (row["n_statusname"] != null)
                {
                    model.N_statusname = row["n_statusname"].ToString();
                }
                if (row["c_contact"] != null)
                {
                    model.C_contact = row["c_contact"].ToString();
                }
                if (row["c_con_phone"] != null)
                {
                    model.C_con_phone = row["c_con_phone"].ToString();
                }
                if (row["c_grd"] != null)
                {
                    model.C_grd = row["c_grd"].ToString();
                }
                if (row["c_prod_use"] != null)
                {
                    model.C_prod_use = row["c_prod_use"].ToString();
                }
                if (row["d_ship_start_dt"] != null && row["d_ship_start_dt"].ToString() != "")
                {
                    model.D_ship_start_dt = DateTime.Parse(row["d_ship_start_dt"].ToString());
                }
                if (row["d_ship_end_dt"] != null && row["d_ship_end_dt"].ToString() != "")
                {
                    model.D_ship_end_dt = DateTime.Parse(row["d_ship_end_dt"].ToString());
                }
                if (row["n_object_count_wgt"] != null && row["n_object_count_wgt"].ToString() != "")
                {
                    model.N_object_count_wgt = decimal.Parse(row["n_object_count_wgt"].ToString());
                }
                if (row["c_object_content"] != null)
                {
                    model.C_object_content = row["c_object_content"].ToString();
                }
                if (row["c_tech_desc"] != null)
                {
                    model.C_tech_desc = row["c_tech_desc"].ToString();
                }
                if (row["c_site_survey_content"] != null)
                {
                    model.C_site_survey_content = row["c_site_survey_content"].ToString();
                }
                if (row["n_parent_qua"] != null && row["n_parent_qua"].ToString() != "")
                {
                    model.N_parent_qua = decimal.Parse(row["n_parent_qua"].ToString());
                }
                if (row["n_quest_qua"] != null && row["n_quest_qua"].ToString() != "")
                {
                    model.N_quest_qua = decimal.Parse(row["n_quest_qua"].ToString());
                }
                if (row["n_middle_qua"] != null && row["n_middle_qua"].ToString() != "")
                {
                    model.N_middle_qua = decimal.Parse(row["n_middle_qua"].ToString());
                }
                if (row["n_else_qua"] != null && row["n_else_qua"].ToString() != "")
                {
                    model.N_else_qua = decimal.Parse(row["n_else_qua"].ToString());
                }
                if (row["c_dept"] != null)
                {
                    model.C_dept = row["c_dept"].ToString();
                }
                if (row["c_quality_dept"] != null)
                {
                    model.C_quality_dept = row["c_quality_dept"].ToString();
                }
                if (row["c_technology"] != null)
                {
                    model.C_technology = row["c_technology"].ToString();
                }
                if (row["c_qt"] != null)
                {
                    model.C_qt = row["c_qt"].ToString();
                }
                if (row["c_remark"] != null)
                {
                    model.C_remark = row["c_remark"].ToString();
                }
                if (row["c_cust_making"] != null)
                {
                    model.C_cust_making = row["c_cust_making"].ToString();
                }
                if (row["d_cust_making_dt"] != null && row["d_cust_making_dt"].ToString() != "")
                {
                    model.D_cust_making_dt = DateTime.Parse(row["d_cust_making_dt"].ToString());
                }
                if (row["c_quality_result"] != null)
                {
                    model.C_quality_result = row["c_quality_result"].ToString();
                }
                if (row["c_objection_type"] != null)
                {
                    model.C_objection_type = row["c_objection_type"].ToString();
                }
                if (row["c_ourreasons"] != null)
                {
                    model.C_ourreasons = row["c_ourreasons"].ToString();
                }
                if (row["d_feedback_area"] != null && row["d_feedback_area"].ToString() != "")
                {
                    model.D_feedback_area = DateTime.Parse(row["d_feedback_area"].ToString());
                }
                if (row["c_effect_valid"] != null)
                {
                    model.C_effect_valid = row["c_effect_valid"].ToString();
                }
                if (row["c_precc_result"] != null)
                {
                    model.C_precc_result = row["c_precc_result"].ToString();
                }
                if (row["n_amount"] != null && row["n_amount"].ToString() != "")
                {
                    model.N_amount = decimal.Parse(row["n_amount"].ToString());
                }
                if (row["d_compensation_dt"] != null && row["d_compensation_dt"].ToString() != "")
                {
                    model.D_compensation_dt = DateTime.Parse(row["d_compensation_dt"].ToString());
                }
                if (row["c_state"] != null)
                {
                    model.C_state = row["c_state"].ToString();
                }
                if (row["N_CYCLE"] != null && row["N_CYCLE"].ToString() != "")
                {
                    model.N_cycle = decimal.Parse(row["N_CYCLE"].ToString());
                }
                if (row["c_month_average"] != null)
                {
                    model.C_month_average = row["c_month_average"].ToString();
                }
                if (row["c_salesman"] != null)
                {
                    model.C_salesman = row["c_salesman"].ToString();
                }
                if (row["c_salesid"] != null)
                {
                    model.C_salesid = row["c_salesid"].ToString();
                }
                if (row["n_flag"] != null && row["n_flag"].ToString() != "")
                {
                    model.N_flag = decimal.Parse(row["n_flag"].ToString());
                }
                if (row["c_emp_id"] != null)
                {
                    model.C_emp_id = row["c_emp_id"].ToString();
                }
                if (row["c_emp_name"] != null)
                {
                    model.C_emp_name = row["c_emp_name"].ToString();
                }
                if (row["n_status"] != null && row["n_status"].ToString() != "")
                {
                    model.N_status = decimal.Parse(row["n_status"].ToString());
                }
                if (row["c_crt_id"] != null)
                {
                    model.C_crt_id = row["c_crt_id"].ToString();
                }
                if (row["D_EMP_DT"] != null && row["D_EMP_DT"].ToString() != "")
                {
                    model.D_emp_dt = DateTime.Parse(row["D_EMP_DT"].ToString());
                }
                if (row["D_CRT_DT"] != null && row["D_CRT_DT"].ToString() != "")
                {
                    model.D_crt_dt = DateTime.Parse(row["D_CRT_DT"].ToString());
                }
                #endregion
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select m.C_ID,
       m.C_NO,
       c_area_id,
       c_distributor,
       c_directuser,
       c_contact,
       c_con_phone,
       c_grd,
       c_prod_use,
       d_ship_start_dt,
       d_ship_end_dt,
       n_object_count_wgt,
       c_object_content,
       c_tech_desc,
       c_site_survey_content,
       n_parent_qua,
       n_quest_qua,
       n_middle_qua,
       n_else_qua,
       c_dept,
       c_quality_dept,
       c_technology,
       c_qt,
       c_remark,
       c_cust_making,
       d_cust_making_dt,
       c_quality_result,
       c_objection_type,
       c_ourreasons,
       d_feedback_area,
       c_effect_valid,
       c_precc_result,
       n_amount,
       d_compensation_dt,
       c_state,
       N_CYCLE,
       c_month_average,
       c_salesman,
       n_flag,
       m.c_emp_id,
       m.c_emp_name,
       m.n_status,
       m.c_crt_id,
       D_EMP_DT,
       m.D_CRT_DT,
       decode(n_flag, 1, '质量异议反馈', 2, '客户信息反馈', 3, '委托检验') N_FLAGNAME,
       decode(m.n_status,
              -1,
              '未提交',
              0,
              '待处理',
              1,
              '审核中',
              2,
              '已完成') N_STATUSNAME
  from TMQ_QUA_MAIN m

 where m.N_STATUS > -2
 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            strSql.Append(" order by m.D_CRT_DT desc ");
            var dt = DbHelperOra.Query(strSql.ToString()).Tables[0];

            return dt;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddItem(Mod_TMQ_QUA_ITEM model)
        {
            #region 新增字表
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tmq_qua_item(");
            strSql.Append(@" c_id, 
                           c_parentid, 
                           c_brand_name, 
                           c_spec, 
                           c_batch, 
                           n_shippedqty, 
                           n_object_wgt, 
                           c_stl_code, 
                           c_emp_id, 
                           c_emp_name, 
                           n_status, 
                           c_crt_id)values (           
                          :c_id, 
                          :c_parentid, 
                          :c_brand_name, 
                          :c_spec, 
                          :c_batch, 
                          :n_shippedqty, 
                          :n_object_wgt, 
                          :c_stl_code, 
                          :c_emp_id, 
                          :c_emp_name, 
                          :n_status, 
                          :c_crt_id)");
            OracleParameter[] parameters = {
                            new OracleParameter(":c_id", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_parentid", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_brand_name", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_spec", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_batch", OracleDbType.Varchar2,100),
                            new OracleParameter(":n_shippedqty", OracleDbType.Decimal,15),
                            new OracleParameter(":n_object_wgt", OracleDbType.Decimal,15),
                            new OracleParameter(":c_stl_code", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_emp_id", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_emp_name", OracleDbType.Varchar2,100),
                            new OracleParameter(":n_status", OracleDbType.Decimal,1),
                            new OracleParameter(":c_crt_id", OracleDbType.Varchar2,100)
                         };
            parameters[0].Value = model.C_id;
            parameters[1].Value = model.C_parentid;
            parameters[2].Value = model.C_brand_name;
            parameters[3].Value = model.C_spec;
            parameters[4].Value = model.C_batch;
            parameters[5].Value = model.N_shippedqty;
            parameters[6].Value = model.N_object_wgt;
            parameters[7].Value = model.C_stl_code;
            parameters[8].Value = model.C_emp_id;
            parameters[9].Value = model.C_emp_name;
            parameters[10].Value = model.N_status;
            parameters[11].Value = model.C_crt_id;
            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            #endregion
        }

        public bool UpdateItem(Mod_TMQ_QUA_ITEM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMQ_QUA_ITEM set ");
            strSql.Append("C_PARENTID=:C_PARENTID,");
            strSql.Append("C_BRAND_NAME=:C_BRAND_NAME,");
            strSql.Append("C_SPEC=:C_SPEC,");
            strSql.Append("C_BATCH=:C_BATCH,");
            strSql.Append("N_SHIPPEDQTY=:N_SHIPPEDQTY,");
            strSql.Append("N_OBJECT_WGT=:N_OBJECT_WGT,");
            strSql.Append("C_STL_CODE=:C_STL_CODE,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append(" where C_ID=:C_ID and C_PARENTID=:C_PARENTID and C_BRAND_NAME=:C_BRAND_NAME and C_SPEC=:C_SPEC and C_BATCH=:C_BATCH and N_SHIPPEDQTY=:N_SHIPPEDQTY and N_OBJECT_WGT=:N_OBJECT_WGT and C_STL_CODE=:C_STL_CODE and C_EMP_ID=:C_EMP_ID and C_EMP_NAME=:C_EMP_NAME  ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_PARENTID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BRAND_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_SHIPPEDQTY", OracleDbType.Decimal,15),
                    new OracleParameter(":N_OBJECT_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_STL_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_parentid;
            parameters[1].Value = model.C_brand_name;
            parameters[2].Value = model.C_spec;
            parameters[3].Value = model.C_batch;
            parameters[4].Value = model.N_shippedqty;
            parameters[5].Value = model.N_object_wgt;
            parameters[6].Value = model.C_stl_code;
            parameters[7].Value = model.C_emp_id;
            parameters[8].Value = model.C_emp_name;
            parameters[9].Value = model.C_id;
            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddListItem(List<Mod_TMQ_QUA_ITEM> list, string parentID)
        {
            try
            {
                TransactionHelper.BeginTransaction();
                StringBuilder strDelSql = new StringBuilder();
                strDelSql.Append("delete from   TMQ_QUA_ITEM   ");
                strDelSql.Append(" where C_PARENTID='" + parentID + "'");
                if (TransactionHelper.ExecuteSql(strDelSql.ToString()) < 0)
                {
                    TransactionHelper.RollBack();
                }
                foreach (var model in list)
                {
                    #region 新增功能
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into tmq_qua_item(");
                    strSql.Append(@" c_id, 
                           c_parentid, 
                           c_brand_name, 
                           c_spec, 
                           c_batch, 
                           n_shippedqty, 
                           n_object_wgt, 
                           c_stl_code, 
                           c_emp_id, 
                           c_emp_name, 
                           c_crt_id) values (:c_id, 
                          :c_parentid, 
                          :c_brand_name, 
                          :c_spec, 
                          :c_batch, 
                          :n_shippedqty, 
                          :n_object_wgt, 
                          :c_stl_code, 
                          :c_emp_id, 
                          :c_emp_name, :c_crt_id)");

                    OracleParameter[] parameters = {
                            new OracleParameter(":c_id", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_parentid", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_brand_name", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_spec", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_batch", OracleDbType.Varchar2,100),
                            new OracleParameter(":n_shippedqty", OracleDbType.Decimal,15),
                            new OracleParameter(":n_object_wgt", OracleDbType.Decimal,15),
                            new OracleParameter(":c_stl_code", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_emp_id", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_emp_name", OracleDbType.Varchar2,100),
                            new OracleParameter(":c_crt_id", OracleDbType.Varchar2,100)
                         };
                    parameters[0].Value = model.C_id;
                    parameters[1].Value = model.C_parentid;
                    parameters[2].Value = model.C_brand_name;
                    parameters[3].Value = model.C_spec;
                    parameters[4].Value = model.C_batch;
                    parameters[5].Value = model.N_shippedqty;
                    parameters[6].Value = model.N_object_wgt;
                    parameters[7].Value = model.C_stl_code;
                    parameters[8].Value = model.C_emp_id;
                    parameters[9].Value = model.C_emp_name;
                    parameters[10].Value = model.C_crt_id;
                    #endregion
                    TransactionHelper.ExecuteSql(strSql.ToString(), parameters);
                }
                TransactionHelper.Commit();
                return true;
            }
            catch (Exception ex)
            {
                TransactionHelper.RollBack();
                return false;
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteItem(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from   TMQ_QUA_ITEM   ");
            strSql.Append(" where C_ID='" + ID + "'");
            int rows = DbHelperOra.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetItemList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select  c_id, c_parentid, c_brand_name, c_spec, c_batch, n_shippedqty, n_object_wgt, c_stl_code, 
                           c_emp_id, c_emp_name, n_status, c_emp_dt, c_crt_id, d_crt_dt from tmq_qua_item where 1=1  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 更新异议数量合计
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public bool UpdateSumWgt(string parentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select  decode(sum(N_OBJECT_WGT),null,0,sum(N_OBJECT_WGT)) SumWgt from tmq_qua_item where C_PARENTID='" + parentId + "' ");
            var sumWgt = DbHelperOra.Query(strSql.ToString()).Tables[0].Rows[0]["SumWgt"].ToString();
            string sql = "update tmq_qua_main set N_OBJECT_COUNT_WGT=" + sumWgt + "  where c_id='" + parentId + "'";
            if (DbHelperOra.ExecuteSql(sql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region  //质量异议审批
        /// <summary>
        /// 质量异议审批
        /// </summary>
        /// <param name="modFile">文件</param>
        /// <param name="modNextEmp">步骤操作人</param>
        /// <returns></returns>
        public bool ApproveQua(Mod_TMF_FILEINFO modFile, Mod_TMB_FILE_NEXT_EMP modNextEmp)
        {
            ArrayList arraySql = new ArrayList();

            #region //文件
            string ID = Guid.NewGuid().ToString("N");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMF_FILEINFO(");
            strSql.Append("C_ID,");
            strSql.Append("C_FLOW_ID,");
            strSql.Append("C_EMP_ID,");
            strSql.Append("C_TITLE,");
            strSql.Append("C_CONTENT,");
            strSql.Append("N_TYPE,");
            strSql.Append("C_TASK_ID,");
            strSql.Append("C_STEP_ID");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + ID + "',");
            strSql.Append("'" + modFile.C_FLOW_ID + "',");
            strSql.Append("'" + modFile.C_EMP_ID + "',");
            strSql.Append("'" + modFile.C_TITLE + "',");
            strSql.Append("'" + modFile.C_CONTENT + "',");
            strSql.Append("" + modFile.N_TYPE + ",");
            strSql.Append("'" + modFile.C_TASK_ID + "',");
            strSql.Append("'" + modFile.C_STEP_ID + "'");
            strSql.Append(")");
            arraySql.Add(strSql.ToString());
            #endregion

            #region //更新质量异议反馈
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("update TMQ_QUA_MAIN set ");
            strSql2.Append("C_FLOWID='" + modFile.C_FLOW_ID + "', ");
            strSql2.Append("N_STATUS=1, ");//1审批中         
            strSql2.Append("C_CUST_MAKING='" + modFile.C_EMP_ID + "',");//制单人
            strSql2.Append("D_CUST_MAKING_DT=to_date('" + DateTime.Now + "','yyyy-mm-dd hh24:mi:ss'),");//制单时间
            strSql2.Append("C_APPROVEID='" + modNextEmp.C_NEXT_EMP_ID + "' ");//审批人
            strSql2.Append(" where C_ID='" + modFile.C_TASK_ID + "' ");
            arraySql.Add(strSql2.ToString());
            #endregion

            #region//步骤操作人
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("insert into TMB_FILE_NEXT_EMP(");
            strSql3.Append("C_FILE_ID,");
            strSql3.Append("C_NEXT_EMP_ID,");
            strSql3.Append("C_STEP_ID");
            strSql3.Append(")");
            strSql3.Append(" values (");
            strSql3.Append("'" + ID + "',");
            strSql3.Append("'" + modNextEmp.C_NEXT_EMP_ID + "',");
            strSql3.Append("'" + modNextEmp.C_STEP_ID + "'");
            strSql3.Append(")");
            arraySql.Add(strSql3.ToString());
            #endregion

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        #endregion

        public DataSet ListArea()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select t.* from ts_dic t where t.c_typecode = 'ConArea' AND T.C_DETAILCODE NOT IN('7','6','10') and t.n_status=1 order by t.c_index asc   ");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 更新质量批号物料编码/生产日期
        /// </summary>
        public void UpdateMatCode()
        {          
            DbHelperOra.RunProcedure("pkg_zhiliang.p_zhiliang_mat", new OracleParameter[] { });
        }
    }
}
