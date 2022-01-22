#nullable enable
using System;

namespace MyFinance.BLL.Common.Exceptions
{
    public class ValueOutOfRangeException: CustomBLLException
    {
        const string defaultMsg = "Property value out of range";

        public ValueOutOfRangeException() : base(defaultMsg)
        {
        }

        public ValueOutOfRangeException(string? message) : base(message ?? defaultMsg)
        {
        }

        public ValueOutOfRangeException(string? message, Exception? innerException) : base(message ?? defaultMsg, innerException)
        {
        }

    }
}
