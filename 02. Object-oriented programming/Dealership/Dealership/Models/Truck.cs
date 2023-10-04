using Dealership.Models.Contracts;

using System.Text;

namespace Dealership.Models
{
    public class Truck : Vehicle, ITruck
    {
        private const string InvalidCapacityError = "Weight capacity must be between {0} and {1}!";

        private const int wheelsCount = 8;
        private const int MinCapacity = 1;
        private const int MaxCapacity = 100;

        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity) 
            : base(make, model, price)
        {
            this.WeightCapacity = weightCapacity;
        }

        public override VehicleType Type
        {
            get
            {
                return VehicleType.Truck;
            }
        }

        public override int Wheels
        {
            get
            {
                return wheelsCount;
            }
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }
            init
            {
                this.ValidateWeightCapacity(value);
                this.weightCapacity = value;
            }
        }

        protected override string AdditionalInfo()
        {
            return $"Weight Capacity: {this.WeightCapacity}t";
        }

        private void ValidateWeightCapacity(int capacity)
        {
            Validator.ValidateIntRange(capacity, MinCapacity, MaxCapacity, 
                string.Format(InvalidCapacityError, MinCapacity, MaxCapacity));
        }
    }
}
