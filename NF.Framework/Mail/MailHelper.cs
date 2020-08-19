using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework
{
    public class MailHelper
    {
        public MailHelper() { }
        #region 发送邮件
        /// <summary>
        /// 邮件发送
        /// </summary>
        /// <param name="mailaddress">收件人地址</param>
        /// <param name="title">邮件标题</param>
        /// <param name="file">附件</param>
        /// <param name="content">内容</param>
        /// <param name="fromname">发送人邮箱</param>
        /// <param name="pwd">发送人邮箱密码</param>
        /// 已测试，可用
        public static bool SendMail(string mailaddress, string title, string[] lstFiles, string content, string fromname, string pwd)
        {
            MailMessage mails = new MailMessage();
            mails.From = new MailAddress(fromname, fromname, System.Text.Encoding.UTF8);//说明指定发件人的信息
            mails.Subject = title;
            if (lstFiles != null)
            {
                //附件 
                foreach (string item in lstFiles)
                {
                    mails.Attachments.Add(new Attachment(item));
                }
            }
            mails.BodyEncoding = System.Text.Encoding.UTF8;
            mails.IsBodyHtml = true;
            mails.Body = content;
            mails.Priority = MailPriority.High;//优先级
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential(fromname, pwd);//发送人的邮箱
            string host = fromname.Substring(fromname.LastIndexOf("@") + 1);
            smtp.Host = "smtp." + host;
            //收件人的邮箱
            //string[] maillist = mailaddress.Split(';');
            //for (int i = 0; i < maillist.Length; i++)
            //{
            //    mails.To.Add(maillist[i]);
            //}

            string[] list = mailaddress.Split(',', ';', '，', '；');//收件人
            foreach (var item in list)
            {
                mails.To.Add(item);
            }

            try
            {
                smtp.EnableSsl = true;//ssl加密
                //smtp.Timeout = 1200;//超时时间
                smtp.Send(mails);
                mails.Dispose();
                return true;
                //HttpContext.Current.Response.Write(" <script>alert('发送成功'); </script>");
            }
            catch (Exception e)
            {
                return false;
                // HttpContext.Current.Response.Write(" <script>alert('" + e.Message + "'); </script>");
            }
        }

        #endregion
    }
}
