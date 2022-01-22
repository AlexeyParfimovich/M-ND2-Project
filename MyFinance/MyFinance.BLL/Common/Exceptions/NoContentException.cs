#nullable enable
using System;

namespace MyFinance.BLL.Common.Exceptions
{
    public class NoContentException: CustomBLLException
    {
        const string defaultMsg = "Data not found";

        public NoContentException() : base(defaultMsg)
        {
        }

        public NoContentException(string? message) : base(message ?? defaultMsg)
        {
        }

        public NoContentException(string? message, Exception? innerException) : base(message ?? defaultMsg, innerException)
        {
        }
    }
}
