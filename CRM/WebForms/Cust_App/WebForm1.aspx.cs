using NF.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM.Cust_App
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          Response.Write( Encrypt.Decode("C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B", "xgcrm001"));
        }
    }
}