using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.WebSocket;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSocketServer
{
    public class CrmSocketServer : WebSocketServer<CrmSocketSession>
    {
        public const int SHUTDOWNCODE = 999;
        public const string HEARTBEAT = nameof(HEARTBEAT);
        public const string SHUTDONWREASON = "User Forced Exit";

        public CrmSocketServer()
        {
        }
    }

    public class CrmSocketMsg
    {
        /// <summary>
        /// 强制退出
        /// </summary>
        public const int SHUTDOWNCODE1 = 999;

        /// <summary>
        /// 非法请求
        /// </summary>
        public const int SHUTDOWNCODE2 = 405;

        public const string SHUTDOWNOFFLINE = "";
    }

    public class CrmSocketSession : JsonWebSocketSession<CrmSocketSession>
    {
        /// <summary>
        /// 连接时间
        /// </summary>
        public DateTime ConnectedTime { get; set; }
        public string ConnectedTimeStr { get => ConnectedTime.ToString("yyyy-MM-dd HH:mm:ss"); }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account
        {
            get
            {
                return this.Path.Split('/')[1];
            }
        }

        /// <summary>
        /// 是否是断线重连
        /// </summary>
        public bool IsReconnected
        {
            get
            {
                return this.Path.Split('/')[2] == "RE_CON";
            }
        }

        /// <summary>
        /// 客户端地址
        /// </summary>
        public string Address { get { return this.RemoteEndPoint?.Address?.ToString() ?? string.Empty; } }

        /// <summary>
        /// 未识别的请求
        /// </summary>
        public bool IsUnKnowScoket
        {
            get
            {
                return string.IsNullOrEmpty(this.Path) || this.Path.StartsWith("/") == false;
            }
        }

        public string LastTimeStr { get { return this.LastActiveTime.ToString("yyyy-MM-dd HH:mm:ss"); } }
    }

    public class CrmSocketConnManager
    {
        /// <summary>
        /// 管理socket客户端连接
        /// </summary>
        public static ConcurrentDictionary<string, List<CrmSocketSession>> Connections { get; } =
             new ConcurrentDictionary<string, List<CrmSocketSession>>();

        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="connSession"></param>
        public static void Connect(CrmSocketSession connSession)
        {
            connSession.ConnectedTime = DateTime.Now;

            var others = Connections.Where(w => w.Key == connSession.Account).SelectMany(x => x.Value).ToList();

            if (Connections.ContainsKey(connSession.Account) == false)
            {
                Connections[connSession.Account] = new List<CrmSocketSession>();
            }

            Connections[connSession.Account].Add(connSession);

            if (others.Any())
            {
                if (connSession.IsReconnected)
                {
                    var sames = others.Where(w => w.Address == connSession.Address).ToList();
                    foreach (var sameItem in sames)
                    {
                        // 下线同一机器下的过期session
                        ShutDown(sameItem.SessionID, "Time Out");

                        Connections[connSession.Account].Remove(sameItem);
                    }

                    if (others.Any(x => x.Address != connSession.Address))
                    {
                        // 说明在断线期间已经被人强制 登录了，
                        ShutDown(connSession.SessionID, "该用户已经在其他地方登录");
                    }
                }
                else
                {
                    // 强制退出
                    foreach (var otherSession in others)
                    {
                        if (otherSession.Connected)
                            ShutDown(otherSession.SessionID,
                                $"该用户已经在{connSession.RemoteEndPoint.Address}:{connSession.RemoteEndPoint.Port}强占登录");
                    }
                }
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="connSession"></param>
        public static void DisConnection(
            CrmSocketSession connSession,
            int code = CrmSocketServer.SHUTDOWNCODE,
            string reason = CrmSocketServer.SHUTDONWREASON)
        {
            if (connSession.Connected == true)
                connSession.CloseWithHandshake(code, reason);

            foreach (var item in Connections)
            {
                if (item.Key == connSession.Account)
                {
                    item.Value.Remove(connSession);
                    if (item.Value.Any() == false)
                    {
                        List<CrmSocketSession> removeValues = new List<CrmSocketSession>();
                        Connections.TryRemove(item.Key, out removeValues);
                    }
                    break;
                }
                else continue;
            }
        }

        public static void DisConnection(CrmSocketSession connSession, CloseReason value)
        {
            DisConnection(connSession, 3, value.ToString());
        }

        /// <summary>
        /// 验证是否有其他用户正在线上
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <param name="ip">客户端IP地址</param>
        /// <returns></returns>
        public static bool CheckSingleLogin(string account, string ip)
        {
            return Connections.Any(
                w =>
                w.Key == account &&
                w.Value.Any(
                    x =>
                    x.Address != ip &&
                    x.Connected == true));
        }

        /// <summary>
        /// 强制下线
        /// </summary>
        /// <param name="sessionId"></param>
        public static void ShutDown(string sessionId, string reason)
        {
            var sessions = Connections.SelectMany(w => w.Value).Where(w => w.SessionID == sessionId).ToList();
            foreach (var sessionItem in sessions)
            {
                sessionItem.SendJsonMessage(nameof(ShutDown), reason);
                //DisConnection(sessionItem);
            }
        }

        internal static void HeartBeat(CrmSocketSession session)
        {
            if (Connections.Any(w => w.Value.Contains(session)) == false)
            {
                Connect(session);
            }
        }
    }
}