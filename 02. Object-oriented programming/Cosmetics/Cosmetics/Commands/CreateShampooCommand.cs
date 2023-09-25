using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cosmetics.Commands
{
    public class CreateShampooCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 6;

        public CreateShampooCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);

            string name = this.CommandParameters[0];
            string brand = this.CommandParameters[1];
            decimal price = this.ParseDecimalParameter(this.CommandParameters[2], nameof(price));
            GenderType gender = this.ParseGenderType(this.CommandParameters[3]);
            int millilitres = this.ParseIntParameter(this.CommandParameters[4], nameof(millilitres));
            UsageType usage = (UsageType)Enum.Parse(typeof(UsageType), this.CommandParameters[5]);

            return CreateShampoo(name, brand, price, gender, millilitres, usage);
        }

        private string CreateShampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage)
        {
            if (this.Repository.ProductExists(name))
            {
                throw new ArgumentException($"Shampoo {name} already exists!");
            }
            
            this.Repository.CreateShampoo(name, brand, price, gender, millilitres, usage);

            return $"Shampoo with name {name} created.";
        }
    }
}
