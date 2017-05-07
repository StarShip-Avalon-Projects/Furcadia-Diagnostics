/*** Numeric.cs
 * 
 * Furcadia Numeric Systems & Conversion Module
 *   (c) 2009 by IceDragon of QuickFox.org
 * 
 * <icedragon@quickfox.org>
 * http://www.icerealm.org
 * 
 * This file contains classes that handle the Furcadia numeric systems (base95
 * and base220) as well as the conversion between them and their numeric
 * values.
 * 
 * ChangeLog:
 *   20090909 - Added more documentation and CHAR_OFFSET/LAST_CHAR constants
 *   20090721 - Initial Release.
 * 
 * Furcadia is (c) 1996-Present Day by Dragon's Eye Productions
 */

using System;

namespace Furcadia
{
    public abstract class Numeric : IEquatable<uint>, IComparable<uint>
    {
        /*
         *** Data Members
         */
        protected uint nValue = 0; // Numeric value container.


        /*
         *** Properties
         */
        public uint UIntValue
        {
            get { return nValue; }
            set { nValue = value; }
        }


        /*
         *** Methods
         */
        /// <summary>
        /// A function that transforms current number into its string
        /// representation.
        /// </summary>
        /// <returns></returns>
        public abstract override string ToString();
        /// <summary>
        /// A function that transform a string representation of a
        /// number into its numeric value.
        /// </summary>
        /// <param name="str"></param>
        public abstract void FromString(string str);


        /*
         *** Interface Implementations
         */
        #region IEquatable<uint> Members

        public bool Equals(uint other)
        {
            return (UIntValue == other);
        }

        #endregion
        #region IComparable<uint> Members

        public int CompareTo(uint other)
        {
            return nValue.CompareTo(other);
        }

        #endregion
    }


    /// <summary>
    /// Furcadia base95 numeric manipulation class.
    /// </summary>
    public class Base95 : Numeric
    {
        /*
         *** Constants
         */
        public const char CHAR_OFFSET = ' ';
        public const char LAST_CHAR = '~';

        /*
         *** Properties
         */
        /// <summary>
        /// Gets or sets the string value (base95 representation) of the
        /// base95 number.
        /// </summary>
        public string StringValue
        {
            get { return ConvertToBase95(nValue); }
            set { nValue = ConvertFromBase95(value); }
        }

        
        /*
         *** Constructors
         */
        public Base95() : this(0) {}
        public Base95(int num) : this((uint)num) {}
        public Base95(uint num) { UIntValue = num; }
        public Base95(string b95str) { StringValue = b95str; }


        /*
         *** Class Functions
         */
        /// <summary>
        /// Convert a specific number into its base95 representation. The
        /// amount of base95 digits returned depends on how big the number
        /// is.
        /// </summary>
        /// <param name="num">Regular number to convert to base95</param>
        /// <returns>A base95 string representation of the supplied number</returns>
        public static string ConvertToBase95(uint num)
        {
            return ConvertToBase95(num, 0);
        }
        /// <summary>
        /// Convert a specific number into its base95 representation with a
        /// specific amount of base95 digits returned.
        /// 
        /// If the number is bigger than its base95 representation is capable
        /// of displaying, the biggest base95 number will be returned instead.
        /// </summary>
        /// <param name="num">Regular number to convert to base95</param>
        /// <param name="nDigits">Amount of base95 digits to return</param>
        /// <returns>
        /// A base95 string representation of the supplied number or a number
        /// closest to it if out of base95 range
        /// </returns>
        public static string ConvertToBase95(uint num, int nDigits)
        {
            string b95str = "";
            uint ch;

            // Conversion
            while (num > 0)
            {
                ch = (num % 95) + CHAR_OFFSET; num /= 95;
                b95str = (char)ch + b95str;
            }

            // Applying padding if necessary.
            if (nDigits > 0)
            {
                if (b95str.Length < nDigits)
                    return b95str.PadLeft(nDigits,CHAR_OFFSET);
                if (b95str.Length > nDigits)
                    return new String(LAST_CHAR, nDigits);
            }

            return b95str;
        }
        /// <summary>
        /// Convert a specific base95 number into a regular number as a uint.
        /// </summary>
        /// <param name="b95str">Base95 number represented by string</param>
        /// <returns>A numeric value that the base95 number represents</return>
        public static uint ConvertFromBase95(string b95str)
        {
            uint num = 0;
            uint mod = 1;

            // Conversion
            for (int i = b95str.Length - 1; i >= 0; i--)
            {
                num += (uint)(((int)b95str[i] - CHAR_OFFSET) * mod);
                mod *= 95;
            }

            return num;
        }


        /*
         *** Methods
         */
        /// <summary>
        /// Retrieve the string (base95) representation of the number.
        /// </summary>
        /// <returns>Base95 string representing the number stored</returns>
        public override string ToString()
        {
            return StringValue;
        }
        /// <summary>
        /// Store a number represented by a string (base95) as the current
        /// number.
        /// </summary>
        /// <param name="str">Base95 number represented by a string</param>
        public override void FromString(string str)
        {
            StringValue = str;
        }
        /// <summary>
        /// Retrieve the integer value of the number.
        /// </summary>
        /// <returns>Integer value of the number stored</returns>
        public uint ToUInt()
        {
            return UIntValue;
        }
        /// <summary>
        /// Store a number represented by an integer as the current number.
        /// </summary>
        /// <param name="num">Numeric value represented by uint</param>
        public void FromUInt(uint num)
        {
            UIntValue = num;
        }
    }

    /// <summary>
    /// Furcadia base220 numeric system class.
    /// </summary>
    public class Base220 : Numeric
    {
        /*
         *** Constants
         */
        public const char CHAR_OFFSET = '#';
        public const char LAST_CHAR = (char)0xFE;

        /*
         *** Properties
         */
        /// <summary>
        /// Gets or sets the string value (base220 representation) of the
        /// base220 number.
        /// </summary>
        public string StringValue
        {
            get { return ConvertToBase220(nValue); }
            set { nValue = ConvertFromBase220(value); }
        }


        /*
         *** Constructors
         */
        public Base220() : this(0) { }
        public Base220(int num) : this((uint)num) { }
        public Base220(uint num) { UIntValue = num; }
        public Base220(string b220str) { StringValue = b220str; }


        /*
         *** Class Functions
         */
        /// <summary>
        /// Convert a specific number into its base220 representation. The
        /// amount of base220 digits returned depends on how big the number
        /// is.
        /// </summary>
        /// <param name="num">Regular number to convert to base220</param>
        /// <returns>A base220 string representation of the supplied number</returns>
        public static string ConvertToBase220(uint num)
        {
            return ConvertToBase220(num, 0);
        }
        /// <summary>
        /// Convert a specific number into its base220 representation with a
        /// specific amount of base220 digits returned.
        /// 
        /// If the number is bigger than its base220 representation is capable
        /// of displaying, the biggest base220 number will be returned instead.
        /// </summary>
        /// <param name="num">Regular number to convert to base220</param>
        /// <param name="nDigits">Amount of base220 digits to return</param>
        /// <returns>
        /// A base220 string representation of the supplied number or a number
        /// closest to it if out of base220 range
        /// </returns>
        public static string ConvertToBase220(uint num, int nDigits)
        {
            string b220str = "";
            uint ch;

            // Conversion
            while (num > 0)
            {
                ch = (num % 220) + CHAR_OFFSET; num /= 220;
                b220str = (char)ch + b220str;
            }

            // Applying padding if necessary.
            if (nDigits > 0)
            {
                if (b220str.Length < nDigits)
                    return b220str.PadRight(nDigits,CHAR_OFFSET);
                if (b220str.Length > nDigits)
                    return new String(LAST_CHAR, nDigits);
            }

            return b220str;
        }
        /// <summary>
        /// Convert a specific base220 number into a regular number as a uint.
        /// </summary>
        /// <param name="b220str">Base220 number represented by string</param>
        /// <returns>A numeric value that the base220 number represents</return>
        public static uint ConvertFromBase220(string b220str)
        {
            uint num = 0;
            uint mod = 1;

            // Conversion
            for (int i = b220str.Length - 1; i >= 0; i--)
            {
                num += (uint)(((int)b220str[i] - CHAR_OFFSET) * mod);
                mod *= 220;
            }

            return num;
        }


        /*
         *** Methods
         */
        /// <summary>
        /// Retrieve the string (base220) representation of the number.
        /// </summary>
        /// <returns>Base220 string representing the number stored</returns>
        public override string ToString()
        {
            return StringValue;
        }
        /// <summary>
        /// Store a number represented by a string (base220) as the current
        /// number.
        /// </summary>
        /// <param name="str">Base220 number represented by a string</param>
        public override void FromString(string str)
        {
            StringValue = str;
        }
        /// <summary>
        /// Retrieve the integer value of the number.
        /// </summary>
        /// <returns>Integer value of the number stored</returns>
        public uint ToUInt()
        {
            return UIntValue;
        }
        /// <summary>
        /// Store a number represented by an integer as the current number.
        /// </summary>
        /// <param name="num">Numeric value represented by uint</param>
        public void FromUInt(uint num)
        {
            UIntValue = num;
        }
    }
}
