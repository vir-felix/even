﻿using RoastedMarketplace.Infrastructure.Mvc.Models;

namespace RoastedMarketplace.Models.Shipments
{
    public class ShipmentItemModel : FoundationModel
    {
        public int OrderItemId { get; set; }

        public int Quantity { get; set; }

        public string ProductName { get; set; }

        public string AttributeText { get; set; }

        public int OrderedQuantity { get; set; }

        public int ShippedQuantity { get; set; }
    }
}