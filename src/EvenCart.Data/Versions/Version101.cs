﻿using DotEntity;
using DotEntity.Versioning;
using EvenCart.Data.Entity.Purchases;
using EvenCart.Data.Entity.Shop;
using Db = DotEntity.DotEntity.Database;
namespace EvenCart.Data.Versions
{
    public class Version101 : IDatabaseVersion
    {
        public void Upgrade(IDotEntityTransaction transaction)
        {
            Db.AddColumn<OrderItem, ProductSaleType>(nameof(OrderItem.ProductSaleType), ProductSaleType.OneTime, transaction);
            Db.AddColumn<OrderItem, TimeCycle>(nameof(OrderItem.SubscriptionCycle), TimeCycle.Yearly, transaction);
            Db.AddColumn<OrderItem, int>(nameof(OrderItem.CycleCount), 99, transaction);
            Db.AddColumn<OrderItem, int?>(nameof(OrderItem.TrialDays), 0, transaction);
        }

        public void Downgrade(IDotEntityTransaction transaction)
        {
            //do nothing
        }

        public string VersionKey => "EvenCart.Data.Versions.Version1_0_1";
    }

}