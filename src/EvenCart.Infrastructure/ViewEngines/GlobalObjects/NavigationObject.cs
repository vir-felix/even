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
using EvenCart.Core.Caching;
using EvenCart.Core.Infrastructure;
using EvenCart.Data.Entity.Navigation;
using EvenCart.Data.Entity.Settings;
using EvenCart.Data.Entity.Shop;
using EvenCart.Services.Navigation;
using EvenCart.Services.Products;
using EvenCart.Infrastructure.Helpers;
using EvenCart.Infrastructure.ViewEngines.GlobalObjects.Implementations;

namespace EvenCart.Infrastructure.ViewEngines.GlobalObjects
{
    public class NavigationObject : GlobalObject
    {
        public override object GetObject()
        {
            var generalSettings = DependencyResolver.Resolve<GeneralSettings>();
            if (generalSettings.PrimaryNavigationId <= 0)
                return null;

            var menuService = DependencyResolver.Resolve<IMenuService>();
            var categoryService = DependencyResolver.Resolve<ICategoryService>();
            var menu = menuService.Get(generalSettings.PrimaryNavigationId);
            if (menu == null)
                return null;
            var allCategories = categoryService.GetFullCategoryTree();
            return GetNavigation(menu.MenuItems, "PRIMARY_NAVIGATION", allCategories);
        }

        public static IList<NavigationImplementation> GetNavigation(IList<MenuItem> menuItems, string navigationName, IList<Category> categories)
        {
            var cacheProvider = DependencyResolver.Resolve<ICacheProvider>();
            var cacheKey = $"NAVIGATION_{navigationName}";
            return cacheProvider.Get(cacheKey, () => GetNavigationImpl(menuItems, 0, categories));
        }
        ///Making this method static so we can use the same method in MenuWidget.
        /// todo: is there a better way of doing this? may be move this to a helper function
        private static IList<NavigationImplementation> GetNavigationImpl(IList<MenuItem> menuItems, int parentMenuItemId, IList<Category> categories)
        {
            if (menuItems == null)
                return null;
            var navigation = new List<NavigationImplementation>();
            foreach (var menuItem in menuItems.Where(x => x.ParentId == parentMenuItemId))
            {
                if (parentMenuItemId == 0 && menuItem.IsGroup)
                    continue;

                var url = menuItem.SeoMeta == null ? menuItem.Url : null;
                if (url == null && menuItem.SeoMeta != null)
                {
                    url = SeoMetaHelper.GetUrl(menuItem.SeoMeta);
                }
               
                var title = menuItem.Name;
                var navigationItem = new NavigationImplementation
                {
                    Url = url,
                    Title = title,
                    IsGroup = menuItem.IsGroup,
                    Css = menuItem.CssClass,
                    Children = GetNavigationImpl(menuItems, menuItem.Id, categories) ??
                               new List<NavigationImplementation>(),
                    Id = menuItem.Id,
                    OpenInNewWindow = menuItem.OpenInNewWindow,
                    Description = menuItem.Description,
                    ExtraData = menuItem.ExtraData
                };
                navigation.Add(navigationItem);
            }
            return navigation;
        }

        public override bool RenderInAdmin => false;

        public override bool RenderInPublic => true;
    }
}