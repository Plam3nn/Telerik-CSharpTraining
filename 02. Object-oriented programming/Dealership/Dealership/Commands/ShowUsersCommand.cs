using Dealership.Models;
using Dealership.Core.Contracts;
using Dealership.Exceptions;
using System.Text;

namespace Dealership.Commands
{
    public class ShowUsersCommand : BaseCommand
    {
        public ShowUsersCommand(IRepository repository) 
            : base(repository)
        {
        }

        protected override bool RequireLogin
        {
            get { return true; }
        }

        protected override string ExecuteCommand()
        {
            if (this.Repository.LoggedUser.Role != Role.Admin)
            {
                throw new AuthorizationException("You are not an admin!");
            }

            StringBuilder output = new StringBuilder();
            output.AppendLine("--USERS--");

            int userCounter = 1;

            foreach (var user in this.Repository.Users)
            {
                output.AppendLine($"{userCounter++}. {user.ToString()}");
            }

            return output.ToString();
        }
    }
}
