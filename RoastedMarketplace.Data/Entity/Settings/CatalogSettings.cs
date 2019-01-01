﻿using RoastedMarketplace.Core.Config;
using RoastedMarketplace.Data.Enum;

namespace RoastedMarketplace.Data.Entity.Settings
{
    public class CatalogSettings : ISettingGroup
    {
        public bool DisplayProductsFromChildCategories { get; set; }

        public int NumberOfProductsPerPage { get; set; }

        public CatalogPaginationType CatalogPaginationType { get; set; }

        public bool DisplaySortOptions { get; set; }

        public bool EnableWishlist { get; set; }
    }
}