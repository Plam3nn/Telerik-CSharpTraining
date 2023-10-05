using Dealership.Models.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle
    {        
        private const string InvalidMakeError = "Make must be between {0} and {1} characters long!";
        private const string InvalidModelError = "Model must be between {0} and {1} characters long!";
        private const string InvalidPriceError = "Price must be between {0} and {1}!";

        private const int MakeMinLength = 2;
        private const int MakeMaxLength = 15;
        private const int ModelMinLength = 1;
        private const int ModelMaxLength = 15;
        private const decimal MinPrice = 0.0m;
        private const decimal MaxPrice = 1000000.0m;

        private string make;
        private string model;
        private decimal price;
        private readonly IList<IComment> comments;

        protected Vehicle(string make, string model, decimal price)
        {
            this.comments = new List<IComment>();

            this.Make = make;
            this.Model = model;
            this.Price = price;
        }

        public abstract int Wheels { get; }

        public abstract VehicleType Type { get; }

        public string Make
        {
            get
            {
                return this.make;
            }
            init
            {
                this.ValidateMake(value);
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            init
            {
                this.ValidateModel(value);
                this.model = value;
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
                this.ValidatePrice(value);
                this.price = value;
            }
        }

        public IList<IComment> Comments
        {
            get
            {
                return new List<IComment>(comments);
            }
        }

        protected abstract string AdditionalInfo();

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"{this.Type}:");
            output.AppendLine($"  Make: {this.Make}");
            output.AppendLine($"  Model: {this.Model}");
            output.AppendLine($"  Wheels: {this.Wheels}");
            output.AppendLine($"  Price: ${this.Price}");
            output.AppendLine($"  {this.AdditionalInfo()}");

            if (this.Comments.Any())
            {
                output.AppendLine("    --COMMENTS--");
                
                foreach (var comment in this.Comments)
                {
                    output.AppendLine("    ----------");
                    output.AppendLine($"    {comment.ToString()}");
                    output.AppendLine("    ----------");
                }

                output.Append("    --COMMENTS--");
            }
            else
            {
                output.Append("    --NO COMMENTS--");
            }

            return output.ToString();
        }

        public void AddComment(IComment comment)
        {
            this.comments.Add(comment);
        }

        public void RemoveComment(IComment comment)
        {
            this.comments.Remove(comment);
        }

        private void ValidatePrice(decimal price)
        {
            Validator.ValidateDecimalRange(price, MinPrice, MaxPrice, 
                string.Format(InvalidPriceError, MinPrice, MaxPrice));
        }

        private void ValidateModel(string model)
        {
            Validator.ValidateStringNullOrEmpty(model, nameof(this.Model));

            Validator.ValidateIntRange(model.Length, ModelMinLength, ModelMaxLength, 
                string.Format(InvalidModelError, ModelMinLength, ModelMaxLength));
        }

        private void ValidateMake(string make)
        {
            Validator.ValidateStringNullOrEmpty(make, nameof(this.Make));

            Validator.ValidateIntRange(make.Length, MakeMinLength, MakeMaxLength,
                string.Format(InvalidMakeError, MakeMinLength, MakeMaxLength));
        }
    }
}
