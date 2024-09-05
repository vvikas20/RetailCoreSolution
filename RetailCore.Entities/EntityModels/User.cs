using System;
using System.Collections.Generic;

namespace RetailCore.Entities.EntityModels;

public partial class User
{
    public Guid UserId { get; set; }

    public string Username { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public Guid? RoleId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Address> AddressCreatedByNavigations { get; set; } = new List<Address>();

    public virtual ICollection<Address> AddressModifiedByNavigations { get; set; } = new List<Address>();

    public virtual ICollection<Address> AddressUsers { get; set; } = new List<Address>();

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ICollection<Cart> CartCreatedByNavigations { get; set; } = new List<Cart>();

    public virtual ICollection<CartItem> CartItemCreatedByNavigations { get; set; } = new List<CartItem>();

    public virtual ICollection<CartItem> CartItemModifiedByNavigations { get; set; } = new List<CartItem>();

    public virtual ICollection<Cart> CartModifiedByNavigations { get; set; } = new List<Cart>();

    public virtual ICollection<Cart> CartUsers { get; set; } = new List<Cart>();

    public virtual ICollection<Coupon> CouponCreatedByNavigations { get; set; } = new List<Coupon>();

    public virtual ICollection<Coupon> CouponModifiedByNavigations { get; set; } = new List<Coupon>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<User> InverseCreatedByNavigation { get; set; } = new List<User>();

    public virtual ICollection<User> InverseModifiedByNavigation { get; set; } = new List<User>();

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<OnlinePayment> OnlinePaymentCreatedByNavigations { get; set; } = new List<OnlinePayment>();

    public virtual ICollection<OnlinePayment> OnlinePaymentModifiedByNavigations { get; set; } = new List<OnlinePayment>();

    public virtual ICollection<Order> OrderCreatedByNavigations { get; set; } = new List<Order>();

    public virtual ICollection<OrderItem> OrderItemCreatedByNavigations { get; set; } = new List<OrderItem>();

    public virtual ICollection<OrderItem> OrderItemModifiedByNavigations { get; set; } = new List<OrderItem>();

    public virtual ICollection<Order> OrderModifiedByNavigations { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderUsers { get; set; } = new List<Order>();

    public virtual ICollection<PaymentMethod> PaymentMethodCreatedByNavigations { get; set; } = new List<PaymentMethod>();

    public virtual ICollection<PaymentMethod> PaymentMethodModifiedByNavigations { get; set; } = new List<PaymentMethod>();

    public virtual ICollection<Permission> PermissionCreatedByNavigations { get; set; } = new List<Permission>();

    public virtual ICollection<Permission> PermissionModifiedByNavigations { get; set; } = new List<Permission>();

    public virtual ICollection<PermissionType> PermissionTypeCreatedByNavigations { get; set; } = new List<PermissionType>();

    public virtual ICollection<PermissionType> PermissionTypeModifiedByNavigations { get; set; } = new List<PermissionType>();

    public virtual ICollection<ProductAttribute> ProductAttributeCreatedByNavigations { get; set; } = new List<ProductAttribute>();

    public virtual ICollection<ProductAttributeMapping> ProductAttributeMappingCreatedByNavigations { get; set; } = new List<ProductAttributeMapping>();

    public virtual ICollection<ProductAttributeMapping> ProductAttributeMappingModifiedByNavigations { get; set; } = new List<ProductAttributeMapping>();

    public virtual ICollection<ProductAttribute> ProductAttributeModifiedByNavigations { get; set; } = new List<ProductAttribute>();

    public virtual ICollection<ProductCategory> ProductCategoryCreatedByNavigations { get; set; } = new List<ProductCategory>();

    public virtual ICollection<ProductCategory> ProductCategoryModifiedByNavigations { get; set; } = new List<ProductCategory>();

    public virtual ICollection<Product> ProductCreatedByNavigations { get; set; } = new List<Product>();

    public virtual ICollection<ProductImage> ProductImageCreatedByNavigations { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductImage> ProductImageModifiedByNavigations { get; set; } = new List<ProductImage>();

    public virtual ICollection<Product> ProductModifiedByNavigations { get; set; } = new List<Product>();

    public virtual ICollection<ProductReview> ProductReviewCreatedByNavigations { get; set; } = new List<ProductReview>();

    public virtual ICollection<ProductReview> ProductReviewModifiedByNavigations { get; set; } = new List<ProductReview>();

    public virtual ICollection<ProductTag> ProductTagCreatedByNavigations { get; set; } = new List<ProductTag>();

    public virtual ICollection<ProductTagMapping> ProductTagMappingCreatedByNavigations { get; set; } = new List<ProductTagMapping>();

    public virtual ICollection<ProductTagMapping> ProductTagMappingModifiedByNavigations { get; set; } = new List<ProductTagMapping>();

    public virtual ICollection<ProductTag> ProductTagModifiedByNavigations { get; set; } = new List<ProductTag>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Role> RoleCreatedByNavigations { get; set; } = new List<Role>();

    public virtual ICollection<RoleLevel> RoleLevelCreatedByNavigations { get; set; } = new List<RoleLevel>();

    public virtual ICollection<RoleLevel> RoleLevelModifiedByNavigations { get; set; } = new List<RoleLevel>();

    public virtual ICollection<Role> RoleModifiedByNavigations { get; set; } = new List<Role>();

    public virtual ICollection<RolePermission> RolePermissionCreatedByNavigations { get; set; } = new List<RolePermission>();

    public virtual ICollection<RolePermission> RolePermissionModifiedByNavigations { get; set; } = new List<RolePermission>();

    public virtual ICollection<Shipping> ShippingCreatedByNavigations { get; set; } = new List<Shipping>();

    public virtual ICollection<Shipping> ShippingModifiedByNavigations { get; set; } = new List<Shipping>();

    public virtual ICollection<Wishlist> WishlistCreatedByNavigations { get; set; } = new List<Wishlist>();

    public virtual ICollection<Wishlist> WishlistModifiedByNavigations { get; set; } = new List<Wishlist>();

    public virtual ICollection<WishlistProduct> WishlistProductCreatedByNavigations { get; set; } = new List<WishlistProduct>();

    public virtual ICollection<WishlistProduct> WishlistProductModifiedByNavigations { get; set; } = new List<WishlistProduct>();

    public virtual ICollection<Wishlist> WishlistUsers { get; set; } = new List<Wishlist>();
}
