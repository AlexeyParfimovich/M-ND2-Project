#nullable enable
using System;

namespace MyFinance.BLL.Common.Exceptions
{
    /*
     * TODO: получать хранить проверяемый ключ и его значение
     */
    public class ValueNotFoundException: CustomBLLException
    {
        const string defaultMsg = "Key value not found";

        public ValueNotFoundException() : base(defaultMsg)
        {
        }

        public ValueNotFoundException(string? message) : base(message ?? defaultMsg)
        {
        }

        public ValueNotFoundException(string? message, Exception? innerException) : base(message ?? defaultMsg, innerException)
        {
        }

    }
}
