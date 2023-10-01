using System;

namespace CosmeticsShop.Exceptions
{
    internal class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) 
            : base(message)
        {
        }
    }
}
