using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RetailCore.Entities.EntityModels;
using RetailCore.Interfaces.DataAccess;

namespace RetailCore.Persistance.Context;

public partial class DevelopmentDiaryContext : BaseDBContext
{
	public DevelopmentDiaryContext() : base()
	{
	}

	public DevelopmentDiaryContext(DbContextOptions<DevelopmentDiaryContext> options)
	: base(options)
	{
	}

	public virtual DbSet<Note> Notes { get; set; }

	public virtual DbSet<Permission> Permissions { get; set; }

	public virtual DbSet<PermissionType> PermissionTypes { get; set; }

	public virtual DbSet<Role> Roles { get; set; }

	public virtual DbSet<RoleLevel> RoleLevels { get; set; }

	public virtual DbSet<RolePermission> RolePermissions { get; set; }

	public virtual DbSet<Series> Series { get; set; }
	public virtual DbSet<User> Users { get; set; }

	public virtual DbSet<UserRole> UserRoles { get; set; }

	public virtual DbSet<UserSeries> UserSeries { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
		=> optionsBuilder.UseSqlServer("Data Source=2212VIKASS0000L\\MSSQLSERVER2019;Initial Catalog=DevelopmentDiary;Persist Security Info=True;User ID=sa;Password=Microsoft#1234;TrustServerCertificate=True");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Note>(entity =>
		{
			entity.HasKey(e => e.NotesId);

			entity.Property(e => e.NotesId)
				.ValueGeneratedNever()
				.HasColumnName("NotesID");
			entity.Property(e => e.CreatedOn).HasColumnType("datetime");
			entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
			entity.Property(e => e.NotesDisplayName).HasMaxLength(50);
			entity.Property(e => e.NotesHeader).HasMaxLength(200);
			entity.Property(e => e.NotesName).HasMaxLength(50);
			entity.Property(e => e.SeriesId).HasColumnName("SeriesID");

			entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.NoteCreatedByNavigations)
				.HasForeignKey(d => d.CreatedBy)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Notes_UserCreatedBy");

			entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.NoteModifiedByNavigations)
				.HasForeignKey(d => d.ModifiedBy)
				.HasConstraintName("FK_Notes_UserModifiedBy");

			entity.HasOne(d => d.Series).WithMany(p => p.Notes)
				.HasForeignKey(d => d.SeriesId)
				.HasConstraintName("FK_Notes_Series");
		});

		modelBuilder.Entity<Permission>(entity =>
		{
			entity.ToTable("Permission");

			entity.Property(e => e.PermissionId)
				.ValueGeneratedNever()
				.HasColumnName("PermissionID");
			entity.Property(e => e.PermissionData).HasMaxLength(50);
			entity.Property(e => e.PermissionDisplayName).HasMaxLength(50);
			entity.Property(e => e.PermissionName).HasMaxLength(50);
			entity.Property(e => e.PermissionTypeId).HasColumnName("PermissionTypeID");

			entity.HasOne(d => d.PermissionType).WithMany(p => p.Permissions)
				.HasForeignKey(d => d.PermissionTypeId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Permission_PermissionType");
		});

		modelBuilder.Entity<PermissionType>(entity =>
		{
			entity.ToTable("PermissionType");

			entity.Property(e => e.PermissionTypeId)
				.ValueGeneratedNever()
				.HasColumnName("PermissionTypeID");
			entity.Property(e => e.PermissionTypeDisplayName).HasMaxLength(50);
			entity.Property(e => e.PermissionTypeName).HasMaxLength(50);
		});

		modelBuilder.Entity<Role>(entity =>
		{
			entity.ToTable("Role");

			entity.Property(e => e.RoleId)
				.ValueGeneratedNever()
				.HasColumnName("RoleID");
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
			entity.Property(e => e.RoleDisplayName).HasMaxLength(50);
			entity.Property(e => e.RoleLevelId).HasColumnName("RoleLevelID");
			entity.Property(e => e.RoleName).HasMaxLength(50);

			entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RoleCreatedByNavigations)
				.HasForeignKey(d => d.CreatedBy)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Role_CreatedByUser");

			entity.HasOne(d => d.ModifiiedByNavigation).WithMany(p => p.RoleModifiiedByNavigations)
				.HasForeignKey(d => d.ModifiiedBy)
				.HasConstraintName("FK_Role_ModifiedUser");

			entity.HasOne(d => d.RoleLevel).WithMany(p => p.Roles)
				.HasForeignKey(d => d.RoleLevelId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Role_RoleLevel");
		});

		modelBuilder.Entity<RoleLevel>(entity =>
		{
			entity.ToTable("RoleLevel");

			entity.Property(e => e.RoleLevelId)
				.ValueGeneratedNever()
				.HasColumnName("RoleLevelID");
			entity.Property(e => e.CreatedOn).HasColumnType("datetime");
			entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
			entity.Property(e => e.RoleLevelDisplayName).HasMaxLength(50);
			entity.Property(e => e.RoleLevelName).HasMaxLength(50);

			entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RoleLevelCreatedByNavigations)
				.HasForeignKey(d => d.CreatedBy)
				.HasConstraintName("FK_RoleLevel_User");

			entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.RoleLevelModifiedByNavigations)
				.HasForeignKey(d => d.ModifiedBy)
				.HasConstraintName("FK_RoleLevel_User1");
		});

		modelBuilder.Entity<RolePermission>(entity =>
		{
			entity.ToTable("RolePermission");

			entity.Property(e => e.RolePermissionId)
				.ValueGeneratedNever()
				.HasColumnName("RolePermissionID");
			entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
			entity.Property(e => e.RoleId).HasColumnName("RoleID");

			entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
				.HasForeignKey(d => d.PermissionId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_RolePermission_Permission");

			entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
				.HasForeignKey(d => d.RoleId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_RolePermission_Role");
		});

		modelBuilder.Entity<Series>(entity =>
		{
			entity.Property(e => e.SeriesId)
				.ValueGeneratedNever()
				.HasColumnName("SeriesID");
			entity.Property(e => e.CreatedOn).HasColumnType("datetime");
			entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
			entity.Property(e => e.SeriesDisplayName).HasMaxLength(50);
			entity.Property(e => e.SeriesName).HasMaxLength(50);

			entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.SeriesCreatedByNavigations)
				.HasForeignKey(d => d.CreatedBy)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Series_UserCreatedBy");

			entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.SeriesModifiedByNavigations)
				.HasForeignKey(d => d.ModifiedBy)
				.HasConstraintName("FK_Series_UserModifiedBy");
		});

		modelBuilder.Entity<User>(entity =>
		{
			entity.ToTable("User");

			entity.Property(e => e.UserId)
				.ValueGeneratedNever()
				.HasColumnName("UserID");
			entity.Property(e => e.CreatedOn).HasColumnType("datetime");
			entity.Property(e => e.Email).HasMaxLength(30);
			entity.Property(e => e.FirstName).HasMaxLength(50);
			entity.Property(e => e.LastName).HasMaxLength(50);
			entity.Property(e => e.MiddleName).HasMaxLength(50);
			entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
			entity.Property(e => e.PasswordHash).HasMaxLength(32);
			entity.Property(e => e.Salt).HasMaxLength(32);
			entity.Property(e => e.Username).HasMaxLength(50);

			entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
				.HasForeignKey(d => d.CreatedBy)
				.HasConstraintName("FK_User_UserCreatedBy");

			entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.InverseModifiedByNavigation)
				.HasForeignKey(d => d.ModifiedBy)
				.HasConstraintName("FK_User_UserModifiedBy");
		});

		modelBuilder.Entity<UserRole>(entity =>
		{
			entity.HasKey(e => e.UserRoleId).HasName("PK_UserRoleMapping");

			entity.ToTable("UserRole");

			entity.Property(e => e.UserRoleId)
				.ValueGeneratedNever()
				.HasColumnName("UserRoleID");
			entity.Property(e => e.RoleId).HasColumnName("RoleID");
			entity.Property(e => e.UserId).HasColumnName("UserID");

			entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
				.HasForeignKey(d => d.RoleId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_UserRole_Role");

			entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_UserRole_User");
		});

		modelBuilder.Entity<UserSeries>(entity =>
		{
			entity.Property(e => e.UserSeriesId)
				.ValueGeneratedNever()
				.HasColumnName("UserSeriesID");
			entity.Property(e => e.SeriesId).HasColumnName("SeriesID");
			entity.Property(e => e.UserId).HasColumnName("UserID");

			entity.HasOne(d => d.Series).WithMany(p => p.UserSeries)
				.HasForeignKey(d => d.SeriesId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_UserSeries_Series");

			entity.HasOne(d => d.User).WithMany(p => p.UserSeries)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_UserSeries_User");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
