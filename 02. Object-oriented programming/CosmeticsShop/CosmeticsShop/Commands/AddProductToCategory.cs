using CosmeticsShop.Core;
using CosmeticsShop.Models;
using CosmeticsShop.Validations;
using CosmeticsShop.Exceptions;

using System.Collections.Generic;

namespace CosmeticsShop.Commands
{
    public class AddProductToCategory : ICommand
    {
        private const int ExpectedParametersCount = 2;

        private readonly CosmeticsRepository cosmeticsRepository;

        public AddProductToCategory(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            // TODO: Validate parameters count
            DataValidator.ValidateParametersCount(parameters, ExpectedParametersCount, nameof(AddProductToCategory));

            string categoryName = parameters[0];
            string productName = parameters[1];

            this.CheckCategoryExistence(categoryName);
            this.CheckProductExistence(productName);

            Category category = this.cosmeticsRepository.FindCategoryByName(categoryName);
            Product product = this.cosmeticsRepository.FindProductByName(productName);

            category.AddProduct(product);

            return $"Product {productName} added to category {categoryName}!";
        }

        private void CheckCategoryExistence(string name)
        {
            if (!this.cosmeticsRepository.CategoryExist(name))
{                
                throw new EntityNotFoundException(string.Format(Messages.CategoryDoesNotExist, name));
            }
        }

        private void CheckProductExistence(string name)
        {
            if (!this.cosmeticsRepository.ProductExist(name))
            {
                throw new EntityNotFoundException(string.Format(Messages.ProductDoesNotExist, name));
            }
        }
    }
}
