#nullable enable
using System;

namespace MyFinance.BLL.Common.Exceptions
{
    public class ValueConflictException: CustomBLLException
    {
        const string defaultMsg = "Key value already exists";

        public ValueConflictException() : base(defaultMsg)
        {
        }

        public ValueConflictException(string? message) : base(message ?? defaultMsg)
        {
        }

        public ValueConflictException(string? message, Exception? innerException) : base(message ?? defaultMsg, innerException)
        {
        }

    }
}
