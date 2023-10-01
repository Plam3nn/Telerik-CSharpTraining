using CosmeticsShop.Exceptions;
using System.Collections.Generic;
using System.Data;

namespace CosmeticsShop.Validations
{
    public static class DataValidator
    {
        public static void ValidateStringLength(int stringLength, int minLength, int maxLength, string propertyName)
        {
            if (stringLength < minLength || stringLength > maxLength)
            {
                throw new InvalidInputException(string.Format(Messages.InvalidStringLength, propertyName, minLength, maxLength));
            }
        }

        public static void ValidateNullString(string value, string propertyName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidInputException(string.Format(Messages.NullString, propertyName));
            }
        }

        public static void ValidateNonNegative(double value, string propertyName)
        {
            if (value < 0)
            {
                throw new InvalidInputException(string.Format(Messages.NegativeNumber, propertyName));
            }
        }

        public static void ValidateParametersCount(IReadOnlyCollection<string> parameters, int expectedParametersCount, string command)
        {
            if (parameters.Count != expectedParametersCount)
            {
                throw new InvalidInputException(string.Format(Messages.InvalidParametersCount, command, expectedParametersCount));
            }
        }
    }
}
