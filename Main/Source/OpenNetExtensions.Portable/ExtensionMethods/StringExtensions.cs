using System;

namespace OpenNetExtensions.ExtensionMethods
{
	public static class StringExtensions
    {
        #region --- HasLength ---

        /// <summary>
        /// Returns true if not null or empty.  Cleaner api with positive voice.
        /// var s = ...;
        /// if (s.HasLength())...
        /// vs
        /// if(!string.IsNullOrEmpty(s))...
        /// </summary>
		public static bool HasLength(this string value)
		{
            return !String.IsNullOrEmpty(value);
		}

        #endregion

        #region --- Ensure Begins/Ends With ---

        public static string EnsureBeginsWith(this string origString, string value)
        {
            if (origString == null) { return null; }

            if (!origString.StartsWith(value))
            {
                return value + origString;
            }

            return origString;
        }

        public static string EnsureEndsWith(this string origString, string value)
        {
            if (origString == null) { return null; }

            if (!origString.EndsWith(value))
            {
                return origString + value;
            }

            return origString;
        }

        #endregion

        #region --- FormatWith ---

        /// <summary>
        /// Wrapper on string.Format to clean up api.
        /// var s = ...;
        /// s.FormatWith(args);
        /// vs
        /// string.Format(s, args)
        /// </summary>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        #endregion

        #region --- Remove ---

        public static string Remove(this string origString, params string[] valuesToRemove)
        {
            return origString.Replace("", valuesToRemove);
        }

        #endregion

        #region --- Replace ---

        public static string Replace(this string origString, string newValue, params string[] oldValues)
        {
            //TODO: Performance Test using StringBuilder

            string newString = origString;
            foreach (string oldValue in oldValues)
            {
                newString = newString.Replace(oldValue, newValue);
            }

            return newString;
        }

        #endregion

        #region --- RemoveRight ---

        /// <summary>
		/// Remove the passed value from the right end of the passed origString
		/// if it exists.
		/// </summary>
		/// <param name="origString">String to remove value from.</param>
		/// <param name="value">String value to remove.</param>
		/// <returns>Original String with the value removed from the right end.  
		/// If the value was not on the right, the orignal string is returned unchanged.  
		/// If null, is passed as the orignial string, null is returned.</returns>
        public static string RemoveRight(this string origString, string value)
        {
            if (origString == null) { return null; }

            if (origString.EndsWith(value))
            {
                // Remove value from end of the string.
                return origString.Remove(origString.Length - value.Length, value.Length);
            }

            return origString;
        }

		#endregion

		#region --- Right ---

		/// <summary>
		/// Returns the right characters of the passed string value of the specified length.
		/// </summary>
		/// <param name="value">String value to parse the right characters from.</param>
		/// <param name="length">Number of characters to return.</param>
		/// <returns>Characters from the right end of the value.  
		/// If string value is passed as null, String.Empty is returned.  
		/// If the requested length is greater than the length of the value, the entire value is returned.</returns>
        public static string Right(this string value, int length)
        {
            if (length <= 0) { throw new ArgumentOutOfRangeException("length", "Length must be greater than zero."); }

            if (value == null) { return ""; }

            if (value.Length > length)
            {
                // Return right characters of the specified length.
                return value.Substring(value.Length - length, length);
            }
            else
            {
                // Right Length requested is either longer than or 
                // equal to the string length.
                // So return the entire string.
                return value;
            }
        }

		/// <summary>
		/// Returns the right characters of the passed string value of the specified length.
		/// When the requested length is greater than the length of the passed value,
		/// the returned value is padded on the left with the passed padding character.
		/// </summary>
		/// <param name="value">String value to parse the right characters from.</param>
		/// <param name="length">Number of characters to return.</param>
		/// <param name="leftPaddingChar">Character to pad left of return value.</param>
		/// <returns>Characters from the right end of the value.  
		/// If string value is passed as null, the return value will be the specified length with only the padding chars.  
		/// If the requested length is greater than the length of the value, the return value will be padded on the left with the padding char.</returns>
        public static string Right(string value, int length, char leftPaddingChar)
        {
            //  Note: Not validating parameters because they 
            //  are validated in Right( value, length ).  The leftPaddingChar
            //  will always be valid because it is a char datatype.

            // Parse the right of the value.
            string str = Right(value, length);

            // Pad left if string value is not as long as the specified length.
            if (str.Length == length)
            {
                return str;
            }
            else
            {
                return str.PadLeft(length, leftPaddingChar);
            }
        }

		#endregion

		#region --- NullToEmpty ---

		public static string NullToEmpty(this string value)
		{
            return (value == null) ? string.Empty : value;
		}

		#endregion

		#region --- EmptyToNull ---

		public static string EmptyToNull(this string value)
		{
			return (value == string.Empty) ? null : value;
        }

        #endregion

        #region --- IsVowel ---

        public static bool IsVowel(char character)
        {
            switch (char.ToLower(character))
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    return true;
                default:
                    return false;
            }
        }

        #endregion
    }
}
