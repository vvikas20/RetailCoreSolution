using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RetailCore.Entities.EntityModels;
using RetailCore.Persistance.Context;

namespace RetailCore.Persistance.Context;

public partial class RetailCoreContext : BaseDBContext
{
    public RetailCoreContext()
    {
    }

    public RetailCoreContext(DbContextOptions<RetailCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<OnlinePayment> OnlinePayments { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PermissionType> PermissionTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

    public virtual DbSet<ProductAttributeMapping> ProductAttributeMappings { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductReview> ProductReviews { get; set; }

    public virtual DbSet<ProductTag> ProductTags { get; set; }

    public virtual DbSet<ProductTagMapping> ProductTagMappings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleLevel> RoleLevels { get; set; }

    public virtual DbSet<RoleLevelPermissionTypeMapping> RoleLevelPermissionTypeMappings { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<Shipping> Shippings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wishlist> Wishlists { get; set; }

    public virtual DbSet<WishlistProduct> WishlistProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=2212VIKASS0000L\\MSSQLSERVER2019;Initial Catalog=RetailCore;Persist Security Info=True;User ID=sa;Password=Microsoft#1234;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Address__091C2AFB447356EA");

            entity.ToTable("Address");

            entity.Property(e => e.AddressId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PostalCode).HasMaxLength(20);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.StreetAddress).HasMaxLength(255);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AddressCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Address__Created__06CD04F7");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.AddressModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Address__Modifie__07C12930");

            entity.HasOne(d => d.User).WithMany(p => p.AddressUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Address__UserId__03F0984C");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.AuditLogId).HasName("PK__AuditLog__EB5F6CBD3B6CB04F");

            entity.ToTable("AuditLog");

            entity.Property(e => e.AuditLogId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Action).HasMaxLength(20);
            entity.Property(e => e.ActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TableName).HasMaxLength(100);

            entity.HasOne(d => d.ActionedByNavigation).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.ActionedBy)
                .HasConstraintName("FK__AuditLog__Action__607251E5");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD7B7AFF49FC9");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CartCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Cart__CreatedBy__2EDAF651");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.CartModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Cart__ModifiedBy__2FCF1A8A");

            entity.HasOne(d => d.User).WithMany(p => p.CartUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Cart__UserId__2CF2ADDF");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__CartItem__488B0B0A6C81FB6E");

            entity.ToTable("CartItem");

            entity.Property(e => e.CartItemId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK__CartItem__CartId__339FAB6E");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CartItemCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__CartItem__Create__367C1819");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.CartItemModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__CartItem__Modifi__37703C52");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__CartItem__Produc__3493CFA7");
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.CouponId).HasName("PK__Coupon__384AF1BA0C510D93");

            entity.ToTable("Coupon");

            entity.Property(e => e.CouponId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CouponCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Coupon__CreatedB__531856C7");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.CouponModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Coupon__Modified__540C7B00");
        });

        modelBuilder.Entity<OnlinePayment>(entity =>
        {
            entity.HasKey(e => e.OnlinePaymentId).HasName("PK__OnlinePa__029C2CC081CD3140");

            entity.ToTable("OnlinePayment");

            entity.Property(e => e.OnlinePaymentId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(100);
            entity.Property(e => e.TransactionStatus).HasMaxLength(50);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.OnlinePaymentCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__OnlinePay__Creat__45BE5BA9");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.OnlinePaymentModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__OnlinePay__Modif__46B27FE2");

            entity.HasOne(d => d.Order).WithMany(p => p.OnlinePayments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OnlinePay__Order__42E1EEFE");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCFAFC534DA");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ShippingCost)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.OrderCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Order__CreatedBy__123EB7A3");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.OrderModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Order__ModifiedB__1332DBDC");

            entity.HasOne(d => d.ShippingAddress).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShippingAddressId)
                .HasConstraintName("FK__Order__ShippingA__0D7A0286");

            entity.HasOne(d => d.User).WithMany(p => p.OrderUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Order__UserId__0B91BA14");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED06816028D812");

            entity.ToTable("OrderItem");

            entity.Property(e => e.OrderItemId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.OrderItemCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__OrderItem__Creat__19DFD96B");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.OrderItemModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__OrderItem__Modif__1AD3FDA4");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__17036CC0");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderItem__Produ__17F790F9");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("PK__PaymentM__DC31C1D3356376FD");

            entity.ToTable("PaymentMethod");

            entity.Property(e => e.PaymentMethodId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MethodName).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PaymentMethodCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__PaymentMe__Creat__4C6B5938");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.PaymentMethodModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__PaymentMe__Modif__4D5F7D71");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__Permissi__EFA6FB2F9628D209");

            entity.ToTable("Permission");

            entity.Property(e => e.PermissionId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PermissionDisplayName).HasMaxLength(100);
            entity.Property(e => e.PermissionName).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermissionCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Permissio__Creat__778AC167");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.PermissionModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Permissio__Modif__787EE5A0");

            entity.HasOne(d => d.PermissionType).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.PermissionTypeId)
                .HasConstraintName("FK__Permissio__Permi__74AE54BC");
        });

        modelBuilder.Entity<PermissionType>(entity =>
        {
            entity.HasKey(e => e.PermissionTypeId).HasName("PK__Permissi__53B420CFC5C14DF9");

            entity.ToTable("PermissionType");

            entity.Property(e => e.PermissionTypeId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.TypeName).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermissionTypeCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Permissio__Creat__6FE99F9F");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.PermissionTypeModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Permissio__Modif__70DDC3D8");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CDB0C3B68C");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Product__Categor__412EB0B6");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProductCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Product__Created__440B1D61");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ProductModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Product__Modifie__44FF419A");
        });

        modelBuilder.Entity<ProductAttribute>(entity =>
        {
            entity.HasKey(e => e.ProductAttributeId).HasName("PK__ProductA__00CE674780503E12");

            entity.ToTable("ProductAttribute");

            entity.Property(e => e.ProductAttributeId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AttributeName).HasMaxLength(100);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProductAttributeCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__ProductAt__Creat__35BCFE0A");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ProductAttributeModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__ProductAt__Modif__36B12243");
        });

        modelBuilder.Entity<ProductAttributeMapping>(entity =>
        {
            entity.HasKey(e => e.ProductAttributeMappingId).HasName("PK__ProductA__8064B0BB502E458A");

            entity.ToTable("ProductAttributeMapping");

            entity.Property(e => e.ProductAttributeMappingId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProductAttributeMappingCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__ProductAt__Creat__4BAC3F29");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ProductAttributeMappingModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__ProductAt__Modif__4CA06362");

            entity.HasOne(d => d.ProductAttribute).WithMany(p => p.ProductAttributeMappings)
                .HasForeignKey(d => d.ProductAttributeId)
                .HasConstraintName("FK__ProductAt__Produ__49C3F6B7");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductAttributeMappings)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductAt__Produ__48CFD27E");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK__ProductC__3224ECCED9284E7B");

            entity.ToTable("ProductCategory");

            entity.Property(e => e.ProductCategoryId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProductCategoryCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__ProductCa__Creat__2F10007B");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ProductCategoryModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__ProductCa__Modif__300424B4");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.ProductImageId).HasName("PK__ProductI__07B2B1B8DBF12CA4");

            entity.ToTable("ProductImage");

            entity.Property(e => e.ProductImageId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
            entity.Property(e => e.IsPrimary).HasDefaultValue(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProductImageCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__ProductIm__Creat__5AB9788F");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ProductImageModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__ProductIm__Modif__5BAD9CC8");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductIm__Produ__57DD0BE4");
        });

        modelBuilder.Entity<ProductReview>(entity =>
        {
            entity.HasKey(e => e.ProductReviewId).HasName("PK__ProductR__3963188057C23BB8");

            entity.ToTable("ProductReview");

            entity.Property(e => e.ProductReviewId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProductReviewCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__ProductRe__Creat__5AEE82B9");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ProductReviewModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__ProductRe__Modif__5BE2A6F2");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductRe__Produ__5812160E");
        });

        modelBuilder.Entity<ProductTag>(entity =>
        {
            entity.HasKey(e => e.ProductTagId).HasName("PK__ProductT__88A7F34AFA756052");

            entity.ToTable("ProductTag");

            entity.Property(e => e.ProductTagId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.TagName).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProductTagCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__ProductTa__Creat__3C69FB99");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ProductTagModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__ProductTa__Modif__3D5E1FD2");
        });

        modelBuilder.Entity<ProductTagMapping>(entity =>
        {
            entity.HasKey(e => e.ProductTagMappingId).HasName("PK__ProductT__1D35E4D7DD86763D");

            entity.ToTable("ProductTagMapping");

            entity.Property(e => e.ProductTagMappingId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProductTagMappingCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__ProductTa__Creat__534D60F1");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ProductTagMappingModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__ProductTa__Modif__5441852A");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductTagMappings)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductTa__Produ__5070F446");

            entity.HasOne(d => d.ProductTag).WithMany(p => p.ProductTagMappings)
                .HasForeignKey(d => d.ProductTagId)
                .HasConstraintName("FK__ProductTa__Produ__5165187F");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1A77049EDD");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.RoleName).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RoleCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Role__CreatedBy__693CA210");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.RoleModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Role__ModifiedBy__6A30C649");

            entity.HasOne(d => d.RoleLevel).WithMany(p => p.Roles)
                .HasForeignKey(d => d.RoleLevelId)
                .HasConstraintName("FK__Role__RoleLevelI__66603565");
        });

        modelBuilder.Entity<RoleLevel>(entity =>
        {
            entity.HasKey(e => e.RoleLevelId).HasName("PK__RoleLeve__934E77C9ECE234A4");

            entity.ToTable("RoleLevel");

            entity.Property(e => e.RoleLevelId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.RoleLevel1).HasColumnName("RoleLevel");
            entity.Property(e => e.RoleLevelDisplayName).HasMaxLength(100);
            entity.Property(e => e.RoleLevelName).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RoleLevelCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__RoleLevel__Creat__619B8048");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.RoleLevelModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__RoleLevel__Modif__628FA481");
        });

        modelBuilder.Entity<RoleLevelPermissionTypeMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoleLeve__3214EC0709628675");

            entity.ToTable("RoleLevelPermissionTypeMapping");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RoleLevelPermissionTypeMappingCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__RoleLevel__Creat__7BE56230");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.RoleLevelPermissionTypeMappingModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__RoleLevel__Modif__7CD98669");

            entity.HasOne(d => d.PermissionType).WithMany(p => p.RoleLevelPermissionTypeMappings)
                .HasForeignKey(d => d.PermissionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RoleLevel__Permi__7AF13DF7");

            entity.HasOne(d => d.RoleLevel).WithMany(p => p.RoleLevelPermissionTypeMappings)
                .HasForeignKey(d => d.RoleLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RoleLevel__RoleL__79FD19BE");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.RolePermissionId).HasName("PK__RolePerm__120F46BAD3B53B92");

            entity.ToTable("RolePermission");

            entity.Property(e => e.RolePermissionId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RolePermissionCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__RolePermi__Creat__7F2BE32F");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.RolePermissionModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__RolePermi__Modif__00200768");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK__RolePermi__Permi__7D439ABD");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__RolePermi__RoleI__7C4F7684");
        });

        modelBuilder.Entity<Shipping>(entity =>
        {
            entity.HasKey(e => e.ShippingId).HasName("PK__Shipping__5FACD5807EEA6BFA");

            entity.ToTable("Shipping");

            entity.Property(e => e.ShippingId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Carrier).HasMaxLength(100);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ShipmentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TrackingNumber).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ShippingCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Shipping__Create__3E1D39E1");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ShippingModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Shipping__Modifi__3F115E1A");

            entity.HasOne(d => d.Order).WithMany(p => p.Shippings)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Shipping__OrderI__3B40CD36");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4CC3F47D81");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D105342178F36C").IsUnique();

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PasswordHash).HasMaxLength(512);
            entity.Property(e => e.PasswordSalt).HasMaxLength(512);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__User__CreatedBy__286302EC");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.InverseModifiedByNavigation)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__User__ModifiedBy__29572725");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__User__RoleId__2610A626");
        });

        modelBuilder.Entity<Wishlist>(entity =>
        {
            entity.HasKey(e => e.WishlistId).HasName("PK__Wishlist__233189EB10DC112F");

            entity.ToTable("Wishlist");

            entity.Property(e => e.WishlistId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WishlistCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Wishlist__Create__208CD6FA");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.WishlistModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Wishlist__Modifi__2180FB33");

            entity.HasOne(d => d.User).WithMany(p => p.WishlistUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Wishlist__UserId__1EA48E88");
        });

        modelBuilder.Entity<WishlistProduct>(entity =>
        {
            entity.HasKey(e => e.WishlistProductId).HasName("PK__Wishlist__56CBB39C53154D28");

            entity.ToTable("WishlistProduct");

            entity.Property(e => e.WishlistProductId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WishlistProductCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__WishlistP__Creat__282DF8C2");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.WishlistProductModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__WishlistP__Modif__29221CFB");

            entity.HasOne(d => d.Product).WithMany(p => p.WishlistProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__WishlistP__Produ__2645B050");

            entity.HasOne(d => d.Wishlist).WithMany(p => p.WishlistProducts)
                .HasForeignKey(d => d.WishlistId)
                .HasConstraintName("FK__WishlistP__Wishl__25518C17");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}