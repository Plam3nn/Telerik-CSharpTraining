using System;

namespace CosmeticsShop.Exceptions
{
    internal class InvalidInputException : Exception
    {
        public InvalidInputException(string message) 
            : base(message)
        {
        }
    }
}
