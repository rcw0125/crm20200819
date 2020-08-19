using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL.I;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// ReZJB_FYD
    /// </summary>
    public partial class Bll_Interface_FR
    {
        private readonly Dal_Interface_FR dal = new Dal_Interface_FR();
        public Bll_Interface_FR()
        { }
        /// <summary>
        ///同步条码库存信息
        /// </summary>
        /// <param name="Barcode">钢卷唯一码</param>
        /// <param name="CK">仓库</param>
        /// <param name="HW">货位</param>
        /// <param name="WGDH">完工单号</param>
        /// <param name="PH">批号</param>
        /// <param name="GH">钩号</param>
        /// <param name="GZ">钢种</param>
        /// <returns>同步结果</returns>
        public string TbKCList(string Barcode, string CK, string HW, string WGDH, string PH, string GH, string GZ)
        {
            return dal.TbKCList(Barcode, CK, HW, WGDH, PH, GH, GZ);
        }
        /// <summary>
        ///同步条码库存信息
        /// </summary>
        public string TbPCIList()
        {
            return dal.TbPCIList();
        }
        /// <summary>
        ///同步条码库存信息
        /// </summary>
        public string TBFYD(string path)
        {
            return dal.TBFYD(path);
        }
        public string csfydtb(string path, string fyd)
        {
            return dal.csfydtb(path, fyd);
        }
        /// <summary>
        ///根据发运单号获取条码中间表数据
        /// </summary>
        /// <param name="C_FYDH">发运单号</param>
        /// <returns></returns>
        public DataSet GetTMFYD(string C_FYDH, DateTime dt1, DateTime dt2)
        {
            return dal.GetTMFYD(C_FYDH, dt1, dt2);
        }
        /// <summary>
        /// 根据单号获取线材实绩日志
        /// </summary>
        /// <param name="DH">单号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public DataSet GetYWDXQ(string DH, string status, string id)
        {
            return dal.GetYWDXQ(DH, status, id);
        }
        /// <summary>
        /// 获取最新的转库单号
        /// </summary>
        /// <param name="zkdstr">转库单</param>
        /// <returns></returns>
        public string GetZKDNO(string zkdstr)
        {
            return dal.GetZKDNO(zkdstr);
        }
        /// <summary>
        /// 检测库存是否变更
        /// </summary>
        /// <param name="mat">物料号</param>
        /// <param name="ck">仓库</param>
        /// <param name="batch">批号</param>
        /// <returns></returns>
        public int CKKC(string mat, string ck, string batch, string zldj, string bzyq, string bpdj)
        {
            return dal.CKKC(mat, ck, batch, zldj, bzyq, bpdj);
        }
        /// <summary>
        /// 向条码发送转库单
        /// </summary>
        /// <param name="idstr">id字符串</param>
        /// <param name="ckcode">仓库代码</param>
        /// <returns></returns>
        public string SENDZKD1(List<CommonKC> list, string mbck, string zkd, string userId, string usercode)
        {
            return dal.SENDZKD1(list, mbck, zkd, userId, usercode);
        }
        /// <summary>
        /// 根据转库单号获取条码转库单数据
        /// </summary>
        /// <param name="C_ZKD">其他出库单号</param>
        /// <returns></returns>
        public DataSet GetTMZKZJB(string C_ZKD, DateTime dt1, DateTime dt2)
        {
            return dal.GetTMZKZJB(C_ZKD, dt1, dt2);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dh">单号</param>
        /// <param name="ck">仓库</param>
        /// <param name="mbck">目标仓库</param>
        /// <param name="grd">钢种</param>
        /// <param name="ph">批号</param>
        /// <param name="sfdp">是否待判</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public DataSet GetZKDList(string dh, string ck, string mbck, string grd, string ph, string sfdp, string status, string rq)
        {
            return dal.GetZKDList(dh, ck, mbck, grd, ph, sfdp, status, rq);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dh">单号</param>
        /// <param name="ck">仓库</param>
        /// <param name="mbck">目标仓库</param>
        /// <param name="grd">钢种</param>
        /// <param name="ph">批号</param>
        /// <param name="sfdp">是否待判</param>
        /// <param name="status">状态</param>
        /// <param name="zdrq">制单日期</param>
        /// <returns></returns>
        public DataSet GetQTCKDList(string dh, string ck, string mbck, string grd, string ph, string sfdp, string status,string zdrq)
        {
            return dal.GetQTCKDList(dh, ck, mbck, grd, ph, sfdp, status,zdrq);
        }
        /// <summary>
        /// 同步条码转库单信息
        /// </summary>
        /// <param name="path">地址</param>
        /// <returns></returns>
        public string TBZKD1(string path)
        {
            return dal.TBZKD1(path);
        }
        /// <summary>
        /// 获取最新的其他出库单号
        /// </summary>
        /// <param name="qtckdstr">出库单号</param>
        /// <returns></returns>
        public string GetQTCKNO(string qtckdstr)
        {
            return dal.GetQTCKNO(qtckdstr);
        }
        /// <summary>
        /// 向条码发送其他出库信息
        /// </summary>
        /// <param name="num">数量</param>
        /// <param name="cph">车牌号</param>
        /// <param name="address">位置</param>
        /// <param name="zdr">制单人</param>
        /// <param name="cklx">出库类型</param>
        /// <param name="shdw">送货单位</param>
        /// <param name="fysj">发运实绩</param>
        /// <returns></returns>
        public string SENDQTCKD1(List<CommonKC> list, string qtckd, string cph, string address, string zdrid, string zdrcode, string cklx, string shdw, DateTime fysj, string cys, string mbckid)
        {
            return dal.SENDQTCKD1(list, qtckd, cph, address, zdrid, zdrcode, cklx, shdw, fysj, cys, mbckid);
        }
        /// <summary>
        ///根据条码其他出库单撤销数据
        /// </summary>
        /// <param name="ZKD">转库单</param>
        /// <returns></returns>
        public int CXZKDByDH(string ZKD)
        {
            return dal.CXZKDByDH(ZKD);
        }
        /// <summary>
        ///根据条码其他出库单撤销数据
        /// </summary>
        /// <param name="qtckd">其他出库单</param>
        /// <returns></returns>
        public string CXQTCKDByDH(string qtckd)
        {
            return dal.CXQTCKDByDH(qtckd);
        }
        /// <summary>
        /// 同步条码移位单信息
        /// </summary>
        /// <returns></returns>
        public string TBYWD()
        {
            return dal.TBYWD();
        }
        /// <summary>
        /// 获取移位单数据
        /// </summary>
        /// <param name="C_YWDH">其他出库单号</param>
        /// <returns></returns>
        public DataSet GetTMYWD(string C_YWDH, DateTime dt1, DateTime dt2)
        {
            return dal.GetTMYWD(C_YWDH, dt1, dt2);
        }
        /// <summary>
        /// 获取其他出库单数据
        /// </summary>
        /// <param name="C_QTCKD">其他出库单号</param>
        /// <returns></returns>
        public DataSet GetTMZJB(string C_QTCKD, DateTime dt1, DateTime dt2)
        {
            return dal.GetTMZJB(C_QTCKD, dt1, dt2);
        }
        public string QTCKSENDnc(string xmlFileName, string ckd)
        {
            //return dal.QTCKSENDnc(xmlFileName, ckd);
            return "";
        }
        /// <summary>
        /// 同步条码其他出库单信息
        /// </summary>
        /// <returns></returns>
        public string QTCKDTB(string xmlFileName)
        {
            return dal.QTCKDTB(xmlFileName);
        }
        /// <summary>
        /// 同步条码其他出库单信息調試
        /// </summary>
        /// <returns></returns>
        public string QTCKDTBTS(string xmlFileName)
        {
            return dal.QTCKDTBTS(xmlFileName);
        }
        /// <summary>
        /// 添加操作记录
        /// </summary>
        /// <param name="msg"></param>
        public void AddLog(string msg)
        {
            dal.AddLog(msg);
        }
        /// <summary>
        /// 获取条码发运单备注
        /// </summary>
        /// <param name="fydh">发运单号</param>
        /// <returns></returns>
        public DataSet GetTMFYDBZ(string fydh, string ck, string ph, string gg)
        {
            return dal.GetTMFYDBZ(fydh, ck, ph, gg);
        }
        /// <summary>
        /// 根据批号获取条码库存
        /// </summary>
        /// <param name="pch">批号</param>
        /// <returns></returns>
        public DataSet GetRFKCbyPH(string pch, string gh)
        {
            return dal.GetRFKCbyPH(pch,gh);
        }
        /// <summary>
        /// 根据批号获取条码库存
        /// </summary>
        /// <param name="barcode">单卷号</param>
        /// <param name="ck">仓库</param>
        /// <param name="hw">货位</param>
        /// <param name="zl">重量</param>
        /// <param name="czry">czry</param>
        /// <returns></returns>
        public int UPRoll(string barcode, string ck, string hw, string zl, string czry)
        {
            return dal.UPRoll(barcode, ck, hw, zl, czry);
        }
        /// <summary>
        /// 根据批号获取线材实绩日志
        /// </summary>
        /// <param name="pch">批号</param>
        /// <param name="dt1">操作开始时间</param>
        /// <param name="dt2">操作结束时间</param>
        /// <param name="gh">钩号</param>
        /// <returns></returns>
        public DataSet GetLog(string pch, string dt1, string dt2, string gh)
        {
            return dal.GetLog(pch, dt1, dt2,gh);
        }
        /// <summary>
        /// 根据牌号获取状态
        /// </summary>
        /// <param name="dh">牌号</param>
        /// <returns></returns>
        public string GetMOVETYPE(string Barcode)
        {
            return dal.GetMOVETYPE(Barcode);
        }
        }

}
