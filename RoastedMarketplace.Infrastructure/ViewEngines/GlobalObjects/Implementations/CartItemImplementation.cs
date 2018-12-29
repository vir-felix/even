﻿using RoastedMarketplace.Infrastructure.Mvc.Models;

namespace RoastedMarketplace.Infrastructure.ViewEngines.GlobalObjects.Implementations
{
    public class CartItemImplementation : FoundationModel
    {
        public string ProductName { get; set; }

        public int ProductId { get; set; }

        public string AttributeText { get; set; }

        public decimal? ComparePrice { get; set; } // = 100

        public string ComparePriceFormatted => ComparePrice.ToCurrency();

        public decimal Price { get; set; } //= 80

        public string PriceFormatted => Price.ToCurrency();

        public int Quantity { get; set; }

        public decimal Tax { get; set; }

        public string TaxFormatted => Tax.ToCurrency();

        public decimal TaxPercent { get; set; }

        public decimal Discount { get; set; } //=10

        public string DiscountFormatted => Discount.ToCurrency();

        public decimal FinalPrice { get; set; } //=70

        public string FinalPriceFormatted => FinalPrice.ToCurrency();

        public string ImageUrl { get; set; }

        public string Slug { get; set; }

        public decimal SubTotal { get; set; }

        public string SubTotalFormatted => SubTotal.ToCurrency();

        public int Id { get; set; }
    }
}