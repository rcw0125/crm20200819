using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebSocketServer
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var set = ConfigurationManager.AppSettings["WEBSOCKET_PORT"];
            int port = 1212;

            int.TryParse(set, out port);

            CrmSocketServer server = new CrmSocketServer();
            server.NewSessionConnected += Server_NewSessionConnected;
            server.NewMessageReceived += Server_NewMessageReceived;
            server.SessionClosed += Server_SessionClosed;
            if (!server.Setup(port)) { return; }

            if (!server.Start()) { return; }

        }

        private void Server_SessionClosed(CrmSocketSession session, CloseReason value)
        {
            CrmSocketConnManager.DisConnection(session, value);
        }

        private void Server_NewMessageReceived(CrmSocketSession session, string value)
        {

            if (value == CrmSocketServer.HEARTBEAT)
            {
                CrmSocketConnManager.HeartBeat(session);
                session.SendJsonMessage("MSG", "SocketIsConnected");
                // 心跳信息不处理
                return;
            }
            session.SendJsonMessage("MSG", $"ServerRecivedMsg{value}");
        }

        private void Server_NewSessionConnected(CrmSocketSession session)
        {
            if (session.IsUnKnowScoket)
            {
                session.Close(CloseReason.SocketError);
            }

            CrmSocketConnManager.Connect(session);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}