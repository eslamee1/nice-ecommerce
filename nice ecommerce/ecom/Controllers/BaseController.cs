using ecom.Data;
using ecom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ecom.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public BaseController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Layout()
        {
            var topLevelCategories = _context.Categories
                .FromSqlRaw("EXEC GetTopLevelCategories")
                .Select(c => new { c.CategoryId, c.CategoryName })
                .ToList();

            ViewBag.ParentCategories = topLevelCategories;
            return View();
        }

        protected async Task<IActionResult> AddToCartAsync(int productId)
        {
            // Retrieve the product from the database
            var product = await _context.Products
                .Where(p => p.ProductId == productId)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            // Get the current user ID
            var userId = User.Identity.IsAuthenticated ? User.Identity.Name : null;

            if (userId == null)
            {
                return Unauthorized();
            }

            // Retrieve or create the shopping cart for the user
            var cart = await _context.ShoppingCarts
                .Include(sc => sc.ShoppingCartItems)
                .FirstOrDefaultAsync(sc => sc.UserId == userId);

            if (cart == null)
            {
                cart = new ShoppingCart
                {
                    UserId = userId,
                    ShoppingCartItems = new List<ShoppingCartItem>()
                };
                _context.ShoppingCarts.Add(cart);
            }

            // Add the product to the cart
            var existingItem = cart.ShoppingCartItems
                .FirstOrDefault(i => i.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.ShoppingCartItems.Add(new ShoppingCartItem
                {
                    ProductId = productId,
                    Quantity = 1,
                    Cart = cart,
                    Product = product
                });
            }

            await _context.SaveChangesAsync();

            // Redirect to the cart view or another appropriate action
            return RedirectToAction("Index", "Cart");
        }
    }
}
