﻿using System;
using RoastedMarketplace.Core.Data;
using RoastedMarketplace.Data.Entity.Users;

namespace RoastedMarketplace.Data.Entity.Pages
{
    public class ContentPage : FoundationEntity, ISeoEntity
    {
        public string Name { get; set; }

        public int UserId { get; set; }

        public string Content { get; set; }

        public bool Published { get; set; }

        public bool Private { get; set; }

        public string Password { get; set; }

        public string SystemName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public DateTime PublishedOn { get; set; }

        #region Virtual Properties
        public virtual SeoMeta SeoMeta { get; set; }

        public virtual User User { get; set; }
        #endregion
    }
}