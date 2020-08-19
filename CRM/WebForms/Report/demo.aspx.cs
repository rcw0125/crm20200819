using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM.WebForms.Report
{
    public partial class demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'>_loading(2);</script>", false);
            if (get())
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _close();</script>", false);
            }

        }

        private bool get()
        {
            System.Threading.Thread.Sleep(5000);
            return true;
        }
    }
}