using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 轧钢实绩
    /// </summary>
    public partial class Bll_TRC_ROLL_PRODCUT
    {
        private readonly Dal_TRC_ROLL_PRODCUT dal = new Dal_TRC_ROLL_PRODCUT();
        public Bll_TRC_ROLL_PRODCUT()
        { }
        #region  BasicMethod

        /// <summary>
        /// 执行钢坯/线材库存类型type
        /// </summary>
        public void ExeProc()
        {
            dal.ExeProc();
        }


        #region 获取钢坯产量
        /// <summary>
        /// 获取钢坯产量
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetProdSlab(string date)
        {
            return dal.GetProdSlab(date);
        }
        #endregion

        #region 获取线材产量
        /// <summary>
        /// 获取线材产量
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetProdRoll(string date)
        {
            return dal.GetProdRoll(date);
        }
        #endregion

        #region //获取汽运/火运线材销量
        /// <summary>
        /// 获取汽运/火运线材销量
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetSaleShip(string date)
        {
            return dal.GetSaleShip(date);
        }
        #endregion

        #region //获取线材销量
        public DataSet GetSaleRoll(string date)
        {
            return dal.GetSaleRoll(date);
        }
        #endregion

        #region //获取钢坯销量
        /// <summary>
        /// 获取钢坯销量
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetSaleSlab(string date)
        {
            return dal.GetSaleSlab(date);
        }
        #endregion

        #region //远程质证书打印

        public DataSet GetZZSList(string fyd, string zsh)
        {
            return dal.GetZZSList(fyd, zsh);
        }

        public string GetZZSPrintRowNum(string stlgrd, string std)
        {
            return dal.GetZZSPrintRowNum(stlgrd, std);
        }
        public string GetZZSType(string stlgrd, string std)
        {
            return dal.GetZZSType(stlgrd, std);
        }

        /// <summary>
        /// 获取出库发运单
        /// </summary>
        /// <param name="ch">车号</param>
        /// <param name="custName">客户名称</param>
        /// <param name="fyd">发运单号</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="batch">批号</param>
        /// <param name="startDate">出库开始时间</param>
        /// <param name="endDate">出库结束时间</param>
        /// <param name="ww">委外</param>
        /// <param name="type">8线材，6钢坯</param>
        /// <returns></returns>

        public DataSet GetZZS(string ch, string custName, string fyd, string stlGrd, string spec, string batch, string startDate, string endDate, string ww, string type, string stove, string printstate)
        {
            return dal.GetZZS(ch, custName, fyd, stlGrd, spec, batch, startDate, endDate, ww, type, stove, printstate);
        }



        public DataSet GetCustStd_JH(string stdCode, string stlGrd, string zyx1, string zyx2)
        {
            return dal.GetCustStd_JH(stdCode, stlGrd, zyx1, zyx2);
        }

        public DataSet GetCustStd_JH(string stdCode, string stlGrd, string techProt, string zyx1, string zyx2)
        {
            return dal.GetCustStd_JH(stdCode, stlGrd, techProt, zyx1, zyx2);
        }

        public bool ExistsZZS(string fyd, string batch)
        {
            return dal.ExistsZZS(fyd, batch);
        }
        public bool ExistsZZS(string fyd, string batch, string stove)
        {
            return dal.ExistsZZS(fyd, batch, stove);
        }

        #endregion

        #region //添加远程质证书
        public bool InsertZZS(Mod_TQC_ZZS_INFO item)
        {
            return dal.InsertZZS(item);
        }
        #endregion

        #region //更新远程客户打印次数


        /// <summary>
        /// 更新证书号PDF
        /// </summary>
        /// <param name="fyd"></param>
        /// <param name="zsh"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool UpdateZZSPDF(string fyd, string zsh, string path)
        {
            return dal.UpdateZZSPDF(fyd, zsh, path);
        }
        public bool UpdateZZSPrint(string fyd, string zsh)
        {
            return dal.UpdateZZSPrint(fyd, zsh);
        }
        public bool UpdateZZSPrint(string fyd, string zsh, string emp)
        {
            return dal.UpdateZZSPrint(fyd, zsh, emp);
        }
        #endregion

        #region //获取证书号打印次数

        public int GetPrintNum(string zsh)
        {
            return dal.GetPrintNum(zsh);
        }
        #endregion

        #region //客户获取自己远程打印信息

        public DataSet GetCustZZS(string fyd, string zsh, string batch, string ch, string conNO, string ckkssj, string ckjssj, string custNo, string type)
        {
            return dal.GetCustZZS(fyd, zsh, batch, ch, conNO, ckkssj, ckjssj, custNo, type);
        }
        #endregion


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
        public bool Add(Mod_TRC_ROLL_PRODCUT model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TRC_ROLL_PRODCUT model)
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
        public Mod_TRC_ROLL_PRODCUT GetModel(string C_ID)
        {

            return dal.GetModel(C_ID);
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
        public List<Mod_TRC_ROLL_PRODCUT> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TRC_ROLL_PRODCUT> DataTableToList(DataTable dt)
        {
            List<Mod_TRC_ROLL_PRODCUT> modelList = new List<Mod_TRC_ROLL_PRODCUT>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TRC_ROLL_PRODCUT model;
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
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod



        #region  ExtensionMethod

        /// <summary>
        /// 订单挂单
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="C_ORDER_NO">订单号</param>
        /// <param name="C_CON_NO">合同号</param>
        /// <param name="C_CUST_NO">客户编码</param>
        /// <param name="C_CUST_NAME">客户名称</param>
        /// <param name="C_ISFREE">是否自由状态</param>
        public bool UpdateMatch(string id, string C_ORDER_NO, string C_CON_NO, string C_CUST_NO, string C_CUST_NAME, string C_ISFREE)
        {
            return dal.UpdateMatch(id, C_ORDER_NO, C_CON_NO, C_CUST_NO, C_CUST_NAME, C_ISFREE);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="batchno">批次号</param>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <param name="zldj">质量等级</param>
        /// <param name="salearea">销售区域</param>
        /// <param name="custname">客户名称</param>
        /// <returns></returns>
        public int GetRecordCount(string batchno, string ckcode, string stlgrd, string spec, string matcode, string zldj, string salearea, string custname)
        {
            return dal.GetRecordCount(batchno, ckcode, stlgrd, spec, matcode, zldj, salearea, custname);
        }

        /// <summary>
        /// 储运发运单仓库查询
        /// </summary>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="fydID">发运单明细主键</param>
        /// <returns></returns>
        public DataSet GetCKRollProdcut(string ckcode, string fydID)
        {
            return dal.GetCKRollProdcut(ckcode, fydID);
        }

        /// <summary>
        /// 根据订单查询线材仓库
        /// </summary>
        /// <param name="orderID">发运单明细主键</param>
        /// <returns></returns>
        public DataSet GetCKRollProdcut(string orderID)
        {
            return dal.GetCKRollProdcut(orderID);
        }

        /// <summary>
        /// 客户库存查询
        /// </summary>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="conno">合同号</param>
        /// <param name="custname">客户名称</param>
        /// <returns></returns>
        public DataSet GetCustRollProc(string stlgrd, string spec, string conno, string custname, string area)
        {
            return dal.GetCustRollProc(stlgrd, spec, conno, custname, area);
        }

        /// <summary>
        /// 获取线材超期库存
        /// </summary>
        /// <param name="batchno">批次号</param>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <param name="zldj">质量等级</param>
        /// <param name="salearea">销售区域</param>
        /// <param name="minarea">小区域</param>
        /// <param name="custname">客户名称</param>
        /// <param name="sckssj">生产开始时间</param>
        /// <param name="scjssj">生产结束时间</param>
        /// <returns></returns>
        public DataSet GetRollProdcut_CQ(string batchno, string ckcode, string stlgrd, string spec, string matcode, string zldj, string salearea, string minarea, string custname, string C_PCINFO, string flag, string sckssj, string scjssj)
        {
            return dal.GetRollProdcut_CQ(batchno, ckcode, stlgrd, spec, matcode, zldj, salearea, minarea, custname, C_PCINFO, flag, sckssj, scjssj);
        }

        /// <summary>
        /// 线材改判库存
        /// </summary>
        /// <param name="batchno">批次号</param>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <param name="zldj">质量等级</param>
        /// <param name="salearea">销售区域</param>
        /// <param name="minarea">小区域</param>
        /// <param name="custname">客户名称</param>
        /// <param name="sckssj">生产开始时间</param>
        /// <param name="scjssj">生产结束时间</param>
        /// <returns></returns>
        public DataSet GetRollProdcut_GP(string batchno, string ckcode, string stlgrd, string spec, string matcode, string zldj, string salearea, string minarea, string custname, string C_PCINFO, string flag, string sckssj, string scjssj)
        {
            return dal.GetRollProdcut_GP(batchno, ckcode, stlgrd, spec, matcode, zldj, salearea, minarea, custname, C_PCINFO, flag, sckssj, scjssj);
        }


        /// <summary>
        /// 线材仓库查询是否室内
        /// </summary>
        /// <param name="batchno">批次号</param>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <param name="zldj">质量等级</param>
        /// <param name="salearea">销售区域</param>
        /// <param name="minarea">小区域</param>
        /// <param name="custname">客户名称</param>
        /// <param name="sckssj">生产开始时间</param>
        /// <param name="scjssj">生产结束时间</param>
        /// <returns></returns>
        public DataSet GetRollProdcut_SFSN(string batchno, string ckcode, string stlgrd, string spec, string matcode, string zldj, string salearea, string minarea, string custname, string C_PCINFO, string flag, string sckssj, string scjssj, string sfsn, string con)
        {
            return dal.GetRollProdcut_SFSN(batchno, ckcode, stlgrd, spec, matcode, zldj, salearea, minarea, custname, C_PCINFO, flag, sckssj, scjssj, sfsn, con);
        }

        /// <summary>
        /// 线材仓库查询
        /// </summary>
        /// <param name="batchno">批次号</param>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <param name="zldj">质量等级</param>
        /// <param name="salearea">销售区域</param>
        /// <param name="minarea">小区域</param>
        /// <param name="custname">客户名称</param>
        /// <param name="sckssj">生产开始时间</param>
        /// <param name="scjssj">生产结束时间</param>
        /// <returns></returns>
        public DataSet GetRollProdcut3(string batchno, string ckcode, string stlgrd, string spec, string matcode, string zldj, string salearea, string minarea, string custname, string C_PCINFO, string flag, string sckssj, string scjssj)
        {
            return dal.GetRollProdcut3(batchno, ckcode, stlgrd, spec, matcode, zldj, salearea, minarea, custname, C_PCINFO, flag, sckssj, scjssj);
        }



        /// <summary>
        /// 线材资源整批调配
        /// </summary>
        /// <param name="batchno">批次号</param>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <param name="zldj">质量等级</param>
        /// <param name="salearea">销售区域</param>
        /// <param name="custname">客户名称</param>
        /// <param name="sckssj">生产开始时间</param>
        /// <param name="scjssj">生产结束时间</param>
        /// <returns></returns>
        public DataSet GetRollProdcut(string batchno, string ckcode, string stlgrd, string spec, string matcode, string zldj, string salearea, string custname, string C_PCINFO, string flag, string sckssj, string scjssj, string conno, string gpstate)
        {
            return dal.GetRollProdcut(batchno, ckcode, stlgrd, spec, matcode, zldj, salearea, custname, C_PCINFO, flag, sckssj, scjssj, conno, gpstate);
        }

        /// <summary>
        /// 线材列表单卷显示
        /// </summary>
        /// <param name="batchno">批次号</param>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <param name="zldj">质量等级</param>
        /// <param name="salearea">销售区域</param>
        /// <param name="custname">客户名称</param>
        /// <param name="pagesize">显示页数</param>
        /// <param name="pageindex">起始页数</param>
        /// <returns></returns>
        public DataSet GetRollProdcut2(string batchno, string ckcode, string stlgrd, string spec, string matcode, string zldj, string salearea, string custname, string C_PCINFO, string flag, string con, string top)
        {
            return dal.GetRollProdcut2(batchno, ckcode, stlgrd, spec, matcode, zldj, salearea, custname, C_PCINFO, flag, con, top);
        }

        /// <summary>
        /// 线材列表单卷显示
        /// </summary>
        /// <param name="batchno">批次号</param>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <param name="zldj">质量等级</param>
        /// <param name="salearea">销售区域</param>
        /// <param name="custname">客户名称</param>
        /// <param name="pagesize">显示页数</param>
        /// <param name="pageindex">起始页数</param>
        /// <returns></returns>
        public DataSet GetRollProdcut2_top(string batchno, string ckcode, string stlgrd, string spec, string matcode, string zldj, string salearea, string custname, string C_PCINFO, string flag, string con, string top)
        {
            return dal.GetRollProdcut2_top(batchno, ckcode, stlgrd, spec, matcode, zldj, salearea, custname, C_PCINFO, flag, con, top);
        }


        /// <summary>
        /// 根据批号获取相关数据
        /// </summary>
        /// <param name="batchno"></param>
        /// <returns></returns>
        public DataSet GetRollProdcut(string batchno)
        {
            return dal.GetRollProdcut(batchno);
        }

        /// <summary>
        /// 获取线材各区域总量/监控/超期
        /// </summary>
        /// <returns></returns>
        public DataSet GetRollArea(string stlGrd, string spec)
        {
            return dal.GetRollArea(stlGrd, spec);
        }



        /// <summary>
        /// 检查合同是否排产或是否有线材库存
        /// </summary>
        /// <param name="conno"></param>
        /// <returns></returns>
        public ModMsg Check_OrderAndRoll(string conno)
        {
            return dal.Check_OrderAndRoll(conno);
        }
        #endregion  ExtensionMethod

        #region //PCI
        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <param name="ph">批号</param>
        /// <param name="grd">钢种</param>
        /// <param name="std">执行标准</param>
        /// <param name="ck">仓库</param>
        /// <param name="qy">区域</param>
        /// <param name="kw">库位</param>
        /// <param name="sfdp">是否待判</param>
        /// <returns></returns>
        public DataSet GetXCKC(string ph, string grd, string std, string ck, string qy, string kw, string status, string C_QTCKD, string C_ZKD, string sfdp)
        {
            return dal.GetXCKC(ph, grd, std, ck, qy, kw, status, C_QTCKD, C_ZKD, sfdp);
        }
        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <param name="ph">批号</param>
        /// <param name="grd">钢种</param>
        /// <param name="std">执行标准</param>
        /// <param name="ck">仓库</param>
        /// <param name="qy">区域</param>
        /// <param name="kw">库位</param>
        /// <param name="sfdp">是否待判</param>
        /// <returns></returns>
        public DataSet GetXCKC1(string ph, string grd, string std, string ck, string qy, string kw, string status, string C_QTCKD, string C_ZKD, string sfdp)
        {
            return dal.GetXCKC1(ph, grd, std, ck, qy, kw, status, C_QTCKD, C_ZKD, sfdp);
        }
        public DataSet GetXCKList(string ck, string kw, string gz, string bz, string batchno, string barcode, string sfdp, string zldj, string dt1, string dt2, string qy, string kczt, string gg)
        {
            return dal.GetXCKList(ck, kw, gz, bz, batchno, barcode, sfdp, zldj, dt1, dt2, qy, kczt, gg);
        }
        #endregion
    }
}

