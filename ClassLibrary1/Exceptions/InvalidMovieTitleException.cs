using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace ClassLibrary1
{

    [ExcludeFromCodeCoverage]
    [Serializable]
    public sealed class InvalidMovieTitleException : Exception
    {
        public InvalidMovieTitleException() { }
        public InvalidMovieTitleException(string message) : base(message) { }
        public InvalidMovieTitleException(string message, Exception inner) : base(message, inner) { }
        private InvalidMovieTitleException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
