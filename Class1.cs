using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;
//作者@似最初
//微信公众号：追鸽小记
namespace IconUtility
    {
    /// <summary>
    /// 提供操作图标的实用方法
    /// </summary>
    public static class IconHelper
        {
        private static Font segoeFluentFont;

        /// <summary>
        /// 加载 Segoe Fluent 字体
        /// </summary>
        /// <param name="fontData">字体文件的字节数据</param>
        /// <param name="fontSize">字体大小</param>
        public static void LoadSegoeFluentFont(byte[] fontData, float fontSize)
            {
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            fontCollection.AddMemoryFont(fontPtr, fontData.Length);
            Marshal.FreeCoTaskMem(fontPtr);

            segoeFluentFont = new Font(fontCollection.Families[0], fontSize);
            }

        /// <summary>
        /// 绘制 Segoe Fluent 图标并生成图像
        /// </summary>
        /// <param name="iconUnicode">图标的 Unicode 编码</param>
        /// <param name="imageWidth">图像宽度</param>
        /// <param name="imageHeight">图像高度</param>
        /// <param name="fontColor">字体颜色</param>
        /// <param name="backgroundColor">背景颜色</param>
        /// <returns>生成的图像</returns>
        public static Bitmap GetSegoeFluentIconImage(string iconUnicode, int imageWidth, int imageHeight, Color fontColor, Color backgroundColor)
            {
            Brush fontBrush = new SolidBrush(fontColor);
            Brush backgroundBrush = new SolidBrush(backgroundColor);

            Bitmap iconImage = new Bitmap(imageWidth, imageHeight);
            Graphics g = Graphics.FromImage(iconImage);

            g.FillRectangle(backgroundBrush, 0, 0, imageWidth, imageHeight);

            SizeF iconSize = g.MeasureString(iconUnicode, segoeFluentFont);
            float x = (imageWidth - iconSize.Width) / 2;
            float y = (imageHeight - iconSize.Height) / 2;

            g.DrawString(iconUnicode, segoeFluentFont, fontBrush, new PointF(x, y));

            return iconImage;
            }

        /// <summary>
        /// 将图像保存到桌面
        /// </summary>
        /// <param name="iconImage">要保存的图像</param>
        public static void SaveIconToDesktop(System.Drawing.Image iconImage)
            {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "icon.png");
            iconImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            }

        //使用Demo
        #region
        //假设 Segoe Fluent ttf 文件名为 "SegoeFluent.ttf"，并已添加到资源文件中
        //byte[] fontData = Properties.Resources.Segoe_Fluent; // "SegoeFluent" 是资源文件中 ttf 文件的名称
        //float fontSize = 32f;
        //IconHelper.LoadSegoeFluentFont(fontData, fontSize);

        //    string iconUnicode = "\ue776"; // 假设您想要绘制的图标的 Unicode 编码
        //int imageWidth = 60;
        //int imageHeight = 60;
        //Color fontColor = ColorTranslator.FromHtml("#239565"); // 将 RGB 值 #239565 转为 Color 对象
        //Color backgroundColor = Color.White;
        //Bitmap iconImage = IconHelper.GetSegoeFluentIconImage(iconUnicode, imageWidth, imageHeight, fontColor, backgroundColor);

        //button21.Label = "按钮";
        //    button21.Image =IconHelper.GetSegoeFluentIconImage(iconUnicode, imageWidth, imageHeight, fontColor, backgroundColor); // 根据 Segoe Fluent 字体编码获取图标
        //    button21.ShowImage = true;

        //    // 保存图标到桌面
        //    IconHelper.SaveIconToDesktop(iconImage);
        #endregion





        }
    }
