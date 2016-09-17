using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitmapPixelsDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void FileOpenMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenImageDialog.ShowDialog() == DialogResult.OK)
            {
                using (var originalBitmap = Bitmap.FromFile(OpenImageDialog.FileName) as Bitmap)
                {
                    OriginalImage.Image = originalBitmap.Clone() as Bitmap;

                    Stopwatch timer = new Stopwatch();

                    BitmapPixelsGrayscaleImage.Image = await Task.Run(() =>
                    {
                        timer.Start();

                        Bitmap grayscaleBitmap = originalBitmap.Clone() as Bitmap;

                        using (BitmapPixels grayscaleBitmapPixels = new BitmapPixels(grayscaleBitmap))
                        {
                            grayscaleBitmapPixels.Lock();

                            MakeGrayscal(grayscaleBitmapPixels);

                            timer.Stop();

                            return grayscaleBitmap;
                        }
                    });

                    BitmapPixelsConvertTimeLabel.Text = $"{timer.ElapsedMilliseconds} milliseconds";

                    timer.Reset();

                    SetPixelsGrayscaleImage.Image = await Task.Run(() =>
                    {
                        timer.Start();

                        Bitmap grayscaleBitmap = originalBitmap.Clone() as Bitmap;

                        MakeGrayscal(grayscaleBitmap);

                        timer.Stop();

                        return grayscaleBitmap;
                    });

                    SetPixelConvertTimeLabel.Text = $"{timer.ElapsedMilliseconds} milliseconds";
                }
            }
        }

        /// <summary>
        /// Converts the specified BitmapPixels to grayscale.
        /// </summary>
        /// <param name="pixels">The BitmapPixels to convert.</param>
        public static void MakeGrayscal(BitmapPixels pixels)
        {
            unsafe
            {
                RGBAColor* color_ps = pixels.Pointer;

                byte new_pixel;
                for (int pixel = 0; pixel < pixels.Height * pixels.Width; pixel++, color_ps++)
                {
                    new_pixel = (byte)(color_ps->R * 0.2126 + color_ps->G * 0.7152 + color_ps->B * 0.0722);
                    *color_ps = new RGBAColor(new_pixel, new_pixel, new_pixel, color_ps->A); //set the new pixel using the existing alpha component
                }
            }
        }

        /// <summary>
        /// Converts the specified BitmapPixels to grayscale.
        /// </summary>
        /// <param name="pixels">The BitmapPixels to convert.</param>
        public static void MakeGrayscal(Bitmap bitmap)
        {
            byte new_pixel;
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color c = bitmap.GetPixel(x, y);
                    new_pixel = (byte)(c.R * 0.2126 + c.G * 0.7152 + c.B * 0.0722); ;

                    bitmap.SetPixel(x, y, Color.FromArgb(c.A, new_pixel, new_pixel, new_pixel)); //set the new pixel using the existing alpha component
                }
            }
        }
    }
}
