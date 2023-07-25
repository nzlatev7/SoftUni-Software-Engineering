using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private UserRepository users;
        private VehicleRepository vehicles;
        private RouteRepository routes;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            IUser user;

            if (users.FindById(drivingLicenseNumber) != null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }

            user = new User(firstName, lastName, drivingLicenseNumber);
            users.AddModel(user);

            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)  
        {
            
            if (vehicleType != "PassengerCar"
                && vehicleType != "CargoVan")
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            if (vehicles.FindById(licensePlateNumber) != null)
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }

            IVehicle vehicle = null;

            switch (vehicleType)
            {
                case "PassengerCar":
                    vehicle = new PassengerCar(brand, model, licensePlateNumber);
                    break;
                case "CargoVan":
                    vehicle = new CargoVan(brand, model, licensePlateNumber);
                    break;
            }

            vehicles.AddModel(vehicle);

            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            IRoute route;

            if (routes.GetAll()
                .Any(x => x.StartPoint == startPoint 
                    && x.EndPoint == endPoint 
                    && x.Length == length))
            {
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }

            if (routes.GetAll()
                .Any(x => x.StartPoint == startPoint
                    && x.EndPoint == endPoint
                    && x.Length < length))
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }

            if (routes.GetAll()
                .Any(x => x.StartPoint == startPoint
                    && x.EndPoint == endPoint
                    && x.Length > length))
            {
                var routeForLock = routes.GetAll()
                    .Where(x => x.StartPoint == startPoint
                        && x.EndPoint == endPoint
                        && x.Length > length).FirstOrDefault();

                routeForLock.LockRoute();
            }

            route = new Route(startPoint, endPoint, length, routes.Count + 1);
            routes.AddModel(route);

            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            var user = users.FindById(drivingLicenseNumber);
            var route = routes.FindById(routeId);
            var vehicle = vehicles.FindById(licensePlateNumber);

            if (user.IsBlocked)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }

            if (vehicle.IsDamaged)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }

            if (route.IsLocked)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);
            }

            vehicle.Drive(route.Length);

            if (isAccidentHappened)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }

        public string RepairVehicles(int count)
        {
            List<IVehicle> damagedVehicles = vehicles.GetAll()
                .Where(x => x.IsDamaged)
                .OrderBy(x => x.Brand)
                .ThenBy(x => x.Model)
                .Take(count)
                .ToList();

            foreach (var vehicle in damagedVehicles)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }

            return string.Format(OutputMessages.RepairedVehicles, damagedVehicles.Count);
        }

        public string UsersReport()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine("*** E-Drive-Rent ***");

            foreach (var user in users.GetAll()
                .OrderByDescending(x => x.Rating)
                .ThenBy(x => x.LastName)
                .ThenBy(x => x.FirstName))
            {
                report.AppendLine(user.ToString());
            }

            return report.ToString().TrimEnd();
        }
    }
}
