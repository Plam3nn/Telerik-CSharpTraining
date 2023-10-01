using CosmeticsShop.Core;
using CosmeticsShop.Exceptions;
using CosmeticsShop.Models;
using CosmeticsShop.Validations;
using System.Collections.Generic;

namespace CosmeticsShop.Commands
{
    public class ShowCategory : ICommand
    {
        private const int ExpectedParametersCount = 1;

        private readonly CosmeticsRepository cosmeticsRepository;

        public ShowCategory(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            //TODO: Validate parameters count
            DataValidator.ValidateParametersCount(parameters, ExpectedParametersCount, nameof(ShowCategory));

            string categoryName = parameters[0];

            CheckCategoryExistence(categoryName);

            Category category = this.cosmeticsRepository.FindCategoryByName(categoryName);

            return category.Print();
        }

        private void CheckCategoryExistence(string name)
        {
            if (!this.cosmeticsRepository.CategoryExist(name))
            {
                throw new EntityNotFoundException(string.Format(Messages.CategoryDoesNotExist, name));
            }
        }
    }
}
