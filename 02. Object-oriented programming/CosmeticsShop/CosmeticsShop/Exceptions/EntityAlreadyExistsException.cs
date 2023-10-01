using System;
namespace CosmeticsShop.Exceptions
{
    internal class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string message) 
            : base(message)
        {
        }
    }
}
