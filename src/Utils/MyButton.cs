using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SplashKitSDK;

namespace SoNeat.src.Utils
{
    public class MyButton
    {
        private Bitmap _buttonBitmap;
        public double X { get; set; }
        public double Y { get; set; }

        public MyButton(string bitmapPath, double x, double y)
        {
            bitmapPath = Utility.NormalizePath(bitmapPath);
            string BitmapName = Path.GetFileNameWithoutExtension(bitmapPath);
            if (SplashKit.HasBitmap(BitmapName))
            {
                _buttonBitmap = SplashKit.BitmapNamed(BitmapName);
            }
            else
            {
                _buttonBitmap = SplashKit.LoadBitmap(BitmapName, bitmapPath);
            }
            X = x;
            Y = y;
        }

        public void Draw()
        {
            SplashKit.DrawBitmap(_buttonBitmap, X, Y);
        }

        public bool IsClicked()
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                Point2D pt = SplashKit.MousePosition();
                return (pt.X >= X) && (pt.X <= (X + _buttonBitmap.Width))
                    && (pt.Y >= Y) && (pt.Y <= (Y + _buttonBitmap.Height));
            }
            return false;
        }

        public bool IsHovered()
        {
            Point2D pt = SplashKit.MousePosition();
            return (pt.X >= X) && (pt.X <= (X + _buttonBitmap.Width))
                && (pt.Y >= Y) && (pt.Y <= (Y + _buttonBitmap.Height));
        }
    }
}