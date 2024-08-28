using ecom.Models;
using ecom.Models.Comments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ecom.Models;

namespace ecom.Data
{
	public class ApplicationDbContext : IdentityDbContext<AppUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
		{
		}

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Discount> Discounts { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<ShippingDetail> ShippingDetails { get; set; }

        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


        public virtual DbSet<VwOrderDetail> VwOrderDetails { get; set; }


        public virtual DbSet<VwShoppingCartDetail> VwShoppingCartDetails { get; set; }

        public virtual DbSet<VwUserOrderHistory> VwUserOrderHistories { get; set; }

        public virtual DbSet<VwWishlistDetail> VwWishlistDetails { get; set; }

        public virtual DbSet<Wishlist> Wishlists { get; set; }

        public virtual DbSet<WishlistItem> WishlistItems { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
		public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<AppUser> ApplicationUsers { get; set; }

        public virtual DbSet<MainComment> MainComments { get; set; }
		public virtual DbSet<SubComment> SubComments { get; set; }
		public virtual DbSet<MyMessage> MyMessages { get; set; }
              
        public virtual DbSet<TodoList> TodoLists { get; set; }


    }
}
