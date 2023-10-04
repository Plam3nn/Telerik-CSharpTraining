using Dealership.Models.Contracts;

using System.Text;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar
    {       
        private const string InvalidSeatsError = "Seats must be between {0} and {1}!";

        private const int wheelsCount = 4;
        private const int MinSeats = 1;
        private const int MaxSeats = 10;

        private int seats;

        public Car(string make, string model, decimal price, int seats) 
            : base(make, model, price)
        {
            this.Seats = seats;
        }

        public override VehicleType Type
        {
            get
            {
                return VehicleType.Car;
            }
        }

        public override int Wheels
        {
            get
            {
                return wheelsCount;
            }
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }
            init
            {
                this.ValidateSeats(value);
                this.seats = value;
            }
        }

        protected override string AdditionalInfo()
        {
            return $"Seats: {this.Seats}";
        }

        private void ValidateSeats(int seatsCount)
        {
            Validator.ValidateIntRange(seatsCount, MinSeats, MaxSeats, 
                string.Format(InvalidSeatsError, MinSeats, MaxSeats));
        }
    }
}
