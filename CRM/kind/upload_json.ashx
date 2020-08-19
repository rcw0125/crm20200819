<%@ webhandler Language="C#" class="Upload" %>

/**
 * KindEditor ASP.NET
 *
 * 本ASP.NET程序是演示程序，建议不要直接在实际项目中使用。
 * 如果您确定直接使用本程序，使用之前请仔细确认相关安全设置。
 *
 */

using System;
using System.Collections;
using System.Web;
using System.IO;
using System.Globalization;
using LitJson;
using System.Drawing;
using System.Drawing.Imaging;

public class Upload : IHttpHandler
{
	private HttpContext context;

	public void ProcessRequest(HttpContext context)
	{
		String aspxUrl = context.Request.Path.Substring(0, context.Request.Path.LastIndexOf("/") + 1);
		
		//文件保存目录路径
		String savePath = "../attached/";

		//文件保存目录URL
		String saveUrl = aspxUrl + "../attached/";

		//定义允许上传的文件扩展名
		Hashtable extTable = new Hashtable();
		extTable.Add("image", "gif,jpg,jpeg,png,bmp");
		extTable.Add("flash", "swf,flv");
        extTable.Add("flv", "flv");
		extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
		extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2,wps,7z,exe,msi,gif,jpg,jpeg,png,bmp,gd,sep");

		//最大文件大小
		long maxSize = 900000000000;
		this.context = context;

		HttpPostedFile imgFile = context.Request.Files["imgFile"];
		if (imgFile == null)
		{
			showError("请选择文件。");
		}

		String dirPath = context.Server.MapPath(savePath);
		if (!Directory.Exists(dirPath))
		{
			showError("上传目录不存在。");
		}

		String dirName = context.Request.QueryString["dir"];
		if (String.IsNullOrEmpty(dirName)) {
			dirName = "image";
		}
		if (!extTable.ContainsKey(dirName)) {
			showError("目录名不正确。");
		}

		String fileName = imgFile.FileName;
		String fileExt = Path.GetExtension(fileName).ToLower();

		if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
		{
			showError("上传文件大小超过限制。");
		}

		if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
		{
			showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。");
		}

		//创建文件夹
		dirPath += dirName + "/";
		saveUrl += dirName + "/";
		if (!Directory.Exists(dirPath)) {
			Directory.CreateDirectory(dirPath);
		}
		String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
		dirPath += ymd + "/";
		saveUrl += ymd + "/";
		if (!Directory.Exists(dirPath)) {
			Directory.CreateDirectory(dirPath);
		}

		String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
		String filePath = dirPath + newFileName;

		imgFile.SaveAs(filePath);

		String fileUrl = saveUrl + newFileName;

		Hashtable hash = new Hashtable();
		hash["error"] = 0;
		hash["url"] = fileUrl;

        string aa = "gif,jpg,jpeg,png,bmp";
        if (Array.IndexOf(aa.Split(','), fileExt.Substring(1).ToLower()) != -1)
        {
            Image imggg = Image.FromFile(filePath);
            if (imggg.Width > 800)
            {
                imggg.Dispose();
                MakeThumbnail(filePath, filePath, 800, 533, "HW", fileExt);
            }

            if (imgFile.InputStream == null || imgFile.InputStream.Length >800 * 533)
            {
                MakeThumbnail(filePath, filePath, 800, 533, "HW", fileExt);
            }



        }
        
		context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
		context.Response.Write(JsonMapper.ToJson(hash));
		context.Response.End();
	}

	private void showError(string message)
	{
		Hashtable hash = new Hashtable();
		hash["error"] = 1;
		hash["message"] = message;
		context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
		context.Response.Write(JsonMapper.ToJson(hash));
		context.Response.End();
	}

	public bool IsReusable
	{
		get
		{
			return true;
		}
	}

    // <summary>
    /// 生成缩略图
    /// </summary>
    /// <param name="originalImagePath">源图路径</param>
    /// <param name="thumbnailPath">缩略图路径</param>
    /// <param name="width">缩略图宽度</param>
    /// <param name="height">缩略图高度</param>
    /// <param name="mode">生成缩略图的方式:HW指定高宽缩放(可能变形);W指定宽，高按比例 H指定高，宽按比例 Cut指定高宽裁减(不变形)</param>　　
    /// <param name="mode">要缩略图保存的格式(gif,jpg,bmp,png) 为空或未知类型都视为jpg</param>　　
    public void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode, string imageType)
    {
        Image originalImage = Image.FromFile(originalImagePath);
        int towidth = width;
        int toheight = height;
        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;
        switch (mode)
        {
            case "HW"://指定高宽缩放（可能变形）　　　　　　　　
                break;
            case "W"://指定宽，高按比例　　　　　　　　　　
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形）　　　　　　　　
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }
        //新建一个bmp图片
        Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
        //新建一个画板
        Graphics g = System.Drawing.Graphics.FromImage(bitmap);
        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //清空画布并以透明背景色填充
        g.Clear(Color.Transparent);
        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
          new Rectangle(x, y, ow, oh),
          GraphicsUnit.Pixel);
        try
        {
            //以jpg格式保存缩略图
            switch (imageType.ToLower())
            {
                case ".gif":
                    originalImage.Dispose();
                    File.Delete(originalImagePath);
                    bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
                case ".jpg":
                    originalImage.Dispose();
                    File.Delete(originalImagePath);
                    bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
                case ".bmp":
                    originalImage.Dispose();
                    File.Delete(originalImagePath);
                    bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
                case ".png":
                    originalImage.Dispose();
                    File.Delete(originalImagePath);
                    bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
                default:
                    originalImage.Dispose();
                    File.Delete(originalImagePath);
                    bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
            }


        }
        catch (System.Exception)
        {

        }
        finally
        {
            bitmap.Dispose();
            g.Dispose();
        }
    }
}
