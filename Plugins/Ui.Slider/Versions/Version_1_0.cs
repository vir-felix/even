﻿using DotEntity;
using DotEntity.Versioning;
using RoastedMarketplace.Data.Entity.MediaEntities;
using Ui.Slider.Data;
using Db = DotEntity.DotEntity.Database;
namespace Ui.Slider.Versions
{
    public class Version_1_0 : IDatabaseVersion
    {
        public void Upgrade(IDotEntityTransaction transaction)
        {
            Db.CreateTable<UiSlider>(transaction);
            Db.CreateConstraint(Relation.Create<Media, UiSlider>("Id", "MediaId"), transaction, true);
        }

        public void Downgrade(IDotEntityTransaction transaction)
        {
            Db.DropTable<UiSlider>(transaction);
            Db.DropConstraint(Relation.Create<Media, UiSlider>("Id", "MediaId"), transaction);
        }

        public string VersionKey { get; } = "Ui.Slider.Versions.Version_1_0";
    }
}