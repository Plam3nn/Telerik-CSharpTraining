namespace Agency.Utilities
{
    public static class ExceptionMessages
    {
        //Vehicle
        public const string InvalidVehiclePassengerCapacity = "A vehicle with less than 1 passengers or more than 800 passengers cannot exist!";
        public const string InvalidPricePerKilometer = "A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!";

        //Train
        public const string InvalidTrainPassengerCapacity = "A train cannot have less than 30 passengers or more than 150 passengers.";
        public const string InvalidTrainCartsAmount = "A train cannot have less than 1 cart or more than 15 carts.";

        //Bus
        public const string InvalidBusPassengerCapacity = "A bus cannot have less than 10 passengers or more than 50 passengers.";

        //Journey
        public const string InvalidStartLocationLength = "The StartingLocation's length cannot be less than 5 or more than 25 symbols long.";
        public const string InvalidDestinationLength = "The Destination's length cannot be less than 5 or more than 25 symbols long.";
        public const string InvalidDistance = "The Distance cannot be less than 5 or more than 5000 kilometers.";

        //Ticket
        public const string InvalidAdministrativeCost = "Value of 'costs' must be a positive number. Actual value: {0}.";
        //public const string 

        //Repository
        public const string VehicleNotFound = "Vehicle with id: {0} was not found!";
        public const string JourneyNotFound = "Journey with id: {0} was not found!";
        public const string TicketNotFound = "Ticket with id: {0} was not found!";

        //Commands
        public const string InvalidNumberOfArguments = "Invalid number of arguments. Expected: {0}, Received: {1}";
    }
}
