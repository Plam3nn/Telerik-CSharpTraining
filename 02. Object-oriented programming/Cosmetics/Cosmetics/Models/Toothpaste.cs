using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System.Text;

namespace Cosmetics.Models
{
    public class Toothpaste : Product, IToothpaste
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
            : base(name, brand, price, gender) 
        {
            this.Ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
            init
            {
                ValidateIngredients(value);
                this.ingredients = value;
            }
        }

        protected override string AdditionalInfo()
        {
            var output = new StringBuilder();

            output.AppendLine($" #Ingredients: [{string.Join(", ", this.Ingredients.Split())}]");

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

        private void ValidateIngredients(string value)
        {
            ValidationHelper.ValidateNullOrEmpty(value, nameof(this.Ingredients));
        }
    }
}
