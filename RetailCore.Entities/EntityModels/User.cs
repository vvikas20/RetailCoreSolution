using System;
using System.Collections.Generic;

namespace RetailCore.Entities.EntityModels;

public partial class User
{
    public Guid UserId { get; set; }

    public string Username { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public byte[] Salt { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public bool Verified { get; set; }

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<User> InverseCreatedByNavigation { get; set; } = new List<User>();

    public virtual ICollection<User> InverseModifiedByNavigation { get; set; } = new List<User>();

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<Note> NoteCreatedByNavigations { get; set; } = new List<Note>();

    public virtual ICollection<Note> NoteModifiedByNavigations { get; set; } = new List<Note>();

    public virtual ICollection<Role> RoleCreatedByNavigations { get; set; } = new List<Role>();

    public virtual ICollection<RoleLevel> RoleLevelCreatedByNavigations { get; set; } = new List<RoleLevel>();

    public virtual ICollection<RoleLevel> RoleLevelModifiedByNavigations { get; set; } = new List<RoleLevel>();

    public virtual ICollection<Role> RoleModifiiedByNavigations { get; set; } = new List<Role>();

    public virtual ICollection<Series> SeriesCreatedByNavigations { get; set; } = new List<Series>();

    public virtual ICollection<Series> SeriesModifiedByNavigations { get; set; } = new List<Series>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<UserSeries> UserSeries { get; set; } = new List<UserSeries>();
}
