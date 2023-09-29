using System.Text;

using Agency.Exceptions;
using Agency.Models.Contracts;
using Agency.Utilities;

namespace Agency.Models
{
    public class Train : Vehicle, ITrain
    {
        private const int PassengerCapacityMinValue = 30;
        private const int PassengerCapacityMaxValue = 150;
        private const int CartsMinValue = 1;
        private const int CartsMaxValue = 15;

        private int passengerCapacity;
        private int carts;

        public Train(int id, int passengerCapacity, double pricePerKilometer, int carts)
            : base(id, passengerCapacity, pricePerKilometer)
        {
            this.Carts = carts;
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
                    PassengerCapacityMaxValue, ExceptionMessages.InvalidTrainPassengerCapacity);

                this.passengerCapacity = value;
            }
        }

        public int Carts
        {
            get
            {
                return this.carts;
            }
            init
            {
                this.ValidateCartsAmount(value, CartsMinValue, CartsMaxValue);
                this.carts = value;
            }
        }

        private void ValidateCartsAmount(int amount, int minAmount, int maxAmount)
        {
            if (!ValidationHelper.NumberIsInRange(amount, minAmount, maxAmount))
            {
                throw new InvalidUserInputException(ExceptionMessages.InvalidTrainCartsAmount);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("Train ----");
            output.AppendLine($"Passenger capacity: {this.PassengerCapacity}");
            output.AppendLine($"Price per kilometer: {this.PricePerKilometer:F2}");
            output.Append($"Carts amount: {this.Carts}");

            return output.ToString();
        }
    }
}
