
using Dealership.Exceptions;
using Dealership.Models.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Dealership.Models
{
    public class User : IUser
    {
        private const string InvalidUsernameFormatError = "Username contains invalid symbols!";
        private const string InvalidStringLengthError = "{0} must be between {1} and {2} characters long!";
        private const string InvalidPasswordFormatError = "Password contains invalid symbols!";
        private const string NotAnVipUserVehiclesAdd = "You are not VIP and cannot add more than {0} vehicles!";
        private const string AdminCannotAddVehicles = "You are an admin and therefore cannot add vehicles!";
        private const string YouAreNotTheAuthor = "You are not the author of the comment you are trying to remove!";
        private const string NoVehiclesHeader = "--NO VEHICLES--";
        
        private const string UsernamePattern = "^[A-Za-z0-9]+$";
        private const string PasswordPattern = "^[A-Za-z0-9@*_-]+$";

        private const int NameMinLength = 2;
        private const int NameMaxLength = 20;
        private const int PasswordMinLength = 5;
        private const int PasswordMaxLength = 30;
        private const int MaxVehiclesToAdd = 5;

        private string username;
        private string firstName;
        private string lastName;
        private string password;
        private List<IVehicle> vehicles;
        private Role role;

        public User(string username, string firstName, string lastName, string password, Role role)
        {
            this.vehicles = new List<IVehicle>();

            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = role;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            init
            {
                this.ValidateUsername(value);
                this.username = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            init
            {
                this.ValidateName(value, nameof(this.FirstName));
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            init
            {
                this.ValidateName(value, nameof(this.LastName));
                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            init
            {
                this.ValidatePassword(value);
                this.password = value;
            }
        }

        public Role Role
        {
            get
            {
                return this.role;
            }
            init
            {
                this.role = value;
            }
        }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return new List<IVehicle>(vehicles);
            }
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            vehicleToAddComment.AddComment(commentToAdd);
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if (commentToRemove.Author != this.Username)
            {
                throw new AuthorizationException(YouAreNotTheAuthor);
            }

            vehicleToRemoveComment.RemoveComment(commentToRemove);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (this.Role == Role.Admin)
            {
                throw new AuthorizationException(AdminCannotAddVehicles);
            }

            if (this.Role != Role.VIP)
            {
                if (this.vehicles.Count == MaxVehiclesToAdd)
                {
                    throw new AuthorizationException(string.Format(NotAnVipUserVehiclesAdd, MaxVehiclesToAdd));
                }
            }
            
            this.vehicles.Add(vehicle);
        }               

        public void RemoveVehicle(IVehicle vehicle)
        {
            this.vehicles.Remove(vehicle);
        }

        public string PrintVehicles()
        {
            if (!this.vehicles.Any())
            {
                throw new InvalidUserInputException(NoVehiclesHeader);
            }

            StringBuilder output = new StringBuilder();
            output.AppendLine($"--USER {this.Username}--");

            int vehicleCounter = 1;

            foreach (var vehicle in this.vehicles)
            {
                output.Append(vehicleCounter);
                output.AppendLine(vehicle.ToString());
                vehicleCounter++;
            }

            return output.ToString();
        }

        public override string ToString()
        {
            return $"Username: {this.Username}, FullName: {this.FirstName + " " +this.LastName}, Role: { this.Role}";
        }

        private void ValidatePassword(string password)
        {
            Validator.ValidateStringNullOrEmpty(password, nameof(this.Password));

            Validator.ValidateSymbols(password, PasswordPattern, InvalidPasswordFormatError);

            Validator.ValidateIntRange(password.Length, PasswordMinLength, PasswordMaxLength,
                string.Format(InvalidStringLengthError, nameof(this.Password), PasswordMinLength, PasswordMaxLength));
        }

        private void ValidateUsername(string username)
        {
            Validator.ValidateStringNullOrEmpty(username, nameof(this.Username));

            Validator.ValidateSymbols(username, UsernamePattern, InvalidUsernameFormatError);

            Validator.ValidateIntRange(username.Length, NameMinLength, NameMaxLength,
                string.Format(InvalidStringLengthError, nameof(this.Username), NameMinLength, NameMaxLength));
        }

        private void ValidateName(string name, string propertyName)
        {
            Validator.ValidateStringNullOrEmpty(name, propertyName);

            Validator.ValidateIntRange(name.Length, NameMinLength, NameMaxLength,
                string.Format(InvalidStringLengthError, propertyName, NameMinLength, NameMaxLength));
        }        
    }
}
