using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Text;

namespace Cosmetics.Models
{
    public abstract class Product : IProduct
    {       
        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            init
            {
                ValidateName(value, nameof(this.Name));
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            init
            {
                ValidateBrand(value, nameof(this.Brand));
                this.brand = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            init
            {
                ValidatePrice(value);
                this.price = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
            init
            {
                ValidateGender(value);
                this.gender = value;
            }
        }

        public string Print()
        {
            var output = new StringBuilder();

            output.AppendLine($"#{this.Name} {this.Brand}");
            output.AppendLine($" #Price: ${this.Price}");
            output.AppendLine($" #Gender: {this.Gender}");
            output.AppendLine(AdditionalInfo());
            output.Append(" ===");

            return output.ToString();
        }

        protected abstract string AdditionalInfo();

        protected abstract void ValidateName(string value, string fieldName);

        protected abstract void ValidateBrand(string value, string fieldName);

        protected abstract void ValidatePrice(decimal price);

        private void ValidateGender(GenderType gender)
        {
            if (gender != GenderType.Men
                && gender != GenderType.Women
                && gender != GenderType.Unisex)
            {
                throw new ArgumentException($"Invalid input for gender. Gender can be '{GenderType.Men}', '{GenderType.Women}' or '{GenderType.Unisex}'");
            }
        }        
    }
}