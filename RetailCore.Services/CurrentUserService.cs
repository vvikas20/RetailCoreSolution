using RetailCore.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
    }
}
