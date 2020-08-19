using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TMO_SALEORDERITEM
	/// </summary>
	public partial class Dal_TMO_SALEORDERITEM
    {
		public Dal_TMO_SALEORDERITEM()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TMO_SALEORDERITEM");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TMO_SALEORDERITEM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TMO_SALEORDERITEM(");
			strSql.Append("C_ID,C_BILLID,C_INITIALIZE_ID,C_ORDERNO,C_CONNO,C_INVBASDOCID,C_INVENTORYID,C_UNITID,C_FUNITID,N_NUMBER,D_CONSIGNDATE,D_DELIVERDATE,C_PK_CORP,C_ADVISECALBODYID,C_CURRENCYTYPEID,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,C_RECEIPTAREAID,C_RECEIVEADDRESS,C_RECEIPTCORPID,N_ORIGINALCURSUMMNY,C_VFREE1,C_VFREE2,C_VFREE3,C_VDEF1,C_REMARK,N_STATUS,C_INITORDERID)");
			strSql.Append(" values (");
			strSql.Append(":C_ID,:C_BILLID,:C_INITIALIZE_ID,:C_ORDERNO,:C_CONNO,:C_INVBASDOCID,:C_INVENTORYID,:C_UNITID,:C_FUNITID,:N_NUMBER,:D_CONSIGNDATE,:D_DELIVERDATE,:C_PK_CORP,:C_ADVISECALBODYID,:C_CURRENCYTYPEID,:N_TAXRATE,:N_ORIGINALCURPRICE,:N_ORIGINALCURTAXPRICE,:N_ORIGINALCURTAXMNY,:N_ORIGINALCURMNY,:C_RECEIPTAREAID,:C_RECEIVEADDRESS,:C_RECEIPTCORPID,:N_ORIGINALCURSUMMNY,:C_VFREE1,:C_VFREE2,:C_VFREE3,:C_VDEF1,:C_REMARK,:N_STATUS,:C_INITORDERID)");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_BILLID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_INITIALIZE_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_ORDERNO", OracleDbType.Varchar2,100),
					new OracleParameter(":C_CONNO", OracleDbType.Varchar2,100),
					new OracleParameter(":C_INVBASDOCID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_INVENTORYID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_UNITID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_FUNITID", OracleDbType.Varchar2,100),
					new OracleParameter(":N_NUMBER", OracleDbType.Decimal,15),
					new OracleParameter(":D_CONSIGNDATE", OracleDbType.Date),
					new OracleParameter(":D_DELIVERDATE", OracleDbType.Date),
					new OracleParameter(":C_PK_CORP", OracleDbType.Varchar2,100),
					new OracleParameter(":C_ADVISECALBODYID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_CURRENCYTYPEID", OracleDbType.Varchar2,100),
					new OracleParameter(":N_TAXRATE", OracleDbType.Decimal,15),
					new OracleParameter(":N_ORIGINALCURPRICE", OracleDbType.Decimal,15),
					new OracleParameter(":N_ORIGINALCURTAXPRICE", OracleDbType.Decimal,15),
					new OracleParameter(":N_ORIGINALCURTAXMNY", OracleDbType.Decimal,15),
					new OracleParameter(":N_ORIGINALCURMNY", OracleDbType.Decimal,15),
					new OracleParameter(":C_RECEIPTAREAID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_RECEIVEADDRESS", OracleDbType.Varchar2,100),
					new OracleParameter(":C_RECEIPTCORPID", OracleDbType.Varchar2,100),
					new OracleParameter(":N_ORIGINALCURSUMMNY", OracleDbType.Decimal,15),
					new OracleParameter(":C_VFREE1", OracleDbType.Varchar2,100),
					new OracleParameter(":C_VFREE2", OracleDbType.Varchar2,100),
					new OracleParameter(":C_VFREE3", OracleDbType.Varchar2,100),
					new OracleParameter(":C_VDEF1", OracleDbType.Varchar2,100),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
					new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
					new OracleParameter(":C_INITORDERID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_ID;
			parameters[1].Value = model.C_BILLID;
			parameters[2].Value = model.C_INITIALIZE_ID;
			parameters[3].Value = model.C_ORDERNO;
			parameters[4].Value = model.C_CONNO;
			parameters[5].Value = model.C_INVBASDOCID;
			parameters[6].Value = model.C_INVENTORYID;
			parameters[7].Value = model.C_UNITID;
			parameters[8].Value = model.C_FUNITID;
			parameters[9].Value = model.N_NUMBER;
			parameters[10].Value = model.D_CONSIGNDATE;
			parameters[11].Value = model.D_DELIVERDATE;
			parameters[12].Value = model.C_PK_CORP;
			parameters[13].Value = model.C_ADVISECALBODYID;
			parameters[14].Value = model.C_CURRENCYTYPEID;
			parameters[15].Value = model.N_TAXRATE;
			parameters[16].Value = model.N_ORIGINALCURPRICE;
			parameters[17].Value = model.N_ORIGINALCURTAXPRICE;
			parameters[18].Value = model.N_ORIGINALCURTAXMNY;
			parameters[19].Value = model.N_ORIGINALCURMNY;
			parameters[20].Value = model.C_RECEIPTAREAID;
			parameters[21].Value = model.C_RECEIVEADDRESS;
			parameters[22].Value = model.C_RECEIPTCORPID;
			parameters[23].Value = model.N_ORIGINALCURSUMMNY;
			parameters[24].Value = model.C_VFREE1;
			parameters[25].Value = model.C_VFREE2;
			parameters[26].Value = model.C_VFREE3;
			parameters[27].Value = model.C_VDEF1;
			parameters[28].Value = model.C_REMARK;
			parameters[29].Value = model.N_STATUS;
			parameters[30].Value = model.C_INITORDERID;

			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Mod_TMO_SALEORDERITEM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TMO_SALEORDERITEM set ");
			strSql.Append("C_BILLID=:C_BILLID,");
			strSql.Append("C_INITIALIZE_ID=:C_INITIALIZE_ID,");
			strSql.Append("C_ORDERNO=:C_ORDERNO,");
			strSql.Append("C_CONNO=:C_CONNO,");
			strSql.Append("C_INVBASDOCID=:C_INVBASDOCID,");
			strSql.Append("C_INVENTORYID=:C_INVENTORYID,");
			strSql.Append("C_UNITID=:C_UNITID,");
			strSql.Append("C_FUNITID=:C_FUNITID,");
			strSql.Append("N_NUMBER=:N_NUMBER,");
			strSql.Append("D_CONSIGNDATE=:D_CONSIGNDATE,");
			strSql.Append("D_DELIVERDATE=:D_DELIVERDATE,");
			strSql.Append("C_PK_CORP=:C_PK_CORP,");
			strSql.Append("C_ADVISECALBODYID=:C_ADVISECALBODYID,");
			strSql.Append("C_CURRENCYTYPEID=:C_CURRENCYTYPEID,");
			strSql.Append("N_TAXRATE=:N_TAXRATE,");
			strSql.Append("N_ORIGINALCURPRICE=:N_ORIGINALCURPRICE,");
			strSql.Append("N_ORIGINALCURTAXPRICE=:N_ORIGINALCURTAXPRICE,");
			strSql.Append("N_ORIGINALCURTAXMNY=:N_ORIGINALCURTAXMNY,");
			strSql.Append("N_ORIGINALCURMNY=:N_ORIGINALCURMNY,");
			strSql.Append("C_RECEIPTAREAID=:C_RECEIPTAREAID,");
			strSql.Append("C_RECEIVEADDRESS=:C_RECEIVEADDRESS,");
			strSql.Append("C_RECEIPTCORPID=:C_RECEIPTCORPID,");
			strSql.Append("N_ORIGINALCURSUMMNY=:N_ORIGINALCURSUMMNY,");
			strSql.Append("C_VFREE1=:C_VFREE1,");
			strSql.Append("C_VFREE2=:C_VFREE2,");
			strSql.Append("C_VFREE3=:C_VFREE3,");
			strSql.Append("C_VDEF1=:C_VDEF1,");
			strSql.Append("C_REMARK=:C_REMARK,");
			strSql.Append("N_STATUS=:N_STATUS,");
			strSql.Append("C_INITORDERID=:C_INITORDERID");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_BILLID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_INITIALIZE_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_ORDERNO", OracleDbType.Varchar2,100),
					new OracleParameter(":C_CONNO", OracleDbType.Varchar2,100),
					new OracleParameter(":C_INVBASDOCID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_INVENTORYID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_UNITID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_FUNITID", OracleDbType.Varchar2,100),
					new OracleParameter(":N_NUMBER", OracleDbType.Decimal,15),
					new OracleParameter(":D_CONSIGNDATE", OracleDbType.Date),
					new OracleParameter(":D_DELIVERDATE", OracleDbType.Date),
					new OracleParameter(":C_PK_CORP", OracleDbType.Varchar2,100),
					new OracleParameter(":C_ADVISECALBODYID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_CURRENCYTYPEID", OracleDbType.Varchar2,100),
					new OracleParameter(":N_TAXRATE", OracleDbType.Decimal,15),
					new OracleParameter(":N_ORIGINALCURPRICE", OracleDbType.Decimal,15),
					new OracleParameter(":N_ORIGINALCURTAXPRICE", OracleDbType.Decimal,15),
					new OracleParameter(":N_ORIGINALCURTAXMNY", OracleDbType.Decimal,15),
					new OracleParameter(":N_ORIGINALCURMNY", OracleDbType.Decimal,15),
					new OracleParameter(":C_RECEIPTAREAID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_RECEIVEADDRESS", OracleDbType.Varchar2,100),
					new OracleParameter(":C_RECEIPTCORPID", OracleDbType.Varchar2,100),
					new OracleParameter(":N_ORIGINALCURSUMMNY", OracleDbType.Decimal,15),
					new OracleParameter(":C_VFREE1", OracleDbType.Varchar2,100),
					new OracleParameter(":C_VFREE2", OracleDbType.Varchar2,100),
					new OracleParameter(":C_VFREE3", OracleDbType.Varchar2,100),
					new OracleParameter(":C_VDEF1", OracleDbType.Varchar2,100),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
					new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
					new OracleParameter(":C_INITORDERID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_BILLID;
			parameters[1].Value = model.C_INITIALIZE_ID;
			parameters[2].Value = model.C_ORDERNO;
			parameters[3].Value = model.C_CONNO;
			parameters[4].Value = model.C_INVBASDOCID;
			parameters[5].Value = model.C_INVENTORYID;
			parameters[6].Value = model.C_UNITID;
			parameters[7].Value = model.C_FUNITID;
			parameters[8].Value = model.N_NUMBER;
			parameters[9].Value = model.D_CONSIGNDATE;
			parameters[10].Value = model.D_DELIVERDATE;
			parameters[11].Value = model.C_PK_CORP;
			parameters[12].Value = model.C_ADVISECALBODYID;
			parameters[13].Value = model.C_CURRENCYTYPEID;
			parameters[14].Value = model.N_TAXRATE;
			parameters[15].Value = model.N_ORIGINALCURPRICE;
			parameters[16].Value = model.N_ORIGINALCURTAXPRICE;
			parameters[17].Value = model.N_ORIGINALCURTAXMNY;
			parameters[18].Value = model.N_ORIGINALCURMNY;
			parameters[19].Value = model.C_RECEIPTAREAID;
			parameters[20].Value = model.C_RECEIVEADDRESS;
			parameters[21].Value = model.C_RECEIPTCORPID;
			parameters[22].Value = model.N_ORIGINALCURSUMMNY;
			parameters[23].Value = model.C_VFREE1;
			parameters[24].Value = model.C_VFREE2;
			parameters[25].Value = model.C_VFREE3;
			parameters[26].Value = model.C_VDEF1;
			parameters[27].Value = model.C_REMARK;
			parameters[28].Value = model.N_STATUS;
			parameters[29].Value = model.C_INITORDERID;
			parameters[30].Value = model.C_ID;

			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TMO_SALEORDERITEM ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string C_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TMO_SALEORDERITEM ");
			strSql.Append(" where C_ID in ("+C_IDlist + ")  ");
			int rows=DbHelperOra.ExecuteSql(strSql.ToString());
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
		public Mod_TMO_SALEORDERITEM GetModel(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_BILLID,C_INITIALIZE_ID,C_ORDERNO,C_CONNO,C_INVBASDOCID,C_INVENTORYID,C_UNITID,C_FUNITID,N_NUMBER,D_CONSIGNDATE,D_DELIVERDATE,C_PK_CORP,C_ADVISECALBODYID,C_CURRENCYTYPEID,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,C_RECEIPTAREAID,C_RECEIVEADDRESS,C_RECEIPTCORPID,N_ORIGINALCURSUMMNY,C_VFREE1,C_VFREE2,C_VFREE3,C_VDEF1,C_REMARK,N_STATUS,C_INITORDERID from TMO_SALEORDERITEM ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			Mod_TMO_SALEORDERITEM model=new Mod_TMO_SALEORDERITEM();
			DataSet ds=DbHelperOra.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public Mod_TMO_SALEORDERITEM DataRowToModel(DataRow row)
		{
			Mod_TMO_SALEORDERITEM model=new Mod_TMO_SALEORDERITEM();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_BILLID"]!=null)
				{
					model.C_BILLID=row["C_BILLID"].ToString();
				}
				if(row["C_INITIALIZE_ID"]!=null)
				{
					model.C_INITIALIZE_ID=row["C_INITIALIZE_ID"].ToString();
				}
				if(row["C_ORDERNO"]!=null)
				{
					model.C_ORDERNO=row["C_ORDERNO"].ToString();
				}
				if(row["C_CONNO"]!=null)
				{
					model.C_CONNO=row["C_CONNO"].ToString();
				}
				if(row["C_INVBASDOCID"]!=null)
				{
					model.C_INVBASDOCID=row["C_INVBASDOCID"].ToString();
				}
				if(row["C_INVENTORYID"]!=null)
				{
					model.C_INVENTORYID=row["C_INVENTORYID"].ToString();
				}
				if(row["C_UNITID"]!=null)
				{
					model.C_UNITID=row["C_UNITID"].ToString();
				}
				if(row["C_FUNITID"]!=null)
				{
					model.C_FUNITID=row["C_FUNITID"].ToString();
				}
				if(row["N_NUMBER"]!=null && row["N_NUMBER"].ToString()!="")
				{
					model.N_NUMBER=decimal.Parse(row["N_NUMBER"].ToString());
				}
				if(row["D_CONSIGNDATE"]!=null && row["D_CONSIGNDATE"].ToString()!="")
				{
					model.D_CONSIGNDATE=DateTime.Parse(row["D_CONSIGNDATE"].ToString());
				}
				if(row["D_DELIVERDATE"]!=null && row["D_DELIVERDATE"].ToString()!="")
				{
					model.D_DELIVERDATE=DateTime.Parse(row["D_DELIVERDATE"].ToString());
				}
				if(row["C_PK_CORP"]!=null)
				{
					model.C_PK_CORP=row["C_PK_CORP"].ToString();
				}
				if(row["C_ADVISECALBODYID"]!=null)
				{
					model.C_ADVISECALBODYID=row["C_ADVISECALBODYID"].ToString();
				}
				if(row["C_CURRENCYTYPEID"]!=null)
				{
					model.C_CURRENCYTYPEID=row["C_CURRENCYTYPEID"].ToString();
				}
				if(row["N_TAXRATE"]!=null && row["N_TAXRATE"].ToString()!="")
				{
					model.N_TAXRATE=decimal.Parse(row["N_TAXRATE"].ToString());
				}
				if(row["N_ORIGINALCURPRICE"]!=null && row["N_ORIGINALCURPRICE"].ToString()!="")
				{
					model.N_ORIGINALCURPRICE=decimal.Parse(row["N_ORIGINALCURPRICE"].ToString());
				}
				if(row["N_ORIGINALCURTAXPRICE"]!=null && row["N_ORIGINALCURTAXPRICE"].ToString()!="")
				{
					model.N_ORIGINALCURTAXPRICE=decimal.Parse(row["N_ORIGINALCURTAXPRICE"].ToString());
				}
				if(row["N_ORIGINALCURTAXMNY"]!=null && row["N_ORIGINALCURTAXMNY"].ToString()!="")
				{
					model.N_ORIGINALCURTAXMNY=decimal.Parse(row["N_ORIGINALCURTAXMNY"].ToString());
				}
				if(row["N_ORIGINALCURMNY"]!=null && row["N_ORIGINALCURMNY"].ToString()!="")
				{
					model.N_ORIGINALCURMNY=decimal.Parse(row["N_ORIGINALCURMNY"].ToString());
				}
				if(row["C_RECEIPTAREAID"]!=null)
				{
					model.C_RECEIPTAREAID=row["C_RECEIPTAREAID"].ToString();
				}
				if(row["C_RECEIVEADDRESS"]!=null)
				{
					model.C_RECEIVEADDRESS=row["C_RECEIVEADDRESS"].ToString();
				}
				if(row["C_RECEIPTCORPID"]!=null)
				{
					model.C_RECEIPTCORPID=row["C_RECEIPTCORPID"].ToString();
				}
				if(row["N_ORIGINALCURSUMMNY"]!=null && row["N_ORIGINALCURSUMMNY"].ToString()!="")
				{
					model.N_ORIGINALCURSUMMNY=decimal.Parse(row["N_ORIGINALCURSUMMNY"].ToString());
				}
				if(row["C_VFREE1"]!=null)
				{
					model.C_VFREE1=row["C_VFREE1"].ToString();
				}
				if(row["C_VFREE2"]!=null)
				{
					model.C_VFREE2=row["C_VFREE2"].ToString();
				}
				if(row["C_VFREE3"]!=null)
				{
					model.C_VFREE3=row["C_VFREE3"].ToString();
				}
				if(row["C_VDEF1"]!=null)
				{
					model.C_VDEF1=row["C_VDEF1"].ToString();
				}
				if(row["C_REMARK"]!=null)
				{
					model.C_REMARK=row["C_REMARK"].ToString();
				}
				if(row["N_STATUS"]!=null && row["N_STATUS"].ToString()!="")
				{
					model.N_STATUS=decimal.Parse(row["N_STATUS"].ToString());
				}
				if(row["C_INITORDERID"]!=null)
				{
					model.C_INITORDERID=row["C_INITORDERID"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_BILLID,C_INITIALIZE_ID,C_ORDERNO,C_CONNO,C_INVBASDOCID,C_INVENTORYID,C_UNITID,C_FUNITID,N_NUMBER,D_CONSIGNDATE,D_DELIVERDATE,C_PK_CORP,C_ADVISECALBODYID,C_CURRENCYTYPEID,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,C_RECEIPTAREAID,C_RECEIVEADDRESS,C_RECEIPTCORPID,N_ORIGINALCURSUMMNY,C_VFREE1,C_VFREE2,C_VFREE3,C_VDEF1,C_REMARK,N_STATUS,C_INITORDERID ");
			strSql.Append(" FROM TMO_SALEORDERITEM ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOra.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM TMO_SALEORDERITEM ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperOra.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.C_ID desc");
			}
			strSql.Append(")AS Row, T.*  from TMO_SALEORDERITEM T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOra.Query(strSql.ToString());
		}

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OracleParameter[] parameters = {
					new OracleParameter(":tblName", OracleDbType.Varchar2, 255),
					new OracleParameter(":fldName", OracleDbType.Varchar2, 255),
					new OracleParameter(":PageSize", OracleDbType.Number),
					new OracleParameter(":PageIndex", OracleDbType.Number),
					new OracleParameter(":IsReCount", OracleDbType.Clob),
					new OracleParameter(":OrderType", OracleDbType.Clob),
					new OracleParameter(":strWhere", OracleDbType.Varchar2,1000),
					};
			parameters[0].Value = "TMO_SALEORDERITEM";
			parameters[1].Value = "C_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod

        #region //自定义
        /// <summary>
		/// 获取订单明细
		/// </summary>
		public DataSet GetOrder(string pkid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_BILLID,C_INITIALIZE_ID,C_ORDERNO,C_CONNO,C_INVBASDOCID,C_INVENTORYID,C_UNITID,C_FUNITID,N_NUMBER,D_CONSIGNDATE,D_DELIVERDATE,C_PK_CORP,C_ADVISECALBODYID,C_CURRENCYTYPEID,N_TAXRATE,N_ORIGINALCURPRICE,N_ORIGINALCURTAXPRICE,N_ORIGINALCURTAXMNY,N_ORIGINALCURMNY,C_RECEIPTAREAID,C_RECEIVEADDRESS,C_RECEIPTCORPID,N_ORIGINALCURSUMMNY,C_VFREE1,C_VFREE2,C_VFREE3,C_VDEF1,C_REMARK,N_STATUS,C_INITORDERID ");
            strSql.Append(" FROM TMO_SALEORDERITEM  where C_BILLID='"+ pkid + "'");
           
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

    }
}

