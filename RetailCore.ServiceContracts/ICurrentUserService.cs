using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.ServiceContracts
{
    public interface ICurrentUserService
    {
        Guid UserId { get; set; }
        string Username { get; set; }
        List<string> Permissions { get; set; }
    }
}
