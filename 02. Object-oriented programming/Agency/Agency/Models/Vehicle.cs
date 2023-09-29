using Agency.Exceptions;
using Agency.Models.Contracts;
using Agency.Utilities;

namespace Agency.Models
{
    public abstract class Vehicle : IVehicle
    {
        private const int PassengerCapacityMinValue = 1;
        private const int PassengerCapacityMaxValue = 800;
        private const double PricePerKilometerMinValue = 0.10;
        private const double PricePerKilometerMaxValue = 2.50;

        private int passengerCapacity;
        private double pricePerKilometer;

        protected Vehicle(int id, int passengerCapacity, double pricePerKilometer)
        {
            this.Id = id;
            this.PassengerCapacity = passengerCapacity;
            this.PricePerKilometer = pricePerKilometer;
        }

        public int Id { get; init; }

        public virtual int PassengerCapacity
        {
            get
            {
                return this.passengerCapacity;
            }
            init
            {
                this.ValidatePassengerCapacity(value, PassengerCapacityMinValue, 
                    PassengerCapacityMaxValue, ExceptionMessages.InvalidVehiclePassengerCapacity);

                this.passengerCapacity = value;
            }
        }

        public double PricePerKilometer
        {
            get
            {
                return this.pricePerKilometer;
            }
            init
            {
                this.ValidatePricePerKilometer(value, PricePerKilometerMinValue,
                    PricePerKilometerMaxValue);

                this.pricePerKilometer = value;
            }
        }

        protected void ValidatePassengerCapacity(int capacity, int minCapacity, int maxCapacity, string exceptionMessage)
        {
            if (!ValidationHelper.NumberIsInRange(capacity, minCapacity, maxCapacity))
            {
                throw new InvalidUserInputException(exceptionMessage);
            }
        }

        private void ValidatePricePerKilometer(double price, double minPrice, double maxPrice)
        {
            if (!ValidationHelper.NumberIsInRange(price, minPrice, maxPrice))
            {
                throw new InvalidUserInputException(ExceptionMessages.InvalidPricePerKilometer);
            }
        }        
    }
}
