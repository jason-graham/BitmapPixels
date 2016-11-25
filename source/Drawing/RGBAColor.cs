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
//  09/06/16    Encapsulated fields
//  05/22/13    Created
//
//---------------------------------------------------------------------------

namespace System.Drawing
{
    using Runtime.Serialization;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The RGBAColor class represents a RGBA Color structure.
    /// </summary>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct RGBAColor : IComparable, IComparable<RGBAColor>, IEquatable<RGBAColor>, ISerializable
    {
        /// <summary>
        /// Represents an RGBAColor structure that is empty.
        /// </summary>
        public static readonly RGBAColor Empty = new RGBAColor(0, 0, 0, 0);

        /// <summary>
        /// Defines the name of the RGBA field used for serialization.
        /// </summary>
        private const string RGBA_NAME = "RGBA";

        #region Fields
        /// <summary>
        /// Defines the Blue component value.
        /// </summary>
        [FieldOffset(0)]
        private readonly byte b;

        /// <summary>
        /// Defines the Green component value.
        /// </summary>
        [FieldOffset(1)]
        private readonly byte g;

        /// <summary>
        /// Defines the Red component value.
        /// </summary>
        [FieldOffset(2)]
        private readonly byte r;

        /// <summary>
        /// Defines the Alpha component.
        /// </summary>
        [FieldOffset(3)]
        private readonly byte a;

        /// <summary>
        /// Defines the 4 color components as an integer.
        /// </summary>
        [FieldOffset(0)]
        private readonly int rgba;
        #endregion

        #region Properties
        /// <summary>
        /// Defines the Blue component value.
        /// </summary>
        public byte B
        {
            get
            {
                return b;
            }
        }

        /// <summary>
        /// Defines the Green component value.
        /// </summary>
        public byte G
        {
            get
            {
                return g;
            }
        }

        /// <summary>
        /// Defines the Red component value.
        /// </summary>
        public byte R
        {
            get
            {
                return r;
            }
        }

        /// <summary>
        /// Defines the Alpha component.
        /// </summary>
        public byte A
        {
            get
            {
                return a;
            }
        }

        /// <summary>
        /// Defines the 4 color components as an integer.
        /// </summary>
        public int RGBA
        {
            get
            {
                return rgba;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes an RGBAColor structure with the three RGB component (Red, Green, Blue) values.
        /// </summary>
        /// <param name="r">The Red component.</param>
        /// <param name="g">The Green component.</param>
        /// <param name="b">The Blue component.</param>
        public RGBAColor(byte r, byte g, byte b)
            : this()
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = 255;
        }

        /// <summary>
        /// Initializes an RGBAColor structure with the for RGBA component (Red, Green, Blue, Alpha) values.
        /// </summary>
        /// <param name="r">The Red component.</param>
        /// <param name="g">The Green component.</param>
        /// <param name="b">The Blue component.</param>
        /// <param name="A">The Alpha component.</param>
        public RGBAColor(byte r, byte g, byte b, byte a)
            : this()
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        /// <summary>
        /// Initializes the RGBAColor structure with the four color components packed in a signed integer.
        /// </summary>
        /// <param name="rgba">The packed four color components.</param>
        public RGBAColor(int rgba)
        {
            this.r = 0;
            this.g = 0;
            this.b = 0;
            this.a = 0;
            this.rgba = rgba;
        }

        private RGBAColor(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            this.r = 0;
            this.g = 0;
            this.b = 0;
            this.a = 0;
            this.rgba = info.GetInt32(RGBA_NAME);
        }
        #endregion

        #region Operators
        /// <summary>
        /// Converts Color to RGBAColor.
        /// </summary>
        /// <param name="color">The Color to convert.</param>
        /// <returns>A RGBAColor structure.</returns>
        public static RGBAColor FromColor(Color color)
        {
            return new RGBAColor(color.R, color.G, color.B, color.A);
        }

        /// <summary>
        /// Converts RGBAColor to Color.
        /// </summary>
        /// <param name="rgba">The RGBAColor to convert.</param>
        /// <returns>A Color structure.</returns>
        public static Color ToColor(RGBAColor rgba)
        {
            return Color.FromArgb(rgba.A, rgba.R, rgba.G, rgba.B);
        }

        /// <summary>
        /// Explicit operator to convert RGBAColor to Color.
        /// </summary>
        /// <param name="rgba">The RGBAColor to convert.</param>
        /// <returns>A Color structure.</returns>
        public static explicit operator Color(RGBAColor rgba)
        {
            return ToColor(rgba);
        }

        /// <summary>
        /// Explicit operator to convert Color to RGBAColor.
        /// </summary>
        /// <param name="color">The Color to convert.</param>
        /// <returns>A RGBAColor structure.</returns>
        public static explicit operator RGBAColor(Color color)
        {
            return FromColor(color);
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Returns a hash code for this RGBAColor structure.
        /// </summary>
        /// <returns>An integer value that specifies the hash code for this RGBAColor structure.</returns>
        public override int GetHashCode()
        {
            return RGBA.GetHashCode();
        }

        /// <summary>
        /// Determines if the object is equal to this.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>true if obj and this instance are the same type and represent the same value; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            if (obj is RGBAColor)
                return this.Equals((RGBAColor)obj);
            else
                return false;
        }

        public static bool operator ==(RGBAColor left, RGBAColor right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RGBAColor left, RGBAColor right)
        {
            return !(left == right);
        }
        #endregion

        #region IComparable Implementation
        public int CompareTo(object obj)
        {
            if (!(obj is RGBAColor))
                throw new ArgumentException("obj is not RGBAColor", "obj");

            return CompareTo((RGBAColor)obj);
        }
        #endregion

        #region IComparable Implementation
        public int CompareTo(RGBAColor other)
        {
            return RGBA.CompareTo(other.RGBA);
        }
        #endregion

        #region IEquatable Implementation
        public bool Equals(RGBAColor other)
        {
            return RGBA == other.RGBA;
        }
        #endregion

        #region ISerializable Implementation
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            info.AddValue(RGBA_NAME, RGBA);
        }
        #endregion
    }
}
