#nullable enable
using System;

namespace MyFinance.BLL.Common.Exceptions
{
    public abstract class CustomBLLException : Exception
    {
        public CustomBLLException()
        {
        }

        public CustomBLLException(string? message) : base(message)
        {
        }

        public CustomBLLException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
