using System.Text;

using Agency.Models.Contracts;
using Agency.Utilities;

namespace Agency.Models
{
    public class Bus : Vehicle, IBus
    {
        private const int PassengerCapacityMinValue = 10;
        private const int PassengerCapacityMaxValue = 50;

        private int passengerCapacity;

        public Bus(int id, int passengerCapacity, double pricePerKilometer, bool hasFreeTv)
            : base(id, passengerCapacity, pricePerKilometer)
        {
            this.HasFreeTv = hasFreeTv;
        }

        public override int PassengerCapacity
        {
            get
            {
                return this.passengerCapacity;
            }
            init
            {
                base.ValidatePassengerCapacity(value, PassengerCapacityMinValue, 
                    PassengerCapacityMaxValue, ExceptionMessages.InvalidBusPassengerCapacity);

                this.passengerCapacity = value;
            }
        }

        public bool HasFreeTv { get; init; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("Bus ----");
            output.AppendLine($"Passenger capacity: {this.PassengerCapacity}");
            output.AppendLine($"Price per kilometer: {this.PricePerKilometer:F2}");
            output.Append($"Has free TV: {this.HasFreeTv}");

            return output.ToString();
        }

        
    }
}
