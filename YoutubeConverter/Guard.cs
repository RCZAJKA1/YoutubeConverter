namespace YoutubeConverter
{
    using System;

    /// <summary>
    ///     Guards from invalid parameters.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        ///     Throws an exception if the object is null.
        /// </summary>
        /// <param name="obj">The object being evaluated.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ThrowIfNull(this object obj, string paramName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>
        ///     Throws an exception if the string is empty.
        /// </summary>
        /// <param name="str">The string being evaluated.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentEmptyException"></exception>
        public static void ThrowIfEmpty(this string str, string paramName)
        {
            foreach (char c in str)
            {
                if (!char.IsWhiteSpace(c))
                {
                    return;
                }
            }

            throw new ArgumentEmptyException(paramName);
        }
    }
}
