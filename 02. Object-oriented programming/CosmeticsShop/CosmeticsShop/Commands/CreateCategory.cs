using CosmeticsShop.Core;
using CosmeticsShop.Exceptions;
using CosmeticsShop.Validations;
using System.Collections.Generic;
using System.Linq;

namespace CosmeticsShop.Commands
{
    public class CreateCategory : ICommand
    {
        private const int ExpectedParametersCount = 1;

        private readonly CosmeticsRepository cosmeticsRepository;

        public CreateCategory(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            DataValidator.ValidateParametersCount(parameters, ExpectedParametersCount, nameof(CreateCategory));
            
            string categoryName = parameters[0];

            // TODO: Ensure category name is unique
            this.ValidateUniqueness(categoryName);

            this.cosmeticsRepository.CreateCategory(categoryName);

            return $"Category with name {categoryName} was created!";
        }

        private void ValidateUniqueness(string categoryName)
        {
            if (this.cosmeticsRepository.Categories.Any(x => x.Name == categoryName))
            {
                throw new EntityAlreadyExistsException(string.Format(Messages.CategoryAlreadyExists, categoryName));
            }
        }
    }
}
