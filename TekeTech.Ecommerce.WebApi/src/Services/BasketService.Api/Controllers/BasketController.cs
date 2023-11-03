using BasketService.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BasketService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : Controller
    {
        private readonly DatabaseContext _dbContext;

        public BasketController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("AddToBasket")]
        public IActionResult AddToBasket([FromBody] Basket basket)
        {
            // Add the product to the basket
            _dbContext.Basket.Add(basket);
            _dbContext.SaveChanges();
            return Ok("Product added to the basket.");
        }

        [HttpPut("UpdateBasket/{id}")]
        public IActionResult UpdateBasket(int id, [FromBody] Basket updatedBasket)
        {
            // Find the existing basket item
            var existingBasket = _dbContext.Basket.FirstOrDefault(b => b.Id == id);

            if (existingBasket == null)
            {
                return NotFound("Basket item not found.");
            }

            // Update the quantity or other properties as needed
            existingBasket.Quantity = updatedBasket.Quantity;
            _dbContext.SaveChanges();
            return Ok("Basket item updated.");
        }

        [HttpDelete("DeleteFromBasket/{id}")]
        public IActionResult DeleteFromBasket(int id)
        {
            var basketItem = _dbContext.Basket.FirstOrDefault(b => b.Id == id);

            if (basketItem == null)
            {
                return NotFound("Basket item not found.");
            }

            _dbContext.Basket.Remove(basketItem);
            _dbContext.SaveChanges();
            return Ok("Basket item deleted.");
        }

        [HttpGet("GetAllInBasketByCustomerID/{customerID}")]
        public IActionResult GetAllInBasketByCustomerID(string customerID)
        {
            var basketItems = _dbContext.Basket
                .Include(b => b.Product)
                .ThenInclude(p => p.ProductMedia)
                .ThenInclude(pm => pm.Media) // Include Media
                .Where(b => b.CustomerID == customerID)
                .ToList();

            if (basketItems == null || basketItems.Count == 0)
            {
                return NotFound("No items found in the basket.");
            }

            var result = basketItems.Select(basket =>
                new
                {
                    Medias = basket.Product.ProductMedia.Select(pm => pm.Media.MediaURL).ToList(),
                    basket.ProductID,
                    basket.Product.ProductName,
                    basket.Product.Price,
                    basket.Quantity
                });

            return Ok(result);
        }
    }
}
