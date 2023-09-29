using System.Text;

using Agency.Exceptions;
using Agency.Models.Contracts;
using Agency.Utilities;

namespace Agency.Models
{
    public class Ticket : ITicket
    {
        private double administrativeCosts;
        private IJourney journey;

        public Ticket(int id, IJourney journey, double administrativeCosts)
        {
            this.Id = id;
            this.Journey = journey;
            this.AdministrativeCosts = administrativeCosts;
        }

        public int Id { get; init; }

        public double AdministrativeCosts
        {
            get
            {
                return this.administrativeCosts;
            }
            init
            {
                ValidateNegativeAdministrativeCost(value);
                this.administrativeCosts = value;
            }
        }

        public IJourney Journey
        {
            get
            {
                return this.journey;
            }
            init
            {
                this.journey = value;
            }
        }

        public double CalculatePrice()
        {
            return this.AdministrativeCosts * this.Journey.CalculatePrice();
        }

        private void ValidateNegativeAdministrativeCost(double value)
        {
            if (value < 0)
            {
                throw new InvalidUserInputException(string.Format(ExceptionMessages.InvalidAdministrativeCost, value));
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("Ticket ----");
            output.AppendLine($"Destination: {this.Journey.Destination}");
            output.Append($"Price: {this.CalculatePrice():F2}");

            return output.ToString();
        }
    }
}
