using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject = RetailCore.BusinessObjects.BusinessObjects;

namespace RetailCore.ServiceContracts
{
    public interface IUserService
    {
        IEnumerable<BusinessObject.User> GetUsers();
        BusinessObject.User GetAdminUser();
        BusinessObject.User AddUser(BusinessObject.User user);
        BusinessObject.User GetUserById(Guid currentUser);
        BusinessObject.User UpdateUser(BusinessObject.User user);
        bool DeleteUser(Guid id);
        BusinessObject.User VerifyUser(string username, string password);
        int GetUserCount();
    }
}
