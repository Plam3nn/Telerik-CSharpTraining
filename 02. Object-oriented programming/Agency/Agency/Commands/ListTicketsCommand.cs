﻿using System.Text;

using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Models.Contracts;

namespace Agency.Commands
{
    public class ListTicketsCommand : BaseCommand
    {
        public ListTicketsCommand(IRepository repository)
            : base(repository)
        {
        }

        public override string Execute()
        {
            if (this.Repository.Tickets.Count > 0)
            {
                var sb = new StringBuilder();

                foreach (ITicket ticket in this.Repository.Tickets)
                {
                    sb.AppendLine(ticket.ToString());
                    sb.AppendLine("####################");
                }

                return sb.ToString().Trim();
            }
            else
            {
                return "There are no registered tickets.";
            }
        }
    }
}
