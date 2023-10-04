using Dealership.Models.Contracts;

using System.Text;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IMotorcycle
    {        
        private const string InvalidCategoryError = "Category must be between {0} and {1} characters long!";

        private const int wheelsCount = 2;
        private const int CategoryMinLength = 3;
        private const int CategoryMaxLength = 10;

        private string category;

        public Motorcycle(string make, string model, decimal price, string category) 
            : base(make, model, price)
        {
            this.Category = category;
        }

        public override VehicleType Type
        {
            get
            {
                return VehicleType.Motorcycle;
            }
        }

        public override int Wheels
        {
            get
            {
                return wheelsCount;
            }
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            init
            {
                this.ValidateCategory(value);
                this.category = value;
            }
        }

        protected override string AdditionalInfo()
        {
            return $"Category: {this.Category}";
        }

        private void ValidateCategory(string category)
        {
            Validator.ValidateStringNullOrEmpty(category, nameof(this.Category));

            Validator.ValidateIntRange(category.Length, CategoryMinLength, CategoryMaxLength, 
                string.Format(InvalidCategoryError, CategoryMinLength, CategoryMaxLength));
        }
    }
}
