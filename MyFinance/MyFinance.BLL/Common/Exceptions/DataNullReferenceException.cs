#nullable enable
using System;

namespace MyFinance.BLL.Common.Exceptions
{
    public class DataNullReferenceException : CustomBLLException
    {
        const string defaultMsg = "Data object reference is null";

        public DataNullReferenceException(): base (defaultMsg)
        {
        }

        public DataNullReferenceException(string? message) : base(message?? defaultMsg)
        {
        }

        public DataNullReferenceException(string? message, Exception? innerException) : base(message ?? defaultMsg, innerException)
        {
        }

    }
}
