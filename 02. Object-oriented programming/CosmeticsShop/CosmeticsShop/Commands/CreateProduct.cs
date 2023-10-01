using CosmeticsShop.Core;
using CosmeticsShop.Exceptions;
using CosmeticsShop.Models;
using CosmeticsShop.Validations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CosmeticsShop.Commands
{
    public class CreateProduct : ICommand
    {
        private const int ExpectedParametersCount = 4;

        private readonly CosmeticsRepository cosmeticsRepository;

        public CreateProduct(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            DataValidator.ValidateParametersCount(parameters, ExpectedParametersCount, nameof(CreateProduct));

            string name = parameters[0];
            string brand = parameters[1];

            // TODO: Validate price format
            double price = this.ParseDouble(parameters[2]);

            // TODO: Validate gender format
            GenderType gender = this.ParseGender(parameters[3]);

            // TODO: Ensure product name is unique
            this.ValidateUniqueness(name);
            this.cosmeticsRepository.CreateProduct(name, brand, price, gender);

            return $"Product with name {name} was created!";
        }

        private void ValidateUniqueness(string productName)
        {
            if (this.cosmeticsRepository.Products.Any(x => x.Name == productName))
            {
                throw new EntityAlreadyExistsException(string.Format(Messages.ProductAlreadyExists, productName));
            }
        }

        private GenderType ParseGender(string value)
        {
            if (!Enum.TryParse(value, true, out GenderType output))
            {
                throw new InvalidInputException(string.Format(Messages.InvalidGenderInput, "gender",
                    GenderType.Men, GenderType.Women, GenderType.Unisex));
            }

            return output;
        }

        private double ParseDouble(string value)
        {
            if (!double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double output))
            {
                throw new InvalidInputException(string.Format(Messages.InvalidDoubleFormat, "price"));
            }

            return output;
        }        
    }
}
