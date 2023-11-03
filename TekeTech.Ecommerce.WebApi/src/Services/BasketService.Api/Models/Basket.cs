
using BasketService.Api.Models;

namespace BasketService.Api
{
    public class Basket
    {
        public int Id { get; set; }
        public string CustomerID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public bool IsBought { get; set; }

        public virtual Product? Product { get; set; }
        public virtual CustomerInfo? Customer { get; set; }
    }
}

