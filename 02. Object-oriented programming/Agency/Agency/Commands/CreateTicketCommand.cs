using System.Collections.Generic;

using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Exceptions;
using Agency.Models.Contracts;
using Agency.Utilities;


namespace Agency.Commands
{
    public class CreateTicketCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;

        public CreateTicketCommand(IList<string> commandParameters, IRepository repository)
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

            int journeyId = this.ParseIntParameter(base.CommandParameters[0], "id");
            double administrativeCosts = this.ParseDoubleParameter(base.CommandParameters[1], "administrativeCosts");
            IJourney journey = this.Repository.FindJourneyById(journeyId);

            var ticket = base.Repository.CreateTicket(journey, administrativeCosts);
            return $"Ticket with ID {ticket.Id} was created.";
        }
    }
}
