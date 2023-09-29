using System.Text;

using Agency.Exceptions;
using Agency.Models.Contracts;
using Agency.Utilities;

namespace Agency.Models
{
    public class Journey : IJourney
    {
        private const int StartLocationMinLength = 5;
        private const int StartLocationMaxLength = 25;
        private const int DestinationMinLength = 5;
        private const int DestinationMaxLength = 25;
        private const int DistanceMinValue = 5;
        private const int DistanceMaxValue = 5000;

        private string startLocation;
        private string destination;
        private int distance;

        public Journey(int id, string from, string to, int distance, IVehicle vehicle)
        {
            this.Id = id;
            this.StartLocation = from;
            this.Destination = to;
            this.Distance = distance;
            this.Vehicle = vehicle;
        }

        public string StartLocation
        {
            get
            {
                return this.startLocation;
            }
            init
            {
                this.ValidateStartLocationLength(value.Length, StartLocationMinLength, 
                    StartLocationMaxLength);

                this.startLocation = value;
            }
        }

        public string Destination
        {
            get
            {
                return this.destination;
            }
            init
            {
                this.ValidateDestinationLength(value.Length, DestinationMinLength,
                    DestinationMaxLength);

                this.destination = value;
            }
        }

        public int Distance
        {
            get
            {
                return this.distance;
            }
            init
            {
                this.ValidateDistance(value, DistanceMinValue, 
                    DistanceMaxValue);

                this.distance = value;
            }
        }

        public IVehicle Vehicle { get; init; }

        public int Id { get; init; }

        public double CalculatePrice()
        {
            return this.Distance * this.Vehicle.PricePerKilometer;
        }

        private void ValidateStartLocationLength(int startLocationLength, int minLength, int maxLength)
        {
            if (!ValidationHelper.NumberIsInRange(startLocationLength, minLength, maxLength))
            {
                throw new InvalidUserInputException(ExceptionMessages.InvalidStartLocationLength);
            }
        }

        private void ValidateDestinationLength(int destinationLength, int minLength, int maxLength)
        {
            if (!ValidationHelper.NumberIsInRange(destinationLength, minLength, maxLength))
            {
                throw new InvalidUserInputException(ExceptionMessages.InvalidDestinationLength);
            }
        }

        private void ValidateDistance(int distance, int minDistance, int maxDistance)
        {
            if (!ValidationHelper.NumberIsInRange(distance, minDistance, maxDistance))
            {
                throw new InvalidUserInputException(ExceptionMessages.InvalidDistance);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("Journey ----");
            output.AppendLine($"Start location: {this.StartLocation}");
            output.AppendLine($"Destination: {this.Destination}");
            output.AppendLine($"Distance: {this.Distance}");
            output.Append($"Travel cost: {this.CalculatePrice():F2}");

            return output.ToString();
        }
    }   
}
