﻿#region License
// Copyright (c) Sojatia Infocrafts Private Limited.
// The following code is part of EvenCart eCommerce Software (https://evencart.co) Dual Licensed under the terms of
// 
// 1. GNU GPLv3 with additional terms (available to read at https://evencart.co/license)
// 2. EvenCart Proprietary License (available to read at https://evencart.co/license/commercial-license).
// 
// You can select one of the above two licenses according to your requirements. The usage of this code is
// subject to the terms of the license chosen by you.
#endregion

namespace EvenCart.Areas.Administration.Models.Settings
{
    public class TaxSettingsModel : SettingsModel
    {
        public decimal DefaultTaxRate { get; set; }

        public bool PricesIncludeTax { get; set; }

        public bool DisplayProductPricesWithoutTax { get; set; }

        public bool ChargeTaxOnShipping { get; set; }

        public bool ShippingPricesIncludeTax { get; set; }

        public int? ShippingTaxId { get; set; } = 0;
    }
}