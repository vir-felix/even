﻿using System;
using RoastedMarketplace.Core.Data;

namespace RoastedMarketplace.Data.Entity.Purchases
{
    public class ShipmentHistory : FoundationEntity
    {
        public int ShipmentId { get; set; }

        public ShipmentStatus ShipmentStatus { get; set; }

        public DateTime CreatedOn { get; set; }

        #region Virtual Properties
        public virtual Shipment Shipment { get; set; }
        #endregion
    }
}