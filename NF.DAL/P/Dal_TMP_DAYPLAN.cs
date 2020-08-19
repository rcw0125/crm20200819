using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TMP_DAYPLAN
	/// </summary>
	public partial class Dal_TMP_DAYPLAN
    {
		public Dal_TMP_DAYPLAN()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TMP_DAYPLAN");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TMP_DAYPLAN model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TMP_DAYPLAN(");
			strSql.Append("C_ID,C_PLCODE,C_PKBILLB,C_PKBILLH,C_CONNO,C_ORDERNO,C_PKINV,C_PKASSISTMEASURE,N_ASSISTNUM,N_NUM,N_UNITPRICE,N_MONEY,D_PLANDATE,D_ORDSNDATE,D_REQUIREDATE,D_SNDDATE,C_PKCUST,C_PKSENDTYPE,C_PKSALECORP,C_PKSALEORG,C_PKSENDSTOREORG,C_PKOPERATOR,C_PKOPRDEPART,C_PKPLANPERSON,C_PKAPPRPERSON,D_APPRDATE,C_PKARRIVEAREA,C_DESTADDRESS,C_RECEIPTCORPID,C_BIZTYPE,C_REMARK,C_PKSENDAREA,C_PKDELIVORG,C_UNITID,C_VFREE1,C_VFREE2,C_VFREE3,C_VFREE4)");
			strSql.Append(" values (");
			strSql.Append(":C_ID,:C_PLCODE,:C_PKBILLB,:C_PKBILLH,:C_CONNO,:C_ORDERNO,:C_PKINV,:C_PKASSISTMEASURE,:N_ASSISTNUM,:N_NUM,:N_UNITPRICE,:N_MONEY,:D_PLANDATE,:D_ORDSNDATE,:D_REQUIREDATE,:D_SNDDATE,:C_PKCUST,:C_PKSENDTYPE,:C_PKSALECORP,:C_PKSALEORG,:C_PKSENDSTOREORG,:C_PKOPERATOR,:C_PKOPRDEPART,:C_PKPLANPERSON,:C_PKAPPRPERSON,:D_APPRDATE,:C_PKARRIVEAREA,:C_DESTADDRESS,:C_RECEIPTCORPID,:C_BIZTYPE,:C_REMARK,:C_PKSENDAREA,:C_PKDELIVORG,:C_UNITID,:C_VFREE1,:C_VFREE2,:C_VFREE3,:C_VFREE4)");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PLCODE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKBILLB", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKBILLH", OracleDbType.Varchar2,100),
					new OracleParameter(":C_CONNO", OracleDbType.Varchar2,100),
					new OracleParameter(":C_ORDERNO", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKINV", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKASSISTMEASURE", OracleDbType.Varchar2,100),
					new OracleParameter(":N_ASSISTNUM", OracleDbType.Decimal,15),
					new OracleParameter(":N_NUM", OracleDbType.Decimal,15),
					new OracleParameter(":N_UNITPRICE", OracleDbType.Decimal,15),
					new OracleParameter(":N_MONEY", OracleDbType.Decimal,15),
					new OracleParameter(":D_PLANDATE", OracleDbType.Date),
					new OracleParameter(":D_ORDSNDATE", OracleDbType.Date),
					new OracleParameter(":D_REQUIREDATE", OracleDbType.Date),
					new OracleParameter(":D_SNDDATE", OracleDbType.Date),
					new OracleParameter(":C_PKCUST", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKSENDTYPE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKSALECORP", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKSALEORG", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKSENDSTOREORG", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKOPERATOR", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKOPRDEPART", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKPLANPERSON", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKAPPRPERSON", OracleDbType.Varchar2,100),
					new OracleParameter(":D_APPRDATE", OracleDbType.Date),
					new OracleParameter(":C_PKARRIVEAREA", OracleDbType.Varchar2,100),
					new OracleParameter(":C_DESTADDRESS", OracleDbType.Varchar2,100),
					new OracleParameter(":C_RECEIPTCORPID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_BIZTYPE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
					new OracleParameter(":C_PKSENDAREA", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKDELIVORG", OracleDbType.Varchar2,100),
					new OracleParameter(":C_UNITID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_VFREE1", OracleDbType.Varchar2,200),
					new OracleParameter(":C_VFREE2", OracleDbType.Varchar2,200),
					new OracleParameter(":C_VFREE3", OracleDbType.Varchar2,200),
					new OracleParameter(":C_VFREE4", OracleDbType.Varchar2,200)};
			parameters[0].Value = model.C_ID;
			parameters[1].Value = model.C_PLCODE;
			parameters[2].Value = model.C_PKBILLB;
			parameters[3].Value = model.C_PKBILLH;
			parameters[4].Value = model.C_CONNO;
			parameters[5].Value = model.C_ORDERNO;
			parameters[6].Value = model.C_PKINV;
			parameters[7].Value = model.C_PKASSISTMEASURE;
			parameters[8].Value = model.N_ASSISTNUM;
			parameters[9].Value = model.N_NUM;
			parameters[10].Value = model.N_UNITPRICE;
			parameters[11].Value = model.N_MONEY;
			parameters[12].Value = model.D_PLANDATE;
			parameters[13].Value = model.D_ORDSNDATE;
			parameters[14].Value = model.D_REQUIREDATE;
			parameters[15].Value = model.D_SNDDATE;
			parameters[16].Value = model.C_PKCUST;
			parameters[17].Value = model.C_PKSENDTYPE;
			parameters[18].Value = model.C_PKSALECORP;
			parameters[19].Value = model.C_PKSALEORG;
			parameters[20].Value = model.C_PKSENDSTOREORG;
			parameters[21].Value = model.C_PKOPERATOR;
			parameters[22].Value = model.C_PKOPRDEPART;
			parameters[23].Value = model.C_PKPLANPERSON;
			parameters[24].Value = model.C_PKAPPRPERSON;
			parameters[25].Value = model.D_APPRDATE;
			parameters[26].Value = model.C_PKARRIVEAREA;
			parameters[27].Value = model.C_DESTADDRESS;
			parameters[28].Value = model.C_RECEIPTCORPID;
			parameters[29].Value = model.C_BIZTYPE;
			parameters[30].Value = model.C_REMARK;
			parameters[31].Value = model.C_PKSENDAREA;
			parameters[32].Value = model.C_PKDELIVORG;
			parameters[33].Value = model.C_UNITID;
			parameters[34].Value = model.C_VFREE1;
			parameters[35].Value = model.C_VFREE2;
			parameters[36].Value = model.C_VFREE3;
			parameters[37].Value = model.C_VFREE4;

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
		public bool Update(Mod_TMP_DAYPLAN model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TMP_DAYPLAN set ");
			strSql.Append("C_PLCODE=:C_PLCODE,");
			strSql.Append("C_PKBILLB=:C_PKBILLB,");
			strSql.Append("C_PKBILLH=:C_PKBILLH,");
			strSql.Append("C_CONNO=:C_CONNO,");
			strSql.Append("C_ORDERNO=:C_ORDERNO,");
			strSql.Append("C_PKINV=:C_PKINV,");
			strSql.Append("C_PKASSISTMEASURE=:C_PKASSISTMEASURE,");
			strSql.Append("N_ASSISTNUM=:N_ASSISTNUM,");
			strSql.Append("N_NUM=:N_NUM,");
			strSql.Append("N_UNITPRICE=:N_UNITPRICE,");
			strSql.Append("N_MONEY=:N_MONEY,");
			strSql.Append("D_PLANDATE=:D_PLANDATE,");
			strSql.Append("D_ORDSNDATE=:D_ORDSNDATE,");
			strSql.Append("D_REQUIREDATE=:D_REQUIREDATE,");
			strSql.Append("D_SNDDATE=:D_SNDDATE,");
			strSql.Append("C_PKCUST=:C_PKCUST,");
			strSql.Append("C_PKSENDTYPE=:C_PKSENDTYPE,");
			strSql.Append("C_PKSALECORP=:C_PKSALECORP,");
			strSql.Append("C_PKSALEORG=:C_PKSALEORG,");
			strSql.Append("C_PKSENDSTOREORG=:C_PKSENDSTOREORG,");
			strSql.Append("C_PKOPERATOR=:C_PKOPERATOR,");
			strSql.Append("C_PKOPRDEPART=:C_PKOPRDEPART,");
			strSql.Append("C_PKPLANPERSON=:C_PKPLANPERSON,");
			strSql.Append("C_PKAPPRPERSON=:C_PKAPPRPERSON,");
			strSql.Append("D_APPRDATE=:D_APPRDATE,");
			strSql.Append("C_PKARRIVEAREA=:C_PKARRIVEAREA,");
			strSql.Append("C_DESTADDRESS=:C_DESTADDRESS,");
			strSql.Append("C_RECEIPTCORPID=:C_RECEIPTCORPID,");
			strSql.Append("C_BIZTYPE=:C_BIZTYPE,");
			strSql.Append("C_REMARK=:C_REMARK,");
			strSql.Append("C_PKSENDAREA=:C_PKSENDAREA,");
			strSql.Append("C_PKDELIVORG=:C_PKDELIVORG,");
			strSql.Append("C_UNITID=:C_UNITID,");
			strSql.Append("C_VFREE1=:C_VFREE1,");
			strSql.Append("C_VFREE2=:C_VFREE2,");
			strSql.Append("C_VFREE3=:C_VFREE3,");
			strSql.Append("C_VFREE4=:C_VFREE4");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_PLCODE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKBILLB", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKBILLH", OracleDbType.Varchar2,100),
					new OracleParameter(":C_CONNO", OracleDbType.Varchar2,100),
					new OracleParameter(":C_ORDERNO", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKINV", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKASSISTMEASURE", OracleDbType.Varchar2,100),
					new OracleParameter(":N_ASSISTNUM", OracleDbType.Decimal,15),
					new OracleParameter(":N_NUM", OracleDbType.Decimal,15),
					new OracleParameter(":N_UNITPRICE", OracleDbType.Decimal,15),
					new OracleParameter(":N_MONEY", OracleDbType.Decimal,15),
					new OracleParameter(":D_PLANDATE", OracleDbType.Date),
					new OracleParameter(":D_ORDSNDATE", OracleDbType.Date),
					new OracleParameter(":D_REQUIREDATE", OracleDbType.Date),
					new OracleParameter(":D_SNDDATE", OracleDbType.Date),
					new OracleParameter(":C_PKCUST", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKSENDTYPE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKSALECORP", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKSALEORG", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKSENDSTOREORG", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKOPERATOR", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKOPRDEPART", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKPLANPERSON", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKAPPRPERSON", OracleDbType.Varchar2,100),
					new OracleParameter(":D_APPRDATE", OracleDbType.Date),
					new OracleParameter(":C_PKARRIVEAREA", OracleDbType.Varchar2,100),
					new OracleParameter(":C_DESTADDRESS", OracleDbType.Varchar2,100),
					new OracleParameter(":C_RECEIPTCORPID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_BIZTYPE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
					new OracleParameter(":C_PKSENDAREA", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKDELIVORG", OracleDbType.Varchar2,100),
					new OracleParameter(":C_UNITID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_VFREE1", OracleDbType.Varchar2,200),
					new OracleParameter(":C_VFREE2", OracleDbType.Varchar2,200),
					new OracleParameter(":C_VFREE3", OracleDbType.Varchar2,200),
					new OracleParameter(":C_VFREE4", OracleDbType.Varchar2,200),
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_PLCODE;
			parameters[1].Value = model.C_PKBILLB;
			parameters[2].Value = model.C_PKBILLH;
			parameters[3].Value = model.C_CONNO;
			parameters[4].Value = model.C_ORDERNO;
			parameters[5].Value = model.C_PKINV;
			parameters[6].Value = model.C_PKASSISTMEASURE;
			parameters[7].Value = model.N_ASSISTNUM;
			parameters[8].Value = model.N_NUM;
			parameters[9].Value = model.N_UNITPRICE;
			parameters[10].Value = model.N_MONEY;
			parameters[11].Value = model.D_PLANDATE;
			parameters[12].Value = model.D_ORDSNDATE;
			parameters[13].Value = model.D_REQUIREDATE;
			parameters[14].Value = model.D_SNDDATE;
			parameters[15].Value = model.C_PKCUST;
			parameters[16].Value = model.C_PKSENDTYPE;
			parameters[17].Value = model.C_PKSALECORP;
			parameters[18].Value = model.C_PKSALEORG;
			parameters[19].Value = model.C_PKSENDSTOREORG;
			parameters[20].Value = model.C_PKOPERATOR;
			parameters[21].Value = model.C_PKOPRDEPART;
			parameters[22].Value = model.C_PKPLANPERSON;
			parameters[23].Value = model.C_PKAPPRPERSON;
			parameters[24].Value = model.D_APPRDATE;
			parameters[25].Value = model.C_PKARRIVEAREA;
			parameters[26].Value = model.C_DESTADDRESS;
			parameters[27].Value = model.C_RECEIPTCORPID;
			parameters[28].Value = model.C_BIZTYPE;
			parameters[29].Value = model.C_REMARK;
			parameters[30].Value = model.C_PKSENDAREA;
			parameters[31].Value = model.C_PKDELIVORG;
			parameters[32].Value = model.C_UNITID;
			parameters[33].Value = model.C_VFREE1;
			parameters[34].Value = model.C_VFREE2;
			parameters[35].Value = model.C_VFREE3;
			parameters[36].Value = model.C_VFREE4;
			parameters[37].Value = model.C_ID;

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
			strSql.Append("delete from TMP_DAYPLAN ");
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
			strSql.Append("delete from TMP_DAYPLAN ");
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
		public Mod_TMP_DAYPLAN GetModelID(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_PLCODE,C_PKBILLB,C_PKBILLH,C_CONNO,C_ORDERNO,C_PKINV,C_PKASSISTMEASURE,N_ASSISTNUM,N_NUM,N_UNITPRICE,N_MONEY,D_PLANDATE,D_ORDSNDATE,D_REQUIREDATE,D_SNDDATE,C_PKCUST,C_PKSENDTYPE,C_PKSALECORP,C_PKSALEORG,C_PKSENDSTOREORG,C_PKOPERATOR,C_PKOPRDEPART,C_PKPLANPERSON,C_PKAPPRPERSON,D_APPRDATE,C_PKARRIVEAREA,C_DESTADDRESS,C_RECEIPTCORPID,C_BIZTYPE,C_REMARK,C_PKSENDAREA,C_PKDELIVORG,C_UNITID,C_VFREE1,C_VFREE2,C_VFREE3,C_VFREE4,C_SALECODE from TMP_DAYPLAN ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TMP_DAYPLAN model = new Mod_TMP_DAYPLAN();
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
        public Mod_TMP_DAYPLAN GetModelBYID(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_PLCODE,C_PKBILLB,C_PKBILLH,C_CONNO,C_ORDERNO,C_PKINV,C_PKASSISTMEASURE,N_ASSISTNUM,N_NUM,N_UNITPRICE,N_MONEY,D_PLANDATE,D_ORDSNDATE,D_REQUIREDATE,D_SNDDATE,C_PKCUST,C_PKSENDTYPE,C_PKSALECORP,C_PKSALEORG,C_PKSENDSTOREORG,C_PKOPERATOR,C_PKOPRDEPART,C_PKPLANPERSON,C_PKAPPRPERSON,D_APPRDATE,C_PKARRIVEAREA,C_DESTADDRESS,C_RECEIPTCORPID,C_BIZTYPE,C_REMARK,C_PKSENDAREA,C_PKDELIVORG,C_UNITID,C_VFREE1,C_VFREE2,C_VFREE3,C_VFREE4,C_SALECODE,N_EXEC_STATUS from TMP_DAYPLAN ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            Mod_TMP_DAYPLAN model = new Mod_TMP_DAYPLAN();
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
        public Mod_TMP_DAYPLAN GetModel(string C_PLCODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_PLCODE,C_PKBILLB,C_PKBILLH,C_CONNO,C_ORDERNO,C_PKINV,C_PKASSISTMEASURE,N_ASSISTNUM,N_NUM,N_UNITPRICE,N_MONEY,D_PLANDATE,D_ORDSNDATE,D_REQUIREDATE,D_SNDDATE,C_PKCUST,C_PKSENDTYPE,C_PKSALECORP,C_PKSALEORG,C_PKSENDSTOREORG,C_PKOPERATOR,C_PKOPRDEPART,C_PKPLANPERSON,C_PKAPPRPERSON,D_APPRDATE,C_PKARRIVEAREA,C_DESTADDRESS,C_RECEIPTCORPID,C_BIZTYPE,C_REMARK,C_PKSENDAREA,C_PKDELIVORG,C_UNITID,C_VFREE1,C_VFREE2,C_VFREE3,C_VFREE4,C_SALECODE from TMP_DAYPLAN ");
			strSql.Append(" where C_PLCODE=:C_PLCODE ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_PLCODE", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_PLCODE;

			Mod_TMP_DAYPLAN model=new Mod_TMP_DAYPLAN();
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
		public Mod_TMP_DAYPLAN DataRowToModel(DataRow row)
		{
			Mod_TMP_DAYPLAN model=new Mod_TMP_DAYPLAN();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_PLCODE"]!=null)
				{
					model.C_PLCODE=row["C_PLCODE"].ToString();
				}
				if(row["C_PKBILLB"]!=null)
				{
					model.C_PKBILLB=row["C_PKBILLB"].ToString();
				}
				if(row["C_PKBILLH"]!=null)
				{
					model.C_PKBILLH=row["C_PKBILLH"].ToString();
				}
				if(row["C_CONNO"]!=null)
				{
					model.C_CONNO=row["C_CONNO"].ToString();
				}
				if(row["C_ORDERNO"]!=null)
				{
					model.C_ORDERNO=row["C_ORDERNO"].ToString();
				}
				if(row["C_PKINV"]!=null)
				{
					model.C_PKINV=row["C_PKINV"].ToString();
				}
				if(row["C_PKASSISTMEASURE"]!=null)
				{
					model.C_PKASSISTMEASURE=row["C_PKASSISTMEASURE"].ToString();
				}
				if(row["N_ASSISTNUM"]!=null && row["N_ASSISTNUM"].ToString()!="")
				{
					model.N_ASSISTNUM=decimal.Parse(row["N_ASSISTNUM"].ToString());
				}
				if(row["N_NUM"]!=null && row["N_NUM"].ToString()!="")
				{
					model.N_NUM=decimal.Parse(row["N_NUM"].ToString());
				}
				if(row["N_UNITPRICE"]!=null && row["N_UNITPRICE"].ToString()!="")
				{
					model.N_UNITPRICE=decimal.Parse(row["N_UNITPRICE"].ToString());
				}
				if(row["N_MONEY"]!=null && row["N_MONEY"].ToString()!="")
				{
					model.N_MONEY=decimal.Parse(row["N_MONEY"].ToString());
				}
				if(row["D_PLANDATE"]!=null && row["D_PLANDATE"].ToString()!="")
				{
					model.D_PLANDATE=DateTime.Parse(row["D_PLANDATE"].ToString());
				}
				if(row["D_ORDSNDATE"]!=null && row["D_ORDSNDATE"].ToString()!="")
				{
					model.D_ORDSNDATE=DateTime.Parse(row["D_ORDSNDATE"].ToString());
				}
				if(row["D_REQUIREDATE"]!=null && row["D_REQUIREDATE"].ToString()!="")
				{
					model.D_REQUIREDATE=DateTime.Parse(row["D_REQUIREDATE"].ToString());
				}
				if(row["D_SNDDATE"]!=null && row["D_SNDDATE"].ToString()!="")
				{
					model.D_SNDDATE=DateTime.Parse(row["D_SNDDATE"].ToString());
				}
				if(row["C_PKCUST"]!=null)
				{
					model.C_PKCUST=row["C_PKCUST"].ToString();
				}
				if(row["C_PKSENDTYPE"]!=null)
				{
					model.C_PKSENDTYPE=row["C_PKSENDTYPE"].ToString();
				}
				if(row["C_PKSALECORP"]!=null)
				{
					model.C_PKSALECORP=row["C_PKSALECORP"].ToString();
				}
				if(row["C_PKSALEORG"]!=null)
				{
					model.C_PKSALEORG=row["C_PKSALEORG"].ToString();
				}
				if(row["C_PKSENDSTOREORG"]!=null)
				{
					model.C_PKSENDSTOREORG=row["C_PKSENDSTOREORG"].ToString();
				}
				if(row["C_PKOPERATOR"]!=null)
				{
					model.C_PKOPERATOR=row["C_PKOPERATOR"].ToString();
				}
				if(row["C_PKOPRDEPART"]!=null)
				{
					model.C_PKOPRDEPART=row["C_PKOPRDEPART"].ToString();
				}
				if(row["C_PKPLANPERSON"]!=null)
				{
					model.C_PKPLANPERSON=row["C_PKPLANPERSON"].ToString();
				}
				if(row["C_PKAPPRPERSON"]!=null)
				{
					model.C_PKAPPRPERSON=row["C_PKAPPRPERSON"].ToString();
				}
				if(row["D_APPRDATE"]!=null && row["D_APPRDATE"].ToString()!="")
				{
					model.D_APPRDATE=DateTime.Parse(row["D_APPRDATE"].ToString());
				}
				if(row["C_PKARRIVEAREA"]!=null)
				{
					model.C_PKARRIVEAREA=row["C_PKARRIVEAREA"].ToString();
				}
				if(row["C_DESTADDRESS"]!=null)
				{
					model.C_DESTADDRESS=row["C_DESTADDRESS"].ToString();
				}
				if(row["C_RECEIPTCORPID"]!=null)
				{
					model.C_RECEIPTCORPID=row["C_RECEIPTCORPID"].ToString();
				}
				if(row["C_BIZTYPE"]!=null)
				{
					model.C_BIZTYPE=row["C_BIZTYPE"].ToString();
				}
				if(row["C_REMARK"]!=null)
				{
					model.C_REMARK=row["C_REMARK"].ToString();
				}
				if(row["C_PKSENDAREA"]!=null)
				{
					model.C_PKSENDAREA=row["C_PKSENDAREA"].ToString();
				}
				if(row["C_PKDELIVORG"]!=null)
				{
					model.C_PKDELIVORG=row["C_PKDELIVORG"].ToString();
				}
				if(row["C_UNITID"]!=null)
				{
					model.C_UNITID=row["C_UNITID"].ToString();
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
				if(row["C_VFREE4"]!=null)
				{
					model.C_VFREE4=row["C_VFREE4"].ToString();
				}
                if (row["C_SALECODE"] != null)
                {
                    model.C_SALECODE = row["C_SALECODE"].ToString();
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
			strSql.Append("select C_ID,C_PLCODE,C_PKBILLB,C_PKBILLH,C_CONNO,C_ORDERNO,C_PKINV,C_PKASSISTMEASURE,N_ASSISTNUM,N_NUM,N_UNITPRICE,N_MONEY,D_PLANDATE,D_ORDSNDATE,D_REQUIREDATE,D_SNDDATE,C_PKCUST,C_PKSENDTYPE,C_PKSALECORP,C_PKSALEORG,C_PKSENDSTOREORG,C_PKOPERATOR,C_PKOPRDEPART,C_PKPLANPERSON,C_PKAPPRPERSON,D_APPRDATE,C_PKARRIVEAREA,C_DESTADDRESS,C_RECEIPTCORPID,C_BIZTYPE,C_REMARK,C_PKSENDAREA,C_PKDELIVORG,C_UNITID,C_VFREE1,C_VFREE2,C_VFREE3,C_VFREE4 ");
			strSql.Append(" FROM TMP_DAYPLAN ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOra.Query(strSql.ToString());
		}

        #endregion  BasicMethod

        #region //更新日计划导入NC状态
        public bool UpdateDayPlanStatus(string plancode)
        {
            //D_NC_DATE
            string strSql = "update tmp_dayplan set N_EXEC_STATUS=1 where C_PLCODE='"+plancode+"'";
            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }
        #endregion

    }
}

