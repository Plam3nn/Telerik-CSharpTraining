using CosmeticsShop.Validations;
using System.Text;

namespace CosmeticsShop.Models
{
    public class Product
    {
        private const int nameMinLength = 3;
        private const int nameMaxLength = 10;
        private const int brandMinLength = 2;
        private const int brandMaxLength = 10;

        private string name;
        private string brand;
        private double price;
        private readonly GenderType gender;

        public Product(string name, string brand, double price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                // TODO: Validate value
                DataValidator.ValidateNullString(value, nameof(this.Name));
                DataValidator.ValidateStringLength(value.Length, nameMinLength, nameMaxLength, nameof(this.Name));
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                // TODO: Validate brand
                DataValidator.ValidateNullString(value, nameof(this.Brand));
                DataValidator.ValidateStringLength(value.Length, brandMinLength, brandMaxLength, nameof(this.Brand));
                this.brand = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                // TODO: Validate price
                DataValidator.ValidateNonNegative(value, nameof(this.Price));
                this.price = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
        }

        public string Print()
        {
            var strBulder = new StringBuilder();
            strBulder.AppendLine($"#{this.name} {this.brand}");
            strBulder.AppendLine($" #Price: ${this.price}");
            strBulder.AppendLine($" #Gender: {this.gender}");

            return strBulder.ToString().Trim();
        }
    }
}
