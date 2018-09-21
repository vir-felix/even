﻿using System;
using System.Linq.Expressions;
using RoastedMarketplace.Core.Services;
using RoastedMarketplace.Data.Entity.Promotions;

namespace RoastedMarketplace.Services.Promotions
{
    public class DiscountCouponService : FoundationEntityService<DiscountCoupon>, IDiscountCouponService
    {
        public override DiscountCoupon Get(int id)
        {
            return GetByWhere(x => x.Id == id);
        }

        public DiscountCoupon GetByCouponCode(string couponCode)
        {
            couponCode = couponCode.ToLower();
            return GetByWhere(x => x.CouponCode == couponCode);
        }

        private DiscountCoupon GetByWhere(Expression<Func<DiscountCoupon, bool>> where)
        {
            return Repository.Where(where)
                .SelectSingle();
        }

        public override void Insert(DiscountCoupon entity, Transaction transaction = null)
        {
            //always save in lower case
            entity.CouponCode = entity.CouponCode.ToLower();
            base.Insert(entity, transaction);
        }

        public override void Update(DiscountCoupon entity, Transaction transaction = null)
        {
            //always save in lower case
            entity.CouponCode = entity.CouponCode.ToLower();
            base.Update(entity, transaction);
        }
    }
}