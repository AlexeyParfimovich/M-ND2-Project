#nullable enable
using System;

namespace MyFinance.BLL.Common.Exceptions
{
    public class DtoNullReferenceException : CustomBLLException
    {
        const string defaultMsg = "Data object reference is null";

        public DtoNullReferenceException(): base (defaultMsg)
        {
        }

        public DtoNullReferenceException(string? message) : base(message?? defaultMsg)
        {
        }

        public DtoNullReferenceException(string? message, Exception? innerException) : base(message ?? defaultMsg, innerException)
        {
        }

    }
}
