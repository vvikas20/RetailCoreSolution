using RetailCore.BusinessObjects.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.BusinessObjects.Systems
{
    public class ApplicationUser
    {

        private readonly object _lock = new object();

        public void SetApplicationUser(User existingUser, IEnumerable<Permission> permissions)
        {
            lock (_lock)
            {
                if (existingUser == null)
                    throw new ArgumentNullException(nameof(existingUser));

                UserId = existingUser.UserId;
                Username = existingUser.Username;
                FirstName = existingUser.FirstName;
                LastName = existingUser.LastName;
                Email = existingUser.Email;
                RoleId = existingUser.Role.RoleId;
                RoleName = existingUser.Role.RoleName;
                RoleLevelId = existingUser.Role.RoleLevel.RoleLevelId;
                RoleLevelName = existingUser.Role.RoleLevel.RoleLevelName;
                RoleLevelDisplayName = existingUser.Role.RoleLevel.RoleLevelDisplayName;
                RoleLevelValue = existingUser.Role.RoleLevel.RoleLevel1;
                Permissions = permissions ?? new List<Permission>();
            }
        }

        public Guid UserId { get; private set; }

        public string Username { get; private set; } = null!;

        public string FirstName { get; private set; } = null!;

        public string? LastName { get; private set; }

        public string Email { get; private set; } = null!;

        public Guid RoleId { get; private set; }

        public string RoleName { get; private set; } = null!;

        public Guid RoleLevelId { get; private set; }

        public string RoleLevelName { get; private set; } = null!;

        public string? RoleLevelDisplayName { get; private set; }

        public int RoleLevelValue { get; private set; }

        public IEnumerable<Permission> Permissions { get; private set; } = new List<Permission>();
    }
}
