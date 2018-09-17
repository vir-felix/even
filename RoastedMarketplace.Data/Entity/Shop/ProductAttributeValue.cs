﻿using RoastedMarketplace.Core.Data;

namespace RoastedMarketplace.Data.Entity.Shop
{
    public class ProductAttributeValue : FoundationEntity
    {
        public int ProductAttributeId { get; set; }

        public int AvailableAttributeValueId { get; set; }

        public string Label { get; set; }

        #region Virtual Properties
        public virtual AvailableAttributeValue AvailableAttributeValue {get; set; }
        #endregion
    }
}