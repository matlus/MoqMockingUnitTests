using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace ClassLibrary1
{

    [ExcludeFromCodeCoverage]
    [Serializable]
    public sealed class MovieTitleNullOrEmptyException : Exception
    {
        public MovieTitleNullOrEmptyException() { }
        public MovieTitleNullOrEmptyException(string message) : base(message) { }
        public MovieTitleNullOrEmptyException(string message, Exception inner) : base(message, inner) { }
        private MovieTitleNullOrEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
