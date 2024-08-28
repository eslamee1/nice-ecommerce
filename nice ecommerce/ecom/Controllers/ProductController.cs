using ecom.Data;
using ecom.Models;
using ecom.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecom.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private static IHttpContextAccessor httpContextAccessor;

        public ProductController(ApplicationDbContext context) : base(context,httpContextAccessor)
        {
            this._context = context;
        }


        public IActionResult Index(string searchQuery, int? parentCategoryId)
        {


            // Get all products by default
            var productsQuery = _context.Products.ToList();/*AsQueryable();*/

            // Apply search filter if a search query is provided
            //if (!string.IsNullOrEmpty(searchQuery))
            //{
            //    productsQuery = productsQuery.Where(p => p.ProductName.Contains(searchQuery)
            //                                          || p.Description.Contains(searchQuery));
            //}

            //Apply ParentCategory filter

            //if (parentCategoryId.HasValue)
            //{
            //    // Get all categories that are either the parent category or its subcategories
            //    var categoriesToInclude = _context.Categories
            //                                      .Where(c => c.ParentCategoryId == parentCategoryId.Value || c.CategoryId == parentCategoryId.Value)
            //                                      .Select(c => c.CategoryId)
            //                                      .ToList();

            //    productsQuery = productsQuery.Where(p => categoriesToInclude.Contains(p.CategoryId.Value));
            //}

            var productVMs = productsQuery
                .Select(p => new ProductVM
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    ImageUrl = _context.ProductImages
                        .Where(img => img.ProductId == p.ProductId)
                        .Select(img => img.ImageUrl)
                        .FirstOrDefault()
                })
                .ToList();

            // Pass the search query and parent category id to the view
            ViewBag.SearchQuery = searchQuery;
            ViewBag.ParentCategoryId = parentCategoryId;

            // Pass the parent categories to the view
            ViewBag.ParentCategories = _context.Categories
                                                .Where(c => c.ParentCategoryId == null && c.IsActive == true)
                                                .ToList();

            return View(productVMs);
        }


        //public IActionResult Index(string searchQuery, int? parentCategoryId)
        //{
        //    // Fetch products based on filters and search query
        //    var productsQuery = _context.Products.AsQueryable();

        //    if (!string.IsNullOrEmpty(searchQuery))
        //    {
        //        productsQuery = productsQuery.Where(p => p.ProductName.Contains(searchQuery)
        //                                                  || p.Description.Contains(searchQuery));
        //    }

        //    if (parentCategoryId.HasValue)
        //    {
        //        var categoriesToInclude = _context.Categories
        //            .Where(c => c.ParentCategoryId == parentCategoryId.Value || c.CategoryId == parentCategoryId.Value)
        //            .Select(c => c.CategoryId)
        //            .ToList();

        //        productsQuery = productsQuery.Where(p => categoriesToInclude.Contains(p.CategoryId.Value));
        //    }

        //    var productVMs = productsQuery
        //        .Select(p => new ProductVM
        //        {
        //            ProductId = p.ProductId,
        //            ProductName = p.ProductName,
        //            Price = p.Price,
        //            ImageUrl = _context.ProductImages
        //                .Where(img => img.ProductId == p.ProductId)
        //                .Select(img => img.ImageUrl)
        //                .FirstOrDefault()
        //        })
        //        .ToList();

        //    ViewBag.SearchQuery = searchQuery;
        //    ViewBag.ParentCategoryId = parentCategoryId;

        //    return View(productVMs);
        //}



        [Authorize]
        public IActionResult Details(int id)
        {
            var product = _context.Products
                .Where(p => p.ProductId == id)
                .Select(p => new ProductVM
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Description = p.Description,
                    ImageUrl = _context.ProductImages
                        .Where(pi => pi.ProductId == id)
                        .Select(pi => pi.ImageUrl)
                        .FirstOrDefault(),
                    StockQuantity = (int)p.Stock // Ensure this property is populated
                })
                .FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


    }
}
