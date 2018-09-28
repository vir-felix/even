﻿using RoastedMarketplace.Core.Services;
using RoastedMarketplace.Data.Entity.MediaEntities;

namespace RoastedMarketplace.Services.MediaServices
{
    public class MediaService : FoundationEntityService<Media>, IMediaService
    {
        private readonly IProductMediaService _productMediaService;
        public MediaService(IProductMediaService productMediaService)
        {
            _productMediaService = productMediaService;
        }

        public override void Delete(Media entity, Transaction transaction = null)
        {
            //delete the product media
            _productMediaService.Delete(x => x.MediaId == entity.Id, transaction);
            //proceed with usual deletion
            base.Delete(entity, transaction);
        }
    }
}