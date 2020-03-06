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
using System.Linq;
using EvenCart.Core.Data;
using EvenCart.Core.Services;
using EvenCart.Data.Entity.Pages;

namespace EvenCart.Services.Pages
{
    public class SeoMetaService : FoundationEntityService<SeoMeta>, ISeoMetaService
    {
        public SeoMeta GetForEntity<T>(int entityId) where T : FoundationEntity
        {
            var entityName = typeof(T).Name;
            return Repository.Where(x => x.EntityName == entityName && x.EntityId == entityId).SelectSingle();
        }

        public IList<SeoMeta> Search(string slug, string languageCultureCode = "en-US")
        {
            return Repository.Where(x => x.Slug == slug && x.LanguageCultureCode == languageCultureCode)
                .Select()
                .ToList();
        }
    }
}