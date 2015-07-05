namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Static class containing extension methods for the <see cref="System.String"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// String extension method which converts string to a byte array and compute the hash.
        /// </summary>
        /// <param name="input">The string on which the method is invoked</param>
        /// <returns>Returns hexadecimal string</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// String extension method which converts the specified string representation of a logical value to its Boolean true string equivalent.
        /// </summary>
        /// <param name="input">The string on which the method is invoked</param>
        /// <returns>Returns true if value equals TrueString</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }
       
        /// <summary>
        /// String extension method which converts the specified string representation of a number to an equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="input">The string on which the method is invoked</param>
        /// <returns>Returns a 16-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is not valid 16-bit integer.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }
      
        /// <summary>
        /// String extension method which converts the specified string representation of a number to an equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="input">The string on which the method is invoked</param>
        /// <returns>Returns a 32-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is not valid 32-bit integer.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// String extension method which converts the specified string representation of a number to an equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="input">The string on which the method is invoked</param>
        /// <returns>Returns a 64-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is not valid 64-bit integer.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }
        
        /// <summary>
        /// String extension method which converts the specified string representation of a date and time to an equivalent date and time value.
        /// </summary>
        /// <param name="input">The string on which the method is invoked</param>
        /// <returns>Returns the date and time equivalent of the value of value, or the date and time equivalent of DateTime.MinValue if value is not correct</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }
       
        /// <summary>
        /// String extension method which returns a copy of this string converted to uppercase first letter
        /// </summary>
        /// <param name="input">The string on which the method is invoked</param>
        /// <returns>Returns the string with capital first letter, if first letter cannot be capitalized returns the original string</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }
       
        /// <summary>
        /// Returns a substring between two string values from given start index, if index is not set is 0 
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="startString">starting string value</param>
        /// <param name="endString">end string value</param>
        /// <param name="startFrom">start integer position</param>
        /// <returns>first matched string which is it between the given strings or empty string if cannot find match or parameters are equal</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }
       
        /// <summary>
        /// String extension method which converts cyrillic letters string to its latin letters representation. 
        /// </summary>
        /// <param name="input">The string on which the method is invoked</param>
        /// <returns>Returns latin letters representation of the string.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// String extension method which converts latin letters string to its cyrillic letters representation. 
        /// </summary>
        /// <param name="input">The string on which the method is invoked</param>
        /// <returns>Returns cyrillic letters representation of the string.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }
       
        /// <summary>
        /// String extension method which converts string to valid username, removing invalid symbols
        /// </summary>
        /// <param name="input">The string on which the method is invoked</param>
        /// <returns>Returns valid username or empty string if cannot be converted</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }
       
        /// <summary>
        /// String extension method which converts string to valid latin filename by converting cyrillic letters and removing invalid symbols
        /// </summary>
        /// <param name="input">The string on which the method is invoked</param>
        /// <returns>Returns valid latin file name,  or empty string if cannot be converted</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }
        
        /// <summary>
        /// String extension method which returns string with length equal to chars count starting from 0 index of the string, returns same string if chars count is bigger than string.length
        /// </summary>
        /// <param name="input">The string on which the method is invoked</param>
        /// <param name="charsCount">chars count</param>
        /// <returns>Returns string with length equal to chars count or same string if length is bigger than string length</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }
       
        /// <summary>
        /// String extension method which returns filename extension if it exist or returns empty string
        /// </summary>
        /// <param name="fileName">The filename on which the method is invoked</param>
        /// <returns>Returns filename extension or empty string if extension is missing</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }
       
        /// <summary>
        /// String extension method which returns content of filename extension
        /// </summary>
        /// <param name="fileExtension">The filename extension on which the method is invoked</param>
        /// <returns>Returns content of filename extension or returns application/octet-stream if cannot recognize extension</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }
        
        /// <summary>
        ///  String extension method which converts the input string to a byte array
        /// </summary>
        /// <param name="input">The string on which the method is invoked</param>
        /// <returns>Returns a byte array of the input string</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
