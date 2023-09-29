using System.Collections.Generic;

using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Exceptions;
using Agency.Utilities;


namespace Agency.Commands
{
    public class CreateBusCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3;

        public CreateBusCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException(string.Format(ExceptionMessages.InvalidNumberOfArguments,
                    ExpectedNumberOfArguments, this.CommandParameters.Count));
            }

            int passengerCapacity = this.ParseIntParameter(base.CommandParameters[0], "passengerCapacity");
            double pricePerKilometer = this.ParseDoubleParameter(base.CommandParameters[1], "pricePerKilometer");
            bool hasFreeTv = this.ParseBoolParameter(base.CommandParameters[2], "hasFreeTv");

            var bus = this.Repository.CreateBus(passengerCapacity, pricePerKilometer, hasFreeTv);
            return $"Vehicle with ID {bus.Id} was created.";
        }
    }
}
