using Microsoft.EntityFrameworkCore;
using FashionEcommerce.Api.Models;
using FashionEcommerce.Models;

namespace FashionEcommerce.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Users
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresseses { get; set; }

        // Products
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<MasterColor> MasterColors { get; set; }
        public DbSet<MasterSize> MasterSizes { get; set; }

        // Orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
 
        // Cart
        public DbSet<CartItem> CartItems { get; set; }

        // Reviews
        public DbSet<ProductReview> ProductReviews { get; set; }

        // Promotions
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionCondition> PromotionConditions { get; set; }
        public DbSet<ProductPromotion> ProductPromotions { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
       
        //Article
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        
        //Notifications
        public DbSet<Notification> Notifications { get; set; }

    }
}