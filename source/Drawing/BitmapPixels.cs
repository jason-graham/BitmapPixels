//---------------------------------------------------------------------------- 
//
//  Copyright (C) Jason Graham.  All rights reserved.
// 
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
// 
// History
//  09/06/16    Updated field names
//  05/22/13    Created
//
//---------------------------------------------------------------------------

namespace System.Drawing
{
    using System.Drawing.Imaging;
    using System.Security.Permissions;

    /// <summary>
    /// The BitmapPixels is used for fast access to a Bitmap's Pixels.
    /// </summary>
    public sealed class BitmapPixels : IDisposable
    {
        #region Fields
        /// <summary>
        /// Defines the base Bitmap of the BitmapPixels.
        /// </summary>
        private Bitmap bitmap;
        /// <summary>
        /// Defines the BitmapData used to lock and unlock the Bitmap.
        /// </summary>
        private BitmapData bitmapData;
        /// <summary>
        /// A pointer to the color data of the base Bitmap.
        /// </summary>
        private unsafe RGBAColor* pointer = null;
        /// <summary>
        /// Determines if the Bitmap is locked.
        /// </summary>
        private bool locked;
        /// <summary>
        /// Defines the area to lock the Bitmap.
        /// </summary>
        private Rectangle bounds;
        /// <summary>
        /// Determines if the bitmap is owned by this instance and should be disposed.
        /// </summary>
        private bool bitmapOwner;
        #endregion

        #region Properties
        /// <summary>
        /// Returns the Bitmap's underlying pointer.
        /// </summary>
        public unsafe RGBAColor* Pointer
        {
            [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                return pointer;
            }
        }

        /// <summary>
        /// Gets the width of the Bitmap.
        /// </summary>
        public int Width
        {
            get
            {
                return bounds.Width;
            }
        }

        /// <summary>
        /// Gets the height of the Bitmap.
        /// </summary>
        public int Height
        {
            get
            {
                return bounds.Height;
            }
        }

        /// <summary>
        /// Get the size of the Bitmap.
        /// </summary>
        public Size Size
        {
            get
            {
                return bounds.Size;
            }
        }

        /// <summary>
        /// Get the Bitmap this represents.
        /// </summary>
        public Bitmap Bitmap
        {
            get
            {
                return bitmap;
            }
        }

        /// <summary>
        /// Determines if the Bitmap is locked in memory. Call Unlock to unlock the Bitmap.
        /// </summary>
        public bool IsLocked
        {
            get
            {
                return locked;
            }
        }

        /// <summary>
        /// Gets or sets the pixel at the specified coordinates.
        /// </summary>
        /// <param name="x">The x axis index.</param>
        /// <param name="y">The y axis index.</param>
        /// <returns>The color at the specified coordinates.</returns>
        public RGBAColor this[int x, int y]
        {
            [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                ThrowIfUnlocked();
                CheckPoint(x, y);

                unsafe
                {
                    return *(pointer + bounds.Width * y + x);
                }
            }
            [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            set
            {
                ThrowIfUnlocked();
                CheckPoint(x, y);

                unsafe
                {
                    *(pointer + bounds.Width * y + x) = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the pixel at the specified coordinates.
        /// </summary>
        /// <param name="coordinates">The pixel coordinates.</param>
        /// <returns>The color at the specified coordinates.</returns>
        public RGBAColor this[Point coordinates]
        {
            get
            {
                return this[coordinates.X, coordinates.Y];
            }
            set
            {
                this[coordinates.X, coordinates.Y] = value;
            }
        }

        /// <summary>
        /// Gets or sets an array of colors.
        /// </summary>
        public RGBAColor[,] Colors
        {
            [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                ThrowIfUnlocked();

                RGBAColor[,] data = new RGBAColor[Size.Width, Size.Height];

                unsafe
                {
                    RGBAColor* colors_ps = pointer;

                    for (int y = 0; y < Size.Height; y++)
                    {
                        for (int x = 0; x < Size.Width; x++)
                        {
                            data[x, y] = *colors_ps;
                            colors_ps++;
                        }
                    }
                }

                return data;
            }
            [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            set
            {
                ThrowIfUnlocked();

                if (value.GetLength(0) != Size.Width)
                    throw new ArgumentException("Dimension 0 has an invalid number of elements.");
                if (value.GetLength(1) != Size.Height)
                    throw new ArgumentException("Dimension 1 has an invalid number of elements.");

                unsafe
                {
                    RGBAColor* colors_ps = pointer;

                    for (int y = 0; y < Size.Height; y++)
                    {
                        for (int x = 0; x < Size.Width; x++)
                        {
                            *colors_ps = value[x, y];
                            colors_ps++;
                        }
                    }
                }
            }
        }

        #region Property Validation Methods
        private void ThrowIfUnlocked()
        {
            if (!locked)
                throw new InvalidOperationException("Call BitmapPixels.Lock before attempting this operation.");
        }

        /// <summary>
        /// Validates the point.
        /// </summary>
        /// <param name="x">The x axis index.</param>
        /// <param name="y">The y axis index.</param>
        private void CheckPoint(int x, int y)
        {
            if (x < 0)
                throw new ArgumentException("x cannot be less than 0.", "x");
            if (y < 0)
                throw new ArgumentException("y cannot be less than 0.", "y");
            if (x >= bounds.Width)
                throw new ArgumentException("x cannot be greater than the Width - 1.", "x");
            if (y >= bounds.Height)
                throw new ArgumentException("x cannot be greater than the Height - 1.", "y");
        } 
        #endregion
        #endregion

        #region Constuctor
        /// <summary>
        /// Initializes the BitmapPixels class with a source Bitmap.
        /// </summary>
        /// <param name="source">The source Bitmap to load the pixels from.</param>
        public BitmapPixels(Bitmap source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            PixelFormat format = source.PixelFormat;

            if (!ValidPixelFormat(format))
                throw new InvalidPixelFormatException(format);

            GraphicsUnit unit = GraphicsUnit.Pixel;

            bitmapOwner = false;
            bitmap = source;
            bounds = Rectangle.Truncate(bitmap.GetBounds(ref unit));
        }

        /// <summary>
        /// Initializes the BitmapPixels using an empty Bitmap.
        /// </summary>
        /// <param name="size">The size of the Bitmap.</param>
        public BitmapPixels(Size size)
        {
            bitmapOwner = true;
            bitmap = new Bitmap(size.Width, size.Height);
            bounds = new Rectangle(Point.Empty, size);
        }
        #endregion

        #region Lock / Unlock
        /// <summary>
        /// Lock the Bitmap to access pixel's from pointer. You must unlock the Bitmap or dispose to release resources.
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void Lock()
        {
            if (locked)
                return;

            bitmapData = bitmap.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            locked = true;

            unsafe
            {
                pointer = (RGBAColor*)bitmapData.Scan0.ToPointer();
            }
        }

        /// <summary>
        /// Unlocks the Bitmap after a call to Lock.
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void Unlock()
        {
            if (!locked)
                return;

            bitmap.UnlockBits(bitmapData);
            locked = false;

            unsafe
            {
                pointer = null;
            }
        }
        #endregion

        #region Disposing
        /// <summary>
        /// Destructor to handle disposing this instance.
        /// </summary>
        ~BitmapPixels()
        {
            Dispose(false);
        }

        /// <summary>
        /// Disposes the instance, releasing managed and unmanaged memory.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes unmanaged and optionally, managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (locked)
                Unlock();

            if (disposing)
            {
                if (bitmap != null && bitmapOwner)
                {
                    bitmap.Dispose();
                    bitmap = null;
                }
            }
        }
        #endregion

        /// <summary>
        /// Determines if the specified PixelFormat is a format which can be loaded with the BitmapPixels class.
        /// </summary>
        /// <param name="format">The format of the color data for each pixel in the image.</param>
        /// <returns>true if the format is 24bpp Rgb or 32bpp Argb/PArgb/Rgb; otherwise false.</returns>
        public static bool ValidPixelFormat(PixelFormat format)
        {
            switch (format)
            {
                case PixelFormat.Format24bppRgb:
                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb:
                case PixelFormat.Format32bppRgb:
                    return true;
                default:
                    return false;
            }
        }
    }
}
