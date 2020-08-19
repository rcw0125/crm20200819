using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


using System.Text.RegularExpressions;



namespace NF.Framework
{
    /// <summary>
    /// StringFormat 的摘要说明
    /// </summary>
    public class StringFormat
    {
        public StringFormat()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public static string ResolveUrl(string url)
        {
            return (new Control()).ResolveUrl(url);
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string SubString(string str, int n)
        {
            string temp = string.Empty;
            if (System.Text.Encoding.Default.GetByteCount(str) <= n)//如果长度比需要的长度n小,返回原字符串
            {
                return str;
            }
            else
            {
                int t = 0;
                char[] q = str.ToCharArray();
                for (int i = 0; i < q.Length && t < n; i++)
                {
                    if ((int)q[i] >= 0x4E00 && (int)q[i] <= 0x9FA5)//是否汉字
                    {
                        temp += q[i];
                        t += 2;
                    }
                    else
                    {
                        temp += q[i];
                        t++;
                    }
                }
                return (temp + "...");
            }
        }


        /// <summary>
        /// 过滤内容里的html标签
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string RemoveHtmlTag(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" no[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex10 = new System.Text.RegularExpressions.Regex(@"<div>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex11 = new System.Text.RegularExpressions.Regex(@"</div>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记 
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性 网管网bitsCN.com 
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件 
            html = regex4.Replace(html, ""); //过滤iframe 
            html = regex5.Replace(html, ""); //过滤frameset 
            html = regex6.Replace(html, ""); //过滤frameset 
            html = regex7.Replace(html, ""); //过滤frameset 
            html = regex8.Replace(html, ""); //过滤frameset 
            html = regex9.Replace(html, "");
            html = regex10.Replace(html, ""); //过滤frameset 
            html = regex11.Replace(html, "");
            html = html.Replace(" ", "");


            html = html.Replace("</strong>", "");
            html = html.Replace("<strong>", "");
            return html;
        }

        /// <summary>
        /// label显示使用
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string huanhang(string value)
        {
            return value.Replace("\r\n", "<br/>").Replace("\r", "<br/>").Replace("\n", "<br/>").Replace(" ", "&nbsp;");
        }

        public static void SetBackPageNo(System.Web.UI.Page Page)
        {
            //在页面的Page_Load 中调用，用全局的Session保存返回父页面的次数
            //得到传来页面的文件名称，是唯一的，以示区别其它的Session
            string back_name = System.Web.HttpContext.Current.Request.Path;
            if (!Page.IsPostBack)
            {
                HttpContext.Current.Session[back_name] = 0;   //首次进入本页面，初始值设置为0
            }
            //累计本页面刷新次数（首次和回发），以便后面得到返回次数，
            HttpContext.Current.Session[back_name] = Convert.ToInt32(HttpContext.Current.Session[back_name]) + 1;
        }

        /// <summary>
        /// 合同状态
        /// </summary>
        /// <param name="OrderStateId">标识</param>
        /// <returns></returns>
        public static string GetOrderState(object OrderStateId)
        {
            string _name = string.Empty;
            int _status = Convert.ToInt32(OrderStateId);

            switch (_status)
            {
                case -1:
                    _name = "未提交";
                    break;
                case 0:
                    _name = "待审";
                    break;
                case 1:
                    _name = "审核中";
                    break;
                case 2:
                    _name = "生效";
                    break;
                case 3:
                    _name = "变更";
                    break;
                case 4:
                    _name = "审核通过";
                    break;
                case 5:
                    _name = "冻结";
                    break;
                case 6:
                    _name = "终止";
                    break;

            }
            return _name;
        }

        /// <summary>
        /// 合同状态
        /// </summary>
        /// <param name="flag">标识</param>
        /// <returns></returns>
        public static string GetStatus(object flag)
        {
            string _name = string.Empty;
            int _status = Convert.ToInt32(flag);

            switch (_status)
            {
                case -1:
                    _name = "未提交";
                    break;
                case 0:
                    _name = "已提交";
                    break;
                case 1:
                    _name = "已处理";
                    break;
            }
            return _name;
        }




    }
}
