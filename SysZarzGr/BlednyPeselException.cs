using System;
using System.Runtime.Serialization;

namespace SysZarzGr
{
    [Serializable]
    internal class BlednyPeselException : Exception
    {
        public BlednyPeselException()
        {
        }

        public BlednyPeselException(string message) : base(message)
        {
        }

        public BlednyPeselException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BlednyPeselException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}