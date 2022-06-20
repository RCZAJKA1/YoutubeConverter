namespace YoutubeConverter
{
    using System;

    /// <summary>
    ///     The exception that is thrown when one of the arguments provided to the method is empty.
    /// </summary>
    public sealed class ArgumentEmptyException : ArgumentException
    {
        /// <summary>
        ///     The default argument empty exception.
        /// </summary>
        private const string EmptyMessage = "The argument cannot be empty or only contain white space.";

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentEmptyException"/> class with a specified error message.
        /// </summary>
        public ArgumentEmptyException() : base(EmptyMessage)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentEmptyException"/> class with a specified error message.
        /// </summary>
        public ArgumentEmptyException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentEmptyException"/> class with a specified error message 
        ///     and a reference to the inner exception that is the cause of the exception.
        /// </summary>
        public ArgumentEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentEmptyException"/> class with a specified error message 
        ///     and the name of the parameter that causes this exception.
        /// </summary>
        public ArgumentEmptyException(string message, string paramName) : base(message, paramName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentEmptyException"/> class with a specified error message,
        ///     the parameter name, and a reference to the inner exception that is the cause of the exception.
        /// </summary>
        public ArgumentEmptyException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }
    }
}
