using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Api.Models
{
    namespace BasketService.Api.Models
    {
        public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string Brand { get; set; }
            public float Price { get; set; }
            public int ShipmentDay { get; set; }
            public string Features { get; set; }
            public string Sizes { get; set; }
            public int Inventory { get; set; }
            public string SellerName { get; set; }
            public string City { get; set; }
            public string MarketPlace { get; set; }
            public string ProductURL { get; set; }
            public int CategoryId { get; set; }
            public virtual List<ProductMedia> ProductMedia { get; internal set; }
            public virtual List<ProductReview> ProductReview { get; internal set; }
            public virtual List<ProductCampaign> ProductCampaign { get; internal set; }
        }

        public class Category
        {
            public int CategoryId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int? ParentCategoryId { get; set; }


        }

        public class ProductMedia
        {
            public int ProductMediaId { get; set; }
            public int ProductId { get; set; }
            public int MediaId { get; set; }

            public virtual Media Media { get; internal set; }
            public virtual Product Product { get; set; }
        }

        public class Media
        {
            public int MediaId { get; set; }
            public string MediaURL { get; set; }

        }

        public class ProductReview
        {
            public int ProductReviewId { get; set; }
            public int ProductId { get; set; }
            public int ReviewId { get; set; }

            public virtual Product Product { get; set; }
            public virtual Review Review { get; set; }
        }

        public class Review
        {
            public int ReviewId { get; set; }
            public string Content { get; set; }
            public int Rating { get; set; }
        }

        public class ProductCampaign
        {
            public int ProductCampaignId { get; set; }
            public int ProductId { get; set; }
            public int CampaignId { get; set; }

            public virtual Product Product { get; set; }
            public virtual Campaign Campaign { get; set; }
        }

        public class Campaign
        {
            public int CampaignId { get; set; }
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public float DiscountRate { get; set; }
        }
    }

}
