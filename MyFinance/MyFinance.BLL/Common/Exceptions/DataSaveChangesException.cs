#nullable enable
using System;

namespace MyFinance.BLL.Common.Exceptions
{
    public class DataSaveChangesException: CustomBLLException
    {
        const string defaultMsg = "Data changes are not saved";

        public DataSaveChangesException() : base(defaultMsg)
        {
        }

        public DataSaveChangesException(string? message) : base(message ?? defaultMsg)
        {
        }

        public DataSaveChangesException(string? message, Exception? innerException) : base(message ?? defaultMsg, innerException)
        {
        }
    }
}
