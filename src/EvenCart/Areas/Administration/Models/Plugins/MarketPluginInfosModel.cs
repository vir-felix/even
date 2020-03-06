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

using System.Collections.Generic;
using EvenCart.Infrastructure.Mvc.Models;

namespace EvenCart.Areas.Administration.Models.Plugins
{
    public class MarketPluginInfosModel : FoundationModel
    {
        public int Current { get; set; }

        public int RowCount { get; set; }

        public int Total { get; set; }

        public int RangeStart { get; set; }

        public int RangeEnd { get; set; }

        public bool Success { get; set; }

        public IList<MarketPluginInfoModel> Plugins { get; set; }
    }
}