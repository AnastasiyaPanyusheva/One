using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Pan_lab6.Models
{
    public static class Images
    {
        public static Image ToImage(this string text)
        {
            Image bmp = new Bitmap(1, 1);

            var drawing = Graphics.FromImage(bmp);
            var font = new Font("Times New Roman", 14);
            var textColor = Color.Black;
            var backColor = Color.White;
            var textSize = drawing.MeasureString(text, font);

            bmp.Dispose();
            drawing.Dispose();

            bmp = new Bitmap((int)textSize.Width, (int)textSize.Height);
            Brush textBrush = new SolidBrush(textColor);

            drawing = Graphics.FromImage(bmp);
            drawing.Clear(backColor);
            drawing.DrawString(text, font, textBrush, 0, 0);
            drawing.Save();
            textBrush.Dispose();
            drawing.Dispose();

            return bmp;
        }

        public static Stream ToStream(this Image image)
        {
            var Stream = new MemoryStream();
            image.Save(Stream, ImageFormat.Png);
            Stream.Position = 0;

            return Stream;
        }
    }
}