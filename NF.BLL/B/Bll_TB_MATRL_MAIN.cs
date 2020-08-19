using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 物料主数据表
    /// </summary>
    public partial class Bll_TB_MATRL_MAIN
    {
        private readonly Dal_TB_MATRL_MAIN dal = new Dal_TB_MATRL_MAIN();
        public Bll_TB_MATRL_MAIN()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            return dal.Exists(C_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TB_MATRL_MAIN model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TB_MATRL_MAIN model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string C_ID)
        {

            return dal.Delete(C_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_IDlist)
        {
            return dal.DeleteList(C_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TB_MATRL_MAIN GetModel(string C_ID)
        {

            return dal.GetModel(C_ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="C_PK_INVMANDOC">存货管理档案主键</param>
        /// <returns></returns>
        public Mod_TB_MATRL_MAIN GetMatModel(string C_PK_INVMANDOC)
        {
            return dal.GetMatModel(C_PK_INVMANDOC);
        }

        /// <summary>
        /// 获取大类钢种
        /// </summary>
        public DataSet GetMaxGRD()
        {
            return dal.GetMaxGRD();
        }


        /// <summary>
        /// 获取物料数据列表
        /// </summary>
        /// <param name="matName">物料名称</param>
        /// <param name="matCode">物料编码</param>
        /// <param name="matSTLGRD">钢种</param>
        /// <param name="matSPEC">规格</param>
        /// <param name="matClass">物料组编码</param>
        /// <returns></returns>
        public DataSet GetList(string matName, string matCode, string matSTLGRD, string matSPEC, string groupCode, string groupName)
        {
            return dal.GetList(matName, matCode, matSTLGRD, matSPEC, groupCode, groupName);
        }

        /// <summary>
        /// 批量物料编码查询
        /// </summary>
        /// <param name="matcode"></param>
        /// <returns></returns>
        public DataSet GetList2(string matcode)
        {
            return dal.GetList2(matcode);
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TB_MATRL_MAIN> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TB_MATRL_MAIN> DataTableToList(DataTable dt)
        {
            List<Mod_TB_MATRL_MAIN> modelList = new List<Mod_TB_MATRL_MAIN>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TB_MATRL_MAIN model;
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string matCode, string STLGRD, string SPEC)
        {
            return dal.GetRecordCount(matCode, STLGRD, SPEC);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(int pageSize, int startIndex, string matCode, string STLGRD, string SPEC)
        {
            return dal.GetListByPage(pageSize, startIndex, matCode, STLGRD, SPEC);
        }
        #endregion  BasicMethod


        #region 自定义

        #region //客户自由项匹配操作

        #region //钢种
        /// <summary>
        /// 获取钢种
        /// </summary>
        public DataSet GetStlGrd(string stlgrd)
        {
            return dal.GetStlGrd(stlgrd);
        }
        #endregion

        #region  //执行标准
        /// <summary>
        /// 获取执行标准
        /// </summary>
        /// <param name="stlGrd"></param>
        /// <returns></returns>
        public DataSet GetSTD(string stlGrd)
        {
            return dal.GetSTD(stlGrd);
        }
        #endregion

        #region//自由项1自由项2组合
        /// <summary>
        /// 获取自由项
        /// </summary>
        /// <param name="stlgrd">钢种</param>
        /// <param name="std">执行标准</param>
        /// <returns></returns>
        public DataSet GetFree(string stlgrd, string std)
        {
            return dal.GetFree(stlgrd, std);
        }

        /// <summary>
        /// 获取自由项
        /// </summary>
        /// <param name="stlgrd">钢种</param>
        /// <param name="std">执行标准</param>
        /// <returns></returns>
        public DataSet GetFree2(string stlgrd, string std)
        {
            return dal.GetFree2(stlgrd, std);
        }
        #endregion

        #region 自由项1和自由项2
        /// <summary>
        /// 自由项1
        /// </summary>
        /// <param name="stlGrd"></param>
        /// <returns></returns>
        public DataSet GetZYX1(string stlGrd)
        {
            return dal.GetZYX1(stlGrd);
        }
        /// <summary>
        /// 自由项2
        /// </summary>
        /// <param name="stlGrd"></param>
        /// <returns></returns>
        public DataSet GetZYX2(string stlGrd)
        {
            return dal.GetZYX2(stlGrd);
        }
        #endregion

        #region //客户自由项添加
        /// <summary>
        /// 添加客户自由匹配项
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool InsertFree(Mod_TB_STD_CONFIG mod)
        {
            return dal.InsertFree(mod);

        }
        #endregion

        #endregion


        #region //物料组
        /// <summary>
        /// 获取物料组
        /// </summary>
        /// <returns></returns>
        public DataSet GetMatrlGroup()
        {
            return dal.GetMatrlGroup();
        }
        #endregion

        #region //线材物料组
        /// <summary>
        /// 获取物料组
        /// </summary>
        /// <returns></returns>
        public DataSet GetXCMatrlGroup()
        {
            return dal.GetXCMatrlGroup();
        }
        #endregion



        #region//预测订单

        /// <summary>
        /// 预测订单产品查询
        /// </summary>
        /// <param name="matCode">物流编码</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <returns></returns>
        public DataSet GetStlGrd(string matCode, string stlGrd, string spec)
        {
            return dal.GetStlGrd(matCode, stlGrd, spec);
        }


        /// <summary>
        /// 预测订单钢坯产品查询
        /// </summary>
        /// <param name="matCode">物流编码</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <returns></returns>
        public DataSet GetGP_StlGrd(string matCode, string stlGrd, string spec)
        {
            return dal.GetGP_StlGrd(matCode, stlGrd, spec);
        }
        #endregion

        #region 客户产品

        public DataSet Get_PROD_KIND(string custNo)
        {
            return dal.Get_PROD_KIND(custNo);
        }
        /// <summary>
        /// 获取钢种小类
        /// </summary>
        /// <param name="custNo"></param>
        /// <param name="C_PROD_KIND"></param>
        /// <returns></returns>
        public DataSet Get_PROD_NAME(string custNo, string C_PROD_KIND)
        {
            return dal.Get_PROD_NAME(custNo, C_PROD_KIND);
        }

        /// <summary>
        /// 获取小类钢种
        /// </summary>
        /// <param name="custNo"></param>
        /// <param name="C_PROD_KIND"></param>
        /// <param name="C_PROD_NAME"></param>
        /// <returns></returns>
        public DataSet Get_PROD_NAME_StlGrd(string custNo, string C_PROD_KIND, string C_PROD_NAME)
        {
            return dal.Get_PROD_NAME_StlGrd(custNo, C_PROD_KIND, C_PROD_NAME);
        }

        /// <summary>
        /// 手机端获取客户下单钢种
        /// </summary>
        /// <param name="custNo"></param>
        /// <param name="matCode"></param>
        /// <param name="stlGrd"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        public DataSet GetCustStlGrd(string custNo, string matCode, string stlGrd, string spec, string custTechProt, string stdCode)
        {
            return dal.GetCustStlGrd(custNo, matCode, stlGrd, spec, custTechProt, stdCode);
        }
        /// <summary>
        /// 获取客户下单钢种
        /// </summary>
        /// <param name="custNo"></param>
        /// <param name="matCode"></param>
        /// <param name="stlGrd"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        public DataSet GetCustStlGrd(string custNo, string matCode, string stlGrd, string spec)
        {
            return dal.GetCustStlGrd(custNo, matCode, stlGrd, spec);
        }

        /// <summary>
        /// 根据物料编码批量查询
        /// </summary>
        /// <param name="custNo"></param>
        /// <param name="matCode"></param>
        /// <returns></returns>
        public DataSet GetCustStlGrd(string custNo, string matCode)
        {
            return dal.GetCustStlGrd(custNo, matCode);
        }

        /// <summary>
        /// 获取客户下单钢种
        /// </summary>
        /// <param name="prodKind"></param>
        /// <param name="prodName"></param>
        /// <param name="custNo"></param>
        /// <param name="matCode"></param>
        /// <param name="stlGrd"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        public DataSet GetCust_StlGrd(string prodKind, string prodName, string custNo, string matCode, string stlGrd, string spec)
        {
            return dal.GetCust_StlGrd(prodKind, prodName, custNo, matCode, stlGrd, spec);
        }

        /// <summary>
        /// 客户订单钢坯产品查询
        /// </summary>
        /// <param name="matCode">物流编码</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <returns></returns>
        public DataSet GetCustStlGrd_GP(string custNo, string matCode, string stlGrd, string spec)
        {
            return dal.GetCustStlGrd_GP(custNo, matCode, stlGrd, spec);
        }

        /// <summary>
        /// 客户订单钢坯产品查询
        /// </summary>
        /// <param name="matCode">物流编码</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <returns></returns>
        public DataSet GetCustStlGrd_GP(string prodKind, string prodName, string custNo, string matCode, string stlGrd, string spec)
        {
            return dal.GetCustStlGrd_GP(prodKind, prodName, custNo, matCode, stlGrd, spec);
        }


        /// <summary>
        /// 客户副产品查询
        /// </summary>
        /// <returns></returns>
        public DataSet GetCustStlGrd_FCP(string matCode, string matName)
        {
            return dal.GetCustStlGrd_FCP(matCode, matName);
        }

        #endregion


        #region //头尾材

        /// <summary>
        /// 合同订单头尾材物料编码批量查询
        /// </summary>
        /// <param name="matCode"></param>
        /// <returns></returns>
        public DataSet GetTWC_StlGrd(string matCode)
        {
            return dal.GetTWC_StlGrd(matCode);
        }


        /// <summary>
        /// 合同订单头尾材物料
        /// </summary>
        /// <param name="matCode"></param>
        /// <returns></returns>
        public DataSet GetTWC_StlGrd(string matCode, string stlGrd, string spec)
        {

            return dal.GetTWC_StlGrd(matCode, stlGrd, spec);
        }


        #endregion


        /// <summary>
        /// 获取物料数据列表
        /// </summary>
        /// <param name="stlGrd">钢种</param>
        /// <param name="specMin">规格最小值</param>
        /// <param name="specMax">规格最大值</param>
        /// <param name="matClass"></param>
        /// <returns></returns>
        public DataSet GetMatList(string stlGrd, string specMin, string specMax, string matClass, string matType)
        {
            return dal.GetMatList(stlGrd, specMin, specMax, matClass, matType);
        }

        /// <summary>
        /// 获取物料组数据
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        public DataSet GetMatGroup(string groupCode)
        {
            return dal.GetMatGroup(groupCode);
        }

        /// <summary>
        /// 钢种规格执行标准检查
        /// </summary>
        /// <param name="stlgrd">钢种</param>
        /// <param name="stdcode">执行标准</param>
        /// <param name="spec">规格</param>
        /// <returns></returns>
        public DataSet GetStd_Grd_Spec(string stlgrd, string stdcode, string spec)
        {
            return dal.GetStd_Grd_Spec(stlgrd, stdcode, spec);
        }

        #endregion

    }
}

