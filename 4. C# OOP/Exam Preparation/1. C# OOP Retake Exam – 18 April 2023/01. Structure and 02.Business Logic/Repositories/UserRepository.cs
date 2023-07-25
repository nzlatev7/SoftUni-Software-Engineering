using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories.Contracts
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> users;

        public UserRepository()
        {
            users = new List<IUser>();
        }

        public void AddModel(IUser model)
        {
            users.Add(model);
        }
        public bool RemoveById(string identifier)
        {
            var user = FindById(identifier);

            return users.Remove(user);
        }

        public IUser FindById(string identifier)
        {
            return users
                .FirstOrDefault(x => x.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            return users.AsReadOnly();
        }
    }
}
