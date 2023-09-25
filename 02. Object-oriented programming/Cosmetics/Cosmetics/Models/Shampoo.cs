using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System.Text;

namespace Cosmetics.Models
{
    public class Shampoo : Product, IShampoo
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private int millilitres;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Millilitres = millilitres;
            this.Usage = usage;
        }

        public int Millilitres
        {
            get
            {
                return this.millilitres;
            }
            init
            {
                ValidationHelper.ValidateNonNegative(value, nameof(this.Millilitres));
                this.millilitres = value;
            }
        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }
            init
            {
                ValidationHelper.ValidateUsage(value);
                this.usage = value;
            }
        }

        protected override string AdditionalInfo()
        {
            var output = new StringBuilder();

            output.AppendLine($" #Milliliters: {this.Millilitres}");
            output.AppendLine($" #Usage: {this.Usage}");

            return output.ToString();
        }

        protected override void ValidateBrand(string value, string fieldName)
        {
            ValidationHelper.ValidateNullOrEmpty(value, fieldName);
            ValidationHelper.ValidateStringLength(value, NameMinLength, NameMaxLength);
        }

        protected override void ValidateName(string value, string fieldName)
        {
            ValidationHelper.ValidateNullOrEmpty(value, fieldName);
            ValidationHelper.ValidateStringLength(value, BrandMinLength, BrandMaxLength);
        }

        protected override void ValidatePrice(decimal price)
        {
            ValidationHelper.ValidateNonNegative(price, nameof(this.Price));
        }
    }
}
