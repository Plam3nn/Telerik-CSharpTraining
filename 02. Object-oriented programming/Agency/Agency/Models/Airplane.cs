using System.Text;

using Agency.Models.Contracts;

namespace Agency.Models
{
    public class Airplane : Vehicle, IAirplane
    {
        public Airplane(int id, int passengerCapacity, double pricePerKilometer, bool isLowCost)
            : base(id, passengerCapacity, pricePerKilometer)
        {
            this.IsLowCost = isLowCost;
        }        

        public bool IsLowCost { get; init; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("Airplane ----");
            output.AppendLine($"Passenger capacity: {this.PassengerCapacity}");
            output.AppendLine($"Price per kilometer: {this.PricePerKilometer:F2}");
            output.Append($"Is low-cost: {this.IsLowCost}");

            return output.ToString();
        }
    }
}
