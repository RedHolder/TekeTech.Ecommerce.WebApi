using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.Api.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductListController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ProductListController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            int category,
            int pi = 1,
            string brand = null,
            float? LP = null,
            float? HP = null)
        {
            int pageSize = 20; // Sayfa başına ürün sayısı
            int skipCount = (pi - 1) * pageSize;

            var query = _context.Products
                 // Kategori bilgisini al
                .Where(p => (category > 0) || p.CategoryId == category)
                .Where(p => string.IsNullOrEmpty(brand) || p.Brand == brand)
                .Where(p => (!LP.HasValue || p.Price >= LP.Value) && (!HP.HasValue || p.Price <= HP.Value))
                .OrderBy(p => p.ProductId)
                .Skip(skipCount)
                .Take(pageSize);

            var products = await query.ToListAsync();

            // ProductMedia ilişkisini çöz
            foreach (var product in products)
            {
                int i = 2;
                product.ProductMedia = _context.ProductMedias
                    .Where(pm => pm.ProductId == product.ProductId)
                    .ToList();
            }

            // ProductReview ilişkisini çöz
            foreach (var product in products)
            {
                product.ProductReview = _context.ProductReviews
                    .Where(pr => pr.ProductId == product.ProductId)
                    .ToList();
            }

            // ProductCampaign ilişkisini çöz
            foreach (var product in products)
            {
                product.ProductCampaign = _context.ProductCampaigns
                    .Where(pc => pc.ProductId == product.ProductId)
                    .ToList();
            }

            return Ok(products);
        }

    }
}
