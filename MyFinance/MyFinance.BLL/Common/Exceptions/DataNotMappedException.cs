#nullable enable
using System;

namespace MyFinance.BLL.Common.Exceptions
{
    class DataNotMappedException: CustomBLLException
    {
        const string defaultMsg = "Data objects not mapped";

        public DataNotMappedException() : base(defaultMsg)
        {
        }

        public DataNotMappedException(string? message) : base(message ?? defaultMsg)
        {
        }

        public DataNotMappedException(string? message, Exception? innerException) : base(message ?? defaultMsg, innerException)
        {
        }
    }
}
