using System.Collections.Generic;

using Agency.Core.Contracts;
using Agency.Exceptions;
using Agency.Models;
using Agency.Models.Contracts;
using Agency.Utilities;

namespace Agency.Core
{
    public class Repository : IRepository
    {
        private readonly List<IVehicle> vehicles = new List<IVehicle>();
        private readonly List<IJourney> journeys = new List<IJourney>();
        private readonly List<ITicket> tickets = new List<ITicket>();

        public IList<IVehicle> Vehicles
        {
            get
            {
                return new List<IVehicle>(vehicles);
            }
        }
        public IList<IJourney> Journeys
        {
            get
            {
                return new List<IJourney>(journeys);
            }
        }
        public IList<ITicket> Tickets
        {
            get
            {
                return new List<ITicket>(tickets);
            }
        }

        public IBus CreateBus(int passengerCapacity, double pricePerKilometer, bool hasFreeTv)
        {
            int nextId = this.Vehicles.Count + 1;
            Bus bus = new Bus(nextId, passengerCapacity, pricePerKilometer, hasFreeTv);
            this.vehicles.Add(bus);
            return bus;
        }

        public IAirplane CreateAirplane(int passengerCapacity, double pricePerKilometer, bool isLowCost)
        {
            int nextId = this.Vehicles.Count + 1;
            Airplane airplane = new Airplane(nextId, passengerCapacity, pricePerKilometer, isLowCost);
            this.vehicles.Add(airplane);
            return airplane;
        }

        public ITrain CreateTrain(int passengerCapacity, double pricePerKilometer, int carts)
        {
            int nextId = this.Vehicles.Count + 1;
            Train train = new Train(nextId, passengerCapacity, pricePerKilometer, carts);
            this.vehicles.Add(train);
            return train;
        }

        public IJourney CreateJourney(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            int nextId = this.Journeys.Count + 1;
            Journey journey = new Journey(nextId, startLocation, destination, distance, vehicle);
            this.journeys.Add(journey);
            return journey;
        }

        public ITicket CreateTicket(IJourney journey, double administrativeCosts)
        {
            int nextId = this.Tickets.Count + 1;
            Ticket ticket = new Ticket(nextId, journey, administrativeCosts);
            this.tickets.Add(ticket);
            return ticket;
        }

        public IVehicle FindVehicleById(int id)
        {
            foreach (var vehicle in this.Vehicles)
            {
                if (vehicle.Id == id)
                {
                    return vehicle;
                }
            }

            throw new EntityNotFoundException(string.Format(ExceptionMessages.VehicleNotFound, id));
        }

        public IJourney FindJourneyById(int id)
        {
            foreach (var journey in this.Journeys)
            {
                if (journey.Id == id)
                {
                    return journey;
                }
            }

            throw new EntityNotFoundException(string.Format(ExceptionMessages.JourneyNotFound, id));
        }

        public ITicket FindTicketById(int id)
        {
            foreach (var ticket in this.Tickets)
            {
                if (ticket.Id == id)
                {
                    return ticket;
                }
            }

            throw new EntityNotFoundException(string.Format(ExceptionMessages.TicketNotFound, id));
        }
    }
}
