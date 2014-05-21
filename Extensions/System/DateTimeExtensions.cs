// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeExtensions.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace System
{
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Extensions of the <see cref="DateTime"/> class.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Get the ordinal string for the given <see cref="DateTime"/>.
        /// </summary>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <returns>
        /// An ordinal representation of the day.  <c>Eg: 15th</c>
        /// </returns>
        public static string Ordinal(this DateTime date)
        {
            string suffix;

            var ones = date.Day % 10;
            var tens = (int)Math.Floor(date.Day / 10M) % 10;

            if (tens == 1)
            {
                suffix = "th";
            }
            else
            {
                switch (ones)
                {
                    case 1:
                        suffix = "st";
                        break;

                    case 2:
                        suffix = "nd";
                        break;

                    case 3:
                        suffix = "rd";
                        break;

                    default:
                        suffix = "th";
                        break;
                }
            }

            return string.Format(CultureInfo.CurrentCulture, "{0}{1}", date.Day, suffix);
        }

        /// <summary>
        /// Create a relativley short unique identifer using the <see cref="System.DateTime"/> as a base by 
        /// taking <see cref="M:System.DateTime.Ticks"/> and converting it to a collection of Base 62 chars.  
        /// Based upon the method documented at
        /// <example>http://www.anotherchris.net/csharp/friendly-unique-id-generation-part-2/</example>
        /// </summary>
        /// <param name="value">The value to use as a base for the identifier.</param>
        /// <returns>A relativley short unique identifier.</returns>
        public static string ToUniqueIdentifier(this DateTime value)
        {
            return Base62ToString(value.Ticks);
        }

        private static string Base62ToString(long value)
        {
            var x = 0L;
            var y = Math.DivRem(value, 62, out x);

            if (y > 0)
            {
                return Base62ToString(y) + ValToChar(x).ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                return ValToChar(x).ToString(CultureInfo.InvariantCulture);
            }   
        }

        private static char ValToChar(long value)
        {
            if (value > 9)
            {
                var ascii = (65 + ((int)value - 10));

                if (ascii > 90)
                {
                    ascii += 6;
                }

                return (char)ascii;
            }
            else
            {
                return value.ToString(CultureInfo.InvariantCulture).ElementAt(0);
            }
        }
    }
}