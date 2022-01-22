#nullable enable
using System;

namespace MyFinance.BLL.Common.Exceptions
{
    public class ValueNotSpecifiedException: CustomBLLException
    {
        const string defaultMsg = "Required property not specified or empty";

        public ValueNotSpecifiedException() : base(defaultMsg)
        {
        }

        public ValueNotSpecifiedException(string? message) : base(message ?? defaultMsg)
        {
        }

        public ValueNotSpecifiedException(string? message, Exception? innerException) : base(message ?? defaultMsg, innerException)
        {
        }

    }
}
