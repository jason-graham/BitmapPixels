//---------------------------------------------------------------------------- 
//
//  Copyright (C) CSharp Labs.  All rights reserved.
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
//  09/06/16    Implemented ISerializable
//  05/22/13    Created
//
//---------------------------------------------------------------------------

using System.Globalization;
using System.Runtime.Serialization;

namespace System.Drawing.Imaging
{
    /// <summary>
    /// Represents an Exception raised when the PixelFormat of an Image is invalid for the current operation.
    /// </summary>
    [Serializable]
    public sealed class InvalidPixelFormatException : Exception, ISerializable
    {
        private const string PIXELFORMAT_NAME = "RGBA";

        #region Properties
        private PixelFormat pixelFormat;

        /// <summary>
        /// Gets the PixelFormat of the Image.
        /// </summary>
        public PixelFormat PixelFormat
        {
            get
            {
                return pixelFormat;
            }
            private set
            {
                pixelFormat = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the InvalidPixelFormatException with the invalid format.
        /// </summary>
        /// <param name="pixelFormat">The invalid PixelFormat.</param>
        public InvalidPixelFormatException(PixelFormat pixelFormat)
            : base(string.Format(CultureInfo.InvariantCulture, "The PixelFormat '{0}' is an invalid format for the current operation.", pixelFormat))
        {
            PixelFormat = pixelFormat;
        }

        public InvalidPixelFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            PixelFormat = (PixelFormat)info.GetValue(PIXELFORMAT_NAME, typeof(PixelFormat));
        }
        #endregion

        #region ISerializable Implementation
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            base.GetObjectData(info, context);

            info.AddValue(PIXELFORMAT_NAME, PixelFormat);
        }
        #endregion
    }
}
