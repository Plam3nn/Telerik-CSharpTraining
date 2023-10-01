namespace CosmeticsShop.Exceptions
{
    public static class Messages
    {
        public const string InvalidStringLength = "{0} should be between {1} and {2} characters long";
        public const string NullString = "{0} cannot be null.";
        public const string NegativeNumber = "{0} cannot be negative.";
        public const string InvalidParametersCount = "{0} command expects {1} parameters.";
        public const string CategoryDoesNotExist = "Category {0} does not exist.";
        public const string ProductDoesNotExist = "Product {0} does not exist.";
        public const string CategoryAlreadyExists = "Category {0} already exists.";
        public const string ProductAlreadyExists = "Product {0} already exists.";
        public const string InvalidDoubleFormat = "Invalid input for {0}. Must be real number.";
        public const string InvalidGenderInput = "Invalid input for {0}. Can be {1}, {2} or {3}.";
        public const string InvalidCommandInput = "No such command '{0}'.";
    }
}
