using SuperSocket.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSocketServer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBind1();
            }
        }

        private void DataBind1()
        {
            List<CrmSocketSession> users = CrmSocketConnManager.Connections.SelectMany(w => w.Value).ToList();
            this.GridView1.DataSource = users;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var session = GridView1.Rows[e.RowIndex].Cells[0].Text;

            if (string.IsNullOrEmpty(session) == false)
            {
                CrmSocketConnManager.ShutDown(session, "管理员强制下线");
            }

            DataBind1();
            //string strUid = GridView1.Rows[e.RowIndex].Cells[0].Text;
            //CrmSocketSession users = new CrmSocketSession() { Uid = strUid };
            //context.User.Attach(users);
            //context.User.Remove(users);
            //context.SaveChanges();
            //DataBind();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            DataBind1();
        }
    }
}